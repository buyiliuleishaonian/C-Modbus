using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wen.ModbusTCPLib;

namespace Wen.ModbusProject.连接西门子
{
    public partial class FrmParamSet : Form
    {
        public FrmParamSet()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 需要得到主窗体得到的数据
        /// </summary>
        /// <param name="initialValue"></param>
        /// <param name="var"></param>
        /// <param name="mdoubustcp"></param>
        public FrmParamSet(string initialValue, Variable var, ModbusTCP modbus) : this()
        {
            this.lbl_VarValue.Text= initialValue;
            this.variable=var;
            this.lbl_VarDataType.Text=var.DataType.ToString();
            modbustcp=modbus;
        }

        private Variable variable;
        private ModbusTCP modbustcp;

        /// <summary>
        /// 写入参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                switch (variable.DataType)
                {
                    case DataType.Short:
                        result= modbustcp.PreSetSingleRegister((ushort)(variable.Start/2), Convert.ToInt16(this.txtPerSet.Text.Trim()));
                        break;
                    case DataType.UShort:
                        result= modbustcp.PreSetSingleRegister((ushort)(variable.Start/2), Convert.ToUInt16(this.txtPerSet.Text.Trim()));
                        break;
                    case DataType.Int:
                        result= modbustcp.PreSetMultiRegisters((ushort)(variable.Start/2), ByteArrayLib.GetByteArrayFromInt(Convert.ToInt32(this.txtPerSet.Text.Trim())));
                        break;
                    case DataType.UInt:
                        result= modbustcp.PreSetMultiRegisters((ushort)(variable.Start/2), ByteArrayLib.GetByteArrayFromUInt(Convert.ToUInt32(this.txtPerSet.Text.Trim())));
                        break;
                    case DataType.Float:
                        result= modbustcp.PreSetMultiRegisters((ushort)(variable.Start/2), ByteArrayLib.GetByteArrayFromFloat(Convert.ToSingle(this.txtPerSet.Text.Trim())));
                        break;
                    case DataType.Double:
                        result= modbustcp.PreSetMultiRegisters((ushort)(variable.Start/2), ByteArrayLib.GetByteArrayFromDouble(Convert.ToDouble(this.txtPerSet.Text.Trim())));
                        break;
                    case DataType.Long:
                        result= modbustcp.PreSetMultiRegisters((ushort)(variable.Start/2), ByteArrayLib.GetByteArrayFromLong(Convert.ToInt64(this.txtPerSet.Text.Trim())));
                        break;
                    case DataType.ULong:
                        result= modbustcp.PreSetMultiRegisters((ushort)(variable.Start/2), ByteArrayLib.GetByteArrayFromULong(Convert.ToUInt64(this.txtPerSet.Text.Trim())));
                        break;
                    case DataType.String:
                        result= modbustcp.PreSetMultiRegisters((ushort)(variable.Start/2), ByteArrayLib.GetByteArrayFromSiemensString(this.txtPerSet.Text));
                        break;
                    default:
                        MessageBox.Show("不支持该数据类型写入", "参数设置");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查参数设置是否正确"+ex.Message, "参数设置");
                return;
            }
            if (result)
            {
                MessageBox.Show("写入成功");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("写入失败,请检查参数设置");
                this.DialogResult= DialogResult.Cancel;
            }
        }

        /// <summary>
        /// 直接关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }

        /// <summary>
        /// 当按下回车键，直接写入关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPerSet_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtPerSet.Text.Trim().Length>0&&e.KeyCode==Keys.Enter)
            {
                btn_OK_Click(null, null);
            }
        }
    }
}
