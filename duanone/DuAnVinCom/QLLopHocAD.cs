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
    public partial class QLLopHocAD : Form
    {
        public QLLopHocAD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemSuaLopHoc sss = new ThemSuaLopHoc();
            sss.Show();
            this.Hide();
        }
    }
}
