using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;
using Tool;
using System.Linq.Expressions;


namespace Business.BusinessClass
{
    public class UnPokeClass
    {
        /// <summary>
        /// 异形烟烟柜烟仓特异形烟数据
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="outlist">接收完成任务集合</param>
        /// <param name="outStr">任务日志字符串</param>
        /// <returns></returns>
        public static object[] GetOneDateBaseTask(decimal status, string linenum, out StringBuilder outStr)
        {
            object[] values = new object[104];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = 0;
            }
            StringBuilder sb = new StringBuilder();
            using (DZEntities en = new DZEntities())
            {
                List<T_UN_POKE> list = new List<T_UN_POKE>();
                
                decimal ts = en.T_PRODUCE_SORTTROUGH.Where(item => item.GROUPNO == 1 && item.CIGARETTETYPE == 40).Select(item => item.MACHINESEQ ?? 0).FirstOrDefault();
                
                var query = en.T_UN_POKE.Where(item => item.LINENUM == linenum).OrderBy(item => item.SORTNUM).FirstOrDefault();
                if (query == null)
                {
                    outStr = null;
                    return values;
                }
                list = en.T_UN_POKE.Where(item => item.SORTNUM == query.SORTNUM && item.STATUS == status && item.MACHINESEQ != ts).OrderBy(item => item.SORTNUM).ToList();

                //混合道+++

                values[0] = query.SORTNUM;
                values[1] = query.SENDTASKNUM;
                sb.AppendLine("任务号：" + query.SORTNUM);
                decimal machineseq = 0;
                foreach (var item in list.Where(ite => ite.CTYPE == 2).GroupBy(item => item.MACHINESEQ).Select(item => new { MACHINESEQ = item.Key, QTY = item.Sum(x => x.POKENUM) }).OrderBy(ite => ite.MACHINESEQ).ToList())
                {
                    if (machineseq != ts)
                    {
                        machineseq = item.MACHINESEQ??0;
                        values[(int)machineseq + 1] = item.QTY;
                        sb.AppendLine(linenum + "线 " + machineseq + " 号烟仓，出烟数量：" + item.QTY);
                    }
                }
                foreach (var item in list.Where(ite => ite.CTYPE == 3).GroupBy(item => item.MACHINESEQ).Select(item => new { MACHINESEQ = item.Key, QTY = item.Sum(x => x.POKENUM) }).OrderBy(ite => ite.MACHINESEQ).ToList())
                {
                    if (machineseq != ts)
                    {
                        machineseq = item.MACHINESEQ ?? 0;
                        values[(int)machineseq + 1 + 90] = item.QTY;
                        sb.AppendLine(linenum + "线 " + machineseq + " 号烟仓，出烟数量：" + item.QTY);
                    }
                }
                values[98] = list.Where(item => item.CTYPE == 2 && item.MACHINESEQ > 30 && item.MACHINESEQ < 91).Sum(item => item.POKENUM);
                values[99] = list.Where(item => item.CTYPE == 3).Sum(item => item.POKENUM);
                values[100] = list.Where(item => item.CTYPE == 2 && item.MACHINESEQ > 0 && item.MACHINESEQ < 31).Sum(item => item.POKENUM);

                values[101] = 0;
                values[102] = 0;
                values[103] = 1;
                sb.AppendLine("2#立式烟仓总条数：" + values[98] + "卧式烟仓总条数：" + values[99] + "1#立式烟仓总条数：" + values[100] + "，任务发送标志位：" + values[103]);
                outStr = sb;
                return values;
            }
        }
        public static int UpdateTask(decimal packageNo, int status)
        {
            using (DZEntities data = new DZEntities())
            {
                long sendSeq = DateTime.Now.Ticks;
                List<T_UN_POKE> list = new List<T_UN_POKE>();
                list = data.T_UN_POKE.Where(item => item.SORTNUM == packageNo).ToList();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        item.STATUS = status;
                        item.SENDSEQ = sendSeq;
                    }
                }
                int row = data.SaveChanges();
                return row;
            }
        }

        public static void UpdateunTask(decimal sortnum, int status)
        {
            using (DZEntities en = new DZEntities())
            {
                var poke = en.T_UN_POKE.Where(item => item.SORTNUM == sortnum).ToList();
                foreach (var item in poke)
                {
                    if (item.STATUS == 15)
                    {
                        item.STATUS = status;
                    }
                }

                var taskFirst = poke.FirstOrDefault();
                if (taskFirst != null)
                {
                    var pokestate = en.T_UN_POKE.Where(item => item.TASKNUM == taskFirst.TASKNUM && (item.STATUS == 15 || item.STATUS == 10)).ToList();
                    if (pokestate.Count == 0)
                    {
                        var task = en.T_UN_TASK.Where(item => item.TASKNUM == taskFirst.TASKNUM).ToList();
                        foreach (var item in task)
                        {
                            if (item.STATE == "15")
                            {
                                item.STATE = "30";
                                item.FINISHTIME = DateTime.Now;
                            }
                        }
                    }
                }
                en.SaveChanges();
            }
        }

        public static List<TaskDetail> GetDataAll(int pageNum, out int sumCount, int sortNum = 0, string regionCode = "0", string cusCode = "0")
        {
            //ORA-00904: "Extent1"."CLEARTHRESHOLD": 标识符无效

            //Response re = new Response();
            using (DZEntities en = new DZEntities())
            {
                //Expression<Func<T_UN_TASK, bool>> exSortNum = PredicateExtensions.True<T_UN_TASK>();
                //Expression<Func<T_UN_TASK, bool>> exCode = PredicateExtensions.True<T_UN_TASK>();
                //Expression<Func<T_UN_TASK, bool>> exCusCode = PredicateExtensions.True<T_UN_TASK>();
                Func<TaskDetail, bool> exSortNum;
                Func<TaskDetail, bool> exCode;
                Func<TaskDetail, bool> exCusCode;
                if (sortNum != 0)
                {
                    exSortNum = item => item.SortNum.ToString().Contains(sortNum.ToString());
                }
                else
                {
                    exSortNum = item => true;
                }
                if (regionCode != "0" && regionCode != "")
                {
                    exCode = item => item.RegionCode.Contains(regionCode);
                }
                else
                {
                    exCode = item => true;
                }
                if (cusCode != "0" && cusCode != "")
                {
                    exCusCode = item => item.CusCode.Contains(cusCode);
                }
                else
                {
                    exCusCode = item => true;
                }
                #region
                //var data = en.T_UN_TASK.Where(exSortNum.Compile()).Where(exCode.Compile()).Where(exCusCode.Compile()).ToList();
                //var data = en.T_UN_TASK.Where(exSortNum).Where(exCode).Where(exCusCode).Join(en.T_UN_POKE, task => task.TASKNUM, poke => poke.TASKNUM,
                //        (task, poke) => new TaskDetail
                //        {
                //            SortSeq = task.SORTSEQ,
                //            SortNum = poke.SORTNUM,
                //            RegionCode = task.REGIONCODE,
                //            CusName = task.CUSTOMERNAME,
                //            CigCode = poke.CIGARETTECODE,
                //            Status = poke.STATUS,
                //            ThroughNum = poke.TROUGHNUM,
                //            BillCode = task.BILLCODE,
                //            CigName = ""
                //        });
                //var detail = data.Join(en.T_PRODUCE_SORTTROUGH, task => task.ThroughNum, through => through.TROUGHNUM,
                //  (task, through) => new TaskDetail
                //  {
                //      //SortSeq = task.SORTSEQ,
                //      //SortNum = task.SORTNUM,
                //      //RegionCode = task.REGIONCODE,
                //      //CusName = task.CUSTOMERNAME,
                //      //CigCode = task.CIGARETTECODE,
                //      //Status = task.STATUS,
                //      //ThroughNum = task.TROUGHNUM,
                //      //BillCode = task.BILLCODE,
                //      //CigName = through.CIGARETTENAME
                //      SortSeq = task.SortSeq,
                //      SortNum = task.SortNum,
                //      RegionCode = task.RegionCode,
                //      CusName = task.CusName,
                //      CigCode = task.CigCode,
                //      Status = task.Status,
                //      ThroughNum = task.ThroughNum,
                //      BillCode = task.BillCode,
                //      CigName = through.CIGARETTENAME
                //  })/*.OrderBy(item => item.SortNum).Skip(pageNum * 50).Take(50)*/.ToList();
                #endregion

                int count = (from poke in en.T_UN_POKE
                             join task in en.T_UN_TASK on poke.TASKNUM equals task.TASKNUM
                             join through in en.T_PRODUCE_SORTTROUGH on poke.TROUGHNUM equals through.TROUGHNUM
                             select new TaskDetail
                             {
                                 SortSeq = task.SORTSEQ,
                                 SortNum = poke.SORTNUM,
                                 RegionCode = task.REGIONCODE,
                                 CusName = task.CUSTOMERNAME,
                                 CigCode = poke.CIGARETTECODE,
                                 Status = poke.STATUS,
                                 ThroughNum = poke.TROUGHNUM,
                                 BillCode = task.BILLCODE,
                                 CigName = through.CIGARETTENAME,
                                 Num = poke.POKENUM ?? 0,
                                 CusCode = poke.CUSTOMERCODE
                             }).Where(exSortNum).Where(exCode).Where(exCusCode).OrderBy(item => item.SortNum).Count();
                var data = (from poke in en.T_UN_POKE
                            join task in en.T_UN_TASK on poke.TASKNUM equals task.TASKNUM
                            join through in en.T_PRODUCE_SORTTROUGH on poke.TROUGHNUM equals through.TROUGHNUM
                            select new TaskDetail
                            {
                                SortSeq = task.SORTSEQ,
                                SortNum = poke.SORTNUM,
                                RegionCode = task.REGIONCODE,
                                CusName = task.CUSTOMERNAME,
                                CigCode = poke.CIGARETTECODE,
                                Status = poke.STATUS,
                                ThroughNum = poke.TROUGHNUM,
                                BillCode = task.BILLCODE,
                                CigName = through.CIGARETTENAME,
                                Num = poke.POKENUM ?? 0,
                                CusCode = poke.CUSTOMERCODE
                            }).Where(exSortNum).Where(exCode).Where(exCusCode).OrderBy(item => item.SortNum).OrderBy(item => item.SortSeq).Skip((pageNum - 1) * 50).Take(50).ToList();
                sumCount = count;
                return data;
            }
        }

        /// <summary>
        /// 更新任务(任务号区间查询) 
        /// </summary>
        /// <param name="startNum">起始任务号</param>
        /// <param name="endNum">结束任务号</param>
        /// <param name="status"></param>
        public static int UpdateTask(decimal startNum, decimal endNum, decimal status)
        {
            using (DZEntities en = new DZEntities())
            {
                var query = en.T_UN_POKE.Where(item => item.SORTNUM >= startNum && item.SORTNUM <= endNum).ToList();
                foreach (var item in query)
                {
                    item.STATUS = status;
                }
                var queryTask = en.T_UN_TASK.Where(item => item.SORTNUM >= startNum && item.SORTNUM <= endNum).ToList();
                foreach (var item in queryTask)
                {
                    if (status == 20)
                    {
                        item.STATE = "30";
                        item.FINISHTIME = DateTime.Now;
                    }
                    else
                    {
                        item.STATE = "15";
                    }
                }
                int rowNum = en.SaveChanges();
                return rowNum;
            }
        }
        public static List<TaskInfo> GetUNCustomer()
        {
            using (DZEntities en = new DZEntities())
            {
                var query = en.T_UN_TASK.GroupBy(item => new { item.REGIONCODE, item.ORDERDATE, item.SYNSEQ }).Select(item => new TaskInfo
                {
                    REGIONCODE = item.Key.REGIONCODE,
                    ORDERDATE = item.Key.ORDERDATE,
                    SYNSEQ = item.Key.SYNSEQ ?? 0,
                    FinishCount = 0,
                    FinishQTY = 0,
                    QTY = item.Sum(x => x.TASKQUANTITY) ?? 0,
                    Count = item.Count(t => t.REGIONCODE == item.Key.REGIONCODE)
                }).ToList();
                var query2 = en.T_UN_TASK.Where(item => item.STATE == "30").GroupBy(item => item.REGIONCODE).Select(item => new TaskInfo { REGIONCODE = item.Key, FinishCount = item.Count(x => x.REGIONCODE == item.Key), FinishQTY = item.Sum(x => x.TASKQUANTITY) ?? 0 }).ToList();
                if (query2.Count > 0)
                {
                    foreach (var item in query2)
                    {
                        var data = query.Find(x => x.REGIONCODE == item.REGIONCODE);
                        data.FinishCount = item.FinishCount;
                        data.FinishQTY = item.FinishQTY;
                    }
                }
                if (query.Count > 0)
                {
                    foreach (var item in query)
                    {
                        item.Rate = Math.Round((item.FinishCount / item.Count), 2).ToString("P"); /*+ "%"*/;
                    }
                }
                return query;
            }
        }

        /// <summary>
        /// 校验特异形烟是否录入长宽
        /// </summary>
        /// <returns></returns>
        public static string GetNullLWSomke()
        {
            string needInfo = null;
            using (DZEntities data = new DZEntities())
            {
                var jydate = (from item in data.T_UN_POKE select item).ToList();
                if (jydate == null || jydate.Count == 0)
                {
                    return "当前没有数据";
                }
                var query = (from item in data.T_WMS_ITEM
                             join trough in data.T_PRODUCE_SORTTROUGH on item.ITEMNO equals trough.CIGARETTECODE
                             join task in data.T_UN_TASKLINE on trough.CIGARETTECODE equals task.CIGARETTECODE
                             where (trough.CIGARETTETYPE == 30 || trough.CIGARETTETYPE == 40) && trough.TROUGHTYPE == 10 && ((item.ILENGTH == null || item.IWIDTH == null) || (item.ILENGTH == 0 || item.IWIDTH == 0))
                             group item by new { trough.CIGARETTECODE, trough.CIGARETTENAME } into g
                             select g).ToList();
                if (query == null || query.Count == 0)
                {
                    return "校验无误！";
                }
                else
                {
                    foreach (var item in query)
                    {
                        needInfo += item.Key.CIGARETTECODE + "|" + item.Key.CIGARETTENAME + "，";
                    }
                    return needInfo + "这些品牌没有录入长宽！请在分拣前录入!!";
                }

            }
        }
    }
}
