using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAnVinCom
{
    public partial class FormPhanCongMonHoc : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();
        public FormPhanCongMonHoc()
        {
            InitializeComponent();
            LoadData();
           
        }
        private void LoadData()
        {
            // Tải danh sách giáo viên vào ComboBox
            var teachers = db.GiaoViens.Select(gv => new { gv.MaGiaoVien, gv.HoTenGiaoVien }).ToList();
            cbxMaGV.DataSource = teachers;
            cbxMaGV.DisplayMember = "MaGiaoVien";
            cbxMaGV.ValueMember = "MaGiaoVien";

            // Tải dữ liệu phân công môn học vào DataGridView
            var assignments = db.PhanCongs
                .Join(db.GiaoViens, pc => pc.MaGV, gv => gv.MaGiaoVien, (pc, gv) => new { pc, gv.HoTenGiaoVien })
                .Join(db.MonHocs, pc => pc.pc.MaMon, mh => mh.MaMon, (pc, mh) => new
                {
                    pc.pc.MaGV,
                    pc.pc.MaMon,
                    pc.HoTenGiaoVien,
                    mh.TenMonHoc,
                    pc.pc.NgayBatDau, // Thêm trường NgayBatDau
                    pc.pc.NgayKetThuc  // Thêm trường NgayKetThuc
                })
                .ToList();

            dgvMonHoc.DataSource = assignments;
        }

        private string GenerateMaMon()
        {
            var lastMonHoc = db.MonHocs
                .OrderByDescending(m => m.MaMon)
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
                newMaMon = "MH" + lastNumber.ToString("D4"); // Ví dụ: MH0001, MH0002,...
            } while (db.MonHocs.Any(m => m.MaMon == newMaMon));

            return newMaMon;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var maGV = cbxMaGV.SelectedValue.ToString();
            var tenMonHoc = txtTenMonHoc.Text;

            if (string.IsNullOrEmpty(tenMonHoc))
            {
                MessageBox.Show("Tên môn học không được để trống.");
                return;
            }

            var maMon = GenerateMaMon();
            var ngayBatDau = dtpNgayBatDau.Value.Date;
            var ngayKetThuc = dtpNgayKetThuc.Value.Date;

            // Kiểm tra điều kiện ngày kết thúc
            if ((ngayKetThuc - ngayBatDau).Days < 120)
            {
                MessageBox.Show("Ngày kết thúc phải cách ngày bắt đầu ít nhất 120 ngày.");
                return;
            }

            // Thêm môn học mới vào bảng MonHoc
            var monHoc = new MonHoc
            {
                MaMon = maMon,
                TenMonHoc = tenMonHoc
            };
            db.MonHocs.InsertOnSubmit(monHoc);

            // Thêm phân công giáo viên vào bảng PhanCong
            var phanCong = new PhanCong
            {
                MaGV = maGV,
                MaMon = maMon,
                NgayBatDau = ngayBatDau,
                NgayKetThuc = ngayKetThuc
            };
            db.PhanCongs.InsertOnSubmit(phanCong);

            db.SubmitChanges();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvMonHoc.CurrentRow;
            if (selectedRow != null)
            {
                var maGV = selectedRow.Cells["MaGV"].Value.ToString();
                var maMon = selectedRow.Cells["MaMon"].Value.ToString();

                var phanCong = db.PhanCongs.SingleOrDefault(pc => pc.MaGV == maGV && pc.MaMon == maMon);

                if (phanCong != null)
                {
                    var ngayBatDau = dtpNgayBatDau.Value.Date;
                    var ngayKetThuc = dtpNgayKetThuc.Value.Date;

                    if ((ngayKetThuc - ngayBatDau).Days < 120)
                    {
                        MessageBox.Show("Ngày kết thúc phải cách ngày bắt đầu ít nhất 120 ngày.");
                        return;
                    }

                    phanCong.NgayBatDau = ngayBatDau;
                    phanCong.NgayKetThuc = ngayKetThuc;

                    db.SubmitChanges();
                    LoadData();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
           
            cbxMaGV.SelectedIndex = -1;
            txtTenMonHoc.Clear();
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvMonHoc.CurrentRow;
            if (selectedRow != null)
            {
                var maGV = selectedRow.Cells["MaGV"].Value.ToString();
                var maMon = selectedRow.Cells["MaMon"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phân công môn học này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var phanCong = db.PhanCongs.SingleOrDefault(pc => pc.MaGV == maGV && pc.MaMon == maMon);
                    if (phanCong != null)
                    {
                        db.PhanCongs.DeleteOnSubmit(phanCong);
                        db.SubmitChanges();
                        LoadData();
                        MessageBox.Show("Xóa phân công môn học thành công.");
                    }
                }
            }
        }



        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMonHoc.CurrentRow != null)
            {
                var selectedRow = dgvMonHoc.CurrentRow;
                var maGV = selectedRow.Cells["MaGV"].Value.ToString();
                var maMon = selectedRow.Cells["MaMon"].Value.ToString();

                var phanCong = db.PhanCongs
                    .SingleOrDefault(pc => pc.MaGV == maGV && pc.MaMon == maMon);

                if (phanCong != null)
                {
                    dtpNgayBatDau.Value = phanCong.NgayBatDau ?? DateTime.Now;
                    dtpNgayKetThuc.Value = phanCong.NgayKetThuc ?? DateTime.Now;
                    txtTenMonHoc.Text = db.MonHocs
                        .Where(mh => mh.MaMon == maMon)
                        .Select(mh => mh.TenMonHoc)
                        .FirstOrDefault();
                }
            }
        }

        private void cbxMaGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaGV.SelectedValue != null)
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
}
