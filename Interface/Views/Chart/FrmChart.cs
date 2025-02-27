using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Interface.Views
{
    public partial class FrmChart : Form
    {
        List<string> caseViolations;

        public FrmChart(List<string> caseVioliation)
        {
            InitializeComponent();
            this.caseViolations = caseVioliation;
        }

        private void FrmChart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P) 
                btnPrint_Click(sender, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void FrmChart_Load(object sender, EventArgs e)
        {
            Series series = new Series();
            series.Name = "Casos de Violências";
            series.Color = Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(114)))), ((int)(((byte)(30)))));
            List<string[]> listCaseViolations = new List<string[]>();

            foreach (var row in caseViolations)
            {
                listCaseViolations.Add(row.ToString().Split(';'));
            }
        
            List<string> newList = new List<string>();
            
            foreach (var listCaseViolation in listCaseViolations)
            {
                foreach(var list in listCaseViolation)
                {
                    if (!string.IsNullOrEmpty(list))
                        newList.Add(list);
                }
            }
            DataTable dtCaseViolations  = new DataTable();
            dtCaseViolations.Columns.Add("Quantity", typeof(int));
            dtCaseViolations.Columns.Add("Case_Of_Violation", typeof(string));

            // Suponha que os itens já estejam no newList
            foreach (string item in newList)
            {
                bool itemExists = false;

                // Verificar se o item já existe no DataTable
                foreach (DataRow row in dtCaseViolations.Rows)
                {
                    if (row["Case_Of_Violation"].ToString().Trim().ToLower() == item.Trim().ToLower())
                    {
                        // Incrementar a quantidade
                        row["Quantity"] = (int)row["Quantity"] + 1;
                        itemExists = true;
                        break;
                    }
                }

                // Se o item não existe, adicioná-lo no DataTable
                if (!itemExists)
                {
                    DataRow newRow = dtCaseViolations.NewRow();
                    newRow["Quantity"] = 1;
                    newRow["Case_Of_Violation"] = item;
                    dtCaseViolations.Rows.Add(newRow);
                }
            }


            foreach (DataRow row in dtCaseViolations.Rows)
            {
                series.Points.AddXY(row["Case_Of_Violation"].ToString(), row["Quantity"].ToString());
            }

            chart.Series.Add(series);
        }
    }
}
