using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BAW.Biz;
using BAW.Utils;

namespace BAW.HiddenConfig
{
    public partial class FrmSetting : Form
    {
        //private StationDao siteDao = new StationDao();

        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            //pictureBox2.Image = null;
            //groupBox2.Enabled = false;
            //CMD_OK.Enabled = false;
            //CMD_CREATEDB.Visible = false;
            //CMD_OK.Visible = true;
            //panel1.Visible = true;
            //panel2.Visible = false;




        }

        private void CMD_CREATEDB_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string connectionString = "SERVER=" + SIP.Text + ";" + "DATABASE=" +
            DBN.Text + ";" + "UID=" + UN.Text + ";" + "PASSWORD=" + PASS.Text + ";";
            ManageLOG.writeRegistry(Configurations.AppRegName, "CON", ManageLOG.enCode(connectionString));
            string onnectionString1 = "SERVER=" + SIP1.Text + ";port="+PORT1.Text+";" + "DATABASE=" +
            DBN1.Text + ";" + "UID=" + UN1.Text + ";" + "PASSWORD=" + PASS1.Text + ";";
            ManageLOG.writeRegistry(Configurations.AppRegName, "CON1", ManageLOG.enCode(onnectionString1));



            ManageLOG.writeRegistry(Configurations.AppRegName, "AutoPrint", cbPrintAuto.Checked.ToString());
            ManageLOG.writeRegistry(Configurations.AppRegName, "AutoGenAutoPrint", cbAutoGenPrintAuto.Checked.ToString());
            ManageLOG.writeRegistry(Configurations.AppRegName, "Interval", txtInterval.Text);
            ManageLOG.writeRegistry(Configurations.AppRegName, "SSIDName", txtSSidName.Text);
            ManageLOG.writeRegistry(Configurations.AppRegName, "SupportCATInternet", txtInternetSupport.Text);
            ManageLOG.writeRegistry(Configurations.AppRegName, "SupportCATApplication", txtAppSupport.Text);


            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
            Close();

            Cursor = Cursors.Default;

        }

        private void CMD_CLOSE_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = null;
                try
                {
                    string conStr = "SERVER=" + SIP.Text + ";" + "DATABASE=" +
                    DBN.Text + ";" + "UID=" + UN.Text + ";" + "PASSWORD=" + PASS.Text + ";";
                    con = new MySqlConnection(conStr);
                    con.Open(); //open the connection
                    MessageBox.Show("Connected Success!");
                    //CMD_OK.Enabled = true;
                    //groupBox2.Enabled = false;
                    //CMD_OK.Focus();

                    //Show station
                }
                catch (MySqlException err) //We will capture and display any MySql errors that will occur
                {
                    MessageBox.Show("Error: " + err.ToString());
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close(); //safely close the connection
                    }
                } //remember to safely close the connection after accessing the database
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Conect Fail!");
                SIP.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //    Cursor = Cursors.WaitCursor;
            //    if (ManageLOG.Formula(textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text))
            //    {
            //        pictureBox2.Image = Properties.Resources.CT;
            //        groupBox2.Enabled = true;
            //        textBox1.Enabled = false;
            //        textBox2.Enabled = false;
            //        textBox3.Enabled = false;
            //        textBox4.Enabled = false;
            //        SIP.Focus();
            //    }
            //    else
            //    {
            //        pictureBox2.Image = Properties.Resources.CF;
            //        groupBox2.Enabled = false;
            //        textBox1.Enabled = true;
            //        textBox2.Enabled = true;
            //        textBox3.Enabled = true;
            //        textBox4.Enabled = true;
            //    }
            //    Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = null;
                try
                {
                    string conStr = "SERVER=" + SIP1.Text + ";" + "DATABASE=" +
                    DBN1.Text + ";" + "UID=" + UN1.Text + ";" + "PASSWORD=" + PASS1.Text + ";";
                    con = new MySqlConnection(conStr);
                    con.Open(); //open the connection
                    MessageBox.Show("Connected Success!");
                    //CMD_OK.Enabled = true;
                    //groupBox2.Enabled = false;
                    //CMD_OK.Focus();

                    //Show station
                    //lounge_site.DataSource = siteDao.SelectAdhoc(conStr);
                }
                catch (MySqlException err) //We will capture and display any MySql errors that will occur
                {
                    MessageBox.Show("Error: " + err.ToString());
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close(); //safely close the connection
                    }
                } //remember to safely close the connection after accessing the database
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Conect Fail!");
                SIP1.Focus();
            }
        }

        private void CMD_OK_Click(object sender, EventArgs e)
        {
            //CMD_OK.Visible = false;
            //CMD_CREATEDB.Visible = true;
            //panel1.Visible = false;
            //panel2.Visible = true;
        }

    }
}
