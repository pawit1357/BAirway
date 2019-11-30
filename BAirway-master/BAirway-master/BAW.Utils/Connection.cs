using System.Data.SqlClient;
using BAW.Biz;
using MySql.Data.MySqlClient;
using System.Net.NetworkInformation;
namespace BAW.Utils
{
    public class Connection
    {
        //public SQLiteConnection connectionOffine;
        //public MySqlConnection connection;
        //private string server;
        //private string database;
        //private string uid;
        //private string password;

        //Constructor
        public Connection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            //string conStr = ManageLOG.deCode(ManageLOG.getValueFromRegistry("WiFi Management", "CON"));
            //connection = new MySqlConnection(conStr);
            //connectionOffine = new SQLiteConnection(String.Format(Configurations.SqLiteStr,Configurations.AppFolder,Configurations.LocalDbFolder,Configurations.DbFile));
        }

        #region "MYSQL CONNECTON
        
        //open connection to database
        //public bool OpenConnection()
        //{
        //    try
        //    {
        //        connection.Open();
        //        return true;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        switch (ex.Number)
        //        {
        //            case 0:
        //                MessageBox.Show("Cannot connect to server.  Contact administrator");
        //                break;
        //            case 1042:
        //                //MessageBox.Show("Cannot connect to server.  The System will work on offine mode");
        //                break;
        //            case 1045:
        //                MessageBox.Show("Invalid username/password, please try again");
        //                break;
        //        }
        //        return false;
        //    }
        //}

        //Close connection
        //public bool CloseConnection()
        //{
        //    try
        //    {
        //        connection.Close();
        //        return true;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}
        
        #endregion

        #region "SQLITE CONNECTION"
        //public bool OpenOffineConnection()
        //{
        //    try
        //    {
        //        connectionOffine.Open();
        //        return true;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        switch (ex.Number)
        //        {
        //            case 0:
        //                MessageBox.Show("Cannot connect to server.  Contact administrator");
        //                break;
        //            case 1042:
        //                //MessageBox.Show("Cannot connect to server.  The System will work on offine mode");
        //                break;
        //            case 1045:
        //                MessageBox.Show("Invalid username/password, please try again");
        //                break;
        //        }
        //        return false;
        //    }
        //}

        //public bool CloseOffineConnection()
        //{
        //    try
        //    {
        //        connectionOffine.Close();
        //        return true;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}
        #endregion

        public static bool IsServerConnected()
        {

            //string serverDbIP = Configurations.MysqlStr.Split(';')[0].Split('=')[1];
            //PingReply pingReply;
            //using (var ping = new Ping())
            //    pingReply = ping.Send(serverDbIP);
            //var available = pingReply.Status == IPStatus.Success;

            string conStr = ManageLOG.deCode(ManageLOG.getValueFromRegistry("WiFi Management", "CON"));
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conStr))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");

                        break;
                    case 1042:
                        //MessageBox.Show("Cannot connect to server.  The System will work on offine mode");
                        break;
                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
            //return available;
        }

        //Backup
        //public void Backup()
        //{
        //    try
        //    {
        //        DateTime Time = DateTime.Now;
        //        int year = Time.Year;
        //        int month = Time.Month;
        //        int day = Time.Day;
        //        int hour = Time.Hour;
        //        int minute = Time.Minute;
        //        int second = Time.Second;
        //        int millisecond = Time.Millisecond;

        //        //Save file to C:\ with the current date as a filename
        //        string path;
        //        path = "C:\\MySqlBackup" + year + "-" + month + "-" + day +
        //    "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
        //        StreamWriter file = new StreamWriter(path);


        //        ProcessStartInfo psi = new ProcessStartInfo();
        //        psi.FileName = "mysqldump";
        //        psi.RedirectStandardInput = false;
        //        psi.RedirectStandardOutput = true;
        //        psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
        //            uid, password, server, database);
        //        psi.UseShellExecute = false;

        //        Process process = Process.Start(psi);

        //        string output;
        //        output = process.StandardOutput.ReadToEnd();
        //        file.WriteLine(output);
        //        process.WaitForExit();
        //        file.Close();
        //        process.Close();
        //    }
        //    catch (IOException ex)
        //    {
        //        ManageLOG.writeLoginLogs(-1, ModelUserLogs.EVENT_EXCEPTION, "Connection-Backup:" + ex.Message);
        //        MessageBox.Show("Error , unable to backup!");
        //    }
        //}

        //Restore
        //public void Restore()
        //{
        //    try
        //    {
        //        //Read file from C:\
        //        string path;
        //        path = "C:\\MySqlBackup.sql";
        //        StreamReader file = new StreamReader(path);
        //        string input = file.ReadToEnd();
        //        file.Close();

        //        ProcessStartInfo psi = new ProcessStartInfo();
        //        psi.FileName = "mysql";
        //        psi.RedirectStandardInput = true;
        //        psi.RedirectStandardOutput = false;
        //        psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
        //            uid, password, server, database);
        //        psi.UseShellExecute = false;


        //        Process process = Process.Start(psi);
        //        process.StandardInput.WriteLine(input);
        //        process.StandardInput.Close();
        //        process.WaitForExit();
        //        process.Close();
        //    }
        //    catch (IOException ex)
        //    {
        //        ManageLOG.writeLoginLogs(-1, ModelUserLogs.EVENT_EXCEPTION,  "Connection-Restore:" + ex.Message);
        //        MessageBox.Show("Error , unable to Restore!");
        //    }
        //}

    }
}


