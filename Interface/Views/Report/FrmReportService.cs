using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.Views
{
    public partial class FrmReportService : Form
    {
        public FrmReportService()
        {
            InitializeComponent();
        }

        private void FrmReportService_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Now.Year; i >= 2023 ; i--)
            {
                cbYear.Items.Add(i.ToString());
            }

            cbPage.Text = "1";
            cbRows.Text = "5";
            LoadEvents();
        }

        private void LoadEvents()
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = cbxAll.Checked ? PaefiService.FindByAll(): PaefiService.FindByPeriod(cbMonth.Text, cbYear.Text);

            dgvReport.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int index = dgvReport.Rows.Add();
                dgvReport.Rows[index].Cells["ColDate"].Value = dr["date_insertion"].ToString();
                dgvReport.Rows[index].Cells["ColName"].Value = dr["name"].ToString();
                dgvReport.Rows[index].Cells["ColBirth"].Value = dr["birth"].ToString();
                dgvReport.Rows[index].Cells["ColReference"].Value = dr["family_reference"].ToString();
                dgvReport.Rows[index].Cells["ColAddress"].Value = $"{dr["address"].ToString()}, {dr["number_address"]}";
                dgvReport.Rows[index].Cells[5].Value = dr["insertion_in_PAEFI"].ToString();
                dgvReport.Rows[index].Cells[6].Value = dr["type_of_service"].ToString();
                dgvReport.Rows[index].Cells[7].Value = dr["summary_of_demand"].ToString();
                dgvReport.Rows[index].Cells[8].Value = dr["entrance_door"].ToString();
                dgvReport.Rows[index].Cells[9].Value = dr["type_of_benefit"].ToString();
                dgvReport.Rows[index].Cells[10].Value = dr["case_of_violation"].ToString();
                dgvReport.Rows[index].Cells[11].Value = dr["is_there_follow_up"].ToString() == "1" ? "Sim": "Não";
                dgvReport.Rows[index].Cells[12].Value = dr["does_the_patient_have_special_needs"].ToString() == "1" ? "Sim" : "Não";
                dgvReport.Rows[index].Cells[13].Value = dr["interventions_performed"].ToString();
                dgvReport.Rows[index].Cells[14].Value = dr["referrals_made"].ToString();
                dgvReport.Rows[index].Cells[15].Value = dr["summary_description_of_the_case"].ToString();

                dgvReport.Rows[index].Height = 45;
                dgvReport.Rows[index].Selected = false;
            }
        }

        private void cbxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxAll.Checked)
            {
                SelectedMonthTheCbMonth();
                cbYear.Text = DateTime.Now.Year.ToString();
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

        private void dgvReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvReport.CurrentRow.Selected = false;
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEvents();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEvents();
        }
    }
}
