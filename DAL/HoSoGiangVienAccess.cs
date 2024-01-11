using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;
using Range = Microsoft.Office.Interop.Excel.Range;
using Microsoft.Office.Interop.Excel;

namespace DAL
{
    public class HoSoGiangVienAccess : DBConnect
    {
        public List<GiangVien> getListGiangVien(string makhoa)
        {
            conn.Close();
            conn.Open();
            List<GiangVien> giangVienList = new List<GiangVien>();
            string query = "";
            if (makhoa == "all")
            {
                query = "SELECT * FROM qlgiangvien";
            }
            else
            {
                query = $"SELECT * FROM qlgiangvien WHERE makhoa = '{makhoa}'";
            }
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string q = $"SELECT username FROM [user] WHERE manguoidung = '{reader[0].ToString()}'";
                        SqlCommand cmd = new SqlCommand(q, conn);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                byte[] byteArray = (byte[])reader[2];
                                GiangVien gv = new GiangVien(reader[0].ToString(), reader[1].ToString(), byteArray, reader[3].ToString(), DateTime.Parse(reader[4].ToString()), reader[5].ToString(), int.Parse(reader[6].ToString()), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), r[0].ToString()); ;
                                giangVienList.Add(gv);
                            }
                            else
                            {
                                byte[] byteArray = (byte[])reader[2];
                                GiangVien gv = new GiangVien(reader[0].ToString(), reader[1].ToString(), byteArray, reader[3].ToString(), DateTime.Parse(reader[4].ToString()), reader[5].ToString(), int.Parse(reader[6].ToString()), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), ""); ;
                                giangVienList.Add(gv);
                            }
                        }

                        
                    }
                }
            }
            return giangVienList;
        }
        public GiangVien GetGiangVien(string magv)
        {
            conn.Close();
            conn.Open();
            string query = "SELECT * FROM qlgiangvien WHERE magv = @magv";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@magv", magv);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string q = $"SELECT username FROM [user] WHERE manguoidung = '{magv}'";
                        SqlCommand command = new SqlCommand(q, conn);
                        using (SqlDataReader r = command.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                byte[] byteArray = (byte[])reader[2];
                                return new GiangVien(reader[0].ToString(), reader[1].ToString(), byteArray, reader[3].ToString(), DateTime.Parse(reader[4].ToString()), reader[5].ToString(), int.Parse(reader[6].ToString()), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), r[0].ToString());
                            }
                            else
                            {
                                byte[] byteArray = (byte[])reader[2];
                                return new GiangVien(reader[0].ToString(), reader[1].ToString(), byteArray, reader[3].ToString(), DateTime.Parse(reader[4].ToString()), reader[5].ToString(), int.Parse(reader[6].ToString()), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), "");
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }

        }
        public bool addHoSoGiangVien(GiangVien gv)
        {
            conn.Close();
            try
            {
                conn.Open();

                string SQL = string.Format("INSERT INTO qlgiangvien(magv, hoten, image, gioitinh, ngaysinh, cccd, sodienthoai, email, chuyenmon, makhoa) VALUES (@magv, @hoten, @image, @gioitinh, @ngaysinh, @cccd, @sodienthoai, @email, @chuyenmon, @makhoa)");

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@magv", gv.Magv);
                cmd.Parameters.AddWithValue("@hoten", gv.Hoten);
                cmd.Parameters.AddWithValue("@image", gv.Image);
                cmd.Parameters.AddWithValue("@gioitinh", gv.Gioitinh);
                cmd.Parameters.AddWithValue("@ngaysinh", gv.Ngaysinh);
                cmd.Parameters.AddWithValue("@cccd", gv.Cccd);
                cmd.Parameters.AddWithValue("@sodienthoai", gv.Sodienthoai);
                cmd.Parameters.AddWithValue("@email", gv.Email);
                cmd.Parameters.AddWithValue("@chuyenmon", gv.Chuyenmon);
                cmd.Parameters.AddWithValue("@makhoa", gv.Makhoa);


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
        public bool updateHoSoGiangVien(GiangVien gv)
        {
            conn.Close();
            try
            {
                conn.Open();

                string SQL = string.Format("UPDATE qlgiangvien SET hoten = @hoten, gioitinh = @gioitinh, ngaysinh = @ngaysinh, cccd = @cccd, sodienthoai = @sodienthoai, email = @email, chuyenmon = @chuyenmon, makhoa = @makhoa WHERE magv = @magv");

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@magv", gv.Magv);
                cmd.Parameters.AddWithValue("@hoten", gv.Hoten);
                cmd.Parameters.AddWithValue("@gioitinh", gv.Gioitinh);
                cmd.Parameters.AddWithValue("@ngaysinh", gv.Ngaysinh);
                cmd.Parameters.AddWithValue("@cccd", gv.Cccd);
                cmd.Parameters.AddWithValue("@sodienthoai", gv.Sodienthoai);
                cmd.Parameters.AddWithValue("@email", gv.Email);
                cmd.Parameters.AddWithValue("@chuyenmon", gv.Chuyenmon);
                cmd.Parameters.AddWithValue("@makhoa", gv.Makhoa);
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
        public bool deleteHoSoGiangVien(string magv)
        {
            conn.Close();
            try
            {
                conn.Open();

                string SQL = string.Format($"DELETE FROM qlgiangvien WHERE magv = '{magv}'");

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
        
        public bool addUsername(string username, string magv)
        {
            try
            {
                conn.Close();
                conn.Open();
                string sql = $"INSERT INTO [user] (username, password, quyen, manguoidung) VALUES('{username}', '123', N'Giảng Viên', '{magv}')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (cmd.ExecuteNonQuery() > 0)
                        return true;
                }
                
            }catch (Exception e) { }
            finally { conn.Close(); }
            return false;
        }
        public bool updateUsername(string username, string magv) {
        try
        {
                conn.Close();
                conn.Open();
                string sql = $"UPDATE [user] SET username = '{username}' WHERE manguoidung = '{magv}'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (cmd.ExecuteNonQuery() > 0)
                        return true;
                }

            }
            catch (Exception e) { }
            finally { conn.Close(); }
            return false;
        }

        public bool checkAvailable(string id)
        {
            conn.Close();
            try
            {
                conn.Open();
                string SQL = string.Format("SELECT * FROM [user] WHERE manguoidung = '{0}'", id);

                SqlCommand cmd = new SqlCommand(SQL, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
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
        public string getPassword(string id)
        {
            conn.Close();
            conn.Open();
            string query = $"SELECT password FROM [user] WHERE manguoidung = '{id}'";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader[0].ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public bool updatePassword(string id, string password)
        {
            conn.Close();
            conn.Open();
            try
            {
                string SQL = string.Format($"UPDATE [user] SET password = '{password}' where manguoidung = '{id}'");
                Console.WriteLine(SQL);
                SqlCommand cmd = new SqlCommand(SQL, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
            return false;
        }
        public void importExcelGV(string excelFilePath)
        {
            try
            {
                // Open the Excel file and retrieve the data
                Application excel = new Application();
                Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Open(excelFilePath);

                // Loop through all the sheets in the workbook
                for (int i = 1; i <= wb.Sheets.Count; i++)
                {
                    // Retrieve the data from the sheet
                    Worksheet sheet = (Worksheet)wb.Sheets[i];
                    Range range = sheet.UsedRange;

                    // Create a connection to the Excel file
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();

                        // Retrieve the data using a DataSet or DataTable
                        System.Data.DataTable data = new System.Data.DataTable();
                        OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + sheet.Name + "$]", connection);
                        adapter.Fill(data);

                        // Close the connection to the Excel file
                        connection.Close();

                        // Create a connection to the SQL Server database
                        
                            conn.Open();

                            // Insert the data into the desired table
                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                            {
                                bulkCopy.DestinationTableName = "qlgiangvien";
                                bulkCopy.WriteToServer(data);
                            }

                            // Close the connection to the SQL Server database
                            conn.Close();
                        
                    }
                }

                // Close the Excel file
                wb.Close();
                excel.Quit();
            }

            catch (Exception exception)
            {
               

            }


        }
    }
}
