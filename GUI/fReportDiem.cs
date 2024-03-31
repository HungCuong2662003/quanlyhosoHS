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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class fReportDiem : Form
    {
      
        private bool check=false;
        public fReportDiem()
        {
            InitializeComponent();
        }

        private void fReportDiemTN_Load(object sender, EventArgs e)
        {
            ReportBLL reportBLL = new ReportBLL();
            this.reportViewer_diemtotnghiep.RefreshReport();
            comboBox_malop.DisplayMember = "lopID";
            comboBox_malop.ValueMember = "lopID";
            comboBox_malop.DataSource = reportBLL.laymalop();
            comboBox_malop1.DisplayMember = "lopID";
            comboBox_malop1.ValueMember = "lopID";
            comboBox_malop1.DataSource = reportBLL.laymalop();
            comboBox_malop.Text = "";
            comboBox_malop1.Text = "";
        }
        private void button_diemhoctap_Click(object sender, EventArgs e)
        {
            try
            {
                ReportBLL reportBLL = new ReportBLL();
                DiemHocTapDTO diemHocTapDTO = new DiemHocTapDTO();
                reportViewer_diemhoctap.LocalReport.DataSources.Clear();
                diemHocTapDTO.malop = comboBox_malop.Text;
                ReportDataSource source;
                /*if (comboBox_malop.Text == "")
                {
                    if (comboBox_hocluc.Text == "Yếu")
                    {
                        source = new ReportDataSource("DataSet1", reportBLL.XuatDiemHTtheohlYeu());
                        reportViewer_diemhoctap.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report2.rdlc";
                        reportViewer_diemhoctap.LocalReport.DataSources.Add(source);
                        reportViewer_diemhoctap.RefreshReport();
                        return;
                    }
                    else if (comboBox_hocluc.Text == "Trung bình")
                    {
                        source = new ReportDataSource("DataSet1", reportBLL.XuatDiemHTtheohlTB());
                        reportViewer_diemhoctap.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report2.rdlc";
                        reportViewer_diemhoctap.LocalReport.DataSources.Add(source);
                        reportViewer_diemhoctap.RefreshReport();
                        return;
                    }
                    else if (comboBox_hocluc.Text == "Khá")
                    {
                        source = new ReportDataSource("DataSet1", reportBLL.XuatDiemHTtheohlKha());
                        reportViewer_diemhoctap.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report2.rdlc";
                        reportViewer_diemhoctap.LocalReport.DataSources.Add(source);
                        reportViewer_diemhoctap.RefreshReport();
                        return;
                    }
                    else
                    {
                        source = new ReportDataSource("DataSet1", reportBLL.XuatDiemHTtheohlGioi());
                        reportViewer_diemhoctap.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report2.rdlc";
                        reportViewer_diemhoctap.LocalReport.DataSources.Add(source);
                        reportViewer_diemhoctap.RefreshReport();
                        return;
                    }
                }
                else if (comboBox_hocluc.Text == "")
                {
                    source = new ReportDataSource("DataSet1", reportBLL.XuatDiemHTtheolop(diemHocTapDTO));
                    reportViewer_diemhoctap.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report2.rdlc";
                    reportViewer_diemhoctap.LocalReport.DataSources.Add(source);
                    reportViewer_diemhoctap.RefreshReport();
                    return;
                }
                else
                {
                    if (comboBox_hocluc.Text == "Yếu")
                    {
                        source = new ReportDataSource("DataSet1", reportBLL.XuatDiemHTtheomahsYeu(diemHocTapDTO));
                        reportViewer_diemhoctap.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report2.rdlc";
                        reportViewer_diemhoctap.LocalReport.DataSources.Add(source);
                        reportViewer_diemhoctap.RefreshReport();
                        return;
                    }
                    else if (comboBox_hocluc.Text == "Trung bình")
                    {
                        source = new ReportDataSource("DataSet1", reportBLL.XuatDiemHTtheomahsTB(diemHocTapDTO));
                        reportViewer_diemhoctap.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report2.rdlc";
                        reportViewer_diemhoctap.LocalReport.DataSources.Add(source);
                        reportViewer_diemhoctap.RefreshReport();
                        return;
                    }
                    else if (comboBox_hocluc.Text == "Khá")
                    {
                        source = new ReportDataSource("DataSet1", reportBLL.XuatDiemHTtheomahsKha(diemHocTapDTO));
                        reportViewer_diemhoctap.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report2.rdlc";
                        reportViewer_diemhoctap.LocalReport.DataSources.Add(source);
                        reportViewer_diemhoctap.RefreshReport();
                        return;
                    }
                    else
                    {
                        source = new ReportDataSource("DataSet1", reportBLL.XuatDiemHTtheomahsGioi(diemHocTapDTO));
                        reportViewer_diemhoctap.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report2.rdlc";
                        reportViewer_diemhoctap.LocalReport.DataSources.Add(source);
                        reportViewer_diemhoctap.RefreshReport();
                        return;
                    }
                }*/
                source = new ReportDataSource("DataSet1", reportBLL.xuatdiemhk1(diemHocTapDTO));
                reportViewer_diemhoctap.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report2.rdlc";
                reportViewer_diemhoctap.LocalReport.DataSources.Add(source);
                reportViewer_diemhoctap.RefreshReport();
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi  : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_BAOCAO_Click(object sender, EventArgs e)
        {
           
            try
            {
                ReportBLL reportBLL = new ReportBLL();
                DiemHocTapDTO diemHocTapDTO = new DiemHocTapDTO();
                diemHocTapDTO.malop = comboBox_malop1.Text;
                
                reportViewer_diemtotnghiep.LocalReport.DataSources.Clear();
                if (comboBox_malop1.Text == "")
                {
                    
                    if(comboBox_tt.Text=="Đã tốt nghiệp")
                    {
                        ReportDataSource source = new ReportDataSource("DataSet1", reportBLL.xuatDiemTNtheotttotnghiep());
                        reportViewer_diemtotnghiep.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report3.rdlc";
                        reportViewer_diemtotnghiep.LocalReport.DataSources.Add(source);
                        reportViewer_diemtotnghiep.RefreshReport();
                        return;
                    }
                    else if(comboBox_tt.Text=="Chưa tốt nghiệp")
                    {
                        ReportDataSource source = new ReportDataSource("DataSet1", reportBLL.xuatDiemTNtheottchuatotnghiep());
                        reportViewer_diemtotnghiep.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report3.rdlc";
                        reportViewer_diemtotnghiep.LocalReport.DataSources.Add(source);
                        reportViewer_diemtotnghiep.RefreshReport();
                        return;
                    }
                }
                else if (comboBox_tt.Text == "")
                {
                    ReportDataSource source = new ReportDataSource("DataSet1", reportBLL.XuatDiemTNtheolop(diemHocTapDTO));
                    reportViewer_diemtotnghiep.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report3.rdlc";
                    reportViewer_diemtotnghiep.LocalReport.DataSources.Add(source);
                    reportViewer_diemtotnghiep.RefreshReport();
                    return;
                }
                else
                {
                    if (comboBox_tt.Text == "Đã tốt nghiệp")
                    {
                        ReportDataSource source = new ReportDataSource("DataSet1", reportBLL.xuatDiemTNtheomatttotnghiep(diemHocTapDTO));
                        reportViewer_diemtotnghiep.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report3.rdlc";
                        reportViewer_diemtotnghiep.LocalReport.DataSources.Add(source);
                        reportViewer_diemtotnghiep.RefreshReport();
                        return;
                    }
                    else if (comboBox_tt.Text == "Chưa tốt nghiệp")
                    {
                        ReportDataSource source = new ReportDataSource("DataSet1", reportBLL.xuatDiemTNtheomattchuatotnghiep(diemHocTapDTO));
                        reportViewer_diemtotnghiep.LocalReport.ReportPath = "D:\\winform\\quanlyhosoHS\\GUI\\Report3.rdlc";
                        reportViewer_diemtotnghiep.LocalReport.DataSources.Add(source);
                        reportViewer_diemtotnghiep.RefreshReport();
                        return;
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

        private void fReportDiemTN_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
