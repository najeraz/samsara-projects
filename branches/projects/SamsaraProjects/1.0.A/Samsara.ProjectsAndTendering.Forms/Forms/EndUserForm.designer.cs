﻿namespace Samsara.ProjectsAndTendering.Forms.Forms
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Samsara.ProjectsAndTendering.Core.Parameters.DependencyParameters dependencyParameters2 = new Samsara.ProjectsAndTendering.Core.Parameters.DependencyParameters();
            Samsara.ProjectsAndTendering.Core.Parameters.DependencyParameters dependencyParameters1 = new Samsara.ProjectsAndTendering.Core.Parameters.DependencyParameters();
            this.txtSchName = new System.Windows.Forms.TextBox();
            this.lblSchDependency = new System.Windows.Forms.Label();
            this.lblSchName = new System.Windows.Forms.Label();
            this.txtDetName = new System.Windows.Forms.TextBox();
            this.lblDetDependency = new System.Windows.Forms.Label();
            this.lblDetName = new System.Windows.Forms.Label();
            this.dccDetDependency = new Samsara.ProjectsAndTendering.Controls.Controls.DependencyChooserControl();
            this.dccSchDependency = new Samsara.ProjectsAndTendering.Controls.Controls.DependencyChooserControl();
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
            this.gbxSearchParameters.Controls.Add(this.dccSchDependency);
            this.gbxSearchParameters.Controls.Add(this.txtSchName);
            this.gbxSearchParameters.Controls.Add(this.lblSchDependency);
            this.gbxSearchParameters.Controls.Add(this.lblSchName);
            this.gbxSearchParameters.Size = new System.Drawing.Size(502, 76);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.dccDetDependency);
            this.gbxDetDetail.Controls.Add(this.txtDetName);
            this.gbxDetDetail.Controls.Add(this.lblDetDependency);
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
            this.txtSchName.Location = new System.Drawing.Point(87, 23);
            this.txtSchName.Name = "txtSchName";
            this.txtSchName.Size = new System.Drawing.Size(226, 20);
            this.txtSchName.TabIndex = 20;
            // 
            // lblSchDependency
            // 
            this.lblSchDependency.AutoSize = true;
            this.lblSchDependency.Location = new System.Drawing.Point(7, 52);
            this.lblSchDependency.Name = "lblSchDependency";
            this.lblSchDependency.Size = new System.Drawing.Size(74, 13);
            this.lblSchDependency.TabIndex = 18;
            this.lblSchDependency.Text = "Dependencia:";
            // 
            // lblSchName
            // 
            this.lblSchName.AutoSize = true;
            this.lblSchName.Location = new System.Drawing.Point(7, 26);
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
            // dccDetDependency
            // 
            this.dccDetDependency.CustomParent = null;
            this.dccDetDependency.DisplayMember = "Name";
            this.dccDetDependency.Location = new System.Drawing.Point(86, 45);
            this.dccDetDependency.Name = "dccDetDependency";
            dependencyParameters2.BidderId = null;
            dependencyParameters2.Name = null;
            this.dccDetDependency.Parameters = dependencyParameters2;
            this.dccDetDependency.Size = new System.Drawing.Size(226, 22);
            this.dccDetDependency.TabIndex = 23;
            this.dccDetDependency.Value = null;
            this.dccDetDependency.ValueMember = "DependencyId";
            // 
            // dccSchDependency
            // 
            this.dccSchDependency.CustomParent = null;
            this.dccSchDependency.DisplayMember = "Name";
            this.dccSchDependency.Location = new System.Drawing.Point(87, 49);
            this.dccSchDependency.Name = "dccSchDependency";
            dependencyParameters1.BidderId = null;
            dependencyParameters1.Name = null;
            this.dccSchDependency.Parameters = dependencyParameters1;
            this.dccSchDependency.Size = new System.Drawing.Size(226, 22);
            this.dccSchDependency.TabIndex = 24;
            this.dccSchDependency.Value = null;
            this.dccSchDependency.ValueMember = "DependencyId";
            // 
            // EndUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 308);
            this.Name = "EndUserForm";
            this.Text = "Catálogo de Usuarios Finales";
            this.pnlDetCtgButtons.ResumeLayout(false);
            this.gbxSearchParameters.ResumeLayout(false);
            this.gbxSearchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSchDependency;
        private System.Windows.Forms.Label lblSchName;
        private System.Windows.Forms.Label lblDetDependency;
        private System.Windows.Forms.Label lblDetName;
        internal System.Windows.Forms.TextBox txtSchName;
        internal System.Windows.Forms.TextBox txtDetName;
        internal Controls.Controls.DependencyChooserControl dccSchDependency;
        internal Controls.Controls.DependencyChooserControl dccDetDependency;
    }
}