namespace Samsara.CustomerContext.Forms.Forms
{
    partial class DBMSForm
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
            this.txtDetName = new System.Windows.Forms.TextBox();
            this.lblDetName = new System.Windows.Forms.Label();
            this.txtSchName = new System.Windows.Forms.TextBox();
            this.lblSchName = new System.Windows.Forms.Label();
            this.lblDetFullName = new System.Windows.Forms.Label();
            this.txtDetDescription = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.gbxSearchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetCtgButtons
            // 
            this.pnlDetCtgButtons.Location = new System.Drawing.Point(3, 259);
            this.pnlDetCtgButtons.Size = new System.Drawing.Size(505, 25);
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Controls.Add(this.txtSchName);
            this.gbxSearchParameters.Controls.Add(this.lblSchName);
            this.gbxSearchParameters.Size = new System.Drawing.Size(505, 50);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.txtDetDescription);
            this.gbxDetDetail.Controls.Add(this.lblDetFullName);
            this.gbxDetDetail.Controls.Add(this.txtDetName);
            this.gbxDetDetail.Controls.Add(this.lblDetName);
            this.gbxDetDetail.Size = new System.Drawing.Size(505, 256);
            // 
            // btnSchClose
            // 
            this.btnSchClose.Location = new System.Drawing.Point(141, 0);
            // 
            // btnSchEdit
            // 
            this.btnSchEdit.Location = new System.Drawing.Point(323, 0);
            // 
            // btnSchCreate
            // 
            this.btnSchCreate.Location = new System.Drawing.Point(414, 0);
            // 
            // btnSchAccept
            // 
            this.btnSchAccept.Location = new System.Drawing.Point(50, 0);
            // 
            // btnSchClear
            // 
            this.btnSchClear.Location = new System.Drawing.Point(323, 0);
            // 
            // btnSchSearch
            // 
            this.btnSchSearch.Location = new System.Drawing.Point(414, 0);
            // 
            // btnSchDelete
            // 
            this.btnSchDelete.Location = new System.Drawing.Point(232, 0);
            // 
            // txtDetName
            // 
            this.txtDetName.Location = new System.Drawing.Point(79, 19);
            this.txtDetName.Name = "txtDetName";
            this.txtDetName.Size = new System.Drawing.Size(341, 20);
            this.txtDetName.TabIndex = 24;
            // 
            // lblDetName
            // 
            this.lblDetName.AutoSize = true;
            this.lblDetName.Location = new System.Drawing.Point(7, 22);
            this.lblDetName.Name = "lblDetName";
            this.lblDetName.Size = new System.Drawing.Size(47, 13);
            this.lblDetName.TabIndex = 23;
            this.lblDetName.Text = "Nombre:";
            // 
            // txtSchName
            // 
            this.txtSchName.Location = new System.Drawing.Point(57, 19);
            this.txtSchName.Name = "txtSchName";
            this.txtSchName.Size = new System.Drawing.Size(226, 20);
            this.txtSchName.TabIndex = 25;
            // 
            // lblSchName
            // 
            this.lblSchName.AutoSize = true;
            this.lblSchName.Location = new System.Drawing.Point(4, 22);
            this.lblSchName.Name = "lblSchName";
            this.lblSchName.Size = new System.Drawing.Size(47, 13);
            this.lblSchName.TabIndex = 24;
            this.lblSchName.Text = "Nombre:";
            // 
            // lblDetFullName
            // 
            this.lblDetFullName.AutoSize = true;
            this.lblDetFullName.Location = new System.Drawing.Point(7, 48);
            this.lblDetFullName.Name = "lblDetFullName";
            this.lblDetFullName.Size = new System.Drawing.Size(66, 13);
            this.lblDetFullName.TabIndex = 23;
            this.lblDetFullName.Text = "Descripción:";
            // 
            // txtDetDescription
            // 
            this.txtDetDescription.Location = new System.Drawing.Point(79, 48);
            this.txtDetDescription.Multiline = true;
            this.txtDetDescription.Name = "txtDetDescription";
            this.txtDetDescription.Size = new System.Drawing.Size(341, 56);
            this.txtDetDescription.TabIndex = 26;
            // 
            // DBMSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 313);
            this.Name = "DBMSForm";
            this.Text = "Catálogo de Competencia";
            this.gbxSearchParameters.ResumeLayout(false);
            this.gbxSearchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetDescription)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDetName;
        private System.Windows.Forms.Label lblSchName;
        public System.Windows.Forms.TextBox txtDetName;
        private System.Windows.Forms.Label lblDetFullName;
        internal System.Windows.Forms.TextBox txtSchName;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetDescription;
    }
}