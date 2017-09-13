using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BAW.Model;
using BAW.Dao;
using BAW.Utils;
using BAW.Biz;

namespace BAirway
{
    public partial class FrmAutoGen : Form
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FrmAutoGen));
        #region "DECLARE"

        private ModelTransaction tran = new ModelTransaction();

        private TransactionDao tranDao = new TransactionDao();
        private AuthenCodeDao authenDao = new AuthenCodeDao();
        private GroupDao groupDao = new GroupDao();

        private Boolean onlineStatus = false;
        private int StationID = -1;
        private int staffId = -1;
        private int lounge = -1;
        private int area = -1;
        private String stationName = "";
        private String loungeName = "";
        private String areaName = "";

        #endregion

        public FrmAutoGen()
        {
            InitializeComponent();
        }

        private void FrmAutoGen_Load(object sender, EventArgs e)
        {
            #region Initial variable
            StationID = Convert.ToInt32(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID"));
            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo") != null)
            {
                String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');
                staffId = Convert.ToInt32(userInfo[0]);
                lounge = Convert.ToInt32(userInfo[1]);
                area = Convert.ToInt32(userInfo[2]);
                stationName = userInfo[3];
                loungeName = userInfo[4];
                areaName = userInfo[5];
                cbDisableVaridate.Visible = userInfo[7].ToUpper().Equals("ADMIN") || userInfo[7].ToUpper().Equals("SPECIAL");
            }
            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "OnlineStatus") != null)
            {
                onlineStatus = (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "OnlineStatus").Equals("1")) ? true : false;
            }
            #endregion
            lSupport.Text = String.Format(lSupport.Text, ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SupportCATInternet"), "");

            lounge_site.Enabled = false;
            lounge_site.Text = stationName;
            L_SITE_DESC.Text = loungeName + "-" + areaName;

            date_of_flight.DataSource = MyFunction.getYearDDL(1);
            group_id.DataSource = (onlineStatus) ? groupDao.Select("") : groupDao.SelectOffine("");

            refreshData();
        }
        private void B_SAVE_Click(object sender, EventArgs e)
        {

        }
        private void B_CANCEL_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void txt_barcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Return)
            {
                //if (!Connection.IsServerConnected() && onlineStatus)
                //{
                //    MessageBox.Show("การเชื่อมต่อกับอินเตอร์มีปัญหา\nโปรดเข้าระบบอีกครั้งเพื่อทำงานในโหมดออฟไลน์");
                //    Application.Exit();
                //    return;
                //}

                if (group_id.Text.Equals(""))
                {
                    MessageBox.Show("ยังไม่ได้เลือกข้อมูล Group");
                    txt_barcode.Text = string.Empty;
                    group_id.Select();
                    return;
                }

                try
                {
                    txt_barcode.Text = txt_barcode.Text.Replace("\r\n", "");
                    string strCode = txt_barcode.Text;

                    int dayOfYear = Convert.ToInt32(strCode.Substring(44, 3));
                    if (cbDisableVaridate.Checked || strCode.Substring(0, 2).Equals("M1") && (DateTime.Now.DayOfYear == dayOfYear || DateTime.Now.DayOfYear + 1 == dayOfYear))
                    {
                        ModelTransaction tran = new ModelTransaction();
                        tran.id = 0;
                        tran.boardingpass = txt_barcode.Text;
                        tran.type = "A";
                        tran.group_id = Convert.ToInt32(group_id.SelectedValue);
                        tran.passenger_name = strCode.Substring(2, 20);
                        tran.from_city = strCode.Substring(30, 3);
                        tran.to_city = strCode.Substring(33, 3);
                        tran.airline_code = strCode.Substring(36, 2);
                        tran.flight_no = strCode.Substring(39, 4);
                        tran.date_of_flight = new DateTime(Convert.ToInt32(date_of_flight.SelectedValue), DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                        tran.seat_no = strCode.Substring(48, 4);
                        tran.remark = remark.Text;
                        tran.remakr2 = remark2.Text;

                        tran.LoungePlace = StationID;
                        tran.LoungeType = lounge;
                        tran.LoungeArea = area;


                        tran.begin_date = DateTime.Now;

                        tran.create_by = staffId;
                        tran.create_date = DateTime.Now;
                        tran.update_by = staffId;
                        tran.update_date = DateTime.Now;

                        logger.Debug("AUTO->INPUT :" +
                    tran.passenger_name + "" + tran.flight_no + "" + tran.seat_no + "," +
                    tran.type + "," +                 //Type
                    tran.create_date.ToString("yyyy-MM-dd HH:MM:ss") + "," +
                    tran.group_idName + "," +         //GroupName
                    tran.duration + "," +             //Duration
                    tran.passenger_name + "," +       //PassengerName
                    tran.from_city + "," +            //FromCity
                    tran.to_city + "," +              //ToCity
                    tran.airline_code + "," +         //AirlineCode
                    tran.flight_no + "," +            //FlightNo
                    tran.date_of_flight.ToString("yyyy-MM-dd HH:MM:ss") + "," +
                    tran.seat_no + "," +              //SeatNo
                    tran.LoungeSiteCode + "," +           //LoungePlace
                    tran.LoungeName + "," +           //LoungeType
                    tran.LoungeAreaName + "," +       //LoungeArea
                    tran.create_byName + "," +        //Owner
                    tran.begin_date.ToString("yyyy-MM-dd HH:MM:ss") + "," +
                    tran.status + "," +               //Status
                    tran.remark + "," +               //Remark
                    tran.ath_id + "," +               //AccessCode
                    tran.remakr2 + "," +              //Remark2
                    tran.update_date.ToString("yyyy-MM-dd HH:MM:ss") + "," +
                    tran.update_byName                //LastUpdateBy
                    );
                        /*
                        List<ModelTransaction> tmps = (onlineStatus) ? tranDao.Select(" Where boardingpass='" + txt_barcode.Text + "'  order by t.create_date desc", StationID) : tranDao.SelectOffine(" Where boardingpass='" + txt_barcode.Text + "'  order by t.create_date desc", StationID);
                        //Generate Access Code ใหม่ถ้ามีอายุการใช้งานเกิน 5 ชั่วโมง
                        if (tmps.Count > 0 && ((DateTime.Now.Hour - tmps[0].create_date.Hour) <= 5))
                        {

                            tran.ath_id = tmps[0].ath_id;
                            if ((onlineStatus) ? tranDao.Insert(tran, StationID) : tranDao.InsertOffine(tran, StationID))
                            {
                                CMD_PRINT.Enabled = true;
                                lbMessage.Text = "บันทึกข้อมูลเรียบร้อยแล้ว";

                                lbAccessCode.Text = String.Format("{0}", tmps[0].ath_id);
                                lbAccessCode.ForeColor = Color.Green;
                                txt_barcode.Select();
                                //Auto print
                                if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoGenAutoPrint") != null)
                                {
                                    if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoGenAutoPrint").Equals(""))
                                    {
                                        Boolean bPrint = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoGenAutoPrint").Equals("False") ? false : true;
                                        if (bPrint)
                                        {
                                            if (!lbAccessCode.Text.Equals(""))
                                            {
                                                printDocument1.Print();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            */
                        String cri = "where ath_use = 0";
                        List<ModelAuthenCode> lists = (onlineStatus) ? authenDao.Select(cri, StationID) : authenDao.SelectOffine(cri, StationID);
                        if (lists != null)
                        {
                            if (lists.Count > 0)
                            {
                                //
                                ModelAuthenCode accessCode = lists[0];
                                //
                                tran.ath_id = tran.ath_id = (onlineStatus) ? lists[0].ath_code : "";
                                

                                //auto save
                                if ((onlineStatus) ? tranDao.Insert(tran, StationID) : tranDao.InsertOffine(tran, StationID))
                                {
                                    if (onlineStatus)
                                    {
                                        accessCode.ath_use = "1";
                                        Boolean result = (onlineStatus) ? authenDao.Update(accessCode) : authenDao.UpdateOffine(accessCode);
                                        if (result)
                                        {

                                            CMD_PRINT.Enabled = true;
                                            lbMessage.Text = "บันทึกข้อมูลเรียบร้อยแล้ว";

                                            lbAccessCode.Text = String.Format("{0}", accessCode.ath_code);
                                            lbAccessCode.ForeColor = Color.Green;
                                            txt_barcode.Select();
                                            //Auto print
                                            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoGenAutoPrint") != null)
                                            {
                                                if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoGenAutoPrint").Equals(""))
                                                {
                                                    Boolean bPrint = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "AutoGenAutoPrint").Equals("False") ? false : true;
                                                    if (bPrint && this.onlineStatus)
                                                    {
                                                        if (!lbAccessCode.Text.Equals(""))
                                                        {
                                                            printDocument1.Print();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {

                                            lbMessage.Text = "เกิดข้อผิดพลาดในการปรับปรุงค่า Access Code";
                                        }
                                    }
                                    else
                                    {

                                        lbMessage.Text = "บันทึกข้อมูลเรียบร้อยแล้ว";
                                        CMD_PRINT.Enabled = true;
                                        lbAccessCode.Text = String.Format("{0}", tran.ath_id);
                                        lbAccessCode.ForeColor = Color.Green;

                                    }
                                }
                            }
                            else
                            {
                                logger.Error("Out of access code!");
                                lbMessage.Text = "";
                                lbAccessCode.Text = String.Format("Access Code is not enought!");
                                lbAccessCode.ForeColor = Color.Red;
                                txt_barcode.Select();
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
                        lbMessage.Text = "";
                        lbAccessCode.Text = String.Format("BoardingPass is expired or incorrect data format.");
                        lbAccessCode.ForeColor = Color.Red;
                        txt_barcode.Select();
                    }

                    //Clear Barcode Value
                    clearData();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.InnerException);
                    e.Handled = false;
                    ManageLOG.writeLoginLogs(-1, ModelUserLogs.EVENT_EXCEPTION, this.Name + "-passenger_name_KeyUp:" + ex.Message);
                    txt_barcode.Text = "";
                    txt_barcode.Focus();
                }
            }
        }

        private void group_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_barcode.Select();
        }

        #region "Method"
        public void refreshData()
        {
            CMD_PRINT.Enabled = false;
            txt_barcode.Select();
            lbMessage.Text = "";
            lbAccessCode.Text = "";
            clearData();
        }
        private void clearData()
        {
            txt_barcode.Select();
            txt_barcode.Text = string.Empty;
            remark2.Text = string.Empty;
            remark.Text = string.Empty;

        }
        #endregion

        private void FrmAutoGen_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void CMD_PRINT_Click(object sender, EventArgs e)
        {
            if (!lbAccessCode.Text.Equals("") && lbAccessCode.ForeColor == Color.Green)
            {
                printDocument1.Print();
                CMD_PRINT.Enabled = false;
            }
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
            String accessCode = lbAccessCode.Text;
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
            e.Graphics.DrawString(template_p1, new Font("Arial", 8), Brushes.Black, 0, 5);
            e.Graphics.DrawString(accessCode, new Font("Arial", 14), Brushes.Black, 80, 55);
            e.Graphics.DrawString(template_p2, new Font("Arial", 8), Brushes.Black, 0, 75);
            e.Graphics.DrawString(template_p3, new Font("Arial", 6), Brushes.Black, 0, 95);
            e.Graphics.DrawString("-", new Font("Arial", 6), Brushes.Black, 0, 225);
        }

        private void group_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
