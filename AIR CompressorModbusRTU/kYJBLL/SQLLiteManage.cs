using KYJDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;

namespace kYJBLL
{
    public class SQLLiteManage
    {
        private SQLLiteServer SQLLiteServer { get; set; }=new SQLLiteServer();

        /// <summary>
        /// 给定Sqllite的链接地址
        /// </summary>
        /// <param name="path"></param>
        public void ConnStr(string path)
        {
            SQLLiteServer.ConnStr(path);
        }

        /// <summary>
        /// 查询表是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool IsTableExist(string tableName)
        { 
            return SQLLiteServer.IsTabelExist(tableName);
        }

        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool DeleteTable(string tableName)
        {
            return SQLLiteServer.DeleteTable(tableName);
        }

        /// <summary>
        /// 清空表数据
        /// </summary>
        /// <returns></returns>
        public bool VacuumTable()
        {
            return SQLLiteServer.VacuumTable();
        }

        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        /// <param name="isPrimaryKey"></param>
        /// <returns></returns>
        public bool CreateTable(string tableName,List<string> columns,bool isPrimaryKey = true)
        {
            return SQLLiteServer.CreateTable(tableName,columns);
        }

        /// <summary>
        /// 初始化数据表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        /// <param name="isPrimaryKey"></param>
        /// <returns></returns>
        public OperateResult ReCreateActualTable(string tableName, List<string> columns)
        {
            if (IsTableExist(tableName))
            {
                if (!DeleteTable(tableName))
                {
                    return OperateResult.CreateFailResult("删除表失败");
                }
            }

            if (!CreateTable(tableName, columns))
            {
                return OperateResult.CreateFailResult("创建表失败");
            }

            VacuumTable();

            return OperateResult.CreateSuccessResult();
        }
    }
}
