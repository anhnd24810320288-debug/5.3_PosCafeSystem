
using Org.BouncyCastle.Asn1.Crmf;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CafePOSSystem
{
    partial class FormQuanLyThucDon
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvMon;
        private System.Windows.Forms.Label lblDanhMucMoi;
        private System.Windows.Forms.TextBox txtDanhMucMoi;
        private System.Windows.Forms.Button btnThemDanhMuc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTieuDe = new System.Windows.Forms.Label();
            lblTenMon = new System.Windows.Forms.Label();
            txtTenMon = new System.Windows.Forms.TextBox();
            lblDanhMuc = new System.Windows.Forms.Label();
            cboDanhMuc = new System.Windows.Forms.ComboBox();
            lblDonGia = new System.Windows.Forms.Label();
            numDonGia = new System.Windows.Forms.NumericUpDown();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            dgvMon = new System.Windows.Forms.DataGridView();
            lblDanhMucMoi = new System.Windows.Forms.Label();
            txtDanhMucMoi = new System.Windows.Forms.TextBox();
            btnThemDanhMuc = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMon).BeginInit();
            SuspendLayout();

            lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            lblTieuDe.Height = 50;
            lblTieuDe.Text = "QUẢN LÝ THỰC ĐƠN";
            lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI", 16F, System.Drawing.FontStyle.Bold);

            lblTenMon.Location = new System.Drawing.Point(20, 65);
            lblTenMon.Size = new System.Drawing.Size(100, 28);
            lblTenMon.Text = "Tên món:";

            txtTenMon.Location = new System.Drawing.Point(125, 65);
            txtTenMon.Size = new System.Drawing.Size(260, 27);

            lblDanhMuc.Location = new System.Drawing.Point(20, 105);
            lblDanhMuc.Size = new System.Drawing.Size(100, 28);
            lblDanhMuc.Text = "Danh mục:";

            cboDanhMuc.Location = new System.Drawing.Point(125, 105);
            cboDanhMuc.Size = new System.Drawing.Size(260, 28);
            cboDanhMuc.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            lblDonGia.Location = new System.Drawing.Point(20, 145);
            lblDonGia.Size = new System.Drawing.Size(100, 28);
            lblDonGia.Text = "Đơn giá:";

            numDonGia.Location = new System.Drawing.Point(125, 145);
            numDonGia.Size = new System.Drawing.Size(260, 27);
            numDonGia.Maximum = 1000000000;
            numDonGia.Minimum = 0;
            numDonGia.DecimalPlaces = 0;
            numDonGia.ThousandsSeparator = true;
            numDonGia.Increment = 1000;

            btnThem.Location = new System.Drawing.Point(20, 190);
            btnThem.Size = new System.Drawing.Size(85, 36);
            btnThem.Text = "Thêm";

            btnSua.Location = new System.Drawing.Point(115, 190);
            btnSua.Size = new System.Drawing.Size(85, 36);
            btnSua.Text = "Sửa";

            btnXoa.Location = new System.Drawing.Point(210, 190);
            btnXoa.Size = new System.Drawing.Size(85, 36);
            btnXoa.Text = "Xóa";

            btnLamMoi.Location = new System.Drawing.Point(305, 190);
            btnLamMoi.Size = new System.Drawing.Size(100, 36);
            btnLamMoi.Text = "Làm mới";

            lblDanhMucMoi.Location = new System.Drawing.Point(20, 245);
            lblDanhMucMoi.Size = new System.Drawing.Size(130, 28);
            lblDanhMucMoi.Text = "Danh mục mới:";

            txtDanhMucMoi.Location = new System.Drawing.Point(150, 245);
            txtDanhMucMoi.Size = new System.Drawing.Size(235, 27);

            btnThemDanhMuc.Location = new System.Drawing.Point(395, 243);
            btnThemDanhMuc.Size = new System.Drawing.Size(120, 32);
            btnThemDanhMuc.Text = "Thêm danh mục";

            dgvMon.Location = new System.Drawing.Point(20, 295);
            dgvMon.Size = new System.Drawing.Size(760, 260);
            dgvMon.Anchor = System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            dgvMon.ReadOnly = true;
            dgvMon.AllowUserToAddRows = false;
            dgvMon.AllowUserToDeleteRows = false;
            dgvMon.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvMon.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMon.MultiSelect = false;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 575);
            Controls.Add(dgvMon);
            Controls.Add(btnThemDanhMuc);
            Controls.Add(txtDanhMucMoi);
            Controls.Add(lblDanhMucMoi);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(numDonGia);
            Controls.Add(lblDonGia);
            Controls.Add(cboDanhMuc);
            Controls.Add(lblDanhMuc);
            Controls.Add(txtTenMon);
            Controls.Add(lblTenMon);
            Controls.Add(lblTieuDe);
            MinimumSize = new System.Drawing.Size(700, 500);
            Name = "FormQuanLyThucDon";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Quản lý thực đơn";

            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
