
namespace Db_Project.Forms
{
    partial class AdminDashboard
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
            this.adminRestaurantGrid = new System.Windows.Forms.DataGridView();
            this.adminOrdersGrid = new System.Windows.Forms.DataGridView();
            this.btnAddRestaurant = new System.Windows.Forms.Button();
            this.txtRestaurantName = new System.Windows.Forms.TextBox();
            this.btnDeleteRestaurant = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lstAddresses = new System.Windows.Forms.ListBox();
            this.lstPhones = new System.Windows.Forms.ListBox();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.btnRemoveAddress = new System.Windows.Forms.Button();
            this.btnAddPhone = new System.Windows.Forms.Button();
            this.btnRemovePhone = new System.Windows.Forms.Button();
            this.btnUpdateRestaurant = new System.Windows.Forms.Button();
            this.txtRating = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.adminRestaurantGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminOrdersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // adminRestaurantGrid
            // 
            this.adminRestaurantGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adminRestaurantGrid.Location = new System.Drawing.Point(12, 12);
            this.adminRestaurantGrid.Name = "adminRestaurantGrid";
            this.adminRestaurantGrid.RowHeadersWidth = 62;
            this.adminRestaurantGrid.RowTemplate.Height = 28;
            this.adminRestaurantGrid.Size = new System.Drawing.Size(501, 460);
            this.adminRestaurantGrid.TabIndex = 0;
            // 
            // adminOrdersGrid
            // 
            this.adminOrdersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adminOrdersGrid.Location = new System.Drawing.Point(753, 12);
            this.adminOrdersGrid.Name = "adminOrdersGrid";
            this.adminOrdersGrid.RowHeadersWidth = 62;
            this.adminOrdersGrid.RowTemplate.Height = 28;
            this.adminOrdersGrid.Size = new System.Drawing.Size(405, 460);
            this.adminOrdersGrid.TabIndex = 1;
            // 
            // btnAddRestaurant
            // 
            this.btnAddRestaurant.Location = new System.Drawing.Point(12, 490);
            this.btnAddRestaurant.Name = "btnAddRestaurant";
            this.btnAddRestaurant.Size = new System.Drawing.Size(212, 46);
            this.btnAddRestaurant.TabIndex = 2;
            this.btnAddRestaurant.Text = "Add restaurant";
            this.btnAddRestaurant.UseVisualStyleBackColor = true;
            this.btnAddRestaurant.Click += new System.EventHandler(this.btnAddRestaurant_Click);
            // 
            // txtRestaurantName
            // 
            this.txtRestaurantName.Location = new System.Drawing.Point(12, 554);
            this.txtRestaurantName.Name = "txtRestaurantName";
            this.txtRestaurantName.Size = new System.Drawing.Size(233, 26);
            this.txtRestaurantName.TabIndex = 3;
            this.txtRestaurantName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnDeleteRestaurant
            // 
            this.btnDeleteRestaurant.Location = new System.Drawing.Point(304, 490);
            this.btnDeleteRestaurant.Name = "btnDeleteRestaurant";
            this.btnDeleteRestaurant.Size = new System.Drawing.Size(189, 46);
            this.btnDeleteRestaurant.TabIndex = 4;
            this.btnDeleteRestaurant.Text = "Delete Restaurant";
            this.btnDeleteRestaurant.UseVisualStyleBackColor = true;
            this.btnDeleteRestaurant.Click += new System.EventHandler(this.btnDeleteRestaurant_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(520, 554);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(233, 26);
            this.txtAddress.TabIndex = 5;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(520, 596);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(233, 26);
            this.txtPhone.TabIndex = 6;
            // 
            // lstAddresses
            // 
            this.lstAddresses.FormattingEnabled = true;
            this.lstAddresses.ItemHeight = 20;
            this.lstAddresses.Location = new System.Drawing.Point(520, 13);
            this.lstAddresses.Name = "lstAddresses";
            this.lstAddresses.Size = new System.Drawing.Size(212, 164);
            this.lstAddresses.TabIndex = 7;
            // 
            // lstPhones
            // 
            this.lstPhones.FormattingEnabled = true;
            this.lstPhones.ItemHeight = 20;
            this.lstPhones.Location = new System.Drawing.Point(520, 193);
            this.lstPhones.Name = "lstPhones";
            this.lstPhones.Size = new System.Drawing.Size(212, 164);
            this.lstPhones.TabIndex = 8;
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(520, 376);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(212, 33);
            this.btnAddAddress.TabIndex = 9;
            this.btnAddAddress.Text = "Add address";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // btnRemoveAddress
            // 
            this.btnRemoveAddress.Location = new System.Drawing.Point(520, 415);
            this.btnRemoveAddress.Name = "btnRemoveAddress";
            this.btnRemoveAddress.Size = new System.Drawing.Size(212, 33);
            this.btnRemoveAddress.TabIndex = 10;
            this.btnRemoveAddress.Text = "Remove address";
            this.btnRemoveAddress.UseVisualStyleBackColor = true;
            this.btnRemoveAddress.Click += new System.EventHandler(this.btnRemoveAddress_Click);
            // 
            // btnAddPhone
            // 
            this.btnAddPhone.Location = new System.Drawing.Point(520, 463);
            this.btnAddPhone.Name = "btnAddPhone";
            this.btnAddPhone.Size = new System.Drawing.Size(212, 33);
            this.btnAddPhone.TabIndex = 11;
            this.btnAddPhone.Text = "Add phone number";
            this.btnAddPhone.UseVisualStyleBackColor = true;
            this.btnAddPhone.Click += new System.EventHandler(this.btnAddPhone_Click);
            // 
            // btnRemovePhone
            // 
            this.btnRemovePhone.Location = new System.Drawing.Point(520, 515);
            this.btnRemovePhone.Name = "btnRemovePhone";
            this.btnRemovePhone.Size = new System.Drawing.Size(212, 33);
            this.btnRemovePhone.TabIndex = 12;
            this.btnRemovePhone.Text = "Remove phone number";
            this.btnRemovePhone.UseVisualStyleBackColor = true;
            this.btnRemovePhone.Click += new System.EventHandler(this.btnRemovePhone_Click);
            // 
            // btnUpdateRestaurant
            // 
            this.btnUpdateRestaurant.Location = new System.Drawing.Point(12, 607);
            this.btnUpdateRestaurant.Name = "btnUpdateRestaurant";
            this.btnUpdateRestaurant.Size = new System.Drawing.Size(212, 46);
            this.btnUpdateRestaurant.TabIndex = 13;
            this.btnUpdateRestaurant.Text = "Update restaurant";
            this.btnUpdateRestaurant.UseVisualStyleBackColor = true;
            this.btnUpdateRestaurant.Click += new System.EventHandler(this.btnUpdateRestaurant_Click);
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(260, 554);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(233, 26);
            this.txtRating.TabIndex = 14;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 810);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.btnUpdateRestaurant);
            this.Controls.Add(this.btnRemovePhone);
            this.Controls.Add(this.btnAddPhone);
            this.Controls.Add(this.btnRemoveAddress);
            this.Controls.Add(this.btnAddAddress);
            this.Controls.Add(this.lstPhones);
            this.Controls.Add(this.lstAddresses);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnDeleteRestaurant);
            this.Controls.Add(this.txtRestaurantName);
            this.Controls.Add(this.btnAddRestaurant);
            this.Controls.Add(this.adminOrdersGrid);
            this.Controls.Add(this.adminRestaurantGrid);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.adminRestaurantGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminOrdersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView adminRestaurantGrid;
        private System.Windows.Forms.DataGridView adminOrdersGrid;
        private System.Windows.Forms.Button btnAddRestaurant;
        private System.Windows.Forms.TextBox txtRestaurantName;
        private System.Windows.Forms.Button btnDeleteRestaurant;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ListBox lstAddresses;
        private System.Windows.Forms.ListBox lstPhones;
        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.Button btnRemoveAddress;
        private System.Windows.Forms.Button btnAddPhone;
        private System.Windows.Forms.Button btnRemovePhone;
        private System.Windows.Forms.Button btnUpdateRestaurant;
        private System.Windows.Forms.TextBox txtRating;
    }
}