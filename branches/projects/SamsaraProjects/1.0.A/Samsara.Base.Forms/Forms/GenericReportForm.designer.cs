namespace Samsara.Base.Forms.Forms
{
    partial class GenericReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericReportForm));
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.Principal = new System.Windows.Forms.TabPage();
            this.grdPrincipal = new Samsara.Base.Controls.Controls.SamsaraUltraGrid();
            this.upPrplSearchButtons = new Infragistics.Win.Misc.UltraPanel();
            this.upPrplSeparatorClean = new Infragistics.Win.Misc.UltraPanel();
            this.btnPrplClear = new System.Windows.Forms.Button();
            this.upPrplSeparatorSearch = new Infragistics.Win.Misc.UltraPanel();
            this.btnPrplGenerate = new System.Windows.Forms.Button();
            this.upPrplSeparatorBottonSearch = new Infragistics.Win.Misc.UltraPanel();
            this.gbxPrplParameters = new System.Windows.Forms.GroupBox();
            this.tabPrincipal.SuspendLayout();
            this.Principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).BeginInit();
            this.upPrplSearchButtons.ClientArea.SuspendLayout();
            this.upPrplSearchButtons.SuspendLayout();
            this.upPrplSeparatorClean.SuspendLayout();
            this.upPrplSeparatorSearch.SuspendLayout();
            this.upPrplSeparatorBottonSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.Principal);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(640, 443);
            this.tabPrincipal.TabIndex = 20;
            // 
            // Principal
            // 
            this.Principal.BackColor = System.Drawing.Color.Transparent;
            this.Principal.Controls.Add(this.grdPrincipal);
            this.Principal.Controls.Add(this.upPrplSearchButtons);
            this.Principal.Controls.Add(this.gbxPrplParameters);
            this.Principal.Location = new System.Drawing.Point(4, 22);
            this.Principal.Name = "Principal";
            this.Principal.Padding = new System.Windows.Forms.Padding(3);
            this.Principal.Size = new System.Drawing.Size(632, 417);
            this.Principal.TabIndex = 0;
            this.Principal.Text = "Principal";
            // 
            // grdPrincipal
            // 
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdPrincipal.DisplayLayout.Appearance = appearance13;
            this.grdPrincipal.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdPrincipal.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.grdPrincipal.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdPrincipal.DisplayLayout.GroupByBox.BandLabelAppearance = appearance15;
            this.grdPrincipal.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BackColor2 = System.Drawing.SystemColors.Control;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdPrincipal.DisplayLayout.GroupByBox.PromptAppearance = appearance16;
            this.grdPrincipal.DisplayLayout.MaxColScrollRegions = 1;
            this.grdPrincipal.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPrincipal.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            appearance18.BackColor = System.Drawing.SystemColors.Highlight;
            appearance18.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdPrincipal.DisplayLayout.Override.ActiveRowAppearance = appearance18;
            this.grdPrincipal.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdPrincipal.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            this.grdPrincipal.DisplayLayout.Override.CardAreaAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdPrincipal.DisplayLayout.Override.CellAppearance = appearance20;
            this.grdPrincipal.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdPrincipal.DisplayLayout.Override.CellPadding = 0;
            appearance21.BackColor = System.Drawing.SystemColors.Control;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.grdPrincipal.DisplayLayout.Override.GroupByRowAppearance = appearance21;
            appearance22.TextHAlignAsString = "Left";
            this.grdPrincipal.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.grdPrincipal.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdPrincipal.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            this.grdPrincipal.DisplayLayout.Override.RowAppearance = appearance23;
            this.grdPrincipal.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdPrincipal.DisplayLayout.Override.TemplateAddRowAppearance = appearance24;
            this.grdPrincipal.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdPrincipal.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdPrincipal.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPrincipal.Location = new System.Drawing.Point(3, 122);
            this.grdPrincipal.Name = "grdPrincipal";
            this.grdPrincipal.Size = new System.Drawing.Size(626, 292);
            this.grdPrincipal.TabIndex = 22;
            this.grdPrincipal.Text = "samsaraUltraGrid1";
            // 
            // upPrplSearchButtons
            // 
            // 
            // upPrplSearchButtons.ClientArea
            // 
            this.upPrplSearchButtons.ClientArea.Controls.Add(this.upPrplSeparatorClean);
            this.upPrplSearchButtons.ClientArea.Controls.Add(this.btnPrplClear);
            this.upPrplSearchButtons.ClientArea.Controls.Add(this.upPrplSeparatorSearch);
            this.upPrplSearchButtons.ClientArea.Controls.Add(this.btnPrplGenerate);
            this.upPrplSearchButtons.ClientArea.Controls.Add(this.upPrplSeparatorBottonSearch);
            this.upPrplSearchButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.upPrplSearchButtons.Location = new System.Drawing.Point(3, 97);
            this.upPrplSearchButtons.Name = "upPrplSearchButtons";
            this.upPrplSearchButtons.Size = new System.Drawing.Size(626, 25);
            this.upPrplSearchButtons.TabIndex = 23;
            // 
            // upPrplSeparatorClean
            // 
            this.upPrplSeparatorClean.Dock = System.Windows.Forms.DockStyle.Right;
            this.upPrplSeparatorClean.Location = new System.Drawing.Point(428, 0);
            this.upPrplSeparatorClean.Name = "upPrplSeparatorClean";
            this.upPrplSeparatorClean.Size = new System.Drawing.Size(16, 25);
            this.upPrplSeparatorClean.TabIndex = 6;
            // 
            // btnPrplClear
            // 
            this.btnPrplClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrplClear.Location = new System.Drawing.Point(444, 0);
            this.btnPrplClear.Name = "btnPrplClear";
            this.btnPrplClear.Size = new System.Drawing.Size(75, 25);
            this.btnPrplClear.TabIndex = 2;
            this.btnPrplClear.Text = "Limpiar";
            this.btnPrplClear.UseVisualStyleBackColor = true;
            // 
            // upPrplSeparatorSearch
            // 
            this.upPrplSeparatorSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.upPrplSeparatorSearch.Location = new System.Drawing.Point(519, 0);
            this.upPrplSeparatorSearch.Name = "upPrplSeparatorSearch";
            this.upPrplSeparatorSearch.Size = new System.Drawing.Size(16, 25);
            this.upPrplSeparatorSearch.TabIndex = 5;
            // 
            // btnPrplGenerate
            // 
            this.btnPrplGenerate.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrplGenerate.Location = new System.Drawing.Point(535, 0);
            this.btnPrplGenerate.Name = "btnPrplGenerate";
            this.btnPrplGenerate.Size = new System.Drawing.Size(75, 25);
            this.btnPrplGenerate.TabIndex = 3;
            this.btnPrplGenerate.Text = "Generar";
            this.btnPrplGenerate.UseVisualStyleBackColor = true;
            this.btnPrplGenerate.Click += new System.EventHandler(this.btnClick);
            // 
            // upPrplSeparatorBottonSearch
            // 
            this.upPrplSeparatorBottonSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.upPrplSeparatorBottonSearch.Location = new System.Drawing.Point(610, 0);
            this.upPrplSeparatorBottonSearch.Name = "upPrplSeparatorBottonSearch";
            this.upPrplSeparatorBottonSearch.Size = new System.Drawing.Size(16, 25);
            this.upPrplSeparatorBottonSearch.TabIndex = 1;
            // 
            // gbxPrplParameters
            // 
            this.gbxPrplParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxPrplParameters.Location = new System.Drawing.Point(3, 3);
            this.gbxPrplParameters.Name = "gbxPrplParameters";
            this.gbxPrplParameters.Size = new System.Drawing.Size(626, 94);
            this.gbxPrplParameters.TabIndex = 19;
            this.gbxPrplParameters.TabStop = false;
            this.gbxPrplParameters.Text = "Parámetros de búsqueda:";
            // 
            // GenericReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 443);
            this.Controls.Add(this.tabPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GenericReportForm";
            this.Text = "GenericReportForm";
            this.tabPrincipal.ResumeLayout(false);
            this.Principal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).EndInit();
            this.upPrplSearchButtons.ClientArea.ResumeLayout(false);
            this.upPrplSearchButtons.ResumeLayout(false);
            this.upPrplSeparatorClean.ResumeLayout(false);
            this.upPrplSeparatorSearch.ResumeLayout(false);
            this.upPrplSeparatorBottonSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Principal;
        protected System.Windows.Forms.GroupBox gbxPrplParameters;
        private Infragistics.Win.Misc.UltraPanel upPrplSearchButtons;
        internal Infragistics.Win.Misc.UltraPanel upPrplSeparatorClean;
        public System.Windows.Forms.Button btnPrplClear;
        internal Infragistics.Win.Misc.UltraPanel upPrplSeparatorSearch;
        public System.Windows.Forms.Button btnPrplGenerate;
        internal Infragistics.Win.Misc.UltraPanel upPrplSeparatorBottonSearch;
        public Samsara.Base.Controls.Controls.SamsaraUltraGrid grdPrincipal;
        public System.Windows.Forms.TabControl tabPrincipal;
    }
}