using BAW.Biz;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAW.Dao
{
    public class RadDao
    {
        public String getAthCodeInfo(String ath_id)
        {
            DateTime acctstarttime = DateTime.MinValue;
            string query = "SELECT username,acctstarttime,acctstoptime,acctsessiontime,calledstationid FROM radacct WHERE username = '" + ath_id + "'";

            //Create a list to store the result

            using (MySqlConnection connection = new MySqlConnection("SERVER=202.47.250.203;port=7000;DATABASE=radius;UID=wifi;PASSWORD=password;"))//Configurations.MysqlStr))
            {
                connection.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dr = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dr.Read())
                {
                    acctstarttime = (DBNull.Value == dr["acctstarttime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["acctstarttime"]);
                }
                dr.Close();
            }
            return acctstarttime.ToString("yyyy-MM-dd HH:MM:ss"); ;
        }
    }
}
