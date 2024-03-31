using DTO;
using SecurityLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanAccessDAL:DataAccessDAL
    {
        public string checklogin( TaiKhoanDTO taiKhoanDTO)
        {
            
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"check_login", sqlConnection))
                    {
                        string user = null;
                    
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@user", taiKhoanDTO.taikhoan);
                        sqlCommand.Parameters.AddWithValue("@pass", taiKhoanDTO.matkhau);
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                user = reader.GetString(1);
                            }
                            reader.Close();
                            sqlConnection.Close();
                        }
                        else
                        {
                            return "tk mk sai";
                        }
                        return user;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi  : {ex.Message}");
                throw;
            }
        }
        public bool doimk(TaiKhoanDTO taiKhoanDTO)
        {
            
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"update Taikhoan set matkhau=@matkhau where taikhoan=@taikhoan",sqlConnection))
                    {
                        string check = checklogin(taiKhoanDTO);
                        if (check != null)
                        {
                            sqlCommand.Connection = sqlConnection;
                            sqlCommand.Parameters.AddWithValue("@matkhau", PasswordHasher.HashPassword(taiKhoanDTO.matkhau));
                            sqlCommand.Parameters.AddWithValue("@taikhoan", taiKhoanDTO.taikhoan);
                            int kq = sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                            return kq > 0;
                        }
                        else { return false; }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi  : {ex.Message}");
                throw;
            }


        }

        public bool checkTk(TaiKhoanDTO taiKhoanDTO)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("select taikhoan from Taikhoan where taikhoan=@taikhoan", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@taikhoan", taiKhoanDTO.taikhoan);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        bool kq = sqlDataReader.HasRows;
                        sqlDataReader.Close();
                        return kq;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi  : {ex.Message}");
                throw;
            }
        }
        public bool checkMadangnhap(TaiKhoanDTO taiKhoanDTO)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select magiaovien from Taikhoan where magiaovien=@magiaovien", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@magiaovien", taiKhoanDTO.magv);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        bool kq = sqlDataReader.HasRows;
                        sqlDataReader.Close();
                        
                        return kq;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi  : {ex.Message}");
                throw;
            }
        }
        public bool checkMadangnhapGV(TaiKhoanDTO taiKhoanDTO)
        {

            
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select giaovienID from GiaoVien where giaovienID=@magiaovien ", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@magiaovien", taiKhoanDTO.magv);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        bool kq = sqlDataReader.HasRows;
                        sqlDataReader.Close();
                        
                        return kq;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi  : {ex.Message}");
                throw;
            }
        }
        public bool DkTK(TaiKhoanDTO taiKhoanDTO)
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"insert into Taikhoan values(@taikhoan, @matkhau,@ma)",sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@taikhoan", taiKhoanDTO.taikhoan);
                        sqlCommand.Parameters.AddWithValue("@matkhau", taiKhoanDTO.matkhau);
                        sqlCommand.Parameters.AddWithValue("@ma", taiKhoanDTO.magv);
                        int kq = sqlCommand.ExecuteNonQuery();
                        
                        return kq > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi  : {ex.Message}");
                throw;
            }
        }
        public string checkquyen(TaiKhoanDTO taiKhoanDTO)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select maquyen from Taikhoan  where taikhoan=@taikhoan"))
                    {
                        string quyen = string.Empty;
                        var result = sqlCommand.ExecuteScalar();
                        if (result != null)
                        {
                            quyen = result.ToString();
                        }
                        return quyen;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi  : {ex.Message}");
                throw;
            }
        }
    }
}
