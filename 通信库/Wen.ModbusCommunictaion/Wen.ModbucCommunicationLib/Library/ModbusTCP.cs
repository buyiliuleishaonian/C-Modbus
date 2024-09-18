using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;
using Wen.ModbucCommunicationLib.Base;
using Wen.ModbucCommunicationLib.Enum;
using Wen.ModbucCommunicationLib.Helper;
using Wen.ModbucCommunicationLib.Message;

namespace Wen.ModbucCommunicationLib.Library
{
    /// <summary>
    /// ModbusTCP通信基类
    /// </summary>
    public class ModbusTCP :NetDeviceBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataFormat"></param>
        public ModbusTCP(DataFormat dataFormat = DataFormat.ABCD)
        {
            this.DataFormat= dataFormat;
        }

        /// <summary>
        /// 从站地址
        /// </summary>
        public byte DevAddress { get; set; } = 1;

        /// <summary>
        /// 是否是短整型地址
        /// </summary>
        public bool IsShortAddress { get; set; } = true;

        /// <summary>
        /// 事务锁
        /// </summary>
        private static readonly object transtationlock = new object();


        private ushort eventIndex=0;
        /// <summary>
        /// 事务标识符
        /// </summary>
        public ushort EventIndex
        {
            get
            {
                lock (transtationlock)
                {
                    return eventIndex==ushort.MaxValue ? (ushort)1:++eventIndex;
                }
            }
            set { eventIndex = value; }
        }


        /// <summary>
        /// 读取布尔数组,按照ModbusRTU，可能只会进行消息读取
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public override OperateResult<bool[]> ReadBoolArray(string address, ushort length)
        {
            //拼接报文
            var sendCommand = BuildReadMessageFrame(address, length);
            if (!sendCommand.IsSuccess) return OperateResult.CreateFailResult<bool[]>("报文拼接错误");
            //发送报文
            //接收报文
            //对于消息
            //1、不清楚返回长度，不用写消息类
            //2、只清楚返回长度，将HeadLength=0
            //3、如果需要根据HeadData数据，来写后续报文，需要写消息类

            byte[] response = null;
            ModbusTCPMessage message = new ModbusTCPMessage()
            {
                //这个功能码，只能给用来计算报文返回长度
                FunctionCode=FunctionCode.ReadOutputStatus,
                NumberOfPoint=length,
            };
            var result = SendAndReceive(sendCommand.Content, ref response, message);

            if (result.IsSuccess)
            {
                //验证报文
                if (CheckResponse(response, UShortLib.GetByteLengthFromBoolLength(length), true, sendCommand.Content[6]).IsSuccess)
                {
                    //解析报文
                    sendCommand=AnalysisResponseMessage(response, true);
                    if (sendCommand.IsSuccess)
                    {
                        //当读取线圈的长度不是8的倍数，就可以多一个字节，其中某些不属于读取的内容
                        //所以查询每一个字节，截取所读取的长度
                        return OperateResult.CreateSuccessResult(sendCommand.Content.Select(c => c==0x01).Take(length).ToArray());
                    }
                    else
                    {
                        return OperateResult.CreateFailResult<bool[]>(sendCommand);
                    }
                }
            }
            //报错
            return OperateResult.CreateFailResult<bool[]>(sendCommand);
        }

        /// <summary>
        /// 读取字节数组,按照ModbusRTU，可能只会进行消息读取
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public override OperateResult<byte[]> ReadByteArray(string address, ushort length)
        {
            //拼接报文
            var sendCommand = BuildReadMessageFrame(address, length);
            if (!sendCommand.IsSuccess) return OperateResult.CreateFailResult<byte[]>("报文拼接错误");
            //发送报文
            //接收报文
            //对于消息
            //1、不清楚返回长度，不用写消息类
            //2、只清楚返回长度，将HeadLength=0
            //3、如果需要根据HeadData数据，来写后续报文，需要写消息类

            byte[] response = null;
            ModbusTCPMessage message = new ModbusTCPMessage()
            {
                //这个功能码，只能给用来计算报文返回长度
                FunctionCode=FunctionCode.ReadInputRegister,
                NumberOfPoint=length,
            };
            var result = SendAndReceive(sendCommand.Content, ref response, message);

            if (result.IsSuccess)
            {
                //验证报文
                if (CheckResponse(response, (ushort)(length*2), true, sendCommand.Content[6]).IsSuccess)
                {
                    //解析报文
                    sendCommand=AnalysisResponseMessage(response, false);
                    if (sendCommand.IsSuccess)
                    {
                        //当读取线圈的长度不是8的倍数，就可以多一个字节，其中某些不属于读取的内容
                        //所以查询每一个字节，截取所读取的长度
                        return sendCommand;
                    }
                    else
                    {
                        return OperateResult.CreateFailResult<byte[]>(sendCommand);
                    }
                }
            }
            //报错
            return OperateResult.CreateFailResult<byte[]>(sendCommand);
        }

        /// <summary>
        /// 写入布尔数组
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="value">布尔数组</param>
        /// <returns></returns>
        public override OperateResult WriteBoolArray(string address, bool[] value)
        {
            //写入报文
            var sendCommand = BuildWriteMessageFrame(address, ByteArrayLib.GetByteArrayFromBoolArray(value), true, value.Length);
            if (!sendCommand.IsSuccess) return OperateResult.CreateFailResult("写入报文错误");
            byte[] response = null;
            ModbusTCPMessage message = new ModbusTCPMessage()
            {
                FunctionCode=FunctionCode.ForceMultiCoil
            };
            //发送并接收报文
            var result = SendAndReceive(sendCommand.Content, ref response, message);
            if (result.IsSuccess)
            {
                if (CheckResponse(response, UShortLib.GetByteLengthFromBoolLength(value.Length), false, this.DevAddress).IsSuccess)
                {
                    return ByteArrayLib.GetByteArrayEquals(response.Take(12).Skip(6).ToArray(), sendCommand.Content.Take(12).Skip(6).ToArray())
                        ? OperateResult.CreateSuccessResult()
                        : OperateResult.CreateFailResult("返回报字节存在错误");
                }
                else
                {
                    return OperateResult.CreateFailResult("检查");
                }
            }
            else
            {
                return OperateResult.CreateFailResult("发送报文错误");
            }
        }

        /// <summary>
        /// 写入字节数组
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override OperateResult WriteByteArray(string address, byte[] value)
        {
            //写入报文
            var sendCommand = BuildWriteMessageFrame(address, value, false);
            if (!sendCommand.IsSuccess) return OperateResult.CreateFailResult("写入报文错误");
            byte[] response = null;
            ModbusTCPMessage message = new ModbusTCPMessage()
            {
                FunctionCode=FunctionCode.PreSetMultiRegister
            };
            //发送并接收报文
            var result = SendAndReceive(sendCommand.Content, ref response, message);
            if (result.IsSuccess)
            {
                if (CheckResponse(response, UShortLib.GetByteLengthFromBoolLength(value.Length), false, this.DevAddress).IsSuccess)
                {
                    return ByteArrayLib.GetByteArrayEquals(response.Take(12).Skip(6).ToArray(), sendCommand.Content.Take(12).Skip(6).ToArray())
                        ? OperateResult.CreateSuccessResult()
                        : OperateResult.CreateFailResult("返回报文前6字节存在错误");
                }
                else
                {
                    return OperateResult.CreateFailResult("检查");
                }
            }
            else
            {
                return OperateResult.CreateFailResult("发送报文错误");
            }
        }


        /// <summary>
        /// 拼接报文，发送的报文帧
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public OperateResult<byte[]> BuildReadMessageFrame(string address, ushort length)
        {
            ByteArray sendCommand = new ByteArray();
            var result = ModbusHelper.ModbusAddressAnalysis(address, DevAddress, this.IsShortAddress);
            //事务标识符
            sendCommand.Add(EventIndex);
            //协议标识符
            sendCommand.Add(0x00,0x00);
            //长度
            sendCommand.Add(0x00,0x06);
            //从站地址，1字节
            sendCommand.Add(result.Content2);
            //功能码，1字节
            sendCommand.Add((byte)result.Content1.ReadFunction);
            //起始地址，2字节
            sendCommand.Add(result.Content3);
            //长度，2字节
            sendCommand.Add(length);
            //返回报文
            return OperateResult.CreateSuccessResult(sendCommand.array);
        }


        /// <summary>
        /// 拼接报文，写入的报文帧
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <param name="isBit"></param>
        /// <param name="colilength"></param>
        /// <returns></returns>
        public OperateResult<byte[]> BuildWriteMessageFrame(string address, byte[] value, bool isBit, int colilength = 0)
        {
            ByteArray sendCommand = new ByteArray();
            var result = ModbusHelper.ModbusAddressAnalysis(address, this.DevAddress, this.IsShortAddress);

            //事务标识符
            sendCommand.Add(EventIndex);
            //协议标识符
            sendCommand.Add(0x00, 0x00);
            //长度
            sendCommand.Add((ushort)(7+(value.Length)));
            //从站地址，1字节
            sendCommand.Add(result.Content2);
            //功能码，1字节
            sendCommand.Add((byte)result.Content1.WriteFunction);
            //起始地址，2字节
            sendCommand.Add(result.Content3);
            //寄存器数量 2字节
            sendCommand.Add((ushort)(isBit ? colilength : (ushort)(value.Length/2)));
            //地址长度
            sendCommand.Add((byte)value.Length);
            //数据
            sendCommand.Add(value);
            //返回报文
            return OperateResult.CreateSuccessResult(sendCommand.array);
        }

        //检验返回报文
        /// <summary>
        /// 校验返回报文
        /// </summary>
        /// <param name="response">返回报文</param>
        /// <param name="length">数据字节长度</param>
        /// <param name="isRead">是否是读取还是返回报文认证</param>
        /// <param name="devAddress">从站地址</param>
        /// <returns></returns>
        public OperateResult CheckResponse(byte[] response, ushort length, bool isRead, byte devAddress)
        {
            int reLength = isRead ? 9+length : 12;
            //判断长度
            if (response.Length==reLength)
            {
                //从站地址
                if (response[6]==devAddress)
                {
                        return OperateResult.CreateSuccessResult();
                }
                else
                {
                    return OperateResult.CreateFailResult("返回报文从站地址错误"+response[6]);
                }
            }
            else
            {
                return OperateResult.CreateFailResult("返回报文长度错误"+response);
            }
        }

        //解析报文
        /// <summary>
        /// 解析报文
        /// </summary>
        /// <param name="response">返回报文字节数组</param>
        /// <param name="isBit">判断是线圈还是寄存器</param>
        /// <returns></returns>
        public OperateResult<byte[]> AnalysisResponseMessage(byte[] response, bool isBit)
        {
            //取得数据
            byte[] data = ByteArrayLib.GetByteArrayFromByteArray(response, 9, response.Length-9);
            //布尔
            if (isBit)
            {
                bool[] bitData = BitLib.GetBitArrayFromByteArray(data);
                //如果只有20个线圈，但是返回3个字节
                //bitData.Select(),会查询bitData每一个元素
                //判断其是否满足要求，然后转换为一个字节，进行返回
                return OperateResult.CreateSuccessResult(bitData.Select(c => c==true ? (byte)0x01 : (byte)0x00).ToArray());
            }
            //寄存器
            else
            {
                return OperateResult.CreateSuccessResult(data);
            }
        }
    }
}
