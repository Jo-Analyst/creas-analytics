using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml.Linq;
using DataBase;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            dgvHistory.Focus();
            cbPage.Text = "1";
            cbRows.Text = "5";
            loadEvents();
            this.cbRows.SelectedIndexChanged += cbRows_SelectedIndexChanged;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbPage_SelectedIndexChanged);
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

                loadEvents();

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
            catch (Exception) { 
            MessageBox.Show("Houve um erro no sistema. Tente novamente mais tarde", "Creas Analytics", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateFields()
        {
            return string.IsNullOrWhiteSpace(txtInsertionInPaefi.Text) && string.IsNullOrWhiteSpace(txtDescription.Text) && string.IsNullOrWhiteSpace(txtEntranceDoor.Text) && string.IsNullOrWhiteSpace(txtReferralsMade.Text) && string.IsNullOrWhiteSpace(txtSummaryOfDemand.Text) && string.IsNullOrWhiteSpace(txtTypeBenefits.Text) && !rbHomeVisit.Checked && !rbNoFollowUp.Checked && !rbNoThereIsANeed.Checked && !rbPresence.Checked && !rbYesFollowUp.Checked && !rbYesThereIsANeed.Checked && !rbDistance.Checked;
        }

        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
         
            bool isConfirmed = false;

            dgvHistory.CurrentRow.Selected = false;

            int id = Convert.ToInt32(dgvHistory.CurrentRow.Cells[2].Value);
            //string name = dgvHistory.CurrentRow.Cells["ColName"].Value.ToString();
            //string CPF = dgvHistory.CurrentRow.Cells["ColCpf"].Value.ToString();
            //string birth = dgvHistory.CurrentRow.Cells["ColBirth"].Value.ToString();
            //string address = dgvHistory.CurrentRow.Cells["ColAddress"].Value.ToString();
            //string numberAddress = dgvHistory.CurrentRow.Cells["ColNumber"].Value.ToString();
            //string phone = dgvHistory.CurrentRow.Cells["ColPhone"].Value.ToString();
            //string familyReference = dgvHistory.CurrentRow.Cells["ColFamilyReference"].Value.ToString();

            //if (dgvHistory.CurrentCell.ColumnIndex == 0)
            //{

            //    FrmSaveUser frmUser = new FrmSaveUser(id, name, CPF, birth, phone, address, numberAddress, familyReference);
            //    frmUser.ShowDialog();
            //    if (frmUser.isSaved)
            //        isConfirmed = true;
            //}
            //else

            if (dgvHistory.CurrentCell.ColumnIndex == 1)
            {
                DialogResult dr = MessageBox.Show($"Deseja mesmo excluir este atendimento?", "CREAS Analytcs", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        PaefiService.Delete(id);
                        isConfirmed = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (isConfirmed) loadEvents();
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

        private void UpdateComboBoxItems()
        {
            cbPage.Items.Clear();
            for (int i = 1; i <= pageMaximum; i++)
            {
                cbPage.Items.Add(i);
            }
         
            cbPage.Text = (page > pageMaximum ? pageMaximum : page).ToString();
        }

        int page = 1, pageMaximum = 1;

        private void CheckNumberOfPages(int numberRows)
        {
            PageData.quantityRowsSelected = numberRows;
            pageMaximum =  PageData.SetPageQuantityServices(userId);
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