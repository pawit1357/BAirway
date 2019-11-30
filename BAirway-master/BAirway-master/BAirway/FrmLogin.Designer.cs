namespace BAirway
{
    partial class FrmLogin
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
            this.LUPDATE_DATE = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.LAPPTITLE = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LAPPCOMPANY = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.station = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.area = new System.Windows.Forms.ComboBox();
            this.lounge = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lSupport = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LUPDATE_DATE
            // 
            this.LUPDATE_DATE.BackColor = System.Drawing.Color.Transparent;
            this.LUPDATE_DATE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LUPDATE_DATE.ForeColor = System.Drawing.Color.Teal;
            this.LUPDATE_DATE.Location = new System.Drawing.Point(300, 237);
            this.LUPDATE_DATE.Name = "LUPDATE_DATE";
            this.LUPDATE_DATE.Size = new System.Drawing.Size(147, 16);
            this.LUPDATE_DATE.TabIndex = 24;
            this.LUPDATE_DATE.Text = "####";
            this.LUPDATE_DATE.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Font = new System.Drawing.Font("BrowalliaUPC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cancel.ForeColor = System.Drawing.Color.White;
            this.Cancel.Location = new System.Drawing.Point(378, 203);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(69, 31);
            this.Cancel.TabIndex = 21;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.UsernameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UsernameLabel.Location = new System.Drawing.Point(175, 145);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UsernameLabel.Size = new System.Drawing.Size(107, 31);
            this.UsernameLabel.TabIndex = 16;
            this.UsernameLabel.Text = "Staff ID";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.OK.Font = new System.Drawing.Font("BrowalliaUPC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.OK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.OK.Location = new System.Drawing.Point(300, 203);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(72, 31);
            this.OK.TabIndex = 20;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // LAPPTITLE
            // 
            this.LAPPTITLE.BackColor = System.Drawing.Color.Transparent;
            this.LAPPTITLE.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LAPPTITLE.ForeColor = System.Drawing.Color.DarkBlue;
            this.LAPPTITLE.Location = new System.Drawing.Point(12, 13);
            this.LAPPTITLE.Name = "LAPPTITLE";
            this.LAPPTITLE.Size = new System.Drawing.Size(435, 28);
            this.LAPPTITLE.TabIndex = 23;
            this.LAPPTITLE.Text = "####";
            this.LAPPTITLE.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PasswordTextBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.PasswordTextBox.Location = new System.Drawing.Point(288, 176);
            this.PasswordTextBox.MaxLength = 20;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(159, 21);
            this.PasswordTextBox.TabIndex = 19;
            this.PasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTextBox_KeyDown);
            // 
            // LAPPCOMPANY
            // 
            this.LAPPCOMPANY.BackColor = System.Drawing.Color.Transparent;
            this.LAPPCOMPANY.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LAPPCOMPANY.ForeColor = System.Drawing.Color.DarkBlue;
            this.LAPPCOMPANY.Location = new System.Drawing.Point(36, 41);
            this.LAPPCOMPANY.Name = "LAPPCOMPANY";
            this.LAPPCOMPANY.Size = new System.Drawing.Size(411, 25);
            this.LAPPCOMPANY.TabIndex = 22;
            this.LAPPCOMPANY.Text = "####";
            this.LAPPCOMPANY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.UsernameTextBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.UsernameTextBox.Location = new System.Drawing.Point(288, 149);
            this.UsernameTextBox.MaxLength = 20;
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(159, 21);
            this.UsernameTextBox.TabIndex = 17;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.PasswordLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PasswordLabel.Location = new System.Drawing.Point(164, 170);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PasswordLabel.Size = new System.Drawing.Size(118, 23);
            this.PasswordLabel.TabIndex = 18;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // station
            // 
            this.station.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.station.DisplayMember = "site_name";
            this.station.Enabled = false;
            this.station.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.station.FormattingEnabled = true;
            this.station.Location = new System.Drawing.Point(238, 69);
            this.station.Name = "station";
            this.station.Size = new System.Drawing.Size(209, 21);
            this.station.TabIndex = 151;
            this.station.ValueMember = "id";
            this.station.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.group_id_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(125, 63);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(107, 31);
            this.label1.TabIndex = 152;
            this.label1.Text = "Station";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(236, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 163;
            this.label6.Text = "Area:";
            // 
            // area
            // 
            this.area.DisplayMember = "area_name";
            this.area.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.area.FormattingEnabled = true;
            this.area.Location = new System.Drawing.Point(276, 123);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(171, 21);
            this.area.TabIndex = 162;
            this.area.ValueMember = "id";
            // 
            // lounge
            // 
            this.lounge.DisplayMember = "lounge_name";
            this.lounge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lounge.FormattingEnabled = true;
            this.lounge.Location = new System.Drawing.Point(276, 96);
            this.lounge.Name = "lounge";
            this.lounge.Size = new System.Drawing.Size(171, 21);
            this.lounge.TabIndex = 160;
            this.lounge.ValueMember = "id";
            this.lounge.SelectedIndexChanged += new System.EventHandler(this.staff_lounge_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(224, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 161;
            this.label4.Text = "Lounge:";
            // 
            // lSupport
            // 
            this.lSupport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lSupport.AutoSize = true;
            this.lSupport.BackColor = System.Drawing.Color.White;
            this.lSupport.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lSupport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lSupport.Location = new System.Drawing.Point(257, 253);
            this.lSupport.Name = "lSupport";
            this.lSupport.Size = new System.Drawing.Size(147, 18);
            this.lSupport.TabIndex = 164;
            this.lSupport.Text = "Support Tel : {0} {1}";
            this.lSupport.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::BAirway.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(478, 276);
            this.ControlBox = false;
            this.Controls.Add(this.lSupport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.area);
            this.Controls.Add(this.lounge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.station);
            this.Controls.Add(this.LUPDATE_DATE);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.LAPPTITLE);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.LAPPCOMPANY);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LUPDATE_DATE;
        internal System.Windows.Forms.Button Cancel;
        internal System.Windows.Forms.Label UsernameLabel;
        internal System.Windows.Forms.Button OK;
        internal System.Windows.Forms.Label LAPPTITLE;
        internal System.Windows.Forms.TextBox PasswordTextBox;
        internal System.Windows.Forms.Label LAPPCOMPANY;
        internal System.Windows.Forms.TextBox UsernameTextBox;
        internal System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.ComboBox station;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox area;
        private System.Windows.Forms.ComboBox lounge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lSupport;
    }
}