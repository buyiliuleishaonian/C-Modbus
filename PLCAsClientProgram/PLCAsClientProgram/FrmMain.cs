using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wen.PLCAsClientProgram;

namespace PLCAsClientProgram
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private Socket tcpServer;

        private CancellationTokenSource cts;

        /// <summary>
        /// 接受和发送的数据
        /// </summary>
        private int sendCount = 100;
        private int recevieCount = 200;

        //发送给客户端的数据
        private byte[] recevie;

        //创建服务器的ip
        private const string ip = "192.168.125.10";

        //创建ip和端口号——socket的字典集合，用来接受，发送客户端数据
        private Dictionary<string,Socket> currentClient=new Dictionary<string,Socket>();

        //创建锁对象
        private static readonly object objLock = new object();
        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            //建立Socket对象
            tcpServer=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //创建Socket连接所需要的ip和端口号对象
            IPEndPoint ipAndPoint = new IPEndPoint(IPAddress.Parse(this.txt_IPAddress.Text.ToString())
                , Convert.ToInt32(this.txt_port.Text.ToString()));
            try
            {
                //让监听的socket绑定服务器的ip和端口号
                tcpServer.Bind(ipAndPoint);
                MessageBox.Show("连接成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败："+ex.Message);
            }
            //设定监听服务器的个数
            tcpServer.Listen(5);
            cts=new CancellationTokenSource();
            //通过后台线程来接受数据
            Task.Run(new Action(() =>
            {
                ListenData();
            }), cts.Token);
        }

        /// <summary>
        /// 启动监听，开启多线程处理数据
        /// </summary>
        private void ListenData()
        {
            while (!this.cts.IsCancellationRequested)
            {
                //创建一个新的socket来处理数据
                try
                {
                    Socket socketRecevie = tcpServer.Accept();
                    if (!socketRecevie.RemoteEndPoint.ToString().StartsWith(ip))
                    {
                        tcpServer.Close();
                        continue;
                    }
                    //如果存在ip地址，那就更换最新的Socket
                    if (currentClient.ContainsKey(socketRecevie.RemoteEndPoint.ToString()))
                    {
                        currentClient[socketRecevie.RemoteEndPoint.ToString()]=socketRecevie;
                    }
                    //不存在，就添加
                    else
                    {
                        currentClient.Add(socketRecevie.RemoteEndPoint.ToString(), socketRecevie);
                    }
                    //来接受和处理数据
                    Task.Run(new Action(() =>
                    {
                        RecevieValue(socketRecevie);
                    }), cts.Token);
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        ///  接受数据
        /// </summary>
        /// <param name="socket"></param>
        private void RecevieValue(object socket)
        {
            while (!this.cts.IsCancellationRequested)
            {
                byte[] buffer = new byte[1024];
                int length = 0;
                Socket socket1 = socket as Socket;
                lock (objLock)
                {
                    try
                    {
                        length=socket1.Receive(buffer);
                    }
                    catch(Exception ex)
                    {
                        if (currentClient.ContainsKey(socket1.RemoteEndPoint.ToString()))
                        {
                            currentClient.Remove(socket1.RemoteEndPoint.ToString()) ;
                        }
                        MessageBox.Show("读取失败"+ex.Message);
                    }
                }
                if (length==recevieCount)
                {
                    Update(buffer);
                }
            }
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="buffer"></param>
        private void Update(byte[] buffer)
        {
            //建立缓冲区
            byte[] send = ByteArrayLib.GetByteArrayFromByteArray(buffer, 0, recevieCount);
            recevie=ByteArrayLib.GetByteArrayFromByteArray(buffer, recevieCount-sendCount, sendCount);

            this.Invoke(new Action(() =>
            {
                //读取区域
                foreach (var item in this.gpb_Read.Controls)
                {
                    if (item is Label label)
                    {
                        if (label.Tag!=null&&label.Tag.ToString().Trim().Length>0)
                        {
                            var bindValue = BindValueFormat(label.Tag.ToString());
                            if (bindValue.IsSuccess)
                            {
                                switch (bindValue.Content.DataType)
                                {
                                    case DataType.Bool:
                                        label.BackColor=BitLib.GetBitFromByteArray(send, bindValue.Content.Start,
                                            bindValue.Content.OffsetOrLength) ? Color.Green : Color.Red;
                                        break;
                                    case DataType.Byte:
                                        label.Text=ByteLib.GetByteFromByteArray(send, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.Short:
                                        label.Text=ShortLib.GetShortFromByteArray(send, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.UShort:
                                        label.Text=UShortLib.GetUShortFromByteArray(send, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.Int:
                                        label.Text=IntLib.GetIntFromByteArray(send, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.UInt:
                                        label.Text=UIntLib.GetUIntFromByteArray(send, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.Float:
                                        label.Text=FloatLib.GetFloatFromByteArray(send, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.Double:
                                        label.Text=DoubleLib.GetDoubleFromByteArray(send, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.Long:
                                        label.Text=LongLib.GetLongFromByteArray(send, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.ULong:
                                        label.Text=ULongLib.GetULongFromByteArray(send, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.String:
                                        label.Text=StringLib.GetStringFromValueArray(send, bindValue.Content.Start, bindValue.Content.OffsetOrLength).ToString();
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }

                //写入区域
                //读取区域
                foreach (var item in this.gpb_Write.Controls)
                {
                    if (item is Label label)
                    {
                        if (label.Tag!=null&&label.Tag.ToString().Trim().Length>0)
                        {
                            var bindValue = BindValueFormat(label.Tag.ToString());
                            if (bindValue.IsSuccess)
                            {
                                switch (bindValue.Content.DataType)
                                {
                                    case DataType.Bool:
                                        label.BackColor=BitLib.GetBitFromByteArray(recevie, bindValue.Content.Start,
                                            bindValue.Content.OffsetOrLength) ? Color.Green : Color.Red;
                                        break;
                                    case DataType.Byte:
                                        label.Text=ByteLib.GetByteFromByteArray(recevie, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.Short:
                                        label.Text=ShortLib.GetShortFromByteArray(recevie, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.UShort:
                                        label.Text=UShortLib.GetUShortFromByteArray(recevie, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.Int:
                                        label.Text=IntLib.GetIntFromByteArray(recevie, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.UInt:
                                        label.Text=UIntLib.GetUIntFromByteArray(recevie, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.Float:
                                        label.Text=FloatLib.GetFloatFromByteArray(recevie, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.Double:
                                        label.Text=DoubleLib.GetDoubleFromByteArray(recevie, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.Long:
                                        label.Text=LongLib.GetLongFromByteArray(recevie, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.ULong:
                                        label.Text=ULongLib.GetULongFromByteArray(recevie, bindValue.Content.Start).ToString();
                                        break;
                                    case DataType.String:
                                        label.Text=StringLib.GetStringFromValueArray(recevie, bindValue.Content.Start, bindValue.Content.OffsetOrLength).ToString();
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }));
        }

        /// <summary>
        /// 处理数据绑定
        /// </summary>
        /// <returns></returns>
        private OperateResult<BindValue> BindValueFormat(string tag)
        {
            if (tag.Contains(","))
            {
                string[] length = tag.Split(',');
                BindValue value = new BindValue();
                if (length.Length==2)
                {
                    try
                    {
                        value.DataType=(DataType)Enum.Parse(typeof(DataType), length[1]);
                        if (length[0].Contains('.'))
                        {
                            string[] length1 = length[0].Split('.');
                            value.Start=Convert.ToInt32(length1[0]);
                            value.OffsetOrLength=Convert.ToInt32(length1[1]);
                        }
                        else
                        {
                            value.Start=Convert.ToInt32(length[0]);
                            value.OffsetOrLength=0;
                        }
                        return OperateResult.CreateSuccessResult(value);
                    }
                    catch
                    {
                        return OperateResult.CreateFailResult<BindValue>("数据绑定错误"+tag);
                    }
                }
                else
                {
                    return OperateResult.CreateFailResult<BindValue>("数据绑定错误"+tag);
                }
            }
            else
            {
                return OperateResult.CreateFailResult<BindValue>("数据绑定错误"+tag);
            }
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                if (label.Tag!=null&&label.Tag.ToString().Trim().Length>0)
                {
                    var bindValue = BindValueFormat(label.Tag.ToString());
                    if (bindValue.IsSuccess)
                    {
                        string current = bindValue.Content.DataType==DataType.Bool ? (label.BackColor==Color.Red ? "False" : "True")
                        : label.Text;
                        FrmParam frm = new FrmParam(current, bindValue.Content.DataType);
                        if (frm.ShowDialog()==DialogResult.OK)
                        {
                            lock (objLock)
                            {
                                object setvalue = frm.SetValue;
                                byte[] updateDate = ByteArrayLib.SetByteArray(recevie, setvalue,
                                    bindValue.Content.Start, bindValue.Content.OffsetOrLength);
                                //遍历所有服务器，发送给PLC
                                foreach (var item in currentClient.Values) 
                                {
                                    item.Send(updateDate);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 断开服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DisConnect_Click(object sender, EventArgs e)
        {
            this.cts?.Cancel();
            foreach (var item in currentClient.Values)
            {
                item?.Close();
            }
            tcpServer?.Close();
        }
    }
}
