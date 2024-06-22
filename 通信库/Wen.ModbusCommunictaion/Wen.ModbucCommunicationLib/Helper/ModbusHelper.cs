using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;
using Wen.ModbucCommunicationLib.StoreArea;

namespace Wen.ModbucCommunicationLib.Helper
{
    /// <summary>
    /// 解析Modbus通信的 设备PLC的通信地址
    /// </summary>
    public class ModbusHelper
    {
        /// <summary>
        /// 解析Modbus地址， 1.40001,40001
        /// </summary>
        /// <param name="address">Modbus地址</param>
        /// <param name="devAddress">默认从站地址</param>
        /// <param name="isushort">是否是短整型</param>
        /// <returns>返回结果
        /// <remarks>第一值表示为功能码</remarks>
        /// <remarks>第二值表示为从站地址</remarks>
        /// <remarks>第三值表示为相对地址</remarks>
        /// </returns>
        public static OperateResult<ModbusStoreArea, byte, ushort> ModbusAddressAnalysis(string address, byte defaultDevAddress,bool isShortAddress)
        { 
            //返回结果
            var result=new OperateResult<ModbusStoreArea, byte, ushort>() 
            {
                IsSuccess = true,
            };

            try
            {
                //寄存地址
                string analysis = string.Empty;

                if (address.Contains("."))
                {
                    string[] value = address.Split('.');
                    //可能存在地址上表明了从站地址
                    if (value.Length==2)
                    {
                        //得到从站地址
                        result.Content2=Convert.ToByte(value[0]);
                        analysis=value[1];
                    }
                    else
                    {
                        return OperateResult.CreateFailResult<ModbusStoreArea, byte, ushort>("变量格式不对"+address);
                    }
                }
                else
                {
                    result.Content2=defaultDevAddress;
                    analysis=address;
                }

                //不管是否给了从站地址，此时都已经得到从站地址

                //解析寄存地址 40001 000001
                //判断是否是短整型，
                analysis=analysis.PadLeft(isShortAddress ? 5 : 6, '0');
                switch (analysis[0].ToString())
                {
                    case "0":
                        result.Content1=ModbusStoreArea.x0;
                        result.Content3=Convert.ToUInt16(Convert.ToUInt32(analysis.Substring(1))-1);
                        break;
                    case "1":
                        result.Content1=ModbusStoreArea.x1;
                        result.Content3=Convert.ToUInt16(Convert.ToUInt32(analysis.Substring(1))-1);
                        break;
                    case "3":
                        result.Content1=ModbusStoreArea.x3;
                        result.Content3=Convert.ToUInt16(Convert.ToUInt32(analysis.Substring(1))-1);
                        break;
                    case "4":
                        result.Content1=ModbusStoreArea.x4;
                        result.Content3=Convert.ToUInt16(Convert.ToUInt32(analysis.Substring(1))-1);
                        break;
                    default:
                        result.IsSuccess=false;
                        result.Message="变量格式错误"+analysis;
                        break;
                }
            }
            catch(Exception ex) 
            {
                result.IsSuccess=false;
                result.Message=ex.Message;
            }
            return result;
        }
    }
}
