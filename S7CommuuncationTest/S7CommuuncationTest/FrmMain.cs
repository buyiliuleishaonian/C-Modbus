using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S7CommuuncationTest
{
    /// <summary>
    /// 这整个程序是教学，是实体PLC 通过KEPServer通信，一个浮点数地址
    /// 某些报文是固定的
    /// </summary>
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private Socket tcpClient = null;


        /// <summary>
        /// 进行Socket的三次握手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_Conn_Click(object sender, EventArgs e)
        {
            tcpClient=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                tcpClient.Connect((IPAddress)Enum.Parse(typeof(IPAddress), "192.168.125.10"), 502);
            }
            catch
            {
                AddLog("connect fail");
                return;
            }
            AddLog("connect success");
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="content"></param>
        private void AddLog(string content)
        {
            this.rtb_Info.AppendText(DateTime.Now.ToString("HH:MM:SS")+" "+content);
        }

        /// <summary>
        /// 一次确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FristComfirm_Click(object sender, EventArgs e)
        {
            //拼接报文
            List<byte> hand1 = new List<byte>();

            //第五层TPKT
            hand1.AddRange(new byte[] { 0x03, 0x00, 0x00, 0x16 });

            //第六层 cotp
            hand1.AddRange(new byte[] { 0x11, 0xe0, 0x00, 0x00 });
            hand1.AddRange(new byte[] { 0x00, 0x01, 0x00, 0xc0 });
            hand1.AddRange(new byte[] { 0x4b, 0x54, 0xc2, 0x02 });
            hand1.AddRange(new byte[] { 0x03, 0x01 });

            //只关注有不有回复
            byte[] rec = SendAndReceive(hand1.ToArray());
            if (rec!=null)
            {
                AddLog(BitConverter.ToString(rec));
            }
            else
            {
                AddLog("hand1 Error");
            }
        }

        /// <summary>
        /// 发送返回接收
        /// </summary>
        /// <param name="sendByte"></param>
        /// <returns></returns>
        private byte[] SendAndReceive(byte[] sendByte)
        {
            try
            {
                tcpClient.Send(sendByte, sendByte.Length, SocketFlags.None);
                int k = tcpClient.Available;
                int time = 0;
                while (k==0)
                {
                    time++;
                    k=tcpClient.Available;
                    Thread.Sleep(10);
                    if (time>5) break;
                }
                byte[] myBuffer = new byte[k];
                tcpClient.Receive(myBuffer, SocketFlags.None);
                return myBuffer;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 二次确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SecondComfirm_Click(object sender, EventArgs e)
        {
            List<byte> hand2 = new List<byte>();

            //第五层TPKT
            hand2.AddRange(new byte[] { 0x03, 0x00, 0x00, 0x19 });

            //第六层 cotp
            hand2.AddRange(new byte[] { 0x03, 0x00, 0x00, 0x19 });
            //第七层 S7
            hand2.AddRange(new byte[] { 0x32, 0x01, 0x00, 0x00 });
            hand2.AddRange(new byte[] { 0x00, 0x02, 0x00, 0x08 });
            hand2.AddRange(new byte[] { 0x00, 0x00, 0xf0, 0x00 });
            hand2.AddRange(new byte[] { 0x03, 0xc0 });

            //只关注有不有回复
            byte[] rec = SendAndReceive(hand2.ToArray());
            if (rec!=null)
            {
                AddLog(BitConverter.ToString(rec));
            }
            else
            {
                AddLog("hand2 Error");
            }
        }

        /// <summary>
        /// 读取变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReadVariable_Click(object sender, EventArgs e)
        {
            List<byte> read = new List<byte>();

            //第五层TPKT
            read.AddRange(new byte[] { 0x03, 0x00, 0x00, 0x16 });

            //第六层 cotp
            read.AddRange(new byte[] { 0x02, 0xf0, 0x80});
            //第七层
            //[header]
            read.AddRange(new byte[] { 0x32, 0x01, 0x00, 0x00 });
            read.AddRange(new byte[] { 0x00, 0x03, 0x00, 0x0e });
            read.AddRange(new byte[] { 0x00, 0x00 });

            //[Param]
            read.AddRange(new byte[] {0x04,0x01,0x12,0x0a});
            read.AddRange(new byte[] { 0x10, 0x02, 0x00, 0x04 });
            read.AddRange(new byte[] { 0x00, 0x03, 0x84, 0x00 });
            read.AddRange(new byte[] { 0x00,0x00 });

            //只关注有不有回复
            byte[] rec = SendAndReceive(read.ToArray());
            if (rec!=null)
            {
                AddLog(BitConverter.ToString(rec));
                byte[] data = new byte[4];
                Array.Copy(rec,25,data,0,4);
                data=data.Reverse().ToArray();
                AddLog(BitConverter.ToString(data));
            }
            else
            {
                AddLog("read Error");
            }
        }
    }
}
