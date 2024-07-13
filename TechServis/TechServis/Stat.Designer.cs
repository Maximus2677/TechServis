namespace TechServis
{
    partial class Stat
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Kol = new System.Windows.Forms.Label();
            this.lbl_Sred = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Tipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(255, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Статистика";
            // 
            // lbl_Kol
            // 
            this.lbl_Kol.AutoSize = true;
            this.lbl_Kol.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Kol.Location = new System.Drawing.Point(40, 74);
            this.lbl_Kol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Kol.Name = "lbl_Kol";
            this.lbl_Kol.Size = new System.Drawing.Size(278, 21);
            this.lbl_Kol.TabIndex = 1;
            this.lbl_Kol.Text = "Количество выполненых заявок: ";
            // 
            // lbl_Sred
            // 
            this.lbl_Sred.AutoSize = true;
            this.lbl_Sred.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Sred.Location = new System.Drawing.Point(40, 95);
            this.lbl_Sred.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Sred.Name = "lbl_Sred";
            this.lbl_Sred.Size = new System.Drawing.Size(300, 21);
            this.lbl_Sred.TabIndex = 2;
            this.lbl_Sred.Text = "Среднее время выполнения заявки: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipe,
            this.Kol});
            this.dataGridView1.Location = new System.Drawing.Point(9, 119);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(626, 271);
            this.dataGridView1.TabIndex = 3;
            // 
            // Tipe
            // 
            this.Tipe.HeaderText = "Тип поломки";
            this.Tipe.MinimumWidth = 6;
            this.Tipe.Name = "Tipe";
            this.Tipe.ReadOnly = true;
            this.Tipe.Width = 125;
            // 
            // Kol
            // 
            this.Kol.HeaderText = "Количество случаев";
            this.Kol.MinimumWidth = 6;
            this.Kol.Name = "Kol";
            this.Kol.ReadOnly = true;
            this.Kol.Width = 125;
            // 
            // Stat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 399);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbl_Sred);
            this.Controls.Add(this.lbl_Kol);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Stat";
            this.Text = "Статистика";
            this.Load += new System.EventHandler(this.Stat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Kol;
        private System.Windows.Forms.Label lbl_Sred;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kol;
    }
}