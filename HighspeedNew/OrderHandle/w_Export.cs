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

namespace HighSpeed.OrderHandle
{
    public partial class w_Export : Form
    {
        public w_Export()
        {
            InitializeComponent();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {

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
    }
}
