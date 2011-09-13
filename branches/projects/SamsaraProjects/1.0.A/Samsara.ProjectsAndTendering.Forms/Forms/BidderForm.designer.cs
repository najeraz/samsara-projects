namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    partial class BidderForm
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
            this.lblSchType = new System.Windows.Forms.Label();
            this.lblSchName = new System.Windows.Forms.Label();
            this.txtDetName = new System.Windows.Forms.TextBox();
            this.lblDetType = new System.Windows.Forms.Label();
            this.lblDetName = new System.Windows.Forms.Label();
            this.uceDetType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceSchType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.gbxSearchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceDetType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSchType)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetCtgButtons
            // 
            this.pnlDetCtgButtons.Location = new System.Drawing.Point(3, 254);
            this.pnlDetCtgButtons.Size = new System.Drawing.Size(502, 25);
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Controls.Add(this.uceSchType);
            this.gbxSearchParameters.Controls.Add(this.txtSchName);
            this.gbxSearchParameters.Controls.Add(this.lblSchType);
            this.gbxSearchParameters.Controls.Add(this.lblSchName);
            this.gbxSearchParameters.Size = new System.Drawing.Size(502, 76);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.uceDetType);
            this.gbxDetDetail.Controls.Add(this.txtDetName);
            this.gbxDetDetail.Controls.Add(this.lblDetType);
            this.gbxDetDetail.Controls.Add(this.lblDetName);
            this.gbxDetDetail.Size = new System.Drawing.Size(502, 251);
            // 
            // btnSchClose
            // 
            this.btnSchClose.Location = new System.Drawing.Point(229, 0);
            // 
            // btnSchEdit
            // 
            this.btnSchEdit.Location = new System.Drawing.Point(320, 0);
            // 
            // btnSchCreate
            // 
            this.btnSchCreate.Location = new System.Drawing.Point(411, 0);
            // 
            // btnSchAccept
            // 
            this.btnSchAccept.Location = new System.Drawing.Point(138, 0);
            // 
            // btnSchClear
            // 
            this.btnSchClear.Location = new System.Drawing.Point(320, 0);
            // 
            // btnSchSearch
            // 
            this.btnSchSearch.Location = new System.Drawing.Point(411, 0);
            // 
            // txtSchName
            // 
            this.txtSchName.Location = new System.Drawing.Point(60, 19);
            this.txtSchName.Name = "txtSchName";
            this.txtSchName.Size = new System.Drawing.Size(226, 20);
            this.txtSchName.TabIndex = 20;
            // 
            // lblSchType
            // 
            this.lblSchType.AutoSize = true;
            this.lblSchType.Location = new System.Drawing.Point(7, 49);
            this.lblSchType.Name = "lblSchType";
            this.lblSchType.Size = new System.Drawing.Size(31, 13);
            this.lblSchType.TabIndex = 18;
            this.lblSchType.Text = "Tipo:";
            // 
            // lblSchName
            // 
            this.lblSchName.AutoSize = true;
            this.lblSchName.Location = new System.Drawing.Point(7, 22);
            this.lblSchName.Name = "lblSchName";
            this.lblSchName.Size = new System.Drawing.Size(47, 13);
            this.lblSchName.TabIndex = 19;
            this.lblSchName.Text = "Nombre:";
            // 
            // txtDetName
            // 
            this.txtDetName.Location = new System.Drawing.Point(57, 19);
            this.txtDetName.Name = "txtDetName";
            this.txtDetName.Size = new System.Drawing.Size(226, 20);
            this.txtDetName.TabIndex = 20;
            // 
            // lblDetType
            // 
            this.lblDetType.AutoSize = true;
            this.lblDetType.Location = new System.Drawing.Point(6, 49);
            this.lblDetType.Name = "lblDetType";
            this.lblDetType.Size = new System.Drawing.Size(31, 13);
            this.lblDetType.TabIndex = 18;
            this.lblDetType.Text = "Tipo:";
            // 
            // lblDetName
            // 
            this.lblDetName.AutoSize = true;
            this.lblDetName.Location = new System.Drawing.Point(4, 22);
            this.lblDetName.Name = "lblDetName";
            this.lblDetName.Size = new System.Drawing.Size(47, 13);
            this.lblDetName.TabIndex = 19;
            this.lblDetName.Text = "Nombre:";
            // 
            // uceDetType
            // 
            this.uceDetType.Location = new System.Drawing.Point(57, 45);
            this.uceDetType.Name = "uceDetType";
            this.uceDetType.Size = new System.Drawing.Size(226, 21);
            this.uceDetType.TabIndex = 22;
            // 
            // uceSchType
            // 
            this.uceSchType.Location = new System.Drawing.Point(60, 45);
            this.uceSchType.Name = "uceSchType";
            this.uceSchType.Size = new System.Drawing.Size(226, 21);
            this.uceSchType.TabIndex = 23;
            // 
            // BidderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 308);
            this.Name = "BidderForm";
            this.Text = "Catálogo de Licitantes";
            this.gbxSearchParameters.ResumeLayout(false);
            this.gbxSearchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceDetType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSchType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSchType;
        private System.Windows.Forms.Label lblSchName;
        private System.Windows.Forms.Label lblDetType;
        private System.Windows.Forms.Label lblDetName;
        internal System.Windows.Forms.TextBox txtSchName;
        internal System.Windows.Forms.TextBox txtDetName;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor uceSchType;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor uceDetType;
    }
}