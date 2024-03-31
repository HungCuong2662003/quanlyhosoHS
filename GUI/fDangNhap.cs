using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class fDangNhap : Form
    {
        taikhoanBLL taikhoanBLL = new taikhoanBLL();
        TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO();
        private bool check = false;
        public fDangNhap()
        {
            InitializeComponent();
        }


        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (check == false)
                {
                    if (MessageBox.Show("ban muon thoat?", "thong bao", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("ban muon thoat?", "thong bao", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {
            
        }
        private string username;
        private void button_dangnhap_Click(object sender, EventArgs e)
        {  
            try
            {
                 
            check=true;
            
            taiKhoanDTO.taikhoan = textBox_taikhoan.Text;
            taiKhoanDTO.matkhau = textBox_matkhau.Text;
            string getuser = taikhoanBLL.check_login(taiKhoanDTO);
            if (getuser == "required_taikhoan")
            {
                MessageBox.Show("tai khoan khong dc de trong");
                return;
            }
            if (getuser == "required_matkhau")
            {
                MessageBox.Show("mk khong dc de trong");
                return;
            }
            if (getuser == "tk mk sai")
            {
                MessageBox.Show("tk mk sai");
                return;

            }
            MessageBox.Show("dang nhap thanh cong");
            this.username = textBox_taikhoan.Text;
            fDieuKhien f = new fDieuKhien(this.username);
            fquanlytaikhoan fquanlytaikhoan =new fquanlytaikhoan(this.username);
            this.Hide();
            f.ShowDialog();
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                check = true;
                fDangKy fDangKy = new fDangKy();
                this.Hide();
                fDangKy.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
