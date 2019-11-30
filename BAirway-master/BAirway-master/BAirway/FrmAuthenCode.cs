using System;
using System.Drawing;
using System.Windows.Forms;
using BAW.Dao;
using BAW.Model;
using BAW.Utils;
using BAW.Biz;
using System.Collections.Generic;

namespace BAirway
{
    public partial class FrmAuthenCode : Form
    {
        private AuthenCodeDao authenCodeDao = null;
        private int id = -1;
        public FrmAuthenCode()
        {
            InitializeComponent();
            authenCodeDao = new AuthenCodeDao();
        }

        private void FrmAuthenCode_Load(object sender, EventArgs e)
        {
            StationDao siteDao = new StationDao();
            lounge_site.DataSource = siteDao.Select("");
            //initial
            refresh();
        }

        private void B_ADD_Click(object sender, EventArgs e)
        {
            if (isValidInputData())
            {
                int StationID = Convert.ToInt32(lounge_site.SelectedValue);

                ModelAuthenCode model = new ModelAuthenCode();
                model.id = this.id;
                model.ath_code = ath_code.Text;
                model.ath_use = (ath_use.Checked) ? "1" : "0";
                model.station_id = StationID;
                Boolean result = false;
                switch (B_ADD.Text)
                {
                    case "บันทึก":
                        result = authenCodeDao.Insert(model);
                        if (result)
                        {
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                        }
                        break;
                    case "แก้ไข":
                        result = authenCodeDao.Update(model);
                        if (result)
                        {
                            MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว");
                        }
                        break;
                }
                if (result)
                {
                    refresh();
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

                ModelAuthenCode model = new ModelAuthenCode();
                model.id = this.id;
                model.ath_code = ath_code.Text;
                model.ath_use = (ath_use.Checked) ? "1" : "0";

                Boolean result = authenCodeDao.Delete(model);
                if (result)
                {
                    MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");
                    refresh();
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
                this.id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                ath_code.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value + "";
                //lounge_site.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                ath_use.Checked = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.Equals("1")) ? true : false;

            }
            Cursor = Cursors.Default;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 1)
            {
                e.CellStyle.BackColor = Color.Lavender;
            }
            switch (e.ColumnIndex)
            {
                case 3:
                    e.Value = (e.Value.Equals("0") ? "Available" : "UnAvailable");
                    break;
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

            List<ModelAuthenCode> lists = authenCodeDao.SelectAutehnPage("", Convert.ToInt32(lounge_site.SelectedValue));
            if (lists.Count > 0)
            {

                int use = 0;
                foreach (ModelAuthenCode c in lists)
                {
                    if (c.ath_use.Equals("1"))
                    {
                        use++;
                    }
                }
                lbRecords.Text = String.Format("Total {0} : used {1} records", lists.Count, use);
            }
            B_DELETE.Visible = false;
            B_ADD.Enabled = true;
            B_CANCEL.Enabled = true;

            B_ADD.Text = "บันทึก";

            ath_code.Text = "";
            ath_use.Checked = false;
        }

        private Boolean isValidInputData()
        {
            if (ath_code.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล");
                ath_code.Focus();
                return false;
            }
            //if (ath_user.Text.Equals(""))
            //{
            //    MessageBox.Show("ยังไม่ได้ป้อนข้อมูล");
            //    ath_user.Focus();
            //    return false;
            //}
            //if (ath_pass.Text.Equals(""))
            //{
            //    MessageBox.Show("ยังไม่ได้ป้อนข้อมูล");
            //    ath_pass.Focus();
            //    return false;
            //}
            return true;
        }

        private void B_SEARCH_Click(object sender, EventArgs e)
        {
            List<ModelAuthenCode> lists = authenCodeDao.SelectAutehnPage(" Where ath_code='" + ath_code.Text + "'", Convert.ToInt32(lounge_site.SelectedValue));
            if (lists.Count > 0)
            {
                dataGridView1.DataSource = lists;
                int use = 0;
                foreach (ModelAuthenCode c in lists)
                {
                    if (c.ath_use.Equals("1"))
                    {
                        use++;
                    }
                }
                lbRecords.Text = String.Format("Total {0} : used {1} records", lists.Count, use);
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล");
                lbRecords.Text = String.Format("Total {0} : used {1} records", 0, 0);
                ath_code.Text = string.Empty;
                dataGridView1.DataSource = null;
            }
        }

        private void lounge_site_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ModelAuthenCode> lists = authenCodeDao.SelectAutehnPage("", Convert.ToInt32(lounge_site.SelectedValue));
            if (lists.Count > 0)
            {
                dataGridView1.DataSource = lists;
                int use = 0;
                foreach (ModelAuthenCode c in lists)
                {
                    if (c.ath_use.Equals("1"))
                    {
                        use++;
                    }
                }
                lbRecords.Text = String.Format("Total {0} : used {1} records", lists.Count, use);
            }
            else
            {
                lbRecords.Text = String.Format("Total {0} : used {1} records", 0, 0);
                ath_code.Text = string.Empty;
                dataGridView1.DataSource = null;
            }

        }

        private void B_DELETE_ALL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการลบข้อมูล Access Code ของ Site " + lounge_site.Text + " ทั้งหมด?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Boolean result = authenCodeDao.DeleteBySite(Convert.ToInt32(lounge_site.SelectedValue));
                if (result)
                {
                    ath_code.Text = string.Empty;
                    lbRecords.Text = String.Format("Total {0} : used {1} records", 0, 0);
                    dataGridView1.DataSource = null;
                    MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");
                    refresh();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการลบข้อมูล localhostdb  ทั้งหมด?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Boolean result = authenCodeDao.deleteLocalDB();
                if (result)
                {
                    ath_code.Text = string.Empty;
                    lbRecords.Text = String.Format("Total {0} : used {1} records", 0, 0);
                    dataGridView1.DataSource = null;
                    MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");
                    refresh();
                }
            }
        }

    }
}
