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

using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using HighspeedNew.PubFun;
using Business.Modle;
using Business.BusinessClass;

namespace HighSpeed.OrderHandle
{
    public partial class w_Export : Form
    {
        Socket socketClient;
        public w_Export()
        {
            InitializeComponent();
            Bind();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            int count = this.orderdata.SelectedRows.Count;
            if (count > 0)
            {
                String synseq = this.orderdata.SelectedRows[0].Cells["synseq"].Value + "";
                // String exportnum = this.orderdata.SelectedRows[0].Cells["exportnum"].Value + "";
                //取页面参数

                export(synseq, "1", "2");

                // export(synseq,exportnum);
            }
            else
            {
                MessageBox.Show("请点击选择您要导出的数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Bind();
            orderdata.ClearSelection();
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
            //IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress address = IPAddress.Parse("10.75.142.1");
            IPEndPoint endpoint = new IPEndPoint(address, 9050);
            //创建服务端负责监听的套接字，参数（使用IPV4协议，使用流式连接，使用Tcp协议传输数据）
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketClient.Connect(endpoint);
        }

        private int sendFile(String filePath)
        {
            int i = SocketClientConnector.SendFile(socketClient, filePath, 102400, 1);
            Byte[] bytes = new Byte[1024];
            int len = socketClient.Receive(bytes);
            String result = Encoding.Default.GetString(bytes, 0, len);
            if (!"".Equals(result))
            {
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
            return i;
        }
        //多条打码机的数据可以写到一个文件上发送过去，不过每次发送的明细不能超过一万条
        private void export(string synseq, string groupno, string linetype)//lineno打码机编号
        {
            this.btn_export.Enabled = false;
            panel2.Visible = true;
            label2.Visible = true;
            progressBar1.Visible = true;
            label2.Text = "数据查询中，准备进行数据导出...";
            label2.Refresh();
            int taskseq = 0, seq = 1;
            String tasknum = "", cuscode = "", cusname = "", itemno = "", itemname = "", quantity = "", regioncode = "", orderdate = "", cuscodetmp = "";
            
            List<InfoExport> list = new List<InfoExport>();
            list = ExportClass.Export(Convert.ToDecimal(synseq));

            //取批次号
            //String batchcodesql = "select SEQ_ONEHAOGONGCHENG.Nextval from dual";

            int len = list.Count;

            
           String onesynseq = "0";//一号工程批次号


            //DataTable table = Db.Query(sql);
            //int len = table.Rows.Count;
            //String[] infostr = new String[len];

            if (len > 0)
            {
                InitSocket();
                //DataRow row = new DataRow();
                //创建到处目录
                String folder = "HighSpeedExportData";
                if (!Directory.Exists("D:\\" + folder))
                {
                    Directory.CreateDirectory("D:\\" + folder);
                }
                int count = 0, fileSeq = 1, rowCcount = 0, bz = 0, succCount = 0;
                String fileNameStr = ""; String info = "", tmpInfo = "", tempCode = "", unSuccFile = "";
                for (int i = 0; i < len; i++)
                {
                    progressBar1.Value = ((i + 1) * 100 / len);
                    progressBar1.Refresh();

                    InfoExport infos = new InfoExport();
                    infos = list[i];

                    tasknum = infos.SortNum.ToString();
                    cuscode = infos.CustomerCode.ToString();
                    cusname = infos.CustomerName.ToString();
                    itemno = infos.CigaretteCode.ToString();
                    itemname = infos.CigaretteName.ToString();
                    quantity = infos.PokeNum.ToString();
                    regioncode = infos.RegionCode.ToString();
                    orderdate = infos.Orderdate.ToString();
                    //lineno = row["SORTNAME"].ToString();
                    taskseq++;
                    rowCcount = rowCcount + 1;

                    label2.Text = "正在导出第" + fileSeq + "个文件...";
                    label2.Refresh();
                    //取下条记录比较车组与零售户
                    if (i + 1 < len)
                    {
                        cuscodetmp = list[i + 1].CustomerCode.ToString();
                        tempCode = list[i + 1].RegionCode.ToString();
                    }
                    else
                    {
                        cuscodetmp = "";
                        tempCode = "";
                    }
                    //infostr[i] = tasknum + taskseq + "," + tasknum + "," + cuscode + "," + cusname + "," + itemno + "," + itemname + "," + quantity + ",2," + seq + "," + regioncode + "," + regioncode + "," + orderdate + "," + orderdate + ",S1001,1";
                    tmpInfo = tmpInfo + tasknum + "," + tasknum + "," + cuscode + "," + cusname + "," + itemno + "," + itemname + "," + quantity + "," + onesynseq + "," + seq + "," + regioncode + "," + regioncode + "," + orderdate + "," + orderdate + ",1;\r\n";

                    if (cuscode != cuscodetmp)
                    {
                        taskseq = 0;
                        seq++;
                    }
                    //当下个车组与当前不同时
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
                            String filename = "RetailerOrder-" + time + "-" + synseq + "-" + fileSeq;
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
                            String filename = "RetailerOrder-" + time + "-" + synseq + "-" + fileSeq;
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

        List<ExportInfo> exportInfo;
        private void Bind()
        {
            try
            {
                exportInfo = new List<ExportInfo>();
                exportInfo = ExportClass.Getdata();

                this.orderdata.DataSource = exportInfo;
                this.orderdata.AutoGenerateColumns = false;

                //string columnwidths = pub.IniReadValue(this.Name, this.orderdata.Name);
                //if (columnwidths != "")
                //{
                //    string[] columns = columnwidths.Split(',');
                //    int j = 0;
                //    for (int i = 0; i < columns.Length; i++)
                //    {
                //        if (orderdata.Columns[i].Visible == true)
                //        {
                //            orderdata.Columns[j].Width = Convert.ToInt32(columns[i]);
                //            j = j + 1;
                //        }
                //    }
                //}
                orderdata.ClearSelection();

            }
            catch (Exception ex)
            {
                // throw ex;
            }
        }

        private void w_Export_Load(object sender, EventArgs e)
        {
            orderdata.ClearSelection();
        }
    }
}
