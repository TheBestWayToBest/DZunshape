using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Modle
{
    public class ItemInfo
    {
        /// <summary>
        /// 卷烟编码
        /// </summary>
        public string ItemNo { get; set; }

        /// <summary>
        /// 卷烟名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 件烟条码
        /// </summary>
        public string BigBox_Bar { get; set; }

        /// <summary>
        /// 卷烟类型
        /// </summary>
        public string Shiptype { get; set; }

        /// <summary>
        /// 卷烟状态
        /// </summary>
        public decimal RowStatus { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public decimal ILength { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public decimal IWidth { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public decimal IHeight { get; set; }

        /// <summary>
        /// 件条转化率
        /// </summary>
        public decimal JT_Size { get; set; }
    }
}
