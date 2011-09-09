﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComisionesSamsara;

namespace ComisionesAgentes
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
            try
            {
                this.LlenaDicMeses();

                if (this.DtDetalleComisiones == null)
                    return;

                this.Text = this.Title;

                try
                {
                    checkedColumns = FileUtils.Read("dictionary.bin");
                }
                catch
                {
                    checkedColumns = new Dictionary<string, string>();
                }

                this.grdDetalleQuincena.DataSource = this.DtDetalleComisiones.AsEnumerable()
                    .Where(x => Convert.ToInt32(x["mes"]) == this.Mes
                        && this.Q == x["Q"].ToString().Trim()
                        && Convert.ToInt32(x["anio"]) == this.Año).CopyToDataTable();

                try
                {
                    this.grdFacturasCanceladas.DataSource = this.DtFacturasCanceladas.AsEnumerable()
                        .Where(x => this.dicMeses[x["mes"].ToString()] == this.Mes
                            && this.Q == x["Q"].ToString().Trim()
                            && Convert.ToInt32(x["anio"]) == this.Año).OrderBy(x => x["factura"]).CopyToDataTable();

                    this.tcComplemento.TabPages["FacturasCanceladas"].Text = "Facturas Canceladas [" +
                        ((DataTable)this.grdFacturasCanceladas.DataSource).Rows.Count + "]";
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    this.tcComplemento.TabPages["FacturasCanceladas"].Text = "Facturas Canceladas [0]";
                }

                try
                {
                    this.grdFacturasPendientes.DataSource = this.DtFacturasPendientes.AsEnumerable()
                        .Where(x => this.dicMeses[x["mes"].ToString()] == this.Mes
                            && this.Q == x["Q"].ToString().Trim()
                            && Convert.ToInt32(x["anio"]) == this.Año).OrderBy(x => x["factura"]).CopyToDataTable();

                    this.tcComplemento.TabPages["FacturasPendientes"].Text = "Facturas Pendientes [" +
                        ((DataTable)this.grdFacturasPendientes.DataSource).Rows.Count + "]";
                }
                catch (Exception ex)
                {
                    ex.ToString();
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
                        this.grdDetalleQuincena.Columns[columName].Visible
                            = checkedColumns[columName] == "1";
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
            if (this.grdDetalleQuincena.Columns.Count > 0)
            {
                this.grdDetalleQuincena.Columns[e.Index].Visible
                    = !this.clbColumnas.GetItemChecked(e.Index);
                checkedColumns[this.grdDetalleQuincena.Columns[e.Index].Name]
                    = this.grdDetalleQuincena.Columns[e.Index].Visible ? "1" : "0";
            }

            FileUtils.Write(checkedColumns, "dictionary.bin");
        }

        private void GeneralGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (GeneralUtils.IsCurrencyFormat(e.Column.Name))
            {
                e.Column.DefaultCellStyle.Format = "c";
            }

            if (GeneralUtils.IsRightAlignment(e.Column.Name))
            {
                e.Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void grdDetalleQuincena_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.grdDetalleQuincena.Rows[e.RowIndex].Cells["pendiente_pago"].Value.ToString() == "Si")
            {
                e.CellStyle.BackColor = Color.LightGreen;
            }
        }

        private void grdFacturasCanceladas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.grdFacturasCanceladas.Rows[e.RowIndex].Cells["pendiente_cobro"].Value.ToString() == "Si")
            {
                e.CellStyle.BackColor = Color.Red;
            }
        }
    }
}
