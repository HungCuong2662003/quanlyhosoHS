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
    public class diemBLL
    {
        DiemAccessDAL diemAccessDAL=new DiemAccessDAL();
/*        public List<DiemHocTapDTO> Laytoanbodiem()
        {
            try
            {
                return diemAccessDAL.laytoanbodiem();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy toàn bộ điểm: {ex.Message}");
                throw;
            }
        }*/
        public bool Themdiem(DiemHocTapDTO diem)
        {
            
            try
            {
                return diemAccessDAL.themdiem(diem);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");
               
                throw;
            }
        }
        public bool suadiem(DiemHocTapDTO diem)
        {
            try
            {
                return diemAccessDAL.suadiem(diem);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool xoadiem(DiemHocTapDTO diem)
        {
            try
            {
                return diemAccessDAL.xoadiem(diem);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Timkiemdiemtheoma(DiemHocTapDTO diem)
        {
            try
            {
                return diemAccessDAL.timkiemdiemtheoma(diem);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Timkiemdiemtheoten(DiemHocTapDTO diem)
        {
            
            try
            {
                return diemAccessDAL.timkiemdiemtheoten(diem);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Timkiemdiem(DiemHocTapDTO diem)
        {
            try
            {
                return diemAccessDAL.timkiemdiem(diem);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable laytoanbodiem()
        {
            try
            {
                return diemAccessDAL.laytatcadiem();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable laymamon()
        {
            try
            {
                return diemAccessDAL.laymamon();
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
                return diemAccessDAL.laymahs();
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
                return diemAccessDAL.laymalop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
    }
}
