
namespace Samsara.CustomerContext.Controls.Controls.ManyToOne
{
    partial class CustomerInfrastructureNetworkWifiAccessPointsControl
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
            Samsara.CustomerContext.Core.Parameters.AccessPointBrandParameters accessPointBrandParameters1 = new Samsara.CustomerContext.Core.Parameters.AccessPointBrandParameters();
            Samsara.CustomerContext.Core.Parameters.AccessPointTypeParameters accessPointTypeParameters1 = new Samsara.CustomerContext.Core.Parameters.AccessPointTypeParameters();
            this.lblAccessPointType = new Infragistics.Win.Misc.UltraLabel();
            this.lblAccessPointBrand = new Infragistics.Win.Misc.UltraLabel();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblModel = new Infragistics.Win.Misc.UltraLabel();
            this.lblBandWidth = new Infragistics.Win.Misc.UltraLabel();
            this.txtBandWidth = new System.Windows.Forms.TextBox();
            this.lblDistance = new Infragistics.Win.Misc.UltraLabel();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.apbcAccessPointBrand = new Samsara.CustomerContext.Controls.Controls.Choosers.AccessPointBrandChooserControl();
            this.aptcAccessPointType = new Samsara.CustomerContext.Controls.Controls.Choosers.AccessPointTypeChooserControl();
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
            this.grdRelations.Size = new System.Drawing.Size(710, 233);
            // 
            // upnDetailButtons
            // 
            this.upnDetailButtons.Location = new System.Drawing.Point(0, 233);
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
            this.gbxDetDetail.Location = new System.Drawing.Point(0, 258);
            this.gbxDetDetail.Size = new System.Drawing.Size(710, 130);
            // 
            // tabDetail
            // 
            this.tabDetail.Size = new System.Drawing.Size(704, 111);
            // 
            // tabItmPrincipal
            // 
            this.tabItmPrincipal.Controls.Add(this.aptcAccessPointType);
            this.tabItmPrincipal.Controls.Add(this.apbcAccessPointBrand);
            this.tabItmPrincipal.Controls.Add(this.txtDistance);
            this.tabItmPrincipal.Controls.Add(this.lblDistance);
            this.tabItmPrincipal.Controls.Add(this.txtBandWidth);
            this.tabItmPrincipal.Controls.Add(this.lblBandWidth);
            this.tabItmPrincipal.Controls.Add(this.txtModel);
            this.tabItmPrincipal.Controls.Add(this.lblModel);
            this.tabItmPrincipal.Controls.Add(this.lblAccessPointType);
            this.tabItmPrincipal.Controls.Add(this.lblAccessPointBrand);
            this.tabItmPrincipal.Size = new System.Drawing.Size(696, 85);
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
            // lblAccessPointType
            // 
            this.lblAccessPointType.AutoSize = true;
            this.lblAccessPointType.Location = new System.Drawing.Point(12, 49);
            this.lblAccessPointType.Name = "lblAccessPointType";
            this.lblAccessPointType.Size = new System.Drawing.Size(29, 14);
            this.lblAccessPointType.TabIndex = 107;
            this.lblAccessPointType.Text = "Tipo:";
            // 
            // lblAccessPointBrand
            // 
            this.lblAccessPointBrand.AutoSize = true;
            this.lblAccessPointBrand.Location = new System.Drawing.Point(12, 22);
            this.lblAccessPointBrand.Name = "lblAccessPointBrand";
            this.lblAccessPointBrand.Size = new System.Drawing.Size(39, 14);
            this.lblAccessPointBrand.TabIndex = 106;
            this.lblAccessPointBrand.Text = "Marca:";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(439, 6);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(226, 20);
            this.txtModel.TabIndex = 113;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(343, 9);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(45, 14);
            this.lblModel.TabIndex = 112;
            this.lblModel.Text = "Modelo:";
            // 
            // lblBandWidth
            // 
            this.lblBandWidth.AutoSize = true;
            this.lblBandWidth.Location = new System.Drawing.Point(343, 35);
            this.lblBandWidth.Name = "lblBandWidth";
            this.lblBandWidth.Size = new System.Drawing.Size(91, 14);
            this.lblBandWidth.TabIndex = 112;
            this.lblBandWidth.Text = "Ancho de Banda:";
            // 
            // txtBandWidth
            // 
            this.txtBandWidth.Location = new System.Drawing.Point(439, 32);
            this.txtBandWidth.Name = "txtBandWidth";
            this.txtBandWidth.Size = new System.Drawing.Size(226, 20);
            this.txtBandWidth.TabIndex = 113;
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(343, 61);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(54, 14);
            this.lblDistance.TabIndex = 112;
            this.lblDistance.Text = "Distancia:";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(439, 58);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(226, 20);
            this.txtDistance.TabIndex = 113;
            // 
            // apbcAccessPointBrand
            // 
            this.apbcAccessPointBrand.CustomParent = null;
            this.apbcAccessPointBrand.DisplayMember = "Name";
            this.apbcAccessPointBrand.Location = new System.Drawing.Point(87, 17);
            this.apbcAccessPointBrand.Name = "apbcAccessPointBrand";
            accessPointBrandParameters1.AccessPointBrandId = null;
            accessPointBrandParameters1.Description = null;
            accessPointBrandParameters1.Name = null;
            this.apbcAccessPointBrand.Parameters = accessPointBrandParameters1;
            this.apbcAccessPointBrand.ReadOnly = false;
            this.apbcAccessPointBrand.Size = new System.Drawing.Size(226, 22);
            this.apbcAccessPointBrand.TabIndex = 114;
            this.apbcAccessPointBrand.Value = null;
            this.apbcAccessPointBrand.ValueMember = "AccessPointBrandId";
            // 
            // aptcAccessPointType
            // 
            this.aptcAccessPointType.CustomParent = null;
            this.aptcAccessPointType.DisplayMember = "Name";
            this.aptcAccessPointType.Location = new System.Drawing.Point(87, 45);
            this.aptcAccessPointType.Name = "aptcAccessPointType";
            accessPointTypeParameters1.AccessPointTypeId = null;
            accessPointTypeParameters1.Description = null;
            accessPointTypeParameters1.Name = null;
            this.aptcAccessPointType.Parameters = accessPointTypeParameters1;
            this.aptcAccessPointType.ReadOnly = false;
            this.aptcAccessPointType.Size = new System.Drawing.Size(226, 22);
            this.aptcAccessPointType.TabIndex = 115;
            this.aptcAccessPointType.Value = null;
            this.aptcAccessPointType.ValueMember = "AccessPointTypeId";
            // 
            // CustomerInfrastructureNetworkWifiAccessPointsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CustomerInfrastructureNetworkWifiAccessPointsControl";
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

        private Infragistics.Win.Misc.UltraLabel lblAccessPointType;
        private Infragistics.Win.Misc.UltraLabel lblAccessPointBrand;
        internal System.Windows.Forms.TextBox txtDistance;
        private Infragistics.Win.Misc.UltraLabel lblDistance;
        internal System.Windows.Forms.TextBox txtBandWidth;
        private Infragistics.Win.Misc.UltraLabel lblBandWidth;
        internal System.Windows.Forms.TextBox txtModel;
        private Infragistics.Win.Misc.UltraLabel lblModel;
        internal Choosers.AccessPointTypeChooserControl aptcAccessPointType;
        internal Choosers.AccessPointBrandChooserControl apbcAccessPointBrand;


    }
}
