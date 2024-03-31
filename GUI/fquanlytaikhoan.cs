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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace GUI
{
    public partial class fquanlytaikhoan : Form
    {
        private bool check=false;
        private string user;
        public fquanlytaikhoan(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void fquanlytaikhoan_Load(object sender, EventArgs e)
        {
           /* taikhoanBLL taikhoanBLL = new taikhoanBLL();
            TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO();
            taiKhoanDTO.taikhoan = user;
            string kq = taikhoanBLL.checkquyen(taiKhoanDTO);
            if (kq=="quyen1"){
                menu_quanly.Enabled = false;
            }*/

        }



       
        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                check = true;
                TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO();
                taikhoanBLL taikhoanBLL = new taikhoanBLL();
                taiKhoanDTO.taikhoan = textBox_tk.Text;
                taiKhoanDTO.matkhau = textBox_mkcu.Text;
                string getuser = taikhoanBLL.check_login(taiKhoanDTO);
                if (getuser == "requeid_taikhoan")
                {
                    MessageBox.Show("tai khoan khong dc de trong");
                    return;
                }
                else if (getuser == "requeid_matkhau")
                {
                    MessageBox.Show("mk khong dc de trong");
                    return;
                }
                else if (getuser == "tk mk sai")
                {
                    MessageBox.Show("tk mk sai");
                    return;
                }
                else
                {
                    if (textBox_mkmoi.Text == "")
                    {
                        MessageBox.Show("mk moi khong duoc de trong");
                    }else if (textBox_xacnhan.Text == "")
                    {
                        MessageBox.Show("mk xac nhan khong duoc de trong");
                    }
                    else if (textBox_mkmoi.Text != textBox_xacnhan.Text)
                    {
                        MessageBox.Show("nhap mk phai trung nhau");
                        textBox_xacnhan.Text = "";
                    }
                    else
                    {
                        TaiKhoanDTO taiKhoanDTO1 = new TaiKhoanDTO();
                        taiKhoanDTO1.taikhoan = textBox_tk.Text;
                        taiKhoanDTO1.matkhau = textBox_mkmoi.Text;

                        bool kq = taikhoanBLL.Doimatkhau(taiKhoanDTO1);
                        if (kq)
                        {
                            MessageBox.Show("doi thanh cong");
                            fDangNhap fDangNhap = new fDangNhap();
                            this.Hide();
                            fDangNhap.ShowDialog();
                            this.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                check = true;
                if (MessageBox.Show("ban muon dang xuat?", "thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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

        private void button2_Click(object sender, EventArgs e)
        {
          
            try
            {
                check = true;
                if (MessageBox.Show("ban muon thoat?", "thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    fDieuKhien fDieuKhien = new fDieuKhien(this.user);
                    this.Hide();
                    fDieuKhien.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fquanlytaikhoan_FormClosing(object sender, FormClosingEventArgs e)
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

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                check = true;
                fDieuKhien fDieuKhien = new fDieuKhien("");
                this.Hide();
                fDieuKhien.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void báoCáoHồSơHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
            try
            {
                check = true;
                fReportHSHS fReportHSHS = new fReportHSHS();
                this.Hide();
                fReportHSHS.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void báoCáoĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            try
            {
                check = true;
                fReportDiem fReportDiem = new fReportDiem();
                this.Hide();
                fReportDiem.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quảnLýHồSơToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            try
            {
                check = true;
                fQuanlyHosoHS fQuanlysuahoso = new fQuanlyHosoHS("");
                this.Hide();
                fQuanlysuahoso.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void xửLýTốtNghiệpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                check = true;
                fQuanlytotnghiep fQuanlytotnghiep = new fQuanlytotnghiep("");
                this.Hide();
                fQuanlytotnghiep.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thêmĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                check = true;
                fQuanlydiem fQuanlydiem = new fQuanlydiem("");
                this.Hide();
                fQuanlydiem.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sửaĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                check = true;
                fQuanlytotnghiep fQuanlytotnghiep = new fQuanlytotnghiep("");
                this.Hide();
                fQuanlytotnghiep.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
