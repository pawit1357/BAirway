using BAW.Biz;
//using BAirway.Report;
using BAW.Dao;
using BAW.Model;
using BAW.Utils;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BAirway
{
    public partial class FrmReport : Form
    {
        private GroupDao groupDao = new GroupDao();
        private UserDao userDao = new UserDao();
        private StationDao siteDao = new StationDao();
        private TransactionDao tranDao = new TransactionDao();
        private AuthenCodeDao authenDao = new AuthenCodeDao();
        private MenuLangDao menuLangDao = new MenuLangDao();
        private Hashtable listMenuLangLabel = new Hashtable();


        private String host;
        private String user;
        private String pass;

        private List<ModelGroup> groups = new List<ModelGroup>();
        private List<ModelUser> users = new List<ModelUser>();
        private List<ModelStation> stations = new List<ModelStation>();

        public FrmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            if (ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo") != null)
            {
                String[] userInfo = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "userInfo").Split(',');

                if (userInfo[6].Equals("9"))
                {
                    lounge_site.DataSource = siteDao.Select("");
                }
                else {
                    String StationID = ManageLOG.getValueFromRegistry("WiFi Management", "StationID");
                    if (!String.IsNullOrEmpty(StationID))
                    {
                        lounge_site.DataSource = siteDao.Select(" where id=" + StationID);
                    }
                    else
                    {
                        lounge_site.DataSource = siteDao.Select("");
                    }
                }
            }
            stations = siteDao.Select("");
            groups = groupDao.Select("");
            users = userDao.Select("");

            this.reportViewer1.RefreshReport();

            this.listMenuLangLabel = menuLangDao.Select();
            //foreach (Control control in groupBox1.Controls)
            //{
            //    if (control is Label)
            //    {
            //        Console.WriteLine(String.Format("{0},{1},{2}", this.Name, control.Name, control.Text));

            //    }
            //}
            //Console.WriteLine();
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


        private void B_SHOW_Click(object sender, EventArgs e)
        {
            //validate
            if (Convert.ToInt32(DP_START.Value.ToString("yyyyMMdd")) > Convert.ToInt32(DP_END.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("วันที่เริ่มต้นต้องน้อยกว่าวันที่สิ้นสุด");
                return;
            }
            Cursor = Cursors.WaitCursor;
            ShowReport();//Show Report
            Cursor = Cursors.Default;
        }

        public void ShowReport()
        {

            String cri = " where date(create_date) between date('" + DP_START.Value.ToString("yyyy-MM-dd") + "') and date('" + DP_END.Value.ToString("yyyy-MM-dd") + "') and LoungePlace=" + lounge_site.SelectedValue;
            //int StationID = Convert.ToInt16(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID"));

            List<ModelTransaction> lists = tranDao.Select(cri, Convert.ToInt16(lounge_site.SelectedValue));
            if (lists != null)
            {
                //foreach (ModelTransaction model in lists)
                //{
                    //model.group_idName = findGroupName(model.group_id + "");
                    //model.LoungeName = findStationName(model.LoungePlace + "");
                    //model.seat_no = model.seat_no;
                    //model.create_byName = findUserName(model.create_by + "");
                    //model.update_byName = findUserName(model.update_by + "");

                //}



                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                var rptPath = @"report1.rdlc";
                reportViewer1.Visible = true;
                reportViewer1.LocalReport.ReportPath = rptPath;
                ReportDataSource datasource = new ReportDataSource("DataSet1", lists);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(datasource);
                reportViewer1.DocumentMapCollapsed = true;
                reportViewer1.RefreshReport();

            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล");
            }
        }

        private void lounge_site_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ModelStation> sites = siteDao.Select("where id=" + lounge_site.SelectedValue);
            if (sites != null)
            {
                if (sites.Count > 0)
                {
                    host = sites[0].site_host_ip;
                    user = sites[0].site_host_user;
                    pass = sites[0].site_host_pass;
                }
            }
        }

        //private int row = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //try
            //{
            //    //Set the left margin
            //    int iLeftMargin = e.MarginBounds.Left;
            //    //Set the top margin
            //    int iTopMargin = e.MarginBounds.Top;
            //    //Whether more pages have to print or not
            //    bool bMorePagesToPrint = false;
            //    int iTmpWidth = 0;

            //    //For the first page to print set the cell width and header height
            //    if (bFirstPage)
            //    {
            //        foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
            //        {
            //            iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
            //                           (double)iTotalWidth * (double)iTotalWidth *
            //                           ((double)e.MarginBounds.Width / (double)iTotalWidth))));

            //            iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
            //                        GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

            //            // Save width and height of headres
            //            arrColumnLefts.Add(iLeftMargin);
            //            arrColumnWidths.Add(iTmpWidth);
            //            iLeftMargin += iTmpWidth;
            //        }
            //    }
            //    //Loop till all the grid rows not get printed
            //    while (iRow <= dataGridView1.Rows.Count - 1)
            //    {
            //        DataGridViewRow GridRow = dataGridView1.Rows[iRow];
            //        //Set the cell height
            //        iCellHeight = GridRow.Height + 5;
            //        int iCount = 0;
            //        //Check whether the current page settings allo more rows to print
            //        if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
            //        {
            //            bNewPage = true;
            //            bFirstPage = false;
            //            bMorePagesToPrint = true;
            //            break;
            //        }
            //        else
            //        {
            //            if (bNewPage)
            //            {
            //                //Draw Header
            //                e.Graphics.DrawString("Customer Summary", new Font(dataGridView1.Font, FontStyle.Bold),
            //                        Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
            //                        e.Graphics.MeasureString("Customer Summary", new Font(dataGridView1.Font,
            //                        FontStyle.Bold), e.MarginBounds.Width).Height - 13);

            //                String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            //                //Draw Date
            //                e.Graphics.DrawString(strDate, new Font(dataGridView1.Font, FontStyle.Bold),
            //                        Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
            //                        e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
            //                        FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
            //                        e.Graphics.MeasureString("Customer Summary", new Font(new Font(dataGridView1.Font,
            //                        FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

            //                //Draw Columns                 
            //                iTopMargin = e.MarginBounds.Top;
            //                foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
            //                {
            //                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
            //                        new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
            //                        (int)arrColumnWidths[iCount], iHeaderHeight));

            //                    e.Graphics.DrawRectangle(Pens.Black,
            //                        new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
            //                        (int)arrColumnWidths[iCount], iHeaderHeight));

            //                    e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
            //                        new SolidBrush(GridCol.InheritedStyle.ForeColor),
            //                        new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
            //                        (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
            //                    iCount++;
            //                }
            //                bNewPage = false;
            //                iTopMargin += iHeaderHeight;
            //            }
            //            iCount = 0;
            //            //Draw Columns Contents                
            //            foreach (DataGridViewCell Cel in GridRow.Cells)
            //            {
            //                if (Cel.Value != null)
            //                {
            //                    e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
            //                                new SolidBrush(Cel.InheritedStyle.ForeColor),
            //                                new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
            //                                (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
            //                }
            //                //Drawing Cells Borders 
            //                e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
            //                        iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

            //                iCount++;
            //            }
            //        }
            //        iRow++;
            //        iTopMargin += iCellHeight;
            //    }

            //    //If more lines exist, print another page.
            //    if (bMorePagesToPrint)
            //        e.HasMorePages = true;
            //    else
            //        e.HasMorePages = false;
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


        }


        private void button1_Click(object sender, EventArgs e)
        {

            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }

            //printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        //    try
        //    {
        //        strFormat = new StringFormat();
        //        strFormat.Alignment = StringAlignment.Near;
        //        strFormat.LineAlignment = StringAlignment.Center;
        //        strFormat.Trimming = StringTrimming.EllipsisCharacter;

        //        arrColumnLefts.Clear();
        //        arrColumnWidths.Clear();
        //        iCellHeight = 0;
        //        iRow = 0;
        //        bFirstPage = true;
        //        bNewPage = true;

        //        // Calculating Total Widths
        //        iTotalWidth = 0;
        //        foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
        //        {
        //            iTotalWidth += dgvGridCol.Width;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        }

        //private String findGroupName(String findPK)
        //{
        //    String result = "";
        //    foreach (ModelGroup model in groups)
        //    {
        //        if (model.id == Convert.ToInt16(findPK))
        //        {
        //            result = model.group_description;
        //            break;
        //        }
        //    }
        //    return result;
        //}

        //private String findUserName(String findPK)
        //{
        //    String result = "";
        //    foreach (ModelUser model in users)
        //    {
        //        if (model.id == Convert.ToInt16(findPK))
        //        {
        //            result = model.user_name;
        //            break;
        //        }
        //    }
        //    return result;
        //}
        //private String findStationName(String findPK)
        //{
        //    String result = "";
        //    foreach (ModelStation model in stations)
        //    {
        //        if (model.id == Convert.ToInt16(findPK))
        //        {
        //            result = model.site_name;
        //            break;
        //        }
        //    }
        //    return result;
        //}
        private void group_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
