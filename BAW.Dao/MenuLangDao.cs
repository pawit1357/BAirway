using System;
using System.Collections.Generic;

using BAW.Model;
using MySql.Data.MySqlClient;
using BAW.Biz;
using System.Collections;

namespace BAW.Dao
{
    public class MenuLangDao
    {
        
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MenuLangDao));

        public const string LANG_EN = "EN";
        public const string LANG_TH = "TH";
        public const string MENU_LOGIN = "LOGIN";

        public MenuLangDao()
        {

        }

        //Select statement
        public Hashtable Select()
        {
            Hashtable ht = new Hashtable();

            string query = "SELECT * FROM tb_menu_lang ";

            //Create a list to store the result
            List<ModelMenuLang> lists = new List<ModelMenuLang>();

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
                    ModelMenuLang modelMenuLang = new ModelMenuLang
                    {
                        id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt16(dr["id"]),
                        menu_name = dr["menu_name"].ToString(),
                        menu_component = dr["menu_component"].ToString(),
                        component_label_th = dr["component_label_th"].ToString(),
                        component_label_en = dr["component_label_en"].ToString()
                    };

                    String key = String.Format("{0}|{1}|TH", modelMenuLang.menu_name, modelMenuLang.menu_component);
                    ht.Add(key, modelMenuLang.component_label_th);
                    key = String.Format("{0}|{1}|EN", modelMenuLang.menu_name, modelMenuLang.menu_component);
                    ht.Add(key, modelMenuLang.component_label_en);

                    lists.Add(modelMenuLang);
                }

                //close Data Reader
                dr.Close();
            }
            //return list to be displayed
            return ht;

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

    }
}
