namespace BAirway
{
    partial class FrmManualGen
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
            this.cboRemark1 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.airlineCode = new System.Windows.Forms.TextBox();
            this.tocity = new System.Windows.Forms.TextBox();
            this.fromcity = new System.Windows.Forms.TextBox();
            this.CMD_PRINT = new System.Windows.Forms.Button();
            this.seat_no = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.passenger_name = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.flight_no = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.B_SAVE = new System.Windows.Forms.Button();
            this.B_CANCEL = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.date_of_flight = new System.Windows.Forms.DateTimePicker();
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
            this.splitContainer1.Size = new System.Drawing.Size(1209, 673);
            this.splitContainer1.SplitterDistance = 93;
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
            this.lounge_site.TabIndex = 192;
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
            this.pictureBox2.Size = new System.Drawing.Size(1209, 93);
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
            this.splitContainer2.Size = new System.Drawing.Size(1209, 576);
            this.splitContainer2.SplitterDistance = 421;
            this.splitContainer2.TabIndex = 180;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboRemark1);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.airlineCode);
            this.groupBox2.Controls.Add(this.tocity);
            this.groupBox2.Controls.Add(this.fromcity);
            this.groupBox2.Controls.Add(this.CMD_PRINT);
            this.groupBox2.Controls.Add(this.seat_no);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.passenger_name);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.flight_no);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.B_SAVE);
            this.groupBox2.Controls.Add(this.B_CANCEL);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.date_of_flight);
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
            this.groupBox2.Size = new System.Drawing.Size(1209, 421);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manual Generate";
            // 
            // cboRemark1
            // 
            this.cboRemark1.DisplayMember = "value";
            this.cboRemark1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboRemark1.FormattingEnabled = true;
            this.cboRemark1.Location = new System.Drawing.Point(187, 266);
            this.cboRemark1.Name = "cboRemark1";
            this.cboRemark1.Size = new System.Drawing.Size(431, 31);
            this.cboRemark1.TabIndex = 198;
            this.cboRemark1.ValueMember = "id";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(395, 237);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 20);
            this.label17.TabIndex = 197;
            this.label17.Text = "*";
            this.label17.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(395, 213);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 20);
            this.label16.TabIndex = 196;
            this.label16.Text = "*";
            this.label16.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(296, 187);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 20);
            this.label15.TabIndex = 195;
            this.label15.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(296, 153);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 20);
            this.label14.TabIndex = 194;
            this.label14.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(481, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 20);
            this.label12.TabIndex = 193;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(395, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 20);
            this.label11.TabIndex = 192;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(481, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 20);
            this.label10.TabIndex = 191;
            this.label10.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(624, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 20);
            this.label8.TabIndex = 190;
            this.label8.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(58, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 14);
            this.label6.TabIndex = 189;
            this.label6.Text = "Airline Code :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(58, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 14);
            this.label5.TabIndex = 188;
            this.label5.Text = "To :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(58, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 187;
            this.label4.Text = "From :";
            // 
            // airlineCode
            // 
            this.airlineCode.BackColor = System.Drawing.Color.White;
            this.airlineCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.airlineCode.ForeColor = System.Drawing.Color.ForestGreen;
            this.airlineCode.Location = new System.Drawing.Point(187, 94);
            this.airlineCode.MaxLength = 45;
            this.airlineCode.Name = "airlineCode";
            this.airlineCode.Size = new System.Drawing.Size(202, 22);
            this.airlineCode.TabIndex = 3;
            // 
            // tocity
            // 
            this.tocity.BackColor = System.Drawing.Color.White;
            this.tocity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tocity.ForeColor = System.Drawing.Color.ForestGreen;
            this.tocity.Location = new System.Drawing.Point(187, 238);
            this.tocity.MaxLength = 45;
            this.tocity.Name = "tocity";
            this.tocity.Size = new System.Drawing.Size(202, 22);
            this.tocity.TabIndex = 8;
            // 
            // fromcity
            // 
            this.fromcity.BackColor = System.Drawing.Color.White;
            this.fromcity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fromcity.ForeColor = System.Drawing.Color.ForestGreen;
            this.fromcity.Location = new System.Drawing.Point(187, 210);
            this.fromcity.MaxLength = 45;
            this.fromcity.Name = "fromcity";
            this.fromcity.Size = new System.Drawing.Size(202, 22);
            this.fromcity.TabIndex = 7;
            // 
            // CMD_PRINT
            // 
            this.CMD_PRINT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CMD_PRINT.Image = global::BAirway.Properties.Resources.printer2;
            this.CMD_PRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CMD_PRINT.Location = new System.Drawing.Point(396, 331);
            this.CMD_PRINT.Name = "CMD_PRINT";
            this.CMD_PRINT.Size = new System.Drawing.Size(68, 35);
            this.CMD_PRINT.TabIndex = 12;
            this.CMD_PRINT.Text = "Print";
            this.CMD_PRINT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CMD_PRINT.UseVisualStyleBackColor = true;
            this.CMD_PRINT.Click += new System.EventHandler(this.CMD_PRINT_Click);
            // 
            // seat_no
            // 
            this.seat_no.BackColor = System.Drawing.Color.White;
            this.seat_no.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.seat_no.ForeColor = System.Drawing.Color.ForestGreen;
            this.seat_no.Location = new System.Drawing.Point(187, 182);
            this.seat_no.MaxLength = 4;
            this.seat_no.Name = "seat_no";
            this.seat_no.Size = new System.Drawing.Size(103, 22);
            this.seat_no.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(58, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 14);
            this.label9.TabIndex = 182;
            this.label9.Text = "Seat No:";
            // 
            // passenger_name
            // 
            this.passenger_name.BackColor = System.Drawing.Color.White;
            this.passenger_name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.passenger_name.ForeColor = System.Drawing.Color.ForestGreen;
            this.passenger_name.Location = new System.Drawing.Point(187, 66);
            this.passenger_name.Name = "passenger_name";
            this.passenger_name.Size = new System.Drawing.Size(287, 22);
            this.passenger_name.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(58, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 180;
            this.label13.Text = "Full Name:";
            // 
            // flight_no
            // 
            this.flight_no.BackColor = System.Drawing.Color.White;
            this.flight_no.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.flight_no.ForeColor = System.Drawing.Color.ForestGreen;
            this.flight_no.Location = new System.Drawing.Point(187, 122);
            this.flight_no.MaxLength = 45;
            this.flight_no.Name = "flight_no";
            this.flight_no.Size = new System.Drawing.Size(287, 22);
            this.flight_no.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(58, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 178;
            this.label7.Text = "Flight No:";
            // 
            // B_SAVE
            // 
            this.B_SAVE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_SAVE.Image = global::BAirway.Properties.Resources.disk_blue_ok;
            this.B_SAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_SAVE.Location = new System.Drawing.Point(470, 331);
            this.B_SAVE.Name = "B_SAVE";
            this.B_SAVE.Size = new System.Drawing.Size(68, 35);
            this.B_SAVE.TabIndex = 11;
            this.B_SAVE.Text = "Save";
            this.B_SAVE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_SAVE.UseVisualStyleBackColor = true;
            this.B_SAVE.Click += new System.EventHandler(this.B_SAVE_Click);
            // 
            // B_CANCEL
            // 
            this.B_CANCEL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_CANCEL.Image = global::BAirway.Properties.Resources.redo;
            this.B_CANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_CANCEL.Location = new System.Drawing.Point(543, 331);
            this.B_CANCEL.Name = "B_CANCEL";
            this.B_CANCEL.Size = new System.Drawing.Size(75, 35);
            this.B_CANCEL.TabIndex = 13;
            this.B_CANCEL.Text = "Reset";
            this.B_CANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_CANCEL.UseVisualStyleBackColor = true;
            this.B_CANCEL.Click += new System.EventHandler(this.B_CANCEL_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label22.Location = new System.Drawing.Point(58, 157);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(87, 14);
            this.label22.TabIndex = 161;
            this.label22.Text = "Date Of Flight:";
            // 
            // date_of_flight
            // 
            this.date_of_flight.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.date_of_flight.CustomFormat = "dd-MM-yyyy";
            this.date_of_flight.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.date_of_flight.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_of_flight.Location = new System.Drawing.Point(187, 150);
            this.date_of_flight.Name = "date_of_flight";
            this.date_of_flight.Size = new System.Drawing.Size(103, 26);
            this.date_of_flight.TabIndex = 5;
            this.date_of_flight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.group_id_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label19.Location = new System.Drawing.Point(58, 306);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 14);
            this.label19.TabIndex = 167;
            this.label19.Text = "Remark 2:";
            // 
            // remark2
            // 
            this.remark2.BackColor = System.Drawing.Color.White;
            this.remark2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.remark2.ForeColor = System.Drawing.Color.ForestGreen;
            this.remark2.Location = new System.Drawing.Point(187, 303);
            this.remark2.Name = "remark2";
            this.remark2.Size = new System.Drawing.Size(431, 22);
            this.remark2.TabIndex = 10;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.Location = new System.Drawing.Point(58, 269);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 14);
            this.label20.TabIndex = 165;
            this.label20.Text = "Remark:";
            // 
            // remark
            // 
            this.remark.BackColor = System.Drawing.Color.White;
            this.remark.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.remark.ForeColor = System.Drawing.Color.ForestGreen;
            this.remark.Location = new System.Drawing.Point(187, 266);
            this.remark.Name = "remark";
            this.remark.Size = new System.Drawing.Size(431, 22);
            this.remark.TabIndex = 9;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label27.Location = new System.Drawing.Point(58, 33);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(44, 14);
            this.label27.TabIndex = 151;
            this.label27.Text = "Group:";
            // 
            // group_id
            // 
            this.group_id.DisplayMember = "group_description";
            this.group_id.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.group_id.FormattingEnabled = true;
            this.group_id.Location = new System.Drawing.Point(188, 23);
            this.group_id.Name = "group_id";
            this.group_id.Size = new System.Drawing.Size(430, 31);
            this.group_id.TabIndex = 1;
            this.group_id.ValueMember = "id";
            this.group_id.SelectedIndexChanged += new System.EventHandler(this.group_id_SelectedIndexChanged);
            this.group_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.group_id_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lbMessage);
            this.panel1.Controls.Add(this.lbAccessCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1209, 151);
            this.panel1.TabIndex = 0;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.BackColor = System.Drawing.Color.White;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbMessage.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbMessage.Location = new System.Drawing.Point(428, 27);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(0, 33);
            this.lbMessage.TabIndex = 127;
            // 
            // lbAccessCode
            // 
            this.lbAccessCode.AutoSize = true;
            this.lbAccessCode.BackColor = System.Drawing.Color.White;
            this.lbAccessCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbAccessCode.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbAccessCode.Location = new System.Drawing.Point(428, 60);
            this.lbAccessCode.Name = "lbAccessCode";
            this.lbAccessCode.Size = new System.Drawing.Size(0, 33);
            this.lbAccessCode.TabIndex = 126;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // FrmManualGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 673);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmManualGen";
            this.Text = "Manual Generate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmManualGen_FormClosed);
            this.Load += new System.EventHandler(this.FrmManualGen_Load);
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
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker date_of_flight;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox remark2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox remark;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox group_id;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbAccessCode;
        private System.Windows.Forms.TextBox passenger_name;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox flight_no;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox seat_no;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button CMD_PRINT;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox tocity;
        private System.Windows.Forms.TextBox fromcity;
        private System.Windows.Forms.TextBox airlineCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lSupport;
        private System.Windows.Forms.ComboBox lounge_site;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboRemark1;
    }
}

