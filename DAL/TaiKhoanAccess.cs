using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class TaiKhoanAcess : DBConnect
    {
        public bool CheckLogic(TaiKhoan taikhoan)
        {
            try
            {
                conn.Open();
                string SQL = string.Format("SELECT * FROM [user] WHERE username = '{0}' and password = '{1}'", taikhoan.Username, taikhoan.Password);
         
                SqlCommand cmd = new SqlCommand(SQL, conn);
                SqlDataReader reader = cmd.ExecuteReader();
       
                if (reader.HasRows) {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
            return false;
        }
        public TaiKhoan getTaiKhoanDangNhap(TaiKhoan taiKhoan)
        {
            conn.Close();
            conn.Open();
            string query = "SELECT * FROM [user] WHERE username = @username and password = @password";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", taiKhoan.Username);
                cmd.Parameters.AddWithValue("@password", taiKhoan.Password);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {                    
                        return new TaiKhoan(reader["username"].ToString(), reader["password"].ToString(), reader["quyen"].ToString(), reader["manguoidung"].ToString());
                    }
                    else
                    {
                        return null;
                    }
                }
            }

        }
        
    }
}