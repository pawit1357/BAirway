using System;
using BAW.Biz;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Text;

namespace BAW.Transfer
{
    public class Program
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {

            DirectoryInfo initD = new DirectoryInfo(Configurations.policyLogPath);
            if (!initD.Exists) { initD.Create(); }
            //----------------Ftp File
            Utils.CustomUtils util = new Utils.CustomUtils();
            util.ftpServerIP = Configurations.ftpHost;
            util.ftpUserID = Configurations.ftpUsers;
            util.ftpPassword = Configurations.ftpPassword;

            DateTime curDate = DateTime.Now.AddDays(Configurations.BackCurDate);
            String filePath = Configurations.policyLogPath + (Convert.ToInt16(curDate.ToString("yyyy"))) + "-" + curDate.ToString("MM") + "-" + curDate.ToString("dd") + ".txt";
            
            if (File.Exists(filePath))
            {
                String fileZipPath = Configurations.policyLogPath + (Convert.ToInt16(curDate.ToString("yyyy"))) + "-" + curDate.ToString("MM") + "-" + curDate.ToString("dd") + ".zip";
                
                Utils.CustomUtils.Zip(filePath, fileZipPath);
                if (File.Exists(filePath))
                {
                    Boolean result = util.Upload(fileZipPath);
                    if (result)
                    {
                        File.Delete(filePath);
                        File.Delete(fileZipPath);
                        logger.Debug("ftp policy success." + DateTime.Now);
                    }
                    else
                    {
                        logger.Error("ftp policy fail." + DateTime.Now);
                    }
                }
                else {
                    logger.Error(filePath + " dose not exist.");
                }
            }
            else
            {
                logger.Error(filePath + " dose not exist.");
            }
        }

       



    }
}

			



