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
    public partial class FornHK : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();
        public FornHK()
        {
            InitializeComponent();
            LoadData();
            txtMaHK.Enabled = false;

        }

        private void FornHK_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            var hocKys = db.HocKies.ToList();
            dgvHocKy.DataSource = hocKys;
        }
        private string GenerateMaHK()
        {
            var lastHK = db.HocKies
                .OrderByDescending(hk => hk.MaHK)
                .FirstOrDefault();

            int lastNumber = 0;
            if (lastHK != null)
            {
                int.TryParse(lastHK.MaHK.Substring(2), out lastNumber);
            }

            string newMaHK;
            do
            {
                lastNumber++;
                newMaHK = "HK" + lastNumber.ToString("D4"); // Ví dụ: HK0001, HK0002,...
            } while (db.HocKies.Any(hk => hk.MaHK == newMaHK));

            return newMaHK;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenHK.Text))
            {
                string newMaHK = GenerateMaHK();
                HocKy newHK = new HocKy
                {
                    MaHK = newMaHK,
                    TenHK = txtTenHK.Text
                };

                db.HocKies.InsertOnSubmit(newHK);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Thêm mới thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên học kỳ.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (dgvHocKy.SelectedRows.Count > 0 && !string.IsNullOrEmpty(txtTenHK.Text))
            {
                string maHK = txtMaHK.Text;
                HocKy hk = db.HocKies.FirstOrDefault(h => h.MaHK == maHK);

                if (hk != null)
                {
                    hk.TenHK = txtTenHK.Text;
                    db.SubmitChanges();
                    LoadData();
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn học kỳ và nhập tên học kỳ.");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
           txtMaHK.Clear();
            txtTenHK.Clear();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHocKy.SelectedRows.Count > 0)
            {
                string maHK = txtMaHK.Text;
                HocKy hk = db.HocKies.FirstOrDefault(h => h.MaHK == maHK);

                if (hk != null)
                {
                    db.HocKies.DeleteOnSubmit(hk);
                    db.SubmitChanges();
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn học kỳ để xóa.");
            }
        }

        private void dgvHocKy_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHocKy.SelectedRows.Count > 0)
            {
                txtMaHK.Text = dgvHocKy.SelectedRows[0].Cells["MaHK"].Value.ToString();
                txtTenHK.Text = dgvHocKy.SelectedRows[0].Cells["TenHK"].Value.ToString();
            }
        }
    }
}
