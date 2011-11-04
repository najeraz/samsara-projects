namespace Samsara.CustomerContext.Controls.Controls.ManyToOne
{
    partial class CustomerInfrastructurePrintersControl
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

        #region Component Designer generated code

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
            Samsara.CustomerContext.Core.Parameters.PrinterTypeParameters printerTypeParameters1 = new Samsara.CustomerContext.Core.Parameters.PrinterTypeParameters();
            Samsara.CustomerContext.Core.Parameters.PrinterBrandParameters printerBrandParameters1 = new Samsara.CustomerContext.Core.Parameters.PrinterBrandParameters();
            this.txtlSerialNumber = new System.Windows.Forms.TextBox();
            this.lblSerialNumber = new Infragistics.Win.Misc.UltraLabel();
            this.lblPrinterType = new Infragistics.Win.Misc.UltraLabel();
            this.lblPrinterBrand = new Infragistics.Win.Misc.UltraLabel();
            this.ptcPrinterType = new Samsara.CustomerContext.Controls.Controls.Choosers.PrinterTypeChooserControl();
            this.pbcPrinterBrand = new Samsara.CustomerContext.Controls.Controls.Choosers.PrinterBrandChooserControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdRelations)).BeginInit();
            this.upnDetailButtons.ClientArea.SuspendLayout();
            this.upnDetailButtons.SuspendLayout();
            this.upnlSeparatorDeleteRelation.SuspendLayout();
            this.upnlSeparatorEditRelation.SuspendLayout();
            this.upnlSeparatorCreateRelation.SuspendLayout();
            this.upnlSeparatorDetailButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxDetDetail)).BeginInit();
            this.gbxDetDetail.SuspendLayout();
            this.tabDetail.SuspendLayout();
            this.tabItmPrincipal.SuspendLayout();
            this.upnlButtons.ClientArea.SuspendLayout();
            this.upnlButtons.SuspendLayout();
            this.upnlSeparatorSaveRelation.SuspendLayout();
            this.upnlSeparatorCancelRelation.SuspendLayout();
            this.upnlSeparatorButtons.SuspendLayout();
            this.upnlSeparatorViewRelation.SuspendLayout();
            this.upnlSeparatorCloseRelation.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdRelations
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdRelations.DisplayLayout.Appearance = appearance1;
            this.grdRelations.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdRelations.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdRelations.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdRelations.DisplayLayout.MaxColScrollRegions = 1;
            this.grdRelations.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdRelations.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Highlight;
            appearance3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdRelations.DisplayLayout.Override.ActiveRowAppearance = appearance3;
            this.grdRelations.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdRelations.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            this.grdRelations.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdRelations.DisplayLayout.Override.CellAppearance = appearance5;
            this.grdRelations.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdRelations.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grdRelations.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.grdRelations.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grdRelations.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdRelations.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            this.grdRelations.DisplayLayout.Override.RowAppearance = appearance8;
            this.grdRelations.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdRelations.DisplayLayout.Override.TemplateAddRowAppearance = appearance9;
            this.grdRelations.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdRelations.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdRelations.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdRelations.Size = new System.Drawing.Size(710, 204);
            // 
            // upnDetailButtons
            // 
            this.upnDetailButtons.Location = new System.Drawing.Point(0, 204);
            this.upnDetailButtons.Size = new System.Drawing.Size(710, 25);
            // 
            // upnlSeparatorDeleteRelation
            // 
            this.upnlSeparatorDeleteRelation.Location = new System.Drawing.Point(322, 0);
            // 
            // ubtnDeleteRelation
            // 
            this.ubtnDeleteRelation.Location = new System.Drawing.Point(338, 0);
            // 
            // upnlSeparatorEditRelation
            // 
            this.upnlSeparatorEditRelation.Location = new System.Drawing.Point(415, 0);
            // 
            // ubtnEditRelation
            // 
            this.ubtnEditRelation.Location = new System.Drawing.Point(431, 0);
            // 
            // upnlSeparatorCreateRelation
            // 
            this.upnlSeparatorCreateRelation.Location = new System.Drawing.Point(601, 0);
            // 
            // ubtnCreateRelation
            // 
            this.ubtnCreateRelation.Location = new System.Drawing.Point(617, 0);
            // 
            // upnlSeparatorDetailButtons
            // 
            this.upnlSeparatorDetailButtons.Location = new System.Drawing.Point(694, 0);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Location = new System.Drawing.Point(0, 229);
            this.gbxDetDetail.Size = new System.Drawing.Size(710, 159);
            // 
            // tabDetail
            // 
            this.tabDetail.Size = new System.Drawing.Size(704, 140);
            // 
            // tabItmPrincipal
            // 
            this.tabItmPrincipal.Controls.Add(this.pbcPrinterBrand);
            this.tabItmPrincipal.Controls.Add(this.ptcPrinterType);
            this.tabItmPrincipal.Controls.Add(this.txtlSerialNumber);
            this.tabItmPrincipal.Controls.Add(this.lblSerialNumber);
            this.tabItmPrincipal.Controls.Add(this.lblPrinterType);
            this.tabItmPrincipal.Controls.Add(this.lblPrinterBrand);
            this.tabItmPrincipal.Size = new System.Drawing.Size(696, 114);
            // 
            // upnlButtons
            // 
            this.upnlButtons.Location = new System.Drawing.Point(0, 388);
            this.upnlButtons.Size = new System.Drawing.Size(710, 25);
            // 
            // upnlSeparatorSaveRelation
            // 
            this.upnlSeparatorSaveRelation.Location = new System.Drawing.Point(508, 0);
            // 
            // ubtnSaveRelation
            // 
            this.ubtnSaveRelation.Location = new System.Drawing.Point(524, 0);
            // 
            // upnlSeparatorCancelRelation
            // 
            this.upnlSeparatorCancelRelation.Location = new System.Drawing.Point(601, 0);
            // 
            // ubtnCancelRelation
            // 
            this.ubtnCancelRelation.Location = new System.Drawing.Point(617, 0);
            // 
            // upnlSeparatorButtons
            // 
            this.upnlSeparatorButtons.Location = new System.Drawing.Point(694, 0);
            // 
            // upnlSeparatorViewRelation
            // 
            this.upnlSeparatorViewRelation.Location = new System.Drawing.Point(508, 0);
            // 
            // ubtnViewRelation
            // 
            this.ubtnViewRelation.Location = new System.Drawing.Point(524, 0);
            // 
            // upnlSeparatorCloseRelation
            // 
            this.upnlSeparatorCloseRelation.Location = new System.Drawing.Point(415, 0);
            // 
            // ubtnCloseRelation
            // 
            this.ubtnCloseRelation.Location = new System.Drawing.Point(431, 0);
            // 
            // txtlSerialNumber
            // 
            this.txtlSerialNumber.Location = new System.Drawing.Point(447, 19);
            this.txtlSerialNumber.Name = "txtlSerialNumber";
            this.txtlSerialNumber.Size = new System.Drawing.Size(226, 20);
            this.txtlSerialNumber.TabIndex = 111;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Location = new System.Drawing.Point(351, 22);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(93, 14);
            this.lblSerialNumber.TabIndex = 110;
            this.lblSerialNumber.Text = "Número de Serie:";
            // 
            // lblPrinterType
            // 
            this.lblPrinterType.AutoSize = true;
            this.lblPrinterType.Location = new System.Drawing.Point(13, 49);
            this.lblPrinterType.Name = "lblPrinterType";
            this.lblPrinterType.Size = new System.Drawing.Size(29, 14);
            this.lblPrinterType.TabIndex = 107;
            this.lblPrinterType.Text = "Tipo:";
            // 
            // lblPrinterBrand
            // 
            this.lblPrinterBrand.AutoSize = true;
            this.lblPrinterBrand.Location = new System.Drawing.Point(13, 22);
            this.lblPrinterBrand.Name = "lblPrinterBrand";
            this.lblPrinterBrand.Size = new System.Drawing.Size(39, 14);
            this.lblPrinterBrand.TabIndex = 106;
            this.lblPrinterBrand.Text = "Marca:";
            // 
            // ptcPrinterType
            // 
            this.ptcPrinterType.CustomParent = null;
            this.ptcPrinterType.DisplayMember = "Name";
            this.ptcPrinterType.Location = new System.Drawing.Point(88, 45);
            this.ptcPrinterType.Name = "ptcPrinterType";
            printerTypeParameters1.Description = null;
            printerTypeParameters1.Name = null;
            printerTypeParameters1.PrinterTypeId = null;
            this.ptcPrinterType.Parameters = printerTypeParameters1;
            this.ptcPrinterType.ReadOnly = false;
            this.ptcPrinterType.Size = new System.Drawing.Size(226, 22);
            this.ptcPrinterType.TabIndex = 112;
            this.ptcPrinterType.Value = null;
            this.ptcPrinterType.ValueMember = "PrinterTypeId";
            // 
            // pbcPrinterBrand
            // 
            this.pbcPrinterBrand.CustomParent = null;
            this.pbcPrinterBrand.DisplayMember = "Name";
            this.pbcPrinterBrand.Location = new System.Drawing.Point(88, 17);
            this.pbcPrinterBrand.Name = "pbcPrinterBrand";
            printerBrandParameters1.Description = null;
            printerBrandParameters1.Name = null;
            printerBrandParameters1.PrinterBrandId = null;
            this.pbcPrinterBrand.Parameters = printerBrandParameters1;
            this.pbcPrinterBrand.ReadOnly = false;
            this.pbcPrinterBrand.Size = new System.Drawing.Size(226, 22);
            this.pbcPrinterBrand.TabIndex = 113;
            this.pbcPrinterBrand.Value = null;
            this.pbcPrinterBrand.ValueMember = "PrinterBrandId";
            // 
            // CustomerInfrastructurePrintersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CustomerInfrastructurePrintersControl";
            this.Size = new System.Drawing.Size(710, 413);
            ((System.ComponentModel.ISupportInitialize)(this.grdRelations)).EndInit();
            this.upnDetailButtons.ClientArea.ResumeLayout(false);
            this.upnDetailButtons.ResumeLayout(false);
            this.upnlSeparatorDeleteRelation.ResumeLayout(false);
            this.upnlSeparatorEditRelation.ResumeLayout(false);
            this.upnlSeparatorCreateRelation.ResumeLayout(false);
            this.upnlSeparatorDetailButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxDetDetail)).EndInit();
            this.gbxDetDetail.ResumeLayout(false);
            this.tabDetail.ResumeLayout(false);
            this.tabItmPrincipal.ResumeLayout(false);
            this.tabItmPrincipal.PerformLayout();
            this.upnlButtons.ClientArea.ResumeLayout(false);
            this.upnlButtons.ResumeLayout(false);
            this.upnlSeparatorSaveRelation.ResumeLayout(false);
            this.upnlSeparatorCancelRelation.ResumeLayout(false);
            this.upnlSeparatorButtons.ResumeLayout(false);
            this.upnlSeparatorViewRelation.ResumeLayout(false);
            this.upnlSeparatorCloseRelation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblSerialNumber;
        private Infragistics.Win.Misc.UltraLabel lblPrinterType;
        private Infragistics.Win.Misc.UltraLabel lblPrinterBrand;
        internal System.Windows.Forms.TextBox txtlSerialNumber;
        internal Choosers.PrinterBrandChooserControl pbcPrinterBrand;
        internal Choosers.PrinterTypeChooserControl ptcPrinterType;


    }
}
