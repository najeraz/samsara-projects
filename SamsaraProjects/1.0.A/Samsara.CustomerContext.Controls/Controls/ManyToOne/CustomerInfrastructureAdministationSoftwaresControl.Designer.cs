namespace Samsara.CustomerContext.Controls.Controls.ManyToOne
{
    partial class CustomerInfrastructureAdministationSoftwaresControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInfrastructureAdministationSoftwaresControl));
            Samsara.CustomerContext.Core.Parameters.DBMSParameters dbmsParameters1 = new Samsara.CustomerContext.Core.Parameters.DBMSParameters();
            Samsara.CustomerContext.Core.Parameters.CustomerInfrastructureServerComputerParameters customerInfrastructureServerComputerParameters1 = new Samsara.CustomerContext.Core.Parameters.CustomerInfrastructureServerComputerParameters();
            this.lblNumberOfUsers = new Infragistics.Win.Misc.UltraLabel();
            this.txtName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblName = new Infragistics.Win.Misc.UltraLabel();
            this.lblCustomerInfraestructureServerComputer = new Infragistics.Win.Misc.UltraLabel();
            this.lblDBMS = new Infragistics.Win.Misc.UltraLabel();
            this.tabItmDescription = new System.Windows.Forms.TabPage();
            this.gbxDescription = new System.Windows.Forms.GroupBox();
            this.txtDescription = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.gbxModules = new System.Windows.Forms.GroupBox();
            this.txtModules = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.steNumberOfUsers = new Samsara.Controls.Controls.SamsaraTextEditor();
            this.dcDetDBMS = new Samsara.CustomerContext.Controls.Controls.Choosers.DBMSChooserControl();
            this.cisccDetCustomerInfrastructureServerComputer = new Samsara.CustomerContext.Controls.Controls.Choosers.CustomerInfrastructureServerComputerChooserControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            this.tabItmDescription.SuspendLayout();
            this.gbxDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            this.gbxModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModules)).BeginInit();
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
            this.tabDetail.Controls.Add(this.tabItmDescription);
            this.tabDetail.Size = new System.Drawing.Size(704, 105);
            this.tabDetail.Controls.SetChildIndex(this.tabItmDescription, 0);
            this.tabDetail.Controls.SetChildIndex(this.tabItmPrincipal, 0);
            // 
            // tabItmPrincipal
            // 
            this.tabItmPrincipal.Controls.Add(this.cisccDetCustomerInfrastructureServerComputer);
            this.tabItmPrincipal.Controls.Add(this.dcDetDBMS);
            this.tabItmPrincipal.Controls.Add(this.steNumberOfUsers);
            this.tabItmPrincipal.Controls.Add(this.lblNumberOfUsers);
            this.tabItmPrincipal.Controls.Add(this.txtName);
            this.tabItmPrincipal.Controls.Add(this.lblName);
            this.tabItmPrincipal.Controls.Add(this.lblCustomerInfraestructureServerComputer);
            this.tabItmPrincipal.Controls.Add(this.lblDBMS);
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
            // lblNumberOfUsers
            // 
            this.lblNumberOfUsers.AutoSize = true;
            this.lblNumberOfUsers.Location = new System.Drawing.Point(8, 46);
            this.lblNumberOfUsers.Name = "lblNumberOfUsers";
            this.lblNumberOfUsers.Size = new System.Drawing.Size(95, 14);
            this.lblNumberOfUsers.TabIndex = 105;
            this.lblNumberOfUsers.Text = "Num de Usuarios:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(226, 21);
            this.txtName.TabIndex = 108;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 14);
            this.lblName.TabIndex = 106;
            this.lblName.Text = "Nombre:";
            // 
            // lblCustomerInfraestructureServerComputer
            // 
            this.lblCustomerInfraestructureServerComputer.AutoSize = true;
            this.lblCustomerInfraestructureServerComputer.Location = new System.Drawing.Point(366, 46);
            this.lblCustomerInfraestructureServerComputer.Name = "lblCustomerInfraestructureServerComputer";
            this.lblCustomerInfraestructureServerComputer.Size = new System.Drawing.Size(67, 14);
            this.lblCustomerInfraestructureServerComputer.TabIndex = 101;
            this.lblCustomerInfraestructureServerComputer.Text = "Montado en:";
            // 
            // lblDBMS
            // 
            this.lblDBMS.AutoSize = true;
            this.lblDBMS.Location = new System.Drawing.Point(366, 19);
            this.lblDBMS.Name = "lblDBMS";
            this.lblDBMS.Size = new System.Drawing.Size(39, 14);
            this.lblDBMS.TabIndex = 102;
            this.lblDBMS.Text = "SGBD:";
            // 
            // tabItmDescription
            // 
            this.tabItmDescription.BackColor = System.Drawing.Color.Transparent;
            this.tabItmDescription.Controls.Add(this.gbxDescription);
            this.tabItmDescription.Controls.Add(this.gbxModules);
            this.tabItmDescription.Location = new System.Drawing.Point(4, 22);
            this.tabItmDescription.Name = "tabItmDescription";
            this.tabItmDescription.Size = new System.Drawing.Size(696, 79);
            this.tabItmDescription.TabIndex = 1;
            this.tabItmDescription.Text = "Descripción";
            // 
            // gbxDescription
            // 
            this.gbxDescription.Controls.Add(this.txtDescription);
            this.gbxDescription.Location = new System.Drawing.Point(351, 2);
            this.gbxDescription.Name = "gbxDescription";
            this.gbxDescription.Size = new System.Drawing.Size(343, 75);
            this.gbxDescription.TabIndex = 97;
            this.gbxDescription.TabStop = false;
            this.gbxDescription.Text = "Descripción General:";
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(3, 16);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(337, 56);
            this.txtDescription.TabIndex = 0;
            // 
            // gbxModules
            // 
            this.gbxModules.Controls.Add(this.txtModules);
            this.gbxModules.Location = new System.Drawing.Point(2, 2);
            this.gbxModules.Name = "gbxModules";
            this.gbxModules.Size = new System.Drawing.Size(343, 75);
            this.gbxModules.TabIndex = 96;
            this.gbxModules.TabStop = false;
            this.gbxModules.Text = "Modulos:";
            // 
            // txtModules
            // 
            this.txtModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModules.Location = new System.Drawing.Point(3, 16);
            this.txtModules.Multiline = true;
            this.txtModules.Name = "txtModules";
            this.txtModules.Size = new System.Drawing.Size(337, 56);
            this.txtModules.TabIndex = 0;
            // 
            // steNumberOfUsers
            // 
            this.steNumberOfUsers.CustomParent = null;
            this.steNumberOfUsers.Location = new System.Drawing.Point(109, 42);
            this.steNumberOfUsers.MaskType = Samsara.Support.Util.TextMaskFormatEnum.NaturalQuantity;
            this.steNumberOfUsers.Name = "steNumberOfUsers";
            this.steNumberOfUsers.ReadOnly = false;
            this.steNumberOfUsers.Size = new System.Drawing.Size(227, 20);
            this.steNumberOfUsers.TabIndex = 109;
            this.steNumberOfUsers.Value = ((object)(resources.GetObject("steNumberOfUsers.Value")));
            // 
            // dcDetDBMS
            // 
            this.dcDetDBMS.CustomParent = null;
            this.dcDetDBMS.DisplayMember = "Name";
            this.dcDetDBMS.Location = new System.Drawing.Point(463, 14);
            this.dcDetDBMS.Name = "dcDetDBMS";
            dbmsParameters1.DBMSId = null;
            dbmsParameters1.Description = null;
            dbmsParameters1.Name = null;
            this.dcDetDBMS.Parameters = dbmsParameters1;
            this.dcDetDBMS.ReadOnly = false;
            this.dcDetDBMS.Size = new System.Drawing.Size(226, 22);
            this.dcDetDBMS.TabIndex = 110;
            this.dcDetDBMS.Value = null;
            this.dcDetDBMS.ValueMember = "DBMSId";
            // 
            // cisccDetCustomerInfrastructureServerComputer
            // 
            this.cisccDetCustomerInfrastructureServerComputer.CustomParent = null;
            this.cisccDetCustomerInfrastructureServerComputer.DisplayMember = "Name";
            this.cisccDetCustomerInfrastructureServerComputer.Location = new System.Drawing.Point(463, 42);
            this.cisccDetCustomerInfrastructureServerComputer.Name = "cisccDetCustomerInfrastructureServerComputer";
            customerInfrastructureServerComputerParameters1.ComputerBrandId = null;
            customerInfrastructureServerComputerParameters1.CPU = null;
            customerInfrastructureServerComputerParameters1.CustomerInfrastructureId = null;
            customerInfrastructureServerComputerParameters1.CustomerInfrastructureServerComputerId = null;
            customerInfrastructureServerComputerParameters1.ManufacturerReferenceNumber = null;
            customerInfrastructureServerComputerParameters1.OperativeSystemId = null;
            customerInfrastructureServerComputerParameters1.RAM = null;
            customerInfrastructureServerComputerParameters1.Scalability = null;
            customerInfrastructureServerComputerParameters1.SerialNumber = null;
            customerInfrastructureServerComputerParameters1.ServerModel = null;
            customerInfrastructureServerComputerParameters1.StorageSystem = null;
            customerInfrastructureServerComputerParameters1.Utilization = null;
            this.cisccDetCustomerInfrastructureServerComputer.Parameters = customerInfrastructureServerComputerParameters1;
            this.cisccDetCustomerInfrastructureServerComputer.ReadOnly = false;
            this.cisccDetCustomerInfrastructureServerComputer.Size = new System.Drawing.Size(227, 22);
            this.cisccDetCustomerInfrastructureServerComputer.TabIndex = 111;
            this.cisccDetCustomerInfrastructureServerComputer.Value = null;
            this.cisccDetCustomerInfrastructureServerComputer.ValueMember = "CustomerInfrastructureServerComputerId";
            // 
            // CustomerInfrastructureAdministationSoftwaresControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CustomerInfrastructureAdministationSoftwaresControl";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            this.tabItmDescription.ResumeLayout(false);
            this.gbxDescription.ResumeLayout(false);
            this.gbxDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            this.gbxModules.ResumeLayout(false);
            this.gbxModules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabItmDescription;
        private Infragistics.Win.Misc.UltraLabel lblNumberOfUsers;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtName;
        private Infragistics.Win.Misc.UltraLabel lblName;
        private Infragistics.Win.Misc.UltraLabel lblCustomerInfraestructureServerComputer;
        private Infragistics.Win.Misc.UltraLabel lblDBMS;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDescription;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtModules;
        private System.Windows.Forms.GroupBox gbxDescription;
        private System.Windows.Forms.GroupBox gbxModules;
        internal Samsara.Controls.Controls.SamsaraTextEditor steNumberOfUsers;
        internal Samsara.CustomerContext.Controls.Controls.Choosers.CustomerInfrastructureServerComputerChooserControl cisccDetCustomerInfrastructureServerComputer;
        internal Samsara.CustomerContext.Controls.Controls.Choosers.DBMSChooserControl dcDetDBMS;



    }
}
