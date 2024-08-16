using System;
using System.Linq;
using System.Windows.Forms;

namespace DuAnVinCom
{
    public partial class ThubaoHiem : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();

        public ThubaoHiem()
        {
            InitializeComponent();
        }

        private void ThubaoHiem_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadBaoHiemData(); 
        }

        private void LoadBaoHiemData()
        {
            var baoHiemData = db.BaoHiems.Select(bh => new
            {
                bh.MaBaoHiem,
                bh.MaHocSinh,
                bh.HocSinh.HoTen,
                bh.TrangThai,
                bh.LoaiBaoHiem,
                bh.NgayApDung,
                bh.SoTien
            }).ToList();

            dgvTienBaoHiem.DataSource = baoHiemData;
        }

        private void LoadData()
        {
            // Load teachers into MaGiaoVien combobox
            var teachers = db.GiaoViens.Select(gv => new
            {
                gv.MaGiaoVien,
                gv.HoTenGiaoVien
            }).ToList();
            cbxMaGV.DataSource = teachers;
            cbxMaGV.DisplayMember = "MaGiaoVien"; 
            cbxMaGV.ValueMember = "MaGiaoVien";

            // Load students into MaHocSinh combobox
            var students = db.HocSinhs.Select(hs => new
            {
                hs.MaHocSinh,
                hs.HoTen
            }).ToList();
            cbxHocSinh.DataSource = students;
            cbxHocSinh.DisplayMember = "MaGiaoVien";
            cbxHocSinh.ValueMember = "MaHocSinh";

            // Load insurance types into LoaiBaoHiem combobox
            cbxLoaiBaoHiem.Items.Add(new { Text = "Bảo hiểm y tế", Value = 5000000 });
            cbxLoaiBaoHiem.Items.Add(new { Text = "Bảo hiểm tai nạn", Value = 1000000 });
            cbxLoaiBaoHiem.DisplayMember = "Text";
            cbxLoaiBaoHiem.ValueMember = "Value";


        }

        private string GenerateMaBaoHiem()
        {
            var lastBaoHiem = db.BaoHiems.OrderByDescending(bh => bh.MaBaoHiem).FirstOrDefault();
            if (lastBaoHiem != null)
            {
                int lastNumber = int.Parse(lastBaoHiem.MaBaoHiem.Substring(2));
                return "BH" + (lastNumber + 1).ToString("D4");
            }
            return "BH0001";
        }





        private void cbxLoaiBaoHiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLoaiBaoHiem.SelectedItem != null)
            {
                var selected = (dynamic)cbxLoaiBaoHiem.SelectedItem;
                txtSoTien.Text = selected.Value.ToString();
            }
        }

       
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var baoHiem = new BaoHiem
            {
                MaBaoHiem = GenerateMaBaoHiem(),
                MaHocSinh = cbxHocSinh.SelectedValue.ToString(),
                TrangThai = "Thanh toán", // Update status to "Thanh toán"
                LoaiBaoHiem = cbxLoaiBaoHiem.Text,
                NgayApDung = dateTimePicker1.Value,
                SoTien = txtSoTien.Text
            };

            db.BaoHiems.InsertOnSubmit(baoHiem);
            db.SubmitChanges();
            LoadBaoHiemData();

            MessageBox.Show("Đăng ký thành công!");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTienBaoHiem_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTienBaoHiem.SelectedRows.Count > 0)
            {
                var selectedRow = dgvTienBaoHiem.SelectedRows[0];
                txtMaBH.Text = selectedRow.Cells["MaBaoHiem"].Value.ToString();
                cbxHocSinh.SelectedValue = selectedRow.Cells["MaHocSinh"].Value.ToString();
                txtTenHS.Text = selectedRow.Cells["HoTen"].Value.ToString();
                cbxTinhTrang.Text = selectedRow.Cells["Tình Trạng"].Value.ToString();
                cbxLoaiBaoHiem.Text = selectedRow.Cells["LoaiBaoHiem"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells["NgayApDung"].Value);
                txtSoTien.Text = selectedRow.Cells["SoTien"].Value.ToString();
            }
        }

        private void cbxHocSinh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedMaHocSinh = cbxHocSinh.SelectedValue.ToString();
            var student = db.HocSinhs.SingleOrDefault(hs => hs.MaHocSinh == selectedMaHocSinh);

            if (student != null)
            {
                txtTenHS.Text = student.HoTen;
            }
        }

        private void cbxMaGV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedMaGiaoVien = cbxMaGV.SelectedValue.ToString();
            var teacher = db.GiaoViens.SingleOrDefault(gv => gv.MaGiaoVien == selectedMaGiaoVien);

            if (teacher != null)
            {
                txtTenGV.Text = teacher.HoTenGiaoVien;
            }
        }
    }
}
