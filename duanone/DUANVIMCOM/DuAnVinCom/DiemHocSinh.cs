﻿using System;
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
    public partial class DiemHocSinh : Form
    {
        public DiemHocSinh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XacNhanGiaoVien sss = new XacNhanGiaoVien();
            sss.Show();
        }
    }
}