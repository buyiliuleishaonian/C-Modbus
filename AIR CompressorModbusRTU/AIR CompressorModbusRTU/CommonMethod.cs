using ConfigLib;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.ModbucCommunicationLib.Library;

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
        /// PLC通信对象，（端口号，串口号等）
        /// </summary>
        public  static ModbusRTU  PLC { get; set; }=new ModbusRTU();


        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="failOrSuccess"></param>
        /// <param name="log"></param>
        public static void AddLog(bool failOrSuccess,string log)
        {
            Console.WriteLine(log);
        }
    }
}
