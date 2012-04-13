
namespace Samsara.CustomerContext.Controls.ManyToOne
{
    partial class CustomerInfrastructureNetworkCommutatorsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInfrastructureNetworkCommutatorsControl));
            Samsara.CustomerContext.Core.Parameters.CommutatorTypeParameters commutatorTypeParameters1 = new Samsara.CustomerContext.Core.Parameters.CommutatorTypeParameters();
            Samsara.CustomerContext.Core.Parameters.CommutatorBrandParameters commutatorBrandParameters1 = new Samsara.CustomerContext.Core.Parameters.CommutatorBrandParameters();
            this.lblCommutatorType = new Infragistics.Win.Misc.UltraLabel();
            this.lblCommutatorBrand = new Infragistics.Win.Misc.UltraLabel();
            this.lblNumberOfLines = new Infragistics.Win.Misc.UltraLabel();
            this.lblNumberOfTrunks = new Infragistics.Win.Misc.UltraLabel();
            this.steNumberOfTrunks = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.steNumberOfExtensions = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.ctcCommutatorType = new Samsara.CustomerContext.Controls.Choosers.CommutatorTypeChooserControl();
            this.cbcCommutatorBrand = new Samsara.CustomerContext.Controls.Choosers.CommutatorBrandChooserControl();
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
            this.grdRelations.Size = new System.Drawing.Size(710, 239);
            // 
            // upnDetailButtons
            // 
            this.upnDetailButtons.Location = new System.Drawing.Point(0, 239);
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
            this.gbxDetDetail.Location = new System.Drawing.Point(0, 264);
            this.gbxDetDetail.Size = new System.Drawing.Size(710, 124);
            // 
            // tabDetail
            // 
            this.tabDetail.Size = new System.Drawing.Size(704, 105);
            // 
            // tabItmPrincipal
            // 
            this.tabItmPrincipal.Controls.Add(this.cbcCommutatorBrand);
            this.tabItmPrincipal.Controls.Add(this.ctcCommutatorType);
            this.tabItmPrincipal.Controls.Add(this.steNumberOfExtensions);
            this.tabItmPrincipal.Controls.Add(this.steNumberOfTrunks);
            this.tabItmPrincipal.Controls.Add(this.lblCommutatorType);
            this.tabItmPrincipal.Controls.Add(this.lblNumberOfTrunks);
            this.tabItmPrincipal.Controls.Add(this.lblNumberOfLines);
            this.tabItmPrincipal.Controls.Add(this.lblCommutatorBrand);
            this.tabItmPrincipal.Size = new System.Drawing.Size(696, 79);
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
            // lblCommutatorType
            // 
            this.lblCommutatorType.AutoSize = true;
            this.lblCommutatorType.Location = new System.Drawing.Point(13, 49);
            this.lblCommutatorType.Name = "lblCommutatorType";
            this.lblCommutatorType.Size = new System.Drawing.Size(29, 14);
            this.lblCommutatorType.TabIndex = 107;
            this.lblCommutatorType.Text = "Tipo:";
            // 
            // lblCommutatorBrand
            // 
            this.lblCommutatorBrand.AutoSize = true;
            this.lblCommutatorBrand.Location = new System.Drawing.Point(13, 22);
            this.lblCommutatorBrand.Name = "lblCommutatorBrand";
            this.lblCommutatorBrand.Size = new System.Drawing.Size(39, 14);
            this.lblCommutatorBrand.TabIndex = 106;
            this.lblCommutatorBrand.Text = "Marca:";
            // 
            // lblNumberOfLines
            // 
            this.lblNumberOfLines.AutoSize = true;
            this.lblNumberOfLines.Location = new System.Drawing.Point(332, 48);
            this.lblNumberOfLines.Name = "lblNumberOfLines";
            this.lblNumberOfLines.Size = new System.Drawing.Size(127, 14);
            this.lblNumberOfLines.TabIndex = 106;
            this.lblNumberOfLines.Text = "Número de extensiones:";
            // 
            // lblNumberOfTrunks
            // 
            this.lblNumberOfTrunks.AutoSize = true;
            this.lblNumberOfTrunks.Location = new System.Drawing.Point(332, 22);
            this.lblNumberOfTrunks.Name = "lblNumberOfTrunks";
            this.lblNumberOfTrunks.Size = new System.Drawing.Size(57, 14);
            this.lblNumberOfTrunks.TabIndex = 106;
            this.lblNumberOfTrunks.Text = "Troncales:";
            // 
            // steNumberOfTrunks
            // 
            this.steNumberOfTrunks.CustomParent = null;
            this.steNumberOfTrunks.Location = new System.Drawing.Point(461, 19);
            this.steNumberOfTrunks.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.NaturalQuantity;
            this.steNumberOfTrunks.Name = "steNumberOfTrunks";
            this.steNumberOfTrunks.ReadOnly = false;
            this.steNumberOfTrunks.Size = new System.Drawing.Size(226, 20);
            this.steNumberOfTrunks.TabIndex = 110;
            this.steNumberOfTrunks.Value = ((object)(resources.GetObject("steNumberOfTrunks.Value")));
            // 
            // steNumberOfExtensions
            // 
            this.steNumberOfExtensions.CustomParent = null;
            this.steNumberOfExtensions.Location = new System.Drawing.Point(461, 45);
            this.steNumberOfExtensions.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.NaturalQuantity;
            this.steNumberOfExtensions.Name = "steNumberOfExtensions";
            this.steNumberOfExtensions.ReadOnly = false;
            this.steNumberOfExtensions.Size = new System.Drawing.Size(226, 20);
            this.steNumberOfExtensions.TabIndex = 110;
            this.steNumberOfExtensions.Value = ((object)(resources.GetObject("steNumberOfExtensions.Value")));
            // 
            // ctcCommutatorType
            // 
            this.ctcCommutatorType.CustomParent = null;
            this.ctcCommutatorType.DisplayMember = "Name";
            this.ctcCommutatorType.Location = new System.Drawing.Point(88, 45);
            this.ctcCommutatorType.Name = "ctcCommutatorType";
            commutatorTypeParameters1.CommutatorTypeId = null;
            commutatorTypeParameters1.Description = null;
            commutatorTypeParameters1.Name = null;
            this.ctcCommutatorType.Parameters = commutatorTypeParameters1;
            this.ctcCommutatorType.ReadOnly = false;
            this.ctcCommutatorType.Size = new System.Drawing.Size(226, 22);
            this.ctcCommutatorType.TabIndex = 112;
            this.ctcCommutatorType.Value = null;
            this.ctcCommutatorType.ValueMember = "CommutatorTypeId";
            // 
            // cbcCommutatorBrand
            // 
            this.cbcCommutatorBrand.CustomParent = null;
            this.cbcCommutatorBrand.DisplayMember = "Name";
            this.cbcCommutatorBrand.Location = new System.Drawing.Point(88, 17);
            this.cbcCommutatorBrand.Name = "cbcCommutatorBrand";
            commutatorBrandParameters1.CommutatorBrandId = null;
            commutatorBrandParameters1.Description = null;
            commutatorBrandParameters1.Name = null;
            this.cbcCommutatorBrand.Parameters = commutatorBrandParameters1;
            this.cbcCommutatorBrand.ReadOnly = false;
            this.cbcCommutatorBrand.Size = new System.Drawing.Size(226, 22);
            this.cbcCommutatorBrand.TabIndex = 113;
            this.cbcCommutatorBrand.Value = null;
            this.cbcCommutatorBrand.ValueMember = "CommutatorBrandId";
            // 
            // CustomerInfrastructureNetworkCommutatorsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CustomerInfrastructureNetworkCommutatorsControl";
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

        private Infragistics.Win.Misc.UltraLabel lblCommutatorType;
        private Infragistics.Win.Misc.UltraLabel lblCommutatorBrand;
        private Infragistics.Win.Misc.UltraLabel lblNumberOfTrunks;
        private Infragistics.Win.Misc.UltraLabel lblNumberOfLines;
        internal Samsara.Base.Controls.Controls.SamsaraTextEditor steNumberOfExtensions;
        internal Samsara.Base.Controls.Controls.SamsaraTextEditor steNumberOfTrunks;
        internal Choosers.CommutatorTypeChooserControl ctcCommutatorType;
        internal Choosers.CommutatorBrandChooserControl cbcCommutatorBrand;


    }
}
