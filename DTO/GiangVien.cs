using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiangVien
    {
        string magv;
        string hoten;
        byte[] image;
        string gioitinh;
        DateTime ngaysinh;
        string cccd;
        int sodienthoai;
        string email;
        string chuyenmon;
        string makhoa;
        string taikhoan;
        public GiangVien(string magv, string hoten, string gioitinh, DateTime ngaysinh, string cccd, int sodienthoai, string email, string chuyenmon, string makhoa)
        {
            this.magv = magv;
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.cccd = cccd;
            this.sodienthoai = sodienthoai;
            this.email = email;
            this.chuyenmon = chuyenmon;
            this.makhoa = makhoa;
        }

        public GiangVien(string magv, string hoten, byte[] image, string gioitinh, DateTime ngaysinh, string cccd, int sodienthoai, string email, string chuyenmon, string makhoa)
        {
            this.magv = magv;
            this.hoten = hoten;
            this.image = image;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.cccd = cccd;
            this.sodienthoai = sodienthoai;
            this.email = email;
            this.chuyenmon = chuyenmon;
            this.makhoa = makhoa;
        }
        public GiangVien(string magv, string hoten, byte[] image, string gioitinh, DateTime ngaysinh, string cccd, int sodienthoai, string email, string chuyenmon, string makhoa, string taikhoan)
        {
            this.magv = magv;
            this.hoten = hoten;
            this.image = image;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.cccd = cccd;
            this.sodienthoai = sodienthoai;
            this.email = email;
            this.chuyenmon = chuyenmon;
            this.makhoa = makhoa;
            this.taikhoan = taikhoan;
        }

        public string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Magv { get => magv; set => magv = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public byte[] Image { get => image; set => image = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Cccd { get => cccd; set => cccd = value; }
        public int Sodienthoai { get => sodienthoai; set => sodienthoai = value; }
        public string Email { get => email; set => email = value; }
        public string Chuyenmon { get => chuyenmon; set => chuyenmon = value; }
        public string Makhoa { get => makhoa; set => makhoa = value; }
    }
}
