namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    partial class DependencyForm
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
            this.txtSchName = new System.Windows.Forms.TextBox();
            this.lblSchName = new System.Windows.Forms.Label();
            this.txtDetName = new System.Windows.Forms.TextBox();
            this.lbDetName = new System.Windows.Forms.Label();
            this.uceSchBidder = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblSchBidder = new System.Windows.Forms.Label();
            this.uceDetBidder = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblDetBidder = new System.Windows.Forms.Label();
            this.gbxSearchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceSchBidder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceDetBidder)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetCtgButtons
            // 
            this.pnlDetCtgButtons.Location = new System.Drawing.Point(3, 263);
            this.pnlDetCtgButtons.Size = new System.Drawing.Size(478, 25);
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Controls.Add(this.uceSchBidder);
            this.gbxSearchParameters.Controls.Add(this.lblSchBidder);
            this.gbxSearchParameters.Controls.Add(this.txtSchName);
            this.gbxSearchParameters.Controls.Add(this.lblSchName);
            this.gbxSearchParameters.Size = new System.Drawing.Size(478, 84);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.uceDetBidder);
            this.gbxDetDetail.Controls.Add(this.lblDetBidder);
            this.gbxDetDetail.Controls.Add(this.txtDetName);
            this.gbxDetDetail.Controls.Add(this.lbDetName);
            this.gbxDetDetail.Size = new System.Drawing.Size(478, 260);
            // 
            // btnSchClose
            // 
            this.btnSchClose.Location = new System.Drawing.Point(205, 0);
            // 
            // btnSchEdit
            // 
            this.btnSchEdit.Location = new System.Drawing.Point(296, 0);
            // 
            // btnSchCreate
            // 
            this.btnSchCreate.Location = new System.Drawing.Point(387, 0);
            // 
            // btnSchAccept
            // 
            this.btnSchAccept.Location = new System.Drawing.Point(114, 0);
            // 
            // btnSchClear
            // 
            this.btnSchClear.Location = new System.Drawing.Point(296, 0);
            // 
            // btnSchSearch
            // 
            this.btnSchSearch.Location = new System.Drawing.Point(387, 0);
            // 
            // txtSchName
            // 
            this.txtSchName.Location = new System.Drawing.Point(60, 19);
            this.txtSchName.Name = "txtSchName";
            this.txtSchName.Size = new System.Drawing.Size(226, 20);
            this.txtSchName.TabIndex = 22;
            // 
            // lblSchName
            // 
            this.lblSchName.AutoSize = true;
            this.lblSchName.Location = new System.Drawing.Point(7, 22);
            this.lblSchName.Name = "lblSchName";
            this.lblSchName.Size = new System.Drawing.Size(47, 13);
            this.lblSchName.TabIndex = 21;
            this.lblSchName.Text = "Nombre:";
            // 
            // txtDetName
            // 
            this.txtDetName.Location = new System.Drawing.Point(60, 19);
            this.txtDetName.Name = "txtDetName";
            this.txtDetName.Size = new System.Drawing.Size(226, 20);
            this.txtDetName.TabIndex = 22;
            // 
            // lbDetName
            // 
            this.lbDetName.AutoSize = true;
            this.lbDetName.Location = new System.Drawing.Point(7, 22);
            this.lbDetName.Name = "lbDetName";
            this.lbDetName.Size = new System.Drawing.Size(47, 13);
            this.lbDetName.TabIndex = 21;
            this.lbDetName.Text = "Nombre:";
            // 
            // uceSchBidder
            // 
            this.uceSchBidder.Location = new System.Drawing.Point(60, 45);
            this.uceSchBidder.Name = "uceSchBidder";
            this.uceSchBidder.Size = new System.Drawing.Size(226, 21);
            this.uceSchBidder.TabIndex = 25;
            // 
            // lblSchBidder
            // 
            this.lblSchBidder.AutoSize = true;
            this.lblSchBidder.Location = new System.Drawing.Point(7, 49);
            this.lblSchBidder.Name = "lblSchBidder";
            this.lblSchBidder.Size = new System.Drawing.Size(31, 13);
            this.lblSchBidder.TabIndex = 24;
            this.lblSchBidder.Text = "Tipo:";
            // 
            // uceDetBidder
            // 
            this.uceDetBidder.Location = new System.Drawing.Point(60, 45);
            this.uceDetBidder.Name = "uceDetBidder";
            this.uceDetBidder.Size = new System.Drawing.Size(226, 21);
            this.uceDetBidder.TabIndex = 25;
            // 
            // lblDetBidder
            // 
            this.lblDetBidder.AutoSize = true;
            this.lblDetBidder.Location = new System.Drawing.Point(7, 49);
            this.lblDetBidder.Name = "lblDetBidder";
            this.lblDetBidder.Size = new System.Drawing.Size(31, 13);
            this.lblDetBidder.TabIndex = 24;
            this.lblDetBidder.Text = "Tipo:";
            // 
            // DependencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 317);
            this.Name = "DependencyForm";
            this.Text = "DependenciaForm";
            this.gbxSearchParameters.ResumeLayout(false);
            this.gbxSearchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceSchBidder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceDetBidder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSchName;
        private System.Windows.Forms.Label lbDetName;
        internal System.Windows.Forms.TextBox txtSchName;
        internal System.Windows.Forms.TextBox txtDetName;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor uceSchBidder;
        private System.Windows.Forms.Label lblSchBidder;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor uceDetBidder;
        private System.Windows.Forms.Label lblDetBidder;
    }
}