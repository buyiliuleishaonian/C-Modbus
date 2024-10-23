using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wen.KYJControlLib;

using System.Timers;
using Wen.ModbucCommunicationLib.Helper;
using thinger.DataConvertLib;

namespace AIR_ModbusTCP
{
    public partial class FrmTapControl : Form
    {
        public FrmTapControl()
        {
            InitializeComponent();
            Update=new System.Timers.Timer();
            Update.Interval=100;
            Update.Elapsed+=Update_Elapsed;
            Update.Start();


            this.FormClosing+=FrmTapControl_FormClosing;
        }

        private void FrmTapControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            Update?.Stop();
        }

        private void Update_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                Initial();
            }));
        }

        private System.Timers.Timer Update;

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initial()
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                foreach (var item in this.panelEnhanced1.Controls)
                {
                    if (item is DeviceControl dev)
                    {
                        var result1 = CommonMethod.PLCDevice.VarList.Find(c => c.VarName==dev.DeviceState).VarValue;
                        dev.State=Convert.ToByte(result1);
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
            this.Update?.Stop();
            this?.Close();
        }

        /// <summary>
        /// 控制阀的开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceCommon_DeviceControlClick(object sender, EventArgs e)
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                if (sender.ToString().ToLower().Contains("close"))
                {
                    foreach (var item in this.panelEnhanced1.Controls)
                    {
                        if (item is DeviceControl dev)
                        {
                            if (dev.CloseAddress==sender.ToString())
                            {
                               var result= ControlTap(dev,false);
                                if (result.IsSuccess)
                                {
                                    CommonMethod.Addoperatelog(false, "关闭"+dev.BindVarName);
                                }
                                else
                                {
                                    CommonMethod.Addoperatelog(true, "关闭"+dev.BindVarName+"失败");
                                }
                            }
                        }
                    }
                }
                else if (sender.ToString().ToLower().Contains("open"))
                {
                    foreach (var item in this.panelEnhanced1.Controls)
                    {
                        if (item is DeviceControl dev)
                        {
                            if (dev.OpenAddress==sender.ToString())
                            {

                               var result=  ControlTap(dev,true);
                                if (result.IsSuccess)
                                {
                                    CommonMethod.Addoperatelog(false, "打开"+dev.BindVarName);
                                }
                                else
                                {
                                    CommonMethod.Addoperatelog(true, "打开"+dev.BindVarName+"失败");
                                }
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 控制阀
        /// </summary>
        /// <param name="dev"></param>
        /// <param name="isOpen"></param>
        /// <returns></returns>
        private static OperateResult ControlTap(DeviceControl dev, bool isOpen)
        {
            var result = CommonMethod.PLCDevice.VarList;
            var variable1 = CommonMethod.PLCDevice.VarList.Where(c => c.VarName==dev.CloseAddress).FirstOrDefault();
            var variable2 = CommonMethod.PLCDevice.VarList.Where(c => c.VarName==dev.OpenAddress).FirstOrDefault();
            var variable3 = CommonMethod.PLCDevice.VarList.Where(c => c.VarName==dev.DeviceState).FirstOrDefault();


            var resul111t = ModbusHelper.ModbusAddressAnalysis(variable1.VarAddress, CommonMethod.PLC.DevAddress, CommonMethod.PLCDevice.IsShortAddress);

            if (isOpen)
            {
                dev.State =Convert.ToByte("1");
                var result1 = CommonMethod.WritePLC(variable1.VarAddress, "0");
                var result2 = CommonMethod.WritePLC(variable2.VarAddress, "1");
                var result3 = CommonMethod.WritePLC(variable3.VarAddress, dev.State.ToString());
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
                dev.State =Convert.ToByte("0");
                var result1 = CommonMethod.WritePLC(variable1.VarAddress, "1");
                var result2 = CommonMethod.WritePLC(variable2.VarAddress, "0");
                var result3 = CommonMethod.WritePLC(variable3.VarAddress, dev.State.ToString());

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
    }
}
