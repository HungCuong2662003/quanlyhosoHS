using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReportDAL:DataAccessDAL
    {
        public DataTable xuatttcntheolop( DiemHocTapDTO diemHocTapDTO)
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3 from HocSinh where malop=@malop", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@malop", diemHocTapDTO.malop);
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
        public DataTable xuatttcntheokhoa(DiemHocTapDTO diemHocTapDTO)
        {
          
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3 from HocSinh,Lop where HocSinh.malop=Lop.lopID and nienkhoa=@nienkhoa", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@nienkhoa", diemHocTapDTO.nienkhoa);
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
        public DataTable xuatttcn(DiemHocTapDTO diemHocTapDTO)
        {
           
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select hocsinhID,tenHS,gioitinh,ngaysinh,dantoc,tinhtrangsuckhoe,doituongchinhsach,ngayvaotruong,diemtrungtuyen1,diemtrungtuyen2,diemtrungtuyen3 from HocSinh,Lop where HocSinh.malop=Lop.lopID and nienkhoa=@nienkhoa and malop=@malop ", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@malop", diemHocTapDTO.malop);
                        sqlCommand.Parameters.AddWithValue("@nienkhoa", diemHocTapDTO.nienkhoa);
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
        public DataTable xuatttgdtheolop(DiemHocTapDTO diemHocTapDTO)
        {
            
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select hocsinhID,tenHS, hotencha,ngaysinhcha,sdtcha,nghenghiepcha,diachilienhecha,hotenme,ngaysinhme,sdtme,nghenghiepme,diachilienheme from HocSinh where malop=@malop ", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@malop", diemHocTapDTO.malop);
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
        public DataTable xuatttgdtheokhoa(DiemHocTapDTO diemHocTapDTO)
        {
           
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select hocsinhID,tenHS, hotencha,ngaysinhcha,sdtcha,nghenghiepcha,diachilienhecha,hotenme,ngaysinhme,sdtme,nghenghiepme,diachilienheme  from HocSinh,Lop where HocSinh.malop=Lop.lopID and nienkhoa=@nienkhoa", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@nienkhoa", diemHocTapDTO.nienkhoa);
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
        public DataTable xuatttgd(DiemHocTapDTO diemHocTapDTO)
        {
            
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select hocsinhID, tenHS, hotencha, ngaysinhcha, sdtcha, nghenghiepcha, diachilienhecha, hotenme, ngaysinhme, sdtme, nghenghiepme, diachilienheme  from HocSinh, Lop where HocSinh.malop = Lop.lopID and nienkhoa = @nienkhoa and malop = @malop ", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@malop", diemHocTapDTO.malop);
                        sqlCommand.Parameters.AddWithValue("@nienkhoa", diemHocTapDTO.nienkhoa);
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
        public DataTable xuatttlhtheolop(DiemHocTapDTO diemHocTapDTO)
        {
            
            try{
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select hocsinhID,tenHS,sdt,email,diachi from HocSinh where malop=@malop", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@malop", diemHocTapDTO.malop);
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
        public DataTable xuatttlhtheokhoa(DiemHocTapDTO diemHocTapDTO)
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select  hocsinhID,tenHS,sdt,email,diachi  from HocSinh,Lop where HocSinh.malop=Lop.lopID and nienkhoa=@nienkhoa", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@nienkhoa", diemHocTapDTO.nienkhoa);
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
        public DataTable xuatttlh(DiemHocTapDTO diemHocTapDTO)
        {
           
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select hocsinhID,tenHS,sdt,email,diachi  from HocSinh,Lop where HocSinh.malop=Lop.lopID and nienkhoa=@nienkhoa and malop=@malop", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@malop", diemHocTapDTO.malop);
                        sqlCommand.Parameters.AddWithValue("@nienkhoa", diemHocTapDTO.nienkhoa);
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
        public DataTable xuatDiemHTtheolop(DiemHocTapDTO diem)
        {
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select *from DiemHocTap where malop=@malop ", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@malop", diem.malop);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable xuatDiemHTtheohlYeu()
        {
         
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiem, DiemHocTap.malop,diemHK1,diemHK2,DTB,mahs,mamon from DiemHocTap,Lop where DTB<3 and DiemHocTap.malop=Lop.lopID", sqlConnection))
                    {
                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable xuatDiemHTtheohlTB()
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiem, DiemHocTap.malop,diemHK1,diemHK2,DTB,mahs,mamon from DiemHocTap,Lop where DTB>=3 and DtB<6 and DiemHocTap.malop=Lop.lopID", sqlConnection))
                    {
                       
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable xuatDiemHTtheohlKha( )
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiem, DiemHocTap.malop,diemHK1,diemHK2,DTB,mahs,mamon from DiemHocTap,Lop where DTB>=6 and DTB<8 and DiemHocTap.malop=Lop.lopID", sqlConnection))
                    {
                    
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable xuatDiemHTtheohlGioi( )
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiem, DiemHocTap.malop,diemHK1,diemHK2,DTB,mahs,mamon from DiemHocTap,Lop where DTB>=8  and DiemHocTap.malop=Lop.lopID", sqlConnection))
                    {
                  
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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

        public DataTable xuatDiemHTtheomahsYeu(DiemHocTapDTO diem)
        {
           
            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiem, DiemHocTap.malop,diemHK1,diemHK2,DTB,mahs,mamon from DiemHocTap,Lop where DTB<3 and DiemHocTap.malop=@malop and DiemHocTap.malop=Lop.lopID ", sqlConnection))
                    {
                      
                        cmd.Parameters.AddWithValue("@malop", diem.malop);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable xuatDiemHTtheomahsTB(DiemHocTapDTO diem)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiem, DiemHocTap.malop,diemHK1,diemHK2,DTB,mahs,mamon from DiemHocTap,Lop where DTB>=3 and DTB<6 and DiemHocTap.malop=@malop and DiemHocTap.malop=Lop.lopID ", sqlConnection))
                    {
                       
                        cmd.Parameters.AddWithValue("@malop", diem.malop);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable xuatDiemHTtheomahsKha(DiemHocTapDTO diem)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiem, DiemHocTap.malop,diemHK1,diemHK2,DTB,mahs,mamon from DiemHocTap,Lop where DTB>=6 and DTB<8 and DiemHocTap.malop=@malop and DiemHocTap.malop=Lop.lopID ", sqlConnection))
                    {
                       
                        cmd.Parameters.AddWithValue("@malop", diem.malop);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable xuatDiemHTtheomahsGioi(DiemHocTapDTO diem)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiem, DiemHocTap.malop,diemHK1,diemHK2,DTB,mahs,mamon from DiemHocTap,Lop where DTB>=8 and DiemHocTap.malop=@malop and DiemHocTap.malop=Lop.lopID ", sqlConnection))
                    {
                        
                        cmd.Parameters.AddWithValue("@malop", diem.malop);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable xuatDiemTNtheolop(DiemHocTapDTO diemHocTapDTO)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select *from DiemTotNghiep where malop=@malop ", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@malop", diemHocTapDTO.malop);
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
        public DataTable xuatDiemTNtheotttotnghiep( )
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiemtotnghiep,mahs, DiemTotNghiep.malop,diemmon1, diemmon2, diemmon3, tinhtrang from DiemTotNghiep,Lop where tinhtrang='tot nghiep' and DiemTotNghiep.malop=Lop.lopID", sqlConnection))
                    {

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable xuatDiemTNtheottchuatotnghiep( )
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiemtotnghiep, mahs, DiemTotNghiep.malop,diemmon1, diemmon2, diemmon3, tinhtrang from DiemTotNghiep,Lop where tinhtrang='' and DiemTotNghiep.malop=Lop.lopID", sqlConnection))
                    {

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable xuatDiemTNtheomatttotnghiep(DiemHocTapDTO diemHocTapDTO)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiemtotnghiep, mahs, DiemTotNghiep.malop,diemmon1, diemmon2, diemmon3, tinhtrang from DiemTotNghiep,Lop where tinhtrang='tot nghiep' and DiemTotNghiep.malop=@malop and DiemTotNghiep.malop=Lop.lopID", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@malop", diemHocTapDTO.malop);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable xuatDiemTNtheomattchuatotnghiep(DiemHocTapDTO diemHocTapDTO)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiemtotnghiep, mahs, DiemTotNghiep.malop,diemmon1, diemmon2, diemmon3, tinhtrang from DiemTotNghiep,Lop where tinhtrang='' and DiemTotNghiep.malop=@malop and DiemTotNghiep.malop=Lop.lopID", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@malop", diemHocTapDTO.malop);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable laynienkhoa()
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(@"select * from nienkhoa order by  stt ", sqlConnection))
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
        public DataTable xuatDiemHTdiem5(DiemHocTapDTO diem)
        {

            try
            {
                using (SqlConnection sqlConnection = connect())
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(@"select madiem, DiemHocTap.malop,diemHK1,diemHK2,DTB,mahs,mamon from DiemHocTap,Lop where diemHK1=4.5 and DiemHocTap.malop=Lop.lopID ", sqlConnection))
                    {

                        cmd.Parameters.AddWithValue("@malop", diem.malop);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
