using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

using thinger.DataConvertLib;
using Wen.ModbucCommunicationLib.Enum;
using Wen.ModbucCommunicationLib.Interface;
using IMessage = Wen.ModbucCommunicationLib.Interface.IMessage;

namespace Wen.ModbucCommunicationLib.Base
{
    public class ReadWriteBase : IReadWrite
    {
        
        /// <summary>
        /// 最小存储数据类型
        /// </summary>
        public AreaType AreaType { get; set; } = AreaType.Wrod;

        /// <summary>
        /// 字节大小端
        /// </summary>
        public DataFormat DataFormat { get; set; } = DataFormat.ABCD;

        //1、首先通过接口得到通用读写方法
        //2、将其设定为虚方法，方便重写
        #region 继承读写接口，读写方法实现
        /// <summary>
        /// 读取布尔数组
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<bool[]> ReadBoolArray(string address, ushort length)
        {
            return OperateResult.CreateFailResult<bool[]>(new OperateResult());
        }
        /// <summary>
        /// 读取字节数组
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<byte[]> ReadByteArray(string address, ushort length)
        {
            return OperateResult.CreateFailResult<byte[]>(new OperateResult());
        }
        /// <summary>
        /// 写入布尔数组
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteBoolArray(string address, bool[] value)
        {
            return OperateResult.CreateFailResult();
        }
        /// <summary>
        /// 写入字节数组
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteByteArray(string address, byte[] value)
        {
            return OperateResult.CreateFailResult();
        }
        #endregion

        //所有的读写方法都是基于  继承接口的读写方法
        //对此只需要对这个继承接口的读写方法重写就可以实现所有的读写功能

        //在继承此ReadWriteBase，调用这个读写通用方法时，
        //读取：需要明白DataForamt大小端，PLC的最低存储区
        //写入：需要明白单个bool需要注意是否在寄存区，是寄存区需要单独调用WriteBool
        //写入string 需要编码解析（不是Encoding.ASCII需要单独调用WriteString）
        
        #region 读取方法

        #region 通用读取的方法
        /// <summary>
        /// 读取通用方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<T> ReadCommon<T>(string address,ushort length=1)
        {
            string datatype=typeof(T).ToString();
            OperateResult<T> result = new OperateResult<T>();
            switch (datatype)
            {
                case "System.Boolean":
                    result = OperateResult.CopyOperateResult<T, bool>(ReadBool(address));
                    break;
                case "System.Boolean[]":
                    result = OperateResult.CopyOperateResult<T, bool[]>(ReadBoolArray(address,length));
                    break;
                case "System.Byte":
                    result = OperateResult.CopyOperateResult<T, byte>(ReadByte(address,length));
                    break;
                case "System.Byte[]":
                    result = OperateResult.CopyOperateResult<T, byte[]>(ReadByteArray(address,length));
                    break;
                case "System.Int16":
                    result = OperateResult.CopyOperateResult<T, ushort>(ReadUInt16(address));
                    break;
                case "System.Int16[]":
                    result = OperateResult.CopyOperateResult<T, ushort[]>(ReadUInt16Array(address,length));
                    break;
                case "System.UInt16":
                    result = OperateResult.CopyOperateResult<T, ushort[]>(ReadUInt16Array(address,length));
                    break;
                case "System.Int32":
                    result = OperateResult.CopyOperateResult<T, int>(ReadInt32(address));
                    break;
                case "System.Int32[]":
                    result = OperateResult.CopyOperateResult<T, int[]>(ReadInt32Array(address,length));
                    break;
                case "System.UInt32":
                    result = OperateResult.CopyOperateResult<T, uint>(ReadUInt32(address));
                    break;
                case "System.UInt32[]":
                    result = OperateResult.CopyOperateResult<T, uint[]>(ReadUInt32Array(address,length));
                    break;
                case "System.Single":
                    result = OperateResult.CopyOperateResult<T, float>(ReadFloat(address));
                    break;
                case "System.Single[]":
                    result = OperateResult.CopyOperateResult<T, float[]>(ReadFloatArray(address,length));
                    break;
                case "System.Int64":
                    result = OperateResult.CopyOperateResult<T, long>(ReadLong(address));
                    break;
                case "System.Int64[]":
                    result = OperateResult.CopyOperateResult<T, long[]>(ReadLongArray(address, length));
                    break;
                case "System.Double":
                    result = OperateResult.CopyOperateResult<T, double>(ReadDouble(address));
                    break;
                case "System.Double[]":
                    result = OperateResult.CopyOperateResult<T, double[]>(ReadDoubleArray(address, length));
                    break;
                case "System.String":
                    result = OperateResult.CopyOperateResult<T, string>(ReadStringArray(address, length));
                    break;
                default:
                    break;
            }
            return result;  
        }
        #endregion

        #region 读取单个布尔
        /// <summary>
        /// 读取单个布尔
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<bool> ReadBool(string address,ushort length=1)
        { 
            var result=ReadBoolArray(address,length);
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(result.Content[0]);
            }
            else
            {
                return OperateResult.CreateFailResult<bool>(result);
            }
        }
        #endregion


        #region 读取单个字节
        /// <summary>
        /// 读取单个字节
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length">字节个数</param>
        /// <returns></returns>
        public virtual OperateResult<byte> ReadByte(string address,ushort length=1)
        {
            var result = ReadByteArray(address, length);
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(result.Content[0]);
            }
            else
            {
                return OperateResult.CreateFailResult<byte>(result);
            }
        }
        #endregion

        #region 读取int16
        /// <summary>
        /// 读取Int16
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length">字节个数</param>
        /// <returns></returns>
        public virtual OperateResult<short[]> ReadInt16Array(string address,ushort length)
        {
            //最小单位可能是 BYTE,也可能是 WROD,这样处理不管是WORD，对应在字节数组里面，都是读取两个字节
            //暂时存疑,因为这样处理读取WROD时，只能在Byte[]数组，读一个字节
            var result=ReadByteArray(address, (ushort)(length*2/(int)this.AreaType));
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(ShortLib.GetShortArrayFromByteArray(result.Content,this.DataFormat));
            }
            else 
            {
                //这里读取失败，说明result就还是var,可以根据需求，变为short[]类型
                return OperateResult.CreateFailResult<short[]>(result);
            }
        }

        /// <summary>
        /// 读取单个Int16
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<short> ReadInt16(string address)
        {
            //最小单位可能是 BYTE,也可能是 WROD,这样处理不管是WORD，对应在字节数组里面，都是读取两个字节
            //暂时存疑,因为这样处理读取WROD时，只能在Byte数组，读一个字节
            var result = ReadInt16Array(address,1);
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(result.Content[0]);
            }
            else
            {
                //这里读取失败，说明result就还是var,可以根据需求，变为short类型
                return OperateResult.CreateFailResult<short>(result);
            }
        }
        #endregion

        #region 读取Uint16
        /// <summary>
        /// 读取Uint16
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length">字节个数</param>
        /// <returns></returns>
        public virtual OperateResult<ushort[]> ReadUInt16Array(string address, ushort length)
        {
            //最小单位可能是 BYTE,也可能是 WROD,这样处理不管是WORD，对应在字节数组里面，都是读取两个字节
            //暂时存疑,因为这样处理读取WROD时，只能在Byte[]数组，读一个字节
            var result = ReadByteArray(address, (ushort)(length*2/(int)this.AreaType));
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(UShortLib.GetUShortArrayFromByteArray(result.Content, this.DataFormat));
            }
            else
            {
                //这里读取失败，说明result就还是var,可以根据需求，变为short[]类型
                return OperateResult.CreateFailResult<ushort[]>(result);
            }

        }

        /// <summary>
        /// 读取单个Uint16
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<ushort> ReadUInt16(string address)
        {
            //最小单位可能是 BYTE,也可能是 WROD,这样处理不管是WORD，对应在字节数组里面，都是读取两个字节
            //暂时存疑,因为这样处理读取WROD时，只能在Byte数组，读一个字节
            var result = ReadUInt16Array(address, 1);
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(result.Content[0]);
            }
            else
            {
                //这里读取失败，说明result就还是var,可以根据需求，变为short类型
                return OperateResult.CreateFailResult<ushort>(result);
            }

        }

        #endregion

        #region  读取Int32
        /// <summary>
        /// 读取Int32
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length">字节个数</param>
        /// <returns></returns>
        public virtual OperateResult<int[]> ReadInt32Array(string address, ushort length)
        {
            var result = ReadByteArray(address,(ushort)((length*4)/(int)this.AreaType));
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(IntLib.GetIntArrayFromByteArray(result.Content,this.DataFormat));
            }
            else
            {
                return OperateResult.CreateFailResult<int[]>(result);
            }
        }

        /// <summary>
        /// 读取单个Int32
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<int> ReadInt32(string address)
        {
            var result = ReadInt32Array(address, 1);
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(result.Content[0]);
            }
            else
            {
                return OperateResult.CreateFailResult<int>(result);
            }
        }
        #endregion

        #region 读取UInt32
        /// <summary>
        /// 读取UInt16
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length">字节个数</param>
        /// <returns></returns>
        public virtual OperateResult<uint[]> ReadUInt32Array(string address,ushort length)
        {
            var result = ReadByteArray(address, (ushort)((length*4)/(int)this.AreaType));
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(UIntLib.GetUIntArrayFromByteArray(result.Content,this.DataFormat));
            }
            else 
            {
                return OperateResult.CreateFailResult<uint[]>(result);
            }
        }

        /// <summary>
        /// 读取单个UInt32
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<uint> ReadUInt32(string address)
        {
            var result = ReadUInt32Array(address, 1);
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(result.Content[0]);
            }
            else
            {
                return OperateResult.CreateFailResult<uint>(result);
            }
        }
        #endregion

        #region  读取Int64
        /// <summary>
        /// 读取Int64
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<long[]> ReadLongArray(string address,ushort length)
        {
            var result = ReadByteArray(address, (ushort)((length*8)/(int)this.AreaType));
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(LongLib.GetLongArrayFromByteArray(result.Content));
            }
            else 
            {
                return OperateResult.CreateFailResult<Int64[]>(result);
            }
        }
        /// <summary>
        /// 读取单个Int64
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<long> ReadLong(string address)
        {
            var result = ReadLongArray(address, 1);
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(result.Content[0]);
            }
            else
            {
                return OperateResult.CreateFailResult<Int64>(result);
            }
        }
        #endregion

        #region 读取UInt64
        /// <summary>
        /// 读取UInt64
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<ulong[]> ReadULongArray(string address, ushort length)
        {
            var result = ReadByteArray(address, (ushort)((length*8)/(int)this.AreaType));
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(ULongLib.GetULongArrayFromByteArray(result.Content));
            }
            else
            {
                return OperateResult.CreateFailResult<UInt64[]>(result);
            }
        }

        /// <summary>
        /// 读取单个UInt64
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<ulong> ReadULong(string address)
        {
            var result = ReadULongArray(address, 1);
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(result.Content[0]);
            }
            else
            {
                return OperateResult.CreateFailResult<UInt64>(result);
            }
        }
        #endregion

        #region 读取Float
        /// <summary>
        /// 读取Float
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<float[]> ReadFloatArray(string address, ushort length)
        {
            var result = ReadByteArray(address, (ushort)((length*8)/(int)this.AreaType));
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(FloatLib.GetFloatArrayFromByteArray(result.Content));
            }
            else
            {
                return OperateResult.CreateFailResult<float[]>(result);
            }
        }

        /// <summary>
        /// 读取单个Float
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<float> ReadFloat(string address)
        {
            var result = ReadFloatArray(address,1);
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(result.Content[0]);
            }
            else
            {
                return OperateResult.CreateFailResult<float>(result);
            }
        }
        #endregion

        #region 读取Double
        /// <summary>
        /// 读取Double
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<Double[]> ReadDoubleArray(string address, ushort length)
        {
            var result = ReadByteArray(address, (ushort)((length*8)/(int)this.AreaType));
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(DoubleLib.GetDoubleArrayFromByteArray(result.Content));
            }
            else
            {
                return OperateResult.CreateFailResult<Double[]>(result);
            }
        }

        /// <summary>
        /// 读取单个Double
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual OperateResult<Double> ReadDouble(string address)
        {
            var result = ReadDoubleArray(address,1);
            if (result.IsSuccess)
            {
                return OperateResult.CreateSuccessResult(result.Content[0]);
            }
            else
            {
                return OperateResult.CreateFailResult<Double>(result);
            }
        }
        #endregion

        #region 读取String
        /// <summary>
        /// 读取String
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <param name="StringType"></param>
        /// <returns></returns>
        public virtual OperateResult<string> ReadStringArray(string address,ushort length,StringType StringType=StringType.ASCIIString)
        {
            var result = ReadByteArray(address, length);
            if (result.IsSuccess)
            {
                switch (StringType)
                {
                    case StringType.DecString:
                        return OperateResult.CreateSuccessResult(StringLib.GetStringFromValueArray(result.Content, 0, result.Content.Length));
                    case StringType.HexString:
                        return OperateResult.CreateSuccessResult(StringLib.GetHexStringFromByteArray(result.Content, 0, result.Content.Length));
                    case StringType.ASCIIString:
                        return OperateResult.CreateSuccessResult(StringLib.GetStringFromByteArrayByEncoding(result.Content, 0, result.Content.Length, Encoding.ASCII));
                    case StringType.BitConvertString:
                        return OperateResult.CreateSuccessResult(StringLib.GetStringFromByteArrayByBitConvert(result.Content, 0, result.Content.Length));
                    case StringType.SiemensString:
                        return OperateResult.CreateSuccessResult(StringLib.GetSiemensStringFromByteArray(result.Content, 0, result.Content.Length));
                    default:
                        return OperateResult.CreateSuccessResult(StringLib.GetStringFromByteArrayByEncoding(result.Content, 0, result.Content.Length, Encoding.ASCII));
                }
            }
            else
            {
                return OperateResult.CreateFailResult<string>(result);
            }
        }
        #endregion

        #endregion

        #region 写入方法

        #region 写入通用方法
        /// <summary>
        /// 通用写入方法
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteCommon(string address, object value)
        {
            OperateResult result = new OperateResult();
            try
            {
                switch (value.GetType().Name)
                {
                    case "Boolean":
                        return WriteBool(address, (bool)value);
                    case "Boolean[]":
                        return WriteBoolArray(address, (bool[])value);
                    case "Byte":
                        return WriteByte(address, (byte)value);
                    case "Byte[]":
                        return WriteByteArray(address, (byte[])value);
                    case "Int16":
                        return WriteShort(address, (short)value);
                    case "Int16[]":
                        return WriteShortArray(address, (short[])value);
                    case "UInt16":
                        return WriteUShort(address, (ushort)value);
                    case "UInt16[]":
                        return WriteUShortArray(address, (ushort[])value);
                    case "Int32":
                        return WriteInt(address, (int)value);
                    case "Int32[]":
                        return WriteIntArray(address, (int[])value);
                    case "UInt32":
                        return WriteUInt(address, (uint)value);
                    case "UInt32[]":
                        return WriteUIntArray(address, (uint[])value);
                    case "Int64":
                        return WriteLong(address, (long)value);
                    case "Int64[]":
                        return WriteLongArray(address, (long[])value);
                    case "UInt64[]":
                        return WriteULong(address, (ulong)value);
                    case "UInt64":
                        return WriteULongArray(address, (ulong[])value);
                    case "Single":
                        return WriteFloat(address, (long)value);
                    case "Single[]":
                        return WriteFloatArray(address, (float[])value);
                    case "Double":
                        return WriteDouble(address, (double)value);
                    case "Double[]":
                        return WriteDoubleArray(address, (double[])value);
                    case "String":
                        return WriteString(address, (string)value);
                    default:
                        return new OperateResult(false, "不支持数据类型");
                }
            }
            catch(Exception ex)
            {
                return new OperateResult(false,ex.Message);
            }
        }
        #endregion

        #region 写入单个布尔
        /// <summary>
        /// 写入单个布尔，isregister判断地址是否是寄存器，true表示是寄存器
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <param name="isregister"></param>
        /// <returns></returns>
        public virtual OperateResult WriteBool(string address,bool value, bool isregister=false)
        {
            if (isregister)
            {
                //如果是寄存器 1.40001.1（ModbusTCP） DB1.DBX0.1（西门子DB块）
                int index= address.LastIndexOf(".");
                //寄存器地址，偏移量
                string  add= address.Substring(0, index);
                int offset =Convert.ToInt32( address.Substring(index+1));
                //修改字节的某个为
                var result = ReadInt16(address);
                if (result.IsSuccess)
                {
                    return WriteShort(add,ShortLib.SetBitValueFromShort(result.Content,offset,value,this.DataFormat));
                }
                else 
                {
                    return OperateResult.CreateFailResult("寄存器读取失败");
                }
            }
            else
            {
                return WriteBoolArray(address,new bool[] { value});
            }
        }
        #endregion

        #region 读取单个字节
        /// <summary>
        /// 读取单个字节
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteByte(string address, byte value)
        {
            return WriteByteArray(address,new byte[] { value });
        }
        #endregion

        #region 写入Short
        /// <summary>
        /// 写入Short
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteShortArray(string address, short[] value)
        {
            return WriteByteArray(address,ByteArrayLib.GetByteArrayFromShortArray(value,this.DataFormat));
        }
        /// <summary>
        /// 写入单个Short
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteShort(string address,short value)
        {
            return WriteShortArray(address,new short[] { value});
        }
        #endregion

        #region 写入UShort
        /// <summary>
        /// 写入UShort
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteUShortArray(string address, ushort[] value)
        {
            return WriteByteArray(address, ByteArrayLib.GetByteArrayFromUShortArray(value, this.DataFormat));
        }
        /// <summary>
        /// 写入单个UShort
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteUShort(string address, ushort value)
        {
            return WriteUShortArray(address, new ushort[] { value });
        }
        #endregion

        #region 写入Int
        /// <summary>
        /// 写入Int
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteIntArray(string address, int[] value)
        {
            return WriteByteArray(address, ByteArrayLib.GetByteArrayFromIntArray(value, this.DataFormat));
        }
        /// <summary>
        /// 写入单个Int
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteInt(string address, int value)
        {
            return WriteIntArray(address, new int[] { value });
        }
        #endregion

        #region 写入UInt
        /// <summary>
        /// 写入UInt
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteUIntArray(string address, uint[] value)
        {
            return WriteByteArray(address, ByteArrayLib.GetByteArrayFromUIntArray(value, this.DataFormat));
        }
        /// <summary>
        /// 写入单个Uint
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteUInt(string address, uint value)
        {
            return WriteUIntArray(address, new uint[] { value  });
        }
        #endregion

        #region 写入Int64
        /// <summary>
        /// 写入Int64
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteLongArray(string address, long[] value)
        {
            return WriteByteArray(address, ByteArrayLib.GetByteArrayFromLongArray(value, this.DataFormat));
        }
        /// <summary>
        /// 写入单个Int64
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteLong(string address, long value)
        {
            return WriteLongArray(address, new long[] { value });
        }
        #endregion

        #region 写入UInt64
        /// <summary>
        /// 写入UInt64
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteULongArray(string address, ulong[] value)
        {
            return WriteByteArray(address, ByteArrayLib.GetByteArrayFromULongArray(value, this.DataFormat));
        }
        /// <summary>
        /// 写入单个Uint64
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteULong(string address, ulong value)
        {
            return WriteULongArray(address, new ulong[] { value });
        }
        #endregion

        #region 写入float
        /// <summary>
        /// 写入float
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteFloatArray(string address, float[] value)
        {
            return WriteByteArray(address, ByteArrayLib.GetByteArrayFromFloatArray(value, this.DataFormat));
        }
        /// <summary>
        /// 写入单个float
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteFloat(string address, float value)
        {
            return WriteFloatArray(address, new float[] { value });
        }
        #endregion

        #region 写入Double
        /// <summary>
        /// 写入Double
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteDoubleArray(string address, double[] value)
        {
            return WriteByteArray(address, ByteArrayLib.GetByteArrayFromDoubleArray(value, this.DataFormat));
        }
        /// <summary>
        /// 写入单个Double
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteDouble(string address, double value)
        {
            return WriteDoubleArray(address, new double[] { value });
        }
        #endregion

        #region 写入String
        /// <summary>
        /// 写入string
        /// </summary>
        /// <param name="addres"></param>
        /// <param name="value"></param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public virtual OperateResult WriteString(string address,string value,Encoding encoding)
        {
            return WriteByteArray(address,ByteArrayLib.GetByteArrayFromString(value,encoding));
        }
        /// <summary>
        /// 写入string，默认编码格式Encoding.ASCII
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual OperateResult WriteString(string address, string value)
        {
            return WriteByteArray(address,ByteArrayLib.GetByteArrayFromString(value,Encoding.ASCII));
        }
        #endregion

        #endregion
    }
}
