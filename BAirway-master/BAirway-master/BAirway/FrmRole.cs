using System;
using System.Drawing;
using System.Windows.Forms;
using BAW.Dao;
using BAW.Model;

namespace BAirway
{
    public partial class FrmRole : Form
    {
        private RoleDao roleDao = null;
        private int id = -1;
        public FrmRole()
        {
            InitializeComponent();
            roleDao = new RoleDao();
        }

        private void FrmRole_Load(object sender, EventArgs e)
        {
            //initial
            refresh();
        }

        private void B_ADD_Click(object sender, EventArgs e)
        {
            if (isValidInputData())
            {
                ModelRole model = new ModelRole();
                model.id = this.id;
                model.role_code = role_code.Text;
                model.role_name = role_name.Text;

                Boolean result = false;
                switch (B_ADD.Text)
                {
                    case "บันทึก":
                        result = roleDao.Insert(model);
                        if (result)
                        {
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                        }
                        break;
                    case "แก้ไข":
                        result = roleDao.Update(model);
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

                ModelRole model = new ModelRole();
                model.id = this.id;
                model.role_code = role_code.Text;
                model.role_name = role_name.Text;

                Boolean result = roleDao.Delete(model);
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
                role_code.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value + "";
                role_name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value + "";

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
            dataGridView1.DataSource = roleDao.Select(" Where role_code <> 'SPECIAL'");

            B_DELETE.Visible = false;
            B_ADD.Enabled = true;
            B_CANCEL.Enabled = true;

            B_ADD.Text = "บันทึก";

            role_code.Text = "";
            role_name.Text = "";
        }

        private Boolean isValidInputData()
        {
            if (role_code.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Code");
                role_code.Focus();
                return false;
            }
            if (role_name.Text.Equals(""))
            {
                MessageBox.Show("ยังไม่ได้ป้อนข้อมูล Name");
                role_name.Focus();
                return false;
            }
            return true;
        }

    }
}
