using BLL;
using DevExpress.XtraCharts.Design;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTrangChu : DevExpress.XtraEditors.XtraForm
    {
        public static string maNguoiDung = "";
        public static string quyenNguoiDung = "";
        HoSoSinhVienBLl hoSoSinhVienBLl = new HoSoSinhVienBLl();
        private string selectedImagePath = "";
        HoSoTamTruBLL hoSoTamTruBLL = new HoSoTamTruBLL();
        public frmTrangChu()
        {
            InitializeComponent();
            quyenNguoiDung = frmDangNhap.quyenNguoiDung.ToString();
            FunctionPanelHoSoSinhVien();
            LoadPanelHoSoTamTru();
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
            foreach (GridColumn column in gridViewAllHoSoSinhVien.Columns)
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
            foreach (GridColumn column in gridViewHoSoTamTru.Columns)
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


            imageSinhVien.Image = imageSinhVien.InitialImage;
        }

        private void imageSinhVien_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
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
                    }
                    else
                    {
                        XtraMessageBox.Show("Mã sinh viên đã tồn tại trong hệ thống");
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
                HoSoTamTru hstt = new HoSoTamTru(txtMaSVHoSoTamTru.Text, txtNoiTamTru.Text, DateTime.Parse(dtNgayDenTamTru.Text.ToString()), txtGhiChuHoSoTamTru.Text);
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
                    HoSoTamTru hstt = new HoSoTamTru(txtMaSVHoSoTamTru.Text, txtNoiTamTru.Text, DateTime.Parse(dtNgayDenTamTru.Text.ToString()), txtGhiChuHoSoTamTru.Text.ToString(), int.Parse(txtMaIDHoSoTamTru.Text));
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
    }
}