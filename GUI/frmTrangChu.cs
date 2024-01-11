using BLL;
using DevExpress.Utils.CommonDialogs;
using DevExpress.Xpo.Logger.Transport;
using DevExpress.XtraCharts.Design;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DocumentFormat.OpenXml.Wordprocessing;
using DTO;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using System.Data.SqlClient;

namespace GUI
{
    public partial class frmTrangChu : DevExpress.XtraEditors.XtraForm
    {
        public static string maNguoiDung = "";
        public static string quyenNguoiDung = "";
        public static bool viewAllGV = true;
        public static string strPassword = "";
        public static string id = "";
        HoSoSinhVienBLl hoSoSinhVienBLl = new HoSoSinhVienBLl();
        private string selectedImagePath = "";
        HoSoTamTruBLL hoSoTamTruBLL = new HoSoTamTruBLL();
        HoSoGiangVienBLL hoSoGiangVienBLL = new HoSoGiangVienBLL();
        public frmTrangChu()
        {
            InitializeComponent();
            quyenNguoiDung = frmDangNhap.quyenNguoiDung.ToString();
            FunctionPanelHoSoSinhVien();
            LoadPanelHoSoTamTru();
            loadPanelHoSoGiangVien();
        }
        private void FunctionPanelHoSoSinhVien()
        {
            AddDataComboBox();
            loadTableAllSinhVienOfHoSoSinhVien();
        }
        private void loadHoSoSinhVien_1(string masv)
        {
            txtMsv.Enabled = false;
            dtNgaySinh.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            dtNgaySinh.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            ThongTinSinhVien thongtin = hoSoSinhVienBLl.getHoSoSinhVien(masv);
            txtMsv.Text = thongtin.Masv.ToUpper();
            txtNamNhapHoc.Text = thongtin.Namnhaphoc.ToString();
            txtHoTen.Text = thongtin.Hoten;
            dtNgaySinh.EditValue = DateTime.Parse(thongtin.Ngaysinh.ToString());
            cbGioiTinh.EditValue = thongtin.Gioitinh;
            cbHeDT.EditValue = thongtin.Hedaotao;
            cbDanToc.EditValue = thongtin.Dantoc;
            cbKhoa.SelectedValue = thongtin.Khoa;
            cbTinhTrang.EditValue = thongtin.Tinhtrang;
            cbLop.SelectedValue = thongtin.Lop;
            txtCccd.Text = thongtin.Cccd.ToString();
            txtEmail.Text = thongtin.Email;
            txtHoTenBo.Text = thongtin.Hotenbo;
            txtHoTenMe.Text = thongtin.Hotenme;
            txtNgheBo.Text = thongtin.Nghebo;
            txtNgheMe.Text = thongtin.Ngheme;
            txtDiaChi.Text = thongtin.Diachi;
            txtSoDienThoai.Text = '0' + thongtin.Sodienthoai.ToString();

            Image image = ByteArrayToImage(thongtin.Image);
            imageSinhVien.Image = image;
        }
        private void loadTableAllSinhVienOfHoSoSinhVien()
        {
            HoSoSinhVienBLl hoSoSinhVienBLl = new HoSoSinhVienBLl();
            List<ThongTinSinhVien> sinhVienList = hoSoSinhVienBLl.getListSinhVien();
            gridControlAllHoSoSinhVien.DataSource = sinhVienList;
            gridViewAllHoSoSinhVien.OptionsBehavior.Editable = false;
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridViewAllHoSoSinhVien.Columns)
            {
                column.BestFit();
            }

        }
        private void loadTableAllSinhVienOfHoSoTamTru()
        {
            HoSoTamTruBLL hoSoTamTruBLL = new HoSoTamTruBLL();
            List<HoSoTamTru> hoSoTamTruList = hoSoTamTruBLL.getAllHoSoTamTru();
            gridControlHoSoTamTru.DataSource = hoSoTamTruList;
            gridViewHoSoTamTru.OptionsBehavior.Editable = false;
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridViewHoSoTamTru.Columns)
            {
                column.BestFit();
            }
        }
        private void AddDataComboBox()
        {
            cbGioiTinh.Properties.Items.Add("Nam");
            cbGioiTinh.Properties.Items.Add("Nữ");
            cbHeDT.Properties.Items.Add("Chính Quy");
            cbHeDT.Properties.Items.Add("Không Chính Quy");
            List<string> danTocVietNam = new List<string>
                {
                    "Kinh", "Tày", "Thái", "Mường", "H'Mông", "Dao", "Gia Rai", "Ê Đê", "Ba Na", "Xơ Đăng",
                    "Sán Chay", "Cơ Ho", "Chăm", "Sán Dìu", "Hrê", "Ra Glai", "M'Nông", "Brâu", "Ơ Đu", "Giáy",
                    "Cờ Lao", "Gié Triêng", "Hoa", "Ngái", "Chu Ru", "La Chí", "La Ha", "Pu Péo", "Ro Măm",
                    "La Hu", "Lự", "Mảng", "Cơ Tu", "Tà Ôi", "Cơ Lùng", "Cống", "Bơ Đeo", "Chơ Ro", "Lào",
                    "Sa Pa", "La Chứ", "Phù Lá", "Khơ Mú", "Pà Thẻn", "Chơang", "Chu Pah", "Thiểu", "Mạ",
                    "Co", "Chứt", "Chẻ", "Chơ Ro", "Xinh Mun", "Hà Nhì", "Cong", "Si La"
                };

            cbDanToc.Properties.Items.AddRange(danTocVietNam.ToArray());
            List<Khoa> khoaList = hoSoSinhVienBLl.getKhoa();
            cbKhoa.DataSource = khoaList;
            cbKhoa.DisplayMember = "tenkhoa";
            cbKhoa.ValueMember = "makhoa";

            cbTinhTrang.Properties.Items.Add("Đang Học");
            cbTinhTrang.Properties.Items.Add("Bảo Lưu");
            cbTinhTrang.Properties.Items.Add("Bỏ Học");
            cbTinhTrang.Properties.Items.Add("Buộc Thôi Học");

            cbGioiTinhGV.Properties.Items.Add("Nam");
            cbGioiTinhGV.Properties.Items.Add("Nữ");
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                return null;
            }

            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                return System.Drawing.Image.FromStream(memoryStream);
            }
        }
        private void frmTrangChu_FormClosing(object sender, FormClosingEventArgs e)
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


        private void gridViewAllHoSoSinhVien_Click(object sender, EventArgs e)
        {
            if (gridViewAllHoSoSinhVien.RowCount > 0)
            {
                loadHoSoSinhVien_1(gridViewAllHoSoSinhVien.GetFocusedRowCellValue("Masv").ToString());
            }
        }

        private void cbKhoa_SelectedValueChanged_1(object sender, EventArgs e)
        {
            HoSoSinhVienBLl hoSoSinhVienBLl = new HoSoSinhVienBLl();
            List<Lop> lopList = hoSoSinhVienBLl.getLop(cbKhoa.SelectedValue.ToString());
            cbLop.DataSource = lopList;
            cbLop.DisplayMember = "tenlop";
            cbLop.ValueMember = "tenlop";
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            resetData();
        }
        private void resetData()
        {
            txtMsv.Enabled = true;
            txtMsv.Text = "";
            txtNamNhapHoc.Text = "";
            txtHoTen.Text = "";
            dtNgaySinh.EditValue = "01-01-2024";
            cbGioiTinh.SelectedIndex = 0;
            cbHeDT.SelectedIndex = 0;
            cbDanToc.SelectedIndex = 0;
            cbKhoa.SelectedIndex = 0;
            cbTinhTrang.SelectedIndex = 0;
            cbLop.SelectedIndex = 0;
            txtCccd.Text = "";
            txtEmail.Text = "";
            txtHoTenBo.Text = "";
            txtHoTenMe.Text = "";
            txtNgheBo.Text = "";
            txtNgheMe.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = '0' + "";
            selectedImagePath = "";


            imageSinhVien.Image = imageSinhVien.InitialImage;
        }

        private void imageSinhVien_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {

                imageSinhVien.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void btnThayDoiAnh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                XtraMessageBox.Show("Vui lòng chọn hình ảnh.");
                return;
            }
            else if (txtMsv.Text == "")
            {
                XtraMessageBox.Show("Vui lòng chọn sinh viên cần chỉnh sửa.");
                return;

            }
            byte[] imageData = File.ReadAllBytes(selectedImagePath);
            hoSoSinhVienBLl.UpdateImage(imageData, txtMsv.Text);
            loadTableAllSinhVienOfHoSoSinhVien();
            selectedImagePath = "";
            XtraMessageBox.Show("Cập nhật hoàn tất");
        }

        private void btnThemSinhVien_Click(object sender, EventArgs e)
        {
            if (txtMsv.Text == "" || txtNamNhapHoc.Text == "" || txtHoTen.Text == "" || dtNgaySinh.DateTime == null || cbGioiTinh.SelectedItem == null || cbHeDT.SelectedItem == null || cbDanToc.SelectedItem == null || cbKhoa.SelectedItem == null || cbLop.SelectedItem == null || cbTinhTrang.SelectedItem == null || txtCccd.Text == "" || txtEmail.Text == "" || txtHoTenBo.Text == "" || txtSoDienThoai.Text == "" || txtNgheBo.Text == "" || txtHoTenMe.Text == "" || txtNgheMe.Text == "" || txtDiaChi.Text == "")
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                if (!IsEmailValid(txtEmail.Text))
                {
                    XtraMessageBox.Show("Email sai định dạng");
                }
                if (!IsPhoneNumberValid(txtSoDienThoai.Text))
                {
                    XtraMessageBox.Show("Số điện thoại sai định dạng");
                }
                if (!IsIdNumberValid(txtCccd.Text))
                {
                    XtraMessageBox.Show("CMND / CCCD sai định dạng");
                }
                if (!IsAgeValid(dtNgaySinh.DateTime))
                {
                    XtraMessageBox.Show("Ngày sinh chưa đủ 18 tuổi");
                }
                if (selectedImagePath == "")
                {
                    XtraMessageBox.Show("Vui lòng thêm hình ảnh");
                }
                if (selectedImagePath != "" && IsEmailValid(txtEmail.Text) == true && IsPhoneNumberValid(txtSoDienThoai.Text) == true && IsIdNumberValid(txtCccd.Text) == true && IsAgeValid(dtNgaySinh.DateTime) == true)
                {
                    byte[] imageData = File.ReadAllBytes(selectedImagePath);
                    ThongTinSinhVien ttsv = new ThongTinSinhVien(txtMsv.Text, int.Parse(txtNamNhapHoc.Text), imageData, txtHoTen.Text.ToString(), dtNgaySinh.DateTime, cbGioiTinh.Text, cbHeDT.Text, cbDanToc.Text, cbKhoa.SelectedValue.ToString(), cbLop.SelectedValue.ToString(), cbTinhTrang.Text, int.Parse(txtCccd.Text), int.Parse(txtSoDienThoai.Text), txtEmail.Text, txtHoTenBo.Text, txtNgheBo.Text, txtHoTenMe.Text, txtNgheMe.Text, txtDiaChi.Text);

                    if (hoSoSinhVienBLl.AddNewSinhVien(ttsv))
                    {
                        XtraMessageBox.Show("Thêm thành công");
                        loadTableAllSinhVienOfHoSoSinhVien();
                        selectedImagePath = "";
                        imageSinhVien.Image = imageSinhVien.InitialImage;
                    }
                    else
                    {
                        XtraMessageBox.Show("Mã sinh viên đã tồn tại trong hệ thống");
                        selectedImagePath = "";
                    }
                }
            }
        }
        static bool IsEmailValid(string email)
        {
            // Define a regular expression pattern for a basic email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Create a Regex object
            Regex regex = new Regex(pattern);

            // Check if the email matches the pattern
            return regex.IsMatch(email);
        }
        static bool IsPhoneNumberValid(string phoneNumber)
        {
            // Simple validation for a 9-digit phone number
            string pattern = @"^\d{10}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        static bool IsIdNumberValid(string idNumber)
        {
            // Simple validation for a 9-digit ID number
            string pattern = @"^\d{9,12}$";
            return Regex.IsMatch(idNumber, pattern);
        }

        static bool IsAgeValid(DateTime birthdate)
        {
            // Check if age is over 18
            int age = DateTime.Now.Year - birthdate.Year;
            if (DateTime.Now.Month < birthdate.Month || (DateTime.Now.Month == birthdate.Month && DateTime.Now.Day < birthdate.Day))
            {
                age--;
            }
            return age >= 18;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMsv.Text != "")
            {
                if (XtraMessageBox.Show($"Bạn có chắc chắn muốn xoá sinh viên {txtMsv.Text}?", "Xác nhận xoá", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (hoSoSinhVienBLl.DeleteSinhVien(txtMsv.Text))
                    {
                        XtraMessageBox.Show("Xoá thành công");
                        loadTableAllSinhVienOfHoSoSinhVien();
                        resetData();

                    }
                    else
                    {
                        XtraMessageBox.Show("Sinh viên không tồn tại");
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn sinh viên cần xoá");
            }
        }

        private void LoadPanelHoSoTamTru()
        {
            dtNgayDenTamTru.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            dtNgayDenTamTru.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            List<Khoa> khoaList = hoSoSinhVienBLl.getKhoa();
            cbKhoaHoSoTamTru.DataSource = khoaList;
            cbKhoaHoSoTamTru.DisplayMember = "tenkhoa";
            cbKhoaHoSoTamTru.ValueMember = "makhoa";
            loadTableAllSinhVienOfHoSoTamTru();
            txtHoTenHoSoTamTru.ReadOnly = true;
            txtMaIDHoSoTamTru.ReadOnly = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMsv.Text == "" || txtNamNhapHoc.Text == "" || txtHoTen.Text == "" || dtNgaySinh.DateTime == null || cbGioiTinh.SelectedItem == null || cbHeDT.SelectedItem == null || cbDanToc.SelectedItem == null || cbKhoa.SelectedItem == null || cbLop.SelectedItem == null || cbTinhTrang.SelectedItem == null || txtCccd.Text == "" || txtEmail.Text == "" || txtHoTenBo.Text == "" || txtSoDienThoai.Text == "" || txtNgheBo.Text == "" || txtHoTenMe.Text == "" || txtNgheMe.Text == "" || txtDiaChi.Text == "")
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                if (!IsEmailValid(txtEmail.Text))
                {
                    XtraMessageBox.Show("Email sai định dạng");
                }
                if (!IsPhoneNumberValid(txtSoDienThoai.Text))
                {
                    XtraMessageBox.Show("Số điện thoại sai định dạng");
                }
                if (!IsIdNumberValid(txtCccd.Text))
                {
                    XtraMessageBox.Show("CMND / CCCD sai định dạng");
                }
                if (!IsAgeValid(dtNgaySinh.DateTime))
                {
                    XtraMessageBox.Show("Ngày sinh chưa đủ 18 tuổi");
                }
                if (IsEmailValid(txtEmail.Text) == true && IsPhoneNumberValid(txtSoDienThoai.Text) == true && IsIdNumberValid(txtCccd.Text) == true && IsAgeValid(dtNgaySinh.DateTime) == true)
                {
                    ThongTinSinhVien ttsv = new ThongTinSinhVien(txtMsv.Text, int.Parse(txtNamNhapHoc.Text), txtHoTen.Text.ToString(), dtNgaySinh.DateTime, cbGioiTinh.Text, cbHeDT.Text, cbDanToc.Text, cbKhoa.SelectedValue.ToString(), cbLop.SelectedValue.ToString(), cbTinhTrang.Text, int.Parse(txtCccd.Text), int.Parse(txtSoDienThoai.Text), txtEmail.Text, txtHoTenBo.Text, txtNgheBo.Text, txtHoTenMe.Text, txtNgheMe.Text, txtDiaChi.Text);
                    if (XtraMessageBox.Show($"Bạn có chắc chắn muốn cập nhật sinh viên {txtMsv.Text}?", "Xác nhận cập nhật", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (hoSoSinhVienBLl.UpdateHoSoSinhVien(ttsv))
                        {
                            XtraMessageBox.Show("Sửa thành công");
                            loadTableAllSinhVienOfHoSoSinhVien();
                        }
                        else
                        {
                            XtraMessageBox.Show("Mã sinh viên không tồn tại trong hệ thống");
                        }
                    }
                }
            }
        }
        private void cbKhoaHoSoTamTru_SelectedValueChanged_1(object sender, EventArgs e)
        {
            HoSoSinhVienBLl hoSoSinhVienBLl = new HoSoSinhVienBLl();
            List<Lop> lopList = hoSoSinhVienBLl.getLop(cbKhoaHoSoTamTru.SelectedValue.ToString());
            cbLopHoSoTamTru.DataSource = lopList;
            cbLopHoSoTamTru.DisplayMember = "tenlop";
            cbLopHoSoTamTru.ValueMember = "tenlop";
        }

        private void btnDanhSachHoSoTamTruTheoKhoa_Click(object sender, EventArgs e)
        {
            HoSoTamTruBLL hoSoTamTruBLL = new HoSoTamTruBLL();
            List<HoSoTamTru> hoSoTamTruList = hoSoTamTruBLL.getAllHoSoTamTruTheoKhoa(cbKhoa.SelectedValue.ToString());
            gridControlHoSoTamTru.DataSource = hoSoTamTruList;
            gridViewHoSoTamTru.OptionsBehavior.Editable = false;
        }

        private void btnXemToanBoDanhSach_Click(object sender, EventArgs e)
        {
            loadTableAllSinhVienOfHoSoTamTru();
        }

        private void cbLopHoSoTamTru_SelectedValueChanged(object sender, EventArgs e)
        {
            HoSoTamTruBLL hoSoTamTruBLL = new HoSoTamTruBLL();
            List<HoSoTamTru> hoSoTamTruList = hoSoTamTruBLL.getAllHoSoTamTruTheoLop(cbLopHoSoTamTru.SelectedValue.ToString());
            gridControlHoSoTamTru.DataSource = hoSoTamTruList;
            gridViewHoSoTamTru.OptionsBehavior.Editable = false;
        }

        private void gridViewHoSoTamTru_Click(object sender, EventArgs e)
        {
            if (gridViewHoSoTamTru.RowCount > 0)
            {
                HoSoTamTru hoSoTamTru = hoSoTamTruBLL.getHoSoTamTru(gridViewHoSoTamTru.GetFocusedRowCellValue("Masv").ToString());
                txtMaIDHoSoTamTru.Text = hoSoTamTru.Mahoso.ToString();
                txtMaSVHoSoTamTru.Text = hoSoTamTru.Masv.ToString();
                txtHoTenHoSoTamTru.Text = hoSoTamTru.Hoten.ToString();
                txtNoiTamTru.Text = hoSoTamTru.Diachitamtru.ToString();
                dtNgayDenTamTru.EditValue = DateTime.Parse(hoSoTamTru.Ngayden.ToString());
                txtGhiChuHoSoTamTru.Text = hoSoTamTru.Ghichu.ToString();
            }
        }
        public void NhapLaiHoSoTamTru()
        {
            txtMaIDHoSoTamTru.Text = "";
            txtMaSVHoSoTamTru.Text = "";
            txtHoTenHoSoTamTru.Text = "";
            dtNgayDenTamTru.EditValue = "";
            txtNoiTamTru.Text = "";
            txtGhiChuHoSoTamTru.Text = "";
        }
        private void btnNhapLaiTamTru_Click(object sender, EventArgs e)
        {
            NhapLaiHoSoTamTru();
        }

        private void btnXoaTamTru_Click(object sender, EventArgs e)
        {
            if (txtMaIDHoSoTamTru.Text == "")
            {
                XtraMessageBox.Show("Vui lòng chọn hồ sơ cần xoá");
            }
            else
            {
                if (XtraMessageBox.Show($"Bạn có chắc chắn muốn xoá hồ sơ tạm trú của sinh viên {txtHoTenHoSoTamTru.Text}?", "Xác nhận xoá", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (hoSoTamTruBLL.deleteHoSoTamTru(txtMaIDHoSoTamTru.Text))
                    {
                        XtraMessageBox.Show("Xoá thành công");
                        NhapLaiHoSoTamTru();
                        loadTableAllSinhVienOfHoSoTamTru();
                    }
                    else
                    {
                        XtraMessageBox.Show("Mã sinh viên hoặc mã hồ sơ không tồn tại trong hệ thống");
                    }
                }
            }

        }

        private void btnThemMoiHoSoTamTru_Click(object sender, EventArgs e)
        {
            if (txtMaSVHoSoTamTru.Text == "" || txtNoiTamTru.Text == "" || dtNgayDenTamTru.EditValue == "")
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                HoSoTamTru hstt = new HoSoTamTru(txtMaSVHoSoTamTru.Text, txtNoiTamTru.Text, dtNgayDenTamTru.DateTime, txtGhiChuHoSoTamTru.Text);
                if (hoSoTamTruBLL.addHoSoTamTru(hstt))
                {
                    loadTableAllSinhVienOfHoSoTamTru();
                    NhapLaiHoSoTamTru();
                    XtraMessageBox.Show("Thêm thành công");
                }
                else
                {
                    XtraMessageBox.Show("Sinh viên đã tồn tại");
                }
            }
        }

        private void btnSuaTamTru_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show($"Bạn có chắc chắn muốn cập nhật hồ sơ tạm trú của sinh viên {txtHoTenHoSoTamTru.Text}?", "Xác nhận cập nhật", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (txtMaSVHoSoTamTru.Text == "" || txtNoiTamTru.Text == "" || dtNgayDenTamTru.EditValue == "")
                {
                    XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin");
                }
                else
                {
                    HoSoTamTru hstt = new HoSoTamTru(txtMaSVHoSoTamTru.Text, txtNoiTamTru.Text, dtNgayDenTamTru.DateTime, txtGhiChuHoSoTamTru.Text.ToString(), int.Parse(txtMaIDHoSoTamTru.Text));
                    if (hoSoTamTruBLL.updateHoSoTamTru(hstt))
                    {
                        loadTableAllSinhVienOfHoSoTamTru();
                        XtraMessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        XtraMessageBox.Show("Cập nhật thất bại");
                    }
                }
            }


        }

        private void btnXemListSinhVien_Click(object sender, EventArgs e)
        {
            frmListSinhVien frmListSinhVien = new frmListSinhVien(this);
            frmListSinhVien.Show();
        }
        public void SetDataFromListSV(string masv, string hoten, string diachi)
        {
            txtMaSVHoSoTamTru.Text = masv;
            txtHoTenHoSoTamTru.Text = hoten;
            txtNoiTamTru.Text = diachi;
        }

        private void loadPanelHoSoGiangVien()
        {
            LoadDataTableGiangVien("all");
            List<Khoa> khoaList = hoSoSinhVienBLl.getKhoa();
            cbGvTheoKhoa.DataSource = khoaList;
            cbGvTheoKhoa.DisplayMember = "tenkhoa";
            cbGvTheoKhoa.ValueMember = "makhoa";
            cbKhoaGV.DataSource = khoaList;
            cbKhoaGV.DisplayMember = "tenkhoa";
            cbKhoaGV.ValueMember = "makhoa";

            if (rdTatCaGV.Checked == true)
            {
                rdTatCaGVTheoKhoa.Checked = false;
            }
            else if (rdTatCaGVTheoKhoa.Checked == true)
            {
                rdTatCaGV.Checked = false;
            }
        }
        private void rdTatCaGV_CheckedChanged(object sender, EventArgs e)
        {
            cbGvTheoKhoa.Enabled = false;
            viewAllGV = true;
        }

        private void rdTatCaGVTheoKhoa_CheckedChanged(object sender, EventArgs e)
        {
            cbGvTheoKhoa.Enabled = true;
            viewAllGV = false;

        }

        private void btnLocGiangVien_Click(object sender, EventArgs e)
        {
            if (viewAllGV == true)
            {
                LoadDataTableGiangVien("all");
            }
            else
            {
                LoadDataTableGiangVien(cbKhoaGV.SelectedValue.ToString());
            }
        }
        private void LoadDataTableGiangVien(string makhoa)
        {
            dtNgaySinhGV.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            dtNgaySinhGV.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            HoSoGiangVienBLL hoSoGiangVien = new HoSoGiangVienBLL();
            List<GiangVien> giangVienList = hoSoGiangVien.getHoSoGiangVien(makhoa);
            gridControlListGiangVien.DataSource = giangVienList;
            dtGridViewGiangVien.DataSource = giangVienList;
            gridViewListGiangVien.OptionsBehavior.Editable = false;
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridViewHoSoTamTru.Columns)
            {
                column.BestFit();
            }
        }
        private void btnThemGiangVien_Click(object sender, EventArgs e)
        {

            if (txtMaGV.Text == "" || txtHoTenGV.Text == "" || selectedImagePath == "" || cbGioiTinhGV.Text == "" || dtNgaySinhGV.Text == "" || txtCCCDGV.Text == "" || txtSoDienThoaiGV.Text == "" || txtEmailGV.Text == "" || txtChuyenMonGV.Text == "" || cbKhoaGV.SelectedValue.ToString() == "")
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                if (!IsEmailValid(txtEmailGV.Text))
                {
                    XtraMessageBox.Show("Email sai định dạng");
                }
                if (!IsPhoneNumberValid(txtSoDienThoaiGV.Text))
                {
                    XtraMessageBox.Show("Số điện thoại sai định dạng");
                }
                if (!IsIdNumberValid(txtCCCDGV.Text))
                {
                    XtraMessageBox.Show("CMND / CCCD sai định dạng");
                }
                if (!IsAgeValid(dtNgaySinhGV.DateTime))
                {
                    XtraMessageBox.Show("Ngày sinh chưa đủ 18 tuổi");
                }
                if (IsEmailValid(txtEmailGV.Text) == true && IsPhoneNumberValid(txtSoDienThoaiGV.Text) == true && IsIdNumberValid(txtCCCDGV.Text) == true && IsAgeValid(dtNgaySinhGV.DateTime) == true)
                {
                    byte[] imageData = File.ReadAllBytes(selectedImagePath);
                    GiangVien gv = new GiangVien(txtMaGV.Text, txtHoTenGV.Text, imageData, cbGioiTinhGV.Text, dtNgaySinhGV.DateTime, txtCCCDGV.Text, int.Parse(txtSoDienThoaiGV.Text), txtEmailGV.Text, txtChuyenMonGV.Text, cbKhoaGV.SelectedValue.ToString());

                    if (hoSoGiangVienBLL.addHoSoGiangVien(gv))
                    {
                        XtraMessageBox.Show("Thêm thành công");
                        LoadDataTableGiangVien("all");
                        NhapLaiGiangVien();
                    }
                    else
                    {
                        XtraMessageBox.Show("Giảng viên đã tồn tại trong hệ thống");
                    }
                }
            }
        }

        private void imagePickGV_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                imagePickGV.Image = Image.FromFile(selectedImagePath);
            }
        }
        private void NhapLaiGiangVien()
        {
            txtMaGV.Text = "";
            txtHoTenGV.Text = "";
            selectedImagePath = "";
            imageSinhVien.Image = imageSinhVien.InitialImage;
            cbGioiTinh.SelectedIndex = 0;
            txtCCCDGV.Text = "";
            txtSoDienThoaiGV.Text = "";
            txtEmailGV.Text = "";
            txtChuyenMonGV.Text = "";
            cbKhoaGV.SelectedIndex = 0;
        }
        private void gridViewListGiangVien_Click(object sender, EventArgs e)
        {
            if (gridViewListGiangVien.RowCount > 0)
            {
                loadHoSoGiangVien(gridViewListGiangVien.GetFocusedRowCellValue("Magv").ToString());
            }
        }
        private void loadHoSoGiangVien(string magv)
        {
            txtMaGV.Enabled = false;
            dtNgaySinhGV.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            dtNgaySinhGV.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            GiangVien gv = hoSoGiangVienBLL.getGiangVien(magv);
            txtMaGV.Text = gv.Magv.ToUpper();
            dtNgaySinhGV.EditValue = DateTime.Parse(gv.Ngaysinh.ToString());
            txtHoTenGV.Text = gv.Hoten;
            cbGioiTinhGV.SelectedItem = gv.Gioitinh;
            txtCCCDGV.Text = gv.Cccd;
            txtEmailGV.Text = gv.Email;
            txtChuyenMonGV.Text = gv.Chuyenmon;
            txtSoDienThoaiGV.Text = '0' + gv.Sodienthoai.ToString();
            txtTaiKhoanGV.Text = gv.Taikhoan;
            Image image = ByteArrayToImage(gv.Image);
            imagePickGV.Image = image;
        }

        private void btnSuaGV_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text == "" || txtHoTenGV.Text == "" || cbGioiTinhGV.Text == "" || dtNgaySinhGV.Text == "" || txtCCCDGV.Text == "" || txtSoDienThoaiGV.Text == "" || txtEmailGV.Text == "" || txtChuyenMonGV.Text == "" || cbKhoaGV.SelectedValue.ToString() == "")
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                if (!IsEmailValid(txtEmailGV.Text))
                {
                    XtraMessageBox.Show("Email sai định dạng");
                }
                if (!IsPhoneNumberValid(txtSoDienThoaiGV.Text))
                {
                    XtraMessageBox.Show("Số điện thoại sai định dạng");
                }
                if (!IsIdNumberValid(txtCCCDGV.Text))
                {
                    XtraMessageBox.Show("CMND / CCCD sai định dạng");
                }
                if (!IsAgeValid(dtNgaySinhGV.DateTime))
                {
                    XtraMessageBox.Show("Ngày sinh chưa đủ 18 tuổi");
                }
                if (IsEmailValid(txtEmailGV.Text) == true && IsPhoneNumberValid(txtSoDienThoaiGV.Text) == true && IsIdNumberValid(txtCCCDGV.Text) == true && IsAgeValid(dtNgaySinhGV.DateTime) == true)
                {

                    if (XtraMessageBox.Show($"Bạn có chắc chắn muốn cập nhật hồ sơ của giảng viên {txtMaGV.Text}?", "Xác nhận cập nhật", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        GiangVien gv = new GiangVien(txtMaGV.Text, txtHoTenGV.Text, cbGioiTinhGV.Text, dtNgaySinhGV.DateTime, txtCCCDGV.Text, int.Parse(txtSoDienThoaiGV.Text), txtEmailGV.Text, txtChuyenMonGV.Text, cbKhoaGV.SelectedValue.ToString());
                        if (hoSoGiangVienBLL.updateHoSoGiangVien(gv))
                        {
                            XtraMessageBox.Show("Sửa thành công");
                            LoadDataTableGiangVien("all");
                            NhapLaiGiangVien();
                        }
                        else
                        {
                            XtraMessageBox.Show("Giảng viên không tồn tại trong hệ thống");
                        }
                    }
                }
            }
        }

        private void btnXoaGV_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text == "")
            {
                XtraMessageBox.Show("Vui lòng chọn giảng viên cần xoá");
            }
            else
            {
                if (XtraMessageBox.Show($"Bạn có chắc chắn muốn xoá hồ sơ của giảng viên {txtMaGV.Text}?", "Xác nhận xoá", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (hoSoGiangVienBLL.deleteHoSoGiangVien(txtMaGV.Text))
                    {
                        XtraMessageBox.Show("Xoá thành công");
                        LoadDataTableGiangVien("all");
                        NhapLaiGiangVien();
                    }
                    else
                    {
                        XtraMessageBox.Show("Giảng viên không tồn tại trong hệ thống");
                    }
                }
            }
        }

        private void btnNhapLaiGV_Click(object sender, EventArgs e)
        {
            NhapLaiGiangVien();
        }

        private void btnTaoTKGV_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text == "")
            {
                XtraMessageBox.Show("Vui lòng điền mà giảng viên");
            }
            else
            {
                if (hoSoGiangVienBLL.addUsername(GetInitials(txtHoTenGV.Text), txtMaGV.Text))
                {
                    XtraMessageBox.Show("Thêm tài khoản thành công");
                }
                else
                {
                    if (XtraMessageBox.Show($"Giảng viên {txtMaGV.Text} đã có tài khoản trên hệ thống. Bạn có muốn cập nhật lại không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        hoSoGiangVienBLL.updateUsername(GetInitials(txtHoTenGV.Text), txtMaGV.Text);
                        XtraMessageBox.Show("Cập nhật thành công");
                    }
                }
            }
        }
        static string GetInitials(string text)
        {
            string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string result = "";

            foreach (string word in words)
            {
                result += word[0];
            }

            return result.ToLower();
        }

        private void btnDoiMKGV_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text == "")
            {
                XtraMessageBox.Show("Vui lòng điền mã giảng viên");
            }
            else
            {
                id = txtMaGV.Text;
                if (hoSoGiangVienBLL.checkAvailable(txtMaGV.Text))
                {
                    strPassword = hoSoGiangVienBLL.getPassword(txtMaGV.Text);
                    DoiMatKhau doiMatKhau = new DoiMatKhau(this, strPassword);
                    doiMatKhau.Show();
                }
                else
                {
                    XtraMessageBox.Show($"Giảng viên {txtMaGV.Text} hiện tại chưa có tài khoản. Vui lòng tạo tài khoản");
                }
            }

        }
        public void updatePassword(string password)
        {
            if (hoSoGiangVienBLL.updatePassword(id, password))
            {
                XtraMessageBox.Show("Cập nhật thành công");
            }
        }

        private void btnImportExcelGV_Click(object sender, EventArgs e)
        {
            btnImportExcelGV_Click();
        }

        private void btnImportExcelGV_Click()
        {
            byte[] imageData = File.ReadAllBytes("C:\\Users\\nguye\\source\\repos\\PR_QLSV\\PR_QLSV\\GUI\\image\\hososinhvien.png");
            dtGridViewGiangVien.DataSource = null;
            dtGridViewGiangVien.Rows.Clear();
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            // Stop reading/writing a spreadsheet when the free limit is reached.
            SpreadsheetInfo.FreeLimitReached += (sender, e) => e.FreeLimitReachedAction = FreeLimitReachedAction.Stop;
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "SELECT FILE";
            file.FileName = selectedImagePath;
            file.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|" +
            "XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|" +
            "ODS files (*.ods, *.ots)|*.ods;*.ots|" +
            "CSV files (*.csv, *.tsv)|*.csv;*.tsv|" +
            "HTML files (*.html, *.htm)|*.html;*.htm";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = file.FileName;
            }
            var workbook = ExcelFile.Load(selectedImagePath);
            var worksheet = workbook.Worksheets.ActiveWorksheet;
            DataGridViewConverter.ExportToDataGridView(
                worksheet,
                this.dtGridViewGiangVien,
                new ExportToDataGridViewOptions() { ColumnHeaders = false });
            SqlConnection conn = new SqlConnection("Data Source=NGUYENTHANHCONG\\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True; MultipleActiveResultSets=true");
            conn.Open();
            for (int i = 0; i < dtGridViewGiangVien.Rows.Count - 1; i++)
            {   
                string sql = $"INSERT INTO qlgiangvien  (magv, hoten, image, gioitinh, ngaysinh, cccd, sodienthoai, email, chuyenmon, makhoa) VALUES ('{dtGridViewGiangVien.Rows[i].Cells[1].Value}', '{dtGridViewGiangVien.Rows[i].Cells[2].Value}', @image, '{dtGridViewGiangVien.Rows[i].Cells[4].Value}', '{dtGridViewGiangVien.Rows[i].Cells[5].Value}', '{dtGridViewGiangVien.Rows[i].Cells[6].Value}','{dtGridViewGiangVien.Rows[i].Cells[7].Value}', '{dtGridViewGiangVien.Rows[i].Cells[8].Value}', '{dtGridViewGiangVien.Rows[i].Cells[9].Value}', '{dtGridViewGiangVien.Rows[i].Cells[10].Value}')";
                XtraMessageBox.Show(sql);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@image", imageData);
                    cmd.ExecuteNonQuery();
                }
                
            }
            conn.Close();
            LoadDataTableGiangVien("all");

        }
        private void uploadFromTableGiangVienToSQL()
        {
            
        }
    }
}