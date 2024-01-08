using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTO
{
    public class TaiKhoan
    {
        private string id;
        private string username;
        private string password;
        private string quyen;
        private string mathanhvien;

        public TaiKhoan()
        {

        }
        public TaiKhoan(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public TaiKhoan(string id, string username, string password, string quyen, string mathanhvien)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Quyen = quyen;
            this.mathanhvien = mathanhvien;
        }
        public TaiKhoan(string username, string password, string quyen, string mathanhvien)
        {
            this.Username = username;
            this.Password = password;
            this.Quyen = quyen;
            this.mathanhvien = mathanhvien;
        }

        public string Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Quyen { get => quyen; set => quyen = value; }
        public string MaThanhVien { get => mathanhvien; set => mathanhvien = value; }
    }
    
}