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
    public partial class XacNhanGiaoVien : Form
    {
        public XacNhanGiaoVien()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThaoTacGiaoVienChuNhiem frm2 = new ThaoTacGiaoVienChuNhiem();
            frm2.ShowDialog();
            this.Close();
        }
    }
}
