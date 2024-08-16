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
    public partial class QLPhongHocAD : Form
    {
        public QLPhongHocAD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemSuaPhongHoc sss = new ThemSuaPhongHoc();
            sss.Show();
        }
    }
}
