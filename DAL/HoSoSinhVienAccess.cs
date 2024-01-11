using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoSoSinhVienAccess : DBConnect
    {
        public ThongTinSinhVien HoSoSinhVien(string msv)
        {
            conn.Close();
            conn.Open();
            string query = "SELECT * FROM hososv WHERE masv = @masv";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@masv", msv);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[] byteArray = (byte[])reader[2];
                        return new ThongTinSinhVien(reader[0].ToString(), int.Parse(reader[1].ToString()), byteArray, reader[3].ToString(), DateTime.Parse(reader[4].ToString()), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), int.Parse(reader[11].ToString()), int.Parse(reader[12].ToString()), reader[13].ToString(), reader[14].ToString(), reader[15].ToString(), reader[16].ToString(), reader[17].ToString(), reader[18].ToString());
                        
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            
        }
        public List<ThongTinSinhVien> GetSinhVienList()
        {
            conn.Close();
            conn.Open();
            List<ThongTinSinhVien> sinhVienList = new List<ThongTinSinhVien>();
            string query = "SELECT * FROM hososv";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        byte[] byteArray = (byte[])reader[2];
                        ThongTinSinhVien sinhVien = new ThongTinSinhVien(reader[0].ToString(), int.Parse(reader[1].ToString()), byteArray, reader[3].ToString(), DateTime.Parse(reader[4].ToString()), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), int.Parse(reader[11].ToString()), int.Parse(reader[12].ToString()), reader[13].ToString(), reader[14].ToString(), reader[15].ToString(), reader[16].ToString(), reader[17].ToString(), reader[18].ToString()); ;
                        sinhVienList.Add(sinhVien);
                    }
                }
            }
            return sinhVienList;

        }
        public List<ThongTinSinhVien> getSinhVienListTamTru()
        {
            conn.Close();
            conn.Open();
            List<ThongTinSinhVien> sinhVienL = new List<ThongTinSinhVien>();
            string query = "SELECT masv, hoten FROM hososv";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {   
                        using (SqlCommand cmd = new SqlCommand($"SELECT diachitamtru FROM hosotamtru WHERE masv = '{reader[0].ToString()}'", conn))
                        
                        {
                            using (SqlDataReader r = cmd.ExecuteReader()) {
                                if (r.Read())
                                {
                                    ThongTinSinhVien sinhVien = new ThongTinSinhVien(reader[0].ToString(), reader[1].ToString(), r[0].ToString());
                                    sinhVienL.Add(sinhVien);
                                }
                                else
                                {
                                    ThongTinSinhVien sinhVien = new ThongTinSinhVien(reader[0].ToString(), reader[1].ToString(), "");
                                    sinhVienL.Add(sinhVien);
                                }
                            }

                        }
                    }
                }
            }
            return sinhVienL;

        }

        public List<Khoa> ListKhoa()
        {
            conn.Close();
            conn.Open();
            List<Khoa> khoaList = new List<Khoa>();
            string query = "SELECT * FROM khoa";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Khoa khoa = new Khoa(reader[0].ToString(), reader[1].ToString());
                        khoaList.Add(khoa);
                    }
                    conn.Close();
                }
            }
            conn.Close();
            return khoaList;

        }
        public List<Lop> ListLop(string makhoa)
        {   conn.Close();
            conn.Open();
            List<Lop> lopList = new List<Lop>();
            string query = $"SELECT * FROM lop WHERE makhoa = '{makhoa}'";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lop lop = new Lop(reader[0].ToString(), int.Parse(reader[1].ToString()), reader[2].ToString());
                        lopList.Add(lop);
                    }
                    conn.Close();
                }
            }
            conn.Close();
            return lopList;
        }
        public bool UpdateHoSo(ThongTinSinhVien tt)
        {
            conn.Close();
            try
            {
                conn.Open();
                string SQL = string.Format($"UPDATE hososv SET namnhaphoc = '{tt.Namnhaphoc}', hoten = N'{tt.Hoten}', ngaysinh = '{tt.Ngaysinh}',gioitinh = N'{tt.Gioitinh}',hedaotao = N'{tt.Hedaotao}',dantoc = N'{tt.Dantoc}',khoa = N'{tt.Khoa}',tenlop = N'{tt.Lop}',tinhtrang = N'{tt.Tinhtrang}', cccd = '{tt.Cccd}', sodienthoai = '{tt.Sodienthoai}', email = '{tt.Email}', hotenbo = N'{tt.Hotenbo}', nghebo = N'{tt.Nghebo}', hotenme = N'{tt.Hotenme}', ngheme = N'{tt.Ngheme}', diachi = N'{tt.Diachi}' WHERE masv = '{tt.Masv}'");

                SqlCommand cmd = new SqlCommand(SQL, conn);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
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
        public bool UpdateImage(byte[] byteImage, string masv)
        {
            conn.Close();
            try
            {
                conn.Open();
                string SQL = string.Format($"UPDATE hososv SET image = @image WHERE masv = '{masv}'");

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@image", byteImage);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
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
        public bool AddNewSinhVien(ThongTinSinhVien ttsv)
        {
            conn.Close();
            try
            {
                conn.Open();

                string SQL = string.Format("INSERT INTO hososv(masv, namnhaphoc, image ,hoten, ngaysinh, gioitinh, hedaotao, dantoc, khoa, tenlop, tinhtrang, cccd, sodienthoai, email, hotenbo,nghebo, hotenme,ngheme, diachi) VALUES (@masv, @namnhaphoc, @image, @hoten, @ngaysinh, @gioitinh, @hedaotao, @dantoc, @khoa, @tenlop, @tinhtrang,  @cccd, @sodienthoai, @email, @hotenbo, @nghebo, @hotenme, @ngheme, @diachi)");

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@masv", ttsv.Masv);
                cmd.Parameters.AddWithValue("@namnhaphoc", ttsv.Namnhaphoc);
                cmd.Parameters.AddWithValue("@image", ttsv.Image);
                cmd.Parameters.AddWithValue("@hoten", ttsv.Hoten);
                cmd.Parameters.AddWithValue("@ngaysinh", ttsv.Ngaysinh);
                cmd.Parameters.AddWithValue("@gioitinh", ttsv.Gioitinh);
                cmd.Parameters.AddWithValue("@hedaotao", ttsv.Hedaotao);
                cmd.Parameters.AddWithValue("@dantoc", ttsv.Dantoc);
                cmd.Parameters.AddWithValue("@khoa", ttsv.Khoa);
                cmd.Parameters.AddWithValue("@tenlop", ttsv.Lop);
                cmd.Parameters.AddWithValue("@tinhtrang", ttsv.Tinhtrang);
                cmd.Parameters.AddWithValue("@cccd", ttsv.Cccd);
                cmd.Parameters.AddWithValue("@sodienthoai", ttsv.Sodienthoai);
                cmd.Parameters.AddWithValue("@email", ttsv.Email);
                cmd.Parameters.AddWithValue("@hotenbo", ttsv.Hotenbo);
                cmd.Parameters.AddWithValue("@nghebo", ttsv.Nghebo);
                cmd.Parameters.AddWithValue("@hotenme", ttsv.Hotenme);
                cmd.Parameters.AddWithValue("@ngheme", ttsv.Ngheme);
                cmd.Parameters.AddWithValue("@diachi", ttsv.Diachi);


                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }

            return false;
        }
        public bool DeleteSinhVien(string masv)
        {
            try
            {
                conn.Close();
                conn.Open();

                string SQL = string.Format("DELETE FROM hososv WHERE masv = @masv");

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@masv", masv);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }


    }
}
