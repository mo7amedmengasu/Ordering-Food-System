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
            ((System.ComponentModel.ISupportInitialize)(this.restaurantGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // restaurantGrid
            // 
            this.restaurantGrid.AllowUserToAddRows = false;
            this.restaurantGrid.AllowUserToDeleteRows = false;
            this.restaurantGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.restaurantGrid.Location = new System.Drawing.Point(12, 94);
            this.restaurantGrid.Name = "restaurantGrid";
            this.restaurantGrid.ReadOnly = true;
            this.restaurantGrid.RowHeadersWidth = 62;
            this.restaurantGrid.RowTemplate.Height = 28;
            this.restaurantGrid.Size = new System.Drawing.Size(560, 333);
            this.restaurantGrid.TabIndex = 0;
            // 
            // RestaurantsAvailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 450);
            this.Controls.Add(this.restaurantGrid);
            this.Name = "RestaurantsAvailable";
            this.Text = "RestaurantsAvailable";
            this.Load += new System.EventHandler(this.RestaurantsAvailable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.restaurantGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView restaurantGrid;
    }
}