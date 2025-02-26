using DataBase;
using Interface.Properties;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Interface
{
    public partial class FrmCustomerService : Form
    {

        int userId, page = 1, pageMaximum = 1, serviceId;

        public FrmCustomerService()
        {
            InitializeComponent();
        }

        public FrmCustomerService(int userId, string name)
        {
            InitializeComponent();
            this.userId = userId;
            lblName.Text = name;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbCaseOfViolation.ClearSelected();
        }

        private void FrmCustomerService_Load(object sender, EventArgs e)
        {
            dtDate.MaxDate = DateTime.Now;
            dgvHistory.Focus();
            cbPage.Text = "1";
            cbRows.Text = "5";
            ToFillInCheckListBox();
            loadEvents();
            this.cbRows.SelectedIndexChanged += cbRows_SelectedIndexChanged;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbPage_SelectedIndexChanged);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = IsValidateFields();

            if (!isValid)
            {
                MessageBox.Show("Informe as informações que são necessárias para o relatório.", "CREAS Analytics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (clbCaseOfViolation.CheckedItems.Count == 0)
            {
                MessageBox.Show("Informe os casos de violência.", "CREAS Analytics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (btnSave.Text == "Novo")
            {
                ClearFields();
                btnSave.Text = "Salvar";
                return;
            }

            PaefiService paefiService = new PaefiService();
            try
            {
                paefiService.id = serviceId;
                paefiService.dateInsertion = dtDate.Value;
                paefiService.insertionInPaefi = txtInsertionInPaefi.Text.Trim();
                paefiService.summaryDescriptionOfTheCase = txtDescription.Text.Trim();
                paefiService.entranceDoor = txtEntranceDoor.Text.Trim();
                paefiService.interventionsPerformed = txtInterventionsPerformed.Text.Trim();
                paefiService.typeOfBenefit = txtTypeBenefits.Text.Trim();
                paefiService.referralsMade = txtReferralsMade.Text.Trim();
                paefiService.summaryOfDemand = txtSummaryOfDemand.Text.Trim();
                paefiService.caseOfViolation = "";
                paefiService.userId = userId;

                if (rbDistance.Checked)
                    paefiService.typeOfService = "A distância";
                else if (rbHomeVisit.Checked)
                    paefiService.typeOfService = "Visita domiciliar";
                else if (rbPresence.Checked)
                    paefiService.typeOfService = "Presencial";

                paefiService.isThereFollowUp = rbYesFollowUp.Checked;
                paefiService.doesThePatientHaveSpecialNeeds = rbYesThereIsANeed.Checked;

                foreach (var item in clbCaseOfViolation.CheckedItems)
                {
                    paefiService.caseOfViolation += $"{item};";
                }

                paefiService.Save();
                lblStatus.Text = "Atendimento salvo com sucesso";

                loadEvents();
                if (serviceId > 0)
                {
                    ClearFields();
                    return;
                }

                btnSave.Text = "Novo";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void loadDgvHistory()
        {
            try
            {
                dgvHistory.Rows.Clear();

                int quantRows = int.Parse(cbRows.Text);
                int pageSelected = (page - 1) * quantRows;

                DataTable paefiServices = PaefiService.FindByUserId(userId, pageSelected, quantRows);

                foreach (DataRow dr in paefiServices.Rows)
                {
                    int index = dgvHistory.Rows.Add();
                    dgvHistory.Rows[index].Cells[0].Value = Properties.Resources.edit;
                    dgvHistory.Rows[index].Cells[1].Value = Properties.Resources.delete;
                    dgvHistory.Rows[index].Cells[2].Value = dr["id"].ToString();
                    dgvHistory.Rows[index].Cells[3].Value = dr["date_insertion"].ToString();
                    dgvHistory.Rows[index].Cells[4].Value = dr["insertion_in_PAEFI"].ToString();
                    dgvHistory.Rows[index].Cells[5].Value = dr["type_of_service"].ToString();
                    dgvHistory.Rows[index].Cells[6].Value = dr["summary_of_demand"].ToString();
                    dgvHistory.Rows[index].Cells[7].Value = dr["entrance_door"].ToString();
                    dgvHistory.Rows[index].Cells[8].Value = dr["type_of_benefit"].ToString();
                    dgvHistory.Rows[index].Cells[9].Value = dr["case_of_violation"].ToString();
                    dgvHistory.Rows[index].Cells[10].Value = dr["is_there_follow_up"].ToString() == "1" ? "Sim" : "Não";
                    dgvHistory.Rows[index].Cells[11].Value = dr["does_the_patient_have_special_needs"].ToString() == "1" ? "Sim" : "Não";
                    dgvHistory.Rows[index].Cells[12].Value = dr["interventions_performed"].ToString();
                    dgvHistory.Rows[index].Cells[13].Value = dr["referrals_made"].ToString();
                    dgvHistory.Rows[index].Cells[14].Value = dr["summary_description_of_the_case"].ToString();


                    dgvHistory.Rows[index].Selected = false;
                    dgvHistory.Rows[index].Height = 45;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema. Tente novamente mais tarde", "Creas Analytics", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidateFields()
        {
            return !string.IsNullOrWhiteSpace(txtInsertionInPaefi.Text) || !string.IsNullOrWhiteSpace(txtDescription.Text) || !string.IsNullOrWhiteSpace(txtEntranceDoor.Text) || !string.IsNullOrWhiteSpace(txtReferralsMade.Text) || !string.IsNullOrWhiteSpace(txtSummaryOfDemand.Text) || !string.IsNullOrWhiteSpace(txtTypeBenefits.Text);
        }

        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            dgvHistory.CurrentRow.Selected = false;

            int id = Convert.ToInt32(dgvHistory.CurrentRow.Cells[2].Value);
            if (dgvHistory.CurrentCell.ColumnIndex == 0)
            {
                ClearFields();
                serviceId = int.Parse(dgvHistory.CurrentRow.Cells[2].Value.ToString());
                dtDate.Text = dgvHistory.CurrentRow.Cells[3].Value.ToString();
                txtInsertionInPaefi.Text = dgvHistory.CurrentRow.Cells[4].Value.ToString();
                string typeService = dgvHistory.CurrentRow.Cells[5].Value.ToString();

                switch (typeService)
                {
                    case "A distância":
                        rbDistance.Checked = true; break;
                    case "Visita domiciliar":
                        rbHomeVisit.Checked = true; break;
                    case "Presencial":
                        rbPresence.Checked = true; break;
                }

                txtSummaryOfDemand.Text = dgvHistory.CurrentRow.Cells[6].Value.ToString();
                txtEntranceDoor.Text = dgvHistory.CurrentRow.Cells[7].Value.ToString();
                txtTypeBenefits.Text = dgvHistory.CurrentRow.Cells[8].Value.ToString();

                var caseOfViolation = dgvHistory.CurrentRow.Cells[9].Value.ToString().Split(';');

                ClearCheckedTheListBox();
                foreach (var check in caseOfViolation)
                {
                    int index = clbCaseOfViolation.Items.IndexOf(check);

                    if (index != -1)
                    {
                        clbCaseOfViolation.SetItemChecked(index, true);
                    }
                    else if(!string.IsNullOrWhiteSpace(check))
                    {
                        clbCaseOfViolation.Items.Add(check,true);
                    }
                }

                string is_there_follow_up = dgvHistory.CurrentRow.Cells[10].Value.ToString();

                if (is_there_follow_up == "Sim")

                    rbYesFollowUp.Checked = true;
                else rbNoFollowUp.Checked = true;

                string doesThePatientHaveSpecialNeeds = dgvHistory.CurrentRow.Cells[11].Value.ToString();


                if (doesThePatientHaveSpecialNeeds == "Sim")
                    rbYesThereIsANeed.Checked = true;
                else rbNoThereIsANeed.Checked = true;
                txtInterventionsPerformed.Text = dgvHistory.CurrentRow.Cells[12].Value.ToString();
                txtReferralsMade.Text = dgvHistory.CurrentRow.Cells[13].Value.ToString();
                txtDescription.Text = dgvHistory.CurrentRow.Cells[14].Value.ToString();
            }


            if (dgvHistory.CurrentCell.ColumnIndex == 1)
            {
                DialogResult dr = MessageBox.Show($"Deseja mesmo excluir este atendimento?", "CREAS Analytcs", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        PaefiService.Delete(id);
                        ClearFields();
                        loadEvents();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearCheckedTheListBox()
        {
            clbCaseOfViolation.Items.Clear();
            ToFillInCheckListBox();
        }

        private void cbRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadEvents();
            if (page == pageMaximum)
            {
                DisabledBtnArrowLeft();
                DisabledBtnArrowRight();
            }
        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = int.Parse(cbPage.Text);
            if (pageMaximum == 1) return;

            loadDgvHistory();

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

        private void loadEvents()
        {
            CheckNumberOfPages(int.Parse(cbRows.SelectedItem.ToString()));
            UpdateComboBoxItems();
            loadDgvHistory();

        }

        private void ToFillInCheckListBox()
        {
            List<String> caseOfViolations = new List<String>(Settings.Default["caseOfViolations"].ToString().Split(';'));
            foreach (String caseOfViolation in caseOfViolations)
            {
                clbCaseOfViolation.Items.Add(caseOfViolation);
            }
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

        private void CheckNumberOfPages(int numberRows)
        {
            PageData.quantityRowsSelected = numberRows;
            pageMaximum = PageData.SetPageQuantityServices(userId);
            if (pageMaximum > 1)
                EnabledBtnArrowRight();

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
            dgvHistory.Focus();
            loadDgvHistory();
        }

        private void EnabledBtnArrowLeft()
        {
            btnArrowLeft.Enabled = true;
            btnArrowLeft.Image = Properties.Resources.left_arrow_white;
        }

        private void DisabledBtnArrowRight()
        {
            btnArrowRight.Enabled = false;
            btnArrowRight.Image = Properties.Resources.right_arrow_grey;
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

            dgvHistory.Focus();
            loadDgvHistory();
        }

        private void ClearFields()
        {
            txtDescription.Clear();
            txtEntranceDoor.Clear();
            txtInsertionInPaefi.Clear();
            txtInterventionsPerformed.Clear();
            txtReferralsMade.Clear();
            txtSummaryOfDemand.Clear();
            txtTypeBenefits.Clear();
            rbHomeVisit.Checked = true;
            rbNoFollowUp.Checked = true;
            rbNoThereIsANeed.Checked = true;
            ClearCheckedTheListBox();
            lblStatus.Text = string.Empty;
            serviceId = 0;
            dtDate.Text = DateTime.Now.ToShortDateString();
            btnSave.Text = "Salvar";
        }

        private void FrmCustomerService_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Right && btnArrowRight.Enabled) btnArrowRight_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Left && btnArrowLeft.Enabled) btnArrowLeft_Click(sender, e);
        }

        private void DisabledBtnArrowLeft()
        {
            btnArrowLeft.Enabled = false;
            btnArrowLeft.Image = Properties.Resources.left_arrow_grey;
        }

        private void dgvHistory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvHistory.Cursor = e.ColumnIndex == 0 || e.ColumnIndex == 1 ? Cursors.Hand : Cursors.Arrow;
        }

        private void EnabledBtnArrowRight()
        {
            btnArrowRight.Enabled = true;
            btnArrowRight.Image = Properties.Resources.right_arrow_white;
        }
    }
}