﻿namespace Samsara.ProjectsAndTendering.Forms.Forms
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
            this.txtSchName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDetName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDetCtgButtons.SuspendLayout();
            this.gbxSearchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSchSearch
            // 
            this.btnSchSearch.Location = new System.Drawing.Point(397, 21);
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Controls.Add(this.txtSchName);
            this.gbxSearchParameters.Controls.Add(this.label3);
            this.gbxSearchParameters.Size = new System.Drawing.Size(478, 50);
            this.gbxSearchParameters.Controls.SetChildIndex(this.btnSchSearch, 0);
            this.gbxSearchParameters.Controls.SetChildIndex(this.label3, 0);
            this.gbxSearchParameters.Controls.SetChildIndex(this.txtSchName, 0);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.txtDetName);
            this.gbxDetDetail.Controls.Add(this.label2);
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
            this.grdSchSearch.Location = new System.Drawing.Point(3, 53);
            this.grdSchSearch.Size = new System.Drawing.Size(478, 184);
            // 
            // txtSchName
            // 
            this.txtSchName.Location = new System.Drawing.Point(60, 19);
            this.txtSchName.Name = "txtSchName";
            this.txtSchName.Size = new System.Drawing.Size(226, 20);
            this.txtSchName.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Nombre:";
            // 
            // txtDetName
            // 
            this.txtDetName.Location = new System.Drawing.Point(60, 19);
            this.txtDetName.Name = "txtDetName";
            this.txtDetName.Size = new System.Drawing.Size(226, 20);
            this.txtDetName.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nombre:";
            // 
            // DependencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 266);
            this.Name = "DependencyForm";
            this.Text = "DependenciaForm";
            this.pnlDetCtgButtons.ResumeLayout(false);
            this.gbxSearchParameters.ResumeLayout(false);
            this.gbxSearchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSchName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDetName;
        private System.Windows.Forms.Label label2;
    }
}