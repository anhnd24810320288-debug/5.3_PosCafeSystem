
namespace CafePOSSystem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.Panel panelBan;
        private System.Windows.Forms.Label lblTieuDeBan;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
        private System.Windows.Forms.Panel panelHoaDon;
        private System.Windows.Forms.Label lblTieuDeHoaDon;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblMonAn;
        private System.Windows.Forms.ComboBox cboMonAn;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnDoiBan;
        private System.Windows.Forms.Button btnQuanLy;
        private System.Windows.Forms.Button btnLamMoi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            layoutMain = new System.Windows.Forms.TableLayoutPanel();
            panelBan = new System.Windows.Forms.Panel();
            lblTieuDeBan = new System.Windows.Forms.Label();
            flpBan = new System.Windows.Forms.FlowLayoutPanel();
            panelHoaDon = new System.Windows.Forms.Panel();
            lblTieuDeHoaDon = new System.Windows.Forms.Label();
            lblDanhMuc = new System.Windows.Forms.Label();
            cboDanhMuc = new System.Windows.Forms.ComboBox();
            lblMonAn = new System.Windows.Forms.Label();
            cboMonAn = new System.Windows.Forms.ComboBox();
            lblSoLuong = new System.Windows.Forms.Label();
            numSoLuong = new System.Windows.Forms.NumericUpDown();
            btnThemMon = new System.Windows.Forms.Button();
            dgvChiTiet = new System.Windows.Forms.DataGridView();
            lblTongTien = new System.Windows.Forms.Label();
            btnThanhToan = new System.Windows.Forms.Button();
            btnDoiBan = new System.Windows.Forms.Button();
            btnQuanLy = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();

            layoutMain.SuspendLayout();
            panelBan.SuspendLayout();
            panelHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();

            layoutMain.ColumnCount = 2;
            layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 35F));
            layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 65F));
            layoutMain.Controls.Add(panelBan, 0, 0);
            layoutMain.Controls.Add(panelHoaDon, 1, 0);
            layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutMain.Padding = new System.Windows.Forms.Padding(10);
            layoutMain.RowCount = 1;
            layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Percent, 100F));

            panelBan.Controls.Add(flpBan);
            panelBan.Controls.Add(lblTieuDeBan);
            panelBan.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBan.Padding = new System.Windows.Forms.Padding(5);

            lblTieuDeBan.Dock = System.Windows.Forms.DockStyle.Top;
            lblTieuDeBan.Height = 45;
            lblTieuDeBan.Text = "SƠ ĐỒ BÀN";
            lblTieuDeBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTieuDeBan.Font = new System.Drawing.Font(
                "Segoe UI", 14F, System.Drawing.FontStyle.Bold);

            flpBan.Dock = System.Windows.Forms.DockStyle.Fill;
            flpBan.AutoScroll = true;
            flpBan.Padding = new System.Windows.Forms.Padding(5);

            panelHoaDon.Controls.Add(btnLamMoi);
            panelHoaDon.Controls.Add(btnQuanLy);
            panelHoaDon.Controls.Add(btnDoiBan);
            panelHoaDon.Controls.Add(btnThanhToan);
            panelHoaDon.Controls.Add(lblTongTien);
            panelHoaDon.Controls.Add(dgvChiTiet);
            panelHoaDon.Controls.Add(btnThemMon);
            panelHoaDon.Controls.Add(numSoLuong);
            panelHoaDon.Controls.Add(lblSoLuong);
            panelHoaDon.Controls.Add(cboMonAn);
            panelHoaDon.Controls.Add(lblMonAn);
            panelHoaDon.Controls.Add(cboDanhMuc);
            panelHoaDon.Controls.Add(lblDanhMuc);
            panelHoaDon.Controls.Add(lblTieuDeHoaDon);
            panelHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            panelHoaDon.Padding = new System.Windows.Forms.Padding(5);

            lblTieuDeHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            lblTieuDeHoaDon.Height = 45;
            lblTieuDeHoaDon.Text = "CHI TIẾT HÓA ĐƠN";
            lblTieuDeHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTieuDeHoaDon.Font = new System.Drawing.Font(
                "Segoe UI", 14F, System.Drawing.FontStyle.Bold);

            lblDanhMuc.Location = new System.Drawing.Point(10, 58);
            lblDanhMuc.Size = new System.Drawing.Size(85, 30);
            lblDanhMuc.Text = "Danh mục";
            lblDanhMuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboDanhMuc.Location = new System.Drawing.Point(100, 58);
            cboDanhMuc.Size = new System.Drawing.Size(170, 30);
            cboDanhMuc.Anchor = System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left;

            lblMonAn.Location = new System.Drawing.Point(280, 58);
            lblMonAn.Size = new System.Drawing.Size(55, 30);
            lblMonAn.Text = "Món";
            lblMonAn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            cboMonAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboMonAn.Location = new System.Drawing.Point(335, 58);
            cboMonAn.Size = new System.Drawing.Size(190, 30);
            cboMonAn.Anchor = System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            lblSoLuong.Location = new System.Drawing.Point(10, 98);
            lblSoLuong.Size = new System.Drawing.Size(65, 30);
            lblSoLuong.Text = "Số lượng";
            lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            numSoLuong.Location = new System.Drawing.Point(80, 98);
            numSoLuong.Minimum = 1;
            numSoLuong.Maximum = 1000;
            numSoLuong.Value = 1;
            numSoLuong.Size = new System.Drawing.Size(80, 30);

            btnThemMon.Location = new System.Drawing.Point(175, 96);
            btnThemMon.Size = new System.Drawing.Size(130, 34);
            btnThemMon.Text = "Thêm món";
            btnThemMon.BackColor = System.Drawing.Color.LightGreen;
            btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            dgvChiTiet.Location = new System.Drawing.Point(10, 140);
            dgvChiTiet.Size = new System.Drawing.Size(530, 300);
            dgvChiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.MultiSelect = false;

            lblTongTien.Location = new System.Drawing.Point(10, 450);
            lblTongTien.Size = new System.Drawing.Size(530, 35);
            lblTongTien.Anchor = System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            lblTongTien.Font = new System.Drawing.Font(
                "Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            lblTongTien.ForeColor = System.Drawing.Color.DarkRed;
            lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            btnThanhToan.Location = new System.Drawing.Point(10, 495);
            btnThanhToan.Size = new System.Drawing.Size(150, 42);
            btnThanhToan.Anchor = System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.BackColor = System.Drawing.Color.LightGreen;
            btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            btnDoiBan.Location = new System.Drawing.Point(170, 495);
            btnDoiBan.Size = new System.Drawing.Size(110, 42);
            btnDoiBan.Anchor = System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnDoiBan.Text = "Đổi bàn";

            btnQuanLy.Location = new System.Drawing.Point(290, 495);
            btnQuanLy.Size = new System.Drawing.Size(130, 42);
            btnQuanLy.Anchor = System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnQuanLy.Text = "Quản lý thực đơn";

            btnLamMoi.Location = new System.Drawing.Point(430, 495);
            btnLamMoi.Size = new System.Drawing.Size(110, 42);
            btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Right;
            btnLamMoi.Text = "Làm mới";

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 600);
            Controls.Add(layoutMain);
            MinimumSize = new System.Drawing.Size(850, 500);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cafe POS System";

            layoutMain.ResumeLayout(false);
            panelBan.ResumeLayout(false);
            panelHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
        }
    }
}
