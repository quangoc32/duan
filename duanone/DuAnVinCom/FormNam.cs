using System;
using System.Linq;
using System.Windows.Forms;

namespace DuAnVinCom
{
    public partial class FormNam : Form
    {
        DuAn1DataContext db = new DuAn1DataContext();

        public FormNam()
        {
            InitializeComponent();
            LoadData();
            txtMaNH.Enabled = false; // Disable the MaNH textbox because it's auto-generated
        }

        private void FormNam_Load(object sender, EventArgs e)
        {
            // Optional: Code to handle when the form loads, if needed
        }

        private void LoadData()
        {
            var namHocs = db.NamHocs.ToList(); // Retrieve data from the NamHoc table
            dgvNam.DataSource = namHocs; // Bind the data to the DataGridView
        }

        private string GenerateMaNH()
        {
            var lastNamHoc = db.NamHocs
                .OrderByDescending(nh => nh.MaNH)
                .FirstOrDefault();

            int lastNumber = 0;
            if (lastNamHoc != null)
            {
                int.TryParse(lastNamHoc.MaNH.Substring(2), out lastNumber);
            }

            string newMaNH;
            do
            {
                lastNumber++;
                newMaNH = "NH" + lastNumber.ToString("D4"); // Ví dụ: NH0001, NH0002,...
            } while (db.NamHocs.Any(nh => nh.MaNH == newMaNH));

            return newMaNH;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenNH.Text))
            {
                string newMaNH = GenerateMaNH();
                NamHoc newNamHoc = new NamHoc
                {
                    MaNH = newMaNH,
                    NamHoc1 = txtTenNH.Text // Ensure this field name matches your database schema
                };

                db.NamHocs.InsertOnSubmit(newNamHoc);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Thêm mới thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên năm học.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNam.SelectedRows.Count > 0 && !string.IsNullOrEmpty(txtTenNH.Text))
            {
                string maNH = txtMaNH.Text;
                NamHoc namHoc = db.NamHocs.FirstOrDefault(nh => nh.MaNH == maNH);

                if (namHoc != null)
                {
                    namHoc.NamHoc1 = txtTenNH.Text; // Ensure this field name matches your database schema
                    db.SubmitChanges();
                    LoadData();
                  
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Mã năm học không tồn tại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn năm học và nhập tên năm học.");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadData();
        }

        private void ClearInputFields()
        {
            txtMaNH.Clear();
            txtTenNH.Clear();
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNam.SelectedRows.Count > 0)
            {
                string maNH = txtMaNH.Text;
                NamHoc namHoc = db.NamHocs.FirstOrDefault(nh => nh.MaNH == maNH);

                if (namHoc != null)
                {
                    db.NamHocs.DeleteOnSubmit(namHoc);
                    db.SubmitChanges();
                    LoadData();
                    ClearInputFields();
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Mã năm học không tồn tại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn năm học để xóa.");
            }
        }

        private void dgvNam_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNam.SelectedRows.Count > 0)
            {
                txtMaNH.Text = dgvNam.SelectedRows[0].Cells["MaNH"].Value.ToString();
                txtTenNH.Text = dgvNam.SelectedRows[0].Cells["NamHoc1"].Value.ToString(); // Ensure this column name matches your DataGridView column
            }
        }
    }
}
