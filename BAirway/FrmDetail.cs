using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BAW.Dao;
using BAW.Model;
using BAW.Biz;
using BAW.Utils;
using System.Collections;
//using BAirway.Report;

namespace BAirway
{
    public partial class FrmDetail : Form
    {
        private String btnActionName = "Save";
        private TransactionDao tranDao = new TransactionDao();
        private AuthenCodeDao authenDao = new AuthenCodeDao();
        private ModelTransaction model = null;
        private FrmMain main;
        private MenuLangDao menuLangDao = new MenuLangDao();
        private Hashtable listMenuLangLabel = new Hashtable();


        private Boolean onlineStatus = false;
        private int StationID = -1;
        private int staffId = -1;
        private int lounge = -1;
        private int area = -1;

        ModelAuthenCode accessCode = new ModelAuthenCode();

        public FrmDetail(FrmMain _main, ModelTransaction _model)
        {
            InitializeComponent();
            this.main = _main;
            this.model = _model;
        }

        private void FrmDetail_Load(object sender, EventArgs e)
        {
            //check offine mode
            #region Initial variable
            StationID = Convert.ToInt32(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID"));
            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo") != null)
            {
                String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');
                staffId = Convert.ToInt32(userInfo[0]);
                lounge = Convert.ToInt32(userInfo[1]);
                area = Convert.ToInt32(userInfo[2]);
            }
            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "OnlineStatus") != null)
            {
                onlineStatus = (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "OnlineStatus").Equals("1")) ? true : false;
            }
            #endregion

            if (model != null)
            {
                remakr2.Text = model.remakr2;
                remark.Text = model.remark;
                B_ACCESS_CODE.Text = model.ath_id + "";
            }
            List<ModelAuthenCode> codes = (onlineStatus) ? authenDao.Select(" where ath_code='" + model.ath_id + "'", StationID) : authenDao.SelectOffine(" where ath_code='" + model.ath_id + "'", StationID);
            if (codes.Count > 0)
            {
                accessCode = codes[0];
                B_ACCESS_CODE.Text = codes[0].ath_code;

            }
            //
            if (onlineStatus)
            {
                label3.Text = String.Format(label3.Text, main.staffModel.user_name);
            }
            else
            {
                label3.Text = String.Format(label3.Text, staffId);
            }
            this.listMenuLangLabel = menuLangDao.Select();
            //foreach (Control control in groupBox1.Controls)
            //{
            //    if (control is Label)
            //    {
            //        Console.WriteLine(String.Format("{0},{1},{2}", this.Name, control.Name, control.Text));

            //    }
            //}
            //Console.WriteLine();

            chnageLabel();
        }
        private void chnageLabel()
        {
            String defaultLang = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "DefaultLang");
            if (defaultLang != null)
            {
                defaultLang = defaultLang.Split('|')[1];
                foreach (Control control in groupBox1.Controls)
                {
                    if (control is Label)
                    {
                        String key = String.Format("{0}|{1}|{2}", this.Name, control.Name, defaultLang);
                        if (listMenuLangLabel[key] != null)
                        {
                            control.Text = listMenuLangLabel[key].ToString();
                        }

                    }
                }
            }
        }

        private void B_SAVE1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Boolean result = false;

            this.model.remakr2 = remakr2.Text;
            this.model.remark = remark.Text;
            this.model.ath_id = (accessCode == null) ? model.ath_id : accessCode.ath_code;
            this.model.update_by = (onlineStatus) ? this.main.staffModel.id : staffId;
            this.model.update_date = DateTime.Now;
            if ((onlineStatus) ? tranDao.Update(this.model, StationID) : tranDao.UpdateOffline(this.model, StationID))
            {
                accessCode.ath_use = "1";
                result = (onlineStatus) ? authenDao.Update(accessCode) : authenDao.UpdateOffine(accessCode);
            }
            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
            //Refresh Main
            accessCode = null;
            main.refreshData();
            clear();
            Cursor = Cursors.Default;
            Close();
        }

        private void B_DEL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tranDao.Delete(model, StationID);
                MessageBox.Show("Delete success.");

                //Refresh Main
                main.refreshData();
                Close();
            }
        }

        private void B_CANCEL_Click(object sender, EventArgs e)
        {
            switch (btnActionName)
            {
                case "Save":
                    group_id.Text = "";
                    passenger_name.Text = "";
                    txt_barcode.Text = "";
                    from_city.Text = "";
                    to_city.Text = "";
                    flight_no.Text = "";
                    date_of_flight.Text = "";
                    seat_no.Text = "";
                    remark.Text = "";
                    airline_code.Text = "";
                    remakr2.Text = "";
                    txt_barcode.Focus();
                    break;
                default:
                    Close();
                    break;
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

        private void CMD_REGEN_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Boolean result = false;
            String cri = "where ath_use = 0";
            List<ModelAuthenCode> lists = (onlineStatus) ? authenDao.Select(cri, StationID) : authenDao.SelectOffine(cri, StationID);            
            if (lists.Count > 0)
            {
                accessCode = lists[0];
                B_ACCESS_CODE.Text = accessCode.ath_code;
                model.ath_id = accessCode.ath_code;
                model.update_by = (onlineStatus) ? this.main.staffModel.id : staffId;
                model.update_date = DateTime.Now;
                if ((onlineStatus) ? tranDao.Update(model, StationID) : tranDao.UpdateOffline(model, StationID))
                {
                    accessCode.ath_use = "1";
                    result = (onlineStatus) ? authenDao.Update(accessCode) : authenDao.UpdateOffine(accessCode);
                }
                MessageBox.Show("เปลี่ยนแปลง Access Code เรียบร้อยแล้ว");
                main.refreshData();
            }
            else
            {
                MessageBox.Show("Access Code ไม่เพียงพอ");
            }
            Cursor = Cursors.Default;

        }

        private void CMD_PRINT_Click(object sender, EventArgs e)
        {

            if (!B_ACCESS_CODE.Text.Equals(""))
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            String expireDate = DateTime.Now.AddHours(3).ToString();
            String ssidName = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SSIDName");
            String accessCode = B_ACCESS_CODE.Text;
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
            e.Graphics.DrawString(accessCode, new Font("Arial", 10), Brushes.Black, 80, 55);
            e.Graphics.DrawString(template_p2, new Font("Arial", 8), Brushes.Black, 0, 75);
            e.Graphics.DrawString(template_p3, new Font("Arial", 6), Brushes.Black, 0, 95);
            e.Graphics.DrawString("-", new Font("Arial", 6), Brushes.Black, 0, 225);

        }

        private void group_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void clear()
        {
            passenger_name.Text = "";
            from_city.Text = "";
            to_city.Text = "";
            airline_code.Text = "";
            flight_no.Text = "";
            date_of_flight.Value = DateTime.Now;
            seat_no.Text = "";
            remark.Text = "";
            remakr2.Text = "";
            btnActionName = "";
            B_DEL.Visible = false;
            CMD_REGEN.Visible = false;
            txt_barcode.Text = "";
            txt_barcode.Select();
        }
    }
}
