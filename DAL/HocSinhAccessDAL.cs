using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAL
{
    public class HocSinhAccessDAL:DataAccessDAL
    {
        public DataTable laytoanbodshs()
        {
            try
            {
               
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3,diachi,sdt,email,hotencha,ngaysinhcha,sdtcha,nghenghiepcha,diachilienhecha,hotenme, ngaysinhme,sdtme, nghenghiepme,diachilienheme,uutien,malop from   HocSinh order by stt desc", sqlConnection))
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
                Console.WriteLine($"Lỗi khi lấy tất cả thông tin học sinh  là: {ex.Message}");
                throw;
            }
        }
        public DataTable laytoanbodshsttcn()
        {
            try
            {

                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select  hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe, doituongchinhsach,ngayvaotruong,diachi,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3,uutien,malop from HocSinh order by stt desc", sqlConnection))
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
                Console.WriteLine($"Lỗi khi lấy thông tin cá nhân học sinh  là: {ex.Message}");
                throw;
            }
        }
        public DataTable laytoanbodshsttgd()
        {
            try
            {
               
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select  hocsinhID, tenHS, hotencha,ngaysinhcha,sdtcha,nghenghiepcha,diachilienhecha, hotenme,ngaysinhme,sdtme,nghenghiepme,diachilienheme from HocSinh order by stt desc", sqlConnection))
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
                Console.WriteLine($"Lỗi khi lấy thông tin gia đình học sinh  là: {ex.Message}");
                throw;
            }
        }
        public DataTable laytoanbodshsttlh()
        {
            try
            {
                
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select  hocsinhID,tenHS,sdt,email from HocSinh order by stt desc", sqlConnection))
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
                Console.WriteLine($"Lỗi khi lấy thông tin liên hệ học sinh  là: {ex.Message}");
                throw;
            }
        }
        public  bool Them(HocSinhDTO hs)
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"insert into HocSinh(hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3,diachi,uutien,malop) values(@hocsinhID,@tenHS,@gioitinh,@ngaysinh,@dantoc,@tinhtrangsuckhoe,@doituongchinhsach,@ngayvaotruong,@diemtrungtuyen1,@diemtrungtuyen2,@diemtrungtuyen3,@diachi, @uutien,@malop)", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@hocsinhID", hs.hocsinhID);
                        sqlCommand.Parameters.AddWithValue("@tenHS", hs.tenHS);
                        sqlCommand.Parameters.AddWithValue("@gioitinh", hs.gioitinh);
                        sqlCommand.Parameters.AddWithValue("@ngaysinh", hs.ngaysinh);
                        sqlCommand.Parameters.AddWithValue("@dantoc", hs.dantoc);
                        sqlCommand.Parameters.AddWithValue("@tinhtrangsuckhoe", hs.tinhtrangsuckhoe);
                        sqlCommand.Parameters.AddWithValue("@doituongchinhsach", hs.doituongchinhsach);
                        sqlCommand.Parameters.AddWithValue("@ngayvaotruong", hs.ngayvaotruong);
                        sqlCommand.Parameters.AddWithValue("@diemtrungtuyen1", hs.diemtrungtuyen1);
                        sqlCommand.Parameters.AddWithValue("@diemtrungtuyen2", hs.diemtrungtuyen2);
                        sqlCommand.Parameters.AddWithValue("@diemtrungtuyen3", hs.diemtrungtuyen3);
                        sqlCommand.Parameters.AddWithValue("@diachi", hs.diachi);
                        sqlCommand.Parameters.AddWithValue("@uutien", hs.uutien);
                        sqlCommand.Parameters.AddWithValue("@malop", hs.malop);
                        int kq = sqlCommand.ExecuteNonQuery();
                        return kq > 0;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm ttcn: {ex.Message}");
                throw;
            }

        }
        public bool themttgd(HocSinhDTO hs)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"update  HocSinh set hotencha=@hotencha,ngaysinhcha=@ngaysinhcha,sdtcha=@sdtcha,nghenghiepcha=@nghenghiepcha,diachilienhecha=@diachilienhecha,hotenme=@hotenme,ngaysinhme=@ngaysinhme,sdtme=@sdtme,nghenghiepme=@nghenghiepme,diachilienheme=@diachilienheme where  hocsinhID=@mahs", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@hotencha", hs.hotencha);
                        sqlCommand.Parameters.AddWithValue("@ngaysinhcha", hs.ngaysinhcha);
                        sqlCommand.Parameters.AddWithValue("@sdtcha", hs.sdtcha);
                        sqlCommand.Parameters.AddWithValue("@nghenghiepcha", hs.nghenghiepcha);
                        sqlCommand.Parameters.AddWithValue("@diachilienhecha", hs.diachilienhecha);
                        sqlCommand.Parameters.AddWithValue("@hotenme", hs.hotenme);
                        sqlCommand.Parameters.AddWithValue("@ngaysinhme", hs.ngaysinhme);
                        sqlCommand.Parameters.AddWithValue("@sdtme", hs.sdtme);
                        sqlCommand.Parameters.AddWithValue("@nghenghiepme", hs.nghenghiepme);
                        sqlCommand.Parameters.AddWithValue("@diachilienheme", hs.diachilienheme);
                        sqlCommand.Parameters.AddWithValue("@mahs", hs.hocsinhID);
                        int kq = sqlCommand.ExecuteNonQuery();
                        return kq > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm ttgd: {ex.Message}");
                throw;
            }
        }
        public bool themttlh(HocSinhDTO hs)
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"update  HocSinh set email=@email, sdt=@sdt where hocsinhID=@mahs", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@email", hs.email);
                        sqlCommand.Parameters.AddWithValue("@sdt", hs.sdt);
                        sqlCommand.Parameters.AddWithValue("@mahs", hs.hocsinhID);
                        int kq = sqlCommand.ExecuteNonQuery();
                        return kq > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm ttlh: {ex.Message}");
                throw;
            }
        }
        public bool xoahshs(HocSinhDTO hs)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"delete from HocSinh where hocsinhID=@mahs", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@mahs", hs.hocsinhID);
                        int kq = sqlCommand.ExecuteNonQuery();
                        return kq > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa hshs: {ex.Message}");
                throw;
            }
        }
        public bool suattcn(HocSinhDTO hs)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"update HocSinh set  tenHS=@tenHS, gioitinh=@gioitinh,dantoc=@dantoc,tinhtrangsuckhoe=@tinhtrangsuckhoe,doituongchinhsach=@doituongchinhsach,ngayvaotruong=@ngayvaotruong,diemtrungtuyen1=@diemtrungtuyen1,diemtrungtuyen2=@diemtrungtuyen2,diemtrungtuyen3=@diemtrungtuyen3,diachi=@diachi,uutien=@uutien,malop=@malop where hocsinhID=@mahs", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@tenHS", hs.tenHS);
                        sqlCommand.Parameters.AddWithValue("@gioitinh", hs.gioitinh);
                        sqlCommand.Parameters.AddWithValue("@dantoc", hs.dantoc);
                        sqlCommand.Parameters.AddWithValue("@tinhtrangsuckhoe", hs.tinhtrangsuckhoe);
                        sqlCommand.Parameters.AddWithValue("@doituongchinhsach", hs.doituongchinhsach);
                        sqlCommand.Parameters.AddWithValue("@ngayvaotruong", hs.ngayvaotruong);
                        sqlCommand.Parameters.AddWithValue("@diemtrungtuyen1", hs.diemtrungtuyen1);
                        sqlCommand.Parameters.AddWithValue("@diemtrungtuyen2", hs.diemtrungtuyen2);
                        sqlCommand.Parameters.AddWithValue("@diemtrungtuyen3", hs.diemtrungtuyen3);
                        sqlCommand.Parameters.AddWithValue("@diachi", hs.diachi);
                        sqlCommand.Parameters.AddWithValue("@uutien", hs.uutien);
                        sqlCommand.Parameters.AddWithValue("@malop", hs.malop);
                        sqlCommand.Parameters.AddWithValue("@mahs", hs.hocsinhID);
                        int kq = sqlCommand.ExecuteNonQuery();
                        return kq > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi sửa ttcn: {ex.Message}");
                throw;
            }
        }
        public bool suattgd(HocSinhDTO hs)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"update  HocSinh set hotencha=@hotencha,ngaysinhcha=@ngaysinhcha,sdtcha=@sdtcha,nghenghiepcha=@nghenghiepcha,diachilienhecha=@diachilienhecha,hotenme=@hotenme,ngaysinhme=@ngaysinhme,sdtme=@sdtme,nghenghiepme=@nghenghiepme,diachilienheme=@diachilienheme where  hocsinhID=@mahs", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@hotencha", hs.hotencha);
                        sqlCommand.Parameters.AddWithValue("@ngaysinhcha", hs.ngaysinhcha);
                        sqlCommand.Parameters.AddWithValue("@sdtcha", hs.sdtcha);
                        sqlCommand.Parameters.AddWithValue("@nghenghiepcha", hs.nghenghiepcha);
                        sqlCommand.Parameters.AddWithValue("@diachilienhecha", hs.diachilienhecha);
                        sqlCommand.Parameters.AddWithValue("@hotenme", hs.hotenme);
                        sqlCommand.Parameters.AddWithValue("@ngaysinhme", hs.ngaysinhme);
                        sqlCommand.Parameters.AddWithValue("@sdtme", hs.sdtme);
                        sqlCommand.Parameters.AddWithValue("@nghenghiepme", hs.nghenghiepme);
                        sqlCommand.Parameters.AddWithValue("@diachilienheme", hs.diachilienheme);
                        sqlCommand.Parameters.AddWithValue("@mahs", hs.hocsinhID);
                        int kq = sqlCommand.ExecuteNonQuery();
                        return kq > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi sửa ttgd: {ex.Message}");
                throw;
            }
        }
        public bool suattlh(HocSinhDTO hs)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"update  HocSinh set email=@email, sdt=@sdt where hocsinhID=@mahs", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@email", hs.email);
                        sqlCommand.Parameters.AddWithValue("@sdt", hs.sdt);
                        sqlCommand.Parameters.AddWithValue("@mahs", hs.hocsinhID);
                        int kq = sqlCommand.ExecuteNonQuery();

                        return kq > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi sửa ttlh: {ex.Message}");
                throw;
            }
        }

        public DataTable timkiemtthstheomattcn(HocSinhDTO hocSinhDTO)
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select   hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe, doituongchinhsach,ngayvaotruong,diachi,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3,uutien,malop from HocSinh where hocsinhID=@hocsinhID ", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@hocsinhID", hocSinhDTO.hocsinhID);
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
                Console.WriteLine($"Lỗi tìm kiếm ttcn: {ex.Message}");
                throw;
            }
        }
        public DataTable timkiemtthstheomattgd(HocSinhDTO hocSinhDTO)
        {
            
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select hocsinhID, tenHS, hotencha,ngaysinhcha,sdtcha,nghenghiepcha,diachilienhecha, hotenme,ngaysinhme,sdtme,nghenghiepme,diachilienheme from HocSinh where hocsinhID=@hocsinhID", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@hocsinhID", hocSinhDTO.hocsinhID);
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        
                        return dt;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm ttgd: {ex.Message}");
                throw;
            }
        }
        public DataTable timkiemtthstheomattlh(HocSinhDTO hocSinhDTO)
        {
   
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select  hocsinhID,tenHS,sdt,email from HocSinh where hocsinhID=@hocsinhID", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@hocsinhID", hocSinhDTO.hocsinhID);
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                       
                        return dt;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm ttlh: {ex.Message}");
                throw;
            }
        }
        public DataTable timkiemtthstheoma(HocSinhDTO hocSinhDTO)
        {
        
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select  hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3,diachi,sdt,email,hotencha,ngaysinhcha,sdtcha,nghenghiepcha,diachilienhecha,hotenme, ngaysinhme,sdtme, nghenghiepme,diachilienheme,uutien,malop from HocSinh where hocsinhID=@hocsinhID", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@hocsinhID", hocSinhDTO.hocsinhID);
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
                Console.WriteLine($"Lỗi khi tìm kiếm tths theo mã: {ex.Message}");
                throw;
            }
        }
        public DataTable timkiemtthstheoten(HocSinhDTO hocSinhDTO)
        {
          
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select  hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3,diachi,sdt,email,hotencha,ngaysinhcha,sdtcha,nghenghiepcha,diachilienhecha,hotenme, ngaysinhme,sdtme, nghenghiepme,diachilienheme,uutien,malop from HocSinh where tenHS like  @tenhs", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@tenhs", "%" + hocSinhDTO.tenHS + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                   
                        return dt;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm tths theo tên: {ex.Message}");
                throw;
            }
        }
        public DataTable timkiemtths(HocSinhDTO hocSinhDTO)
        {
        
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select  hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3,diachi,sdt,email,hotencha,ngaysinhcha,sdtcha,nghenghiepcha,diachilienhecha,hotenme, ngaysinhme,sdtme, nghenghiepme,diachilienheme,uutien,malop from HocSinh where hocsinhID=@hocsinhID and (tenHS like @tenhs) ", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@tenhs", "%" + hocSinhDTO.tenHS + "%");
                        sqlCommand.Parameters.AddWithValue("@hocsinhID", hocSinhDTO.hocsinhID);
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                      
                        return dt;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm tths theo mã & tên: {ex.Message}");
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
                Console.WriteLine($"Lỗi khi lấy mã lớp: {ex.Message}");
                throw;
            }
        }
        public DataTable laymauutien()
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select * from Uutien  order by  stt", sqlConnection))
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
                Console.WriteLine($"Lỗi khi lấy mã ưu tiên : {ex.Message}");
                throw;
            }
        }
        public bool checkhs(HocSinhDTO hocSinhDTO)
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("select * from HocSinh where tenHS=@tenHS and gioitinh=@gioitinh and ngaysinh=@ngaysinh and dantoc=@dantoc and tinhtrangsuckhoe=@tinhtrangsuckhoe and ngayvaotruong=@ngayvaotruong and diachi=@diachi and doituongchinhsach=@doituongchinhsach and uutien=@uutien and malop=@malop", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@tenHS", hocSinhDTO.tenHS);
                        sqlCommand.Parameters.AddWithValue("@gioitinh", hocSinhDTO.gioitinh);
                        sqlCommand.Parameters.AddWithValue("@ngaysinh", hocSinhDTO.ngaysinh);
                        sqlCommand.Parameters.AddWithValue("@dantoc",hocSinhDTO.dantoc);
                        sqlCommand.Parameters.AddWithValue("@tinhtrangsuckhoe", hocSinhDTO.tinhtrangsuckhoe);
                        sqlCommand.Parameters.AddWithValue("@ngayvaotruong", hocSinhDTO.ngayvaotruong);

                        sqlCommand.Parameters.AddWithValue("@diachi", hocSinhDTO.diachi);
                        sqlCommand.Parameters.AddWithValue("@doituongchinhsach", hocSinhDTO.doituongchinhsach);
                        sqlCommand.Parameters.AddWithValue("@uutien", hocSinhDTO.uutien);
                        sqlCommand.Parameters.AddWithValue("@malop", hocSinhDTO.malop);
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


    }
    

}
