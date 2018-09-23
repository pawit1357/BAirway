using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Net;
using BAW.Dao;
using BAW.Utils;
using BAW.Biz;
using MySql.Data.MySqlClient;

namespace BAirway
{
    public partial class FrmSetting : Form
    {
        private StationDao siteDao = new StationDao();

        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            groupBox2.Enabled = false;
            CMD_OK.Enabled = false;
            CMD_CREATEDB.Visible = false;
            CMD_OK.Visible = true;
            panel1.Visible = true;
            panel2.Visible = false;




        }

        private void CMD_CREATEDB_Click(object sender, EventArgs e)
        {

            DialogResult dr1 = MessageBox.Show("เริ่มสร้างฐานข้อมูล(LOCAL)", "เริ่มสร้างฐานข้อมูล", MessageBoxButtons.OKCancel);
            if (dr1 == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                if (ManageLOG.Formula(textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text))
                {
                    pictureBox2.Image = Properties.Resources.CT;
                    ManageLOG.writeRegistry(Configurations.AppRegName, "SK", ManageLOG.enCode((textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text)));

                    string connectionString;
                    connectionString = "SERVER=" + SIP.Text + ";" + "DATABASE=" +
                    DBN.Text + ";" + "UID=" + UN.Text + ";" + "PASSWORD=" + PASS.Text + ";";
                    ManageLOG.writeRegistry(Configurations.AppRegName, "CON", ManageLOG.enCode(connectionString));
                    ManageLOG.writeRegistry(Configurations.AppRegName, "StationID", lounge_site.SelectedValue.ToString());

                    ManageLOG.writeRegistry(Configurations.AppRegName, "AutoPrint", "true");
                    ManageLOG.writeRegistry(Configurations.AppRegName, "AutoGenAutoPrint", "true");
                    ManageLOG.writeRegistry(Configurations.AppRegName, "ManualGenAutoPrint", "true");            
                    ManageLOG.writeRegistry(Configurations.AppRegName, "Interval", "5");
                    ManageLOG.writeRegistry(Configurations.AppRegName, "txtWiFiExpire", "3");
                    ManageLOG.writeRegistry(Configurations.AppRegName, "SSIDName","@Bangkokairways1");
                    ManageLOG.writeRegistry(Configurations.AppRegName, "SupportCATInternet", "09-9213-7016");
                    ManageLOG.writeRegistry(Configurations.AppRegName, "SupportCATApplication", "");
                    ManageLOG.writeRegistry(Configurations.AppRegName, "UserInfo", "-1,-1,-1," + lounge_site.Text + ",-1,,-1,,,");
                    //
                    ManageLOG.writeRegistry(Configurations.AppRegName, "SelfAccessFontSize", "20.25");
                    ManageLOG.writeRegistry(Configurations.AppRegName, "txtPAcCode", "8");
                    ManageLOG.writeRegistry(Configurations.AppRegName, "txtPT1Size", "8");
                    ManageLOG.writeRegistry(Configurations.AppRegName, "txtPT2Size", "8");
                    ManageLOG.writeRegistry(Configurations.AppRegName, "txtPT3Size", "6");





                    // if 'Yes' do something here 
                    String sourcePath = String.Format(@"C:\{0}\{1}\", Configurations.AppFolder, Configurations.LocalDbFolder);
                    String fileName = Configurations.DbFile;

                    try
                    {
                        //Check Folder is exist
                        if (!Directory.Exists(sourcePath))
                        {
                            Directory.CreateDirectory(sourcePath);
                        }
                        //Check file exist
                        if (File.Exists(sourcePath + "" + fileName))
                        {
                            File.Delete(sourcePath + "" + fileName);
                        }

                        // Create an instance of WebClient
                        WebClient client = new WebClient();
                        // Hookup DownloadFileCompleted Event
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                        // Start the download and copy the file to c:\temp
                        client.DownloadFileAsync(new Uri(Configurations.DownloadLocalURL), sourcePath + "" + fileName);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดไม่สามารถสร้างฐ้านข้อมูลได้ (" + ex.Message + ")");
                    }

                }
                else
                {
                    pictureBox2.Image = Properties.Resources.CF;
                    MessageBox.Show("Serial Key ไม่ถูกต้อง");
                    pictureBox2.Image = null;
                }

                Cursor = Cursors.Default;
            }
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
                    CMD_OK.Enabled = true;
                    groupBox2.Enabled = false;
                    CMD_OK.Focus();

                    //Show station
                    lounge_site.DataSource = siteDao.SelectAdhoc(conStr);
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
            Cursor = Cursors.WaitCursor;
            if (ManageLOG.Formula(textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text))
            {
                pictureBox2.Image = Properties.Resources.CT;
                groupBox2.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                SIP.Focus();
            }
            else
            {
                pictureBox2.Image = Properties.Resources.CF;
                groupBox2.Enabled = false;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            Cursor = Cursors.Default;
        }

        private void CMD_OK_Click(object sender, EventArgs e)
        {
            CMD_OK.Visible = false;
            CMD_CREATEDB.Visible = true;
            panel1.Visible = false;
            panel2.Visible = true;
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!Directory.Exists(String.Format(@"C:\{0}\\{1}\\", Configurations.AppFolder, Configurations.ImagePath)))
            {
                Directory.CreateDirectory(String.Format(@"C:\{0}\\{1}\\", Configurations.AppFolder, Configurations.ImagePath));
            }
            //Check file exist
            if (!File.Exists(Configurations.PosLogoPath))
            {
                WebClient client1 = new WebClient();
                client1.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted1);
                // Start the download and copy the file to c:\temp
                client1.DownloadFileAsync(new Uri(Configurations.DownloadPosLogoURL), Configurations.PosLogoPath);
            }
        }
        void client_DownloadFileCompleted1(object sender, AsyncCompletedEventArgs e)
        {

            MessageBox.Show("สร้างฐานข้อมูล(LOCAL)เรียบร้อยแล้ว\nการตั้งค่าระบบจะมีผลกับการเปิดใช้งานโปรแกรมในครั้งต่อไป");
            Application.Exit();
        }
    }
}
