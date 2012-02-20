
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
            Samsara.ProjectsAndTendering.Core.Parameters.AsesorParameters asesorParameters2 = new Samsara.ProjectsAndTendering.Core.Parameters.AsesorParameters();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.asesorChooserControl1 = new Samsara.ProjectsAndTendering.Controls.Controls.Choosers.AsesorChooserControl();
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
            this.gbxDetDetail.Controls.Add(this.asesorChooserControl1);
            this.gbxDetDetail.Controls.Add(this.ultraButton2);
            this.gbxDetDetail.Controls.Add(this.ultraButton1);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(229, 126);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 1;
            this.ultraButton1.Text = "Multiple";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraButton2
            // 
            this.ultraButton2.Location = new System.Drawing.Point(375, 126);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(75, 23);
            this.ultraButton2.TabIndex = 1;
            this.ultraButton2.Text = "Single";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // asesorChooserControl1
            // 
            this.asesorChooserControl1.ControlType = Samsara.Base.Controls.Enums.SamsaraEntityChooserControlTypeEnum.Single;
            this.asesorChooserControl1.CustomParent = null;
            this.asesorChooserControl1.DisplayMember = "Name";
            this.asesorChooserControl1.Location = new System.Drawing.Point(244, 48);
            this.asesorChooserControl1.Name = "asesorChooserControl1";
            asesorParameters2.CreatedBy = null;
            asesorParameters2.CreationDate = null;
            asesorParameters2.FullName = null;
            asesorParameters2.Name = null;
            asesorParameters2.ShowAll = null;
            asesorParameters2.ShowApprovers = null;
            asesorParameters2.UpdatedBy = null;
            asesorParameters2.UpdatedDate = null;
            this.asesorChooserControl1.Parameters = asesorParameters2;
            this.asesorChooserControl1.ReadOnly = false;
            this.asesorChooserControl1.Size = new System.Drawing.Size(226, 22);
            this.asesorChooserControl1.TabIndex = 2;
            this.asesorChooserControl1.Value = null;
            this.asesorChooserControl1.ValueMember = "AsesorId";
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
            this.pnlDetCtgButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private ProjectsAndTendering.Controls.Controls.Choosers.AsesorChooserControl asesorChooserControl1;
    }
}