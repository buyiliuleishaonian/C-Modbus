using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace CommonHelper
{
    /// <summary>
    /// 字符串加密解密类
    /// </summary>
    public sealed class StringSecurityHelper
    {
        private StringSecurityHelper() { }

        #region DES 加密/解密

        private static byte[] key = ASCIIEncoding.ASCII.GetBytes("uiertysd");
        private static byte[] iv = ASCIIEncoding.ASCII.GetBytes("99008855");

        /// <summary>
        /// DES加密。
        /// </summary>
        /// <param name="inputString">输入字符串。</param>
        /// <returns>加密后的字符串。</returns>
        public static string DESEncrypt(string inputString)
        {
            MemoryStream ms = null;
            CryptoStream cs = null;
            StreamWriter sw = null;

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                sw = new StreamWriter(cs);
                sw.Write(inputString);
                sw.Flush();
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }
            finally
            {
                if (sw != null) sw.Close();
                if (cs != null) cs.Close();
                if (ms != null) ms.Close();
            }
        }

        /// <summary>
        /// DES解密。
        /// </summary>
        /// <param name="inputString">输入字符串。</param>
        /// <returns>解密后的字符串。</returns>
        public static string DESDecrypt(string inputString)
        {
            MemoryStream ms = null;
            CryptoStream cs = null;
            StreamReader sr = null;

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                ms = new MemoryStream(Convert.FromBase64String(inputString));
                cs = new CryptoStream(ms, des.CreateDecryptor(key, iv), CryptoStreamMode.Read);
                sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            finally
            {
                if (sr != null) sr.Close();
                if (cs != null) cs.Close();
                if (ms != null) ms.Close();
            }
        }

        #endregion

        #region SHA1加密
        /// <summary>
        /// 使用SHA1加密字符串
        /// </summary>
        /// <param name="inputString">待加密的字符串</param>
        /// <returns>加密后的字符串（40个字符）</returns>
        public static string StringToSHA1Hash(string inputString)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] encrypteBytes = sha1.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encrypteBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encrypteBytes[i]);
            }
            return sb.ToString();
        }

        #endregion

        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="password">需要加密的数据</param>
        /// <returns>返回加密之后的十六进制的字符串</returns>

        public static string MD5Encrypt(string password)
        {
            //手下需要创建MD5对象
            //MD5是个抽象类
            //通过MD5类中的create方法从，返回值是MD5，这样来模拟一个对象
            MD5 md5 = MD5.Create();
            //开始加密字节数组
            //需要将字符串转成字节数组
            byte[] buffer = Encoding.Default.GetBytes(password);
            //开始加密,得到得是一个字节数组
            buffer = md5.ComputeHash(buffer);
            //将字节数组转成字符串有三种方式
            //1、就是将字节数组通过编码方式转成对应得字串
            //2、就是将字节数组直接tostring（）；这样得到只可能是字节数组所在的命名空间
            //3、将字节数组里面的每一个元素都转成字符串。
            string newstr = null;
            for (int i = 0; i < buffer.Length; i++)
            {
                newstr += buffer[i].ToString("x");//十进制转程16进制
            }
            return newstr;
        }
        #endregion

    }
}
