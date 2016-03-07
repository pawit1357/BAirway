using BAW.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string xxx = CustomUtils.RemoveSpecialCharacters("pawitวงวงวงงว;;วงงววงงวมมมม,,,,,,,sae-eaungฟกดห,:32321!@@#$@$#$%%^$%&%^$");
            Console.WriteLine(xxx);
            //int counter = 0;
            //string line;

            //// Read the file and display it line by line.
            //System.IO.StreamReader file =
            //   new System.IO.StreamReader(@"C:\Users\pawit\Downloads\muic_query.txt");
            //while ((line = file.ReadLine()) != null)
            //{
            //    if (!line.Equals(String.Empty))
            //    {
            //        Insert2SQLite(line);
            //        Console.WriteLine(line);
            //    }
            //    counter++;
            //}

            //file.Close();

            //// Suspend the screen.
            //Console.ReadLine();
        }


        public static string deCode(string data)
        {
            byte[] bt = System.Convert.FromBase64String(data);
            return System.Text.Encoding.ASCII.GetString(bt);
        }


        public Boolean Insert2SQLite(String query)
        {
            bool result = false;
            try
            {
                Console.Write(query);
                //string query = "INSERT INTO tb_authen_code(ath_user,ath_pass,ath_code,createdate,ath_use,station_id) VALUES('" + model.ath_user + "','" + model.ath_pass + "','" + model.ath_code + "','" + DateTime.Now + "',0,'" + model.station_id + "')";
                using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=Z:\Documents\workspace_ios\muic_v2\muic_v2\muicv2.db;Version=3;"))
                {
                    connection.Open();
                    //create command and assign the query and connection from the constructor
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception ex)
            {
                //logger.Error(ex.InnerException);
                result = false;
            }
            Console.WriteLine(result.ToString());
            return true;
        }
        

    }
}
