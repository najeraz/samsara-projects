namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    partial class CatalogForm
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Buscar = new System.Windows.Forms.TabPage();
            this.grdSchSearch = new Samsara.ProjectsAndTendering.Controls.SamsaraUltraGrid();
            this.upButtons = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel5 = new Infragistics.Win.Misc.UltraPanel();
            this.btnSchClose = new System.Windows.Forms.Button();
            this.ultraPanel4 = new Infragistics.Win.Misc.UltraPanel();
            this.btnSchEdit = new System.Windows.Forms.Button();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.btnSchCreate = new System.Windows.Forms.Button();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.btnSchSearch = new System.Windows.Forms.Button();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.gbxSearchParameters = new System.Windows.Forms.GroupBox();
            this.Nuevo = new System.Windows.Forms.TabPage();
            this.gbxDetDetail = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDetAccept = new System.Windows.Forms.Button();
            this.btnDetCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Buscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).BeginInit();
            this.upButtons.ClientArea.SuspendLayout();
            this.upButtons.SuspendLayout();
            this.ultraPanel5.SuspendLayout();
            this.ultraPanel4.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            this.Nuevo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Buscar);
            this.tabControl1.Controls.Add(this.Nuevo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 443);
            this.tabControl1.TabIndex = 20;
            // 
            // Buscar
            // 
            this.Buscar.Controls.Add(this.grdSchSearch);
            this.Buscar.Controls.Add(this.upButtons);
            this.Buscar.Controls.Add(this.gbxSearchParameters);
            this.Buscar.Location = new System.Drawing.Point(4, 22);
            this.Buscar.Name = "Buscar";
            this.Buscar.Padding = new System.Windows.Forms.Padding(3);
            this.Buscar.Size = new System.Drawing.Size(632, 417);
            this.Buscar.TabIndex = 0;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            // 
            // grdSchSearch
            // 
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdSchSearch.DisplayLayout.Appearance = appearance13;
            this.grdSchSearch.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdSchSearch.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.grdSchSearch.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdSchSearch.DisplayLayout.GroupByBox.BandLabelAppearance = appearance15;
            this.grdSchSearch.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BackColor2 = System.Drawing.SystemColors.Control;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdSchSearch.DisplayLayout.GroupByBox.PromptAppearance = appearance16;
            this.grdSchSearch.DisplayLayout.MaxColScrollRegions = 1;
            this.grdSchSearch.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdSchSearch.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            appearance18.BackColor = System.Drawing.SystemColors.Highlight;
            appearance18.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdSchSearch.DisplayLayout.Override.ActiveRowAppearance = appearance18;
            this.grdSchSearch.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdSchSearch.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            this.grdSchSearch.DisplayLayout.Override.CardAreaAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdSchSearch.DisplayLayout.Override.CellAppearance = appearance20;
            this.grdSchSearch.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdSchSearch.DisplayLayout.Override.CellPadding = 0;
            appearance21.BackColor = System.Drawing.SystemColors.Control;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.grdSchSearch.DisplayLayout.Override.GroupByRowAppearance = appearance21;
            appearance22.TextHAlignAsString = "Left";
            this.grdSchSearch.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.grdSchSearch.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdSchSearch.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            this.grdSchSearch.DisplayLayout.Override.RowAppearance = appearance23;
            this.grdSchSearch.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdSchSearch.DisplayLayout.Override.TemplateAddRowAppearance = appearance24;
            this.grdSchSearch.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdSchSearch.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdSchSearch.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdSchSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSchSearch.Location = new System.Drawing.Point(3, 97);
            this.grdSchSearch.Name = "grdSchSearch";
            this.grdSchSearch.Size = new System.Drawing.Size(626, 292);
            this.grdSchSearch.TabIndex = 22;
            this.grdSchSearch.Text = "samsaraUltraGrid1";
            // 
            // upButtons
            // 
            // 
            // upButtons.ClientArea
            // 
            this.upButtons.ClientArea.Controls.Add(this.ultraPanel5);
            this.upButtons.ClientArea.Controls.Add(this.btnSchClose);
            this.upButtons.ClientArea.Controls.Add(this.ultraPanel4);
            this.upButtons.ClientArea.Controls.Add(this.btnSchEdit);
            this.upButtons.ClientArea.Controls.Add(this.ultraPanel1);
            this.upButtons.ClientArea.Controls.Add(this.btnSchCreate);
            this.upButtons.ClientArea.Controls.Add(this.ultraPanel3);
            this.upButtons.ClientArea.Controls.Add(this.btnSchSearch);
            this.upButtons.ClientArea.Controls.Add(this.ultraPanel2);
            this.upButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.upButtons.Location = new System.Drawing.Point(3, 389);
            this.upButtons.Name = "upButtons";
            this.upButtons.Size = new System.Drawing.Size(626, 25);
            this.upButtons.TabIndex = 21;
            // 
            // ultraPanel5
            // 
            this.ultraPanel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.ultraPanel5.Location = new System.Drawing.Point(246, 0);
            this.ultraPanel5.Name = "ultraPanel5";
            this.ultraPanel5.Size = new System.Drawing.Size(16, 25);
            this.ultraPanel5.TabIndex = 8;
            // 
            // btnSchClose
            // 
            this.btnSchClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSchClose.Location = new System.Drawing.Point(262, 0);
            this.btnSchClose.Name = "btnSchClose";
            this.btnSchClose.Size = new System.Drawing.Size(75, 25);
            this.btnSchClose.TabIndex = 7;
            this.btnSchClose.Text = "Cerrar";
            this.btnSchClose.UseVisualStyleBackColor = true;
            // 
            // ultraPanel4
            // 
            this.ultraPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.ultraPanel4.Location = new System.Drawing.Point(337, 0);
            this.ultraPanel4.Name = "ultraPanel4";
            this.ultraPanel4.Size = new System.Drawing.Size(16, 25);
            this.ultraPanel4.TabIndex = 6;
            // 
            // btnSchEdit
            // 
            this.btnSchEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSchEdit.Location = new System.Drawing.Point(353, 0);
            this.btnSchEdit.Name = "btnSchEdit";
            this.btnSchEdit.Size = new System.Drawing.Size(75, 25);
            this.btnSchEdit.TabIndex = 5;
            this.btnSchEdit.Text = "Modificar";
            this.btnSchEdit.UseVisualStyleBackColor = true;
            // 
            // ultraPanel1
            // 
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ultraPanel1.Location = new System.Drawing.Point(428, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(16, 25);
            this.ultraPanel1.TabIndex = 4;
            // 
            // btnSchCreate
            // 
            this.btnSchCreate.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSchCreate.Location = new System.Drawing.Point(444, 0);
            this.btnSchCreate.Name = "btnSchCreate";
            this.btnSchCreate.Size = new System.Drawing.Size(75, 25);
            this.btnSchCreate.TabIndex = 3;
            this.btnSchCreate.Text = "Nuevo";
            this.btnSchCreate.UseVisualStyleBackColor = true;
            // 
            // ultraPanel3
            // 
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.ultraPanel3.Location = new System.Drawing.Point(519, 0);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(16, 25);
            this.ultraPanel3.TabIndex = 2;
            // 
            // btnSchSearch
            // 
            this.btnSchSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSchSearch.Location = new System.Drawing.Point(535, 0);
            this.btnSchSearch.Name = "btnSchSearch";
            this.btnSchSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSchSearch.TabIndex = 0;
            this.btnSchSearch.Text = "Buscar";
            this.btnSchSearch.UseVisualStyleBackColor = true;
            // 
            // ultraPanel2
            // 
            this.ultraPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.ultraPanel2.Location = new System.Drawing.Point(610, 0);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(16, 25);
            this.ultraPanel2.TabIndex = 1;
            // 
            // gbxSearchParameters
            // 
            this.gbxSearchParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxSearchParameters.Location = new System.Drawing.Point(3, 3);
            this.gbxSearchParameters.Name = "gbxSearchParameters";
            this.gbxSearchParameters.Size = new System.Drawing.Size(626, 94);
            this.gbxSearchParameters.TabIndex = 19;
            this.gbxSearchParameters.TabStop = false;
            this.gbxSearchParameters.Text = "Parámetros de búsqueda:";
            // 
            // Nuevo
            // 
            this.Nuevo.Controls.Add(this.gbxDetDetail);
            this.Nuevo.Controls.Add(this.panel1);
            this.Nuevo.Location = new System.Drawing.Point(4, 22);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Padding = new System.Windows.Forms.Padding(3);
            this.Nuevo.Size = new System.Drawing.Size(632, 417);
            this.Nuevo.TabIndex = 1;
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.UseVisualStyleBackColor = true;
            // 
            // gbxDetDetail
            // 
            this.gbxDetDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDetDetail.Location = new System.Drawing.Point(3, 3);
            this.gbxDetDetail.Name = "gbxDetDetail";
            this.gbxDetDetail.Size = new System.Drawing.Size(626, 380);
            this.gbxDetDetail.TabIndex = 18;
            this.gbxDetDetail.TabStop = false;
            this.gbxDetDetail.Text = "Datos del Registro:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDetAccept);
            this.panel1.Controls.Add(this.btnDetCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 383);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 31);
            this.panel1.TabIndex = 0;
            // 
            // btnDetAccept
            // 
            this.btnDetAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetAccept.Location = new System.Drawing.Point(467, 5);
            this.btnDetAccept.Name = "btnDetAccept";
            this.btnDetAccept.Size = new System.Drawing.Size(75, 23);
            this.btnDetAccept.TabIndex = 0;
            this.btnDetAccept.Text = "Aceptar";
            this.btnDetAccept.UseVisualStyleBackColor = true;
            // 
            // btnDetCancel
            // 
            this.btnDetCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetCancel.Location = new System.Drawing.Point(548, 5);
            this.btnDetCancel.Name = "btnDetCancel";
            this.btnDetCancel.Size = new System.Drawing.Size(75, 23);
            this.btnDetCancel.TabIndex = 0;
            this.btnDetCancel.Text = "Cancelar";
            this.btnDetCancel.UseVisualStyleBackColor = true;
            // 
            // CatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 443);
            this.Controls.Add(this.tabControl1);
            this.Name = "CatalogForm";
            this.Text = "CatalogForm";
            this.tabControl1.ResumeLayout(false);
            this.Buscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSchSearch)).EndInit();
            this.upButtons.ClientArea.ResumeLayout(false);
            this.upButtons.ResumeLayout(false);
            this.ultraPanel5.ResumeLayout(false);
            this.ultraPanel4.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            this.ultraPanel3.ResumeLayout(false);
            this.ultraPanel2.ResumeLayout(false);
            this.Nuevo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Buscar;
        private System.Windows.Forms.TabPage Nuevo;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Button btnDetCancel;
        protected System.Windows.Forms.Button btnDetAccept;
        protected System.Windows.Forms.GroupBox gbxSearchParameters;
        protected System.Windows.Forms.GroupBox gbxDetDetail;
        public System.Windows.Forms.Button btnSchSearch;
        private Infragistics.Win.Misc.UltraPanel upButtons;
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private Infragistics.Win.Misc.UltraPanel ultraPanel5;
        public System.Windows.Forms.Button btnSchClose;
        private Infragistics.Win.Misc.UltraPanel ultraPanel4;
        public System.Windows.Forms.Button btnSchEdit;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        public System.Windows.Forms.Button btnSchCreate;
        protected Samsara.ProjectsAndTendering.Controls.SamsaraUltraGrid grdSchSearch;
    }
}