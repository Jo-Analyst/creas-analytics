using DataBase;
using System;
using System.Data;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmUsers : Form
    {

        int page = 1, pageMaximum = 1;

        public FrmUsers()
        {
            InitializeComponent();
        }


        private void btnNewUser_Click(object sender, EventArgs e)
        {
            FrmSaveUser frmSaveUser = new FrmSaveUser();
            frmSaveUser.ShowDialog();
            if (frmSaveUser.isSaved)
            {
                FrmUsers_Load(sender, e);
                LoadEvents();
            }
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
            LoadUsers();
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
            LoadUsers();
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

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            cbPage.Text = "1";
            cbRows.Text = "5";
            LoadEvents();
            this.cbRows.SelectedIndexChanged += cbRows_SelectedIndexChanged;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbPage_SelectedIndexChanged);
        }

        private void CheckNumberOfPages(int numberRows)
        {
            PageData.quantityRowsSelected = numberRows;
            pageMaximum = string.IsNullOrWhiteSpace(txtName.Text) ? PageData.SetPageQuantityUsers() : PageData.SetPageQuantityUsersByName(txtName.Text);

            if (pageMaximum > 1)
                EnabledBtnArrowRight();

        }

        private void LoadUsers()
        {
            try
            {
                dgvUsers.Rows.Clear();

                int quantRows = int.Parse(cbRows.Text);
                int pageSelected = (page - 1) * quantRows;

                DataTable dtUsers = string.IsNullOrWhiteSpace(txtName.Text) ? User.FindAll(pageSelected, quantRows) : User.FindByName(txtName.Text.Trim(), pageSelected, quantRows);

                foreach (DataRow user in dtUsers.Rows)
                {
                    int index = dgvUsers.Rows.Add();
                    dgvUsers.Rows[index].Cells["ColADD"].Value = Properties.Resources.add_post;
                    dgvUsers.Rows[index].Cells["ColEdit"].Value = Properties.Resources.user_avatar;
                    dgvUsers.Rows[index].Cells["ColDelete"].Value = Properties.Resources.delete;
                    dgvUsers.Rows[index].Cells["ColId"].Value = user["id"].ToString();
                    dgvUsers.Rows[index].Cells["ColName"].Value = user["name"].ToString();
                    dgvUsers.Rows[index].Cells["ColCPF"].Value = string.IsNullOrEmpty(user["CPF"].ToString()) ? "" : Security.Dry(user["CPF"].ToString());
                    dgvUsers.Rows[index].Cells["ColBirth"].Value = user["Birth"].ToString();
                    dgvUsers.Rows[index].Cells["ColAddress"].Value = user["Address"].ToString();
                    dgvUsers.Rows[index].Cells["ColNumber"].Value = user["number_address"].ToString();
                    dgvUsers.Rows[index].Cells["ColPhone"].Value = user["phone"].ToString();
                    dgvUsers.Rows[index].Cells["ColFamilyReference"].Value = user["family_reference"].ToString();
                    dgvUsers.Rows[index].Height = 45;
                }

                UpdateUserDescription();
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUserDescription()
        {
            lblDescriptionRow.Text = $"Exibindo {dgvUsers.Rows.Count} de {PageData.quantity} usuários cadastrados";
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

        private void FrmUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
                btnNewUser_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Right && btnArrowRight.Enabled) btnArrowRight_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Left && btnArrowLeft.Enabled) btnArrowLeft_Click(sender, e);
        }

        private void LoadEvents()
        {
            CheckNumberOfPages(int.Parse(cbRows.Text));
            UpdateComboBoxItems();
            LoadUsers();
            UpdateUserDescription();
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

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = int.Parse(cbPage.Text);
            if (pageMaximum == 1) return;

            LoadUsers();

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

        private void dgvUsers_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvUsers.Cursor = e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 ? Cursors.Hand : Cursors.Arrow;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            bool isConfirmed = false;

            if (e.RowIndex == -1) return;

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["ColId"].Value);
            string name = dgvUsers.CurrentRow.Cells["ColName"].Value.ToString();
            string CPF = dgvUsers.CurrentRow.Cells["ColCpf"].Value.ToString();
            string birth = dgvUsers.CurrentRow.Cells["ColBirth"].Value.ToString();
            string address = dgvUsers.CurrentRow.Cells["ColAddress"].Value.ToString();
            string numberAddress = dgvUsers.CurrentRow.Cells["ColNumber"].Value.ToString();
            string phone = dgvUsers.CurrentRow.Cells["ColPhone"].Value.ToString();
            string familyReference = dgvUsers.CurrentRow.Cells["ColFamilyReference"].Value.ToString();

            if (dgvUsers.CurrentCell.ColumnIndex == 0)
            {
                FrmCustomerService frmCustomer = new FrmCustomerService(id, name);
                frmCustomer.ShowDialog();
            }
            else if (dgvUsers.CurrentCell.ColumnIndex == 1)
            {

                FrmSaveUser frmUser = new FrmSaveUser(id, name, CPF, birth, phone, address, numberAddress, familyReference);
                frmUser.ShowDialog();
                if (frmUser.isSaved)
                    isConfirmed = true;
            }
            else if (dgvUsers.CurrentCell.ColumnIndex == 2)
            {
                DialogResult dr = MessageBox.Show($"Deseja mesmo excluir o(a) usuário(a) {name} do sistema?", "CREAS Analytcs", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        User.Delete(id);
                        isConfirmed = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (isConfirmed) LoadEvents();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            LoadEvents();
            if (pageMaximum == 1)
            {
                DisabledBtnArrowLeft();
                DisabledBtnArrowRight();
            }
        }
    }
}