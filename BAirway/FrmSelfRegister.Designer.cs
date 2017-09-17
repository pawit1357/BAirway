namespace BAirway
{
    partial class FrmSelfRegister
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
            this.CMD_PRINT = new System.Windows.Forms.Button();
            this.TXT_BARCODE_DATA = new System.Windows.Forms.TextBox();
            this.TXT_ACCESS_CODE = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CMD_PRINT
            // 
            this.CMD_PRINT.BackColor = System.Drawing.Color.Transparent;
            this.CMD_PRINT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CMD_PRINT.Location = new System.Drawing.Point(1939, 815);
            this.CMD_PRINT.Margin = new System.Windows.Forms.Padding(4);
            this.CMD_PRINT.Name = "CMD_PRINT";
            this.CMD_PRINT.Size = new System.Drawing.Size(127, 121);
            this.CMD_PRINT.TabIndex = 3;
            this.CMD_PRINT.TabStop = false;
            this.CMD_PRINT.UseVisualStyleBackColor = false;
            this.CMD_PRINT.Click += new System.EventHandler(this.CMD_PRINT_Click);
            // 
            // TXT_BARCODE_DATA
            // 
            this.TXT_BARCODE_DATA.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TXT_BARCODE_DATA.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TXT_BARCODE_DATA.Location = new System.Drawing.Point(593, 249);
            this.TXT_BARCODE_DATA.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_BARCODE_DATA.Name = "TXT_BARCODE_DATA";
            this.TXT_BARCODE_DATA.Size = new System.Drawing.Size(883, 47);
            this.TXT_BARCODE_DATA.TabIndex = 1;
            this.TXT_BARCODE_DATA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TXT_BARCODE_DATA.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TXT_BARCODE_DATA_KeyUp);
            // 
            // TXT_ACCESS_CODE
            // 
            this.TXT_ACCESS_CODE.Enabled = false;
            this.TXT_ACCESS_CODE.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TXT_ACCESS_CODE.Location = new System.Drawing.Point(593, 490);
            this.TXT_ACCESS_CODE.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_ACCESS_CODE.Name = "TXT_ACCESS_CODE";
            this.TXT_ACCESS_CODE.Size = new System.Drawing.Size(883, 47);
            this.TXT_ACCESS_CODE.TabIndex = 2;
            this.TXT_ACCESS_CODE.TabStop = false;
            this.TXT_ACCESS_CODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmSelfRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::BAirway.Properties.Resources.bangkokairways_1900x900;
            this.ClientSize = new System.Drawing.Size(1848, 892);
            this.ControlBox = false;
            this.Controls.Add(this.TXT_ACCESS_CODE);
            this.Controls.Add(this.TXT_BARCODE_DATA);
            this.Controls.Add(this.CMD_PRINT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelfRegister";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSelfRegister";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSelfRegister_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSelfRegister_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CMD_PRINT;
        private System.Windows.Forms.TextBox TXT_BARCODE_DATA;
        private System.Windows.Forms.TextBox TXT_ACCESS_CODE;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.Timer timer1;
    }
}