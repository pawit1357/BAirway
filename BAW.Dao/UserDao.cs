using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using BAW.Model;
using BAW.Biz;
using System.Data.SQLite;


namespace BAW.Dao
{
           
    public class UserDao
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(UserDao));
        public UserDao()
        {

        }

        //Select statement
        public List<ModelUser> Select(String cri)
        {
            string query = "SELECT u.id,u.user_name,u.user_pass,u.user_role,u.user_status,u.station_id,r.role_name,u.createdate  " +
                            "FROM tb_users u "+
                            "left join tb_role r on u.user_role = r.id  " + cri;

            //Create a list to store the result
            List<ModelUser> lists = new List<ModelUser>();

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
                    ModelUser transaction = new ModelUser();
                    transaction.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    transaction.user_name = (DBNull.Value == dr["user_name"]) ? "" : Convert.ToString(dr["user_name"]);
                    transaction.user_pass = (DBNull.Value == dr["user_pass"]) ? "" : Convert.ToString(dr["user_pass"]);
                    transaction.user_role = (DBNull.Value == dr["user_role"]) ? -1 : Convert.ToInt16(dr["user_role"]);
                    transaction.userRoleName = dr["role_name"].ToString();
                    transaction.user_status = dr["user_status"].ToString();
                    transaction.stationId = (DBNull.Value == dr["station_id"]) ? -1 : Convert.ToInt16(dr["station_id"]);
                    //transaction.createDate = (DBNull.Value == dr["createDate"]) ? Date : Convert.ToDateTime(dr["createDate"]);
                    lists.Add(transaction);
                }

                //close Data Reader
                dr.Close();
            }


            //return list to be displayed
            return lists;
        }
        public List<ModelUser> SelectOffine(String cri)
        {
            string query = "SELECT u.id,u.user_name,u.user_pass,u.user_role,u.user_status,u.station_id,r.role_name,u.createdate  " +
                            "FROM tb_users u " +
                            "left join tb_role r on u.user_role = r.id  " + cri;

            //Create a list to store the result
            List<ModelUser> lists = new List<ModelUser>();

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
                    ModelUser transaction = new ModelUser();
                    transaction.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    transaction.user_name = (DBNull.Value == dr["user_name"]) ? "" : Convert.ToString(dr["user_name"]);
                    transaction.user_pass = (DBNull.Value == dr["user_pass"]) ? "" : Convert.ToString(dr["user_pass"]);
                    transaction.user_role = (DBNull.Value == dr["user_role"]) ? -1 : Convert.ToInt16(dr["user_role"]);
                    transaction.userRoleName = dr["role_name"].ToString();
                    transaction.user_status = dr["user_status"].ToString();
                    transaction.stationId = (DBNull.Value == dr["station_id"]) ? -1 : Convert.ToInt16(dr["station_id"]);
                    //transaction.createDate = (DBNull.Value == dr["createDate"]) ? Date : Convert.ToDateTime(dr["createDate"]);
                    lists.Add(transaction);
                }

                //close Data Reader
                dr.Close();
            }


            //return list to be displayed
            return lists;
        }
        //Insert statement
        public Boolean Insert(ModelUser model)
        {

            try
            {
                string query = "INSERT INTO tb_users(user_name,user_pass,user_role,createdate,user_status,station_id) VALUES('" + model.user_name + "','" + model.user_pass + "'," + model.user_role + ",NOW(),'" + model.user_status + "',"+model.stationId+")";
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

        public Boolean InsertOffline(ModelUser model)
        {
            try
            {
                string query = "INSERT INTO tb_users(id,user_name,user_pass,user_role,createdate,user_status,station_id) VALUES("+model.id+",'" + model.user_name + "','" + model.user_pass + "'," + model.user_role + ",'"+DateTime.Now+"','" + model.user_status + "'," + model.stationId + ")";
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
        public Boolean Update(ModelUser model)
        {
            try
            {
                string query = "UPDATE tb_users SET id=" + model.id + ", user_name ='" + model.user_name + "' ,user_pass ='" + model.user_pass + "',user_role=" + model.user_role + ",user_status='" + model.user_status + "',station_id="+model.stationId+" WHERE id =" + model.id;
                //Open connection
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
        //Delete statement
        public Boolean Delete(ModelUser model)
        {
            try
            {
                string query = "DELETE FROM tb_users WHERE id=" + model.id;

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

    }
}
