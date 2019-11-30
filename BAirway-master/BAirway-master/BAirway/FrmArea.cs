using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BAW.Model;
using BAW.Dao;
using BAW.Utils;
using BAW.Biz;

namespace BAirway
{
    public partial class FrmArea : Form
    {
        private StationDao stationDao = null;
        private LoungeDao loungeDao = null;
        private AreaDao areaDao = null;
        private int id = -1;

        public FrmArea()
        {
            InitializeComponent();
            stationDao = new StationDao();
            areaDao = new AreaDao();
            loungeDao = new LoungeDao();
        }

        private void FrmArea_Load(object sender, EventArgs e)
        {
            //initial
            refresh();
        }

        private void B_ADD_Click(object sender, EventArgs e)
        {
            if (isValidInputData())
            {
                ModelArea model = new ModelArea();
                model.id = this.id;
                model.area_station = Convert.ToInt16(area_station.SelectedValue);
                model.area_lounge = Convert.ToInt16(area_lounge.SelectedValue);
                model.area_name = area_name.Text;

                Boolean result = false;
                switch (B_ADD.Text)
                {
                    case "บันทึก":
                        //Check Exist
                        List<ModelArea> stationLists = areaDao.Select(" Where area_name='" + model.area_name + "'");
                        if (stationLists.Count > 0)
                        {
                            MessageBox.Show("มีข้อมูล " + model.area_name + " ในระบบแล้ว");
                            area_name.Text = "";
                        }
                        else
                        {
                            result = areaDao.Insert(model);
                            if (result)
                            {
                                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                            }
                        }
                        break;
                    case "แก้ไข":
                        result = areaDao.Update(model);
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
                ModelArea model = new ModelArea();
                model.id = this.id;
                model.area_station = Convert.ToInt16(area_station.SelectedValue);
                model.area_lounge = Convert.ToInt16(area_lounge.SelectedValue);
                model.area_name = area_name.Text;
                Boolean result = areaDao.Delete(model);
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
                this.id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                area_station.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue + "";
                area_lounge.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue +"";
                area_name.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value + "";
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
            //        List<ModelStation> station = stationDao.Select("where id=" + dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            //        if (station.Count > 0)
            //        {
            //            e.Value = station[0].site_name;
            //        }                    
            //        break;
            //    case 2:
            //        List<ModelLounge> site = loungeDao.Select("where id=" + dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            //        if (site.Count > 0)
            //        {
            //            e.Value = site[0].lounge_name;
            //        }
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
            area_station.DataSource = stationDao.Select(" where id="+StationID);
            area_lounge.DataSource = loungeDao.Select(" where lounge_station="+StationID);

            dataGridView1.DataSource = areaDao.Select(" where area_station=" + StationID);

            B_DELETE.Visible = false;
            B_ADD.Enabled = true;
            B_CANCEL.Enabled = true;

            B_ADD.Text = "บันทึก";

            area_lounge.SelectedIndex = 0;
            area_name.Text = "";
        }

        private Boolean isValidInputData()
        {
            if (area_name.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Site");
                area_name.Focus();
                return false;
            }
            return true;
        }

        private void lounge_station_SelectedIndexChanged(object sender, EventArgs e)
        {
            area_lounge.DataSource = loungeDao.Select("where l.lounge_station=" + area_station.SelectedValue);
        }
        private void group_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void area_lounge_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String StationID = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID");
            //String lounge = area_lounge.SelectedValue.ToString();
            //dataGridView1.DataSource = areaDao.Select(" where area_station="+StationID+" and area_lounge="+lounge);
        }
    }
}

