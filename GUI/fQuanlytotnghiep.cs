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
    public partial class fQuanlytotnghiep : Form
    {
        private bool check=false;
        private string ma;
        public fQuanlytotnghiep(string ma)
        {
            InitializeComponent();
            this.ma = ma;
            textBox_diemthem2.KeyPress += textBox_diemthem1_KeyPress;
            textBox_diemthem3.KeyPress += textBox_diemthem1_KeyPress;
            
        }

        private void fQuanlytotnghiep_Load(object sender, EventArgs e)
        {
         
            try
            {
                DiemTNBLL diemTNBLL = new DiemTNBLL();
                dataGridView1.DataSource = diemTNBLL.laydiemTN();
                comboBox_mahs.DisplayMember = "hocsinhID";
                comboBox_mahs.ValueMember = "hocsinhID";
                comboBox_mahs.DataSource = diemTNBLL.laymahs();
                comboBox_malop.DisplayMember = "lopID";
                comboBox_malop.ValueMember = "lopID";
                comboBox_malop.DataSource = diemTNBLL.laymalop();
                comboBox_mahs.Text = ma;
                if (comboBox_mahs.Text != "")
                {
                    button_timkiem.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button_them_Click(object sender, EventArgs e)
        {
           
            try
            {
                DiemTotNghiepDTO diemTotNghiepDTO = new DiemTotNghiepDTO();
                DiemTNBLL diemTNBLL = new DiemTNBLL();
                diemTotNghiepDTO.madiemtotnghiep=textBox_madiemtotnghiep.Text;
                diemTotNghiepDTO.mahs = comboBox_mahs.Text;
                diemTotNghiepDTO.malop = comboBox_malop.Text;
                diemTotNghiepDTO.diemmon1 = double.Parse(textBox_diemthem1.Text);
                diemTotNghiepDTO.diemmon2 = double.Parse(textBox_diemthem2.Text);
                diemTotNghiepDTO.diemmon3 = double.Parse(textBox_diemthem3.Text);
                bool kq = diemTNBLL.Them(diemTotNghiepDTO);
                if (kq)
                {
                    MessageBox.Show("them thanh cong");
                    button_hienthi.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button_hienthi_Click(object sender, EventArgs e)
        {
            
            try
            {
                DiemTNBLL diemTNBLL = new DiemTNBLL();

                dataGridView1.DataSource = diemTNBLL.laydiemTN();
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
                check = true;
                if (MessageBox.Show("ban muon thoat?", "thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    fDieuKhien fDieuKhien = new fDieuKhien("");
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


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {   textBox_madiemtotnghiep.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBox_mahs.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox_malop.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox_diemthem1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox_diemthem2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox_diemthem3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
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

        private void button_thoat_sua_Click(object sender, EventArgs e)
        {
           
            try
            {
                check = true;
                if (MessageBox.Show("ban muon thoat?", "thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    fDieuKhien fDieuKhien = new fDieuKhien("");
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

        private void button_thoat1_Click(object sender, EventArgs e)
        {
           
            try
            {
                check = true;
                if (MessageBox.Show("ban muon thoat?", "thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    fDieuKhien fDieuKhien = new fDieuKhien("");
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

        private void fQuanlytotnghiep_FormClosing(object sender, FormClosingEventArgs e)
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

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                check = true;
                fquanlytaikhoan fquanlytaikhoan = new fquanlytaikhoan("");
                this.Hide();
                fquanlytaikhoan.ShowDialog();
                this.Close();
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

        private void button_sua_Click(object sender, EventArgs e)
        {
           
            try
            {
                DiemTNBLL diemTNBLL = new DiemTNBLL();
                DiemTotNghiepDTO diemTotNghiepDTO = new DiemTotNghiepDTO();
                diemTotNghiepDTO.madiemtotnghiep=textBox_madiemtotnghiep.Text;
                diemTotNghiepDTO.mahs = comboBox_mahs.Text;
                diemTotNghiepDTO.malop = comboBox_malop.Text;
                diemTotNghiepDTO.diemmon1 = double.Parse(textBox_diemthem1.Text);
                diemTotNghiepDTO.diemmon2 = double.Parse(textBox_diemthem2.Text);
                diemTotNghiepDTO.diemmon3 = double.Parse(textBox_diemthem3.Text);
                bool kq = diemTNBLL.suadiem(diemTotNghiepDTO);
                if (kq)
                {
                    MessageBox.Show("sua thanh cong");
                    button_hienthi.PerformClick();
                }
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
                fQuanlyHosoHS fQuanlyhoso = new fQuanlyHosoHS("");
                this.Hide();
                fQuanlyhoso.ShowDialog();
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

        private void button_xoa_Click(object sender, EventArgs e)
        {
            
            try
            {
                DiemTNBLL diemTNBLL = new DiemTNBLL();
                DiemTotNghiepDTO diemTotNghiepDTO = new DiemTotNghiepDTO();
                diemTotNghiepDTO.madiemtotnghiep = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                bool kq = diemTNBLL.xoa(diemTotNghiepDTO);
                if (kq)
                {
                    MessageBox.Show("xoa thanh cong");
                    button_hienthi.PerformClick();
                }
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
                DiemTNBLL diemTNBLL = new DiemTNBLL();
                DiemTotNghiepDTO diemTotNghiepDTO = new DiemTotNghiepDTO();
                diemTotNghiepDTO.mahs = comboBox_mahs.Text;
                dataGridView1.DataSource = diemTNBLL.TimkiemdiemTNtheoma(diemTotNghiepDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sửaĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void xóaĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void textBox_diemthem1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            string newText = (sender as TextBox).Text + e.KeyChar;
        }

    }
}
