﻿namespace Invictus
{
    partial class AbtractForm
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
            this.TablesNameCbx = new System.Windows.Forms.ComboBox();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TablesNameCbx
            // 
            this.TablesNameCbx.FormattingEnabled = true;
            this.TablesNameCbx.Location = new System.Drawing.Point(40, 29);
            this.TablesNameCbx.Name = "TablesNameCbx";
            this.TablesNameCbx.Size = new System.Drawing.Size(304, 21);
            this.TablesNameCbx.TabIndex = 0;
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(40, 97);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(476, 475);
            this.DataGridView.TabIndex = 1;
            // 
            // AbtractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 623);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.TablesNameCbx);
            this.Name = "AbtractForm";
            this.Text = "AbtractForm";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox TablesNameCbx;
        private System.Windows.Forms.DataGridView DataGridView;
    }
}