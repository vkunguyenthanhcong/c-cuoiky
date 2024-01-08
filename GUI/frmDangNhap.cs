using BLL;
using DevExpress.XtraEditors;
using DTO;
using System.ServiceModel.Channels;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        public static string userName = "";
        public static string maNguoiDung = "";
        public static string quyenNguoiDung = "";
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                TaiKhoan taiKhoan = new TaiKhoan(txtUsername.Text, txtPassword.Text);
                TaiKhoan tk = TKBLL.getTaiKhoanDangNhap(taiKhoan);
                maNguoiDung = tk.MaThanhVien;
                quyenNguoiDung = tk.Quyen;
                userName = tk.Username;
                this.Hide();
                frmTrangChu frm = new frmTrangChu();
                frm.Show();
            }
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác Nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}