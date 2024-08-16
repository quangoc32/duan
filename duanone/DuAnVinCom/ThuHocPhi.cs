using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DuAnVinCom
{
    public partial class ThuHocPhi : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();
       
        public ThuHocPhi()
        {
            InitializeComponent();
           

        }

        private void ThuHocPhi_Load(object sender, EventArgs e)
        { 
            LoadData();
            dateTimePicker2.Value = DateTime.Now; // Set the current date
            txtSoTien.Text = "1000000"; // Auto-load fee amount (example value)

        
        }



        public void LoadData()
        {

            // Load students into MaHocSinh combobox
            var students = db.HocSinhs.Select(hs => new
            {
                hs.MaHocSinh,
                hs.HoTen
            }).ToList();
            cbxMaHS.DataSource = students;
            cbxMaHS.DisplayMember = "MaHocSinh";
            cbxMaHS.ValueMember = "MaHocSinh";

            var hocPhis = db.HocPhis.Select(hp => new
            {
                hp.MaHocPhi,
                hp.MaHocSinh,
                TenHS = hp.HocSinh.HoTen,
                hp.NgayThu,
                hp.SoTien,
                hp.TrangThai
            }).ToList();

            // Add class info to each hocPhi
            var hocPhisWithClass = hocPhis.Select(hp => new
            {
                hp.MaHocPhi,
                hp.MaHocSinh,
                hp.TenHS,
                hp.NgayThu,
                hp.SoTien,
                hp.TrangThai,
                
            }).ToList();

            dgvTienHocPhi.DataSource = hocPhisWithClass;


        }

       


        private string GenerateMaPhieu()
        {
            var lastHP = db.HocPhis.OrderByDescending(hp => hp.MaHocPhi).FirstOrDefault();

            int lastNumber = 0;
            if (lastHP != null)
            {
                int.TryParse(lastHP.MaHocPhi.Substring(2), out lastNumber);
            }

            string newMaHP;
            do
            {
                lastNumber++;
                newMaHP = "HP" + lastNumber.ToString("D4");
            } while (db.HocPhis.Any(hp => hp.MaHocPhi == newMaHP));

            return newMaHP;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var hocphi = new HocPhi
            {
                MaHocPhi = GenerateMaPhieu(),
                MaHocSinh = cbxMaHS.SelectedValue.ToString(),
                TrangThai = "Đã thanh toán", // Update status to "Đã thanh toán"
                NgayThu = dateTimePicker2.Value,
                SoTien = txtSoTien.Text
            };

            db.HocPhis.InsertOnSubmit(hocphi);
            db.SubmitChanges();
            LoadData();

            MessageBox.Show("Đăng ký thành công!");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxMaHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMaHocSinh = cbxMaHS.SelectedValue.ToString();
            var student = db.HocSinhs.SingleOrDefault(hs => hs.MaHocSinh == selectedMaHocSinh);

            if (student != null)
            {
                txtTenHS.Text = student.HoTen;
            }
        }

        private void cbxMaGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvTienHocPhi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTienHocPhi.SelectedRows.Count > 0)
            {
                var selectedRow = dgvTienHocPhi.SelectedRows[0];

                txtMaHP.Text = selectedRow.Cells["MaHocPhi"].Value.ToString();
                cbxMaHS.SelectedValue = selectedRow.Cells["MaHocSinh"].Value.ToString();
                dateTimePicker2.Value = Convert.ToDateTime(selectedRow.Cells["NgayThu"].Value);
                txtSoTien.Text = selectedRow.Cells["SoTien"].Value.ToString();
                cbxTrangThai.Text = selectedRow.Cells["TrangThai"].Value.ToString();
                txtTenHS.Text = selectedRow.Cells["TenHS"].Value.ToString();
        
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            
        }

        private void cbxLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
