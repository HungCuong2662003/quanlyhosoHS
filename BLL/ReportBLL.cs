using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReportBLL
    {
        ReportDAL reportHSHSDAL =new ReportDAL();
        public DataTable Xuatttcntheolop(DiemHocTapDTO diemHocTapDTO)
        {
            
            try
            {
                return reportHSHSDAL.xuatttcntheolop(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Xuatttcntheokhoa(DiemHocTapDTO diemHocTapDTO)
        {
           
            try
            {
                return reportHSHSDAL.xuatttcntheokhoa(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Xuatttcn(DiemHocTapDTO diemHocTapDTO)
        {
            
            try
            {
                return reportHSHSDAL.xuatttcn(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Xuatttgdtheolop(DiemHocTapDTO diemHocTapDTO)
        {
            
            try
            {
                return reportHSHSDAL.xuatttgdtheolop(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Xuatttgdtheokhoa(DiemHocTapDTO diemHocTapDTO)
        {
           
            try
            {
                return reportHSHSDAL.xuatttgdtheokhoa(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Xuatttgd(DiemHocTapDTO diemHocTapDTO)
        {
            
            try
            {
                return reportHSHSDAL.xuatttgd(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Xuatttlhtheolop(DiemHocTapDTO diemHocTapDTO)
        {
           
            try
            {
                return reportHSHSDAL.xuatttlhtheolop(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Xuatttlhtheokhoa(DiemHocTapDTO diemHocTapDTO)
        {
            
            try
            {
                return reportHSHSDAL.xuatttlhtheokhoa(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Xuatttlh(DiemHocTapDTO diemHocTapDTO)
        {
            
            try
            {
                return reportHSHSDAL.xuatttlh(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }

        //xuat diem hoc tap
        public DataTable XuatDiemHTtheolop(DiemHocTapDTO diemHocTapDTO)
        {
            
            try
            {
                return reportHSHSDAL.xuatDiemHTtheolop(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable XuatDiemHTtheohlYeu( )
        {
           
            try
            {
                return reportHSHSDAL.xuatDiemHTtheohlYeu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable XuatDiemHTtheohlTB()
        {

            try
            {
                return reportHSHSDAL.xuatDiemHTtheohlTB();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable XuatDiemHTtheohlKha( )
        {

            try
            {
                return reportHSHSDAL.xuatDiemHTtheohlKha();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable XuatDiemHTtheohlGioi( )
        {

            try
            {
                return reportHSHSDAL.xuatDiemHTtheohlGioi();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable XuatDiemHTtheomahsYeu(DiemHocTapDTO diemHocTapDTO)
        {
           
            try
            {
                return reportHSHSDAL.xuatDiemHTtheomahsYeu(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable XuatDiemHTtheomahsTB(DiemHocTapDTO diemHocTapDTO)
        {

            try
            {
                return reportHSHSDAL.xuatDiemHTtheomahsTB(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable XuatDiemHTtheomahsKha(DiemHocTapDTO diemHocTapDTO)
        {

            try
            {
                return reportHSHSDAL.xuatDiemHTtheomahsKha(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable XuatDiemHTtheomahsGioi(DiemHocTapDTO diemHocTapDTO)
        {

            try
            {
                return reportHSHSDAL.xuatDiemHTtheomahsGioi(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        //xuat diem tot nghiep
        public DataTable XuatDiemTNtheolop(DiemHocTapDTO diemHocTapDTO)
        {
           
            try
            {
                return reportHSHSDAL.xuatDiemTNtheolop(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable xuatDiemTNtheotttotnghiep( )
        {

            try
            {
                return reportHSHSDAL.xuatDiemTNtheotttotnghiep();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable xuatDiemTNtheottchuatotnghiep( )
        {

            try
            {
                return reportHSHSDAL.xuatDiemTNtheottchuatotnghiep();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable xuatDiemTNtheomatttotnghiep(DiemHocTapDTO diemHocTapDTO)
        {

            try
            {
                return reportHSHSDAL.xuatDiemTNtheomatttotnghiep(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable xuatDiemTNtheomattchuatotnghiep(DiemHocTapDTO diemHocTapDTO)
        {

            try
            {
                return reportHSHSDAL.xuatDiemTNtheomattchuatotnghiep(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }

        public DataTable laymalop( )
        {
            try
            {
                return reportHSHSDAL.laymalop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable laynienkhoa()
        {
            try
            {
                return reportHSHSDAL.laynienkhoa();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable xuatdiemhk1( DiemHocTapDTO diemHocTapDTO)
        {
            try
            {
                return reportHSHSDAL.xuatDiemHTdiem5(diemHocTapDTO );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
    }
}
