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


        /// <summary>
        /// 烟仓任务发送
        /// </summary>
        /// <returns></returns>
        public static List<string> GetOnlyDBItem()
        {
            List<string> list = new List<string>();
            list.Add(OpcPresortServer + "DB1,DINT0");
            list.Add(OpcPresortServer + "DB1,DINT4");
            for (int i = 0; i <= 192; i += 2)
            {
                list.Add(OpcPresortServer + "DB1,W" + i + 8);//为烟柜内部皮带的条烟总数
            }
            list.Add(OpcPresortServer + "DB1,DINT204");//立式烟仓与卧式烟仓总条烟数
            list.Add(OpcPresortServer + "DB1,W208");
            list.Add(OpcPresortServer + "DB1,W210");
            return list;
        }

        /// <summary>
        /// 烟仓任务监控标志位
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSpyOnlyLineItem()
        {
            List<string> list = new List<string>();

            list.Add(OpcPresortServer + "DB1,W210");// 交互标志 0
            return list;
        }

        /// <summary>
        /// 烟仓任务结束回应
        /// </summary>
        /// <returns></returns>
        public static List<string> GetOnlyLineFinishTaskItem()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 10; i += 4)
            {
                list.Add(OpcPresortServer + "DB30,DINT" + i);
            }
            return list;
        }

        /// <summary>
        /// 卧式烟仓补货任务
        /// </summary>
        /// <returns></returns>
        public static List<string> GetRelenishplanItem()
        {
            List<string> list = new List<string>();
            list.Add(OpcPresortServer + "DB2.DINT0");
            list.Add(OpcPresortServer + "DB2.W4");
            list.Add(OpcPresortServer + "DB2.DINT6");
            list.Add(OpcPresortServer + "DB2.DINT10");
            list.Add(OpcPresortServer + "DB2.W14");
            list.Add(OpcPresortServer + "DB2.W16");
            return list;
        }

        /// <summary>
        /// 补货任务任务结束回应
        /// </summary>
        /// <returns></returns>
        public static List<string> GetReFinishTaskItem()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 10; i += 4)
            {
                list.Add(OpcPresortServer + "DB31,DINT" + i);
            }
            return list;
        }
        /// <summary>
        /// 补货任务监控标志位
        /// </summary>
        /// <returns></returns>
        public static List<string> GetReSpyOnlyLineItem()
        {
            List<string> list = new List<string>();

            list.Add(OpcPresortServer + "DB2.W16");// 交互标志 0
            return list;
        }

        public static List<string> GetScan() 
        {
            List<string> list = new List<string>() { "DB" };
            return list;
        }

    }
}
