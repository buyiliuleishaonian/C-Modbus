using ConfigLib;
using kYJBLL;
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

namespace AIR_CompressorModbusRTU
{
    public partial class FrmParamSet : Form
    {

        SQLLiteManage SQLLiteManage { get; set; } = new SQLLiteManage();
        public FrmParamSet()
        {
            InitializeComponent();
            Timer=new Timer();
            Timer.Interval=200;
            Timer.Tick+=Timer_Tick;
            Timer.Start();

            //修改配置信息
            this.tog_AutoStart.IsChecked=CommonMethod.config.AutoStart;
            this.tog_AutoLock.IsChecked=CommonMethod.config.AutoLock;
            this.tog_AutoLogin.IsChecked=CommonMethod.config.AutoLogin;
            this.up_LockPeriod.CurrentValue=CommonMethod.config.LockyPeriod;
            this.up_ShowSeriesCount.CurrentValue=CommonMethod.config.SaveShowSeriesCount;

            this.FormClosing+=FrmParamSet_FormClosing;

            this.tog_AutoLock.CheckedChanged+=Tog_AutoLock_CheckedChanged;

            this.tog_AutoLogin.CheckedChanged+=Tog_AutoLogin_CheckedChanged;

            this.tog_AutoStart.CheckedChanged+=Tog_AutoStart_CheckedChanged;

            this.up_LockPeriod.ValueChanged+=Up_LockPeriod_ValueChanged;

            this.up_ShowSeriesCount.ValueChanged+=Up_ShowSeriesCount_ValueChanged;

        }


        /// <summary>
        /// 修改曲线数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Up_ShowSeriesCount_ValueChanged(object sender, EventArgs e)
        {
            if (CommonMethod.SetSaveShowSeriesCount(Convert.ToInt32(((UpDownLabel)sender).CurrentValue)))
            {
                CommonMethod.AddOpLog(false, CommonMethod.SysAdmin.LoginName+"修改显示曲线数量"+" "+(((UpDownLabel)sender).CurrentValue).ToString());
                CommonMethod.GetConfig();
            }
        }

        /// <summary>
        /// 修改自动锁屏时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Up_LockPeriod_ValueChanged(object sender, EventArgs e)
        {
            if (CommonMethod.SetLockPeriod(Convert.ToInt32(((UpDownLabel)sender).CurrentValue)))
            {
                CommonMethod.AddOpLog(false, CommonMethod.SysAdmin.LoginName+"修改锁屏时间"+" "+(((UpDownLabel)sender).CurrentValue).ToString());
                CommonMethod.GetConfig();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tog_AutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (CommonMethod.SetAutoStart(((Toggle)sender).IsChecked))
            {
                //修改注册表
                AutoStart(((Toggle)sender).IsChecked);
                CommonMethod.AddOpLog(false, CommonMethod.SysAdmin.LoginName+"修改开机自动启动为"+" "+(((Toggle)sender).IsChecked).ToString());
                CommonMethod.GetConfig();
            }
        }

        /// <summary>
        /// 更改自动登入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tog_AutoLogin_CheckedChanged(object sender, EventArgs e)
        {
              if (CommonMethod.SetAutoLogin(((Toggle)sender).IsChecked))
            {
                CommonMethod.AddOpLog(false, CommonMethod.SysAdmin.LoginName+"修改程序自动登入"+" "+(((Toggle)sender).IsChecked).ToString());
                CommonMethod.GetConfig();
            }
        }


        /// <summary>
        /// 更改自动关锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tog_AutoLock_CheckedChanged(object sender, EventArgs e)
        {
           if (CommonMethod.SetAutoLock(((Toggle)sender).IsChecked))
            {
                CommonMethod.AddOpLog(false, CommonMethod.SysAdmin.LoginName+"修改无操作锁屏"+" "+(((Toggle)sender).IsChecked).ToString());
                CommonMethod.GetConfig();
            }
        }

        /// <summary>
        /// 关闭读取配置文件和
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmParamSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Timer?.Stop();
        }

        /// <summary>
        /// 定时更新变量实际值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateControl(this.panelEnhanced1);
        }

        /// <summary>
        /// 修改属性
        /// </summary>
        /// <param name="panel"></param>
        private void UpdateControl(Control panel)
        {
            foreach (Control ctl in panel.Controls)
            {
                if (ctl is TextSet textSet)
                {
                    float value = 0.0f;
                    if (float.TryParse(CommonMethod.PLCDevice.CurrentValue[textSet.BindVarName].ToString(), out value))
                    {
                        textSet.CurrentValue=value.ToString("f1");
                    }
                }
            }
        }

        private Timer Timer;

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSetCommon_ControlDoubleClick(object sender, EventArgs e)
        {
            if (sender is TextSet set)
            {
                VariableBase variable = CommonMethod.PLCDevice.VarList.FirstOrDefault(c => c.VarName==set.BindVarName);
                FrmModify frm = new FrmModify(variable);
                frm.ShowDialog();
            }
        }

        #region 配置操作
        /// <summary>
        /// 修改开机自动启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tog_AutoStart_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        /// <summary>
        /// 修改程序自动登入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tog_AutoLogin_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 修改自动锁屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tog_AutoLock_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// 修改锁屏时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void up_LockPeriod_ValueChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 修改显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void up_ShowSeriesCount_ValueChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 开机自动启动注册表
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
        #endregion

        /// <summary>
        /// 数据表初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Operate_Click(object sender, EventArgs e)
        {
            if (new FrmMessageBoxWithAck("数据库操作", "是否确认初始化数据库").ShowDialog()==DialogResult.OK)
            {
                List<string> list = new List<string>() { "insertTime" };
                list.AddRange(CommonMethod.PLCDevice.StoreVarList.Select(c => c.VarName).ToList());

                var result = SQLLiteManage.ReCreateActualTable("ActualTable", list);
                if (result.IsSuccess)
                {
                    new FrmMessageBoxWithOutAck("数据库操作", "数据库操作成功").ShowDialog();
                    CommonMethod.AddOpLog(false, CommonMethod.SysAdmin.LoginName+"初始化表数据成功");
                }
                else
                {
                    new FrmMessageBoxWithOutAck("数据库操作", "数据库操作失败").ShowDialog();
                    CommonMethod.AddOpLog(true, CommonMethod.SysAdmin.LoginName+"初始化表数据失败");
                }
            }
        }
    }
}
