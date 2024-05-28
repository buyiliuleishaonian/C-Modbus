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

using thinger.CommunicationLib;
using thinger.DataConvertLib;


namespace PLCAsServer_ModbusTCP_
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.cmb_DataFormat.DataSource=null;
            this.cmb_DataFormat.DataSource=Enum.GetNames(typeof(DataFormat));
        }

        //创建ModbusTCP通信的
        private ModbusTCP modbusTCP;   

        //建立多线程，手动取消对象
        private CancellationTokenSource cts;
        //数据长度
        private int dataCount = 100;
        //设定锁对象
        private static readonly Object objLock=new Object();

        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            modbusTCP=new ModbusTCP();
            modbusTCP.IsShortAddress=this.ckb_IsShortAddRess.Checked;
            modbusTCP.DevAddress=Convert.ToByte( this.txt_Point.Text);
            modbusTCP.DataFormat=(DataFormat)Enum.Parse(typeof(DataFormat),this.cmb_DataFormat.Text.ToString());

            //建立连接
            try
            {
                modbusTCP.Connect(this.txt_IPAddress.Text, Convert.ToInt32(this.txt_port.Text.ToString()));
                MessageBox.Show("PLC连接成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show("通信失败"+ex.Message);
                return;
            }
            cts=new CancellationTokenSource();
            Task.Run(new Action(() =>
            {
                ReceiveData();
            }),cts.Token);
        }

        /// <summary>
        /// 接受数据
        /// </summary>
        private void ReceiveData()
        {
            while (!cts.IsCancellationRequested)
            {
                lock (objLock)
                {

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
                                            label.BackColor=(modbusTCP.ReadBool(bindVariable.Content.Start))
                                            .Content==true?Color.Green:Color.Red;
                                            break;
                                        case DataType.Byte:
                                            label.Text=Convert.ToString( modbusTCP.ReadCommon<byte[]>(bindVariable.Content.Start).Content);
                                            break;
                                        case DataType.Short:
                                            label.Text=Convert.ToString(modbusTCP.ReadCommon<short[]>(bindVariable.Content.Start).Content);
                                            break;
                                        case DataType.UShort:
                                            label.Text=Convert.ToString(modbusTCP.ReadCommon<ushort[]>(bindVariable.Content.Start).Content);
                                            break;
                                        case DataType.Int:
                                            label.Text=Convert.ToString(modbusTCP.ReadCommon<int[]>(bindVariable.Content.Start).Content);
                                            break;
                                        case DataType.UInt:
                                            label.Text=Convert.ToString(modbusTCP.ReadCommon<uint[]>(bindVariable.Content.Start).Content);
                                            break;
                                        case DataType.Float:
                                            label.Text=Convert.ToString(modbusTCP.ReadCommon<float[]>(bindVariable.Content.Start).Content);
                                            break;
                                        case DataType.Double:
                                            label.Text=Convert.ToString(modbusTCP.ReadCommon<double[]>(bindVariable.Content.Start).Content);
                                            break;
                                        case DataType.Long:
                                            label.Text=Convert.ToString(modbusTCP.ReadCommon<long[]>(bindVariable.Content.Start).Content);
                                            break;
                                        case DataType.ULong:
                                            label.Text=Convert.ToString(modbusTCP.ReadCommon<ulong[]>(bindVariable.Content.Start).Content);
                                            break;
                                        case DataType.String:
                                            label.Text=Convert.ToString(modbusTCP.ReadCommon<string[]>(bindVariable.Content.Start).Content);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }

                        ////写入PLC的数据
                        //foreach (var item in this.gpb_Write.Controls)
                        //{
                        //    //判断是否是label控件
                        //    if (item is Label label)
                        //    {
                        //        //判断label控件的tag属性是否为空
                        //        if (label.Tag!=null&&label.Tag.ToString().Length>0)
                        //        {
                        //            var bindVariable = BindVariableFormat(label.Tag.ToString());
                        //            try
                        //            {
                        //                switch (bindVariable.Content.DataType)
                        //                {
                        //                    case DataType.Bool:
                        //                        label.BackColor=(modbusTCP.ReadCommon<bool[]>(bindVariable.Content.Start))
                        //                        .Content[0]==true ? Color.Green : Color.Red;
                        //                        break;
                        //                    case DataType.Byte:
                        //                        label.Text=Convert.ToString(modbusTCP.ReadCommon<byte[]>(bindVariable.Content.Start));
                        //                        break;
                        //                    case DataType.Short:
                        //                        label.Text=Convert.ToString(modbusTCP.ReadCommon<short[]>(bindVariable.Content.Start));
                        //                        break;
                        //                    case DataType.UShort:
                        //                        label.Text=Convert.ToString(modbusTCP.ReadCommon<ushort[]>(bindVariable.Content.Start));
                        //                        break;
                        //                    case DataType.Int:
                        //                        label.Text=Convert.ToString(modbusTCP.ReadCommon<int[]>(bindVariable.Content.Start));
                        //                        break;
                        //                    case DataType.UInt:
                        //                        label.Text=Convert.ToString(modbusTCP.ReadCommon<uint[]>(bindVariable.Content.Start));
                        //                        break;
                        //                    case DataType.Float:
                        //                        label.Text=Convert.ToString(modbusTCP.ReadCommon<float[]>(bindVariable.Content.Start));
                        //                        break;
                        //                    case DataType.Double:
                        //                        label.Text=Convert.ToString(modbusTCP.ReadCommon<double[]>(bindVariable.Content.Start));
                        //                        break;
                        //                    case DataType.Long:
                        //                        label.Text=Convert.ToString(modbusTCP.ReadCommon<long[]>(bindVariable.Content.Start));
                        //                        break;
                        //                    case DataType.ULong:
                        //                        label.Text=Convert.ToString(modbusTCP.ReadCommon<ulong[]>(bindVariable.Content.Start));
                        //                        break;
                        //                    case DataType.String:
                        //                        label.Text=Convert.ToString(modbusTCP.ReadCommon<string[]>(bindVariable.Content.Start));
                        //                        break;
                        //                    default:
                        //                        break;
                        //                }
                        //            }
                        //            catch (Exception ex) 
                        //            {
                        //                MessageBox.Show(ex.Message);
                        //            }
                        //        }
                        //    }
                        //}
                    }));
                }
            }
        }

        /// <summary>
        /// 解析控件绑定的变量
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>

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
                            bindVariable.Start=(result[0]);
                        }
                        else
                        {
                            bindVariable.Start=(bytes[0]);
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
        


        private void btn_DisConnect_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
            modbusTCP.DisConnect();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts?.Cancel();
            if (modbusTCP!=null)
            {
                modbusTCP.DisConnect();
            }
        }
    }
}
