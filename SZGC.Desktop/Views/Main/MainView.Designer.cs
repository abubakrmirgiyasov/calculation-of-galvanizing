namespace SZGC.Desktop.Views.Main
{
    partial class MainView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Main_TLP = new System.Windows.Forms.TableLayoutPanel();
            this.Func_TS = new System.Windows.Forms.ToolStrip();
            this.Order_TSB = new System.Windows.Forms.ToolStripButton();
            this.Nomenclature_TSB = new System.Windows.Forms.ToolStripButton();
            this.Stage_TSB = new System.Windows.Forms.ToolStripButton();
            this.Hide_TSB = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Main_TS = new System.Windows.Forms.ToolStrip();
            this.AdvancedSearch_TSB = new System.Windows.Forms.ToolStripButton();
            this.Reset_TSB = new System.Windows.Forms.ToolStripButton();
            this.Search_TB_TSB = new System.Windows.Forms.ToolStripTextBox();
            this.Search_B_TSB = new System.Windows.Forms.ToolStripButton();
            this.Add_TSB = new System.Windows.Forms.ToolStripButton();
            this.Edit_TSB = new System.Windows.Forms.ToolStripButton();
            this.Delete_TSB = new System.Windows.Forms.ToolStripButton();
            this.Main_DGV = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateBaseOn_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_TLP.SuspendLayout();
            this.Func_TS.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.Main_TS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DGV)).BeginInit();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_TLP
            // 
            this.Main_TLP.ColumnCount = 2;
            this.Main_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.Main_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_TLP.Controls.Add(this.Func_TS, 0, 0);
            this.Main_TLP.Controls.Add(this.menuStrip1, 1, 0);
            this.Main_TLP.Controls.Add(this.Main_TS, 1, 1);
            this.Main_TLP.Controls.Add(this.Main_DGV, 1, 2);
            this.Main_TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TLP.Location = new System.Drawing.Point(0, 0);
            this.Main_TLP.Margin = new System.Windows.Forms.Padding(0);
            this.Main_TLP.Name = "Main_TLP";
            this.Main_TLP.RowCount = 3;
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Main_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_TLP.Size = new System.Drawing.Size(1136, 655);
            this.Main_TLP.TabIndex = 28;
            // 
            // Func_TS
            // 
            this.Func_TS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.Func_TS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Func_TS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Func_TS.GripMargin = new System.Windows.Forms.Padding(0);
            this.Func_TS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Func_TS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Func_TS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Order_TSB,
            this.Nomenclature_TSB,
            this.Stage_TSB,
            this.Hide_TSB});
            this.Func_TS.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.Func_TS.Location = new System.Drawing.Point(0, 0);
            this.Func_TS.Name = "Func_TS";
            this.Func_TS.Padding = new System.Windows.Forms.Padding(0);
            this.Func_TS.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Main_TLP.SetRowSpan(this.Func_TS, 3);
            this.Func_TS.Size = new System.Drawing.Size(200, 655);
            this.Func_TS.TabIndex = 3;
            this.Func_TS.Text = "Функции";
            // 
            // Order_TSB
            // 
            this.Order_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Order_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Order_TSB.Image = ((System.Drawing.Image)(resources.GetObject("Order_TSB.Image")));
            this.Order_TSB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Order_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Order_TSB.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.Order_TSB.Name = "Order_TSB";
            this.Order_TSB.Padding = new System.Windows.Forms.Padding(5);
            this.Order_TSB.Size = new System.Drawing.Size(199, 46);
            this.Order_TSB.Tag = "order";
            this.Order_TSB.Text = "Заказы";
            this.Order_TSB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Order_TSB.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.Order_TSB.ToolTipText = "Заказы";
            this.Order_TSB.Click += new System.EventHandler(this.Order_TSB_Click);
            // 
            // Nomenclature_TSB
            // 
            this.Nomenclature_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Nomenclature_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(150)))), ((int)(((byte)(201)))));
            this.Nomenclature_TSB.Image = global::SZGC.Desktop.Properties.Resources.icons8_steel_i_beam_32;
            this.Nomenclature_TSB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Nomenclature_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Nomenclature_TSB.Margin = new System.Windows.Forms.Padding(0);
            this.Nomenclature_TSB.Name = "Nomenclature_TSB";
            this.Nomenclature_TSB.Padding = new System.Windows.Forms.Padding(5);
            this.Nomenclature_TSB.Size = new System.Drawing.Size(199, 46);
            this.Nomenclature_TSB.Tag = "nomen";
            this.Nomenclature_TSB.Text = "Номенклатура";
            this.Nomenclature_TSB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Nomenclature_TSB.ToolTipText = "Номенклатура";
            this.Nomenclature_TSB.Click += new System.EventHandler(this.Nomenclature_TSB_Click);
            // 
            // Stage_TSB
            // 
            this.Stage_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stage_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(150)))), ((int)(((byte)(201)))));
            this.Stage_TSB.Image = global::SZGC.Desktop.Properties.Resources.icons8_flow_32;
            this.Stage_TSB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Stage_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Stage_TSB.Margin = new System.Windows.Forms.Padding(0);
            this.Stage_TSB.Name = "Stage_TSB";
            this.Stage_TSB.Padding = new System.Windows.Forms.Padding(5);
            this.Stage_TSB.Size = new System.Drawing.Size(199, 46);
            this.Stage_TSB.Tag = "stage";
            this.Stage_TSB.Text = "Этапы";
            this.Stage_TSB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Stage_TSB.ToolTipText = "Этапы";
            this.Stage_TSB.Click += new System.EventHandler(this.Stages_TSB_Click);
            // 
            // Hide_TSB
            // 
            this.Hide_TSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Hide_TSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Hide_TSB.Image = global::SZGC.Desktop.Properties.Resources.Left;
            this.Hide_TSB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Hide_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Hide_TSB.Name = "Hide_TSB";
            this.Hide_TSB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Hide_TSB.Size = new System.Drawing.Size(199, 36);
            this.Hide_TSB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Hide_TSB.Click += new System.EventHandler(this.Hide_TSB_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings_TSMI});
            this.menuStrip1.Location = new System.Drawing.Point(200, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(936, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Main_TS
            // 
            this.Main_TS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.Main_TS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Main_TS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TS.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Main_TS.GripMargin = new System.Windows.Forms.Padding(0);
            this.Main_TS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Main_TS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Main_TS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdvancedSearch_TSB,
            this.Reset_TSB,
            this.Search_TB_TSB,
            this.Search_B_TSB,
            this.Add_TSB,
            this.Edit_TSB,
            this.Delete_TSB});
            this.Main_TS.Location = new System.Drawing.Point(200, 28);
            this.Main_TS.Name = "Main_TS";
            this.Main_TS.Padding = new System.Windows.Forms.Padding(0);
            this.Main_TS.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Main_TS.Size = new System.Drawing.Size(936, 40);
            this.Main_TS.TabIndex = 0;
            this.Main_TS.Text = "Основное";
            // 
            // AdvancedSearch_TSB
            // 
            this.AdvancedSearch_TSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AdvancedSearch_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdvancedSearch_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AdvancedSearch_TSB.Image = global::SZGC.Desktop.Properties.Resources.SearchFilter;
            this.AdvancedSearch_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AdvancedSearch_TSB.Name = "AdvancedSearch_TSB";
            this.AdvancedSearch_TSB.Size = new System.Drawing.Size(180, 37);
            this.AdvancedSearch_TSB.Text = "Расширенный поиск";
            this.AdvancedSearch_TSB.Click += new System.EventHandler(this.AdvancedSearch_TSB_Click);
            // 
            // Reset_TSB
            // 
            this.Reset_TSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Reset_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Reset_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Reset_TSB.Image = global::SZGC.Desktop.Properties.Resources.SearchClear;
            this.Reset_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Reset_TSB.Name = "Reset_TSB";
            this.Reset_TSB.Size = new System.Drawing.Size(106, 37);
            this.Reset_TSB.Text = "Сбросить";
            this.Reset_TSB.Click += new System.EventHandler(this.Reset_TSB_Click);
            // 
            // Search_TB_TSB
            // 
            this.Search_TB_TSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Search_TB_TSB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Search_TB_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(77)))), ((int)(((byte)(89)))));
            this.Search_TB_TSB.Name = "Search_TB_TSB";
            this.Search_TB_TSB.Size = new System.Drawing.Size(175, 40);
            // 
            // Search_B_TSB
            // 
            this.Search_B_TSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Search_B_TSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Search_B_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Search_B_TSB.Image = global::SZGC.Desktop.Properties.Resources.Search;
            this.Search_B_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Search_B_TSB.Name = "Search_B_TSB";
            this.Search_B_TSB.Size = new System.Drawing.Size(36, 37);
            this.Search_B_TSB.ToolTipText = "Поиск";
            this.Search_B_TSB.Click += new System.EventHandler(this.Search_B_TSB_Click_1);
            // 
            // Add_TSB
            // 
            this.Add_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Add_TSB.Image = global::SZGC.Desktop.Properties.Resources.add;
            this.Add_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Add_TSB.Name = "Add_TSB";
            this.Add_TSB.Size = new System.Drawing.Size(105, 37);
            this.Add_TSB.Text = "Добавить";
            this.Add_TSB.Click += new System.EventHandler(this.Add_TSB_Click);
            // 
            // Edit_TSB
            // 
            this.Edit_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Edit_TSB.Image = global::SZGC.Desktop.Properties.Resources.edit;
            this.Edit_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Edit_TSB.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.Edit_TSB.Name = "Edit_TSB";
            this.Edit_TSB.Size = new System.Drawing.Size(104, 37);
            this.Edit_TSB.Text = "Изменить";
            this.Edit_TSB.Click += new System.EventHandler(this.Edit_TSB_Click);
            // 
            // Delete_TSB
            // 
            this.Delete_TSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Delete_TSB.Image = global::SZGC.Desktop.Properties.Resources.delete;
            this.Delete_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Delete_TSB.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.Delete_TSB.Name = "Delete_TSB";
            this.Delete_TSB.Size = new System.Drawing.Size(96, 37);
            this.Delete_TSB.Text = "Удалить";
            this.Delete_TSB.Click += new System.EventHandler(this.Delete_TSB_Click);
            // 
            // Main_DGV
            // 
            this.Main_DGV.AllowUserToAddRows = false;
            this.Main_DGV.AllowUserToDeleteRows = false;
            this.Main_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Main_DGV.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Main_DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Main_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Main_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_DGV.Location = new System.Drawing.Point(203, 71);
            this.Main_DGV.Name = "Main_DGV";
            this.Main_DGV.ReadOnly = true;
            this.Main_DGV.RowHeadersVisible = false;
            this.Main_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Main_DGV.Size = new System.Drawing.Size(930, 581);
            this.Main_DGV.TabIndex = 4;
            this.Main_DGV.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Main_DGV_CellMouseDoubleClick);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateBaseOn_TSMI});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.ShowImageMargin = false;
            this.ContextMenuStrip.Size = new System.Drawing.Size(196, 26);
            // 
            // CreateBaseOn_TSMI
            // 
            this.CreateBaseOn_TSMI.Name = "CreateBaseOn_TSMI";
            this.CreateBaseOn_TSMI.Size = new System.Drawing.Size(195, 22);
            this.CreateBaseOn_TSMI.Text = "Создать на основании";
            this.CreateBaseOn_TSMI.Click += new System.EventHandler(this.CreateBaseOn_TSMI_Click);
            // 
            // Settings_TSMI
            // 
            this.Settings_TSMI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Settings_TSMI.Name = "Settings_TSMI";
            this.Settings_TSMI.Size = new System.Drawing.Size(88, 20);
            this.Settings_TSMI.Text = "Настройки";
            this.Settings_TSMI.Click += new System.EventHandler(this.Settings_TSMI_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1136, 655);
            this.Controls.Add(this.Main_TLP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1152, 694);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "СЗГЦ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
            this.Load += new System.EventHandler(this.MainView_Load);
            this.Main_TLP.ResumeLayout(false);
            this.Main_TLP.PerformLayout();
            this.Func_TS.ResumeLayout(false);
            this.Func_TS.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Main_TS.ResumeLayout(false);
            this.Main_TS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DGV)).EndInit();
            this.ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Main_TLP;
        private System.Windows.Forms.ToolStrip Func_TS;
        private System.Windows.Forms.ToolStripButton Hide_TSB;
        private System.Windows.Forms.ToolStrip Main_TS;
        private System.Windows.Forms.ToolStripButton AdvancedSearch_TSB;
        private System.Windows.Forms.ToolStripButton Reset_TSB;
        private System.Windows.Forms.ToolStripTextBox Search_TB_TSB;
        private System.Windows.Forms.ToolStripButton Search_B_TSB;
        private System.Windows.Forms.ToolStripLabel Datas_TSB;
        private System.Windows.Forms.ToolStripButton Order_TSB;
        private System.Windows.Forms.ToolStripButton Nomenclature_TSB;
        private System.Windows.Forms.ToolStripButton Stage_TSB;
        private System.Windows.Forms.DataGridView Main_DGV;
        private System.Windows.Forms.ToolStripButton Add_TSB;
        private System.Windows.Forms.ToolStripButton Edit_TSB;
        private System.Windows.Forms.ToolStripButton Delete_TSB;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CreateBaseOn_TSMI;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Settings_TSMI;
    }
}

