using DataBase;
using System;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (pbLoading.Value < 100)
            {
                pbLoading.Value += 5;
            }
            else
            {
                timer.Stop();
                this.Visible = false;
                try
                {
                    if (!DB.ExistsDataBase())
                    {
                        DialogResult dr = MessageBox.Show("Verificado aqui que não foi encontrado uma base de dados neste computador. Deseja criar uma base de dados?", "CREAS Analytics", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.Yes)
                        {
                            DB.CreateDatabase();
                            DB.CreateTables();
                        }
                        else
                        {
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            openFileDialog.Filter = "|*.bak";
                            openFileDialog.Title = "Abrir arquivo de restauração";
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                Backup.RestoreDataBase(openFileDialog.FileName);
                            }
                            else
                                Application.Exit();
                        }
                    }

                    new FrmCreasAnalystics().ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    MessageBox.Show("Houve um problema no servidor. Tente novamente. Caso o erro persista contate o suporte.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }
    }
}
