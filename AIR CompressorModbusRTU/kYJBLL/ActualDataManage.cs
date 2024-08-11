using KYJDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kYJBLL
{
    /// <summary>
    /// 数据逻辑
    /// </summary>
    public class ActualDataManage
    {
        private ActualDataServer ActualDataServer=new ActualDataServer();

        /// <summary>
        /// 数据添加
        /// </summary>
        /// <param name="varName">数据列名</param>
        /// <param name="varValue">数据</param>
        /// <returns></returns>
        public int AddActualData(List<string> varName,List<string> varValue)
        {
            return ActualDataServer.AddActualData(varName, varValue);
        }

        /// <summary>
        /// 按照时间和参数，查询历史信息
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="varname"></param>
        /// <returns></returns>
        public DataTable SelectHistoryData(string start,string end,List<string> varName)
        {
            return ActualDataServer.SelectHistoryData(start,end,varName);
        }

        /// <summary>
        /// 根据要求查询数据表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="condition">要求</param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable QueryDataCondition(string start,string end,List<string> condition,string tableName)
        {
            return ActualDataServer.QueryDataValue(start,end,condition,tableName);
        }
    }
}
