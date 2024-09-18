using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace CommonHelper
{
    public class IniConfigHelper
    {
        #region API函数声明

        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32",EntryPoint ="GetPrivateProfileString")]//返回取得字符串缓冲区的长度
        private static extern uint GetPrivateProfileStringA(string section, string key,
            string def, byte[] buffer, int size, string filePath);


        [DllImport("kernel32",EntryPoint ="GetPrivateProfileString")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);


        #endregion

        #region 读Ini文件
        /// <summary>
        /// 查询INI文件中的指定配置项
        /// </summary>
        /// <param name="Section">标题名</param>
        /// <param name="Key">键值对</param>
        /// <param name="NoText">当找不到键值对时返回的参数</param>
        /// <param name="iniFilePath">文件路径</param>
        /// <returns></returns>
        public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        #endregion

        #region 写Ini文件
        /// <summary>
        /// 写入Ini文件
        /// </summary>
        /// <param name="Section">节点名</param>
        /// <param name="Key">键值对</param>
        /// <param name="Value">写入值</param>
        /// <param name="iniFilePath">路径</param>
        /// <returns></returns>
        public static bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
                if (OpStation == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 读取所有的Section(节点)的名称
        /// <summary>
        /// 读取指定ini文件的所有节点名称
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> ReadSectionName(string path)
        {
            byte[] buffer=new byte[65536];
            uint length=GetPrivateProfileStringA(null, null, null, buffer, buffer.Length, path);
            int startSection = 0;
            List<string> section=new List<string>();
            for (int i = 0; i < length; i++)
            {
                if (buffer[i]==0)
                {
                    section.Add(Encoding.Default.GetString(buffer, startSection, i-startSection));
                    startSection=i+1;
                }
            }
            return section;
        }
        #endregion

        #region 读取指定section下所有的值

        /// <summary>
        /// 读取指定Section的key值
        /// </summary>
        /// <param name="section"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> ReadSectionKey(string section,string path)
        {

            byte[] buffer = new byte[65536];
            uint length = GetPrivateProfileStringA(section, null, null, buffer, buffer.Length, path);
            int startSection = 0;
            List<string> sectionKey = new List<string>();
            for (int i = 0; i < length; i++)
            {
                if (buffer[i]==0)
                {
                    sectionKey.Add(Encoding.Default.GetString(buffer, startSection, i-startSection));
                    startSection=i+1;
                }
            }
            return sectionKey;
        }
        #endregion

    }
}