using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoSoTamTruAccess : DBConnect
    {
        public List<HoSoTamTru> AllHoSoTamTru()
        {
            conn.Close();
            conn.Open();
            List<HoSoTamTru> hoSoTamTruList = new List<HoSoTamTru>();
            string query = "SELECT a.mahoso, a.masv, b.hoten, b.khoa, b.tenlop, a.diachitamtru, a.ngayden, a.ghichu FROM hosotamtru a, hososv b where a.masv = b.masv";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoSoTamTru hoSoTamTru = new HoSoTamTru(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), DateTime.Parse(reader[6].ToString()) , reader[7].ToString()); ;
                        hoSoTamTruList.Add(hoSoTamTru);
                    }
                }
            }
            return hoSoTamTruList;
        }
        public List<HoSoTamTru> AllHoSoTamTruTheoKhoa(string makhoa)
        {
            conn.Close();
            conn.Open();
            List<HoSoTamTru> hoSoTamTruList = new List<HoSoTamTru>();
            string query = "SELECT a.mahoso, a.masv, b.hoten, b.khoa, b.tenlop, a.diachitamtru, a.ngayden, a.ghichu FROM hosotamtru a, hososv b where a.masv = b.masv and b.khoa = @makhoa";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@makhoa", makhoa);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoSoTamTru hoSoTamTru = new HoSoTamTru(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), DateTime.Parse(reader[6].ToString()), reader[7].ToString()); ;
                        hoSoTamTruList.Add(hoSoTamTru);
                    }
                }
            }
            return hoSoTamTruList;
        }
        public List<HoSoTamTru> AllHoSoTamTruTheoLop(string tenlop)
        {
            conn.Close();
            conn.Open();
            List<HoSoTamTru> hoSoTamTruList = new List<HoSoTamTru>();
            string query = "SELECT a.mahoso, a.masv, b.hoten, b.khoa, b.tenlop, a.diachitamtru, a.ngayden, a.ghichu FROM hosotamtru a, hososv b where a.masv = b.masv and b.tenlop = @tenlop";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@tenlop", tenlop);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoSoTamTru hoSoTamTru = new HoSoTamTru(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), DateTime.Parse(reader[6].ToString()), reader[7].ToString());
                        hoSoTamTruList.Add(hoSoTamTru);
                    }
                }
            }
            return hoSoTamTruList;
        }
        public HoSoTamTru getHoSoTamTru(string msv)
        {
            conn.Close();
            conn.Open();
            string query = "SELECT a.mahoso, a.masv, b.hoten, a.diachitamtru, a.ngayden, a.ghichu FROM hosotamtru a, hososv b where a.masv = b.masv and a.masv = @masv";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@masv", msv);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       return new HoSoTamTru(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), DateTime.Parse(reader[4].ToString()), reader[5].ToString());
                    }
                    else
                    {
                        return null;
                    }
                }
            }

        }
        public bool deleteHoSoTamTru(string hosoid)
        {
            try
            {
                conn.Close();
                conn.Open();

                string SQL = string.Format("DELETE FROM hosotamtru WHERE mahoso = @mahoso");

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@mahoso", hosoid);

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
        public bool AddHoSoTamTru(HoSoTamTru hstt)
        {
            conn.Close();
            try
            {
                conn.Open();

                string SQL = string.Format("INSERT INTO hosotamtru(masv, diachitamtru ,ngayden, ghichu) VALUES ('{0}',N'{1}','{2}',N'{3}')", hstt.Masv, hstt.Diachitamtru, hstt.Ngayden, hstt.Ghichu);

                SqlCommand cmd = new SqlCommand(SQL, conn);

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
        public bool updateHoSoTamTru(HoSoTamTru hstt)
        {
            conn.Close();
            try
            {
                conn.Open();

                string SQL = string.Format("UPDATE hosotamtru SET masv = '{0}', diachitamtru = N'{1}', ngayden = '{2}', ghichu = N'{3}' WHERE mahoso = '{4}'", hstt.Masv, hstt.Diachitamtru, hstt.Ngayden, hstt.Ghichu, hstt.Mahoso);

                SqlCommand cmd = new SqlCommand(SQL, conn);

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
    }

}
