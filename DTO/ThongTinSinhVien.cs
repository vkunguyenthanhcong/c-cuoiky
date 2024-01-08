using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongTinSinhVien
    {
        string masv;
        int namnhaphoc;
        byte[] image;
        string hoten;
        DateTime ngaysinh;
        string gioitinh;
        string hedaotao;
        string dantoc;
        string khoa;
        string lop;
        string tinhtrang;
        int cccd;
        int sodienthoai;
        string email;
        string hotenbo;
        string hotenme;
        string nghebo;
        string ngheme;
        string diachi;

        string tamtru;

        public string Tamtru { get => tamtru; set => tamtru = value; }
        public string Masv { get => masv; set => masv = value; }
        public int Namnhaphoc { get => namnhaphoc; set => namnhaphoc = value; }
        public byte[] Image { get => image; set => image = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Hedaotao { get => hedaotao; set => hedaotao = value; }
        public string Dantoc { get => dantoc; set => dantoc = value; }
        public string Khoa { get => khoa; set => khoa = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
        public int Cccd { get => cccd; set => cccd = value; }
        public int Sodienthoai { get => sodienthoai; set => sodienthoai = value; }
        public string Email { get => email; set => email = value; }
        public string Hotenbo { get => hotenbo; set => hotenbo = value; }
        public string Hotenme { get => hotenme; set => hotenme = value; }
        public string Nghebo { get => nghebo; set => nghebo = value; }
        public string Ngheme { get => ngheme; set => ngheme = value; }
        public string Diachi { get => diachi; set => diachi = value; }

        public ThongTinSinhVien() { }
        public ThongTinSinhVien(byte[] image) {
            this.Image = image;
        }
        
        public ThongTinSinhVien(string masv, int namnhaphoc, byte[] image, string hoten, DateTime ngaysinh, string gioitinh, string hedaotao, string dantoc, string khoa, string lop, string tinhtrang, int cccd, int sodienthoai, string email, string hotenbo, string hotenme, string nghebo, string ngheme, string diachi)
        {
            this.Masv = masv;
            this.Namnhaphoc = namnhaphoc;
            this.Image = image;
            this.Hoten = hoten;
            this.Ngaysinh = ngaysinh;
            this.Gioitinh = gioitinh;
            this.Hedaotao = hedaotao;
            this.Dantoc = dantoc;
            this.Khoa = khoa;
            this.Lop = lop;
            this.Tinhtrang = tinhtrang;
            this.Cccd = cccd;
            this.Sodienthoai = sodienthoai;
            this.Email = email;
            this.Hotenbo = hotenbo;
            this.Hotenme = hotenme;
            this.Nghebo = nghebo;
            this.Ngheme = ngheme;
            this.Diachi = diachi;
        }
        public ThongTinSinhVien(string masv, string hoten)
        {
            this.Masv = masv;
            this.Hoten = hoten;
        }
        public ThongTinSinhVien(string masv, string hoten, string tamtru) 
        {
            this.Masv = masv;
            this.Hoten = hoten;
            this.Tamtru = tamtru;
        }
        public ThongTinSinhVien(string masv, int namnhaphoc , string hoten, DateTime ngaysinh, string gioitinh, string hedaotao, string dantoc, string khoa, string lop, string tinhtrang, int cccd, int sodienthoai, string email, string hotenbo, string hotenme, string nghebo, string ngheme, string diachi)
        {
            this.Masv = masv;
            this.Namnhaphoc = namnhaphoc;
            this.Hoten = hoten;
            this.Ngaysinh = ngaysinh;
            this.Gioitinh = gioitinh;
            this.Hedaotao = hedaotao;
            this.Dantoc = dantoc;
            this.Khoa = khoa;
            this.Lop = lop;
            this.Tinhtrang = tinhtrang;
            this.Cccd = cccd;
            this.Sodienthoai = sodienthoai;
            this.Email = email;
            this.Hotenbo = hotenbo;
            this.Hotenme = hotenme;
            this.Nghebo = nghebo;
            this.Ngheme = ngheme;
            this.Diachi = diachi;
        }
        public ThongTinSinhVien(string masv, int cccd, int sodienthoai, string email, string hotenbo, string hotenme, string nghebo, string ngheme, string diachi)
        {
            this.Masv = masv;
            this.Cccd = cccd;
            this.Sodienthoai = sodienthoai;
            this.Email = email;
            this.Hotenbo = hotenbo;
            this.Hotenme = hotenme;
            this.Nghebo = nghebo;
            this.Ngheme = ngheme;
            this.Diachi = diachi;
        }

    }
}
