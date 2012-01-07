namespace SamsaraCommissions
{
    partial class DetalleQuincena
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
            this.tcDetalle = new System.Windows.Forms.TabControl();
            this.DetalleQui = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcFacturasPagadas = new System.Windows.Forms.TabControl();
            this.FacturasPagadas = new System.Windows.Forms.TabPage();
            this.grdDetalleQuincena = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tcComplemento = new System.Windows.Forms.TabControl();
            this.FacturasCanceladas = new System.Windows.Forms.TabPage();
            this.grdFacturasCanceladas = new System.Windows.Forms.DataGridView();
            this.FacturasPendientes = new System.Windows.Forms.TabPage();
            this.grdFacturasPendientes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbColumnas = new System.Windows.Forms.CheckedListBox();
            this.tcDetalle.SuspendLayout();
            this.DetalleQui.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tcFacturasPagadas.SuspendLayout();
            this.FacturasPagadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalleQuincena)).BeginInit();
            this.panel2.SuspendLayout();
            this.tcComplemento.SuspendLayout();
            this.FacturasCanceladas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFacturasCanceladas)).BeginInit();
            this.FacturasPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFacturasPendientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcDetalle
            // 
            this.tcDetalle.Controls.Add(this.DetalleQui);
            this.tcDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDetalle.Location = new System.Drawing.Point(0, 0);
            this.tcDetalle.Name = "tcDetalle";
            this.tcDetalle.SelectedIndex = 0;
            this.tcDetalle.Size = new System.Drawing.Size(709, 405);
            this.tcDetalle.TabIndex = 1;
            // 
            // DetalleQui
            // 
            this.DetalleQui.Controls.Add(this.panel1);
            this.DetalleQui.Location = new System.Drawing.Point(4, 22);
            this.DetalleQui.Name = "DetalleQui";
            this.DetalleQui.Padding = new System.Windows.Forms.Padding(3);
            this.DetalleQui.Size = new System.Drawing.Size(701, 379);
            this.DetalleQui.TabIndex = 0;
            this.DetalleQui.Text = "Detalle Quincena";
            this.DetalleQui.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tcFacturasPagadas);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 373);
            this.panel1.TabIndex = 6;
            // 
            // tcFacturasPagadas
            // 
            this.tcFacturasPagadas.Controls.Add(this.FacturasPagadas);
            this.tcFacturasPagadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcFacturasPagadas.Location = new System.Drawing.Point(153, 0);
            this.tcFacturasPagadas.Name = "tcFacturasPagadas";
            this.tcFacturasPagadas.SelectedIndex = 0;
            this.tcFacturasPagadas.Size = new System.Drawing.Size(542, 197);
            this.tcFacturasPagadas.TabIndex = 9;
            // 
            // FacturasPagadas
            // 
            this.FacturasPagadas.Controls.Add(this.grdDetalleQuincena);
            this.FacturasPagadas.Location = new System.Drawing.Point(4, 22);
            this.FacturasPagadas.Name = "FacturasPagadas";
            this.FacturasPagadas.Padding = new System.Windows.Forms.Padding(3);
            this.FacturasPagadas.Size = new System.Drawing.Size(534, 171);
            this.FacturasPagadas.TabIndex = 1;
            this.FacturasPagadas.Text = "Facturas Pagadas";
            this.FacturasPagadas.UseVisualStyleBackColor = true;
            // 
            // grdDetalleQuincena
            // 
            this.grdDetalleQuincena.AllowUserToAddRows = false;
            this.grdDetalleQuincena.AllowUserToDeleteRows = false;
            this.grdDetalleQuincena.AllowUserToResizeRows = false;
            this.grdDetalleQuincena.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetalleQuincena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetalleQuincena.Location = new System.Drawing.Point(3, 3);
            this.grdDetalleQuincena.Name = "grdDetalleQuincena";
            this.grdDetalleQuincena.Size = new System.Drawing.Size(528, 165);
            this.grdDetalleQuincena.TabIndex = 5;
            this.grdDetalleQuincena.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdDetalleQuincena_CellFormatting);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tcComplemento);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(153, 197);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 176);
            this.panel2.TabIndex = 8;
            // 
            // tcComplemento
            // 
            this.tcComplemento.Controls.Add(this.FacturasCanceladas);
            this.tcComplemento.Controls.Add(this.FacturasPendientes);
            this.tcComplemento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcComplemento.Location = new System.Drawing.Point(0, 0);
            this.tcComplemento.Name = "tcComplemento";
            this.tcComplemento.SelectedIndex = 0;
            this.tcComplemento.Size = new System.Drawing.Size(542, 176);
            this.tcComplemento.TabIndex = 8;
            // 
            // FacturasCanceladas
            // 
            this.FacturasCanceladas.Controls.Add(this.grdFacturasCanceladas);
            this.FacturasCanceladas.Location = new System.Drawing.Point(4, 22);
            this.FacturasCanceladas.Name = "FacturasCanceladas";
            this.FacturasCanceladas.Padding = new System.Windows.Forms.Padding(3);
            this.FacturasCanceladas.Size = new System.Drawing.Size(534, 150);
            this.FacturasCanceladas.TabIndex = 0;
            this.FacturasCanceladas.Text = "Facturas Canceladas";
            this.FacturasCanceladas.UseVisualStyleBackColor = true;
            // 
            // grdFacturasCanceladas
            // 
            this.grdFacturasCanceladas.AllowUserToAddRows = false;
            this.grdFacturasCanceladas.AllowUserToDeleteRows = false;
            this.grdFacturasCanceladas.AllowUserToResizeRows = false;
            this.grdFacturasCanceladas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFacturasCanceladas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFacturasCanceladas.Location = new System.Drawing.Point(3, 3);
            this.grdFacturasCanceladas.Name = "grdFacturasCanceladas";
            this.grdFacturasCanceladas.Size = new System.Drawing.Size(528, 144);
            this.grdFacturasCanceladas.TabIndex = 6;
            this.grdFacturasCanceladas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdFacturasCanceladas_CellFormatting);
            this.grdFacturasCanceladas.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.GeneralGrid_ColumnAdded);
            // 
            // FacturasPendientes
            // 
            this.FacturasPendientes.Controls.Add(this.grdFacturasPendientes);
            this.FacturasPendientes.Location = new System.Drawing.Point(4, 22);
            this.FacturasPendientes.Name = "FacturasPendientes";
            this.FacturasPendientes.Padding = new System.Windows.Forms.Padding(3);
            this.FacturasPendientes.Size = new System.Drawing.Size(534, 150);
            this.FacturasPendientes.TabIndex = 1;
            this.FacturasPendientes.Text = "Facturas Pendientes";
            this.FacturasPendientes.UseVisualStyleBackColor = true;
            // 
            // grdFacturasPendientes
            // 
            this.grdFacturasPendientes.AllowUserToAddRows = false;
            this.grdFacturasPendientes.AllowUserToDeleteRows = false;
            this.grdFacturasPendientes.AllowUserToResizeRows = false;
            this.grdFacturasPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFacturasPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFacturasPendientes.Location = new System.Drawing.Point(3, 3);
            this.grdFacturasPendientes.Name = "grdFacturasPendientes";
            this.grdFacturasPendientes.Size = new System.Drawing.Size(528, 144);
            this.grdFacturasPendientes.TabIndex = 6;
            this.grdFacturasPendientes.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.GeneralGrid_ColumnAdded);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbColumnas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 373);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ocultar/Mostrar Columnas";
            // 
            // clbColumnas
            // 
            this.clbColumnas.CheckOnClick = true;
            this.clbColumnas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbColumnas.FormattingEnabled = true;
            this.clbColumnas.Location = new System.Drawing.Point(3, 16);
            this.clbColumnas.Name = "clbColumnas";
            this.clbColumnas.Size = new System.Drawing.Size(147, 354);
            this.clbColumnas.TabIndex = 0;
            this.clbColumnas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbColumnas_ItemCheck);
            // 
            // DetalleQuincena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 405);
            this.Controls.Add(this.tcDetalle);
            this.Name = "DetalleQuincena";
            this.Text = "DetalleQuincena";
            this.tcDetalle.ResumeLayout(false);
            this.DetalleQui.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tcFacturasPagadas.ResumeLayout(false);
            this.FacturasPagadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalleQuincena)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tcComplemento.ResumeLayout(false);
            this.FacturasCanceladas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFacturasCanceladas)).EndInit();
            this.FacturasPendientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFacturasPendientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcDetalle;
        private System.Windows.Forms.TabPage DetalleQui;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbColumnas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView grdFacturasPendientes;
        private System.Windows.Forms.TabControl tcComplemento;
        private System.Windows.Forms.TabPage FacturasPendientes;
        private System.Windows.Forms.TabPage FacturasCanceladas;
        private System.Windows.Forms.DataGridView grdFacturasCanceladas;
        private System.Windows.Forms.TabControl tcFacturasPagadas;
        private System.Windows.Forms.TabPage FacturasPagadas;
        private System.Windows.Forms.DataGridView grdDetalleQuincena;

    }
}