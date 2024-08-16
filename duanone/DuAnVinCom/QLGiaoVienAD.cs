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
    public partial class QLGiaoVienAD : Form
    {
        public QLGiaoVienAD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemSuaGiaoVienAD sss = new ThemSuaGiaoVienAD();
            sss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPhanCongMonHoc ss = new FormPhanCongMonHoc();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormThongKeGiaoVien sss = new FormThongKeGiaoVien();
            sss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormChucVuGV sss = new FormChucVuGV();  
            sss.Show();
        }
    }
}
