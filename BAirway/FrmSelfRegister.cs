using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using BAW.Biz;
using BAW.Dao;
using BAW.Model;
using BAW.Utils;

namespace BAirway
{
    public partial class FrmSelfRegister : Form
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FrmSelfRegister));
        private TransactionDao tranDao = new TransactionDao();
        private AuthenCodeDao authenCodeDao = new AuthenCodeDao();
        private Boolean success = false;
        private Boolean onlineStatus = false;
        private int StationID = -1;
        private int staffId = -1;
        private int lounge = -1;
        private int area = -1;

        public FrmSelfRegister()
        {
            InitializeComponent();
        }

        private void FrmSelfRegister_Load(object sender, EventArgs e)
        {
            if (Connection.IsServerConnected())
            {
                onlineStatus = true;
            }
            else
            {

            }

            #region Initial variable
            StationID = Convert.ToInt32(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID"));
            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo") != null)
            {
                String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');
                staffId = Convert.ToInt32(userInfo[0]);
                lounge = Convert.ToInt32(userInfo[1]);
                area = Convert.ToInt32(userInfo[2]);
            }
            if (!String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SelfAccessFontSize") ))
            {
                Font font = new Font("Tahoma", float.Parse(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SelfAccessFontSize"), CultureInfo.InvariantCulture.NumberFormat),
                              FontStyle.Bold | FontStyle.Regular);
            }
            else
            {
                Font font = new Font("Times New Roman", 20.25f,
                                        FontStyle.Bold | FontStyle.Regular);

                TXT_ACCESS_CODE.Font = font;
            }
            #endregion

            String interval = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "Interval");
            int inv = String.IsNullOrEmpty(interval) ? 2 : Convert.ToInt32(interval);
            timer1.Interval = inv * 1000;


            TXT_BARCODE_DATA.Enabled = this.onlineStatus;
            TXT_ACCESS_CODE.Enabled = this.onlineStatus;
            CMD_PRINT.Enabled = this.onlineStatus;


            TXT_BARCODE_DATA.Text = (this.onlineStatus) ? "" : "SYSTEM IS OFFINE!";
            TXT_ACCESS_CODE.Text = (this.onlineStatus) ? "" : "SYSTEM IS OFFINE!";
        }

        private void CMD_PRINT_Click(object sender, EventArgs e)
        {
            if (!TXT_ACCESS_CODE.Text.Equals(""))
            {
                printDocument1.Print();
            }
        }

        private void TXT_BARCODE_DATA_TextChanged(object sender, EventArgs e)
        {
        }

        private void FrmSelfRegister_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //case Keys.Alt|Keys.F4:
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    TXT_ACCESS_CODE.Text = "";
                    TXT_BARCODE_DATA.Text = "";
                    TXT_BARCODE_DATA.Focus();
                    break;
                case Keys.F6:
                    printDocument2.Print();
                    break;
            }
        }

        private void TXT_BARCODE_DATA_KeyUp(object sender, KeyEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (e.KeyValue == (char)Keys.Return)
            {
                e.Handled = true;

                if (!TXT_BARCODE_DATA.Text.Equals(""))
                {
                    try
                    {

                        TXT_BARCODE_DATA.Text = TXT_BARCODE_DATA.Text.Replace("\r\n", "");
                        string strCode = TXT_BARCODE_DATA.Text;
                        int dayOfYear = Convert.ToInt32(strCode.Substring(44, 3));

                        if (strCode.Substring(0, 2).Equals("M1") && (DateTime.Now.DayOfYear == dayOfYear || DateTime.Now.DayOfYear + 1 == dayOfYear))
                        {

                            TXT_BARCODE_DATA.Enabled = false;
                            logger.Debug("Boarding pass:" + strCode);
                            ModelTransaction tran = new ModelTransaction();

                            tran.id = 0;
                            tran.boardingpass = TXT_BARCODE_DATA.Text;
                            tran.type = "S";//Self
                            tran.group_id = 16;
                            tran.passenger_name = strCode.Substring(2, 20);
                            tran.from_city = strCode.Substring(30, 3);
                            tran.to_city = strCode.Substring(33, 3);
                            tran.airline_code = strCode.Substring(36, 2);
                            tran.flight_no = strCode.Substring(39, 4);
                            tran.date_of_flight = DateTime.Now;
                            tran.seat_no = strCode.Substring(48, 4);
                            tran.remark = "";
                            tran.remakr2 = "";

                            tran.LoungePlace = Convert.ToInt32(StationID);
                            tran.LoungeType = lounge;
                            tran.LoungeArea = area;

                            tran.begin_date = DateTime.Now;
                            tran.create_by = staffId;
                            tran.create_date = DateTime.Now;
                            tran.update_date = DateTime.Now;
                            tran.update_by = staffId;
                            /*
                            List<ModelTransaction> tmps = (onlineStatus) ? tranDao.Select(" Where boardingpass='" + TXT_BARCODE_DATA.Text + "' order by t.create_date desc", StationID) : tranDao.SelectOffine(" Where boardingpass='" + TXT_BARCODE_DATA.Text + "' order by t.create_date desc", StationID);

                            //Generate Access Code ใหม่ถ้ามีอายุการใช้งานเกิน 5 ชั่วโมง
                            if (tmps.Count > 0 && ((DateTime.Now.Hour - tmps[0].create_date.Hour) <= 5))
                            {

                                tran.ath_id = tmps[0].ath_id;
                                tran.create_date = DateTime.Now;

                                if ((onlineStatus) ? tranDao.Insert(tran, StationID) : tranDao.InsertOffine(tran, StationID))
                                {
                                    Console.Beep();
                                    TXT_ACCESS_CODE.Text = tran.ath_id;
                                    TXT_BARCODE_DATA.Enabled = false;
                                    //Auto print
                                    if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoPrint") != null)
                                    {
                                        if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoPrint").Equals(""))
                                        {
                                            Boolean bPrint = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoPrint").Equals("False") ? false : true;
                                            if (bPrint)
                                            {
                                                if (!TXT_ACCESS_CODE.Text.Equals(""))
                                                {
                                                    TXT_BARCODE_DATA.Enabled = false;
                                                    printDocument1.Print();
                                                }
                                            }
                                        }
                                    }
                                    success = true;
                                }
                                else
                                {
                                    TXT_BARCODE_DATA.Enabled = true;
                                    TXT_ACCESS_CODE.Text = "CAN'T CREATE PLEASE TRY AGAIN!";
                                    TXT_BARCODE_DATA.Text = "";
                                    TXT_BARCODE_DATA.Focus();
                                    Cursor = Cursors.Default;
                                }
                            }
                            else
                            {
                                */
                                //get authen code
                                String cri = "where ath_use = 0";
                                List<ModelAuthenCode> lists = (onlineStatus) ? authenCodeDao.Select(cri, StationID) : authenCodeDao.SelectOffine(cri, StationID);
                                if (lists != null)
                                {
                                    if (lists.Count > 0)
                                    {
                                        ModelAuthenCode tmpAuthenModel = lists[0];
                                        tran.ath_id = tmpAuthenModel.ath_code;
                                        tran.create_date = DateTime.Now;

                                        if ((onlineStatus) ? tranDao.Insert(tran, StationID) : tranDao.InsertOffine(tran, StationID))
                                        {
                                            tmpAuthenModel.ath_use = "1";
                                            Boolean result = (onlineStatus) ? authenCodeDao.Update(tmpAuthenModel) : authenCodeDao.UpdateOffine(tmpAuthenModel);
                                            if (result)
                                            {
                                                Console.Beep();
                                                TXT_ACCESS_CODE.Text = tmpAuthenModel.ath_code;
                                                //Auto print
                                                if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoPrint") != null)
                                                {
                                                    if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoPrint").Equals(""))
                                                    {
                                                        Boolean bPrint = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoPrint").Equals("False") ? false : true;
                                                        if (bPrint)
                                                        {
                                                            if (!TXT_ACCESS_CODE.Text.Equals(""))
                                                            {
                                                                printDocument1.Print();
                                                                TXT_BARCODE_DATA.Enabled = false;
                                                                TXT_BARCODE_DATA.Text = string.Empty;
                                                                TXT_ACCESS_CODE.Text = string.Empty;
                                                                success = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                TXT_ACCESS_CODE.Text = "CAN'T CREATE PLEASE TRY AGAIN!";
                                                TXT_BARCODE_DATA.Enabled = true;
                                                TXT_BARCODE_DATA.Text = "";
                                                TXT_BARCODE_DATA.Focus();
                                                Cursor = Cursors.Default;
                                            }
                                        }
                                        else
                                        {
                                            TXT_ACCESS_CODE.Text = "CAN'T CREATE PLEASE TRY AGAIN!";
                                            TXT_BARCODE_DATA.Enabled = true;
                                            TXT_BARCODE_DATA.Text = "";
                                            TXT_BARCODE_DATA.Focus();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    else
                                    {
                                        logger.Error("Out of access code!");
                                        TXT_ACCESS_CODE.Text = "OUT OF ACCESS CODE!";
                                        TXT_BARCODE_DATA.Enabled = true;
                                        TXT_BARCODE_DATA.Text = "";
                                        TXT_BARCODE_DATA.Focus();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                else
                                {
                                    logger.Error("Out of access code!");
                                }
                            //}
                        }
                        else
                        {
                            TXT_ACCESS_CODE.Text = "BoardingPass is expired or incorrect data format.";
                            TXT_BARCODE_DATA.Enabled = true;
                            TXT_BARCODE_DATA.Text = "";
                            TXT_BARCODE_DATA.Focus();
                            Cursor = Cursors.Default;
                        }
                        Cursor = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        logger.Error(ex.StackTrace);
                        TXT_ACCESS_CODE.Text = "INCORRECT DATA FORMAT!";
                        TXT_BARCODE_DATA.Enabled = true;
                        TXT_BARCODE_DATA.Text = "";
                        TXT_BARCODE_DATA.Focus();
                        Cursor = Cursors.Default;
                    }

                    TXT_BARCODE_DATA.Enabled = false;
                    if (success)
                    {
                        timer1.Enabled = true;
                        timer1.Start();
                    }
                    else
                    {
                        timer1.Enabled = false;
                        timer1.Stop();
                    }

                }
            }

            TXT_BARCODE_DATA.Enabled = true;
            TXT_BARCODE_DATA.Focus();
            Cursor = Cursors.Default;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TXT_ACCESS_CODE.Text = "";
            TXT_BARCODE_DATA.Text = "";
            TXT_BARCODE_DATA.Focus();
            timer1.Enabled = false;
            timer1.Stop();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int wiFiExpire = 0;
            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtWiFiExpire") != null)
            {
                if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtWiFiExpire").Equals(""))
                {
                    try
                    {
                        wiFiExpire = Convert.ToInt32(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtWiFiExpire"));
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        wiFiExpire = 3;
                    }
                }
            }


            String expireDate = DateTime.Now.AddHours(wiFiExpire).ToString();
            String ssidName = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SSIDName");
            String accessCode = TXT_ACCESS_CODE.Text;
            String template_p1 =
                            "\t\tBangkok Airways\n" +
                            "\t\tInternet Service\n\n" +
                            "------------------------------------------------\n" +
                            "Access Code: ";
            String template_p2 = "Expire Time: " + expireDate + "\n";
            String template_p3 = "---------------------------------------------------------------\nInstructions for User\n" +
                "1. Select Wifi " + ((ssidName == null) ? "" : ssidName) + "\n     (เลือก Wifi) \n" +
            "2. Run the Internet Browser and go to any website.\n(เปิดอินเตอร์เนตบราวเซอร์แล้วไปยังเวปไซต์ที่ต้องการ) \n" +
            "3. The system will automatically redirect to the \nLogin Page,(ระบบจะไปยังหน้าจอ Login อัตโนมัติ)\n" +
            "Please enter Access Code.\n (ป้อน Access Code ที่ได้รับ)" +
            "\n" +
            "\n";

            Bitmap logo = new Bitmap(Configurations.PosLogoPath);
            Bitmap clone = new Bitmap(logo.Width, logo.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics gr = Graphics.FromImage(clone))
            {
                gr.DrawImage(logo, new Rectangle(0, 0, 110, 60));
            }
            e.Graphics.DrawImage(clone, -5, -12);

            int PT1Size = 8;
            int PAcCode = 14;
            int PT2Size = 8;
            int PT3Size = 6;

            if (!String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPT1Size")))
            {
                PT1Size = Convert.ToInt16(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPT1Size"));
            }
            if (!String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPAcCode")))
            {
                PAcCode = Convert.ToInt16(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPAcCode"));
            }
            if (!String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPT2Size")))
            {
                PT2Size = Convert.ToInt16(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPT2Size"));
            }
            if (!String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPT3Size")))
            {
                PT3Size = Convert.ToInt16(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "txtPT3Size"));
            }

            //e.Graphics.DrawImage(clone, -5, -12);
            e.Graphics.DrawString(template_p1, new Font("Arial", PT1Size), Brushes.Black, 0, 5);
            e.Graphics.DrawString(accessCode, new Font("Arial", PAcCode), Brushes.Black, 80, 55);
            e.Graphics.DrawString(template_p2, new Font("Arial", PT2Size), Brushes.Black, 0, 75);
            e.Graphics.DrawString(template_p3, new Font("Arial", PT3Size), Brushes.Black, 0, 95);


            //e.Graphics.DrawString(template_p1, new Font("Arial", 8), Brushes.Black, 0, 5);
            //e.Graphics.DrawString(accessCode, new Font("Arial", 14), Brushes.Black, 80, 55);
            //e.Graphics.DrawString(template_p2, new Font("Arial", 8), Brushes.Black, 0, 75);
            //e.Graphics.DrawString(template_p3, new Font("Arial", 6), Brushes.Black, 0, 95);
            e.Graphics.DrawString("-", new Font("Arial", 6), Brushes.Black, 0, 225);

        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
                "1. Select Wifi " + ((ssidName == null) ? "" : ssidName) + "\n     (เลือก Wifi) \n" +
            "2. Run the Internet Browser and go to any website.\n(เปิดอินเตอร์เนตบราวเซอร์แล้วไปยังเวปไซต์ที่ต้องการ) \n" +
            "3. The system will automatically redirect to the \nLogin Page,(ระบบจะไปยังหน้าจอ Login อัตโนมัติ)\n" +
            "Please enter Access Code.\n (ป้อน Access Code ที่ได้รับ)" +
            "\n"+
            "\n";

            Bitmap logo = new Bitmap(Configurations.PosLogoPath);
            Bitmap clone = new Bitmap(logo.Width, logo.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics gr = Graphics.FromImage(clone))
            {
                gr.DrawImage(logo, new Rectangle(0, 0, 110, 60));
            }
            e.Graphics.DrawImage(clone, -5, -12);
            e.Graphics.DrawString(template_p1, new Font("Arial", 8), Brushes.Black, 0, 5);
            e.Graphics.DrawString(accessCode, new Font("Arial", 14), Brushes.Black, 80, 55);
            e.Graphics.DrawString(template_p2, new Font("Arial", 8), Brushes.Black, 0, 75);
            e.Graphics.DrawString(template_p3, new Font("Arial", 6), Brushes.Black, 0, 95);
            e.Graphics.DrawString("-", new Font("Arial", 6), Brushes.Black, 0, 225);

        }
    }
}
