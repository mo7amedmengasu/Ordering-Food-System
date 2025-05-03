namespace Db_Project.Forms
{
    partial class AddEditUserForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.useridarea = new System.Windows.Forms.TextBox();
            this.firstrnamearea = new System.Windows.Forms.TextBox();
            this.lastnamearea = new System.Windows.Forms.TextBox();
            this.emailarea = new System.Windows.Forms.TextBox();
            this.addressarea = new System.Windows.Forms.TextBox();
            this.passwordarea = new System.Windows.Forms.TextBox();
            this.rolearea = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(112, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(112, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(112, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Role:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(112, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "Password:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(308, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(275, 32);
            this.label8.TabIndex = 7;
            this.label8.Text = "Update Users Form";
            // 
            // useridarea
            // 
            this.useridarea.Location = new System.Drawing.Point(292, 92);
            this.useridarea.Name = "useridarea";
            this.useridarea.Size = new System.Drawing.Size(203, 22);
            this.useridarea.TabIndex = 8;
            // 
            // firstrnamearea
            // 
            this.firstrnamearea.Location = new System.Drawing.Point(292, 130);
            this.firstrnamearea.Name = "firstrnamearea";
            this.firstrnamearea.Size = new System.Drawing.Size(203, 22);
            this.firstrnamearea.TabIndex = 9;
            // 
            // lastnamearea
            // 
            this.lastnamearea.Location = new System.Drawing.Point(292, 169);
            this.lastnamearea.Name = "lastnamearea";
            this.lastnamearea.Size = new System.Drawing.Size(203, 22);
            this.lastnamearea.TabIndex = 10;
            // 
            // emailarea
            // 
            this.emailarea.Location = new System.Drawing.Point(292, 211);
            this.emailarea.Name = "emailarea";
            this.emailarea.Size = new System.Drawing.Size(203, 22);
            this.emailarea.TabIndex = 11;
            // 
            // addressarea
            // 
            this.addressarea.Location = new System.Drawing.Point(292, 250);
            this.addressarea.Name = "addressarea";
            this.addressarea.Size = new System.Drawing.Size(203, 22);
            this.addressarea.TabIndex = 12;
            // 
            // passwordarea
            // 
            this.passwordarea.Location = new System.Drawing.Point(292, 331);
            this.passwordarea.Name = "passwordarea";
            this.passwordarea.Size = new System.Drawing.Size(203, 22);
            this.passwordarea.TabIndex = 14;
            // 
            // rolearea
            // 
            this.rolearea.FormattingEnabled = true;
            this.rolearea.Items.AddRange(new object[] {
            "Customer",
            "Admin"});
            this.rolearea.Location = new System.Drawing.Point(292, 291);
            this.rolearea.Name = "rolearea";
            this.rolearea.Size = new System.Drawing.Size(203, 24);
            this.rolearea.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(666, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 36);
            this.button1.TabIndex = 16;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddEditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rolearea);
            this.Controls.Add(this.passwordarea);
            this.Controls.Add(this.addressarea);
            this.Controls.Add(this.emailarea);
            this.Controls.Add(this.lastnamearea);
            this.Controls.Add(this.firstrnamearea);
            this.Controls.Add(this.useridarea);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditUserForm";
            this.Text = "AddEditUserForm";
            this.Load += new System.EventHandler(this.AddEditUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox useridarea;
        private System.Windows.Forms.TextBox firstrnamearea;
        private System.Windows.Forms.TextBox lastnamearea;
        private System.Windows.Forms.TextBox emailarea;
        private System.Windows.Forms.TextBox addressarea;
        private System.Windows.Forms.TextBox passwordarea;
        private System.Windows.Forms.ComboBox rolearea;
        private System.Windows.Forms.Button button1;
    }
}