using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wen.ModbucCommunicationLib.Library;


namespace Wen.ModbusCommunictaion
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            if (modbusRTU.Connect("COM1"))
            {
                var result = modbusRTU.WriteByteArray("40001", ByteArrayLib.GetByteArrayFromUShortArray(new ushort[] {11,12,13 })).Message;
            }
            InitializeComponent();
        }

        public ModbusRTU modbusRTU = new ModbusRTU();
    }
}
