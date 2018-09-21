using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BAW.Model;
using BAW.Dao;
using BAW.Utils;
using System.Collections;
using BAW.Biz;

namespace BAirway
{
    public partial class FrmGroup : Form
    {
        private GroupDao groupDao = null;
        private MenuLangDao menuLangDao = new MenuLangDao();
        private Hashtable listMenuLangLabel = new Hashtable();


        private int id = -1;

        public FrmGroup()
        {
            InitializeComponent();
            groupDao = new GroupDao();
        }

        private void FrmArea_Load(object sender, EventArgs e)
        {
            this.listMenuLangLabel = menuLangDao.Select();
            //foreach (Control control in groupBox1.Controls)
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
                foreach (Control control in groupBox1.Controls)
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
                ModelGroup model = new ModelGroup();
                model.id = this.id;
                model.group_code = txtCode.Text;
                model.group_description = txtDesc.Text;
                model.group_order = Convert.ToInt32(txtOrder.Text);

                Boolean result = false;
                switch (B_ADD.Text)
                {
                    case "บันทึก":
                        //Check Exist
                        List<ModelGroup> stationLists = groupDao.Select(" Where group_code='" + model.group_code + "'");
                        if (stationLists.Count > 0)
                        {
                            MessageBox.Show("มีข้อมูล " + model.group_code + " ในระบบแล้ว");
                            txtCode.SelectAll();
                            txtCode.Focus();
                            //txtDesc.Text = "";
                        }
                        else
                        {
                            result = groupDao.Insert(model);
                            if (result)
                            {
                                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                            }
                        }
                        break;
                    case "แก้ไข":
                        result = groupDao.Update(model);
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
                ModelGroup model = new ModelGroup();
                model.id = this.id;
                model.group_code = txtCode.Text;
                model.group_description = txtDesc.Text;
                model.group_order = Convert.ToInt32(txtOrder.Text);
                Boolean result = groupDao.Delete(model);
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
                txtCode.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue + "";
                txtDesc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue + "";
                txtOrder.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue + "";
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
            String StationID = ManageLOG.getValueFromRegistry("WiFi Management", "StationID");

            B_DELETE.Visible = false;
            B_ADD.Enabled = true;
            B_CANCEL.Enabled = true;
            B_ADD.Text = "บันทึก";
            txtCode.Text = "";
            txtDesc.Text = "";
            txtOrder.Text = "0";
            dataGridView1.DataSource = groupDao.Select("");
        }

        private Boolean isValidInputData()
        {
            if (txtDesc.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Site");
                txtDesc.Focus();
                return false;
            }
            return true;
        }

        private void group_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

    }
}

