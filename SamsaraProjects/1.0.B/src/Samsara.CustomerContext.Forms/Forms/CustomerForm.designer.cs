
namespace Samsara.CustomerContext.Forms.Forms
{
    partial class CustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Samsara.CustomerContext.Core.Parameters.BusinessTypeParameters businessTypeParameters1 = new Samsara.CustomerContext.Core.Parameters.BusinessTypeParameters();
            this.txtSchName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ulblSchOrganizationName = new Infragistics.Win.Misc.UltraLabel();
            this.txtSchComercialName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ulblSchComercialName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraCheckEditor1 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraPanel4 = new Infragistics.Win.Misc.UltraPanel();
            this.samsaraTextEditor1 = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.samsaraTextEditor2 = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.ultraGroupBox4 = new Infragistics.Win.Misc.UltraGroupBox();
            this.samsaraTextEditor3 = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.ultraGroupBox5 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraCheckEditor2 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.samsaraTextEditor4 = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.ultraPanel5 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraTabControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage5 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl11 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraPanel6 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraGroupBox6 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraOptionSet1 = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraTabControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage6 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.tabCustomerDetail = new System.Windows.Forms.TabControl();
            this.tabItmDetPrincipal = new System.Windows.Forms.TabPage();
            this.tabItmDetInfraestructure = new System.Windows.Forms.TabPage();
            this.tabDetInfrastructure = new System.Windows.Forms.TabControl();
            this.tabItmDetComputers = new System.Windows.Forms.TabPage();
            this.tabDetInfraestructureComputers = new System.Windows.Forms.TabControl();
            this.tabItmDetPersonalComputers = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructurePersonalComputers = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructurePersonalComputersControl();
            this.tabItmDetServerComputers = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureServerComputers = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureServerComputersControl();
            this.tabItmDetNetwork = new System.Windows.Forms.TabPage();
            this.tabDetInfraestructureNetwork = new System.Windows.Forms.TabControl();
            this.tabItmNetworkSite = new System.Windows.Forms.TabPage();
            this.tabDetSite = new System.Windows.Forms.TabControl();
            this.tabItmSitePrincipal = new System.Windows.Forms.TabPage();
            this.gbxDetSiteDescription = new System.Windows.Forms.GroupBox();
            this.txtDetSiteDescription = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.gbxDetSiteCooling = new System.Windows.Forms.GroupBox();
            this.txtDetSiteCooling = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.gbxDetSiteIsolatedRoom = new System.Windows.Forms.GroupBox();
            this.txtDetSiteIsolatedRoom = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tabItmRacks = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureNetworkSiteRacks = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureNetworkSiteRacksControl();
            this.tabItmNetworkSwitches = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureNetworkSwitches = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureNetworkSwitchesControl();
            this.tabItmNetworkCommutators = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureNetworkCommutators = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureNetworkCommutatorsControl();
            this.tabItmNetworkCabling = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureNetworkCablings = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureNetworkCablingsControl();
            this.tabItmNetworkRouters = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureNetworkRouters = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureNetworkRoutersControl();
            this.tabItmNetworkFirewalls = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureNetworkFirewalls = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureNetworkFirewallsControl();
            this.tabItmNetworkWifi = new System.Windows.Forms.TabPage();
            this.tabDetAccessPoints = new System.Windows.Forms.TabControl();
            this.tabItmAccessPoints = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureNetworkWifiAccessPoints = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureNetworkWifiAccessPointsControl();
            this.tabItmDetEnergy = new System.Windows.Forms.TabPage();
            this.tabDetInfraestructureEnergy = new System.Windows.Forms.TabControl();
            this.tabItmEnergy = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureUPSs = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureUPSsControl();
            this.tabItmDetPeripherals = new System.Windows.Forms.TabPage();
            this.tabDetInfraestructurePeripherals = new System.Windows.Forms.TabControl();
            this.tabItmPeripherals = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructurePrinters = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructurePrintersControl();
            this.tabItmDetSoftware = new System.Windows.Forms.TabPage();
            this.tabDetInfraestructureSoftware = new System.Windows.Forms.TabControl();
            this.tabItmDetAdministrationSoftware = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureAdministationSoftwares = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureAdministationSoftwaresControl();
            this.tabItmDetSecuritySoftware = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureSecuritySoftwares = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureSecuritySoftwaresControl();
            this.tabItmDetBackupSoftware = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureBackupSoftwares = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureBackupSoftwaresControl();
            this.tabItmDetSuppliers = new System.Windows.Forms.TabPage();
            this.tabDetInfraestructureSuppliers = new System.Windows.Forms.TabControl();
            this.tabItmDetISP = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureISPs = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureISPsControl();
            this.tabItmDetTelephony = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureTelephonies = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureTelephoniesControl();
            this.tabItmDetVideo = new System.Windows.Forms.TabPage();
            this.tabDetInfraestructureVideo = new System.Windows.Forms.TabControl();
            this.tabItmDetCCTV = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureCCTVs = new Samsara.CustomerContext.Controls.ManyToOne.CustomerInfrastructureCCTVsControl();
            this.tabItmPrincipal = new System.Windows.Forms.TabPage();
            this.txtDetTrainingAndCourses = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.gbxDetTrainingAndCourses = new System.Windows.Forms.GroupBox();
            this.txtDetGroundedOutlet = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.gbxDetGroundedOutlet = new System.Windows.Forms.GroupBox();
            this.btcDetBusinessType = new Samsara.CustomerContext.Controls.Choosers.BusinessTypeChooserControl();
            this.lblDetName = new System.Windows.Forms.Label();
            this.lblDetBusinessType = new System.Windows.Forms.Label();
            this.txtDetComercialName = new System.Windows.Forms.TextBox();
            this.txtDetName = new System.Windows.Forms.TextBox();
            this.lblDetComercialName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).BeginInit();
            this.gbxSchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            this.pnlDetButtons.SuspendLayout();
            this.upSeparatorAccept.SuspendLayout();
            this.upSchSeparatorClose.SuspendLayout();
            this.upSchSeparatorDelete.SuspendLayout();
            this.upSchSeparatorEdit.SuspendLayout();
            this.upSchSeparatorCreate.SuspendLayout();
            this.upSchSeparatorBottons.SuspendLayout();
            this.upSchSeparatorShowDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchComercialName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCheckEditor1)).BeginInit();
            this.ultraPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).BeginInit();
            this.ultraGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).BeginInit();
            this.ultraGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCheckEditor2)).BeginInit();
            this.ultraPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl2)).BeginInit();
            this.ultraTabControl2.SuspendLayout();
            this.ultraPanel6.ClientArea.SuspendLayout();
            this.ultraPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).BeginInit();
            this.ultraGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl3)).BeginInit();
            this.tabCustomerDetail.SuspendLayout();
            this.tabItmDetPrincipal.SuspendLayout();
            this.tabItmDetInfraestructure.SuspendLayout();
            this.tabDetInfrastructure.SuspendLayout();
            this.tabItmDetComputers.SuspendLayout();
            this.tabDetInfraestructureComputers.SuspendLayout();
            this.tabItmDetPersonalComputers.SuspendLayout();
            this.tabItmDetServerComputers.SuspendLayout();
            this.tabItmDetNetwork.SuspendLayout();
            this.tabDetInfraestructureNetwork.SuspendLayout();
            this.tabItmNetworkSite.SuspendLayout();
            this.tabDetSite.SuspendLayout();
            this.tabItmSitePrincipal.SuspendLayout();
            this.gbxDetSiteDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetSiteDescription)).BeginInit();
            this.gbxDetSiteCooling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetSiteCooling)).BeginInit();
            this.gbxDetSiteIsolatedRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetSiteIsolatedRoom)).BeginInit();
            this.tabItmRacks.SuspendLayout();
            this.tabItmNetworkSwitches.SuspendLayout();
            this.tabItmNetworkCommutators.SuspendLayout();
            this.tabItmNetworkCabling.SuspendLayout();
            this.tabItmNetworkRouters.SuspendLayout();
            this.tabItmNetworkFirewalls.SuspendLayout();
            this.tabItmNetworkWifi.SuspendLayout();
            this.tabDetAccessPoints.SuspendLayout();
            this.tabItmAccessPoints.SuspendLayout();
            this.tabItmDetEnergy.SuspendLayout();
            this.tabDetInfraestructureEnergy.SuspendLayout();
            this.tabItmEnergy.SuspendLayout();
            this.tabItmDetPeripherals.SuspendLayout();
            this.tabDetInfraestructurePeripherals.SuspendLayout();
            this.tabItmPeripherals.SuspendLayout();
            this.tabItmDetSoftware.SuspendLayout();
            this.tabDetInfraestructureSoftware.SuspendLayout();
            this.tabItmDetAdministrationSoftware.SuspendLayout();
            this.tabItmDetSecuritySoftware.SuspendLayout();
            this.tabItmDetBackupSoftware.SuspendLayout();
            this.tabItmDetSuppliers.SuspendLayout();
            this.tabDetInfraestructureSuppliers.SuspendLayout();
            this.tabItmDetISP.SuspendLayout();
            this.tabItmDetTelephony.SuspendLayout();
            this.tabItmDetVideo.SuspendLayout();
            this.tabDetInfraestructureVideo.SuspendLayout();
            this.tabItmDetCCTV.SuspendLayout();
            this.tabItmPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetTrainingAndCourses)).BeginInit();
            this.gbxDetTrainingAndCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetGroundedOutlet)).BeginInit();
            this.gbxDetGroundedOutlet.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPrincipal
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdPrincipal.DisplayLayout.Appearance = appearance1;
            this.grdPrincipal.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdPrincipal.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdPrincipal.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdPrincipal.DisplayLayout.GroupByBox.Prompt = "Arrastre un encabezado de la columna aquí para agrupar por esa columna";
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
            this.grdPrincipal.Location = new System.Drawing.Point(0, 101);
            this.grdPrincipal.Size = new System.Drawing.Size(977, 363);
            // 
            // btnSchClear
            // 
            this.btnSchClear.Location = new System.Drawing.Point(795, 0);
            // 
            // btnSchSearch
            // 
            this.btnSchSearch.Location = new System.Drawing.Point(886, 0);
            // 
            // gbxSchParameters
            // 
            this.gbxSchParameters.Controls.Add(this.txtSchComercialName);
            this.gbxSchParameters.Controls.Add(this.ulblSchComercialName);
            this.gbxSchParameters.Controls.Add(this.txtSchName);
            this.gbxSchParameters.Controls.Add(this.ulblSchOrganizationName);
            this.gbxSchParameters.Size = new System.Drawing.Size(977, 76);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.tabCustomerDetail);
            this.gbxDetDetail.Size = new System.Drawing.Size(977, 484);
            this.gbxDetDetail.TabIndex = 0;
            // 
            // pnlDetButtons
            // 
            this.pnlDetButtons.Location = new System.Drawing.Point(0, 484);
            this.pnlDetButtons.Size = new System.Drawing.Size(977, 25);
            this.pnlDetButtons.TabIndex = 1;
            // 
            // btnDetSave
            // 
            this.btnDetSave.Location = new System.Drawing.Point(704, 0);
            // 
            // btnDetCancel
            // 
            this.btnDetCancel.Location = new System.Drawing.Point(886, 0);
            // 
            // btnDetBackToSearch
            // 
            this.btnDetBackToSearch.Location = new System.Drawing.Point(795, 0);
            // 
            // btnSchAccept
            // 
            this.btnSchAccept.Location = new System.Drawing.Point(431, 0);
            // 
            // btnSchClose
            // 
            this.btnSchClose.Location = new System.Drawing.Point(522, 0);
            // 
            // btnSchDelete
            // 
            this.btnSchDelete.Location = new System.Drawing.Point(613, 0);
            // 
            // btnSchEdit
            // 
            this.btnSchEdit.Location = new System.Drawing.Point(795, 0);
            // 
            // btnSchCreate
            // 
            this.btnSchCreate.Location = new System.Drawing.Point(886, 0);
            // 
            // btnSchShowDetail
            // 
            this.btnSchShowDetail.Location = new System.Drawing.Point(704, 0);
            // 
            // upSeparatorAccept
            // 
            this.upSeparatorAccept.Location = new System.Drawing.Point(415, 0);
            // 
            // upSchSeparatorClose
            // 
            this.upSchSeparatorClose.Location = new System.Drawing.Point(506, 0);
            // 
            // upSchSeparatorDelete
            // 
            this.upSchSeparatorDelete.Location = new System.Drawing.Point(597, 0);
            // 
            // upSchSeparatorEdit
            // 
            this.upSchSeparatorEdit.Location = new System.Drawing.Point(779, 0);
            // 
            // upSchSeparatorCreate
            // 
            this.upSchSeparatorCreate.Location = new System.Drawing.Point(870, 0);
            // 
            // upSchSeparatorBottons
            // 
            this.upSchSeparatorBottons.Location = new System.Drawing.Point(961, 0);
            // 
            // upSchSeparatorShowDetail
            // 
            this.upSchSeparatorShowDetail.Location = new System.Drawing.Point(688, 0);
            // 
            // txtSchName
            // 
            this.txtSchName.Location = new System.Drawing.Point(114, 19);
            this.txtSchName.Name = "txtSchName";
            this.txtSchName.Size = new System.Drawing.Size(283, 21);
            this.txtSchName.TabIndex = 2;
            // 
            // ulblSchOrganizationName
            // 
            this.ulblSchOrganizationName.AutoSize = true;
            this.ulblSchOrganizationName.Location = new System.Drawing.Point(59, 23);
            this.ulblSchOrganizationName.Name = "ulblSchOrganizationName";
            this.ulblSchOrganizationName.Size = new System.Drawing.Size(48, 14);
            this.ulblSchOrganizationName.TabIndex = 1;
            this.ulblSchOrganizationName.Text = "Nombre:";
            // 
            // txtSchComercialName
            // 
            this.txtSchComercialName.Location = new System.Drawing.Point(114, 46);
            this.txtSchComercialName.Name = "txtSchComercialName";
            this.txtSchComercialName.Size = new System.Drawing.Size(283, 21);
            this.txtSchComercialName.TabIndex = 4;
            // 
            // ulblSchComercialName
            // 
            this.ulblSchComercialName.AutoSize = true;
            this.ulblSchComercialName.Location = new System.Drawing.Point(6, 50);
            this.ulblSchComercialName.Name = "ulblSchComercialName";
            this.ulblSchComercialName.Size = new System.Drawing.Size(102, 14);
            this.ulblSchComercialName.TabIndex = 3;
            this.ulblSchComercialName.Text = "Nombre Comercial:";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraTextEditor1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(332, 243);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(313, 42);
            this.ultraGroupBox1.TabIndex = 8;
            this.ultraGroupBox1.Text = "8.- Tiene alguna preferencia de marca?";
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTextEditor1.Location = new System.Drawing.Point(3, 16);
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.Size = new System.Drawing.Size(307, 21);
            this.ultraTextEditor1.TabIndex = 0;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.ultraCheckEditor1);
            this.ultraGroupBox2.Controls.Add(this.ultraPanel4);
            this.ultraGroupBox2.Controls.Add(this.samsaraTextEditor1);
            this.ultraGroupBox2.Location = new System.Drawing.Point(332, 57);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(313, 56);
            this.ultraGroupBox2.TabIndex = 5;
            this.ultraGroupBox2.Text = "5.- Tienen Pensado Crecer en el No. De usuarios en un plazo de 3 a 5 años?";
            // 
            // ultraCheckEditor1
            // 
            this.ultraCheckEditor1.AutoSize = true;
            this.ultraCheckEditor1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraCheckEditor1.Location = new System.Drawing.Point(61, 29);
            this.ultraCheckEditor1.Name = "ultraCheckEditor1";
            this.ultraCheckEditor1.Size = new System.Drawing.Size(31, 24);
            this.ultraCheckEditor1.TabIndex = 1;
            this.ultraCheckEditor1.Text = "Si";
            // 
            // ultraPanel4
            // 
            this.ultraPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraPanel4.Location = new System.Drawing.Point(3, 29);
            this.ultraPanel4.Name = "ultraPanel4";
            this.ultraPanel4.Size = new System.Drawing.Size(58, 24);
            this.ultraPanel4.TabIndex = 0;
            // 
            // samsaraTextEditor1
            // 
            this.samsaraTextEditor1.CustomParent = null;
            this.samsaraTextEditor1.Dock = System.Windows.Forms.DockStyle.Right;
            this.samsaraTextEditor1.Location = new System.Drawing.Point(192, 29);
            this.samsaraTextEditor1.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.NaturalQuantity;
            this.samsaraTextEditor1.MeasurementFileUnit = "GB";
            this.samsaraTextEditor1.Name = "samsaraTextEditor1";
            this.samsaraTextEditor1.ReadOnly = false;
            this.samsaraTextEditor1.Size = new System.Drawing.Size(118, 24);
            this.samsaraTextEditor1.TabIndex = 2;
            this.samsaraTextEditor1.Value = ((object)(resources.GetObject("samsaraTextEditor1.Value")));
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.samsaraTextEditor2);
            this.ultraGroupBox3.Location = new System.Drawing.Point(332, 9);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(313, 42);
            this.ultraGroupBox3.TabIndex = 4;
            this.ultraGroupBox3.Text = "4.- Numero de usuarios que accesarian al Servidor?";
            // 
            // samsaraTextEditor2
            // 
            this.samsaraTextEditor2.CustomParent = null;
            this.samsaraTextEditor2.Dock = System.Windows.Forms.DockStyle.Right;
            this.samsaraTextEditor2.Location = new System.Drawing.Point(192, 16);
            this.samsaraTextEditor2.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.NaturalQuantity;
            this.samsaraTextEditor2.MeasurementFileUnit = "GB";
            this.samsaraTextEditor2.Name = "samsaraTextEditor2";
            this.samsaraTextEditor2.ReadOnly = false;
            this.samsaraTextEditor2.Size = new System.Drawing.Size(118, 23);
            this.samsaraTextEditor2.TabIndex = 0;
            this.samsaraTextEditor2.Value = ((object)(resources.GetObject("samsaraTextEditor2.Value")));
            // 
            // ultraGroupBox4
            // 
            this.ultraGroupBox4.Controls.Add(this.samsaraTextEditor3);
            this.ultraGroupBox4.Location = new System.Drawing.Point(332, 119);
            this.ultraGroupBox4.Name = "ultraGroupBox4";
            this.ultraGroupBox4.Size = new System.Drawing.Size(313, 56);
            this.ultraGroupBox4.TabIndex = 6;
            this.ultraGroupBox4.Text = "6.- Cual es el tamaño de la Informacion actualmente (Espacio ocupado en DD)";
            // 
            // samsaraTextEditor3
            // 
            this.samsaraTextEditor3.CustomParent = null;
            this.samsaraTextEditor3.Dock = System.Windows.Forms.DockStyle.Right;
            this.samsaraTextEditor3.Location = new System.Drawing.Point(192, 29);
            this.samsaraTextEditor3.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.FileSize;
            this.samsaraTextEditor3.MeasurementFileUnit = "GB";
            this.samsaraTextEditor3.Name = "samsaraTextEditor3";
            this.samsaraTextEditor3.ReadOnly = false;
            this.samsaraTextEditor3.Size = new System.Drawing.Size(118, 24);
            this.samsaraTextEditor3.TabIndex = 0;
            this.samsaraTextEditor3.Value = ((object)(resources.GetObject("samsaraTextEditor3.Value")));
            // 
            // ultraGroupBox5
            // 
            this.ultraGroupBox5.Controls.Add(this.ultraCheckEditor2);
            this.ultraGroupBox5.Controls.Add(this.samsaraTextEditor4);
            this.ultraGroupBox5.Controls.Add(this.ultraPanel5);
            this.ultraGroupBox5.Location = new System.Drawing.Point(332, 181);
            this.ultraGroupBox5.Name = "ultraGroupBox5";
            this.ultraGroupBox5.Size = new System.Drawing.Size(313, 56);
            this.ultraGroupBox5.TabIndex = 7;
            this.ultraGroupBox5.Text = "7.- Cuanto tienen estimado crecer en el tamaño de la informacion en un plazo de 3" +
                " a 5 años?";
            // 
            // ultraCheckEditor2
            // 
            this.ultraCheckEditor2.AutoSize = true;
            this.ultraCheckEditor2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraCheckEditor2.Location = new System.Drawing.Point(61, 29);
            this.ultraCheckEditor2.Name = "ultraCheckEditor2";
            this.ultraCheckEditor2.Size = new System.Drawing.Size(31, 24);
            this.ultraCheckEditor2.TabIndex = 1;
            this.ultraCheckEditor2.Text = "Si";
            // 
            // samsaraTextEditor4
            // 
            this.samsaraTextEditor4.CustomParent = null;
            this.samsaraTextEditor4.Dock = System.Windows.Forms.DockStyle.Right;
            this.samsaraTextEditor4.Location = new System.Drawing.Point(192, 29);
            this.samsaraTextEditor4.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.FileSize;
            this.samsaraTextEditor4.MeasurementFileUnit = "GB";
            this.samsaraTextEditor4.Name = "samsaraTextEditor4";
            this.samsaraTextEditor4.ReadOnly = false;
            this.samsaraTextEditor4.Size = new System.Drawing.Size(118, 24);
            this.samsaraTextEditor4.TabIndex = 2;
            this.samsaraTextEditor4.Value = ((object)(resources.GetObject("samsaraTextEditor4.Value")));
            // 
            // ultraPanel5
            // 
            this.ultraPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraPanel5.Location = new System.Drawing.Point(3, 29);
            this.ultraPanel5.Name = "ultraPanel5";
            this.ultraPanel5.Size = new System.Drawing.Size(58, 24);
            this.ultraPanel5.TabIndex = 0;
            // 
            // ultraTabControl2
            // 
            this.ultraTabControl2.Controls.Add(this.ultraTabSharedControlsPage5);
            this.ultraTabControl2.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl2.Name = "ultraTabControl2";
            this.ultraTabControl2.SharedControlsPage = this.ultraTabSharedControlsPage5;
            this.ultraTabControl2.Size = new System.Drawing.Size(200, 100);
            this.ultraTabControl2.TabIndex = 0;
            // 
            // ultraTabSharedControlsPage5
            // 
            this.ultraTabSharedControlsPage5.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage5.Name = "ultraTabSharedControlsPage5";
            this.ultraTabSharedControlsPage5.Size = new System.Drawing.Size(196, 77);
            // 
            // ultraTabPageControl11
            // 
            this.ultraTabPageControl11.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl11.Name = "ultraTabPageControl11";
            this.ultraTabPageControl11.Size = new System.Drawing.Size(196, 77);
            // 
            // ultraPanel6
            // 
            // 
            // ultraPanel6.ClientArea
            // 
            this.ultraPanel6.ClientArea.Controls.Add(this.ultraGroupBox6);
            this.ultraPanel6.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel6.Name = "ultraPanel6";
            this.ultraPanel6.Size = new System.Drawing.Size(200, 100);
            this.ultraPanel6.TabIndex = 0;
            // 
            // ultraGroupBox6
            // 
            this.ultraGroupBox6.Controls.Add(this.ultraOptionSet1);
            this.ultraGroupBox6.Location = new System.Drawing.Point(5, 3);
            this.ultraGroupBox6.Name = "ultraGroupBox6";
            this.ultraGroupBox6.Size = new System.Drawing.Size(313, 59);
            this.ultraGroupBox6.TabIndex = 0;
            this.ultraGroupBox6.Text = "1.- Actualmente tiene un Servidor?";
            // 
            // ultraOptionSet1
            // 
            valueListItem10.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem10.DataValue = true;
            valueListItem10.DisplayText = "Si";
            valueListItem11.DataValue = false;
            valueListItem11.DisplayText = "No";
            this.ultraOptionSet1.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11});
            this.ultraOptionSet1.Location = new System.Drawing.Point(13, 19);
            this.ultraOptionSet1.Name = "ultraOptionSet1";
            this.ultraOptionSet1.Size = new System.Drawing.Size(39, 32);
            this.ultraOptionSet1.TabIndex = 0;
            // 
            // ultraTabControl3
            // 
            this.ultraTabControl3.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl3.Name = "ultraTabControl3";
            this.ultraTabControl3.SharedControlsPage = this.ultraTabSharedControlsPage6;
            this.ultraTabControl3.Size = new System.Drawing.Size(200, 100);
            this.ultraTabControl3.TabIndex = 0;
            // 
            // ultraTabSharedControlsPage6
            // 
            this.ultraTabSharedControlsPage6.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage6.Name = "ultraTabSharedControlsPage6";
            this.ultraTabSharedControlsPage6.Size = new System.Drawing.Size(196, 77);
            // 
            // tabCustomerDetail
            // 
            this.tabCustomerDetail.Controls.Add(this.tabItmDetPrincipal);
            this.tabCustomerDetail.Controls.Add(this.tabItmDetInfraestructure);
            this.tabCustomerDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCustomerDetail.Location = new System.Drawing.Point(3, 16);
            this.tabCustomerDetail.Name = "tabCustomerDetail";
            this.tabCustomerDetail.SelectedIndex = 0;
            this.tabCustomerDetail.Size = new System.Drawing.Size(971, 465);
            this.tabCustomerDetail.TabIndex = 28;
            // 
            // tabItmDetPrincipal
            // 
            this.tabItmDetPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetPrincipal.Controls.Add(this.btcDetBusinessType);
            this.tabItmDetPrincipal.Controls.Add(this.lblDetName);
            this.tabItmDetPrincipal.Controls.Add(this.lblDetBusinessType);
            this.tabItmDetPrincipal.Controls.Add(this.txtDetComercialName);
            this.tabItmDetPrincipal.Controls.Add(this.txtDetName);
            this.tabItmDetPrincipal.Controls.Add(this.lblDetComercialName);
            this.tabItmDetPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetPrincipal.Name = "tabItmDetPrincipal";
            this.tabItmDetPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmDetPrincipal.Size = new System.Drawing.Size(963, 439);
            this.tabItmDetPrincipal.TabIndex = 0;
            this.tabItmDetPrincipal.Text = "Principal";
            // 
            // tabItmDetInfraestructure
            // 
            this.tabItmDetInfraestructure.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetInfraestructure.Controls.Add(this.tabDetInfrastructure);
            this.tabItmDetInfraestructure.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetInfraestructure.Name = "tabItmDetInfraestructure";
            this.tabItmDetInfraestructure.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmDetInfraestructure.Size = new System.Drawing.Size(963, 439);
            this.tabItmDetInfraestructure.TabIndex = 1;
            this.tabItmDetInfraestructure.Text = "Infraestructura";
            // 
            // tabDetInfrastructure
            // 
            this.tabDetInfrastructure.Controls.Add(this.tabItmPrincipal);
            this.tabDetInfrastructure.Controls.Add(this.tabItmDetComputers);
            this.tabDetInfrastructure.Controls.Add(this.tabItmDetNetwork);
            this.tabDetInfrastructure.Controls.Add(this.tabItmDetEnergy);
            this.tabDetInfrastructure.Controls.Add(this.tabItmDetPeripherals);
            this.tabDetInfrastructure.Controls.Add(this.tabItmDetSoftware);
            this.tabDetInfrastructure.Controls.Add(this.tabItmDetSuppliers);
            this.tabDetInfrastructure.Controls.Add(this.tabItmDetVideo);
            this.tabDetInfrastructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetInfrastructure.Location = new System.Drawing.Point(3, 3);
            this.tabDetInfrastructure.Name = "tabDetInfrastructure";
            this.tabDetInfrastructure.SelectedIndex = 0;
            this.tabDetInfrastructure.Size = new System.Drawing.Size(957, 433);
            this.tabDetInfrastructure.TabIndex = 1;
            // 
            // tabItmDetComputers
            // 
            this.tabItmDetComputers.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetComputers.Controls.Add(this.tabDetInfraestructureComputers);
            this.tabItmDetComputers.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetComputers.Name = "tabItmDetComputers";
            this.tabItmDetComputers.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmDetComputers.Size = new System.Drawing.Size(949, 407);
            this.tabItmDetComputers.TabIndex = 0;
            this.tabItmDetComputers.Text = "Computadoras";
            // 
            // tabDetInfraestructureComputers
            // 
            this.tabDetInfraestructureComputers.Controls.Add(this.tabItmDetPersonalComputers);
            this.tabDetInfraestructureComputers.Controls.Add(this.tabItmDetServerComputers);
            this.tabDetInfraestructureComputers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetInfraestructureComputers.Location = new System.Drawing.Point(3, 3);
            this.tabDetInfraestructureComputers.Name = "tabDetInfraestructureComputers";
            this.tabDetInfraestructureComputers.SelectedIndex = 0;
            this.tabDetInfraestructureComputers.Size = new System.Drawing.Size(943, 401);
            this.tabDetInfraestructureComputers.TabIndex = 1;
            // 
            // tabItmDetPersonalComputers
            // 
            this.tabItmDetPersonalComputers.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetPersonalComputers.Controls.Add(this.mtoCustomerInfrastructurePersonalComputers);
            this.tabItmDetPersonalComputers.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetPersonalComputers.Name = "tabItmDetPersonalComputers";
            this.tabItmDetPersonalComputers.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmDetPersonalComputers.Size = new System.Drawing.Size(935, 375);
            this.tabItmDetPersonalComputers.TabIndex = 0;
            this.tabItmDetPersonalComputers.Text = "Personales";
            // 
            // mtoCustomerInfrastructurePersonalComputers
            // 
            this.mtoCustomerInfrastructurePersonalComputers.CustomerInfrastructure = null;
            this.mtoCustomerInfrastructurePersonalComputers.CustomParent = null;
            this.mtoCustomerInfrastructurePersonalComputers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructurePersonalComputers.Location = new System.Drawing.Point(3, 3);
            this.mtoCustomerInfrastructurePersonalComputers.Name = "mtoCustomerInfrastructurePersonalComputers";
            this.mtoCustomerInfrastructurePersonalComputers.ReadOnly = false;
            this.mtoCustomerInfrastructurePersonalComputers.Size = new System.Drawing.Size(929, 369);
            this.mtoCustomerInfrastructurePersonalComputers.TabIndex = 0;
            // 
            // tabItmDetServerComputers
            // 
            this.tabItmDetServerComputers.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetServerComputers.Controls.Add(this.mtoCustomerInfrastructureServerComputers);
            this.tabItmDetServerComputers.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetServerComputers.Name = "tabItmDetServerComputers";
            this.tabItmDetServerComputers.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmDetServerComputers.Size = new System.Drawing.Size(935, 375);
            this.tabItmDetServerComputers.TabIndex = 1;
            this.tabItmDetServerComputers.Text = "Servidores";
            // 
            // mtoCustomerInfrastructureServerComputers
            // 
            this.mtoCustomerInfrastructureServerComputers.CustomerInfrastructure = null;
            this.mtoCustomerInfrastructureServerComputers.CustomParent = null;
            this.mtoCustomerInfrastructureServerComputers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureServerComputers.Location = new System.Drawing.Point(3, 3);
            this.mtoCustomerInfrastructureServerComputers.Name = "mtoCustomerInfrastructureServerComputers";
            this.mtoCustomerInfrastructureServerComputers.ReadOnly = false;
            this.mtoCustomerInfrastructureServerComputers.Size = new System.Drawing.Size(929, 369);
            this.mtoCustomerInfrastructureServerComputers.TabIndex = 0;
            // 
            // tabItmDetNetwork
            // 
            this.tabItmDetNetwork.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetNetwork.Controls.Add(this.tabDetInfraestructureNetwork);
            this.tabItmDetNetwork.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetNetwork.Name = "tabItmDetNetwork";
            this.tabItmDetNetwork.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmDetNetwork.Size = new System.Drawing.Size(949, 407);
            this.tabItmDetNetwork.TabIndex = 1;
            this.tabItmDetNetwork.Text = "Redes";
            // 
            // tabDetInfraestructureNetwork
            // 
            this.tabDetInfraestructureNetwork.Controls.Add(this.tabItmNetworkSite);
            this.tabDetInfraestructureNetwork.Controls.Add(this.tabItmNetworkSwitches);
            this.tabDetInfraestructureNetwork.Controls.Add(this.tabItmNetworkCommutators);
            this.tabDetInfraestructureNetwork.Controls.Add(this.tabItmNetworkCabling);
            this.tabDetInfraestructureNetwork.Controls.Add(this.tabItmNetworkRouters);
            this.tabDetInfraestructureNetwork.Controls.Add(this.tabItmNetworkFirewalls);
            this.tabDetInfraestructureNetwork.Controls.Add(this.tabItmNetworkWifi);
            this.tabDetInfraestructureNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetInfraestructureNetwork.Location = new System.Drawing.Point(3, 3);
            this.tabDetInfraestructureNetwork.Name = "tabDetInfraestructureNetwork";
            this.tabDetInfraestructureNetwork.SelectedIndex = 0;
            this.tabDetInfraestructureNetwork.Size = new System.Drawing.Size(943, 401);
            this.tabDetInfraestructureNetwork.TabIndex = 89;
            // 
            // tabItmNetworkSite
            // 
            this.tabItmNetworkSite.BackColor = System.Drawing.Color.Transparent;
            this.tabItmNetworkSite.Controls.Add(this.tabDetSite);
            this.tabItmNetworkSite.Location = new System.Drawing.Point(4, 22);
            this.tabItmNetworkSite.Name = "tabItmNetworkSite";
            this.tabItmNetworkSite.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmNetworkSite.Size = new System.Drawing.Size(935, 375);
            this.tabItmNetworkSite.TabIndex = 0;
            this.tabItmNetworkSite.Text = "Site";
            // 
            // tabDetSite
            // 
            this.tabDetSite.Controls.Add(this.tabItmSitePrincipal);
            this.tabDetSite.Controls.Add(this.tabItmRacks);
            this.tabDetSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetSite.Location = new System.Drawing.Point(3, 3);
            this.tabDetSite.Name = "tabDetSite";
            this.tabDetSite.SelectedIndex = 0;
            this.tabDetSite.Size = new System.Drawing.Size(929, 369);
            this.tabDetSite.TabIndex = 0;
            // 
            // tabItmSitePrincipal
            // 
            this.tabItmSitePrincipal.BackColor = System.Drawing.Color.Transparent;
            this.tabItmSitePrincipal.Controls.Add(this.gbxDetSiteDescription);
            this.tabItmSitePrincipal.Controls.Add(this.gbxDetSiteCooling);
            this.tabItmSitePrincipal.Controls.Add(this.gbxDetSiteIsolatedRoom);
            this.tabItmSitePrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabItmSitePrincipal.Name = "tabItmSitePrincipal";
            this.tabItmSitePrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmSitePrincipal.Size = new System.Drawing.Size(921, 343);
            this.tabItmSitePrincipal.TabIndex = 0;
            this.tabItmSitePrincipal.Text = "Principal";
            // 
            // gbxDetSiteDescription
            // 
            this.gbxDetSiteDescription.Controls.Add(this.txtDetSiteDescription);
            this.gbxDetSiteDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDetSiteDescription.Location = new System.Drawing.Point(3, 153);
            this.gbxDetSiteDescription.Name = "gbxDetSiteDescription";
            this.gbxDetSiteDescription.Size = new System.Drawing.Size(915, 75);
            this.gbxDetSiteDescription.TabIndex = 114;
            this.gbxDetSiteDescription.TabStop = false;
            this.gbxDetSiteDescription.Text = "Descripción General:";
            // 
            // txtDetSiteDescription
            // 
            this.txtDetSiteDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetSiteDescription.Location = new System.Drawing.Point(3, 16);
            this.txtDetSiteDescription.Multiline = true;
            this.txtDetSiteDescription.Name = "txtDetSiteDescription";
            this.txtDetSiteDescription.Size = new System.Drawing.Size(909, 56);
            this.txtDetSiteDescription.TabIndex = 0;
            // 
            // gbxDetSiteCooling
            // 
            this.gbxDetSiteCooling.Controls.Add(this.txtDetSiteCooling);
            this.gbxDetSiteCooling.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDetSiteCooling.Location = new System.Drawing.Point(3, 78);
            this.gbxDetSiteCooling.Name = "gbxDetSiteCooling";
            this.gbxDetSiteCooling.Size = new System.Drawing.Size(915, 75);
            this.gbxDetSiteCooling.TabIndex = 116;
            this.gbxDetSiteCooling.TabStop = false;
            this.gbxDetSiteCooling.Text = "Refrigeración:";
            // 
            // txtDetSiteCooling
            // 
            this.txtDetSiteCooling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetSiteCooling.Location = new System.Drawing.Point(3, 16);
            this.txtDetSiteCooling.Multiline = true;
            this.txtDetSiteCooling.Name = "txtDetSiteCooling";
            this.txtDetSiteCooling.Size = new System.Drawing.Size(909, 56);
            this.txtDetSiteCooling.TabIndex = 0;
            // 
            // gbxDetSiteIsolatedRoom
            // 
            this.gbxDetSiteIsolatedRoom.Controls.Add(this.txtDetSiteIsolatedRoom);
            this.gbxDetSiteIsolatedRoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDetSiteIsolatedRoom.Location = new System.Drawing.Point(3, 3);
            this.gbxDetSiteIsolatedRoom.Name = "gbxDetSiteIsolatedRoom";
            this.gbxDetSiteIsolatedRoom.Size = new System.Drawing.Size(915, 75);
            this.gbxDetSiteIsolatedRoom.TabIndex = 115;
            this.gbxDetSiteIsolatedRoom.TabStop = false;
            this.gbxDetSiteIsolatedRoom.Text = "Cuarto Aislado:";
            // 
            // txtDetSiteIsolatedRoom
            // 
            this.txtDetSiteIsolatedRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetSiteIsolatedRoom.Location = new System.Drawing.Point(3, 16);
            this.txtDetSiteIsolatedRoom.Multiline = true;
            this.txtDetSiteIsolatedRoom.Name = "txtDetSiteIsolatedRoom";
            this.txtDetSiteIsolatedRoom.Size = new System.Drawing.Size(909, 56);
            this.txtDetSiteIsolatedRoom.TabIndex = 0;
            // 
            // tabItmRacks
            // 
            this.tabItmRacks.BackColor = System.Drawing.Color.Transparent;
            this.tabItmRacks.Controls.Add(this.mtoCustomerInfrastructureNetworkSiteRacks);
            this.tabItmRacks.Location = new System.Drawing.Point(4, 22);
            this.tabItmRacks.Name = "tabItmRacks";
            this.tabItmRacks.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmRacks.Size = new System.Drawing.Size(921, 343);
            this.tabItmRacks.TabIndex = 1;
            this.tabItmRacks.Text = "Racks";
            // 
            // mtoCustomerInfrastructureNetworkSiteRacks
            // 
            this.mtoCustomerInfrastructureNetworkSiteRacks.CustomerInfrastructureNetworkSite = null;
            this.mtoCustomerInfrastructureNetworkSiteRacks.CustomParent = null;
            this.mtoCustomerInfrastructureNetworkSiteRacks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureNetworkSiteRacks.Location = new System.Drawing.Point(3, 3);
            this.mtoCustomerInfrastructureNetworkSiteRacks.Name = "mtoCustomerInfrastructureNetworkSiteRacks";
            this.mtoCustomerInfrastructureNetworkSiteRacks.ReadOnly = false;
            this.mtoCustomerInfrastructureNetworkSiteRacks.Size = new System.Drawing.Size(915, 337);
            this.mtoCustomerInfrastructureNetworkSiteRacks.TabIndex = 0;
            // 
            // tabItmNetworkSwitches
            // 
            this.tabItmNetworkSwitches.BackColor = System.Drawing.Color.Transparent;
            this.tabItmNetworkSwitches.Controls.Add(this.mtoCustomerInfrastructureNetworkSwitches);
            this.tabItmNetworkSwitches.Location = new System.Drawing.Point(4, 22);
            this.tabItmNetworkSwitches.Name = "tabItmNetworkSwitches";
            this.tabItmNetworkSwitches.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmNetworkSwitches.Size = new System.Drawing.Size(935, 375);
            this.tabItmNetworkSwitches.TabIndex = 1;
            this.tabItmNetworkSwitches.Text = "Switches";
            // 
            // mtoCustomerInfrastructureNetworkSwitches
            // 
            this.mtoCustomerInfrastructureNetworkSwitches.CustomerInfrastructureNetwork = null;
            this.mtoCustomerInfrastructureNetworkSwitches.CustomParent = null;
            this.mtoCustomerInfrastructureNetworkSwitches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureNetworkSwitches.Location = new System.Drawing.Point(3, 3);
            this.mtoCustomerInfrastructureNetworkSwitches.Name = "mtoCustomerInfrastructureNetworkSwitches";
            this.mtoCustomerInfrastructureNetworkSwitches.ReadOnly = false;
            this.mtoCustomerInfrastructureNetworkSwitches.Size = new System.Drawing.Size(929, 369);
            this.mtoCustomerInfrastructureNetworkSwitches.TabIndex = 0;
            // 
            // tabItmNetworkCommutators
            // 
            this.tabItmNetworkCommutators.BackColor = System.Drawing.Color.Transparent;
            this.tabItmNetworkCommutators.Controls.Add(this.mtoCustomerInfrastructureNetworkCommutators);
            this.tabItmNetworkCommutators.Location = new System.Drawing.Point(4, 22);
            this.tabItmNetworkCommutators.Name = "tabItmNetworkCommutators";
            this.tabItmNetworkCommutators.Size = new System.Drawing.Size(935, 375);
            this.tabItmNetworkCommutators.TabIndex = 3;
            this.tabItmNetworkCommutators.Text = "Conmutadores";
            // 
            // mtoCustomerInfrastructureNetworkCommutators
            // 
            this.mtoCustomerInfrastructureNetworkCommutators.CustomerInfrastructureNetwork = null;
            this.mtoCustomerInfrastructureNetworkCommutators.CustomParent = null;
            this.mtoCustomerInfrastructureNetworkCommutators.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureNetworkCommutators.Location = new System.Drawing.Point(0, 0);
            this.mtoCustomerInfrastructureNetworkCommutators.Name = "mtoCustomerInfrastructureNetworkCommutators";
            this.mtoCustomerInfrastructureNetworkCommutators.ReadOnly = false;
            this.mtoCustomerInfrastructureNetworkCommutators.Size = new System.Drawing.Size(935, 375);
            this.mtoCustomerInfrastructureNetworkCommutators.TabIndex = 0;
            // 
            // tabItmNetworkCabling
            // 
            this.tabItmNetworkCabling.BackColor = System.Drawing.Color.Transparent;
            this.tabItmNetworkCabling.Controls.Add(this.mtoCustomerInfrastructureNetworkCablings);
            this.tabItmNetworkCabling.Location = new System.Drawing.Point(4, 22);
            this.tabItmNetworkCabling.Name = "tabItmNetworkCabling";
            this.tabItmNetworkCabling.Size = new System.Drawing.Size(935, 375);
            this.tabItmNetworkCabling.TabIndex = 2;
            this.tabItmNetworkCabling.Text = "Cableado";
            // 
            // mtoCustomerInfrastructureNetworkCablings
            // 
            this.mtoCustomerInfrastructureNetworkCablings.CustomerInfrastructureNetwork = null;
            this.mtoCustomerInfrastructureNetworkCablings.CustomParent = null;
            this.mtoCustomerInfrastructureNetworkCablings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureNetworkCablings.Location = new System.Drawing.Point(0, 0);
            this.mtoCustomerInfrastructureNetworkCablings.Name = "mtoCustomerInfrastructureNetworkCablings";
            this.mtoCustomerInfrastructureNetworkCablings.ReadOnly = false;
            this.mtoCustomerInfrastructureNetworkCablings.Size = new System.Drawing.Size(935, 375);
            this.mtoCustomerInfrastructureNetworkCablings.TabIndex = 0;
            // 
            // tabItmNetworkRouters
            // 
            this.tabItmNetworkRouters.BackColor = System.Drawing.Color.Transparent;
            this.tabItmNetworkRouters.Controls.Add(this.mtoCustomerInfrastructureNetworkRouters);
            this.tabItmNetworkRouters.Location = new System.Drawing.Point(4, 22);
            this.tabItmNetworkRouters.Name = "tabItmNetworkRouters";
            this.tabItmNetworkRouters.Size = new System.Drawing.Size(935, 375);
            this.tabItmNetworkRouters.TabIndex = 4;
            this.tabItmNetworkRouters.Text = "Routers";
            // 
            // mtoCustomerInfrastructureNetworkRouters
            // 
            this.mtoCustomerInfrastructureNetworkRouters.CustomerInfrastructureNetwork = null;
            this.mtoCustomerInfrastructureNetworkRouters.CustomParent = null;
            this.mtoCustomerInfrastructureNetworkRouters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureNetworkRouters.Location = new System.Drawing.Point(0, 0);
            this.mtoCustomerInfrastructureNetworkRouters.Name = "mtoCustomerInfrastructureNetworkRouters";
            this.mtoCustomerInfrastructureNetworkRouters.ReadOnly = false;
            this.mtoCustomerInfrastructureNetworkRouters.Size = new System.Drawing.Size(935, 375);
            this.mtoCustomerInfrastructureNetworkRouters.TabIndex = 0;
            // 
            // tabItmNetworkFirewalls
            // 
            this.tabItmNetworkFirewalls.BackColor = System.Drawing.Color.Transparent;
            this.tabItmNetworkFirewalls.Controls.Add(this.mtoCustomerInfrastructureNetworkFirewalls);
            this.tabItmNetworkFirewalls.Location = new System.Drawing.Point(4, 22);
            this.tabItmNetworkFirewalls.Name = "tabItmNetworkFirewalls";
            this.tabItmNetworkFirewalls.Size = new System.Drawing.Size(935, 375);
            this.tabItmNetworkFirewalls.TabIndex = 5;
            this.tabItmNetworkFirewalls.Text = "Firewalls";
            // 
            // mtoCustomerInfrastructureNetworkFirewalls
            // 
            this.mtoCustomerInfrastructureNetworkFirewalls.CustomerInfrastructureNetwork = null;
            this.mtoCustomerInfrastructureNetworkFirewalls.CustomParent = null;
            this.mtoCustomerInfrastructureNetworkFirewalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureNetworkFirewalls.Location = new System.Drawing.Point(0, 0);
            this.mtoCustomerInfrastructureNetworkFirewalls.Name = "mtoCustomerInfrastructureNetworkFirewalls";
            this.mtoCustomerInfrastructureNetworkFirewalls.ReadOnly = false;
            this.mtoCustomerInfrastructureNetworkFirewalls.Size = new System.Drawing.Size(935, 375);
            this.mtoCustomerInfrastructureNetworkFirewalls.TabIndex = 0;
            // 
            // tabItmNetworkWifi
            // 
            this.tabItmNetworkWifi.BackColor = System.Drawing.Color.Transparent;
            this.tabItmNetworkWifi.Controls.Add(this.tabDetAccessPoints);
            this.tabItmNetworkWifi.Location = new System.Drawing.Point(4, 22);
            this.tabItmNetworkWifi.Name = "tabItmNetworkWifi";
            this.tabItmNetworkWifi.Size = new System.Drawing.Size(935, 375);
            this.tabItmNetworkWifi.TabIndex = 6;
            this.tabItmNetworkWifi.Text = "Redes inalámbricas";
            // 
            // tabDetAccessPoints
            // 
            this.tabDetAccessPoints.Controls.Add(this.tabItmAccessPoints);
            this.tabDetAccessPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetAccessPoints.Location = new System.Drawing.Point(0, 0);
            this.tabDetAccessPoints.Name = "tabDetAccessPoints";
            this.tabDetAccessPoints.SelectedIndex = 0;
            this.tabDetAccessPoints.Size = new System.Drawing.Size(935, 375);
            this.tabDetAccessPoints.TabIndex = 0;
            // 
            // tabItmAccessPoints
            // 
            this.tabItmAccessPoints.BackColor = System.Drawing.Color.Transparent;
            this.tabItmAccessPoints.Controls.Add(this.mtoCustomerInfrastructureNetworkWifiAccessPoints);
            this.tabItmAccessPoints.Location = new System.Drawing.Point(4, 22);
            this.tabItmAccessPoints.Name = "tabItmAccessPoints";
            this.tabItmAccessPoints.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmAccessPoints.Size = new System.Drawing.Size(927, 349);
            this.tabItmAccessPoints.TabIndex = 0;
            this.tabItmAccessPoints.Text = "Puntos de Acceso";
            // 
            // mtoCustomerInfrastructureNetworkWifiAccessPoints
            // 
            this.mtoCustomerInfrastructureNetworkWifiAccessPoints.CustomerInfrastructureNetworkWifi = null;
            this.mtoCustomerInfrastructureNetworkWifiAccessPoints.CustomParent = null;
            this.mtoCustomerInfrastructureNetworkWifiAccessPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureNetworkWifiAccessPoints.Location = new System.Drawing.Point(3, 3);
            this.mtoCustomerInfrastructureNetworkWifiAccessPoints.Name = "mtoCustomerInfrastructureNetworkWifiAccessPoints";
            this.mtoCustomerInfrastructureNetworkWifiAccessPoints.ReadOnly = false;
            this.mtoCustomerInfrastructureNetworkWifiAccessPoints.Size = new System.Drawing.Size(921, 343);
            this.mtoCustomerInfrastructureNetworkWifiAccessPoints.TabIndex = 0;
            // 
            // tabItmDetEnergy
            // 
            this.tabItmDetEnergy.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetEnergy.Controls.Add(this.tabDetInfraestructureEnergy);
            this.tabItmDetEnergy.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetEnergy.Name = "tabItmDetEnergy";
            this.tabItmDetEnergy.Size = new System.Drawing.Size(949, 407);
            this.tabItmDetEnergy.TabIndex = 2;
            this.tabItmDetEnergy.Text = "Energía";
            // 
            // tabDetInfraestructureEnergy
            // 
            this.tabDetInfraestructureEnergy.Controls.Add(this.tabItmEnergy);
            this.tabDetInfraestructureEnergy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetInfraestructureEnergy.Location = new System.Drawing.Point(0, 0);
            this.tabDetInfraestructureEnergy.Name = "tabDetInfraestructureEnergy";
            this.tabDetInfraestructureEnergy.SelectedIndex = 0;
            this.tabDetInfraestructureEnergy.Size = new System.Drawing.Size(949, 407);
            this.tabDetInfraestructureEnergy.TabIndex = 89;
            // 
            // tabItmEnergy
            // 
            this.tabItmEnergy.BackColor = System.Drawing.Color.Transparent;
            this.tabItmEnergy.Controls.Add(this.mtoCustomerInfrastructureUPSs);
            this.tabItmEnergy.Location = new System.Drawing.Point(4, 22);
            this.tabItmEnergy.Name = "tabItmEnergy";
            this.tabItmEnergy.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmEnergy.Size = new System.Drawing.Size(941, 381);
            this.tabItmEnergy.TabIndex = 0;
            this.tabItmEnergy.Text = "UPSs";
            // 
            // mtoCustomerInfrastructureUPSs
            // 
            this.mtoCustomerInfrastructureUPSs.CustomerInfrastructure = null;
            this.mtoCustomerInfrastructureUPSs.CustomParent = null;
            this.mtoCustomerInfrastructureUPSs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureUPSs.Location = new System.Drawing.Point(3, 3);
            this.mtoCustomerInfrastructureUPSs.Name = "mtoCustomerInfrastructureUPSs";
            this.mtoCustomerInfrastructureUPSs.ReadOnly = false;
            this.mtoCustomerInfrastructureUPSs.Size = new System.Drawing.Size(935, 375);
            this.mtoCustomerInfrastructureUPSs.TabIndex = 0;
            // 
            // tabItmDetPeripherals
            // 
            this.tabItmDetPeripherals.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetPeripherals.Controls.Add(this.tabDetInfraestructurePeripherals);
            this.tabItmDetPeripherals.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetPeripherals.Name = "tabItmDetPeripherals";
            this.tabItmDetPeripherals.Size = new System.Drawing.Size(949, 407);
            this.tabItmDetPeripherals.TabIndex = 3;
            this.tabItmDetPeripherals.Text = "Periféricos";
            // 
            // tabDetInfraestructurePeripherals
            // 
            this.tabDetInfraestructurePeripherals.Controls.Add(this.tabItmPeripherals);
            this.tabDetInfraestructurePeripherals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetInfraestructurePeripherals.Location = new System.Drawing.Point(0, 0);
            this.tabDetInfraestructurePeripherals.Name = "tabDetInfraestructurePeripherals";
            this.tabDetInfraestructurePeripherals.SelectedIndex = 0;
            this.tabDetInfraestructurePeripherals.Size = new System.Drawing.Size(949, 407);
            this.tabDetInfraestructurePeripherals.TabIndex = 90;
            // 
            // tabItmPeripherals
            // 
            this.tabItmPeripherals.BackColor = System.Drawing.Color.Transparent;
            this.tabItmPeripherals.Controls.Add(this.mtoCustomerInfrastructurePrinters);
            this.tabItmPeripherals.Location = new System.Drawing.Point(4, 22);
            this.tabItmPeripherals.Name = "tabItmPeripherals";
            this.tabItmPeripherals.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmPeripherals.Size = new System.Drawing.Size(941, 381);
            this.tabItmPeripherals.TabIndex = 0;
            this.tabItmPeripherals.Text = "Impresoras";
            // 
            // mtoCustomerInfrastructurePrinters
            // 
            this.mtoCustomerInfrastructurePrinters.CustomerInfrastructure = null;
            this.mtoCustomerInfrastructurePrinters.CustomParent = null;
            this.mtoCustomerInfrastructurePrinters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructurePrinters.Location = new System.Drawing.Point(3, 3);
            this.mtoCustomerInfrastructurePrinters.Name = "mtoCustomerInfrastructurePrinters";
            this.mtoCustomerInfrastructurePrinters.ReadOnly = false;
            this.mtoCustomerInfrastructurePrinters.Size = new System.Drawing.Size(935, 375);
            this.mtoCustomerInfrastructurePrinters.TabIndex = 0;
            // 
            // tabItmDetSoftware
            // 
            this.tabItmDetSoftware.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetSoftware.Controls.Add(this.tabDetInfraestructureSoftware);
            this.tabItmDetSoftware.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetSoftware.Name = "tabItmDetSoftware";
            this.tabItmDetSoftware.Size = new System.Drawing.Size(949, 407);
            this.tabItmDetSoftware.TabIndex = 4;
            this.tabItmDetSoftware.Text = "Software";
            // 
            // tabDetInfraestructureSoftware
            // 
            this.tabDetInfraestructureSoftware.Controls.Add(this.tabItmDetAdministrationSoftware);
            this.tabDetInfraestructureSoftware.Controls.Add(this.tabItmDetSecuritySoftware);
            this.tabDetInfraestructureSoftware.Controls.Add(this.tabItmDetBackupSoftware);
            this.tabDetInfraestructureSoftware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetInfraestructureSoftware.Location = new System.Drawing.Point(0, 0);
            this.tabDetInfraestructureSoftware.Name = "tabDetInfraestructureSoftware";
            this.tabDetInfraestructureSoftware.SelectedIndex = 0;
            this.tabDetInfraestructureSoftware.Size = new System.Drawing.Size(949, 407);
            this.tabDetInfraestructureSoftware.TabIndex = 91;
            // 
            // tabItmDetAdministrationSoftware
            // 
            this.tabItmDetAdministrationSoftware.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetAdministrationSoftware.Controls.Add(this.mtoCustomerInfrastructureAdministationSoftwares);
            this.tabItmDetAdministrationSoftware.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetAdministrationSoftware.Name = "tabItmDetAdministrationSoftware";
            this.tabItmDetAdministrationSoftware.Size = new System.Drawing.Size(941, 381);
            this.tabItmDetAdministrationSoftware.TabIndex = 1;
            this.tabItmDetAdministrationSoftware.Text = "Software de Administración";
            // 
            // mtoCustomerInfrastructureAdministationSoftwares
            // 
            this.mtoCustomerInfrastructureAdministationSoftwares.CustomerInfrastructure = null;
            this.mtoCustomerInfrastructureAdministationSoftwares.CustomParent = null;
            this.mtoCustomerInfrastructureAdministationSoftwares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureAdministationSoftwares.Location = new System.Drawing.Point(0, 0);
            this.mtoCustomerInfrastructureAdministationSoftwares.Name = "mtoCustomerInfrastructureAdministationSoftwares";
            this.mtoCustomerInfrastructureAdministationSoftwares.ReadOnly = false;
            this.mtoCustomerInfrastructureAdministationSoftwares.Size = new System.Drawing.Size(941, 381);
            this.mtoCustomerInfrastructureAdministationSoftwares.TabIndex = 116;
            // 
            // tabItmDetSecuritySoftware
            // 
            this.tabItmDetSecuritySoftware.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetSecuritySoftware.Controls.Add(this.mtoCustomerInfrastructureSecuritySoftwares);
            this.tabItmDetSecuritySoftware.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetSecuritySoftware.Name = "tabItmDetSecuritySoftware";
            this.tabItmDetSecuritySoftware.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmDetSecuritySoftware.Size = new System.Drawing.Size(941, 381);
            this.tabItmDetSecuritySoftware.TabIndex = 0;
            this.tabItmDetSecuritySoftware.Text = "Software de Seguridad";
            // 
            // mtoCustomerInfrastructureSecuritySoftwares
            // 
            this.mtoCustomerInfrastructureSecuritySoftwares.CustomerInfrastructure = null;
            this.mtoCustomerInfrastructureSecuritySoftwares.CustomParent = null;
            this.mtoCustomerInfrastructureSecuritySoftwares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureSecuritySoftwares.Location = new System.Drawing.Point(3, 3);
            this.mtoCustomerInfrastructureSecuritySoftwares.Name = "mtoCustomerInfrastructureSecuritySoftwares";
            this.mtoCustomerInfrastructureSecuritySoftwares.ReadOnly = false;
            this.mtoCustomerInfrastructureSecuritySoftwares.Size = new System.Drawing.Size(935, 375);
            this.mtoCustomerInfrastructureSecuritySoftwares.TabIndex = 0;
            // 
            // tabItmDetBackupSoftware
            // 
            this.tabItmDetBackupSoftware.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetBackupSoftware.Controls.Add(this.mtoCustomerInfrastructureBackupSoftwares);
            this.tabItmDetBackupSoftware.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetBackupSoftware.Name = "tabItmDetBackupSoftware";
            this.tabItmDetBackupSoftware.Size = new System.Drawing.Size(941, 381);
            this.tabItmDetBackupSoftware.TabIndex = 2;
            this.tabItmDetBackupSoftware.Text = "Software de Respaldos";
            // 
            // mtoCustomerInfrastructureBackupSoftwares
            // 
            this.mtoCustomerInfrastructureBackupSoftwares.CustomerInfrastructure = null;
            this.mtoCustomerInfrastructureBackupSoftwares.CustomParent = null;
            this.mtoCustomerInfrastructureBackupSoftwares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureBackupSoftwares.Location = new System.Drawing.Point(0, 0);
            this.mtoCustomerInfrastructureBackupSoftwares.Name = "mtoCustomerInfrastructureBackupSoftwares";
            this.mtoCustomerInfrastructureBackupSoftwares.ReadOnly = false;
            this.mtoCustomerInfrastructureBackupSoftwares.Size = new System.Drawing.Size(941, 381);
            this.mtoCustomerInfrastructureBackupSoftwares.TabIndex = 0;
            // 
            // tabItmDetSuppliers
            // 
            this.tabItmDetSuppliers.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetSuppliers.Controls.Add(this.tabDetInfraestructureSuppliers);
            this.tabItmDetSuppliers.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetSuppliers.Name = "tabItmDetSuppliers";
            this.tabItmDetSuppliers.Size = new System.Drawing.Size(949, 407);
            this.tabItmDetSuppliers.TabIndex = 5;
            this.tabItmDetSuppliers.Text = "Proveedores y Servicios";
            // 
            // tabDetInfraestructureSuppliers
            // 
            this.tabDetInfraestructureSuppliers.Controls.Add(this.tabItmDetISP);
            this.tabDetInfraestructureSuppliers.Controls.Add(this.tabItmDetTelephony);
            this.tabDetInfraestructureSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetInfraestructureSuppliers.Location = new System.Drawing.Point(0, 0);
            this.tabDetInfraestructureSuppliers.Name = "tabDetInfraestructureSuppliers";
            this.tabDetInfraestructureSuppliers.SelectedIndex = 0;
            this.tabDetInfraestructureSuppliers.Size = new System.Drawing.Size(949, 407);
            this.tabDetInfraestructureSuppliers.TabIndex = 91;
            // 
            // tabItmDetISP
            // 
            this.tabItmDetISP.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetISP.Controls.Add(this.mtoCustomerInfrastructureISPs);
            this.tabItmDetISP.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetISP.Name = "tabItmDetISP";
            this.tabItmDetISP.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmDetISP.Size = new System.Drawing.Size(941, 381);
            this.tabItmDetISP.TabIndex = 0;
            this.tabItmDetISP.Text = "Proveedor de Internet";
            // 
            // mtoCustomerInfrastructureISPs
            // 
            this.mtoCustomerInfrastructureISPs.CustomerInfrastructure = null;
            this.mtoCustomerInfrastructureISPs.CustomParent = null;
            this.mtoCustomerInfrastructureISPs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureISPs.Location = new System.Drawing.Point(3, 3);
            this.mtoCustomerInfrastructureISPs.Name = "mtoCustomerInfrastructureISPs";
            this.mtoCustomerInfrastructureISPs.ReadOnly = false;
            this.mtoCustomerInfrastructureISPs.Size = new System.Drawing.Size(935, 375);
            this.mtoCustomerInfrastructureISPs.TabIndex = 0;
            // 
            // tabItmDetTelephony
            // 
            this.tabItmDetTelephony.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetTelephony.Controls.Add(this.mtoCustomerInfrastructureTelephonies);
            this.tabItmDetTelephony.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetTelephony.Name = "tabItmDetTelephony";
            this.tabItmDetTelephony.Size = new System.Drawing.Size(941, 381);
            this.tabItmDetTelephony.TabIndex = 1;
            this.tabItmDetTelephony.Text = "Proveedor de Telefonía";
            // 
            // mtoCustomerInfrastructureTelephonies
            // 
            this.mtoCustomerInfrastructureTelephonies.CustomerInfrastructure = null;
            this.mtoCustomerInfrastructureTelephonies.CustomParent = null;
            this.mtoCustomerInfrastructureTelephonies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureTelephonies.Location = new System.Drawing.Point(0, 0);
            this.mtoCustomerInfrastructureTelephonies.Name = "mtoCustomerInfrastructureTelephonies";
            this.mtoCustomerInfrastructureTelephonies.ReadOnly = false;
            this.mtoCustomerInfrastructureTelephonies.Size = new System.Drawing.Size(941, 381);
            this.mtoCustomerInfrastructureTelephonies.TabIndex = 0;
            // 
            // tabItmDetVideo
            // 
            this.tabItmDetVideo.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetVideo.Controls.Add(this.tabDetInfraestructureVideo);
            this.tabItmDetVideo.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetVideo.Name = "tabItmDetVideo";
            this.tabItmDetVideo.Size = new System.Drawing.Size(949, 407);
            this.tabItmDetVideo.TabIndex = 6;
            this.tabItmDetVideo.Text = "Video y Monitoreo";
            // 
            // tabDetInfraestructureVideo
            // 
            this.tabDetInfraestructureVideo.Controls.Add(this.tabItmDetCCTV);
            this.tabDetInfraestructureVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetInfraestructureVideo.Location = new System.Drawing.Point(0, 0);
            this.tabDetInfraestructureVideo.Name = "tabDetInfraestructureVideo";
            this.tabDetInfraestructureVideo.SelectedIndex = 0;
            this.tabDetInfraestructureVideo.Size = new System.Drawing.Size(949, 407);
            this.tabDetInfraestructureVideo.TabIndex = 91;
            // 
            // tabItmDetCCTV
            // 
            this.tabItmDetCCTV.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDetCCTV.Controls.Add(this.mtoCustomerInfrastructureCCTVs);
            this.tabItmDetCCTV.Location = new System.Drawing.Point(4, 22);
            this.tabItmDetCCTV.Name = "tabItmDetCCTV";
            this.tabItmDetCCTV.Padding = new System.Windows.Forms.Padding(3);
            this.tabItmDetCCTV.Size = new System.Drawing.Size(941, 381);
            this.tabItmDetCCTV.TabIndex = 0;
            this.tabItmDetCCTV.Text = "CCTVs";
            // 
            // mtoCustomerInfrastructureCCTVs
            // 
            this.mtoCustomerInfrastructureCCTVs.CustomerInfrastructure = null;
            this.mtoCustomerInfrastructureCCTVs.CustomParent = null;
            this.mtoCustomerInfrastructureCCTVs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureCCTVs.Location = new System.Drawing.Point(3, 3);
            this.mtoCustomerInfrastructureCCTVs.Name = "mtoCustomerInfrastructureCCTVs";
            this.mtoCustomerInfrastructureCCTVs.ReadOnly = false;
            this.mtoCustomerInfrastructureCCTVs.Size = new System.Drawing.Size(935, 375);
            this.mtoCustomerInfrastructureCCTVs.TabIndex = 0;
            // 
            // tabItmPrincipal
            // 
            this.tabItmPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.tabItmPrincipal.Controls.Add(this.gbxDetGroundedOutlet);
            this.tabItmPrincipal.Controls.Add(this.gbxDetTrainingAndCourses);
            this.tabItmPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabItmPrincipal.Name = "tabItmPrincipal";
            this.tabItmPrincipal.Size = new System.Drawing.Size(949, 407);
            this.tabItmPrincipal.TabIndex = 7;
            this.tabItmPrincipal.Text = "Principal";
            // 
            // txtDetTrainingAndCourses
            // 
            this.txtDetTrainingAndCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetTrainingAndCourses.Location = new System.Drawing.Point(3, 16);
            this.txtDetTrainingAndCourses.Multiline = true;
            this.txtDetTrainingAndCourses.Name = "txtDetTrainingAndCourses";
            this.txtDetTrainingAndCourses.Size = new System.Drawing.Size(943, 65);
            this.txtDetTrainingAndCourses.TabIndex = 30;
            // 
            // gbxDetTrainingAndCourses
            // 
            this.gbxDetTrainingAndCourses.Controls.Add(this.txtDetTrainingAndCourses);
            this.gbxDetTrainingAndCourses.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDetTrainingAndCourses.Location = new System.Drawing.Point(0, 0);
            this.gbxDetTrainingAndCourses.Name = "gbxDetTrainingAndCourses";
            this.gbxDetTrainingAndCourses.Size = new System.Drawing.Size(949, 84);
            this.gbxDetTrainingAndCourses.TabIndex = 31;
            this.gbxDetTrainingAndCourses.TabStop = false;
            this.gbxDetTrainingAndCourses.Text = "Cursos y Entrenamiento:";
            // 
            // txtDetGroundedOutlet
            // 
            this.txtDetGroundedOutlet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetGroundedOutlet.Location = new System.Drawing.Point(3, 16);
            this.txtDetGroundedOutlet.Multiline = true;
            this.txtDetGroundedOutlet.Name = "txtDetGroundedOutlet";
            this.txtDetGroundedOutlet.Size = new System.Drawing.Size(943, 65);
            this.txtDetGroundedOutlet.TabIndex = 28;
            // 
            // gbxDetGroundedOutlet
            // 
            this.gbxDetGroundedOutlet.Controls.Add(this.txtDetGroundedOutlet);
            this.gbxDetGroundedOutlet.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDetGroundedOutlet.Location = new System.Drawing.Point(0, 84);
            this.gbxDetGroundedOutlet.Name = "gbxDetGroundedOutlet";
            this.gbxDetGroundedOutlet.Size = new System.Drawing.Size(949, 84);
            this.gbxDetGroundedOutlet.TabIndex = 31;
            this.gbxDetGroundedOutlet.TabStop = false;
            this.gbxDetGroundedOutlet.Text = "Tierra Física:";
            // 
            // btcDetBusinessType
            // 
            this.btcDetBusinessType.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Single;
            this.btcDetBusinessType.CustomParent = null;
            this.btcDetBusinessType.DisplayMember = "Name";
            this.btcDetBusinessType.Location = new System.Drawing.Point(109, 61);
            this.btcDetBusinessType.Name = "btcDetBusinessType";
            businessTypeParameters1.BusinessTypeId = null;
            businessTypeParameters1.CreatedBy = null;
            businessTypeParameters1.CreatedOn = null;
            businessTypeParameters1.Description = null;
            businessTypeParameters1.Name = null;
            businessTypeParameters1.UpdatedBy = null;
            businessTypeParameters1.UpdatedOn = null;
            this.btcDetBusinessType.Parameters = businessTypeParameters1;
            this.btcDetBusinessType.ReadOnly = false;
            this.btcDetBusinessType.Size = new System.Drawing.Size(226, 22);
            this.btcDetBusinessType.TabIndex = 33;
            this.btcDetBusinessType.Value = null;
            this.btcDetBusinessType.ValueMember = "BusinessTypeId";
            this.btcDetBusinessType.Values = null;
            // 
            // lblDetName
            // 
            this.lblDetName.AutoSize = true;
            this.lblDetName.Location = new System.Drawing.Point(7, 12);
            this.lblDetName.Name = "lblDetName";
            this.lblDetName.Size = new System.Drawing.Size(47, 13);
            this.lblDetName.TabIndex = 29;
            this.lblDetName.Text = "Nombre:";
            // 
            // lblDetBusinessType
            // 
            this.lblDetBusinessType.AutoSize = true;
            this.lblDetBusinessType.Location = new System.Drawing.Point(7, 65);
            this.lblDetBusinessType.Name = "lblDetBusinessType";
            this.lblDetBusinessType.Size = new System.Drawing.Size(87, 13);
            this.lblDetBusinessType.TabIndex = 30;
            this.lblDetBusinessType.Text = "Giro de Negocio:";
            // 
            // txtDetComercialName
            // 
            this.txtDetComercialName.Location = new System.Drawing.Point(109, 35);
            this.txtDetComercialName.Name = "txtDetComercialName";
            this.txtDetComercialName.Size = new System.Drawing.Size(277, 20);
            this.txtDetComercialName.TabIndex = 32;
            // 
            // txtDetName
            // 
            this.txtDetName.Location = new System.Drawing.Point(109, 9);
            this.txtDetName.Name = "txtDetName";
            this.txtDetName.Size = new System.Drawing.Size(277, 20);
            this.txtDetName.TabIndex = 31;
            // 
            // lblDetComercialName
            // 
            this.lblDetComercialName.AutoSize = true;
            this.lblDetComercialName.Location = new System.Drawing.Point(7, 38);
            this.lblDetComercialName.Name = "lblDetComercialName";
            this.lblDetComercialName.Size = new System.Drawing.Size(96, 13);
            this.lblDetComercialName.TabIndex = 28;
            this.lblDetComercialName.Text = "Nombre Comercial:";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 535);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).EndInit();
            this.gbxSchParameters.ResumeLayout(false);
            this.gbxSchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.pnlDetButtons.ResumeLayout(false);
            this.upSeparatorAccept.ResumeLayout(false);
            this.upSchSeparatorClose.ResumeLayout(false);
            this.upSchSeparatorDelete.ResumeLayout(false);
            this.upSchSeparatorEdit.ResumeLayout(false);
            this.upSchSeparatorCreate.ResumeLayout(false);
            this.upSchSeparatorBottons.ResumeLayout(false);
            this.upSchSeparatorShowDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSchName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchComercialName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCheckEditor1)).EndInit();
            this.ultraPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).EndInit();
            this.ultraGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).EndInit();
            this.ultraGroupBox5.ResumeLayout(false);
            this.ultraGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCheckEditor2)).EndInit();
            this.ultraPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl2)).EndInit();
            this.ultraTabControl2.ResumeLayout(false);
            this.ultraPanel6.ClientArea.ResumeLayout(false);
            this.ultraPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).EndInit();
            this.ultraGroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl3)).EndInit();
            this.tabCustomerDetail.ResumeLayout(false);
            this.tabItmDetPrincipal.ResumeLayout(false);
            this.tabItmDetPrincipal.PerformLayout();
            this.tabItmDetInfraestructure.ResumeLayout(false);
            this.tabDetInfrastructure.ResumeLayout(false);
            this.tabItmDetComputers.ResumeLayout(false);
            this.tabDetInfraestructureComputers.ResumeLayout(false);
            this.tabItmDetPersonalComputers.ResumeLayout(false);
            this.tabItmDetServerComputers.ResumeLayout(false);
            this.tabItmDetNetwork.ResumeLayout(false);
            this.tabDetInfraestructureNetwork.ResumeLayout(false);
            this.tabItmNetworkSite.ResumeLayout(false);
            this.tabDetSite.ResumeLayout(false);
            this.tabItmSitePrincipal.ResumeLayout(false);
            this.gbxDetSiteDescription.ResumeLayout(false);
            this.gbxDetSiteDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetSiteDescription)).EndInit();
            this.gbxDetSiteCooling.ResumeLayout(false);
            this.gbxDetSiteCooling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetSiteCooling)).EndInit();
            this.gbxDetSiteIsolatedRoom.ResumeLayout(false);
            this.gbxDetSiteIsolatedRoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetSiteIsolatedRoom)).EndInit();
            this.tabItmRacks.ResumeLayout(false);
            this.tabItmNetworkSwitches.ResumeLayout(false);
            this.tabItmNetworkCommutators.ResumeLayout(false);
            this.tabItmNetworkCabling.ResumeLayout(false);
            this.tabItmNetworkRouters.ResumeLayout(false);
            this.tabItmNetworkFirewalls.ResumeLayout(false);
            this.tabItmNetworkWifi.ResumeLayout(false);
            this.tabDetAccessPoints.ResumeLayout(false);
            this.tabItmAccessPoints.ResumeLayout(false);
            this.tabItmDetEnergy.ResumeLayout(false);
            this.tabDetInfraestructureEnergy.ResumeLayout(false);
            this.tabItmEnergy.ResumeLayout(false);
            this.tabItmDetPeripherals.ResumeLayout(false);
            this.tabDetInfraestructurePeripherals.ResumeLayout(false);
            this.tabItmPeripherals.ResumeLayout(false);
            this.tabItmDetSoftware.ResumeLayout(false);
            this.tabDetInfraestructureSoftware.ResumeLayout(false);
            this.tabItmDetAdministrationSoftware.ResumeLayout(false);
            this.tabItmDetSecuritySoftware.ResumeLayout(false);
            this.tabItmDetBackupSoftware.ResumeLayout(false);
            this.tabItmDetSuppliers.ResumeLayout(false);
            this.tabDetInfraestructureSuppliers.ResumeLayout(false);
            this.tabItmDetISP.ResumeLayout(false);
            this.tabItmDetTelephony.ResumeLayout(false);
            this.tabItmDetVideo.ResumeLayout(false);
            this.tabDetInfraestructureVideo.ResumeLayout(false);
            this.tabItmDetCCTV.ResumeLayout(false);
            this.tabItmPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDetTrainingAndCourses)).EndInit();
            this.gbxDetTrainingAndCourses.ResumeLayout(false);
            this.gbxDetTrainingAndCourses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetGroundedOutlet)).EndInit();
            this.gbxDetGroundedOutlet.ResumeLayout(false);
            this.gbxDetGroundedOutlet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtSchName;
        private Infragistics.Win.Misc.UltraLabel ulblSchOrganizationName;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtSchComercialName;
        internal Infragistics.Win.Misc.UltraLabel ulblSchComercialName;
        internal Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        internal Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel4;
        internal Base.Controls.Controls.SamsaraTextEditor samsaraTextEditor1;
        internal Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
        internal Base.Controls.Controls.SamsaraTextEditor samsaraTextEditor2;
        internal Infragistics.Win.Misc.UltraGroupBox ultraGroupBox4;
        internal Base.Controls.Controls.SamsaraTextEditor samsaraTextEditor3;
        internal Infragistics.Win.Misc.UltraGroupBox ultraGroupBox5;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor2;
        internal Base.Controls.Controls.SamsaraTextEditor samsaraTextEditor4;
        private Infragistics.Win.Misc.UltraPanel ultraPanel5;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl2;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage5;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl11;
        private Infragistics.Win.Misc.UltraPanel ultraPanel6;
        internal Infragistics.Win.Misc.UltraGroupBox ultraGroupBox6;
        internal Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl3;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage6;
        internal System.Windows.Forms.TabControl tabCustomerDetail;
        private System.Windows.Forms.TabPage tabItmDetPrincipal;
        private System.Windows.Forms.TabPage tabItmDetInfraestructure;
        internal System.Windows.Forms.TabControl tabDetInfrastructure;
        private System.Windows.Forms.TabPage tabItmDetComputers;
        internal System.Windows.Forms.TabControl tabDetInfraestructureComputers;
        private System.Windows.Forms.TabPage tabItmDetPersonalComputers;
        internal Controls.ManyToOne.CustomerInfrastructurePersonalComputersControl mtoCustomerInfrastructurePersonalComputers;
        private System.Windows.Forms.TabPage tabItmDetServerComputers;
        internal Controls.ManyToOne.CustomerInfrastructureServerComputersControl mtoCustomerInfrastructureServerComputers;
        private System.Windows.Forms.TabPage tabItmDetNetwork;
        internal System.Windows.Forms.TabControl tabDetInfraestructureNetwork;
        private System.Windows.Forms.TabPage tabItmNetworkSite;
        internal System.Windows.Forms.TabControl tabDetSite;
        private System.Windows.Forms.TabPage tabItmSitePrincipal;
        private System.Windows.Forms.GroupBox gbxDetSiteDescription;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetSiteDescription;
        private System.Windows.Forms.GroupBox gbxDetSiteCooling;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetSiteCooling;
        private System.Windows.Forms.GroupBox gbxDetSiteIsolatedRoom;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetSiteIsolatedRoom;
        private System.Windows.Forms.TabPage tabItmRacks;
        internal Controls.ManyToOne.CustomerInfrastructureNetworkSiteRacksControl mtoCustomerInfrastructureNetworkSiteRacks;
        private System.Windows.Forms.TabPage tabItmNetworkSwitches;
        internal Controls.ManyToOne.CustomerInfrastructureNetworkSwitchesControl mtoCustomerInfrastructureNetworkSwitches;
        private System.Windows.Forms.TabPage tabItmNetworkCommutators;
        internal Controls.ManyToOne.CustomerInfrastructureNetworkCommutatorsControl mtoCustomerInfrastructureNetworkCommutators;
        private System.Windows.Forms.TabPage tabItmNetworkCabling;
        internal Controls.ManyToOne.CustomerInfrastructureNetworkCablingsControl mtoCustomerInfrastructureNetworkCablings;
        private System.Windows.Forms.TabPage tabItmNetworkRouters;
        internal Controls.ManyToOne.CustomerInfrastructureNetworkRoutersControl mtoCustomerInfrastructureNetworkRouters;
        private System.Windows.Forms.TabPage tabItmNetworkFirewalls;
        internal Controls.ManyToOne.CustomerInfrastructureNetworkFirewallsControl mtoCustomerInfrastructureNetworkFirewalls;
        private System.Windows.Forms.TabPage tabItmNetworkWifi;
        internal System.Windows.Forms.TabControl tabDetAccessPoints;
        private System.Windows.Forms.TabPage tabItmAccessPoints;
        internal Controls.ManyToOne.CustomerInfrastructureNetworkWifiAccessPointsControl mtoCustomerInfrastructureNetworkWifiAccessPoints;
        private System.Windows.Forms.TabPage tabItmDetEnergy;
        internal System.Windows.Forms.TabControl tabDetInfraestructureEnergy;
        private System.Windows.Forms.TabPage tabItmEnergy;
        internal Controls.ManyToOne.CustomerInfrastructureUPSsControl mtoCustomerInfrastructureUPSs;
        private System.Windows.Forms.TabPage tabItmDetPeripherals;
        internal System.Windows.Forms.TabControl tabDetInfraestructurePeripherals;
        private System.Windows.Forms.TabPage tabItmPeripherals;
        internal Controls.ManyToOne.CustomerInfrastructurePrintersControl mtoCustomerInfrastructurePrinters;
        private System.Windows.Forms.TabPage tabItmDetSoftware;
        internal System.Windows.Forms.TabControl tabDetInfraestructureSoftware;
        private System.Windows.Forms.TabPage tabItmDetAdministrationSoftware;
        internal Controls.ManyToOne.CustomerInfrastructureAdministationSoftwaresControl mtoCustomerInfrastructureAdministationSoftwares;
        private System.Windows.Forms.TabPage tabItmDetSecuritySoftware;
        internal Controls.ManyToOne.CustomerInfrastructureSecuritySoftwaresControl mtoCustomerInfrastructureSecuritySoftwares;
        private System.Windows.Forms.TabPage tabItmDetBackupSoftware;
        internal Controls.ManyToOne.CustomerInfrastructureBackupSoftwaresControl mtoCustomerInfrastructureBackupSoftwares;
        private System.Windows.Forms.TabPage tabItmDetSuppliers;
        internal System.Windows.Forms.TabControl tabDetInfraestructureSuppliers;
        private System.Windows.Forms.TabPage tabItmDetISP;
        internal Controls.ManyToOne.CustomerInfrastructureISPsControl mtoCustomerInfrastructureISPs;
        private System.Windows.Forms.TabPage tabItmDetTelephony;
        internal Controls.ManyToOne.CustomerInfrastructureTelephoniesControl mtoCustomerInfrastructureTelephonies;
        private System.Windows.Forms.TabPage tabItmDetVideo;
        internal System.Windows.Forms.TabControl tabDetInfraestructureVideo;
        private System.Windows.Forms.TabPage tabItmDetCCTV;
        internal Controls.ManyToOne.CustomerInfrastructureCCTVsControl mtoCustomerInfrastructureCCTVs;
        internal Controls.Choosers.BusinessTypeChooserControl btcDetBusinessType;
        private System.Windows.Forms.Label lblDetName;
        private System.Windows.Forms.Label lblDetBusinessType;
        internal System.Windows.Forms.TextBox txtDetComercialName;
        internal System.Windows.Forms.TextBox txtDetName;
        private System.Windows.Forms.Label lblDetComercialName;
        private System.Windows.Forms.TabPage tabItmPrincipal;
        private System.Windows.Forms.GroupBox gbxDetGroundedOutlet;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetGroundedOutlet;
        private System.Windows.Forms.GroupBox gbxDetTrainingAndCourses;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetTrainingAndCourses;



    }
}