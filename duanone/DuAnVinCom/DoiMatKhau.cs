using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DuAnVinCom
{
    public partial class DoiMatKhau : Form
    {
        private ChucVu user;
        MD5 md = MD5.Create();
        public DoiMatKhau(ChucVu user)
        {
            InitializeComponent();
            this.user = user;
        }
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
            string.IsNullOrWhiteSpace(txtPassword.Text) ||
            string.IsNullOrWhiteSpace(txtRePassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ email, mật khẩu mới và xác nhận mật khẩu.");
                return;
            }

            if (txtPassword.Text.Length < 10)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 10 ký tự.");
                return;
            }

            if (txtPassword.Text != txtRePassword.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.");
                return;
            }

            try
            {
                using (DuAn1DataContext db = new DuAn1DataContext())
                {
                    string email = txtEmail.Text;
                    string matKhauMoi = txtPassword.Text;

                    var user = db.ChucVus.FirstOrDefault(nv => nv.Email == email);

                    if (user == null)
                    {
                        MessageBox.Show("Người dùng không tồn tại.");
                        return;
                    }

                    user.MatKhau = HashPassword(matKhauMoi);  // Consider hashing the password
                    user.IsFirstOne = false;

                    db.SubmitChanges();

                    MessageBox.Show("Đổi mật khẩu thành công.");
                    DangNhap formDangNhap = new DangNhap();
                    formDangNhap.Show();
                    this.Hide(); // Close the current form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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
