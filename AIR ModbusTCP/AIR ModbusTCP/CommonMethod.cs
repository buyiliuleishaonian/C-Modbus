using ConfigLib;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.ModbucCommunicationLib.Library;
using thinger.DataConvertLib;

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
        public static ModbusTCP PLC { get; set; } = new ModbusTCP();

        /// <summary>
        /// 设备配置对象
        /// </summary>
        public static ModbusTCPDevice PLCDevice { get; set; }=new ModbusTCPDevice();

        /// <summary>
        /// 写入PLC
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="Name"></param>
        public void WritePLC(string addRess,string value)
        {
            PLC.WriteCommon();
        }
    }
}
