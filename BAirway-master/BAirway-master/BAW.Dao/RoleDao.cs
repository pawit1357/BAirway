using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using BAW.Biz;
using BAW.Model;
using System.Data.SQLite;


namespace BAW.Dao
{
    public class RoleDao
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(RoleDao));
        public RoleDao()
        {

        }

        //Select statement
        public List<ModelRole> Select(String cri)
        {
            string query = "SELECT * FROM tb_role " + cri;

            //Create a list to store the result
            List<ModelRole> lists = new List<ModelRole>();

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
                    ModelRole model = new ModelRole();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    model.role_code = (DBNull.Value == dr["role_code"]) ? "" : Convert.ToString(dr["role_code"]);
                    model.role_name = (DBNull.Value == dr["role_name"]) ? "" : Convert.ToString(dr["role_name"]);

                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();

                //return list to be displayed
                return lists;
            }

        }
        public List<ModelRole> SelectOffline(String cri)
        {
            string query = "SELECT * FROM tb_role " + cri;

            //Create a list to store the result
            List<ModelRole> lists = new List<ModelRole>();

            //Open connection
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
                    ModelRole model = new ModelRole();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    model.role_code = (DBNull.Value == dr["role_code"]) ? "" : Convert.ToString(dr["role_code"]);
                    model.role_name = (DBNull.Value == dr["role_name"]) ? "" : Convert.ToString(dr["role_name"]);

                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();

                //return list to be displayed
                return lists;
            }

        }
        //Insert statement
        public Boolean Insert(ModelRole model)
        {
            try
            {
                string query = "INSERT INTO tb_role(role_code,role_name) VALUES('" + model.role_code + "','" + model.role_name + "')";
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
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        public Boolean InsertOffline(ModelRole model)
        {
            try
            {
                string query = "INSERT INTO tb_role(id,role_code,role_name) VALUES("+model.id+",'" + model.role_code + "','" + model.role_name + "')";
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
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        //Update statement
        public Boolean Update(ModelRole model)
        {
            try
            {
                string query = "UPDATE tb_role SET role_code ='" + model.role_code + "' ,role_name ='" + model.role_name + "' WHERE id =" + model.id;
                //Open connection
                //if (this.OpenConnection() == true)
                //{
                using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
                {
                    connection.Open();
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Assign the query using CommandText
                    //cmd.CommandText = query;
                    //Assign the connection using Connection
                    //cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();
                }
                //close connection
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
        //Delete statement
        public Boolean Delete(ModelRole model)
        {
            try
            {
                string query = "DELETE FROM tb_role WHERE id=" + model.id;

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
