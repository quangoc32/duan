namespace DuAnVinCom
{
    partial class ThemSuaPhongHoc
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.txtTenPhongHoc = new System.Windows.Forms.TextBox();
            this.txtSoLuongHocSinh = new System.Windows.Forms.TextBox();
            this.dgvPhongHoc = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbxTangLau = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã Phòng Học";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên Phòng Học";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(423, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số Lượng Học Sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(423, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tầng Lầu";
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(196, 57);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(203, 22);
            this.txtMaPhong.TabIndex = 6;
            // 
            // txtTenPhongHoc
            // 
            this.txtTenPhongHoc.Location = new System.Drawing.Point(196, 106);
            this.txtTenPhongHoc.Name = "txtTenPhongHoc";
            this.txtTenPhongHoc.Size = new System.Drawing.Size(203, 22);
            this.txtTenPhongHoc.TabIndex = 7;
            // 
            // txtSoLuongHocSinh
            // 
            this.txtSoLuongHocSinh.Location = new System.Drawing.Point(616, 56);
            this.txtSoLuongHocSinh.Name = "txtSoLuongHocSinh";
            this.txtSoLuongHocSinh.Size = new System.Drawing.Size(203, 22);
            this.txtSoLuongHocSinh.TabIndex = 8;
            // 
            // dgvPhongHoc
            // 
            this.dgvPhongHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhongHoc.Location = new System.Drawing.Point(12, 165);
            this.dgvPhongHoc.Name = "dgvPhongHoc";
            this.dgvPhongHoc.RowHeadersWidth = 51;
            this.dgvPhongHoc.RowTemplate.Height = 24;
            this.dgvPhongHoc.Size = new System.Drawing.Size(826, 196);
            this.dgvPhongHoc.TabIndex = 10;
            this.dgvPhongHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhongHoc_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.Control;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(75, 387);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(200, 36);
            this.btnThem.TabIndex = 77;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(323, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 36);
            this.button1.TabIndex = 78;
            this.button1.Text = "Sửa";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(573, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 36);
            this.button2.TabIndex = 79;
            this.button2.Text = "Ẩn Thông Tin";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbxTangLau
            // 
            this.cbxTangLau.FormattingEnabled = true;
            this.cbxTangLau.Location = new System.Drawing.Point(616, 106);
            this.cbxTangLau.Name = "cbxTangLau";
            this.cbxTangLau.Size = new System.Drawing.Size(203, 24);
            this.cbxTangLau.TabIndex = 80;
            // 
            // ThemSuaPhongHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(850, 446);
            this.Controls.Add(this.cbxTangLau);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvPhongHoc);
            this.Controls.Add(this.txtSoLuongHocSinh);
            this.Controls.Add(this.txtTenPhongHoc);
            this.Controls.Add(this.txtMaPhong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThemSuaPhongHoc";
            this.Text = "ThemSuaPhongHoc";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongHoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.TextBox txtTenPhongHoc;
        private System.Windows.Forms.TextBox txtSoLuongHocSinh;
        private System.Windows.Forms.DataGridView dgvPhongHoc;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbxTangLau;
    }
}