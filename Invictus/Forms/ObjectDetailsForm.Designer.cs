namespace Invictus.Forms
{
    partial class ObjectDetailsForm<E, I>
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
            this.createOrUpdateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entity Detail";
            // 
            // createOrUpdateBtn
            // 
            this.createOrUpdateBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createOrUpdateBtn.Location = new System.Drawing.Point(241, 688);
            this.createOrUpdateBtn.Name = "createOrUpdateBtn";
            this.createOrUpdateBtn.Size = new System.Drawing.Size(75, 32);
            this.createOrUpdateBtn.TabIndex = 1;
            this.createOrUpdateBtn.Text = "Create";
            this.createOrUpdateBtn.UseVisualStyleBackColor = true;
            this.createOrUpdateBtn.Click += new System.EventHandler(this.createOrUpdateBtn_Click);
            // 
            // ObjectDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 774);
            this.Controls.Add(this.createOrUpdateBtn);
            this.Controls.Add(this.label1);
            this.Name = "ObjectDetailsForm";
            this.Text = "ObjectDetailsForm";
            this.Load += new System.EventHandler(this.ObjectDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createOrUpdateBtn;
    }
}