
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CafePOSSystem
{
    public partial class FormQuanLyThucDon : Form
    {
        private int maMonDangChon = -1;

        public FormQuanLyThucDon()
        {
            InitializeComponent();

            Load += (s, e) => NapDuLieu();
            btnThem.Click += (s, e) => ThemMon();
            btnSua.Click += (s, e) => SuaMon();
            btnXoa.Click += (s, e) => XoaMon();
            btnLamMoi.Click += (s, e) => LamMoi();
            btnThemDanhMuc.Click += (s, e) => ThemDanhMuc();
            dgvMon.CellClick += (s, e) => ChonMon();
        }

        private void NapDuLieu()
        {
            NapDanhMuc();
            NapMon();
        }

        private void NapDanhMuc()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(
                    "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc",
                    conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboDanhMuc.DataSource = null;
                    cboDanhMuc.DisplayMember = "TenDanhMuc";
                    cboDanhMuc.ValueMember = "MaDanhMuc";
                    cboDanhMuc.DataSource = dt;
                }
            }
        }

        private void NapMon()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        m.MaMon,
                        m.TenMon AS 'Tên món',
                        m.MaDanhMuc,
                        d.TenDanhMuc AS 'Danh mục',
                        m.DonGia AS 'Đơn giá'
                    FROM MonAn m
                    INNER JOIN DanhMuc d ON m.MaDanhMuc = d.MaDanhMuc
                    ORDER BY m.MaMon";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvMon.DataSource = dt;
                }
            }

            if (dgvMon.Columns.Contains("MaMon"))
                dgvMon.Columns["MaMon"].Visible = false;

            if (dgvMon.Columns.Contains("MaDanhMuc"))
                dgvMon.Columns["MaDanhMuc"].Visible = false;

            if (dgvMon.Columns.Contains("Đơn giá"))
                dgvMon.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món.");
                txtTenMon.Focus();
                return false;
            }

            if (cboDanhMuc.SelectedValue == null ||
                cboDanhMuc.SelectedValue is DataRowView)
            {
                MessageBox.Show("Vui lòng chọn danh mục.");
                return false;
            }

            if (numDonGia.Value < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                return false;
            }

            return true;
        }

        private void ThemMon()
        {
            if (!KiemTraDuLieu())
                return;

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(
                        @"INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia)
                          VALUES (@tenmon, @madm, @dongia)", conn))
                    {
                        cmd.Parameters.AddWithValue("@tenmon", txtTenMon.Text.Trim());
                        cmd.Parameters.AddWithValue("@madm",
                            Convert.ToInt32(cboDanhMuc.SelectedValue));
                        cmd.Parameters.AddWithValue("@dongia", numDonGia.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm món thành công!");
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm món.\n" + ex.Message);
            }
        }

        private void SuaMon()
        {
            if (maMonDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn món cần sửa trong bảng.");
                return;
            }

            if (!KiemTraDuLieu())
                return;

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(
                        @"UPDATE MonAn
                          SET TenMon = @tenmon,
                              MaDanhMuc = @madm,
                              DonGia = @dongia
                          WHERE MaMon = @mamon", conn))
                    {
                        cmd.Parameters.AddWithValue("@tenmon", txtTenMon.Text.Trim());
                        cmd.Parameters.AddWithValue("@madm",
                            Convert.ToInt32(cboDanhMuc.SelectedValue));
                        cmd.Parameters.AddWithValue("@dongia", numDonGia.Value);
                        cmd.Parameters.AddWithValue("@mamon", maMonDangChon);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật món thành công!");
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể sửa món.\n" + ex.Message);
            }
        }

        private void XoaMon()
        {
            if (maMonDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa trong bảng.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa món này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM MonAn WHERE MaMon = @mamon", conn))
                    {
                        cmd.Parameters.AddWithValue("@mamon", maMonDangChon);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Xóa món thành công!");
                LamMoi();
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show(
                    "Không thể xóa món vì món này đã được sử dụng trong hóa đơn.\n" +
                    "Hãy giữ lại món để bảo toàn lịch sử bán hàng.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa món.\n" + ex.Message);
            }
        }

        private void ChonMon()
        {
            if (dgvMon.CurrentRow == null ||
                dgvMon.CurrentRow.IsNewRow)
                return;

            DataGridViewRow row = dgvMon.CurrentRow;

            if (row.Cells["MaMon"].Value == null)
                return;

            maMonDangChon = Convert.ToInt32(row.Cells["MaMon"].Value);
            txtTenMon.Text = Convert.ToString(row.Cells["Tên món"].Value) ?? "";

            if (row.Cells["MaDanhMuc"].Value != null)
                cboDanhMuc.SelectedValue =
                    Convert.ToInt32(row.Cells["MaDanhMuc"].Value);

            if (row.Cells["Đơn giá"].Value != null)
                numDonGia.Value = Math.Min(
                    numDonGia.Maximum,
                    Math.Max(numDonGia.Minimum,
                        Convert.ToDecimal(row.Cells["Đơn giá"].Value)));
        }

        private void ThemDanhMuc()
        {
            string tenDanhMuc = txtDanhMucMoi.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenDanhMuc))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục mới.");
                txtDanhMucMoi.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO DanhMuc (TenDanhMuc) VALUES (@ten)", conn))
                    {
                        cmd.Parameters.AddWithValue("@ten", tenDanhMuc);
                        cmd.ExecuteNonQuery();
                    }
                }

                txtDanhMucMoi.Clear();
                NapDanhMuc();

                MessageBox.Show("Thêm danh mục thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm danh mục.\n" + ex.Message);
            }
        }

        private void LamMoi()
        {
            maMonDangChon = -1;
            txtTenMon.Clear();
            numDonGia.Value = 0;
            txtDanhMucMoi.Clear();

            NapDuLieu();
            dgvMon.ClearSelection();
        }
    }
}
