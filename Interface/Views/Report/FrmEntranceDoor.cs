using DataBase;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Interface.Views
{
    public partial class FrmEntranceDoor : Form
    {
        string monthCompleted;
        List<String> listCaseVioliations = new List<string>();

        public FrmEntranceDoor()
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
                DataTable dtEntranceDoor = PaefiService.GetQuantityEntranceDoor(int.Parse(cbYear.Text));

                if (cbMonth.SelectedIndex <= 0)
                {
                    int totalSpontaneousDemand = 0, totalDial100 = 0, totalDial156 = 0, totalDial180 = 0, totalReferralByPSB = 0, totalReferralByPSE_AC = 0, totalReferralByTheHealthArea = 0, totalReferralByTheEducationArea = 0, totalReferralByTheJusticeSystem = 0, totalReferralByTheGuardianshipCouncil = 0, totalReferralByPublicSecurity = 0, totalOtherReferrals = 0;
                    for (int i = 0; i <= 11; i++)
                    {
                        dgvReport.Rows.Add();
                        dgvReport.Rows[i].Cells[0].Value = new DateTime(DateTime.Now.Year, i + 1, 1).ToString("MMMM").ToUpper();
                        var entrancedoor = GetEntranceDoorQuantitiesByMonth(dtEntranceDoor, dgvReport.Rows[i].Cells[0].Value.ToString());
                        dgvReport.Rows[i].Cells[1].Value = entrancedoor.quantitySpontaneousDemand.ToString();
                        dgvReport.Rows[i].Cells[2].Value = entrancedoor.quantityDial100.ToString();
                        dgvReport.Rows[i].Cells[3].Value = entrancedoor.quantityDial156.ToString();
                        dgvReport.Rows[i].Cells[4].Value = entrancedoor.quantityDial180.ToString();
                        dgvReport.Rows[i].Cells[5].Value = entrancedoor.quantityReferralByPSB.ToString();
                        dgvReport.Rows[i].Cells[6].Value = entrancedoor.quantityReferralByPSE_AC.ToString();
                        dgvReport.Rows[i].Cells[7].Value = entrancedoor.quantityReferralByTheHealthArea.ToString();
                        dgvReport.Rows[i].Cells[8].Value = entrancedoor.quantityReferralByTheEducationArea.ToString();
                        dgvReport.Rows[i].Cells[9].Value = entrancedoor.quantityReferralByTheJusticeSystem.ToString();
                        dgvReport.Rows[i].Cells[10].Value = entrancedoor.quantityReferralByTheGuardianshipCouncil.ToString();
                        dgvReport.Rows[i].Cells[11].Value = entrancedoor.quantityReferralByPublicSecurity.ToString();
                        dgvReport.Rows[i].Cells[12].Value = entrancedoor.quantityOtherReferrals.ToString();
                        totalSpontaneousDemand += entrancedoor.quantitySpontaneousDemand;
                        totalDial100 += entrancedoor.quantityDial100;
                        totalDial156 += entrancedoor.quantityDial156;
                        totalDial180 += entrancedoor.quantityDial180;
                        totalReferralByPSB += entrancedoor.quantityReferralByPSB;
                        totalReferralByPSE_AC += entrancedoor.quantityReferralByPSE_AC;
                        totalReferralByTheHealthArea += entrancedoor.quantityReferralByTheHealthArea;
                        totalReferralByTheEducationArea += entrancedoor.quantityReferralByTheEducationArea;
                        totalReferralByTheJusticeSystem += entrancedoor.quantityReferralByTheJusticeSystem;
                        totalReferralByTheGuardianshipCouncil += entrancedoor.quantityReferralByTheGuardianshipCouncil;
                        totalReferralByPublicSecurity += entrancedoor.quantityReferralByPublicSecurity;
                        totalOtherReferrals += entrancedoor.quantityOtherReferrals;

                        dgvReport.Rows[i].Height = 45;
                        dgvReport.Rows[i].Selected = false;
                    }

                    dgvReport.Rows.Add("TOTAL", totalSpontaneousDemand, totalDial100, totalDial156, totalDial180, totalReferralByPSB, totalReferralByPSE_AC, totalReferralByTheHealthArea, totalReferralByTheEducationArea, totalReferralByTheJusticeSystem, totalReferralByTheGuardianshipCouncil, totalReferralByPublicSecurity, totalOtherReferrals);
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
                    dtGeneralServiceByMonth.Columns.Add("entrance_door", typeof(string));
                    GetMonthByIndex();
                    foreach (DataRow row in dtEntranceDoor.Rows)
                    {
                        if (row["month_insertion"].ToString().ToLower() == monthCompleted.ToLower())
                        {
                            dtGeneralServiceByMonth.Rows.Add(row["quantity"].ToString(), row["month_insertion"].ToString(), row["entrance_door"].ToString());
                        }
                    }

                    var entranceDoor = GetEntranceDoorQuantitiesByMonth(dtGeneralServiceByMonth, monthCompleted);
                    dgvReport.Rows[0].Cells[1].Value = entranceDoor.quantitySpontaneousDemand.ToString();
                    dgvReport.Rows[0].Cells[2].Value = entranceDoor.quantityDial100.ToString();
                    dgvReport.Rows[0].Cells[3].Value = entranceDoor.quantityDial156.ToString();
                    dgvReport.Rows[0].Cells[4].Value = entranceDoor.quantityDial180.ToString();
                    dgvReport.Rows[0].Cells[5].Value = entranceDoor.quantityReferralByPSB.ToString();
                    dgvReport.Rows[0].Cells[5].Value = entranceDoor.quantityReferralByPSE_AC.ToString();
                    dgvReport.Rows[0].Cells[5].Value = entranceDoor.quantityReferralByTheHealthArea.ToString();
                    dgvReport.Rows[0].Cells[5].Value = entranceDoor.quantityReferralByTheEducationArea.ToString();
                    dgvReport.Rows[0].Cells[5].Value = entranceDoor.quantityReferralByTheJusticeSystem.ToString();
                    dgvReport.Rows[0].Cells[5].Value = entranceDoor.quantityReferralByTheGuardianshipCouncil.ToString();
                    dgvReport.Rows[0].Cells[5].Value = entranceDoor.quantityReferralByPublicSecurity.ToString();
                    dgvReport.Rows[0].Cells[5].Value = entranceDoor.quantityOtherReferrals.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (int quantitySpontaneousDemand, int quantityDial100, int quantityDial156, int quantityDial180, int quantityReferralByPSB, int quantityReferralByPSE_AC, int quantityReferralByTheHealthArea, int quantityReferralByTheEducationArea, int quantityReferralByTheJusticeSystem, int quantityReferralByTheGuardianshipCouncil, int quantityReferralByPublicSecurity, int quantityOtherReferrals) GetEntranceDoorQuantitiesByMonth(DataTable dtGeneralEntranceDoor, string month)
        {
            int quantitySpontaneousDemand = 0, quantityDial100 = 0, quantityDial156 = 0, quantityDial180 = 0, quantityReferralByPSB = 0, quantityReferralByPSE_AC = 0, quantityReferralByTheHealthArea = 0, quantityReferralByTheEducationArea = 0, quantityReferralByTheJusticeSystem = 0, quantityReferralByTheGuardianshipCouncil = 0, quantityReferralByPublicSecurity = 0, quantityOtherReferrals = 0;

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

            foreach (DataRow dt in dtGeneralEntranceDoor.Rows)
            {
                string entranceDoor = dt["entrance_door"].ToString();

                if (dt["month_insertion"].ToString().ToLower() == month.ToLower())
                {

                    switch (entranceDoor.ToLower())
                    {
                        case "demanda espontânea":
                            quantitySpontaneousDemand = Convert.ToInt32(dt["quantity"]);
                            break;
                        case "disque 100":
                            quantityDial100 = Convert.ToInt32(dt["quantity"]);
                            break;
                        case "disque 156":
                            quantityDial156 = Convert.ToInt32(dt["quantity"]);
                            break;
                        case "disque 180":
                            quantityDial180 = Convert.ToInt32(dt["quantity"]);
                            break;
                        case "encaminhamento pela psb (cras; núcleos de scfv;etc;)":
                            quantityReferralByPSB = Convert.ToInt32(dt["quantity"]);
                            break;
                    }
                }
            }

            return (quantitySpontaneousDemand, quantityDial100, quantityDial156, quantityDial180, quantityReferralByPSB, quantityReferralByPSE_AC, quantityReferralByTheHealthArea, quantityReferralByTheEducationArea, quantityReferralByTheJusticeSystem, quantityReferralByTheGuardianshipCouncil, quantityReferralByPublicSecurity, quantityOtherReferrals);
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