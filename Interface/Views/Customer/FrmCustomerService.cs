using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using DataBase;

namespace Interface
{
    public partial class FrmCustomerService : Form
    {
        
        int userId;

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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PaefiService paefiService = new PaefiService();
            try
            {
                paefiService.dateInsertion = dtDate.Value;
                paefiService.insertionInPaefi = txtInsertionInPaefi.Text.Trim();
                paefiService.summaryDescriptionOfTheCase = txtDescription.Text.Trim();
                paefiService.entranceDoor = txtEntranceDoor.Text.Trim();
                paefiService.interventionsPerformed = txtInterventionsPerformed.Text.Trim();
                paefiService.summaryDescriptionOfTheCase = txtSummaryOfDemand.Text.Trim();
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

                //var checkedItems = new List<string>();
                //checkedItems.Add("Violência física contra mulher");
                //checkedItems.Add("Violência psicológica contra mulher");

                //foreach (var check in checkedItems)
                //{
                //    int index = clbCaseOfViolation.Items.IndexOf(check);

                //    if(index != -1)
                //    {
                //        clbCaseOfViolation.SetItemChecked(index, true);
                //    }
                //}

                foreach (var item in clbCaseOfViolation.CheckedItems)
                {
                    paefiService.caseOfViolation += $"{item};";
                }

               int result = paefiService.Save();
                lblStatus.Text = "Atendimento salvo com sucesso";

                SetDdgHistory(result, dtDate.Value.ToShortDateString(), txtInsertionInPaefi.Text.Trim(), txtSummaryOfDemand.Text.Trim(), txtEntranceDoor.Text.Trim(), txtTypeBenefits.Text.Trim(), txtInterventionsPerformed.Text.Trim(), txtReferralsMade.Text.Trim(), txtDescription.Text.Trim(), paefiService.typeOfService, paefiService.isThereFollowUp ? "Sim": "Não", paefiService.doesThePatientHaveSpecialNeeds ? "Sim" : "Não", paefiService.caseOfViolation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SetDdgHistory(int id, string date, string insertionInPaefi, string summaryOfDemand, string entranceDoor, string typeBenefits, string interventionsPerformed, string referralsMade, string description, string service, string followUp, string thereIsANeed, string caseOfViolation)
        {
            int index = dgvHistory.Rows.Add();
            dgvHistory.Rows[index].Cells[0].Value = Properties.Resources.edit;
            dgvHistory.Rows[index].Cells[1].Value = Properties.Resources.delete;
            dgvHistory.Rows[index].Cells[2].Value = id;
            dgvHistory.Rows[index].Cells[3].Value = date;
            dgvHistory.Rows[index].Cells[4].Value = insertionInPaefi;
            dgvHistory.Rows[index].Cells[5].Value = service;
            dgvHistory.Rows[index].Cells[6].Value = summaryOfDemand;
            dgvHistory.Rows[index].Cells[7].Value = entranceDoor;
            dgvHistory.Rows[index].Cells[8].Value = typeBenefits;
            dgvHistory.Rows[index].Cells[9].Value = caseOfViolation;
            dgvHistory.Rows[index].Cells[10].Value = followUp;
            dgvHistory.Rows[index].Cells[11].Value = thereIsANeed;
            dgvHistory.Rows[index].Cells[12].Value = interventionsPerformed;
            dgvHistory.Rows[index].Cells[13].Value = referralsMade;
            dgvHistory.Rows[index].Cells[14].Value = description;
            

            dgvHistory.Rows[index].Selected = false;
            dgvHistory.Rows[index].Height = 45; 
        }

        private bool validateFields()
        {
            return string.IsNullOrWhiteSpace(txtInsertionInPaefi.Text) && string.IsNullOrWhiteSpace(txtDescription.Text) && string.IsNullOrWhiteSpace(txtEntranceDoor.Text) && string.IsNullOrWhiteSpace(txtReferralsMade.Text) && string.IsNullOrWhiteSpace(txtSummaryOfDemand.Text) && string.IsNullOrWhiteSpace(txtTypeBenefits.Text) && !rbHomeVisit.Checked && !rbNoFollowUp.Checked && !rbNoThereIsANeed.Checked && !rbPresence.Checked && !rbYesFollowUp.Checked && !rbYesThereIsANeed.Checked && !rbDistance.Checked;
        }
    }
}