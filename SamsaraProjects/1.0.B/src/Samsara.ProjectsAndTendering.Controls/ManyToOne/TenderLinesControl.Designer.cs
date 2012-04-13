
namespace Samsara.ProjectsAndTendering.Controls.ManyToOne
{
    partial class TenderLinesControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenderLinesControl));
            this.lblConcept = new Infragistics.Win.Misc.UltraLabel();
            this.lblQuantity = new Infragistics.Win.Misc.UltraLabel();
            this.txtQuantity = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.lblProduct = new Infragistics.Win.Misc.UltraLabel();
            this.pscProduct = new Samsara.AlleatoERP.Controls.Search.ProductSearchControl();
            this.ugbxConcept = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtConcept = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTenderLineNumber = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
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
            ((System.ComponentModel.ISupportInitialize)(this.ugbxConcept)).BeginInit();
            this.ugbxConcept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcept)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.grdRelations.DisplayLayout.GroupByBox.Prompt = "Arrastre un encabezado de la columna aquí para agrupar por esa columna";
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
            this.grdRelations.Size = new System.Drawing.Size(560, 152);
            // 
            // upnDetailButtons
            // 
            this.upnDetailButtons.Location = new System.Drawing.Point(0, 152);
            this.upnDetailButtons.Size = new System.Drawing.Size(560, 25);
            // 
            // upnlSeparatorDeleteRelation
            // 
            this.upnlSeparatorDeleteRelation.Location = new System.Drawing.Point(172, 0);
            // 
            // ubtnDeleteRelation
            // 
            this.ubtnDeleteRelation.Location = new System.Drawing.Point(188, 0);
            // 
            // upnlSeparatorEditRelation
            // 
            this.upnlSeparatorEditRelation.Location = new System.Drawing.Point(265, 0);
            // 
            // ubtnEditRelation
            // 
            this.ubtnEditRelation.Location = new System.Drawing.Point(281, 0);
            // 
            // upnlSeparatorCreateRelation
            // 
            this.upnlSeparatorCreateRelation.Location = new System.Drawing.Point(451, 0);
            // 
            // ubtnCreateRelation
            // 
            this.ubtnCreateRelation.Location = new System.Drawing.Point(467, 0);
            // 
            // upnlSeparatorDetailButtons
            // 
            this.upnlSeparatorDetailButtons.Location = new System.Drawing.Point(544, 0);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Location = new System.Drawing.Point(0, 177);
            this.gbxDetDetail.Size = new System.Drawing.Size(560, 211);
            // 
            // tabDetail
            // 
            this.tabDetail.Size = new System.Drawing.Size(554, 192);
            // 
            // tabItmPrincipal
            // 
            this.tabItmPrincipal.Controls.Add(this.ugbxConcept);
            this.tabItmPrincipal.Controls.Add(this.panel1);
            this.tabItmPrincipal.Size = new System.Drawing.Size(546, 166);
            // 
            // upnlButtons
            // 
            this.upnlButtons.Location = new System.Drawing.Point(0, 388);
            this.upnlButtons.Size = new System.Drawing.Size(560, 25);
            // 
            // upnlSeparatorSaveRelation
            // 
            this.upnlSeparatorSaveRelation.Location = new System.Drawing.Point(358, 0);
            // 
            // ubtnSaveRelation
            // 
            this.ubtnSaveRelation.Location = new System.Drawing.Point(374, 0);
            // 
            // upnlSeparatorCancelRelation
            // 
            this.upnlSeparatorCancelRelation.Location = new System.Drawing.Point(451, 0);
            // 
            // ubtnCancelRelation
            // 
            this.ubtnCancelRelation.Location = new System.Drawing.Point(467, 0);
            // 
            // upnlSeparatorButtons
            // 
            this.upnlSeparatorButtons.Location = new System.Drawing.Point(544, 0);
            // 
            // upnlSeparatorViewRelation
            // 
            this.upnlSeparatorViewRelation.Location = new System.Drawing.Point(358, 0);
            // 
            // ubtnViewRelation
            // 
            this.ubtnViewRelation.Location = new System.Drawing.Point(374, 0);
            // 
            // upnlSeparatorCloseRelation
            // 
            this.upnlSeparatorCloseRelation.Location = new System.Drawing.Point(265, 0);
            // 
            // ubtnCloseRelation
            // 
            this.ubtnCloseRelation.Location = new System.Drawing.Point(281, 0);
            // 
            // lblConcept
            // 
            this.lblConcept.AutoSize = true;
            this.lblConcept.Location = new System.Drawing.Point(12, 12);
            this.lblConcept.Name = "lblConcept";
            this.lblConcept.Size = new System.Drawing.Size(43, 14);
            this.lblConcept.TabIndex = 107;
            this.lblConcept.Text = "Partida:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 38);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(53, 14);
            this.lblQuantity.TabIndex = 106;
            this.lblQuantity.Text = "Cantidad:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.CustomParent = null;
            this.txtQuantity.Location = new System.Drawing.Point(87, 35);
            this.txtQuantity.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.NaturalQuantity;
            this.txtQuantity.MeasurementFileUnit = "MB";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = false;
            this.txtQuantity.Size = new System.Drawing.Size(96, 20);
            this.txtQuantity.TabIndex = 113;
            this.txtQuantity.Value = ((object)(resources.GetObject("txtQuantity.Value")));
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(12, 65);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(53, 14);
            this.lblProduct.TabIndex = 106;
            this.lblProduct.Text = "Producto:";
            // 
            // pscProduct
            // 
            this.pscProduct.Location = new System.Drawing.Point(87, 61);
            this.pscProduct.Name = "pscProduct";
            this.pscProduct.ReadOnly = false;
            this.pscProduct.Size = new System.Drawing.Size(336, 24);
            this.pscProduct.TabIndex = 114;
            this.pscProduct.Value = null;
            // 
            // ugbxConcept
            // 
            this.ugbxConcept.Controls.Add(this.txtConcept);
            this.ugbxConcept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugbxConcept.Location = new System.Drawing.Point(3, 94);
            this.ugbxConcept.Name = "ugbxConcept";
            this.ugbxConcept.Size = new System.Drawing.Size(540, 69);
            this.ugbxConcept.TabIndex = 115;
            this.ugbxConcept.Text = "Concepto:";
            // 
            // txtConcept
            // 
            this.txtConcept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConcept.Location = new System.Drawing.Point(3, 16);
            this.txtConcept.Multiline = true;
            this.txtConcept.Name = "txtConcept";
            this.txtConcept.Size = new System.Drawing.Size(534, 50);
            this.txtConcept.TabIndex = 112;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblConcept);
            this.panel1.Controls.Add(this.lblQuantity);
            this.panel1.Controls.Add(this.pscProduct);
            this.panel1.Controls.Add(this.lblProduct);
            this.panel1.Controls.Add(this.txtTenderLineNumber);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 91);
            this.panel1.TabIndex = 116;
            // 
            // txtTenderLineNumber
            // 
            this.txtTenderLineNumber.CustomParent = null;
            this.txtTenderLineNumber.Location = new System.Drawing.Point(87, 9);
            this.txtTenderLineNumber.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.NaturalQuantity;
            this.txtTenderLineNumber.MeasurementFileUnit = "MB";
            this.txtTenderLineNumber.Name = "txtTenderLineNumber";
            this.txtTenderLineNumber.ReadOnly = false;
            this.txtTenderLineNumber.Size = new System.Drawing.Size(96, 20);
            this.txtTenderLineNumber.TabIndex = 113;
            this.txtTenderLineNumber.Value = ((object)(resources.GetObject("txtTenderLineNumber.Value")));
            // 
            // TenderLinesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TenderLinesControl";
            this.Size = new System.Drawing.Size(560, 413);
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
            this.upnlButtons.ClientArea.ResumeLayout(false);
            this.upnlButtons.ResumeLayout(false);
            this.upnlSeparatorSaveRelation.ResumeLayout(false);
            this.upnlSeparatorCancelRelation.ResumeLayout(false);
            this.upnlSeparatorButtons.ResumeLayout(false);
            this.upnlSeparatorViewRelation.ResumeLayout(false);
            this.upnlSeparatorCloseRelation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbxConcept)).EndInit();
            this.ugbxConcept.ResumeLayout(false);
            this.ugbxConcept.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcept)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblConcept;
        private Infragistics.Win.Misc.UltraLabel lblQuantity;
        internal Samsara.Base.Controls.Controls.SamsaraTextEditor txtQuantity;
        private Infragistics.Win.Misc.UltraLabel lblProduct;
        internal Samsara.AlleatoERP.Controls.Search.ProductSearchControl pscProduct;
        private Infragistics.Win.Misc.UltraGroupBox ugbxConcept;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtConcept;
        private System.Windows.Forms.Panel panel1;
        internal Base.Controls.Controls.SamsaraTextEditor txtTenderLineNumber;
    }
}
