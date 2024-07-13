namespace TechServis
{
    partial class AddUser
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
            this.tb_UserPassword = new System.Windows.Forms.TextBox();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_AdminRole = new System.Windows.Forms.CheckBox();
            this.ManagerRole = new System.Windows.Forms.CheckBox();
            this.MasterRole = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 202);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 19);
            this.button1.TabIndex = 31;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_UserPassword
            // 
            this.tb_UserPassword.Location = new System.Drawing.Point(73, 103);
            this.tb_UserPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_UserPassword.MaxLength = 40;
            this.tb_UserPassword.Name = "tb_UserPassword";
            this.tb_UserPassword.Size = new System.Drawing.Size(358, 20);
            this.tb_UserPassword.TabIndex = 26;
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(73, 80);
            this.tb_UserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(358, 20);
            this.tb_UserName.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Логин";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(80, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 31);
            this.label1.TabIndex = 18;
            this.label1.Text = "Добавление пользователя";
            // 
            // cb_AdminRole
            // 
            this.cb_AdminRole.AutoSize = true;
            this.cb_AdminRole.Location = new System.Drawing.Point(344, 126);
            this.cb_AdminRole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_AdminRole.Name = "cb_AdminRole";
            this.cb_AdminRole.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cb_AdminRole.Size = new System.Drawing.Size(93, 17);
            this.cb_AdminRole.TabIndex = 32;
            this.cb_AdminRole.Text = "Роль Админа";
            this.cb_AdminRole.UseVisualStyleBackColor = true;
            // 
            // ManagerRole
            // 
            this.ManagerRole.AutoSize = true;
            this.ManagerRole.Location = new System.Drawing.Point(325, 147);
            this.ManagerRole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ManagerRole.Name = "ManagerRole";
            this.ManagerRole.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ManagerRole.Size = new System.Drawing.Size(113, 17);
            this.ManagerRole.TabIndex = 33;
            this.ManagerRole.Text = "Роль Менеджера";
            this.ManagerRole.UseVisualStyleBackColor = true;
            // 
            // MasterRole
            // 
            this.MasterRole.AutoSize = true;
            this.MasterRole.Checked = true;
            this.MasterRole.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MasterRole.Location = new System.Drawing.Point(339, 168);
            this.MasterRole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MasterRole.Name = "MasterRole";
            this.MasterRole.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MasterRole.Size = new System.Drawing.Size(98, 17);
            this.MasterRole.TabIndex = 34;
            this.MasterRole.Text = "Роль Мастера";
            this.MasterRole.UseVisualStyleBackColor = true;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 245);
            this.Controls.Add(this.MasterRole);
            this.Controls.Add(this.ManagerRole);
            this.Controls.Add(this.cb_AdminRole);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_UserPassword);
            this.Controls.Add(this.tb_UserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddUser";
            this.Text = "Добавление пользователя";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_UserPassword;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_AdminRole;
        private System.Windows.Forms.CheckBox ManagerRole;
        private System.Windows.Forms.CheckBox MasterRole;
    }
}