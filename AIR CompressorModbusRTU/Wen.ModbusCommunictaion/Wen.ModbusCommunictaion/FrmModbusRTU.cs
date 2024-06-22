using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Wen.ModbusCommunicationLib;
using Wen.ModbucCommunicationLib.Library;
using thinger.DataConvertLib;

namespace Wen.ModbusCommunictaion
{
    public partial class FrmModbusRTU : Form
    {
        public FrmModbusRTU()
        {
            InitializeComponent();

            this.lst_Info.Columns[1].Width = this.lst_Info.Width - this.lst_Info.Columns[0].Width - 30;

            this.cmb_Port.DataSource = SerialPort.GetPortNames();

            this.cmb_BaudRate.Items.AddRange(new string[] { "2400", "4800", "9600", "19200", "38400" });
            this.cmb_BaudRate.SelectedIndex = 2;

            this.cmb_Parity.DataSource = Enum.GetNames(typeof(Parity));
            this.cmb_Parity.SelectedIndex = 0;

            this.cmb_StopBits.DataSource= Enum.GetNames(typeof(StopBits));
            this.cmb_StopBits.SelectedIndex = 1;
            
            this.cmb_DataType.DataSource = Enum.GetNames(typeof(DataType)).Where(c => (DataType)Enum.Parse(typeof(DataType), c) <= DataType.String).ToList();
            this.cmb_DataFormat.DataSource = Enum.GetNames(typeof(DataFormat));
        }

        //创建通信对象
        private ModbusRTU device = null;

        //创建连接正常标志位
        private bool isConnected = false;

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            device = new ModbusRTU();

            device.DevAddress =Convert.ToByte( this.txt_DevAddress.Text);
            device.IsShortAddress = this.chk_IsShortAddress.Checked;
            device.DataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), this.cmb_DataFormat.Text);

            Parity parity = (Parity)Enum.Parse(typeof(Parity), this.cmb_Parity.Text);
            StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), this.cmb_StopBits.Text);

            int baudRate = Convert.ToInt32(this.cmb_BaudRate.Text);
            int dataBits = Convert.ToInt32(this.txt_DataBits.Text);

            var result = device.Connect(this.cmb_Port.Text,baudRate,dataBits,stopBits,parity);

            if (result)
            {
                isConnected = true;
                CommonMethods.AddLog(this.lst_Info, 0, "设备连接成功");
            }
            else
            {
                isConnected = false;
                CommonMethods.AddLog(this.lst_Info, 0, "设备连接失败" );
            }
        }

        private void btn_DisConn_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                device?.DisConnect();
                CommonMethods.AddLog(this.lst_Info, 0, "设备断开连接");
            }
            else
            {
                CommonMethods.AddLog(this.lst_Info, 0, "设备未连接");
            }
        }

        /// <summary>
        /// 通用验证
        /// </summary>
        /// <returns></returns>
        private bool CommonValidate()
        {
            if (isConnected == false)
            {
                CommonMethods.AddLog(this.lst_Info, 1, "设备未连接，请检查");
                return false;
            }

            return true;
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            if (CommonValidate())
            {
                DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.cmb_DataType.Text);

                switch (dataType)
                {
                    case DataType.Bool:

                        //var result1 = device.ReadBoolArray(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        //if (result1.IsSuccess)
                        //{
                        //    CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result1.Content));
                        //}
                        //else
                        //{
                        //    CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result1.Message);
                        //}

                        var result1 = device.ReadCommon<bool[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        if (result1.IsSuccess)
                        {
                            CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result1.Content));
                        }
                        else
                        {
                            CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result1.Message);
                        }

                        break;
                    case DataType.Byte:
                    case DataType.SByte:
                        var result2 = device.ReadCommon<byte[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        if (result2.IsSuccess)
                        {
                            CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result2.Content));
                        }
                        else
                        {
                            CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result2.Message);
                        }

                        break;
                    case DataType.Short:

                        var result3 = device.ReadCommon<short[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        if (result3.IsSuccess)
                        {
                            CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result3.Content));
                        }
                        else
                        {
                            CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result3.Message);
                        }

                        break;
                    case DataType.UShort:
                        var result4 = device.ReadCommon<ushort[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        if (result4.IsSuccess)
                        {
                            CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result4.Content));
                        }
                        else
                        {
                            CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result4.Message);
                        }

                        break;
                    case DataType.Int:
                        var result5 = device.ReadCommon<int[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        if (result5.IsSuccess)
                        {
                            CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result5.Content));
                        }
                        else
                        {
                            CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result5.Message);
                        }
                        break;
                    case DataType.UInt:
                        var result6 = device.ReadCommon<uint[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        if (result6.IsSuccess)
                        {
                            CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result6.Content));
                        }
                        else
                        {
                            CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result6.Message);
                        }
                        break;
                    case DataType.Float:
                        var result7 = device.ReadCommon<float[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        if (result7.IsSuccess)
                        {
                            CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result7.Content));
                        }
                        else
                        {
                            CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result7.Message);
                        }
                        break;
                    case DataType.Double:
                        var result8 = device.ReadCommon<float[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        if (result8.IsSuccess)
                        {
                            CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result8.Content));
                        }
                        else
                        {
                            CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result8.Message);
                        }
                        break;
                    case DataType.Long:
                        var result9 = device.ReadCommon<long[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        if (result9.IsSuccess)
                        {
                            CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result9.Content));
                        }
                        else
                        {
                            CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result9.Message);
                        }
                        break;
                    case DataType.ULong:
                        var result10 = device.ReadCommon<ulong[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        if (result10.IsSuccess)
                        {
                            CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result10.Content));
                        }
                        else
                        {
                            CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result10.Message);
                        }
                        break;
                    case DataType.String:
                        var result11 = device.ReadCommon<string>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        if (result11.IsSuccess)
                        {
                            CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + result11.Content);
                        }
                        else
                        {
                            CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result11.Message);
                        }
                        break;
                    default:
                        CommonMethods.AddLog(this.lst_Info, 1, "读取失败:不支持的数据类型");
                        break;
                }

            }
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            if (CommonValidate())
            {
                DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.cmb_DataType.Text);

                var result = OperateResult.CreateFailResult();

                switch (dataType)
                {
                    case DataType.Bool:
                        result = device.WriteCommon(this.txt_Variable.Text, BitLib.GetBitArrayFromBitArrayString(this.txt_SetValue.Text.Trim()));
                        break;
                    case DataType.Byte:
                    case DataType.SByte:
                        result = device.WriteCommon(this.txt_Variable.Text, ByteArrayLib.GetByteArrayFromHexString(this.txt_SetValue.Text.Trim()));
                        break;
                    case DataType.Short:
                        result = device.WriteCommon(this.txt_Variable.Text, ShortLib.GetShortArrayFromString(this.txt_SetValue.Text.Trim()));
                        break;
                    case DataType.UShort:
                        result = device.WriteCommon(this.txt_Variable.Text, UShortLib.GetUShortArrayFromString(this.txt_SetValue.Text.Trim()));
                        break;
                    case DataType.Int:
                        result = device.WriteCommon(this.txt_Variable.Text, IntLib.GetIntArrayFromString(this.txt_SetValue.Text.Trim()));
                        break;
                    case DataType.UInt:
                        result = device.WriteCommon(this.txt_Variable.Text, UIntLib.GetUIntArrayFromString(this.txt_SetValue.Text.Trim()));
                        break;
                    case DataType.Float:
                        result = device.WriteCommon(this.txt_Variable.Text, FloatLib.GetFloatArrayFromString(this.txt_SetValue.Text.Trim()));
                        break;
                    case DataType.Double:
                        result = device.WriteCommon(this.txt_Variable.Text, DoubleLib.GetDoubleArrayFromString(this.txt_SetValue.Text.Trim()));
                        break;
                    case DataType.Long:
                        result = device.WriteCommon(this.txt_Variable.Text, LongLib.GetLongArrayFromString(this.txt_SetValue.Text.Trim()));
                        break;
                    case DataType.ULong:
                        result = device.WriteCommon(this.txt_Variable.Text, ULongLib.GetULongArrayFromString(this.txt_SetValue.Text.Trim()));
                        break;
                    case DataType.String:
                        result = device.WriteCommon(this.txt_Variable.Text, this.txt_SetValue.Text.Trim());
                        break;
                    default:
                        break;
                }

                if (result.IsSuccess)
                {
                    CommonMethods.AddLog(this.lst_Info, 0, "写入成功");
                }
                else
                {
                    CommonMethods.AddLog(this.lst_Info, 0, "写入失败");
                }
            }
        }
    }
}
