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
    public class DiemTNAccessDAL : DataAccessDAL
    {
        public DataTable laydiemtotnghiep()
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select madiemtotnghiep, DiemTotNghiep.mahs, tenHS,DiemTotNghiep.malop,diemmon1,diemmon2, diemmon3,tinhtrang  from DiemTotNghiep,HocSinh where DiemTotNghiep.mahs=HocSinh.hocsinhID   order by  DiemTotNghiep.stt desc", sqlConnection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        
                        return dt;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi  : {ex.Message}");
                throw;
            }
        }
        public bool themdiem(DiemTotNghiepDTO dto)
        {
            
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"insert into DiemTotNghiep(madiemtotnghiep,mahs,malop,diemmon1,diemmon2,diemmon3) values (@madiemtotnghiep,@mahs,@malop,@diemmon1,@diemmon2,@diemmon3)", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@madiemtotnghiep", dto.madiemtotnghiep);
                        sqlCommand.Parameters.AddWithValue("@diemmon1", dto.diemmon1);
                        sqlCommand.Parameters.AddWithValue("@diemmon2", dto.diemmon2);
                        sqlCommand.Parameters.AddWithValue("@diemmon3", dto.diemmon3);
                        sqlCommand.Parameters.AddWithValue("@mahs", dto.mahs);
                        sqlCommand.Parameters.AddWithValue("@malop", dto.malop);
                        sqlCommand.Connection = sqlConnection;
                        int kq = sqlCommand.ExecuteNonQuery();
                        return kq > 0;

                       
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");
                throw;
            }
        }
        public bool SuaDiem(DiemTotNghiepDTO dto)
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"update DiemTotNghiep set madiemtotnghiep=@madiemtotnghiep, malop=@malop, diemmon1=@diemmon1, diemmon2=@diemmon2, diemmon3=@diemmon3 where mahs=@mahs", sqlConnection))
                    {
                        cmd.Connection = sqlConnection;
                        cmd.Parameters.AddWithValue("@madiemtotnghiep", dto.madiemtotnghiep);
                        cmd.Parameters.AddWithValue("@diemmon1", dto.diemmon1);
                        cmd.Parameters.AddWithValue("@diemmon2", dto.diemmon2);
                        cmd.Parameters.AddWithValue("@diemmon3", dto.diemmon3);
                        cmd.Parameters.AddWithValue("@mahs", dto.mahs);
                        cmd.Parameters.AddWithValue("@malop", dto.malop);
                        int kq = cmd.ExecuteNonQuery();
                        
                        return kq > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");
                throw;
            }

        }
        public bool Xoa(DiemTotNghiepDTO dto)
        {
           
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"delete from DiemTotNghiep where madiemtotnghiep=@madiemtotnghiep", sqlConnection))
                    {
                        cmd.Connection = sqlConnection;
                        cmd.Parameters.AddWithValue("@madiemtotnghiep", dto.madiemtotnghiep);
                        int kq = cmd.ExecuteNonQuery();
                        
                        return kq > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");
                throw;
            }
        }
        public DataTable timkiemdiemTN(DiemTotNghiepDTO diemTotNghiepDTO)
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@" select DiemTotNghiep.mahs, tenHS,DiemTotNghiep.malop,diemmon1,diemmon2, diemmon3,tinhtrang  from DiemTotNghiep,HocSinh where mahs=@mahs and tenHS like @tenHS and DiemTotNghiep.mahs=HocSinh.hocsinhID", sqlConnection))

                    {
                        sqlCommand.Parameters.AddWithValue("mahs", diemTotNghiepDTO.mahs);
                        sqlCommand.Parameters.AddWithValue("tenHS", "%" + diemTotNghiepDTO.tenHS + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        sqlConnection.Close();
                        return dt;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi  : {ex.Message}");
                throw;
            }
        }
        public DataTable timkiemdiemTNtheoma(DiemTotNghiepDTO diemTotNghiepDTO)
        {
          
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@" select madiemtotnghiep,DiemTotNghiep.mahs, tenHS,DiemTotNghiep.malop,diemmon1,diemmon2, diemmon3,tinhtrang  from DiemTotNghiep,HocSinh where mahs=@mahs and DiemTotNghiep.mahs=HocSinh.hocsinhID", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("mahs", diemTotNghiepDTO.mahs);
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        
                        return dt;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");
                throw;
            }
        }
        public DataTable timkiemdiemTNtheoten(DiemTotNghiepDTO diemTotNghiepDTO)
        {
     
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select madiemtotnghiep, DiemTotNghiep.mahs, tenHS,DiemTotNghiep.malop,diemmon1,diemmon2, diemmon3,tinhtrang  from DiemTotNghiep,HocSinh where tenHS like @tenHS and DiemTotNghiep.mahs=HocSinh.hocsinhID ", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("tenHS", "%" + diemTotNghiepDTO.tenHS + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        sqlConnection.Close();
                        return dt;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");
                throw;
            }
        }

        public DataTable laymahs()
        {
            
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select * from HocSinh order by  stt ", sqlConnection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                       
                        return dt;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");
                throw;
            }
        }
        public DataTable laymalop()
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select * from Lop order by  stt ", sqlConnection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        return dt;
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
