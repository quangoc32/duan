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
    public partial class FormKhoi : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();
        public FormKhoi()
        {
            InitializeComponent();         
            LoadData();
           txtMaKhoi.Enabled = false;
        }

        private void LoadData()
        {
            var khoiLops = db.KhoiLops.ToList();
            dgvKhoiLop.DataSource = khoiLops;
        }

        private string GenerateMaKhoi()
        {
            var lastKhoi = db.KhoiLops
                .OrderByDescending(k => k.MaKhoi)
                .FirstOrDefault();

            int lastNumber = 0;
            if (lastKhoi != null)
            {
                int.TryParse(lastKhoi.MaKhoi.Substring(2), out lastNumber);
            }

            string newMaKhoi;
            do
            {
                lastNumber++;
                newMaKhoi = "KL" + lastNumber.ToString("D4"); // Ví dụ: KL0001, KL0002,...
            } while (db.KhoiLops.Any(k => k.MaKhoi == newMaKhoi));

            return newMaKhoi;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenKhoi.Text))
            {
                string newMaKhoi = GenerateMaKhoi();
                KhoiLop newKhoi = new KhoiLop
                {
                    MaKhoi = newMaKhoi,
                    TenKhoi = txtTenKhoi.Text
                };

                db.KhoiLops.InsertOnSubmit(newKhoi);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Thêm mới thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên khối.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhoiLop.SelectedRows.Count > 0 && !string.IsNullOrEmpty(txtTenKhoi.Text))
            {
                string maKhoi = txtMaKhoi.Text;
                KhoiLop khoi = db.KhoiLops.FirstOrDefault(k => k.MaKhoi == maKhoi);

                if (khoi != null)
                {
                    khoi.TenKhoi = txtTenKhoi.Text;
                    db.SubmitChanges();
                    LoadData();
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khối và nhập tên khối.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaKhoi.Clear();
            txtTenKhoi.Clear();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhoiLop.SelectedRows.Count > 0)
            {
                string maKhoi = txtMaKhoi.Text;
                KhoiLop khoi = db.KhoiLops.FirstOrDefault(k => k.MaKhoi == maKhoi);

                if (khoi != null)
                {
                    db.KhoiLops.DeleteOnSubmit(khoi);
                    db.SubmitChanges();
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khối để xóa.");
            }
        }

        private void dgvKhoiLop_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoiLop.SelectedRows.Count > 0)
            {
                txtMaKhoi.Text = dgvKhoiLop.SelectedRows[0].Cells["MaKhoi"].Value.ToString();
                txtTenKhoi.Text = dgvKhoiLop.SelectedRows[0].Cells["TenKhoi"].Value.ToString();
            }
        }

        private void FormKhoi_Load(object sender, EventArgs e)
        {

        }

        private void txtMaKhoi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
