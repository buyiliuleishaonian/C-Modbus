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

namespace Wen.PLCAsServerProgram
{
    public partial class FrmParam : Form
    {
        public FrmParam(string current,DataType dataType)
        {
            InitializeComponent();
            this.lbl_CurrentValue.Text = current;   
            this.lbl_CurrentDataType.Text=dataType.ToString();
            this.dataType = dataType;
        }

        public DataType dataType;

        public object SetValue { get; set; }

        /// <summary>
        /// 确认修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            string set=this.txt_SetValue.Text.Trim();
            try
            {
                switch (this.dataType)
                {
                    case DataType.Bool:
                        this.SetValue=set.ToUpper()=="TRUE";
                        break;
                    case DataType.Byte:
                        this.SetValue=Convert.ToByte(set);
                        break;
                    case DataType.Short:
                        this.SetValue=Convert.ToInt16(set);
                        break;
                    case DataType.UShort:
                        this.SetValue = Convert.ToUInt16(set);
                        break;
                    case DataType.Int:
                        this.SetValue=Convert.ToInt32(set);
                        break;
                    case DataType.UInt:
                        this.SetValue=Convert.ToUInt32(set);
                        break;
                    case DataType.Float:
                        this.SetValue=Convert.ToSingle(set);
                        break;
                    case DataType.Double:
                        this.SetValue=Convert.ToDouble(set);
                        break;
                    case DataType.Long:
                        this.SetValue=Convert.ToInt64(set);
                        break;
                    case DataType.ULong:
                        this.SetValue= Convert.ToUInt64(set);
                        break;
                    case DataType.String:
                        this.SetValue=set;
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("修改的数据无法转换对应的数据类型"+ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 取消修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 按下回车键也触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmParam_KeyDown(object sender, KeyEventArgs e)
        {
            btn_Update_Click(null,null);
        }
    }
}
