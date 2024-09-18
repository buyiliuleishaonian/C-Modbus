using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;


namespace CommonHelper
{
    /// <summary>
    /// CPUInfoHelper
    /// </summary>
    public class CPUInfoHelper
    {

        private static string defaultValue = "abcdefgh";

        /// <summary>
        /// 获取计算机信息
        /// </summary>
        /// <returns>获取结果</returns>
        public static string GetComputerInfo()
        {
            string cpu = GetCPUInfo();
            string bios = GetBIOSInfo();
            return string.Concat(cpu, bios);
        }
        /// <summary>
        /// 获取CPU
        /// </summary>
        /// <returns></returns>
        public static string GetCPUInfo()
        {
            return GetHardWareInfo("Win32_Processor", "ProcessorId");
        }
        /// <summary>
        /// 获取BIOS
        /// </summary>
        /// <returns></returns>
        public static string GetBIOSInfo()
        {
            string info = GetHardWareInfo("Win32_BIOS", "SerialNumber");
            if (!string.IsNullOrEmpty(info) && info != "To be filled by O.E.M" && !info.Contains("O.E.M") && !info.Contains("OEM") && !info.Contains("Default"))
            {
                return info;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 获取硬件信息
        /// </summary>
        /// <param name="typePath">不同类型</param>
        /// <param name="key">钥匙</param>
        /// <returns></returns>
        private static string GetHardWareInfo(string typePath, string key)
        {
            ManagementClass managementClass = new ManagementClass(typePath);
            ManagementObjectCollection mn = managementClass.GetInstances();
            PropertyDataCollection properties = managementClass.Properties;
            foreach (PropertyData property in properties)
            {
                if (property.Name == key)
                {
                    foreach (ManagementObject m in mn)
                    {
                        return m.Properties[property.Name].Value.ToString();
                    }
                }
            }
            return string.Empty;
        }


        /// <summary>
        /// 加密结果
        /// </summary>
        /// <returns>返回加密结果</returns>
        public static string Encrypt()
        {
            return StringSecurityHelper.DESEncrypt(StringSecurityHelper.MD5Encrypt(GetComputerInfo()));
        }

        /// <summary>
        /// 验证是否正确
        /// </summary>
        /// <param name="Code">字符串</param>
        /// <returns>结果</returns>
        public static bool Check(string Code)
        {
            if (StringSecurityHelper.DESDecrypt(Code) == StringSecurityHelper.MD5Encrypt(GetComputerInfo()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
