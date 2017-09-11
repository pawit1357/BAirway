using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using BAW.Model;
using BAW.Biz;
using System.Data.SQLite;


namespace BAW.Dao
{
    public class AreaDao 
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AreaDao));
        //private Boolean isDbAlive = false;

        public AreaDao()
        {
            //this.isDbAlive = Connection.IsServerConnected();
        }

        //Select statement
        public List<ModelArea> Select(String cri)
        {
            string query =
                            "SELECT a.id,a.area_name,a.area_code,a.area_station,a.area_lounge,s.site_name,l.lounge_name" +
                            " FROM tb_area a " +
                            " left join tb_station s on a.area_station = s.id " +
                            " left join tb_lounge l on a.area_lounge = l.id "+cri;

            //Create a list to store the result
            List<ModelArea> lists = new List<ModelArea>();

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
                    ModelArea model = new ModelArea();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    model.station = (DBNull.Value == dr["site_name"]) ? "" : Convert.ToString(dr["site_name"]);
                    model.lounge = (DBNull.Value == dr["lounge_name"]) ? "" : Convert.ToString(dr["lounge_name"]);
                    model.area_station = (DBNull.Value == dr["area_station"]) ? -1 : Convert.ToInt16(dr["area_station"]);
                    model.area_lounge = (DBNull.Value == dr["area_lounge"]) ? -1 : Convert.ToInt16(dr["area_lounge"]);
                    model.area_code = (DBNull.Value == dr["area_code"]) ? "" : Convert.ToString(dr["area_code"]);
                    model.area_name = (DBNull.Value == dr["area_name"]) ? "" : Convert.ToString(dr["area_name"]);

                    lists.Add(model);
                }
                dr.Close();
            }
            //if (lists.Count > 0)
            //{
            //    ModelArea model1 = new ModelArea();
            //    model1.id = -1;
            //    model1.area_code = "";
            //    model1.area_name = "";
            //    lists.Insert(0, model1);
            //}
            return lists;
        }
        public List<ModelArea> SelectOffine(String cri)
        {
            List<ModelArea> lists = new List<ModelArea>();
            try
            {
                string query =
                                "SELECT a.id,a.area_name,a.area_code,a.area_station,a.area_lounge,s.site_name,l.lounge_name" +
                                " FROM tb_area a " +
                                " left join tb_station s on a.area_station = s.id " +
                                " left join tb_lounge l on a.area_lounge = l.id " + cri;

                //Create a list to store the result



                using (SQLiteConnection conn = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    conn.Open();
                    //Create Command
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    //Create a data reader and Execute the command
                    SQLiteDataReader dr = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dr.Read())
                    {
                        ModelArea model = new ModelArea();
                        model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                        model.station = (DBNull.Value == dr["site_name"]) ? "" : Convert.ToString(dr["site_name"]);
                        model.lounge = (DBNull.Value == dr["lounge_name"]) ? "" : Convert.ToString(dr["lounge_name"]);
                        model.area_station = (DBNull.Value == dr["area_station"]) ? -1 : Convert.ToInt16(dr["area_station"]);
                        model.area_lounge = (DBNull.Value == dr["area_lounge"]) ? -1 : Convert.ToInt16(dr["area_lounge"]);
                        model.area_code = (DBNull.Value == dr["area_code"]) ? "" : Convert.ToString(dr["area_code"]);
                        model.area_name = (DBNull.Value == dr["area_name"]) ? "" : Convert.ToString(dr["area_name"]);


                        lists.Add(model);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                //return null;
            }
            //if (lists.Count > 0)
            //{
            //    ModelArea model1 = new ModelArea();
            //    model1.id = -1;
            //    model1.area_code = "";
            //    model1.area_name = "";
            //    lists.Insert(0, model1);
            //}
            return lists;
        }
        //Insert statement
        public Boolean Insert(ModelArea model)
        {
            try
            {
                string query = "INSERT INTO tb_area(area_station,area_lounge,area_code,area_name) VALUES(" + model.area_station+"," + model.area_lounge + ",'" + model.area_code + "','" + model.area_name + "')";
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
        public Boolean InsertOffline(ModelArea model)
        {
            try
            {
                string query = "INSERT INTO tb_area(id,area_station,area_lounge,area_code,area_name) VALUES("+model.id+"," + model.area_station + "," + model.area_lounge + ",'" + model.area_code + "','" + model.area_name + "')";
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
        public Boolean Update(ModelArea model)
        {
            try
            {
                string query = "UPDATE tb_area SET area_station="+model.area_station+", area_lounge=" + model.area_lounge + ",area_code ='" + model.area_code + "' ,area_name ='" + model.area_name + "' WHERE id =" + model.id;
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
                //    this.CloseConnection();
                //}
                //else {
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
        public Boolean Delete(ModelArea model)
        {
            try
            {
                string query = "DELETE FROM tb_area WHERE id=" + model.id;

                //if (this.OpenConnection() == true)
                //{
                using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                    //this.CloseConnection();
                //}
                //else {
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
