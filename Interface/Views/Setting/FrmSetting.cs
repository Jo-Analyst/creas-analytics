using Interface.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmSetting : Form
    {
        List<string> caseOfViolations;
        bool isEdition;
        int indexCurrent;

        public FrmSetting()
        {
            InitializeComponent();

            cbPrint.Checked = bool.Parse(Settings.Default["print_directory_direct"].ToString());
            txtDirectoryBackup.Text = Settings.Default["path_Backup"].ToString();
            caseOfViolations = new List<string>(Settings.Default["caseOfViolations"].ToString().Split(';'));
            foreach (string caseOfViolation in caseOfViolations)
            {
               InsertDataInDgv(caseOfViolation);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Settings.Default["print_directory_direct"] = cbPrint.Checked;
            Settings.Default["path_Backup"] = txtDirectoryBackup.Text;
            Settings.Default["caseOfViolations"] = String.Join(";", caseOfViolations);
            Settings.Default.Save();
            this.Close();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                txtDirectoryBackup.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            txtDirectoryBackup.Focus();
        }

        private void FrmSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
                btnConfirm_Click(sender, e);

            if (e.Control && e.KeyCode == Keys.O)
                btnSelectFolder_Click(sender, e);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Informe o caso de violação que será adicionado no sistema", "CREAS Analytics", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (!isEdition)
            {
                InsertDataInDgv(txtDescription.Text.Trim());
                caseOfViolations.Add(txtDescription.Text.Trim());
            }
            else
            {
                dgvCaseOfViolation.Rows[indexCurrent].Cells["ColDescription"].Value = txtDescription.Text.Trim();
                caseOfViolations[indexCurrent] = txtDescription.Text.Trim();
                isEdition = false;
                btnInsert.Text = "Inserir Caso";
            }

            txtDescription.Clear();
        }

        private void InsertDataInDgv(string text)
        {
            int index = dgvCaseOfViolation.Rows.Add(Resources.user_avatar, Resources.delete, text);
            dgvCaseOfViolation.Rows[index].Height = 45;
            dgvCaseOfViolation.Rows[index].Selected = false;
        }

        private void dgvCaseOfViolation_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            dgvCaseOfViolation.Cursor = e.ColumnIndex == 0 || e.ColumnIndex == 1 ? Cursors.Hand : Cursors.Default;
        }

        private void dgvCaseOfViolation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                txtDescription.Text = dgvCaseOfViolation.CurrentRow.Cells["ColDescription"].Value.ToString();
                isEdition = true;
                indexCurrent = e.RowIndex;
                btnInsert.Text = "Editar Caso";
            }
            else if (e.ColumnIndex == 1)
            {
                if (dgvCaseOfViolation.Rows.Count == 1)
                {
                    MessageBox.Show("O sistema deve ter pelo menos um caso de violência cadastrado no sistema", "CREAS Analytics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                dgvCaseOfViolation.Rows.RemoveAt(e.RowIndex);
                caseOfViolations.RemoveAt(e.RowIndex);
            }
        }
    }
}