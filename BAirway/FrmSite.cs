using System;
using System.Drawing;
using System.Windows.Forms;
using BAW.Dao;
using BAW.Model;
using System.Collections.Generic;

namespace BAirway
{
    public partial class FrmSite : Form
    {
        private StationDao siteDao = null;
        private int id = -1;
        public FrmSite()
        {
            InitializeComponent();
            siteDao = new StationDao();
        }

        private void FrmSite_Load(object sender, EventArgs e)
        {
            //initial
            refresh();
        }

        private void B_ADD_Click(object sender, EventArgs e)
        {
            if (isValidInputData())
            {
                ModelStation model = new ModelStation();
                model.id = this.id;
                model.site_code = site_code.Text;
                model.site_name = site_name.Text;

                Boolean result = false;
                switch (B_ADD.Text)
                {
                    case "บันทึก":
                        //Check Exist
                      List<ModelStation> stationLists =  siteDao.Select(" Where site_code='"+model.site_code+"'");
                      if (stationLists.Count > 0)
                      {
                          MessageBox.Show("มีข้อมูล "+model.site_code+" ในระบบแล้ว");
                          site_code.SelectAll();
                          site_name.Text = "";
                      }
                      else
                      {
                          result = siteDao.Insert(model);
                          if (result)
                          {
                              MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                          }
                      }
                        break;
                    case "แก้ไข":
                        result = siteDao.Update(model);
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

                ModelStation model = new ModelStation();
                model.id = this.id;
                model.site_code = site_code.Text;
                model.site_name = site_name.Text;

                Boolean result = siteDao.Delete(model);
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
                site_code.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value + "";
                site_name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value + "";

            }
            Cursor = Cursors.Default;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 1)
            {
                e.CellStyle.BackColor = Color.Lavender;
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
            
            dataGridView1.DataSource = siteDao.Select("");

            B_DELETE.Visible = false;
            B_ADD.Enabled = true;
            B_CANCEL.Enabled = true;

            B_ADD.Text = "บันทึก";

            site_code.Text = "";
            site_name.Text = "";
        }

        private Boolean isValidInputData()
        {
            if (site_code.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Code");
                site_code.Focus();
                return false;
            }
            if (site_name.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Name");
                site_name.Focus();
                return false;
            }
            return true;
        }

    }
}
