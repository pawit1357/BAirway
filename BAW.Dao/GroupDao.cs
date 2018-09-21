using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using BAW.Model;
using BAW.Biz;
using System.Data.SQLite;


namespace BAW.Dao
{
    public class GroupDao
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(GroupDao));
        public GroupDao()
        {
            
        }

        //Select statement
        public List<ModelGroup> Select(String cri)
        {
            string query = "SELECT * FROM tb_group " + cri + " order by group_order asc";

            //Create a list to store the result
            List<ModelGroup> lists = new List<ModelGroup>();

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
                    ModelGroup model = new ModelGroup();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    model.group_code = (DBNull.Value == dr["group_code"]) ? "" : Convert.ToString(dr["group_code"]);
                    model.group_description = (DBNull.Value == dr["group_description"]) ? "" : Convert.ToString(dr["group_description"]);
                    model.group_order =Convert.ToInt16( (DBNull.Value == dr["group_order"]) ? "0" : Convert.ToString(dr["group_order"]));
                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();
            }

            //return list to be displayed
            if (lists.Count > 0)
            {
                ModelGroup model1 = new ModelGroup();
                model1.id = -1;
                model1.group_code = "";
                model1.group_description = "";
                model1.group_order = 0;
                lists.Insert(0, model1);
            }
            return lists;

        }
        public List<ModelGroupRemark> SelectGroupRemarkByGroupCode(String group_code)
        {
            string query = String.Format("SELECT * FROM tb_group_remark where group_code='{0}'",group_code);

            //Create a list to store the result
            List<ModelGroupRemark> lists = new List<ModelGroupRemark>();

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
                    ModelGroupRemark model = new ModelGroupRemark();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    model.group_code = (DBNull.Value == dr["group_code"]) ? "" : Convert.ToString(dr["group_code"]);
                    model.value = (DBNull.Value == dr["value"]) ? "" : Convert.ToString(dr["value"]);
                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();
            }

            //return list to be displayed
  
            return lists;

        }
        public List<ModelGroup> SelectOffine(String cri)
        {
            string query = "SELECT * FROM tb_group " + cri + " order by group_order asc";

            //Create a list to store the result
            List<ModelGroup> lists = new List<ModelGroup>();
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
                    ModelGroup model = new ModelGroup();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    model.group_code = (DBNull.Value == dr["group_code"]) ? "" : Convert.ToString(dr["group_code"]);
                    model.group_description = (DBNull.Value == dr["group_description"]) ? "" : Convert.ToString(dr["group_description"]);
                    model.group_order = Convert.ToInt16((DBNull.Value == dr["group_order"]) ? "0" : Convert.ToString(dr["group_order"]));
                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();

            }
            if (lists.Count > 0)
            {
                ModelGroup model1 = new ModelGroup();
                model1.id = -1;
                model1.group_code = "";
                model1.group_description = "";
                model1.group_order = 0;
                lists.Insert(0, model1);
            }
            return lists;

        }
        //Insert statement
        public Boolean Insert(ModelGroup model)
        {
            try
            {
                string query = "INSERT INTO tb_group(group_code,group_description,group_order) VALUES('" + model.group_code + "','" + model.group_description +"'," +model.group_order+ ")";
                
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
        public Boolean InsertOffline(ModelGroup model)
        {
            try
            {
                string query = "INSERT INTO tb_group(group_code,group_description,group_order) VALUES('" + model.group_code + "','" + model.group_description + "'," + model.group_order + ")";
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
        public Boolean Update(ModelGroup model)
        {
            try
            {
                string query = "UPDATE tb_group SET group_code ='" + model.group_code + "' ,group_description ='" + model.group_description + "',group_order=" +model.group_order+ " WHERE id =" + model.id;
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
        public Boolean Delete(ModelGroup model)
        {
            try
            {
                string query = "DELETE FROM tb_group WHERE id=" + model.id;
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
