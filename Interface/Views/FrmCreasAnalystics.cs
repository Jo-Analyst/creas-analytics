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

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsers frmUsers = new FrmUsers();
            frmUsers.ShowDialog();
        }

        private void atendimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmReportService().ShowDialog();
        }
    }
}
