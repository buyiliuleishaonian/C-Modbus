﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wen.ModbusRTUib
{
    public class ModbusRTU
    {
        #region 构造函数
        public ModbusRTU()
        {
            serialPort=null;
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
        /// 写入超时时间
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

        #region  建立01H读取输出线圈
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
        public byte[] ReadOutPutCoils(byte slave,ushort startCoil,ushort length)
        {
            //第一步拼接报文
            List<byte>  sendReadOutPutCoils=new List<byte>();
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
            if( SendAndReceive(sendReadOutPutCoils.ToArray(),ref receive))
            {

                //线圈长度
                int coil = length%8==0 ? 1 : length/8+1;
                //第四步验证报文
                if (CheckCRC(receive)&&receive.Length==5+coil)
                {
                    //第五步，解析报文
                    byte[] buffer = new byte[coil];
                    Array.Copy(receive, 3, buffer, 0, buffer.Length);
                    return buffer;
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
                int coil = length%8==0 ? 1 : length/8+1;
                //第四步验证报文
                if (CheckCRC(receive)&&receive.Length==5+coil)
                {
                    //第五步，解析报文
                    byte[] buffer = new byte[coil];
                    Array.Copy(receive, 3, buffer, 0, buffer.Length);
                    return buffer;
                }
            }
            return null;
        }
        #endregion


        /// <summary>
        /// 发送，接受报文
        /// </summary>
        /// <param name="send">发送报文字节数组</param>
        /// <param name="receive">接受报文字节数组</param>
        /// <returns>判断是成功</returns>
        public bool SendAndReceive(byte[] send,ref byte[] receive)
        {
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
                catch(Exception )
            {
                return false;
            }
        }

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
}