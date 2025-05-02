namespace Db_Project.Forms
{
    partial class ManageRestaurantsForm
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
            this.restaurantGrid = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.btnAddRestaurant = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.btnAddPhone = new System.Windows.Forms.Button();
            this.btnDeleteAddress = new System.Windows.Forms.Button();
            this.btnDeletePhone = new System.Windows.Forms.Button();
            this.lstAddresses = new System.Windows.Forms.ListBox();
            this.lstPhones = new System.Windows.Forms.ListBox();
            this.btnUpdateRestaurant = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // restaurantGrid
            // 
            this.restaurantGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.restaurantGrid.Location = new System.Drawing.Point(29, 30);
            this.restaurantGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.restaurantGrid.Name = "restaurantGrid";
            this.restaurantGrid.ReadOnly = true;
            this.restaurantGrid.RowHeadersWidth = 62;
            this.restaurantGrid.RowTemplate.Height = 28;
            this.restaurantGrid.Size = new System.Drawing.Size(308, 206);
            this.restaurantGrid.TabIndex = 0;
            this.restaurantGrid.SelectionChanged += new System.EventHandler(this.restaurantGrid_SelectionChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(29, 257);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(224, 22);
            this.txtName.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(29, 282);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(224, 22);
            this.txtAddress.TabIndex = 2;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(29, 308);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(224, 22);
            this.txtPhone.TabIndex = 3;
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(29, 334);
            this.txtRating.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRating.Name = "txtRating";
            this.txtRating.ShortcutsEnabled = false;
            this.txtRating.Size = new System.Drawing.Size(224, 22);
            this.txtRating.TabIndex = 4;
            // 
            // btnAddRestaurant
            // 
            this.btnAddRestaurant.Location = new System.Drawing.Point(283, 252);
            this.btnAddRestaurant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddRestaurant.Name = "btnAddRestaurant";
            this.btnAddRestaurant.Size = new System.Drawing.Size(162, 26);
            this.btnAddRestaurant.TabIndex = 5;
            this.btnAddRestaurant.Text = "Add restaurant";
            this.btnAddRestaurant.UseVisualStyleBackColor = true;
            this.btnAddRestaurant.Click += new System.EventHandler(this.btnAddRestaurant_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 282);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "Delete restaurant";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnDeleteRestaurant_Click);
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(600, 30);
            this.btnAddAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(100, 21);
            this.btnAddAddress.TabIndex = 9;
            this.btnAddAddress.Text = "Add address";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // btnAddPhone
            // 
            this.btnAddPhone.Location = new System.Drawing.Point(600, 134);
            this.btnAddPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddPhone.Name = "btnAddPhone";
            this.btnAddPhone.Size = new System.Drawing.Size(100, 21);
            this.btnAddPhone.TabIndex = 10;
            this.btnAddPhone.Text = "Add phone number";
            this.btnAddPhone.UseVisualStyleBackColor = true;
            this.btnAddPhone.Click += new System.EventHandler(this.btnAddPhone_Click);
            // 
            // btnDeleteAddress
            // 
            this.btnDeleteAddress.Location = new System.Drawing.Point(600, 56);
            this.btnDeleteAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteAddress.Name = "btnDeleteAddress";
            this.btnDeleteAddress.Size = new System.Drawing.Size(100, 21);
            this.btnDeleteAddress.TabIndex = 11;
            this.btnDeleteAddress.Text = "Delete Address";
            this.btnDeleteAddress.UseVisualStyleBackColor = true;
            this.btnDeleteAddress.Click += new System.EventHandler(this.btnDeleteAddress_Click);
            // 
            // btnDeletePhone
            // 
            this.btnDeletePhone.Location = new System.Drawing.Point(600, 160);
            this.btnDeletePhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeletePhone.Name = "btnDeletePhone";
            this.btnDeletePhone.Size = new System.Drawing.Size(100, 21);
            this.btnDeletePhone.TabIndex = 12;
            this.btnDeletePhone.Text = "Delete Address";
            this.btnDeletePhone.UseVisualStyleBackColor = true;
            this.btnDeletePhone.Click += new System.EventHandler(this.btnDeletePhone_Click);
            // 
            // lstAddresses
            // 
            this.lstAddresses.FormattingEnabled = true;
            this.lstAddresses.ItemHeight = 16;
            this.lstAddresses.Location = new System.Drawing.Point(396, 30);
            this.lstAddresses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstAddresses.Name = "lstAddresses";
            this.lstAddresses.Size = new System.Drawing.Size(107, 68);
            this.lstAddresses.TabIndex = 13;
            // 
            // lstPhones
            // 
            this.lstPhones.FormattingEnabled = true;
            this.lstPhones.ItemHeight = 16;
            this.lstPhones.Location = new System.Drawing.Point(396, 122);
            this.lstPhones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstPhones.Name = "lstPhones";
            this.lstPhones.Size = new System.Drawing.Size(107, 68);
            this.lstPhones.TabIndex = 14;
            // 
            // btnUpdateRestaurant
            // 
            this.btnUpdateRestaurant.Location = new System.Drawing.Point(283, 313);
            this.btnUpdateRestaurant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateRestaurant.Name = "btnUpdateRestaurant";
            this.btnUpdateRestaurant.Size = new System.Drawing.Size(162, 26);
            this.btnUpdateRestaurant.TabIndex = 15;
            this.btnUpdateRestaurant.Text = "Update restaurant";
            this.btnUpdateRestaurant.UseVisualStyleBackColor = true;
            this.btnUpdateRestaurant.Click += new System.EventHandler(this.btnUpdateRestaurant_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "<----";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ManageRestaurantsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnUpdateRestaurant);
            this.Controls.Add(this.lstPhones);
            this.Controls.Add(this.lstAddresses);
            this.Controls.Add(this.btnDeletePhone);
            this.Controls.Add(this.btnDeleteAddress);
            this.Controls.Add(this.btnAddPhone);
            this.Controls.Add(this.btnAddAddress);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddRestaurant);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.restaurantGrid);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManageRestaurantsForm";
            this.Text = "ManageRestaurantsForm";
            this.Load += new System.EventHandler(this.ManageRestaurantsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.restaurantGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView restaurantGrid;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Button btnAddRestaurant;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDeleteRestaurant;
        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.Button btnAddPhone;
        private System.Windows.Forms.Button btnDeleteAddress;
        private System.Windows.Forms.Button btnDeletePhone;
        private System.Windows.Forms.ListBox lstAddresses;
        private System.Windows.Forms.ListBox lstPhones;
        private System.Windows.Forms.Button btnUpdateRestaurant;
        private System.Windows.Forms.Button button2;
    }
}