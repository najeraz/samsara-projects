﻿namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    partial class CatalogForm
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.Search = new System.Windows.Forms.TabPage();
            this.grdSchSearch = new Samsara.ProjectsAndTendering.Controls.SamsaraUltraGrid();
            this.upButtons = new Infragistics.Win.Misc.UltraPanel();
            this.upSchSeparator1 = new Infragistics.Win.Misc.UltraPanel();
            this.btnSchClose = new System.Windows.Forms.Button();
            this.upSchSeparator2 = new Infragistics.Win.Misc.UltraPanel();
            this.btnSchEdit = new System.Windows.Forms.Button();
            this.upSchSeparator3 = new Infragistics.Win.Misc.UltraPanel();
            this.btnSchCreate = new System.Windows.Forms.Button();
            this.upSchSeparator4 = new Infragistics.Win.Misc.UltraPanel();
            this.btnSchSearch = new System.Windows.Forms.Button();
            this.upSchSeparator5 = new Infragistics.Win.Misc.UltraPanel();
            this.gbxSearchParameters = new System.Windows.Forms.GroupBox();
            this.New = new System.Windows.Forms.TabPage();
            this.gbxDetDetail = new System.Windows.Forms.GroupBox();
            this.pnlDetCtgButtons = new System.Windows.Forms.Panel();
            this.upDetSeparator3 = new Infragistics.Win.Misc.UltraPanel();
            this.btnDetSave = new System.Windows.Forms.Button();
            this.upDetSeparator2 = new Infragistics.Win.Misc.UltraPanel();
            this.btnDetCancel = new System.Windows.Forms.Button();
            this.upDetSeparator1 = new Infragistics.Win.Misc.UltraPanel();
            this.tabPrincipal.SuspendLayout();
            this.Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).BeginInit();
            this.upButtons.ClientArea.SuspendLayout();
            this.upButtons.SuspendLayout();
            this.upSchSeparator1.SuspendLayout();
            this.upSchSeparator2.SuspendLayout();
            this.upSchSeparator3.SuspendLayout();
            this.upSchSeparator4.SuspendLayout();
            this.upSchSeparator5.SuspendLayout();
            this.New.SuspendLayout();
            this.pnlDetCtgButtons.SuspendLayout();
            this.upDetSeparator3.SuspendLayout();
            this.upDetSeparator2.SuspendLayout();
            this.upDetSeparator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.Search);
            this.tabPrincipal.Controls.Add(this.New);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(640, 443);
            this.tabPrincipal.TabIndex = 20;
            // 
            // Search
            // 
            this.Search.Controls.Add(this.grdSchSearch);
            this.Search.Controls.Add(this.upButtons);
            this.Search.Controls.Add(this.gbxSearchParameters);
            this.Search.Location = new System.Drawing.Point(4, 22);
            this.Search.Name = "Search";
            this.Search.Padding = new System.Windows.Forms.Padding(3);
            this.Search.Size = new System.Drawing.Size(632, 417);
            this.Search.TabIndex = 0;
            this.Search.Text = "Buscar";
            this.Search.UseVisualStyleBackColor = true;
            // 
            // grdSchSearch
            // 
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdSchSearch.DisplayLayout.Appearance = appearance13;
            this.grdSchSearch.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdSchSearch.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.grdSchSearch.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdSchSearch.DisplayLayout.GroupByBox.BandLabelAppearance = appearance15;
            this.grdSchSearch.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BackColor2 = System.Drawing.SystemColors.Control;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdSchSearch.DisplayLayout.GroupByBox.PromptAppearance = appearance16;
            this.grdSchSearch.DisplayLayout.MaxColScrollRegions = 1;
            this.grdSchSearch.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdSchSearch.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            appearance18.BackColor = System.Drawing.SystemColors.Highlight;
            appearance18.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdSchSearch.DisplayLayout.Override.ActiveRowAppearance = appearance18;
            this.grdSchSearch.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdSchSearch.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            this.grdSchSearch.DisplayLayout.Override.CardAreaAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdSchSearch.DisplayLayout.Override.CellAppearance = appearance20;
            this.grdSchSearch.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdSchSearch.DisplayLayout.Override.CellPadding = 0;
            appearance21.BackColor = System.Drawing.SystemColors.Control;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.grdSchSearch.DisplayLayout.Override.GroupByRowAppearance = appearance21;
            appearance22.TextHAlignAsString = "Left";
            this.grdSchSearch.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.grdSchSearch.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdSchSearch.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            this.grdSchSearch.DisplayLayout.Override.RowAppearance = appearance23;
            this.grdSchSearch.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdSchSearch.DisplayLayout.Override.TemplateAddRowAppearance = appearance24;
            this.grdSchSearch.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdSchSearch.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdSchSearch.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdSchSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSchSearch.Location = new System.Drawing.Point(3, 97);
            this.grdSchSearch.Name = "grdSchSearch";
            this.grdSchSearch.Size = new System.Drawing.Size(626, 292);
            this.grdSchSearch.TabIndex = 22;
            this.grdSchSearch.Text = "samsaraUltraGrid1";
            // 
            // upButtons
            // 
            // 
            // upButtons.ClientArea
            // 
            this.upButtons.ClientArea.Controls.Add(this.upSchSeparator1);
            this.upButtons.ClientArea.Controls.Add(this.btnSchClose);
            this.upButtons.ClientArea.Controls.Add(this.upSchSeparator2);
            this.upButtons.ClientArea.Controls.Add(this.btnSchEdit);
            this.upButtons.ClientArea.Controls.Add(this.upSchSeparator3);
            this.upButtons.ClientArea.Controls.Add(this.btnSchCreate);
            this.upButtons.ClientArea.Controls.Add(this.upSchSeparator4);
            this.upButtons.ClientArea.Controls.Add(this.btnSchSearch);
            this.upButtons.ClientArea.Controls.Add(this.upSchSeparator5);
            this.upButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.upButtons.Location = new System.Drawing.Point(3, 389);
            this.upButtons.Name = "upButtons";
            this.upButtons.Size = new System.Drawing.Size(626, 25);
            this.upButtons.TabIndex = 21;
            // 
            // upSchSeparator1
            // 
            this.upSchSeparator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.upSchSeparator1.Location = new System.Drawing.Point(246, 0);
            this.upSchSeparator1.Name = "upSchSeparator1";
            this.upSchSeparator1.Size = new System.Drawing.Size(16, 25);
            this.upSchSeparator1.TabIndex = 8;
            // 
            // btnSchClose
            // 
            this.btnSchClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSchClose.Location = new System.Drawing.Point(262, 0);
            this.btnSchClose.Name = "btnSchClose";
            this.btnSchClose.Size = new System.Drawing.Size(75, 25);
            this.btnSchClose.TabIndex = 7;
            this.btnSchClose.Text = "Cerrar";
            this.btnSchClose.UseVisualStyleBackColor = true;
            // 
            // upSchSeparator2
            // 
            this.upSchSeparator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.upSchSeparator2.Location = new System.Drawing.Point(337, 0);
            this.upSchSeparator2.Name = "upSchSeparator2";
            this.upSchSeparator2.Size = new System.Drawing.Size(16, 25);
            this.upSchSeparator2.TabIndex = 6;
            // 
            // btnSchEdit
            // 
            this.btnSchEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSchEdit.Location = new System.Drawing.Point(353, 0);
            this.btnSchEdit.Name = "btnSchEdit";
            this.btnSchEdit.Size = new System.Drawing.Size(75, 25);
            this.btnSchEdit.TabIndex = 5;
            this.btnSchEdit.Text = "Modificar";
            this.btnSchEdit.UseVisualStyleBackColor = true;
            // 
            // upSchSeparator3
            // 
            this.upSchSeparator3.Dock = System.Windows.Forms.DockStyle.Right;
            this.upSchSeparator3.Location = new System.Drawing.Point(428, 0);
            this.upSchSeparator3.Name = "upSchSeparator3";
            this.upSchSeparator3.Size = new System.Drawing.Size(16, 25);
            this.upSchSeparator3.TabIndex = 4;
            // 
            // btnSchCreate
            // 
            this.btnSchCreate.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSchCreate.Location = new System.Drawing.Point(444, 0);
            this.btnSchCreate.Name = "btnSchCreate";
            this.btnSchCreate.Size = new System.Drawing.Size(75, 25);
            this.btnSchCreate.TabIndex = 3;
            this.btnSchCreate.Text = "Nuevo";
            this.btnSchCreate.UseVisualStyleBackColor = true;
            // 
            // upSchSeparator4
            // 
            this.upSchSeparator4.Dock = System.Windows.Forms.DockStyle.Right;
            this.upSchSeparator4.Location = new System.Drawing.Point(519, 0);
            this.upSchSeparator4.Name = "upSchSeparator4";
            this.upSchSeparator4.Size = new System.Drawing.Size(16, 25);
            this.upSchSeparator4.TabIndex = 2;
            // 
            // btnSchSearch
            // 
            this.btnSchSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSchSearch.Location = new System.Drawing.Point(535, 0);
            this.btnSchSearch.Name = "btnSchSearch";
            this.btnSchSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSchSearch.TabIndex = 0;
            this.btnSchSearch.Text = "Buscar";
            this.btnSchSearch.UseVisualStyleBackColor = true;
            // 
            // upSchSeparator5
            // 
            this.upSchSeparator5.Dock = System.Windows.Forms.DockStyle.Right;
            this.upSchSeparator5.Location = new System.Drawing.Point(610, 0);
            this.upSchSeparator5.Name = "upSchSeparator5";
            this.upSchSeparator5.Size = new System.Drawing.Size(16, 25);
            this.upSchSeparator5.TabIndex = 1;
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxSearchParameters.Location = new System.Drawing.Point(3, 3);
            this.gbxSearchParameters.Name = "gbxSearchParameters";
            this.gbxSearchParameters.Size = new System.Drawing.Size(626, 94);
            this.gbxSearchParameters.TabIndex = 19;
            this.gbxSearchParameters.TabStop = false;
            this.gbxSearchParameters.Text = "Parámetros de búsqueda:";
            // 
            // New
            // 
            this.New.Controls.Add(this.gbxDetDetail);
            this.New.Controls.Add(this.pnlDetCtgButtons);
            this.New.Location = new System.Drawing.Point(4, 22);
            this.New.Name = "New";
            this.New.Padding = new System.Windows.Forms.Padding(3);
            this.New.Size = new System.Drawing.Size(632, 417);
            this.New.TabIndex = 1;
            this.New.Text = "Nuevo";
            this.New.UseVisualStyleBackColor = true;
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDetDetail.Location = new System.Drawing.Point(3, 3);
            this.gbxDetDetail.Name = "gbxDetDetail";
            this.gbxDetDetail.Size = new System.Drawing.Size(626, 386);
            this.gbxDetDetail.TabIndex = 18;
            this.gbxDetDetail.TabStop = false;
            this.gbxDetDetail.Text = "Datos del Registro:";
            // 
            // pnlDetCtgButtons
            // 
            this.pnlDetCtgButtons.Controls.Add(this.upDetSeparator3);
            this.pnlDetCtgButtons.Controls.Add(this.btnDetSave);
            this.pnlDetCtgButtons.Controls.Add(this.upDetSeparator2);
            this.pnlDetCtgButtons.Controls.Add(this.btnDetCancel);
            this.pnlDetCtgButtons.Controls.Add(this.upDetSeparator1);
            this.pnlDetCtgButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetCtgButtons.Location = new System.Drawing.Point(3, 389);
            this.pnlDetCtgButtons.MaximumSize = new System.Drawing.Size(0, 25);
            this.pnlDetCtgButtons.MinimumSize = new System.Drawing.Size(0, 25);
            this.pnlDetCtgButtons.Name = "pnlDetCtgButtons";
            this.pnlDetCtgButtons.Size = new System.Drawing.Size(626, 25);
            this.pnlDetCtgButtons.TabIndex = 0;
            // 
            // upDetSeparator3
            // 
            this.upDetSeparator3.Dock = System.Windows.Forms.DockStyle.Right;
            this.upDetSeparator3.Location = new System.Drawing.Point(428, 0);
            this.upDetSeparator3.Name = "upDetSeparator3";
            this.upDetSeparator3.Size = new System.Drawing.Size(16, 25);
            this.upDetSeparator3.TabIndex = 9;
            // 
            // btnDetSave
            // 
            this.btnDetSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDetSave.Location = new System.Drawing.Point(444, 0);
            this.btnDetSave.Name = "btnDetSave";
            this.btnDetSave.Size = new System.Drawing.Size(75, 25);
            this.btnDetSave.TabIndex = 0;
            this.btnDetSave.Text = "Guardar";
            this.btnDetSave.UseVisualStyleBackColor = true;
            // 
            // upDetSeparator2
            // 
            this.upDetSeparator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.upDetSeparator2.Location = new System.Drawing.Point(519, 0);
            this.upDetSeparator2.Name = "upDetSeparator2";
            this.upDetSeparator2.Size = new System.Drawing.Size(16, 25);
            this.upDetSeparator2.TabIndex = 8;
            // 
            // btnDetCancel
            // 
            this.btnDetCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDetCancel.Location = new System.Drawing.Point(535, 0);
            this.btnDetCancel.Name = "btnDetCancel";
            this.btnDetCancel.Size = new System.Drawing.Size(75, 25);
            this.btnDetCancel.TabIndex = 0;
            this.btnDetCancel.Text = "Cancelar";
            this.btnDetCancel.UseVisualStyleBackColor = true;
            // 
            // upDetSeparator1
            // 
            this.upDetSeparator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.upDetSeparator1.Location = new System.Drawing.Point(610, 0);
            this.upDetSeparator1.Name = "upDetSeparator1";
            this.upDetSeparator1.Size = new System.Drawing.Size(16, 25);
            this.upDetSeparator1.TabIndex = 7;
            // 
            // CatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 443);
            this.Controls.Add(this.tabPrincipal);
            this.Name = "CatalogForm";
            this.Text = "CatalogForm";
            this.tabPrincipal.ResumeLayout(false);
            this.Search.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).EndInit();
            this.upButtons.ClientArea.ResumeLayout(false);
            this.upButtons.ResumeLayout(false);
            this.upSchSeparator1.ResumeLayout(false);
            this.upSchSeparator2.ResumeLayout(false);
            this.upSchSeparator3.ResumeLayout(false);
            this.upSchSeparator4.ResumeLayout(false);
            this.upSchSeparator5.ResumeLayout(false);
            this.New.ResumeLayout(false);
            this.pnlDetCtgButtons.ResumeLayout(false);
            this.upDetSeparator3.ResumeLayout(false);
            this.upDetSeparator2.ResumeLayout(false);
            this.upDetSeparator1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Search;
        private System.Windows.Forms.TabPage New;
        protected System.Windows.Forms.Panel pnlDetCtgButtons;
        protected System.Windows.Forms.GroupBox gbxSearchParameters;
        protected System.Windows.Forms.GroupBox gbxDetDetail;
        public System.Windows.Forms.Button btnSchSearch;
        private Infragistics.Win.Misc.UltraPanel upButtons;
        private Infragistics.Win.Misc.UltraPanel upSchSeparator4;
        private Infragistics.Win.Misc.UltraPanel upSchSeparator5;
        private Infragistics.Win.Misc.UltraPanel upSchSeparator1;
        public System.Windows.Forms.Button btnSchClose;
        private Infragistics.Win.Misc.UltraPanel upSchSeparator2;
        public System.Windows.Forms.Button btnSchEdit;
        private Infragistics.Win.Misc.UltraPanel upSchSeparator3;
        public System.Windows.Forms.Button btnSchCreate;
        internal Samsara.ProjectsAndTendering.Controls.SamsaraUltraGrid grdSchSearch;
        internal System.Windows.Forms.TabControl tabPrincipal;
        private Infragistics.Win.Misc.UltraPanel upDetSeparator1;
        private Infragistics.Win.Misc.UltraPanel upDetSeparator3;
        private Infragistics.Win.Misc.UltraPanel upDetSeparator2;
        internal System.Windows.Forms.Button btnDetCancel;
        internal System.Windows.Forms.Button btnDetSave;
    }
}