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
    public partial class ThaoTacGiaoVienChuNhiem : Form
    {
        public ThaoTacGiaoVienChuNhiem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PhieuDiemHocSinh ss = new PhieuDiemHocSinh();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BangDiemGiaoVienChuNhiem sss = new BangDiemGiaoVienChuNhiem();
            sss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
