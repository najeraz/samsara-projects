﻿namespace Samsara.Controls.Controls
{
    partial class SamsaraUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            this.samsaraUltraComboEditor1 = new Samsara.Controls.Controls.SamsaraUltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.samsaraUltraComboEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // samsaraUltraComboEditor1
            // 
            editorButton1.Text = "+";
            this.samsaraUltraComboEditor1.ButtonsLeft.Add(editorButton1);
            this.samsaraUltraComboEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.samsaraUltraComboEditor1.Location = new System.Drawing.Point(0, 0);
            this.samsaraUltraComboEditor1.Name = "samsaraUltraComboEditor1";
            this.samsaraUltraComboEditor1.Size = new System.Drawing.Size(227, 21);
            this.samsaraUltraComboEditor1.TabIndex = 0;
            this.samsaraUltraComboEditor1.Text = "samsaraUltraComboEditor1";
            // 
            // SamsaraUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.samsaraUltraComboEditor1);
            this.Name = "SamsaraUserControl";
            this.Size = new System.Drawing.Size(227, 22);
            ((System.ComponentModel.ISupportInitialize)(this.samsaraUltraComboEditor1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SamsaraUltraComboEditor samsaraUltraComboEditor1;
    }
}
