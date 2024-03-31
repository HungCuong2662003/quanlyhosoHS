using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DiemAccessDAL : DataAccessDAL
    {
   
        public bool themdiem(DiemHocTapDTO diem)
        {
            try
            {
              
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"insert into DiemHocTap(madiem,malop,diemHK1,diemHK2,mahs,mamon) values (@madiem,@malop,@diemHK1,@diemHK2,@mahs,@mamon)",sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@madiem", diem.madiem);
                        sqlCommand.Parameters.AddWithValue("@malop", diem.malop);
                        sqlCommand.Parameters.AddWithValue("@mahs", diem.mahs);
                        sqlCommand.Parameters.AddWithValue("@mamon", diem.mamon);
                        sqlCommand.Parameters.AddWithValue("@diemHK1", diem.diemHK1);
                        sqlCommand.Parameters.AddWithValue("@diemHK2", diem.diemHK2);
                        int kq = sqlCommand.ExecuteNonQuery();
                        return kq > 0;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm điểm: {ex.Message}");
                throw;
            }
        }
        public bool suadiem(DiemHocTapDTO diem)
        {
            try
            {
               
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"update DiemHocTap set mahs=@mahs ,mamon= @mamon,malop=@malop,diemHK1= @diemHK1,diemHK2=@diemHK2 where madiem=@madiem",sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@madiem", diem.madiem);
                        sqlCommand.Parameters.AddWithValue("@mahs", diem.mahs);
                        sqlCommand.Parameters.AddWithValue("@mamon", diem.mamon);
                        sqlCommand.Parameters.AddWithValue("@malop", diem.malop);
                        sqlCommand.Parameters.AddWithValue("@diemHK1", diem.diemHK1);
                        sqlCommand.Parameters.AddWithValue("@diemHK2", diem.diemHK2);
                        int kq = sqlCommand.ExecuteNonQuery();
                        return kq > 0;
                    }
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi sửa điểm: {ex.Message}");
                throw;
            }
        }
        
        public bool xoadiem(DiemHocTapDTO diem)
        {
            try
            {
                
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"delete from DiemHocTap where madiem=@madiem", sqlConnection))
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.Parameters.AddWithValue("@madiem", diem.madiem);
                        int kq = sqlCommand.ExecuteNonQuery();
                        return kq > 0;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa điểm: {ex.Message}");
                throw;
            }
        }
       
        public DataTable timkiemdiem(DiemHocTapDTO diemHocTapDTO)
        {
            try
            {
               
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select mahs,tenHS, madiem,DiemHocTap.malop,diemHK1, diemHK2,DTB,mamon from DiemHocTap ,HocSinh where tenHS like @tenHS and DiemHocTap.mahs=HocSinh.hocsinhID and  mahs=@mahs  ", sqlConnection))
                    {
                        DataTable dt = new DataTable();
                        sqlCommand.Parameters.AddWithValue("mahs", diemHocTapDTO.mahs);
                        sqlCommand.Parameters.AddWithValue("tenHS", "%" + diemHocTapDTO.tenhs + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        adapter.Fill(dt);
                        return dt;
                    }
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm điểm theo mã & tên là: {ex.Message}");
                throw;
            }
        
        }
        public DataTable timkiemdiemtheoma(DiemHocTapDTO diemHocTapDTO)
        {
            try
            {
                
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select  mahs,tenHS, madiem,DiemHocTap.malop,diemHK1, diemHK2,DTB,mamon from DiemHocTap,HocSinh where mahs=@mahs and DiemHocTap.mahs=HocSinh.hocsinhID ", sqlConnection))
                    {
                        DataTable dt = new DataTable();
                        sqlCommand.Parameters.AddWithValue("mahs", diemHocTapDTO.mahs);
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        adapter.Fill(dt);
                        return dt;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm điểm theo mã là: {ex.Message}");
                throw;
            }
           
        }
        public DataTable timkiemdiemtheoten(DiemHocTapDTO diemHocTapDTO)
        {
            try
            {
                
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select mahs,tenHS, madiem,DiemHocTap.malop,diemHK1, diemHK2,DTB,mamon from DiemHocTap ,HocSinh where tenHS like @tenHS and DiemHocTap.mahs=HocSinh.hocsinhID", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@tenhs", "%" + diemHocTapDTO.tenhs + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm điểm theo tên là: {ex.Message}");
                throw;
            }
           
        }
        public DataTable laytatcadiem()
        {
            try
            {
                
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select mahs,tenHS, madiem,DiemHocTap.malop,diemHK1, diemHK2,DTB,mamon from DiemHocTap ,HocSinh where DiemHocTap.mahs=HocSinh.hocsinhID   order by  DiemHocTap.stt desc ", sqlConnection))
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        adapter.Fill(dt);
                        return dt;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy tất cả điểm  là: {ex.Message}");
                throw;
            }
           
        }
        public DataTable laymamon()
        {
            try
            {

                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select * from MonHoc order by  stt", sqlConnection))
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
                Console.WriteLine($"Lỗi  là: {ex.Message}");
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
                    using (SqlCommand sqlCommand = new SqlCommand(@"select * from HocSinh order by  stt", sqlConnection))
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
                Console.WriteLine($"Lỗi  là: {ex.Message}");
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
                Console.WriteLine($"Lỗi  là: {ex.Message}");
                throw;
            }
        }

    }
}
