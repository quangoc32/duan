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
    public partial class ThemSuaTietHoc : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();
        public ThemSuaTietHoc()
        {
            InitializeComponent();
            LoadData();
            LoadDataToGridView();
        }

        private void LoadDataToGridView()
        {
            try
            {
                using (var db = new DuAn1DataContext())
                {
                    var tietHocs = from th in db.TietHocs
                                   join gv in db.GiaoViens on th.MaGiaoVien equals gv.MaGiaoVien
                                   join lh in db.LopHocs on th.MaLopHoc equals lh.MaLop
                                   join mh in db.MonHocs on th.MaMonHoc equals mh.MaMon
                                   join ph in db.PhongHocs on th.MaPhongHoc equals ph.MaPhongHoc
                                   select new
                                   {
                                       th.MaTietHoc,
                                       th.MaMonHoc,
                                       mh.TenMonHoc,
                                       th.MaLopHoc,
                                       lh.TenLop,
                                       th.MaGiaoVien,
                                       gv.HoTenGiaoVien,
                                       th.MaPhongHoc,
                                       ph.TenPhongHoc,
                                       th.Thu,
                                       th.Tiet,
                                       th.GioBatDau,
                                       th.GioKetThuc
                                   };

                    dgvTietHoc.DataSource = tietHocs.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp dữ liệu vào DataGridView: " + ex.Message);
            }
        }

        private void LoadData()
        {
            using (var db = new DuAn1DataContext())
            {
                // Load GiaoVien
                // Tải dữ liệu cho cbxMaGiaoVien
                cbxMaGV.DataSource = db.GiaoViens.ToList();
                cbxMaGV.DisplayMember = "MaGiaoVien";
               cbxMaGV.ValueMember = "MaGiaoVien";

                // Load LopHoc
                cbxLop.DataSource = db.LopHocs.ToList();
                cbxLop.DisplayMember = "TenLop";
                cbxLop.ValueMember = "MaLop";

                // Load MonHoc
                cbxMonHoc.DataSource = db.MonHocs.ToList();
                cbxMonHoc.DisplayMember = "TenMonHoc";
                cbxMonHoc.ValueMember = "MaMon";

                // Load PhongHoc
                cbxPhong.DataSource = db.PhongHocs.ToList();
                cbxPhong.DisplayMember = "TenPhongHoc";
                cbxPhong.ValueMember = "MaPhongHoc";

                // Load Thứ
                cbxThu.Items.AddRange(new string[] { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ Nhật" });

                // Load Tiết
                cbxTiet.Items.AddRange(Enumerable.Range(1, 10).Select(i => "Tiết " + i).ToArray());
            }
        }

        private string GenerateMaTietHoc()
        {
            var lastTietHoc = db.TietHocs.OrderByDescending(th => th.MaTietHoc).FirstOrDefault();
            if (lastTietHoc != null)
            {
                int lastMaTietHoc;
                if (int.TryParse(lastTietHoc.MaTietHoc.Substring(2), out lastMaTietHoc))
                {
                    return "TH" + (lastMaTietHoc + 1).ToString("D4");
                }
                else
                {
                    return "TH0001";
                }
            }
            else
            {
                return "TH0001";
            }
        }
        private void CalculateThoiGianTietHoc(int tiet, out TimeSpan gioBatDau, out TimeSpan gioKetThuc)
        {
            TimeSpan startTime = new TimeSpan(7, 0, 0); // 7h00
            TimeSpan duration = new TimeSpan(0, 50, 0); // 50 phút

            if (tiet >= 1 && tiet <= 5)
            {
                gioBatDau = startTime.Add(TimeSpan.FromMinutes((tiet - 1) * 50));
                gioKetThuc = gioBatDau.Add(duration);
            }
            else
            {
                gioBatDau = new TimeSpan(13, 0, 0).Add(TimeSpan.FromMinutes((tiet - 6) * 50));
                gioKetThuc = gioBatDau.Add(duration);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var tietHoc = new TietHoc
                {
                    MaTietHoc = GenerateMaTietHoc(),
                    MaMonHoc = cbxMonHoc.SelectedValue.ToString(),
                    MaLopHoc = cbxLop.SelectedValue.ToString(),
                    MaGiaoVien = cbxMaGV.SelectedValue.ToString(),
                    MaPhongHoc = cbxPhong.SelectedValue.ToString(),
                    Thu = cbxThu.SelectedItem.ToString(),
                    Tiet = cbxTiet.SelectedIndex + 1,
                    SoTiet = 1,
                    GioBatDau = TimeSpan.Parse(txtBatDau.Text),
                    GioKetThuc = TimeSpan.Parse(txtKetThuc.Text)
                };

                db.TietHocs.InsertOnSubmit(tietHoc);
                db.SubmitChanges();
                MessageBox.Show("Thêm tiết học thành công!");
                LoadDataToGridView(); // Cập nhật DataGridView sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tiết học: " + ex.Message);
            }
        }

       

      

        private void cbxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxMaGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaGV.SelectedIndex != -1)
            {
                string selectedMaGiaoVien = cbxMaGV.SelectedValue.ToString();
                var teacher = db.GiaoViens.SingleOrDefault(gv => gv.MaGiaoVien == selectedMaGiaoVien);

                if (teacher != null)
                {
                    txtGiaoVien.Text = teacher.HoTenGiaoVien;
                }
            }
        }

        private void cbxPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTietHoc.SelectedRows.Count > 0)
                {
                    string maTietHoc = dgvTietHoc.SelectedRows[0].Cells["MaTietHoc"].Value.ToString();
                    TietHoc tietHoc = db.TietHocs.SingleOrDefault(th => th.MaTietHoc == maTietHoc);

                    if (tietHoc != null)
                    {
                        int tiet = cbxTiet.SelectedIndex + 1;
                        TimeSpan gioBatDau, gioKetThuc;
                        CalculateThoiGianTietHoc(tiet, out gioBatDau, out gioKetThuc);

                        tietHoc.MaGiaoVien = cbxMaGV.SelectedValue.ToString();
                        tietHoc.MaLopHoc = cbxLop.SelectedValue.ToString();
                        tietHoc.MaMonHoc = cbxMonHoc.SelectedValue.ToString();
                        tietHoc.MaPhongHoc = cbxPhong.SelectedValue.ToString();
                        tietHoc.Thu = cbxThu.SelectedItem.ToString();
                        tietHoc.GioBatDau = gioBatDau;
                        tietHoc.GioKetThuc = gioKetThuc;

                        db.SubmitChanges();
                        MessageBox.Show("Cập nhật tiết học thành công!");
                        LoadDataToGridView(); // Cập nhật DataGridView sau khi cập nhật
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tiết học: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbxMaGV.SelectedIndex = -1;
            cbxLop.SelectedIndex = -1;
            cbxMonHoc.SelectedIndex = -1;
            cbxPhong.SelectedIndex = -1;
            cbxThu.SelectedIndex = -1;
           
            txtBatDau.Clear();
            txtKetThuc.Clear();
        }

        private void dgvTietHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTietHoc.Rows[e.RowIndex];
                cbxMaGV.SelectedValue = row.Cells["MaGiaoVien"].Value.ToString();
                cbxLop.SelectedValue = row.Cells["MaLopHoc"].Value.ToString();
                cbxMonHoc.SelectedValue = row.Cells["MaMonHoc"].Value.ToString();
                cbxPhong.SelectedValue = row.Cells["MaPhongHoc"].Value.ToString();
                cbxThu.SelectedItem = row.Cells["Thu"].Value.ToString();
                txtBatDau.Text = row.Cells["GioBatDau"].Value.ToString();
                txtKetThuc.Text = row.Cells["GioKetThuc"].Value.ToString();
            }
        }

        private void cbxTiet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTiet.SelectedIndex != -1)
            {
                int tietHoc = cbxTiet.SelectedIndex + 1;
                TimeSpan gioBatDau, gioKetThuc;

                CalculateThoiGianTietHoc(tietHoc, out gioBatDau, out gioKetThuc);

                txtBatDau.Text = gioBatDau.ToString(@"hh\:mm");
                txtKetThuc.Text = gioKetThuc.ToString(@"hh\:mm");
            }
        }
    }
}
