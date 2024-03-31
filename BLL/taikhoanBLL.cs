using DAL;
using DTO;
using SecurityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class taikhoanBLL
    {
        TaiKhoanAccessDAL accessDAL=new TaiKhoanAccessDAL();
        public string check_login(TaiKhoanDTO taiKhoanDTO)
        {
           
            try
            {
                if (taiKhoanDTO.taikhoan == "")
                {
                    return "requeid_taikhoan";
                }
                if (taiKhoanDTO.matkhau == "")
                {
                    return "requeid_matkhau";
                }
                taiKhoanDTO.matkhau = PasswordHasher.HashPassword(taiKhoanDTO.matkhau);
                string info = accessDAL.checklogin(taiKhoanDTO);
                return info;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }

        }
        public bool Doimatkhau(TaiKhoanDTO taiKhoanDTO)
        {
            
            try
            {
                return accessDAL.doimk(taiKhoanDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public string checkquyen(TaiKhoanDTO taiKhoanDTO)
        {
           
            try
            {
                return accessDAL.checkquyen(taiKhoanDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool dktk(TaiKhoanDTO taiKhoanDTO)
        {
            
            try
            {
                taiKhoanDTO.matkhau = PasswordHasher.HashPassword(taiKhoanDTO.matkhau);
                return accessDAL.DkTK(taiKhoanDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool checktk(TaiKhoanDTO taiKhoanDTO)
        {
            
            try
            {
                return accessDAL.checkTk(taiKhoanDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool checktkmadangnhap(TaiKhoanDTO taiKhoanDTO)
        {

            try
            {
                return accessDAL.checkMadangnhap(taiKhoanDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
        public bool checktkmadangnhapGV(TaiKhoanDTO taiKhoanDTO)
        {
           
            try
            {
                return accessDAL.checkMadangnhapGV(taiKhoanDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
    }
}
