using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace BAW.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<Rpt01> listRpt = new List<Rpt01>();
            //Open connection
            using (MySqlConnection connection = new MySqlConnection("SERVER=localhost;DATABASE=itech;UID=root;PASSWORD=P@ssw0rd;"))
            {
                String sql = "select e.name,e.barcode,b.from_date,b.thru_date" +
                            " from request_borrow b" +
                            " left join request_borrow_equipment_type rbet on b.id = rbet.request_borrow_id" +
                            " left join equipment e on e.equipment_type_list_id = rbet.equipment_type_list_id" +
                            " where b.status_code in ('R_B_NEW_RETURNED')" +
                            " and date(b.from_date)between '2015-11-01' and '2015-11-30'" +
                            //" and e.barcode = '404000008711'" +
                            " and e.equipment_type_list_id in (1134, 1135, 1107, 1108, 1089, 1132, 1128, 1129, 1153, 1125)" +
                            " and e.name is not null" +
                            " order by b.from_date,e.name asc";

                connection.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dr = cmd.ExecuteReader();

                int year = 2015;
                int month = 11;

                //String _barcode = String.Empty;
                //Read the data and store them in the list
                while (dr.Read())
                {

                    Rpt01 rpt01 = new Rpt01();
                    rpt01.Name = dr["name"].ToString();
                    rpt01.Barcode = dr["barcode"].ToString();
                    rpt01.FromDate = Convert.ToDateTime(dr["from_date"].ToString());
                    rpt01.EndDate = Convert.ToDateTime(dr["thru_date"].ToString());

                    listRpt.Add(rpt01);

                }

                var groupItem = listRpt.GroupBy(x => x.Barcode).ToList();
                foreach (var item in groupItem)
                {
                    List<DateTime> days = new List<DateTime>();
                    List<Rpt01> lstRpt01 = listRpt.Where(x => x.Barcode == item.Key).ToList();
                    foreach (Rpt01 rpt in lstRpt01)
                    {
                        int day = rpt.EndDate.Subtract(rpt.FromDate).Days;
                        for (int i = 0; i <= day; i++)
                        {
                            days.Add(rpt.FromDate.AddDays(i));
                        }
                    }
                    Console.Write(String.Format("{0},{1},", lstRpt01[0].Name, lstRpt01[0].Barcode));

                    int dayInMonth = DateTime.DaysInMonth(year, month);
                    for (int i = 1; i <= dayInMonth; i++)
                    {
                        DateTime dt = days.Where(x => x.Day == i && x.Year == year && x.Month == month).FirstOrDefault();
                        if (DateTime.MinValue == dt)
                        {
                            Console.Write("0");
                        }
                        else
                        {
                            Console.Write("1");
                        }
                    }
                    Console.WriteLine();
                }
                //close Data Reader
                dr.Close();
            }
            Console.WriteLine();
        }
    }
}

public class Rpt01
{
    public String Name { get; set; }
    public String Barcode { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime EndDate { get; set; }
}
