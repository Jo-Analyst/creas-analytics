namespace Interface.Views
{
    partial class FrmReportTypeService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportTypeService));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.btnGenerateChart = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ColMonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInitialWelcome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVirtualAssistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInsertionOfUserInPAEFI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHomeVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOuter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AllowUserToResizeColumns = false;
            this.dgvReport.AllowUserToResizeRows = false;
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReport.ColumnHeadersHeight = 40;
            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMonths,
            this.ColInitialWelcome,
            this.ColVirtualAssistance,
            this.ColInsertionOfUserInPAEFI,
            this.ColHomeVisit,
            this.ColOuter});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReport.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.Location = new System.Drawing.Point(14, 95);
            this.dgvReport.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvReport.MultiSelect = false;
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.Size = new System.Drawing.Size(701, 366);
            this.dgvReport.TabIndex = 1;
            this.dgvReport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReport_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbMonth);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 76);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ano";
            // 
            // cbYear
            // 
            this.cbYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbYear.ForeColor = System.Drawing.Color.White;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(51, 31);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(94, 28);
            this.cbYear.TabIndex = 19;
            this.cbYear.TabStop = false;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mês";
            // 
            // cbMonth
            // 
            this.cbMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMonth.ForeColor = System.Drawing.Color.White;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
            "<Selecione>",
            "JAN",
            "FEV",
            "MAR",
            "ABR",
            "MAI",
            "JUN",
            "JUL",
            "AGO",
            "SET",
            "OUT",
            "NOV",
            "DEZ"});
            this.cbMonth.Location = new System.Drawing.Point(192, 28);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(118, 28);
            this.cbMonth.TabIndex = 17;
            this.cbMonth.TabStop = false;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            // 
            // btnGenerateChart
            // 
            this.btnGenerateChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateChart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateChart.ForeColor = System.Drawing.Color.White;
            this.btnGenerateChart.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateChart.Image")));
            this.btnGenerateChart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateChart.Location = new System.Drawing.Point(572, 469);
            this.btnGenerateChart.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateChart.Name = "btnGenerateChart";
            this.btnGenerateChart.Size = new System.Drawing.Size(143, 47);
            this.btnGenerateChart.TabIndex = 3;
            this.btnGenerateChart.TabStop = false;
            this.btnGenerateChart.Text = "Gerar gráfico";
            this.btnGenerateChart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnGenerateChart, "Gerar gráfico - CTRL + G");
            this.btnGenerateChart.UseVisualStyleBackColor = true;
            this.btnGenerateChart.Click += new System.EventHandler(this.btnGenerateChart_Click);
            // 
            // ColMonths
            // 
            this.ColMonths.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.ColMonths.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColMonths.HeaderText = "";
            this.ColMonths.MinimumWidth = 6;
            this.ColMonths.Name = "ColMonths";
            this.ColMonths.ReadOnly = true;
            this.ColMonths.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColMonths.Width = 6;
            // 
            // ColInitialWelcome
            // 
            this.ColInitialWelcome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColInitialWelcome.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColInitialWelcome.HeaderText = "Acolhida inicial";
            this.ColInitialWelcome.MinimumWidth = 6;
            this.ColInitialWelcome.Name = "ColInitialWelcome";
            this.ColInitialWelcome.ReadOnly = true;
            this.ColInitialWelcome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColInitialWelcome.Width = 104;
            // 
            // ColVirtualAssistance
            // 
            this.ColVirtualAssistance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColVirtualAssistance.HeaderText = "Atividades do PAEFI";
            this.ColVirtualAssistance.MinimumWidth = 6;
            this.ColVirtualAssistance.Name = "ColVirtualAssistance";
            this.ColVirtualAssistance.ReadOnly = true;
            this.ColVirtualAssistance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColVirtualAssistance.Width = 140;
            // 
            // ColInsertionOfUserInPAEFI
            // 
            this.ColInsertionOfUserInPAEFI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColInsertionOfUserInPAEFI.HeaderText = "Inserção de usuário no PAEFI";
            this.ColInsertionOfUserInPAEFI.MinimumWidth = 6;
            this.ColInsertionOfUserInPAEFI.Name = "ColInsertionOfUserInPAEFI";
            this.ColInsertionOfUserInPAEFI.ReadOnly = true;
            this.ColInsertionOfUserInPAEFI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColInsertionOfUserInPAEFI.Width = 213;
            // 
            // ColHomeVisit
            // 
            this.ColHomeVisit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColHomeVisit.HeaderText = "Visita domiciliar";
            this.ColHomeVisit.Name = "ColHomeVisit";
            this.ColHomeVisit.ReadOnly = true;
            this.ColHomeVisit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColHomeVisit.Width = 108;
            // 
            // ColOuter
            // 
            this.ColOuter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColOuter.HeaderText = "Outro";
            this.ColOuter.Name = "ColOuter";
            this.ColOuter.ReadOnly = true;
            this.ColOuter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColOuter.Width = 47;
            // 
            // FrmReportTypeService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(65)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(731, 532);
            this.Controls.Add(this.btnGenerateChart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvReport);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(747, 571);
            this.Name = "FrmReportTypeService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório dos atendimentos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReportService_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReportService_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Button btnGenerateChart;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMonths;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInitialWelcome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVirtualAssistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInsertionOfUserInPAEFI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHomeVisit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOuter;
    }
}