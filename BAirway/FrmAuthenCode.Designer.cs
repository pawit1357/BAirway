namespace BAirway
{
    partial class FrmAuthenCode
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbRecords = new System.Windows.Forms.Label();
            this.B_SEARCH = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lounge_site = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ath_use = new System.Windows.Forms.CheckBox();
            this.ath_code = new System.Windows.Forms.TextBox();
            this.B_DELETE = new System.Windows.Forms.Button();
            this.B_ADD = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.B_CANCEL = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.station_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelAuthenCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.B_DELETE_ALL = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelAuthenCodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbRecords);
            this.groupBox1.Controls.Add(this.B_SEARCH);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lounge_site);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ath_use);
            this.groupBox1.Controls.Add(this.ath_code);
            this.groupBox1.Controls.Add(this.B_DELETE);
            this.groupBox1.Controls.Add(this.B_ADD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(5, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 163);
            this.groupBox1.TabIndex = 171;
            this.groupBox1.TabStop = false;
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbRecords.Location = new System.Drawing.Point(7, 143);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(25, 14);
            this.lbRecords.TabIndex = 191;
            this.lbRecords.Text = "##";
            // 
            // B_SEARCH
            // 
            this.B_SEARCH.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_SEARCH.Image = global::BAirway.Properties.Resources.document_view;
            this.B_SEARCH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_SEARCH.Location = new System.Drawing.Point(309, 45);
            this.B_SEARCH.Name = "B_SEARCH";
            this.B_SEARCH.Size = new System.Drawing.Size(75, 33);
            this.B_SEARCH.TabIndex = 167;
            this.B_SEARCH.Text = "ค้นหา";
            this.B_SEARCH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_SEARCH.UseVisualStyleBackColor = true;
            this.B_SEARCH.Click += new System.EventHandler(this.B_SEARCH_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(35, 17);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(53, 31);
            this.label10.TabIndex = 166;
            this.label10.Text = "Station";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lounge_site
            // 
            this.lounge_site.DisplayMember = "site_name";
            this.lounge_site.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lounge_site.FormattingEnabled = true;
            this.lounge_site.Location = new System.Drawing.Point(94, 23);
            this.lounge_site.Name = "lounge_site";
            this.lounge_site.Size = new System.Drawing.Size(209, 21);
            this.lounge_site.TabIndex = 165;
            this.lounge_site.ValueMember = "id";
            this.lounge_site.SelectedIndexChanged += new System.EventHandler(this.lounge_site_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(43, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 157;
            this.label4.Text = "Status:";
            // 
            // ath_use
            // 
            this.ath_use.AutoSize = true;
            this.ath_use.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ath_use.Location = new System.Drawing.Point(93, 81);
            this.ath_use.Name = "ath_use";
            this.ath_use.Size = new System.Drawing.Size(44, 17);
            this.ath_use.TabIndex = 156;
            this.ath_use.Text = "Use";
            this.ath_use.UseVisualStyleBackColor = true;
            // 
            // ath_code
            // 
            this.ath_code.BackColor = System.Drawing.Color.White;
            this.ath_code.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ath_code.ForeColor = System.Drawing.Color.ForestGreen;
            this.ath_code.Location = new System.Drawing.Point(94, 50);
            this.ath_code.Name = "ath_code";
            this.ath_code.Size = new System.Drawing.Size(209, 21);
            this.ath_code.TabIndex = 1;
            // 
            // B_DELETE
            // 
            this.B_DELETE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_DELETE.Image = global::BAirway.Properties.Resources.error;
            this.B_DELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_DELETE.Location = new System.Drawing.Point(304, 122);
            this.B_DELETE.Name = "B_DELETE";
            this.B_DELETE.Size = new System.Drawing.Size(75, 35);
            this.B_DELETE.TabIndex = 5;
            this.B_DELETE.Text = "ลบ";
            this.B_DELETE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_DELETE.UseVisualStyleBackColor = true;
            this.B_DELETE.Click += new System.EventHandler(this.B_DELETE_Click);
            // 
            // B_ADD
            // 
            this.B_ADD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_ADD.Image = global::BAirway.Properties.Resources.disk_blue_ok;
            this.B_ADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_ADD.Location = new System.Drawing.Point(385, 122);
            this.B_ADD.Name = "B_ADD";
            this.B_ADD.Size = new System.Drawing.Size(75, 35);
            this.B_ADD.TabIndex = 3;
            this.B_ADD.Text = "บันทึก";
            this.B_ADD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_ADD.UseVisualStyleBackColor = true;
            this.B_ADD.Click += new System.EventHandler(this.B_ADD_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(14, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 149;
            this.label3.Text = "AccessCode:";
            // 
            // B_CANCEL
            // 
            this.B_CANCEL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_CANCEL.Image = global::BAirway.Properties.Resources.redo;
            this.B_CANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_CANCEL.Location = new System.Drawing.Point(396, 403);
            this.B_CANCEL.Name = "B_CANCEL";
            this.B_CANCEL.Size = new System.Drawing.Size(75, 35);
            this.B_CANCEL.TabIndex = 4;
            this.B_CANCEL.Text = "ยกเลิก";
            this.B_CANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_CANCEL.UseVisualStyleBackColor = true;
            this.B_CANCEL.Click += new System.EventHandler(this.B_CANCEL_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(304, 29);
            this.label9.TabIndex = 0;
            this.label9.Text = "จัดการข้อมูล Access Code";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(-2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 52);
            this.panel1.TabIndex = 178;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.station_id,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView1.DataSource = this.modelAuthenCodeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(5, 225);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(467, 174);
            this.dataGridView1.TabIndex = 179;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn5.HeaderText = "id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // station_id
            // 
            this.station_id.DataPropertyName = "station_id";
            this.station_id.HeaderText = "สถานี";
            this.station_id.Name = "station_id";
            this.station_id.ReadOnly = true;
            this.station_id.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ath_code";
            this.dataGridViewTextBoxColumn1.HeaderText = "Access Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ath_use";
            this.dataGridViewTextBoxColumn4.HeaderText = "สถานะ";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ath_user";
            this.dataGridViewTextBoxColumn2.HeaderText = "ath_user";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ath_pass";
            this.dataGridViewTextBoxColumn3.HeaderText = "ath_pass";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "createDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "createDate";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // modelAuthenCodeBindingSource
            // 
            this.modelAuthenCodeBindingSource.DataSource = typeof(BAW.Model.ModelAuthenCode);
            // 
            // B_DELETE_ALL
            // 
            this.B_DELETE_ALL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_DELETE_ALL.Image = global::BAirway.Properties.Resources.error;
            this.B_DELETE_ALL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_DELETE_ALL.Location = new System.Drawing.Point(266, 403);
            this.B_DELETE_ALL.Name = "B_DELETE_ALL";
            this.B_DELETE_ALL.Size = new System.Drawing.Size(124, 35);
            this.B_DELETE_ALL.TabIndex = 168;
            this.B_DELETE_ALL.Text = "ล้างข้อมูลทั้ง Site";
            this.B_DELETE_ALL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_DELETE_ALL.UseVisualStyleBackColor = true;
            this.B_DELETE_ALL.Click += new System.EventHandler(this.B_DELETE_ALL_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Image = global::BAirway.Properties.Resources.error;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(136, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 35);
            this.button1.TabIndex = 180;
            this.button1.Text = "ล้างข้อมูล localdb";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmAuthenCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(477, 442);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.B_DELETE_ALL);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.B_CANCEL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAuthenCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "จัดการข้อมูล Access Code";
            this.Load += new System.EventHandler(this.FrmAuthenCode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelAuthenCodeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button B_ADD;
        private System.Windows.Forms.Button B_CANCEL;
        private System.Windows.Forms.Button B_DELETE;
        private System.Windows.Forms.TextBox ath_code;
        private System.Windows.Forms.CheckBox ath_use;
        private System.Windows.Forms.Label label4;
        //private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn athcodeDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn athuserDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn athpassDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn athuseDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource modelAuthenCodeBindingSource;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox lounge_site;
        private System.Windows.Forms.Button B_SEARCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn station_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button B_DELETE_ALL;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Button button1;
    }
}