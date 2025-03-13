using DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Interface.Views
{
    public partial class FrmReportGeneralServiceCopy : Form
    {
        int pageMaximum = 1, page = 1;
        string monthCompleted;
        List<String> listCaseVioliations = new List<string>();

        public FrmReportGeneralServiceCopy()
        {
            InitializeComponent();
        }

        private void FrmReportService_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Now.Year; i >= 2023; i--)
            {
                cbYear.Items.Add(i.ToString());
            }

            cbMonth.SelectedIndex = 0;
            cbxAll_CheckedChanged(sender, e);
            LoadData();           
        }

        private void LoadEvents()
        {
            LoadData();
        }      

        private void LoadData()
        {
            try
            {
                dgvReport.Rows.Clear();
                listCaseVioliations.Clear();

                if (cbxAll.Checked)
                {
                    for (int i = 0; i <= 11; i++)
                    {
                        dgvReport.Rows.Add();
                        dgvReport.Rows[i].Cells[0].Value = new DateTime(DateTime.Now.Year, i + 1, 1).ToString("MMMM").ToUpper();
                        dgvReport.Rows[i].Height = 45;
                        dgvReport.Rows[i].Selected = false;
                    }
                }
                else
                {
                    dgvReport.Rows.Add();
                    dgvReport.Rows[0].Cells[0].Value = monthCompleted.ToUpper();
                    dgvReport.Rows[0].Height = 45;
                    dgvReport.Rows[0].Selected = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void cbxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxAll.Checked)
            {
                cbYear.Text = DateTime.Now.Year.ToString();
                SelectedMonthTheCbMonth();
                GetMonthByIndex();
            }
            else
            {
                cbMonth.SelectedIndex = -1;
                cbYear.SelectedIndex = -1;
            }

            cbMonth.Enabled = !cbxAll.Checked;
            cbYear.Enabled = !cbxAll.Checked;
        }

        private void SelectedMonthTheCbMonth()
        {
            switch (DateTime.Now.Month)
            {
                case 1:
                    cbMonth.SelectedIndex = 0; break;
                case 2:
                    cbMonth.SelectedIndex = 1; break;
                case 3:
                    cbMonth.SelectedIndex = 2; break;
                case 4:
                    cbMonth.SelectedIndex = 3; break;
                case 5:
                    cbMonth.SelectedIndex = 4; break;
                case 6:
                    cbMonth.SelectedIndex = 5; break;
                case 7:
                    cbMonth.SelectedIndex = 6; break;
                case 8:
                    cbMonth.SelectedIndex = 7; break;
                case 9:
                    cbMonth.SelectedIndex = 8; break;
                case 10:
                    cbMonth.SelectedIndex = 9; break;
                case 11:
                    cbMonth.SelectedIndex = 10; break;
                case 12:
                    cbMonth.SelectedIndex = 11; break;

            }
        }

        private void GetMonthByIndex()
        {
            switch (cbMonth.SelectedIndex)
            {
                case 1:
                    monthCompleted = "Janeiro"; break;
                case 2:
                    monthCompleted = "Fevereiro"; break;
                case 3:
                    monthCompleted = "Março"; break;
                case 4:
                    monthCompleted = "Abril"; break;
                case 5:
                    monthCompleted = "Maio"; break;
                case 6:
                    monthCompleted = "Junho"; break;
                case 7:
                    monthCompleted = "Julho"; break;
                case 8:
                    monthCompleted = "Agosto"; break;
                case 9:
                    monthCompleted = "Setembro"; break;
                case 10:
                    monthCompleted = "Outubro"; break;
                case 11:
                    monthCompleted = "Novembro"; break;
                case 12:
                    monthCompleted = "Dezembro"; break;
                default:
                    monthCompleted = string.Empty; break;
            }
        }

        private void dgvReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvReport.CurrentRow.Selected = false;
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMonthByIndex();
            LoadEvents();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadEvents();
        }     

        private void btnGenerateChart_Click(object sender, EventArgs e)
        {
            new FrmChart(listCaseVioliations).ShowDialog();
        }

        private void FrmReportService_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
                btnGenerateChart_Click(sender, e);            
        }
    }
}
