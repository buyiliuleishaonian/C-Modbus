using AIR_BLL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.ControlLib;

namespace AIR_ModbusTCP
{
    public partial class FrmParamSet : Form
    {
        public FrmParamSet()
        {
            InitializeComponent();

            timer=new System.Timers.Timer();
            timer.Interval=200;
            timer.Elapsed+=Timer_Elapsed;
            timer.Start();

            this.tog_AutoLock.IsChecked=CommonMethod.Config.AutoLock;
            this.tog_AutoLogin.IsChecked=CommonMethod.Config.AutoLogin;
            this.tog_AutoStart.IsChecked=CommonMethod.Config.AutoStart;

            this.up_LockPeriod.CurrentValue=CommonMethod.Config.LockyPeriod;
            this.up_ShowSeriesCount.CurrentValue=CommonMethod.Config.SaveShowSeriesCount;

            //添加Tog控件，变化触发事件
            this.tog_AutoStart.CheckedChanged+=Tog_AutoStart_CheckedChanged;
            this.tog_AutoLock.CheckedChanged+=Tog_AutoLock_CheckedChanged;
            this.tog_AutoLogin.CheckedChanged+=Tog_AutoLogin_CheckedChanged;
            this.up_LockPeriod.ValueChanged+=Up_LockPeriod_ValueChanged;
            this.up_ShowSeriesCount.ValueChanged+=Up_ShowSeriesCount_ValueChanged;


            this.FormClosing+=FrmParamSet_FormClosing;
        }


        #region 修改配置文件
        private void Tog_AutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (CommonMethod.WriteAutoLogin(this.tog_AutoLogin.IsChecked))
            {
                CommonMethod.Addoperatelog(false, "修改自动登入成功");
                CommonMethod.ReadConfig();
            }
        }

        private void Up_ShowSeriesCount_ValueChanged(object sender, EventArgs e)
        {
            if (CommonMethod.WriteDrawSeriable(this.up_ShowSeriesCount.CurrentValue.ToString()))
            {
                CommonMethod.Addoperatelog(false, "修改曲线显示数量成功");
                CommonMethod.ReadConfig();
            }
        }

        private void Up_LockPeriod_ValueChanged(object sender, EventArgs e)
        {
            if (CommonMethod.WriteStartTime(this.up_LockPeriod.CurrentValue.ToString()))
            {
                CommonMethod.Addoperatelog(false, "修改自动黑屏时间成功");
                CommonMethod.ReadConfig();
            }
        }

        private void Tog_AutoLock_CheckedChanged(object sender, EventArgs e)
        {
            if (CommonMethod.WriteAutoLock(this.tog_AutoLock.IsChecked))
            {
                CommonMethod.Addoperatelog(false, "无操作自动锁屏");
                CommonMethod.ReadConfig();
            }
        }

        private void Tog_AutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (CommonMethod.WriteAutoStart(this.tog_AutoStart.IsChecked))
            {
                AutoStart(((Toggle)sender).IsChecked);
                CommonMethod.Addoperatelog(false, "开机自动启动");
                CommonMethod.ReadConfig();
            }
        }
        #endregion


        /// <summary>
        ///关闭定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmParamSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        #region 修改plc限定信息
        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                Initial();
            }));
        }

        private System.Timers.Timer timer;

        public void Initial()
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                foreach (var item in this.panelEnhanced1.Controls)
                {
                    if (item is TextSet txt)
                    {
                        if (txt.BindVarName!=null&&txt.BindVarName.ToString().Length>0)
                        {
                            var res = CommonMethod.PLCDevice.VarList.Where(c => c.VarName==txt.BindVarName).First().VarValue;
                            txt.CurrentValue=res==null ? "0.0" : res.ToString();
                        }
                    }
                }
            }
        }
        #endregion


        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonTextSet_ControlDoubleClick(object sender, EventArgs e)
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                if (sender is TextSet txt)
                {
                    if (txt.BindVarName!=null&&txt.BindVarName.ToString().Length>0)
                    {
                        FrmModify frm = new FrmModify(txt.BindVarName.ToString());
                        frm.ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// 数据库操作属性
        /// </summary>
        private SQLiteManage SQLiteManage { get; set; } = new SQLiteManage();

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Operate_Click(object sender, EventArgs e)
        {
            if (CommonMethod.PLCDevice.IsConnected&&CommonMethod.PLCDevice.StoreVarList.Count>0)
            {

                if (SQLiteManage.SelectTable("ActualTable"))SQLiteManage.DeleteTable("ActualTable"); 
                var varname= CommonMethod.PLCDevice.StoreVarList.Select(c => c.VarName).ToList();
                varname.Add("InsertTime");
                if (SQLiteManage.CreateTable("ActualTable", varname, true))
                {
                    CommonMethod.Addoperatelog(false, "初始化数据库成功");
                }
                else
                {
                    CommonMethod.Addoperatelog(false, "初始化数据库错误");
                }
            }
        }


        /// <summary>
        /// 开机自动启动/关闭
        /// </summary>
        /// <param name="start"></param>
        private void AutoStart(bool start = true)
        {
            if (start)
            {
                RegistryKey R_Local = Registry.CurrentUser;
                RegistryKey R_run = R_Local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                R_run.SetValue("AIR CompressorModbusRTU", System.Windows.Forms.Application.ExecutablePath);
                R_run.Close();
                R_Local.Close();
            }
            else
            {
                RegistryKey R_Local = Registry.CurrentUser;
                RegistryKey R_run = R_Local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                R_run.DeleteValue("AIR CompressorModbusRTU", false);
                R_run.Close();
                R_Local.Close();
            }
        }

    }
}
