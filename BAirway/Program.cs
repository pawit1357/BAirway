using BAW.Biz;
using BAW.Dao;
using BAW.Utils;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace BAirway
{
    static class Program
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            logger.Debug("LOAD PROGRAM");
            if (String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "CON")))
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmSetting());
            }
            else
            {
                logger.Debug("CHECK CONNECTION");

                if (Connection.IsServerConnected())
                {
                    ManageLOG.writeRegistry(Configurations.AppRegName, "OnlineStatus", "1");

                    #region "Syncronize Data"
                    logger.Debug("Syncronize Data");
                    //upload data from localdb-->online db
                    logger.Debug("transfer2Server");
                    TransactionUtil.transfer2Server();
                    logger.Debug("synCodeToOnline");
                    TransactionUtil.synCodeToOnline();
                    //new thred to download authen code
                    String currentDate = DateTime.Now.ToString("yyyyMMdd");
                    logger.Debug("LastedUpdateAthCode");
                    String LastedUpdateAthCode = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "LastedUpdateAthCode");
                    if (String.IsNullOrEmpty(LastedUpdateAthCode) || !currentDate.Equals(LastedUpdateAthCode))
                    {
                        Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
                        thread.Start();
                        ManageLOG.writeRegistry(Configurations.AppRegName, "LastedUpdateAthCode", currentDate);
                    }
                    #endregion

                    #region "Check has pos logo"
                    logger.Debug("Check has pos logo");

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

                if (String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "DefaultLang")))
                {
                    ManageLOG.writeRegistry(Configurations.AppRegName, "DefaultLang", "0|TH");
                }
                //Selft Access Screen
                if (String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SelfAccessFontSize")))
                {
                    ManageLOG.writeRegistry(Configurations.AppRegName, "SelfAccessFontSize", "20.25");
                }
                //Print Stricker
                if (String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPAcCode")))
                {
                    ManageLOG.writeRegistry(Configurations.AppRegName, "txtPAcCode", "8");

                }
                if (String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPT1Size")))
                {
                    ManageLOG.writeRegistry(Configurations.AppRegName, "txtPT1Size", "14");

                }
                if (String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPT2Size")))
                {
                    ManageLOG.writeRegistry(Configurations.AppRegName, "txtPT2Size", "8");

                }
                if (String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPT3Size")))
                {
                    ManageLOG.writeRegistry(Configurations.AppRegName, "txtPT3Size", "6");

                }


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMenu());
            }

        }

        public static void WorkThreadFunction()
        {
            try
            {

                //String currentDate = DateTime.Now.ToString("yyyyMMdd");

                //String LastedUpdateAthCode = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "LastedUpdateAthCode");
                //if (String.IsNullOrEmpty(LastedUpdateAthCode) || !currentDate.Equals(LastedUpdateAthCode))
                //{
                TransactionUtil.downloadAuthenCode();
                //ManageLOG.writeRegistry(Configurations.AppRegName, "LastedUpdateAthCode", currentDate);
                //}




                //TransactionUtil.downloadStation();
                //TransactionUtil.downloadUsers();
                //TransactionUtil.downloadLounge();
                //TransactionUtil.downloadArea();
                //TransactionUtil.downloadGroup();
                //TransactionUtil.downloadRole();

            }
            catch (Exception ex)
            {
                logger.Equals(ex.Message);
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
