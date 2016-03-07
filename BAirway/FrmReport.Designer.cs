namespace BAirway
{
    partial class FrmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lounge_site = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DP_START = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.B_SHOW = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DP_END = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.ModelTransactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModelTransactionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lounge_site);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DP_START);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.B_SHOW);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DP_END);
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 84);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รูปแบบรายการ";
            // 
            // lounge_site
            // 
            this.lounge_site.DisplayMember = "site_name";
            this.lounge_site.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lounge_site.FormattingEnabled = true;
            this.lounge_site.Location = new System.Drawing.Point(96, 25);
            this.lounge_site.Name = "lounge_site";
            this.lounge_site.Size = new System.Drawing.Size(311, 22);
            this.lounge_site.TabIndex = 150;
            this.lounge_site.ValueMember = "id";
            this.lounge_site.SelectedIndexChanged += new System.EventHandler(this.lounge_site_SelectedIndexChanged);
            this.lounge_site.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.group_id_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(37, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 14);
            this.label3.TabIndex = 151;
            this.label3.Text = "สนามบิน:";
            // 
            // DP_START
            // 
            this.DP_START.CustomFormat = "dd-MM-yyyy";
            this.DP_START.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.DP_START.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DP_START.Location = new System.Drawing.Point(96, 53);
            this.DP_START.Name = "DP_START";
            this.DP_START.Size = new System.Drawing.Size(121, 22);
            this.DP_START.TabIndex = 1;
            this.DP_START.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.group_id_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.Location = new System.Drawing.Point(31, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 14);
            this.label15.TabIndex = 128;
            this.label15.Text = "วันที่เริ่มต้น";
            // 
            // B_SHOW
            // 
            this.B_SHOW.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_SHOW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_SHOW.Location = new System.Drawing.Point(413, 49);
            this.B_SHOW.Name = "B_SHOW";
            this.B_SHOW.Size = new System.Drawing.Size(80, 26);
            this.B_SHOW.TabIndex = 4;
            this.B_SHOW.Text = "แสดงรายงาน";
            this.B_SHOW.UseVisualStyleBackColor = true;
            this.B_SHOW.Click += new System.EventHandler(this.B_SHOW_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(223, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 130;
            this.label1.Text = "วันที่สิ้นสุด";
            // 
            // DP_END
            // 
            this.DP_END.CustomFormat = "dd-MM-yyyy";
            this.DP_END.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.DP_END.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DP_END.Location = new System.Drawing.Point(286, 53);
            this.DP_END.Name = "DP_END";
            this.DP_END.Size = new System.Drawing.Size(121, 22);
            this.DP_END.TabIndex = 2;
            this.DP_END.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.group_id_KeyPress);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(746, 473);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 4;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(746, 381);
            this.reportViewer1.TabIndex = 0;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // ModelTransactionBindingSource
            // 
            //this.ModelTransactionBindingSource.DataSource = typeof(BAW.Model.ModelTransaction);
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 473);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModelTransactionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DP_START;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button B_SHOW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DP_END;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox lounge_site;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.BindingSource ModelTransactionBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}