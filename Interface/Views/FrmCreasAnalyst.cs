using System;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmCreasAnalyst : Form
    {
        public FrmCreasAnalyst()
        {
            InitializeComponent();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsers frmUsers = new FrmUsers();
            frmUsers.ShowDialog();
        }
    }
}
