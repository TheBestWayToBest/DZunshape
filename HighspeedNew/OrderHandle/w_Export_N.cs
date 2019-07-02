using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Business.BusinessClass;

using System.Data.SqlClient;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using Business.Modle;
using HighspeedNew.PubFun;

namespace HighSpeedNew.OrderHandle
{
    public partial class w_Export_N : Form
    {
        Socket socketClient;
        List<TaskInfo> list;
        public w_Export_N()
        {
            InitializeComponent();
            Bind();
        }
        ScheduleClass sc = new ScheduleClass();
        void Bind()
        {
            //String strsql = "SELECT batchcode,sum(t.taskquantity) as qty,COUNT(*)as cuscount,t.synseq,count(distinct regioncode) as regioncodecount from t_produce_task t where t.state=15 group BY t.batchcode,t.synseq order by synseq ";
            //scre.Content.Select(x => new { synseq = x.SYNSEQ, regioncode = x.REGIONCODE, count = x.Count, qty = x.QTY }).ToList();
            var rm = sc.GetTaskInfoByBatchcode();
            list = rm.Content;
            if (rm.IsSuccess)
            {
                orderdata.DataSource = list.Select(x => new
                {
                    synseq = x.SYNSEQ,
                    linenum = x.LINENUM,
                    batchcode = x.BATCHODE,
                    qty = x.QTY,
                    count = x.Count
                }).ToList();
                    //OrderBy(x => new { x.synseq,x.linenum}).ToList();
            }
            else
            {
                MessageBox.Show(rm.MessageText);
                orderdata.DataSource = null;
            }

        }

        private void export(string synseq, string linenum, string lineno)//lineno打码机编号  linenum区分特异型烟和烟仓
        {
            this.btn_export.Enabled = false;
            panel2.Visible = true;
            label2.Visible = true;
            progressBar1.Visible = true;
            label2.Text = "数据查询中，准备进行数据导出...";
            label2.Refresh();
            int taskseq = 0, seq = 1;
            String tasknum = "", cuscode = "", cusname = "", itemno = "", itemname = "", quantity = "", regioncode = "", orderdate = "", cuscodetmp = "";
            
            //根据类型给打码机编号赋值
            if (linenum == "1") lineno = "DZ01";
            else lineno = "DZ02";

            //取数据
            var result = sc.Get1stPrjInfo(Convert.ToDecimal(synseq), linenum);
            List<_1stPrjInfo>list = result.Content.ToList();
            if (list.Any())
            {
                //取一号工程批次号
                Business.DZEntities en = new Business.DZEntities();
                String batchcodesql = "select S_PRODUCE_1STPRJINFO.Nextval from dual";
                string batchcode = en.ExecuteStoreQuery<decimal>(batchcodesql, null).FirstOrDefault().ToString();

                //创建通讯链接
                //InitSocket();
                //创建到处目录
                String folder = "HighSpeedExportData";
                if (!Directory.Exists("D:\\" + folder))
                {
                    Directory.CreateDirectory("D:\\" + folder);
                }
                int len = list.Count;
                int count = 0, fileSeq = 1, rowCcount = 0, bz = 0, succCount = 0;
                String fileNameStr = ""; String info = "", tmpInfo = "", tempCode = "", unSuccFile = "";
                //foreach (_1stPrjInfo info in list)
                for (int i = 0; i < len; i++)
                {

                    progressBar1.Value = ((i + 1) * 100 / len);
                    progressBar1.Refresh();

                    _1stPrjInfo prjInfo = list[i];
                    tasknum = prjInfo.sortNum.ToString();
                    cuscode = prjInfo.custCode;
                    cusname = prjInfo.custName;
                    itemno = prjInfo.cigCode;
                    itemname = prjInfo.cigName;
                    quantity = prjInfo.quantity.ToString();
                    regioncode = prjInfo.regionCode;
                    orderdate = prjInfo.orderDate;
                    //lineno = row["SORTNAME"].ToString();
                    //lineno = "1";
                    taskseq++;
                    rowCcount = rowCcount + 1;

                    label2.Text = "正在导出第" + fileSeq + "个文件...";
                    label2.Refresh();
                    //取下条记录比较车组与零售户
                    if (i + 1 < len)
                    {
                        prjInfo = list[i + 1];
                        cuscodetmp = prjInfo.custCode;
                        tempCode = prjInfo.regionCode;
                    }
                    else
                    {
                        cuscodetmp = "";
                        tempCode = "";
                    }
                    //infostr[i] = tasknum + taskseq + "," + tasknum + "," + cuscode + "," + cusname + "," + itemno + "," + itemname + "," + quantity + ",2," + seq + "," + regioncode + "," + regioncode + "," + orderdate + "," + orderdate + ",S1001,1";
                    tmpInfo = tmpInfo + tasknum + "," + tasknum + "," + cuscode + "," + cusname + "," + itemno + "," + itemname + "," + quantity + "," + batchcode + "," + seq + "," + regioncode + "," + regioncode + "," + orderdate + "," + orderdate + "," + lineno + ",1;\r\n";
                    if (cuscode != cuscodetmp)
                    {
                        taskseq = 0;
                        seq++;
                    }

                    if (!tempCode.Equals(regioncode))
                    {
                        //判断累计记录数是否大于10000，大于则将之前的记录数导出，否则将记录数合并
                        if (rowCcount + count > 1000000000)
                        {
                            label2.Text = "正在压缩第" + fileSeq + "个文件...";
                            label2.Refresh();
                            //将之前的记录信息导出
                            DateTime dt = DateTime.Now;
                            String time = string.Format("{0:yyyyMMddHHmmssfff}", dt);
                            String filename = "RetailerOrder-" + time + "-" + synseq + "-" + linenum + "-" + fileSeq;
                            fileNameStr = fileNameStr + "," + filename + ".zip";
                            StreamWriter sw = new StreamWriter("D:\\HighSpeedExportData\\" + filename + ".Order", false, Encoding.UTF8);
                            sw.WriteLine(info.Substring(0, info.Length - 1));
                            sw.Close();//写入
                            //CompressFile("D:\\" + filename + ".Order");
                            GetFileToZip("D:\\HighSpeedExportData\\" + filename + ".Order", "D:\\HighSpeedExportData\\" + filename + ".zip", filename + ".Order");
                            //发送数据
                            label2.Text = "正在发送第" + fileSeq + "个文件";
                            label2.Refresh();
                            bz = sendFile("D:\\HighSpeedExportData\\" + filename + ".zip");
                            //记录发送成功数量和失败文件信息
                            if (bz == 0)
                            {
                                succCount = succCount + 1;
                                label2.Text = "第" + fileSeq + "个文件发送完毕!";
                            }
                            else
                            {
                                unSuccFile = unSuccFile + "," + filename + ".zip";
                                label2.Text = "第" + fileSeq + "个文件发送失败!";
                            }

                            label2.Refresh();
                            //记录新车组的信息
                            fileSeq = fileSeq + 1;
                            count = rowCcount;
                            info = tmpInfo;
                        }
                        else
                        {
                            count = rowCcount + count;
                            info = info + tmpInfo;
                        }

                        //判断循环是否完成（是否为最后一条记录）,如果是最后一条，则将剩余记录导出
                        if ("".Equals(tempCode))
                        {
                            //fileSeq = fileSeq + 1;
                            label2.Text = "正在压缩第" + fileSeq + "个文件";
                            label2.Refresh();
                            DateTime dt = DateTime.Now;
                            String time = string.Format("{0:yyyyMMddHHmmssfff}", dt);
                            String filename = "RetailerOrder-" + time + "-" + synseq + "-" + linenum + "-" + fileSeq;
                            fileNameStr = fileNameStr + "," + filename + ".zip";
                            StreamWriter sw = new StreamWriter("D:\\HighSpeedExportData\\" + filename + ".Order", false, Encoding.UTF8);
                            sw.WriteLine(info.Substring(0, info.Length - 1));
                            sw.Close();//写入
                            //CompressFile("D:\\" + filename + ".Order");
                            GetFileToZip("D:\\HighSpeedExportData\\" + filename + ".Order", "D:\\HighSpeedExportData\\" + filename + ".zip", filename + ".Order");
                            //发送数据
                            //sendFile("D:\\HighSpeedExportData\\" + filename + ".zip");
                            label2.Text = "正在发送第" + fileSeq + "个文件";
                            label2.Refresh();
                            bz = sendFile("D:\\HighSpeedExportData\\" + filename + ".zip");
                            //记录发送成功数量和失败文件信息
                            if (bz == 0)
                            {
                                succCount = succCount + 1;
                                label2.Text = "第" + fileSeq + "个文件发送完毕!";
                            }
                            else
                            {
                                unSuccFile = unSuccFile + "," + filename + ".zip";
                                label2.Text = "第" + fileSeq + "个文件发送失败!";
                            }

                            label2.Refresh();
                        }
                        tmpInfo = "";
                        rowCcount = 0;
                    }
                }
                //在弹窗前关闭控件
                panel2.Visible = false;
                label2.Visible = false;
                progressBar1.Visible = false;

                String msg = "成功导出" + fileSeq + "个文件，成功发送" + succCount + "个文件！";
                //导出的文件的所有文件名
                if (!"".Equals(fileNameStr)) fileNameStr = fileNameStr.Substring(1);
                //发送失败的所有文件名
                if (!"".Equals(unSuccFile))
                {
                    unSuccFile = unSuccFile.Substring(1);
                    msg = msg + "其中发送失败文件为(" + unSuccFile + ")！";
                }
                else
                {
                    msg = msg + "文件名为(" + fileNameStr + ")！";
                }

                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                socketClient.Disconnect(false);
                socketClient.Close();
            }
            this.btn_export.Enabled = true;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            int count = this.orderdata.SelectedRows.Count;
            if (count > 0)
            {
                String synseq = this.orderdata.SelectedRows[0].Cells["synseq"].Value + "";
                String linenum = this.orderdata.SelectedRows[0].Cells["linenum"].Value + "";
                export(synseq,linenum, "01");
            }
            else
            {
                MessageBox.Show("请点击选择您要导出的数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void GetFileToZip(string filepath, string zippath, String entryname)
        {

            FileStream fs = File.OpenRead(filepath);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();

            FileStream ZipFile = File.Create(zippath);
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            ZipEntry ZipEntry = new ZipEntry(entryname);
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(6);

            ZipStream.Write(buffer, 0, buffer.Length);
            ZipStream.Finish();
            ZipStream.Close();
        }

        public static void CompressFile(string path)
        {

            FileStream sourceFile = File.OpenRead(path);

            //String newfile = path.Substring(0, path.Length - 6);
            FileStream destinationFile = File.Create(path + ".zip");

            byte[] buffer = new byte[sourceFile.Length];

            sourceFile.Read(buffer, 0, buffer.Length);

            using (GZipStream output = new GZipStream(destinationFile,

                CompressionMode.Compress))
            {

                Console.WriteLine("Compressing {0} to {1}.", sourceFile.Name,

                    destinationFile.Name, false);

                output.Write(buffer, 0, buffer.Length);

            }

            // Close the files.

            sourceFile.Close();

            destinationFile.Close();

            String[] destination = path.Split('.');
            //MessageBox.Show(destination[0] + ".zip");
            File.Move(path + ".zip", destination[0] + ".zip");

        }

        private void InitSocket()
        {
            //IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());10.75.142.1
            IPAddress address = IPAddress.Parse("127.0.0.1");
            IPEndPoint endpoint = new IPEndPoint(address, 9050);
            //创建服务端负责监听的套接字，参数（使用IPV4协议，使用流式连接，使用Tcp协议传输数据）
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketClient.Connect(endpoint);
        }

        private int sendFile(String filePath)
        {
            int i = SocketClientConnector.SendFile(socketClient, filePath, 102400, 1);
            //if (i == 0) MessageBox.Show("文件  " + filePath + "  发送失败!");
            Byte[] bytes = new Byte[1024];
            int len = socketClient.Receive(bytes);
            //String result=System.Text.UTF8Encoding.UTF8.GetString(bytes);
            String result = Encoding.Default.GetString(bytes, 0, len);
            if (!"".Equals(result))
            {
                //result = result.Substring(8, result.Length-1);
                String[] msg = System.Text.RegularExpressions.Regex.Split(result, "\\r\\n");

                if (msg.Length == 2)
                {
                    MessageBox.Show("文件解析成功！");
                    i = 0;
                }
                else
                {
                    MessageBox.Show("文件解析失败！错误信息：" + msg[1]);
                    i = -1;
                }
            }
            //socketClient.Disconnect(false);
            //socketClient.Close();
            return i;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            orderdata.ClearSelection();
        }

        private void orderdata_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (list[e.RowIndex].LINENUM == "1")
                {
                    e.Value = "烟仓";
                }
                else
                {
                    e.Value = "特异型烟";
                }
            }
        }
    }
}
