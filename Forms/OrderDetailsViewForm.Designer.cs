namespace Db_Project.Forms
{
    partial class OrderDetailsViewForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtTotalAmount;
       
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTotalAmount;
       

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(100, 20);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.ReadOnly = true;
            this.txtOrderId.Size = new System.Drawing.Size(200, 22);
            this.txtOrderId.TabIndex = 0;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(100, 60);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(200, 22);
            this.txtDate.TabIndex = 1;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(380, 61);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(200, 22);
            this.txtStatus.TabIndex = 2;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(380, 20);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(200, 22);
            this.txtTotalAmount.TabIndex = 3;
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.ColumnHeadersHeight = 29;
            this.dgvOrderItems.Location = new System.Drawing.Point(20, 150);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.Size = new System.Drawing.Size(560, 200);
            this.dgvOrderItems.TabIndex = 6;
            this.dgvOrderItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellContentClick);
            // 
            // lblOrderId
            // 
            this.lblOrderId.Location = new System.Drawing.Point(20, 20);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(100, 23);
            this.lblOrderId.TabIndex = 7;
            this.lblOrderId.Text = "Order ID:";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(20, 60);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 23);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Date:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(300, 59);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Location = new System.Drawing.Point(300, 20);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(100, 23);
            this.lblTotalAmount.TabIndex = 10;
            this.lblTotalAmount.Text = "Total:";
            // 
            // OrderDetailsViewForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 380);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTotalAmount);
            this.Name = "OrderDetailsViewForm";
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.OrderDetailsViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
    }
}
