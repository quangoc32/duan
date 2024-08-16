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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private Form currentFormChild;

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLHocSinhAD());
            label3.Text = button1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TrangChuAD());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLGiaoVienAD());
            label3.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLPhongHocAD());
            label3.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLLopHocAD());
            label3.Text = button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLTietHocAD());
            label3.Text = button4.Text;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLKhoi());
            label3.Text = button8.Text;
        }
    }
}
