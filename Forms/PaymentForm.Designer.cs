namespace Db_Project.Forms
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblPaymentStatusLabel;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox comboPaymentMethod;
        private System.Windows.Forms.Button btnPayNow;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblPaymentStatusLabel = new System.Windows.Forms.Label();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.comboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.btnPayNow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPaymentStatusLabel
            // 
            this.lblPaymentStatusLabel.AutoSize = true;
            this.lblPaymentStatusLabel.Location = new System.Drawing.Point(30, 30);
            this.lblPaymentStatusLabel.Name = "lblPaymentStatusLabel";
            this.lblPaymentStatusLabel.Size = new System.Drawing.Size(47, 16);
            this.lblPaymentStatusLabel.TabIndex = 0;
            this.lblPaymentStatusLabel.Text = "Status:";
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Location = new System.Drawing.Point(100, 30);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(44, 16);
            this.lblPaymentStatus.TabIndex = 1;
            this.lblPaymentStatus.Text = "label1";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(30, 70);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(200, 22);
            this.txtAmount.TabIndex = 2;
            // 
            // comboPaymentMethod
            // 
            this.comboPaymentMethod.FormattingEnabled = true;
            this.comboPaymentMethod.Items.AddRange(new object[] {
            "Credit Card",
            "Debit Card",
            "Cash",
            "PayPal"});
            this.comboPaymentMethod.Location = new System.Drawing.Point(30, 110);
            this.comboPaymentMethod.Name = "comboPaymentMethod";
            this.comboPaymentMethod.Size = new System.Drawing.Size(200, 24);
            this.comboPaymentMethod.TabIndex = 3;
            // 
            // btnPayNow
            // 
            this.btnPayNow.Location = new System.Drawing.Point(30, 150);
            this.btnPayNow.Name = "btnPayNow";
            this.btnPayNow.Size = new System.Drawing.Size(200, 30);
            this.btnPayNow.TabIndex = 4;
            this.btnPayNow.Text = "Pay Now";
            this.btnPayNow.UseVisualStyleBackColor = true;
            this.btnPayNow.Click += new System.EventHandler(this.btnPayNow_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.Add(this.lblPaymentStatusLabel);
            this.Controls.Add(this.lblPaymentStatus);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.comboPaymentMethod);
            this.Controls.Add(this.btnPayNow);
            this.Name = "PaymentForm";
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}