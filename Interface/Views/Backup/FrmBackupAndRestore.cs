﻿using DataBase;
using Interface.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmBackupAndRestore : Form
    {
        public FrmBackupAndRestore()
        {
            InitializeComponent();
        }

        string path = Settings.Default["path_Backup"].ToString();

        private void CreateDirectory()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string getDate()
        {
            DateTime dt = DateTime.Now;
            int year = dt.Year;
            int month = dt.Month;
            int day = dt.Day;

            int hour = dt.Hour;
            int minute = dt.Minute;
            int second = dt.Second;

            return $"{day.ToString().PadLeft(2, '0')}-{month.ToString().PadLeft(2, '0')}-{year}---{hour.ToString().PadLeft(2, '0')}-{minute.ToString().PadLeft(2, '0')}-{second.ToString().PadLeft(2, '0')}";
        }

        Backup backup = new Backup();

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Configure o local onde será armazenará o arquivo do backup", "CREAS Analytics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                CreateDirectory();
                string file = $"{path}\\CREAS-Analytics-backup---{getDate()}.bak";
                backup.GenerateBackup(file);
                MessageBox.Show($"Backup realizado com sucesso. O caminho do arquivo é este: {file}.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "|*.bak";
                openFileDialog.Title = "Abrir arquivo de restauração";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    backup.RestoreDataBase(openFileDialog.FileName);
                    MessageBox.Show("Restauração realizado com sucesso.", "Mensage,", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
        }

        private void FrmBackupAndRestore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.B)
            {
                btnBackup_Click(sender, e);
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.R)
            {
                btnRestore_Click(sender, e);
            }
        }
    }
}
