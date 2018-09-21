using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Net;
using BAW.Utils;
using BAW.Biz;
using MySql.Data.MySqlClient;
using BAW.Dao;
using System.Drawing;
using System.Collections.Generic;
using BAW.Model;

namespace BAirway
{
    public partial class FrmConfiguration : Form
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FrmConfiguration));
        public FrmConfiguration()
        {
            InitializeComponent();
        }


        private void FrmConfiguration_Load(object sender, EventArgs e)
        {
            initial();
        }

        private void CMD_CONNTECTION_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = null;
                try
                {
                    string conStr = "SERVER=" + SIP.Text + ";" + "DATABASE=" +
                    DBN.Text + ";" + "UID=" + UN.Text + ";" + "PASSWORD=" + PASS.Text + ";";
                    con = new MySqlConnection(conStr);
                    con.Open();
                    MessageBox.Show("Connected Success!");
                }
                catch (MySqlException err)
                {
                    MessageBox.Show("Error: " + err.ToString());
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close(); //safely close the connection
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Conect Fail!");
            }
        }

        private void CMD_CLOSE_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CMD_OK_Click(object sender, EventArgs e)
        {

            string connectionString;
            connectionString = "SERVER=" + SIP.Text + ";" + "DATABASE=" +
            DBN.Text + ";" + "UID=" + UN.Text + ";" + "PASSWORD=" + PASS.Text + ";";
            ManageLOG.writeRegistry(Configurations.AppRegName, "CON", ManageLOG.enCode(connectionString));
            ManageLOG.writeRegistry(Configurations.AppRegName, "AutoPrint", cbPrintAuto.Checked.ToString());
            ManageLOG.writeRegistry(Configurations.AppRegName, "AutoGenAutoPrint", cbAutoGenPrintAuto.Checked.ToString());
            ManageLOG.writeRegistry(Configurations.AppRegName, "ManualGenAutoPrint", cbManualGenPrintAuto.Checked.ToString());            
            ManageLOG.writeRegistry(Configurations.AppRegName, "Interval", txtInterval.Text);
            ManageLOG.writeRegistry(Configurations.AppRegName, "SSIDName", txtSSidName.Text);
            ManageLOG.writeRegistry(Configurations.AppRegName, "txtWiFiExpire", txtWiFiExpire.Text);
            ManageLOG.writeRegistry(Configurations.AppRegName, "StationID", lounge_site.SelectedValue.ToString());

            ManageLOG.writeRegistry(Configurations.AppRegName, "SupportCATInternet", txtInternetSupport.Text);
            ManageLOG.writeRegistry(Configurations.AppRegName, "SupportCATApplication", txtAppSupport.Text);
            ManageLOG.writeRegistry(Configurations.AppRegName, "PRINTER", ddlPrinter.SelectedValue.ToString());
            //Selft Access Screen
            ManageLOG.writeRegistry(Configurations.AppRegName, "SelfAccessFontSize", txtSelftAccessFontSize.Text);
            //Print Stricker
            ManageLOG.writeRegistry(Configurations.AppRegName, "txtPAcCode", txtPAcCode.Text);
            ManageLOG.writeRegistry(Configurations.AppRegName, "txtPT1Size", txtPT1Size.Text);
            ManageLOG.writeRegistry(Configurations.AppRegName, "txtPT2Size", txtPT2Size.Text);
            ManageLOG.writeRegistry(Configurations.AppRegName, "txtPT3Size", txtPT3Size.Text);






            


        String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');

            String tmp = userInfo[0] + "," +
                userInfo[1] + "," +
                userInfo[2] + "," +
                lounge_site.Text + "," +
                userInfo[4] + "," +
                userInfo[5] + "," +
                userInfo[6] + "," +
                userInfo[7] + "," +
                userInfo[8] + "," +
                userInfo[9];


            ManageLOG.writeRegistry(Configurations.AppRegName, "UserInfo", tmp);
            MessageBox.Show("บันทึกเรียบร้อยแล้ว เริ่มเปิดโปรแกรมใหม่เพื่อเริ่มใช้ค่าที่ได้บันทึก");
            Application.Exit();
            initial();
            Close();
        }

        private void initial()
        {
            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo") != null)
            {
                StationDao siteDao = new StationDao();
                String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');
                String StationID = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID");
                if (userInfo[6].Equals("9"))
                {
                    lounge_site.DataSource = siteDao.Select("");
                    lounge_site.Enabled = true;
                    lounge_site.Text = userInfo[3];
                }
                else
                {                    
                    if (!String.IsNullOrEmpty(StationID))
                    {
                        lounge_site.DataSource = siteDao.Select(" where id=" + StationID);
                    }
                }
            }


            String[] conStr = ManageLOG.deCode(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "CON")).Split(';');
            if (conStr.Length == 5)
            {
                SIP.Text = conStr[0].Split('=')[1];
                DBN.Text = conStr[1].Split('=')[1];
                UN.Text = conStr[2].Split('=')[1];
                PASS.Text = conStr[3].Split('=')[1];

                if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoPrint") != null)
                {
                    if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoPrint").Equals(""))
                    {
                        cbPrintAuto.Checked = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoPrint").Equals("False") ? false : true;
                    }
                }
                if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoGenAutoPrint") != null)
                {
                    if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoGenAutoPrint").Equals(""))
                    {

                        cbAutoGenPrintAuto.Checked = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoGenAutoPrint").Equals("False") ? false : true;
                    }
                }
                if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "ManualGenAutoPrint") != null)
                {
                    if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "ManualGenAutoPrint").Equals(""))
                    {

                        cbManualGenPrintAuto.Checked = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "ManualGenAutoPrint").Equals("False") ? false : true;
                    }
                }

                if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SupportCATInternet") != null)
                {
                    if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SupportCATInternet").Equals(""))
                    {
                        txtInternetSupport.Text = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SupportCATInternet");
                    }
                }
                if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SupportCATApplication") != null)
                {
                    if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SupportCATApplication").Equals(""))
                    {
                        txtAppSupport.Text = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SupportCATApplication");
                    }
                }

                if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtWiFiExpire") != null)
                {
                    if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtWiFiExpire").Equals(""))
                    {
                        txtWiFiExpire.Text = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtWiFiExpire");
                    }
                }

                String interval = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "Interval");
                if (interval != null)
                {
                    if (!interval.Equals(""))
                    {
                        txtInterval.Text = interval;
                    }
                }
                String SSIDName = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SSIDName");
                if (SSIDName != null)
                {
                    txtSSidName.Text = SSIDName;
                }
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void CheckIsNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Allow only number.");
            }
        }

        private void CMD_CREATE_DB_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("คุณต้องการสร้างฐานข้อมูลใหม่หรือไม่", "สร้างฐานข้อมูล", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // if 'Yes' do something here 
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

            MessageBox.Show("สร้างฐานข้อมูลเรียบร้อยแล้ว\nการตั้งค่าระบบจะมีผลกับการเปิดใช้งานโปรแกรมในครั้งต่อไป");
            Application.Exit();
        }

        private void txt_barcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Return)
            {
                try
                {
                    txt_barcode.Text = txt_barcode.Text.Replace("\r\n", "");
                    string strCode = txt_barcode.Text;

                    printDocument1.Print();
                }
                catch (Exception ex)
                {
                    e.Handled = false;
                    txt_barcode.Text = "";
                    txt_barcode.Focus();
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            String expireDate = DateTime.Now.AddHours(5).ToString();
            String ssidName = "TEST PRINT (SSID)";
            String accessCode = "12345";
            String template_p1 =
                            "\t\tBangkok Airways\n" +
                            "\t\tInternet Service\n\n" +
                            "------------------------------------------------\n" +
                            "Access Code: ";
            String template_p2 = "Expire Time: " + expireDate + "\n";
            String template_p3 = "---------------------------------------------------------------\nInstructions for User\n" +
                "  1. Select Wifi " + ((ssidName == null) ? "" : ssidName) + "\n     (เลือก Wifi) \n" +
            "  2. Run the Internet Browser and go to any website.\n     (เปิดอินเตอร์เนตบราวเซอร์แล้วไปยังเวปไซต์ที่ต้องการ) \n" +
            "  3. The system will automatically redirect to the Login Page,\n     (ระบบจะไปยังหน้าจอ Login อัตโนมัติ)\n" +
            "  Please enter Access Code.\n     (ป้อน Access Code ที่ได้รับ)" +
            " \n\n\n";

            Bitmap logo = new Bitmap(Configurations.PosLogoPath);
            Bitmap clone = new Bitmap(logo.Width, logo.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics gr = Graphics.FromImage(clone))
            {
                gr.DrawImage(logo, new Rectangle(0, 0, 110, 60));
            }
            e.Graphics.DrawImage(clone, -5, -12);
            e.Graphics.DrawString(template_p1, new Font("Arial", 8), Brushes.Black, 0, 5);
            e.Graphics.DrawString(accessCode, new Font("Arial", 10), Brushes.Black, 80, 55);
            e.Graphics.DrawString(template_p2, new Font("Arial", 8), Brushes.Black, 0, 75);
            e.Graphics.DrawString(template_p3, new Font("Arial", 6), Brushes.Black, 0, 95);
            e.Graphics.DrawString("-", new Font("Arial", 6), Brushes.Black, 0, 225);

            txt_barcode.Text = "";
            txt_barcode.Focus();
        }

        private void TransferTo202_Click(object sender, EventArgs e)
        {
            int StationID = Convert.ToInt32(lounge_site.SelectedValue);
            logger.Debug(String.Format("Begin transfer data from site>",lounge_site.Text));
            TransactionDao dao = new TransactionDao();

            String cri = "where date(create_date) = date('" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "') and LoungePlace=" + StationID + " order by update_date desc";

            List<ModelTransaction> lists = dao.Select61(cri, StationID);
            int result = 0;
            if (lists.Count > 0)
            {
                foreach (ModelTransaction m in lists)
                {
                    result += (dao.Insert(m,StationID))? result++:0;
                }
            }

            logger.Debug(String.Format("Result of transafer total{0} success{1} record(s)",lists.Count,result));
        }
    }
}
