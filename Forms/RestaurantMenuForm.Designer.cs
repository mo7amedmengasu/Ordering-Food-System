namespace Db_Project.Forms
{
    partial class RestaurantMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // flowLayoutPanel1
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(660, 300);
            this.flowLayoutPanel1.TabIndex = 0;

            // txtName
            this.txtName.Location = new System.Drawing.Point(12, 330);
            this.txtName.Name = "txtName";
            this.txtName.Text = "Name";
            this.txtName.GotFocus += (sender, e) =>
            {
                if (this.txtName.Text == "Name") this.txtName.Text = "";
            };
            this.txtName.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(this.txtName.Text)) this.txtName.Text = "Name";
            };

            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 1;

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(12, 360);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Text = "Description";
            this.txtDescription.GotFocus += (sender, e) =>
            {
                if (this.txtDescription.Text == "Description") this.txtDescription.Text = "";
            };
            this.txtDescription.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(this.txtDescription.Text)) this.txtDescription.Text = "Description";
            };
            this.txtDescription.Size = new System.Drawing.Size(200, 23);
            this.txtDescription.TabIndex = 2;

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(12, 390);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Text = "Price";
            this.txtPrice.GotFocus += (sender, e) =>
            {
                if (this.txtPrice.Text == "Price") this.txtPrice.Text = "";
            };
            this.txtPrice.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(this.txtPrice.Text)) this.txtPrice.Text = "Price";
            };
            this.txtPrice.Size = new System.Drawing.Size(200, 23);
            this.txtPrice.TabIndex = 3;

            // chkAvailable
            this.chkAvailable.AutoSize = true;
            this.chkAvailable.Location = new System.Drawing.Point(12, 420);
            this.chkAvailable.Name = "chkAvailable";
            this.chkAvailable.Size = new System.Drawing.Size(75, 19);
            this.chkAvailable.TabIndex = 4;
            this.chkAvailable.Text = "Available";
            this.chkAvailable.UseVisualStyleBackColor = true;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(240, 330);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(240, 370);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(340, 330);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnToggle
            this.btnToggle.Location = new System.Drawing.Point(340, 370);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(90, 30);
            this.btnToggle.TabIndex = 8;
            this.btnToggle.Text = "Toggle";
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(440, 330);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // RestaurantMenuForm
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.chkAvailable);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.btnRefresh);
            this.Name = "RestaurantMenuForm";
            this.Text = "Restaurant Menu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
