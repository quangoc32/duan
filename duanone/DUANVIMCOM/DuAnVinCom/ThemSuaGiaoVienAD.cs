using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAnVinCom
{
    public partial class ThemSuaGiaoVienAD : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();
        public ThemSuaGiaoVienAD()
        {
            InitializeComponent();
            InitializeComboBox();
            LoadData();
            dgvGiaoVien.SelectionChanged += dgvGiaoVien_SelectionChanged;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private string ConvertImageToBase64(Image image)
        {
            if (image == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private Image ConvertBase64ToImage(string base64String)
        {
            if (string.IsNullOrEmpty(base64String)) return null;
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    string hoTenGiaoVien = CapitalizeWords(txtTenGV.Text.Trim());
                    string email = txtEmail.Text.Trim();
                    string matKhau = GenerateRandomPassword();
                    string cccd = txtCCCD.Text.Trim();

                    if (IsEmailDuplicate(email))
                    {
                        MessageBox.Show("Email đã tồn tại. Vui lòng sử dụng email khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (IsCCCDDuplicate(cccd))
                    {
                        MessageBox.Show("CCCD đã tồn tại. Vui lòng sử dụng CCCD khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    GiaoVien newGiaoVien = new GiaoVien
                    {
                        MaGiaoVien = GenerateMaGV(),
                        HoTenGiaoVien = hoTenGiaoVien,
                        DiaChi = txtDiaChi.Text.Trim(),
                        ChucVu = cbxChucVu.SelectedItem.ToString(),
                        TinhTrang = cbxTinhTrang.SelectedItem.ToString(),
                        GioiTinh = radNam.Checked ? "Nam" : "Nu",
                        NgaySinh = dateTimePicker1.Value,
                        HinhAnh = ConvertImageToBase64(pictureBox1.Image),
                        Email = email,
                        MatKhau = matKhau,
                        CCCD = cccd,
                        IsFirstOne = true,
                        IsFirstHide = false
                    };

                    db.GiaoViens.InsertOnSubmit(newGiaoVien);
                    db.SubmitChanges();

                    LoadData();
                    ClearInputFields();
                    MessageBox.Show("Thêm giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GenerateMaGV()
        {
            var lastGV = db.GiaoViens
       .OrderByDescending(gv => gv.MaGiaoVien)
       .FirstOrDefault();

            int lastNumber = 0;
            if (lastGV != null)
            {
                int.TryParse(lastGV.MaGiaoVien.Substring(2), out lastNumber);
            }

            string newMaGV;
            do
            {
                lastNumber++;
                newMaGV = "GV" + lastNumber.ToString("D4");
            } while (db.GiaoViens.Any(gv => gv.MaGiaoVien == newMaGV));

            return newMaGV;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTenGV.Text) ||
                            string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                            string.IsNullOrWhiteSpace(txtEmail.Text) ||
                            string.IsNullOrWhiteSpace(txtCCCD.Text) ||
                            cbxChucVu.SelectedItem == null ||
                            cbxTinhTrang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!txtEmail.Text.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Email phải có định dạng @gmail.com", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCCCD.Text.Length != 12 || !txtCCCD.Text.All(char.IsDigit))
            {
                MessageBox.Show("CCCD phải đủ 12 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool IsCCCDDuplicate(string cccd)
        {
            return db.GiaoViens.Any(gv => gv.CCCD == cccd);
        }

        private bool IsEmailDuplicate(string email)
        {
            return db.GiaoViens.Any(gv => gv.Email == email);
        }

        private string CapitalizeWords(string input)
        {
            return Regex.Replace(input.ToLower(), @"\b[a-z]", match => match.Value.ToUpper());
        }

        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvGiaoVien.SelectedRows.Count > 0)
            {
                string maGV = dgvGiaoVien.SelectedRows[0].Cells["MaGiaoVien"].Value.ToString();
                GiaoVien selectedGV = db.GiaoViens.SingleOrDefault(gv => gv.MaGiaoVien == maGV);

                if (selectedGV != null && ValidateInputs())
                {
                    string cccd = txtCCCD.Text.Trim();

                    if (IsCCCDDuplicateForEdit(cccd, maGV))
                    {
                        MessageBox.Show("CCCD đã tồn tại. Vui lòng sử dụng CCCD khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    selectedGV.HoTenGiaoVien = CapitalizeWords(txtTenGV.Text.Trim());
                    selectedGV.DiaChi = txtDiaChi.Text.Trim();
                    selectedGV.ChucVu = cbxChucVu.SelectedItem.ToString();
                    selectedGV.TinhTrang = cbxTinhTrang.SelectedItem.ToString();
                    selectedGV.GioiTinh = radNam.Checked ? "Nam" : "Nu";
                    selectedGV.NgaySinh = dateTimePicker1.Value;
                    selectedGV.HinhAnh = ConvertImageToBase64(pictureBox1.Image);
                    selectedGV.Email = txtEmail.Text.Trim();
                    selectedGV.CCCD = cccd;

                    db.SubmitChanges();

                    LoadData();
                    ClearInputFields();
                    MessageBox.Show("Sửa giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một giáo viên để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsCCCDDuplicateForEdit(string cccd, string currentMaGV)
        {
            return db.GiaoViens.Any(gv => gv.CCCD == cccd && gv.MaGiaoVien != currentMaGV);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInputFields();
        }

        private void btnAnTT_Click(object sender, EventArgs e)
        {
            if (dgvGiaoVien.SelectedRows.Count > 0)
            {
                string maGV = dgvGiaoVien.SelectedRows[0].Cells["MaGV"].Value.ToString();
                GiaoVien selectedGV = db.GiaoViens.SingleOrDefault(gv => gv.MaGiaoVien == maGV);

                if (selectedGV != null)
                {
                    selectedGV.IsFirstHide = true;
                    db.SubmitChanges();
                    LoadData();
                    MessageBox.Show("Đã ẩn giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một giáo viên để ẩn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearInputFields()
        {
            txtMaGV.Clear();
            txtTenGV.Clear();
            txtDiaChi.Clear();
            cbxChucVu.SelectedIndex = -1;
            cbxTinhTrang.SelectedIndex = -1;
            radNam.Checked = false;
            radNu.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.Image = null;
            txtEmail.Clear();
            txtMatKhau.Clear();
            txtCCCD.Clear();
            txtTimKiem.Clear();
        }



        private void InitializeComboBox()
        {
            // Thêm các mục vào ComboBox cho Chức vụ
            cbxChucVu.Items.Add("Giáo Viên");
            cbxChucVu.Items.Add("Kế Toán");
            cbxChucVu.Items.Add("Hiệu Trưởng");
            cbxChucVu.Items.Add("Phó Hiệu Trưởng");
            cbxChucVu.Items.Add("Quản Trị Viên");
            // Thêm các vai trò khác nếu cần
            cbxTinhTrang.Items.Add("Đang làm việc");
            cbxTinhTrang.Items.Add("Đã nghĩ việc");
            cbxTinhTrang.Items.Add("Đã nghĩ hưu");

        }

        private void LoadData()
        {
            var teachers = from gv in db.GiaoViens
                           where gv.IsFirstHide == false
                           select new
                           {
                               gv.MaGiaoVien,
                               gv.HoTenGiaoVien,
                               gv.DiaChi,
                               gv.GioiTinh,
                               gv.TinhTrang,
                               gv.ChucVu,
                               gv.NgaySinh,
                               gv.Email,
                               gv.CCCD,
                               HinhAnh = ConvertBase64ToImage(gv.HinhAnh)
                           };

           dgvGiaoVien.DataSource = teachers.ToList();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            var filteredData = from gv in db.GiaoViens
                               where (gv.MaGiaoVien.Contains(searchText) || gv.MaGiaoVien.Contains(searchText)) && (gv.IsFirstHide == true)
                               select new
                               {
                                   gv.MaGiaoVien,
                                   gv.HoTenGiaoVien,
                                   gv.DiaChi,
                                   gv.GioiTinh,
                                   gv.ChucVu,
                                   gv.TinhTrang,
                                   gv.NgaySinh,
                                   gv.Email,
                                   gv.CCCD,
                                   HinhAnh = ConvertBase64ToImage(gv.HinhAnh)
                               };

            dgvGiaoVien.DataSource = filteredData.ToList();

        }

        private void dgvGiaoVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGiaoVien.SelectedRows.Count > 0)
            {
                var selectedRow = dgvGiaoVien.SelectedRows[0];

                txtMaGV.Text = selectedRow.Cells["MaGiaoVien"].Value.ToString();
                txtTenGV.Text = selectedRow.Cells["HoTenGiaoVien"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtCCCD.Text = selectedRow.Cells["CCCD"].Value.ToString();

                string gioiTinh = selectedRow.Cells["GioiTinh"].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }

                cbxChucVu.SelectedItem = selectedRow.Cells["ChucVu"].Value.ToString();
                cbxTinhTrang.SelectedItem = selectedRow.Cells["TinhTrang"].Value.ToString();
                dateTimePicker1.Value = (DateTime)selectedRow.Cells["NgaySinh"].Value;
                pictureBox1.Image = (Image)selectedRow.Cells["HinhAnh"].Value;

                // Note: MatKhau is typically not displayed back in a UI for security reasons, so it's omitted here.
            }
        }
    }
}
