using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DuAnVinCom
{
    public partial class DangNhap : Form
    {
        private const string DefaultPasswordHash = "D41D8CD98F00B204E9800998ECF8427E"; // MD5 hash của mật khẩu rỗng

        public DangNhap()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            QuenMatKhau frm2 = new QuenMatKhau();
            frm2.ShowDialog();
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu.");
                return;
            }

            try
            {
                using (DuAn1DataContext db = new DuAn1DataContext())
                {
                    string email = txtEmail.Text;
                    string hashedPassword = HashPassword(txtPassword.Text); // Mã hóa mật khẩu người dùng nhập vào

                    var user = db.ChucVus.FirstOrDefault(u => u.Email == email && u.MatKhau == hashedPassword);

                    if (user == null)
                    {
                        MessageBox.Show("Không tìm thấy người dùng với thông tin đã nhập.");
                        return;
                    }

                    if (hashedPassword == DefaultPasswordHash) // Kiểm tra nếu mật khẩu là mặc định
                    {
                        DoiMatKhau formDoiMatKhau = new DoiMatKhau(user);
                        formDoiMatKhau.Show();
                        this.Hide(); // Ẩn form đăng nhập
                    }
                    else
                    {
                        Form formToShow;
                        switch (user.TenChucVu) // Sử dụng TenChucVu để xác định form
                        {
                            case "Giáo Viên":
                                formToShow = new FormGiaoVien();
                                break;
                            case "Quản Trị Viên":
                                formToShow = new FormAdmin();
                                break;
                            case "Kế Toán":
                                formToShow = new FormKeToan();
                                break;
                            default:
                                MessageBox.Show($"Vai trò không hợp lệ: {user.TenChucVu}");
                                return;
                        }

                        if (formToShow != null)
                        {
                            formToShow.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Không thể khởi tạo form.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
