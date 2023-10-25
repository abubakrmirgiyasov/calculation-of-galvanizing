namespace SZGC.Desktop.Views.Order
{
    partial class OrderView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Name_TB = new System.Windows.Forms.TextBox();
            this.Save_B = new System.Windows.Forms.Button();
            this.Stage_DGV = new System.Windows.Forms.DataGridView();
            this.cc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StageAdd_B = new System.Windows.Forms.Button();
            this.StageDelete_B = new System.Windows.Forms.Button();
            this.Nomenclature_DGV = new System.Windows.Forms.DataGridView();
            this.NomenclatureAdd_B = new System.Windows.Forms.Button();
            this.NomenclatureDelete_B = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NumOfHitchStation_NUD = new System.Windows.Forms.NumericUpDown();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Stage_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nomenclature_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfHitchStation_NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.65517F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.34483F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Name_TB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Save_B, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.Stage_DGV, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.StageAdd_B, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.StageDelete_B, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.Nomenclature_DGV, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.NomenclatureAdd_B, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.NomenclatureDelete_B, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.NumOfHitchStation_NUD, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(441, 548);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заказы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.label2.Location = new System.Drawing.Point(5, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Наименование";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Name_TB
            // 
            this.Name_TB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Name_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name_TB.Location = new System.Drawing.Point(223, 60);
            this.Name_TB.Margin = new System.Windows.Forms.Padding(5);
            this.Name_TB.Name = "Name_TB";
            this.Name_TB.Size = new System.Drawing.Size(213, 20);
            this.Name_TB.TabIndex = 2;
            // 
            // Save_B
            // 
            this.Save_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.tableLayoutPanel1.SetColumnSpan(this.Save_B, 2);
            this.Save_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Save_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Save_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_B.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save_B.ForeColor = System.Drawing.Color.White;
            this.Save_B.Location = new System.Drawing.Point(5, 512);
            this.Save_B.Margin = new System.Windows.Forms.Padding(5);
            this.Save_B.Name = "Save_B";
            this.Save_B.Size = new System.Drawing.Size(431, 30);
            this.Save_B.TabIndex = 19;
            this.Save_B.Text = "Сохранить";
            this.Save_B.UseVisualStyleBackColor = false;
            // 
            // Stage_DGV
            // 
            this.Stage_DGV.AllowUserToAddRows = false;
            this.Stage_DGV.AllowUserToDeleteRows = false;
            this.Stage_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Stage_DGV.BackgroundColor = System.Drawing.Color.White;
            this.Stage_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Stage_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cc,
            this.Column3});
            this.tableLayoutPanel1.SetColumnSpan(this.Stage_DGV, 2);
            this.Stage_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Stage_DGV.Location = new System.Drawing.Point(3, 354);
            this.Stage_DGV.Name = "Stage_DGV";
            this.Stage_DGV.RowHeadersVisible = false;
            this.Stage_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Stage_DGV.Size = new System.Drawing.Size(435, 150);
            this.Stage_DGV.TabIndex = 18;
            this.Stage_DGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Stage_DGV_DataError);
            this.Stage_DGV.SelectionChanged += new System.EventHandler(this.Stage_DGV_SelectionChanged);
            // 
            // cc
            // 
            this.cc.DataPropertyName = "StageView";
            this.cc.HeaderText = "Этап";
            this.cc.Name = "cc";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Time";
            this.Column3.HeaderText = "Время, мин";
            this.Column3.Name = "Column3";
            // 
            // StageAdd_B
            // 
            this.StageAdd_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.StageAdd_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StageAdd_B.Enabled = false;
            this.StageAdd_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StageAdd_B.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StageAdd_B.ForeColor = System.Drawing.Color.White;
            this.StageAdd_B.Location = new System.Drawing.Point(5, 316);
            this.StageAdd_B.Margin = new System.Windows.Forms.Padding(5);
            this.StageAdd_B.Name = "StageAdd_B";
            this.StageAdd_B.Size = new System.Drawing.Size(208, 30);
            this.StageAdd_B.TabIndex = 16;
            this.StageAdd_B.Text = "Выбрать этап";
            this.StageAdd_B.UseVisualStyleBackColor = false;
            this.StageAdd_B.Click += new System.EventHandler(this.StageAdd_B_Click);
            // 
            // StageDelete_B
            // 
            this.StageDelete_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.StageDelete_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StageDelete_B.Enabled = false;
            this.StageDelete_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StageDelete_B.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StageDelete_B.ForeColor = System.Drawing.Color.White;
            this.StageDelete_B.Location = new System.Drawing.Point(223, 316);
            this.StageDelete_B.Margin = new System.Windows.Forms.Padding(5);
            this.StageDelete_B.Name = "StageDelete_B";
            this.StageDelete_B.Size = new System.Drawing.Size(213, 30);
            this.StageDelete_B.TabIndex = 17;
            this.StageDelete_B.Text = "Удалить";
            this.StageDelete_B.UseVisualStyleBackColor = false;
            this.StageDelete_B.Click += new System.EventHandler(this.StageDelete_B_Click);
            // 
            // Nomenclature_DGV
            // 
            this.Nomenclature_DGV.AllowUserToAddRows = false;
            this.Nomenclature_DGV.AllowUserToDeleteRows = false;
            this.Nomenclature_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Nomenclature_DGV.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Nomenclature_DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Nomenclature_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Nomenclature_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Weight,
            this.Column4});
            this.tableLayoutPanel1.SetColumnSpan(this.Nomenclature_DGV, 2);
            this.Nomenclature_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Nomenclature_DGV.Location = new System.Drawing.Point(3, 158);
            this.Nomenclature_DGV.Name = "Nomenclature_DGV";
            this.Nomenclature_DGV.RowHeadersVisible = false;
            this.Nomenclature_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Nomenclature_DGV.Size = new System.Drawing.Size(435, 150);
            this.Nomenclature_DGV.TabIndex = 15;
            this.Nomenclature_DGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Nomenclature_DGV_CellEndEdit);
            this.Nomenclature_DGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Nomenclature_DGV_DataError);
            this.Nomenclature_DGV.SelectionChanged += new System.EventHandler(this.Nomenclature_DGV_SelectionChanged);
            // 
            // NomenclatureAdd_B
            // 
            this.NomenclatureAdd_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.NomenclatureAdd_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NomenclatureAdd_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NomenclatureAdd_B.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenclatureAdd_B.ForeColor = System.Drawing.Color.White;
            this.NomenclatureAdd_B.Location = new System.Drawing.Point(5, 120);
            this.NomenclatureAdd_B.Margin = new System.Windows.Forms.Padding(5);
            this.NomenclatureAdd_B.Name = "NomenclatureAdd_B";
            this.NomenclatureAdd_B.Size = new System.Drawing.Size(208, 30);
            this.NomenclatureAdd_B.TabIndex = 14;
            this.NomenclatureAdd_B.Text = "Выбрать номенклатуру";
            this.NomenclatureAdd_B.UseVisualStyleBackColor = false;
            this.NomenclatureAdd_B.Click += new System.EventHandler(this.NomenclatureAdd_B_Click);
            // 
            // NomenclatureDelete_B
            // 
            this.NomenclatureDelete_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.NomenclatureDelete_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NomenclatureDelete_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NomenclatureDelete_B.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenclatureDelete_B.ForeColor = System.Drawing.Color.White;
            this.NomenclatureDelete_B.Location = new System.Drawing.Point(223, 120);
            this.NomenclatureDelete_B.Margin = new System.Windows.Forms.Padding(5);
            this.NomenclatureDelete_B.Name = "NomenclatureDelete_B";
            this.NomenclatureDelete_B.Size = new System.Drawing.Size(213, 30);
            this.NomenclatureDelete_B.TabIndex = 13;
            this.NomenclatureDelete_B.Text = "Удалить";
            this.NomenclatureDelete_B.UseVisualStyleBackColor = false;
            this.NomenclatureDelete_B.Click += new System.EventHandler(this.NomenclatureDelete_B_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.label3.Location = new System.Drawing.Point(5, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Кол-во станций навески";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumOfHitchStation_NUD
            // 
            this.NumOfHitchStation_NUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumOfHitchStation_NUD.Location = new System.Drawing.Point(223, 90);
            this.NumOfHitchStation_NUD.Margin = new System.Windows.Forms.Padding(5);
            this.NumOfHitchStation_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumOfHitchStation_NUD.Name = "NumOfHitchStation_NUD";
            this.NumOfHitchStation_NUD.Size = new System.Drawing.Size(213, 20);
            this.NumOfHitchStation_NUD.TabIndex = 21;
            this.NumOfHitchStation_NUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "NomenclatureName";
            this.Column1.HeaderText = "Номенклатура";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Count";
            this.Column2.HeaderText = "Кол-во, шт";
            this.Column2.Name = "Column2";
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "AllWeight";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Weight.DefaultCellStyle = dataGridViewCellStyle2;
            this.Weight.HeaderText = "Масса всех, кг";
            this.Weight.Name = "Weight";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CountTraverse";
            dataGridViewCellStyle3.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Кол-во траверс";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(441, 548);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заказы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderView_FormClosing);
            this.Load += new System.EventHandler(this.OrderView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Stage_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nomenclature_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfHitchStation_NUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Name_TB;
        private System.Windows.Forms.Button NomenclatureDelete_B;
        private System.Windows.Forms.Button NomenclatureAdd_B;
        private System.Windows.Forms.DataGridView Nomenclature_DGV;
        private System.Windows.Forms.Button StageAdd_B;
        private System.Windows.Forms.Button StageDelete_B;
        private System.Windows.Forms.DataGridView Stage_DGV;
        private System.Windows.Forms.Button Save_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn cc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumOfHitchStation_NUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}