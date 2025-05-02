namespace Db_Project.Forms
{
    partial class RestaurantsAvailable
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
            this.lstPhones = new System.Windows.Forms.ListView();
            this.lstAddresses = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // restaurantGrid
            // 
            this.restaurantGrid.AllowUserToAddRows = false;
            this.restaurantGrid.AllowUserToDeleteRows = false;
            this.restaurantGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.restaurantGrid.Location = new System.Drawing.Point(11, 75);
            this.restaurantGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.restaurantGrid.Name = "restaurantGrid";
            this.restaurantGrid.ReadOnly = true;
            this.restaurantGrid.RowHeadersWidth = 62;
            this.restaurantGrid.RowTemplate.Height = 28;
            this.restaurantGrid.Size = new System.Drawing.Size(498, 266);
            this.restaurantGrid.TabIndex = 0;
            // 
            // lstPhones
            // 
            this.lstPhones.HideSelection = false;
            this.lstPhones.Location = new System.Drawing.Point(547, 75);
            this.lstPhones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstPhones.Name = "lstPhones";
            this.lstPhones.Size = new System.Drawing.Size(206, 100);
            this.lstPhones.TabIndex = 1;
            this.lstPhones.UseCompatibleStateImageBehavior = false;
            // 
            // lstAddresses
            // 
            this.lstAddresses.HideSelection = false;
            this.lstAddresses.Location = new System.Drawing.Point(547, 190);
            this.lstAddresses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstAddresses.Name = "lstAddresses";
            this.lstAddresses.Size = new System.Drawing.Size(206, 100);
            this.lstAddresses.TabIndex = 2;
            this.lstAddresses.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "<----";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RestaurantsAvailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 360);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstAddresses);
            this.Controls.Add(this.lstPhones);
            this.Controls.Add(this.restaurantGrid);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RestaurantsAvailable";
            this.Text = "RestaurantsAvailable";
            this.Load += new System.EventHandler(this.RestaurantsAvailable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.restaurantGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView restaurantGrid;
        private System.Windows.Forms.ListView lstPhones;
        private System.Windows.Forms.ListView lstAddresses;
        private System.Windows.Forms.Button button1;
    }
}