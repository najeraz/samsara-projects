namespace Samsara.CustomerContext.Controls.Controls
{
    partial class CustomerInfrastructureBackupSoftwaresControl
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
            Samsara.CustomerContext.Core.Parameters.BackupSoftwareBrandParameters backupSoftwareBrandParameters1 = new Samsara.CustomerContext.Core.Parameters.BackupSoftwareBrandParameters();
            Samsara.CustomerContext.Core.Parameters.CustomerInfrastructureServerComputerParameters customerInfrastructureServerComputerParameters1 = new Samsara.CustomerContext.Core.Parameters.CustomerInfrastructureServerComputerParameters();
            this.lblBackupSoftwareBrand = new Infragistics.Win.Misc.UltraLabel();
            this.gbxDescription = new System.Windows.Forms.GroupBox();
            this.txtDescription = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblCustomerInfraestructureServerComputer = new Infragistics.Win.Misc.UltraLabel();
            this.bsbcBackupSoftwareBrand = new Samsara.CustomerContext.Controls.Controls.BackupSoftwareBrandChooserControl();
            this.cisccCustomerInfrastructureServerComputer = new Samsara.CustomerContext.Controls.Controls.CustomerInfrastructureServerComputerChooserControl();
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
            this.gbxDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
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
            this.tabItmPrincipal.Controls.Add(this.cisccCustomerInfrastructureServerComputer);
            this.tabItmPrincipal.Controls.Add(this.bsbcBackupSoftwareBrand);
            this.tabItmPrincipal.Controls.Add(this.lblCustomerInfraestructureServerComputer);
            this.tabItmPrincipal.Controls.Add(this.gbxDescription);
            this.tabItmPrincipal.Controls.Add(this.lblBackupSoftwareBrand);
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
            // lblBackupSoftwareBrand
            // 
            this.lblBackupSoftwareBrand.AutoSize = true;
            this.lblBackupSoftwareBrand.Location = new System.Drawing.Point(13, 22);
            this.lblBackupSoftwareBrand.Name = "lblBackupSoftwareBrand";
            this.lblBackupSoftwareBrand.Size = new System.Drawing.Size(39, 14);
            this.lblBackupSoftwareBrand.TabIndex = 106;
            this.lblBackupSoftwareBrand.Text = "Marca:";
            // 
            // gbxDescription
            // 
            this.gbxDescription.Controls.Add(this.txtDescription);
            this.gbxDescription.Location = new System.Drawing.Point(331, 3);
            this.gbxDescription.Name = "gbxDescription";
            this.gbxDescription.Size = new System.Drawing.Size(351, 75);
            this.gbxDescription.TabIndex = 110;
            this.gbxDescription.TabStop = false;
            this.gbxDescription.Text = "Descripción:";
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(3, 16);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(345, 56);
            this.txtDescription.TabIndex = 0;
            // 
            // lblCustomerInfraestructureServerComputer
            // 
            this.lblCustomerInfraestructureServerComputer.AutoSize = true;
            this.lblCustomerInfraestructureServerComputer.Location = new System.Drawing.Point(13, 49);
            this.lblCustomerInfraestructureServerComputer.Name = "lblCustomerInfraestructureServerComputer";
            this.lblCustomerInfraestructureServerComputer.Size = new System.Drawing.Size(50, 14);
            this.lblCustomerInfraestructureServerComputer.TabIndex = 111;
            this.lblCustomerInfraestructureServerComputer.Text = "Servidor:";
            // 
            // bsbcBackupSoftwareBrand
            // 
            this.bsbcBackupSoftwareBrand.CustomParent = null;
            this.bsbcBackupSoftwareBrand.DisplayMember = "Name";
            this.bsbcBackupSoftwareBrand.Location = new System.Drawing.Point(88, 17);
            this.bsbcBackupSoftwareBrand.Name = "bsbcBackupSoftwareBrand";
            backupSoftwareBrandParameters1.BackupSoftwareBrandId = null;
            backupSoftwareBrandParameters1.Description = null;
            backupSoftwareBrandParameters1.Name = null;
            this.bsbcBackupSoftwareBrand.Parameters = backupSoftwareBrandParameters1;
            this.bsbcBackupSoftwareBrand.ReadOnly = false;
            this.bsbcBackupSoftwareBrand.Size = new System.Drawing.Size(226, 22);
            this.bsbcBackupSoftwareBrand.TabIndex = 113;
            this.bsbcBackupSoftwareBrand.Value = null;
            this.bsbcBackupSoftwareBrand.ValueMember = "BackupSoftwareBrandId";
            // 
            // cisccCustomerInfrastructureServerComputer
            // 
            this.cisccCustomerInfrastructureServerComputer.CustomParent = null;
            this.cisccCustomerInfrastructureServerComputer.DisplayMember = "Name";
            this.cisccCustomerInfrastructureServerComputer.Location = new System.Drawing.Point(88, 45);
            this.cisccCustomerInfrastructureServerComputer.Name = "cisccCustomerInfrastructureServerComputer";
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
            this.cisccCustomerInfrastructureServerComputer.Parameters = customerInfrastructureServerComputerParameters1;
            this.cisccCustomerInfrastructureServerComputer.ReadOnly = false;
            this.cisccCustomerInfrastructureServerComputer.Size = new System.Drawing.Size(226, 22);
            this.cisccCustomerInfrastructureServerComputer.TabIndex = 114;
            this.cisccCustomerInfrastructureServerComputer.Value = null;
            this.cisccCustomerInfrastructureServerComputer.ValueMember = "CustomerInfrastructureServerComputerId";
            // 
            // CustomerInfrastructureBackupSoftwaresControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CustomerInfrastructureBackupSoftwaresControl";
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
            this.gbxDescription.ResumeLayout(false);
            this.gbxDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblBackupSoftwareBrand;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDescription;
        private Infragistics.Win.Misc.UltraLabel lblCustomerInfraestructureServerComputer;
        private System.Windows.Forms.GroupBox gbxDescription;
        internal CustomerInfrastructureServerComputerChooserControl cisccCustomerInfrastructureServerComputer;
        internal BackupSoftwareBrandChooserControl bsbcBackupSoftwareBrand;


    }
}
