using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Modle
{
   public class MainOrder
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int RowNum { get; set; }
       /// <summary>
        /// 车组信息
        /// </summary>
        public string RegionCode { get; set; }
       /// <summary>
       /// 订单户数
       /// </summary>
       public decimal OrderCount { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
       public decimal OrderNum { get; set; }
    }
}
