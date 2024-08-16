using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DuAnVinCom
{
    public partial class FormChucVuGV : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();

        public FormChucVuGV()
        {
            InitializeComponent();

            LoadData();
            LoadGiaoVien();
        }

        private void FormChucVuGV_Load(object sender, EventArgs e)
        {
        }

        private void LoadData()
        {
            var chucVuList = from cv in db.ChucVus
                             join gv in db.GiaoViens on cv.MaGiaoVien equals gv.MaGiaoVien
                             select new
                             {
                                 MaChucVu = cv.MaChucVu,
                                 TenChucVu = cv.TenChucVu,
                                 MaGiaoVien = cv.MaGiaoVien,
                                 TenGiaoVien = gv.HoTenGiaoVien,
                                 Email = cv.Email,
                                 MatKhau = cv.MatKhau
                             };
            dgvChucVu.DataSource = chucVuList.ToList();
        }

        private void LoadGiaoVien()
        {
            var giaoVienList = from gv in db.GiaoViens
                               select new
                               {
                                   gv.MaGiaoVien,
                                   gv.HoTenGiaoVien
                               };

            cbxMaGiaoVien.DataSource = giaoVienList.ToList();
            cbxMaGiaoVien.DisplayMember = "MaGiaoVien";
            cbxMaGiaoVien.ValueMember = "MaGiaoVien";
        }

        private string GenerateMaChucVu()
        {
            // Giả sử bạn muốn tạo mã chức vụ bằng cách kết hợp "CV" với số thứ tự tăng dần.
            int maxId = db.ChucVus.Count() + 1;
            return "CV" + maxId.ToString("D3");
        }

        private string GenerateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Chia chuỗi thành các từ
            var words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    // Viết hoa chữ cái đầu
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            // Kết hợp các từ lại với nhau
            return string.Join(" ", words);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(txtChucVu.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                !txtEmail.Text.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin và đảm bảo email có định dạng '@gmail.com'.");
                return;
            }

            ChucVu newChucVu = new ChucVu
            {
                MaChucVu = GenerateMaChucVu(),
                MaGiaoVien = cbxMaGiaoVien.SelectedValue.ToString(),
                TenChucVu = CapitalizeFirstLetter(txtChucVu.Text),
                Email = txtEmail.Text,
                MatKhau = !string.IsNullOrEmpty(txtMatKhau.Text) ? GenerateMD5(txtMatKhau.Text) : null
            };

            db.ChucVus.InsertOnSubmit(newChucVu);
            db.SubmitChanges();
            MessageBox.Show("Thêm chức vụ thành công!");
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (dgvChucVu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chức vụ để sửa.");
                return;
            }

            var selectedMaChucVu = dgvChucVu.SelectedRows[0].Cells["MaChucVu"].Value.ToString();
            var chucVu = db.ChucVus.FirstOrDefault(cv => cv.MaChucVu == selectedMaChucVu);

            if (chucVu == null)
            {
                MessageBox.Show("Chức vụ không tồn tại.");
                return;
            }

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(txtChucVu.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                !txtEmail.Text.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin và đảm bảo email có định dạng '@gmail.com'.");
                return;
            }

            chucVu.MaGiaoVien = cbxMaGiaoVien.SelectedValue.ToString();
            chucVu.TenChucVu = CapitalizeFirstLetter(txtChucVu.Text);
            chucVu.Email = txtEmail.Text;
            if (!string.IsNullOrEmpty(txtMatKhau.Text))
            {
                chucVu.MatKhau = GenerateMD5(txtMatKhau.Text);
            }

            db.SubmitChanges();
            MessageBox.Show("Cập nhật chức vụ thành công!");
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbxMaGiaoVien.SelectedIndex = -1;
            txtTenGV.Clear();
            txtChucVu.Clear();
            txtEmail.Clear();
            txtMatKhau.Clear();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var selectedMaChucVu = dgvChucVu.SelectedRows[0].Cells["MaChucVu"].Value.ToString();
            var chucVu = db.ChucVus.FirstOrDefault(cv => cv.MaChucVu == selectedMaChucVu);

            if (chucVu != null)
            {
                db.ChucVus.DeleteOnSubmit(chucVu);
                db.SubmitChanges();
                MessageBox.Show("Xóa chức vụ thành công!");
                LoadData();
            }
        }

        private void cbxMaGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaGiaoVien.SelectedValue != null)
            {
                var selectedMaGV = cbxMaGiaoVien.SelectedValue.ToString();
                var giaoVien = db.GiaoViens.FirstOrDefault(gv => gv.MaGiaoVien == selectedMaGV);
                if (giaoVien != null)
                {
                    txtTenGV.Text = giaoVien.HoTenGiaoVien;
                }
            }
        }
    }
}
