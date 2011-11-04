namespace Samsara.CustomerContext.Controls.Controls.ManyToOne
{
    partial class CustomerInfrastructureServerComputersControl
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
            Samsara.CustomerContext.Core.Parameters.ComputerBrandParameters computerBrandParameters1 = new Samsara.CustomerContext.Core.Parameters.ComputerBrandParameters();
            Samsara.CustomerContext.Core.Parameters.OperativeSystemParameters operativeSystemParameters1 = new Samsara.CustomerContext.Core.Parameters.OperativeSystemParameters();
            this.lblComputerBrand = new Infragistics.Win.Misc.UltraLabel();
            this.txtManufacturerNumber = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtModel = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtSerialNumber = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblModel = new Infragistics.Win.Misc.UltraLabel();
            this.lblSerialNumber = new Infragistics.Win.Misc.UltraLabel();
            this.lblManufacturerNumber = new Infragistics.Win.Misc.UltraLabel();
            this.tabItmSpecs = new System.Windows.Forms.TabPage();
            this.gbxStorage = new System.Windows.Forms.GroupBox();
            this.txtStorage = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtRAM = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtCPU = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblCPU = new Infragistics.Win.Misc.UltraLabel();
            this.lblRAM = new Infragistics.Win.Misc.UltraLabel();
            this.tabItmDesciption = new System.Windows.Forms.TabPage();
            this.gbxScalability = new System.Windows.Forms.GroupBox();
            this.txtScalability = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.gbxUtilization = new System.Windows.Forms.GroupBox();
            this.txtUtilization = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tabItmSoftware = new System.Windows.Forms.TabPage();
            this.lblOperativeSystem = new Infragistics.Win.Misc.UltraLabel();
            this.tabItmDBMS = new System.Windows.Forms.TabPage();
            this.mtoCustomerInfrastructureServerComputerDBMSs = new Samsara.CustomerContext.Controls.Controls.ManyToOne.CustomerInfrastructureServerComputerDBMSsControl();
            this.cbcComputerBrand = new Samsara.CustomerContext.Controls.Controls.Choosers.ComputerBrandChooserControl();
            this.oscOperativeSystem = new Samsara.CustomerContext.Controls.Controls.Choosers.OperativeSystemChooserControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtManufacturerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNumber)).BeginInit();
            this.tabItmSpecs.SuspendLayout();
            this.gbxStorage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPU)).BeginInit();
            this.tabItmDesciption.SuspendLayout();
            this.gbxScalability.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtScalability)).BeginInit();
            this.gbxUtilization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUtilization)).BeginInit();
            this.tabItmSoftware.SuspendLayout();
            this.tabItmDBMS.SuspendLayout();
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
            this.grdRelations.Size = new System.Drawing.Size(710, 120);
            // 
            // upnDetailButtons
            // 
            this.upnDetailButtons.Location = new System.Drawing.Point(0, 120);
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
            this.gbxDetDetail.Location = new System.Drawing.Point(0, 145);
            this.gbxDetDetail.Size = new System.Drawing.Size(710, 243);
            // 
            // tabDetail
            // 
            this.tabDetail.Controls.Add(this.tabItmSpecs);
            this.tabDetail.Controls.Add(this.tabItmDesciption);
            this.tabDetail.Controls.Add(this.tabItmSoftware);
            this.tabDetail.Controls.Add(this.tabItmDBMS);
            this.tabDetail.Size = new System.Drawing.Size(704, 224);
            this.tabDetail.Controls.SetChildIndex(this.tabItmDBMS, 0);
            this.tabDetail.Controls.SetChildIndex(this.tabItmSoftware, 0);
            this.tabDetail.Controls.SetChildIndex(this.tabItmDesciption, 0);
            this.tabDetail.Controls.SetChildIndex(this.tabItmSpecs, 0);
            this.tabDetail.Controls.SetChildIndex(this.tabItmPrincipal, 0);
            // 
            // tabItmPrincipal
            // 
            this.tabItmPrincipal.Controls.Add(this.cbcComputerBrand);
            this.tabItmPrincipal.Controls.Add(this.txtManufacturerNumber);
            this.tabItmPrincipal.Controls.Add(this.txtModel);
            this.tabItmPrincipal.Controls.Add(this.txtSerialNumber);
            this.tabItmPrincipal.Controls.Add(this.lblModel);
            this.tabItmPrincipal.Controls.Add(this.lblSerialNumber);
            this.tabItmPrincipal.Controls.Add(this.lblManufacturerNumber);
            this.tabItmPrincipal.Controls.Add(this.lblComputerBrand);
            this.tabItmPrincipal.Size = new System.Drawing.Size(696, 198);
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
            // lblComputerBrand
            // 
            this.lblComputerBrand.AutoSize = true;
            this.lblComputerBrand.Location = new System.Drawing.Point(13, 22);
            this.lblComputerBrand.Name = "lblComputerBrand";
            this.lblComputerBrand.Size = new System.Drawing.Size(39, 14);
            this.lblComputerBrand.TabIndex = 106;
            this.lblComputerBrand.Text = "Marca:";
            // 
            // txtManufacturerNumber
            // 
            this.txtManufacturerNumber.Location = new System.Drawing.Point(124, 99);
            this.txtManufacturerNumber.Name = "txtManufacturerNumber";
            this.txtManufacturerNumber.Size = new System.Drawing.Size(226, 21);
            this.txtManufacturerNumber.TabIndex = 114;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(124, 45);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(226, 21);
            this.txtModel.TabIndex = 115;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(124, 72);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(226, 21);
            this.txtSerialNumber.TabIndex = 116;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(13, 49);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(45, 14);
            this.lblModel.TabIndex = 110;
            this.lblModel.Text = "Modelo:";
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Location = new System.Drawing.Point(13, 76);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(34, 14);
            this.lblSerialNumber.TabIndex = 109;
            this.lblSerialNumber.Text = "Serie:";
            // 
            // lblManufacturerNumber
            // 
            this.lblManufacturerNumber.AutoSize = true;
            this.lblManufacturerNumber.Location = new System.Drawing.Point(13, 103);
            this.lblManufacturerNumber.Name = "lblManufacturerNumber";
            this.lblManufacturerNumber.Size = new System.Drawing.Size(104, 14);
            this.lblManufacturerNumber.TabIndex = 111;
            this.lblManufacturerNumber.Text = "Numero Fabricante:";
            // 
            // tabItmSpecs
            // 
            this.tabItmSpecs.BackColor = System.Drawing.Color.Transparent;
            this.tabItmSpecs.Controls.Add(this.gbxStorage);
            this.tabItmSpecs.Controls.Add(this.txtRAM);
            this.tabItmSpecs.Controls.Add(this.txtCPU);
            this.tabItmSpecs.Controls.Add(this.lblCPU);
            this.tabItmSpecs.Controls.Add(this.lblRAM);
            this.tabItmSpecs.Location = new System.Drawing.Point(4, 22);
            this.tabItmSpecs.Name = "tabItmSpecs";
            this.tabItmSpecs.Size = new System.Drawing.Size(696, 198);
            this.tabItmSpecs.TabIndex = 1;
            this.tabItmSpecs.Text = "Especificaciones";
            // 
            // gbxStorage
            // 
            this.gbxStorage.Controls.Add(this.txtStorage);
            this.gbxStorage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxStorage.Location = new System.Drawing.Point(0, 78);
            this.gbxStorage.Name = "gbxStorage";
            this.gbxStorage.Size = new System.Drawing.Size(696, 120);
            this.gbxStorage.TabIndex = 104;
            this.gbxStorage.TabStop = false;
            this.gbxStorage.Text = "Sistema Almacenamiento:";
            // 
            // txtStorage
            // 
            this.txtStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStorage.Location = new System.Drawing.Point(3, 16);
            this.txtStorage.Multiline = true;
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.Size = new System.Drawing.Size(690, 101);
            this.txtStorage.TabIndex = 0;
            // 
            // txtRAM
            // 
            this.txtRAM.Location = new System.Drawing.Point(65, 42);
            this.txtRAM.Name = "txtRAM";
            this.txtRAM.Size = new System.Drawing.Size(226, 21);
            this.txtRAM.TabIndex = 103;
            // 
            // txtCPU
            // 
            this.txtCPU.Location = new System.Drawing.Point(65, 15);
            this.txtCPU.Name = "txtCPU";
            this.txtCPU.Size = new System.Drawing.Size(226, 21);
            this.txtCPU.TabIndex = 102;
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(14, 19);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(31, 14);
            this.lblCPU.TabIndex = 100;
            this.lblCPU.Text = "CPU:";
            // 
            // lblRAM
            // 
            this.lblRAM.AutoSize = true;
            this.lblRAM.Location = new System.Drawing.Point(14, 46);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(32, 14);
            this.lblRAM.TabIndex = 101;
            this.lblRAM.Text = "RAM:";
            // 
            // tabItmDesciption
            // 
            this.tabItmDesciption.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDesciption.Controls.Add(this.gbxScalability);
            this.tabItmDesciption.Controls.Add(this.gbxUtilization);
            this.tabItmDesciption.Location = new System.Drawing.Point(4, 22);
            this.tabItmDesciption.Name = "tabItmDesciption";
            this.tabItmDesciption.Size = new System.Drawing.Size(696, 198);
            this.tabItmDesciption.TabIndex = 2;
            this.tabItmDesciption.Text = "Descripción";
            // 
            // gbxScalability
            // 
            this.gbxScalability.Controls.Add(this.txtScalability);
            this.gbxScalability.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxScalability.Location = new System.Drawing.Point(0, 86);
            this.gbxScalability.Name = "gbxScalability";
            this.gbxScalability.Size = new System.Drawing.Size(696, 86);
            this.gbxScalability.TabIndex = 99;
            this.gbxScalability.TabStop = false;
            this.gbxScalability.Text = "Escalabilidad:";
            // 
            // txtScalability
            // 
            this.txtScalability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScalability.Location = new System.Drawing.Point(3, 16);
            this.txtScalability.Multiline = true;
            this.txtScalability.Name = "txtScalability";
            this.txtScalability.Size = new System.Drawing.Size(690, 67);
            this.txtScalability.TabIndex = 0;
            // 
            // gbxUtilization
            // 
            this.gbxUtilization.Controls.Add(this.txtUtilization);
            this.gbxUtilization.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxUtilization.Location = new System.Drawing.Point(0, 0);
            this.gbxUtilization.Name = "gbxUtilization";
            this.gbxUtilization.Size = new System.Drawing.Size(696, 86);
            this.gbxUtilization.TabIndex = 98;
            this.gbxUtilization.TabStop = false;
            this.gbxUtilization.Text = "Utilización:";
            // 
            // txtUtilization
            // 
            this.txtUtilization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUtilization.Location = new System.Drawing.Point(3, 16);
            this.txtUtilization.Multiline = true;
            this.txtUtilization.Name = "txtUtilization";
            this.txtUtilization.Size = new System.Drawing.Size(690, 67);
            this.txtUtilization.TabIndex = 0;
            // 
            // tabItmSoftware
            // 
            this.tabItmSoftware.BackColor = System.Drawing.Color.Transparent;
            this.tabItmSoftware.Controls.Add(this.oscOperativeSystem);
            this.tabItmSoftware.Controls.Add(this.lblOperativeSystem);
            this.tabItmSoftware.Location = new System.Drawing.Point(4, 22);
            this.tabItmSoftware.Name = "tabItmSoftware";
            this.tabItmSoftware.Size = new System.Drawing.Size(696, 198);
            this.tabItmSoftware.TabIndex = 3;
            this.tabItmSoftware.Text = "Software General";
            // 
            // lblOperativeSystem
            // 
            this.lblOperativeSystem.AutoSize = true;
            this.lblOperativeSystem.Location = new System.Drawing.Point(12, 18);
            this.lblOperativeSystem.Name = "lblOperativeSystem";
            this.lblOperativeSystem.Size = new System.Drawing.Size(100, 14);
            this.lblOperativeSystem.TabIndex = 93;
            this.lblOperativeSystem.Text = "Sistema Operativo:";
            // 
            // tabItmDBMS
            // 
            this.tabItmDBMS.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDBMS.Controls.Add(this.mtoCustomerInfrastructureServerComputerDBMSs);
            this.tabItmDBMS.Location = new System.Drawing.Point(4, 22);
            this.tabItmDBMS.Name = "tabItmDBMS";
            this.tabItmDBMS.Size = new System.Drawing.Size(696, 198);
            this.tabItmDBMS.TabIndex = 4;
            this.tabItmDBMS.Text = "Sistemas Gestores de Bases de Datos";
            // 
            // mtoCustomerInfrastructureServerComputerDBMSs
            // 
            this.mtoCustomerInfrastructureServerComputerDBMSs.CustomerInfrastructureServerComputer = null;
            this.mtoCustomerInfrastructureServerComputerDBMSs.CustomParent = null;
            this.mtoCustomerInfrastructureServerComputerDBMSs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtoCustomerInfrastructureServerComputerDBMSs.Location = new System.Drawing.Point(0, 0);
            this.mtoCustomerInfrastructureServerComputerDBMSs.Name = "mtoCustomerInfrastructureServerComputerDBMSs";
            this.mtoCustomerInfrastructureServerComputerDBMSs.Size = new System.Drawing.Size(696, 198);
            this.mtoCustomerInfrastructureServerComputerDBMSs.TabIndex = 0;
            // 
            // cbcComputerBrand
            // 
            this.cbcComputerBrand.CustomParent = null;
            this.cbcComputerBrand.DisplayMember = "Name";
            this.cbcComputerBrand.Location = new System.Drawing.Point(124, 17);
            this.cbcComputerBrand.Name = "cbcComputerBrand";
            computerBrandParameters1.ComputerBrandId = null;
            computerBrandParameters1.Description = null;
            computerBrandParameters1.Name = null;
            this.cbcComputerBrand.Parameters = computerBrandParameters1;
            this.cbcComputerBrand.ReadOnly = false;
            this.cbcComputerBrand.Size = new System.Drawing.Size(226, 22);
            this.cbcComputerBrand.TabIndex = 117;
            this.cbcComputerBrand.Value = null;
            this.cbcComputerBrand.ValueMember = "ComputerBrandId";
            // 
            // dcDBMS
            // 
            this.oscOperativeSystem.CustomParent = null;
            this.oscOperativeSystem.DisplayMember = "Name";
            this.oscOperativeSystem.Location = new System.Drawing.Point(118, 14);
            this.oscOperativeSystem.Name = "oscOperativeSystem";
            operativeSystemParameters1.OperativeSystemId = null;
            operativeSystemParameters1.Description = null;
            operativeSystemParameters1.Name = null;
            this.oscOperativeSystem.Parameters = operativeSystemParameters1;
            this.oscOperativeSystem.ReadOnly = false;
            this.oscOperativeSystem.Size = new System.Drawing.Size(226, 22);
            this.oscOperativeSystem.TabIndex = 95;
            this.oscOperativeSystem.Value = null;
            this.oscOperativeSystem.ValueMember = "OperativeSystemId";
            // 
            // CustomerInfrastructureServerComputersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CustomerInfrastructureServerComputersControl";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtManufacturerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNumber)).EndInit();
            this.tabItmSpecs.ResumeLayout(false);
            this.tabItmSpecs.PerformLayout();
            this.gbxStorage.ResumeLayout(false);
            this.gbxStorage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPU)).EndInit();
            this.tabItmDesciption.ResumeLayout(false);
            this.gbxScalability.ResumeLayout(false);
            this.gbxScalability.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtScalability)).EndInit();
            this.gbxUtilization.ResumeLayout(false);
            this.gbxUtilization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUtilization)).EndInit();
            this.tabItmSoftware.ResumeLayout(false);
            this.tabItmSoftware.PerformLayout();
            this.tabItmDBMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblComputerBrand;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtManufacturerNumber;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtModel;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtSerialNumber;
        private Infragistics.Win.Misc.UltraLabel lblModel;
        private Infragistics.Win.Misc.UltraLabel lblSerialNumber;
        private Infragistics.Win.Misc.UltraLabel lblManufacturerNumber;
        private System.Windows.Forms.TabPage tabItmSpecs;
        private System.Windows.Forms.TabPage tabItmDesciption;
        private System.Windows.Forms.TabPage tabItmSoftware;
        private System.Windows.Forms.TabPage tabItmDBMS;
        private System.Windows.Forms.GroupBox gbxStorage;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtStorage;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtRAM;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtCPU;
        private Infragistics.Win.Misc.UltraLabel lblCPU;
        private Infragistics.Win.Misc.UltraLabel lblRAM;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtScalability;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtUtilization;
        private Infragistics.Win.Misc.UltraLabel lblOperativeSystem;
        private System.Windows.Forms.GroupBox gbxScalability;
        private System.Windows.Forms.GroupBox gbxUtilization;
        internal CustomerInfrastructureServerComputerDBMSsControl mtoCustomerInfrastructureServerComputerDBMSs;
        internal Choosers.OperativeSystemChooserControl oscOperativeSystem;
        internal Choosers.ComputerBrandChooserControl cbcComputerBrand;


    }
}
