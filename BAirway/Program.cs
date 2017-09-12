using BAW.Biz;
using BAW.Dao;
using BAW.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace BAirway
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if (Connection.IsServerConnected())
            {
                ManageLOG.writeRegistry(Configurations.AppRegName, "OnlineStatus", "1");

                #region "Syncronize Data"

                //upload data from localdb-->online db

                Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
                thread.Start();

                #endregion
                #region "Check has pos logo"

                if (!Directory.Exists(String.Format(@"C:\{0}\\{1}\\", Configurations.AppFolder, Configurations.ImagePath)))
                {
                    Directory.CreateDirectory(String.Format(@"C:\{0}\\{1}\\", Configurations.AppFolder, Configurations.ImagePath));
                }
                if (!Directory.Exists(String.Format(@"C:\{0}\\{1}\\", Configurations.AppFolder, Configurations.LocalDbFolder)))
                {
                    Directory.CreateDirectory(String.Format(@"C:\{0}\\{1}\\", Configurations.AppFolder, Configurations.LocalDbFolder));
                }
                //Check file exist
                if (!File.Exists(Configurations.PosLogoPath))
                {
                    WebClient client1 = new WebClient();
                    client1.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client1.DownloadFileAsync(new Uri(Configurations.DownloadPosLogoURL), Configurations.PosLogoPath);
                }

                String sourcePath = String.Format(@"C:\{0}\{1}\", Configurations.AppFolder, Configurations.LocalDbFolder);
                String fileName = Configurations.DbFile;
                //Check file exist
                if (!File.Exists(sourcePath + "" + fileName))
                {
                    // Create an instance of WebClient
                    WebClient client = new WebClient();
                    // Hookup DownloadFileCompleted Event
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    // Start the download and copy the file to c:\temp
                    client.DownloadFileAsync(new Uri(Configurations.DownloadLocalURL), sourcePath + "" + fileName);
                }

                #endregion
            }
            else
            {
                ManageLOG.writeRegistry(Configurations.AppRegName, "OnlineStatus", "0");
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMenu());

        }

        public static void WorkThreadFunction()
        {
            try
            {
                TransactionUtil.transfer2Server();
                TransactionUtil.downloadAuthenCode();

                //TransactionUtil.downloadStation();
                TransactionUtil.downloadUsers();
                //TransactionUtil.downloadLounge();
                //TransactionUtil.downloadArea();
                //TransactionUtil.downloadGroup();
                //TransactionUtil.downloadRole();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // log errors
                //logger.Equals(ex.Message);
            }
        }


        private static void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //logger.Debug("Download document success.");
        }








    }
}
