using System;
using System.Linq;
using System.Windows.Forms;

namespace DuAnVinCom
{
    public partial class ThemSuaPhongHoc : Form
    {
        private DuAn1DataContext db;

        public ThemSuaPhongHoc()
        {
            InitializeComponent();
            db = new DuAn1DataContext();
            LoadTangLau();
            LoadData();
        }

        private void ThemSuaPhongHoc_Load(object sender, EventArgs e)
        {                
           
        }

        private void LoadTangLau()
        {
           cbxTangLau.Items.AddRange(new object[] { "Tầng 1", "Tầng 2", "Tầng 3", "Tầng 4", "Tầng 5", "Tầng 6" });
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            try
            {
                var newPhongHoc = new PhongHoc
                {
                    MaPhongHoc = GenerateMaPhongHoc(),
                    TenPhongHoc = txtTenPhongHoc.Text,
                    SucChua = 35, // Fixed value
                    TangLau = cbxTangLau.SelectedItem.ToString()
                };

                db.PhongHocs.InsertOnSubmit(newPhongHoc);
                db.SubmitChanges();
                LoadData();

                MessageBox.Show("Thêm phòng học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAnthongtin_Click(object sender, EventArgs e)
        {
           
        }

        private void ResetForm()
        {
            txtSoLuongHocSinh.Clear();
            txtTenPhongHoc.Clear();
           txtTenPhongHoc.Clear();
            cbxTangLau.SelectedIndex = -1;
        }

        private string GenerateMaPhongHoc()
        {
            var phongHocs = db.PhongHocs.ToList();
            var maxMaPhongHoc = phongHocs
                .Select(ph => ph.MaPhongHoc)
                .Where(ma => ma.StartsWith("PH"))
                .Select(ma => int.Parse(ma.Substring(2)))
                .DefaultIfEmpty(0)
                .Max() + 1;

            return "PH" + maxMaPhongHoc.ToString("D3");
        }

        private void LoadData()
        {
            var phongHocs = db.PhongHocs.ToList();
            dgvPhongHoc.DataSource = phongHocs;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhongHoc.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn phòng học để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedMaPhongHoc = dgvPhongHoc.SelectedRows[0].Cells["MaPhongHoc"].Value.ToString();
                var phongHoc = db.PhongHocs.SingleOrDefault(ph => ph.MaPhongHoc == selectedMaPhongHoc);

                if (phongHoc != null)
                {
                    phongHoc.TenPhongHoc = txtTenPhongHoc.Text;
                    phongHoc.SucChua = 35; // Fixed value
                    phongHoc.TangLau = cbxTangLau.SelectedItem.ToString();

                    db.SubmitChanges();
                    LoadData();

                    MessageBox.Show("Sửa phòng học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phòng học để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhongHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPhongHoc.Rows.Count)
            {
                var row = dgvPhongHoc.Rows[e.RowIndex];
                txtTenPhongHoc.Text = row.Cells["TenPhongHoc"].Value.ToString();
                txtSoLuongHocSinh.Text = row.Cells["SucChua"].Value.ToString();
                cbxTangLau.SelectedItem = row.Cells["TangLau"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
