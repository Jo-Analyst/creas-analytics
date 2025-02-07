using System;
using System.Windows.Forms;
using DataBase;

namespace Interface
{
    public partial class FrmCustomerService : Form
    {

        public FrmCustomerService()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.ClearSelected();
        }
    }
}