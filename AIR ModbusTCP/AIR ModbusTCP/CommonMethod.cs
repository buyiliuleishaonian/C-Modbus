using ConfigLib;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.ModbucCommunicationLib.Library;
using thinger.DataConvertLib;
using System.Diagnostics;
using System.Windows.Forms;


namespace AIR_ModbusTCP
{
    public class CommonMethod
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public static SysAdminModel SysAdminModel { get; set; } = new SysAdminModel();

        /// <summary>
        /// 通信对象
        /// </summary>
        public static Wen.ModbucCommunicationLib.Library.ModbusTCP PLC { get; set; } = new Wen.ModbucCommunicationLib.Library.ModbusTCP();

        /// <summary>
        /// 设备配置对象
        /// </summary>
        public static ModbusTCPDevice PLCDevice { get; set; } = new ModbusTCPDevice();

        /// <summary>
        /// 写入PLC
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="Name"></param>
        public static OperateResult WritePLC(string addRess, string value)
        {
            var variable = PLCDevice.VarList.First(c => c.VarAddress==addRess);
            OperateResult result = null;
            if (variable!=null)
            {
                DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.VarType);

                switch (dataType)
                {
                    case DataType.Bool:
                        result=  PLC.WriteCommon(variable.VarAddress, BitLib.GetBitArrayFromBitArrayString(value));
                        break;
                    case DataType.Byte:
                    case DataType.SByte:
                        result=  PLC.WriteCommon(variable.VarAddress, ByteArrayLib.GetByteArrayFromHexString(value));
                        break;
                    case DataType.Short:
                        result=  PLC.WriteCommon(variable.VarAddress, ShortLib.GetShortArrayFromString(value));
                        break;
                    case DataType.UShort:
                        result=  PLC.WriteCommon(variable.VarAddress, UShortLib.GetUShortArrayFromString(value));
                        break;
                    case DataType.Int:
                        result=  PLC.WriteCommon(variable.VarAddress, IntLib.GetIntArrayFromString(value));
                        break;
                    case DataType.UInt:
                        result=  PLC.WriteCommon(variable.VarAddress, UIntLib.GetUIntArrayFromString(value));
                        break;
                    case DataType.Float:
                        result= PLC.WriteCommon(variable.VarAddress, FloatLib.GetFloatArrayFromString(value));
                        break;
                    case DataType.Double:
                        result= PLC.WriteCommon(variable.VarAddress, DoubleLib.GetDoubleArrayFromString(value));
                        break;
                    case DataType.Long:
                        result=  PLC.WriteCommon(variable.VarAddress, LongLib.GetLongArrayFromString(value));
                        break;
                    case DataType.ULong:
                        result=   PLC.WriteCommon(variable.VarAddress, ULongLib.GetULongArrayFromString(value));
                        break;
                    case DataType.String:
                        result=   PLC.WriteCommon(variable.VarAddress, value);
                        break;
                    default:
                        return OperateResult.CreateFailResult($"变量{variable.VarName}数据类型{variable.VarType}不对");
                }
            }
            else
            {
                return OperateResult.CreateFailResult($"变量地址{addRess}错误,请检查文件地址是否错误");
            }
            return result;
        }

        /// <summary>
        /// 配置文件属性
        /// </summary>
        public static ConfigModel Config { get; set; } = new ConfigModel();
        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string configPath { get; set; } = Application.StartupPath+@"\Config\config.ini";

        public static Action<bool, string> AddSystemLog;

        public static Action<bool, string> AddOperateLog;

        public static int tickCount = 0;

        /// <summary>
        /// 系统日志添加
        /// </summary>
        /// <param name="isFaileorSuccess"></param>
        /// <param name="log"></param>
        public static void Addsystemlog(bool isFaileorSuccess, string log)
        {
            AddSystemLog(isFaileorSuccess, log);
        }


        /// <summary>
        /// 操作日志添加
        /// </summary>
        /// <param name="isFaileorSuccess"></param>
        /// <param name="log"></param>
        public static void Addoperatelog(bool isFaileorSuccess, string log)
        {
            AddOperateLog(isFaileorSuccess, log);
        }


        /// <summary>
        /// 创建配置文件
        /// </summary>
        public static void CreateConfig(string path)
        {
            CommonHelper.IniConfigHelper.WriteIniData("配置文件", "开机自动启动", "false", path);
            CommonHelper.IniConfigHelper.WriteIniData("配置文件", "软件自动登入", "false", path);
            CommonHelper.IniConfigHelper.WriteIniData("配置文件", "无操作自动锁屏", "false", path);
            CommonHelper.IniConfigHelper.WriteIniData("配置文件", "自动锁屏时间", "10", path);
            CommonHelper.IniConfigHelper.WriteIniData("配置文件", "显示曲线数量", "3", path);
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        public static void ReadConfig()
        {
            Config.AutoStart=CommonHelper.IniConfigHelper.ReadIniData("配置文件", "开机自动启动", "false", configPath).ToString().ToLower()=="false" ? false : true;
            Config.AutoLogin=CommonHelper.IniConfigHelper.ReadIniData("配置文件", "软件自动登入", "false", configPath).ToString().ToLower()=="false" ? false : true;
            Config.AutoLock=  CommonHelper.IniConfigHelper.ReadIniData("配置文件", "无操作自动锁屏", "false", configPath).ToString().ToLower()=="false" ? false : true;
            Config.LockyPeriod=Convert.ToInt32(CommonHelper.IniConfigHelper.ReadIniData("配置文件", "自动锁屏时间", "10", configPath));
            Config.SaveShowSeriesCount=Convert.ToInt32(CommonHelper.IniConfigHelper.ReadIniData("配置文件", "显示曲线数量", "3", configPath));
        }

        #region 修改配置文件
        public static bool WriteAutoLock(bool islock)
        {
            return CommonHelper.IniConfigHelper.WriteIniData("配置文件", "开机自动启动", islock.ToString(), configPath);

        }

        public static bool WriteAutoLogin(bool islock)
        {
            return CommonHelper.IniConfigHelper.WriteIniData("配置文件", "软件自动登入", islock.ToString(), configPath);

        }
        public static bool WriteAutoStart(bool islock)
        {
            return CommonHelper.IniConfigHelper.WriteIniData("配置文件", "无操作自动锁屏", islock.ToString(), configPath);

        }
        public static bool WriteDrawSeriable(string vlaue)
        {
            return CommonHelper.IniConfigHelper.WriteIniData("配置文件", "显示曲线数量", vlaue, configPath);

        }
        public static bool WriteStartTime(string value)
        {
            return CommonHelper.IniConfigHelper.WriteIniData("配置文件", "自动锁屏时间", value, configPath);

        }

        #endregion

    }
}
