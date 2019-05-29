using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpcRcw.Da;
using Tool;
using System.Threading.Tasks;

namespace OPC
{
    public class OPCServer
    {
        internal const string SERVER_NAME = "OPC.SimaticNET";       // local server name

        internal const string GROUP_NAME = "grp1";                  // Group name
        internal const int LOCALE_ID = 0x409;                       // LOCALE FOR ENGLISH.

        bool connectState = false;

        public bool ConnectState { get { return connectState; } set { connectState = value; } }
        bool isSendOne = false;

        public bool IsSendOn { get { return isSendOne; } set { isSendOne = value; } }


        /// <summary>
        /// opcserver对象
        /// </summary>
        IOPCServer pIOPCServer;

        /// <summary>
        /// 任务交互区
        /// </summary>
        PlcGroup onlyTaskGroup;
        /// <summary>
        /// 标志位监控
        /// </summary>
        PlcGroup spyBiaozhiGroup;
        /// <summary>
        /// 完成信号交互区
        /// </summary>
        PlcGroup finishOnlyGroup;
        /// <summary>
        /// 包装机
        /// </summary>
        PlcGroup PackageMachineGroup;
        public IOPCServer PIOPCServer { get { return pIOPCServer; } set { pIOPCServer = value; } }
        public PlcGroup OnlyTaskGroup { get { return onlyTaskGroup; } set { onlyTaskGroup = value; } }
        public PlcGroup SpyBiaozhiGroup { get { return spyBiaozhiGroup; } set { spyBiaozhiGroup = value; } }
        public PlcGroup FinishOnlyGroup { get { return finishOnlyGroup; } set { finishOnlyGroup = value; } }


        public string[] Connection()
        {
            string[] strmessage = new string[2];
            Type svrComponenttyp;
            //Guid iidRequiredInterface = typeof(IOPCItemMgt).GUID;

            try
            {
                svrComponenttyp = Type.GetTypeFromProgID(SERVER_NAME);
                // Connect to the local server.
                pIOPCServer = (IOPCServer)Activator.CreateInstance(svrComponenttyp);            //创建服务器连接对象
            }
            catch (ArgumentNullException)
            {
                strmessage[0] = "服务器对象创建失败,未能建立异型烟链板机plc连接，请检查plc连接与opc服务是否正常";
                strmessage[1] = "0";
                return strmessage;
            }
            catch(Exception ex)
            {
                strmessage[0]+=ex;
                strmessage[1] = "0";
                return strmessage;
            }


            onlyTaskGroup = new PlcGroup(pIOPCServer, 1, "group1", 1, LOCALE_ID);// 任务交互区
            finishOnlyGroup = new PlcGroup(pIOPCServer, 5, "group5", 1, LOCALE_ID);// 完成信号
            spyBiaozhiGroup = new PlcGroup(pIOPCServer, 9, "group9", 1, LOCALE_ID);//监控标志位 

            onlyTaskGroup.addItem(PlcItemCollection.GetOnlyDBItem());//任务交互区
            spyBiaozhiGroup.addItem(PlcItemCollection.GetSpyOnlyLineItem());//监控任务标识位
            finishOnlyGroup.addItem(PlcItemCollection.GetOnlyLineFinishTaskItem());//完成信号交互区;

            strmessage[0] += "";//写入校验plc连接尝试结果
            strmessage[1] = "1";
            return strmessage;
        }


        /// <summary>
        /// 检验opc连接  
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            //包装机异型烟链板机（合包）plc连接状态
            int flag1 = SpyBiaozhiGroup.ReadD(0).CastTo<int>(-1);//读取标志
            if (flag1 == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 写入异型烟链板机（合包）任务发送区DB块的内容
        /// </summary>
        /// <returns></returns>
        public StringBuilder SendOnlyTask()
        {
            StringBuilder sb = new StringBuilder();
            isSendOne = true;
            int flag = SpyBiaozhiGroup.ReadD(0).CastTo<int>(-1);
            WriteLog.GetLog().Write("烟仓烟柜发送数据前读标志位：" + flag + flag);
            if (flag == 0)
            {
                string OutStr = "";
                object[] datas = new object[50];//= UnPokeService.getAllLineTask(10, out listOnly, out OutStr);//获取可发送任务
                if (int.Parse(datas[0].ToString()) == 0)
                {
                    //updateListBox("烟仓烟柜分拣数据发送完毕");
                    sb.Append("烟仓烟柜分拣数据发送完毕");
                    return sb;
                }
                WriteLog.GetLog().Write("烟仓烟柜分拣线:" + OutStr);
                //updateListBox("烟仓烟柜分拣线:" + OutStr);
                sb.Append("烟仓烟柜分拣线:" + OutStr);
                OnlyTaskGroup.SyncWrite(datas);
            }
            isSendOne = false;
            return sb;
        }
    }
}
