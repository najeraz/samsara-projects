namespace Samsara.Operation.Forms.Forms
{
    partial class CurrencyForm
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
            this.lblDetCode = new System.Windows.Forms.Label();
            this.txtDetCode = new System.Windows.Forms.TextBox();
            this.txtSchCode = new System.Windows.Forms.TextBox();
            this.lblSchCode = new System.Windows.Forms.Label();
            this.uchkDetIsDefault = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.gbxSearchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uchkDetIsDefault)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetCtgButtons
            // 
            this.pnlDetCtgButtons.Location = new System.Drawing.Point(3, 259);
            this.pnlDetCtgButtons.Size = new System.Drawing.Size(505, 25);
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Controls.Add(this.txtSchCode);
            this.gbxSearchParameters.Controls.Add(this.lblSchCode);
            this.gbxSearchParameters.Controls.Add(this.txtSchName);
            this.gbxSearchParameters.Controls.Add(this.lblSchName);
            this.gbxSearchParameters.Size = new System.Drawing.Size(505, 75);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.uchkDetIsDefault);
            this.gbxDetDetail.Controls.Add(this.txtDetDescription);
            this.gbxDetDetail.Controls.Add(this.lblDetFullName);
            this.gbxDetDetail.Controls.Add(this.txtDetCode);
            this.gbxDetDetail.Controls.Add(this.lblDetCode);
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
            this.txtDetName.Size = new System.Drawing.Size(295, 20);
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
            this.lblDetFullName.Location = new System.Drawing.Point(7, 71);
            this.lblDetFullName.Name = "lblDetFullName";
            this.lblDetFullName.Size = new System.Drawing.Size(66, 13);
            this.lblDetFullName.TabIndex = 23;
            this.lblDetFullName.Text = "Descripción:";
            // 
            // txtDetDescription
            // 
            this.txtDetDescription.Location = new System.Drawing.Point(79, 71);
            this.txtDetDescription.Multiline = true;
            this.txtDetDescription.Name = "txtDetDescription";
            this.txtDetDescription.Size = new System.Drawing.Size(295, 56);
            this.txtDetDescription.TabIndex = 26;
            // 
            // lblDetCode
            // 
            this.lblDetCode.AutoSize = true;
            this.lblDetCode.Location = new System.Drawing.Point(7, 48);
            this.lblDetCode.Name = "lblDetCode";
            this.lblDetCode.Size = new System.Drawing.Size(43, 13);
            this.lblDetCode.TabIndex = 23;
            this.lblDetCode.Text = "Código:";
            // 
            // txtDetCode
            // 
            this.txtDetCode.Location = new System.Drawing.Point(79, 45);
            this.txtDetCode.Name = "txtDetCode";
            this.txtDetCode.Size = new System.Drawing.Size(295, 20);
            this.txtDetCode.TabIndex = 24;
            // 
            // txtSchCode
            // 
            this.txtSchCode.Location = new System.Drawing.Point(57, 45);
            this.txtSchCode.Name = "txtSchCode";
            this.txtSchCode.Size = new System.Drawing.Size(226, 20);
            this.txtSchCode.TabIndex = 27;
            // 
            // lblSchCode
            // 
            this.lblSchCode.AutoSize = true;
            this.lblSchCode.Location = new System.Drawing.Point(4, 48);
            this.lblSchCode.Name = "lblSchCode";
            this.lblSchCode.Size = new System.Drawing.Size(43, 13);
            this.lblSchCode.TabIndex = 26;
            this.lblSchCode.Text = "Código:";
            // 
            // uchkDetIsDefault
            // 
            this.uchkDetIsDefault.AutoSize = true;
            this.uchkDetIsDefault.Location = new System.Drawing.Point(388, 19);
            this.uchkDetIsDefault.Name = "uchkDetIsDefault";
            this.uchkDetIsDefault.Size = new System.Drawing.Size(99, 17);
            this.uchkDetIsDefault.TabIndex = 27;
            this.uchkDetIsDefault.Text = "Moneda default";
            // 
            // CurrencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 313);
            this.Name = "CurrencyForm";
            this.Text = "Catálogo de Monedas";
            this.gbxSearchParameters.ResumeLayout(false);
            this.gbxSearchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uchkDetIsDefault)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDetName;
        private System.Windows.Forms.Label lblSchName;
        public System.Windows.Forms.TextBox txtDetName;
        private System.Windows.Forms.Label lblDetFullName;
        internal System.Windows.Forms.TextBox txtSchName;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetDescription;
        public System.Windows.Forms.TextBox txtSchCode;
        private System.Windows.Forms.Label lblSchCode;
        public System.Windows.Forms.TextBox txtDetCode;
        private System.Windows.Forms.Label lblDetCode;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor uchkDetIsDefault;
    }
}