using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wen.ModbucCommunicationLib.Helper;
using Wen.ModbucCommunicationLib.Library;
using Wen.ModbucCommunicationLib.StoreArea;

namespace Wen.ModbusCommunictaion
{
    public partial class FrmModbusTCP : Form
    {
        public FrmModbusTCP()
        {
            InitializeComponent();

            this.cmb_Port.Items.Add("502");

            this.cmb_Port.SelectedIndex=-1;


            this.cmb_DataFormat.DataSource= (new DataFormat[] {DataFormat.ABCD,DataFormat.BADC,DataFormat.DCBA,DataFormat.CDAB });
            this.cmb_DataFormat.SelectedIndex=0;

            this.cmb_DataType.DataSource = Enum.GetNames(typeof(DataType)).Where(c => (DataType)Enum.Parse(typeof(DataType), c) <= DataType.String).ToList();
           

            ModbusTCP=new ModbusTCP((DataFormat)Enum.Parse(typeof(DataFormat),this.cmb_DataFormat.SelectedItem.ToString()));
        }

        private ModbusTCP ModbusTCP=null;

        

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (this.cmb_Port.Text==null||this.cmb_Port.Text.Trim().Length<=0)
            {
                CommonMethods.AddLog(this.lst_Info,2,"端口号为0");
                return;
            }
            if (this.txt_IP.Text==null||this.txt_IP.Text.Trim().Length<=0)
            {
                CommonMethods.AddLog(this.lst_Info, 2, "ip为空");
                return;
            }
            if (this.txt_DevAddress.Text==null||this.txt_DevAddress.Text.Trim().Length<=0)
            {
                CommonMethods.AddLog(this.lst_Info, 2, "从站地址为空");
                return;
            }
            if (this.cmb_DataFormat.Text==null||this.cmb_DataFormat.Text.Trim().Length<=0)
            {
                CommonMethods.AddLog(this.lst_Info, 2, "大小端为空");
                return;
            }
            ModbusTCP.IsShortAddress=this.chk_IsShortAddress.Checked;
            ModbusTCP.Connect(this.txt_IP.Text,Convert.ToInt32( this.cmb_Port.Text));
            CommonMethods.AddLog(this.lst_Info,0,"连接成功");
        }

        private void btn_DisConn_Click(object sender, EventArgs e)
        {
            if (ModbusTCP!=null)
            {
                ModbusTCP?.DisConnect();
                CommonMethods.AddLog(this.lst_Info, 1, "断开连接");
            }
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Read_Click(object sender, EventArgs e)
        {
             DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.cmb_DataType.Text);

                switch (dataType)
                {
                    case DataType.Bool:

                        //var result1 = ModbusTCP.ReadBoolArray(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

                        //if (result1.IsSuccess)
                        //{
                        //    CommonMethods.AddLog(this.lst_Info, 0, "读取成功:" + StringLib.GetStringFromValueArray(result1.Content));
                        //}
                        //else
                        //{
                        //    CommonMethods.AddLog(this.lst_Info, 1, "读取失败:" + result1.Message);
                        //}

                        var result1 = ModbusTCP.ReadCommon<bool[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

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
                        var result2 = ModbusTCP.ReadCommon<byte[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

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

                        var result3 = ModbusTCP.ReadCommon<short[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

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
                        var result4 = ModbusTCP.ReadCommon<ushort[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

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
                        var result5 = ModbusTCP.ReadCommon<int[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

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
                        var result6 = ModbusTCP.ReadCommon<uint[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

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
                        var result7 = ModbusTCP.ReadCommon<float[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

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
                        var result8 = ModbusTCP.ReadCommon<float[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

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
                        var result9 = ModbusTCP.ReadCommon<long[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

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
                        var result10 = ModbusTCP.ReadCommon<ulong[]>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

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
                        var result11 = ModbusTCP.ReadCommon<string>(this.txt_Variable.Text, Convert.ToUInt16(this.txt_Count.Text));

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


        private void btn_Write_Click(object sender, EventArgs e)
        {
            DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.cmb_DataType.Text);

            var result = OperateResult.CreateFailResult();

            switch (dataType)
            {
                case DataType.Bool:
                    result = ModbusTCP.WriteCommon(this.txt_Variable.Text, BitLib.GetBitArrayFromBitArrayString(this.txt_SetValue.Text.Trim()));

                   // var result1 = ModbusHelper.ModbusAddressAnalysis(this.txt_Variable.Text, 1, true);
                    //if (result.IsSuccess)
                    //{
                    // result=   ModbusTCP.WriteBool(this.txt_Variable.Text, bool.Parse(this.txt_SetValue.Text.Trim()),
                    //        (result1.Content1==ModbusStoreArea.x0&&result1.Content1==ModbusStoreArea.x1) ? true : false);
                    //}
                    //OperateResult.CreateFailResult($"变量{this.txt_Variable.Text}不存在，请检查变量表");
                    break;
                case DataType.Byte:
                case DataType.SByte:
                    result = ModbusTCP.WriteCommon(this.txt_Variable.Text, ByteArrayLib.GetByteArrayFromHexString(this.txt_SetValue.Text.Trim()));
                    break;
                case DataType.Short:
                    result = ModbusTCP.WriteCommon(this.txt_Variable.Text, ShortLib.GetShortArrayFromString(this.txt_SetValue.Text.Trim()));
                    break;
                case DataType.UShort:
                    result = ModbusTCP.WriteCommon(this.txt_Variable.Text, UShortLib.GetUShortArrayFromString(this.txt_SetValue.Text.Trim()));
                    break;
                case DataType.Int:
                    result = ModbusTCP.WriteCommon(this.txt_Variable.Text, IntLib.GetIntArrayFromString(this.txt_SetValue.Text.Trim()));
                    break;
                case DataType.UInt:
                    result = ModbusTCP.WriteCommon(this.txt_Variable.Text, UIntLib.GetUIntArrayFromString(this.txt_SetValue.Text.Trim()));
                    break;
                case DataType.Float:
                    result = ModbusTCP.WriteCommon(this.txt_Variable.Text, FloatLib.GetFloatArrayFromString(this.txt_SetValue.Text.Trim()));
                    break;
                case DataType.Double:
                    result = ModbusTCP.WriteCommon(this.txt_Variable.Text, DoubleLib.GetDoubleArrayFromString(this.txt_SetValue.Text.Trim()));
                    break;
                case DataType.Long:
                    result = ModbusTCP.WriteCommon(this.txt_Variable.Text, LongLib.GetLongArrayFromString(this.txt_SetValue.Text.Trim()));
                    break;
                case DataType.ULong:
                    result = ModbusTCP.WriteCommon(this.txt_Variable.Text, ULongLib.GetULongArrayFromString(this.txt_SetValue.Text.Trim()));
                    break;
                case DataType.String:
                    result = ModbusTCP.WriteCommon(this.txt_Variable.Text, this.txt_SetValue.Text.Trim());
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
