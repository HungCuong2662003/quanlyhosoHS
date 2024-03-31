using BLL;
using DTO;
using Microsoft.Reporting.WinForms;
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
    public partial class fReportHSHS : Form
    {
        private bool check=false;
        public fReportHSHS()
        {
            InitializeComponent();
        }

        private void fReportHSHS_Load(object sender, EventArgs e)
        {
            ReportBLL reportBLL = new ReportBLL();
            this.reportViewer_ttlh.RefreshReport();
            comboBox_malop.DisplayMember = "lopID";
            comboBox_malop.ValueMember = "lopID";
            comboBox_malop.DataSource = reportBLL.laymalop();
            comboBox_malop1.DisplayMember = "lopID";
            comboBox_malop1.ValueMember = "lopID";
            comboBox_malop1.DataSource = reportBLL.laymalop();
            comboBox_malop2.DisplayMember = "lopID";
            comboBox_malop2.ValueMember = "lopID";
            comboBox_malop2.DataSource = reportBLL.laymalop();
            comboBox_nienkhoa.DisplayMember = "nienkhoaID";
            comboBox_nienkhoa.ValueMember = "nienkhoaID";
            comboBox_nienkhoa.DataSource = reportBLL.laynienkhoa();
            comboBox_nienkhoa1.DisplayMember = "nienkhoaID";
            comboBox_nienkhoa1.ValueMember = "nienkhoaID";
            comboBox_nienkhoa1.DataSource = reportBLL.laynienkhoa();
            comboBox_nienkhoa2.DisplayMember = "nienkhoaID";
            comboBox_nienkhoa2.ValueMember = "nienkhoaID";
            comboBox_nienkhoa2.DataSource = reportBLL.laynienkhoa();
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
        private void fReportHSHS_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button1_THOAT_Click(object sender, EventArgs e)
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



        private void trangToolStripMenuItem_Click(object sender, EventArgs e)
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


        private void button_ttcn_Click(object sender, EventArgs e)
        {
            
            try
            {
                ReportBLL reportHSHSBLL = new ReportBLL();
                DiemHocTapDTO diemHocTapDTO = new DiemHocTapDTO();
                diemHocTapDTO.malop = comboBox_malop.Text;
                diemHocTapDTO.nienkhoa = comboBox_nienkhoa.Text;
                reportViewer_ttcn.LocalReport.DataSources.Clear();
                if (comboBox_malop.Text == "")
                {
                    ReportDataSource source = new ReportDataSource("DataSet1", reportHSHSBLL.Xuatttcntheokhoa(diemHocTapDTO));
                    reportViewer_ttcn.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report1.rdlc";
                    reportViewer_ttcn.LocalReport.DataSources.Add(source);
                    reportViewer_ttcn.RefreshReport();
                    return;
                }
                else if (comboBox_nienkhoa.Text == "")
                {
                    ReportDataSource source = new ReportDataSource("DataSet1", reportHSHSBLL.Xuatttcntheolop(diemHocTapDTO));
                    reportViewer_ttcn.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report1.rdlc";
                    reportViewer_ttcn.LocalReport.DataSources.Add(source);
                    reportViewer_ttcn.RefreshReport();
                    return;
                }
                else
                {
                    ReportDataSource source = new ReportDataSource("DataSet1", reportHSHSBLL.Xuatttcn(diemHocTapDTO));
                    reportViewer_ttcn.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report1.rdlc";
                    reportViewer_ttcn.LocalReport.DataSources.Add(source);
                    reportViewer_ttcn.RefreshReport();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ttgd_Click(object sender, EventArgs e)
        {
            
            try
            {
                ReportBLL reportHSHSBLL = new ReportBLL();
                DiemHocTapDTO diemHocTapDTO = new DiemHocTapDTO();
                diemHocTapDTO.malop = comboBox_malop1.Text;
                diemHocTapDTO.nienkhoa = comboBox_nienkhoa1.Text;
                reportViewer_ttgd.LocalReport.DataSources.Clear();
                if (comboBox_malop1.Text == "")
                {
                    ReportDataSource source = new ReportDataSource("DataSet1", reportHSHSBLL.Xuatttgdtheokhoa(diemHocTapDTO));
                    reportViewer_ttgd.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report4.rdlc";
                    reportViewer_ttgd.LocalReport.DataSources.Add(source);
                    reportViewer_ttgd.RefreshReport();
                    return;
                }
                else if (comboBox_nienkhoa1.Text == "")
                {
                    ReportDataSource source = new ReportDataSource("DataSet1", reportHSHSBLL.Xuatttgdtheolop(diemHocTapDTO));
                    reportViewer_ttgd.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report4.rdlc";
                    reportViewer_ttgd.LocalReport.DataSources.Add(source);
                    reportViewer_ttgd.RefreshReport();
                    return;
                }
                else
                {
                    ReportDataSource source = new ReportDataSource("DataSet1", reportHSHSBLL.Xuatttgd(diemHocTapDTO));
                    reportViewer_ttgd.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report4.rdlc";
                    reportViewer_ttgd.LocalReport.DataSources.Add(source);
                    reportViewer_ttgd.RefreshReport();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ttlh_Click(object sender, EventArgs e)
        {
           
            try
            {
                ReportBLL reportHSHSBLL = new ReportBLL();
                DiemHocTapDTO diemHocTapDTO = new DiemHocTapDTO();
                diemHocTapDTO.malop = comboBox_malop2.Text;
                diemHocTapDTO.nienkhoa = comboBox_nienkhoa2.Text;
                reportViewer_ttlh.LocalReport.DataSources.Clear();
                if (comboBox_malop2.Text == "")
                {
                    ReportDataSource source = new ReportDataSource("DataSet1", reportHSHSBLL.Xuatttlhtheokhoa(diemHocTapDTO));
                    reportViewer_ttlh.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report5.rdlc";
                    reportViewer_ttlh.LocalReport.DataSources.Add(source);
                    reportViewer_ttlh.RefreshReport();
                    return;
                }
                else if (comboBox_nienkhoa2.Text == "")
                {
                    ReportDataSource source = new ReportDataSource("DataSet1", reportHSHSBLL.Xuatttlhtheolop(diemHocTapDTO));
                    reportViewer_ttlh.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report5.rdlc";
                    reportViewer_ttlh.LocalReport.DataSources.Add(source);
                    reportViewer_ttlh.RefreshReport();
                }
                else
                {
                    ReportDataSource source = new ReportDataSource("DataSet1", reportHSHSBLL.Xuatttlh(diemHocTapDTO));
                    reportViewer_ttlh.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report5.rdlc";
                    reportViewer_ttlh.LocalReport.DataSources.Add(source);
                    reportViewer_ttlh.RefreshReport();
                }
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
