using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.ModbucCommunicationLib.Enum;

namespace Wen.ModbucCommunicationLib.StoreArea
{
    /// <summary>
    /// Modbus功能区
    /// </summary>
    public class ModbusStoreArea
    {

        public ModbusStoreArea(FunctionCode readFunctionCode,FunctionCode writeFunctionCode) 
        {
            this.WriteFunction=writeFunctionCode;
            this.ReadFunction=readFunctionCode; 
        }

        /// <summary>
        /// 写入功能码
        /// </summary>
        public FunctionCode WriteFunction { get; set; }
        /// <summary>
        /// 读取功能码
        /// </summary>
        public FunctionCode ReadFunction { get; set; }

        /// <summary>
        /// X0  输出线圈
        /// </summary>
        public readonly static ModbusStoreArea x0=new ModbusStoreArea(FunctionCode.ReadOutputStatus,FunctionCode.ForceMultiCoil);
        /// <summary>
        ///  X1 输入线圈
        /// </summary>
        public readonly static ModbusStoreArea x1 = new ModbusStoreArea(FunctionCode.ReadInputStatus,0x00);
        /// <summary>
        /// X3 输入寄存器
        /// </summary>
        public readonly static ModbusStoreArea x3=new ModbusStoreArea (FunctionCode.ReadOutputRegister,0x00);
        /// <summary>
        /// X4 输出寄存器
        /// </summary>
        public readonly static ModbusStoreArea x4 = new ModbusStoreArea(FunctionCode.ReadOutputRegister,FunctionCode.PreSetMultiRegister);
    }
}
