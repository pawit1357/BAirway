namespace BAirway
{
    partial class FrmFtp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ftpPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ftpUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ftpServerIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.B_UPLOAD = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ftpPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ftpUserID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ftpServerIP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ftpPassword
            // 
            this.ftpPassword.BackColor = System.Drawing.Color.White;
            this.ftpPassword.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ftpPassword.ForeColor = System.Drawing.Color.ForestGreen;
            this.ftpPassword.Location = new System.Drawing.Point(100, 83);
            this.ftpPassword.Name = "ftpPassword";
            this.ftpPassword.PasswordChar = '#';
            this.ftpPassword.Size = new System.Drawing.Size(149, 26);
            this.ftpPassword.TabIndex = 154;
            this.ftpPassword.Text = "sp7GuZan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(32, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 155;
            this.label2.Text = "Password :";
            // 
            // ftpUserID
            // 
            this.ftpUserID.BackColor = System.Drawing.Color.White;
            this.ftpUserID.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ftpUserID.ForeColor = System.Drawing.Color.ForestGreen;
            this.ftpUserID.Location = new System.Drawing.Point(100, 51);
            this.ftpUserID.Name = "ftpUserID";
            this.ftpUserID.Size = new System.Drawing.Size(247, 26);
            this.ftpUserID.TabIndex = 152;
            this.ftpUserID.Text = "pawit@prdapp.net";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(31, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 153;
            this.label1.Text = "Username :";
            // 
            // ftpServerIP
            // 
            this.ftpServerIP.BackColor = System.Drawing.Color.White;
            this.ftpServerIP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ftpServerIP.ForeColor = System.Drawing.Color.ForestGreen;
            this.ftpServerIP.Location = new System.Drawing.Point(100, 19);
            this.ftpServerIP.Name = "ftpServerIP";
            this.ftpServerIP.Size = new System.Drawing.Size(247, 26);
            this.ftpServerIP.TabIndex = 150;
            this.ftpServerIP.Text = "prdapp.net:2002";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(59, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 151;
            this.label3.Text = "Host :";
            // 
            // B_UPLOAD
            // 
            this.B_UPLOAD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_UPLOAD.Image = global::BAirway.Properties.Resources.disk_blue_ok;
            this.B_UPLOAD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_UPLOAD.Location = new System.Drawing.Point(317, 157);
            this.B_UPLOAD.Name = "B_UPLOAD";
            this.B_UPLOAD.Size = new System.Drawing.Size(85, 35);
            this.B_UPLOAD.TabIndex = 7;
            this.B_UPLOAD.Text = "Save";
            this.B_UPLOAD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_UPLOAD.UseVisualStyleBackColor = true;
            this.B_UPLOAD.Click += new System.EventHandler(this.B_UPLOAD_Click);
            // 
            // FrmFtp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(414, 199);
            this.Controls.Add(this.B_UPLOAD);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmFtp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP Setting";
            this.Load += new System.EventHandler(this.FrmFtp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_UPLOAD;
        private System.Windows.Forms.TextBox ftpPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ftpUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ftpServerIP;
        private System.Windows.Forms.Label label3;
    }
}