namespace BAirway
{
    partial class FrmDetail
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CMD_REGEN = new System.Windows.Forms.Button();
            this.B_ACCESS_CODE = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.remakr2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.remark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.passenger_name = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.group_id = new System.Windows.Forms.ComboBox();
            this.date_of_flight = new System.Windows.Forms.DateTimePicker();
            this.seat_no = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.flight_no = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.airline_code = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.to_city = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.from_city = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.Barcode = new System.Windows.Forms.Label();
            this.B_CANCEL = new System.Windows.Forms.Button();
            this.B_DEL = new System.Windows.Forms.Button();
            this.B_SAVE1 = new System.Windows.Forms.Button();
            this.CMD_PRINT = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = global::BAirway.Properties.Resources.fleet_a319;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(622, 120);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 166;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(91, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 35);
            this.label1.TabIndex = 169;
            this.label1.Text = "Edit Data";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CMD_REGEN);
            this.groupBox1.Controls.Add(this.B_ACCESS_CODE);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.remakr2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.remark);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(0, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 141);
            this.groupBox1.TabIndex = 170;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Data";
            // 
            // CMD_REGEN
            // 
            this.CMD_REGEN.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CMD_REGEN.Image = global::BAirway.Properties.Resources.redo;
            this.CMD_REGEN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CMD_REGEN.Location = new System.Drawing.Point(197, 89);
            this.CMD_REGEN.Name = "CMD_REGEN";
            this.CMD_REGEN.Size = new System.Drawing.Size(81, 35);
            this.CMD_REGEN.TabIndex = 176;
            this.CMD_REGEN.Text = "Re Gen";
            this.CMD_REGEN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CMD_REGEN.UseVisualStyleBackColor = true;
            this.CMD_REGEN.Click += new System.EventHandler(this.CMD_REGEN_Click);
            // 
            // B_ACCESS_CODE
            // 
            this.B_ACCESS_CODE.BackColor = System.Drawing.Color.White;
            this.B_ACCESS_CODE.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_ACCESS_CODE.ForeColor = System.Drawing.Color.ForestGreen;
            this.B_ACCESS_CODE.Location = new System.Drawing.Point(97, 93);
            this.B_ACCESS_CODE.Name = "B_ACCESS_CODE";
            this.B_ACCESS_CODE.ReadOnly = true;
            this.B_ACCESS_CODE.Size = new System.Drawing.Size(94, 26);
            this.B_ACCESS_CODE.TabIndex = 169;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(9, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 14);
            this.label12.TabIndex = 168;
            this.label12.Text = "Access Code :";
            // 
            // remakr2
            // 
            this.remakr2.BackColor = System.Drawing.Color.White;
            this.remakr2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.remakr2.ForeColor = System.Drawing.Color.ForestGreen;
            this.remakr2.Location = new System.Drawing.Point(97, 61);
            this.remakr2.Name = "remakr2";
            this.remakr2.Size = new System.Drawing.Size(382, 26);
            this.remakr2.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(25, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 14);
            this.label11.TabIndex = 167;
            this.label11.Text = "Remark 2:";
            // 
            // remark
            // 
            this.remark.BackColor = System.Drawing.Color.White;
            this.remark.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.remark.ForeColor = System.Drawing.Color.ForestGreen;
            this.remark.Location = new System.Drawing.Point(97, 29);
            this.remark.Name = "remark";
            this.remark.Size = new System.Drawing.Size(382, 26);
            this.remark.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(36, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 14);
            this.label10.TabIndex = 165;
            this.label10.Text = "Remark:";
            // 
            // passenger_name
            // 
            this.passenger_name.BackColor = System.Drawing.Color.White;
            this.passenger_name.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.passenger_name.ForeColor = System.Drawing.Color.ForestGreen;
            this.passenger_name.Location = new System.Drawing.Point(731, 171);
            this.passenger_name.Name = "passenger_name";
            this.passenger_name.Size = new System.Drawing.Size(287, 26);
            this.passenger_name.TabIndex = 174;
            this.passenger_name.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(627, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 14);
            this.label13.TabIndex = 175;
            this.label13.Text = "Passenger Name:";
            this.label13.Visible = false;
            // 
            // group_id
            // 
            this.group_id.DisplayMember = "id";
            this.group_id.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.group_id.FormattingEnabled = true;
            this.group_id.Location = new System.Drawing.Point(731, 203);
            this.group_id.Name = "group_id";
            this.group_id.Size = new System.Drawing.Size(287, 26);
            this.group_id.TabIndex = 173;
            this.group_id.ValueMember = "id";
            this.group_id.Visible = false;
            this.group_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.group_id_KeyPress);
            // 
            // date_of_flight
            // 
            this.date_of_flight.CustomFormat = "dd-MM-yyyy";
            this.date_of_flight.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.date_of_flight.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_of_flight.Location = new System.Drawing.Point(731, 364);
            this.date_of_flight.Name = "date_of_flight";
            this.date_of_flight.Size = new System.Drawing.Size(127, 26);
            this.date_of_flight.TabIndex = 7;
            this.date_of_flight.Visible = false;
            // 
            // seat_no
            // 
            this.seat_no.BackColor = System.Drawing.Color.White;
            this.seat_no.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.seat_no.ForeColor = System.Drawing.Color.ForestGreen;
            this.seat_no.Location = new System.Drawing.Point(731, 396);
            this.seat_no.Name = "seat_no";
            this.seat_no.Size = new System.Drawing.Size(127, 26);
            this.seat_no.TabIndex = 8;
            this.seat_no.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(670, 402);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 14);
            this.label9.TabIndex = 163;
            this.label9.Text = "Seat No:";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(639, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 14);
            this.label8.TabIndex = 161;
            this.label8.Text = "Date Of Flight:";
            this.label8.Visible = false;
            // 
            // flight_no
            // 
            this.flight_no.BackColor = System.Drawing.Color.White;
            this.flight_no.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.flight_no.ForeColor = System.Drawing.Color.ForestGreen;
            this.flight_no.Location = new System.Drawing.Point(731, 331);
            this.flight_no.Name = "flight_no";
            this.flight_no.Size = new System.Drawing.Size(287, 26);
            this.flight_no.TabIndex = 6;
            this.flight_no.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(663, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 14);
            this.label7.TabIndex = 159;
            this.label7.Text = "Flight No:";
            this.label7.Visible = false;
            // 
            // airline_code
            // 
            this.airline_code.BackColor = System.Drawing.Color.White;
            this.airline_code.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.airline_code.ForeColor = System.Drawing.Color.ForestGreen;
            this.airline_code.Location = new System.Drawing.Point(731, 299);
            this.airline_code.Name = "airline_code";
            this.airline_code.Size = new System.Drawing.Size(287, 26);
            this.airline_code.TabIndex = 5;
            this.airline_code.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(649, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 14);
            this.label6.TabIndex = 157;
            this.label6.Text = "Airline Code:";
            this.label6.Visible = false;
            // 
            // to_city
            // 
            this.to_city.BackColor = System.Drawing.Color.White;
            this.to_city.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.to_city.ForeColor = System.Drawing.Color.ForestGreen;
            this.to_city.Location = new System.Drawing.Point(731, 267);
            this.to_city.Name = "to_city";
            this.to_city.Size = new System.Drawing.Size(287, 26);
            this.to_city.TabIndex = 4;
            this.to_city.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(676, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 155;
            this.label5.Text = "To City:";
            this.label5.Visible = false;
            // 
            // from_city
            // 
            this.from_city.BackColor = System.Drawing.Color.White;
            this.from_city.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.from_city.ForeColor = System.Drawing.Color.ForestGreen;
            this.from_city.Location = new System.Drawing.Point(731, 235);
            this.from_city.Name = "from_city";
            this.from_city.Size = new System.Drawing.Size(287, 26);
            this.from_city.TabIndex = 3;
            this.from_city.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(663, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 14);
            this.label4.TabIndex = 153;
            this.label4.Text = "From City:";
            this.label4.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(647, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 151;
            this.label2.Text = "Group Name:";
            this.label2.Visible = false;
            // 
            // txt_barcode
            // 
            this.txt_barcode.Location = new System.Drawing.Point(0, 0);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(100, 20);
            this.txt_barcode.TabIndex = 183;
            // 
            // Barcode
            // 
            this.Barcode.AutoSize = true;
            this.Barcode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Barcode.Location = new System.Drawing.Point(671, 145);
            this.Barcode.Name = "Barcode";
            this.Barcode.Size = new System.Drawing.Size(54, 14);
            this.Barcode.TabIndex = 149;
            this.Barcode.Text = "Barcode:";
            this.Barcode.Visible = false;
            // 
            // B_CANCEL
            // 
            this.B_CANCEL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_CANCEL.Image = global::BAirway.Properties.Resources.redo;
            this.B_CANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_CANCEL.Location = new System.Drawing.Point(535, 243);
            this.B_CANCEL.Name = "B_CANCEL";
            this.B_CANCEL.Size = new System.Drawing.Size(75, 35);
            this.B_CANCEL.TabIndex = 12;
            this.B_CANCEL.Text = "Clear";
            this.B_CANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_CANCEL.UseVisualStyleBackColor = true;
            this.B_CANCEL.Click += new System.EventHandler(this.B_CANCEL_Click);
            // 
            // B_DEL
            // 
            this.B_DEL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_DEL.Image = global::BAirway.Properties.Resources.delete;
            this.B_DEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_DEL.Location = new System.Drawing.Point(373, 242);
            this.B_DEL.Name = "B_DEL";
            this.B_DEL.Size = new System.Drawing.Size(75, 35);
            this.B_DEL.TabIndex = 171;
            this.B_DEL.Text = "Delete";
            this.B_DEL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_DEL.UseVisualStyleBackColor = true;
            this.B_DEL.Visible = false;
            this.B_DEL.Click += new System.EventHandler(this.B_DEL_Click);
            // 
            // B_SAVE1
            // 
            this.B_SAVE1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.B_SAVE1.Image = global::BAirway.Properties.Resources.disk_blue_ok;
            this.B_SAVE1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_SAVE1.Location = new System.Drawing.Point(454, 242);
            this.B_SAVE1.Name = "B_SAVE1";
            this.B_SAVE1.Size = new System.Drawing.Size(75, 35);
            this.B_SAVE1.TabIndex = 180;
            this.B_SAVE1.Text = "Save";
            this.B_SAVE1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_SAVE1.UseVisualStyleBackColor = true;
            this.B_SAVE1.Click += new System.EventHandler(this.B_SAVE1_Click);
            // 
            // CMD_PRINT
            // 
            this.CMD_PRINT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CMD_PRINT.Image = global::BAirway.Properties.Resources.printer2;
            this.CMD_PRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CMD_PRINT.Location = new System.Drawing.Point(373, 242);
            this.CMD_PRINT.Name = "CMD_PRINT";
            this.CMD_PRINT.Size = new System.Drawing.Size(75, 35);
            this.CMD_PRINT.TabIndex = 181;
            this.CMD_PRINT.Text = "Print";
            this.CMD_PRINT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CMD_PRINT.UseVisualStyleBackColor = true;
            this.CMD_PRINT.Click += new System.EventHandler(this.CMD_PRINT_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(388, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 182;
            this.label3.Text = "Edit By ({0})";
            // 
            // FrmDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(622, 280);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CMD_PRINT);
            this.Controls.Add(this.passenger_name);
            this.Controls.Add(this.B_SAVE1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.B_DEL);
            this.Controls.Add(this.B_CANCEL);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.seat_no);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.group_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date_of_flight);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txt_barcode);
            this.Controls.Add(this.Barcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.from_city);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.to_city);
            this.Controls.Add(this.flight_no);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.airline_code);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Detail";
            this.Load += new System.EventHandler(this.FrmDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Label Barcode;
        //private System.Windows.Forms.Button B_SAVE;
        private System.Windows.Forms.Button B_CANCEL;
        private System.Windows.Forms.TextBox airline_code;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox to_city;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox from_city;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox seat_no;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox flight_no;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox remakr2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox remark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker date_of_flight;
        private System.Windows.Forms.Button B_DEL;
        private System.Windows.Forms.Button B_SAVE1;
        private System.Windows.Forms.TextBox B_ACCESS_CODE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox group_id;
        private System.Windows.Forms.TextBox passenger_name;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button CMD_REGEN;
        private System.Windows.Forms.Button CMD_PRINT;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label3;
    }
}