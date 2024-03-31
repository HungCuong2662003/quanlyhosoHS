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
    public class DataAccessDAL
    {
        public static SqlConnection connect()
        { 
            try
            {
                SqlConnection conn = null;
                string str = "Data Source=LAPTOP-08FUB1Q3\\NGUYENHUNGCUONG;Initial Catalog=quanlyhshs;Integrated Security=True";
                conn = new SqlConnection(str);
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi : {ex.Message}");

                throw;
            }
        }
    }
}
