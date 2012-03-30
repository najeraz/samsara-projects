
namespace Samsara.Commissions.Forms.Forms
{
    partial class ServicesManagementForm
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
            Samsara.AlleatoERP.Core.Parameters.StaffParameters staffParameters2 = new Samsara.AlleatoERP.Core.Parameters.StaffParameters();
            Samsara.AlleatoERP.Core.Parameters.StaffParameters staffParameters1 = new Samsara.AlleatoERP.Core.Parameters.StaffParameters();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesManagementForm));
            this.sccDetStaff = new Samsara.AlleatoERP.Controls.Controls.StaffChooserControl();
            this.ulblDetServiceNumber = new Infragistics.Win.Misc.UltraLabel();
            this.ulblDetServiceAmount = new Infragistics.Win.Misc.UltraLabel();
            this.txtDetServiceNumber = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.txtDetServiceAmount = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.ulblDetStaffs = new Infragistics.Win.Misc.UltraLabel();
            this.ulblSchStaff = new Infragistics.Win.Misc.UltraLabel();
            this.sccSchStaff = new Samsara.AlleatoERP.Controls.Controls.StaffChooserControl();
            this.txtSchServiceNumber = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.ulblSchServiceNumber = new Infragistics.Win.Misc.UltraLabel();
            this.uchkDetAuthorized = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uchkDetProcessed = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).BeginInit();
            this.gbxSchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            this.pnlDetButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uchkDetAuthorized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uchkDetProcessed)).BeginInit();
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
            this.grdPrincipal.Location = new System.Drawing.Point(0, 93);
            this.grdPrincipal.Size = new System.Drawing.Size(636, 279);
            // 
            // gbxSchParameters
            // 
            this.gbxSchParameters.Controls.Add(this.txtSchServiceNumber);
            this.gbxSchParameters.Controls.Add(this.ulblSchServiceNumber);
            this.gbxSchParameters.Controls.Add(this.ulblSchStaff);
            this.gbxSchParameters.Controls.Add(this.sccSchStaff);
            this.gbxSchParameters.Size = new System.Drawing.Size(636, 68);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.uchkDetProcessed);
            this.gbxDetDetail.Controls.Add(this.uchkDetAuthorized);
            this.gbxDetDetail.Controls.Add(this.txtDetServiceAmount);
            this.gbxDetDetail.Controls.Add(this.txtDetServiceNumber);
            this.gbxDetDetail.Controls.Add(this.ulblDetStaffs);
            this.gbxDetDetail.Controls.Add(this.ulblDetServiceAmount);
            this.gbxDetDetail.Controls.Add(this.ulblDetServiceNumber);
            this.gbxDetDetail.Controls.Add(this.sccDetStaff);
            // 
            // sccDetStaff
            // 
            this.sccDetStaff.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Multiple;
            this.sccDetStaff.CustomParent = null;
            this.sccDetStaff.DisplayMember = "Name";
            this.sccDetStaff.Location = new System.Drawing.Point(89, 71);
            this.sccDetStaff.Name = "sccDetStaff";
            staffParameters2.CreatedBy = null;
            staffParameters2.CreatedOn = null;
            staffParameters2.Names = null;
            staffParameters2.StaffId = null;
            staffParameters2.UpdatedBy = null;
            staffParameters2.UpdatedOn = null;
            this.sccDetStaff.Parameters = staffParameters2;
            this.sccDetStaff.ReadOnly = false;
            this.sccDetStaff.Size = new System.Drawing.Size(289, 22);
            this.sccDetStaff.TabIndex = 0;
            this.sccDetStaff.Value = null;
            this.sccDetStaff.ValueMember = "StaffId";
            this.sccDetStaff.Values = null;
            // 
            // ulblDetServiceNumber
            // 
            this.ulblDetServiceNumber.AutoSize = true;
            this.ulblDetServiceNumber.Location = new System.Drawing.Point(8, 22);
            this.ulblDetServiceNumber.Name = "ulblDetServiceNumber";
            this.ulblDetServiceNumber.Size = new System.Drawing.Size(75, 14);
            this.ulblDetServiceNumber.TabIndex = 1;
            this.ulblDetServiceNumber.Text = "Núm Servicio:";
            // 
            // ulblDetServiceAmount
            // 
            this.ulblDetServiceAmount.AutoSize = true;
            this.ulblDetServiceAmount.Location = new System.Drawing.Point(8, 48);
            this.ulblDetServiceAmount.Name = "ulblDetServiceAmount";
            this.ulblDetServiceAmount.Size = new System.Drawing.Size(39, 14);
            this.ulblDetServiceAmount.TabIndex = 1;
            this.ulblDetServiceAmount.Text = "Monto:";
            // 
            // txtDetServiceNumber
            // 
            this.txtDetServiceNumber.CustomParent = null;
            this.txtDetServiceNumber.Location = new System.Drawing.Point(89, 19);
            this.txtDetServiceNumber.MaskType = Samsara.Support.Util.TextMaskFormatEnum.NaturalQuantity;
            this.txtDetServiceNumber.MeasurementFileUnit = "MB";
            this.txtDetServiceNumber.Name = "txtDetServiceNumber";
            this.txtDetServiceNumber.ReadOnly = false;
            this.txtDetServiceNumber.Size = new System.Drawing.Size(150, 20);
            this.txtDetServiceNumber.TabIndex = 2;
            this.txtDetServiceNumber.Value = ((object)(resources.GetObject("txtDetServiceNumber.Value")));
            // 
            // txtDetServiceAmount
            // 
            this.txtDetServiceAmount.CustomParent = null;
            this.txtDetServiceAmount.Location = new System.Drawing.Point(89, 45);
            this.txtDetServiceAmount.MaskType = Samsara.Support.Util.TextMaskFormatEnum.Currency;
            this.txtDetServiceAmount.MeasurementFileUnit = "MB";
            this.txtDetServiceAmount.Name = "txtDetServiceAmount";
            this.txtDetServiceAmount.ReadOnly = false;
            this.txtDetServiceAmount.Size = new System.Drawing.Size(150, 20);
            this.txtDetServiceAmount.TabIndex = 2;
            this.txtDetServiceAmount.Value = ((object)(resources.GetObject("txtDetServiceAmount.Value")));
            // 
            // ulblDetStaffs
            // 
            this.ulblDetStaffs.AutoSize = true;
            this.ulblDetStaffs.Location = new System.Drawing.Point(8, 75);
            this.ulblDetStaffs.Name = "ulblDetStaffs";
            this.ulblDetStaffs.Size = new System.Drawing.Size(53, 14);
            this.ulblDetStaffs.TabIndex = 1;
            this.ulblDetStaffs.Text = "Técnicos:";
            // 
            // ulblSchStaff
            // 
            this.ulblSchStaff.AutoSize = true;
            this.ulblSchStaff.Location = new System.Drawing.Point(15, 43);
            this.ulblSchStaff.Name = "ulblSchStaff";
            this.ulblSchStaff.Size = new System.Drawing.Size(47, 14);
            this.ulblSchStaff.TabIndex = 3;
            this.ulblSchStaff.Text = "Técnico:";
            // 
            // sccSchStaff
            // 
            this.sccSchStaff.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Single;
            this.sccSchStaff.CustomParent = null;
            this.sccSchStaff.DisplayMember = "Name";
            this.sccSchStaff.Location = new System.Drawing.Point(96, 40);
            this.sccSchStaff.Name = "sccSchStaff";
            staffParameters1.CreatedBy = null;
            staffParameters1.CreatedOn = null;
            staffParameters1.Names = null;
            staffParameters1.StaffId = null;
            staffParameters1.UpdatedBy = null;
            staffParameters1.UpdatedOn = null;
            this.sccSchStaff.Parameters = staffParameters1;
            this.sccSchStaff.ReadOnly = false;
            this.sccSchStaff.Size = new System.Drawing.Size(226, 22);
            this.sccSchStaff.TabIndex = 2;
            this.sccSchStaff.Value = null;
            this.sccSchStaff.ValueMember = "StaffId";
            this.sccSchStaff.Values = null;
            // 
            // txtSchServiceNumber
            // 
            this.txtSchServiceNumber.CustomParent = null;
            this.txtSchServiceNumber.Location = new System.Drawing.Point(96, 14);
            this.txtSchServiceNumber.MaskType = Samsara.Support.Util.TextMaskFormatEnum.NaturalQuantity;
            this.txtSchServiceNumber.MeasurementFileUnit = "MB";
            this.txtSchServiceNumber.Name = "txtSchServiceNumber";
            this.txtSchServiceNumber.ReadOnly = false;
            this.txtSchServiceNumber.Size = new System.Drawing.Size(150, 20);
            this.txtSchServiceNumber.TabIndex = 5;
            this.txtSchServiceNumber.Value = ((object)(resources.GetObject("txtSchServiceNumber.Value")));
            // 
            // ulblSchServiceNumber
            // 
            this.ulblSchServiceNumber.AutoSize = true;
            this.ulblSchServiceNumber.Location = new System.Drawing.Point(15, 17);
            this.ulblSchServiceNumber.Name = "ulblSchServiceNumber";
            this.ulblSchServiceNumber.Size = new System.Drawing.Size(75, 14);
            this.ulblSchServiceNumber.TabIndex = 4;
            this.ulblSchServiceNumber.Text = "Núm Servicio:";
            // 
            // uchkDetAuthorized
            // 
            this.uchkDetAuthorized.AutoSize = true;
            this.uchkDetAuthorized.Enabled = false;
            this.uchkDetAuthorized.Location = new System.Drawing.Point(418, 44);
            this.uchkDetAuthorized.Name = "uchkDetAuthorized";
            this.uchkDetAuthorized.Size = new System.Drawing.Size(75, 17);
            this.uchkDetAuthorized.TabIndex = 3;
            this.uchkDetAuthorized.Text = "Autorizado";
            // 
            // uchkDetProcessed
            // 
            this.uchkDetProcessed.AutoSize = true;
            this.uchkDetProcessed.Enabled = false;
            this.uchkDetProcessed.Location = new System.Drawing.Point(418, 21);
            this.uchkDetProcessed.Name = "uchkDetProcessed";
            this.uchkDetProcessed.Size = new System.Drawing.Size(75, 17);
            this.uchkDetProcessed.TabIndex = 3;
            this.uchkDetProcessed.Text = "Procesado";
            // 
            // ServicesManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 443);
            this.Name = "ServicesManagementForm";
            this.Text = "ServicesManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).EndInit();
            this.gbxSchParameters.ResumeLayout(false);
            this.gbxSchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            this.pnlDetButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uchkDetAuthorized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uchkDetProcessed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ulblDetServiceNumber;
        private Infragistics.Win.Misc.UltraLabel ulblDetServiceAmount;
        private Infragistics.Win.Misc.UltraLabel ulblDetStaffs;
        internal AlleatoERP.Controls.Controls.StaffChooserControl sccDetStaff;
        internal Base.Controls.Controls.SamsaraTextEditor txtDetServiceAmount;
        internal Base.Controls.Controls.SamsaraTextEditor txtDetServiceNumber;
        private Infragistics.Win.Misc.UltraLabel ulblSchStaff;
        internal AlleatoERP.Controls.Controls.StaffChooserControl sccSchStaff;
        internal Base.Controls.Controls.SamsaraTextEditor txtSchServiceNumber;
        private Infragistics.Win.Misc.UltraLabel ulblSchServiceNumber;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor uchkDetProcessed;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor uchkDetAuthorized;

    }
}