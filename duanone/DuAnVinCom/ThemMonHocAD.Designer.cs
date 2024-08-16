namespace DuAnVinCom
{
    partial class ThemMonHocAD
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
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dpBatDau = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxMonHoc = new System.Windows.Forms.ComboBox();
            this.cbxMaGV = new System.Windows.Forms.ComboBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnAn = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.dataGridViewPhanCong = new System.Windows.Forms.DataGridView();
            this.txtTenGV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaMon
            // 
            this.txtMaMon.Location = new System.Drawing.Point(164, 17);
            this.txtMaMon.Multiline = true;
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new System.Drawing.Size(188, 24);
            this.txtMaMon.TabIndex = 107;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 23);
            this.label6.TabIndex = 106;
            this.label6.Text = "Mã Môn";
            // 
            // dpKetThuc
            // 
            this.dpKetThuc.Location = new System.Drawing.Point(710, 114);
            this.dpKetThuc.Name = "dpKetThuc";
            this.dpKetThuc.Size = new System.Drawing.Size(200, 22);
            this.dpKetThuc.TabIndex = 105;
            // 
            // dpBatDau
            // 
            this.dpBatDau.Location = new System.Drawing.Point(710, 63);
            this.dpBatDau.Name = "dpBatDau";
            this.dpBatDau.Size = new System.Drawing.Size(200, 22);
            this.dpBatDau.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(559, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 23);
            this.label3.TabIndex = 103;
            this.label3.Text = "Ngày bắt đầu";
            // 
            // cbxMonHoc
            // 
            this.cbxMonHoc.FormattingEnabled = true;
            this.cbxMonHoc.Location = new System.Drawing.Point(710, 17);
            this.cbxMonHoc.Name = "cbxMonHoc";
            this.cbxMonHoc.Size = new System.Drawing.Size(189, 24);
            this.cbxMonHoc.TabIndex = 102;
            // 
            // cbxMaGV
            // 
            this.cbxMaGV.FormattingEnabled = true;
            this.cbxMaGV.Location = new System.Drawing.Point(164, 61);
            this.cbxMaGV.Name = "cbxMaGV";
            this.cbxMaGV.Size = new System.Drawing.Size(188, 24);
            this.cbxMaGV.TabIndex = 101;
            this.cbxMaGV.SelectedIndexChanged += new System.EventHandler(this.cbxMaGV_SelectedIndexChanged_1);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.SystemColors.Control;
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(680, 347);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 36);
            this.btnLamMoi.TabIndex = 100;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click_1);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.Control;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(145, 347);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(137, 36);
            this.btnThem.TabIndex = 99;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // btnAn
            // 
            this.btnAn.BackColor = System.Drawing.SystemColors.Control;
            this.btnAn.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAn.Location = new System.Drawing.Point(506, 347);
            this.btnAn.Name = "btnAn";
            this.btnAn.Size = new System.Drawing.Size(140, 36);
            this.btnAn.TabIndex = 98;
            this.btnAn.Text = "Ẩn";
            this.btnAn.UseVisualStyleBackColor = false;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.SystemColors.Control;
            this.btnCapNhat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Location = new System.Drawing.Point(329, 347);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(140, 36);
            this.btnCapNhat.TabIndex = 97;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click_1);
            // 
            // dataGridViewPhanCong
            // 
            this.dataGridViewPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhanCong.Location = new System.Drawing.Point(22, 158);
            this.dataGridViewPhanCong.Name = "dataGridViewPhanCong";
            this.dataGridViewPhanCong.RowHeadersWidth = 51;
            this.dataGridViewPhanCong.RowTemplate.Height = 24;
            this.dataGridViewPhanCong.Size = new System.Drawing.Size(946, 173);
            this.dataGridViewPhanCong.TabIndex = 96;
            this.dataGridViewPhanCong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPhanCong_CellClick_1);
            // 
            // txtTenGV
            // 
            this.txtTenGV.Location = new System.Drawing.Point(209, 112);
            this.txtTenGV.Multiline = true;
            this.txtTenGV.Name = "txtTenGV";
            this.txtTenGV.Size = new System.Drawing.Size(188, 24);
            this.txtTenGV.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(559, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 94;
            this.label5.Text = "Môn Học";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(559, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 23);
            this.label4.TabIndex = 93;
            this.label4.Text = "Ngày bắt đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 23);
            this.label2.TabIndex = 92;
            this.label2.Text = "Tên Giáo Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 23);
            this.label1.TabIndex = 91;
            this.label1.Text = "Mã Giáo Viên";
            // 
            // ThemMonHocAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(982, 388);
            this.Controls.Add(this.txtMaMon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dpKetThuc);
            this.Controls.Add(this.dpBatDau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxMonHoc);
            this.Controls.Add(this.cbxMaGV);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnAn);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.dataGridViewPhanCong);
            this.Controls.Add(this.txtTenGV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThemMonHocAD";
            this.Text = "ThemMonHocAD";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhanCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpKetThuc;
        private System.Windows.Forms.DateTimePicker dpBatDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxMonHoc;
        private System.Windows.Forms.ComboBox cbxMaGV;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnAn;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.DataGridView dataGridViewPhanCong;
        private System.Windows.Forms.TextBox txtTenGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}