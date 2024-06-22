using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper
{
    /// <summary>
    /// ByteArray工具类。一般用于报文拼接
    /// </summary>
    public class ByteArray
    {
        //初始化，建立一个List<byte>的字段
        private List<byte>  list=new List<byte>();

        //通过这个类的一个属性得到在这个类建立的List<byte>集合
        /// <summary>
        /// List<byre>属性
        /// </summary>
        public List<byte> List
        {
            get { return list; }
        }


        //通过这个类的一个属性得到一个byte[]集合
        /// <summary>
        /// byte[]集合属性
        /// </summary>
       public byte[] Byte
        {
            get { return list.ToArray(); }
        }

        //通过这个类的一个属性得到List属性的长度
        /// <summary>
        /// 得到这个类的长度
        /// </summary>
        public int Length
        {
            get { return list.Count; }
        }

        //方法，每次添加一个byte字节
        /// <summary>
        /// 添加一个byte字节的方法
        /// </summary>
        /// <param name="buffer"></param>
        public void Add(byte buffer)
        { 
            list.Add(buffer);
        }

        //添加一个byte[]数组
        /// <summary>
        /// 添加一个Byte[]数组的方法
        /// </summary>
        /// <param name="buffer"></param>
        public void Add(byte[] buffer)
        {
            list.AddRange(buffer);
        }

        //添加一个List<byte>集合
        /// <summary>
        /// 添加一个List<byte>的方法
        /// </summary>
        /// <param name="ls"></param>
        public void Add(List<byte>  ls)
        {
            list.AddRange(ls);
        }

        //连续添加两个字节，直到添加到5个字节
        /// <summary>
        /// 添加两个个byte字节的方法
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public void Add(byte item1,byte item2)
        {
            Add(new byte[] { item1, item2 });
        }
        /// <summary>
        /// 添加三个byte字节的方法
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public void Add(byte item1, byte item2, byte item3)
        {
            Add(new byte[] { item1, item2, item3});
        }
        /// <summary>
        /// 添加四个byte字节的方法
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public void Add(byte item1, byte item2, byte item3, byte item4)
        {
            Add(new byte[] { item1, item2, item3, item4});
        }

        /// <summary>
        /// 添加五个byte字节的方法
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        public void Add(byte item1, byte item2, byte item3, byte item4, byte item5)
        {
            Add(new byte[] {item1,item2,item3,item4,item5 });
        }

        //添加本类的对象
        /// <summary>
        /// 添加类本身
        /// </summary>
        /// <param name="ba"></param>
        public void Add(ByteArray ba)
        {
            list.AddRange(ba.List);
        }

        //添加short类型
        /// <summary>
        /// 添加short类型
        /// </summary>
        /// <param name="sr"></param>
        public void Add(short sr)
        {
            list.Add((byte)(sr>>8));
            list.Add((byte)(sr));
        }

        //添加ushort类型
        /// <summary>
        /// 添加UShort类型
        /// </summary>
        /// <param name="usr"></param>
        public void Add(ushort usr)
        {
            list.Add((byte)(usr>>8));
            list.Add((byte)usr);
        }
    }
}
