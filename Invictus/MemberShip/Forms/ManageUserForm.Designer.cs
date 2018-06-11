namespace Invictus.MemberShip
{
    partial class ManageUserForm
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
            this.manageRoleLink = new System.Windows.Forms.LinkLabel();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.manageRoleLink);
            this.groupBox.Controls.SetChildIndex(this.manageRoleLink, 0);
            this.groupBox.Controls.SetChildIndex(this.tableNamelb, 0);
            this.groupBox.Controls.SetChildIndex(this.createBtn, 0);
            this.groupBox.Controls.SetChildIndex(this.deleteBtn, 0);
            this.groupBox.Controls.SetChildIndex(this.updateBtn, 0);
            // 
            // tableNamelb
            // 
            this.tableNamelb.Size = new System.Drawing.Size(181, 32);
            this.tableNamelb.Text = "InvictusUsers";
            // 
            // manageRoleLink
            // 
            this.manageRoleLink.AutoSize = true;
            this.manageRoleLink.Location = new System.Drawing.Point(608, 40);
            this.manageRoleLink.Name = "manageRoleLink";
            this.manageRoleLink.Size = new System.Drawing.Size(71, 13);
            this.manageRoleLink.TabIndex = 6;
            this.manageRoleLink.TabStop = true;
            this.manageRoleLink.Text = "Manage Role";
            this.manageRoleLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.manageRoleLink_LinkClicked);
            // 
            // ManageUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 777);
            this.Name = "ManageUserForm";
            this.Text = "ManageUserForm";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel manageRoleLink;
    }
}