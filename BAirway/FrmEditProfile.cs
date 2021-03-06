﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BAW.Dao;
using BAW.Model;

namespace BAirway
{
    public partial class FrmEditProfile : Form
    {
        private FrmMain main;
        private StationDao siteDao = null;
        private RoleDao roleDao = null;
        private UserDao userDao = null;

        private ModelUser user = null;


        public Boolean isUpdate = false;
        public FrmEditProfile(FrmMain main, ModelUser user)
        {
            InitializeComponent();
            userDao = new UserDao();
            siteDao = new StationDao();
            roleDao = new RoleDao();
            this.user = user;
            this.main = main;
        }

        private void FrmEditProfile_Load(object sender, EventArgs e)
        {

            refresh();
            //initial
            user_name.Text = user.user_name;
            user_pass.Text = "";

            staff_station.SelectedValue = user.stationId;
            user_role.SelectedValue = user.user_role;
        }

        private void B_ADD_Click(object sender, EventArgs e)
        {
            if (isValidInputData())
            {
                user.user_name = user_name.Text;
                user.user_pass = user_pass.Text;

                user.user_role = Convert.ToInt32(user_role.SelectedValue);

                Boolean result = userDao.Update(user);
                if (result)
                {
                    MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว");
                    isUpdate = true;

                    Close();
                }
            }
        }

        private void B_CANCEL_Click(object sender, EventArgs e)
        {
            Close();
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
            staff_station.DataSource = siteDao.Select("");
            user_role.DataSource = roleDao.Select(" Where role_code <> 'SPECIAL'");
        }

        private Boolean isValidInputData()
        {
            if (oldpassword.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล");
                oldpassword.Focus();
                return false;
            }
            if (!oldpassword.Text.Equals(user.user_pass))
            {
                MessageBox.Show("รหัสผ่านเก่าไม่ถูกต้อง");
                oldpassword.Focus();
                return false;
            }
            if (user_pass.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล");
                user_pass.Focus();
                return false;
            }

            return true;
        }

        private void group_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
