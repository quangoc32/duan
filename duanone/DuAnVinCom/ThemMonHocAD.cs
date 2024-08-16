using System;
using System.Linq;
using System.Windows.Forms;

namespace DuAnVinCom
{
    public partial class ThemMonHocAD : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();

        public ThemMonHocAD()
        {
            InitializeComponent();
            LoadData();
            LoadDataGridView();
        }

        private void LoadData()
        {
            // Tải danh sách giáo viên vào combobox MaGiaoVien
            var teachers = db.GiaoViens.Select(gv => new
            {
                gv.MaGiaoVien,
                gv.HoTenGiaoVien
            }).ToList();
            cbxMaGV.DataSource = teachers;
            cbxMaGV.DisplayMember = "MaGiaoVien";
            cbxMaGV.ValueMember = "MaGiaoVien";

            // Thêm danh sách môn học vào combobox MonHoc
            cbxMonHoc.Items.AddRange(new object[]
            {
                "Toán", "Lý", "Hóa", "Văn", "Sử", "Địa", "Sinh", "Anh", "Tin học", "Thể dục"
            });

            // Thiết lập combobox không chọn mục nào ban đầu
            cbxMaGV.SelectedIndex = -1;
            cbxMonHoc.SelectedIndex = -1;
        }

        private void LoadDataGridView()
        {
            var data = from pc in db.PhanCongs
                       join gv in db.GiaoViens on pc.MaGV equals gv.MaGiaoVien
                       join mh in db.MonHocs on pc.MaMon equals mh.MaMon
                       select new
                       {
                           pc.MaGV,
                           gv.HoTenGiaoVien,
                           pc.MaMon,
                           mh.TenMonHoc,
                           pc.NgayBatDau,
                           pc.NgayKetThuc
                       };

            dataGridViewPhanCong.DataSource = data.ToList();
        }

       

      

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            
        }

        private void cbxMaGV_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridViewPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private string GenerateMaMon()
        {
            var lastMonHoc = db.MonHocs
                .OrderByDescending(mh => mh.MaMon)
                .FirstOrDefault();

            int lastNumber = 0;
            if (lastMonHoc != null)
            {
                int.TryParse(lastMonHoc.MaMon.Substring(2), out lastNumber);
            }

            string newMaMon;
            do
            {
                lastNumber++;
                newMaMon = "MH" + lastNumber.ToString("D4");
            } while (db.MonHocs.Any(mh => mh.MaMon == newMaMon));

            return newMaMon;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbxMonHoc.Text) || cbxMaGV.SelectedIndex == -1 || dpBatDau.Value == null || dpKetThuc.Value == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newMaMon = GenerateMaMon();

            MonHoc monHoc = new MonHoc
            {
                MaMon = newMaMon,
                TenMonHoc = cbxMonHoc.Text
            };

            db.MonHocs.InsertOnSubmit(monHoc);

            string maGV = cbxMaGV.SelectedValue.ToString();

            PhanCong phanCong = new PhanCong
            {
                MaGV = maGV,
                MaMon = newMaMon,
                NgayBatDau = dpBatDau.Value,
                NgayKetThuc = dpKetThuc.Value
            };

            db.PhanCongs.InsertOnSubmit(phanCong);

            db.SubmitChanges();

            MessageBox.Show("Thêm môn học và phân công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
            LoadData(); // Tải lại dữ liệu cho combobox
        }

       


        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            if (cbxMaGV.SelectedIndex == -1 || cbxMonHoc.SelectedIndex == -1 || dpBatDau.Value == null || dpKetThuc.Value == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maGV = cbxMaGV.SelectedValue.ToString();
            string tenMonHoc = cbxMonHoc.SelectedItem.ToString();

            var monHoc = db.MonHocs.SingleOrDefault(mh => mh.TenMonHoc == tenMonHoc);

            if (monHoc == null)
            {
                MessageBox.Show("Môn học không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phanCong = db.PhanCongs.SingleOrDefault(pc => pc.MaGV == maGV && pc.MaMon == monHoc.MaMon);

            if (phanCong == null)
            {
                MessageBox.Show("Phân công không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            phanCong.NgayBatDau = dpBatDau.Value;
            phanCong.NgayKetThuc = dpKetThuc.Value;

            db.SubmitChanges();

            MessageBox.Show("Cập nhật phân công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            txtTenGV.Clear();
            cbxMaGV.SelectedIndex = -1;
            cbxMonHoc.SelectedIndex = -1;
            dpBatDau.Value = DateTime.Now;
            dpKetThuc.Value = DateTime.Now;
        }

        private void cbxMaGV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxMaGV.SelectedIndex != -1)
            {
                string selectedMaGiaoVien = cbxMaGV.SelectedValue.ToString();
                var teacher = db.GiaoViens.SingleOrDefault(gv => gv.MaGiaoVien == selectedMaGiaoVien);

                if (teacher != null)
                {
                    txtTenGV.Text = teacher.HoTenGiaoVien;
                }
            }
        }

        

        private void dataGridViewPhanCong_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPhanCong.Rows[e.RowIndex];

                cbxMaGV.SelectedValue = row.Cells["MaGV"].Value.ToString();
                cbxMonHoc.SelectedItem = row.Cells["TenMonHoc"].Value.ToString();
                dpBatDau.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
                dpKetThuc.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
            }
        }
    }
}
