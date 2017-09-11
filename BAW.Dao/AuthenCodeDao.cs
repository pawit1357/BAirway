using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using BAW.Model;
using BAW.Biz;
using System.Data.SQLite;


namespace BAW.Dao
{
    public class AuthenCodeDao
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AuthenCodeDao));
        public AuthenCodeDao()
        {

        }

        //Select statement
        public List<ModelAuthenCode> Select(String cri,int station_id)
        {

            string query = "SELECT * FROM tb_authen_code " + ((cri.Equals("")) ? " Where station_id=" + station_id : cri+" And station_id=" + station_id)+" limit 1";

            //Create a list to store the result
            List<ModelAuthenCode> lists = new List<ModelAuthenCode>();

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
                    ModelAuthenCode model = new ModelAuthenCode();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt32(dr["id"]);
                    model.ath_code = (DBNull.Value == dr["ath_code"]) ? "" : Convert.ToString(dr["ath_code"]);
                    model.ath_user = (DBNull.Value == dr["ath_user"]) ? "" : Convert.ToString(dr["ath_user"]);
                    model.ath_pass = (DBNull.Value == dr["ath_pass"]) ? "" : Convert.ToString(dr["ath_pass"]);
                    model.ath_use = (DBNull.Value == dr["ath_use"]) ? "" : Convert.ToString(dr["ath_use"]);
                    model.station_id = (DBNull.Value == dr["station_id"]) ? -1 : Convert.ToInt32(dr["station_id"]);
                    model.createDate = (DBNull.Value == dr["createDate"]) ? DateTime.Now : Convert.ToDateTime(dr["createDate"]);
                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();
            }
            //return list to be displayed
            //validate out of accesscode
            if (cri.StartsWith("where ath_use = 0"))
            {

                if (lists.Count == 0)
                {                   
                    List<ModelAuthenCode> tmpList = Select(" Where station_id=" + station_id, station_id);
                    if (tmpList.Count > 0)
                    {
                        resetAuthenCode(station_id);
                        return Select(cri, station_id);
                    }
                }
            }
            return lists;
        }
        public List<ModelAuthenCode> SelectAllUnUse( int station_id)
        {

            string query = "SELECT * FROM tb_authen_code Where station_id=" + station_id +" and ath_use='0'";

            //Create a list to store the result
            List<ModelAuthenCode> lists = new List<ModelAuthenCode>();

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
                    ModelAuthenCode model = new ModelAuthenCode();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt32(dr["id"]);
                    model.ath_code = (DBNull.Value == dr["ath_code"]) ? "" : Convert.ToString(dr["ath_code"]);
                    model.ath_user = (DBNull.Value == dr["ath_user"]) ? "" : Convert.ToString(dr["ath_user"]);
                    model.ath_pass = (DBNull.Value == dr["ath_pass"]) ? "" : Convert.ToString(dr["ath_pass"]);
                    model.ath_use = (DBNull.Value == dr["ath_use"]) ? "" : Convert.ToString(dr["ath_use"]);
                    model.station_id = (DBNull.Value == dr["station_id"]) ? -1 : Convert.ToInt32(dr["station_id"]);
                    model.createDate = (DBNull.Value == dr["createDate"]) ? DateTime.Now : Convert.ToDateTime(dr["createDate"]);
                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();
            }

            return lists;
        }
        public List<ModelAuthenCode> SelectAutehnPage(String cri, int station_id)
        {

            string query = "SELECT * FROM tb_authen_code " + ((cri.Equals("")) ? " Where station_id=" + station_id : cri + " And station_id=" + station_id);

            //Create a list to store the result
            List<ModelAuthenCode> lists = new List<ModelAuthenCode>();

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
                    ModelAuthenCode model = new ModelAuthenCode();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt32(dr["id"]);
                    model.ath_code = (DBNull.Value == dr["ath_code"]) ? "" : Convert.ToString(dr["ath_code"]);
                    model.ath_user = (DBNull.Value == dr["ath_user"]) ? "" : Convert.ToString(dr["ath_user"]);
                    model.ath_pass = (DBNull.Value == dr["ath_pass"]) ? "" : Convert.ToString(dr["ath_pass"]);
                    model.ath_use = (DBNull.Value == dr["ath_use"]) ? "" : Convert.ToString(dr["ath_use"]);
                    model.station_id = (DBNull.Value == dr["station_id"]) ? -1 : Convert.ToInt32(dr["station_id"]);
                    model.createDate = (DBNull.Value == dr["createDate"]) ? DateTime.Now : Convert.ToDateTime(dr["createDate"]);
                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();
            }
            //return list to be displayed
            //validate out of accesscode
            if (cri.StartsWith("where ath_use = 0"))
            {

                if (lists.Count == 0)
                {
                    List<ModelAuthenCode> tmpList = Select(" Where station_id=" + station_id, station_id);
                    if (tmpList.Count > 0)
                    {
                        resetAuthenCode(station_id);
                        return Select(cri, station_id);
                    }
                }
            }
            return lists;
        }

        public List<ModelAuthenCode> SelectOffine(String cri, int station_id)
        {
            string query = "SELECT * FROM tb_authen_code " + ((cri.Equals("")) ? " Where station_id=" + station_id : cri + " And station_id=" + station_id)+" limit 1";

            //Create a list to store the result
            List<ModelAuthenCode> lists = new List<ModelAuthenCode>();


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
                    ModelAuthenCode model = new ModelAuthenCode();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    model.ath_code = (DBNull.Value == dr["ath_code"]) ? "" : Convert.ToString(dr["ath_code"]);
                    model.ath_user = (DBNull.Value == dr["ath_user"]) ? "" : Convert.ToString(dr["ath_user"]);
                    model.ath_pass = (DBNull.Value == dr["ath_pass"]) ? "" : Convert.ToString(dr["ath_pass"]);
                    model.ath_use = (DBNull.Value == dr["ath_use"]) ? "" : Convert.ToString(dr["ath_use"]);
                    model.station_id = (DBNull.Value == dr["station_id"]) ? -1 : Convert.ToInt32(dr["station_id"]);
                    //model.createDate = (DBNull.Value == dr["createDate"]) ? DateTime.Now : Convert.ToDateTime(dr["createDate"]);
                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();
            }
            //validate out of accesscode
            if (cri.StartsWith("where ath_use = 0"))
            {
                if (lists.Count == 0)
                {
                    List<ModelAuthenCode> tmpList = SelectOffine(" Where station_id=" + station_id, station_id);
                    if (tmpList.Count > 0)
                    {
                        resetAuthenCodeOffine(station_id);
                        return SelectOffine(cri, station_id);
                    }
                }
            }
            return lists;
        }

        public List<ModelAuthenCode> SelectOffineUsedCode(int station_id)
        {
            string query = "SELECT * FROM tb_authen_code Where station_id = " + station_id +" and ath_use=1";

            //Create a list to store the result
            List<ModelAuthenCode> lists = new List<ModelAuthenCode>();


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
                    ModelAuthenCode model = new ModelAuthenCode();
                    model.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]);
                    model.ath_code = (DBNull.Value == dr["ath_code"]) ? "" : Convert.ToString(dr["ath_code"]);
                    model.ath_user = (DBNull.Value == dr["ath_user"]) ? "" : Convert.ToString(dr["ath_user"]);
                    model.ath_pass = (DBNull.Value == dr["ath_pass"]) ? "" : Convert.ToString(dr["ath_pass"]);
                    model.ath_use = (DBNull.Value == dr["ath_use"]) ? "" : Convert.ToString(dr["ath_use"]);
                    model.station_id = (DBNull.Value == dr["station_id"]) ? -1 : Convert.ToInt32(dr["station_id"]);
                    //model.createDate = (DBNull.Value == dr["createDate"]) ? DateTime.Now : Convert.ToDateTime(dr["createDate"]);
                    lists.Add(model);
                }

                //close Data Reader
                dr.Close();
            }
            //validate out of accesscode
            return lists;
        }

        //Insert statement
        public Boolean Insert(ModelAuthenCode model)
        {
            try
            {
                string query = "INSERT INTO tb_authen_code(ath_user,ath_pass,ath_code,createdate,ath_use,station_id) VALUES('" + model.ath_user + "','" + model.ath_pass + "','" + model.ath_code + "',NOW(),0,'"+model.station_id+"')";
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
        public Boolean InsertOffline(ModelAuthenCode model)
        {
            try
            {
                string query = "INSERT INTO tb_authen_code(ath_user,ath_pass,ath_code,createdate,ath_use,station_id) VALUES('" + model.ath_user + "','" + model.ath_pass + "','" + model.ath_code + "','" + DateTime.Now + "',0,'" + model.station_id + "')";
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
        public Boolean Update(ModelAuthenCode model)
        {
            try
            {
                string query = "UPDATE tb_authen_code SET ath_user ='" + model.ath_user + "' ,ath_pass ='" + model.ath_pass + "',ath_use ='" + model.ath_use + "',ath_code='" + model.ath_code + "' WHERE id =" + model.id+" And station_id="+model.station_id;
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
                //Also update used access code to offince
                UpdateOffine(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        public Boolean UpdateByListId(String listAuthIds,int stationId)
        {
            try
            {
                string query = "UPDATE tb_authen_code SET ath_use='1' where ath_code in  ("+ listAuthIds + ")";
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
                //Also update used access code to offince
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        public Boolean UpdateOffine(ModelAuthenCode model)
        {
            try
            {
                string query = "UPDATE tb_authen_code SET ath_user ='" + model.ath_user + "' ,ath_pass ='" + model.ath_pass + "',ath_use ='" + model.ath_use + "',ath_code='" + model.ath_code + "' WHERE id =" + model.id + " And station_id=" + model.station_id;

                using (SQLiteConnection conn = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    conn.Open();
                    //Create Command
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    //Create a data reader and Execute the command
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

        private Boolean resetAuthenCode(int station_id)
        {
            try
            {
                string query = "UPDATE tb_authen_code SET ath_use = '0' Where station_id= "+station_id;
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
        private Boolean resetAuthenCodeOffine(int station_id)
        {
            try
            {
                string query = "UPDATE tb_authen_code SET ath_use = '0' Where station_id="+station_id;
                using (SQLiteConnection conn = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    conn.Open();
                    //Create Command
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
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
        public Boolean Delete(ModelAuthenCode model)
        {
            try
            {
                string query = "DELETE FROM tb_authen_code WHERE id=" + model.id;

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
                logger.Error(ex.InnerException);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public Boolean DeleteBySite(int station_id)
        {
            try
            {
                string query = "DELETE FROM tb_authen_code WHERE station_id=" + station_id;

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
                logger.Error(ex.InnerException);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public Boolean deleteLocalDB()
        {
            try
            {
                string query = "delete from tb_authen_code";
                using (SQLiteConnection conn = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    conn.Open();
                    //Create Command
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
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


    }
}
