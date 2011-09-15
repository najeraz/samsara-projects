namespace Samsara.CustomerContext.Forms.Forms
{
    partial class OperativeSystemForm
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.txtDetName = new System.Windows.Forms.TextBox();
            this.lblDetName = new System.Windows.Forms.Label();
            this.txtSchName = new System.Windows.Forms.TextBox();
            this.lblSchName = new System.Windows.Forms.Label();
            this.lblDetFullName = new System.Windows.Forms.Label();
            this.txtDetDescription = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uceDetOperativeSystemType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblDetOperativeSystemType = new System.Windows.Forms.Label();
            this.uceSchOperativeSystemType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lclSchOperativeSystemType = new System.Windows.Forms.Label();
            this.pnlDetCtgButtons.SuspendLayout();
            this.gbxSearchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceDetOperativeSystemType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSchOperativeSystemType)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetCtgButtons
            // 
            this.pnlDetCtgButtons.Location = new System.Drawing.Point(3, 259);
            this.pnlDetCtgButtons.Size = new System.Drawing.Size(505, 25);
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Controls.Add(this.uceSchOperativeSystemType);
            this.gbxSearchParameters.Controls.Add(this.lclSchOperativeSystemType);
            this.gbxSearchParameters.Controls.Add(this.txtSchName);
            this.gbxSearchParameters.Controls.Add(this.lblSchName);
            this.gbxSearchParameters.Size = new System.Drawing.Size(505, 78);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.uceDetOperativeSystemType);
            this.gbxDetDetail.Controls.Add(this.lblDetOperativeSystemType);
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
            // grdSchSearch
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdSchSearch.DisplayLayout.Appearance = appearance1;
            this.grdSchSearch.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdSchSearch.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdSchSearch.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdSchSearch.DisplayLayout.MaxColScrollRegions = 1;
            this.grdSchSearch.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdSchSearch.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Highlight;
            appearance3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdSchSearch.DisplayLayout.Override.ActiveRowAppearance = appearance3;
            this.grdSchSearch.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdSchSearch.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdSchSearch.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            this.grdSchSearch.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdSchSearch.DisplayLayout.Override.CellAppearance = appearance5;
            this.grdSchSearch.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdSchSearch.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grdSchSearch.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.grdSchSearch.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grdSchSearch.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdSchSearch.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            this.grdSchSearch.DisplayLayout.Override.RowAppearance = appearance8;
            this.grdSchSearch.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdSchSearch.DisplayLayout.Override.TemplateAddRowAppearance = appearance9;
            this.grdSchSearch.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdSchSearch.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdSchSearch.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdSchSearch.Location = new System.Drawing.Point(3, 106);
            this.grdSchSearch.Size = new System.Drawing.Size(505, 153);
            // 
            // btnDetCancel
            // 
            this.btnDetCancel.Location = new System.Drawing.Point(414, 0);
            // 
            // btnDetSave
            // 
            this.btnDetSave.Location = new System.Drawing.Point(323, 0);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(519, 313);
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
            // uceDetOperativeSystemType
            // 
            this.uceDetOperativeSystemType.Location = new System.Drawing.Point(79, 110);
            this.uceDetOperativeSystemType.Name = "uceDetOperativeSystemType";
            this.uceDetOperativeSystemType.Size = new System.Drawing.Size(226, 21);
            this.uceDetOperativeSystemType.TabIndex = 28;
            // 
            // lblDetOperativeSystemType
            // 
            this.lblDetOperativeSystemType.AutoSize = true;
            this.lblDetOperativeSystemType.Location = new System.Drawing.Point(7, 114);
            this.lblDetOperativeSystemType.Name = "lblDetOperativeSystemType";
            this.lblDetOperativeSystemType.Size = new System.Drawing.Size(31, 13);
            this.lblDetOperativeSystemType.TabIndex = 27;
            this.lblDetOperativeSystemType.Text = "Tipo:";
            // 
            // uceSchOperativeSystemType
            // 
            this.uceSchOperativeSystemType.Location = new System.Drawing.Point(57, 45);
            this.uceSchOperativeSystemType.Name = "uceSchOperativeSystemType";
            this.uceSchOperativeSystemType.Size = new System.Drawing.Size(226, 21);
            this.uceSchOperativeSystemType.TabIndex = 30;
            // 
            // lclSchOperativeSystemType
            // 
            this.lclSchOperativeSystemType.AutoSize = true;
            this.lclSchOperativeSystemType.Location = new System.Drawing.Point(4, 49);
            this.lclSchOperativeSystemType.Name = "lclSchOperativeSystemType";
            this.lclSchOperativeSystemType.Size = new System.Drawing.Size(31, 13);
            this.lclSchOperativeSystemType.TabIndex = 29;
            this.lclSchOperativeSystemType.Text = "Tipo:";
            // 
            // OperativeSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 313);
            this.Name = "OperativeSystemForm";
            this.Text = "Catálogo de Sistemas Operativos";
            this.pnlDetCtgButtons.ResumeLayout(false);
            this.gbxSearchParameters.ResumeLayout(false);
            this.gbxSearchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceDetOperativeSystemType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSchOperativeSystemType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDetName;
        private System.Windows.Forms.Label lblSchName;
        public System.Windows.Forms.TextBox txtDetName;
        private System.Windows.Forms.Label lblDetFullName;
        internal System.Windows.Forms.TextBox txtSchName;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetDescription;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor uceDetOperativeSystemType;
        private System.Windows.Forms.Label lblDetOperativeSystemType;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor uceSchOperativeSystemType;
        private System.Windows.Forms.Label lclSchOperativeSystemType;
    }
}