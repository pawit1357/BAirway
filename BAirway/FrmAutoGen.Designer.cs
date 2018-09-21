namespace BAirway
{
    partial class FrmAutoGen
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lounge_site = new System.Windows.Forms.ComboBox();
            this.lSupport = new System.Windows.Forms.Label();
            this.L_SITE_DESC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbDisableVaridate = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.date_of_flight = new System.Windows.Forms.ComboBox();
            this.CMD_PRINT = new System.Windows.Forms.Button();
            this.B_SAVE = new System.Windows.Forms.Button();
            this.B_CANCEL = new System.Windows.Forms.Button();
            this.Barcode = new System.Windows.Forms.Label();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.remark2 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.remark = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.group_id = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.lbAccessCode = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.cboRemark1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lounge_site);
            this.splitContainer1.Panel1.Controls.Add(this.lSupport);
            this.splitContainer1.Panel1.Controls.Add(this.L_SITE_DESC);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1209, 578);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BAirway.Properties.Resources.network_wireless;
            this.pictureBox1.Location = new System.Drawing.Point(1118, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.TabIndex = 193;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // lounge_site
            // 
            this.lounge_site.BackColor = System.Drawing.SystemColors.Menu;
            this.lounge_site.DisplayMember = "site_name";
            this.lounge_site.Enabled = false;
            this.lounge_site.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lounge_site.FormattingEnabled = true;
            this.lounge_site.Location = new System.Drawing.Point(520, 22);
            this.lounge_site.Name = "lounge_site";
            this.lounge_site.Size = new System.Drawing.Size(259, 31);
            this.lounge_site.TabIndex = 193;
            this.lounge_site.ValueMember = "id";
            // 
            // lSupport
            // 
            this.lSupport.AutoSize = true;
            this.lSupport.BackColor = System.Drawing.Color.White;
            this.lSupport.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lSupport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lSupport.Location = new System.Drawing.Point(1172, 50);
            this.lSupport.Name = "lSupport";
            this.lSupport.Size = new System.Drawing.Size(147, 18);
            this.lSupport.TabIndex = 127;
            this.lSupport.Text = "Support Tel : {0} {1}";
            this.lSupport.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // L_SITE_DESC
            // 
            this.L_SITE_DESC.AutoSize = true;
            this.L_SITE_DESC.BackColor = System.Drawing.Color.White;
            this.L_SITE_DESC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.L_SITE_DESC.ForeColor = System.Drawing.Color.ForestGreen;
            this.L_SITE_DESC.Location = new System.Drawing.Point(785, 25);
            this.L_SITE_DESC.Name = "L_SITE_DESC";
            this.L_SITE_DESC.Size = new System.Drawing.Size(40, 24);
            this.L_SITE_DESC.TabIndex = 125;
            this.L_SITE_DESC.Text = "###";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(445, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 31);
            this.label3.TabIndex = 124;
            this.label3.Text = "Site:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(430, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 35);
            this.label1.TabIndex = 122;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::BAirway.Properties.Resources.BoardingPass;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1209, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 120;
            this.pictureBox2.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(1209, 494);
            this.splitContainer2.SplitterDistance = 295;
            this.splitContainer2.TabIndex = 180;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboRemark1);
            this.groupBox2.Controls.Add(this.cbDisableVaridate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.date_of_flight);
            this.groupBox2.Controls.Add(this.CMD_PRINT);
            this.groupBox2.Controls.Add(this.B_SAVE);
            this.groupBox2.Controls.Add(this.B_CANCEL);
            this.groupBox2.Controls.Add(this.Barcode);
            this.groupBox2.Controls.Add(this.txt_barcode);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.remark2);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.remark);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.group_id);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1209, 295);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto Generate";
            // 
            // cbDisableVaridate
            // 
            this.cbDisableVaridate.AutoSize = true;
            this.cbDisableVaridate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbDisableVaridate.Location = new System.Drawing.Point(614, 163);
            this.cbDisableVaridate.Name = "cbDisableVaridate";
            this.cbDisableVaridate.Size = new System.Drawing.Size(228, 18);
            this.cbDisableVaridate.TabIndex = 194;
            this.cbDisableVaridate.Text = "ยกเลิกการตรวจสอบ (สำหรับทดสอบพริ้น)";
            this.cbDisableVaridate.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(592, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 20);
            this.label5.TabIndex = 193;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(261, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 20);
            this.label4.TabIndex = 192;
            this.label4.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(592, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 20);
            this.label8.TabIndex = 191;
            this.label8.Text = "*";
            // 
            // date_of_flight
            // 
            this.date_of_flight.DisplayMember = "id";
            this.date_of_flight.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.date_of_flight.FormattingEnabled = true;
            this.date_of_flight.Location = new System.Drawing.Point(155, 129);
            this.date_of_flight.Name = "date_of_flight";
            this.date_of_flight.Size = new System.Drawing.Size(100, 26);
            this.date_of_flight.TabIndex = 183;
            this.date_of_flight.ValueMember = "id";
            this.date_of_flight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.group_id_KeyPress);
            // 
            // CMD_PRINT
            // 
            this.CMD_PRINT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CMD_PRINT.Image = global::BAirway.Properties.Resources.printer2;
            this.CMD_PRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CMD_PRINT.Location = new System.Drawing.Point(437, 214);
            this.CMD_PRINT.Name = "CMD_PRINT";
            this.CMD_PRINT.Size = new System.Drawing.Size(68, 35);
            this.CMD_PRINT.TabIndex = 182;
            this.CMD_PRINT.Text = "Print";
            this.CMD_PRINT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CMD_PRINT.UseVisualStyleBackColor = true;
            this.CMD_PRINT.Click += new System.EventHandler(this.CMD_PRINT_Click);
            // 
            // B_SAVE
            // 
            this.B_SAVE.Enabled = false;
            this.B_SAVE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_SAVE.Image = global::BAirway.Properties.Resources.disk_blue_ok;
            this.B_SAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_SAVE.Location = new System.Drawing.Point(362, 214);
            this.B_SAVE.Name = "B_SAVE";
            this.B_SAVE.Size = new System.Drawing.Size(68, 35);
            this.B_SAVE.TabIndex = 5;
            this.B_SAVE.Text = "Save";
            this.B_SAVE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_SAVE.UseVisualStyleBackColor = true;
            this.B_SAVE.Visible = false;
            this.B_SAVE.Click += new System.EventHandler(this.B_SAVE_Click);
            // 
            // B_CANCEL
            // 
            this.B_CANCEL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_CANCEL.Image = global::BAirway.Properties.Resources.redo;
            this.B_CANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_CANCEL.Location = new System.Drawing.Point(511, 215);
            this.B_CANCEL.Name = "B_CANCEL";
            this.B_CANCEL.Size = new System.Drawing.Size(75, 35);
            this.B_CANCEL.TabIndex = 6;
            this.B_CANCEL.Text = "Reset";
            this.B_CANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_CANCEL.UseVisualStyleBackColor = true;
            this.B_CANCEL.Click += new System.EventHandler(this.B_CANCEL_Click);
            // 
            // Barcode
            // 
            this.Barcode.AutoSize = true;
            this.Barcode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Barcode.Location = new System.Drawing.Point(19, 167);
            this.Barcode.Name = "Barcode";
            this.Barcode.Size = new System.Drawing.Size(109, 14);
            this.Barcode.TabIndex = 149;
            this.Barcode.Text = "Passport Barcode :";
            // 
            // txt_barcode
            // 
            this.txt_barcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_barcode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_barcode.ForeColor = System.Drawing.Color.ForestGreen;
            this.txt_barcode.Location = new System.Drawing.Point(155, 161);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(431, 26);
            this.txt_barcode.TabIndex = 1;
            this.txt_barcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_barcode_KeyUp);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label22.Location = new System.Drawing.Point(19, 135);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 14);
            this.label22.TabIndex = 161;
            this.label22.Text = "Flight Year:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label19.Location = new System.Drawing.Point(19, 103);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 14);
            this.label19.TabIndex = 167;
            this.label19.Text = "Remark 2:";
            // 
            // remark2
            // 
            this.remark2.BackColor = System.Drawing.Color.White;
            this.remark2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.remark2.ForeColor = System.Drawing.Color.ForestGreen;
            this.remark2.Location = new System.Drawing.Point(155, 97);
            this.remark2.Name = "remark2";
            this.remark2.Size = new System.Drawing.Size(431, 26);
            this.remark2.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.Location = new System.Drawing.Point(19, 71);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 14);
            this.label20.TabIndex = 165;
            this.label20.Text = "Remark:";
            // 
            // remark
            // 
            this.remark.BackColor = System.Drawing.Color.White;
            this.remark.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.remark.ForeColor = System.Drawing.Color.ForestGreen;
            this.remark.Location = new System.Drawing.Point(155, 65);
            this.remark.Name = "remark";
            this.remark.Size = new System.Drawing.Size(431, 26);
            this.remark.TabIndex = 3;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label27.Location = new System.Drawing.Point(19, 32);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(48, 14);
            this.label27.TabIndex = 151;
            this.label27.Text = "Group :";
            // 
            // group_id
            // 
            this.group_id.DisplayMember = "group_description";
            this.group_id.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.group_id.FormattingEnabled = true;
            this.group_id.Location = new System.Drawing.Point(155, 22);
            this.group_id.Name = "group_id";
            this.group_id.Size = new System.Drawing.Size(431, 31);
            this.group_id.TabIndex = 2;
            this.group_id.ValueMember = "id";
            this.group_id.SelectedIndexChanged += new System.EventHandler(this.group_id_SelectedIndexChanged);
            this.group_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.group_id_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lbMessage);
            this.panel1.Controls.Add(this.lbAccessCode);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1209, 194);
            this.panel1.TabIndex = 0;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.BackColor = System.Drawing.Color.White;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbMessage.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbMessage.Location = new System.Drawing.Point(433, 46);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(0, 33);
            this.lbMessage.TabIndex = 129;
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAccessCode
            // 
            this.lbAccessCode.AutoSize = true;
            this.lbAccessCode.BackColor = System.Drawing.Color.White;
            this.lbAccessCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbAccessCode.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbAccessCode.Location = new System.Drawing.Point(432, 79);
            this.lbAccessCode.Name = "lbAccessCode";
            this.lbAccessCode.Size = new System.Drawing.Size(0, 33);
            this.lbAccessCode.TabIndex = 128;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // cboRemark1
            // 
            this.cboRemark1.DisplayMember = "value";
            this.cboRemark1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboRemark1.FormattingEnabled = true;
            this.cboRemark1.Location = new System.Drawing.Point(155, 61);
            this.cboRemark1.Name = "cboRemark1";
            this.cboRemark1.Size = new System.Drawing.Size(431, 31);
            this.cboRemark1.TabIndex = 195;
            this.cboRemark1.ValueMember = "id";
            // 
            // FrmAutoGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 578);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmAutoGen";
            this.Text = "Auto Generate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAutoGen_FormClosed);
            this.Load += new System.EventHandler(this.FrmAutoGen_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn genbystaffidDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn loungTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label L_SITE_DESC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button B_SAVE;
        private System.Windows.Forms.Button B_CANCEL;
        private System.Windows.Forms.Label Barcode;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox remark2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox remark;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox group_id;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CMD_PRINT;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label lbAccessCode;
        private System.Windows.Forms.ComboBox date_of_flight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lSupport;
        private System.Windows.Forms.ComboBox lounge_site;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbDisableVaridate;
        private System.Windows.Forms.ComboBox cboRemark1;
    }
}

