namespace Interface.Views
{
    partial class FrmReportService
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportService));
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxAll = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.btnGenerateChart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRows = new System.Windows.Forms.ComboBox();
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDescriptionRow = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnArrowRight = new System.Windows.Forms.Button();
            this.btnArrowLeft = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvReport.ColumnHeadersHeight = 40;
            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDate,
            this.ColName,
            this.ColBirth,
            this.ColAddress,
            this.ColReference,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column10,
            this.Column12,
            this.Column6,
            this.Column7,
            this.Column11,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReport.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.Location = new System.Drawing.Point(14, 95);
            this.dgvReport.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvReport.MultiSelect = false;
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.Size = new System.Drawing.Size(988, 323);
            this.dgvReport.TabIndex = 1;
            this.dgvReport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReport_CellClick);
            // 
            // ColDate
            // 
            this.ColDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Format = "d";
            dataGridViewCellStyle10.NullValue = null;
            this.ColDate.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColDate.HeaderText = "Data do atendimento";
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            this.ColDate.Width = 157;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColName.HeaderText = "Nome";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.Width = 70;
            // 
            // ColBirth
            // 
            this.ColBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColBirth.HeaderText = "D. Nascimento";
            this.ColBirth.Name = "ColBirth";
            this.ColBirth.ReadOnly = true;
            this.ColBirth.Width = 121;
            // 
            // ColAddress
            // 
            this.ColAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColAddress.HeaderText = "Endereço";
            this.ColAddress.Name = "ColAddress";
            this.ColAddress.ReadOnly = true;
            this.ColAddress.Width = 93;
            // 
            // ColReference
            // 
            this.ColReference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColReference.HeaderText = "Referencial Familiar";
            this.ColReference.Name = "ColReference";
            this.ColReference.ReadOnly = true;
            this.ColReference.Width = 151;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Inserção no PAEFI";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 146;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Atendimento";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.ToolTipText = "Atendimento Presencial ou a distância";
            this.Column3.Width = 109;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Síntese da demanda";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 158;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Porta de Entrada";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 134;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column10.HeaderText = "Tipo de Beneficios";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 147;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column12.HeaderText = "Principal Violação de direito";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 202;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Faz acompanhamento com algum serviço ou profissional? (CRAS, CREAS, CAPS, etc)";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 553;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "Possui necessidades específicas de saúde?";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 304;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column11.HeaderText = "Interveções realizadas";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 169;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "Encaminhamentos Realizados";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 214;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.HeaderText = "Descrição sumaria do caso";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 197;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxAll);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbMonth);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 76);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(88, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1, 53);
            this.label4.TabIndex = 22;
            // 
            // cbxAll
            // 
            this.cbxAll.AutoSize = true;
            this.cbxAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxAll.Location = new System.Drawing.Point(21, 29);
            this.cbxAll.Name = "cbxAll";
            this.cbxAll.Size = new System.Drawing.Size(55, 24);
            this.cbxAll.TabIndex = 21;
            this.cbxAll.Text = "Tudo";
            this.cbxAll.UseVisualStyleBackColor = true;
            this.cbxAll.CheckedChanged += new System.EventHandler(this.cbxAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ano";
            // 
            // cbYear
            // 
            this.cbYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.Enabled = false;
            this.cbYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbYear.ForeColor = System.Drawing.Color.White;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(307, 28);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(94, 28);
            this.cbYear.TabIndex = 19;
            this.cbYear.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mês";
            // 
            // cbMonth
            // 
            this.cbMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.Enabled = false;
            this.cbMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMonth.ForeColor = System.Drawing.Color.White;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
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
            this.cbMonth.Location = new System.Drawing.Point(156, 28);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(94, 28);
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
            this.btnGenerateChart.Location = new System.Drawing.Point(859, 476);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbRows);
            this.panel1.Controls.Add(this.cbPage);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblDescriptionRow);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnArrowRight);
            this.panel1.Controls.Add(this.btnArrowLeft);
            this.panel1.Location = new System.Drawing.Point(13, 420);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 49);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(179, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 40);
            this.label3.TabIndex = 17;
            // 
            // cbRows
            // 
            this.cbRows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.cbRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRows.ForeColor = System.Drawing.Color.White;
            this.cbRows.FormattingEnabled = true;
            this.cbRows.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25"});
            this.cbRows.Location = new System.Drawing.Point(67, 11);
            this.cbRows.Name = "cbRows";
            this.cbRows.Size = new System.Drawing.Size(94, 28);
            this.cbRows.TabIndex = 16;
            this.cbRows.TabStop = false;
            // 
            // cbPage
            // 
            this.cbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.cbPage.DropDownHeight = 150;
            this.cbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPage.ForeColor = System.Drawing.Color.White;
            this.cbPage.FormattingEnabled = true;
            this.cbPage.IntegralHeight = false;
            this.cbPage.ItemHeight = 20;
            this.cbPage.Location = new System.Drawing.Point(766, 11);
            this.cbPage.Margin = new System.Windows.Forms.Padding(19, 17, 19, 17);
            this.cbPage.Name = "cbPage";
            this.cbPage.Size = new System.Drawing.Size(97, 28);
            this.cbPage.TabIndex = 15;
            this.cbPage.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(697, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Página";
            // 
            // lblDescriptionRow
            // 
            this.lblDescriptionRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescriptionRow.AutoSize = true;
            this.lblDescriptionRow.Location = new System.Drawing.Point(189, 17);
            this.lblDescriptionRow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescriptionRow.Name = "lblDescriptionRow";
            this.lblDescriptionRow.Size = new System.Drawing.Size(0, 20);
            this.lblDescriptionRow.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Exibir";
            // 
            // btnArrowRight
            // 
            this.btnArrowRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArrowRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArrowRight.Enabled = false;
            this.btnArrowRight.FlatAppearance.BorderSize = 0;
            this.btnArrowRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArrowRight.Image = global::Interface.Properties.Resources.right_arrow_grey;
            this.btnArrowRight.Location = new System.Drawing.Point(932, 6);
            this.btnArrowRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnArrowRight.Name = "btnArrowRight";
            this.btnArrowRight.Size = new System.Drawing.Size(38, 35);
            this.btnArrowRight.TabIndex = 10;
            this.btnArrowRight.TabStop = false;
            this.toolTip.SetToolTip(this.btnArrowRight, "Avançar para a próxima lista - CTRL+Seta Direita");
            this.btnArrowRight.UseVisualStyleBackColor = true;
            this.btnArrowRight.Click += new System.EventHandler(this.btnArrowRight_Click);
            // 
            // btnArrowLeft
            // 
            this.btnArrowLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArrowLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArrowLeft.Enabled = false;
            this.btnArrowLeft.FlatAppearance.BorderSize = 0;
            this.btnArrowLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArrowLeft.Image = global::Interface.Properties.Resources.left_arrow_grey;
            this.btnArrowLeft.Location = new System.Drawing.Point(886, 6);
            this.btnArrowLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnArrowLeft.Name = "btnArrowLeft";
            this.btnArrowLeft.Size = new System.Drawing.Size(38, 35);
            this.btnArrowLeft.TabIndex = 9;
            this.btnArrowLeft.TabStop = false;
            this.toolTip.SetToolTip(this.btnArrowLeft, "Voltar para a lista anterior - CTRL+Seta Esquerda");
            this.btnArrowLeft.UseVisualStyleBackColor = true;
            this.btnArrowLeft.Click += new System.EventHandler(this.btnArrowLeft_Click);
            // 
            // FrmReportService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(65)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1016, 531);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGenerateChart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvReport);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "FrmReportService";
            this.Text = "Relatório dos atendimentos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReportService_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReportService_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.CheckBox cbxAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenerateChart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRows;
        private System.Windows.Forms.ComboBox cbPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDescriptionRow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnArrowRight;
        private System.Windows.Forms.Button btnArrowLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.ToolTip toolTip;
    }
}