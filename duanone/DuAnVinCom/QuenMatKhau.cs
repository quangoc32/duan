using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DuAnVinCom
{
    public partial class QuenMatKhau : Form
    {
        private string generatedOTP;
        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            DangNhap frm2 = new DangNhap();
            frm2.ShowDialog();
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản email.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtOTP.Text))
            {
                MessageBox.Show("Vui lòng nhập mã OTP.");
                return;
            }

            if (txtOTP.Text.Trim() != generatedOTP)
            {
                MessageBox.Show("Mã OTP không chính xác.");
                return;
            }

            try
            {
                using (DuAn1DataContext db = new DuAn1DataContext())
                {
                    string tk = txtEmail.Text;

                    var user = db.ChucVus.FirstOrDefault(u => u.Email == tk);

                    if (user != null)
                    {
                       DoiMatKhau form2 = new DoiMatKhau();
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản email không chính xác. Vui lòng kiểm tra lại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnOTP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản email.");
                return;
            }

            string emailTo = txtEmail.Text;
            generatedOTP = new Random().Next(100000, 999999).ToString();

            try
            {
                // Kiểm tra xem địa chỉ email nhận có hợp lệ không
                var addr = new System.Net.Mail.MailAddress(emailTo);
                if (addr.Address != emailTo)
                {
                    MessageBox.Show("Địa chỉ email không hợp lệ.");
                    return;
                }

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("nguyenduyhao2021hg@gmail.com");
                mail.To.Add(emailTo);
                mail.Subject = "Mã OTP của bạn";
                mail.Body = "Mã OTP của bạn là: " + generatedOTP;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("nguyenduyhao2021hg@gmail.com", "olxp rprj ewbi mzaf");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Mã OTP đã được gửi đến email của bạn.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
            }

        }
    }
}
