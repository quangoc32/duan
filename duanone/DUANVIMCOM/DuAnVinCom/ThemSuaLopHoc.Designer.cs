namespace DuAnVinCom
{
    partial class ThemSuaLopHoc
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtTenGV = new System.Windows.Forms.TextBox();
            this.txtTenHS = new System.Windows.Forms.TextBox();
            this.dgvLop = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxMaGiaoVien = new System.Windows.Forms.ComboBox();
            this.cbxMaHS = new System.Windows.Forms.ComboBox();
            this.cbxGhiChu = new System.Windows.Forms.ComboBox();
            this.cbxLop = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã Lớp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(401, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mã Giáo Viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(411, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên Học Sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ghi Chú";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtMaLop
            // 
            this.txtMaLop.Location = new System.Drawing.Point(157, 48);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(222, 22);
            this.txtMaLop.TabIndex = 9;
            // 
            // txtTenGV
            // 
            this.txtTenGV.Location = new System.Drawing.Point(916, 50);
            this.txtTenGV.Name = "txtTenGV";
            this.txtTenGV.Size = new System.Drawing.Size(179, 22);
            this.txtTenGV.TabIndex = 10;
           
            // 
            // txtTenHS
            // 
            this.txtTenHS.Location = new System.Drawing.Point(547, 117);
            this.txtTenHS.Name = "txtTenHS";
            this.txtTenHS.Size = new System.Drawing.Size(222, 22);
            this.txtTenHS.TabIndex = 12;
            
            // 
            // dgvLop
            // 
            this.dgvLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLop.Location = new System.Drawing.Point(12, 241);
            this.dgvLop.Name = "dgvLop";
            this.dgvLop.RowHeadersWidth = 51;
            this.dgvLop.RowTemplate.Height = 24;
            this.dgvLop.Size = new System.Drawing.Size(1079, 196);
            this.dgvLop.TabIndex = 14;
            this.dgvLop.SelectionChanged += new System.EventHandler(this.dgvLop_SelectionChanged);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.Control;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(167, 443);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(183, 36);
            this.btnThem.TabIndex = 78;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.Control;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(474, 443);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(163, 36);
            this.btnSua.TabIndex = 79;
            this.btnSua.Text = "Cập Nhật";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.SystemColors.Control;
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(740, 445);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(185, 36);
            this.btnLamMoi.TabIndex = 80;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(780, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên Giáo Viên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(802, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 23);
            this.label6.TabIndex = 82;
            this.label6.Text = "Lớp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 23);
            this.label7.TabIndex = 81;
            this.label7.Text = "Mã Học Sinh";
            // 
            // cbxMaGiaoVien
            // 
            this.cbxMaGiaoVien.FormattingEnabled = true;
            this.cbxMaGiaoVien.Location = new System.Drawing.Point(547, 50);
            this.cbxMaGiaoVien.Name = "cbxMaGiaoVien";
            this.cbxMaGiaoVien.Size = new System.Drawing.Size(222, 24);
            this.cbxMaGiaoVien.TabIndex = 85;
            this.cbxMaGiaoVien.SelectedIndexChanged += new System.EventHandler(this.cbxMaGiaoVien_SelectedIndexChanged);
            // 
            // cbxMaHS
            // 
            this.cbxMaHS.FormattingEnabled = true;
            this.cbxMaHS.Location = new System.Drawing.Point(157, 119);
            this.cbxMaHS.Name = "cbxMaHS";
            this.cbxMaHS.Size = new System.Drawing.Size(222, 24);
            this.cbxMaHS.TabIndex = 86;
            this.cbxMaHS.SelectedIndexChanged += new System.EventHandler(this.cbxMaHS_SelectedIndexChanged);
            // 
            // cbxGhiChu
            // 
            this.cbxGhiChu.FormattingEnabled = true;
            this.cbxGhiChu.Location = new System.Drawing.Point(157, 185);
            this.cbxGhiChu.Name = "cbxGhiChu";
            this.cbxGhiChu.Size = new System.Drawing.Size(222, 24);
            this.cbxGhiChu.TabIndex = 87;
            // 
            // cbxLop
            // 
            this.cbxLop.FormattingEnabled = true;
            this.cbxLop.Location = new System.Drawing.Point(916, 117);
            this.cbxLop.Name = "cbxLop";
            this.cbxLop.Size = new System.Drawing.Size(179, 24);
            this.cbxLop.TabIndex = 88;
            // 
            // ThemSuaLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1097, 493);
            this.Controls.Add(this.cbxLop);
            this.Controls.Add(this.cbxGhiChu);
            this.Controls.Add(this.cbxMaHS);
            this.Controls.Add(this.cbxMaGiaoVien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvLop);
            this.Controls.Add(this.txtTenHS);
            this.Controls.Add(this.txtTenGV);
            this.Controls.Add(this.txtMaLop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThemSuaLopHoc";
            this.Text = "ThemSuaLopHoc";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtTenGV;
        private System.Windows.Forms.TextBox txtTenHS;
        private System.Windows.Forms.DataGridView dgvLop;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxMaGiaoVien;
        private System.Windows.Forms.ComboBox cbxMaHS;
        private System.Windows.Forms.ComboBox cbxGhiChu;
        private System.Windows.Forms.ComboBox cbxLop;
    }
}