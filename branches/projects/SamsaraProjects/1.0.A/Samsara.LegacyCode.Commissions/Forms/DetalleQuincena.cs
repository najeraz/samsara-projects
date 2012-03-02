using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.LegacyCode.Commissions.Util;
using Samsara.Support.Util;

namespace Samsara.LegacyCode.Commissions.Forms
{
    public partial class DetalleQuincena : Form
    {
        private Dictionary<string, int> columnIndexes
            = new Dictionary<string,int>();
        private Dictionary<string, string> checkedColumns;
        private Dictionary<string, int> dicMeses = new Dictionary<string, int>();

        public DataTable DtDetalleComisiones
        {
            get;
            set;
        }

        public DataTable DtFacturasPendientes
        {
            get;
            set;
        }

        public DataTable DtFacturasCanceladas
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public int Año
        {
            get;
            set;
        }

        public string Q
        {
            get;
            set;
        }

        public int Mes
        {
            get;
            set;
        }

        public DetalleQuincena()
        {
            InitializeComponent();
        }

        private void LlenaDicMeses()
        {
            this.dicMeses.Add("Enero", 1);
            this.dicMeses.Add("Febrero", 2);
            this.dicMeses.Add("Marzo", 3);
            this.dicMeses.Add("Abril", 4);
            this.dicMeses.Add("Mayo", 5);
            this.dicMeses.Add("Junio", 6);
            this.dicMeses.Add("Julio", 7);
            this.dicMeses.Add("Agosto", 8);
            this.dicMeses.Add("Septiembre", 9);
            this.dicMeses.Add("Octubre", 10);
            this.dicMeses.Add("Noviembre", 11);
            this.dicMeses.Add("Diciembre", 12);
        }

        public void LoadData()
        {
            UltraGridLayout layout = this.grdDetalleQuincena.DisplayLayout;
            UltraGridBand band = layout.Bands[0];

            try
            {
                this.LlenaDicMeses();

                if (this.DtDetalleComisiones == null)
                    return;

                this.Text = this.Title;

                try
                {
                    checkedColumns = FilesUtil.Read("dictionary.bin");
                }
                catch
                {
                    checkedColumns = new Dictionary<string, string>();
                }

                try
                {
                    this.grdDetalleQuincena.DataSource = this.DtDetalleComisiones.AsEnumerable()
                        .AsParallel().Where(x => Convert.ToInt32(x["mes"]) == this.Mes
                            && this.Q == x["Q"].ToString().Trim()
                            && Convert.ToInt32(x["anio"]) == this.Año).OrderBy(x => x["es_servicio"]).ThenBy(x => x["factura"]).CopyToDataTable();

                    this.tcFacturasPagadas.TabPages["FacturasPagadas"].Text = "Facturas Pagadas [" +
                            this.grdDetalleQuincena.Rows.Count + "]";
                }
                catch
                {
                    this.tcFacturasPagadas.TabPages["FacturasPagadas"].Text = "Facturas Pagadas [0]";
                }

                try
                {
                    this.grdFacturasCanceladas.DataSource = this.DtFacturasCanceladas.AsEnumerable()
                        .AsParallel().Where(x => this.dicMeses[x["mes"].ToString()] == this.Mes
                            && this.Q == x["Q"].ToString().Trim()
                            && Convert.ToInt32(x["anio"]) == this.Año).OrderBy(x => x["factura"]).CopyToDataTable();

                    this.tcComplemento.TabPages["FacturasCanceladas"].Text = "Facturas Canceladas [" +
                        this.grdFacturasCanceladas.Rows.Count + "]";
                }
                catch
                {
                    this.tcComplemento.TabPages["FacturasCanceladas"].Text = "Facturas Canceladas [0]";
                }

                try
                {
                    this.grdFacturasPendientes.DataSource = this.DtFacturasPendientes.AsEnumerable()
                        .AsParallel().Where(x => this.dicMeses[x["mes"].ToString()] == this.Mes
                            && this.Q == x["Q"].ToString().Trim()
                            && Convert.ToInt32(x["anio"]) == this.Año).OrderBy(x => x["factura"]).CopyToDataTable();

                    this.tcComplemento.TabPages["FacturasPendientes"].Text = "Facturas Pendientes [" +
                        this.grdFacturasPendientes.Rows.Count + "]";
                }
                catch
                {
                    this.tcComplemento.TabPages["FacturasPendientes"].Text = "Facturas Pendientes [0]";
                }

                foreach (string columName in this.DtDetalleComisiones.Columns.Cast<DataColumn>()
                    .Select(x => x.ColumnName))
                {
                    this.clbColumnas.Items.Add(columName);
                    this.columnIndexes.Add(columName, this.clbColumnas.Items.Count - 1);
                    if (checkedColumns.ContainsKey(columName))
                    {
                        this.clbColumnas.SetItemChecked(this.clbColumnas.Items.Count - 1,
                            checkedColumns[columName] == "1");
                        band.Columns[columName].Hidden = checkedColumns[columName] == "0";
                    }
                    else
                    {
                        this.checkedColumns.Add(columName, "1");
                        this.clbColumnas.SetItemChecked(this.clbColumnas.Items.Count - 1, true);
                    }
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }

        private void clbColumnas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            UltraGridLayout layout = this.grdDetalleQuincena.DisplayLayout;
            UltraGridBand band = layout.Bands[0];

            if (this.grdDetalleQuincena.DisplayLayout.Bands[0].Columns.Count > 0)
            {
                band.Columns[e.Index].Hidden = this.clbColumnas.GetItemChecked(e.Index);
                checkedColumns[band.Columns[e.Index].Header.Caption]
                    = band.Columns[e.Index].Hidden ? "0" : "1";
            }

            FilesUtil.Write(checkedColumns, "dictionary.bin");
        }

        private void GeneralGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (GeneralUtil.IsCurrencyFormat(e.Column.Name))
            {
                e.Column.DefaultCellStyle.Format = "c";
            }

            if (GeneralUtil.IsRightAlignment(e.Column.Name))
            {
                e.Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void grdFacturasCanceladas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.grdFacturasCanceladas.Rows[e.RowIndex].Cells["pendiente_cobro"].Value.ToString() == "Si")
            {
                e.CellStyle.BackColor = Color.Red;
            }
        }

        private void grdDetalleQuincena_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.Select;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["fiscal"],
                TextMaskFormatEnum.Integer);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["factura"],
                TextMaskFormatEnum.Integer);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["factura_original"],
                TextMaskFormatEnum.Integer);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["importe"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["costo"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["utilidad"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["utilidad_comisionable"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["margen_utilidad"],
                TextMaskFormatEnum.Percentage);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["total_acumulado"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["acumulado_cuota"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["acumulado_comision"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["acumulado_comision_agente"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["total"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["total_pagado"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["porcentaje_comision"],
                TextMaskFormatEnum.Percentage);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["cuota"],
                TextMaskFormatEnum.Currency);

            Parallel.ForEach(this.grdDetalleQuincena.Rows, row =>
            {
                if (row.Cells["pendiente_pago"].Value.ToString() == "Si")
                {
                    row.CellAppearance.BackColor = Color.LightGreen;
                }

                decimal utilidad = Convert.ToDecimal(row.Cells["utilidad_comisionable"].Value);
                decimal utilidadComissionable = Convert.ToDecimal(row.Cells["utilidad_comisionable"].Value);

                if (utilidad - utilidadComissionable > 0.01M || utilidadComissionable <= 0)
                {
                    if (row.CellAppearance.BackColor == Color.LightGreen)
                        row.CellAppearance.BackColor = Color.YellowGreen;
                    else
                        row.CellAppearance.BackColor = Color.Yellow;
                }
            });
        }

        private void grdDetalleQuincena_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            DetalleFactura form = new DetalleFactura();
            form.IdFactura = Convert.ToInt32(e.Row.Cells["factura"].Value);
            form.LoadGrids();
            form.ShowDialog(this);
        }
    }
}
