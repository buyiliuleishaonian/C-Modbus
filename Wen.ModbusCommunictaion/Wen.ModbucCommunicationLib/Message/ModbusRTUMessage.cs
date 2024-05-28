using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;
using Wen.ModbucCommunicationLib.Enum;
using Wen.ModbucCommunicationLib.Interface;

namespace Wen.ModbucCommunicationLib.Message
{
    /// <summary>
    /// ModbusRTU消息类
    /// 继承IMessage接口
    /// HeadDataLength
    /// </summary>
    public class ModbusRTUMessage : IMessage
    {
        /// <summary>
        /// 包头长度
        /// </summary>
        public int HeadDataLength { get; set; } = 0;
        /// <summary>
        /// 包头数据
        /// </summary>
        public byte[] HeadData { get  ; set  ; }
        /// <summary>
        /// 数据报文
        /// </summary>
        public byte[] ContentData { get  ; set  ; }
        /// <summary>
        /// 发送报文
        /// </summary>
        public byte[] SendData { get  ; set  ; }

        /// <summary>
        /// 数据点数量
        /// </summary>
        public int NumberOfPoint { get; set; }

        /// <summary>
        /// 功能码
        /// </summary>
        public FunctionCode FunctionCode { get; set; }

        /// <summary>
        /// 检验包头内容
        /// </summary>
        /// <param name="hedaData"></param>
        /// <returns></returns>
        public bool CheckHeadData(byte[] hedaData)
        {
            return true;
        }

        /// <summary>
        /// 返回报文的整体长度
        /// </summary>
        /// <returns></returns>
        public int GetContentLength()
        {
            switch (FunctionCode)
            {
                //判断布尔个数转化为字节
                case FunctionCode.ReadOutputStatus:
                case FunctionCode.ReadInputStatus:
                    return 5+IntLib.GetByteLengthFromBoolLength(NumberOfPoint);
                case FunctionCode.ReadOutputRegister:
                case FunctionCode.ReadInputRegister:
                    return 5+(NumberOfPoint*2);
                case FunctionCode.ForceCoil:
                case FunctionCode.PreSetRegister:
                case FunctionCode.ForceMultiCoil:
                case FunctionCode.PreSetMultiRegister:
                    return 8;
                default:
                    return 0;
            }
        }
    }
}
