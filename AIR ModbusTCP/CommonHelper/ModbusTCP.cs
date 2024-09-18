using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using thinger.DataConvertLib;

namespace CommonHelper
{
    /// <summary>
    /// ModbusTCP协议
    /// </summary>
    public class ModbusTCP
    {
        //这里的ModbusTCP也是利用socket套接字，利用端口号和ip地址来进行通信
        private Socket socket;

        //对于程序来说，可能出现同时读取和写入，所以为了避免在同一个线程上，出现同时进行读取和写入
        //我们进行加锁处理
        private SimpleHybirdLock simpleHybirdLock = new SimpleHybirdLock();

        #region Socket对象需要的发送/返回延迟时间属性

        //需要设定发送延时时间和返回延时时间，也就是在接受和返回的时候超时，就会报错
        /// <summary>
        /// 发送延时时间
        /// </summary>
        public int SendTimeOut { get; set; } = 2000;

        /// <summary>
        /// 返回延时时间
        /// </summary>
        public int ReceiveTimeOut { get; set; } = 2000;

        #endregion


        #region 建立Socket进行接收延时的时间，和判断是否超过接收时间判断
        public int DelayTiem { get; set; } = 1;

        public int StartTime { get; set; } = 10;
        #endregion

        #region  建立连接
        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="ip">ip地址</param>
        /// <param name="port">端口号</param>
        /// <returns>返回结果</returns>
        public bool Connect(string ip, int port)
        {
            //第一个表示的是ip的版本的地址,第二表示socket的stream安全，但是传输慢，第三个是连接协议的类型
            this.socket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.SendTimeout=SendTimeOut;
            this.socket.ReceiveTimeout=ReceiveTimeOut;
            try
            {
                if (IPAddress.TryParse(ip, out IPAddress ipAddress))
                {
                    //连接本机的ip和端口号
                    this.socket.Connect(ipAddress, port);
                }
                else
                {
                    //无法转成ip地址，就是域名
                    this.socket.Connect(ip, port);
                }
            }
            catch (Exception ex)
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
            if (this.socket!=null)
            {
                this.socket.Close();
            }
        }
        #endregion

        /// <summary>
        /// 单元标识符
        /// </summary>
        private byte Slave { get; set; } = 0x01;

        #region 读取输入输出线圈
        /// <summary>
        /// 读取输入线圈
        /// </summary>
        /// <param name="start">初始线圈地址</param>
        /// <param name="length">线圈数量</param>
        /// <returns></returns>
        public byte[] ReadInPutCoils(ushort start, ushort length)
        {
            //第一步拼接报文
            //事务标识符+协议标识符0X00 0X00+长度+单元标识符+功能码+初始线圈地址+长度
            ByteArray sendBytes = new ByteArray();
            sendBytes.Add(0x00, 0x00, 0x00, 0x00);//事务+协议
            sendBytes.Add(0x00, 0x06, Slave, 0x02);//长度+单元标识符+功能码
            sendBytes.Add(start);
            sendBytes.Add(length);
            byte[] receive = null;
            if (SendAndReceive(sendBytes.List.ToArray(), ref receive))
            {
                int count = length%8==0 ? length/8 : length/8+1;
                byte[] result = new byte[count];
                if (receive.Length==9+count&&sendBytes.List[7]==receive[7])
                {
                    Array.Copy(receive, 9, result, 0, result.Length);
                    return result;
                }
            }
            return null;
        }
        /// <summary>
        /// 读取输出线圈
        /// </summary>
        /// <param name="start">初始线圈地址</param>
        /// <param name="length">线圈长度</param>
        /// <returns></returns>
        public byte[] ReadOutPutCoils(ushort start, ushort length)
        {
            //第一步拼接报文
            //事务标识符+协议标识符0X00 0X00+长度+单元标识符+功能码+初始线圈地址+长度
            ByteArray sendBytes = new ByteArray();
            sendBytes.Add(0x00, 0x00, 0x00, 0x00);//事务+协议
            sendBytes.Add(0x00, 0x06, Slave, 0x01);//长度+单元标识符+功能码
            sendBytes.Add(start);
            sendBytes.Add(length);
            byte[] receive = null;
            if (SendAndReceive(sendBytes.List.ToArray(), ref receive))
            {
                int count = length%8==0 ? length/8 : length/8+1;
                byte[] result = new byte[count];
                if (receive.Length==9+count&&sendBytes.List[7]==receive[7])
                {
                    Array.Copy(receive, 9, result, 0, result.Length);
                    return result;
                }
            }
            return null;
        }


        #endregion

        #region 读取输入输出寄存器
        /// <summary>
        /// 读取输出线圈
        /// </summary>
        /// <param name="start">初始寄存器地址</param>
        /// <param name="length">寄存器数量</param>
        /// <returns>返回结果</returns>
        public byte[] ReadOutPutRegisters(ushort start, ushort length)
        {
            //拼接报文
            ByteArray sendBytes = new ByteArray();
            sendBytes.Add(0x00, 0x00, 0x00, 0x00);//添加事务标识+协议标识
            sendBytes.Add(0x00, 0x06, Slave, 0x03);//添加长度，单元标识，功能码
            sendBytes.Add(start);//初始寄存器地址
            sendBytes.Add(length);//长度
            byte[] receive = null;
            //发送接收报文
            if (SendAndReceive(sendBytes.List.ToArray(), ref receive))
            {
                int count = length*2;//表示数据字节个数
                byte[] result = new byte[count];
                if (receive.Length==9+count&&receive[7]==0x03)
                {
                    Array.Copy(receive, 9, result, 0, result.Length);
                    return result;
                }
            }
            return null;
        }
        /// <summary>
        /// 读取输入寄存器
        /// </summary>
        /// <param name="start">初始寄存器地址</param>
        /// <param name="length">寄存器长度</param>
        /// <returns>返回结果</returns>
        public byte[] ReadInPutRegisters(ushort start, ushort length)
        {
            //拼接报文
            ByteArray sendBytes = new ByteArray();
            sendBytes.Add(0x00, 0x00, 0x00, 0x00);//添加事务标识+协议标识
            sendBytes.Add(0x00, 0x06, Slave, 0x04);//添加长度，单元标识，功能码
            sendBytes.Add(start);//初始寄存器地址
            sendBytes.Add(length);//长度
            byte[] receive = null;
            //发送接收报文
            if (SendAndReceive(sendBytes.List.ToArray(), ref receive))
            {
                int count = length*2;//表示数据字节个数
                byte[] result = new byte[count];
                if (receive.Length==9+count&&receive[7]==0x04)
                {
                    Array.Copy(receive, 9, result, 0, result.Length);
                    return result;
                }
            }
            return null;
        }
        #endregion

        #region 预置单线圈和寄存器
        /// <summary>
        /// 预置单线圈
        /// </summary>
        /// <param name="start">初始线圈地址</param>
        /// <param name="value">写入数据</param>
        /// <returns>返回结果</returns>
        public bool PreSetSingleCoil(ushort start, bool value)
        {
            //拼接报文
            ByteArray sendBytes = new ByteArray();
            sendBytes.Add(0x00, 0x00, 0x00, 0x00);//添加事务标识+协议标识
            sendBytes.Add(0x00, 0x06, Slave, 0x05);//添加长度，单元标识，功能码
            sendBytes.Add(start);
            byte[] set = null;
            if (value)
            {
                set=new byte[] { 0xff, 0x00 };
            }
            else
            {
                set= new byte[] { 0x00, 0x00 };
            }
            sendBytes.Add(set);

            byte[] receive = null;
            if (SendAndReceive(sendBytes.List.ToArray(), ref receive))
            {
                if (receive.Length==sendBytes.Length&&receive[7]==0x05)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 预置单寄存器
        /// </summary>
        /// <param name="start">寄存器地址</param>
        /// <param name="values">写入数据（字节数组）</param>
        /// <returns>返回结果</returns>
        public bool PreSetSingleRegister(ushort start, byte[] values)
        {
            //拼接报文
            ByteArray sendBytes = new ByteArray();
            sendBytes.Add(0x00, 0x00, 0x00, 0x00);//添加事务标识+协议标识
            sendBytes.Add(0x00, 0x06, Slave, 0x06);//添加长度，单元标识，功能码
            sendBytes.Add(start);
            sendBytes.Add(values);
            byte[] receive = null;
            if (SendAndReceive(sendBytes.List.ToArray(), ref receive))
            {
                if (receive.Length==sendBytes.Length&&receive[7]==0x06)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 写入单寄存器数据
        /// </summary>
        /// <param name="start">寄存器地址</param>
        /// <param name="value">写入数据（无符号短整型）</param>
        /// <returns>返回结果</returns>
        public bool PreSetSingleRegister(ushort start, ushort value)
        {
            //将一个基数据转换成一个字节数组，再将其反转
            return PreSetSingleRegister(start, BitConverter.GetBytes(value).Reverse().ToArray());
        }
        /// <summary>
        /// 写入单寄存器数据
        /// </summary>
        /// <param name="start">寄存器地址</param>
        /// <param name="value">写入数据（短整型）</param>
        /// <returns>返回结果</returns>
        public bool PreSetSingleRegister(ushort start, short value)
        {
            return PreSetSingleRegister(start, BitConverter.GetBytes(value).Reverse().ToArray());
        }
        #endregion

        #region 预置多线圈和多寄存器
        /// <summary>
        ///  预置多线圈
        /// </summary>
        /// <param name="start">寄存器地址</param>
        /// <param name="values">线圈数据</param>
        /// <returns>返回结果</returns>
        public bool PreSetMultiCoils(ushort start, bool[] values)
        {
            //拼接报文
            ByteArray sendBytes = new ByteArray();
            byte[] set = ByteArrayFromBoolArray(values);
            sendBytes.Add(0x00, 0x00, 0x00, 0x00);
            sendBytes.Add((short)(7+set.Length));
            sendBytes.Add(Slave, 0x0F);
            sendBytes.Add(start);
            sendBytes.Add((short)values.Length);//线圈数量
            sendBytes.Add((byte)set.Length);//字节计数
            sendBytes.Add(set);//加数据

            byte[] receive = null;
            if (SendAndReceive(sendBytes.List.ToArray(), ref receive))
            {
                byte[] send = new byte[12];
                Array.Copy(sendBytes.List.ToArray(), 0, send, 0, 12);
                send[4] = 0x00;
                send[5] = 0x06;
                return ByteArrayEquls(send, receive);
            }
            return false;
        }

        /// <summary>
        /// 预置多寄存器
        /// </summary>
        /// <param name="start">初始寄存器地址</param>
        /// <param name="values">寄存器数据</param>
        /// <returns>返回结果</returns>
        public bool PreSetMultiRegisters(ushort start, byte[] values)
        {
            ByteArray sendBytes = new ByteArray();
            sendBytes.Add(0x00, 0x00, 0x00, 0x00);
            sendBytes.Add((short)(7+values.Length));
            sendBytes.Add(Slave, 0x10);
            sendBytes.Add(start);
            sendBytes.Add((short)(values.Length/2));//寄存器数量
            sendBytes.Add((byte)(values.Length));//1个字节计数
            sendBytes.Add(values);//寄存器数据

            byte[] receive = null;
            if (SendAndReceive(sendBytes.List.ToArray(), ref receive))
            {
                byte[] send = new byte[12];
                Array.Copy(sendBytes.List.ToArray(), 0, send, 0, 12);
                send[4] = 0x00;
                send[5] = 0x06;
                return ByteArrayEquls(send, receive);
            }
            return false;
        }
        #endregion

        #region 将bool[]转化成字节数组
        /// <summary>
        /// 将bool数组转化成字节数组
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private byte[] ByteArrayFromBoolArray(bool[] values)
        {
            int count = values.Length%8==0 ? values.Length/8 : values.Length/8+1;
            byte[] result = new byte[count];
            //首先要把一个字节全部对应Bool数组弄完，
            for (int i = 0; i<result.Length; i++)
            {
                int initial = values.Length%8<8*(i+1) ? values.Length-8*i : 8;
                for (int x = 0; x < initial; x++)
                {
                    result[i]= SetBitLib(result[i], values[8*i+x], x);
                }
            }
            return result;
        }
        /// <summary>
        /// 将字节里面指定的某位取反
        /// </summary>
        /// <param name="set">字节</param>
        /// <param name="value">数据</param>
        /// <param name="bit">位置</param>
        /// <returns>返回结果</returns>
        private byte SetBitLib(byte set, bool value, int bit)
        {
            return value ? (byte)(set|(byte)Math.Pow(2, bit)) : (byte)(set&~(byte)Math.Pow(2, bit));
        }
        #endregion

        #region 通用发送和接收的方法
        /// <summary>
        /// ModbusTCP通用发送报文，接收报文
        /// </summary>
        /// <param name="send">发送报文</param>
        /// <param name="receive">接收报文</param>
        /// <returns></returns>
        public bool SendAndReceive(byte[] send, ref byte[] receive)
        {
            //加锁
            simpleHybirdLock.Enter();
            try
            {
                //发送报文
                DateTime dateTime = DateTime.Now;
                //一次发送的最大内存数据
                byte[] buffer = new byte[1024];
                //内存流，将返回的数据，先放入其中
                MemoryStream memoryStream = new MemoryStream();
                int timers = 0;
                this.socket.Send(send, send.Length, SocketFlags.None);

                //接受报文
                while (true)
                {
                    //延迟返回
                    Thread.Sleep(this.DelayTiem);
                    if (this.socket.Available>0)
                    {
                        int count = this.socket.Receive(buffer, SocketFlags.None);
                        memoryStream.Write(buffer, 0, count);
                    }
                    else
                    {
                        timers++;
                        if (timers>StartTime)
                        {
                            return false;
                        }
                        else if (memoryStream.Length>0)
                        {
                            break;
                        }
                    }
                }
                //返回报文
                receive= memoryStream.ToArray();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                simpleHybirdLock.Leave();
            }
        }
        #endregion

        /// <summary>
        /// 比较两个字节数组是否相等
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public bool ByteArrayEquls(byte[] b1, byte[] b2)
        {
            return BitConverter.ToString(b1)==BitConverter.ToString(b2);
        }
    }
    #region 简单混合锁
    /// <summary>
    /// 
    /// </summary>
    public sealed class SimpleHybirdLock : IDisposable
    {
        #region IDisposable Support
        private bool disposedValue = false;
        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //TODO：释放托管状态（托管对象）
                }
                //TODO:释放未托管的资源（未托管的对象）并在以下内容中替代终结器
                //TODO：将大型字段设置为null
                m_waiterLock.Close();

                disposedValue = true;
            }
        }

        //TODO:仅当以上Dispose（bool disposing） 拥有用于释放未托管资源的代码时菜替代代终结器
        //~SimpleHybirdLock（）{// //请勿更改此代码，将清理代码放入以上Dispose（bool disposing）中
        // Dispose（flase）;}

        //添加此代码以正确实现可处置模式
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            //请勿更改此代码，将清理代码放入以上Dispose（bool disposing）中
            Dispose(true);
            //TODO:如果在以上内容中替代了终结器，则取消注释一下行
            //GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// 基元用户模式构造同步锁
        /// </summary>
        private Int32 m_waiters = 0;

        /// <summary>
        /// 基于内核模式构造同步锁
        /// </summary>
        private AutoResetEvent m_waiterLock = new AutoResetEvent(false);

        /// <summary>
        /// 获取锁
        /// </summary>
        public void Enter()
        {
            if (Interlocked.Increment(ref m_waiters)==1) return;//用户锁可以使用时，直接返回，第一次调用时发生
            //当发生锁竞争时，使用内核同步构造锁
            m_waiterLock.WaitOne();
        }

        /// <summary>
        /// 离开锁
        /// </summary>
        public void Leave()
        {
            if (Interlocked.Decrement(ref m_waiters)==0) return;//没有可用的锁的时候
            m_waiterLock.Set();
        }

        /// <summary>
        /// 获取当前锁是否在等待当中
        /// </summary>
        public bool isMaiting => m_waiters==0;
    }
    #endregion
}

