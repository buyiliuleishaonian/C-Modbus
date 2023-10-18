using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wen.ModbusProject.连接西门子;
using Wen.ModbusTCPLib;

namespace Wen.ModbusProject
{
    public partial class FrmSiemens : Form
    {
        public FrmSiemens()
        {
            InitializeComponent();
        }
        //创建一个ModbusTCP通信对象
        private ModbusTCP modbusTCP = new ModbusTCP();

        //创建一个当前连接状态
        private bool IsConnect = false;

        //取消线程源
        private CancellationTokenSource cts = null;

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //在连接之后，要一直读取，所以通过线程，之后委托中ladam委托一个方法，进行一直读取
            if (IsConnect)
            {
                MessageBox.Show("西门子PLC已连接");
                return;
            }
            IsConnect=modbusTCP.Connect(this.txtIP.Text, Convert.ToInt32(this.txtPort.Text));
            if (IsConnect)
            {
                MessageBox.Show("西门子PLC已连接");
                cts=new CancellationTokenSource();
                Task.Run(
                    new Action(
                        () =>
                        {
                            PLCCommuniAction();
                        }
                        ), cts.Token
                        );
            }
        }

        /// <summary>
        /// 多线程循环执行方法
        /// </summary>
        private void PLCCommuniAction()
        {
            while (!this.cts.IsCancellationRequested)
            {
                //从PLC中读取从0开始的DB1.DBB0-DBB343的
                //从西门子里面往Modbus中写地址，西门子地址要除以2
                //所在在modbus中地址乘以2就是对应在西门子中的地址

                byte[] result = modbusTCP.ReadOutPutRegisters(0, 68);
                try
                {
                    this.Invoke(new Action(() =>
                    {
                        if (result!=null&&result.Length==136)
                        {
                            UpdateUIControl(result, gx_Read);
                            UpdateUIControl(result, gx_Write);
                        }
                    }));
                }

                catch
                {
                    break;
                }
                //返回数据满足
                //在这个线程下修改数据，需要通过委托
            }
        }


        //编写一个改变容器控件中控件的属性的方法
        //需压判断输入的是否是容器控件，通过foreach将容器控件中的所有控件遍历出来
        //需要判断那些控件需要改变，那些控件不需要改变，可以通过控件的Tag属性，来判断是否 是需要改变的控件

        /// <summary>
        /// 通过读取PLC返回的数据，修改UI层控件的属性
        /// </summary>
        /// <param name="result">返回的byte[]数据</param>
        /// <param name="control">UI层控件</param>
        public void UpdateUIControl(byte[] buffer, Control control)
        {
            //判断是否含有子控件
            if (control.HasChildren)
            {
                //因为我此时只需要更改Label控件属性，根据你实际的情况，遍历控件
                foreach (var item in control.Controls.OfType<Label>())
                {
                    //通过控件中Tag属性，输入三个变量类需要的初始地址，数据类型，未偏移量或长度
                    if (item.Tag!=null&&item.Tag.ToString().Length>0)
                    {
                        Variable var = GetVariableByTag(item.Tag.ToString());
                        if (var!=null)
                        {
                            
                            switch (var.DataType)
                            {
                                case DataType.Bool:
                                    bool result = BitLib.GetBitFromByteArray(buffer, var.Start, var.OffSetOrLength);
                                    item.BackColor=result ? Color.Green : Color.Red;
                                    break;
                                case DataType.Byte:
                                    item.Text=ByteLib.GetByteFromByteArray(buffer, var.Start).ToString();
                                    break;
                                case DataType.Short:
                                    item.Text=ShortLib.GetShortFromByteArray(buffer, var.Start).ToString();
                                    break;
                                case DataType.UShort:
                                    item.Text=UShortLib.GetUShortFromByteArray(buffer, var.Start).ToString();
                                    break;
                                case DataType.Int:
                                    item.Text=IntLib.GetIntFromByteArray(buffer, var.Start).ToString();
                                    break;
                                case DataType.UInt:
                                    item.Text=UIntLib.GetUIntFromByteArray(buffer, var.Start).ToString();
                                    break;
                                case DataType.Float:
                                    item.Text=FloatLib.GetFloatFromByteArray(buffer, var.Start).ToString();
                                    break;
                                case DataType.Double:
                                    item.Text=DoubleLib.GetDoubleFromByteArray(buffer, var.Start).ToString();
                                    break;
                                case DataType.Long:
                                    item.Text=LongLib.GetLongFromByteArray(buffer, var.Start).ToString();
                                    break;
                                case DataType.ULong:
                                    item.Text=ULongLib.GetULongFromByteArray(buffer, var.Start).ToString();
                                    break;
                                case DataType.String:
                                    item.Text=StringLib.GetSiemensStringFromByteArray(buffer, var.Start, var.OffSetOrLength);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        //编写一个，判断输入的字符串，将其拆分之后，分贝传给变量对象的Start，DataType，OffsetOrLength三个属性
        /// <summary>
        /// 将tag分别赔给变量的三个属性
        /// </summary>
        /// <param name="tag">控件的tag</param>
        /// <returns></returns>
        public Variable GetVariableByTag(string tag)
        {
            Variable var = null;
            try
            {
                if (tag.Contains(";"))
                {
                    string[] result = tag.Split(new char[] { ';' });
                    if (result.Length==3)
                    {
                        var=new Variable()
                        {
                            DataType=(DataType)Convert.ToInt32(result[0]),
                            Start=Convert.ToInt32(result[1]),
                            OffSetOrLength=Convert.ToInt32(result[2]),
                        };
                        return var;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            if (IsConnect)
            {
                this.cts?.Cancel();
                modbusTCP.DisConnect();
                MessageBox.Show("西门子PLC连接已关闭");
                return;
            }
        }

        //创建一个窗体来显示，PLC所传输过来的数据值，数据类型，将要设定的参数
        //编写双击事件，通过触发事件对象，判断是否是Label控件，之后将其属性传输给我们所创建的窗体

        private void CommonModify_DoubleClick(object sender,EventArgs e)
        {
            //判断是否点击的Label控件
            if (sender is Label )
            {
                Label lbl = sender as Label;
                if (lbl.Tag!=null&&lbl.Tag.ToString().Trim().Length>0)
                {
                    string initialValue=lbl.Text;
                    Variable var = GetVariableByTag(lbl.Tag.ToString().Trim());
                    FrmParamSet frmParamSet= new FrmParamSet(initialValue,var,modbusTCP);
                    frmParamSet.ShowDialog();
                }
            }
        }
    }
}
