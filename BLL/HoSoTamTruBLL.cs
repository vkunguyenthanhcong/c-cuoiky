using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoSoTamTruBLL
    {
        HoSoTamTruAccess hstamtru = new HoSoTamTruAccess();
        public List<HoSoTamTru> getAllHoSoTamTru()
        {
            return hstamtru.AllHoSoTamTru();
        }
        public List<HoSoTamTru> getAllHoSoTamTruTheoKhoa(string makhoa)
        {
            return hstamtru.AllHoSoTamTruTheoKhoa(makhoa);
        }
        public List<HoSoTamTru> getAllHoSoTamTruTheoLop(string tenlop)
        {
            return hstamtru.AllHoSoTamTruTheoLop(tenlop);
        }
        public HoSoTamTru getHoSoTamTru(string masv)
        {
            return hstamtru.getHoSoTamTru(masv);
        }
        public bool deleteHoSoTamTru(string hosoid)
        {
            return hstamtru.deleteHoSoTamTru(hosoid);
        }
        public bool addHoSoTamTru(HoSoTamTru hoSoTamTru)
        {
            return hstamtru.AddHoSoTamTru(hoSoTamTru);
        }
        public bool updateHoSoTamTru(HoSoTamTru hoSoTamTru)
        {
            return hstamtru.updateHoSoTamTru(hoSoTamTru);
        }
    }
}
