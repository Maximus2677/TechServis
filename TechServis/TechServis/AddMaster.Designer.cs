namespace TechServis
{
    partial class AddMaster
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
            this.button1 = new System.Windows.Forms.Button();
            this.tb_Tel = new System.Windows.Forms.TextBox();
            this.tb_FIO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Login = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 167);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 19);
            this.button1.TabIndex = 31;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_Tel
            // 
            this.tb_Tel.Location = new System.Drawing.Point(116, 107);
            this.tb_Tel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Tel.MaxLength = 20;
            this.tb_Tel.Name = "tb_Tel";
            this.tb_Tel.Size = new System.Drawing.Size(358, 20);
            this.tb_Tel.TabIndex = 26;
            // 
            // tb_FIO
            // 
            this.tb_FIO.Location = new System.Drawing.Point(116, 84);
            this.tb_FIO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_FIO.MaxLength = 50;
            this.tb_FIO.Name = "tb_FIO";
            this.tb_FIO.Size = new System.Drawing.Size(358, 20);
            this.tb_FIO.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Телефон";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "ФИО";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(160, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 31);
            this.label1.TabIndex = 18;
            this.label1.Text = "Добавление мастера";
            // 
            // cb_Login
            // 
            this.cb_Login.FormattingEnabled = true;
            this.cb_Login.Location = new System.Drawing.Point(116, 130);
            this.cb_Login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_Login.Name = "cb_Login";
            this.cb_Login.Size = new System.Drawing.Size(358, 21);
            this.cb_Login.TabIndex = 32;
            // 
            // AddMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 226);
            this.Controls.Add(this.cb_Login);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_Tel);
            this.Controls.Add(this.tb_FIO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddMaster";
            this.Text = "Добавление мастера";
            this.Load += new System.EventHandler(this.AddMaster_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_Tel;
        private System.Windows.Forms.TextBox tb_FIO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Login;
    }
}