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
    public partial class FormQLNamVaKi : Form
    {
        public FormQLNamVaKi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNam ss = new FormNam();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FornHK sss = new FornHK();
            sss.Show();
        }
    }
}
