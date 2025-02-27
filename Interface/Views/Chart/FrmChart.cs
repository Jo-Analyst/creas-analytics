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
        DataTable caseViolations;

        public FrmChart(DataTable caseVioliation)
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
            foreach (DataRow row in caseViolations.Rows)
            {
                listCaseViolations.Add(row["case_of_violation"].ToString().Split(';'));
            }
        
            foreach (var listCaseViolation in listCaseViolations)
            {
                foreach(var list in listCaseViolation)
                {
                    if (!string.IsNullOrEmpty(list))
                        MessageBox.Show(list);
                }
            }
                //series.Points.AddXY(row["case_of_violation"].ToString(), row["quantity"].ToString());
            chart.Series.Add(series);
        }
    }
}
