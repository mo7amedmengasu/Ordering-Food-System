namespace Db_Project.Forms
{
    partial class MenuItemsForm
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
            this.menuGrid = new System.Windows.Forms.DataGridView();
            this.cartListView = new System.Windows.Forms.ListView();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnCheckOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.menuGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuGrid
            // 
            this.menuGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.menuGrid.Location = new System.Drawing.Point(12, 113);
            this.menuGrid.Name = "menuGrid";
            this.menuGrid.ReadOnly = true;
            this.menuGrid.RowHeadersWidth = 62;
            this.menuGrid.RowTemplate.Height = 28;
            this.menuGrid.Size = new System.Drawing.Size(758, 290);
            this.menuGrid.TabIndex = 0;
            // 
            // cartListView
            // 
            this.cartListView.HideSelection = false;
            this.cartListView.Location = new System.Drawing.Point(50, 450);
            this.cartListView.Name = "cartListView";
            this.cartListView.Size = new System.Drawing.Size(659, 391);
            this.cartListView.TabIndex = 1;
            this.cartListView.UseCompatibleStateImageBehavior = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(68, 878);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(102, 20);
            this.lblTotalAmount.TabIndex = 2;
            this.lblTotalAmount.Text = "Total amount";
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(561, 875);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(148, 35);
            this.btnCheckOut.TabIndex = 3;
            this.btnCheckOut.Text = "Check out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // MenuItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 932);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.cartListView);
            this.Controls.Add(this.menuGrid);
            this.Name = "MenuItemsForm";
            this.Text = "MenuItemsForm";
            this.Load += new System.EventHandler(this.MenuItemsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.menuGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView menuGrid;
        private System.Windows.Forms.ListView cartListView;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnCheckOut;
    }
}