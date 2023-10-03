using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace Wen.ModbusBase
{
    /// <summary>
    /// 这里的控制面板，就相当于Modbus的主站，来连接从站
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //设置属性96N81：波特率，N无奇偶检验位，8位一个字节的数据区，1个位停止位
            SerialPort port = new SerialPort();
            port.PortName="COM1";
            port.BaudRate=9600;
            port.Parity=Parity.None;
            port.DataBits=8;
            port.StopBits=StopBits.One;
            //打开串口
            port.Open();
            while (true)
            {
                Thread.Sleep(2000);
                //拼接报文,也就是需要将报文拼接，而且是字节类型
                List<byte> sendPort = new List<byte>();
                sendPort.Add(0x01);//绑定设备地址
                sendPort.Add(0x03);//绑定是读取从站的输出寄存器
                sendPort.Add(0x00);//起始寄存器的高位
                sendPort.Add(0x00);//起始寄存器的低位
                sendPort.Add(0x00);//寄存器数量高位
                sendPort.Add(0x02);//寄存器数量低位
                                   //CRC校验
                sendPort.Add(0xc4);
                sendPort.Add(0x0B);
                //发送报文,需要将报文转为byte数组
                port.Write(sendPort.ToArray(), 0, sendPort.Count);
                //接受报文,当前进程延迟1秒之后，接受报文
                Thread.Sleep(1000);
                //接受缓冲区全部的字节
                byte[] buffer = new byte[port.BytesToRead];
                port.Read(buffer, 0, buffer.Length);
                //验证报文是否正确，可以通过从站地址，功能码区域是否正确
                if (buffer[0]==1&&buffer[1]==3)
                {
                    //观察报文：0x01 0x03 0x04 0x00 ox7b 0x02 ox4d ox4b 0x7f
                    //观察报文： 1    3     4    00  123  2     77   75   127
                    //数据索引  [0]  [1]   [2]   [3] [4] [5]   [6]  [7]   [8]
                    //字节16进制到10进制 高低位转换    123=（123/256）+(123%256) 高位是商，低位是余数
                    //589=(589/256)+(589%256)
                    //转换成10进制  1个高字节=256，数值=高位*256+地位
                    int humidity = buffer[3]*256+buffer[4];
                    int temperature = buffer[5]*256+buffer[6];
                    Console.WriteLine($"温度：{humidity*0.1},湿度：{temperature*0.1}");
                }
                //观察报文
            }
        }
    }
}
