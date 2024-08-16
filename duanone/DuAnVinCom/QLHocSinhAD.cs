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
    public partial class QLHocSinhAD : Form
    {
        public QLHocSinhAD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemSuaHocSinhAD SSS = new ThemSuaHocSinhAD();
            SSS.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormThongKeHocSinh sss = new FormThongKeHocSinh();
            sss.Show();
        }
    }
}
