namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    partial class EndUserForm
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
            this.lblSchDependency = new System.Windows.Forms.Label();
            this.lblSchName = new System.Windows.Forms.Label();
            this.txtDetName = new System.Windows.Forms.TextBox();
            this.lblDetDependency = new System.Windows.Forms.Label();
            this.lblDetName = new System.Windows.Forms.Label();
            this.uceDetDependency = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceSchDependency = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.gbxSearchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceDetDependency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSchDependency)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetCtgButtons
            // 
            this.pnlDetCtgButtons.Location = new System.Drawing.Point(3, 254);
            this.pnlDetCtgButtons.Size = new System.Drawing.Size(502, 25);
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Controls.Add(this.uceSchDependency);
            this.gbxSearchParameters.Controls.Add(this.txtSchName);
            this.gbxSearchParameters.Controls.Add(this.lblSchDependency);
            this.gbxSearchParameters.Controls.Add(this.lblSchName);
            this.gbxSearchParameters.Size = new System.Drawing.Size(502, 76);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.uceDetDependency);
            this.gbxDetDetail.Controls.Add(this.txtDetName);
            this.gbxDetDetail.Controls.Add(this.lblDetDependency);
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
            this.txtSchName.Location = new System.Drawing.Point(87, 23);
            this.txtSchName.Name = "txtSchName";
            this.txtSchName.Size = new System.Drawing.Size(226, 20);
            this.txtSchName.TabIndex = 20;
            // 
            // lblSchDependency
            // 
            this.lblSchDependency.AutoSize = true;
            this.lblSchDependency.Location = new System.Drawing.Point(7, 49);
            this.lblSchDependency.Name = "lblSchDependency";
            this.lblSchDependency.Size = new System.Drawing.Size(74, 13);
            this.lblSchDependency.TabIndex = 18;
            this.lblSchDependency.Text = "Dependencia:";
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
            this.txtDetName.Location = new System.Drawing.Point(86, 19);
            this.txtDetName.Name = "txtDetName";
            this.txtDetName.Size = new System.Drawing.Size(226, 20);
            this.txtDetName.TabIndex = 20;
            // 
            // lblDetDependency
            // 
            this.lblDetDependency.AutoSize = true;
            this.lblDetDependency.Location = new System.Drawing.Point(6, 49);
            this.lblDetDependency.Name = "lblDetDependency";
            this.lblDetDependency.Size = new System.Drawing.Size(74, 13);
            this.lblDetDependency.TabIndex = 18;
            this.lblDetDependency.Text = "Dependencia:";
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
            // uceDetDependency
            // 
            this.uceDetDependency.Location = new System.Drawing.Point(86, 45);
            this.uceDetDependency.Name = "uceDetDependency";
            this.uceDetDependency.Size = new System.Drawing.Size(226, 21);
            this.uceDetDependency.TabIndex = 22;
            // 
            // uceSchDependency
            // 
            this.uceSchDependency.Location = new System.Drawing.Point(87, 49);
            this.uceSchDependency.Name = "uceSchDependency";
            this.uceSchDependency.Size = new System.Drawing.Size(226, 21);
            this.uceSchDependency.TabIndex = 23;
            // 
            // EndUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 308);
            this.Name = "EndUserForm";
            this.Text = "Catálogo de Usuarios Finales";
            this.gbxSearchParameters.ResumeLayout(false);
            this.gbxSearchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceDetDependency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSchDependency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSchDependency;
        private System.Windows.Forms.Label lblSchName;
        private System.Windows.Forms.Label lblDetDependency;
        private System.Windows.Forms.Label lblDetName;
        internal System.Windows.Forms.TextBox txtSchName;
        internal System.Windows.Forms.TextBox txtDetName;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor uceSchDependency;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor uceDetDependency;
    }
}