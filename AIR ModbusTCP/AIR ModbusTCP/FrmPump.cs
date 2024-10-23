using ConfigLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using thinger.ControlLib;
using thinger.DataConvertLib;
using Wen.ModbucCommunicationLib.Helper;

namespace AIR_ModbusTCP
{
    public partial class FrmPump : Form
    {
        public FrmPump(string varName)
        {
            InitializeComponent();
            updateTime=new System.Timers.Timer();
            updateTime.Interval=100;
            updateTime.Elapsed+=UpdateTime_Elapsed;
            updateTime.Start();
            varibaleName=varName;

            index=varibaleName.Contains("1") ? 1 : 2;
            this.lbl_Title.Text = index.ToString()+"#冷却循环泵监控";
            this.textShow1.BindVarName=$"LQB{index}_Current";
            this.textShow2.BindVarName=$"LQB{index}_Speed";
            this.textShow3.BindVarName=$"LQB{index}_TotalPower";
            this.textShow4.BindVarName=$"LQB{index}_HeaterTemp";
            this.textShow5.BindVarName=$"LQB{index}_Fre";
            this.textShow6.BindVarName=$"LQB{index}_Power";
            this.textShow7.BindVarName=$"LQB{index}_RunHour";

            this.simpleLed1.BindVarName=$"LQB{index}_RunState";
            this.simpleLed2.BindVarName=$"LQB{index}_FaultState";

            this.btn_Mode.Tag=$"LQB{index}_Mode";
            this.btn_Run.Tag=$"LQB{index}_Start";
            this.btn_Stop.Tag=$"LQB{index}_Stop";

            this.FormClosing+=FrmPump_FormClosing;
        }

        private void FrmPump_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.updateTime.Stop();
            this.DialogResult= DialogResult.No;

        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                UpdatePumpValue();

                bool value = false;
                if (bool.TryParse(CommonMethod.PLCDevice.CurrentValue[this.btn_Mode.Tag.ToString()].ToString(), out value))
                {
                    this.btn_Mode.Text=value ? "自动模式" : "手动模式";
                    this.btn_Stop.Enabled=this.btn_Run.Enabled=!value;
                }
            }));
        }

        public System.Timers.Timer updateTime { get; set; } = null;

        public string varibaleName { get; set; }

        public int index { get; set; }

        /// <summary>
        /// 修改控件
        /// </summary>
        private void UpdatePumpValue()
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                foreach (var item in this.panelEnhanced1.Controls)
                {
                    if (item is TextShow txt)
                    {
                        var result = CommonMethod.PLCDevice.VarList.Where(c => c.VarName==txt.BindVarName).First().VarValue;
                        if (result!=null)
                        {
                            txt.CurrentValue=result.ToString();
                        }
                    }
                    else if (item is SimpleLed led)
                    {
                        var result = CommonMethod.PLCDevice.VarList.Where(c => c.VarName==led.BindVarName).First().VarValue;
                        if (result!=null)
                        {
                            led.State=Convert.ToBoolean(result.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.FrmPump_FormClosing(null, null);
        }

        /// <summary>
        /// 控制冷却泵运行模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Mode_Click(object sender, EventArgs e)
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                bool value = false;
                var variable = CommonMethod.PLCDevice.VarList.Where(c => c.VarName==this.btn_Mode.Tag.ToString()).First();
                if (bool.TryParse(CommonMethod.PLCDevice.CurrentValue[this.btn_Mode.Tag.ToString()].ToString(), out value))
                {
                    var result = CommonMethod.WritePLC(variable.VarAddress, (!value).ToString());
                    if (result.IsSuccess)
                    {

                    }

                }
            }
        }

        /// <summary>
        /// 手动模式下启动冷却泵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Run_Click(object sender, EventArgs e)
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                var result= ControlLQB(false);
                if (result.IsSuccess)
                {
                    CommonMethod.Addoperatelog(false, "启动"+this.lbl_Title.Text);
                }
                else
                {
                    CommonMethod.Addoperatelog(true, "启动"+this.lbl_Title.Text+"失败");
                }
            }
        }

        /// <summary>
        /// 手动模式下停止冷却泵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                var result= ControlLQB(true);
                if (result.IsSuccess)
                {
                    CommonMethod.Addoperatelog(false, "关闭"+this.lbl_Title.Text);
                }
                else
                {
                    CommonMethod.Addoperatelog(true, "关闭"+this.lbl_Title.Text+"失败");
                }
            }
        }


        private OperateResult ControlLQB(bool isRun)
        {
            var variable1 = CommonMethod.PLCDevice.VarList.Where(c => c.VarName==this.btn_Run.Tag.ToString()).FirstOrDefault();
            var variable2 = CommonMethod.PLCDevice.VarList.Where(c => c.VarName==this.btn_Stop.Tag.ToString()).FirstOrDefault();
            var variable3 = CommonMethod.PLCDevice.VarList.Where(c => c.VarName==this.simpleLed1.BindVarName.ToString()).FirstOrDefault();

            if (isRun)
            {
                var result1 = CommonMethod.WritePLC(variable1.VarAddress, "0");
                var result2 = CommonMethod.WritePLC(variable2.VarAddress, "1");
                var result3 = CommonMethod.WritePLC(variable3.VarAddress, "0");
                if (result1.IsSuccess==false)
                {
                    return OperateResult.CreateFailResult(result1.Message);
                }
                else if (result2.IsSuccess==false)
                {
                    return OperateResult.CreateFailResult(result2.Message);
                }
                else if (result3.IsSuccess==false)
                {
                    return OperateResult.CreateFailResult(result3.Message);
                }
            }
            else
            {
                var result1 = CommonMethod.WritePLC(variable1.VarAddress, "1");
                var result2 = CommonMethod.WritePLC(variable2.VarAddress, "0");
                var result3 = CommonMethod.WritePLC(variable3.VarAddress, "1");
                if (result1.IsSuccess==false)
                {
                    return OperateResult.CreateFailResult(result1.Message);
                }
                else if (result2.IsSuccess==false)
                {
                    return OperateResult.CreateFailResult(result2.Message);
                }
                else if (result3.IsSuccess==false)
                {
                    return OperateResult.CreateFailResult(result3.Message);
                }
            }
            return OperateResult.CreateSuccessResult();
        }


        #region 窗体移动
        private Point size;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                size=new Point(e.X, e.Y);
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                this.Location=new Point(this.Location.X+e.X-size.X, this.Location.Y+e.Y-size.Y);
            }
        }
        #endregion

    }
}
