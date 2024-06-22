using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wen.ComonHelper
{
    public class ModbusRTU
    {
        #region 构造函数
        public ModbusRTU()
        {
            serialPort=new SerialPort();
        }
        #endregion

        #region 建立SerialPort对象，以及ModbusRTU类的属性和字段

        /// <summary>
        /// 创建的串口对象
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// 读取超时时间
        /// </summary>
        public int ReadTimeOut { get; set; } = 2000;//2000毫秒

        /// <summary>
        /// 返回超时时间
        /// </summary>
        public int WriteTimeOut { get; set; } = 2000;

        private bool _dtrEnable = false;
        /// <summary>
        /// DTR使能标志
        /// </summary>
        public bool DtrEnable
        {
            get { return _dtrEnable; }
            set
            {
                _dtrEnable = value;
                serialPort.DtrEnable=value;
            }
        }

        private bool _rtsEnable = false;

        /// <summary>
        /// RTS使能标志
        /// </summary>
        public bool RtsEnable
        {
            get { return _rtsEnable; }
            set
            {
                _rtsEnable=value;
                serialPort.RtsEnable=value;
            }
        }

        private int _receiveDelay = 2000;
        /// <summary>
        /// 接受报文的延时时间
        /// </summary>
        public int ReceiveDelay
        {
            get;
            set;
        }

        /// <summary>
        /// 最大的读取时间
        /// </summary>
        public int ReceiveRead = 5000;

        #endregion

        #region  建立连接和关闭连接
        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="portName">串口名</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">校验位</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="stopBits">停止位</param>
        public bool Connect(string portName, int baudRate, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            bool b = true;
            //判断serialPort对象是否有数据，是否开启
            if (serialPort!=null&&serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.PortName= portName;//绑定串口名
            serialPort.BaudRate= baudRate;//绑定波特率
            serialPort.Parity= parity;//绑定校验位
            serialPort.DataBits= dataBits;//绑定数据位
            serialPort.StopBits=stopBits;//绑定停止位

            serialPort.ReadTimeout= ReadTimeOut;
            serialPort.WriteTimeout= WriteTimeOut;

            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                b=false;
                throw new Exception("连接失败原因："+ex.Message);
            }
            return b;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Disconnect()
        {
            if (serialPort!=null&&serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
        #endregion

        #region  读取0X01输出,0X02输入线圈
        //第一步，拼接报文
        //第二步：发送报文
        //第三步：接收报文
        //第四步：验证报文
        //第五步：解析报文

        /// <summary>
        /// 读取输出线圈
        /// </summary>
        /// <param name="slave">从站地址</param>
        /// <param name="startCoil">初始线圈地址十进制</param>
        /// <param name="length">线圈的数量十进制</param>
        /// <returns></returns>
        public byte[] ReadOutPutCoils(byte slave, ushort startCoil, ushort length)
        {
            //第一步拼接报文
            List<byte> sendReadOutPutCoils = new List<byte>();
            //从站地址
            sendReadOutPutCoils.Add(slave);
            //功能码
            sendReadOutPutCoils.Add(0X01);
            //初始线圈地址
            sendReadOutPutCoils.Add(Convert.ToByte(startCoil/256));
            sendReadOutPutCoils.Add(Convert.ToByte(startCoil%256));
            //线圈数量
            sendReadOutPutCoils.Add(Convert.ToByte(length/256));
            sendReadOutPutCoils.Add(Convert.ToByte(length%256));
            //此时需要获得CRC校验
            byte[] sendCRC = CRC16(sendReadOutPutCoils.ToArray(), sendReadOutPutCoils.Count);
            sendReadOutPutCoils.Add(sendCRC[0]);
            sendReadOutPutCoils.Add(sendCRC[1]);

            //第二步,发送报文
            //第三步，接受报文
            byte[] receive = null;
            //验证发送接受报文是否成功
            if (SendAndReceive(sendReadOutPutCoils.ToArray(), ref receive))
            {

                //线圈长度
                int coil = length%8==0 ? length/8 : length/8+1;
                //第四步验证报文
                if (CheckCRC(receive)&&receive.Length==5+coil)
                {
                    //第五步，解析报文
                    if (receive[0]==slave&&receive[1]==0x01&&receive[2]==coil)
                    {
                        byte[] buffer = new byte[coil];
                        Array.Copy(receive, 3, buffer, 0, buffer.Length);
                        return buffer;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 读取输入线圈
        /// </summary>
        /// <param name="slave">从站地址</param>
        /// <param name="startCoil">初始线圈地址十进制</param>
        /// <param name="length">线圈数量</param>
        /// <returns></returns>
        public byte[] ReadInPutCoils(byte slave, ushort startCoil, ushort length)
        {
            //第一步拼接报文
            List<byte> sendReadOutPutCoils = new List<byte>();
            //从站地址
            sendReadOutPutCoils.Add(slave);
            //功能码
            sendReadOutPutCoils.Add(0X02);
            //初始线圈地址
            sendReadOutPutCoils.Add(Convert.ToByte(startCoil/256));
            sendReadOutPutCoils.Add(Convert.ToByte(startCoil%256));
            //线圈数量
            sendReadOutPutCoils.Add(Convert.ToByte(length/256));
            sendReadOutPutCoils.Add(Convert.ToByte(length%256));
            //此时需要获得CRC校验
            byte[] sendCRC = CRC16(sendReadOutPutCoils.ToArray(), sendReadOutPutCoils.Count);
            sendReadOutPutCoils.Add(sendCRC[0]);
            sendReadOutPutCoils.Add(sendCRC[1]);

            //第二步,发送报文
            //第三步，接受报文
            byte[] receive = null;
            //验证发送接受报文是否成功
            if (SendAndReceive(sendReadOutPutCoils.ToArray(), ref receive))
            {

                //线圈长度
                int coil = length%8==0 ? length/8 : length/8+1;
                //第四步验证报文
                if (CheckCRC(receive)&&receive.Length==5+coil)
                {
                    //第五步，解析报文
                    if (receive[0]==slave&&receive[1]==0x02&&receive[2]==coil)
                    {
                        byte[] buffer = new byte[coil];
                        Array.Copy(receive, 3, buffer, 0, buffer.Length);
                        return buffer;
                    }
                }
            }
            return null;
        }
        #endregion


        #region  读取0x03输出0x04输入寄存器
        /// <summary>
        /// 读取输出寄存器
        /// </summary>
        /// <param name="slaveid">从站地址</param>
        /// <param name="start">初始寄存器地址</param>
        /// <param name="bytelength">寄存器数量</param>
        /// <returns>返回数据</returns>
        public byte[] ReadOutPutRegisters(byte slaveid, ushort start, ushort bytelength)
        {
            //拼接报文
            List<byte> sendReadOutPutRegisters = new List<byte>();
            sendReadOutPutRegisters.Add(slaveid);
            sendReadOutPutRegisters.Add(0x03);
            sendReadOutPutRegisters.Add(Convert.ToByte(start/256));
            sendReadOutPutRegisters.Add(Convert.ToByte(start%256));
            sendReadOutPutRegisters.Add(Convert.ToByte(bytelength/256));
            sendReadOutPutRegisters.Add(Convert.ToByte(bytelength%256));
            //CRC校验码
            byte[] CRC = CRC16(sendReadOutPutRegisters.ToArray(), sendReadOutPutRegisters.Count);
            sendReadOutPutRegisters.AddRange(CRC);

            //发送接收报文
            byte[] receive = null;
            if (SendAndReceive(sendReadOutPutRegisters.ToArray(), ref receive))
            {
                int receivelength = bytelength*2;
                byte[] registers = new byte[receivelength];
                //验证报文
                if (CheckCRC(receive)&&receive.Length==5+receivelength)
                {
                    if (receive[0]==slaveid&&receive[1]==0x03&&receive[2]==receivelength)
                    {
                        //解析报文
                        Array.Copy(receive, 3, registers, 0, registers.Length);
                        return registers;
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// 读取输入寄存器
        /// </summary>
        /// <param name="slaveid">从站地址</param>
        /// <param name="start">初始寄存器地址</param>
        /// <param name="bytelength">寄存器数量</param>
        /// <returns>返回数据</returns>
        public byte[] ReadInPutRegisters(byte slaveid, ushort start, ushort bytelength)
        {
            //拼接报文
            List<byte> sendReadOutPutRegisters = new List<byte>();
            sendReadOutPutRegisters.Add(slaveid);
            sendReadOutPutRegisters.Add(0x04);
            sendReadOutPutRegisters.Add(Convert.ToByte(start/256));
            sendReadOutPutRegisters.Add(Convert.ToByte(start%256));
            sendReadOutPutRegisters.Add(Convert.ToByte(bytelength/256));
            sendReadOutPutRegisters.Add(Convert.ToByte(bytelength%256));
            //CRC校验码
            byte[] CRC = CRC16(sendReadOutPutRegisters.ToArray(), sendReadOutPutRegisters.Count);
            sendReadOutPutRegisters.AddRange(CRC);

            //发送接受报文
            byte[] receive = null;
            if (SendAndReceive(sendReadOutPutRegisters.ToArray(), ref receive))
            {
                int receivelength = bytelength*2;
                byte[] registers = new byte[receivelength];
                //验证报文
                if (CheckCRC(receive)&&receive.Length==5+receivelength)
                {
                    //解析报文
                    if (receive[0]==slaveid&&receive[1]==0x04&&receive[2]==receivelength)
                    {
                        Array.Copy(receive, 3, registers, 0, registers.Length);
                        return registers;
                    }
                }
            }
            return null;
        }
        #endregion


        #region  预置0X05单线圈
        /// <summary>
        /// 预置单线圈
        /// </summary>
        /// <param name="slaveid">从站地址</param>
        /// <param name="start">线圈地址</param>
        /// <param name="value">线圈数据</param>
        /// <returns>是否成功</returns>
        public bool PreSetSingleCoil(byte slaveid, ushort start, bool value)
        {
            //拼接报文
            List<byte> send = new List<byte>();
            send.Add(slaveid);
            send.Add(0X05);
            send.Add(Convert.ToByte(start/256));
            send.Add(Convert.ToByte(start%256));
            send.Add(value ? (byte)0xFF : (byte)0x00);
            send.Add(0x00);

            send.AddRange(CRC16(send.ToArray(), send.Count));

            byte[] receive = new byte[send.Count];
            //发送 接受报文
            if (SendAndReceive(send.ToArray(), ref receive))
            {
                //验证报文
                BytesArrayEquals(send.ToArray(), receive);
                return true;
            }
            return false;
        }
        #endregion

        #region  预置0X06单寄存器
        /// <summary>
        /// 预置单寄存器
        /// </summary>
        /// <param name="slaveid">从站地址</param>
        /// <param name="start">寄存器地址</param>
        /// <param name="value">寄存器数据 字节类型</param>
        /// <returns></returns>
        public bool PreSetSingleRegister(byte slaveid, ushort start, byte[] value)
        {
            //拼接报文
            List<byte> send = new List<byte>();
            send.Add(slaveid);
            send.Add(0X05);
            send.Add(Convert.ToByte(start/256));
            send.Add(Convert.ToByte(start%256));
            send.AddRange(value);//寄存器数据

            send.AddRange(CRC16(send.ToArray(), send.Count));

            byte[] receive = new byte[send.Count];
            //发送接收报文
            if (SendAndReceive(send.ToArray(), ref receive))
            {
                //验证报文
                BytesArrayEquals(send.ToArray(), receive);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 预置单寄存器
        /// </summary>
        /// <param name="slaveid">从站地址</param>
        /// <param name="start">初始寄存器</param>
        /// <param name="value">寄存器数据 有符号的整型</param>
        /// <returns></returns>
        public bool PreSetSingleRegister(byte slaveid, ushort start, short value)
        {
            return PreSetSingleRegister(slaveid, start, BitConverter.GetBytes(value).Reverse().ToArray());
        }
        /// <summary>
        /// 预置单寄存器
        /// </summary>
        /// <param name="slaveid">从站地址</param>
        /// <param name="start">寄存器地址</param>
        /// <param name="value">寄存器数值 无符号整型</param>
        /// <returns></returns>
        public bool PreSetSingleRegister(byte slaveid, ushort start, ushort value)
        {
            return PreSetSingleRegister(slaveid, start, BitConverter.GetBytes(value).Reverse().ToArray());
        }
        #endregion

        #region  预置0X0F多线圈
        /// <summary>
        /// 预置多线圈
        /// </summary>
        /// <param name="slaveid">从站地址</param>
        /// <param name="start">初始线圈</param>
        /// <param name="value">布尔数组</param>
        /// <returns>返回结果</returns>
        public bool PreSetMultiCoils(byte slaveid, ushort start, bool[] value)
        {

            //拼接报文
            List<byte> send = new List<byte>();
            send.Add(slaveid);
            send.Add(0x0f);
            send.Add(Convert.ToByte(start/256));
            send.Add(Convert.ToByte(start%256));
            send.Add(Convert.ToByte(value.Length/256));//线圈数量
            send.Add(Convert.ToByte(value.Length%256));

            byte[] setArray = GetByteArrayFromBoolArray(value);

            send.Add((byte)setArray.Length);//字节计数


            send.AddRange(setArray);
            //CRC校验
            send.AddRange(CRC16(send.ToArray(), send.Count));

            //发送接受报文
            byte[] receive = null;
            if (SendAndReceive(send.ToArray(), ref receive))
            {
                //验证报文
                if (CheckCRC(receive)&&receive.Length==8)
                {
                    for (int i = 0; i<6; i++)
                    {
                        if (send[i]!=receive[i])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
        #endregion

        #region  预置0X10 多寄存器
        public bool PreSetMultiRegisters(byte slaveid, ushort start, byte[] values)
        {
            //判断寄存器数据，不可以奇数字节，不可以无字节，不可以为空
            if (values==null &&values.Length%2!=0&&values.Length==0)
            {
                return false;
            }

            //拼接报文
            List<byte> send = new List<byte>();
            send.Add(slaveid);
            send.Add(0x10);
            send.Add(Convert.ToByte(start/256));
            send.Add(Convert.ToByte(start%256));
            send.Add(Convert.ToByte(values.Length/2/256));//寄存器数量
            send.Add(Convert.ToByte(values.Length/2%256));

            send.Add((byte)values.Length);//字节计数

            //直接将byte[]数据,写入
            send.AddRange(values);
            //CRC校验
            send.AddRange(CRC16(send.ToArray(), send.Count));

            //发送接受报文
            byte[] receive = null;
            if (SendAndReceive(send.ToArray(), ref receive))
            {
                //验证报文
                if (CheckCRC(receive)&&receive.Length==8)
                {
                    for (int i = 0; i<6; i++)
                    {
                        if (send[i]!=receive[i])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
        #endregion

        //为什么需要进行加锁，解锁，当读取和写入是通过多线程操作的时候是相互独立的，在某一瞬间会出现读取和写入是同步的
        /// <summary>
        /// 添加一个锁对象
        /// </summary>
        private SimpleHybirdLock simpleHybirdLock = new SimpleHybirdLock();

        /// <summary>
        /// 发送，接受报文
        /// </summary>
        /// <param name="send">发送报文字节数组</param>
        /// <param name="receive">接受报文字节数组</param>
        /// <returns>判断是成功</returns>
        public bool SendAndReceive(byte[] send, ref byte[] receive)
        {
            //加锁,就是当调用时，判断是否此时已经启用用户锁，如果是，就等待其关闭之后，在调用
            simpleHybirdLock.Enter();
            try
            {
                //发送报文
                serialPort.Write(send, 0, send.Length);
                //定义一个buffer，用来缓存每次接受的报文
                byte[] buffer = new byte[1024];
                //定义一个内存，MemoryStream
                MemoryStream memoryStream = new MemoryStream();
                //定义一个开始时间时间
                DateTime start = DateTime.Now;
                //这么处理的原因是防止一次读取不完整
                //循环读取缓冲区的数据，如果大于0，就读取出来，放到内存里，如果等于0，说明读完了
                //如果每次都没有读到，就要设置一个超时时间
                while (true)
                {
                    Thread.Sleep(ReceiveDelay);
                    if (serialPort.BytesToRead>0)//判断返回的报文的中间缓存区的字节数不为0，才可以读取接受报文
                    {
                        int count = serialPort.Read(buffer, 0, buffer.Length);
                        memoryStream.Write(buffer, 0, count);
                    }
                    else
                    {
                        if (memoryStream.Length>0)
                        {
                            break;
                        }
                        else if ((DateTime.Now-start).TotalMilliseconds>this.ReceiveRead)
                        {
                            return false;
                        }
                    }
                }
                receive=memoryStream.ToArray();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                //进行解锁
                simpleHybirdLock.Leave();
            }
        }

        /// <summary>
        /// 比较数组是否相同
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public bool BytesArrayEquals(byte[] b1, byte[] b2)
        {
            if (b1==null||b2==null) return false;
            if (b1.Length!=b2.Length) return false;
            for (int i = 0; i<b1.Length; i++)
            {
                if (b1[i]!=b2[i])
                {
                    return false;
                }
            }
            return true;
        }

        #region  将布尔数组转变为字节数组
        /// <summary>
        /// 将bool数组转变为字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] GetByteArrayFromBoolArray(bool[] value)
        {
            //首先bool[]，确定字节的个数
            int byteLength = value.Length%8==0 ? value.Length/8 : value.Length/8+1;

            byte[] result = new byte[byteLength];

            //将每个bool数组的位给byte对应的位赋值
            for (int i = 0; i<result.Length; i++)
            {
                //将超过将bool数组，分为8个位一组，对应字节数组
                int total = value.Length<8*(i+1) ? value.Length-8*i : 8;
                for (int j = 0; j<total; j++)
                {
                    result[i]=SetBitValue(result[i], j, value[8*i+j]);
                }
            }
            return result;
        }

        /// <summary>
        /// 将字节中某个位，置位或者复位
        /// </summary>
        /// <param name="src">字节</param>
        /// <param name="bit">指定位</param>
        /// <param name="value">置位或者复位</param>
        /// <returns>返回改变之后的字节</returns>
        public byte SetBitValue(byte src, int bit, bool value)
        {
            //将0000 0000其中一位改为1，可以使对应变为1，然后或1  0010  0000，这样不管是1101 1111/0000 0000都可以不改变其他位
            //将0010 0000其中一位改为0，可以使对应变为0，然后其他位取反  1101 1111，这样不管是1111 1111/0010 0000都可以使其他位不改变
            return value ? (byte)(src|(byte)Math.Pow(2, bit)) : (byte)(src&~(byte)Math.Pow(2, bit));
        }

        #endregion

        #region  CRC校验【查表法，速度很快】
        /// <summary>
        /// 
        /// </summary>
        private static readonly byte[] aucCRCHi =
    {
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
        0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
        0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40
        };
        private static readonly byte[] aucCRCLo =
            {
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06,
        0x07, 0xC7, 0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD,
        0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,
        0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A,
        0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC, 0x14, 0xD4,
        0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
        0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3,
        0xF2, 0x32, 0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4,
        0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,
        0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29,
        0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF, 0x2D, 0xED,
        0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
        0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60,
        0x61, 0xA1, 0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67,
        0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,
        0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68,
        0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA, 0xBE, 0x7E,
        0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
        0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71,
        0x70, 0xB0, 0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92,
        0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,
        0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B,
        0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89, 0x4B, 0x8B,
        0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
        0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42,
        0x43, 0x83, 0x41, 0x81, 0x80, 0x40
        };

        /// <summary>
        /// 验证接受报文的CRC是否正确
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckCRC(byte[] value)
        {
            if (value==null) return false;

            if (value.Length==2) return false;
            int length = value.Length;
            byte[] buf = new byte[length-2];
            Array.Copy(value, 0, buf, 0, buf.Length);

            byte[] CRCbuf = CRC16(buf, buf.Length);
            if (CRCbuf[0]==value[length-2]&&CRCbuf[1]==value[length-1])
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 校验发送的报文，一共字节多少
        /// </summary>
        /// <param name="pucFrame">发送的报文</param>
        /// <param name="usLen">字节数</param>
        /// <returns></returns>
        private byte[] CRC16(byte[] pucFrame, int usLen)
        {
            int i = 0;
            byte[] res = new byte[2] { 0xff, 0xff };
            ushort ilndex;
            while (usLen-->0)
            {
                ilndex=(ushort)(res[0]^pucFrame[i++]);
                res[0]=(byte)(res[1]^aucCRCHi[ilndex]);
                res[1]=aucCRCLo[ilndex];
            }
            return res;
        }

        #endregion
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
