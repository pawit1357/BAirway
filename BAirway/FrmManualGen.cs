using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BAW.Model;
using BAW.Dao;
using BAW.Biz;
using BAW.Utils;

namespace BAirway
{
    public partial class FrmManualGen : Form
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FrmManualGen));
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

        public FrmManualGen()
        {
            InitializeComponent();
        }

        private void FrmManualGen_Load(object sender, EventArgs e)
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

            group_id.DataSource = (onlineStatus) ? groupDao.Select("") : groupDao.SelectOffine("");

            refreshData();
        }

        private void FrmManualGen_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void B_SAVE_Click(object sender, EventArgs e)
        {
            //if (!Connection.IsServerConnected() && onlineStatus)
            //{
            //    MessageBox.Show("การเชื่อมต่อกับอินเตอร์มีปัญหา\nโปรดเข้าระบบอีกครั้งเพื่อทำงานในโหมดออฟไลน์");
            //    Application.Exit();
            //    return;
            //}
            //Validate
            if (passenger_name.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Passenger Name");
                passenger_name.Select();
                return;
            }
            if (airlineCode.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Airline Code");
                airlineCode.Select();
                return;
            }
            if (flight_no.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Flight No");
                flight_no.Select();
                return;
            }
            if (date_of_flight.Value.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Date Of flight");
                date_of_flight.Select();
                return;
            }
            if (seat_no.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Seat No");
                seat_no.Select();
                return;
            }
            //if (fromcity.Text.Equals(""))
            //{
            //    MessageBox.Show("ยังไม่ได้ป้อนข้อมูล From City");
            //    fromcity.Select();
            //    return;
            //}
            //if (tocity.Text.Equals(""))
            //{
            //    MessageBox.Show("ยังไม่ได้ป้อนข้อมูล To City");
            //    tocity.Select();
            //    return;
            //}


            if (group_id.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้เลือกข้อมูล Group");
                group_id.Select();
                return;
            }

            Boolean result = false;

            String cri = "where ath_use = 0";
            List<ModelAuthenCode> lists = (onlineStatus) ? authenDao.Select(cri, StationID) : authenDao.SelectOffine(cri, StationID);
            if (lists.Count > 0)
            {

                ModelAuthenCode accessCode = lists[0];
                ModelTransaction tran = new ModelTransaction();

                tran.type = "M";


                tran.group_id = (group_id.Text.Equals("")) ? -1 : Convert.ToInt32(group_id.SelectedValue);
                tran.passenger_name = passenger_name.Text;
                tran.from_city = fromcity.Text;
                tran.to_city = tocity.Text;
                tran.airline_code = airlineCode.Text;

                tran.flight_no = flight_no.Text;
                tran.date_of_flight = date_of_flight.Value;
                tran.seat_no = ((seat_no.Text.Length > 4) ? seat_no.Text.Substring(0, 4) : seat_no.Text);
                tran.remark = remark.Text;
                tran.remakr2 = remark2.Text;

                tran.LoungePlace = StationID;
                tran.LoungeType = lounge;
                tran.LoungeArea = area;

                tran.begin_date = DateTime.Now;
                tran.ath_id = (onlineStatus)? accessCode.ath_code:"";
                tran.create_by = staffId;
                tran.create_date = DateTime.Now;

                tran.update_date = DateTime.Now;
                tran.update_by = staffId;
                //M1GILJIMENEZ/PILA9 MS EKWGVQS BKKTDXPG 0305 078Y045A0016 300
                tran.boardingpass = MyFunction.getBoadingPass(tran);// passenger_name.Text + "" + fromcity.Text + tocity.Text + airlineCode.Text + date_of_flight.Value + seat_no.Text;

                logger.Debug("MANUAL->INPUT :"+
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
                //auto save
                if ((onlineStatus) ? tranDao.Insert(tran, StationID) : tranDao.InsertOffine(tran, StationID))
                {
                    if (onlineStatus)//
                    {
                        accessCode.ath_use = "1";
                        result = (onlineStatus) ? authenDao.Update(accessCode) : authenDao.UpdateOffine(accessCode);
                        if (result)
                        {

                            lbMessage.Text = "บันทึกข้อมูลเรียบร้อยแล้ว";
                            CMD_PRINT.Enabled = true;
                            lbAccessCode.Text = String.Format("{0}", accessCode.ath_code);
                            lbAccessCode.ForeColor = Color.Green;
                            //Auto print
                            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "ManualGenAutoPrint") != null)
                            {
                                if (!ManageLOG.getValueFromRegistry(Configurations.AppRegName, "ManualGenAutoPrint").Equals(""))
                                {
                                    Boolean bPrint = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "ManualGenAutoPrint").Equals("False") ? false : true;
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
                lbMessage.Text = "";
                lbAccessCode.Text = String.Format("Access Code is not enought!");
                lbAccessCode.ForeColor = Color.Red;
            }
            clearData();
        }

        private void B_CANCEL_Click(object sender, EventArgs e)
        {
            refreshData();
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
            String printerSize = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "PRINTER");

            e.Graphics.DrawString(template_p1, new Font("Arial", 8), Brushes.Black, 0, 5);
            e.Graphics.DrawString(accessCode, new Font("Arial", 14), Brushes.Black, 80, 55);
            e.Graphics.DrawString(template_p2, new Font("Arial", 8), Brushes.Black, 0, 75);
            e.Graphics.DrawString(template_p3, new Font("Arial", 6), Brushes.Black, 0, 95);
            e.Graphics.DrawString("-", new Font("Arial", 6), Brushes.Black, 0, 225);
        }

        #region "Method"
        public void refreshData()
        {
            passenger_name.Select();
            CMD_PRINT.Enabled = false;
            lbMessage.Text = "";
            lbAccessCode.Text = "";

            clearData();
        }

        private void clearData()
        {
            fromcity.Text = "";
            tocity.Text = "";
            airlineCode.Text = "";
            passenger_name.Text = "";
            flight_no.Text = "";
            date_of_flight.Text = "";
            seat_no.Text = "";
            remark.Text = "";
            remark2.Text = "";
        }

        #endregion

        private void group_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}
