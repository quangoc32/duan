using System;
using System.Linq;
using System.Windows.Forms;

namespace DuAnVinCom
{
    public partial class BangDiemGiaoVienChuNhiem : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();

        public BangDiemGiaoVienChuNhiem()
        {
            InitializeComponent();
            LoadataDiem();
        }

        private void LoadataDiem()
        {
            // Tải dữ liệu vào ComboBox
            var hocSinhs = from hs in db.HocSinhs
                           select new { hs.MaHocSinh, hs.HoTen };
            cbxMaHS.DataSource = hocSinhs.ToList();
            cbxMaHS.DisplayMember = "MaHocSinh";  // Hiển thị tên học sinh
            cbxMaHS.ValueMember = "MaHocSinh";
            cbxMaHS.SelectedIndex = -1; // Không chọn giá trị mặc định ban đầu

            var namHocs = from nh in db.NamHocs
                          select nh;
            cbxNamHoc.DataSource = namHocs.ToList();
            cbxNamHoc.DisplayMember = "NamHoc";
            cbxNamHoc.ValueMember = "MaNH";
            cbxNamHoc.SelectedIndex = -1;

            var hocKys = from hk in db.HocKies
                         select hk;
            cbxHocKi.DataSource = hocKys.ToList();
            cbxHocKi.DisplayMember = "TenHK";
            cbxHocKi.ValueMember = "MaHK";
            cbxHocKi.SelectedIndex = -1;

            var monHocs = from mh in db.MonHocs
                          select mh;
            cbxMonHoc.DataSource = monHocs.ToList();
            cbxMonHoc.DisplayMember = "TenMonHoc";
            cbxMonHoc.ValueMember = "MaMon";
            cbxMonHoc.SelectedIndex = -1;
        }

        private void LoadDiemData()
        {
            var query = from d in db.Diems
                        join hs in db.HocSinhs on d.MaHocSinh equals hs.MaHocSinh
                        join nh in db.NamHocs on d.MaNH equals nh.MaNH
                        join hk in db.HocKies on d.MaHK equals hk.MaHK
                        join mh in db.MonHocs on d.MaMon equals mh.MaMon
                        select new
                        {
                            hs.MaHocSinh,
                            hs.HoTen,
                            nh.NamHoc1,
                            hk.TenHK,
                            mh.TenMonHoc,
                            d.KtMieng,
                            d.Kt15p,
                            d.Kt15pLan2,
                            d.Kt15pLan3,
                            d.Kt1Tiet,
                            d.Kt1TietLan2,
                            d.DiemThi,
                            d.DiemTrungBinh
                        };

            dgvDiem.DataSource = query.ToList();
        }


        private void BangDiemGiaoVienChuNhiem_Load(object sender, EventArgs e)
        {
            LoadataDiem();
            LoadDiemData();
        }

        private void cbxMaHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaHS.SelectedValue != null)
            {
                string maHocSinh = cbxMaHS.SelectedValue.ToString();
                var hocSinh = db.HocSinhs.FirstOrDefault(hs => hs.MaHocSinh == maHocSinh);
                if (hocSinh != null)
                {
                    txtTenHS.Text = hocSinh.HoTen;
                }
            }
        }

        private void TinhDiemTrungBinh()
        {
            if (decimal.TryParse(txtDM.Text, out decimal diemMieng) &&
                decimal.TryParse(txt15p1.Text, out decimal diem15p1) &&
                decimal.TryParse(txt15p2.Text, out decimal diem15p2) &&
                decimal.TryParse(txt15p3.Text, out decimal diem15p3) &&
                decimal.TryParse(txt1Tiet.Text, out decimal diem1Tiet1) &&
                decimal.TryParse(txtTiet2.Text, out decimal diem1Tiet2) &&
                decimal.TryParse(txtDiemThi.Text, out decimal diemThi))
            {
                decimal diemTrungBinh = (diemMieng + diem15p1 + diem15p2 + diem15p3 + (diem1Tiet1 + diem1Tiet2) * 2 + diemThi * 3) / 11;
                txtDTB.Text = diemTrungBinh.ToString("0.00");
            }
        }

        private void cbxNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOrInsertDiem();
        }

        private void cbxHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOrInsertDiem();
        }

        private void cbxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOrInsertDiem();
        }

        private void UpdateOrInsertDiem()
        {
            if (cbxMaHS.SelectedValue != null && cbxNamHoc.SelectedValue != null &&
        cbxHocKi.SelectedValue != null && cbxMonHoc.SelectedValue != null)
            {
                string maHocSinh = cbxMaHS.SelectedValue.ToString();
                string maNH = cbxNamHoc.SelectedValue.ToString();
                string maHK = cbxHocKi.SelectedValue.ToString();
                string maMon = cbxMonHoc.SelectedValue.ToString();

                var diem = db.Diems.FirstOrDefault(d => d.MaHocSinh == maHocSinh &&
                                                        d.MaNH == maNH &&
                                                        d.MaHK == maHK &&
                                                        d.MaMon == maMon);

                if (diem == null)
                {
                    diem = new Diem
                    {
                        MaSo = GenerateMaSo(),  // Sử dụng phương thức GenerateMaSo để tạo mã số mới
                        MaHocSinh = maHocSinh,
                        MaNH = maNH,
                        MaHK = maHK,
                        MaMon = maMon,
                        KtMieng = txtDM.Text,
                        Kt15p = txt15p1.Text,
                        Kt15pLan2 = txt15p2.Text,
                        Kt15pLan3 = txt15p3.Text,
                        Kt1Tiet = txt1Tiet.Text,
                        Kt1TietLan2 = txtTiet2.Text,
                        DiemThi = txtDiemThi.Text,
                        DiemTrungBinh = txtDTB.Text
                    };
                    db.Diems.InsertOnSubmit(diem);
                }
                else
                {
                    diem.KtMieng = txtDM.Text;
                    diem.Kt15p = txt15p1.Text;
                    diem.Kt15pLan2 = txt15p2.Text;
                    diem.Kt15pLan3 = txt15p3.Text;
                    diem.Kt1Tiet = txt1Tiet.Text;
                    diem.Kt1TietLan2 = txtTiet2.Text;
                    diem.DiemThi = txtDiemThi.Text;
                    diem.DiemTrungBinh = txtDTB.Text;
                }

                db.SubmitChanges();
                LoadDiemData(); // Tải lại dữ liệu sau khi cập nhật
            }
        }
        private void RefreshBangDiem()
        {
            var bangDiem = from d in db.Diems
                           select new
                           {
                               d.MaHocSinh,
                               d.MaNH,
                               d.MaHK,
                               d.MaMon,
                               d.KtMieng,
                               d.Kt15p,
                               d.Kt15pLan2,
                               d.Kt15pLan3,
                               d.Kt1Tiet,
                               d.Kt1TietLan2,
                               d.DiemThi,
                               d.DiemTrungBinh
                           };

            dgvDiem.DataSource = bangDiem.ToList();
        }

        private string GenerateMaSo()
        {
            string newMaSo;
            int lastNumber = 0;

            try
            {
                // Lấy mã số cuối cùng từ bảng Diem
                var lastDiem = db.Diems
                    .OrderByDescending(d => d.MaSo)
                    .Select(d => d.MaSo)
                    .FirstOrDefault();

                if (lastDiem != null)
                {
                    // Trích xuất số từ mã số cuối cùng
                    int.TryParse(lastDiem.Substring(2), out lastNumber);
                }

                // Tạo mã số mới
                do
                {
                    lastNumber++;
                    newMaSo = "DS" + lastNumber.ToString("D4");
                } while (db.Diems.Any(d => d.MaSo == newMaSo));
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                throw new Exception("Có lỗi khi tạo mã số điểm mới.", ex);
            }

            return newMaSo;
        }
        private void txtDM_TextChanged(object sender, EventArgs e)
        {
            TinhDiemTrungBinh();
        }

        private void txt15p1_TextChanged(object sender, EventArgs e)
        {
            TinhDiemTrungBinh();
        }

        private void txt15p2_TextChanged(object sender, EventArgs e)
        {
            TinhDiemTrungBinh();
        }

        private void txt15p3_TextChanged(object sender, EventArgs e)
        {
            TinhDiemTrungBinh();
        }

        private void txt1Tiet_TextChanged(object sender, EventArgs e)
        {
            TinhDiemTrungBinh();
        }

        private void txtTiet2_TextChanged(object sender, EventArgs e)
        {
            TinhDiemTrungBinh();
        }

        private void txtDiemThi_TextChanged(object sender, EventArgs e)
        {
            TinhDiemTrungBinh();
        }

        private void txtDTB_TextChanged(object sender, EventArgs e)
        {
            // Không cần thiết thêm code ở đây vì điểm trung bình được tự động tính toán.
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            UpdateOrInsertDiem();
            RefreshBangDiem();
        }


    }
}
