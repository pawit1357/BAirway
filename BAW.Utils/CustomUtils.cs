using System;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using System.Drawing;
using ICSharpCode.SharpZipLib.Zip;

namespace BAW.Utils
{
    public class CustomUtils
    {
        public String ftpServerIP { get; set; }
        public String ftpUserID { get; set; }
        public String ftpPassword { get; set; }
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(CustomUtils));
        public Boolean Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(
                      "ftp://" + ftpServerIP + "/" + fileInf.Name));

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(ftpUserID,
                                                       ftpPassword);

            // By default KeepAlive is true, where the control connection is 
            // not closed after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read 
            //the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the 
                    // FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
                //MessageBox.Show(ex.Message, "Upload Error");
                return false;
            }
            return true;
        }

        public static byte[] getByteImage(String img)
        {

            String path = AppDomain.CurrentDomain.BaseDirectory;
            FileStream fs = new FileStream(path + "\\" + img, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            int length = (int)br.BaseStream.Length;
            byte[] m_byte = new byte[length];
            m_byte = br.ReadBytes(length);
            br.Close();
            fs.Close();
            return m_byte;

        }

        public static String convertYYYYMMDD_DDMMYYYY(String date)
        {
            String[] tmp = date.Split('-');
            return tmp[2] + "-" + tmp[1] + "-" + tmp[0];
        }

        public static string GetLogo()
        {
            string logo = "";
            if (!File.Exists(@"C:\dev-workspace-outsource\BAirway\BAirway\images\pos_img_bmp.bmp"))
                return null;
            BitmapData data = GetBitmapData(@"C:\dev-workspace-outsource\BAirway\BAirway\images\pos_img_bmp.bmp");
            BitArray dots = data.Dots;
            byte[] width = BitConverter.GetBytes(data.Width);

            int offset = 0;
            MemoryStream stream = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(stream);

            bw.Write((char)0x1B);
            bw.Write('@');

            bw.Write((char)0x1B);
            bw.Write('3');
            bw.Write((byte)24);

            while (offset < data.Height)
            {
                bw.Write((char)0x1B);
                bw.Write('*');         // bit-image mode
                bw.Write((byte)33);    // 24-dot double-density
                bw.Write(width[0]);  // width low byte
                bw.Write(width[1]);  // width high byte

                for (int x = 0; x < data.Width; ++x)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        byte slice = 0;
                        for (int b = 0; b < 8; ++b)
                        {
                            int y = (((offset / 8) + k) * 8) + b;
                            // Calculate the location of the pixel we want in the bit array.
                            // It'll be at (y * width) + x.
                            int i = (y * data.Width) + x;

                            // If the image is shorter than 24 dots, pad with zero.
                            bool v = false;
                            if (i < dots.Length)
                            {
                                v = dots[i];
                            }
                            slice |= (byte)((v ? 1 : 0) << (7 - b));
                        }

                        bw.Write(slice);
                    }
                }
                offset += 24;
                bw.Write((char)0x0A);
            }
            // Restore the line spacing to the default of 30 dots.
            bw.Write((char)0x1B);
            bw.Write('3');
            bw.Write((byte)30);

            bw.Flush();
            byte[] bytes = stream.ToArray();
            return logo + Encoding.Default.GetString(bytes);
        }

        public static BitmapData GetBitmapData(string bmpFileName)
        {
            using (var bitmap = (Bitmap)Bitmap.FromFile(bmpFileName))
            {
                var threshold = 127;
                var index = 0;
                double multiplier = 570; // this depends on your printer model. for Beiyang you should use 1000
                double scale = (double)(multiplier / (double)bitmap.Width);
                int xheight = (int)(bitmap.Height * scale);
                int xwidth = (int)(bitmap.Width * scale);
                var dimensions = xwidth * xheight;
                var dots = new BitArray(dimensions);

                for (var y = 0; y < xheight; y++)
                {
                    for (var x = 0; x < xwidth; x++)
                    {
                        var _x = (int)(x / scale);
                        var _y = (int)(y / scale);
                        var color = bitmap.GetPixel(_x, _y);
                        var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        dots[index] = (luminance < threshold);
                        index++;
                    }
                }

                return new BitmapData()
                {
                    Dots = dots,
                    Height = (int)(bitmap.Height * scale),
                    Width = (int)(bitmap.Width * scale)
                };
            }
        }

        public class BitmapData
        {
            public BitArray Dots
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }

            public int Width
            {
                get;
                set;
            }
        }



        public static void Zip(string SrcFile, string DstFile)
        {
            FileStream fileStreamIn = new FileStream(SrcFile, FileMode.Open, FileAccess.Read);
            FileStream fileStreamOut = new FileStream(DstFile, FileMode.Create, FileAccess.Write);
            ZipOutputStream zipOutStream = new ZipOutputStream(fileStreamOut);

            byte[] buffer = new byte[fileStreamIn.Length];

            ZipEntry entry = new ZipEntry(Path.GetFileName(SrcFile));
            zipOutStream.PutNextEntry(entry);

            int size;
            do
            {
                size = fileStreamIn.Read(buffer, 0, buffer.Length);
                zipOutStream.Write(buffer, 0, size);
            } while (size > 0);

            zipOutStream.Close();
            fileStreamOut.Close();
            fileStreamIn.Close();
        }
        public static void ZipFolders()
        {
            FastZip fz = new FastZip();
            fz.CreateZip(@"C:\Temp\zip\test.zip", @"C:\Temp\zip\test", true, "", "");
        }
        public static void AddFileToZip(string sourceFile, string zipFolderPath)
        {
            ZipFile zipFile = new ZipFile(zipFolderPath);

            zipFile.BeginUpdate();
            zipFile.UseZip64 = UseZip64.On;
            zipFile.Add(sourceFile, Path.GetFileName(sourceFile));

            zipFile.CommitUpdate();
            zipFile.IsStreamOwner = true;
            zipFile.Close();

        }
        public static void UnZip(string sourcePath, string targetPath)
        {
            ICSharpCode.SharpZipLib.Zip.FastZip fz = new FastZip();
            fz.ExtractZip(sourcePath, targetPath, "");

        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in str)
            {
                if (c != ',')
                {
                    sb.Append(c);
                }
                //if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                //{
                //    sb.Append(c);
                //}
            }
            return sb.ToString();
        }

    }
}
