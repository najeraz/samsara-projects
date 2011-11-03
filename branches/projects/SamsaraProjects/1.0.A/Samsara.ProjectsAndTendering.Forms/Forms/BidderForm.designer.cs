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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Samsara.ProjectsAndTendering.Core.Parameters.BidderTypeParameters bidderTypeParameters2 = new Samsara.ProjectsAndTendering.Core.Parameters.BidderTypeParameters();
            Samsara.ProjectsAndTendering.Core.Parameters.BidderTypeParameters bidderTypeParameters1 = new Samsara.ProjectsAndTendering.Core.Parameters.BidderTypeParameters();
            this.txtSchName = new System.Windows.Forms.TextBox();
            this.lblSchType = new System.Windows.Forms.Label();
            this.lblSchName = new System.Windows.Forms.Label();
            this.txtDetName = new System.Windows.Forms.TextBox();
            this.lblDetType = new System.Windows.Forms.Label();
            this.lblDetName = new System.Windows.Forms.Label();
            this.btccDetBidderType = new Samsara.ProjectsAndTendering.Controls.Controls.BidderTypeChooserControl();
            this.btccSchBidderType = new Samsara.ProjectsAndTendering.Controls.Controls.BidderTypeChooserControl();
            this.pnlDetCtgButtons.SuspendLayout();
            this.gbxSearchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetCtgButtons
            // 
            this.pnlDetCtgButtons.Location = new System.Drawing.Point(3, 254);
            this.pnlDetCtgButtons.Size = new System.Drawing.Size(502, 25);
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Controls.Add(this.btccSchBidderType);
            this.gbxSearchParameters.Controls.Add(this.txtSchName);
            this.gbxSearchParameters.Controls.Add(this.lblSchType);
            this.gbxSearchParameters.Controls.Add(this.lblSchName);
            this.gbxSearchParameters.Size = new System.Drawing.Size(502, 76);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.btccDetBidderType);
            this.gbxDetDetail.Controls.Add(this.txtDetName);
            this.gbxDetDetail.Controls.Add(this.lblDetType);
            this.gbxDetDetail.Controls.Add(this.lblDetName);
            this.gbxDetDetail.Size = new System.Drawing.Size(502, 251);
            // 
            // btnSchClose
            // 
            this.btnSchClose.Location = new System.Drawing.Point(138, 0);
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
            this.btnSchAccept.Location = new System.Drawing.Point(47, 0);
            // 
            // btnSchClear
            // 
            this.btnSchClear.Location = new System.Drawing.Point(320, 0);
            // 
            // btnSchSearch
            // 
            this.btnSchSearch.Location = new System.Drawing.Point(411, 0);
            // 
            // btnSchDelete
            // 
            this.btnSchDelete.Location = new System.Drawing.Point(229, 0);
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
            this.grdSchSearch.Location = new System.Drawing.Point(3, 104);
            this.grdSchSearch.Size = new System.Drawing.Size(502, 150);
            // 
            // btnDetCancel
            // 
            this.btnDetCancel.Location = new System.Drawing.Point(411, 0);
            // 
            // btnDetSave
            // 
            this.btnDetSave.Location = new System.Drawing.Point(320, 0);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(516, 308);
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
            // btccDetBidderType
            // 
            this.btccDetBidderType.CustomParent = null;
            this.btccDetBidderType.DisplayMember = "Name";
            this.btccDetBidderType.Location = new System.Drawing.Point(57, 45);
            this.btccDetBidderType.Name = "btccDetBidderType";
            bidderTypeParameters2.Name = null;
            this.btccDetBidderType.Parameters = bidderTypeParameters2;
            this.btccDetBidderType.Size = new System.Drawing.Size(226, 22);
            this.btccDetBidderType.TabIndex = 23;
            this.btccDetBidderType.Value = null;
            this.btccDetBidderType.ValueMember = "BidderTypeId";
            // 
            // btccSchBidderType
            // 
            this.btccSchBidderType.CustomParent = null;
            this.btccSchBidderType.DisplayMember = "Name";
            this.btccSchBidderType.Location = new System.Drawing.Point(60, 45);
            this.btccSchBidderType.Name = "btccSchBidderType";
            bidderTypeParameters1.Name = null;
            this.btccSchBidderType.Parameters = bidderTypeParameters1;
            this.btccSchBidderType.Size = new System.Drawing.Size(226, 22);
            this.btccSchBidderType.TabIndex = 24;
            this.btccSchBidderType.Value = null;
            this.btccSchBidderType.ValueMember = "BidderTypeId";
            // 
            // BidderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 308);
            this.Name = "BidderForm";
            this.Text = "Catálogo de Licitantes";
            this.pnlDetCtgButtons.ResumeLayout(false);
            this.gbxSearchParameters.ResumeLayout(false);
            this.gbxSearchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSchType;
        private System.Windows.Forms.Label lblSchName;
        private System.Windows.Forms.Label lblDetType;
        private System.Windows.Forms.Label lblDetName;
        internal System.Windows.Forms.TextBox txtSchName;
        internal System.Windows.Forms.TextBox txtDetName;
        internal Controls.Controls.BidderTypeChooserControl btccDetBidderType;
        internal Controls.Controls.BidderTypeChooserControl btccSchBidderType;
    }
}