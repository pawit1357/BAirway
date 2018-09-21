using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BAW.Dao;
using BAW.Utils;
using BAW.Model;
using BAW.Biz;
using System.Collections;

namespace BAirway
{
    public partial class FrmStaff : Form
    {
        private StationDao stationDao = null;
        private LoungeDao loungeDao = null;
        private RoleDao roleDao = null;
        private UserDao userDao = null;
        private AreaDao areaDao = null;
        private StaffDao staffDao = null;
        private MenuLangDao menuLangDao = new MenuLangDao();
        private Hashtable listMenuLangLabel = new Hashtable();


        private int userId = -1;
        private String StationID;


        public FrmStaff()
        {
            InitializeComponent();
            userDao = new UserDao();
            staffDao = new StaffDao();
            stationDao = new StationDao();
            loungeDao = new LoungeDao();
            roleDao = new RoleDao();
            areaDao = new AreaDao();
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            StationID = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID");
            if (!String.IsNullOrEmpty(StationID))
            {
                String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');

                if (!userInfo[6].Equals("9"))
                {
                    staff_station.DataSource = stationDao.Select(" where id = " + StationID);
                    staff_station.SelectedIndex = 0;
                    staff_station.Enabled = false;
                }
                else
                {
                    staff_station.DataSource = stationDao.Select("");
                    staff_station.SelectedIndex = 0;
                    staff_station.Enabled = true;
                }
            }
            user_role.DataSource = roleDao.Select(" Where role_code <> 'SPECIAL'");
            user_role.SelectedIndex = 0;

            this.listMenuLangLabel = menuLangDao.Select();
            //foreach (Control control in groupBox2.Controls)
            //{
            //    if (control is Label)
            //    {
            //        Console.WriteLine(String.Format("{0},{1},{2}", this.Name, control.Name, control.Text));

            //    }
            //}
            //Console.WriteLine();

            //initial
            refresh();
            chnageLabel();
        }
        private void chnageLabel()
        {
            String defaultLang = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "DefaultLang");
            if (defaultLang != null)
            {
                defaultLang = defaultLang.Split('|')[1];
                foreach (Control control in groupBox2.Controls)
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

        private void B_ADD_Click(object sender, EventArgs e)
        {
            if (isValidInputData())
            {
                ModelUser model = new ModelUser();
                model.id = this.userId;
                model.user_name = user_name.Text;
                model.user_pass = user_pass.Text;
                model.user_role = Convert.ToInt32(user_role.SelectedValue);
                model.user_status = "1";
                model.stationId = Convert.ToInt32(StationID);
                Boolean resultUser = false;
                switch (B_ADD.Text)
                {
                    case "บันทึก":

                        resultUser = userDao.Insert(model);
                        if (resultUser)
                        {
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                        }
                        break;
                    case "แก้ไข":
                        resultUser = userDao.Update(model);
                        if (resultUser)
                        {
                            MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว");
                        }
                        else
                        {
                            MessageBox.Show("เกิดข้อผิดพลาด");
                        }
                        break;
                }

                if (resultUser)
                {
                    refresh();
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาด");
                }
            }
        }

        private void B_CANCEL_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void B_DELETE_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ModelUser model = new ModelUser();
                model.id = this.userId;
                model.user_name = user_name.Text;
                model.user_pass = user_pass.Text;
                model.user_role = Convert.ToInt32(user_role.SelectedValue);

                Boolean result = userDao.Delete(model);
                if (result)
                {
                    MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");
                    refresh();
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาด");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (e.RowIndex != -1)
            {
                B_ADD.Text = "แก้ไข";
                B_DELETE.Visible = true;
                this.userId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                user_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value + "";
                user_pass.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value + "";
                user_role.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue + "";
            }
            Cursor = Cursors.Default;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 1)
            {
                e.CellStyle.BackColor = Color.Lavender;
            }
            if (e.RowIndex != -1)
            {
                String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');

                if (!userInfo[6].Equals("9"))
                {
                    if (e.ColumnIndex == 2)
                    {
                        e.Value = "#########";
                    }
                }
            }
        }


        private void TXT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CheckIsNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("กรอกตัวเลขได้อย่างเดียว");
            }
        }
        private void refresh()
        {
            user_name.Text = "";
            user_pass.Text = "";
            user_role.Text = "";
            String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');

            if (!userInfo[6].Equals("9"))
            {
                dataGridView1.DataSource = userDao.Select(" Where u.station_id=" + StationID);
            }
            else
            {
                dataGridView1.DataSource = userDao.Select(" Where u.station_id=" + staff_station.SelectedValue);
            }

            B_DELETE.Visible = false;
            B_ADD.Enabled = true;
            B_CANCEL.Enabled = true;

            B_ADD.Text = "บันทึก";


        }

        private Boolean isValidInputData()
        {
            if (user_name.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล");
                user_name.Focus();
                return false;
            }
            if (user_pass.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล");
                user_pass.Focus();
                return false;
            }
            if (user_role.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล");
                user_role.Focus();
                return false;
            }
            if (staff_station.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล");
                staff_station.Focus();
                return false;
            }
            return true;
        }

        private void staff_station_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = userDao.Select(" Where u.station_id=" + staff_station.SelectedValue);
        }




    }
}
