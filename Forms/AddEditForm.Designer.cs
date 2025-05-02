namespace Db_Project.Forms
{
    partial class AddEditForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.IdArea = new System.Windows.Forms.TextBox();
            this.namearea = new System.Windows.Forms.TextBox();
            this.pricearea = new System.Windows.Forms.TextBox();
            this.restidarea = new System.Windows.Forms.TextBox();
            this.descriptionarea = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.availabilitybox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(156, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item Availability:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(156, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Item Price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(156, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Item Description:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(156, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Restaurant ID:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(156, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Item ID:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(776, 47);
            this.label7.TabIndex = 6;
            this.label7.Text = "Update Menu Item";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // IdArea
            // 
            this.IdArea.Location = new System.Drawing.Point(382, 93);
            this.IdArea.Name = "IdArea";
            this.IdArea.Size = new System.Drawing.Size(216, 22);
            this.IdArea.TabIndex = 7;
            // 
            // namearea
            // 
            this.namearea.Location = new System.Drawing.Point(382, 134);
            this.namearea.Name = "namearea";
            this.namearea.Size = new System.Drawing.Size(216, 22);
            this.namearea.TabIndex = 9;
            // 
            // pricearea
            // 
            this.pricearea.Location = new System.Drawing.Point(382, 212);
            this.pricearea.Name = "pricearea";
            this.pricearea.Size = new System.Drawing.Size(216, 22);
            this.pricearea.TabIndex = 10;
            // 
            // restidarea
            // 
            this.restidarea.Location = new System.Drawing.Point(382, 296);
            this.restidarea.Name = "restidarea";
            this.restidarea.Size = new System.Drawing.Size(216, 22);
            this.restidarea.TabIndex = 11;
            // 
            // descriptionarea
            // 
            this.descriptionarea.Location = new System.Drawing.Point(382, 257);
            this.descriptionarea.Name = "descriptionarea";
            this.descriptionarea.Size = new System.Drawing.Size(216, 22);
            this.descriptionarea.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(624, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 43);
            this.button1.TabIndex = 13;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // availabilitybox
            // 
            this.availabilitybox.FormattingEnabled = true;
            this.availabilitybox.Items.AddRange(new object[] {
            "Available",
            "Not Available"});
            this.availabilitybox.Location = new System.Drawing.Point(382, 176);
            this.availabilitybox.Name = "availabilitybox";
            this.availabilitybox.Size = new System.Drawing.Size(216, 24);
            this.availabilitybox.TabIndex = 14;
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.availabilitybox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.descriptionarea);
            this.Controls.Add(this.restidarea);
            this.Controls.Add(this.pricearea);
            this.Controls.Add(this.namearea);
            this.Controls.Add(this.IdArea);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditForm";
            this.Text = "AddEditForm";
            this.Load += new System.EventHandler(this.AddEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox IdArea;
        private System.Windows.Forms.TextBox namearea;
        private System.Windows.Forms.TextBox pricearea;
        private System.Windows.Forms.TextBox restidarea;
        private System.Windows.Forms.TextBox descriptionarea;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox availabilitybox;
    }
}