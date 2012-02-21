
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
            this.staffChooserControl1 = new Samsara.AlleatoERP.Controls.Controls.StaffChooserControl();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.samsaraTextEditor1 = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.samsaraTextEditor2 = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).BeginInit();
            this.gbxDetDetail.SuspendLayout();
            this.pnlDetCtgButtons.SuspendLayout();
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
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.samsaraTextEditor2);
            this.gbxDetDetail.Controls.Add(this.samsaraTextEditor1);
            this.gbxDetDetail.Controls.Add(this.ultraLabel3);
            this.gbxDetDetail.Controls.Add(this.ultraLabel2);
            this.gbxDetDetail.Controls.Add(this.ultraLabel1);
            this.gbxDetDetail.Controls.Add(this.staffChooserControl1);
            // 
            // staffChooserControl1
            // 
            this.staffChooserControl1.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Multiple;
            this.staffChooserControl1.CustomParent = null;
            this.staffChooserControl1.DisplayMember = "Name";
            this.staffChooserControl1.Location = new System.Drawing.Point(89, 71);
            this.staffChooserControl1.Name = "staffChooserControl1";
            staffParameters2.CreatedBy = null;
            staffParameters2.CreationDate = null;
            staffParameters2.Names = null;
            staffParameters2.StaffId = null;
            staffParameters2.UpdatedBy = null;
            staffParameters2.UpdatedDate = null;
            this.staffChooserControl1.Parameters = staffParameters2;
            this.staffChooserControl1.ReadOnly = false;
            this.staffChooserControl1.Size = new System.Drawing.Size(226, 22);
            this.staffChooserControl1.TabIndex = 0;
            this.staffChooserControl1.Value = null;
            this.staffChooserControl1.ValueMember = "StaffId";
            this.staffChooserControl1.Values = null;
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
            // samsaraTextEditor1
            // 
            this.samsaraTextEditor1.CustomParent = null;
            this.samsaraTextEditor1.Location = new System.Drawing.Point(89, 19);
            this.samsaraTextEditor1.MaskType = Samsara.Support.Util.TextMaskFormatEnum.NaturalQuantity;
            this.samsaraTextEditor1.Name = "samsaraTextEditor1";
            this.samsaraTextEditor1.ReadOnly = false;
            this.samsaraTextEditor1.Size = new System.Drawing.Size(150, 20);
            this.samsaraTextEditor1.TabIndex = 2;
            this.samsaraTextEditor1.Value = ((object)(resources.GetObject("samsaraTextEditor1.Value")));
            // 
            // samsaraTextEditor2
            // 
            this.samsaraTextEditor2.CustomParent = null;
            this.samsaraTextEditor2.Location = new System.Drawing.Point(89, 45);
            this.samsaraTextEditor2.MaskType = Samsara.Support.Util.TextMaskFormatEnum.Currency;
            this.samsaraTextEditor2.Name = "samsaraTextEditor2";
            this.samsaraTextEditor2.ReadOnly = false;
            this.samsaraTextEditor2.Size = new System.Drawing.Size(150, 20);
            this.samsaraTextEditor2.TabIndex = 2;
            this.samsaraTextEditor2.Value = ((object)(resources.GetObject("samsaraTextEditor2.Value")));
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Location = new System.Drawing.Point(8, 75);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(53, 14);
            this.ultraLabel3.TabIndex = 1;
            this.ultraLabel3.Text = "Tecnicos:";
            // 
            // ServicesManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 443);
            this.Name = "ServicesManagementForm";
            this.Text = "ServicesManagement";
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).EndInit();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            this.pnlDetCtgButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AlleatoERP.Controls.Controls.StaffChooserControl staffChooserControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Base.Controls.Controls.SamsaraTextEditor samsaraTextEditor2;
        private Base.Controls.Controls.SamsaraTextEditor samsaraTextEditor1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;

    }
}