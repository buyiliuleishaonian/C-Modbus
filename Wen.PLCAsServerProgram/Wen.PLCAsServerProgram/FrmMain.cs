using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using thinger.DataConvertLib;

namespace Wen.PLCAsServerProgram
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        //建立Socket 对象
        private Socket tcp;
        //建立Task手动停止对象
        public CancellationTokenSource cts;
        //DB块byte数据的长度
        //发送数据长度
        int sendCount = 100;
        //接收数据长度
        int receiveCount = 200;

        byte[] send;
        //锁
        private static readonly object objLock= new object();   
        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            //ip,通信功能，通信协议
            tcp=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            try
            {
                //ip地址，端口号
                tcp.Connect(IPAddress.Parse(this.txt_IPAddress.Text),int.Parse(this.txt_port.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show("PLC连接失败"+ex.Message);
                return;
            }

            MessageBox.Show("PLC连接成功");

            cts= new CancellationTokenSource();

            Task.Run(new Action(() => 
            {
                ReceiveData();
            }),cts.Token);
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        private  void ReceiveData()
        {
            while (!cts.IsCancellationRequested)
            {
                //定义一个缓冲区
                byte[] buffer=new byte[1024];
                //定义读取长度
                int length = -1;
                lock (objLock)
                {
                    try
                    {
                        length=tcp.Receive(buffer, SocketFlags.None);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("读取失败"+ex.Message);
                    }
                }
                //修改读取数据的显示
                if (length==receiveCount)
                {
                    Update(buffer);
                }
            }
        }

        /// <summary>
        ///修改所读取的数据显示
        /// </summary>
        private void Update(byte[] buffer)
        {
            //定义发送数据
            send = ByteArrayLib.GetByteArrayFromByteArray(buffer,receiveCount-sendCount,sendCount);
            //定义接收数据
            byte[] recevie=ByteArrayLib.GetByteArrayFromByteArray(buffer,0,receiveCount);

            this.Invoke(new Action(() =>
            {
                //接收PLC数据，所显示出来的数据
                foreach (var item in this.gpb_Read.Controls)
                {
                    //判断是否是label控件 
                    if (item is Label label)
                    {
                        //判断label控件的tag属性是否为空
                        if (label.Tag!=null&&label.Tag.ToString().Length>0)
                        {
                            var bindVariable = BindVariableFormat(label.Tag.ToString());
                            switch (bindVariable.Content.DataType)
                            {
                                case DataType.Bool:
                                    label.BackColor=BitLib.GetBitFromByteArray(recevie, bindVariable.Content.Start,
                                        bindVariable.Content.OffsetOrLength) ? Color.Green : Color.Red;
                                    break;
                                case DataType.Byte:
                                    label.Text=ByteLib.GetByteFromByteArray(recevie, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.Short:
                                    label.Text=ShortLib.GetShortFromByteArray(recevie, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.UShort:
                                    label.Text=UShortLib.GetUShortFromByteArray(recevie, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.Int:
                                    label.Text=IntLib.GetIntFromByteArray(recevie, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.UInt:
                                    label.Text=UIntLib.GetUIntFromByteArray(recevie, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.Float:
                                    label.Text=FloatLib.GetFloatFromByteArray(recevie, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.Double:
                                    label.Text=DoubleLib.GetDoubleFromByteArray(recevie, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.Long:
                                    label.Text=LongLib.GetLongFromByteArray(recevie, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.ULong:
                                    label.Text=ULongLib.GetULongFromByteArray(recevie, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.String:
                                    label.Text=StringLib.GetStringFromValueArray(recevie, bindVariable.Content.Start, bindVariable.Content.OffsetOrLength).ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                //写入PLC的数据
                foreach (var item in this.gpb_Write.Controls)
                {
                    //判断是否是label控件
                    if (item is Label label)
                    {
                        //判断label控件的tag属性是否为空
                        if (label.Tag!=null&&label.Tag.ToString().Length>0)
                        {
                            var bindVariable = BindVariableFormat(label.Tag.ToString());
                            switch (bindVariable.Content.DataType)
                            {
                                case DataType.Bool:
                                    label.BackColor=BitLib.GetBitFromByteArray(send, bindVariable.Content.Start,
                                        bindVariable.Content.OffsetOrLength) ? Color.Green : Color.Red;
                                    break;
                                case DataType.Byte:
                                    label.Text=ByteLib.GetByteFromByteArray(send, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.Short:
                                    label.Text=ShortLib.GetShortFromByteArray(send, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.UShort:
                                    label.Text=UShortLib.GetUShortFromByteArray(send, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.Int:
                                    label.Text=IntLib.GetIntFromByteArray(send, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.UInt:
                                    label.Text=UIntLib.GetUIntFromByteArray(send, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.Float:
                                    label.Text=FloatLib.GetFloatFromByteArray(send, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.Double:
                                    label.Text=DoubleLib.GetDoubleFromByteArray(send, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.Long:
                                    label.Text=LongLib.GetLongFromByteArray(send, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.ULong:
                                    label.Text=ULongLib.GetULongFromByteArray(send, bindVariable.Content.Start).ToString();
                                    break;
                                case DataType.String:
                                    label.Text=StringLib.GetStringFromValueArray(send, bindVariable.Content.Start, bindVariable.Content.OffsetOrLength).ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }));
        }

        
        private OperateResult<BindVariable> BindVariableFormat(string tag)
        {
            if (tag.Contains(","))
            {
                string[] bytes = tag.Split(',');
                BindVariable bindVariable = new BindVariable();
                if (bytes.Length==2)
                {
                    try
                    {
                        bindVariable.DataType=(DataType)Enum.Parse(typeof(DataType), bytes[1]);
                        //如果包含点说明是bool或string类型
                        if (bytes[0].Contains("."))
                        {
                            string[] result = bytes[0].Split('.');
                            bindVariable.OffsetOrLength=Convert.ToInt32(result[1]);
                            bindVariable.Start=Convert.ToInt32(result[0]);
                        }
                        else
                        {
                            bindVariable.Start=Convert.ToInt32(bytes[0]);
                            bindVariable.OffsetOrLength=0;
                        }
                        return OperateResult.CreateSuccessResult(bindVariable);
                    }
                    catch (Exception ex)
                    {
                        return OperateResult.CreateFailResult<BindVariable>("数据绑定错误"+tag+ex.Message);
                    }
                }
                else
                {
                    return OperateResult.CreateFailResult<BindVariable>("数据绑定错误"+tag);
                }
            }
            else
            {
                return OperateResult.CreateFailResult<BindVariable>("数据绑定错误"+tag);
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DisConnect_Click(object sender, EventArgs e)
        {
            cts?.Cancel();

            tcp?.Close();
        }

        private void Common_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                if (label.Tag!=null&&label.Tag.ToString().Trim().Length>0)
                {
                    var bindValue = BindVariableFormat(label.Tag.ToString());
                    if (bindValue.IsSuccess)
                    {
                        string current = bindValue.Content.DataType==DataType.Bool ? (label.BackColor==Color.Red ? "False" : "True")
                        : label.Text;
                        FrmParam frm = new FrmParam(current,bindValue.Content.DataType);
                        if (frm.ShowDialog()==DialogResult.OK)
                        {
                            lock (objLock)
                            {
                                object setvalue = frm.SetValue;
                                byte[] updateDate = ByteArrayLib.SetByteArray(send, setvalue,
                                    bindValue.Content.Start, bindValue.Content.OffsetOrLength);
                                //发送给PLC
                                tcp.Send(updateDate);
                            }
                        }
                    }
                }
            }
        }
    }
}
