using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            CreateBarChart();
        }

        private void FrmChart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P) 
                btnPrint_Click(sender, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), "barChartImage.png");
            chart.SaveImage(tempFilePath, ChartImageFormat.Png);
        }

        private void CreateBarChart()
        {
            //Series series = new Series{
            //    IsValueShownAsLabel = true, // Mostra os valores nas fatias
            //    ChartType = SeriesChartType.Bar
            //};

            Series series = new Series();

            series.Name = "Casos de Violência";
            series.Color = Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(114)))), ((int)(((byte)(30)))));
          
            chart.ChartAreas["ChartArea1"].AxisY.Title = "Quantidade de casos de violência";
            chart.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);

            chart.ChartAreas["ChartArea1"].AxisX.Title = "Violação de direito associada ao atendimento";
            chart.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);

            List<string[]> listCaseViolations = new List<string[]>();
            
            foreach (var row in caseViolations)
            {
                listCaseViolations.Add(row.ToString().Split(';'));
            }

            List<string> newList = new List<string>();

            foreach (var listCaseViolation in listCaseViolations)
            {
                foreach (var list in listCaseViolation)
                {
                    if (!string.IsNullOrEmpty(list))
                        newList.Add(list);
                }
            }


            DataTable dtCaseViolations = new DataTable();
            dtCaseViolations.Columns.Add("Quantity", typeof(int));
            dtCaseViolations.Columns.Add("Case_Of_Violation", typeof(string));

            foreach (string item in newList)
            {
                bool itemExists = false;

                foreach (DataRow row in dtCaseViolations.Rows)
                {
                    if (row["Case_Of_Violation"].ToString().Trim().ToLower() == item.Trim().ToLower())
                    {
                      
                        row["Quantity"] = (int)row["Quantity"] + 1;
                        itemExists = true;
                        break;
                    }
                }

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
