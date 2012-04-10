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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Samsara.ProjectsAndTendering.Core.Parameters.BidderParameters bidderParameters2 = new Samsara.ProjectsAndTendering.Core.Parameters.BidderParameters();
            Samsara.ProjectsAndTendering.Core.Parameters.BidderParameters bidderParameters1 = new Samsara.ProjectsAndTendering.Core.Parameters.BidderParameters();
            this.txtSchName = new System.Windows.Forms.TextBox();
            this.lblSchName = new System.Windows.Forms.Label();
            this.txtDetName = new System.Windows.Forms.TextBox();
            this.lbDetName = new System.Windows.Forms.Label();
            this.lblSchBidder = new System.Windows.Forms.Label();
            this.lblDetBidder = new System.Windows.Forms.Label();
            this.bccDetBidder = new Samsara.ProjectsAndTendering.Controls.Controls.Choosers.BidderChooserControl();
            this.bccSchBidder = new Samsara.ProjectsAndTendering.Controls.Controls.Choosers.BidderChooserControl();
            this.pnlDetCtgButtons.SuspendLayout();
            this.gbxSearchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetCtgButtons
            // 
            this.pnlDetCtgButtons.Location = new System.Drawing.Point(3, 263);
            this.pnlDetCtgButtons.Size = new System.Drawing.Size(478, 25);
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Controls.Add(this.bccSchBidder);
            this.gbxSearchParameters.Controls.Add(this.lblSchBidder);
            this.gbxSearchParameters.Controls.Add(this.txtSchName);
            this.gbxSearchParameters.Controls.Add(this.lblSchName);
            this.gbxSearchParameters.Size = new System.Drawing.Size(478, 84);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.bccDetBidder);
            this.gbxDetDetail.Controls.Add(this.lblDetBidder);
            this.gbxDetDetail.Controls.Add(this.txtDetName);
            this.gbxDetDetail.Controls.Add(this.lbDetName);
            this.gbxDetDetail.Size = new System.Drawing.Size(478, 260);
            // 
            // btnSchClose
            // 
            this.btnSchClose.Location = new System.Drawing.Point(114, 0);
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
            this.btnSchAccept.Location = new System.Drawing.Point(23, 0);
            // 
            // btnSchClear
            // 
            this.btnSchClear.Location = new System.Drawing.Point(296, 0);
            // 
            // btnSchSearch
            // 
            this.btnSchSearch.Location = new System.Drawing.Point(387, 0);
            // 
            // btnSchDelete
            // 
            this.btnSchDelete.Location = new System.Drawing.Point(205, 0);
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
            this.grdSchSearch.Location = new System.Drawing.Point(3, 112);
            this.grdSchSearch.Size = new System.Drawing.Size(478, 151);
            // 
            // btnDetCancel
            // 
            this.btnDetCancel.Location = new System.Drawing.Point(387, 0);
            // 
            // btnDetSave
            // 
            this.btnDetSave.Location = new System.Drawing.Point(296, 0);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(492, 317);
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
            // lblSchBidder
            // 
            this.lblSchBidder.AutoSize = true;
            this.lblSchBidder.Location = new System.Drawing.Point(7, 49);
            this.lblSchBidder.Name = "lblSchBidder";
            this.lblSchBidder.Size = new System.Drawing.Size(50, 13);
            this.lblSchBidder.TabIndex = 24;
            this.lblSchBidder.Text = "Licitante:";
            // 
            // lblDetBidder
            // 
            this.lblDetBidder.AutoSize = true;
            this.lblDetBidder.Location = new System.Drawing.Point(7, 49);
            this.lblDetBidder.Name = "lblDetBidder";
            this.lblDetBidder.Size = new System.Drawing.Size(50, 13);
            this.lblDetBidder.TabIndex = 24;
            this.lblDetBidder.Text = "Licitante:";
            // 
            // bccDetBidder
            // 
            this.bccDetBidder.CustomParent = null;
            this.bccDetBidder.DisplayMember = "Name";
            this.bccDetBidder.Location = new System.Drawing.Point(60, 45);
            this.bccDetBidder.Name = "bccDetBidder";
            bidderParameters2.BidderTypeId = null;
            bidderParameters2.Name = null;
            this.bccDetBidder.Parameters = bidderParameters2;
            this.bccDetBidder.Size = new System.Drawing.Size(226, 22);
            this.bccDetBidder.TabIndex = 26;
            this.bccDetBidder.Value = null;
            this.bccDetBidder.ValueMember = "BidderId";
            // 
            // bccSchBidder
            // 
            this.bccSchBidder.CustomParent = null;
            this.bccSchBidder.DisplayMember = "Name";
            this.bccSchBidder.Location = new System.Drawing.Point(60, 45);
            this.bccSchBidder.Name = "bccSchBidder";
            bidderParameters1.BidderTypeId = null;
            bidderParameters1.Name = null;
            this.bccSchBidder.Parameters = bidderParameters1;
            this.bccSchBidder.Size = new System.Drawing.Size(226, 22);
            this.bccSchBidder.TabIndex = 27;
            this.bccSchBidder.Value = null;
            this.bccSchBidder.ValueMember = "BidderId";
            // 
            // DependencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 317);
            this.Name = "DependencyForm";
            this.Text = "Catálogo de Dependencias";
            this.pnlDetCtgButtons.ResumeLayout(false);
            this.gbxSearchParameters.ResumeLayout(false);
            this.gbxSearchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSchName;
        private System.Windows.Forms.Label lbDetName;
        internal System.Windows.Forms.TextBox txtSchName;
        internal System.Windows.Forms.TextBox txtDetName;
        private System.Windows.Forms.Label lblSchBidder;
        private System.Windows.Forms.Label lblDetBidder;
        internal Samsara.ProjectsAndTendering.Controls.Controls.Choosers.BidderChooserControl bccDetBidder;
        internal Samsara.ProjectsAndTendering.Controls.Controls.Choosers.BidderChooserControl bccSchBidder;
    }
}