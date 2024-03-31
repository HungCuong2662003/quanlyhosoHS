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
    public class DiemTNBLL
    {
        DiemTNAccessDAL accessDAL = new DiemTNAccessDAL();
        public DataTable laydiemTN()
        {
            
            try
            {
                return accessDAL.laydiemtotnghiep();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi  {ex.Message}");

                throw;
            }
        }
        public bool Them(DiemTotNghiepDTO diemTotNghiepDTO)
        {
            
            try
            {
                return accessDAL.themdiem(diemTotNghiepDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi  {ex.Message}");

                throw;
            }
        }
        
        public bool suadiem(DiemTotNghiepDTO diemTotNghiepDTO)
        {
            
            try
            {
                return accessDAL.SuaDiem(diemTotNghiepDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool xoa(DiemTotNghiepDTO diemTotNghiepDTO)
        {
            
            try
            {
                return accessDAL.Xoa(diemTotNghiepDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Timkiemdiem( DiemTotNghiepDTO diemTotNghiepDTO)
        {
            
            try
            {
                return accessDAL.timkiemdiemTN(diemTotNghiepDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable TimkiemdiemTNtheoma( DiemTotNghiepDTO diemTotNghiepDTO)
        {
            try
            {
                return accessDAL.timkiemdiemTNtheoma(diemTotNghiepDTO);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Timkiemdiemtheoten( DiemTotNghiepDTO diemTotNghiepDTO)
        {
           
            try
            {
                return accessDAL.timkiemdiemTNtheoten(diemTotNghiepDTO);
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
                return accessDAL.laymahs();
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
                return accessDAL.laymalop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
    }
}

