using CommonHelper;
using ConfigLib;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wen.ModbucCommunicationLib.Helper;
using Wen.ModbucCommunicationLib.Library;
using Wen.ModbucCommunicationLib.StoreArea;
using DataType = thinger.DataConvertLib.DataType;

namespace AIR_CompressorModbusRTU
{
    /// <summary>
    /// 公用配置类
    /// </summary>
    public class CommonMethod
    {
        /// <summary>
        /// 用户类
        /// </summary>
        public static SysAdmin SysAdmin { get; set; }

        /// <summary>
        /// PLC配置
        /// </summary>
        public static ModbusRTUDevice PLCDevice { get; set; }

        /// <summary>
        /// 配置文件
        /// </summary>
        public static Config config = new Config();

        /// <summary>
        /// 配置文件路径
        /// </summary>
        private static string initialPath { get; set; } = Application.StartupPath+@"\Config\Config.ini";

        public static int tickCount = 0;

        /// <summary>
        /// PLC通信对象，（端口号，串口号等）
        /// </summary>
        public static ModbusRTU PLC { get; set; } = new ModbusRTU();

        /// <summary>
        /// 日志系统委托对象
        /// </summary>
        public static Action<bool, string> AddLogDelegate;

        /// <summary>
        /// 操作对象
        /// </summary>
        public static Action<bool, string> AddLogOperaDelegate;

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="failOrSuccess"></param>
        /// <param name="log"></param>
        public static void AddLog(bool failOrSuccess, string log)
        {
            AddLogDelegate(failOrSuccess, log);
        }


        /// <summary>
        /// 操作日志
        /// </summary>
        /// <param name="failOrSuccess"></param>
        /// <param name="log"></param>
        public static void AddOpLog(bool failOrSuccess, string log)
        {
            AddLogOperaDelegate(failOrSuccess, log);
        }

        /// <summary>
        /// 通用写入PLC
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="varValue"></param>
        /// <returns></returns>
        public static OperateResult CommonWrite(string varName, string varValue)
        {
            //查找变量
            var variable = PLCDevice.VarList.Where(c => c.VarName==varName).FirstOrDefault();
            if (variable!=null)
            {
                //线性转化变量，此时需要知道变量的DataType
                DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.VarType);
                var value = MigrationLib.SetMigrationValue(varValue, dataType, variable.Scale.ToString(), variable.Offset.ToString());
                if (value.IsSuccess)
                {
                    switch (dataType)
                    {
                        case DataType.Bool:
                            var result = ModbusHelper.ModbusAddressAnalysis(variable.VarAddress, 0, PLCDevice.IsShortAddress);
                            if (result.IsSuccess)
                            {
                                return PLC.WriteBool(variable.VarAddress, bool.Parse(varValue),
                                    (result.Content1==ModbusStoreArea.x0&&result.Content1==ModbusStoreArea.x1) ? true : false);
                            }
                            return OperateResult.CreateFailResult($"变量{varName}不存在，请检查变量表");
                        case DataType.Byte:
                            return PLC.WriteByte(variable.VarAddress, Convert.ToByte(varValue));
                        case DataType.SByte:
                            return PLC.WriteByte(variable.VarAddress, Convert.ToByte(varValue));
                        case DataType.Short:
                            return PLC.WriteShort(variable.VarAddress, Convert.ToInt16(varValue));
                        case DataType.UShort:
                            return PLC.WriteUShort(variable.VarAddress, Convert.ToUInt16(varValue));
                        case DataType.Int:
                            return PLC.WriteInt(variable.VarAddress, Convert.ToInt32(varValue));
                        case DataType.UInt:
                            return PLC.WriteUInt(variable.VarAddress, Convert.ToUInt32(varValue));
                        case DataType.Float:
                            return PLC.WriteFloat(variable.VarAddress, Convert.ToSingle(varValue));
                        case DataType.Double:
                            return PLC.WriteDouble(variable.VarAddress, Convert.ToDouble(varValue));
                        case DataType.Long:
                            return PLC.WriteLong(variable.VarAddress, Convert.ToInt64(varValue));
                        case DataType.ULong:
                            return PLC.WriteULong(variable.VarAddress, Convert.ToUInt64(varValue));
                        case DataType.String:
                            return PLC.WriteString(variable.VarAddress, varValue);
                        case DataType.ByteArray:
                            return PLC.WriteByteArray(variable.VarAddress, ByteArrayLib.GetByteArrayFromString(varValue, Encoding.ASCII));
                        default:
                            return OperateResult.CreateFailResult($"变量{varName}不存在，请检查变量表");
                    }
                }
                else
                {
                    return OperateResult.CreateFailResult($"变量{varName}不存在，请检查变量表");
                }
            }
            else
            {
                return OperateResult.CreateFailResult($"变量{varName}不存在，请检查变量表");
            }
        }

        #region 配置文件操作
        /// <summary>
        /// 读取配置文件
        /// </summary>
        public static void GetConfig()
        {
            if (File.Exists(initialPath))
            {
                config.AutoStart=Convert.ToBoolean(IniConfigHelper.ReadIniData("配置文件", "开机自动启动", "false", initialPath));
                config.AutoLogin=Convert.ToBoolean(IniConfigHelper.ReadIniData("配置文件", "软件自动启动", "false", initialPath));
                config.AutoLock=Convert.ToBoolean(IniConfigHelper.ReadIniData("配置文件", "无操作自动锁屏", "false", initialPath));
                config.LockyPeriod=Convert.ToInt32(IniConfigHelper.ReadIniData("配置文件", "自动锁屏时间", "0", initialPath));
                config.SaveShowSeriesCount=Convert.ToInt32(IniConfigHelper.ReadIniData("配置文件", "显示曲线数量", "0", initialPath));
            }
        }

        /// <summary>
        /// 写入配置文件
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetAutoStart(bool value)
        {
            return IniConfigHelper.WriteIniData("配置文件", "开机自动启动", value.ToString(), initialPath);
        }

        public static bool SetAutoLogin(bool value)
        {
            return IniConfigHelper.WriteIniData("配置文件", "软件自动启动", value.ToString(), initialPath);
        }
        public static bool SetAutoLock(bool value)
        {
            return IniConfigHelper.WriteIniData("配置文件", "无操作自动锁屏", value.ToString(), initialPath);
        }

        public static bool SetLockPeriod(int value)
        {
            return IniConfigHelper.WriteIniData("配置文件", "自动锁屏时间", value.ToString(), initialPath);
        }
        public static bool SetSaveShowSeriesCount(int value)
        {
            return IniConfigHelper.WriteIniData("配置文件", "显示曲线数量", value.ToString(), initialPath);
        }

        #endregion

    }
}
