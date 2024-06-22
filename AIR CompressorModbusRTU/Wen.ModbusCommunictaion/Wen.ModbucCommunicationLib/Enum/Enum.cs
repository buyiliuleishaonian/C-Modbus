using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wen.ModbucCommunicationLib.Enum
{
    /// <summary>
    /// PLC最小存储数据类型
    /// </summary>
    public enum AreaType
    {
        /// <summary>
        /// 西门子最小存储 1字节
        /// </summary>
        Byte=1,
        /// <summary>
        /// 三菱，欧姆龙 最小存储 1字
        /// </summary>
        Wrod=2,
    }

    /// <summary>
    /// 字符串类型
    /// </summary>
    public enum StringType
    {
        /// <summary>
        /// 十进制字符串
        /// </summary>
        DecString,
        /// <summary>
        /// 十六进制字符串
        /// </summary>
        HexString,
        /// <summary>
        /// ASCII字符串
        /// </summary>
        ASCIIString,
        /// <summary>
        /// BitConvert字符串
        /// </summary>
        BitConvertString,
        /// <summary>
        /// 西门子字符串
        /// </summary>
        SiemensString

    }

    /// <summary>
    /// Moudbus功能码
    /// </summary>
    public enum FunctionCode
    {
        /// <summary>
        /// 读取输出线圈
        /// </summary>
        ReadOutputStatus=0x01,
        /// <summary>
        /// 读取输入线圈
        /// </summary>
        ReadInputStatus=0x02,
        /// <summary>
        /// 读取输出寄存器
        /// </summary>
        ReadOutputRegister=0x3,
        /// <summary>
        /// 读取输入寄存器
        /// </summary>
        ReadInputRegister = 0x04,
        /// <summary>
        /// 写入单个输出线圈
        /// </summary>
        ForceCoil=0x05,
        /// <summary>
        /// 写入单个寄存器
        /// </summary>
        PreSetRegister=0x06,
        /// <summary>
        /// 写入多个输出线圈
        /// </summary>
        ForceMultiCoil=0x0F,
        /// <summary>
        /// 写入多个寄存器
        /// </summary>
        PreSetMultiRegister=0x10,
    }
}
