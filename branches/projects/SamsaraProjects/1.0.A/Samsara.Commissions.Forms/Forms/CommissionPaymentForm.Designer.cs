
namespace Samsara.Commissions.Forms.Forms
{
    partial class CommissionPaymentForm
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
            Samsara.AlleatoERP.Core.Parameters.StaffParameters staffParameters1 = new Samsara.AlleatoERP.Core.Parameters.StaffParameters();
            Samsara.AlleatoERP.Core.Parameters.StaffParameters staffParameters2 = new Samsara.AlleatoERP.Core.Parameters.StaffParameters();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommissionPaymentForm));
            this.sccSchStaff = new Samsara.AlleatoERP.Controls.Controls.StaffChooserControl();
            this.ulblSchAsesor = new Infragistics.Win.Misc.UltraLabel();
            this.ulblDetStaff = new Infragistics.Win.Misc.UltraLabel();
            this.sccDetStaff = new Samsara.AlleatoERP.Controls.Controls.StaffChooserControl();
            this.ulblDetAmount = new Infragistics.Win.Misc.UltraLabel();
            this.ulblDetYear = new Infragistics.Win.Misc.UltraLabel();
            this.uceDetMonth = new Samsara.Base.Controls.Controls.SamsaraUltraComboEditor();
            this.ulblDetMonths = new Infragistics.Win.Misc.UltraLabel();
            this.txtDetComments = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ugbxDetComments = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtDetYear = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.txtDetAmount = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.uchkDetIsSalesRetail = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).BeginInit();
            this.gbxSchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            this.pnlDetButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceDetMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbxDetComments)).BeginInit();
            this.ugbxDetComments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uchkDetIsSalesRetail)).BeginInit();
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
            this.grdPrincipal.Location = new System.Drawing.Point(0, 72);
            this.grdPrincipal.Size = new System.Drawing.Size(636, 300);
            // 
            // gbxSchParameters
            // 
            this.gbxSchParameters.Controls.Add(this.ulblSchAsesor);
            this.gbxSchParameters.Controls.Add(this.sccSchStaff);
            this.gbxSchParameters.Size = new System.Drawing.Size(636, 47);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.uchkDetIsSalesRetail);
            this.gbxDetDetail.Controls.Add(this.txtDetAmount);
            this.gbxDetDetail.Controls.Add(this.txtDetYear);
            this.gbxDetDetail.Controls.Add(this.ugbxDetComments);
            this.gbxDetDetail.Controls.Add(this.uceDetMonth);
            this.gbxDetDetail.Controls.Add(this.ulblDetYear);
            this.gbxDetDetail.Controls.Add(this.ulblDetMonths);
            this.gbxDetDetail.Controls.Add(this.ulblDetAmount);
            this.gbxDetDetail.Controls.Add(this.ulblDetStaff);
            this.gbxDetDetail.Controls.Add(this.sccDetStaff);
            // 
            // sccSchStaff
            // 
            this.sccSchStaff.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Single;
            this.sccSchStaff.CustomParent = null;
            this.sccSchStaff.DisplayMember = "Name";
            this.sccSchStaff.Location = new System.Drawing.Point(55, 19);
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
            this.sccSchStaff.TabIndex = 0;
            this.sccSchStaff.Value = null;
            this.sccSchStaff.ValueMember = "StaffId";
            this.sccSchStaff.Values = null;
            // 
            // ulblSchAsesor
            // 
            this.ulblSchAsesor.AutoSize = true;
            this.ulblSchAsesor.Location = new System.Drawing.Point(6, 22);
            this.ulblSchAsesor.Name = "ulblSchAsesor";
            this.ulblSchAsesor.Size = new System.Drawing.Size(43, 14);
            this.ulblSchAsesor.TabIndex = 1;
            this.ulblSchAsesor.Text = "Asesor:";
            // 
            // ulblDetStaff
            // 
            this.ulblDetStaff.AutoSize = true;
            this.ulblDetStaff.Location = new System.Drawing.Point(15, 22);
            this.ulblDetStaff.Name = "ulblDetStaff";
            this.ulblDetStaff.Size = new System.Drawing.Size(55, 14);
            this.ulblDetStaff.TabIndex = 3;
            this.ulblDetStaff.Text = "Asesores:";
            // 
            // sccDetStaff
            // 
            this.sccDetStaff.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Single;
            this.sccDetStaff.CustomParent = null;
            this.sccDetStaff.DisplayMember = "Name";
            this.sccDetStaff.Location = new System.Drawing.Point(73, 19);
            this.sccDetStaff.Name = "sccDetStaff";
            staffParameters2.CreatedBy = null;
            staffParameters2.CreatedOn = null;
            staffParameters2.Names = null;
            staffParameters2.StaffId = null;
            staffParameters2.UpdatedBy = null;
            staffParameters2.UpdatedOn = null;
            this.sccDetStaff.Parameters = staffParameters2;
            this.sccDetStaff.ReadOnly = false;
            this.sccDetStaff.Size = new System.Drawing.Size(226, 22);
            this.sccDetStaff.TabIndex = 2;
            this.sccDetStaff.Value = null;
            this.sccDetStaff.ValueMember = "StaffId";
            this.sccDetStaff.Values = null;
            // 
            // ulblDetAmount
            // 
            this.ulblDetAmount.AutoSize = true;
            this.ulblDetAmount.Location = new System.Drawing.Point(15, 49);
            this.ulblDetAmount.Name = "ulblDetAmount";
            this.ulblDetAmount.Size = new System.Drawing.Size(39, 14);
            this.ulblDetAmount.TabIndex = 3;
            this.ulblDetAmount.Text = "Monto:";
            // 
            // ulblDetYear
            // 
            this.ulblDetYear.AutoSize = true;
            this.ulblDetYear.Location = new System.Drawing.Point(15, 105);
            this.ulblDetYear.Name = "ulblDetYear";
            this.ulblDetYear.Size = new System.Drawing.Size(27, 14);
            this.ulblDetYear.TabIndex = 3;
            this.ulblDetYear.Text = "Año:";
            // 
            // uceDetMonth
            // 
            this.uceDetMonth.Location = new System.Drawing.Point(73, 75);
            this.uceDetMonth.Name = "uceDetMonth";
            this.uceDetMonth.Size = new System.Drawing.Size(226, 21);
            this.uceDetMonth.TabIndex = 6;
            // 
            // ulblDetMonths
            // 
            this.ulblDetMonths.AutoSize = true;
            this.ulblDetMonths.Location = new System.Drawing.Point(15, 78);
            this.ulblDetMonths.Name = "ulblDetMonths";
            this.ulblDetMonths.Size = new System.Drawing.Size(29, 14);
            this.ulblDetMonths.TabIndex = 3;
            this.ulblDetMonths.Text = "Mes:";
            // 
            // txtDetComments
            // 
            this.txtDetComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetComments.Location = new System.Drawing.Point(3, 16);
            this.txtDetComments.Multiline = true;
            this.txtDetComments.Name = "txtDetComments";
            this.txtDetComments.Size = new System.Drawing.Size(269, 65);
            this.txtDetComments.TabIndex = 4;
            // 
            // ugbxDetComments
            // 
            this.ugbxDetComments.Controls.Add(this.txtDetComments);
            this.ugbxDetComments.Location = new System.Drawing.Point(12, 129);
            this.ugbxDetComments.Name = "ugbxDetComments";
            this.ugbxDetComments.Size = new System.Drawing.Size(275, 84);
            this.ugbxDetComments.TabIndex = 7;
            this.ugbxDetComments.Text = "Comentarios:";
            // 
            // txtDetYear
            // 
            this.txtDetYear.CustomParent = this;
            this.txtDetYear.Location = new System.Drawing.Point(73, 102);
            this.txtDetYear.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.NaturalQuantity;
            this.txtDetYear.MeasurementFileUnit = "MB";
            this.txtDetYear.Name = "txtDetYear";
            this.txtDetYear.ReadOnly = false;
            this.txtDetYear.Size = new System.Drawing.Size(108, 20);
            this.txtDetYear.TabIndex = 8;
            this.txtDetYear.Value = ((object)(resources.GetObject("txtDetYear.Value")));
            // 
            // txtDetAmount
            // 
            this.txtDetAmount.CustomParent = this;
            this.txtDetAmount.Location = new System.Drawing.Point(73, 46);
            this.txtDetAmount.MaskType = Samsara.Framework.Core.Enums.TextFormatEnum.Currency;
            this.txtDetAmount.MeasurementFileUnit = "MB";
            this.txtDetAmount.Name = "txtDetAmount";
            this.txtDetAmount.ReadOnly = false;
            this.txtDetAmount.Size = new System.Drawing.Size(108, 20);
            this.txtDetAmount.TabIndex = 9;
            this.txtDetAmount.Value = ((object)(resources.GetObject("txtDetAmount.Value")));
            // 
            // uchkDetIsSalesRetail
            // 
            this.uchkDetIsSalesRetail.AutoSize = true;
            this.uchkDetIsSalesRetail.Location = new System.Drawing.Point(15, 219);
            this.uchkDetIsSalesRetail.Name = "uchkDetIsSalesRetail";
            this.uchkDetIsSalesRetail.Size = new System.Drawing.Size(121, 17);
            this.uchkDetIsSalesRetail.TabIndex = 10;
            this.uchkDetIsSalesRetail.Text = "Es Venta Mostrador";
            // 
            // CommissionPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 443);
            this.Name = "CommissionPaymentForm";
            this.Text = "CommissionPaymentForm";
            ((System.ComponentModel.ISupportInitialize)(this.grdPrincipal)).EndInit();
            this.gbxSchParameters.ResumeLayout(false);
            this.gbxSchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            this.gbxDetDetail.PerformLayout();
            this.pnlDetButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uceDetMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbxDetComments)).EndInit();
            this.ugbxDetComments.ResumeLayout(false);
            this.ugbxDetComments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uchkDetIsSalesRetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ulblSchAsesor;
        private Infragistics.Win.Misc.UltraLabel ulblDetAmount;
        private Infragistics.Win.Misc.UltraLabel ulblDetStaff;
        internal AlleatoERP.Controls.Controls.StaffChooserControl sccSchStaff;
        internal AlleatoERP.Controls.Controls.StaffChooserControl sccDetStaff;
        internal Base.Controls.Controls.SamsaraUltraComboEditor uceDetMonth;
        private Infragistics.Win.Misc.UltraLabel ulblDetYear;
        private Infragistics.Win.Misc.UltraLabel ulblDetMonths;
        private Infragistics.Win.Misc.UltraGroupBox ugbxDetComments;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetComments;
        internal Base.Controls.Controls.SamsaraTextEditor txtDetYear;
        internal Base.Controls.Controls.SamsaraTextEditor txtDetAmount;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor uchkDetIsSalesRetail;


    }
}