using DAL;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanAcess tkAccess = new TaiKhoanAcess();
        public bool CheckLogic(TaiKhoan taikhoan)
        {
            return tkAccess.CheckLogic(taikhoan);
        }
        public TaiKhoan getTaiKhoanDangNhap(TaiKhoan taikhoan)
        {
            return tkAccess.getTaiKhoanDangNhap(taikhoan);
        }
        
       
    }
}