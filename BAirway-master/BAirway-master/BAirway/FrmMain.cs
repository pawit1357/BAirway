using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BAW.Model;
using BAW.Utils;
using BAW.Dao;
using BAW.Biz;
using System.Text.RegularExpressions;

namespace BAirway
{
    public partial class FrmMain : Form
    {
        private StationDao siteDao = new StationDao();

        #region "DECLARE"
        public int rowIndex = -1;
        private AreaDao areaDao = new AreaDao();
        private LoungeDao loungeDao = new LoungeDao();
        private GroupDao groupDao = new GroupDao();
        private TransactionDao dao = new TransactionDao();
        private AuthenCodeDao authenDao = new AuthenCodeDao();
        public ModelTransaction tran = null;

        public ModelUser staffModel = null;
        private Boolean bClickNextMonth = false;

        private Boolean onlineStatus = false;
        private int StationID = -1;
        private int staffId = -1;
        private int lounge = -1;
        private int area = -1;

        private Boolean bSelectCreateDate = true;
        private String stationName = "";
        private String loungeName = "";
        private String areaName = "";
        #endregion

        public FrmMain()
        {
            InitializeComponent();

        }
        public FrmMain(ModelUser _staffModel)
        {
            InitializeComponent();
            this.staffModel = _staffModel;

        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //check offine mode
            #region Initial variable
            StationID = Convert.ToInt16(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID"));
            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo") != null)
            {
                String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');
                staffId = Convert.ToInt16(userInfo[0]);
                lounge = Convert.ToInt16(userInfo[1]);
                area = Convert.ToInt16(userInfo[2]);
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

            switch (staffModel.user_role)
            {
                case 9:
                    lounge_site.Enabled = true;
                    lounge_site.DataSource = (onlineStatus) ? siteDao.Select("") : siteDao.SelectOffine("");
                    break;
                default:
                    lounge_site.Enabled = false;
                    lounge_site.DataSource = (onlineStatus) ? siteDao.Select(" Where id='" + StationID + "'") : siteDao.SelectOffine(" Where id='" + StationID + "'");
                    break;
            }

            L_SITE_DESC.Text = loungeName + "-" + areaName;

            group_id.DataSource = (onlineStatus) ? groupDao.Select("") : groupDao.SelectOffine("");

            if (lounge > 0)
            {
                comboLounge.SelectedValue = lounge;
            }
            if (area > 0)
            {
                comboArea.SelectedValue = area;
            }

            //List<ModelLounge> listLounge = (onlineStatus) ? loungeDao.Select(" Where area_station ='" + StationID + "' and area_lounge='" + lounge + "'") : loungeDao.SelectOffine(" Where area_station ='" + StationID + "' and area_lounge='" + lounge + "'");
            //if (listLounge.Count > 0)
            //{
            //    ModelLounge model1 = new ModelLounge();
            //    model1.id = -1;
            //    //model1.id = "";
            //    model1.lounge_name = "";
            //    listLounge.Insert(0, model1);
            //}
            //comboLounge.DataSource = listLounge;
            //List<ModelArea> listArea = (onlineStatus) ? areaDao.Select(" Where area_station ='" + StationID + "' and area_lounge='" + lounge + "'") : areaDao.SelectOffine(" Where area_station ='" + StationID + "' and area_lounge='" + lounge + "'");
            //if (listArea.Count > 0)
            //{
            //    ModelArea model1 = new ModelArea();
            //    model1.id = -1;
            //    model1.area_code = "";
            //    model1.area_name = "";
            //    listArea.Insert(0, model1);
            //}
            //comboArea.DataSource = listArea;




            refreshData();
        }
        private void B_SEARCH_Click(object sender, EventArgs e)
        {


            Cursor = Cursors.WaitCursor;
            if (Convert.ToInt32(date_of_flight_start.Value.ToString("yyyyMMdd")) > Convert.ToInt32(date_of_flight_end.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("วันที่เริ่มต้นต้องน้อยกว่าวันที่สิ้นสุด");
                return;
            }
            if (Convert.ToInt32(create_date_stsart.Value.ToString("yyyyMMdd")) > Convert.ToInt32(create_date_end.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("วันที่เริ่มต้นต้องน้อยกว่าวันที่สิ้นสุด");
                return;
            }
            String cri = "";
            //ModelTransaction tran = new ModelTransaction();
            StringBuilder sb = new StringBuilder();

            List<String> where = new List<string>();
            //List<String> or = new List<string>();

            if (!passenger_name.Text.Equals(""))
            {
                //tran.passenger_name = passenger_name.Text;
                where.Add(" passenger_name like '%" + passenger_name.Text + "%'");
            }
            if (!group_id.Text.Equals(""))
            {
                //tran.group_id = Convert.ToInt16(group_id.SelectedValue);
                where.Add(" group_id =" + group_id.SelectedValue);
            }
            if (!comboLounge.Text.Equals(""))
            {
                //tran.LoungeArea = Convert.ToInt16(comboArea.SelectedValue);
                where.Add(" LoungeType =" + comboLounge.SelectedValue);
            }
            if (!comboArea.Text.Equals(""))
            {
                //tran.LoungeArea = Convert.ToInt16(comboArea.SelectedValue);
                where.Add(" LoungeArea =" + comboArea.SelectedValue);
            }
            if (!accessCode.Text.Equals(""))
            {
                //tran.ath_id = accessCode.Text;
                where.Add(" ath_id = " + accessCode.Text);
            }
            if (!from_city.Text.Equals(""))
            {
                //tran.from_city = from_city.Text;
                where.Add(" from_city like '%" + from_city.Text + "%'");
            }
            if (!to_city.Text.Equals(""))
            {
                //tran.to_city = to_city.Text;
                where.Add(" to_city like '%" + to_city.Text + "%'");
            }
            if (!airline_code.Text.Equals(""))
            {
                //tran.airline_code = airline_code.Text;
                where.Add(" airline_code like '%" + airline_code.Text + "%'");
            }
            if (!flight_no.Text.Equals(""))
            {
                //tran.flight_no = flight_no.Text;
                if (MyFunction.isNumber(flight_no.Text))
                {
                    where.Add(" flight_no like '%" + Convert.ToInt16(flight_no.Text) + "%'");
                }
                else
                {
                    where.Add(" flight_no like '%" + flight_no.Text + "%'");
                }
            }
            if (!cbAllFlight.Checked)
            {
                if (!date_of_flight_start.Text.Equals("") && !date_of_flight_end.Text.Equals(""))
                {
                    if (!bSelectCreateDate)
                    {
                        where.Add("date(date_of_flight) between date('" + date_of_flight_start.Value.ToString("yyyy-MM-dd") + "') and date('" + date_of_flight_end.Value.ToString("yyyy-MM-dd") + "')");
                    }
                }
            }
            if (!cbGenAll.Checked)
            {
                //tran.create_date_custom = create_date_stsart.Text;
                if (!create_date_stsart.Text.Equals("") && !create_date_end.Text.Equals(""))
                {
                    if (bSelectCreateDate)
                    {
                        where.Add("date(create_date) between date('" + create_date_stsart.Value.ToString("yyyy-MM-dd") + "') and date('" + create_date_end.Value.ToString("yyyy-MM-dd") + "')");
                    }
                }
            }
            if (!seat_no.Text.Equals(""))
            {
                where.Add(" seat_no like '%" + seat_no.Text + "%'");
            }

            if (where.Count > 0)
            {
                cri = "where ";


                for (int i = 0; i < where.Count; i++)
                {
                    if (i == 0)
                    {
                        cri += where[i];
                    }
                    else
                    {
                        cri += " and " + where[i];
                    }
                }

                //for (int i = 0; i < or.Count; i++)
                //{
                //    if (i == 0)
                //    {
                //        cri += or[i];
                //    }
                //    else
                //    {
                //        cri += " or " + or[i];
                //    }
                //}

            }
            searchData(cri);
            Cursor = Cursors.Default;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 1)
            {
                e.CellStyle.BackColor = Color.Lavender;
            }
            //String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');
            //if (!onlineStatus)
            //{
            switch (e.ColumnIndex)
            {
                case 1: e.Value = e.RowIndex + 1;
                    break;
            }
            //}
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Cursor = Cursors.WaitCursor;
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                String cri = " where t.id=" + id;
                List<ModelTransaction> lists = (onlineStatus) ? dao.Select(cri, StationID) : dao.SelectOffine(cri, StationID);
                if (lists.Count > 0)
                {
                    tran = lists[0];
                    FrmDetail frmManualGen = new FrmDetail(this, tran);
                    frmManualGen.ShowDialog();
                }
                Cursor = Cursors.Default;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void B_CLEAR_Click(object sender, EventArgs e)
        {
            passenger_name.Text = String.Empty;
            group_id.SelectedValue = String.Empty;
            from_city.Text = String.Empty;
            to_city.Text = String.Empty;
            airline_code.Text = String.Empty;
            flight_no.Text = String.Empty;
            accessCode.Text = string.Empty;
            cbAllFlight.Checked = true;
            cbGenAll.Checked = true;

            date_of_flight_start.Value = DateTime.Now;
            date_of_flight_end.Value = DateTime.Now;
            create_date_stsart.Value = DateTime.Now;
            create_date_end.Value = DateTime.Now;

            seat_no.Text = String.Empty;
        }

        #region "Method"

        public void refreshData()
        {
            String cri = "where date(create_date) = date('" + DateTime.Now.ToString("yyyy-MM-dd") + "') and LoungePlace=" + StationID + " order by create_date desc";

            List<ModelTransaction> lists = (onlineStatus) ? dao.Select(cri, StationID) : dao.SelectOffine(cri, StationID);
            if (lists.Count > 0)
            {

                dataGridView1.DataSource = lists;
                lbRecords.Text = String.Format("Total {0} records", dataGridView1.RowCount);
            }
            else
            {
                dataGridView1.DataSource = null;
                lbRecords.Text = String.Format("Total {0} records", 0);
            }

            dataGridView1.AutoGenerateColumns = false;

        }

        public void searchData(String cri)
        {
            cri = cri.Equals("") ? " Where LoungePlace=" + StationID : cri + " and LoungePlace=" + StationID;
            List<ModelTransaction> lists = (onlineStatus) ? dao.Select(cri + " order by create_date desc", StationID) : dao.SelectOffine(cri + " order by create_date desc", StationID);
            //List<ModelTransaction> lists = (onlineStatus) ? dao.Select(cri + " order by update_date desc", StationID) : dao.SelectOffine(cri + " order by update_date desc", StationID);
            if (lists.Count > 0)
            {
                dataGridView1.DataSource = lists;
                if (!bClickNextMonth)
                {
                    //MessageBox.Show("พบขอ้มูลทั้งหมด " + lists.Count + " records");
                    lbRecords.Text = String.Format("Total {0} records", dataGridView1.RowCount);
                }
            }
            else
            {
                dataGridView1.DataSource = null;
                lbRecords.Text = String.Format("Total {0} records", 0);
                MessageBox.Show("ไม่พบข้อมูล");
            }
            passenger_name.Focus();
        }

        #endregion

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void group_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 47)
                e.Handled = true;
        }

        private void lounge_site_SelectedIndexChanged(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            StationID = Convert.ToInt16(lounge_site.SelectedValue);

            List<ModelLounge> loungeList = (onlineStatus) ? loungeDao.Select("where l.lounge_station=" + StationID) : loungeDao.SelectOffline("where l.lounge_station=" + StationID);
            ModelLounge model1 = new ModelLounge();
            model1.id = -1;
            //model1.id = "";
            model1.lounge_name = "";
            loungeList.Insert(0, model1);
            comboLounge.DataSource = loungeList;
            refreshData();
            Cursor = Cursors.Default;
        }

        private void comboLounge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(comboLounge.SelectedValue) > 0)
            {
                List<ModelArea> listArea = (onlineStatus) ? areaDao.Select("where a.area_station=" + lounge_site.SelectedValue + " and a.area_lounge=" + comboLounge.SelectedValue) : areaDao.SelectOffine("where a.area_station=" + lounge_site.SelectedValue + " and a.area_lounge=" + comboLounge.SelectedValue);
                comboArea.DataSource = listArea;
            }
            else {
                comboArea.Text = "";
            }

        }

        private void date_of_flight_end_ValueChanged(object sender, EventArgs e)
        {
            bSelectCreateDate = false;
        }

        private void create_date_end_ValueChanged(object sender, EventArgs e)
        {
            bSelectCreateDate = true;
        }



        private void passenger_name_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    // SelectNext(this);
                    break;
                default:
                    //base.OnKeyDown(e);
                    break;
            }
        }
    }
}
