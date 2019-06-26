using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Modle
{
    public class TaskDetail
    {
        /// <summary>
        /// 户序
        /// </summary>
        public decimal? SortSeq { get; set; }
        /// <summary>
        /// 分拣任务号
        /// </summary>
        public decimal? SortNum { get; set; }
        /// <summary>
        /// 车组号
        /// </summary>
        public string RegionCode { get; set; }
        /// <summary>
        /// 卷烟编号
        /// </summary>
        public string CigCode { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CusName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public decimal? Status { get; set; }
        /// <summary>
        /// 通道号
        /// </summary>
        public string ThroughNum { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string BillCode { get; set; }
        /// <summary>
        /// 卷烟名称
        /// </summary>
        public string CigName { get; set; }
        /// <summary>
        /// 抓烟数量
        /// </summary>
        public decimal Num { get; set; }

        public string CusCode { get; set; }
    }
}
