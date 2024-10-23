using AIR_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIR_BLL
{
    /// <summary>
    /// 当前数据库数据库查找
    /// </summary>
    public class DataManage
    {
        private DataService DataService { get; set; }=new DataService();

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="varname"></param>
        /// <returns></returns>
        public DataTable SelectData(string start,string end,List<string> varname)
        {
            return DataService.SelectData(varname,start,end); ;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varname"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddData(List<string> varname, List<string> value,string date)
        {
            return DataService.AddData(varname,value,date) ;
        }
    }
}
