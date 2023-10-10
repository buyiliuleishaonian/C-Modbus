using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wen.ModbusRTUib;
using static System.Windows.Forms.AxHost;

namespace Wen.ModbusProject
{
    //自己构建存储区的枚举 enum

    /// <summary>
    /// 存储区的枚举类型
    /// </summary>
    public enum StoreArea
    {
        输入线圈1X,
        输出线圈0X,
        输入寄存器3X,
        输出寄存器4X
    }
    public partial class FrmModbusRTU : Form
    {
        /// <summary>
        /// ModbusRTU通信对象
        /// </summary>
        private ModbusRTU modbusRTU = new ModbusRTU();

        /// <summary>
        ///判断是否连接
        /// </summary>
        private bool IsConnect { get; set; } = false;

        private DataFormat dataFormat = DataFormat.ABCD;

        public FrmModbusRTU()
        {
            InitializeComponent();
            InitParam();
        }

        #region  参数初始化
        private void InitParam()
        {
            //获得本机上的端口号
            string[] portName = SerialPort.GetPortNames();
            this.cmbPortName.Items.AddRange(portName);
            this.cmbPortName.SelectedIndex = 0;

            //添加波特率
            this.cmbBaudRate.Items.AddRange(new string[] { "2400", "4800", "9600", "19200", "38400" });
            this.cmbBaudRate.SelectedIndex=2;

            //获取所有校验位，枚举类型
            this.cmbParity.DataSource=Enum.GetNames(typeof(Parity));
            this.cmbParity.SelectedIndex=0;

            //停止位 枚举类型
            this.cmbStopBits.DataSource=Enum.GetNames(typeof(StopBits));
            this.cmbStopBits.SelectedIndex=1;

            //数据位  
            this.cmbDataBits.Items.AddRange(new string[] { "7", "8" });
            this.cmbDataBits.SelectedIndex=1;

            //大小端  枚举类型DataFormat,
            //它是一种关于多字节数据类型中字节排列顺序的表示方式
            this.cmbDataFormat.DataSource=Enum.GetNames(typeof(DataFormat));
            this.cmbDataFormat.SelectedIndex=0;

            //存储区 输入线圈1X，输出线圈0X，输入寄存器3X，输出寄存器4X
            this.cmbStoreArea.DataSource=Enum.GetNames(typeof(StoreArea));
            this.cmbStoreArea.SelectedIndex=0;

            //数据类型 枚举类型
            this.cmbDataType.DataSource=Enum.GetNames(typeof(DataType));
            this.cmbDataType.SelectedIndex=0;

            //动态修改ListView的Coulmns某列的宽度
            this.list_Info.Columns[1].Width=this.list_Info.Width-this.list_Info.Columns[0].Width-48;
        }
        #endregion

        #region  连接，关闭连接，写入日志

        /// <summary>
        /// 连接从站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (IsConnect)
            {
                Add_Log(1, "ModbusRTU已连接");
                return;
            }

            //得到选定的校验
            Parity parity = (Parity)Enum.Parse(typeof(Parity), this.cmbParity.Text, true);
            StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), this.cmbStopBits.Text, true);
            //判断选择的串口号，波特率，校验，数据位，停止位，是否会连接成功
            IsConnect= modbusRTU.Connect(this.cmbPortName.Text, Convert.ToInt32(this.cmbBaudRate.Text), parity, Convert.ToInt32(this.cmbDataBits.Text), stopBits);

            if (IsConnect)
            {
                Add_Log(0, "ModbusRTU连接成功");
            }
            else
            {
                Add_Log(1, "ModbusRTU连接失败");
            }
        }

        /// <summary>
        /// 通用写入日志的方法 给ListView显示最新连接信息
        /// </summary>\
        /// <param name="level"></param>
        /// <param name="info"></param>
        private void Add_Log(int level, string info)
        {
            //指定显示初始化ListView的项的文本，以及图片索引
            ListViewItem list = new ListViewItem(DateTime.Now.ToShortDateString(), level);
            list.SubItems.Add(info);

            this.list_Info.Items.Insert(0, list);
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            modbusRTU.Disconnect();
            IsConnect=false;
            Add_Log(0, "ModbusRTU连接关闭");
        }
        #endregion

        #region 通用读取方法，首先验证选择的参数是否正确，判断数据类型，判断存储区，对于读取数据int uint float四个字节构成寄存器需要考虑到plc存储的大小端
        private void btnRead_Click(object sender, EventArgs e)
        {
            //在进行读取之前，验证我们输入从站地址，
            //初始线圈/寄存器地址，线圈/寄存器数量，存储区，数据类型，是否正确
            if (CommonVeify())
            {
                //将对应的从站地址，初始地址，长度，全部转化为ModbusRTU读取方法中的，参数类型
                byte slaveid = byte.Parse(this.txtSlaveID.Text.Trim());
                ushort start = ushort.Parse(this.txtStart.Text);
                ushort dataLength = ushort.Parse(this.txtDataLength.Text);
                //明确当前的数据类型
                DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.cmbDataType.Text, true);
                //得到存储区
                StoreArea area = (StoreArea)Enum.Parse(typeof(StoreArea), this.cmbStoreArea.Text, true);
                //大小端
                dataFormat=(DataFormat)Enum.Parse(typeof(DataFormat), this.cmbDataFormat.Text, true);
                //判断数据类型，一般为bool，byte，short，ushort，int，uint，folat(浮点数),
                //double小数，long长整型，Ulong无符号长整型，string，bytearray字节数组，Hex十六进制，这些一般不考虑
                switch (dataType)
                {
                    case DataType.Bool:
                        ReadBool(area,slaveid,start,dataLength);
                        break;
                    case DataType.Byte:
                        ReadByte(area,slaveid,start,dataLength);
                        break;
                    case DataType.Short:
                        ReadShort(area,slaveid,start,dataLength);   
                        break;
                    case DataType.UShort:
                        ReadUshort(area, slaveid, start, dataLength);
                        break;
                    case DataType.Int:
                        ReadInt(area,slaveid,start,dataLength);
                        break;
                    case DataType.UInt:
                        ReadUint(area, slaveid, start, dataLength);
                        break;
                    case DataType.Float:
                        ReadFloat(area, slaveid, start, dataLength);
                        break;
                    case DataType.Double:
                    case DataType.String:
                    case DataType.Long:
                    case DataType.ULong:
                    case DataType.ByteArray:
                    case DataType.HexString:
                        Add_Log(1, "数据类型错误请检查");
                        return;
                }
            }
        }
        #endregion


        #region 读取bool
        //对应不同的数据类型，需要选择对应的大小端传输
        //写一个读取线圈，bool类型的方法
        //调用ModbusRTU读取输出，输入线圈的方法，
        //判断返回数据的字节数组，是否读取到值
        //将字节数组转化成bool数组，BitLib.GetBitAraayFromByteAraay()方法转化成bool数组，从0开始读取线圈长度
        //最后将其转化成string数组显示出来
        /// <summary>
        /// 读取输入输出线圈，并将数据显示在日志中
        /// </summary>
        /// <param name="area">存储区</param>
        /// <param name="slaveid">从站地址</param>
        /// <param name="start">初始地址</param>
        /// <param name="length">长度</param>
        private void ReadBool(StoreArea area, byte slaveid, ushort start, ushort length)
        {
            byte[] result = null;
            switch (area)
            {
                //输入线圈1X,
                //输出线圈0X,
                //输入寄存器3X,
                //输出寄存器4X
                case StoreArea.输入线圈1X:
                  result = modbusRTU.ReadInPutCoils(slaveid,start,length);
                    break;
                case StoreArea.输出线圈0X: 
                    result=modbusRTU.ReadOutPutCoils(slaveid,start,length);
                    break;
                case StoreArea.输入寄存器3X:
                case StoreArea.输出寄存器4X:
                    Add_Log(1, "读取失败，不支持该存储区");
                    break;
            }
            if (result!=null)
            {
                Add_Log(0, "读取成功："+ StringLib.GetStringFromValueArray(BitLib.GetBitArrayFromByteArray(result)));
            }
            else 
            {
                Add_Log(1,"读取失败，请检查参数是否正确");
            }
        }
        #endregion

        #region 读取字节,线圈数据可以是字节，寄存器也是字节
        private void ReadByte(StoreArea area, byte slaveid, ushort start, ushort length)
        {
            byte[] result = null;
            switch (area)
            {
                //输入线圈1X,
                //输出线圈0X,
                //输入寄存器3X,
                //输出寄存器4X
                case StoreArea.输入线圈1X:
                    result = modbusRTU.ReadInPutCoils(slaveid, start, length);
                    break;
                case StoreArea.输出线圈0X:
                    result=modbusRTU.ReadOutPutCoils(slaveid, start, length);
                    break;
                case StoreArea.输入寄存器3X:
                    result=modbusRTU.ReadInPutRegisters(slaveid, start, length);
                    break;
                case StoreArea.输出寄存器4X:
                    result=modbusRTU.ReadOutPutRegisters(slaveid, start, length);
                    break;
            }
            if (result!=null)
            {
                Add_Log(0, "读取成功："+ StringLib.GetStringFromValueArray(result));
            }
            else
            {
                Add_Log(1, "读取失败，请检查参数是否正确");
            }
        }
        #endregion

        #region 读取Short，此时只能是寄存器，两个字节的寄存器不存在大小端
        private void ReadShort(StoreArea area, byte slaveid, ushort start, ushort length)
        {
            byte[] result = null;
            switch (area)
            {
                //输入线圈1X,
                //输出线圈0X,
                //输入寄存器3X,
                //输出寄存器4X
                case StoreArea.输入线圈1X:
                case StoreArea.输出线圈0X:
                    Add_Log(1, "读取失败不支持该存储区");
                   return;
                case StoreArea.输入寄存器3X:
                    result=modbusRTU.ReadInPutRegisters(slaveid, start, length);
                    break;
                case StoreArea.输出寄存器4X:
                    result=modbusRTU.ReadOutPutRegisters(slaveid, start, length);
                    break;
            }
            if (result!=null)
            {
                Add_Log(0, "读取成功："+ StringLib.GetStringFromValueArray(ShortLib.GetShortArrayFromByteArray( result)));
            }
            else
            {
                Add_Log(1, "读取失败，请检查参数是否正确");
            }
        }
        #endregion

        #region 读取Ushort，只能是寄存器，两个字节的寄存器不存在大小端
        private void ReadUshort(StoreArea area, byte slaveid, ushort start, ushort length)
        {
            byte[] result = null;
            switch (area)
            {
                //输入线圈1X,
                //输出线圈0X,
                //输入寄存器3X,
                //输出寄存器4X
                case StoreArea.输入线圈1X:
                case StoreArea.输出线圈0X:
                    Add_Log(1, "读取失败不支持该存储区");
                    return;
                case StoreArea.输入寄存器3X:
                    result=modbusRTU.ReadInPutRegisters(slaveid, start, length);
                    break;
                case StoreArea.输出寄存器4X:
                    result=modbusRTU.ReadOutPutRegisters(slaveid, start, length);
                    break;
            }
            if (result!=null)
            {
                Add_Log(0, "读取成功："+ StringLib.GetStringFromValueArray(UShortLib.GetUShortArrayFromByteArray(result)));
            }
            else
            {
                Add_Log(1, "读取失败，请检查参数是否正确");
            }
        }
        #endregion

        #region 读取int，需要考虑大小端，在这里所表示的长度必须乘2，int是4个字节表示的
        private void ReadInt(StoreArea area, byte slaveid, ushort start, ushort length)
        {
            byte[] result = null;
            switch (area)
            {
                //输入线圈1X,
                //输出线圈0X,
                //输入寄存器3X,
                //输出寄存器4X
                case StoreArea.输入线圈1X:
                case StoreArea.输出线圈0X:
                    Add_Log(1, "读取失败不支持该存储区");
                    return;
                case StoreArea.输入寄存器3X:
                    result=modbusRTU.ReadInPutRegisters(slaveid, start, (ushort)(length*2));
                    break;
                case StoreArea.输出寄存器4X:
                    result=modbusRTU.ReadOutPutRegisters(slaveid, start, (ushort)(length*2));
                    break;
            }
            if (result!=null)
            {
                Add_Log(0, "读取成功："+ StringLib.GetStringFromValueArray(IntLib.GetIntArrayFromByteArray(result,this.dataFormat)));
            }
            else
            {
                Add_Log(1, "读取失败，请检查参数是否正确");
            }
        }
        #endregion

        #region 读取Uint，需要考虑大小端，uint和int一样
        private void ReadUint(StoreArea area, byte slaveid, ushort start, ushort length)
        {
            byte[] result = null;
            switch (area)
            {
                //输入线圈1X,
                //输出线圈0X,
                //输入寄存器3X,
                //输出寄存器4X
                case StoreArea.输入线圈1X:
                case StoreArea.输出线圈0X:
                    Add_Log(1, "读取失败不支持该存储区");
                    return;
                case StoreArea.输入寄存器3X:
                    result=modbusRTU.ReadInPutRegisters(slaveid, start, (ushort)(length*2));
                    break;
                case StoreArea.输出寄存器4X:
                    result=modbusRTU.ReadOutPutRegisters(slaveid, start, (ushort)(length*2));
                    break;
            }
            if (result!=null)
            {
                Add_Log(0, "读取成功："+ StringLib.GetStringFromValueArray(UIntLib.GetUIntArrayFromByteArray(result, this.dataFormat)));
            }
            else
            {
                Add_Log(1, "读取失败，请检查参数是否正确");
            }
        }
        #endregion

        #region 读取float浮点数
        private void ReadFloat(StoreArea area, byte slaveid, ushort start, ushort length)
        {
            byte[] result = null;
            switch (area)
            {
                //输入线圈1X,
                //输出线圈0X,
                //输入寄存器3X,
                //输出寄存器4X
                case StoreArea.输入线圈1X:
                case StoreArea.输出线圈0X:
                    Add_Log(1, "读取失败不支持该存储区");
                    return;
                case StoreArea.输入寄存器3X:
                    result=modbusRTU.ReadInPutRegisters(slaveid, start, (ushort)(length*2));
                    break;
                case StoreArea.输出寄存器4X:
                    result=modbusRTU.ReadOutPutRegisters(slaveid, start, (ushort)(length*2));
                    break;
            }
            if (result!=null)
            {
                Add_Log(0, "读取成功："+ StringLib.GetStringFromValueArray(FloatLib.GetFloatArrayFromByteArray(result, this.dataFormat)));
            }
            else
            {
                Add_Log(1, "读取失败，请检查参数是否正确");
            }
        }
        #endregion

        #region 验证读取之前，输入的从站地址，线圈/寄存器的初始位置，线圈/寄存器数量，以及存储区和对应数据的类型是否正确
        //验证连接是否成功
        //验证从站地址格式是否正确  byte类型，通过是否可以转换成字节，ushort类型判断是否正确
        //起始地址是否争取  ushort
        //检查长度，是否正确
        /// <summary>
        /// 在读取之前验证，从站地址，初始地址，长度是否可以转化成ModbusRTU类中方法的参数的类型
        /// </summary>
        /// <returns></returns>
        private bool CommonVeify()
        {
            if (!IsConnect)
            {
                Add_Log(1, "ModbusRTU连接失败");
                return false;
            }
            if (!byte.TryParse(this.txtSlaveID.Text, out _))//不需要有对应的byte类型接受，只用判断就可以就用_
            {
                Add_Log(1, "从站地址格式不对请检查");
                return false;
            }
            if (!ushort.TryParse(this.txtStart.Text, out _))
            {
                Add_Log(1, "起始地址格式不对请检查");
                return false;
            }
            if (!ushort.TryParse(this.txtDataLength.Text, out _))
            {
                Add_Log(1, "长度不对请检查");
                return false;
            }
            return true;
        }
        #endregion


        #region  通用写入,写入int uint float数据的时候不需要考虑大小端
        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (CommonVeify())
            {
                //将对应的从站地址，初始地址，长度，全部转化为ModbusRTU读取方法中的，参数类型
                byte slaveid = byte.Parse(this.txtSlaveID.Text.Trim());
                ushort start = ushort.Parse(this.txtStart.Text);
               
                string setValues=this.txtWriteData.Text.Trim();
                //明确当前的数据类型
                DataType dataType = (DataType)Enum.Parse(typeof(DataType), this.cmbDataType.Text, true);
                //得到存储区
                StoreArea area = (StoreArea)Enum.Parse(typeof(StoreArea), this.cmbStoreArea.Text, true);
                //大小端
                dataFormat=(DataFormat)Enum.Parse(typeof(DataFormat), this.cmbDataFormat.Text, true);
                //判断数据类型，一般为bool，byte，short，ushort，int，uint，folat(浮点数),
                //double小数，long长整型，Ulong无符号长整型，string，bytearray字节数组，Hex十六进制，这些一般不考虑
                switch (dataType)
                {
                    case DataType.Bool:
                        WriteBool(area,slaveid,start,setValues);
                        break;
                    case DataType.Byte:
                        WriteByte(area, slaveid, start, setValues);
                        break;
                    case DataType.Short:
                        WriteShort(area, slaveid, start, setValues);
                        break;
                    case DataType.UShort:
                        WriteUshort(area, slaveid, start, setValues);
                        break;
                    case DataType.Int:
                        WriteInt(area, slaveid, start, setValues);
                        break;
                    case DataType.UInt:
                        WriteUInt(area, slaveid, start, setValues);
                        break;
                    case DataType.Float:
                        WriteFloat(area, slaveid, start, setValues);
                        break;
                    case DataType.Double:
                    case DataType.String:
                    case DataType.Long:
                    case DataType.ULong:
                    case DataType.ByteArray:
                    case DataType.HexString:
                        Add_Log(1, "写入失败");
                        return;
                }
            }
        }
        #endregion

        #region  写入bool，单线圈或者多线圈
        private void WriteBool(StoreArea area, byte slave, ushort start, string values)
        {
            bool result = false;
            switch (area)
            {
                case StoreArea.输出线圈0X:
                    bool[] setvalues = BitLib.GetBitArrayFromBitArrayString(values);
                    if (values.Length==1)
                    {
                        result=modbusRTU.PreSetSingleCoil(slave, start, setvalues[0]);
                    }
                    else
                    {
                        result=modbusRTU.PreSetMultiCoils(slave, start, setvalues);
                    }
                    break;
                case StoreArea.输入线圈1X:
                case StoreArea.输入寄存器3X:
                case StoreArea.输出寄存器4X:
                    Add_Log(1,"不支持该寄存区");
                    break;
            }
            if (result)
            {
                Add_Log(0, "写入成功");
            }
            else
            {
                Add_Log(1,"写入失败");
            }
        }
        #endregion

        #region 写入字节
        private void WriteByte(StoreArea area, byte slave, ushort start, string values)
        {
            bool result = false;
            byte[] setByte=ByteArrayLib.GetByteArrayFromHexString(values);
            switch (area)
            {
                
                case StoreArea.输入线圈1X:
                case StoreArea.输出线圈0X:
                case StoreArea.输入寄存器3X:
                    Add_Log(1, "不支持该寄存区");
                    break;
                case StoreArea.输出寄存器4X:
                    result=modbusRTU.PreSetMultiRegisters(slave, start, setByte);
                    break;
            }
            if (result)
            {
                Add_Log(0, "写入成功");
            }
            else
            {
                Add_Log(1, "写入失败");
            }
        }
        #endregion

        #region 写入short
        private void WriteShort(StoreArea area, byte slave, ushort start, string values)
        {
            bool result = false;
            short[] setValues = ShortLib.GetShortArrayFromString(values);
            switch (area)
            {

                case StoreArea.输入线圈1X:
                case StoreArea.输出线圈0X:
                case StoreArea.输入寄存器3X:
                    Add_Log(1, "不支持该寄存区");
                    break;
                case StoreArea.输出寄存器4X:
                    if (setValues.Length==1)
                    {
                        result=modbusRTU.PreSetSingleRegister(slave, start, ByteArrayLib.GetByteArrayFromShort(setValues[0]));
                    }
                    else
                    {
                        result=modbusRTU.PreSetMultiRegisters(slave, start, ByteArrayLib.GetByteArrayFromShortArray(setValues));
                    }
                    break;
            }
            if (result)
            {
                Add_Log(0, "写入成功");
            }
            else
            {
                Add_Log(1, "写入失败");
            }
        }
        #endregion

        #region 写入ushort
        private void WriteUshort(StoreArea area, byte slave, ushort start, string values)
        {
            bool result = false;
            ushort[] setValues = UShortLib.GetUShortArrayFromString(values);
            switch (area)
            {

                case StoreArea.输入线圈1X:
                case StoreArea.输出线圈0X:
                case StoreArea.输入寄存器3X:
                    Add_Log(1, "不支持该寄存区");
                    break;
                case StoreArea.输出寄存器4X:
                    if (setValues.Length==1)
                    {
                        result=modbusRTU.PreSetSingleRegister(slave, start, ByteArrayLib.GetByteArrayFromUShort(setValues[0]));
                    }
                    else
                    {
                        result=modbusRTU.PreSetMultiRegisters(slave, start, ByteArrayLib.GetByteArrayFromUShortArray(setValues));
                    }
                    break;
            }
            if (result)
            {
                Add_Log(0, "写入成功");
            }
            else
            {
                Add_Log(1, "写入失败");
            }
        }
        #endregion

        #region  写入int
        private void WriteInt(StoreArea area, byte slave, ushort start, string values)
        {
            bool result = false;
            int[] setValues = IntLib.GetIntArrayFromString(values);
            switch (area)
            {

                case StoreArea.输入线圈1X:
                case StoreArea.输出线圈0X:
                case StoreArea.输入寄存器3X:
                    Add_Log(1, "不支持该寄存区");
                    break;
                case StoreArea.输出寄存器4X:
                        result=modbusRTU.PreSetMultiRegisters(slave, start, ByteArrayLib.GetByteArrayFromIntArray(setValues));
                    break;
            }
            if (result)
            {
                Add_Log(0, "写入成功");
            }
            else
            {
                Add_Log(1, "写入失败");
            }
        }
        #endregion

        #region 写入Uint
        private void WriteUInt(StoreArea area, byte slave, ushort start, string values)
        {
            bool result = false;
            uint[] setValues = UIntLib.GetUIntArrayFromString(values);
            switch (area)
            {

                case StoreArea.输入线圈1X:
                case StoreArea.输出线圈0X:
                case StoreArea.输入寄存器3X:
                    Add_Log(1, "不支持该寄存区");
                    break;
                case StoreArea.输出寄存器4X:
                    
                        result=modbusRTU.PreSetMultiRegisters(slave, start, ByteArrayLib.GetByteArrayFromUIntArray(setValues));
                    
                    break;
            }
            if (result)
            {
                Add_Log(0, "写入成功");
            }
            else
            {
                Add_Log(1, "写入失败");
            }
        }
        #endregion

        #region 写入float
        private void WriteFloat(StoreArea area, byte slave, ushort start, string values)
        {
            bool result = false;
            float[] setValues = FloatLib.GetFloatArrayFromString(values);
            switch (area)
            {

                case StoreArea.输入线圈1X:
                case StoreArea.输出线圈0X:
                case StoreArea.输入寄存器3X:
                    Add_Log(1, "不支持该寄存区");
                    break;
                case StoreArea.输出寄存器4X:
                        result=modbusRTU.PreSetMultiRegisters(slave, start, ByteArrayLib.GetByteArrayFromFloatArray(setValues));
                    break;
            }
            if (result)
            {
                Add_Log(0, "写入成功");
            }
            else
            {
                Add_Log(1, "写入失败");
            }
        }
        #endregion
    }
}
