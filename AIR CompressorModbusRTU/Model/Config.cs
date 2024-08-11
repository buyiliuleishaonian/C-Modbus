using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Config
    {
        /// <summary>
        /// 自动启动
        /// </summary>
        public bool AutoStart { get; set; }

        /// <summary>
        /// 自动登入
        /// </summary>
        public bool AutoLogin { get; set; }

        /// <summary>
        /// 自动锁屏
        /// </summary>
        public bool AutoLock { get; set; }

        /// <summary>
        /// 自动锁屏时间
        /// </summary>
        public int LockyPeriod { get; set; }

        /// <summary>
        /// 绘制曲线数
        /// </summary>
        public int SaveShowSeriesCount { get; set; }
    }
}
