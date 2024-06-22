using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wen.ModbucCommunicationLib.Interface
{
    /// <summary>
    /// 返回的报文消息接口（报文接口）
    /// </summary>
    public interface IMessage
    {
        //报文分两段： 一段是包头，一段是数据
        /// <summary>
        /// 包头长度
        /// </summary>
        int HeadDataLength { get; set; }

        /// <summary>
        /// 包头数据（如RTU从站地址，功能码，变量起始地址,数量/如TCP 事务标识，协议标识，单元标识）
        /// </summary>
        byte[] HeadData { get; set; }

        /// <summary>
        /// 数据报文
        /// </summary>
        byte[] ContentData { get; set; }

        /// <summary>
        /// 发送报文
        /// </summary>
        byte[] SendData { get; set; }

        /// <summary>
        /// 获取数据长度
        /// </summary>
        /// <returns></returns>
        int GetContentLength();

        /// <summary>
        /// 检查包头数据
        /// </summary>
        /// <returns></returns>
        bool CheckHeadData(byte[] hedaData);
    }
}
