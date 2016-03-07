using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BAW.Dao;
using BAW.Model;
using BAW.Utils;
using BAW.Biz;

namespace BAirway
{
    public partial class FrmLounge : Form
    {
        private StationDao siteDao = null;
        private LoungeDao loungeDao = null;
        private int id = -1;
        public FrmLounge()
        {
            InitializeComponent();
            loungeDao = new LoungeDao();
            siteDao = new StationDao();
        }

        private void FrmLounge_Load(object sender, EventArgs e)
        {
            //initial
            refresh();
        }

        private void B_ADD_Click(object sender, EventArgs e)
        {
            if (isValidInputData())
            {
                ModelLounge model = new ModelLounge();
                model.id = this.id;
                model.lounge_station = Convert.ToInt32(lounge_site.SelectedValue);
                model.lounge_name = lounge_name.Text;

                Boolean result = false;
                switch (B_ADD.Text)
                {
                    case "บันทึก":
                        //Check Exist

                        List<ModelLounge> LoungeLists = loungeDao.Select(" Where lounge_name='" + model.lounge_name + "'");
                        if (LoungeLists.Count > 0)
                        {
                            MessageBox.Show("มีข้อมูล " + model.lounge_name + " ในระบบแล้ว");
                            lounge_name.Text = "";
                        }
                        else
                        {
                            result = loungeDao.Insert(model);
                            if (result)
                            {
                                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                            }
                        }
                        break;
                    case "แก้ไข":
                        result = loungeDao.Update(model);
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
                ModelLounge model = new ModelLounge();
                model.id = this.id;
                model.lounge_station = Convert.ToInt32(lounge_site.SelectedValue);
                model.lounge_name = lounge_name.Text;
                Boolean result = loungeDao.Delete(model);
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
                lounge_site.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue +"";
                lounge_name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value + "";
            }
            Cursor = Cursors.Default;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 1)
            {
                e.CellStyle.BackColor = Color.Lavender;
            }
            //switch (e.ColumnIndex)
            //{
            //    case 1:
                    //List<ModelStation> site = siteDao.Select("where id=" + dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                    //if (site.Count > 0)
                    //{
                    //    e.Value = site[0].site_name;
                    //}
            //        break;
            //}
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
            String StationID = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID");
            lounge_site.DataSource = siteDao.Select(" where id=" + StationID);
            dataGridView1.DataSource = loungeDao.Select(" where lounge_station=" + StationID);

            B_DELETE.Visible = false;
            B_ADD.Enabled = true;
            B_CANCEL.Enabled = true;

            B_ADD.Text = "บันทึก";

            lounge_site.SelectedIndex = 0;
            lounge_name.Text = "";
        }

        private Boolean isValidInputData()
        {
            if (lounge_name.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Site");
                lounge_name.Focus();
                return false;
            }
            return true;
        }

        private void lounge_site_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void group_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
