using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DuAnVinCom
{
    public partial class ThemSuaLopHoc : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();

        public ThemSuaLopHoc()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadData();
            dgvLop.SelectionChanged += dgvLop_SelectionChanged;
        }

        private void InitializeDataGridView()
        {
           

            // Ẩn cột Row Header
            dgvLop.RowHeadersVisible = false;

            // Tự động căn chỉnh kích thước cột
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            LoadData();
        }
        private void LoadData()
        {
            // Tải dữ liệu cho cbxMaGiaoVien
            cbxMaGiaoVien.DataSource = db.GiaoViens.ToList();
            cbxMaGiaoVien.DisplayMember = "MaGiaoVien";
            cbxMaGiaoVien.ValueMember = "MaGiaoVien";

            // Tải dữ liệu cho cbxKhoi
            cbxKhoi.DataSource = db.KhoiLops.ToList();
            cbxKhoi.DisplayMember = "TenKhoi";
            cbxKhoi.ValueMember = "MaKhoi";

            // Tải dữ liệu cho cbxGhiChu
            cbxGhiChu.Items.Clear();
            cbxGhiChu.Items.Add("Đang làm việc");
            cbxGhiChu.Items.Add("Dừng hoạt động");

            // Kết hợp dữ liệu từ LopHoc và KhoiLop
            var lopHocData = from lh in db.LopHocs
                             join kh in db.KhoiLops on lh.MaKhoi equals kh.MaKhoi
                             select new
                             {
                                 lh.MaLop,
                                 lh.MaKhoi,
                                 TenKhoi = kh.TenKhoi,
                                 lh.MaGiaoVien,
                                 lh.TenLop,
                                 lh.GhiChu
                             };

            dgvLop.DataSource = lopHocData.ToList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var newLopHoc = new LopHoc
            {
                MaLop = GenerateMaLop(),
                MaKhoi = cbxKhoi.SelectedValue.ToString(),
                MaGiaoVien = cbxMaGiaoVien.SelectedValue.ToString(),
                TenLop = txtTenLop.Text,
                GhiChu = cbxGhiChu.SelectedItem?.ToString()
            };

            db.LopHocs.InsertOnSubmit(newLopHoc);
            db.SubmitChanges();

            LoadData();
        }

        private string GenerateMaLop()
        {
            var lastLop = db.LopHocs.OrderByDescending(lh => lh.MaLop).FirstOrDefault();

            if (lastLop == null)
            {
                return "VC001";
            }

            int lastNumber = int.Parse(lastLop.MaLop.Substring(2));
            return "VC" + (lastNumber + 1).ToString("D4");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var maLop = txtMaLop.Text;
            var lopHoc = db.LopHocs.SingleOrDefault(lh => lh.MaLop == maLop);

            if (lopHoc != null)
            {
                lopHoc.MaKhoi = cbxKhoi.SelectedValue.ToString();
                lopHoc.MaGiaoVien = cbxMaGiaoVien.SelectedValue.ToString();
                lopHoc.TenLop = txtTenLop.Text;
                lopHoc.GhiChu = cbxGhiChu.SelectedItem?.ToString();

                db.SubmitChanges();
                LoadData();
            }
            else
            {
                MessageBox.Show("Lớp học không tồn tại.");
            }
        }

        private void dgvLop_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLop.SelectedRows.Count > 0)
            {
                var selectedRow = dgvLop.SelectedRows[0];

                // Cập nhật các trường nhập liệu với dữ liệu từ dòng được chọn
                txtMaLop.Text = selectedRow.Cells["MaLop"].Value.ToString();
                cbxKhoi.SelectedValue = selectedRow.Cells["MaKhoi"].Value.ToString();
                cbxMaGiaoVien.SelectedValue = selectedRow.Cells["MaGiaoVien"].Value.ToString();
                txtTenLop.Text = selectedRow.Cells["TenLop"].Value.ToString();
                cbxGhiChu.SelectedItem = selectedRow.Cells["GhiChu"].Value.ToString();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Reload data to reset form
            LoadData();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtTenGV.Clear();
            cbxKhoi.SelectedIndex = -1;
            cbxMaGiaoVien.SelectedIndex = -1;
            cbxGhiChu.SelectedIndex = -1;
        }

        private void cbxMaGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaGiaoVien.SelectedValue != null)
            {
                string selectedMaGiaoVien = cbxMaGiaoVien.SelectedValue.ToString();
                var teacher = db.GiaoViens.SingleOrDefault(gv => gv.MaGiaoVien == selectedMaGiaoVien);

                if (teacher != null)
                {
                    txtTenGV.Text = teacher.HoTenGiaoVien;
                }
            }
        }
    }
}
