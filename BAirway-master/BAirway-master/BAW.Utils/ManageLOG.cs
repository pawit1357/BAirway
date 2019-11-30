using System;
using System.IO;
using Microsoft.Win32;
using BAW.Dao;
using BAW.Model;
namespace BAW.Utils
{
    
    public class ManageLOG 
    {


        private static UserLogsDao userlogs = new UserLogsDao();

        public String fileName { get; set; }
        public String folderName { get; set; }


        public ManageLOG() { }

        public void WriteLog(String logEvent)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs, System.Text.ASCIIEncoding.Default);
                sw.WriteLine(logEvent);
                sw.Close();
                fs.Close();
            }
            catch (IOException ie)
            {
                Console.WriteLine("ERROR MSG {0}", ie.Message);
            }
        }

        //Write
        public static void writeRegistry(String subFolder, String subKey, String keyValue)
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\" + subFolder);
                reg.SetValue(subKey, keyValue);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0} ", e.Message);
            }
        }
        //Read
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
        //Decode
        public static string deCode(string data)
        {
            byte[] bt = System.Convert.FromBase64String(data);
            return System.Text.Encoding.ASCII.GetString(bt);
        }
        //Encode
        public static string enCode(string data)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(data);
            return System.Convert.ToBase64String(toEncodeAsBytes);
        }

        public static Boolean Formula(String key)
        {
            Boolean isTrue = false;
            if (key.Length == 16)
            {
                char[] part01 = key.Substring(0, 8).ToCharArray();
                char[] part02 = key.Substring(8, 8).ToCharArray();
                Int16 sump1 = 0;
                Int16 sump2 = 1;
                for (int i = 0; i < part01.Length; i++)
                {
                    sump1 += Convert.ToInt16(part01[i].ToString());
                }
                for (int j = 0; j < part02.Length; j++)
                {
                    sump2 *= Convert.ToInt16(part02[j].ToString());
                }
                if (sump2 > 0)
                {
                    int result = sump2 / sump1;
                    string degit = result.ToString().Substring(0, 1);
                    int result1 = Convert.ToInt16(degit) + 9;
                    if (result1 == 17)
                    {
                        isTrue = true;
                    }
                    else
                    {
                        isTrue = false;
                    }
                }
                else
                {
                    isTrue = false;
                }
            }
            return isTrue;
        }

        //public static string GetHDDSerialNumber(string drive)
        //{
        //    //check to see if the user provided a drive letter
        //    //if not default it to "C"
        //    if (drive == "" || drive == null)
        //    {
        //        drive = "C";
        //    }
        //    //create our ManagementObject, passing it the drive letter to the
        //    //DevideID using WQL
        //    ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
        //    //bind our management object
        //    disk.Get();
        //    //return the serial number
        //    return disk["VolumeSerialNumber"].ToString();
        //} 

        public static void writeLoginLogs(int userid,int eventid,String desc)
        {
            
            ModelUserLogs log = new ModelUserLogs();
            log.user_id = userid;
            log.event_id = eventid;
            log.log_description = desc;
            userlogs.Insert(log);
        }
    }
}