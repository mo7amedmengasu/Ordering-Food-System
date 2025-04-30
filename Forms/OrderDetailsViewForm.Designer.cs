namespace Db_Project.Forms
{
    partial class OrderDetailsViewForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtDeliveryAddress;
        private System.Windows.Forms.TextBox txtEstimatedTime;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblDeliveryAddress;
        private System.Windows.Forms.Label lblEstimatedTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtDeliveryAddress = new System.Windows.Forms.TextBox();
            this.txtEstimatedTime = new System.Windows.Forms.TextBox();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblDeliveryAddress = new System.Windows.Forms.Label();
            this.lblEstimatedTime = new System.Windows.Forms.Label();
            this.winDBDataSet2 = new Db_Project.WinDBDataSet2();
            this.winDBDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winDBDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winDBDataSet2BindingSource)).BeginInit();
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
            this.txtStatus.Location = new System.Drawing.Point(100, 100);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(200, 22);
            this.txtStatus.TabIndex = 2;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(380, 20);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(200, 22);
            this.txtTotalAmount.TabIndex = 3;
            // 
            // txtDeliveryAddress
            // 
            this.txtDeliveryAddress.Location = new System.Drawing.Point(380, 60);
            this.txtDeliveryAddress.Name = "txtDeliveryAddress";
            this.txtDeliveryAddress.ReadOnly = true;
            this.txtDeliveryAddress.Size = new System.Drawing.Size(200, 22);
            this.txtDeliveryAddress.TabIndex = 4;
            // 
            // txtEstimatedTime
            // 
            this.txtEstimatedTime.Location = new System.Drawing.Point(380, 100);
            this.txtEstimatedTime.Name = "txtEstimatedTime";
            this.txtEstimatedTime.ReadOnly = true;
            this.txtEstimatedTime.Size = new System.Drawing.Size(200, 22);
            this.txtEstimatedTime.TabIndex = 5;
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.AutoGenerateColumns = false;
            this.dgvOrderItems.ColumnHeadersHeight = 29;
            this.dgvOrderItems.DataSource = this.winDBDataSet2BindingSource;
            this.dgvOrderItems.Location = new System.Drawing.Point(20, 150);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.Size = new System.Drawing.Size(560, 200);
            this.dgvOrderItems.TabIndex = 6;
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
            this.lblStatus.Location = new System.Drawing.Point(20, 100);
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
            // lblDeliveryAddress
            // 
            this.lblDeliveryAddress.Location = new System.Drawing.Point(300, 60);
            this.lblDeliveryAddress.Name = "lblDeliveryAddress";
            this.lblDeliveryAddress.Size = new System.Drawing.Size(100, 23);
            this.lblDeliveryAddress.TabIndex = 11;
            this.lblDeliveryAddress.Text = "Address:";
            // 
            // lblEstimatedTime
            // 
            this.lblEstimatedTime.Location = new System.Drawing.Point(300, 100);
            this.lblEstimatedTime.Name = "lblEstimatedTime";
            this.lblEstimatedTime.Size = new System.Drawing.Size(100, 23);
            this.lblEstimatedTime.TabIndex = 12;
            this.lblEstimatedTime.Text = "ETA:";
            // 
            // winDBDataSet2
            // 
            this.winDBDataSet2.DataSetName = "WinDBDataSet2";
            this.winDBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // winDBDataSet2BindingSource
            // 
            this.winDBDataSet2BindingSource.DataSource = this.winDBDataSet2;
            this.winDBDataSet2BindingSource.Position = 0;
            // 
            // OrderDetailsViewForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 380);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtDeliveryAddress);
            this.Controls.Add(this.txtEstimatedTime);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblDeliveryAddress);
            this.Controls.Add(this.lblEstimatedTime);
            this.Name = "OrderDetailsViewForm";
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.OrderDetailsViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winDBDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winDBDataSet2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.BindingSource winDBDataSet2BindingSource;
        private WinDBDataSet2 winDBDataSet2;
    }
}
