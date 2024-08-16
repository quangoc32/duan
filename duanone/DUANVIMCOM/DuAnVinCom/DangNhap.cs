using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAnVinCom
{
    public partial class DangNhap : Form
    {
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
                    string tk = txtEmail.Text;
                    string mk = HashPassword(txtPassword.Text); // Mã hóa mật khẩu người dùng nhập vào

                    var user = db.GiaoViens.FirstOrDefault(u => u.Email == tk && u.MatKhau == mk);

                    if (user == null)
                    {
                        MessageBox.Show("Không tìm thấy người dùng với thông tin đã nhập.");
                        return;
                    }

                    if (user.IsFirstOne ?? false)
                    {
                        DoiMatKhau formDoiMatKhau = new DoiMatKhau(user);
                        formDoiMatKhau.Show();
                    }
                    else
                    {
                        Form formToShow;
                        switch (user.ChucVu)
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
                                MessageBox.Show($"Vai trò không hợp lệ: {user.ChucVu}");
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
