namespace Db_Project.Forms
{
    partial class LoginForm
    {

        private System.ComponentModel.IContainer components = null;
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnGoToSignup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(45, 43); // Adjust Location as needed
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 16); // Adjust Size/Font if needed
            this.lblEmail.TabIndex = 0; // Controls Tab Order
            this.lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(140, 40); // Adjust Location
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(230, 22); // Adjust Size
            this.txtEmail.TabIndex = 1; // Controls Tab Order
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(140, 75); // Adjust Location
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(230, 22); // Adjust Size
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true; // Make it a password box
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(45, 78); // Adjust Location
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 16);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            //
            // btnLogin
            //
            this.btnLogin.Location = new System.Drawing.Point(140, 120); // Adjust Location
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 35); // Adjust Size
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click); // Connects button to event handler
            //
            // btnGoToSignup
            //
            this.btnGoToSignup.Location = new System.Drawing.Point(250, 120); // Adjust Location
            this.btnGoToSignup.Name = "btnGoToSignup";
            this.btnGoToSignup.Size = new System.Drawing.Size(120, 35); // Adjust Size
            this.btnGoToSignup.TabIndex = 5;
            this.btnGoToSignup.Text = "Go to Sign Up";
            this.btnGoToSignup.UseVisualStyleBackColor = true;
            this.btnGoToSignup.Click += new System.EventHandler(this.btnGoToSignup_Click); // Connects button to event handler
            //
            // LoginForm
            //
            this.AcceptButton = this.btnLogin; // Allows pressing Enter to trigger Login
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 193); // Adjust ClientSize to fit controls
            this.Controls.Add(this.btnGoToSignup);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // Prevents resizing
            this.MaximizeBox = false;
            this.Name = "LoginForm"; // Form Name
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Center on screen
            this.Text = "Login"; // Window Title Text
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGoToSignup;
    }
}