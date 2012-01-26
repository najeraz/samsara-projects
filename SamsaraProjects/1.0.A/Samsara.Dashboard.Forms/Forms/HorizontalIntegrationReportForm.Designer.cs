namespace Samsara.Dashboard.Forms.Forms
{
    partial class HorizontalIntegrationReportForm
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
            this.dtePrplMinDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblPrplMinDate = new System.Windows.Forms.Label();
            this.dtePrplMaxDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblPrplEndDate = new System.Windows.Forms.Label();
            this.ubgxPrplFechas = new Infragistics.Win.Misc.UltraGroupBox();
            this.samsaraUltraComboEditor1 = new Samsara.Base.Controls.Controls.SamsaraUltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxPrplParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtePrplMinDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtePrplMaxDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ubgxPrplFechas)).BeginInit();
            this.ubgxPrplFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samsaraUltraComboEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxPrplParameters
            // 
            this.gbxPrplParameters.Controls.Add(this.label1);
            this.gbxPrplParameters.Controls.Add(this.samsaraUltraComboEditor1);
            this.gbxPrplParameters.Controls.Add(this.ubgxPrplFechas);
            this.gbxPrplParameters.Size = new System.Drawing.Size(626, 97);
            // 
            // grdPrincipal
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdPrincipal.DisplayLayout.Appearance = appearance1;
            this.grdPrincipal.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdPrincipal.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdPrincipal.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdPrincipal.DisplayLayout.MaxColScrollRegions = 1;
            this.grdPrincipal.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPrincipal.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Highlight;
            appearance3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdPrincipal.DisplayLayout.Override.ActiveRowAppearance = appearance3;
            this.grdPrincipal.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdPrincipal.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdPrincipal.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            this.grdPrincipal.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdPrincipal.DisplayLayout.Override.CellAppearance = appearance5;
            this.grdPrincipal.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdPrincipal.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grdPrincipal.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.grdPrincipal.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grdPrincipal.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdPrincipal.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            this.grdPrincipal.DisplayLayout.Override.RowAppearance = appearance8;
            this.grdPrincipal.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdPrincipal.DisplayLayout.Override.TemplateAddRowAppearance = appearance9;
            this.grdPrincipal.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdPrincipal.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdPrincipal.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdPrincipal.Location = new System.Drawing.Point(3, 125);
            this.grdPrincipal.Size = new System.Drawing.Size(626, 289);
            // 
            // dtePrplMinDate
            // 
            this.dtePrplMinDate.DateTime = new System.DateTime(2011, 7, 20, 0, 0, 0, 0);
            this.dtePrplMinDate.Location = new System.Drawing.Point(62, 19);
            this.dtePrplMinDate.Name = "dtePrplMinDate";
            this.dtePrplMinDate.Size = new System.Drawing.Size(122, 21);
            this.dtePrplMinDate.TabIndex = 1;
            this.dtePrplMinDate.Value = new System.DateTime(2011, 7, 20, 0, 0, 0, 0);
            // 
            // lblPrplMinDate
            // 
            this.lblPrplMinDate.AutoSize = true;
            this.lblPrplMinDate.Location = new System.Drawing.Point(9, 23);
            this.lblPrplMinDate.Name = "lblPrplMinDate";
            this.lblPrplMinDate.Size = new System.Drawing.Size(35, 13);
            this.lblPrplMinDate.TabIndex = 70;
            this.lblPrplMinDate.Text = "Inicio:";
            // 
            // dtePrplMaxDate
            // 
            this.dtePrplMaxDate.DateTime = new System.DateTime(2011, 7, 20, 0, 0, 0, 0);
            this.dtePrplMaxDate.Location = new System.Drawing.Point(62, 45);
            this.dtePrplMaxDate.Name = "dtePrplMaxDate";
            this.dtePrplMaxDate.Size = new System.Drawing.Size(122, 21);
            this.dtePrplMaxDate.TabIndex = 2;
            this.dtePrplMaxDate.Value = new System.DateTime(2011, 7, 20, 0, 0, 0, 0);
            // 
            // lblPrplEndDate
            // 
            this.lblPrplEndDate.AutoSize = true;
            this.lblPrplEndDate.Location = new System.Drawing.Point(10, 49);
            this.lblPrplEndDate.Name = "lblPrplEndDate";
            this.lblPrplEndDate.Size = new System.Drawing.Size(24, 13);
            this.lblPrplEndDate.TabIndex = 69;
            this.lblPrplEndDate.Text = "Fin:";
            // 
            // ubgxPrplFechas
            // 
            this.ubgxPrplFechas.Controls.Add(this.dtePrplMinDate);
            this.ubgxPrplFechas.Controls.Add(this.lblPrplMinDate);
            this.ubgxPrplFechas.Controls.Add(this.dtePrplMaxDate);
            this.ubgxPrplFechas.Controls.Add(this.lblPrplEndDate);
            this.ubgxPrplFechas.Location = new System.Drawing.Point(6, 13);
            this.ubgxPrplFechas.Name = "ubgxPrplFechas";
            this.ubgxPrplFechas.Size = new System.Drawing.Size(196, 75);
            this.ubgxPrplFechas.TabIndex = 72;
            this.ubgxPrplFechas.Text = "Rango de Fechas:";
            // 
            // samsaraUltraComboEditor1
            // 
            this.samsaraUltraComboEditor1.Location = new System.Drawing.Point(287, 58);
            this.samsaraUltraComboEditor1.Name = "samsaraUltraComboEditor1";
            this.samsaraUltraComboEditor1.Size = new System.Drawing.Size(144, 21);
            this.samsaraUltraComboEditor1.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Agente:";
            // 
            // HorizontalIntegrationReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 443);
            this.Name = "HorizontalIntegrationReportForm";
            this.Text = "HorizontalIntegrationForm";
            this.gbxPrplParameters.ResumeLayout(false);
            this.gbxPrplParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtePrplMinDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtePrplMaxDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ubgxPrplFechas)).EndInit();
            this.ubgxPrplFechas.ResumeLayout(false);
            this.ubgxPrplFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samsaraUltraComboEditor1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtePrplMinDate;
        private System.Windows.Forms.Label lblPrplMinDate;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtePrplMaxDate;
        private System.Windows.Forms.Label lblPrplEndDate;
        private Base.Controls.Controls.SamsaraUltraComboEditor samsaraUltraComboEditor1;
        private Infragistics.Win.Misc.UltraGroupBox ubgxPrplFechas;
        private System.Windows.Forms.Label label1;
    }
}