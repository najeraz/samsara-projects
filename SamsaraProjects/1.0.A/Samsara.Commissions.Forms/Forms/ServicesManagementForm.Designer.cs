
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesManagementForm));
            Samsara.AlleatoERP.Core.Parameters.StaffParameters staffParameters1 = new Samsara.AlleatoERP.Core.Parameters.StaffParameters();
            this.sccDetStaff = new Samsara.AlleatoERP.Controls.Controls.StaffChooserControl();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtDetServiceNumber = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.txtDetServiceAmount = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.sccSchStaff = new Samsara.AlleatoERP.Controls.Controls.StaffChooserControl();
            this.gbxSchParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).BeginInit();
            this.gbxDetDetail.SuspendLayout();
            this.pnlDetCtgButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSchParameters
            // 
            this.gbxSchParameters.Controls.Add(this.ultraLabel4);
            this.gbxSchParameters.Controls.Add(this.sccSchStaff);
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
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.txtDetServiceAmount);
            this.gbxDetDetail.Controls.Add(this.txtDetServiceNumber);
            this.gbxDetDetail.Controls.Add(this.ultraLabel3);
            this.gbxDetDetail.Controls.Add(this.ultraLabel2);
            this.gbxDetDetail.Controls.Add(this.ultraLabel1);
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
            staffParameters2.CreationDate = null;
            staffParameters2.Names = null;
            staffParameters2.StaffId = null;
            staffParameters2.UpdatedBy = null;
            staffParameters2.UpdatedDate = null;
            this.sccDetStaff.Parameters = staffParameters2;
            this.sccDetStaff.ReadOnly = false;
            this.sccDetStaff.Size = new System.Drawing.Size(226, 22);
            this.sccDetStaff.TabIndex = 0;
            this.sccDetStaff.Value = null;
            this.sccDetStaff.ValueMember = "StaffId";
            this.sccDetStaff.Values = null;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(8, 22);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(75, 14);
            this.ultraLabel1.TabIndex = 1;
            this.ultraLabel1.Text = "Núm Servicio:";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Location = new System.Drawing.Point(8, 48);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(39, 14);
            this.ultraLabel2.TabIndex = 1;
            this.ultraLabel2.Text = "Monto:";
            // 
            // txtDetServiceNumber
            // 
            this.txtDetServiceNumber.CustomParent = null;
            this.txtDetServiceNumber.Location = new System.Drawing.Point(89, 19);
            this.txtDetServiceNumber.MaskType = Samsara.Support.Util.TextMaskFormatEnum.NaturalQuantity;
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
            this.txtDetServiceAmount.Name = "txtDetServiceAmount";
            this.txtDetServiceAmount.ReadOnly = false;
            this.txtDetServiceAmount.Size = new System.Drawing.Size(150, 20);
            this.txtDetServiceAmount.TabIndex = 2;
            this.txtDetServiceAmount.Value = ((object)(resources.GetObject("txtDetServiceAmount.Value")));
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Location = new System.Drawing.Point(8, 75);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(53, 14);
            this.ultraLabel3.TabIndex = 1;
            this.ultraLabel3.Text = "Técnicos:";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Location = new System.Drawing.Point(8, 22);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(47, 14);
            this.ultraLabel4.TabIndex = 3;
            this.ultraLabel4.Text = "Técnico:";
            // 
            // sccSchStaff
            // 
            this.sccSchStaff.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Single;
            this.sccSchStaff.CustomParent = null;
            this.sccSchStaff.DisplayMember = "Name";
            this.sccSchStaff.Location = new System.Drawing.Point(67, 19);
            this.sccSchStaff.Name = "sccSchStaff";
            staffParameters1.CreatedBy = null;
            staffParameters1.CreationDate = null;
            staffParameters1.Names = null;
            staffParameters1.StaffId = null;
            staffParameters1.UpdatedBy = null;
            staffParameters1.UpdatedDate = null;
            this.sccSchStaff.Parameters = staffParameters1;
            this.sccSchStaff.ReadOnly = false;
            this.sccSchStaff.Size = new System.Drawing.Size(226, 22);
            this.sccSchStaff.TabIndex = 2;
            this.sccSchStaff.Value = null;
            this.sccSchStaff.ValueMember = "StaffId";
            this.sccSchStaff.Values = null;
            // 
            // ServicesManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 443);
            this.Name = "ServicesManagementForm";
            this.Text = "ServicesManagement";
            this.gbxSchParameters.ResumeLayout(false);
            this.gbxSchParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).EndInit();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            this.pnlDetCtgButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        internal AlleatoERP.Controls.Controls.StaffChooserControl sccDetStaff;
        internal Base.Controls.Controls.SamsaraTextEditor txtDetServiceAmount;
        internal Base.Controls.Controls.SamsaraTextEditor txtDetServiceNumber;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        internal AlleatoERP.Controls.Controls.StaffChooserControl sccSchStaff;

    }
}