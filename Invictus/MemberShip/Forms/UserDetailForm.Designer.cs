namespace Invictus.MemberShip.Forms
{
    partial class UserDetailForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resetPWLb = new System.Windows.Forms.LinkLabel();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.newPWTxt = new System.Windows.Forms.TextBox();
            this.confirmPWTxt = new System.Windows.Forms.TextBox();
            this.userNameTxt = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.canDeleteCkb = new System.Windows.Forms.CheckBox();
            this.canUpdateCkb = new System.Windows.Forms.CheckBox();
            this.canReadCkb = new System.Windows.Forms.CheckBox();
            this.canCreateCkb = new System.Windows.Forms.CheckBox();
            this.confirmPasswordLb = new System.Windows.Forms.Label();
            this.newPasswordLb = new System.Windows.Forms.Label();
            this.passwordLb = new System.Windows.Forms.Label();
            this.userNameLb = new System.Windows.Forms.Label();
            this.userDetailLb = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resetPWLb);
            this.groupBox1.Controls.Add(this.passwordTxt);
            this.groupBox1.Controls.Add(this.newPWTxt);
            this.groupBox1.Controls.Add(this.confirmPWTxt);
            this.groupBox1.Controls.Add(this.userNameTxt);
            this.groupBox1.Controls.Add(this.okBtn);
            this.groupBox1.Controls.Add(this.canDeleteCkb);
            this.groupBox1.Controls.Add(this.canUpdateCkb);
            this.groupBox1.Controls.Add(this.canReadCkb);
            this.groupBox1.Controls.Add(this.canCreateCkb);
            this.groupBox1.Controls.Add(this.confirmPasswordLb);
            this.groupBox1.Controls.Add(this.newPasswordLb);
            this.groupBox1.Controls.Add(this.passwordLb);
            this.groupBox1.Controls.Add(this.userNameLb);
            this.groupBox1.Controls.Add(this.userDetailLb);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 689);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // resetPWLb
            // 
            this.resetPWLb.AutoSize = true;
            this.resetPWLb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPWLb.Location = new System.Drawing.Point(341, 204);
            this.resetPWLb.Name = "resetPWLb";
            this.resetPWLb.Size = new System.Drawing.Size(53, 19);
            this.resetPWLb.TabIndex = 14;
            this.resetPWLb.TabStop = true;
            this.resetPWLb.Text = "Reset ";
            this.resetPWLb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.resetPWLb_LinkClicked);
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(208, 205);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.Size = new System.Drawing.Size(100, 20);
            this.passwordTxt.TabIndex = 13;
            // 
            // newPWTxt
            // 
            this.newPWTxt.Location = new System.Drawing.Point(208, 274);
            this.newPWTxt.Name = "newPWTxt";
            this.newPWTxt.PasswordChar = '*';
            this.newPWTxt.Size = new System.Drawing.Size(100, 20);
            this.newPWTxt.TabIndex = 12;
            // 
            // confirmPWTxt
            // 
            this.confirmPWTxt.Location = new System.Drawing.Point(208, 349);
            this.confirmPWTxt.Name = "confirmPWTxt";
            this.confirmPWTxt.PasswordChar = '*';
            this.confirmPWTxt.Size = new System.Drawing.Size(100, 20);
            this.confirmPWTxt.TabIndex = 11;
            // 
            // userNameTxt
            // 
            this.userNameTxt.Location = new System.Drawing.Point(208, 133);
            this.userNameTxt.Name = "userNameTxt";
            this.userNameTxt.Size = new System.Drawing.Size(100, 20);
            this.userNameTxt.TabIndex = 10;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(208, 595);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 9;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // canDeleteCkb
            // 
            this.canDeleteCkb.AutoSize = true;
            this.canDeleteCkb.Location = new System.Drawing.Point(317, 512);
            this.canDeleteCkb.Name = "canDeleteCkb";
            this.canDeleteCkb.Size = new System.Drawing.Size(77, 17);
            this.canDeleteCkb.TabIndex = 8;
            this.canDeleteCkb.Text = "Can delete";
            this.canDeleteCkb.UseVisualStyleBackColor = true;
            // 
            // canUpdateCkb
            // 
            this.canUpdateCkb.AutoSize = true;
            this.canUpdateCkb.Location = new System.Drawing.Point(69, 512);
            this.canUpdateCkb.Name = "canUpdateCkb";
            this.canUpdateCkb.Size = new System.Drawing.Size(81, 17);
            this.canUpdateCkb.TabIndex = 7;
            this.canUpdateCkb.Text = "Can update";
            this.canUpdateCkb.UseVisualStyleBackColor = true;
            // 
            // canReadCkb
            // 
            this.canReadCkb.AutoSize = true;
            this.canReadCkb.Location = new System.Drawing.Point(317, 453);
            this.canReadCkb.Name = "canReadCkb";
            this.canReadCkb.Size = new System.Drawing.Size(69, 17);
            this.canReadCkb.TabIndex = 6;
            this.canReadCkb.Text = "Can read";
            this.canReadCkb.UseVisualStyleBackColor = true;
            // 
            // canCreateCkb
            // 
            this.canCreateCkb.AutoSize = true;
            this.canCreateCkb.Location = new System.Drawing.Point(69, 453);
            this.canCreateCkb.Name = "canCreateCkb";
            this.canCreateCkb.Size = new System.Drawing.Size(78, 17);
            this.canCreateCkb.TabIndex = 5;
            this.canCreateCkb.Text = "Can create";
            this.canCreateCkb.UseVisualStyleBackColor = true;
            // 
            // confirmPasswordLb
            // 
            this.confirmPasswordLb.AutoSize = true;
            this.confirmPasswordLb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordLb.Location = new System.Drawing.Point(43, 350);
            this.confirmPasswordLb.Name = "confirmPasswordLb";
            this.confirmPasswordLb.Size = new System.Drawing.Size(130, 19);
            this.confirmPasswordLb.TabIndex = 4;
            this.confirmPasswordLb.Text = "Confirm Password";
            // 
            // newPasswordLb
            // 
            this.newPasswordLb.AutoSize = true;
            this.newPasswordLb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordLb.Location = new System.Drawing.Point(43, 275);
            this.newPasswordLb.Name = "newPasswordLb";
            this.newPasswordLb.Size = new System.Drawing.Size(106, 19);
            this.newPasswordLb.TabIndex = 3;
            this.newPasswordLb.Text = "New Password";
            // 
            // passwordLb
            // 
            this.passwordLb.AutoSize = true;
            this.passwordLb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLb.Location = new System.Drawing.Point(43, 204);
            this.passwordLb.Name = "passwordLb";
            this.passwordLb.Size = new System.Drawing.Size(72, 19);
            this.passwordLb.TabIndex = 2;
            this.passwordLb.Text = "Password";
            // 
            // userNameLb
            // 
            this.userNameLb.AutoSize = true;
            this.userNameLb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLb.Location = new System.Drawing.Point(43, 134);
            this.userNameLb.Name = "userNameLb";
            this.userNameLb.Size = new System.Drawing.Size(81, 19);
            this.userNameLb.TabIndex = 1;
            this.userNameLb.Text = "User name";
            // 
            // userDetailLb
            // 
            this.userDetailLb.AutoSize = true;
            this.userDetailLb.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userDetailLb.Location = new System.Drawing.Point(167, 36);
            this.userDetailLb.Name = "userDetailLb";
            this.userDetailLb.Size = new System.Drawing.Size(152, 32);
            this.userDetailLb.TabIndex = 0;
            this.userDetailLb.Text = "User Detail";
            // 
            // UserDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 713);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserDetailForm";
            this.Text = "UserDetailForm";
            this.Load += new System.EventHandler(this.UserDetailForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label userDetailLb;
        private System.Windows.Forms.Label newPasswordLb;
        private System.Windows.Forms.Label passwordLb;
        private System.Windows.Forms.Label userNameLb;
        private System.Windows.Forms.CheckBox canDeleteCkb;
        private System.Windows.Forms.CheckBox canUpdateCkb;
        private System.Windows.Forms.CheckBox canReadCkb;
        private System.Windows.Forms.CheckBox canCreateCkb;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.TextBox newPWTxt;
        private System.Windows.Forms.TextBox confirmPWTxt;
        private System.Windows.Forms.TextBox userNameTxt;
        private System.Windows.Forms.Label confirmPasswordLb;
        private System.Windows.Forms.LinkLabel resetPWLb;
    }
}