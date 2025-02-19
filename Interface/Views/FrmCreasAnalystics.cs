using Interface.Views;
using System;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmCreasAnalystics : Form
    {
        public FrmCreasAnalystics()
        {
            InitializeComponent();
        }

        private void UserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsers frmUsers = new FrmUsers();
            frmUsers.ShowDialog();
        }

        private void ServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmReportService().ShowDialog();
        }

        private void BackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmBackupAndRestore().ShowDialog();
        }

        private void MenuSetting_Click(object sender, EventArgs e)
        {
            new FrmSetting().ShowDialog();
        }
    }
}
