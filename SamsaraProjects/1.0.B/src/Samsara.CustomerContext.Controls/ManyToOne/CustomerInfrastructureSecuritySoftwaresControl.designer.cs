﻿namespace Samsara.CustomerContext.Controls.ManyToOne
{
    partial class CustomerInfrastructureSecuritySoftwaresControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInfrastructureSecuritySoftwaresControl));
            Samsara.CustomerContext.Core.Parameters.SecuritySoftwareBrandParameters securitySoftwareBrandParameters1 = new Samsara.CustomerContext.Core.Parameters.SecuritySoftwareBrandParameters();
            Samsara.CustomerContext.Core.Parameters.SecuritySoftwareTypeParameters securitySoftwareTypeParameters1 = new Samsara.CustomerContext.Core.Parameters.SecuritySoftwareTypeParameters();
            this.lblSecuritySoftwareType = new Infragistics.Win.Misc.UltraLabel();
            this.lblSecuritySoftwareBrand = new Infragistics.Win.Misc.UltraLabel();
            this.uchkConsoleInstalled = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblNumberOfClients = new Infragistics.Win.Misc.UltraLabel();
            this.steNumberOfClients = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.ssbSecuritySoftwareBrand = new Samsara.CustomerContext.Controls.Choosers.SecuritySoftwareBrandChooserControl();
            this.sstcSecuritySoftwareType = new Samsara.CustomerContext.Controls.Choosers.SecuritySoftwareTypeChooserControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.uchkConsoleInstalled)).BeginInit();
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
            this.tabItmPrincipal.Controls.Add(this.sstcSecuritySoftwareType);
            this.tabItmPrincipal.Controls.Add(this.ssbSecuritySoftwareBrand);
            this.tabItmPrincipal.Controls.Add(this.steNumberOfClients);
            this.tabItmPrincipal.Controls.Add(this.uchkConsoleInstalled);
            this.tabItmPrincipal.Controls.Add(this.lblNumberOfClients);
            this.tabItmPrincipal.Controls.Add(this.lblSecuritySoftwareType);
            this.tabItmPrincipal.Controls.Add(this.lblSecuritySoftwareBrand);
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
            // lblSecuritySoftwareType
            // 
            this.lblSecuritySoftwareType.AutoSize = true;
            this.lblSecuritySoftwareType.Location = new System.Drawing.Point(13, 49);
            this.lblSecuritySoftwareType.Name = "lblSecuritySoftwareType";
            this.lblSecuritySoftwareType.Size = new System.Drawing.Size(29, 14);
            this.lblSecuritySoftwareType.TabIndex = 107;
            this.lblSecuritySoftwareType.Text = "Tipo:";
            // 
            // lblSecuritySoftwareBrand
            // 
            this.lblSecuritySoftwareBrand.AutoSize = true;
            this.lblSecuritySoftwareBrand.Location = new System.Drawing.Point(13, 22);
            this.lblSecuritySoftwareBrand.Name = "lblSecuritySoftwareBrand";
            this.lblSecuritySoftwareBrand.Size = new System.Drawing.Size(39, 14);
            this.lblSecuritySoftwareBrand.TabIndex = 106;
            this.lblSecuritySoftwareBrand.Text = "Marca:";
            // 
            // uchkConsoleInstalled
            // 
            this.uchkConsoleInstalled.AutoSize = true;
            this.uchkConsoleInstalled.Location = new System.Drawing.Point(347, 48);
            this.uchkConsoleInstalled.Name = "uchkConsoleInstalled";
            this.uchkConsoleInstalled.Size = new System.Drawing.Size(112, 17);
            this.uchkConsoleInstalled.TabIndex = 112;
            this.uchkConsoleInstalled.Text = "Consola Instalada";
            // 
            // lblNumberOfClients
            // 
            this.lblNumberOfClients.AutoSize = true;
            this.lblNumberOfClients.Location = new System.Drawing.Point(347, 22);
            this.lblNumberOfClients.Name = "lblNumberOfClients";
            this.lblNumberOfClients.Size = new System.Drawing.Size(95, 14);
            this.lblNumberOfClients.TabIndex = 110;
            this.lblNumberOfClients.Text = "Número Usuarios:";
            // 
            // steNumberOfClients
            // 
            this.steNumberOfClients.CustomParent = null;
            this.steNumberOfClients.Location = new System.Drawing.Point(448, 18);
            this.steNumberOfClients.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.NaturalQuantity;
            this.steNumberOfClients.Name = "steNumberOfClients";
            this.steNumberOfClients.ReadOnly = false;
            this.steNumberOfClients.Size = new System.Drawing.Size(226, 20);
            this.steNumberOfClients.TabIndex = 113;
            this.steNumberOfClients.Value = ((object)(resources.GetObject("steNumberOfClients.Value")));
            // 
            // ssbSecuritySoftwareBrand
            // 
            this.ssbSecuritySoftwareBrand.CustomParent = null;
            this.ssbSecuritySoftwareBrand.DisplayMember = "Name";
            this.ssbSecuritySoftwareBrand.Location = new System.Drawing.Point(88, 17);
            this.ssbSecuritySoftwareBrand.Name = "ssbSecuritySoftwareBrand";
            securitySoftwareBrandParameters1.Description = null;
            securitySoftwareBrandParameters1.Name = null;
            securitySoftwareBrandParameters1.SecuritySoftwareBrandId = null;
            this.ssbSecuritySoftwareBrand.Parameters = securitySoftwareBrandParameters1;
            this.ssbSecuritySoftwareBrand.ReadOnly = false;
            this.ssbSecuritySoftwareBrand.Size = new System.Drawing.Size(226, 22);
            this.ssbSecuritySoftwareBrand.TabIndex = 114;
            this.ssbSecuritySoftwareBrand.Value = null;
            this.ssbSecuritySoftwareBrand.ValueMember = "SecuritySoftwareBrandId";
            // 
            // sstcSecuritySoftwareType
            // 
            this.sstcSecuritySoftwareType.CustomParent = null;
            this.sstcSecuritySoftwareType.DisplayMember = "Name";
            this.sstcSecuritySoftwareType.Location = new System.Drawing.Point(88, 45);
            this.sstcSecuritySoftwareType.Name = "sstcSecuritySoftwareType";
            securitySoftwareTypeParameters1.Description = null;
            securitySoftwareTypeParameters1.Name = null;
            securitySoftwareTypeParameters1.SecuritySoftwareTypeId = null;
            this.sstcSecuritySoftwareType.Parameters = securitySoftwareTypeParameters1;
            this.sstcSecuritySoftwareType.ReadOnly = false;
            this.sstcSecuritySoftwareType.Size = new System.Drawing.Size(226, 22);
            this.sstcSecuritySoftwareType.TabIndex = 115;
            this.sstcSecuritySoftwareType.Value = null;
            this.sstcSecuritySoftwareType.ValueMember = "SecuritySoftwareTypeId";
            // 
            // CustomerInfrastructureSecuritySoftwaresControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CustomerInfrastructureSecuritySoftwaresControl";
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
            ((System.ComponentModel.ISupportInitialize)(this.uchkConsoleInstalled)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblSecuritySoftwareType;
        private Infragistics.Win.Misc.UltraLabel lblSecuritySoftwareBrand;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor uchkConsoleInstalled;
        private Infragistics.Win.Misc.UltraLabel lblNumberOfClients;
        internal Samsara.Base.Controls.Controls.SamsaraTextEditor steNumberOfClients;
        internal Choosers.SecuritySoftwareTypeChooserControl sstcSecuritySoftwareType;
        internal Choosers.SecuritySoftwareBrandChooserControl ssbSecuritySoftwareBrand;


    }
}
