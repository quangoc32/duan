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
    public partial class ThemSuaLopHoc : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();
        public ThemSuaLopHoc()
        {
            InitializeComponent();
            LoadData();

            dgvLop.SelectionChanged += dgvLop_SelectionChanged;
        }

        private void LoadData()
        {
            // Load teachers into MaGiaoVien combobox
            var teachers = db.GiaoViens.Select(gv => new
            {
                gv.MaGiaoVien,
                gv.HoTenGiaoVien
            }).ToList();
            cbxMaGiaoVien.DataSource = teachers;
            cbxMaGiaoVien.DisplayMember = "MaGiaoVien";
            cbxMaGiaoVien.ValueMember = "MaGiaoVien";

            // Load students into MaHocSinh combobox
            var students = db.HocSinhs.Select(hs => new
            {
                hs.MaHocSinh,
                hs.HoTen
            }).ToList();
            cbxMaHS.DataSource = students;
            cbxMaHS.DisplayMember = "MaHocSinh";
            cbxMaHS.ValueMember = "MaHocSinh";

            // Load GhiChu options
            cbxGhiChu.Items.Add("Đang hoạt động");
            cbxGhiChu.Items.Add("Ngừng hoạt động");
          

            // Load GhiChu options
            cbxLop.Items.Add("10A1");
            cbxLop.Items.Add("10A2");
            cbxLop.Items.Add("10A3");
            cbxLop.Items.Add("10A4");
            cbxLop.Items.Add("10B1");
            cbxLop.Items.Add("10B2");
            cbxLop.Items.Add("10B3");
            cbxLop.Items.Add("10B4");
            cbxLop.Items.Add("11A1");
            cbxLop.Items.Add("11A2");
            cbxLop.Items.Add("11A3");
            cbxLop.Items.Add("11A4");
            cbxLop.Items.Add("11B1");
            cbxLop.Items.Add("11B2");
            cbxLop.Items.Add("11B3");
            cbxLop.Items.Add("11B4");
            cbxLop.Items.Add("12A1");
            cbxLop.Items.Add("12A2");
            cbxLop.Items.Add("12A3");
            cbxLop.Items.Add("12A4");
            cbxLop.Items.Add("12B1");
            cbxLop.Items.Add("12B2");
            cbxLop.Items.Add("12B3");
            cbxLop.Items.Add("12B4");

            var classes = db.LopHocs.Select(lh => new
            {
                lh.MaLop,
                lh.TenLop,
                lh.MaGiaoVien,
                lh.GhiChu
            }).ToList();
            dgvLop.DataSource = classes;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if ( cbxLop.SelectedItem == null ||
                   cbxMaGiaoVien.SelectedItem == null ||
                   cbxMaHS.SelectedItem == null)
                {
                    MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a new LopHoc object
                LopHoc newClass = new LopHoc
                {
                    MaLop = GenerateMaLop(),
                    MaGiaoVien = cbxMaGiaoVien.SelectedValue.ToString(),
                    TenLop = cbxLop.SelectedItem.ToString(),
                    GhiChu = cbxGhiChu.SelectedItem.ToString()
                };

                // Insert the new class into the database
                db.LopHocs.InsertOnSubmit(newClass);
                db.SubmitChanges();

                LoadData();
             

                MessageBox.Show("Class added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateMaLop()
        {
            var lastLop = db.LopHocs
                .OrderByDescending(gv => gv.MaLop)
                .FirstOrDefault();

            if (lastLop == null)
            {
                return "VC0001";
            }

            int lastNumber = int.Parse(lastLop.MaLop.Substring(2));
            return "VC" + (lastNumber + 1).ToString("D4");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtMaLop.Text) ||
                   cbxLop.SelectedItem == null ||
                   cbxMaGiaoVien.SelectedItem == null ||
                   cbxGhiChu.SelectedItem == null)
                {
                    MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Find the class to update
                var classToUpdate = db.LopHocs.SingleOrDefault(lh => lh.MaLop == txtMaLop.Text);

                if (classToUpdate != null)
                {
                    // Update class information
                    classToUpdate.MaGiaoVien = cbxMaGiaoVien.SelectedValue.ToString();
                    classToUpdate.TenLop = cbxLop.SelectedItem.ToString();
                    classToUpdate.GhiChu = cbxGhiChu.SelectedItem.ToString();

                    // Submit changes to database
                    db.SubmitChanges();

                    // Refresh DataGridView
                    LoadData();
              

                    MessageBox.Show("Class updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Class not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void cbxMaGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMaGiaoVien = cbxMaGiaoVien.SelectedValue.ToString();
            var teacher = db.GiaoViens.SingleOrDefault(gv => gv.MaGiaoVien == selectedMaGiaoVien);

            if (teacher != null)
            {
               txtTenGV.Text = teacher.HoTenGiaoVien;
            }
         

        }

        private void cbxMaHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMaHocSinh = cbxMaHS.SelectedValue.ToString();
            var student = db.HocSinhs.SingleOrDefault(hs => hs.MaHocSinh == selectedMaHocSinh);

            if (student != null)
            {
               txtTenHS.Text = student.HoTen;
            }
           
        }

        private void dgvLop_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLop.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvLop.SelectedRows[0];

                // Update controls with selected row data
                txtMaLop.Text = selectedRow.Cells["MaLop"].Value.ToString();
                cbxLop.SelectedItem = selectedRow.Cells["TenLop"].Value.ToString();
                cbxMaGiaoVien.SelectedValue = selectedRow.Cells["MaGiaoVien"].Value.ToString();
                cbxGhiChu.SelectedItem = selectedRow.Cells["GhiChu"].Value.ToString();
            }
          
        }

       
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Clear textboxes and comboboxes
            if (txtMaLop != null) txtMaLop.Clear();
            if (txtTenGV != null) txtTenGV.Clear();
            if (txtTenHS != null) txtTenHS.Clear();
            if (cbxGhiChu != null) cbxGhiChu.SelectedIndex = -1;
            if (cbxLop != null) cbxLop.SelectedIndex = -1;
            if (cbxMaGiaoVien != null) cbxMaGiaoVien.SelectedIndex = -1;
            if (cbxMaHS != null) cbxMaHS.SelectedIndex = -1;

        }

     

        
    }
}
