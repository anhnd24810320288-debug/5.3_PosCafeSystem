
using MySql.Data.MySqlClient;
using CafePOSSystem;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CafePOSSystem
{
    public partial class Form1 : Form
    {
        private int maBanDangChon = -1;
        private int maHoaDonDangMo = -1;

        public Form1()
        {
            InitializeComponent();

            cboDanhMuc.SelectedIndexChanged += (s, e) => NapMonAn();
            btnThemMon.Click += (s, e) => ThemMon();
            btnThanhToan.Click += (s, e) => ThanhToan();
            btnDoiBan.Click += (s, e) => DoiBan();
            btnQuanLy.Click += (s, e) => MoQuanLyThucDon();
            btnLamMoi.Click += (s, e) => LamMoi();

            Load += (s, e) => KhoiDong();
        }

        private void KhoiDong()
        {
            try
            {
                NapDanhMuc();
                NapBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể kết nối hoặc tải dữ liệu MySQL.\n" + ex.Message,
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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

        private void NapMonAn()
        {
            if (cboDanhMuc.SelectedValue == null ||
                cboDanhMuc.SelectedValue is DataRowView)
            {
                cboMonAn.DataSource = null;
                return;
            }

            if (!int.TryParse(cboDanhMuc.SelectedValue.ToString(), out int maDanhMuc))
                return;

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(
                    @"SELECT MaMon, TenMon
                      FROM MonAn
                      WHERE MaDanhMuc = @madm
                      ORDER BY TenMon", conn))
                {
                    cmd.Parameters.AddWithValue("@madm", maDanhMuc);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cboMonAn.DataSource = null;
                        cboMonAn.DisplayMember = "TenMon";
                        cboMonAn.ValueMember = "MaMon";
                        cboMonAn.DataSource = dt;
                    }
                }
            }
        }

        private void NapBan()
        {
            flpBan.Controls.Clear();

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT MaBan, TenBan, TrangThai FROM BanAn ORDER BY MaBan",
                    conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int maBan = Convert.ToInt32(reader["MaBan"]);
                        string tenBan = reader["TenBan"].ToString() ?? "";
                        string trangThai = reader["TrangThai"].ToString() ?? "Trống";

                        Button btn = new Button();
                        btn.Width = 105;
                        btn.Height = 75;
                        btn.Margin = new Padding(5);
                        btn.Tag = maBan;
                        btn.Text = tenBan + "\n" + trangThai;
                        btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.BackColor = trangThai == "Trống"
                            ? Color.LightGreen
                            : Color.LightCoral;

                        if (maBan == maBanDangChon)
                            btn.FlatAppearance.BorderSize = 3;
                        else
                            btn.FlatAppearance.BorderSize = 1;

                        btn.Click += (s, e) => ChonBan(maBan);
                        flpBan.Controls.Add(btn);
                    }
                }
            }
        }

        private void ChonBan(int maBan)
        {
            maBanDangChon = maBan;
            maHoaDonDangMo = -1;

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(
                    @"SELECT MaHoaDon
                      FROM HoaDon
                      WHERE MaBan = @maban AND TrangThai = 0
                      ORDER BY MaHoaDon DESC
                      LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@maban", maBan);
                    object? result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        maHoaDonDangMo = Convert.ToInt32(result);
                }
            }

            NapBan();
            NapChiTietHoaDon();
        }

        private void NapChiTietHoaDon()
        {
            if (maHoaDonDangMo <= 0)
            {
                dgvChiTiet.DataSource = null;
                lblTongTien.Text = "Tổng tiền: 0 VNĐ";
                return;
            }

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        ct.MaMon,
                        m.TenMon AS 'Tên món',
                        ct.SoLuong AS 'Số lượng',
                        ct.DonGia AS 'Đơn giá',
                        ct.SoLuong * ct.DonGia AS 'Thành tiền'
                    FROM ChiTietHoaDon ct
                    INNER JOIN MonAn m ON ct.MaMon = m.MaMon
                    WHERE ct.MaHoaDon = @mahd
                    ORDER BY m.TenMon";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mahd", maHoaDonDangMo);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvChiTiet.DataSource = dt;
                    }
                }

                using (MySqlCommand cmd = new MySqlCommand(
                    @"SELECT IFNULL(SUM(SoLuong * DonGia), 0)
                      FROM ChiTietHoaDon
                      WHERE MaHoaDon = @mahd", conn))
                {
                    cmd.Parameters.AddWithValue("@mahd", maHoaDonDangMo);

                    decimal tongTien = Convert.ToDecimal(cmd.ExecuteScalar());
                    lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";
                }
            }

            if (dgvChiTiet.Columns.Contains("MaMon"))
                dgvChiTiet.Columns["MaMon"].Visible = false;

            if (dgvChiTiet.Columns.Contains("Đơn giá"))
                dgvChiTiet.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";

            if (dgvChiTiet.Columns.Contains("Thành tiền"))
                dgvChiTiet.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
        }

        private void ThemMon()
        {
            if (maBanDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn bàn trước.");
                return;
            }

            if (cboMonAn.SelectedValue == null ||
                cboMonAn.SelectedValue is DataRowView)
            {
                MessageBox.Show("Vui lòng chọn món ăn.");
                return;
            }

            int maMon = Convert.ToInt32(cboMonAn.SelectedValue);
            int soLuong = Convert.ToInt32(numSoLuong.Value);

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        if (maHoaDonDangMo <= 0)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(
                                @"INSERT INTO HoaDon (MaBan, GioVao, TongTien, TrangThai)
                                  VALUES (@maban, NOW(), 0, 0);
                                  SELECT LAST_INSERT_ID();",
                                conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@maban", maBanDangChon);
                                maHoaDonDangMo = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                        }

                        decimal donGia;

                        using (MySqlCommand cmd = new MySqlCommand(
                            "SELECT DonGia FROM MonAn WHERE MaMon = @mamon",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@mamon", maMon);
                            object? result = cmd.ExecuteScalar();

                            if (result == null || result == DBNull.Value)
                                throw new Exception("Không tìm thấy món ăn.");

                            donGia = Convert.ToDecimal(result);
                        }

                        using (MySqlCommand cmd = new MySqlCommand(
                            @"INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia)
                              VALUES (@mahd, @mamon, @soluong, @dongia)
                              ON DUPLICATE KEY UPDATE
                              SoLuong = SoLuong + @soluong_them",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@mahd", maHoaDonDangMo);
                            cmd.Parameters.AddWithValue("@mamon", maMon);
                            cmd.Parameters.AddWithValue("@soluong", soLuong);
                            cmd.Parameters.AddWithValue("@dongia", donGia);
                            cmd.Parameters.AddWithValue("@soluong_them", soLuong);
                            cmd.ExecuteNonQuery();
                        }

                        using (MySqlCommand cmd = new MySqlCommand(
                            "UPDATE BanAn SET TrangThai = 'Có khách' WHERE MaBan = @maban",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@maban", maBanDangChon);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        NapChiTietHoaDon();
                        NapBan();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        maHoaDonDangMo = -1;

                        MessageBox.Show(
                            "Không thể thêm món.\n" + ex.Message,
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        ChonBan(maBanDangChon);
                    }
                }
            }
        }

        private void ThanhToan()
        {
            if (maBanDangChon <= 0 || maHoaDonDangMo <= 0)
            {
                MessageBox.Show("Bàn này chưa có hóa đơn.");
                return;
            }

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        decimal tongTien;

                        using (MySqlCommand cmd = new MySqlCommand(
                            @"SELECT IFNULL(SUM(SoLuong * DonGia), 0)
                              FROM ChiTietHoaDon WHERE MaHoaDon = @mahd",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@mahd", maHoaDonDangMo);
                            tongTien = Convert.ToDecimal(cmd.ExecuteScalar());
                        }

                        if (tongTien <= 0)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Hóa đơn chưa có món ăn.");
                            return;
                        }

                        DialogResult answer = MessageBox.Show(
                            "Tổng thanh toán: " + tongTien.ToString("N0") +
                            " VNĐ\nXác nhận thanh toán?",
                            "Thanh toán",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (answer != DialogResult.Yes)
                        {
                            transaction.Rollback();
                            return;
                        }

                        using (MySqlCommand cmd = new MySqlCommand(
                            @"UPDATE HoaDon
                              SET TongTien = @tongtien, GioRa = NOW(), TrangThai = 1
                              WHERE MaHoaDon = @mahd AND TrangThai = 0",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@tongtien", tongTien);
                            cmd.Parameters.AddWithValue("@mahd", maHoaDonDangMo);
                            cmd.ExecuteNonQuery();
                        }

                        using (MySqlCommand cmd = new MySqlCommand(
                            "UPDATE BanAn SET TrangThai = 'Trống' WHERE MaBan = @maban",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@maban", maBanDangChon);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show("Thanh toán thành công!");
                        maHoaDonDangMo = -1;
                        NapChiTietHoaDon();
                        NapBan();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        MessageBox.Show(
                            "Lỗi thanh toán: " + ex.Message,
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DoiBan()
        {
            if (maBanDangChon <= 0 || maHoaDonDangMo <= 0)
            {
                MessageBox.Show("Vui lòng chọn bàn đang có hóa đơn.");
                return;
            }

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                DataTable dt = new DataTable();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(
                    "SELECT MaBan, TenBan FROM BanAn WHERE TrangThai = 'Trống' ORDER BY MaBan",
                    conn))
                {
                    adapter.Fill(dt);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bàn trống để chuyển.");
                    return;
                }

                using (Form form = new Form())
                {
                    form.Text = "Chọn bàn đích";
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ClientSize = new Size(300, 130);
                    form.FormBorderStyle = FormBorderStyle.FixedDialog;
                    form.MaximizeBox = false;
                    form.MinimizeBox = false;

                    ComboBox cbo = new ComboBox();
                    cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbo.DisplayMember = "TenBan";
                    cbo.ValueMember = "MaBan";
                    cbo.DataSource = dt;
                    cbo.SetBounds(20, 15, 260, 30);

                    Button btnOK = new Button();
                    btnOK.Text = "Chuyển bàn";
                    btnOK.SetBounds(90, 65, 120, 35);
                    btnOK.DialogResult = DialogResult.OK;

                    form.Controls.Add(cbo);
                    form.Controls.Add(btnOK);
                    form.AcceptButton = btnOK;

                    if (form.ShowDialog(this) != DialogResult.OK ||
                        cbo.SelectedValue == null)
                        return;

                    int maBanMoi = Convert.ToInt32(cbo.SelectedValue);

                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand(
                                "UPDATE HoaDon SET MaBan = @mabanmoi WHERE MaHoaDon = @mahd AND TrangThai = 0",
                                conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@mabanmoi", maBanMoi);
                                cmd.Parameters.AddWithValue("@mahd", maHoaDonDangMo);
                                cmd.ExecuteNonQuery();
                            }

                            using (MySqlCommand cmd = new MySqlCommand(
                                "UPDATE BanAn SET TrangThai = 'Trống' WHERE MaBan = @mabancu",
                                conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@mabancu", maBanDangChon);
                                cmd.ExecuteNonQuery();
                            }

                            using (MySqlCommand cmd = new MySqlCommand(
                                "UPDATE BanAn SET TrangThai = 'Có khách' WHERE MaBan = @mabanmoi",
                                conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@mabanmoi", maBanMoi);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            maBanDangChon = maBanMoi;
                            ChonBan(maBanMoi);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();

                            MessageBox.Show(
                                "Không thể đổi bàn: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void MoQuanLyThucDon()
        {
            using (FormQuanLyThucDon form = new FormQuanLyThucDon())
            {
                form.ShowDialog(this);
            }

            NapDanhMuc();
            NapChiTietHoaDon();
        }

        private void LamMoi()
        {
            try
            {
                NapDanhMuc();
                NapBan();

                if (maBanDangChon > 0)
                    ChonBan(maBanDangChon);
                else
                    NapChiTietHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể làm mới dữ liệu: " + ex.Message);
            }
        }
    }
}
