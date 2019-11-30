using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using BAW.Biz;
using BAW.Model;
using System.Data.SQLite;


namespace BAW.Dao
{
    public class StaffDao
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(StaffDao));
        public StaffDao()
        {

        }

        //Select statement
        public List<ModelStaff> Select(String cri)
        {
            string query = "SELECT * FROM tb_staff_profile " + cri;

            //Create a list to store the result
            List<ModelStaff> lists = new List<ModelStaff>();

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
                    ModelStaff transaction = new ModelStaff();
                    transaction.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    transaction.staff_name = (DBNull.Value == dr["staff_name"]) ? "" : Convert.ToString(dr["staff_name"]);
                    transaction.staff_surname = (DBNull.Value == dr["staff_surname"]) ? "" : Convert.ToString(dr["staff_surname"]);
                    transaction.staff_station = (DBNull.Value == dr["staff_station"]) ? -1 : Convert.ToInt16(dr["staff_station"]);
                    transaction.staff_lounge = (DBNull.Value == dr["staff_lounge"]) ? -1 : Convert.ToInt16(dr["staff_lounge"]);
                    transaction.staff_area = (DBNull.Value == dr["staff_area"]) ? -1 : Convert.ToInt16(dr["staff_area"]);
                    transaction.status = (DBNull.Value == dr["status"]) ? "" : Convert.ToString(dr["status"]);
                    transaction.createDate = Convert.ToDateTime(dr["create_date"]);
                    lists.Add(transaction);
                }

                //close Data Reader
                dr.Close();
            }

            //return list to be displayed
            return lists;
        }
        public List<ModelStaff> SelectOffline(String cri)
        {
            string query = "SELECT * FROM tb_staff_profile " + cri;

            //Create a list to store the result
            List<ModelStaff> lists = new List<ModelStaff>();

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
                    ModelStaff transaction = new ModelStaff();
                    transaction.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    transaction.staff_name = (DBNull.Value == dr["staff_name"]) ? "" : Convert.ToString(dr["staff_name"]);
                    transaction.staff_surname = (DBNull.Value == dr["staff_surname"]) ? "" : Convert.ToString(dr["staff_surname"]);
                    transaction.staff_station = (DBNull.Value == dr["staff_station"]) ? -1 : Convert.ToInt16(dr["staff_station"]);
                    transaction.staff_lounge = (DBNull.Value == dr["staff_lounge"]) ? -1 : Convert.ToInt16(dr["staff_lounge"]);
                    transaction.staff_area = (DBNull.Value == dr["staff_area"]) ? -1 : Convert.ToInt16(dr["staff_area"]);
                    transaction.status = (DBNull.Value == dr["status"]) ? "" : Convert.ToString(dr["status"]);
                    //transaction.createDate = Convert.ToDateTime(dr["create_date"]);
                    lists.Add(transaction);
                }

                //close Data Reader
                dr.Close();
            }

            //return list to be displayed
            return lists;
        }
        //Insert statement
        public int Insert(ModelStaff model)
        {
            int id = -1;
            try
            {
                string query = "INSERT INTO tb_staff_profile(staff_name,staff_surname,staff_station,staff_lounge,staff_area,create_date,status) VALUES('" + model.staff_name + "','" + model.staff_surname + "'," + model.staff_station + "," + model.staff_lounge + "," + model.staff_area + ",NOW(),'" + model.status + "')";
                using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
                {
                    connection.Open();
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    id = Convert.ToInt16(cmd.LastInsertedId);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return -1;
            }
            return id;

        }
        public Boolean InsertOffline(ModelStaff model)
        {

            try
            {
                string query = "INSERT INTO tb_staff_profile(staff_name,staff_surname,staff_station,staff_lounge,staff_area,create_date,status) VALUES('" + model.staff_name + "','" + model.staff_surname + "'," + model.staff_station + "," + model.staff_lounge + "," + model.staff_area + ",'" + DateTime.Now + "','" + model.status + "')";
                //open connection
                using (SQLiteConnection connection = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    connection.Open();
                    //create command and assign the query and connection from the constructor
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //id = Convert.ToInt16(cmd.LastInsertedId);
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
        public Boolean Update(ModelStaff model)
        {
            try
            {
                string query = "UPDATE tb_staff_profile SET staff_name='" + model.staff_name + "',staff_surname='" + model.staff_surname + "',staff_station=" + model.staff_station + ",staff_lounge=" + model.staff_lounge + ",staff_area=" + model.staff_area + ",create_date='" + model.createDate + "',status='" + model.status + "' WHERE id =" + model.id;
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
        public Boolean Delete(ModelStaff model)
        {
            try
            {
                string query = "DELETE FROM tb_staff_profile WHERE id=" + model.id;

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
                ////System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
    }
}
