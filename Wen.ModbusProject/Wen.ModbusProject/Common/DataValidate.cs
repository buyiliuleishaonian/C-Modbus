using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace Wen.ModbusProject
{
    /// <summary>
    /// 通用验证类
    /// </summary>
    public class DataValidate
    {
        /// <summary>
        /// 验证正整数,是正整数输出true,否则为false
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsInteger(string txt)
        {
            Regex objReg = new Regex(@"^[1-9]\d*$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 验证是否是Email
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsEmail(string txt)
        {
            Regex objReg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 验证身份证
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsIdentityCard(string txt)
        {
            Regex objReg = new Regex(@"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
            return objReg.IsMatch(txt);
        }

        /// <summary>
        /// 验证输入的是否是字节
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsByte(string  txt)
        {
            string patten= "^[0-9A-Fa-f]{2}$";
            return Regex.IsMatch(txt, patten);
        }
    }
}
