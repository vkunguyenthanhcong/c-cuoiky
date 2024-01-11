using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoSoGiangVienBLL
    {
        HoSoGiangVienAccess hsgv = new HoSoGiangVienAccess();
        public List<GiangVien> getHoSoGiangVien(string makhoa)
        {
            return hsgv.getListGiangVien(makhoa);
        }
        public bool addHoSoGiangVien(GiangVien gv)
        {
            return hsgv.addHoSoGiangVien(gv);
        }
        public bool deleteHoSoGiangVien(string magv)
        {
            return hsgv.deleteHoSoGiangVien(magv);
        }
        public bool updateHoSoGiangVien(GiangVien gv)
        {
            return hsgv.updateHoSoGiangVien(gv);
        }
        public GiangVien getGiangVien(string magv)
        {
            return hsgv.GetGiangVien(magv);
        }
        public bool addUsername(string username, string magv)
        {
            return hsgv.addUsername(username, magv);
        }
        public bool updateUsername(string username, string magv)
        {
            return hsgv.updateUsername(username, magv);
        }
        public bool checkAvailable(string id)
        {
            return hsgv.checkAvailable(id);
        }
        public string getPassword(string id)
        {
            return hsgv.getPassword(id);
        }
        public bool updatePassword(string id, string password)
        {
            return hsgv.updatePassword(id, password);
        }
        public void importExcelGV(string filePath)
        {
            hsgv.importExcelGV(filePath);
        }
    }
}
