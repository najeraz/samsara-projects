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
            this.txtDetName = new System.Windows.Forms.TextBox();
            this.lblDetName = new System.Windows.Forms.Label();
            this.txtSchName = new System.Windows.Forms.TextBox();
            this.lblSchName = new System.Windows.Forms.Label();
            this.lblDetFullName = new System.Windows.Forms.Label();
            this.txtDetDescription = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblDetBusinessType = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDetPrincipal = new System.Windows.Forms.TabPage();
            this.tabDetInfraestructure = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabDetComputers = new System.Windows.Forms.TabPage();
            this.tabDetNetwork = new System.Windows.Forms.TabPage();
            this.tabDetEnergy = new System.Windows.Forms.TabPage();
            this.tabDetPeripherals = new System.Windows.Forms.TabPage();
            this.tabDetSoftware = new System.Windows.Forms.TabPage();
            this.tabDetSuppliers = new System.Windows.Forms.TabPage();
            this.tabDetVideo = new System.Windows.Forms.TabPage();
            this.pnlDetCtgButtons.SuspendLayout();
            this.gbxSearchParameters.SuspendLayout();
            this.gbxDetDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetDescription)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDetPrincipal.SuspendLayout();
            this.tabDetInfraestructure.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetCtgButtons
            // 
            this.pnlDetCtgButtons.Location = new System.Drawing.Point(3, 387);
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Controls.Add(this.txtSchName);
            this.gbxSearchParameters.Controls.Add(this.lblSchName);
            this.gbxSearchParameters.Size = new System.Drawing.Size(750, 50);
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Controls.Add(this.tabControl1);
            this.gbxDetDetail.Size = new System.Drawing.Size(750, 384);
            // 
            // btnSchClose
            // 
            this.btnSchClose.Location = new System.Drawing.Point(386, 0);
            // 
            // btnSchEdit
            // 
            this.btnSchEdit.Location = new System.Drawing.Point(568, 0);
            // 
            // btnSchCreate
            // 
            this.btnSchCreate.Location = new System.Drawing.Point(659, 0);
            // 
            // btnSchAccept
            // 
            this.btnSchAccept.Location = new System.Drawing.Point(295, 0);
            // 
            // btnSchClear
            // 
            this.btnSchClear.Location = new System.Drawing.Point(568, 0);
            // 
            // btnSchSearch
            // 
            this.btnSchSearch.Location = new System.Drawing.Point(659, 0);
            // 
            // btnSchDelete
            // 
            this.btnSchDelete.Location = new System.Drawing.Point(477, 0);
            // 
            // grdSchSearch
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdSchSearch.DisplayLayout.Appearance = appearance1;
            this.grdSchSearch.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdSchSearch.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdSchSearch.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdSchSearch.DisplayLayout.MaxColScrollRegions = 1;
            this.grdSchSearch.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdSchSearch.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Highlight;
            appearance3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdSchSearch.DisplayLayout.Override.ActiveRowAppearance = appearance3;
            this.grdSchSearch.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdSchSearch.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdSchSearch.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            this.grdSchSearch.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdSchSearch.DisplayLayout.Override.CellAppearance = appearance5;
            this.grdSchSearch.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdSchSearch.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grdSchSearch.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.grdSchSearch.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grdSchSearch.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdSchSearch.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            this.grdSchSearch.DisplayLayout.Override.RowAppearance = appearance8;
            this.grdSchSearch.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdSchSearch.DisplayLayout.Override.TemplateAddRowAppearance = appearance9;
            this.grdSchSearch.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdSchSearch.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdSchSearch.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdSchSearch.Location = new System.Drawing.Point(3, 78);
            this.grdSchSearch.Size = new System.Drawing.Size(750, 309);
            // 
            // btnDetCancel
            // 
            this.btnDetCancel.Location = new System.Drawing.Point(659, 0);
            // 
            // btnDetSave
            // 
            this.btnDetSave.Location = new System.Drawing.Point(568, 0);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(764, 441);
            // 
            // txtDetName
            // 
            this.txtDetName.Location = new System.Drawing.Point(78, 6);
            this.txtDetName.Name = "txtDetName";
            this.txtDetName.Size = new System.Drawing.Size(341, 20);
            this.txtDetName.TabIndex = 24;
            // 
            // lblDetName
            // 
            this.lblDetName.AutoSize = true;
            this.lblDetName.Location = new System.Drawing.Point(6, 9);
            this.lblDetName.Name = "lblDetName";
            this.lblDetName.Size = new System.Drawing.Size(47, 13);
            this.lblDetName.TabIndex = 23;
            this.lblDetName.Text = "Nombre:";
            // 
            // txtSchName
            // 
            this.txtSchName.Location = new System.Drawing.Point(57, 19);
            this.txtSchName.Name = "txtSchName";
            this.txtSchName.Size = new System.Drawing.Size(226, 20);
            this.txtSchName.TabIndex = 25;
            // 
            // lblSchName
            // 
            this.lblSchName.AutoSize = true;
            this.lblSchName.Location = new System.Drawing.Point(4, 22);
            this.lblSchName.Name = "lblSchName";
            this.lblSchName.Size = new System.Drawing.Size(47, 13);
            this.lblSchName.TabIndex = 24;
            this.lblSchName.Text = "Nombre:";
            // 
            // lblDetFullName
            // 
            this.lblDetFullName.AutoSize = true;
            this.lblDetFullName.Location = new System.Drawing.Point(6, 35);
            this.lblDetFullName.Name = "lblDetFullName";
            this.lblDetFullName.Size = new System.Drawing.Size(66, 13);
            this.lblDetFullName.TabIndex = 23;
            this.lblDetFullName.Text = "Descripción:";
            // 
            // txtDetDescription
            // 
            this.txtDetDescription.Location = new System.Drawing.Point(78, 35);
            this.txtDetDescription.Multiline = true;
            this.txtDetDescription.Name = "txtDetDescription";
            this.txtDetDescription.Size = new System.Drawing.Size(341, 56);
            this.txtDetDescription.TabIndex = 26;
            // 
            // lblDetBusinessType
            // 
            this.lblDetBusinessType.AutoSize = true;
            this.lblDetBusinessType.Location = new System.Drawing.Point(6, 115);
            this.lblDetBusinessType.Name = "lblDetBusinessType";
            this.lblDetBusinessType.Size = new System.Drawing.Size(87, 13);
            this.lblDetBusinessType.TabIndex = 23;
            this.lblDetBusinessType.Text = "Giro de Negocio:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDetPrincipal);
            this.tabControl1.Controls.Add(this.tabDetInfraestructure);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(744, 365);
            this.tabControl1.TabIndex = 27;
            // 
            // tabDetPrincipal
            // 
            this.tabDetPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.tabDetPrincipal.Controls.Add(this.lblDetName);
            this.tabDetPrincipal.Controls.Add(this.lblDetBusinessType);
            this.tabDetPrincipal.Controls.Add(this.txtDetName);
            this.tabDetPrincipal.Controls.Add(this.txtDetDescription);
            this.tabDetPrincipal.Controls.Add(this.lblDetFullName);
            this.tabDetPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabDetPrincipal.Name = "tabDetPrincipal";
            this.tabDetPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetPrincipal.Size = new System.Drawing.Size(736, 339);
            this.tabDetPrincipal.TabIndex = 0;
            this.tabDetPrincipal.Text = "Principal";
            // 
            // tabDetInfraestructure
            // 
            this.tabDetInfraestructure.BackColor = System.Drawing.Color.Transparent;
            this.tabDetInfraestructure.Controls.Add(this.tabControl2);
            this.tabDetInfraestructure.Location = new System.Drawing.Point(4, 22);
            this.tabDetInfraestructure.Name = "tabDetInfraestructure";
            this.tabDetInfraestructure.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetInfraestructure.Size = new System.Drawing.Size(736, 339);
            this.tabDetInfraestructure.TabIndex = 1;
            this.tabDetInfraestructure.Text = "Infraestructura";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabDetComputers);
            this.tabControl2.Controls.Add(this.tabDetNetwork);
            this.tabControl2.Controls.Add(this.tabDetEnergy);
            this.tabControl2.Controls.Add(this.tabDetPeripherals);
            this.tabControl2.Controls.Add(this.tabDetSoftware);
            this.tabControl2.Controls.Add(this.tabDetSuppliers);
            this.tabControl2.Controls.Add(this.tabDetVideo);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(730, 333);
            this.tabControl2.TabIndex = 0;
            // 
            // tabDetComputers
            // 
            this.tabDetComputers.BackColor = System.Drawing.Color.Transparent;
            this.tabDetComputers.Location = new System.Drawing.Point(4, 22);
            this.tabDetComputers.Name = "tabDetComputers";
            this.tabDetComputers.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetComputers.Size = new System.Drawing.Size(722, 307);
            this.tabDetComputers.TabIndex = 0;
            this.tabDetComputers.Text = "Computadoras";
            // 
            // tabDetNetwork
            // 
            this.tabDetNetwork.BackColor = System.Drawing.Color.Transparent;
            this.tabDetNetwork.Location = new System.Drawing.Point(4, 22);
            this.tabDetNetwork.Name = "tabDetNetwork";
            this.tabDetNetwork.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetNetwork.Size = new System.Drawing.Size(722, 307);
            this.tabDetNetwork.TabIndex = 1;
            this.tabDetNetwork.Text = "Redes";
            // 
            // tabDetEnergy
            // 
            this.tabDetEnergy.BackColor = System.Drawing.Color.Transparent;
            this.tabDetEnergy.Location = new System.Drawing.Point(4, 22);
            this.tabDetEnergy.Name = "tabDetEnergy";
            this.tabDetEnergy.Size = new System.Drawing.Size(722, 307);
            this.tabDetEnergy.TabIndex = 2;
            this.tabDetEnergy.Text = "Energía";
            // 
            // tabDetPeripherals
            // 
            this.tabDetPeripherals.BackColor = System.Drawing.Color.Transparent;
            this.tabDetPeripherals.Location = new System.Drawing.Point(4, 22);
            this.tabDetPeripherals.Name = "tabDetPeripherals";
            this.tabDetPeripherals.Size = new System.Drawing.Size(722, 307);
            this.tabDetPeripherals.TabIndex = 3;
            this.tabDetPeripherals.Text = "Periféricos";
            // 
            // tabDetSoftware
            // 
            this.tabDetSoftware.BackColor = System.Drawing.Color.Transparent;
            this.tabDetSoftware.Location = new System.Drawing.Point(4, 22);
            this.tabDetSoftware.Name = "tabDetSoftware";
            this.tabDetSoftware.Size = new System.Drawing.Size(722, 307);
            this.tabDetSoftware.TabIndex = 4;
            this.tabDetSoftware.Text = "Software";
            // 
            // tabDetSuppliers
            // 
            this.tabDetSuppliers.BackColor = System.Drawing.Color.Transparent;
            this.tabDetSuppliers.Location = new System.Drawing.Point(4, 22);
            this.tabDetSuppliers.Name = "tabDetSuppliers";
            this.tabDetSuppliers.Size = new System.Drawing.Size(722, 307);
            this.tabDetSuppliers.TabIndex = 5;
            this.tabDetSuppliers.Text = "Proveedores y Servicios";
            // 
            // tabDetVideo
            // 
            this.tabDetVideo.BackColor = System.Drawing.Color.Transparent;
            this.tabDetVideo.Location = new System.Drawing.Point(4, 22);
            this.tabDetVideo.Name = "tabDetVideo";
            this.tabDetVideo.Size = new System.Drawing.Size(722, 307);
            this.tabDetVideo.TabIndex = 6;
            this.tabDetVideo.Text = "Video y Monitoreo";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 441);
            this.Name = "CustomerForm";
            this.Text = "Catálogo de Clientes";
            this.pnlDetCtgButtons.ResumeLayout(false);
            this.gbxSearchParameters.ResumeLayout(false);
            this.gbxSearchParameters.PerformLayout();
            this.gbxDetDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetDescription)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDetPrincipal.ResumeLayout(false);
            this.tabDetPrincipal.PerformLayout();
            this.tabDetInfraestructure.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDetName;
        private System.Windows.Forms.Label lblSchName;
        public System.Windows.Forms.TextBox txtDetName;
        private System.Windows.Forms.Label lblDetFullName;
        internal System.Windows.Forms.TextBox txtSchName;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDetDescription;
        private System.Windows.Forms.Label lblDetBusinessType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDetPrincipal;
        private System.Windows.Forms.TabPage tabDetInfraestructure;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabDetComputers;
        private System.Windows.Forms.TabPage tabDetNetwork;
        private System.Windows.Forms.TabPage tabDetEnergy;
        private System.Windows.Forms.TabPage tabDetPeripherals;
        private System.Windows.Forms.TabPage tabDetSoftware;
        private System.Windows.Forms.TabPage tabDetSuppliers;
        private System.Windows.Forms.TabPage tabDetVideo;
    }
}