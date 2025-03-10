using DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Interface.Views
{
    public partial class FrmReportGeneralService : Form
    {
        int pageMaximum = 1, page = 1;
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

            cbPage.Text = "1";
            cbRows.Text = "5";
            cbxAll_CheckedChanged(sender, e);
            this.cbRows.SelectedIndexChanged += cbRows_SelectedIndexChanged;
            this.cbYear.SelectedIndexChanged += cbYear_SelectedIndexChanged;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbPage_SelectedIndexChanged);
        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = int.Parse(cbPage.Text);
            if (pageMaximum == 1) return;

            LoadData();

            if (page == 1)
            {
                DisabledBtnArrowLeft();
                EnabledBtnArrowRight();
            }
            else if (page == pageMaximum)
            {
                DisabledBtnArrowRight();
                EnabledBtnArrowLeft();
            }

            else
            {
                EnabledBtnArrowLeft();
                EnabledBtnArrowRight();
            }
        }

        private void LoadEvents()
        {
            CheckNumberOfPages(int.Parse(cbRows.Text));
            UpdateComboBoxItems();
            LoadData();
            UpdateUserDescription();
        }

        private void UpdateComboBoxItems()
        {
            cbPage.Items.Clear();
            for (int i = 1; i <= pageMaximum; i++)
            {
                cbPage.Items.Add(i);
            }
            cbPage.Text = (page > pageMaximum ? pageMaximum : page).ToString();
        }

        private void LoadData()
        {
            try
            {
                int quantRows = int.Parse(cbRows.Text);
                int pageSelected = (page - 1) * quantRows;

                DataTable dt = cbxAll.Checked ? PaefiService.FindByAll(pageSelected, quantRows) : PaefiService.FindByPeriod(cbMonth.Text, cbYear.Text, pageSelected, quantRows);          
               
                dgvReport.Rows.Clear();
                listCaseVioliations.Clear();
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
                    dgvReport.Rows[index].Cells[11].Value = dr["is_there_follow_up"].ToString() == "1" ? "Sim" : "Não";
                    dgvReport.Rows[index].Cells[12].Value = dr["does_the_patient_have_special_needs"].ToString() == "1" ? "Sim" : "Não";
                    dgvReport.Rows[index].Cells[13].Value = dr["interventions_performed"].ToString();
                    dgvReport.Rows[index].Cells[14].Value = dr["referrals_made"].ToString();
                    dgvReport.Rows[index].Cells[15].Value = dr["summary_description_of_the_case"].ToString();
                  

                    dgvReport.Rows[index].Height = 45;
                    dgvReport.Rows[index].Selected = false;
                }

                DataTable dataTable = cbxAll.Checked ? PaefiService.FindByAll() : PaefiService.FindByPeriod(cbMonth.Text, cbYear.Text);

                foreach (DataRow dr in dataTable.Rows)
                {
                    listCaseVioliations.Add(dr["case_of_violation"].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckNumberOfPages(int numberRows)
        {
            try
            {
                PageData.quantityRowsSelected = numberRows;
                pageMaximum = cbxAll.Checked ? PageData.SetPageQuantityServicesAll() : PageData.SetPageQuantityServicesByPeriod(cbMonth.Text, cbYear.Text);
                if (pageMaximum > 1)
                    EnabledBtnArrowRight();
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DisabledBtnArrowLeft()
        {
            btnArrowLeft.Enabled = false;
            btnArrowLeft.Image = Properties.Resources.left_arrow_grey;
        }

        private void DisabledBtnArrowRight()
        {
            btnArrowRight.Enabled = false;
            btnArrowRight.Image = Properties.Resources.right_arrow_grey;
        }

        private void EnabledBtnArrowLeft()
        {
            btnArrowLeft.Enabled = true;
            btnArrowLeft.Image = Properties.Resources.left_arrow_white;
        }

        private void EnabledBtnArrowRight()
        {
            btnArrowRight.Enabled = true;
            btnArrowRight.Image = Properties.Resources.right_arrow_white;
        }

        private void UpdateUserDescription()
        {
            lblDescriptionRow.Text = cbxAll.Checked ? $"Exibindo {dgvReport.Rows.Count} de {PageData.quantity} atendimentos realizados" : $"Exibindo {dgvReport.Rows.Count} de {PageData.quantity} atendimentos realizados em {monthCompleted} de {cbYear.Text}";
        }

        private void cbxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxAll.Checked)
            {
                cbYear.Text = DateTime.Now.Year.ToString();
                SelectedMonthTheCbMonth();
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
                case 0:
                    monthCompleted = "Janeiro"; break;
                case 1:
                    monthCompleted = "Fevereiro"; break;
                case 2:
                    monthCompleted = "Março"; break;
                case 3:
                    monthCompleted = "Abril"; break;
                case 4:
                    monthCompleted = "Maio"; break;
                case 5:
                    monthCompleted = "Junho"; break;
                case 6:
                    monthCompleted = "Julho"; break;
                case 7:
                    monthCompleted = "Agosto"; break;
                case 8:
                    monthCompleted = "Setembro"; break;
                case 9:
                    monthCompleted = "Outubro"; break;
                case 10:
                    monthCompleted = "Novembro"; break;
                case 11:
                    monthCompleted = "Dezembro"; break;
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
            LoadEvents();
        }

        private void btnArrowRight_Click(object sender, EventArgs e)
        {
            if (page < pageMaximum)
            {
                page++;
            }

            cbPage.Text = page.ToString();

            if (page == pageMaximum)
            {

                DisabledBtnArrowRight();

            }

            else
            {
                btnArrowLeft.Enabled = true;
                btnArrowLeft.Image = Properties.Resources.left_arrow_white;

            }

            EnabledBtnArrowLeft();
            LoadData();
        }

        private void btnArrowLeft_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
            }

            cbPage.Text = page.ToString();

            if (page == 1)
            {
                DisabledBtnArrowLeft();
                EnabledBtnArrowRight();
            }
            else
            {
                EnabledBtnArrowLeft();
            }
            LoadData();
        }

        private void cbRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEvents();
            if (page == pageMaximum)
            {
                DisabledBtnArrowLeft();
                DisabledBtnArrowRight();
            }
        }

        private void btnGenerateChart_Click(object sender, EventArgs e)
        {
            new FrmChart(listCaseVioliations).ShowDialog();
        }

        private void FrmReportService_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
                btnGenerateChart_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Right && btnArrowRight.Enabled) btnArrowRight_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Left && btnArrowLeft.Enabled) btnArrowLeft_Click(sender, e);
        }
    }
}
