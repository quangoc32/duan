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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DuAnVinCom
{
    
    public partial class ThemSuaHocSinhAD : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();
        public ThemSuaHocSinhAD()
        {
            InitializeComponent();
            InitializeComboBox();          
            LoadData();
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
                    string hoTenHocSinh = CapitalizeWords(txtTenHS.Text.Trim());
                    string diaChi = CapitalizeWords(txtDiaChi.Text.Trim());
                    string hoTenCha = CapitalizeWords(txtChaHS.Text.Trim());
                    string hoTenMe = CapitalizeWords(txtMeHS.Text.Trim());

                    HocSinh newHocSinh = new HocSinh
                    {
                        MaHocSinh = GenerateMaHS(),
                        HoTen = hoTenHocSinh,
                        DiaChi = diaChi,
                        TinhTrang = cbxTinhTrang.SelectedItem.ToString(),
                        GioiTinh = radNam.Checked ? "Nam" : "Nu",
                        NgaySinh = dateTimePicker1.Value,
                        HinhAnh = ConvertImageToBase64(pictureBox1.Image),
                        SDT_HS = txtSDTHS.Text.Trim(),
                        SDT_PHHS = txtPHHS.Text.Trim(),
                        ChaHS = hoTenCha,
                        MeHS = hoTenMe,
                        IsHidden = false,
                    };

                    db.HocSinhs.InsertOnSubmit(newHocSinh);
                    db.SubmitChanges();

                    LoadData();
                    ClearInputFields();
                    MessageBox.Show("Thêm học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string CapitalizeWords(string input)
        {
            return Regex.Replace(input.ToLower(), @"\b[a-z]", match => match.Value.ToUpper());
        }

        private bool ValidateInputs()
        {
            // Kiểm tra các ô nhập liệu không được để trống
            if (string.IsNullOrWhiteSpace(txtTenHS.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtChaHS.Text) ||
                string.IsNullOrWhiteSpace(txtMeHS.Text) ||
                string.IsNullOrWhiteSpace(txtSDTHS.Text) ||
                string.IsNullOrWhiteSpace(txtPHHS.Text) ||
                cbxTinhTrang.SelectedItem == null ||
                pictureBox1.Image == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và chọn hình ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra số điện thoại phải từ 10 đến 11 số
            if (txtSDTHS.Text.Length < 10 || txtSDTHS.Text.Length > 11 ||
                txtPHHS.Text.Length < 10 || txtPHHS.Text.Length > 11)
            {
                MessageBox.Show("Số điện thoại phải từ 10 đến 11 số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra trùng lặp số điện thoại học sinh, bỏ qua nếu đang chỉnh sửa
            var duplicateSDTHS = db.HocSinhs.Any(hs => hs.SDT_HS == txtSDTHS.Text.Trim() && hs.MaHocSinh != txtMaHS.Text.Trim());
            if (duplicateSDTHS)
            {
                MessageBox.Show("Số điện thoại học sinh đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra trùng lặp số điện thoại phụ huynh học sinh, bỏ qua nếu đang chỉnh sửa
            var duplicateSDTPHHS = db.HocSinhs.Any(hs => hs.SDT_PHHS == txtPHHS.Text.Trim() && hs.MaHocSinh != txtMaHS.Text.Trim());
            if (duplicateSDTPHHS)
            {
                MessageBox.Show("Số điện thoại phụ huynh học sinh đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra số điện thoại học sinh không được trùng với số điện thoại cha hoặc mẹ
            if (txtSDTHS.Text == txtChaHS.Text || txtSDTHS.Text == txtMeHS.Text)
            {
                MessageBox.Show("Số điện thoại học sinh không được trùng với số điện thoại cha hoặc mẹ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private string GenerateMaHS()
        {
            var lastGV = db.HocSinhs
                .OrderByDescending(gv => gv.MaHocSinh)
                .FirstOrDefault();

            if (lastGV == null)
            {
                return "HS0001";
            }

            int lastNumber = int.Parse(lastGV.MaHocSinh.Substring(2));
            return "HS" + (lastNumber + 1).ToString("D4");
        }

        private void ClearInputFields()
        {
            txtMaHS.Clear();
            txtTenHS.Clear();
            txtDiaChi.Clear();         
            cbxTinhTrang.SelectedIndex = -1;
            radNam.Checked = false;
            radNu.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.Image = null;
            txtSDTHS.Clear();
            txtPHHS.Clear();
            txtChaHS.Clear();
            txtMeHS.Clear();
        }

        private void InitializeComboBox()
        {
            cbxTinhTrang.Items.Add("Đang học");
            cbxTinhTrang.Items.Add("Đã nghĩ học");
            cbxTinhTrang.Items.Add("Đã tốt nghiệp");
        }

        private void LoadData()
        {
            try
            {
                var students = from hs in db.HocSinhs
                               where hs.IsHidden == false

                               select new
                               {
                                   hs.MaHocSinh,
                                   hs.HoTen,
                                   hs.DiaChi,
                                   hs.GioiTinh,                                
                                   hs.TinhTrang,
                                   hs.NgaySinh,
                                   hs.SDT_HS,
                                   hs.SDT_PHHS,
                                   hs.ChaHS,
                                   hs.MeHS,

                                   
                               };
               dgvHocSinh.DataSource = students.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (dgvHocSinh.SelectedRows.Count > 0)
                {
                    try
                    {
                        string maHS = dgvHocSinh.SelectedRows[0].Cells["MaHocSinh"].Value.ToString(); // Đảm bảo tên cột chính xác
                        HocSinh selectedHS = db.HocSinhs.SingleOrDefault(hs => hs.MaHocSinh == maHS);

                        if (selectedHS != null)
                        {
                            selectedHS.HoTen = CapitalizeWords(txtTenHS.Text.Trim());
                            selectedHS.DiaChi = CapitalizeWords(txtDiaChi.Text.Trim());
                            selectedHS.TinhTrang = cbxTinhTrang.SelectedItem.ToString();
                            selectedHS.GioiTinh = radNam.Checked ? "Nam" : "Nu";
                            selectedHS.NgaySinh = dateTimePicker1.Value;
                            selectedHS.HinhAnh = ConvertImageToBase64(pictureBox1.Image);
                            selectedHS.SDT_HS = txtSDTHS.Text.Trim();
                            selectedHS.SDT_PHHS = txtPHHS.Text.Trim();
                            selectedHS.ChaHS = CapitalizeWords(txtChaHS.Text.Trim());
                            selectedHS.MeHS = CapitalizeWords(txtMeHS.Text.Trim());

                            db.SubmitChanges();
                            LoadData();
                            ClearInputFields();
                            MessageBox.Show("Sửa học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy học sinh để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi sửa học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một học sinh để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Refresh dữ liệu
            LoadData();
            ClearInputFields();
          dgvHocSinh.SelectionChanged += dgvHocSinh_SelectionChanged;
        }

        private void btnAnTT_Click(object sender, EventArgs e)
        {
            if (dgvHocSinh.SelectedRows.Count > 0)
            {
                try
                {
                    // Lấy mã học sinh từ dòng được chọn
                    string maHS = dgvHocSinh.SelectedRows[0].Cells["MaHocSinh"].Value.ToString(); // Đảm bảo tên cột chính xác
                    HocSinh selectedHS = db.HocSinhs.SingleOrDefault(hs => hs.MaHocSinh == maHS);

                    if (selectedHS != null)
                    {
                        // Đánh dấu học sinh là đã ẩn
                        selectedHS.IsHidden = true;
                        db.SubmitChanges();

                        // Tải lại dữ liệu và làm mới giao diện
                        LoadData();
                        MessageBox.Show("Đã ẩn học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy học sinh để ẩn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi ẩn học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học sinh để ẩn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim(); // Lấy giá trị tìm kiếm từ textbox
            if (string.IsNullOrEmpty(searchText)) // Kiểm tra nếu ô tìm kiếm trống
            {
                MessageBox.Show("Vui lòng nhập mã học sinh để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filteredData = from hs in db.HocSinhs
                               where hs.MaHocSinh.Contains(searchText) && hs.IsHidden == true
                               select new
                               {
                                   hs.MaHocSinh,
                                   hs.HoTen,
                                   hs.DiaChi,
                                   hs.GioiTinh,
                                   hs.TinhTrang,
                                   hs.NgaySinh,
                                   hs.SDT_HS,
                                   hs.SDT_PHHS,
                                   hs.ChaHS,
                                   hs.MeHS,
                                   HinhAnh = ConvertBase64ToImage(hs.HinhAnh)
                               };

            var result = filteredData.ToList(); // Lấy danh sách kết quả tìm kiếm

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy học sinh với mã đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvHocSinh.DataSource = result; // Hiển thị kết quả tìm kiếm trên DataGridView
        }

        private void dgvHocSinh_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHocSinh.CurrentRow != null)
            {
                try
                {
                    string maHS = dgvHocSinh.CurrentRow.Cells["MaHocSinh"].Value.ToString(); // Đảm bảo tên cột chính xác
                    HocSinh hs = db.HocSinhs.SingleOrDefault(s => s.MaHocSinh == maHS);
                    if (hs != null)
                    {
                        txtMaHS.Text = hs.MaHocSinh ?? string.Empty;
                        txtTenHS.Text = hs.HoTen ?? string.Empty;
                        txtDiaChi.Text = hs.DiaChi ?? string.Empty;
                        cbxTinhTrang.SelectedItem = hs.TinhTrang ?? string.Empty;
                        radNam.Checked = hs.GioiTinh == "Nam";
                        radNu.Checked = hs.GioiTinh == "Nu";
                        dateTimePicker1.Value = hs.NgaySinh ?? DateTime.Now;
                        pictureBox1.Image = ConvertBase64ToImage(hs.HinhAnh);
                        txtSDTHS.Text = hs.SDT_HS ?? string.Empty;
                        txtPHHS.Text = hs.SDT_PHHS ?? string.Empty;
                        txtMeHS.Text = hs.MeHS ?? string.Empty;
                        txtChaHS.Text = hs.ChaHS ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi chọn học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
