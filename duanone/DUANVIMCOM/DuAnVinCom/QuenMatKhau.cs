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
    public partial class QuenMatKhau : Form
    {
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
            this.Hide();
            DoiMatKhau frm2 = new DoiMatKhau();
            frm2.ShowDialog();
            this.Close();
        }
    }
}
