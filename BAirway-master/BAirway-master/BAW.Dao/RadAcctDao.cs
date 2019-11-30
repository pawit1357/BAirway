using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadiusService
{
    public class RadAcctDao
    {
        //Select statement
        public List<RadAcct> Select(string ath_code)
        {
            string query =
                            "SELECT `radacctid`,`acctstarttime`,`acctstoptime` FROM `radacct` where radacctid='"+ath_code+"'";

            //Create a list to store the result
            List<RadAcct> lists = new List<RadAcct>();

            using (MySqlConnection connection = new MySqlConnection("SERVER=122.155.186.120;port=7000;DATABASE=radius;UID=root;PASSWORD=dalo;"))
            {
                connection.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dr = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dr.Read())
                {
                    RadAcct model = new RadAcct();
                    model.radacctid = (DBNull.Value == dr["radacctid"]) ? "" : Convert.ToString(dr["radacctid"]);
                    model.acctstarttime = (DBNull.Value == dr["acctstarttime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["acctstarttime"]);
                    model.acctstoptime = (DBNull.Value == dr["acctstoptime"]) ? DateTime.MinValue : Convert.ToDateTime(dr["acctstoptime"]);
                    lists.Add(model);
                }
                dr.Close();
            }
            return lists;
        }
    }
}