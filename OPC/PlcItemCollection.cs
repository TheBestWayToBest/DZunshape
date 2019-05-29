using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpcRcw.Da;
using OpcRcw.Comn;

namespace OPC
{
    public static class PlcItemCollection
    {
        public static String OpcPresortServer = "S7:[UnnormalConnection]";

        public static List<string> GetOnlyDBItem()
        {
            List<string> list = new List<string>();
            list.Add(OpcPresortServer + "DB1,DINT0");
            list.Add(OpcPresortServer + "DB1,DINT4");
            for (int i = 0; i <= 96; i+=2)
            {
                list.Add(OpcPresortServer + "DB1,W" + i + 8);//为烟柜内部皮带的条烟总数
            }
            list.Add(OpcPresortServer + "DB1,DINT204");
            list.Add(OpcPresortServer + "DB1,W208");
            list.Add(OpcPresortServer + "DB1,W210");
            return list;
        }

        /// <summary>
        /// 监控标志位
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSpyOnlyLineItem()
        {
            List<string> list = new List<string>();

            list.Add(OpcPresortServer + "DB1,W210");// 交互标志 0
            return list;
        }

        /// <summary>
        /// 任务结束回应
        /// </summary>
        /// <returns></returns>
        public static List<string> GetOnlyLineFinishTaskItem()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(OpcPresortServer + "DB30,DINT" + i);
            }
            return list;
        }
    }
}
