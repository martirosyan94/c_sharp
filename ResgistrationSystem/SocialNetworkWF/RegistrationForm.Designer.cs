
namespace SocialNetworkWF
{
    partial class RegistrationForm
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
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxSurname = new System.Windows.Forms.TextBox();
            this.txtBoxAge = new System.Windows.Forms.TextBox();
            this.txtBoxEmal = new System.Windows.Forms.TextBox();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.cbBoxAccountType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(488, 172);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.RegisterClick);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(107, 46);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(100, 23);
            this.txtBoxName.TabIndex = 1;
            this.txtBoxName.Text = "Name";
            // 
            // txtBoxSurname
            // 
            this.txtBoxSurname.Location = new System.Drawing.Point(107, 95);
            this.txtBoxSurname.Name = "txtBoxSurname";
            this.txtBoxSurname.Size = new System.Drawing.Size(100, 23);
            this.txtBoxSurname.TabIndex = 2;
            this.txtBoxSurname.Text = "Surname";
            // 
            // txtBoxAge
            // 
            this.txtBoxAge.Location = new System.Drawing.Point(107, 151);
            this.txtBoxAge.Name = "txtBoxAge";
            this.txtBoxAge.Size = new System.Drawing.Size(100, 23);
            this.txtBoxAge.TabIndex = 3;
            this.txtBoxAge.Text = "Age";
            // 
            // txtBoxEmal
            // 
            this.txtBoxEmal.Location = new System.Drawing.Point(107, 200);
            this.txtBoxEmal.Name = "txtBoxEmal";
            this.txtBoxEmal.Size = new System.Drawing.Size(100, 23);
            this.txtBoxEmal.TabIndex = 4;
            this.txtBoxEmal.Text = "Email";
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(107, 255);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(100, 23);
            this.txtBoxPassword.TabIndex = 5;
            this.txtBoxPassword.Text = "Name";
            // 
            // cbBoxAccountType
            // 
            this.cbBoxAccountType.DisplayMember = "User";
            this.cbBoxAccountType.FormattingEnabled = true;
            this.cbBoxAccountType.Location = new System.Drawing.Point(107, 321);
            this.cbBoxAccountType.Name = "cbBoxAccountType";
            this.cbBoxAccountType.Size = new System.Drawing.Size(121, 23);
            this.cbBoxAccountType.TabIndex = 6;
            this.cbBoxAccountType.ValueMember = "User";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbBoxAccountType);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.txtBoxEmal);
            this.Controls.Add(this.txtBoxAge);
            this.Controls.Add(this.txtBoxSurname);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.btnRegister);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxSurname;
        private System.Windows.Forms.TextBox txtBoxAge;
        private System.Windows.Forms.TextBox txtBoxEmal;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.ComboBox cbBoxAccountType;
    }
}