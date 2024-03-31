using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fDangKy : Form
    {
        private bool check=false;
        public fDangKy()
        {
            InitializeComponent();
        }

        private void fDangKy_Load(object sender, EventArgs e)
        {


        }

        private void Contro_dk_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (textBox_taikhoan.Text == "" || textBox_ma.Text == "" || textBox_mk1.Text == "" || textBox_matkhau.Text == "")
                {
                    MessageBox.Show("khong dc de trong");
                    return;
                }
                else if (textBox_matkhau.Text != textBox_mk1.Text)
                {
                    MessageBox.Show("mk nhap k khop");
                    return;
                }

                taikhoanBLL taikhoanBLL = new taikhoanBLL();
                TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO();
                taiKhoanDTO.taikhoan = textBox_taikhoan.Text;
                taiKhoanDTO.matkhau = textBox_matkhau.Text;
                taiKhoanDTO.magv = textBox_ma.Text;

                bool kq = taikhoanBLL.checktk(taiKhoanDTO);
                bool kq1 = taikhoanBLL.checktkmadangnhap(taiKhoanDTO);
                bool kq2 = taikhoanBLL.checktkmadangnhapGV(taiKhoanDTO);
                if (kq)
                {
                    MessageBox.Show("tk da ton tai");
                    return;
                }
                else if (kq1)
                {
                    MessageBox.Show("ma dang nhap da duoc su dung");
                    return;
                }
                else if (kq2 == false)
                {
                    MessageBox.Show("ma gv khong ton tai");
                    return;
                }
                else
                {
                    bool kq3 = taikhoanBLL.dktk(taiKhoanDTO);
                    if (kq3)
                    {

                        MessageBox.Show("dang ky thanh cong");
                        check = true;
                        fDangNhap fDangNhap = new fDangNhap();
                        this.Hide();
                        fDangNhap.ShowDialog();
                        this.Close();

                    }
                    return;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_THOAT_Click(object sender, EventArgs e)
        {
            
            try
            {
                check = true;
                if (MessageBox.Show("ban muon thoat?", "thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    fDangNhap fDangNhap = new fDangNhap();
                    this.Hide();
                    fDangNhap.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fDangKy_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
