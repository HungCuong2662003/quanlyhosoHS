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
    public partial class fQuanlydiem : Form
    {
        private bool check = false;
        private string ma;
        public fQuanlydiem(string ma)
        {
            InitializeComponent();
            this.ma = ma;
            textBox_diemhk2.KeyPress += textBox_diemhk1_KeyPress;
            
        }

        private void fQuanlythemdiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.HocSinh' table. You can move, or remove it, as needed.
            this.hocSinhTableAdapter.Fill(this.dataSet1.HocSinh);
            try
            {
                diemBLL diemBLL = new diemBLL();
                dataGridView1.DataSource = diemBLL.laytoanbodiem();
                comboBox_mamon.DisplayMember = "monHocID";
                comboBox_mamon.ValueMember = "monHocID";
                comboBox_mamon.DataSource = diemBLL.laymamon();
                comboBox_mahs.DisplayMember = "hocsinhID";
                comboBox_mahs.ValueMember = "hocsinhID";
                comboBox_mahs.DataSource = diemBLL.laymahs();
                comboBox_malop.DisplayMember = "lopID";
                comboBox_malop.ValueMember = "lopID";
                comboBox_malop.DataSource = diemBLL.laymalop();
                comboBox_mahs.Text = ma;
                if (comboBox_mahs.Text != "")
                {
                    button_timkiem.PerformClick();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                comboBox_mahs.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox_mdiem.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox_malop.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox_diemhk1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox_diemhk2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBox_mamon.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button_THEM_Click(object sender, EventArgs e)
        {
            try
            {
                diemBLL diemBLL = new diemBLL();
                DiemHocTapDTO diemHocTapDTO = new DiemHocTapDTO();
                diemHocTapDTO.madiem = textBox_mdiem.Text;
                diemHocTapDTO.diemHK1 = double.Parse(textBox_diemhk1.Text);
                diemHocTapDTO.diemHK2 = double.Parse(textBox_diemhk2.Text);
                diemHocTapDTO.mahs = comboBox_mahs.Text;
                diemHocTapDTO.mamon = comboBox_mamon.Text;
                diemHocTapDTO.malop = comboBox_malop.Text;
                bool kq = diemBLL.Themdiem(diemHocTapDTO);
                if (kq)
                {
                    MessageBox.Show("them thanh cong");
                    button_HIENTHI.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm điểm : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button_HIENTHI_Click(object sender, EventArgs e)
        {
            try
            {
                diemBLL diemBLL = new diemBLL();

                dataGridView1.DataSource = diemBLL.laytoanbodiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Lỗi đăng xuất là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button_THOAT_Click(object sender, EventArgs e)
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
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void fQuanlythemdiem_FormClosing(object sender, FormClosingEventArgs e)
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
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
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
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                diemBLL diemBLL = new diemBLL();
                DiemHocTapDTO diemHocTapDTO = new DiemHocTapDTO();
                diemHocTapDTO.madiem = textBox_mdiem.Text;
                diemHocTapDTO.diemHK1 = double.Parse(textBox_diemhk1.Text);
                diemHocTapDTO.diemHK2 = double.Parse(textBox_diemhk2.Text);
                diemHocTapDTO.mahs = comboBox_mahs.Text;
                diemHocTapDTO.mamon = comboBox_mamon.Text;
                diemHocTapDTO.malop = comboBox_malop.Text;
                bool kq = diemBLL.suadiem(diemHocTapDTO);
                if (kq)
                {
                    MessageBox.Show("sua thanh cong");
                    button_HIENTHI.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                diemBLL diemBLL = new diemBLL();
                DiemHocTapDTO diemHocTapDTO = new DiemHocTapDTO();
                DialogResult result = MessageBox.Show("ban co muon xoa? ", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    diemHocTapDTO.madiem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    bool kq = diemBLL.xoadiem(diemHocTapDTO);
                    if (kq)
                    {
                        MessageBox.Show("xoa thanh cong");
                        button_HIENTHI.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void báoCáoHồSơHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
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
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                diemBLL diemBLL = new diemBLL();
                DiemHocTapDTO diemHocTapDTO = new DiemHocTapDTO();
                diemHocTapDTO.mahs = comboBox_mahs.Text;
                dataGridView1.DataSource = diemBLL.Timkiemdiemtheoma(diemHocTapDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Lỗi là : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBox_diemhk1_KeyPress(object sender, KeyPressEventArgs e)
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
            if (!IsValidDiem(newText))
            {
                e.Handled = true;
            }
        }
        private bool IsValidDiem(string text)
        {
            if (double.TryParse(text, out double diem))
            {
                return diem >= 0 && diem <= 10;
            }

            return false;
        }
    }
}
