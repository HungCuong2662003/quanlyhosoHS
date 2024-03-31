using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class HocSinhBLL
    {
        HocSinhAccessDAL hsAccess = new HocSinhAccessDAL();
        public DataTable Laytoanbodshs()
        {
           
            try
            {
                return hsAccess.laytoanbodshs();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }

        }
        public DataTable Laytoanbodshsttcn()
        {
            
            try
            {
                return hsAccess.laytoanbodshsttcn();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Laytoanbodshsttgd()
        {
           
            try
            {
                return hsAccess.laytoanbodshsttgd();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable Laytoanbodshsttlh()
        {
            return hsAccess.laytoanbodshsttlh();
        }
        public bool themhs(HocSinhDTO hs)
        {
            
            try
            {
                return hsAccess.Them(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool themttgd(HocSinhDTO hs)
        {
            
            try
            {
                return hsAccess.themttgd(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool themttlh(HocSinhDTO hs)
        {
            
            try
            {
                return hsAccess.themttlh(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool xoaHSHS(HocSinhDTO hs)
        {
            
            try
            {
                return hsAccess.xoahshs(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool suaHSHS(HocSinhDTO hs)
        {
            
            try
            {
                return hsAccess.suattcn(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool xuatttgd(HocSinhDTO hs)
        {
           
            try
            {
                return hsAccess.suattgd(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool xuattlh(HocSinhDTO hs)
        {
            
            try
            {
                return hsAccess.suattlh(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable timkiemtthstheomattcn(HocSinhDTO hs)
        {
            
            try
            {
                return hsAccess.timkiemtthstheomattcn(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable timkiemtthstheomattgd(HocSinhDTO hs)
        {
            
            try
            {
                return hsAccess.timkiemtthstheomattgd(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable timkiemtthstheomattlh(HocSinhDTO hs)
        {
            
            try
            {
                return hsAccess.timkiemtthstheomattlh(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable timkiemtthstheoma(HocSinhDTO hs)
        {
            try
            {

                return hsAccess.timkiemtthstheoma(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable timkiemtthstheoten(HocSinhDTO hs)
        {
            
            try
            {
                return hsAccess.timkiemtthstheoten(hs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable timkiemtths(HocSinhDTO hs)
        {
            
            try
            {
                return hsAccess.timkiemtths(hs);
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
                return hsAccess.laymalop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public DataTable laymauutien()
        {
           
            try
            {
                return hsAccess.laymauutien();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool checkhs(HocSinhDTO hocSinhDTO)
        {

            try
            {
                return hsAccess.checkhs(hocSinhDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
    }

}
