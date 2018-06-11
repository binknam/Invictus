namespace Invictus.Forms
{
    partial class CategoryForm
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
            this.manageUserLink = new System.Windows.Forms.LinkLabel();
            this.userDetailLb = new System.Windows.Forms.LinkLabel();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.userDetailLb);
            this.groupBox.Controls.Add(this.manageUserLink);
            this.groupBox.Controls.SetChildIndex(this.tableNamelb, 0);
            this.groupBox.Controls.SetChildIndex(this.createBtn, 0);
            this.groupBox.Controls.SetChildIndex(this.deleteBtn, 0);
            this.groupBox.Controls.SetChildIndex(this.updateBtn, 0);
            this.groupBox.Controls.SetChildIndex(this.manageUserLink, 0);
            this.groupBox.Controls.SetChildIndex(this.userDetailLb, 0);
            // 
            // tableNamelb
            // 
            this.tableNamelb.Size = new System.Drawing.Size(146, 32);
            this.tableNamelb.Text = "Categories";
            // 
            // manageUserLink
            // 
            this.manageUserLink.AutoSize = true;
            this.manageUserLink.Location = new System.Drawing.Point(628, 27);
            this.manageUserLink.Name = "manageUserLink";
            this.manageUserLink.Size = new System.Drawing.Size(71, 13);
            this.manageUserLink.TabIndex = 6;
            this.manageUserLink.TabStop = true;
            this.manageUserLink.Text = "Manage User";
            this.manageUserLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.manageUserLink_LinkClicked);
            // 
            // userDetailLb
            // 
            this.userDetailLb.AutoSize = true;
            this.userDetailLb.Location = new System.Drawing.Point(28, 27);
            this.userDetailLb.Name = "userDetailLb";
            this.userDetailLb.Size = new System.Drawing.Size(59, 13);
            this.userDetailLb.TabIndex = 7;
            this.userDetailLb.TabStop = true;
            this.userDetailLb.Text = "User Detail";
            this.userDetailLb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.userDetailLb_LinkClicked);
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 777);
            this.Name = "CategoryForm";
            this.Text = "CategoryForm";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel manageUserLink;
        private System.Windows.Forms.LinkLabel userDetailLb;
    }
}