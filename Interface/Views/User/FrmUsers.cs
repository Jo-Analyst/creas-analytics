using DataBase;
using System;
using System.Data;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmUsers : Form
    {

        int page = 1;

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
            }
        }

        private void btnArrowLeft_Click(object sender, EventArgs e)
        {
            if (page == 1)
            {
                btnArrowLeft.Enabled = false;
                btnArrowLeft.Image = Properties.Resources.left_arrow_grey;
                return;
            }
            page--;

            cbPage.Text = page.ToString();
        }

        private void btnArrowRight_Click(object sender, EventArgs e)
        {
            page++;
            btnArrowLeft.Enabled = true;
            btnArrowLeft.Image = Properties.Resources.left_arrow_white;
            cbPage.Text = page.ToString();
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
          
            cbRows.SelectedIndex = 0;

            cbPage.Items.Clear();
            for (int i = 1; i <= 14; i++)
            {
                cbPage.Items.Add(i.ToString());
            }
         
            cbPage.SelectedIndex = 0;
        }

        private void LoadUsers()
        {
            try
            {
                dgvUsers.Rows.Clear();
                DataTable dtUsers = string.IsNullOrWhiteSpace(txtName.Text) ? User.FindAll() : User.FindByName(txtName.Text.Trim());
                foreach (DataRow user in dtUsers.Rows)
                {
                    int index = dgvUsers.Rows.Add();
                    dgvUsers.Rows[index].Cells["ColADD"].Value = Properties.Resources.add_post;
                    dgvUsers.Rows[index].Cells["ColEdit"].Value = Properties.Resources.user_avatar;
                    dgvUsers.Rows[index].Cells["ColDelete"].Value = Properties.Resources.delete;
                    dgvUsers.Rows[index].Cells["ColName"].Value = user["name"].ToString();
                    dgvUsers.Rows[index].Cells["ColCPF"].Value = user["CPF"].ToString();
                    dgvUsers.Rows[index].Cells["ColBirth"].Value = user["Birth"].ToString();
                    dgvUsers.Rows[index].Cells["ColAddress"].Value = user["Address"].ToString();
                    dgvUsers.Rows[index].Cells["ColNumber"].Value = user["number_address"].ToString();
                    dgvUsers.Rows[index].Cells["ColPhone"].Value = user["phone"].ToString();
                    dgvUsers.Rows[index].Cells["ColFamilyReference"].Value = user["family_reference"].ToString();
                    dgvUsers.Rows[index].Height = 40;
                }
            }
            catch (Exception)
            {
         
            }
        }

        private void FrmUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
                btnNewUser_Click(sender, e);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }
}
