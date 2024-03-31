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
    public partial class fDieuKhien : Form
    {
        private string username;
        private bool check=false;
        public fDieuKhien( string username)
        {
            InitializeComponent();
            this.username= username;
        }

        private void fDieuKhien_Load(object sender, EventArgs e)
        {
            try
            {
                HocSinhBLL hocSinh = new HocSinhBLL();
                TaiKhoanDTO dto = new TaiKhoanDTO();
                taikhoanBLL taikhoanBLL = new taikhoanBLL();
                /* dto.taikhoan = username;
                 string kq =taikhoanBLL.checkquyen(dto);
                 if (kq == "quyen1")
                 {
                     quảnLýToolStripMenuItem.Enabled = false;
                 }*/

                dataGridView_tths.DataSource = hocSinh.Laytoanbodshs();
                diemBLL diemBLL = new diemBLL();
                dataGridView_diemht.DataSource = diemBLL.laytoanbodiem();
                DiemTNBLL diemTNBLL = new DiemTNBLL();
                dataGridView_diemtn.DataSource = diemTNBLL.laydiemTN();
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
                fQuanlydiem fQuanlythemdiem = new fQuanlydiem("");
                this.Hide();
                fQuanlythemdiem.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                check = true;
                fquanlytaikhoan fquanlytaikhoan = new fquanlytaikhoan(this.username);
                this.Hide();
                fquanlytaikhoan.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                HocSinhDTO hocSinhDTO = new HocSinhDTO();
                hocSinhDTO.hocsinhID = textBox_mahstths.Text;
                hocSinhDTO.tenHS = textBox_tentths.Text;
                if (textBox_tentths.Text == "")
                {
                    dataGridView_tths.DataSource = hocSinhBLL.timkiemtthstheoma(hocSinhDTO);
                }
                else if (textBox_mahstths.Text == "")
                {
                    dataGridView_tths.DataSource = hocSinhBLL.timkiemtthstheoten(hocSinhDTO);
                }
                else
                {
                    dataGridView_tths.DataSource = hocSinhBLL.timkiemtths(hocSinhDTO);
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

        private void fDieuKhien_FormClosing(object sender, FormClosingEventArgs e)
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



        private void trangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoHồSơHọcToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void báoCáoĐiểmHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void báoCáoĐiểmTốtNghiệpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                check = true;
                fReportDiem fReportDiemTN = new fReportDiem();
                this.Hide();
                fReportDiemTN.ShowDialog();
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



        private void sỬAToolStripMenuItem_Click(object sender, EventArgs e)
            
        {   
            try
            {
                check = true;
                string ma = dataGridView_tths.CurrentRow.Cells[0].Value.ToString();
                fQuanlyHosoHS fQuanlythemhoso = new fQuanlyHosoHS(ma);
                this.Hide();
                fQuanlythemhoso.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xÓAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                check = true;
                string ma = dataGridView_tths.CurrentRow.Cells[0].Value.ToString();
                fQuanlyHosoHS fQuanlythemhoso = new fQuanlyHosoHS(ma);
                this.Hide();
                fQuanlythemhoso.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void suaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                check = true;
                string ma = dataGridView_diemht.CurrentRow.Cells[0].Value.ToString();
                fQuanlydiem fQuanlydiem = new fQuanlydiem(ma);
                this.Hide();
                fQuanlydiem.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                check = true;
                string ma = dataGridView_diemht.CurrentRow.Cells[0].Value.ToString();
                fQuanlydiem fQuanlydiem = new fQuanlydiem(ma);
                this.Hide();
                fQuanlydiem.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sửaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                check = true;
                string ma = dataGridView_diemtn.CurrentRow.Cells[0].Value.ToString();
                fQuanlytotnghiep fQuanlytotnghiep = new fQuanlytotnghiep(ma);
                this.Hide();
                fQuanlytotnghiep.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xóaToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            try
            {
                check = true;
                string ma = dataGridView_diemtn.CurrentRow.Cells[0].Value.ToString();
                fQuanlytotnghiep fQuanlytotnghiep = new fQuanlytotnghiep(ma);
                this.Hide();
                fQuanlytotnghiep.ShowDialog();
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

        private void button_diemhoctap_Click(object sender, EventArgs e)
        {
            try
            {
                diemBLL diemBLL = new diemBLL();
                DiemHocTapDTO diemHocTapDTO = new DiemHocTapDTO();
                diemHocTapDTO.mahs = textBox_mahsdiemht.Text;
                diemHocTapDTO.tenhs = textBox_tenhsdiemht.Text;
                if (textBox_tenhsdiemht.Text == "")
                {
                    dataGridView_diemht.DataSource = diemBLL.Timkiemdiemtheoma(diemHocTapDTO);
                }
                else if (textBox_mahsdiemht.Text == "")
                {
                    dataGridView_diemht.DataSource = diemBLL.Timkiemdiemtheoten(diemHocTapDTO);
                }
                else
                {
                    dataGridView_diemht.DataSource = diemBLL.Timkiemdiem(diemHocTapDTO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_TN_Click(object sender, EventArgs e)
        {
            try
            {
                DiemTNBLL diemTNBLL = new DiemTNBLL();
                DiemTotNghiepDTO diemTotNghiepDTO = new DiemTotNghiepDTO();
                diemTotNghiepDTO.mahs = textBox_mahsdiemtn.Text;
                diemTotNghiepDTO.tenHS = textBox_tenTN.Text;
                if (textBox_mahsdiemtn.Text == "")
                {
                    dataGridView_diemtn.DataSource = diemTNBLL.Timkiemdiemtheoten(diemTotNghiepDTO);
                }
                else if (textBox_tenTN.Text == "")
                {
                    dataGridView_diemtn.DataSource = diemTNBLL.TimkiemdiemTNtheoma(diemTotNghiepDTO);
                }
                else
                {
                    dataGridView_diemtn.DataSource = diemTNBLL.Timkiemdiem(diemTotNghiepDTO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void quảnLýĐiểmHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void quảnLýĐiểmTốtNghiêpToolStripMenuItem_Click(object sender, EventArgs e)
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
