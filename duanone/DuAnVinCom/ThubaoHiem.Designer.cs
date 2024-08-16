namespace DuAnVinCom
{
    partial class ThubaoHiem
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
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.cbxTinhTrang = new System.Windows.Forms.ComboBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.txtMaBH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxLoaiBaoHiem = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxHocSinh = new System.Windows.Forms.ComboBox();
            this.txtTenHS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxMaGV = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTenGV = new System.Windows.Forms.TextBox();
            this.dgvTienBaoHiem = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienBaoHiem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(24)))), ((int)(((byte)(63)))));
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(588, 504);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(180, 61);
            this.btnHuy.TabIndex = 215;
            this.btnHuy.Text = "Hủy Đăng Ký";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(24)))), ((int)(((byte)(63)))));
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(358, 504);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(178, 61);
            this.btnXacNhan.TabIndex = 214;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // cbxTinhTrang
            // 
            this.cbxTinhTrang.FormattingEnabled = true;
            this.cbxTinhTrang.Location = new System.Drawing.Point(554, 143);
            this.cbxTinhTrang.Name = "cbxTinhTrang";
            this.cbxTinhTrang.Size = new System.Drawing.Size(192, 24);
            this.cbxTinhTrang.TabIndex = 213;
            this.cbxTinhTrang.SelectedIndexChanged += new System.EventHandler(this.cbxTinhTrang_SelectedIndexChanged);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(554, 257);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(192, 22);
            this.txtSoTien.TabIndex = 211;
            this.txtSoTien.TextChanged += new System.EventHandler(this.txtSoTien_TextChanged);
            // 
            // txtMaBH
            // 
            this.txtMaBH.Location = new System.Drawing.Point(170, 143);
            this.txtMaBH.Name = "txtMaBH";
            this.txtMaBH.Size = new System.Drawing.Size(192, 22);
            this.txtMaBH.TabIndex = 209;
            this.txtMaBH.TextChanged += new System.EventHandler(this.txtMaBH_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(392, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 23);
            this.label7.TabIndex = 208;
            this.label7.Text = "Loại Bảo Hiểm";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(392, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 23);
            this.label6.TabIndex = 207;
            this.label6.Text = "Trạng Thái";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(392, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 206;
            this.label4.Text = "Số Tiền";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 23);
            this.label2.TabIndex = 205;
            this.label2.Text = "Mã Học Sinh";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 23);
            this.label1.TabIndex = 204;
            this.label1.Text = "Mã Bảo Hiểm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(24)))), ((int)(((byte)(63)))));
            this.label3.Location = new System.Drawing.Point(406, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 57);
            this.label3.TabIndex = 203;
            this.label3.Text = "Tiền Bảo Hiểm";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbxLoaiBaoHiem
            // 
            this.cbxLoaiBaoHiem.FormattingEnabled = true;
            this.cbxLoaiBaoHiem.Location = new System.Drawing.Point(554, 196);
            this.cbxLoaiBaoHiem.Name = "cbxLoaiBaoHiem";
            this.cbxLoaiBaoHiem.Size = new System.Drawing.Size(192, 24);
            this.cbxLoaiBaoHiem.TabIndex = 217;
            this.cbxLoaiBaoHiem.SelectedIndexChanged += new System.EventHandler(this.cbxLoaiBaoHiem_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(782, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 23);
            this.label5.TabIndex = 218;
            this.label5.Text = "Ngày Áp Dụng";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cbxHocSinh
            // 
            this.cbxHocSinh.FormattingEnabled = true;
            this.cbxHocSinh.Location = new System.Drawing.Point(170, 199);
            this.cbxHocSinh.Name = "cbxHocSinh";
            this.cbxHocSinh.Size = new System.Drawing.Size(192, 24);
            this.cbxHocSinh.TabIndex = 220;
            this.cbxHocSinh.SelectedIndexChanged += new System.EventHandler(this.cbxHocSinh_SelectedIndexChanged_1);
            // 
            // txtTenHS
            // 
            this.txtTenHS.Location = new System.Drawing.Point(170, 257);
            this.txtTenHS.Name = "txtTenHS";
            this.txtTenHS.Size = new System.Drawing.Size(192, 22);
            this.txtTenHS.TabIndex = 222;
            this.txtTenHS.TextChanged += new System.EventHandler(this.txtTenHS_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(-2, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 23);
            this.label8.TabIndex = 221;
            this.label8.Text = " Tên Học Sinh";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cbxMaGV
            // 
            this.cbxMaGV.FormattingEnabled = true;
            this.cbxMaGV.Location = new System.Drawing.Point(924, 144);
            this.cbxMaGV.Name = "cbxMaGV";
            this.cbxMaGV.Size = new System.Drawing.Size(192, 24);
            this.cbxMaGV.TabIndex = 223;
            this.cbxMaGV.SelectedIndexChanged += new System.EventHandler(this.cbxMaGV_SelectedIndexChanged_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(782, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 23);
            this.label9.TabIndex = 224;
            this.label9.Text = "Mã Giáo Viên ";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(784, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 23);
            this.label10.TabIndex = 225;
            this.label10.Text = "Tên Giáo Viên";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txtTenGV
            // 
            this.txtTenGV.Location = new System.Drawing.Point(924, 201);
            this.txtTenGV.Name = "txtTenGV";
            this.txtTenGV.Size = new System.Drawing.Size(192, 22);
            this.txtTenGV.TabIndex = 226;
            this.txtTenGV.TextChanged += new System.EventHandler(this.txtTenGV_TextChanged);
            // 
            // dgvTienBaoHiem
            // 
            this.dgvTienBaoHiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTienBaoHiem.Location = new System.Drawing.Point(10, 312);
            this.dgvTienBaoHiem.Name = "dgvTienBaoHiem";
            this.dgvTienBaoHiem.RowHeadersWidth = 51;
            this.dgvTienBaoHiem.RowTemplate.Height = 24;
            this.dgvTienBaoHiem.Size = new System.Drawing.Size(1124, 176);
            this.dgvTienBaoHiem.TabIndex = 227;
            this.dgvTienBaoHiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTienBaoHiem_CellContentClick);
            this.dgvTienBaoHiem.SelectionChanged += new System.EventHandler(this.dgvTienBaoHiem_SelectionChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(924, 258);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 228;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // ThubaoHiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1141, 592);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dgvTienBaoHiem);
            this.Controls.Add(this.txtTenGV);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxMaGV);
            this.Controls.Add(this.txtTenHS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxHocSinh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxLoaiBaoHiem);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.cbxTinhTrang);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.txtMaBH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "ThubaoHiem";
            this.Text = "ThubaoHiem";
            this.Load += new System.EventHandler(this.ThubaoHiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienBaoHiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.ComboBox cbxTinhTrang;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.TextBox txtMaBH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxLoaiBaoHiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxHocSinh;
        private System.Windows.Forms.TextBox txtTenHS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxMaGV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTenGV;
        private System.Windows.Forms.DataGridView dgvTienBaoHiem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}