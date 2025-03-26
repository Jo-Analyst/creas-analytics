using DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Interface.Views
{
    public partial class FrmReportGeneralService : Form
    {
        string monthCompleted;
        List<String> listCaseVioliations = new List<string>();

        public FrmReportGeneralService()
        {
            InitializeComponent();
        }

        private void FrmReportService_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Now.Year; i >= 2023; i--)
            {
                cbYear.Items.Add(i.ToString());
            }

            cbYear.SelectedIndex = 0;
            cbMonth.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvReport.Rows.Clear();
                listCaseVioliations.Clear();
                DataTable dtGeneralServices = PaefiService.GetQuantityService(int.Parse(cbYear.Text));

                if (cbMonth.SelectedIndex <= 0)
                {
                    int totalPresence = 0, totalDistance = 0, totalHomeVisity = 0;
                    for (int i = 0; i <= 11; i++)
                    {
                        dgvReport.Rows.Add();
                        dgvReport.Rows[i].Cells[0].Value = new DateTime(DateTime.Now.Year, i + 1, 1).ToString("MMMM").ToUpper();
                        dgvReport.Rows[i].Cells[1].Value = 0;
                        dgvReport.Rows[i].Cells[2].Value = 0;
                        dgvReport.Rows[i].Cells[3].Value = 0;
                        var service = GetServiceQuantitiesByMonth(dtGeneralServices, dgvReport.Rows[i].Cells[0].Value.ToString());
                        dgvReport.Rows[i].Cells[1].Value = service.quantityPresence.ToString();
                        dgvReport.Rows[i].Cells[2].Value = service.quantityDistance.ToString();
                        dgvReport.Rows[i].Cells[3].Value = service.quantityHomeVisity.ToString();
                        totalPresence += service.quantityPresence;
                        totalDistance += service.quantityDistance;
                        totalHomeVisity += service.quantityHomeVisity;

                        dgvReport.Rows[i].Height = 45;
                        dgvReport.Rows[i].Selected = false;
                    }

                    dgvReport.Rows.Add("TOTAL", totalPresence, totalDistance, totalHomeVisity);
                    dgvReport.Rows[dgvReport.Rows.Count - 1].Height = 45;
                    dgvReport.Rows[dgvReport.Rows.Count - 1].Selected = false;
                }
                else
                {
                    dgvReport.Rows.Add();
                    dgvReport.Rows[0].Cells[0].Value = monthCompleted.ToUpper();
                    dgvReport.Rows[0].Height = 45;
                    dgvReport.Rows[0].Selected = false;
                    DataTable dtGeneralServiceByMonth = new DataTable();
                    dtGeneralServiceByMonth.Columns.Add("quantity", typeof(string));
                    dtGeneralServiceByMonth.Columns.Add("month_insertion", typeof(string));
                    dtGeneralServiceByMonth.Columns.Add("general_services", typeof(string));
                    GetMonthByIndex();
                    foreach (DataRow row in dtGeneralServices.Rows)
                    {
                        if (row["month_insertion"].ToString().ToLower() == monthCompleted.ToLower())
                        {
                            dtGeneralServiceByMonth.Rows.Add(row["quantity"].ToString(), row["month_insertion"].ToString(), row["general_services"].ToString());
                        }
                    }

                    var service = GetServiceQuantitiesByMonth(dtGeneralServiceByMonth, monthCompleted);
                    dgvReport.Rows[0].Cells[1].Value = service.quantityPresence.ToString();
                    dgvReport.Rows[0].Cells[2].Value = service.quantityDistance.ToString();
                    dgvReport.Rows[0].Cells[3].Value = service.quantityHomeVisity.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (int quantityDistance, int quantityHomeVisity, int quantityPresence) GetServiceQuantitiesByMonth(DataTable dtGeneralService, string month)
        {
            int quantityDistance = 0, quantityHomeVisity = 0, quantityPresence = 0;
            Dictionary<string, int> monthIndex = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
            { "janeiro", 0 },
            { "fevereiro", 1 },
            { "março", 2 },
            { "abril", 3 },
            { "maio", 4 },
            { "junho", 5 },
            { "julho", 6 },
            { "agosto", 7 },
            { "setembro", 8 },
            { "outubro", 9 },
            { "novembro", 10 },
            { "dezembro", 11},
            };

            if (!monthIndex.ContainsKey(month))
            {
                throw new ArgumentException("Mês inválido fornecido.", nameof(month));
            }

            int rowIndex = monthIndex[month];

            foreach (DataRow dt in dtGeneralService.Rows)
            {
                string typeOfService = dt["general_services"].ToString();

                if (dt["month_insertion"].ToString().ToLower() == month.ToLower())
                {
                    switch (typeOfService)
                    {
                        case "Presencial":
                            quantityPresence = Convert.ToInt32(dt["quantity"]);
                            break;
                        case "A distância":
                            quantityDistance = Convert.ToInt32(dt["quantity"]);
                            break;
                        case "Visita domiciliar":
                            quantityHomeVisity = Convert.ToInt32(dt["quantity"]);
                            break;
                    }
                }
            }

            return (quantityDistance, quantityHomeVisity, quantityPresence);
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
            LoadData();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
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