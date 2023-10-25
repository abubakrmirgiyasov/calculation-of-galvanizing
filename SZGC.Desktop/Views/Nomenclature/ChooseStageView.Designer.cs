namespace SZGC.Desktop.Views.Nomenclature
{
    partial class ChooseStageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseStageView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Choose_B = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Stages_LB = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Choose_B, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Stages_LB, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(253, 307);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Choose_B
            // 
            this.Choose_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.Choose_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Choose_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Choose_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choose_B.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Choose_B.ForeColor = System.Drawing.Color.White;
            this.Choose_B.Location = new System.Drawing.Point(5, 272);
            this.Choose_B.Margin = new System.Windows.Forms.Padding(5);
            this.Choose_B.Name = "Choose_B";
            this.Choose_B.Size = new System.Drawing.Size(243, 30);
            this.Choose_B.TabIndex = 4;
            this.Choose_B.Text = "Выбрать";
            this.Choose_B.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выбрите номенклатуру";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Stages_LB
            // 
            this.Stages_LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Stages_LB.FormattingEnabled = true;
            this.Stages_LB.Location = new System.Drawing.Point(5, 50);
            this.Stages_LB.Margin = new System.Windows.Forms.Padding(5);
            this.Stages_LB.Name = "Stages_LB";
            this.Stages_LB.Size = new System.Drawing.Size(243, 212);
            this.Stages_LB.TabIndex = 0;
            // 
            // ChooseStageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(253, 307);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseStageView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбрать номенклатуру";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseView_FormClosing);
            this.Load += new System.EventHandler(this.ChooseView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox Stages_LB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Choose_B;
    }
}