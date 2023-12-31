﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//引入命名空间
using System.IO;
using System.Threading;
using System.IO.Ports;
using static System.Net.WebRequestMethods;

namespace Wen.ModbusRTUib
{
    /// <summary>
    /// Modbus通信库
    /// </summary>
    public class ModbusRTU
    {
        //构造方法
        public ModbusRTU()
        { 

        }
        //字段
        //串口对象
        private SerialPort serialPort = null;

        //属性

        private int _receiveDelay = 100;

        /// <summary>
        /// 延迟接受报文时间
        /// </summary>
        public int ReceiveDelay
        {
            get
            { return _receiveDelay; }
            set
            {
                if (value<10 ||value>2000)
                {
                    _receiveDelay = 1000;
                }
                else
                {
                    _receiveDelay=value;
                }
            }
        }

        //方法（打开串口，关闭串口，读取保持寄存器03H，CRC校验）
        /// <summary>
        /// 波特率为9600  N  8 1的串口连接
        /// </summary>
        /// <param name="portName">串口名</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">无奇偶校验位</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="stopBits">停止位</param>
        public void Connect(string portName, int baudRate, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            serialPort=new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("串口打开失败！原因"+ex.Message);
            }
        }

        /// <summary>
        /// 关闭串口通信
        /// </summary>
        public void Disconnect()
        {
            if (serialPort!=null&& serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        //第一步：封装【请求】报文
        //第二步：发送请求报文
        //第三步：接受【应答】报文
        //第四步：验证应答报文，解析【应答报文】

        byte[] receiveBytes = null;
        /// <summary>
        /// 读取保持寄存器的数据库，功能码03
        /// </summary>
        /// <param name="slaveID">设备地址</param>
        /// <param name="startAddress">寄存器的初始位置（10进制）</param>
        /// <param name="count">寄存器的数量</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public byte[] ReadHoldingRegister(byte slaveID,int startAddress,int count)
        {
            //第一步：封装【请求】报文,
            //主站发送报文的长度是固定的8个字节，设备地址1个字节
            //功能码1个字节，初始寄存器的高位，低位分别一个字节，寄存器数量高位，地位，分别一个字节，
            //CRC检验码两个字节
            byte[] sendBytes=new byte[8];
            sendBytes[0]=slaveID;//设备地址
            sendBytes[1]=0x03;//确定其功能区
            sendBytes[2]=(byte)(startAddress/256);//起始寄存器高位
            sendBytes[3]=(byte)(startAddress%256);//起始寄存器低位
            sendBytes[4]=(byte)(count/256);//寄存器数量高位
            sendBytes[5]=(byte)(count%256);//寄存器数量低位
            byte[] crc = CRC16(sendBytes,6);
            sendBytes[6]=crc[0];//CRC检验码
            sendBytes[7]=crc[1];
            //第二步：发送请求报文
            try
            {
                //发送报文
                serialPort.Write(sendBytes,0,sendBytes.Length);
                //缓冲接受报文
                Thread.Sleep(ReceiveDelay);
                //第三步：接受【应答】报文
                receiveBytes = new byte[serialPort.BytesToRead];
                
                //接受报文
                serialPort.Read(receiveBytes,0,receiveBytes.Length);
                //第四步：验证应答报文，解析【应答报文】
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            int returnDataLegth = count*2;
            if (receiveBytes.Length==5+returnDataLegth)//判断返回报文的字节数组长度是否正确
            {
                if (receiveBytes[1]==0x03&&CheckCRC(receiveBytes))//判断是否是读取寄存器的3区就可以
                {
                    //将寄存器的数据读取出来
                    byte[] returnRegisterData = new byte[returnDataLegth];
                    //将字节数量，之后的数据区，复制到
                    Array.Copy(receiveBytes, 3, returnRegisterData, 0, returnDataLegth);
                    return returnRegisterData;
                }
                else return null;
            }
            else return null;
        }


        #region  CRC校验【查表法，速度很快】
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

        private bool CheckCRC(byte[] value)
        {
            if(value==null) return false;

            if(value.Length==2) return false;
            int length = value.Length;
            byte[] buf= new byte[length-2];
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
            byte[] res = new byte[2] { 0xff,0xff};
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
