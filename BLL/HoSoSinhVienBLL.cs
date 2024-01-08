using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoSoSinhVienBLl
    {
        HoSoSinhVienAccess hssvAccess = new HoSoSinhVienAccess();
        public ThongTinSinhVien getHoSoSinhVien(string masv)
        {
            return hssvAccess.HoSoSinhVien(masv);
        }
        public List<Khoa> getKhoa()
        {
            return hssvAccess.ListKhoa();
        }
        public List<Lop> getLop(string makhoa)
        {
            return hssvAccess.ListLop(makhoa);
        }
        public bool UpdateHoSoSinhVien(ThongTinSinhVien thongTinCaNhan)
        {
            return hssvAccess.UpdateHoSo(thongTinCaNhan);
        }
        public bool UpdateImage(byte[] byteImage, string masv)
        {
            return hssvAccess.UpdateImage(byteImage, masv);
        }
        public List<ThongTinSinhVien> getListSinhVien()
        {
            return hssvAccess.GetSinhVienList();
        }
        public bool AddNewSinhVien(ThongTinSinhVien ttsv)
        {
            return hssvAccess.AddNewSinhVien(ttsv);
        }
        public bool DeleteSinhVien(string masv)
        {
            return hssvAccess.DeleteSinhVien(masv);
        }
        public List<ThongTinSinhVien> getSinhVienListTamTru()
        {
            return hssvAccess.getSinhVienListTamTru();
        }


    }
}
