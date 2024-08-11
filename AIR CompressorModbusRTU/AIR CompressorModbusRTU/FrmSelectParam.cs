using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIR_CompressorModbusRTU
{
    public delegate List<string> SelectParam();
    public partial class FrmSelectParam : Form
    {
        public FrmSelectParam(List<string> selectParamList)
        {
            InitializeComponent();
            unselectParam.AddRange(CommonMethod.PLCDevice.StoreVarList.Select(c=>c.Comments).ToList());
            foreach (string item in selectParamList)
            {
                selectParam.Add(item);
                unselectParam.Remove(item);
            }
            this.lst_UnListparam.Items.Clear();
            this.lst_UnListparam.Items.AddRange(unselectParam.ToArray());
            this.lst_Selectparam.Items.Clear();
            this.lst_Selectparam.Items.AddRange(selectParam.ToArray());
        }

        private List<string> selectParam=new List<string>();

        private List<string> unselectParam=new List<string>();

        /// <summary>
        /// 添加单个变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btN_Add_Click(object sender, EventArgs e)
        {
            if (this.lst_UnListparam.Items.Count==0)
            {
                CommonMethod.AddOpLog(false,"没有参数可选择");
                return;
            }
            if (this.lst_UnListparam.SelectedIndex<0)
            {
                CommonMethod.AddOpLog(false, "没有参数可选择");
                return;
            }
            var result=this.lst_UnListparam.SelectedItem as string;
            int index=this.lst_UnListparam.SelectedIndex;
            selectParam.Add((string)result);
            unselectParam.RemoveAt(index);
            UpSelectParam();
        }

        /// <summary>
        /// 添加多个变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddAll_Click(object sender, EventArgs e)
        {
            if (this.lst_UnListparam.Items.Count==0)
            {
                CommonMethod.AddOpLog(false, "没有参数可选择");
                return;
            }
            if (this.lst_UnListparam.SelectedIndex<0)
            {
                CommonMethod.AddOpLog(false, "没有参数可选择");
                return;
            }

            for (int i = 0; i < this.lst_UnListparam.SelectedIndices.Count; i++)
            {
                unselectParam.Remove(this.lst_UnListparam.SelectedItems[i].ToString());
                selectParam.Add(this.lst_UnListparam.SelectedItems[i].ToString());
            }
            //selectParam.AddRange((string)result);
            //unselectParam.RemoveAt(index);
            UpSelectParam();
        }

        /// <summary>
        /// 删除单个变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.lst_Selectparam.Items.Count==0)
            {
                CommonMethod.AddOpLog(false, "没有参数可选择");
                return;
            }
            if (this.lst_Selectparam.SelectedIndex<0)
            {
                CommonMethod.AddOpLog(false, "没有参数可选择");
                return;
            }
            var result = this.lst_Selectparam.SelectedItem as string;
            int index = this.lst_Selectparam.SelectedIndex;
            selectParam.RemoveAt(index);
            unselectParam.Add(result);
            UpSelectParam();
        }

        /// <summary>
        /// 删除多个变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DelAll_Click(object sender, EventArgs e)
        {
            if (this.lst_Selectparam.Items.Count==0)
            {
                CommonMethod.AddOpLog(false, "没有参数可选择");
                return;
            }
            if (this.lst_Selectparam.SelectedIndex<0)
            {
                CommonMethod.AddOpLog(false, "没有参数可选择");
                return;
            }

            for (int i = 0; i < this.lst_Selectparam.SelectedIndices.Count; i++)
            {
                unselectParam.Add(this.lst_Selectparam.SelectedItems[i].ToString());
                selectParam.Remove(this.lst_Selectparam.SelectedItems[i].ToString());
            }
            //selectParam.AddRange((string)result);
            //unselectParam.RemoveAt(index);
            UpSelectParam();
        }

        /// <summary>
        /// 确认参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.OK;
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.No;
        }

        /// <summary>
        ///更改集合
        /// </summary>
        private void UpSelectParam()
        {
            this.lst_Selectparam.Items.Clear();
            this.lst_Selectparam.Items.AddRange(selectParam.ToArray());
            this.lst_UnListparam.Items.Clear();
            this.lst_UnListparam.Items.AddRange(unselectParam.ToArray());
        }

        #region 移动无框窗体
        private Point point;
        /// <summary>
        /// 得到鼠标左键的坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            point=new Point(e.X, e.Y);
        }
        /// <summary>
        /// 移动到鼠标左键拖动的地方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                //修改窗体的位置，得到移动
                this.Location=new Point(this.Location.X+e.X-point.X, this.Location.Y+e.Y-point.Y);
            }
        }
        #endregion

        public List<string> SelectAddOrDeleteParam()
        {
            return selectParam;
        }
    }
}
