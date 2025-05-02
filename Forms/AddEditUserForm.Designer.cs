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
            this.firstnamearea = new System.Windows.Forms.TextBox();
            this.lastnamearea = new System.Windows.Forms.TextBox();
            this.emailarea = new System.Windows.Forms.TextBox();
            this.addressarea = new System.Windows.Forms.TextBox();
            this.rolearea = new System.Windows.Forms.TextBox();
            this.passwordarea = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.useridarea = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(784, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add User";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // firstnamearea
            // 
            this.firstnamearea.Location = new System.Drawing.Point(316, 105);
            this.firstnamearea.Name = "firstnamearea";
            this.firstnamearea.Size = new System.Drawing.Size(212, 22);
            this.firstnamearea.TabIndex = 1;
            // 
            // lastnamearea
            // 
            this.lastnamearea.Location = new System.Drawing.Point(316, 142);
            this.lastnamearea.Name = "lastnamearea";
            this.lastnamearea.Size = new System.Drawing.Size(212, 22);
            this.lastnamearea.TabIndex = 2;
            // 
            // emailarea
            // 
            this.emailarea.Location = new System.Drawing.Point(316, 181);
            this.emailarea.Name = "emailarea";
            this.emailarea.Size = new System.Drawing.Size(212, 22);
            this.emailarea.TabIndex = 3;
            // 
            // addressarea
            // 
            this.addressarea.Location = new System.Drawing.Point(316, 221);
            this.addressarea.Name = "addressarea";
            this.addressarea.Size = new System.Drawing.Size(212, 22);
            this.addressarea.TabIndex = 4;
            // 
            // rolearea
            // 
            this.rolearea.Location = new System.Drawing.Point(316, 265);
            this.rolearea.Name = "rolearea";
            this.rolearea.Size = new System.Drawing.Size(212, 22);
            this.rolearea.TabIndex = 5;
            // 
            // passwordarea
            // 
            this.passwordarea.Location = new System.Drawing.Point(316, 308);
            this.passwordarea.Name = "passwordarea";
            this.passwordarea.Size = new System.Drawing.Size(212, 22);
            this.passwordarea.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "User ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(148, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "First Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(148, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Last Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(147, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "Email:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(147, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "Address:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(147, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 22);
            this.label7.TabIndex = 12;
            this.label7.Text = "Role:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(147, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 22);
            this.label8.TabIndex = 13;
            this.label8.Text = "Password:";
            // 
            // useridarea
            // 
            this.useridarea.Location = new System.Drawing.Point(316, 72);
            this.useridarea.Name = "useridarea";
            this.useridarea.Size = new System.Drawing.Size(212, 22);
            this.useridarea.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(643, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 39);
            this.button1.TabIndex = 15;
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
            this.Controls.Add(this.useridarea);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordarea);
            this.Controls.Add(this.rolearea);
            this.Controls.Add(this.addressarea);
            this.Controls.Add(this.emailarea);
            this.Controls.Add(this.lastnamearea);
            this.Controls.Add(this.firstnamearea);
            this.Controls.Add(this.label1);
            this.Name = "AddEditUserForm";
            this.Text = "Add/EditUserForm";
            this.Load += new System.EventHandler(this.AddEditUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstnamearea;
        private System.Windows.Forms.TextBox lastnamearea;
        private System.Windows.Forms.TextBox emailarea;
        private System.Windows.Forms.TextBox addressarea;
        private System.Windows.Forms.TextBox rolearea;
        private System.Windows.Forms.TextBox passwordarea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox useridarea;
        private System.Windows.Forms.Button button1;
    }
}