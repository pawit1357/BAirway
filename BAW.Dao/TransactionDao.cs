using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using BAW.Model;
using BAW.Biz;
using System.Data.SQLite;


namespace BAW.Dao
{
    public class TransactionDao
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(TransactionDao));
        public TransactionDao()
        {

        }

        //Select statement
        public List<ModelTransaction> Select(String cri,int station_id)
        {
            string query =
            "select" +
            "                    t.id, " +
            "                    t.type," +
            "                    t.group_id," +
            "					 g.group_description," +
            "                    t.passenger_name," +
            "                    t.from_city," +
            "                    t.to_city," +
            "                    t.airline_code," +
            "                    t.flight_no," +
            "                    t.date_of_flight," +
            "                    t.seat_no," +
            "                    t.remark," +
            "                    t.remakr2," +
            "                    t.ath_id," +
            "                    t.create_by," +
            "					 u.user_name," +
            "                    t.create_date," +
            "                    t.update_by," +
            "					(select user_name from tb_users where id= t.update_by) update_byName," +
            "                    t.update_date," +
            "                    t.LoungePlace," +
            "					 s.site_name," +
            "					 s.site_code," +
            "                    t.LoungeType," +
            "					 l.lounge_name," +
            "                    t.LoungeArea," +
            "					 a.area_name," +
            "                    t.type," +
            "                    t.duration," +
            "                    t.begin_date" +
            " from tb_transaction_" + station_id + " t " +
            " left join tb_group g on t.group_id = g.id" +
            " left join tb_users u on t.create_by = u.id" +
            " left join tb_station s on t.LoungePlace = s.id" +
            " left join tb_lounge l on t.LoungeType =  l.id" +
            " left join tb_area a on t.LoungeArea = a.id " + cri;
            
            //Create a list to store the result
            List<ModelTransaction> lists = new List<ModelTransaction>();

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
                    ModelTransaction transaction = new ModelTransaction();

                    transaction.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt32(dr["id"]);
                    transaction.group_id =  (DBNull.Value == dr["group_id"]) ? -1 : Convert.ToInt32(dr["group_id"]);
                    transaction.group_idName = (DBNull.Value == dr["group_description"]) ? "" : Convert.ToString(dr["group_description"]);
                    transaction.passenger_name = (DBNull.Value == dr["passenger_name"]) ? "" : Convert.ToString(dr["passenger_name"]);
                    transaction.from_city = (DBNull.Value == dr["from_city"]) ? "" : Convert.ToString(dr["from_city"]);
                    transaction.to_city = (DBNull.Value == dr["to_city"]) ? "" : Convert.ToString(dr["to_city"]);
                    transaction.airline_code = (DBNull.Value == dr["airline_code"]) ? "" : Convert.ToString(dr["airline_code"]);
                    transaction.flight_no = (DBNull.Value == dr["flight_no"]) ? "" : Convert.ToString(dr["flight_no"]);
                    transaction.date_of_flight = Convert.ToDateTime(dr["date_of_flight"]);
                    transaction.date_of_flight_custom = transaction.date_of_flight.ToString("dd-MM-yyyy HH:mm");
                    transaction.seat_no = (DBNull.Value == dr["seat_no"]) ? "" : Convert.ToString(dr["seat_no"]);
                    transaction.remark = (DBNull.Value == dr["remark"]) ? "" : Convert.ToString(dr["remark"]);
                    transaction.remakr2 = (DBNull.Value == dr["remakr2"]) ? "" : Convert.ToString(dr["remakr2"]);
                    transaction.ath_id = (DBNull.Value == dr["ath_id"]) ? "" : Convert.ToString(dr["ath_id"]);
                    transaction.create_by = (DBNull.Value == dr["create_by"]) ? -1 : Convert.ToInt32(dr["create_by"]);
                    transaction.create_byName = (DBNull.Value == dr["user_name"]) ? "" : Convert.ToString(dr["user_name"]);
                    transaction.create_date = Convert.ToDateTime(dr["create_date"]);
                    transaction.create_date_custom = transaction.create_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.update_by = (DBNull.Value == dr["update_by"]) ? -1 : Convert.ToInt32(dr["update_by"]);
                    transaction.update_byName = (DBNull.Value == dr["update_byName"]) ? "" : Convert.ToString(dr["update_byName"]);
                    transaction.update_date = Convert.ToDateTime(dr["update_date"]);
                    transaction.update_date_custom = transaction.update_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.LoungePlace = (DBNull.Value == dr["LoungePlace"]) ? -1 : Convert.ToInt32(dr["LoungePlace"]);
                    transaction.LoungeSiteCode = (DBNull.Value == dr["site_code"]) ? "" : Convert.ToString(dr["site_code"]);      
                    transaction.LoungeSite = (DBNull.Value == dr["site_name"]) ? "" : Convert.ToString(dr["site_name"]);
                    transaction.LoungeType = (DBNull.Value == dr["LoungeType"]) ? -1 : Convert.ToInt32(dr["LoungeType"]);
                    transaction.LoungeName = (DBNull.Value == dr["lounge_name"]) ? "" : Convert.ToString(dr["lounge_name"]);
                    transaction.LoungeArea = (DBNull.Value == dr["LoungeArea"]) ? -1 : Convert.ToInt32(dr["LoungeArea"]);
                    transaction.LoungeAreaName = (DBNull.Value == dr["area_name"]) ? "" : Convert.ToString(dr["area_name"]);
                    transaction.type = (DBNull.Value == dr["type"]) ? "" : Convert.ToString(dr["type"]);
                    transaction.duration = (DBNull.Value == dr["duration"]) ? -1 : Convert.ToInt32(dr["duration"]);
                    transaction.begin_date = Convert.ToDateTime(dr["begin_date"]);
                    transaction.begin_date_custom = transaction.begin_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.status = "ACTIVE";
                    lists.Add(transaction);
                }

                //close Data Reader
                dr.Close();
            }

            //return list to be displayed
            return lists;

        }


        public List<ModelTransaction> Select61(String cri, int station_id)
        {
            string query =
            "select" +
            "                    t.id, " +
            "                    t.type," +
            "                    t.group_id," +
            "					 g.group_description," +
            "                    t.passenger_name," +
            "                    t.from_city," +
            "                    t.to_city," +
            "                    t.airline_code," +
            "                    t.flight_no," +
            "                    t.date_of_flight," +
            "                    t.seat_no," +
            "                    t.remark," +
            "                    t.remakr2," +
            "                    t.ath_id," +
            "                    t.create_by," +
            "					 u.user_name," +
            "                    t.create_date," +
            "                    t.update_by," +
            "					(select user_name from tb_users where id= t.update_by) update_byName," +
            "                    t.update_date," +
            "                    t.LoungePlace," +
            "					 s.site_name," +
            "					 s.site_code," +
            "                    t.LoungeType," +
            "					 l.lounge_name," +
            "                    t.LoungeArea," +
            "					 a.area_name," +
            "                    t.type," +
            "                    t.duration," +
            "                    t.begin_date" +
            " from tb_transaction_" + station_id + " t " +
            " left join tb_group g on t.group_id = g.id" +
            " left join tb_users u on t.create_by = u.id" +
            " left join tb_station s on t.LoungePlace = s.id" +
            " left join tb_lounge l on t.LoungeType =  l.id" +
            " left join tb_area a on t.LoungeArea = a.id " + cri;

            //Create a list to store the result
            List<ModelTransaction> lists = new List<ModelTransaction>();

            using (MySqlConnection connection = new MySqlConnection("SERVER=61.19.64.10;DATABASE=authencodedb;UID=root;PASSWORD=sp7GuZan;"))
            {
                connection.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dr = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dr.Read())
                {
                    ModelTransaction transaction = new ModelTransaction();

                    transaction.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt32(dr["id"]);
                    transaction.group_id = (DBNull.Value == dr["group_id"]) ? -1 : Convert.ToInt32(dr["group_id"]);
                    transaction.group_idName = (DBNull.Value == dr["group_description"]) ? "" : Convert.ToString(dr["group_description"]);
                    transaction.passenger_name = (DBNull.Value == dr["passenger_name"]) ? "" : Convert.ToString(dr["passenger_name"]);
                    transaction.from_city = (DBNull.Value == dr["from_city"]) ? "" : Convert.ToString(dr["from_city"]);
                    transaction.to_city = (DBNull.Value == dr["to_city"]) ? "" : Convert.ToString(dr["to_city"]);
                    transaction.airline_code = (DBNull.Value == dr["airline_code"]) ? "" : Convert.ToString(dr["airline_code"]);
                    transaction.flight_no = (DBNull.Value == dr["flight_no"]) ? "" : Convert.ToString(dr["flight_no"]);
                    transaction.date_of_flight = Convert.ToDateTime(dr["date_of_flight"]);
                    transaction.date_of_flight_custom = transaction.date_of_flight.ToString("dd-MM-yyyy HH:mm");
                    transaction.seat_no = (DBNull.Value == dr["seat_no"]) ? "" : Convert.ToString(dr["seat_no"]);
                    transaction.remark = (DBNull.Value == dr["remark"]) ? "" : Convert.ToString(dr["remark"]);
                    transaction.remakr2 = (DBNull.Value == dr["remakr2"]) ? "" : Convert.ToString(dr["remakr2"]);
                    transaction.ath_id = (DBNull.Value == dr["ath_id"]) ? "" : Convert.ToString(dr["ath_id"]);
                    transaction.create_by = (DBNull.Value == dr["create_by"]) ? -1 : Convert.ToInt32(dr["create_by"]);
                    transaction.create_byName = (DBNull.Value == dr["user_name"]) ? "" : Convert.ToString(dr["user_name"]);
                    transaction.create_date = Convert.ToDateTime(dr["create_date"]);
                    transaction.create_date_custom = transaction.create_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.update_by = (DBNull.Value == dr["update_by"]) ? -1 : Convert.ToInt32(dr["update_by"]);
                    transaction.update_byName = (DBNull.Value == dr["update_byName"]) ? "" : Convert.ToString(dr["update_byName"]);
                    transaction.update_date = Convert.ToDateTime(dr["update_date"]);
                    transaction.update_date_custom = transaction.update_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.LoungePlace = (DBNull.Value == dr["LoungePlace"]) ? -1 : Convert.ToInt32(dr["LoungePlace"]);
                    transaction.LoungeSiteCode = (DBNull.Value == dr["site_code"]) ? "" : Convert.ToString(dr["site_code"]);
                    transaction.LoungeSite = (DBNull.Value == dr["site_name"]) ? "" : Convert.ToString(dr["site_name"]);
                    transaction.LoungeType = (DBNull.Value == dr["LoungeType"]) ? -1 : Convert.ToInt32(dr["LoungeType"]);
                    transaction.LoungeName = (DBNull.Value == dr["lounge_name"]) ? "" : Convert.ToString(dr["lounge_name"]);
                    transaction.LoungeArea = (DBNull.Value == dr["LoungeArea"]) ? -1 : Convert.ToInt32(dr["LoungeArea"]);
                    transaction.LoungeAreaName = (DBNull.Value == dr["area_name"]) ? "" : Convert.ToString(dr["area_name"]);
                    transaction.type = (DBNull.Value == dr["type"]) ? "" : Convert.ToString(dr["type"]);
                    transaction.duration = (DBNull.Value == dr["duration"]) ? -1 : Convert.ToInt32(dr["duration"]);
                    transaction.begin_date = Convert.ToDateTime(dr["begin_date"]);
                    transaction.begin_date_custom = transaction.begin_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.status = "ACTIVE";
                    lists.Add(transaction);
                }

                //close Data Reader
                dr.Close();
            }

            //return list to be displayed
            return lists;

        }
        //Select statement
        //
        // for get data in transaction (before seprerate talbe)
        //
        public List<ModelTransaction> SelectAdhoc(String cri, int station_id)
        {
            string query =
            "select" +
            "                    t.id, " +
            "                    t.type," +
            "                    t.group_id," +
            "					 g.group_description," +
            "                    t.passenger_name," +
            "                    t.from_city," +
            "                    t.to_city," +
            "                    t.airline_code," +
            "                    t.flight_no," +
            "                    t.date_of_flight," +
            "                    t.seat_no," +
            "                    t.remark," +
            "                    t.remakr2," +
            "                    t.ath_id," +
            "                    t.create_by," +
            "					 u.user_name," +
            "                    t.create_date," +
            "                    t.update_by," +
            "					(select user_name from tb_users where id= t.update_by) update_byName," +
            "                    t.update_date," +
            "                    t.LoungePlace," +
            "					 s.site_name," +
            "					 s.site_code," +
            "                    t.LoungeType," +
            "					 l.lounge_name," +
            "                    t.LoungeArea," +
            "					 a.area_name," +
            "                    t.type," +
            "                    t.duration," +
            "                    t.begin_date" +
            " from tb_transaction t " +
            " left join tb_group g on t.group_id = g.id" +
            " left join tb_users u on t.create_by = u.id" +
            " left join tb_station s on t.LoungePlace = s.id" +
            " left join tb_lounge l on t.LoungeType =  l.id" +
            " left join tb_area a on t.LoungeArea = a.id " + cri;

            //Create a list to store the result
            List<ModelTransaction> lists = new List<ModelTransaction>();

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
                    ModelTransaction transaction = new ModelTransaction();

                    transaction.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt32(dr["id"]);
                    transaction.group_id = (DBNull.Value == dr["group_id"]) ? -1 : Convert.ToInt32(dr["group_id"]);
                    transaction.group_idName = (DBNull.Value == dr["group_description"]) ? "" : Convert.ToString(dr["group_description"]);
                    transaction.passenger_name = (DBNull.Value == dr["passenger_name"]) ? "" : Convert.ToString(dr["passenger_name"]);
                    transaction.from_city = (DBNull.Value == dr["from_city"]) ? "" : Convert.ToString(dr["from_city"]);
                    transaction.to_city = (DBNull.Value == dr["to_city"]) ? "" : Convert.ToString(dr["to_city"]);
                    transaction.airline_code = (DBNull.Value == dr["airline_code"]) ? "" : Convert.ToString(dr["airline_code"]);
                    transaction.flight_no = (DBNull.Value == dr["flight_no"]) ? "" : Convert.ToString(dr["flight_no"]);
                    transaction.date_of_flight = Convert.ToDateTime(dr["date_of_flight"]);
                    transaction.date_of_flight_custom = transaction.date_of_flight.ToString("dd-MM-yyyy HH:mm");
                    transaction.seat_no = (DBNull.Value == dr["seat_no"]) ? "" : Convert.ToString(dr["seat_no"]);
                    transaction.remark = (DBNull.Value == dr["remark"]) ? "" : Convert.ToString(dr["remark"]);
                    transaction.remakr2 = (DBNull.Value == dr["remakr2"]) ? "" : Convert.ToString(dr["remakr2"]);
                    transaction.ath_id = (DBNull.Value == dr["ath_id"]) ? "" : Convert.ToString(dr["ath_id"]);
                    transaction.create_by = (DBNull.Value == dr["create_by"]) ? -1 : Convert.ToInt32(dr["create_by"]);
                    transaction.create_byName = (DBNull.Value == dr["user_name"]) ? "" : Convert.ToString(dr["user_name"]);
                    transaction.create_date = Convert.ToDateTime(dr["create_date"]);
                    transaction.create_date_custom = transaction.create_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.update_by = (DBNull.Value == dr["update_by"]) ? -1 : Convert.ToInt32(dr["update_by"]);
                    transaction.update_byName = (DBNull.Value == dr["update_byName"]) ? "" : Convert.ToString(dr["update_byName"]);
                    transaction.update_date = Convert.ToDateTime(dr["update_date"]);
                    transaction.update_date_custom = transaction.update_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.LoungePlace = (DBNull.Value == dr["LoungePlace"]) ? -1 : Convert.ToInt32(dr["LoungePlace"]);
                    transaction.LoungeSiteCode = (DBNull.Value == dr["site_code"]) ? "" : Convert.ToString(dr["site_code"]);                    
                    transaction.LoungeSite = (DBNull.Value == dr["site_name"]) ? "" : Convert.ToString(dr["site_name"]);
                    transaction.LoungeType = (DBNull.Value == dr["LoungeType"]) ? -1 : Convert.ToInt32(dr["LoungeType"]);
                    transaction.LoungeName = (DBNull.Value == dr["lounge_name"]) ? "" : Convert.ToString(dr["lounge_name"]);
                    transaction.LoungeArea = (DBNull.Value == dr["LoungeArea"]) ? -1 : Convert.ToInt32(dr["LoungeArea"]);
                    transaction.LoungeAreaName = (DBNull.Value == dr["area_name"]) ? "" : Convert.ToString(dr["area_name"]);
                    transaction.type = (DBNull.Value == dr["type"]) ? "" : Convert.ToString(dr["type"]);
                    transaction.duration = (DBNull.Value == dr["duration"]) ? -1 : Convert.ToInt32(dr["duration"]);
                    transaction.begin_date = Convert.ToDateTime(dr["begin_date"]);
                    transaction.begin_date_custom = transaction.begin_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.status = "ACTIVE";
                    lists.Add(transaction);
                }

                //close Data Reader
                dr.Close();
            }

            //return list to be displayed
            return lists;

        }
        public List<ModelTransaction> SelectOffine(String cri, int station_id)
        {
            string query =
            "select" +
            "                    t.id, " +
            "                    t.type," +
            "                    t.group_id," +
            "					 g.group_description," +
            "                    t.passenger_name," +
            "                    t.from_city," +
            "                    t.to_city," +
            "                    t.airline_code," +
            "                    t.flight_no," +
            "                    t.date_of_flight," +
            "                    t.seat_no," +
            "                    t.remark," +
            "                    t.remakr2," +
            "                    t.ath_id," +
            "                    t.create_by," +
            "					 u.user_name," +
            "                    t.create_date," +
            "                    t.update_by," +
            "					(select user_name from tb_users where id= t.update_by) update_byName," +
            "                    t.update_date," +
            "                    t.LoungePlace," +
            "					 s.site_name," +
            "					 s.site_code," +
            "                    t.LoungeType," +
            "					 l.lounge_name," +
            "                    t.LoungeArea," +
            "					 a.area_name," +
            "                    t.type," +
            "                    t.duration," +
            "                    t.begin_date" +
            " from tb_transaction_" + station_id + " t " +
            " left join tb_group g on t.group_id = g.id" +
            " left join tb_users u on t.create_by = u.id" +
            " left join tb_station s on t.LoungePlace = s.id" +
            " left join tb_lounge l on t.LoungeType =  l.id" +
            " left join tb_area a on t.LoungeArea = a.id " + cri;

            //Create a list to store the result
            List<ModelTransaction> lists = new List<ModelTransaction>();

            using (SQLiteConnection conn = new SQLiteConnection(Configurations.SqLiteStr))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                //Create a data reader and Execute the command
                SQLiteDataReader dr = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dr.Read())
                {
                    ModelTransaction transaction = new ModelTransaction();

                    transaction.id = (DBNull.Value == dr["id"]) ? -1 : Convert.ToInt32(dr["id"]);
                    transaction.group_id = (DBNull.Value == dr["group_id"]) ? -1 : Convert.ToInt32(dr["group_id"]);
                    transaction.group_idName = (DBNull.Value == dr["group_description"]) ? "" : Convert.ToString(dr["group_description"]);
                    transaction.passenger_name = (DBNull.Value == dr["passenger_name"]) ? "" : Convert.ToString(dr["passenger_name"]);
                    transaction.from_city = (DBNull.Value == dr["from_city"]) ? "" : Convert.ToString(dr["from_city"]);
                    transaction.to_city = (DBNull.Value == dr["to_city"]) ? "" : Convert.ToString(dr["to_city"]);
                    transaction.airline_code = (DBNull.Value == dr["airline_code"]) ? "" : Convert.ToString(dr["airline_code"]);
                    transaction.flight_no = (DBNull.Value == dr["flight_no"]) ? "" : Convert.ToString(dr["flight_no"]);
                    transaction.date_of_flight = Convert.ToDateTime(dr["date_of_flight"]);
                    transaction.date_of_flight_custom = transaction.date_of_flight.ToString("dd-MM-yyyy HH:mm");
                    transaction.seat_no = (DBNull.Value == dr["seat_no"]) ? "" : Convert.ToString(dr["seat_no"]);
                    transaction.remark = (DBNull.Value == dr["remark"]) ? "" : Convert.ToString(dr["remark"]);
                    transaction.remakr2 = (DBNull.Value == dr["remakr2"]) ? "" : Convert.ToString(dr["remakr2"]);
                    transaction.ath_id = (DBNull.Value == dr["ath_id"]) ? "" : Convert.ToString(dr["ath_id"]);
                    transaction.create_by = (DBNull.Value == dr["create_by"]) ? -1 : Convert.ToInt32(dr["create_by"]);
                    transaction.create_byName = (DBNull.Value == dr["user_name"]) ? "" : Convert.ToString(dr["user_name"]);
                    transaction.create_date = Convert.ToDateTime(dr["create_date"]);
                    transaction.create_date_custom = transaction.create_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.update_by = (DBNull.Value == dr["update_by"]) ? -1 : Convert.ToInt32(dr["update_by"]);
                    transaction.update_byName = (DBNull.Value == dr["update_byName"]) ? "" : Convert.ToString(dr["update_byName"]);
                    transaction.update_date = Convert.ToDateTime(dr["update_date"]);
                    transaction.update_date_custom = transaction.update_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.LoungePlace = (DBNull.Value == dr["LoungePlace"]) ? -1 : Convert.ToInt32(dr["LoungePlace"]);
                    transaction.LoungeSite = (DBNull.Value == dr["site_name"]) ? "" : Convert.ToString(dr["site_name"]);
                    transaction.LoungeSiteCode = (DBNull.Value == dr["site_code"]) ? "" : Convert.ToString(dr["site_code"]);     
                    transaction.LoungeType = (DBNull.Value == dr["LoungeType"]) ? -1 : Convert.ToInt32(dr["LoungeType"]);
                    transaction.LoungeName = (DBNull.Value == dr["lounge_name"]) ? "" : Convert.ToString(dr["lounge_name"]);
                    transaction.LoungeArea = (DBNull.Value == dr["LoungeArea"]) ? -1 : Convert.ToInt32(dr["LoungeArea"]);
                    transaction.LoungeAreaName = (DBNull.Value == dr["area_name"]) ? "" : Convert.ToString(dr["area_name"]);
                    transaction.type = (DBNull.Value == dr["type"]) ? "" : Convert.ToString(dr["type"]);
                    transaction.duration = (DBNull.Value == dr["duration"]) ? -1 : Convert.ToInt32(dr["duration"]);
                    transaction.begin_date = Convert.ToDateTime(dr["begin_date"]);
                    transaction.begin_date_custom = transaction.begin_date.ToString("dd-MM-yyyy HH:mm");
                    transaction.status = "ACTIVE";
                    lists.Add(transaction);
                }

                //close Data Reader
                dr.Close();
            }
                return lists;            
        }
        //Insert statement
        public Boolean Insert(ModelTransaction model, int station_id)
        {
            try
            {
                string query =
                "INSERT INTO tb_transaction_" + station_id + "" +
                "(boardingpass," +
                "group_id," +
                "passenger_name," +
                "from_city," +
                "to_city," +
                "airline_code," +
                "flight_no," +
                "date_of_flight," +
                "seat_no," +
                "remark," +
                "remakr2," +
                "ath_id," +

                "create_by," +
                "create_date," +
                "update_by," +
                "update_date," +
                "LoungePlace," +
                "LoungeType," +
                "LoungeArea," +

                "type," +
                "duration," +
                "begin_date," +
                "status" +
                ")" +
                " VALUES" +
                "(" +
                "@boardingpass," +
                "@group_id," +
                "@passenger_name," +
                "@from_city," +
                "@to_city," +
                "@airline_code," +
                "@flight_no," +
                "@date_of_flight," +
                "@seat_no," +
                "@remark," +
                "@remakr2," +
                "@ath_id," +

                "@create_by," +
                "@create_date," +
                "@update_by," +
                "@update_date," +
                "@LoungePlace," +
                "@LoungeType," +
                "@LoungeArea," +

                "@type," +
                "@duration," +
                "@begin_date," +
                "@status" +
                ");";

                using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
                {
                    connection.Open();
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //cmd.Parameters.AddWithValue("@id", model.id);
                    cmd.Parameters.AddWithValue("@boardingpass", model.boardingpass);
                    cmd.Parameters.AddWithValue("@group_id", model.group_id);
                    cmd.Parameters.AddWithValue("@passenger_name", model.passenger_name);
                    cmd.Parameters.AddWithValue("@from_city", model.from_city);
                    cmd.Parameters.AddWithValue("@to_city", model.to_city);
                    cmd.Parameters.AddWithValue("@airline_code", model.airline_code);
                    cmd.Parameters.AddWithValue("@flight_no", model.flight_no);
                    cmd.Parameters.AddWithValue("@date_of_flight", model.date_of_flight.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@seat_no", model.seat_no);
                    cmd.Parameters.AddWithValue("@remark", model.remark);
                    cmd.Parameters.AddWithValue("@remakr2", model.remakr2);
                    cmd.Parameters.AddWithValue("@ath_id", model.ath_id);


                    cmd.Parameters.AddWithValue("@create_by", model.create_by);
                    cmd.Parameters.AddWithValue("@create_date", model.create_date.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@update_by", model.update_by);
                    cmd.Parameters.AddWithValue("@update_date", model.update_date.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@LoungePlace", model.LoungePlace);
                    cmd.Parameters.AddWithValue("@LoungeType", model.LoungeType);
                    cmd.Parameters.AddWithValue("@LoungeArea", model.LoungeArea);
                    cmd.Parameters.AddWithValue("@type", model.type);
                    cmd.Parameters.AddWithValue("@duration", model.duration);
                    cmd.Parameters.AddWithValue("@begin_date", model.begin_date.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@status", model.status);


                    //Execute command
                    int result = cmd.ExecuteNonQuery();

                    string logSql =
                                   "INSERT INTO tb_transaction_" + station_id + "" +
                                   "(boardingpass," +
                                   "group_id," +
                                   "passenger_name," +
                                   "from_city," +
                                   "to_city," +
                                   "airline_code," +
                                   "flight_no," +
                                   "date_of_flight," +
                                   "seat_no," +
                                   "remark," +
                                   "remakr2," +
                                   "ath_id," +

                                   "create_by," +
                                   "create_date," +
                                   "update_by," +
                                   "update_date," +
                                   "LoungePlace," +
                                   "LoungeType," +
                                   "LoungeArea," +

                                   "type," +
                                   "duration," +
                                   "begin_date," +
                                   "status" +
                                   ")" +
                                   " VALUES" +
                                   "(" +
                                   "'{0}'," +
                                   "'{1}'," +
                                   "'{2}'," +
                                   "'{3}'," +
                                   "'{4}'," +
                                   "'{5}'," +
                                   "'{6}'," +
                                   "'{7}'," +
                                   "'{8}'," +
                                   "'{9}'," +
                                   "'{10}'," +
                                   "'{11}'," +

                                   "'{12}'," +
                                   "'{13}'," +
                                   "'{14}'," +
                                   "'{15}'," +
                                   "'{16}'," +
                                   "'{17}'," +
                                   "'{18}'," +

                                   "'{19}'," +
                                   "'{20}'," +
                                   "'{21}'," +
                                   "'{22}'" +
                                                    ");";

                    logger.Debug("SQL:" + String.Format(logSql, model.boardingpass, model.group_id, model.passenger_name, model.from_city, model.to_city, model.airline_code, model.flight_no, model.date_of_flight.ToString("yyyy-MM-dd HH:mm:ss"), model.seat_no, model.remark, model.remakr2, model.ath_id, model.create_by,model.create_date.ToString("yyyy-MM-dd HH:mm:ss"), model.update_by, model.update_date.ToString("yyyy-MM-dd HH:mm:ss"), model.LoungePlace, model.LoungeType, model.LoungeArea, model.type, model.duration, model.begin_date.ToString("yyyy-MM-dd HH:mm:ss"), model.status));
                }
              
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                return false;
            }
            return true;
        }

        public Boolean InsertOffine(ModelTransaction model, int station_id)
        {
            try
            {
                string query =
                "INSERT INTO tb_transaction_" + station_id + "" +
                "(" +
                "group_id,boardingpass," +
                "passenger_name," +
                "from_city," +
                "to_city," +
                "airline_code," +
                "flight_no," +
                "date_of_flight," +
                "seat_no," +
                "remark," +
                "remakr2," +
                "ath_id," +

                "create_by," +
                "create_date," +
                "update_by," +
                "update_date," +
                "LoungePlace," +
                "LoungeType," +
                "LoungeArea," +

                "type," +
                "duration," +
                "begin_date," +
                "status" +
                ")" +
                " VALUES" +
                "(" +
                //"@id," +
                "@group_id,@boardingpass," +
                "@passenger_name," +
                "@from_city," +
                "@to_city," +
                "@airline_code," +
                "@flight_no," +
                "@date_of_flight," +
                "@seat_no," +
                "@remark," +
                "@remakr2," +
                "@ath_id," +

                "@create_by," +
                "@create_date," +
                "@update_by," +
                "@update_date," +
                "@LoungePlace," +
                "@LoungeType," +
                "@LoungeArea," +

                "@type," +
                "@duration," +
                "@begin_date," +
                "@status" +
                ");";

                using (SQLiteConnection conn = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    conn.Open();
                    //create command and assign the query and connection from the constructor
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);

                    //cmd.Parameters.AddWithValue("@id", model.id);
                    cmd.Parameters.AddWithValue("@boardingpass", model.boardingpass);
                    cmd.Parameters.AddWithValue("@group_id", model.group_id);
                    cmd.Parameters.AddWithValue("@passenger_name", model.passenger_name);
                    cmd.Parameters.AddWithValue("@from_city", model.from_city);
                    cmd.Parameters.AddWithValue("@to_city", model.to_city);
                    cmd.Parameters.AddWithValue("@airline_code", model.airline_code);
                    cmd.Parameters.AddWithValue("@flight_no", model.flight_no);
                    cmd.Parameters.AddWithValue("@date_of_flight", model.date_of_flight.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@seat_no", model.seat_no);
                    cmd.Parameters.AddWithValue("@remark", model.remark);
                    cmd.Parameters.AddWithValue("@remakr2", model.remakr2);
                    cmd.Parameters.AddWithValue("@ath_id", model.ath_id);


                    cmd.Parameters.AddWithValue("@create_by", model.create_by);
                    cmd.Parameters.AddWithValue("@create_date", model.create_date.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@update_by", model.update_by);
                    cmd.Parameters.AddWithValue("@update_date", model.update_date.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@LoungePlace", model.LoungePlace);
                    cmd.Parameters.AddWithValue("@LoungeType", model.LoungeType);
                    cmd.Parameters.AddWithValue("@LoungeArea", model.LoungeArea);
                    cmd.Parameters.AddWithValue("@type", model.type);
                    cmd.Parameters.AddWithValue("@duration", model.duration);
                    cmd.Parameters.AddWithValue("@begin_date", model.begin_date.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@status", model.status);


                    //Execute command
                    int result = cmd.ExecuteNonQuery();
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
        public Boolean Update(ModelTransaction model, int station_id)
        {
            try
            {
                string query =
                            "UPDATE tb_transaction_" + station_id + "" +
                            " SET" +
                            " group_id = @group_id," +
                            "passenger_name = @passenger_name," +
                            "from_city = @from_city," +
                            "to_city = @to_city," +
                            "airline_code = @airline_code," +
                            "flight_no = @flight_no," +
                            "date_of_flight = @date_of_flight," +
                            "seat_no = @seat_no," +
                            "remark = @remark," +
                            "remakr2 = @remakr2," +
                            "ath_id = @ath_id," +

                            "update_by = @update_by," +
                            "update_date = @update_date," +
                            "LoungePlace = @LoungePlace," +
                            "LoungeType = @LoungeType," +
                            "LoungeArea = @LoungeArea," +
                            "type = @type," +
                            "duration = @duration," +
                            "begin_date = @begin_date," +
                            "status = @status " +
                            "WHERE id = @id;";
                using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
                {
                    connection.Open();
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Parameters.AddWithValue("@id", model.id);
                    cmd.Parameters.AddWithValue("@group_id", model.group_id);
                    cmd.Parameters.AddWithValue("@passenger_name", model.passenger_name);
                    cmd.Parameters.AddWithValue("@from_city", model.from_city);
                    cmd.Parameters.AddWithValue("@to_city", model.to_city);
                    cmd.Parameters.AddWithValue("@airline_code", model.airline_code);
                    cmd.Parameters.AddWithValue("@flight_no", model.flight_no);
                    cmd.Parameters.AddWithValue("@date_of_flight", model.date_of_flight);
                    cmd.Parameters.AddWithValue("@seat_no", model.seat_no);
                    cmd.Parameters.AddWithValue("@remark", model.remark);
                    cmd.Parameters.AddWithValue("@remakr2", model.remakr2);
                    cmd.Parameters.AddWithValue("@ath_id", model.ath_id);

                    cmd.Parameters.AddWithValue("@create_by", model.create_by);
                    cmd.Parameters.AddWithValue("@create_date", model.create_date);
                    cmd.Parameters.AddWithValue("@update_by", model.update_by);
                    cmd.Parameters.AddWithValue("@update_date", model.update_date);
                    cmd.Parameters.AddWithValue("@LoungePlace", model.LoungePlace);
                    cmd.Parameters.AddWithValue("@LoungeType", model.LoungeType);
                    cmd.Parameters.AddWithValue("@LoungeArea", model.LoungeArea);
                    cmd.Parameters.AddWithValue("@type", model.type);
                    cmd.Parameters.AddWithValue("@duration", model.duration);
                    cmd.Parameters.AddWithValue("@begin_date", model.begin_date);
                    cmd.Parameters.AddWithValue("@status", model.status);

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
        public Boolean UpdateBeginDate(ModelTransaction model, int station_id)
        {
            try
            {
                string query =
                            "UPDATE tb_transaction_" + station_id + "" +
                            " SET" +
                            " begin_date = @begin_date" +
                            " WHERE id = @id;";
                using (MySqlConnection connection = new MySqlConnection(Configurations.MysqlStr))
                {
                    connection.Open();
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Parameters.AddWithValue("@id", model.id);
                    cmd.Parameters.AddWithValue("@begin_date", model.begin_date);

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
                logger.Error("Update begin date fail::"+ex.InnerException);
                return false;
            }
            return true;
        }
        public Boolean UpdateOffline(ModelTransaction model, int station_id)
        {
            try
            {
                string query =
                            "UPDATE tb_transaction_" + station_id + "" +
                            " SET" +
                            " group_id = @group_id," +
                            "passenger_name = @passenger_name," +
                            "from_city = @from_city," +
                            "to_city = @to_city," +
                            "airline_code = @airline_code," +
                            "flight_no = @flight_no," +
                            "date_of_flight = @date_of_flight," +
                            "seat_no = @seat_no," +
                            "remark = @remark," +
                            "remakr2 = @remakr2," +
                            "ath_id = @ath_id," +

                            "update_by = @update_by," +
                            "update_date = @update_date," +
                            "LoungePlace = @LoungePlace," +
                            "LoungeType = @LoungeType," +
                            "LoungeArea = @LoungeArea," +
                            "type = @type," +
                            "duration = @duration," +
                            "begin_date = @begin_date," +
                            "status = @status " +
                            "WHERE id = @id;";
                using (SQLiteConnection conn = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    conn.Open();
                    //create command and assign the query and connection from the constructor
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", model.id);
                    cmd.Parameters.AddWithValue("@group_id", model.group_id);
                    cmd.Parameters.AddWithValue("@passenger_name", model.passenger_name);
                    cmd.Parameters.AddWithValue("@from_city", model.from_city);
                    cmd.Parameters.AddWithValue("@to_city", model.to_city);
                    cmd.Parameters.AddWithValue("@airline_code", model.airline_code);
                    cmd.Parameters.AddWithValue("@flight_no", model.flight_no);
                    cmd.Parameters.AddWithValue("@date_of_flight", model.date_of_flight);
                    cmd.Parameters.AddWithValue("@seat_no", model.seat_no);
                    cmd.Parameters.AddWithValue("@remark", model.remark);
                    cmd.Parameters.AddWithValue("@remakr2", model.remakr2);
                    cmd.Parameters.AddWithValue("@ath_id", model.ath_id);

                    cmd.Parameters.AddWithValue("@create_by", model.create_by);
                    cmd.Parameters.AddWithValue("@create_date", model.create_date);
                    cmd.Parameters.AddWithValue("@update_by", model.update_by);
                    cmd.Parameters.AddWithValue("@update_date", model.update_date);
                    cmd.Parameters.AddWithValue("@LoungePlace", model.LoungePlace);
                    cmd.Parameters.AddWithValue("@LoungeType", model.LoungeType);
                    cmd.Parameters.AddWithValue("@LoungeArea", model.LoungeArea);
                    cmd.Parameters.AddWithValue("@type", model.type);
                    cmd.Parameters.AddWithValue("@duration", model.duration);
                    cmd.Parameters.AddWithValue("@begin_date", model.begin_date);
                    cmd.Parameters.AddWithValue("@status", model.status);

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
        public Boolean Delete(ModelTransaction model, int station_id)
        {
            try
            {
                string query = "DELETE FROM tb_transaction_" + station_id + " WHERE id=" + model.id;
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

        public Boolean DeleteOffline(ModelTransaction model, int station_id)
        {
            try
            {
                string query = "DELETE FROM tb_transaction_" + station_id + " WHERE id=" + model.id;


                using (SQLiteConnection conn = new SQLiteConnection(Configurations.SqLiteStr))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
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
        //public int getMaxId()
        //{
        //    int result = 0;
        //    List<ModelTransaction> lists = Select(" order by id desc");
        //    if (lists != null)
        //    {
        //        if (lists.Count > 0)
        //        {
        //            result = lists[0].id + 1;
        //        }
        //    }
        //    return result;
        //}

        public List<DateTime> GetDateDistinct()
        {
            string query = "SELECT distinct(date(create_date)) as create_date FROM authencodedb.tb_transaction_7 order by create_date asc";

            //Create a list to store the result
            List<DateTime> lists = new List<DateTime>();

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
                    ModelTransaction transaction = new ModelTransaction();


                    DateTime dt = Convert.ToDateTime(dr["create_date"]);

                    lists.Add(dt);
                }

                //close Data Reader
                dr.Close();
            }

            //return list to be displayed
            return lists;

        }

    }
}



