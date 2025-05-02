namespace Db_Project.Forms
{
    partial class AdminNavigationn
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
            this.btnManageMenu = new System.Windows.Forms.Button();
            this.btnManageRestaurants = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Dashboard";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnManageMenu
            // 
            this.btnManageMenu.Location = new System.Drawing.Point(34, 138);
            this.btnManageMenu.Name = "btnManageMenu";
            this.btnManageMenu.Size = new System.Drawing.Size(222, 222);
            this.btnManageMenu.TabIndex = 1;
            this.btnManageMenu.Text = "Manage Menu";
            this.btnManageMenu.UseVisualStyleBackColor = true;
            this.btnManageMenu.Click += new System.EventHandler(this.btnManageMenu_Click);
            // 
            // btnManageRestaurants
            // 
            this.btnManageRestaurants.Location = new System.Drawing.Point(289, 138);
            this.btnManageRestaurants.Name = "btnManageRestaurants";
            this.btnManageRestaurants.Size = new System.Drawing.Size(222, 222);
            this.btnManageRestaurants.TabIndex = 2;
            this.btnManageRestaurants.Text = "Manage Restaurants";
            this.btnManageRestaurants.UseVisualStyleBackColor = true;
            this.btnManageRestaurants.Click += new System.EventHandler(this.btnManageRestaurants_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Location = new System.Drawing.Point(552, 138);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(222, 222);
            this.btnManageUsers.TabIndex = 3;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // AdminNavigationn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnManageRestaurants);
            this.Controls.Add(this.btnManageMenu);
            this.Controls.Add(this.label1);
            this.Name = "AdminNavigationn";
            this.Text = "AdminNavigationn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageMenu;
        private System.Windows.Forms.Button btnManageRestaurants;
        private System.Windows.Forms.Button btnManageUsers;
    }
}