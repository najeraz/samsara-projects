
namespace Samsara.TIConsulting.Controls.Controls.ManyToOne
{
    partial class ServerConsultingOldServerComputersControl
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
            Samsara.CustomerContext.Core.Parameters.RackTypeParameters rackTypeParameters1 = new Samsara.CustomerContext.Core.Parameters.RackTypeParameters();
            Samsara.CustomerContext.Core.Parameters.ServerComputerTypeParameters serverComputerTypeParameters1 = new Samsara.CustomerContext.Core.Parameters.ServerComputerTypeParameters();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConsultingOldServerComputersControl));
            Samsara.CustomerContext.Core.Parameters.OperativeSystemParameters operativeSystemParameters1 = new Samsara.CustomerContext.Core.Parameters.OperativeSystemParameters();
            Samsara.CustomerContext.Core.Parameters.ComputerBrandParameters computerBrandParameters1 = new Samsara.CustomerContext.Core.Parameters.ComputerBrandParameters();
            this.ugbxServerComputerType = new Infragistics.Win.Misc.UltraGroupBox();
            this.rtcRackType = new Samsara.CustomerContext.Controls.Controls.Choosers.RackTypeChooserControl();
            this.sctcServerComputerType = new Samsara.CustomerContext.Controls.Controls.ServerComputerTypeChooserControl();
            this.ulblDetRackType = new Infragistics.Win.Misc.UltraLabel();
            this.txtServerModel = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ulblOperativeSystem = new Infragistics.Win.Misc.UltraLabel();
            this.ulblServerModel = new Infragistics.Win.Misc.UltraLabel();
            this.ulblServerComputerBrand = new Infragistics.Win.Misc.UltraLabel();
            this.tabItmSpecs = new System.Windows.Forms.TabPage();
            this.ugbxServerSpecs = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtServerSpecs = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ulblServerQuantity = new Infragistics.Win.Misc.UltraLabel();
            this.txtServersQuantity = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.oscOperativeSystem = new Samsara.CustomerContext.Controls.Controls.Choosers.OperativeSystemChooserControl();
            this.cbcComputerBrand = new Samsara.CustomerContext.Controls.Controls.Choosers.ComputerBrandChooserControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.ugbxServerComputerType)).BeginInit();
            this.ugbxServerComputerType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerModel)).BeginInit();
            this.tabItmSpecs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbxServerSpecs)).BeginInit();
            this.ugbxServerSpecs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerSpecs)).BeginInit();
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
            this.grdRelations.Size = new System.Drawing.Size(634, 204);
            this.grdRelations.TabIndex = 0;
            // 
            // upnDetailButtons
            // 
            this.upnDetailButtons.Location = new System.Drawing.Point(0, 204);
            this.upnDetailButtons.Size = new System.Drawing.Size(634, 25);
            this.upnDetailButtons.TabIndex = 1;
            // 
            // upnlSeparatorDeleteRelation
            // 
            this.upnlSeparatorDeleteRelation.Location = new System.Drawing.Point(246, 0);
            this.upnlSeparatorDeleteRelation.TabIndex = 0;
            // 
            // ubtnDeleteRelation
            // 
            this.ubtnDeleteRelation.Location = new System.Drawing.Point(262, 0);
            this.ubtnDeleteRelation.TabIndex = 1;
            // 
            // upnlSeparatorEditRelation
            // 
            this.upnlSeparatorEditRelation.Location = new System.Drawing.Point(339, 0);
            this.upnlSeparatorEditRelation.TabIndex = 2;
            // 
            // ubtnEditRelation
            // 
            this.ubtnEditRelation.Location = new System.Drawing.Point(355, 0);
            this.ubtnEditRelation.TabIndex = 3;
            // 
            // upnlSeparatorCreateRelation
            // 
            this.upnlSeparatorCreateRelation.Location = new System.Drawing.Point(525, 0);
            this.upnlSeparatorCreateRelation.TabIndex = 6;
            // 
            // ubtnCreateRelation
            // 
            this.ubtnCreateRelation.Location = new System.Drawing.Point(541, 0);
            this.ubtnCreateRelation.TabIndex = 7;
            // 
            // upnlSeparatorDetailButtons
            // 
            this.upnlSeparatorDetailButtons.Location = new System.Drawing.Point(618, 0);
            this.upnlSeparatorDetailButtons.TabIndex = 8;
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Location = new System.Drawing.Point(0, 229);
            this.gbxDetDetail.Size = new System.Drawing.Size(634, 159);
            this.gbxDetDetail.TabIndex = 2;
            // 
            // tabDetail
            // 
            this.tabDetail.Controls.Add(this.tabItmSpecs);
            this.tabDetail.Size = new System.Drawing.Size(628, 140);
            this.tabDetail.TabIndex = 0;
            this.tabDetail.Controls.SetChildIndex(this.tabItmSpecs, 0);
            this.tabDetail.Controls.SetChildIndex(this.tabItmPrincipal, 0);
            // 
            // tabItmPrincipal
            // 
            this.tabItmPrincipal.Controls.Add(this.cbcComputerBrand);
            this.tabItmPrincipal.Controls.Add(this.oscOperativeSystem);
            this.tabItmPrincipal.Controls.Add(this.txtServersQuantity);
            this.tabItmPrincipal.Controls.Add(this.ugbxServerComputerType);
            this.tabItmPrincipal.Controls.Add(this.txtServerModel);
            this.tabItmPrincipal.Controls.Add(this.ulblOperativeSystem);
            this.tabItmPrincipal.Controls.Add(this.ulblServerQuantity);
            this.tabItmPrincipal.Controls.Add(this.ulblServerModel);
            this.tabItmPrincipal.Controls.Add(this.ulblServerComputerBrand);
            this.tabItmPrincipal.Size = new System.Drawing.Size(620, 114);
            // 
            // upnlButtons
            // 
            this.upnlButtons.Location = new System.Drawing.Point(0, 388);
            this.upnlButtons.Size = new System.Drawing.Size(634, 25);
            this.upnlButtons.TabIndex = 3;
            // 
            // upnlSeparatorSaveRelation
            // 
            this.upnlSeparatorSaveRelation.Location = new System.Drawing.Point(432, 0);
            this.upnlSeparatorSaveRelation.TabIndex = 2;
            // 
            // ubtnSaveRelation
            // 
            this.ubtnSaveRelation.Location = new System.Drawing.Point(448, 0);
            this.ubtnSaveRelation.TabIndex = 3;
            // 
            // upnlSeparatorCancelRelation
            // 
            this.upnlSeparatorCancelRelation.Location = new System.Drawing.Point(525, 0);
            this.upnlSeparatorCancelRelation.TabIndex = 4;
            // 
            // ubtnCancelRelation
            // 
            this.ubtnCancelRelation.Location = new System.Drawing.Point(541, 0);
            this.ubtnCancelRelation.TabIndex = 5;
            // 
            // upnlSeparatorButtons
            // 
            this.upnlSeparatorButtons.Location = new System.Drawing.Point(618, 0);
            this.upnlSeparatorButtons.TabIndex = 6;
            // 
            // upnlSeparatorViewRelation
            // 
            this.upnlSeparatorViewRelation.Location = new System.Drawing.Point(432, 0);
            this.upnlSeparatorViewRelation.TabIndex = 4;
            // 
            // ubtnViewRelation
            // 
            this.ubtnViewRelation.Location = new System.Drawing.Point(448, 0);
            this.ubtnViewRelation.TabIndex = 5;
            // 
            // upnlSeparatorCloseRelation
            // 
            this.upnlSeparatorCloseRelation.Location = new System.Drawing.Point(339, 0);
            this.upnlSeparatorCloseRelation.TabIndex = 0;
            // 
            // ubtnCloseRelation
            // 
            this.ubtnCloseRelation.Location = new System.Drawing.Point(355, 0);
            this.ubtnCloseRelation.TabIndex = 1;
            // 
            // ugbxServerComputerType
            // 
            this.ugbxServerComputerType.Controls.Add(this.rtcRackType);
            this.ugbxServerComputerType.Controls.Add(this.sctcServerComputerType);
            this.ugbxServerComputerType.Controls.Add(this.ulblDetRackType);
            this.ugbxServerComputerType.Location = new System.Drawing.Point(324, 9);
            this.ugbxServerComputerType.Name = "ugbxServerComputerType";
            this.ugbxServerComputerType.Size = new System.Drawing.Size(292, 71);
            this.ugbxServerComputerType.TabIndex = 8;
            this.ugbxServerComputerType.Text = "Tipo de Servidor";
            // 
            // rtcRackType
            // 
            this.rtcRackType.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Single;
            this.rtcRackType.CustomParent = null;
            this.rtcRackType.DisplayMember = "Name";
            this.rtcRackType.Location = new System.Drawing.Point(113, 44);
            this.rtcRackType.Name = "rtcRackType";
            rackTypeParameters1.CreatedBy = null;
            rackTypeParameters1.CreatedOn = null;
            rackTypeParameters1.Description = null;
            rackTypeParameters1.Name = null;
            rackTypeParameters1.RackTypeId = null;
            rackTypeParameters1.UpdatedBy = null;
            rackTypeParameters1.UpdatedOn = null;
            this.rtcRackType.Parameters = rackTypeParameters1;
            this.rtcRackType.ReadOnly = false;
            this.rtcRackType.Size = new System.Drawing.Size(176, 22);
            this.rtcRackType.TabIndex = 2;
            this.rtcRackType.Value = null;
            this.rtcRackType.ValueMember = "RackTypeId";
            this.rtcRackType.Values = null;
            // 
            // sctcServerComputerType
            // 
            this.sctcServerComputerType.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Single;
            this.sctcServerComputerType.CustomParent = null;
            this.sctcServerComputerType.DisplayMember = "Name";
            this.sctcServerComputerType.Dock = System.Windows.Forms.DockStyle.Top;
            this.sctcServerComputerType.Location = new System.Drawing.Point(3, 16);
            this.sctcServerComputerType.Name = "sctcServerComputerType";
            serverComputerTypeParameters1.CreatedBy = null;
            serverComputerTypeParameters1.CreatedOn = null;
            serverComputerTypeParameters1.Description = null;
            serverComputerTypeParameters1.Name = null;
            serverComputerTypeParameters1.ServerComputerTypeId = null;
            serverComputerTypeParameters1.UpdatedBy = null;
            serverComputerTypeParameters1.UpdatedOn = null;
            this.sctcServerComputerType.Parameters = serverComputerTypeParameters1;
            this.sctcServerComputerType.ReadOnly = false;
            this.sctcServerComputerType.Size = new System.Drawing.Size(286, 22);
            this.sctcServerComputerType.TabIndex = 0;
            this.sctcServerComputerType.Value = null;
            this.sctcServerComputerType.ValueMember = "ServerComputerTypeId";
            this.sctcServerComputerType.Values = null;
            // 
            // ulblDetRackType
            // 
            this.ulblDetRackType.AutoSize = true;
            this.ulblDetRackType.Location = new System.Drawing.Point(33, 47);
            this.ulblDetRackType.Name = "ulblDetRackType";
            this.ulblDetRackType.Size = new System.Drawing.Size(74, 14);
            this.ulblDetRackType.TabIndex = 1;
            this.ulblDetRackType.Text = "Tipo de Rack:";
            // 
            // txtServerModel
            // 
            this.txtServerModel.Location = new System.Drawing.Point(69, 59);
            this.txtServerModel.Name = "txtServerModel";
            this.txtServerModel.Size = new System.Drawing.Size(249, 21);
            this.txtServerModel.TabIndex = 5;
            // 
            // ulblOperativeSystem
            // 
            this.ulblOperativeSystem.AutoSize = true;
            this.ulblOperativeSystem.Location = new System.Drawing.Point(8, 90);
            this.ulblOperativeSystem.Name = "ulblOperativeSystem";
            this.ulblOperativeSystem.Size = new System.Drawing.Size(27, 14);
            this.ulblOperativeSystem.TabIndex = 6;
            this.ulblOperativeSystem.Text = "S.O.";
            // 
            // ulblServerModel
            // 
            this.ulblServerModel.AutoSize = true;
            this.ulblServerModel.Location = new System.Drawing.Point(7, 63);
            this.ulblServerModel.Name = "ulblServerModel";
            this.ulblServerModel.Size = new System.Drawing.Size(45, 14);
            this.ulblServerModel.TabIndex = 4;
            this.ulblServerModel.Text = "Modelo:";
            // 
            // ulblServerComputerBrand
            // 
            this.ulblServerComputerBrand.AutoSize = true;
            this.ulblServerComputerBrand.Location = new System.Drawing.Point(7, 36);
            this.ulblServerComputerBrand.Name = "ulblServerComputerBrand";
            this.ulblServerComputerBrand.Size = new System.Drawing.Size(39, 14);
            this.ulblServerComputerBrand.TabIndex = 2;
            this.ulblServerComputerBrand.Text = "Marca:";
            // 
            // tabItmSpecs
            // 
            this.tabItmSpecs.BackColor = System.Drawing.Color.Transparent;
            this.tabItmSpecs.Controls.Add(this.ugbxServerSpecs);
            this.tabItmSpecs.Location = new System.Drawing.Point(4, 22);
            this.tabItmSpecs.Name = "tabItmSpecs";
            this.tabItmSpecs.Size = new System.Drawing.Size(620, 114);
            this.tabItmSpecs.TabIndex = 1;
            this.tabItmSpecs.Text = "Especificaciones";
            // 
            // ugbxServerSpecs
            // 
            this.ugbxServerSpecs.Controls.Add(this.txtServerSpecs);
            this.ugbxServerSpecs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugbxServerSpecs.Location = new System.Drawing.Point(0, 0);
            this.ugbxServerSpecs.Name = "ugbxServerSpecs";
            this.ugbxServerSpecs.Size = new System.Drawing.Size(643, 114);
            this.ugbxServerSpecs.TabIndex = 102;
            this.ugbxServerSpecs.Text = "Especificaciones:";
            // 
            // txtServerSpecs
            // 
            this.txtServerSpecs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtServerSpecs.Location = new System.Drawing.Point(3, 16);
            this.txtServerSpecs.Multiline = true;
            this.txtServerSpecs.Name = "txtServerSpecs";
            this.txtServerSpecs.Size = new System.Drawing.Size(637, 95);
            this.txtServerSpecs.TabIndex = 0;
            // 
            // ulblServerQuantity
            // 
            this.ulblServerQuantity.AutoSize = true;
            this.ulblServerQuantity.Location = new System.Drawing.Point(7, 9);
            this.ulblServerQuantity.Name = "ulblServerQuantity";
            this.ulblServerQuantity.Size = new System.Drawing.Size(53, 14);
            this.ulblServerQuantity.TabIndex = 0;
            this.ulblServerQuantity.Text = "Cantidad:";
            // 
            // txtServersQuantity
            // 
            this.txtServersQuantity.CustomParent = null;
            this.txtServersQuantity.Location = new System.Drawing.Point(69, 6);
            this.txtServersQuantity.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.NaturalQuantity;
            this.txtServersQuantity.MeasurementFileUnit = "MB";
            this.txtServersQuantity.Name = "txtServersQuantity";
            this.txtServersQuantity.ReadOnly = false;
            this.txtServersQuantity.Size = new System.Drawing.Size(105, 20);
            this.txtServersQuantity.TabIndex = 1;
            this.txtServersQuantity.Value = ((object)(resources.GetObject("txtServersQuantity.Value")));
            // 
            // oscOperativeSystem
            // 
            this.oscOperativeSystem.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Single;
            this.oscOperativeSystem.CustomParent = null;
            this.oscOperativeSystem.DisplayMember = "Name";
            this.oscOperativeSystem.Location = new System.Drawing.Point(69, 87);
            this.oscOperativeSystem.Name = "oscOperativeSystem";
            operativeSystemParameters1.CreatedBy = null;
            operativeSystemParameters1.CreatedOn = null;
            operativeSystemParameters1.Description = null;
            operativeSystemParameters1.IsLegit = null;
            operativeSystemParameters1.Name = null;
            operativeSystemParameters1.OperativeSystemId = null;
            operativeSystemParameters1.OperativeSystemTypeId = null;
            operativeSystemParameters1.UpdatedBy = null;
            operativeSystemParameters1.UpdatedOn = null;
            this.oscOperativeSystem.Parameters = operativeSystemParameters1;
            this.oscOperativeSystem.ReadOnly = false;
            this.oscOperativeSystem.Size = new System.Drawing.Size(249, 22);
            this.oscOperativeSystem.TabIndex = 7;
            this.oscOperativeSystem.Value = null;
            this.oscOperativeSystem.ValueMember = "OperativeSystemId";
            this.oscOperativeSystem.Values = null;
            // 
            // cbcComputerBrand
            // 
            this.cbcComputerBrand.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Single;
            this.cbcComputerBrand.CustomParent = null;
            this.cbcComputerBrand.DisplayMember = "Name";
            this.cbcComputerBrand.Location = new System.Drawing.Point(69, 31);
            this.cbcComputerBrand.Name = "cbcComputerBrand";
            computerBrandParameters1.ComputerBrandId = null;
            computerBrandParameters1.CreatedBy = null;
            computerBrandParameters1.CreatedOn = null;
            computerBrandParameters1.Description = null;
            computerBrandParameters1.Name = null;
            computerBrandParameters1.UpdatedBy = null;
            computerBrandParameters1.UpdatedOn = null;
            this.cbcComputerBrand.Parameters = computerBrandParameters1;
            this.cbcComputerBrand.ReadOnly = false;
            this.cbcComputerBrand.Size = new System.Drawing.Size(249, 22);
            this.cbcComputerBrand.TabIndex = 3;
            this.cbcComputerBrand.Value = null;
            this.cbcComputerBrand.ValueMember = "ComputerBrandId";
            this.cbcComputerBrand.Values = null;
            // 
            // ServerConsultingOldServerComputersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ServerConsultingOldServerComputersControl";
            this.Size = new System.Drawing.Size(634, 413);
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
            ((System.ComponentModel.ISupportInitialize)(this.ugbxServerComputerType)).EndInit();
            this.ugbxServerComputerType.ResumeLayout(false);
            this.ugbxServerComputerType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerModel)).EndInit();
            this.tabItmSpecs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbxServerSpecs)).EndInit();
            this.ugbxServerSpecs.ResumeLayout(false);
            this.ugbxServerSpecs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerSpecs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabItmSpecs;
        private Infragistics.Win.Misc.UltraGroupBox ugbxServerSpecs;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtServerSpecs;
        internal Infragistics.Win.Misc.UltraGroupBox ugbxServerComputerType;
        private Infragistics.Win.Misc.UltraLabel ulblDetRackType;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtServerModel;
        private Infragistics.Win.Misc.UltraLabel ulblOperativeSystem;
        private Infragistics.Win.Misc.UltraLabel ulblServerQuantity;
        private Infragistics.Win.Misc.UltraLabel ulblServerModel;
        private Infragistics.Win.Misc.UltraLabel ulblServerComputerBrand;
        internal CustomerContext.Controls.Controls.Choosers.RackTypeChooserControl rtcRackType;
        internal CustomerContext.Controls.Controls.ServerComputerTypeChooserControl sctcServerComputerType;
        internal CustomerContext.Controls.Controls.Choosers.OperativeSystemChooserControl oscOperativeSystem;
        internal CustomerContext.Controls.Controls.Choosers.ComputerBrandChooserControl cbcComputerBrand;
        internal Base.Controls.Controls.SamsaraTextEditor txtServersQuantity;



    }
}
