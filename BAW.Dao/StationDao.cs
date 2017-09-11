using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using BAW.Model;
using BAW.Biz;
using System.Data.SQLite;
using System.Text;


namespace BAW.Dao
{
    public class StationDao
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(StationDao));
        //private Boolean isDbAlive = false;

        public StationDao()
        {
            //this.isDbAlive = Connection.IsServerConnected();
        }

        //Select statement
        public List<ModelStation> Select(String cri)
        {
            string query = "SELECT * FROM tb_station " + cri;

            //Create a list to store the result
            List<ModelStation> lists = new List<ModelStation>();

            using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
            {
                connection.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dr = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dr.Read())
                {
                    ModelStation model = new ModelStation();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    model.site_code = (DBNull.Value == dr["site_code"]) ? "" : Convert.ToString(dr["site_code"]);
                    model.site_name = (DBNull.Value == dr["site_name"]) ? "" : Convert.ToString(dr["site_name"]);
                    model.site_host_ip = (DBNull.Value == dr["site_host_ip"]) ? "" : Convert.ToString(dr["site_host_ip"]);
                    model.site_host_user = (DBNull.Value == dr["site_host_user"]) ? "" : Convert.ToString(dr["site_host_user"]);
                    model.site_host_pass = (DBNull.Value == dr["site_Host_pass"]) ? "" : Convert.ToString(dr["site_Host_pass"]);
                    if (model.id != 12 || model.id != 14)
                    {
                        lists.Add(model);
                    }
                }

                //close Data Reader
                dr.Close();
            }
            //return list to be displayed
            return lists;
        }
        public List<ModelStation> SelectOffine(String cri)
        {
            string query = "SELECT * FROM tb_station " + cri;

            //Create a list to store the result
            List<ModelStation> lists = new List<ModelStation>();

            using (SQLiteConnection conn = new SQLiteConnection(Configurations.SqLiteStr))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                //Create a data reader and Execute the command
                SQLiteDataReader dr = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dr.Read())
                {
                    ModelStation model = new ModelStation();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    model.site_code = (DBNull.Value == dr["site_code"]) ? "" : Convert.ToString(dr["site_code"]);
                    model.site_name = (DBNull.Value == dr["site_name"]) ? "" : Convert.ToString(dr["site_name"]);
                    model.site_host_ip = (DBNull.Value == dr["site_host_ip"]) ? "" : Convert.ToString(dr["site_host_ip"]);
                    model.site_host_user = (DBNull.Value == dr["site_host_user"]) ? "" : Convert.ToString(dr["site_host_user"]);
                    model.site_host_pass = (DBNull.Value == dr["site_Host_pass"]) ? "" : Convert.ToString(dr["site_Host_pass"]);
                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();
            }
            //return list to be displayed
            return lists;
        }
        //Insert statement
        public Boolean Insert(ModelStation model)
        {
            try
            {
                string query = "INSERT INTO tb_station(site_name,site_code) VALUES('" + model.site_name + "','" + model.site_code + "')";
                using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
                {
                    connection.Open();
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public Boolean InsertOffine(ModelStation model)
        {
            try
            {

                UTF8Encoding utf8 = new UTF8Encoding();
                string unicodeString = model.site_name;
                byte[] encodedBytes = utf8.GetBytes(unicodeString);
                String station_name = utf8.GetString(encodedBytes);

                string query = "INSERT INTO tb_station(id,site_name,site_code) VALUES(" + model.id + ",'" + station_name + "','" + model.site_code + "')";
                using (SQLiteConnection connection = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    connection.Open();
                    //create command and assign the query and connection from the constructor
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                return false;
            }
            return true;
        }
        //Update statement
        public Boolean Update(ModelStation model)
        {
            try
            {
                string query = "UPDATE tb_station SET site_name ='" + model.site_name + "',site_code='" + model.site_code + "' WHERE id =" + model.id;
                using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
                {
                    connection.Open();
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                return false;
            }
            return true;
        }
        public Boolean UpdateOffine(ModelStation model)
        {
            try
            {
                string query = "UPDATE tb_station SET site_name ='" + model.site_name + "',site_code='" + model.site_code + "' WHERE id =" + model.id;
                using (SQLiteConnection connection = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    connection.Open();
                    //create command and assign the query and connection from the constructor
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    //Execute query
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                return false;
            }
            return true;
        }
        //Delete statement
        public Boolean Delete(ModelStation model)
        {
            try
            {
                string query = "DELETE FROM tb_station WHERE id=" + model.id;
                using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                return false;
            }
            return true;
        }

        public Boolean DeleteOffine(ModelStation model)
        {
            try
            {
                string query = "DELETE FROM tb_station WHERE id=" + model.id;
                using (SQLiteConnection connection = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    connection.Open();
                    //create command and assign the query and connection from the constructor
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }


        public List<ModelStation> SelectAdhoc(String conStr)
        {
            //Open connection
            string query = "SELECT * FROM tb_station ";

            //Create a list to store the result
            List<ModelStation> lists = new List<ModelStation>();

            MySqlConnection connection = new MySqlConnection(conStr);

            connection.Open();

            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dr = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dr.Read())
            {
                ModelStation model = new ModelStation();
                model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                model.site_code = (DBNull.Value == dr["site_code"]) ? "" : Convert.ToString(dr["site_code"]);
                model.site_name = (DBNull.Value == dr["site_name"]) ? "" : Convert.ToString(dr["site_name"]);
                model.site_host_ip = (DBNull.Value == dr["site_host_ip"]) ? "" : Convert.ToString(dr["site_host_ip"]);
                model.site_host_user = (DBNull.Value == dr["site_host_user"]) ? "" : Convert.ToString(dr["site_host_user"]);
                model.site_host_pass = (DBNull.Value == dr["site_Host_pass"]) ? "" : Convert.ToString(dr["site_Host_pass"]);
                lists.Add(model);
            }

            //close Data Reader
            dr.Close();

            //close Connection
            connection.Close();

            //return list to be displayed
            return lists;

        }
    }

}
