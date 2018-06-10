namespace Invictus.MemberShip
{
    partial class ManageRoleForm
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
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableNamelb
            // 
            this.tableNamelb.Size = new System.Drawing.Size(180, 32);
            this.tableNamelb.Text = "InvictusRoles";
            // 
            // ManageRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 777);
            this.Name = "ManageRoleForm";
            this.Text = "ManageRoleForm";
            this.Load += new System.EventHandler(this.ManageRoleForm_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}