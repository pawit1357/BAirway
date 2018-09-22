using BAW.Biz;
using BAW.Dao;
using BAW.Model;
using BAW.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BAirway
{
    public partial class FrmLogin : Form
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FrmLogin));
        private StationDao siteDao = null;
        private LoungeDao loungeDao = null;
        private AreaDao areaDao = null;
        private RoleDao roleDao = null;
        private String StationID = "";

        public ModelUser userModel = null;
        private MenuLangDao menuLangDao = new MenuLangDao();
        private Hashtable listMenuLangLabel = new Hashtable();
        public string click = "";
        private int staffId = -1;
        private int loungeId = -1;
        private int areaId = -1;
        private int roleId = -1;
        private String roleName;
        private String username;
        private String password;
        private String stationName;

        private Boolean status = false;
        public Boolean isInit = true;
        public FrmLogin()
        {
            InitializeComponent();
           
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.listMenuLangLabel = menuLangDao.Select();

            StationID = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID");
            String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');
            //1 4,1,26,สนามบินสุวรรณภูมิ Inter,Lounge Inter,Area 1,1,Admin,admin1,admin1
            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "OnlineStatus") != null)
            {
                status = (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "OnlineStatus").Equals("1")) ? true : false;
            }

            if (userInfo.Length >= 1)
            {
                staffId = Convert.ToInt32(userInfo[0]);
            }
            if (userInfo.Length >= 2)
            {
                loungeId = Convert.ToInt32(userInfo[1]);
            }
            if (userInfo.Length >= 3)
            {
                areaId = Convert.ToInt32(userInfo[2]);
            }
            if (userInfo.Length >= 4)
            {
                stationName = userInfo[3];
                station.Text = stationName;
            }
            if (userInfo.Length >= 7)
            {
                roleId = Convert.ToInt32(userInfo[6]);
            }
            if (userInfo.Length >= 8)
            {
                roleName = userInfo[7];
            }
            if (userInfo.Length >= 9)
            {
                username = userInfo[8];
            }
            if (userInfo.Length >= 10)
            {
                password = userInfo[9];
            }

            siteDao = new StationDao();
            loungeDao = new LoungeDao();
            areaDao = new AreaDao();
            roleDao = new RoleDao();

            //Check server is alive
            #region "MENU LANGE"
            List<MasterModel> menuLangs = new List<MasterModel>();
            String[] menuLang = { "TH", "EN" };
            int index = 0;
            foreach(String m in menuLang)
            {
                MasterModel mModel = new MasterModel
                {
                    id = index,
                    name = m
                };
                menuLangs.Add(mModel);
                index++;
            }
            cboLang.DataSource = menuLangs;

            #endregion
            #region "LOUNGES"
            List<ModelLounge> lounges = (status) ? loungeDao.Select(" where l.lounge_station=" + StationID) : loungeDao.SelectOffline(" where l.lounge_station=" + StationID);
            lounge.DataSource = lounges;
            try
            {
                bool bIsLoungeChild = false;
                foreach (ModelLounge l in lounges)
                {
                    if (l.id == loungeId)
                    {
                        bIsLoungeChild = true;
                        break;
                    }
                }
                if (bIsLoungeChild)
                {
                    if (loungeId > 0)
                    {
                        lounge.SelectedValue = loungeId;
                    }
                    else
                    {
                        lounge.SelectedIndex = 0;
                    }
                }
                else {
                    lounge.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                //lounge.SelectedIndex = 0;
            }
            #endregion
            #region "AREA"
            List<ModelArea> areas =(status) ? areaDao.Select(" where a.area_station=" + StationID + " and a.area_lounge=" + lounge.SelectedValue) : areaDao.SelectOffine(" where a.area_station=" + StationID + " and a.area_lounge=" + lounge.SelectedValue);
            area.DataSource = areas;
            #endregion

            try
            {
                bool bIsAreaChild = false;
                foreach (ModelArea a in areas)
                {
                    if (a.id == areaId)
                    {
                        bIsAreaChild = true;
                        break;
                    }
                }
                if (bIsAreaChild)
                {
                    if (areaId > 0)
                    {
                        area.SelectedValue = areaId;
                    }
                    else
                    {
                        area.SelectedIndex = 0;
                    }
                }
                else {
                    area.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                //area.SelectedIndex = 0;
            }

            LAPPTITLE.Text = Application.ProductName;
            LAPPCOMPANY.Text = Application.CompanyName;
            LUPDATE_DATE.Text = "Version " + Application.ProductVersion;
            UsernameTextBox.Focus();

            if (!status)
            {
                UsernameTextBox.Text = username;
                PasswordTextBox.Text = password;
            }




        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text.Equals("-") && PasswordTextBox.Text.Equals("-"))
            {
                UsernameTextBox.Text = "";
                PasswordTextBox.Text = "";
                UsernameTextBox.Focus();
            }
            else
            {

                if (checkLogin(UsernameTextBox.Text, PasswordTextBox.Text))
                {
                    click = "OK";
                    Close();
                    Dispose();
                }
                else
                {
                    MessageBox.Show("บัญชีผู้ใช้ไม่ถูกต้อง", Application.ProductName);
                    PasswordTextBox.SelectAll();
                    PasswordTextBox.Focus();
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            click = "CANCEL";
            Application.Exit();
        }

        public Boolean checkLogin(string user, string pass)
        {
            Cursor = Cursors.WaitCursor;
            string msg = "n";
            try
            {
                
                UserDao staffDao = staffDao = new UserDao();
                List<ModelUser> lists = (status) ? staffDao.Select(" Where u.user_name='" + user + "' and u.user_pass='" + pass + "'" + ((!user.Equals("cat@support")) ? " and u.station_id =" + StationID : "")) : staffDao.SelectOffine(" Where u.user_name='" + user + "' and u.user_pass='" + pass + "'" + ((!user.Equals("cat@support")) ? " and u.station_id =" + StationID : ""));
                if (lists.Count > 0)
                {
                    userModel = lists[0];
                    msg = "y";
                    ManageLOG.writeRegistry(Configurations.AppRegName, "UserInfo", userModel.id + "," + lounge.SelectedValue + "," + area.SelectedValue + "," + station.Text + "," + lounge.Text + "," + area.Text + "," + userModel.user_role + "," + ((status) ? roleDao.Select("where id=" + userModel.user_role)[0].role_name : roleDao.SelectOffline("where id=" + userModel.user_role)[0].role_name) + "," + userModel.user_name + "," + userModel.user_pass);
                }
                else
                {
                    logger.Debug("Login fail user:" + user + "," + pass);
                    msg = "n";
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
            }
            Cursor = Cursors.Default;
            return (msg == "y") ? true : false;
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OK.PerformClick();
            }
        }
        private void group_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void staff_lounge_SelectedIndexChanged(object sender, EventArgs e)
        {


            List<ModelArea> areaLists = (status) ? areaDao.Select(" where a.area_station=" + StationID + " and a.area_lounge=" + lounge.SelectedValue) : areaDao.SelectOffine(" where a.area_station=" + StationID + " and a.area_lounge=" + lounge.SelectedValue);
            if (areaLists != null && areaLists.Count > 0)
            {
                area.DataSource = areaLists;
            }
            else
            {
                MessageBox.Show("ไม่พบ Area ใน " + lounge.Text);
                lounge.SelectedIndex = 0;
                UsernameTextBox.Focus();
            }

        }

        private void cboLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterModel m = (MasterModel)cboLang.SelectedItem;
            if (isInit)
            {
                //if (!String.IsNullOrEmpty(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "DefaultLang")))
                //{
                    String defaultLang = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "DefaultLang");
                    if (defaultLang != null)
                    {
                        int selectedIndex = Convert.ToInt16(defaultLang.Split('|')[0]);
                        cboLang.SelectedIndex = selectedIndex;
                        isInit = false;
                    chnageLabel(defaultLang.Split('|')[1]);
                }
                //}
                //else
                //{
                //    ManageLOG.writeRegistry(Configurations.AppRegName, "DefaultLang", String.Format("{0}|{1}", m.id, m.name));

                //}
            }
            else
            {
                    ManageLOG.writeRegistry(Configurations.AppRegName, "DefaultLang", String.Format("{0}|{1}", m.id, m.name));
                chnageLabel(m.name);

            }


        }

        public void chnageLabel(String defaultLang)
        {
            foreach (Control control in base.Controls)
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
            lSupport.Text = String.Format(lSupport.Text, ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SupportCATInternet"), "");

        }
    }
}
