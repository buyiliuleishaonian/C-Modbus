using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

using Wen.ModbucCommunicationLib.Interface;
using Wen.ModbusCommunicationLib;
using System.Threading;
using System.IO;
using thinger.DataConvertLib;

namespace Wen.ModbucCommunicationLib.Base
{
    /// <summary>
    /// 串口基类
    /// </summary>
    public class SerialDeviceBase : ReadWriteBase
    {
        /// <summary>
        /// 串口对象
        /// </summary>
        private SerialPort serialPort { get; set; } = new SerialPort();

        /// <summary>
        /// 读取超时时间
        /// </summary>
        private int ReadTimeOut { get; set; } = 2000;

        /// <summary>
        /// 写入超时时间
        /// </summary>
        private int WriteTimeOut { get; set; } = 2000;

        /// <summary>
        /// 用于告知所连接的设备，准备好发送信号
        /// </summary>
        public bool RtsEnable { get; set; } = false;

        /// <summary>
        /// 表示数据终端设备（例如计算机）准备好进行通信
        /// </summary>
        public bool DtrEnable { get; set; } = false;

        /// <summary>
        /// 发送报文（存储区）
        /// </summary>
        public byte[] Requet { get; set; }

        /// <summary>
        /// 接收报文(存储区)
        /// </summary>
        public byte[] Response { get; set; }

        /// <summary>
        /// 延迟时间
        /// </summary>
        public int SmleepTime { get; set; } = 20;

        /// <summary>
        /// 超时时间
        /// </summary>
        public int DelayTimeOut = 2000;

        /// <summary>
        /// 串口缓冲区大小设置
        /// </summary>
        private int serialbyteSize = 1024;

        /// <summary>
        /// 简单混合锁对象
        /// </summary>
        public SimpleHybirdLock simpleHybirdLock { get; set; } = new SimpleHybirdLock();


        /// <summary>
        /// 串口通信
        /// </summary>
        /// <param name="PortName">端口号</param>
        /// <param name="baudRata">波特率</param>
        /// <param name="dataBit">数据位</param>
        /// <param name="stopBit">停止位</param>
        /// <param name="parity">校验位</param>
        /// <returns></returns>
        public bool Connect(string PortName, int baudRate = 9600, int dataBit = 8, StopBits stopBit = StopBits.One, Parity parity = Parity.None)
        {
            serialPort.PortName=PortName;
            serialPort.BaudRate=baudRate;
            serialPort.DataBits=dataBit;
            serialPort.Parity=parity;
            serialPort.StopBits=stopBit;

            serialPort.ReadTimeout=ReadTimeOut;
            serialPort.WriteTimeout=WriteTimeOut;
            //提供给设备，告知可以准备发送报文
            serialPort.DtrEnable=DtrEnable;
            //表面本机可以通信了
            serialPort.RtsEnable=RtsEnable;

            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                else
                {
                    serialPort.Open();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void DisConnect()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        #region 发送并接收
        public OperateResult SendAndReceive(byte[] requet, ref byte[] response, IMessage message = null)
        {
            //加锁
            simpleHybirdLock.Enter();
            //记录发送的报文
            this.Requet= requet;
            //创建缓存区文件流
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                //发送报文
                serialPort.Write(requet, 0, requet.Length);
                //按时间来接收报文
                if (message==null)
                {
                    //记录发送时间
                    DateTime start = DateTime.Now;
                    //建立每次接收存储区
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        Thread.Sleep(SmleepTime);
                        if (serialPort.BytesToRead>0)
                        {
                            int current = serialPort.Read(buffer, 0, buffer.Length);
                            memoryStream.Write(buffer, 0, current);
                        }
                        else
                        {
                            if (memoryStream.Length>0)
                            {
                                break;
                            }
                            else if ((DateTime.Now-start).TotalMilliseconds>this.DelayTimeOut)
                            {
                                memoryStream.Dispose();
                                return OperateResult.CreateFailResult("读取超时");
                            }
                        }
                    }
                }
                //按消息来接收报文
                else
                {
                    //首先是验证包头，判断需要根据返回报文写发送报文的情况
                    if (message.HeadDataLength>0)
                    {
                        byte[] headData = ReceiveMessage(message.HeadDataLength);
                        if (message.CheckHeadData(headData))
                        {
                            memoryStream.Write(headData, 0, headData.Length);
                        }
                        else
                        {
                            return OperateResult.CreateFailResult("包头验证不通过");
                        }
                    }
                    //只需要知道返回报文的长度
                    int content = message.GetContentLength();
                    //得到返回报文
                    byte[] buffer = ReceiveMessage(content);
                    memoryStream.Write(buffer, 0, buffer.Length);
                }
                //获取接收报文
                response= memoryStream.ToArray();

                this.Response = response;
                //释放资源
                memoryStream.Dispose();
                //返回结果
                return OperateResult.CreateSuccessResult();
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult(ex.Message);
            }
            finally
            {
                //解锁
                simpleHybirdLock.Leave();
            }
        }

        /// <summary>
        /// 根据返回报文的长度，来读取返回报文
        /// </summary>
        /// <param name="Length">返回报文长度</param>
        /// <returns></returns>
        private byte[] ReceiveMessage(int length)
        {
            //获取和包头一样的长度
            byte[] buffer = new byte[length];
            //已读取长度
            int numbytesRead = 0;
            while (numbytesRead<length)
            {
                int count = Math.Min(length-numbytesRead, serialbyteSize);
                //接收返回字节
                int readCount = serialPort.Read(buffer, numbytesRead, count);
                numbytesRead+=readCount;
                if (readCount==0)
                {
                    break;
                }
            }
            return buffer;
        }
        #endregion


    }
}
