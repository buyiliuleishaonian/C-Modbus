using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using thinger.DataConvertLib;
using Wen.ModbusCommunicationLib;
using Wen.ModbucCommunicationLib.Interface;
using System.Linq.Expressions;

namespace Wen.ModbucCommunicationLib.Base
{
    /// <summary>
    /// 网络通信
    /// </summary>
    public class NetDeviceBase : ReadWriteBase
    {
        private Socket Socket;

        /// <summary>
        /// 延时时间
        /// </summary>
        public int DelayTime { get; set; } = 1000;

        /// <summary>
        /// 读取时间
        /// </summary>
        public int ReadTime { get; set; } = 2000;

        /// <summary>
        /// 写入时间
        /// </summary>
        public int WriteTime { get; set; } = 2000;

        /// <summary>
        /// 超时时间
        /// </summary>
        public int DelayTimeOut = 2000;

        /// <summary>
        /// 串口缓冲区大小设置
        /// </summary>
        private int scoketBufferSize = 8192;

        /// <summary>
        /// 发送报文（存储区）
        /// </summary>
        public byte[] Requet { get; set; }

        /// <summary>
        /// 接收报文(存储区)
        /// </summary>
        public byte[] Response { get; set; }

        /// <summary>
        /// 简单混合锁对象
        /// </summary>
        public SimpleHybirdLock simpleHybirdLock { get; set; } = new SimpleHybirdLock();

        /// <summary>
        /// 延迟时间
        /// </summary>
        public int SmleepTime { get; set; } = 20;


        /// <summary>
        /// 通信，ip，端口号
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool Connect(string ip, int port)
        {
            Socket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //定义发送和接收超时时间
            Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, ReadTime);
            Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, WriteTime);

            //开启远程异步通信，绑定ip和端口号
            try
            {
                IAsyncResult asyncResult = Socket.BeginConnect(ip, port, null, null);

                //绑定通信超时时间
                bool result = asyncResult.AsyncWaitHandle.WaitOne(DelayTime, false);

                if (result==false)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 断开痛惜
        /// </summary>
        public void DisConnect()
        {
            if (Socket!=null)
            {
                Socket.Close();
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
                Socket.Send(requet, 0, requet.Length, SocketFlags.None);
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
                        if (Socket.Available>0)
                        {
                            int current = Socket.Receive(buffer, SocketFlags.None);
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
            byte[] buffer = new byte[length];

            //已经读取的长度
            int numBytesRead = 0;
            while (numBytesRead < length)
            {
                //跟SerialBufferSize对比，取较小值
                int count = Math.Min(length - numBytesRead, scoketBufferSize);

                int readCount = Socket.Receive(buffer, numBytesRead, count, SocketFlags.None);

                numBytesRead += readCount;

                if (readCount == 0)
                {
                    throw new Exception("无法读取到数据");
                }
            }
            return buffer;



            ////获取和包头一样的长度
            //byte[] buffer = new byte[length];
            ////已读取长度
            //int numbytesRead = 0;
            //while (numbytesRead<length)
            //{
            //    int count = Math.Min(length-numbytesRead, serialBufferSize);
            //    //接收返回字节
            //    int readCount = serialPort.Read(buffer, numbytesRead, count);
            //    numbytesRead+=readCount;

            //    if (readCount==0)
            //    {
            //        break;
            //    }
            //}
            //return buffer;
        }
        #endregion
    }
}
