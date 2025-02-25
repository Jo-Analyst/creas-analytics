namespace Interface
{
    partial class FrmSetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetting));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtDirectoryBackup = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbPrint = new System.Windows.Forms.CheckBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnInsert = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dgvCaseOfViolation = new System.Windows.Forms.DataGridView();
            this.ColEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseOfViolation)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Diretório";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSelectFolder);
            this.groupBox1.Controls.Add(this.txtDirectoryBackup);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 121);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Escolha um local padrão para backup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Escolha um diretório direto do disco. EX: C:\\Example";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFolder.ForeColor = System.Drawing.Color.White;
            this.btnSelectFolder.Location = new System.Drawing.Point(468, 53);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(59, 35);
            this.btnSelectFolder.TabIndex = 2;
            this.btnSelectFolder.TabStop = false;
            this.btnSelectFolder.Text = "***";
            this.btnSelectFolder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.btnSelectFolder, "Selecionar Pasta - [CTRL + O]");
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtDirectoryBackup
            // 
            this.txtDirectoryBackup.Location = new System.Drawing.Point(21, 57);
            this.txtDirectoryBackup.Name = "txtDirectoryBackup";
            this.txtDirectoryBackup.Size = new System.Drawing.Size(441, 26);
            this.txtDirectoryBackup.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbPrint);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 72);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Impressão";
            // 
            // cbPrint
            // 
            this.cbPrint.AutoSize = true;
            this.cbPrint.Location = new System.Drawing.Point(21, 30);
            this.cbPrint.Name = "cbPrint";
            this.cbPrint.Size = new System.Drawing.Size(345, 24);
            this.cbPrint.TabIndex = 3;
            this.cbPrint.Text = "Imprimir Relatório diretamente na impressora";
            this.cbPrint.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(427, 491);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(169, 46);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "OK";
            this.toolTip.SetToolTip(this.btnConfirm, "Confirmar - [ENTER]");
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Location = new System.Drawing.Point(444, 226);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(134, 36);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "Inserir Caso";
            this.toolTip.SetToolTip(this.btnInsert, "Confirmar - [ENTER]");
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInsert);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.dgvCaseOfViolation);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(584, 268);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Caso de Violação";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(21, 231);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(406, 26);
            this.txtDescription.TabIndex = 4;
            // 
            // dgvUsers
            // 
            this.dgvCaseOfViolation.AllowUserToAddRows = false;
            this.dgvCaseOfViolation.AllowUserToDeleteRows = false;
            this.dgvCaseOfViolation.AllowUserToResizeColumns = false;
            this.dgvCaseOfViolation.AllowUserToResizeRows = false;
            this.dgvCaseOfViolation.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.dgvCaseOfViolation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCaseOfViolation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaseOfViolation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCaseOfViolation.ColumnHeadersHeight = 40;
            this.dgvCaseOfViolation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColEdit,
            this.ColDelete,
            this.ColDescription});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCaseOfViolation.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCaseOfViolation.EnableHeadersVisualStyles = false;
            this.dgvCaseOfViolation.Location = new System.Drawing.Point(2, 23);
            this.dgvCaseOfViolation.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvCaseOfViolation.MultiSelect = false;
            this.dgvCaseOfViolation.Name = "dgvUsers";
            this.dgvCaseOfViolation.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaseOfViolation.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCaseOfViolation.RowHeadersVisible = false;
            this.dgvCaseOfViolation.RowHeadersWidth = 51;
            this.dgvCaseOfViolation.Size = new System.Drawing.Size(578, 196);
            this.dgvCaseOfViolation.TabIndex = 5;
            this.dgvCaseOfViolation.TabStop = false;
            this.dgvCaseOfViolation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaseOfViolation_CellClick);
            this.dgvCaseOfViolation.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaseOfViolation_CellMouseEnter);
            // 
            // ColEdit
            // 
            this.ColEdit.HeaderText = "Editar";
            this.ColEdit.Name = "ColEdit";
            this.ColEdit.ReadOnly = true;
            // 
            // ColDelete
            // 
            this.ColDelete.HeaderText = "Excluir";
            this.ColDelete.Name = "ColDelete";
            this.ColDelete.ReadOnly = true;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescription.HeaderText = "Descrição";
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            this.ColDescription.ToolTipText = "Referência Familiar";
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(65)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(617, 549);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSetting_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseOfViolation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDirectoryBackup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbPrint;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCaseOfViolation;
        private System.Windows.Forms.DataGridViewImageColumn ColEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtDescription;
    }
}