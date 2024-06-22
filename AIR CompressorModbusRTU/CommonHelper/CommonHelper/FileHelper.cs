using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        #region 文件写入
        /// <summary>
        /// 将文本内容进行写入和追加
        /// </summary>
        /// <param name="path">写入/追加路径</param>
        /// <param name="text">文本内容</param>
        /// <param name="isAppEnd">判断是否追加</param>
        public static void WriteFile(string path, string text, bool isAppEnd)
        {
            //方法一，通过文件流直接写入到文件中
            //using (FileStream fileStream = new FileStream(path, isAppEnd?FileMode.Append:FileMode.Create, FileAccess.Write))
            //{
            //    byte[] buffer = Encoding.Default.GetBytes(text);
            //    fileStream.Write(buffer, 0, buffer.Length);
            //}

            //方法二，通过文件流和写入流
            using (FileStream fileStream = new FileStream(path, isAppEnd ? FileMode.Append : FileMode.Create, FileAccess.Write))
            {
                StreamWriter writer = new StreamWriter(fileStream);
                writer.Write(text);
            }
        }
        #endregion

        #region 文件一次性读取
        /// <summary>
        /// 一次性读取文件内容
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                if (!File.Exists(path))
                {
                    return string.Empty;
                }
                StreamReader reader = new StreamReader(fileStream);
                return reader.ReadToEnd();
            }
        }
        #endregion

        #region 对象序列化，反序列化
        /// <summary>
        /// 对象序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        public static void SerializeFile(object obj, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, obj);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T DeSerializeFile<T>(string path)
        {

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    return (T)binaryFormatter.Deserialize(fileStream);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        #endregion

        #region 对象序列化二进制字符串
        /// <summary>
        /// 将对象序列化成字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SeralizeToString(object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            string value = string.Empty;
            //创建一个缓存区
            using (MemoryStream stream = new MemoryStream())
            {
                //序列化
                formatter.Serialize(stream, obj);
                byte[] buffer = stream.ToArray();
                value=Convert.ToBase64String(buffer);
                stream.Flush();
            }
            return value;
        }

        /// <summary>
        /// 将字符串反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T DeSeralizeToString<T>(string value) where T : class
        {
            IFormatter formatter = new BinaryFormatter();

            byte[] buffer = Convert.FromBase64String(value);

            T obj = null;

            using (MemoryStream stream = new MemoryStream(buffer))
            {
                obj=(T)formatter.Deserialize(stream);
            }

            return obj;
        }
        #endregion

        #region 文件操作
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="srcFileName">源文件路径</param>
        /// <param name="desFileName">目标文件路径</param>
        public static void CopyFile(string srcFileName, string desFileName)
        {
            if (File.Exists(desFileName))
            {
                File.Delete(desFileName);
            }
            File.Copy(srcFileName, desFileName, true);
        }

        /// <summary>
        /// 剪切文件
        /// </summary>
        /// <param name="srcFileName"></param>
        /// <param name="desFileName"></param>
        public static void MoveFile(string srcFileName, string desFileName)
        {
            if (File.Exists(srcFileName))
            {
                if (File.Exists(desFileName))
                {
                    File.Delete(desFileName);
                }
            }
            File.Move(srcFileName, desFileName);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="srcFileName"></param>
        public static void DeleteFile(string srcFileName)
        {
            if (File.Exists(srcFileName))
            {
                File.Delete(srcFileName);
            }
        }
        #endregion

        #region 文件夹操作

        /// <summary>
        /// 得到目录下所有文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        /// <summary>
        /// 获取文件夹下所有子文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetDirectoriesFiles(string path)
        {
            return Directory.GetDirectories(path);
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFile(string path)
        {
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// 删除指定文件夹下所有的子文件夹和文件
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFiles(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            directoryInfo.Delete(true);
        }
        #endregion
    }
}
