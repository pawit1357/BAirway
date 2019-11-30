using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Net;
using BAW.Biz;
using BAW.Utils;
using BAW.Model;
using BAW.Dao;
using System.Drawing;
using System.Threading;

namespace BAirway
{
    public partial class FrmMenu : Form
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FrmMenu));
        public ModelUser userModel = null;

        private FrmMain frmMain = null;
        private FrmAutoGen frmAutoGen = null;
        private FrmManualGen frmManualGen = null;

        private Boolean onlineStatus = false;

        public FrmMenu()
        {
            InitializeComponent();
        }
        private void FrmMenu_Load(object sender, EventArgs e)
        {

            if (ManageLOG.Formula(ManageLOG.deCode(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "SK"))) &&
           !ManageLOG.deCode(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "CON")).Equals("")
            && File.Exists(String.Format(@"C:\{0}\{1}\{2}", Configurations.AppFolder, Configurations.LocalDbFolder, Configurations.DbFile))
            )
            {
                //Check server is alive

                FrmLogin frmLogin = new FrmLogin();
                frmLogin.ShowDialog();
                if (frmLogin.click.Equals("OK"))
                {
                    this.userModel = frmLogin.userModel;
                    if (userModel.user_role == 5)
                    {
                        FrmSelfRegister frmSelf = new FrmSelfRegister();
                        frmSelf.ShowDialog();
                    }
                    else
                    {
                        if (Connection.IsServerConnected())
                        {
                            Cursor = Cursors.WaitCursor;
                            //upload data from localdb-->online db
                            #region "Syncronize Data"
                            Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
                            thread.Start();
                            #endregion

                            tsOnlineStatus.ForeColor = Color.Green;
                            tsOnlineStatus.Text = "Online";
                            ManageLOG.writeRegistry(Configurations.AppRegName, "OnlineStatus", "1");
                            onlineStatus = true;

                            #region "Check has pos logo"

                            if (!Directory.Exists(String.Format(@"C:\{0}\\{1}\\", Configurations.AppFolder, Configurations.ImagePath)))
                            {
                                Directory.CreateDirectory(String.Format(@"C:\{0}\\{1}\\", Configurations.AppFolder, Configurations.ImagePath));
                            }
                            //Check file exist
                            if (!File.Exists(Configurations.PosLogoPath))
                            {
                                WebClient client1 = new WebClient();
                                client1.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                                client1.DownloadFileAsync(new Uri(Configurations.DownloadPosLogoURL), Configurations.PosLogoPath);
                            }
                            #endregion
                        }
                        else
                        {
                            //OFFLINE MODE
                            tsOnlineStatus.ForeColor = Color.Red;
                            tsOnlineStatus.Text = "Offline";

                            ManageLOG.writeRegistry(Configurations.AppRegName, "OnlineStatus", "0");
                            onlineStatus = false;

                            TSM_02.Visible = false;
                            TSM_03.Visible = false;
                            TSM_04.Visible = false;
                            TSM_01_01.Visible = false;
                            TSM_01_03.Visible = false;
                        }

                        initial();
                        Cursor = Cursors.Default;
                    }
                }
            }
            else
            {
                FrmSetting setting = new FrmSetting();
                setting.ShowDialog();
            }
        }

        private void initial()
        {

            if (userModel == null)
            {
                Application.Exit();//if alt+f4 exit app
            }
            else
            {
                //Set Status
                toolStripStatusLabel1.Text = "ผู้ใช้งานปัจจุบัน: " + userModel.user_name;
                String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');
                toolStripStatusLabel2.Text = "สถานะ: " + userInfo[7];

                //set role
                switch (userModel.user_role)
                {
                    case 1://Admin
                        TSB_01.Visible = true;//Manual
                        TSB_03.Visible = true;//Auto Gen
                        /* ================================ */
                        TSM_02.Visible = true;//ข้อมูลหลัก
                        toolStripSeparator4.Visible = false;// เส้นแบ่ง
                        TSM_02_01.Visible = false; 	//acccode
                        TSM_02_02.Visible = false; 	//site
                        TSM_02_05.Visible = false;	//role
                        /* ================================ */
                        TSM_03.Visible = true;//Report
                        /* ================================ */
                        TSM_04.Visible = true;//ตัวเลือก
                        TSM_04_01.Visible = true;	//Configuration
                        TSM_04_02.Visible = false;	//Import Authen Code
                        TSM_04_03.Visible = false;	//Ftp setting
                        TSM_04_04.Visible = false;	//จัดการข้อมูล Access Code
                        /* ================================ */
                        break;
                    case 2:
                        break;
                    case 3://USER
                        TSB_01.Visible = true;   //Manual
                        TSB_03.Visible = true;   //Auto Gen
                        /* ================================ */
                        TSM_02.Visible = false;  //ข้อมูลหลัก
                        toolStripSeparator4.Visible = false;// เส้นแบ่ง
                        TSM_02_01.Visible = false; 	//acccode
                        TSM_02_02.Visible = false; 	//site
                        TSM_02_05.Visible = false;	//role
                        /* ================================ */
                        TSM_03.Visible = false;  //Report
                        /* ================================ */
                        TSM_04.Visible = false;  //ตัวเลือก
                        TSM_04_01.Visible = false;	//Configuration
                        TSM_04_02.Visible = false;	//Import Authen Code
                        TSM_04_03.Visible = false;	//Ftp setting
                        TSM_04_04.Visible = false;	//จัดการข้อมูล Access Code
                        /* ================================ */
                        break;
                    case 4:
                        break;
                    case 9://SPECIAL (Cat support)
                        TSB_01.Visible = true;//Manual
                        TSB_03.Visible = true;//Auto Gen
                        /* ================================ */
                        TSM_02.Visible = true;//ข้อมูลหลัก
                        toolStripSeparator4.Visible = true;// เส้นแบ่ง
                        TSM_02_01.Visible = true; 	//acccode
                        TSM_02_02.Visible = true; 	//site
                        TSM_02_05.Visible = true;	//role
                        /* ================================ */
                        TSM_03.Visible = true;//Report
                        /* ================================ */
                        TSM_04.Visible = true;//ตัวเลือก
                        TSM_04_01.Visible = true;	//Configuration
                        TSM_04_02.Visible = true;	//Import Authen Code
                        TSM_04_03.Visible = true;	//Ftp setting
                        TSM_04_04.Visible = true;	//จัดการข้อมูล Access Code
                        /* ================================ */
                        break;
                }
                //Open main
                if (this != null)
                {
                    frmMain = new FrmMain(userModel);
                    frmMain.MdiParent = this;
                    frmMain.WindowState = FormWindowState.Maximized;
                    frmMain.Show();

                    frmManualGen = new FrmManualGen();
                    frmManualGen.MdiParent = this;
                    frmManualGen.WindowState = FormWindowState.Maximized;

                    frmAutoGen = new FrmAutoGen();
                    frmAutoGen.MdiParent = this;
                    frmAutoGen.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    Application.Exit();
                }
            }

        }

        private void TSM_01_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string name = "";
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem tsm = (ToolStripMenuItem)sender;
                name = tsm.Name;
            }
            if (sender is ToolStripButton)
            {
                ToolStripButton tsb = (ToolStripButton)sender;
                name = tsb.Name;
            }

            switch (name)
            {
                #region "FILE"
                case "TSM_01_01":
                    if (userModel != null)
                    {
                        FrmEditProfile editProfile = new FrmEditProfile(this.frmMain, userModel);
                        editProfile.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("เกิดข้อผิดพลาด");
                    }
                    break;
                case "TSM_01_02":
                    break;
                case "TSM_01_03":
                    userModel = null;
                    frmMain.Close();

                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.ShowDialog();
                    if (frmLogin.click.Equals("OK"))
                    {
                        this.userModel = frmLogin.userModel;
                        /*.SELF_REGSITER.*/
                        if (userModel.user_role == 5)
                        {
                            FrmSelfRegister frmSelf = new FrmSelfRegister();
                            frmSelf.ShowDialog();
                        }
                        else
                        {
                            initial();
                        }
                    }
                    break;
                case "TSM_01_04":
                    if (onlineStatus)
                    {
                        ManageLOG.writeLoginLogs(userModel.id, ModelUserLogs.EVENT_LOGOUT, "Logout");
                    }
                    Application.Exit();

                    break;
                #endregion
                #region "MASTER DATA"
                case "TSM_02_01":
                case "TSM_04_04":
                    FrmAuthenCode frmAuthenCode = new FrmAuthenCode();
                    frmAuthenCode.ShowDialog();
                    break;
                case "TSM_02_02":
                    FrmSite frmSite = new FrmSite();
                    frmSite.ShowDialog();
                    break;
                case "TSM_02_03":
                    FrmLounge frmLounge = new FrmLounge();
                    frmLounge.ShowDialog();
                    break;
                case "TSM_02_04":
                    FrmStaff frmuser = new FrmStaff();
                    frmuser.ShowDialog();
                    break;
                case "TSM_02_05":
                    FrmRole frmRole = new FrmRole();
                    frmRole.ShowDialog();
                    break;
                case "TSM_02_06":
                    FrmArea frmArea = new FrmArea();
                    frmArea.ShowDialog();
                    break;
                case "TSM_02_07":
                    FrmGroup frmGroup = new FrmGroup();
                    frmGroup.ShowDialog();
                    break;
                #endregion
                #region "REPORT"
                case "TSM_03":
                    FrmReport frmReport = new FrmReport();
                    frmReport.ShowDialog();
                    break;
                case "TSM_04_02":
                    FrmLoad frmLoad = new FrmLoad();
                    frmLoad.ShowDialog();
                    break;
                case "TSM_04_03":
                    FrmFtp frmFtp = new FrmFtp();
                    frmFtp.ShowDialog();
                    break;
                #endregion
                #region "OPTION"
                case "TSM_04_01":
                    FrmConfiguration frmConfig = new FrmConfiguration();
                    frmConfig.ShowDialog();
                    break;
                #endregion
                #region "HELP"
                case "TSM_05_01":
                    AboutBox about = new AboutBox();
                    about.ShowDialog();
                    break;
                case "TSM_05_02":
                    String sourcePath = String.Format(@"C:\{0}\BangkokAirwaysWiFiManagement_Manual.pdf", Configurations.AppFolder);
                    if (!File.Exists(sourcePath))
                    {
                        // Create an instance of WebClient
                        WebClient client = new WebClient();
                        // Hookup DownloadFileCompleted Event
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                        // Start the download and copy the file to c:\temp
                        client.DownloadFileAsync(new Uri("http://www.prdapp.net/install/BangkokAirways/Doc/BangkokAirwaysWiFiManagement_Manual.pdf"), String.Format(@"C:\{0}\", Configurations.AppFolder) + "BangkokAirwaysWiFiManagement_Manual.pdf");

                    }
                    System.Threading.Thread.Sleep(2000);
                    System.Diagnostics.Process.Start(String.Format(@"C:\{0}\BangkokAirwaysWiFiManagement_Manual.pdf", Configurations.AppFolder));
                    break;
                #endregion
                #region "TOOL BAR"
                case "TSB_00":
                    if (onlineStatus)
                    {
                        if (frmMain.IsDisposed)
                        {
                            frmMain = new FrmMain();
                            frmMain.MdiParent = this;
                        }
                        frmMain.WindowState = FormWindowState.Maximized;
                        frmMain.Show();
                        frmMain.refreshData();

                        frmAutoGen.Hide();
                        frmManualGen.Hide();
                    }
                    else
                    {
                        if (frmMain.IsDisposed)
                        {
                            frmMain = new FrmMain();
                            frmMain.MdiParent = this;
                        }
                        frmMain.WindowState = FormWindowState.Maximized;
                        frmMain.Show();
                        frmMain.refreshData();

                        if (frmAutoGen != null)
                        {
                            frmAutoGen.Hide();
                        }
                        if (frmManualGen != null)
                        {
                            frmManualGen.Hide();
                        }
                    }
                    break;
                case "TSB_01":
                    if (onlineStatus)
                    {
                        if (frmManualGen.IsDisposed)
                        {
                            frmManualGen = new FrmManualGen();
                            frmManualGen.MdiParent = this;
                        }
                        frmManualGen.WindowState = FormWindowState.Maximized;
                        frmManualGen.Show();
                        frmManualGen.refreshData();

                        frmMain.Hide();
                        frmAutoGen.Hide();
                    }
                    else
                    {
                        if (frmManualGen.IsDisposed)
                        {
                            frmManualGen = new FrmManualGen();
                            frmManualGen.MdiParent = this;
                        }
                        frmManualGen.WindowState = FormWindowState.Maximized;
                        frmManualGen.Show();
                        frmManualGen.refreshData();

                        if (frmMain != null)
                        {
                            frmMain.Hide();
                        }
                        if (frmAutoGen != null)
                        {
                            frmAutoGen.Hide();
                        }
                    }
                    break;
                case "TSB_03":
                    if (onlineStatus)
                    {
                        if (frmAutoGen.IsDisposed)
                        {
                            frmAutoGen = new FrmAutoGen();
                            frmAutoGen.MdiParent = this;
                        }
                        frmAutoGen.WindowState = FormWindowState.Maximized;
                        frmAutoGen.Show();
                        frmAutoGen.refreshData();

                        frmMain.Hide();
                        frmManualGen.Hide();
                    }
                    else
                    {
                        if (frmAutoGen.IsDisposed)
                        {
                            frmAutoGen = new FrmAutoGen();
                            frmAutoGen.MdiParent = this;
                        }
                        frmAutoGen.WindowState = FormWindowState.Maximized;
                        frmAutoGen.Show();
                        frmAutoGen.refreshData();

                        if (frmMain != null)
                        {
                            frmMain.Hide();
                        }
                        if (frmManualGen != null)
                        {
                            frmManualGen.Hide();
                        }
                    }
                    break;
                #endregion
            }
            Cursor = Cursors.Default;
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            logger.Debug("Download document success.");
        }


        public void WorkThreadFunction()
        {
            try
            {
                TransactionUtil.transfer2Server();
                TransactionUtil.downloadStation();
                TransactionUtil.downloadAuthenCode();
                TransactionUtil.downloadUsers();
                TransactionUtil.downloadLounge();
                TransactionUtil.downloadArea();
                TransactionUtil.downloadGroup();
                TransactionUtil.downloadRole();
                // do any background work
            }
            catch (Exception ex)
            {
                // log errors
                logger.Equals(ex.Message);
            }
        }
    }
}
