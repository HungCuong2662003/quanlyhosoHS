using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace GUI
{
    public partial class fQuanlyHosoHS : Form
    {
        private bool check = false;
        private string ma;
        public fQuanlyHosoHS(string ma)
        {
            InitializeComponent();
            this.ma = ma;
            textBox_mahs.Text = ma;
            textBox_mahslh.Text = ma;
            textBox_mahsttgd.Text = ma;
            textBox_sdtcha.KeyPress += textBox_sdtlh_KeyPress;
            textBox_sdtme.KeyPress += textBox_sdtlh_KeyPress;
            textBox_diemtt2.KeyPress += textBox_diemtt1_KeyPress;
            textBox_diemtt3.KeyPress += textBox_diemtt1_KeyPress;
        }
        private void fQuanlyHosoHS_Load(object sender, EventArgs e)
        {


            try
            {
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                dataGridView_ttcn.DataSource = hocSinhBLL.Laytoanbodshsttcn();
                dataGridView_tttgd.DataSource = hocSinhBLL.Laytoanbodshsttgd();
                dataGridView_ttlh.DataSource = hocSinhBLL.Laytoanbodshsttlh();
                comboBox_uutien.DisplayMember = "uutienID";
                comboBox_uutien.ValueMember = "uutienID";
                comboBox_uutien.DataSource = hocSinhBLL.laymauutien();
                comboBox_malop.DisplayMember = "lopID";
                comboBox_malop.ValueMember = "lopID";
                comboBox_malop.DataSource = hocSinhBLL.laymalop();
                if (textBox_mahs.Text != "")
                {
                    button_timkiem.PerformClick();
                    button_timkiemttgd.PerformClick();
                    button_timkiemttlh.PerformClick();

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
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                HocSinhDTO hocSinhDTO = new HocSinhDTO();
                hocSinhDTO.hocsinhID = textBox_mahs.Text;
                dataGridView_ttcn.DataSource = hocSinhBLL.timkiemtthstheomattcn(hocSinhDTO);

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
                HocSinhDTO hs = new HocSinhDTO();
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                hs.hocsinhID = textBox_mahs.Text;
                hs.tenHS = textBox_hoten.Text;
                hs.gioitinh = comboBox_gt.Text;
                hs.ngaysinh = dateTimePicker_ngaysinh.Value;
                hs.dantoc = textBox_dantoc.Text;
                hs.tinhtrangsuckhoe = textBox_tinhtrang.Text;
                hs.doituongchinhsach = textBox_dtcs.Text;
                hs.ngayvaotruong = dateTimePicker_ngaynhaphoc.Value;
                if (textBox_diemtt1.Text == "")
                {
                    hs.diemtrungtuyen1 = 0;
                }
                else
                {
                    hs.diemtrungtuyen1 = double.Parse(textBox_diemtt1.Text);
                }
                if (textBox_diemtt2.Text == "")
                {
                    hs.diemtrungtuyen2 = 0;
                }
                else
                {
                    hs.diemtrungtuyen2 = double.Parse(textBox_diemtt2.Text);
                }
                if (textBox_diemtt3.Text == "")
                {
                    hs.diemtrungtuyen3 = 0;
                }
                else
                {
                    hs.diemtrungtuyen3 = double.Parse(textBox_diemtt3.Text);
                }
                hs.uutien = comboBox_uutien.Text;
                hs.malop = comboBox_malop.Text;
                hs.diachi = textBox_diachi.Text;
                
                bool kq1 = hocSinhBLL.checkhs(hs);
                if (kq1)
                {
                    MessageBox.Show("Hoc sinh da ton tai");
                    return;
                }
                bool kq = hocSinhBLL.themhs(hs);
                if (kq)
                {
                    MessageBox.Show("them thanh cong");
                    button_HIENTHI.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi them ttcn : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }

        private void button_LUU_Click(object sender, EventArgs e)
        {
            try
            {
                check = true;
                DialogResult result = MessageBox.Show("ban muon sua?", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    HocSinhDTO hocSinhDTO = new HocSinhDTO();
                    HocSinhBLL hocSinhBLL = new HocSinhBLL();
                    hocSinhDTO.hocsinhID = textBox_mahs.Text;
                    hocSinhDTO.tenHS = textBox_hoten.Text;
                    hocSinhDTO.gioitinh = comboBox_gt.Text;
                    hocSinhDTO.ngaysinh = dateTimePicker_ngaysinh.Value;
                    hocSinhDTO.dantoc = textBox_dantoc.Text;
                    hocSinhDTO.tinhtrangsuckhoe = textBox_tinhtrang.Text;
                    hocSinhDTO.doituongchinhsach = textBox_dtcs.Text;
                    hocSinhDTO.ngayvaotruong = dateTimePicker_ngaynhaphoc.Value;
                    hocSinhDTO.diemtrungtuyen1 = double.Parse(textBox_diemtt1.Text);
                    hocSinhDTO.diemtrungtuyen2 = double.Parse(textBox_diemtt2.Text);
                    hocSinhDTO.diemtrungtuyen3 = double.Parse(textBox_diemtt3.Text);
                    hocSinhDTO.diachi = textBox_diachi.Text;
                    hocSinhDTO.uutien = comboBox_uutien.Text;
                    hocSinhDTO.malop = comboBox_malop.Text;
                    bool kq = hocSinhBLL.suaHSHS(hocSinhDTO);
                    if (kq)
                    {
                        MessageBox.Show("sua thanh cong");
                        button_HIENTHI.PerformClick();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_XOA_Click(object sender, EventArgs e)
        {
         
            try
            {
                DialogResult result = MessageBox.Show("ban muon xoa ?", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    HocSinhDTO hocSinhDTO = new HocSinhDTO();
                    HocSinhBLL hocSinhBLL = new HocSinhBLL();
                    hocSinhDTO.hocsinhID = dataGridView_ttcn.CurrentRow.Cells[0].Value.ToString();
                    bool kq = hocSinhBLL.xoaHSHS(hocSinhDTO);
                    if (kq)
                    {
                        MessageBox.Show("xoa thanh cong");

                    }
                    button_HIENTHI.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_HIENTHI_Click(object sender, EventArgs e)
        {
           

            try
            {
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                dataGridView_ttcn.DataSource = hocSinhBLL.Laytoanbodshsttcn();
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

        private void button_timkiemttgd_Click(object sender, EventArgs e)
        {
           

            try
            {
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                HocSinhDTO hocSinhDTO = new HocSinhDTO();
                hocSinhDTO.hocsinhID = textBox_mahsttgd.Text;
                dataGridView_tttgd.DataSource = hocSinhBLL.timkiemtthstheomattgd(hocSinhDTO);
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
                HocSinhDTO hs = new HocSinhDTO();
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                hs.hotencha = textBox_hotencha.Text;
                hs.ngaysinhcha = dateTimePicker_cha.Value;
                hs.sdtcha = textBox_sdtcha.Text;
                hs.nghenghiepcha = textBox_nncha.Text;
                hs.diachilienhecha = textBox_diachicha.Text;
                hs.hotenme = textBox_hotenme.Text;
                hs.ngaysinhme = dateTimePicker_ngaysinhme.Value;
                hs.sdtme = textBox_sdtme.Text;
                hs.nghenghiepme = textBox_nnme.Text;
                hs.diachilienheme = textBox_diachime.Text;
                hs.hocsinhID = textBox_mahsttgd.Text;
                bool kq = hocSinhBLL.themttgd(hs);
                if (kq)
                {
                    MessageBox.Show("them thanh cong");
                    button_HIENTHITTGD.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            try
            {
                HocSinhDTO hocSinhDTO = new HocSinhDTO();
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                hocSinhDTO.hocsinhID = textBox_mahsttgd.Text;
                hocSinhDTO.hotencha = textBox_hotencha.Text;
                hocSinhDTO.ngaysinhcha = dateTimePicker_cha.Value;
                hocSinhDTO.sdtcha = textBox_sdtcha.Text;
                hocSinhDTO.nghenghiepcha = textBox_nncha.Text;
                hocSinhDTO.diachilienhecha = textBox_diachicha.Text;
                hocSinhDTO.hotenme = textBox_hotenme.Text;
                hocSinhDTO.ngaysinhme = dateTimePicker_ngaysinhme.Value;
                hocSinhDTO.sdtme = textBox_sdtme.Text;
                hocSinhDTO.nghenghiepme = textBox_nnme.Text;
                hocSinhDTO.diachilienheme = textBox_diachime.Text;
                bool kq = hocSinhBLL.xuatttgd(hocSinhDTO);
                if (kq)
                {
                    MessageBox.Show("sua thanh cong");
                    button_HIENTHITTGD.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_LUUTTGD_Click(object sender, EventArgs e)
        {
           

            try
            {
                DialogResult result = MessageBox.Show("ban muon xoa ?", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    HocSinhDTO hocSinhDTO = new HocSinhDTO();
                    HocSinhBLL hocSinhBLL = new HocSinhBLL();
                    hocSinhDTO.hocsinhID = dataGridView_tttgd.CurrentRow.Cells[0].Value.ToString();
                    bool kq = hocSinhBLL.xoaHSHS(hocSinhDTO);
                    if (kq)
                    {
                        MessageBox.Show("xoa thanh cong");

                    }
                    button_HIENTHITTGD.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_HIENTHITTGD_Click(object sender, EventArgs e)
        {
           

            try
            {
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                dataGridView_tttgd.DataSource = hocSinhBLL.Laytoanbodshsttgd();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTHOATTTGD_Click(object sender, EventArgs e)
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

        private void button_timkiemttlh_Click(object sender, EventArgs e)
        {

            try
            {

                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                HocSinhDTO hocSinhDTO = new HocSinhDTO();
                hocSinhDTO.hocsinhID = textBox_mahslh.Text;
                dataGridView_ttlh.DataSource = hocSinhBLL.timkiemtthstheomattlh(hocSinhDTO);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                HocSinhDTO hocSinhDTO = new HocSinhDTO();
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                hocSinhDTO.email = textBox_email.Text;
                hocSinhDTO.sdt = textBox_sdtlh.Text;
                hocSinhDTO.hocsinhID = textBox_mahslh.Text;
                bool kq = hocSinhBLL.themttlh(hocSinhDTO);
                if (kq)
                {
                    MessageBox.Show("them thanh cong");
                    button_HIENTHITTLH.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_LUUTTLH_Click(object sender, EventArgs e)
        {

            try
            {

                HocSinhDTO hocSinhDTO = new HocSinhDTO();
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                hocSinhDTO.hocsinhID = textBox_mahslh.Text;
                hocSinhDTO.sdt = textBox_sdtlh.Text;
                hocSinhDTO.email = textBox_email.Text;
                bool kq = hocSinhBLL.xuattlh(hocSinhDTO);
                if (kq)
                {
                    MessageBox.Show("sua thanh cong");
                    button_HIENTHITTLH.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {


            try
            {
                DialogResult result = MessageBox.Show("ban muon xoa ?", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    HocSinhDTO hocSinhDTO = new HocSinhDTO();
                    HocSinhBLL hocSinhBLL = new HocSinhBLL();
                    hocSinhDTO.hocsinhID = dataGridView_ttlh.CurrentRow.Cells[0].Value.ToString();
                    bool kq = hocSinhBLL.xoaHSHS(hocSinhDTO);
                    if (kq)
                    {
                        MessageBox.Show("xoa thanh cong");
                        button_HIENTHITTLH.PerformClick();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_HIENTHITTLH_Click(object sender, EventArgs e)
        {
           
            try
            {
                HocSinhBLL hocSinhBLL = new HocSinhBLL();
                dataGridView_ttlh.DataSource = hocSinhBLL.Laytoanbodshsttlh();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_THOATTTLH_Click(object sender, EventArgs e)
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

        private void xửLýTốtNghiêpToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void fQuanlyHosoHS_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridView_ttcn_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                textBox_mahs.Text = dataGridView_ttcn.CurrentRow.Cells[0].Value.ToString();
                textBox_hoten.Text = dataGridView_ttcn.CurrentRow.Cells[1].Value.ToString();
                comboBox_gt.Text = dataGridView_ttcn.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker_ngaysinh.Text = dataGridView_ttcn.CurrentRow.Cells[3].Value.ToString();
                textBox_dantoc.Text = dataGridView_ttcn.CurrentRow.Cells[4].Value.ToString();
                textBox_tinhtrang.Text = dataGridView_ttcn.CurrentRow.Cells[5].Value.ToString();
                textBox_dtcs.Text = dataGridView_ttcn.CurrentRow.Cells[6].Value.ToString();
                dateTimePicker_ngaynhaphoc.Text = dataGridView_ttcn.CurrentRow.Cells[7].Value.ToString();
                textBox_diachi.Text = dataGridView_ttcn.CurrentRow.Cells[8].Value.ToString();
                textBox_diemtt1.Text = dataGridView_ttcn.CurrentRow.Cells[9].Value.ToString();
                textBox_diemtt2.Text = dataGridView_ttcn.CurrentRow.Cells[10].Value.ToString();
                textBox_diemtt3.Text = dataGridView_ttcn.CurrentRow.Cells[11].Value.ToString();
                comboBox_uutien.Text = dataGridView_ttcn.CurrentRow.Cells[12].Value.ToString();
                comboBox_malop.Text = dataGridView_ttcn.CurrentRow.Cells[13].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_tttgd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            try
            {
                textBox_mahsttgd.Text = dataGridView_tttgd.CurrentRow.Cells[0].Value.ToString();
                textBox_hotencha.Text = dataGridView_tttgd.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker_cha.Text = dataGridView_tttgd.CurrentRow.Cells[3].Value.ToString();
                textBox_sdtcha.Text = dataGridView_tttgd.CurrentRow.Cells[4].Value.ToString();
                textBox_nncha.Text = dataGridView_tttgd.CurrentRow.Cells[5].Value.ToString();
                textBox_diachicha.Text = dataGridView_tttgd.CurrentRow.Cells[6].Value.ToString();
                textBox_hotenme.Text = dataGridView_tttgd.CurrentRow.Cells[7].Value.ToString();
                dateTimePicker_ngaysinhme.Text = dataGridView_tttgd.CurrentRow.Cells[8].Value.ToString();
                textBox_sdtme.Text = dataGridView_tttgd.CurrentRow.Cells[9].Value.ToString();
                textBox_nnme.Text = dataGridView_tttgd.CurrentRow.Cells[10].Value.ToString();
                textBox_diachime.Text = dataGridView_tttgd.CurrentRow.Cells[11].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_ttlh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            try
            {
                textBox_mahslh.Text = dataGridView_ttlh.CurrentRow.Cells[0].Value.ToString();
                textBox_sdtlh.Text = dataGridView_ttlh.CurrentRow.Cells[2].Value.ToString();
                textBox_email.Text = dataGridView_ttlh.CurrentRow.Cells[3].Value.ToString();
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
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_email_Validating(object sender, CancelEventArgs e)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            Regex regex = new Regex(emailPattern);

            if (!regex.IsMatch(textBox_email.Text))
            {
                MessageBox.Show("Định dạng email không hợp lệ. Xin vui lòng nhập địa chỉ Gmail.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_email.Text = "";
                e.Cancel = true; // Hủy sự kiện Validating để ngăn người dùng di chuyển khỏi TextBox
            }
        }

        private void textBox_sdtlh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
           
        }

        private void textBox_diemtt1_KeyPress(object sender, KeyPressEventArgs e)
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
