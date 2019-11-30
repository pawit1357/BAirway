using System;
using System.Collections.Generic;

using BAW.Model;
using MySql.Data.MySqlClient;
using BAW.Biz;



namespace BAW.Dao
{
    public class UserLogsDao
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(UserLogsDao));
        public UserLogsDao()
        {

        }

        //Select statement
        public List<ModelUserLogs> Select(String cri)
        {
            string query = "SELECT * FROM tb_users_log " + cri;

            //Create a list to store the result
            List<ModelUserLogs> lists = new List<ModelUserLogs>();

            //Open connection
            //if (this.OpenConnection() == true)
            //{
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
                    ModelUserLogs transaction = new ModelUserLogs();
                    transaction.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    transaction.user_id = (DBNull.Value == dr["user_id"]) ? -1 : Convert.ToInt16(dr["user_id"]);
                    transaction.event_id = (DBNull.Value == dr["event_id"]) ? -1 : Convert.ToInt16(dr["event_id"]);
                    transaction.log_description = (DBNull.Value == dr["log_description"]) ? "" : Convert.ToString(dr["log_description"]);
                    transaction.log_date = Convert.ToDateTime(dr["log_date"]);
                    lists.Add(transaction);
                }

                //close Data Reader
                dr.Close();
            }
            //close Connection
            //this.CloseConnection();

            //return list to be displayed
            return lists;
            //}
            //else
            //{
            //    this.CloseConnection();
            //    if (this.OpenOffineConnection() == true)
            //    {
            //        //Create Command
            //        SQLiteCommand cmd = new SQLiteCommand(query, connectionOffine);
            //        //Create a data reader and Execute the command
            //        SQLiteDataReader dr = cmd.ExecuteReader();

            //        //Read the data and store them in the list
            //        while (dr.Read())
            //        {
            //            ModelUserLogs model = new ModelUserLogs();
            //            model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
            //            model.user_id = (DBNull.Value == dr["user_id"]) ? -1 : Convert.ToInt16(dr["user_id"]);
            //            model.event_id = (DBNull.Value == dr["event_id"]) ? -1 : Convert.ToInt16(dr["event_id"]);
            //            model.log_description = (DBNull.Value == dr["log_description"]) ? "" : Convert.ToString(dr["log_description"]);
            //            model.log_date = Convert.ToDateTime(dr["log_date"]);
            //            lists.Add(model);
            //        }

            //        //close Data Reader
            //        dr.Close();

            //        //close Connection
            //        this.CloseOffineConnection();


            //    }
            //    else
            //    {
            //        System.Windows.Forms.MessageBox.Show("Can't Connect to Offine DB!! Please contact Developer");
            //    }
            //    return lists;
            //}
        }
        //Insert statement
        public Boolean Insert(ModelUserLogs model)
        {
            try
            {
                string query = "INSERT INTO tb_users_log(user_id,event_id,log_description,log_date) VALUES(" + model.user_id + "," + model.event_id + ",'" + model.log_description + "','" + DateTime.Now.ToString() + "')";
                //open connection
                //if (this.OpenConnection() == true)
                //{
                using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
                {
                    connection.Open();
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
                //close connection
                //this.CloseConnection();
                //}
                //else {
                //    this.CloseConnection();
                //    if (this.OpenOffineConnection() == true)
                //    {
                //        //Create Command
                //        SQLiteCommand cmd = new SQLiteCommand(query, connectionOffine);
                //        cmd.ExecuteNonQuery();

                //        //close Connection
                //        this.CloseOffineConnection();
                //    }
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

        //Update statement
        //public Boolean Update(ModelUserLogs model)
        //{
        //    try
        //    {
        //        string query = "UPDATE tb_users_log SET user_id =" + model.user_id + " ,user_checkin_date ='" + model.user_checkin_date + "',user_checkout_date='" + model.user_checkout_date + "' WHERE id =" + model.id;
        //        //Open connection
        //        if (this.OpenConnection() == true)
        //        {
        //            //create mysql command
        //            MySqlCommand cmd = new MySqlCommand();
        //            //Assign the query using CommandText
        //            cmd.CommandText = query;
        //            //Assign the connection using Connection
        //            cmd.Connection = connection;

        //            //Execute query
        //            cmd.ExecuteNonQuery();

        //            //close connection
        //            this.CloseConnection();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //    return true;
        //}
        //Delete statement
        //public Boolean Delete(ModelUserLogs model)
        //{
        //    try
        //    {
        //        string query = "DELETE FROM tb_users_log WHERE id=" + model.id;

        //        if (this.OpenConnection() == true)
        //        {
        //            MySqlCommand cmd = new MySqlCommand(query, connection);
        //            cmd.ExecuteNonQuery();
        //            this.CloseConnection();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //    return true;
        //}
    }
}
