using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BAW.Dao;
using BAW.Model;
using BAW.Utils;

namespace BAirway
{
    public partial class FrmLoad : Form
    {
        private AuthenCodeDao authenCodeDao = null;
        private List<ModelAuthenCode> authenCodes = null;
        public FrmLoad()
        {
            InitializeComponent();
            authenCodeDao = new AuthenCodeDao();

        }

        private void FrmLoad_Load(object sender, EventArgs e)
        {
            StationDao siteDao = new StationDao();
            lounge_site.DataSource = siteDao.Select("");
            refresh();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 1)
            {
                e.CellStyle.BackColor = Color.Lavender;
            }
        }

        private void B_BW_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "Csv file (*.csv)|*.csv";
            TXT_FILENAME.Text = openFileDialog1.FileName;
        }

        private void B_PREVIEW_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TXT_FILENAME.Text.Equals(""))
                {
                    using (CsvFileReader reader = new CsvFileReader(TXT_FILENAME.Text))
                    {
                        authenCodes = new List<ModelAuthenCode>();
                        CsvRow row = new CsvRow();
                        while (reader.ReadRow(row))
                        {
                            //Login,Password,Uptime Limit,Used Uptime,Used Download,Used Upload
                            ModelAuthenCode model = new ModelAuthenCode();
                            model.ath_code = row[1];
                            model.ath_user = row[0];
                            model.ath_pass = row[1];
                            model.ath_use = "0";
                            model.station_id = Convert.ToInt32(lounge_site.SelectedValue);
                            model.createDate = DateTime.Now;
                            authenCodes.Add(model);
                        }
                        dataGridView1.DataSource = authenCodes;
                        if (authenCodes.Count > 0)
                        {
                            B_LOAD.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void B_LOAD_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int success = 0;
            int fail = 0;
            if (authenCodes != null)
            {
                if (authenCodes.Count > 0)
                {
                    int rowIndex = 0;
                    foreach (ModelAuthenCode code in authenCodes)
                    {
                        if (rowIndex > 0)
                        {
                            if (authenCodeDao.Insert(code))
                            {
                                success++;
                            }
                            else
                            {
                                fail++;
                            }
                        }
                        rowIndex++;
                    }
                    MessageBox.Show("โหลดข้อมูลทั้งหมด " + (authenCodes.Count-1) + " สำเร็จ " + success + " ผิดพลาด " + fail);
                    refresh();
                }
            }
            Cursor = Cursors.Default;
        }

        private void refresh()
        {
            B_LOAD.Enabled = false;
            dataGridView1.DataSource = null;
        }
    }
}
