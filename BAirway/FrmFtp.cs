using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using BAW.Model;
using BAW.Dao;
using BAW.Utils;

namespace BAirway
{
    public partial class FrmFtp : Form
    {

        private List<ModelGroup> groups = new List<ModelGroup>();
        private List<ModelUser> users = new List<ModelUser>();
        private List<ModelStation> stations = new List<ModelStation>();
        private GroupDao groupDao = new GroupDao();
        private UserDao userDao = new UserDao();
        private StationDao siteDao = new StationDao();

        public FrmFtp()
        {
            InitializeComponent();
        }

        private void FrmFtp_Load(object sender, EventArgs e)
        {
            stations = siteDao.Select("");
            groups = groupDao.Select("");
            users = userDao.Select("");
        }

        private void B_UPLOAD_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int StationID = Convert.ToInt32(ManageLOG.getValueFromRegistry("WiFi Management", "StationID"));
            //----------------Create folder
            String folderName = @"C:\BangkokAirways\reports\" + DateTime.Now.ToString("yyyyMMdd") + "\\";
            String fileName = folderName + @"\Report_" + StationID + "_" + DateTime.Now.ToString("yyyyMMddHHmm")+ ".txt";
            DirectoryInfo di = new DirectoryInfo(@"" + folderName);
            if (!di.Exists) { di.Create(); }//ถ้าไม่พบ Folder ก็ทำการสร้างมันขึ้นมา
            //----------------Create File
            ManageLOG mangeLog = new ManageLOG();
            mangeLog.fileName = fileName;
            mangeLog.folderName = folderName;
            TransactionDao tranDao = new TransactionDao();

            String cri = "where date(create_date) = date('" + DateTime.Now.ToString("yyyy-MM-dd") + "') and LoungePlace=" + StationID + " order by update_date desc";
            List<ModelTransaction> lists = tranDao.Select(cri, StationID);
            int seq = 1;

            String header = "No,Username,Type,GenDate,GroupName,Duration,PassengerName,FromCity,ToCity,AirlineCode,FlightNo,DateOfFlight,SeatNo,LoungePlace,LoungeType,LoungeArea,Owner,Begin_Date,Status,Remark,AccessCode,Remark2,LastUpdate,LastUpdateBy";
            mangeLog.WriteLog(header);
            foreach (ModelTransaction transaction in lists)
            {
                mangeLog.WriteLog(
                       seq + "," +
                       "-,"+
                    transaction.type + "," +
                    transaction.create_date_custom + "," +
                    transaction.group_idName  + "," +
                    transaction.duration + "," +
                    transaction.passenger_name + "," +
                    transaction.from_city + "," +
                    transaction.to_city + "," +
                    transaction.airline_code + "," +
                    transaction.flight_no + "," +
                    transaction.date_of_flight_custom + "," +
                    transaction.seat_no + "," +
                    transaction.LoungeSite + "," +
                    transaction.LoungeName + "," +
                    transaction.LoungeAreaName + "," +
                    transaction.create_byName + "," +
                    transaction.begin_date_custom + "," +
                    transaction.status + "," +
                    transaction.remark + "," +
                    transaction.ath_id + "," +
                    transaction.remakr2 + "," +
                    transaction.update_date_custom + "," +
                    transaction.update_byName
                    );
                seq++;
            };

            //----------------Ftp File
            CustomUtils util = new CustomUtils();
            util.ftpServerIP = ftpServerIP.Text;
            util.ftpUserID = ftpUserID.Text;
            util.ftpPassword = ftpPassword.Text;
            Boolean result = util.Upload(fileName);
            Cursor = Cursors.Default;
            if (result)
            {
                MessageBox.Show("อัพโหลดเรียบร้อยแล้ว");
            }

        }

        private String findGroupName(String findPK)
        {
            String result = "";
            foreach (ModelGroup model in groups)
            {
                if (model.id == Convert.ToInt32(findPK))
                {
                    result = model.group_description;
                    break;
                }
            }
            return result;
        }

        private String findUserName(String findPK)
        {
            String result = "";
            foreach (ModelUser model in users)
            {
                if (model.id == Convert.ToInt32(findPK))
                {
                    result = model.user_name;
                    break;
                }
            }
            return result;
        }
        private String findStationName(String findPK)
        {
            String result = "";
            foreach (ModelStation model in stations)
            {
                if (model.id == Convert.ToInt32(findPK))
                {
                    result = model.site_name;
                    break;
                }
            }
            return result;
        }
    }
}
