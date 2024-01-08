using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoSoTamTru
    {
        int mahoso;
        string masv;
        string hoten;
        string khoa;
        string lop;
        string diachitamtru;
        DateTime ngayden;
        string ghichu;

        public HoSoTamTru() { }
        public HoSoTamTru(int mahoso, string masv, string hoten, string khoa, string lop, string diachitamtru, DateTime ngayden, string ghichu)
        {
            this.mahoso = mahoso;
            this.masv = masv;
            this.hoten = hoten;
            this.khoa = khoa;
            this.lop = lop;
            this.diachitamtru = diachitamtru;
            this.ngayden = ngayden;
            this.ghichu = ghichu;
        }
        public HoSoTamTru(string masv, string diachitamtru, DateTime ngayden, string ghichu)
        {
            this.masv = masv;
            this.diachitamtru = diachitamtru;
            this.ngayden = ngayden;
            this.ghichu = ghichu;
        }
        public HoSoTamTru(string masv, string diachitamtru, DateTime ngayden, string ghichu, int mahoso)
        {
            this.masv = masv;
            this.diachitamtru = diachitamtru;
            this.ngayden = ngayden;
            this.ghichu = ghichu;
            this.mahoso = mahoso;
        }
        public HoSoTamTru(string masv, string hoten, string khoa, string lop, string diachitamtru, DateTime ngayden, string ghichu)
        {
            this.mahoso = mahoso;
            this.masv = masv;
            this.hoten = hoten;
            this.khoa = khoa;
            this.lop = lop;
            this.diachitamtru = diachitamtru;
            this.ngayden = ngayden;
            this.ghichu = ghichu;
        }
        public HoSoTamTru(int mahoso, string masv, string hoten, string diachitamtru, DateTime ngayden, string ghichu)
        {
            this.mahoso = mahoso;
            this.masv = masv;
            this.hoten = hoten;
            this.diachitamtru = diachitamtru;
            this.ngayden = ngayden;
            this.ghichu = ghichu;
        }

        public int Mahoso { get => mahoso; set => mahoso = value; }
        public string Masv { get => masv; set => masv = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Khoa { get => khoa; set => khoa = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Diachitamtru { get => diachitamtru; set => diachitamtru = value; }
        public DateTime Ngayden { get => ngayden; set => ngayden = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
    }
}
