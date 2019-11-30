using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Win32;

namespace BAW.Biz
{

    public class Configurations
    {

        #region "Shared"


        public static String MysqlStr
        {

            //get { return ConfigurationManager.AppSettings["MysqlStr"]; }
            get { return deCode(getValueFromRegistry(Configurations.AppRegName, "CON")); }
        }
        public static String MysqlStrRad
        {

            //get { return ConfigurationManager.AppSettings["MysqlStr"]; }
            get { return deCode(getValueFromRegistry(Configurations.AppRegName, "CON1")); }
        }
        public static String SqLiteStr
        {
            get { return ConfigurationManager.AppSettings["SqLiteStr"]; }
        }


        public static String AppFolder
        {
            get { return ConfigurationManager.AppSettings["appFolder"]; }
        }
        public static String LocalDbFolder
        {
            get { return ConfigurationManager.AppSettings["localDbFolder"]; }
        }
        public static String DbFile
        {
            get { return ConfigurationManager.AppSettings["dbFile"]; }
        }

        public static String AppRegName
        {
            get { return ConfigurationManager.AppSettings["appRegName"]; }
        }

        public static String PosLogoPath
        {
            get { return ConfigurationManager.AppSettings["posLogoPath"]; }
        }

        public static String DownloadLocalURL
        {
            get { return ConfigurationManager.AppSettings["DownloadLocalURL"]; }
        }
        public static String DownloadPosLogoURL
        {
            get { return ConfigurationManager.AppSettings["DownloadPosLogoURL"]; }
        }
        public static String ImagePath
        {
            get { return ConfigurationManager.AppSettings["ImagePath"]; }
        }

        public static String ftpHost
        {
            get { return ConfigurationManager.AppSettings["ftpHost"]; }
        }
        public static String ftpUsers
        {
            get { return ConfigurationManager.AppSettings["ftpUsers"]; }
        }
        public static String ftpPassword
        {
            get { return ConfigurationManager.AppSettings["ftpPassword"]; }
        }
        public static String policyLogPath
        {
            get { return ConfigurationManager.AppSettings["policyLogPath"]; }
        }

        public static String DailyTransactionLogsPath
        {
            get { return ConfigurationManager.AppSettings["DailyTransactionLogsPath"]; }
        }

        public static int BackCurDate
        {
            get { return Convert.ToInt16(ConfigurationManager.AppSettings["BackCurDate"]); }
        }

        public static String SkipSelfStation
        {
            get { return ConfigurationManager.AppSettings["SkipSelfStation"]; }
        }


        #endregion



        //Encode
        public static string deCode(string data)
        {
            byte[] bt = System.Convert.FromBase64String(data);
            return System.Text.Encoding.ASCII.GetString(bt);
        }

        public static String getValueFromRegistry(String subFolder, String subKey)
        {
            String bReturn = "";
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\" + subFolder);
                bReturn = rk.GetValue(subKey).ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0} ", e.Message);
                bReturn = "";
            }
            return bReturn;
        }
    }
}
