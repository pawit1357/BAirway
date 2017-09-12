using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using BAW.Model;
using BAW.Biz;
using System.Data.SQLite;


namespace BAW.Dao
{
    public class LoungeDao
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(LoungeDao));
        //private Boolean isDbAlive = false;

        public LoungeDao()
        {
            //this.isDbAlive = Connection.IsServerConnected();
        }

        //Select statement
        public List<ModelLounge> Select(String cri)
        {
            string query = "SELECT l.id,l.lounge_station,l.lounge_name,s.site_name FROM tb_lounge l left join tb_station s on l.lounge_station = s.id " + cri;

            //Create a list to store the result
            List<ModelLounge> lists = new List<ModelLounge>();


            //Open connection
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
                    ModelLounge model = new ModelLounge();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    model.lounge_station = (DBNull.Value == dr["lounge_station"]) ? -1 : Convert.ToInt16(dr["lounge_station"]);
                    model.site_name = (DBNull.Value == dr["site_name"]) ? "" : Convert.ToString(dr["site_name"]);
                    model.lounge_name = (DBNull.Value == dr["lounge_name"]) ? "" : Convert.ToString(dr["lounge_name"]);

                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();
            }


            return lists;
        }
        public List<ModelLounge> SelectOffline(String cri)
        {
            string query = "SELECT l.id,l.lounge_station,l.lounge_name,s.site_name FROM tb_lounge l left join tb_station s on l.lounge_station = s.id " + cri;
            //Create a list to store the result
            List<ModelLounge> lists = new List<ModelLounge>();
            try
            {
                //Open connection
                using (SQLiteConnection conn = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    conn.Open();
                    //Create Command
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    //Create a data reader and Execute the command
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    logger.Error("LoungeDao:Connected\n");
                    //Read the data and store them in the list
                    while (dr.Read())
                    {
                        ModelLounge model = new ModelLounge();
                        model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                        model.lounge_station = (DBNull.Value == dr["lounge_station"]) ? -1 : Convert.ToInt16(dr["lounge_station"]);
                        model.site_name = (DBNull.Value == dr["site_name"]) ? "" : Convert.ToString(dr["site_name"]);
                        model.lounge_name = (DBNull.Value == dr["lounge_name"]) ? "" : Convert.ToString(dr["lounge_name"]);
                        logger.Error("LoungeDao:Add List(" + model.id + ")\n");
                        lists.Add(model);
                    }

                    //close Data Reader
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                logger.Error("LoungeDao:" + ex.StackTrace + "\n" + query + "\n" + Configurations.SqLiteStr);
                Console.WriteLine("");
            }
            logger.Error("LoungeDao:" + lists.Count);
            return lists;
        }
        //Insert statement
        public Boolean Insert(ModelLounge model)
        {
            try
            {
                string query = "INSERT INTO tb_lounge(lounge_station,lounge_name) VALUES(" + model.lounge_station + ",'" + model.lounge_name + "')";
                //open connection
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
                return false;
            }
            return true;
        }
        public Boolean InsertOffline(ModelLounge model)
        {
            try
            {
                string query = "INSERT INTO tb_lounge(id,lounge_station,lounge_name) VALUES(" + model.id + "," + model.lounge_station + ",'" + model.lounge_name + "')";
                //open connection
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
        public Boolean Update(ModelLounge model)
        {
            try
            {
                string query = "UPDATE tb_lounge SET lounge_station =" + model.lounge_station + " ,lounge_name ='" + model.lounge_name + "' WHERE id =" + model.id;
                //Open connection
                //if (this.OpenConnection() == true)
                //{
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
                //close connection
                //this.CloseConnection();
                //}
                //else
                //{
                //    System.Windows.Forms.MessageBox.Show("Not Allow Insert,Delete,Update On OffLine Mode!!");
                //}
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        //Delete statement
        public Boolean Delete(ModelLounge model)
        {
            try
            {
                string query = "DELETE FROM tb_lounge WHERE id=" + model.id;

                //if (this.OpenConnection() == true)
                //{
                using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                //    this.CloseConnection();
                //}
                //else
                //{
                //    System.Windows.Forms.MessageBox.Show("Not Allow Insert,Delete,Update On OffLine Mode!!");
                //}
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
    }
}
