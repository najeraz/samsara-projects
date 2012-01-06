
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ComisionesSamsara;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace ComisionesAgentes
{
    public partial class ComisionesForm : Form
    {
        #region Attributes

        private static string cnnString =
            "Data Source=192.168.10.4;Initial Catalog=Comisiones;User Id=javier;Password=javier;";
        private static bool isConfigurable = true;
        private SqlConnection cnn;
        private DataSet ds;
        private string consulta;
        private SqlDataAdapter da;
        private Dictionary<string, int> dicMeses = new Dictionary<string, int>();
        private SqlTransaction transacction = null;

        #endregion Attributes

        #region Constructor

        public ComisionesForm()
        {
            cnn = new SqlConnection(cnnString);
            InitializeComponent();
            PostInitializeComponent();
        }

        #endregion Constructor

        #region Methods

        private void PostInitializeComponent()
        {
            try
            {
                this.LlenaDicMeses();
                this.InsertNewAgents();
                this.LoadCombosAgentes(true);
                this.dtpInicio.Value = new DateTime(2011, 01, 01);
                this.dtpFin.Value = DateTime.Now;
                this.LoadGridAgentesActivos();
                this.LoadDudAños();
                this.LoadAjustes();
                this.tcConfiguracion.Enabled = isConfigurable;
                this.cbxAgenteMargenes_SelectedIndexChanged(null, null);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de conexión con la base de datos.\n\n"
                    + ex.Message, "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
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

        private void LoadDudAños()
        {
            foreach (int num in Enumerable.Range(2001, 20))
            {
                this.dudAños.Items.Add(num);
            }
            this.dudAños.SelectedItem = DateTime.Now.Year;
        }

        private void LoadCombosAgentes(bool loadAgentesConfig)
        {
            DataSet ds = null;

            if (loadAgentesConfig)
            {
                consulta = @"
                    SELECT * FROM agentes_activos 
                    WHERE activo = 1
                    ORDER BY nombre_agente
                ";

                ds = new DataSet();
                da = new SqlDataAdapter(consulta, cnn);
                da.Fill(ds, "agentes");

                this.cbxAgentesConfig.DataSource = ds.Tables["agentes"].Copy();
                this.cbxAgentesConfig.ValueMember = "agente";
                this.cbxAgentesConfig.DisplayMember = "nombre_agente";
            }

            consulta = @"
                    SELECT * FROM agentes_activos 
                    WHERE activo = 1 AND puede_comisionar = 1
                    ORDER BY nombre_agente
                ";

            ds = new DataSet();
            da = new SqlDataAdapter(consulta, cnn);
            da.Fill(ds, "agentes");

            this.cbxAgentes.DataSource = null;
            this.cbxAgentes.DataSource = ds.Tables["agentes"].Copy();
            this.cbxAgentes.ValueMember = "agente";
            this.cbxAgentes.DisplayMember = "nombre_agente";

            this.cbxAgenteComision.DataSource = null;
            this.cbxAgenteComision.DataSource = ds.Tables["agentes"].Copy();
            this.cbxAgenteComision.ValueMember = "agente";
            this.cbxAgenteComision.DisplayMember = "nombre_agente";

            this.cbxAgenteMargenes.DataSource = null;
            this.cbxAgenteMargenes.DataSource = ds.Tables["agentes"].Copy();
            this.cbxAgenteMargenes.ValueMember = "agente";
            this.cbxAgenteMargenes.DisplayMember = "nombre_agente";
        }

        private void LoadGridAgentesActivos()
        {
            consulta = @"
                    SELECT agente, nombre_agente, activo, puede_comisionar
                    FROM agentes_activos 
                    ORDER BY activo desc, nombre_agente
                ";
            da = new SqlDataAdapter(consulta, cnn);
            ds = new DataSet();
            da.Fill(ds, "agentes_activos");
            this.grdAgentesActivos.DataSource = ds.Tables["agentes_activos"];
            this.grdAgentesActivos.Columns["nombre_agente"].Width = 200;
        }

        private void LoadGrdLineas(int idAgente)
        {
            bool closed = cnn.State == ConnectionState.Closed;

            if (closed)
            {
                cnn.Open();
            }

            consulta = string.Format(@"
                    SELECT la.linea, RTRIM(la.nombre_linea) nombre_linea,
                    SUM(COALESCE(fag.margen_minimo, 0)) / CASE WHEN 
                    SUM(CASE WHEN fag.margen_minimo IS NOT NULL
						THEN 1 ELSE 0 END
                    ) = 0 THEN NULL ELSE
                    SUM(CASE WHEN fag.margen_minimo IS NOT NULL
						THEN 1 ELSE 0 END
                    ) END * 100.0 margen_promedio,
                    CAST(SUM(CASE WHEN fag.margen_minimo IS NOT NULL
						THEN 1 ELSE 0 END
                    ) AS VARCHAR(10)) + ' de ' + CAST(COUNT(*) AS VARCHAR(10)) familias_configuradas
                    FROM ERP_CIE.dbo.Lineas_Articulos la
                    INNER JOIN ERP_CIE.dbo.Sublineas_Articulos sa ON sa.linea = la.linea
                    INNER JOIN ERP_CIE.dbo.Familias_Articulos fa ON fa.sublinea = sa.sublinea
                    INNER JOIN Familias_Agentes fag ON fag.familia = fa.familia
                    WHERE agente = {0}
                    GROUP BY la.linea, la.nombre_linea
                    ORDER BY nombre_linea
                ", idAgente);
            da = new SqlDataAdapter(consulta, cnn);
            ds = new DataSet();
            da.Fill(ds, "lineas");
            this.grdLineas.DataSource = ds.Tables["lineas"];

            if (closed)
            {
                cnn.Close();
            }
        }

        private void LoadGrdSublineas(int idAgente, int linea)
        {
            bool closed = cnn.State == ConnectionState.Closed;

            if (closed)
            {
                cnn.Open();
            }

            consulta = string.Format(@"
                    SELECT la.linea, sa.sublinea, RTRIM(sa.nombre_sublinea) nombre_sublinea,
                    SUM(COALESCE(fag.margen_minimo, 0)) / CASE WHEN 
                    SUM(CASE WHEN fag.margen_minimo IS NOT NULL
						THEN 1 ELSE 0 END
                    ) = 0 THEN NULL ELSE
                    SUM(CASE WHEN fag.margen_minimo IS NOT NULL
						THEN 1 ELSE 0 END
                    ) END * 100.0 margen_promedio,
                    CAST(SUM(CASE WHEN fag.margen_minimo IS NOT NULL
						THEN 1 ELSE 0 END
                    ) AS VARCHAR(10)) + ' de ' + CAST(COUNT(*) AS VARCHAR(10)) familias_configuradas
                    FROM ERP_CIE.dbo.Sublineas_Articulos sa
                    INNER JOIN ERP_CIE.dbo.Lineas_Articulos la ON la.linea = sa.linea
                    INNER JOIN ERP_CIE.dbo.Familias_Articulos fa ON fa.sublinea = sa.sublinea
                    INNER JOIN Familias_Agentes fag ON fag.familia = fa.familia
                    WHERE sa.linea = {0} AND agente = {1}
                    GROUP BY la.linea, sa.sublinea, sa.nombre_sublinea
                    ORDER BY nombre_sublinea
                ", linea, idAgente);

            da = new SqlDataAdapter(consulta, cnn);
            ds = new DataSet();
            da.Fill(ds, "sublineas");
            this.grdSublineas.DataSource = ds.Tables["sublineas"];

            if (closed)
            {
                cnn.Close();
            }
        }

        private void LoadGrdFamilias(int idAgente, Nullable<int> sublinea)
        {
            bool closed = cnn.State == ConnectionState.Closed;

            if (closed)
            {
                cnn.Open();
            }

            consulta = string.Format(@"
                    INSERT INTO Familias_Agentes (familia, agente)
                    SELECT familia, {0}
                    FROM	ERP_CIE.dbo.Familias_Articulos fa
                    WHERE familia NOT IN (
					    SELECT familia FROM Familias_Agentes
					    WHERE agente = {0}
                    )
                ", idAgente);

            SqlCommand command = new SqlCommand(consulta, cnn);
            command.ExecuteNonQuery();

            if (sublinea != null)
            {
                consulta = string.Format(@"
					    SELECT la.linea, sa.sublinea, fa.familia, RTRIM(far.nombre_familia) nombre_familia, 
                        fa.margen_minimo * 100.0 margen_minimo
                        FROM Familias_Agentes fa
                        INNER JOIN ERP_CIE.dbo.Familias_Articulos far ON far.familia = fa.familia
                        INNER JOIN ERP_CIE.dbo.Sublineas_Articulos sa ON sa.sublinea = far.sublinea
                        INNER JOIN ERP_CIE.dbo.Lineas_Articulos la ON la.linea = sa.linea
					    WHERE agente = {0} AND sa.sublinea = {1}
                        ORDER BY nombre_familia
                    ", idAgente, sublinea);
                da = new SqlDataAdapter(consulta, cnn);
                ds = new DataSet();
                da.Fill(ds, "margenes");
                this.grdFamilias.DataSource = ds.Tables["margenes"];
            }

            if (closed)
            {
                cnn.Close();
            }
        }

        private void LoadAjustes()
        {
            if (this.cbxAgenteAjustes.DataSource == null)
            {
                consulta = "select id ajuste, aj.agente, nombre_agente, fecha_ajuste from ajustes aj "
                    + "inner join agentes_activos aa on aa.agente = aj.agente where activo = 1 and borrado = 0";

                da = new SqlDataAdapter(consulta, cnn);
                ds = new DataSet();
                da.Fill(ds, "ajustes");
                this.grdAjustes.DataSource = null;
                this.grdAjustes.DataSource = ds.Tables["ajustes"];

                this.cbxAgenteAjustes.DataSource = null;
                this.cbxAgenteAjustes.DataSource = ds.Tables["ajustes"].AsEnumerable()
                    .Select(x => new
                    {
                        agente = Convert.ToInt32(x["agente"]),
                        nombre = x["nombre_agente"].ToString()
                    })
                    .Distinct().OrderBy(x => x.nombre).ToList();
                this.cbxAgenteAjustes.ValueMember = "agente";
                this.cbxAgenteAjustes.DisplayMember = "nombre";
            }

            int idAgente;

            if (this.cbxAgenteAjustes.SelectedValue != null
                && int.TryParse(this.cbxAgenteAjustes.SelectedValue.ToString(), out idAgente))
            {
                consulta = "select id ajuste, aj.agente, nombre_agente, fecha_ajuste from ajustes aj "
                    + "inner join agentes_activos ag on ag.agente = aj.agente where aj.agente = "
                    + idAgente + " and borrado = 0 order by ajuste";

                da = new SqlDataAdapter(consulta, cnn);
                ds = new DataSet();
                da.Fill(ds, "ajustes");

                this.grdAjustes.DataSource = null;
                this.grdAjustes.DataSource = ds.Tables["ajustes"];
            }
        }

        private void InsertNewAgents()
        {
            cnn.Open();

            consulta = @"
                INSERT INTO agentes_activos (agente, nombre_agente, activo, puede_comisionar)
                select distinct cast(f.agente as int) agente,
                LEFT( ERP_CIE.dbo.Nombre_Persona2( f.agente), 100) nombre_agente, 0, 0
                FROM	ERP_CIE.dbo.Facturas_Clientes f
                WHERE agente not in (select agente from agentes_activos)
                ";

            SqlCommand command = new SqlCommand(consulta, cnn);
            command.ExecuteNonQuery();
            cnn.Close();
        }

        private void CalculaComisionesQ()
        {
            this.CalculaComisionesQ(((DataTable)this.grdDetalleComisiones.DataSource),
                ((DataTable)this.grdResumenComisiones.DataSource));
        }

        private void CalculaComisionesQ(DataTable dtComisiones, DataTable dtResumenComisiones)
        {
            DataRow lastRow = null;

            dtResumenComisiones.Rows.Clear();
            foreach (var group in dtComisiones.AsEnumerable().GroupBy(x =>
                new { año = x["anio"], mes = x["mes"], q = x["Q"] }))
            {
                decimal acumulado = decimal.Zero;
                decimal sumatoria_cuotas = decimal.Zero;
                DataRow rowResumen = dtResumenComisiones.NewRow();

                foreach (DataRow row in group)
                {
                    decimal cuota = Convert.ToDecimal(row["cuota"]);
                    sumatoria_cuotas += cuota;
                    acumulado += Convert.ToDecimal(row["utilidad_real"]);
                    row["total_acumulado"] = acumulado;
                    row["acumulado_cuota"]
                        = (acumulado < cuota ? acumulado : cuota).ToString("N4");
                    row["acumulado_comision"]
                        = (acumulado > cuota ? acumulado - cuota : decimal.Zero).ToString("N4");
                    row["acumulado_comision_agente"]
                        = (Convert.ToDecimal(row["acumulado_comision"])
                        * Convert.ToDecimal(row["porcentaje_comision"])).ToString("N4");
                    lastRow = row;
                }

                if (lastRow != null)
                {
                    rowResumen["anio"] = lastRow["anio"];
                    rowResumen["mes"] = this.dicMeses.ElementAt(Convert.ToInt32(lastRow["mes"]) - 1).Key;
                    rowResumen["Q"] = lastRow["Q"];
                    rowResumen["utilidad_general"] = 
                        Math.Round(((DataTable)this.grdFacturasPendientes.DataSource)
                        .AsEnumerable().Where(x => this.dicMeses[x["mes"].ToString()] == Convert.ToInt32(group.Key.mes)
                            && Convert.ToInt32(x["anio"]) == Convert.ToInt32(group.Key.año)
                            && x["Q"].ToString().Trim() == group.Key.q.ToString().Trim())
                            .Sum(x => Convert.ToDecimal(x["utilidad"])) + acumulado, 2);
                    rowResumen["utilidad_Q"] = Math.Round(acumulado, 2);
                    rowResumen["acumulado_comision"]
                        = Math.Round(Convert.ToDecimal(lastRow["acumulado_comision"]), 2);
                    rowResumen["porcentaje_comision"] = Convert.ToDecimal(lastRow["acumulado_comision_agente"]) == decimal.Zero ?
                        decimal.Zero.ToString("N2") : Math.Round(Convert.ToDecimal(lastRow["acumulado_comision_agente"])
                        / Convert.ToDecimal(lastRow["acumulado_comision"]), 2).ToString("N2");
                    rowResumen["cuota"]
                        = Math.Round(sumatoria_cuotas / group.Count(), 2);
                    rowResumen["monto_comision"]
                        = Math.Round(Convert.ToDecimal(lastRow["acumulado_comision_agente"]), 2);
                    rowResumen["saldo_a_pagar"] = "0.00";
                    rowResumen["total_pagado"] = "0.00";
                    rowResumen["fecha_ultimo_ajuste"] = "Nunca";
                }

                dtResumenComisiones.Rows.Add(rowResumen);
            }

            consulta = "select * from comisiones_pagadas cp WHERE agente = "
                + this.cbxAgentes.SelectedValue + " and id = ( "
                + "select max(id) from comisiones_pagadas WHERE agente = cp.agente "
                + "and mes = cp.mes and anio = cp.anio and q = cp.q)";

            da = new SqlDataAdapter(consulta, cnn);
            ds = new DataSet();
            da.Fill(ds, "ajustes");

            foreach (DataRow resumenRow in dtResumenComisiones.Rows)
            {
                DataRow row = ds.Tables["ajustes"].AsEnumerable()
                    .SingleOrDefault(x => x["q"].ToString().Trim() == resumenRow["Q"].ToString().Trim()
                    && this.dicMeses.ElementAt((int)x["mes"] - 1).Key == resumenRow["mes"].ToString()
                    && (int)x["anio"] == (int)resumenRow["anio"]);

                if (row != null)
                {
                    resumenRow["total_pagado"] = row["monto_comision"];
                    resumenRow["fecha_ultimo_ajuste"] = row["fecha_ajuste"];
                }

                resumenRow["saldo_a_pagar"] =
                    (Convert.ToDecimal(resumenRow["monto_comision"])
                    - Convert.ToDecimal(resumenRow["total_pagado"])).ToString("N2");
            }

            this.ActualizaTotalComisiones();
            this.lblAgente.Text = this.cbxAgentes.SelectedValue.ToString();

            var años = dtComisiones.AsEnumerable().Select(x => new
            {
                año = Convert.ToInt32(x["anio"])
            }).Distinct().ToList();
            this.cbxAños.DataSource = null;
            this.cbxAños.DataSource = años;
            this.cbxAños.ValueMember = "año";
            this.cbxAños.DisplayMember = "año";
            this.cbxAños.SelectedValue = años.Max(x => x.año);
            this.cbxAños_SelectedIndexChanged(null, null);
        }

        private void CreaReporteAnual(DataTable dtResumenComisiones)
        {
            consulta = "SELECT '' as Concepto, 0.00 " + string.Join(", 0.00 ", this.dicMeses
                .ToDictionary(x => x.Key + "_Q1", x => x.Value).Concat(this.dicMeses
                .ToDictionary(x => x.Key + "_Q2", x => x.Value))
                .OrderBy(x => x.Value).Select(x => x.Key).ToArray());

            da = new SqlDataAdapter(consulta, cnn);
            ds = new DataSet();
            da.Fill(ds, "meses");

            this.grdReporteAnual.DataSource = null;
            this.grdReporteAnual.DataSource = ds.Tables["meses"];
            ds.Tables["meses"].Rows.Remove(ds.Tables["meses"].Rows[0]);
            ds.Tables["meses"].AcceptChanges();
        }
        
        private void ActualizaTotalComisiones()
        {
            this.txtTotalComisiones.Text = ((DataTable)this.grdResumenComisiones.DataSource)
                .AsEnumerable().Sum(x => NumberUtils.DecimalValue(x["saldo_a_pagar"])).ToString("N2");
        }

        private void UpdateGrdAgentesActivos()
        {
            int idAgente;

            if (this.cbxAgenteComision.SelectedValue != null
                && int.TryParse(this.cbxAgenteComision.SelectedValue.ToString(), out idAgente))
            {
                consulta =
                    "select mes, '' as nombre_mes, cuota_mes cuota, comision_mes comision "
                    + "from tabla_comisiones where anio = " + this.dudAños.SelectedItem
                    + " AND agente = " + idAgente + " order by mes";
                SqlDataAdapter da = new SqlDataAdapter(consulta, cnn);
                ds = new DataSet();
                da.Fill(ds, "comisiones");
                this.grdComisionesAgente.DataSource = null;
                this.grdComisionesAgente.DataSource = ds.Tables["comisiones"];

                foreach (DataRow row in ds.Tables["comisiones"].AsEnumerable())
                {
                    row["nombre_mes"] = this.dicMeses.ElementAt(Convert.ToInt32(row["mes"]) - 1).Key;
                }

                if (ds.Tables["comisiones"].Rows.Count == 0)
                {
                    foreach (int mes in Enumerable.Range(1, 12))
                    {
                        cnn.Open();
                        consulta =
                            "INSERT INTO tabla_comisiones (agente, mes, anio, comision_mes, cuota_mes)"
                            + "VALUES (" + this.cbxAgenteComision.SelectedValue + ", "
                            + mes + ", " + this.dudAños.SelectedItem + ", 0, 0)";
                        SqlCommand command = new SqlCommand(consulta, cnn);
                        command.ExecuteNonQuery();
                        cnn.Close();
                    }

                    this.UpdateGrdAgentesActivos();
                }
            }
        }

        private void CreaAjuste()
        {
            consulta = "INSERT INTO Ajustes (agente,fecha_ajuste, borrado, fecha_borrado, fecha_cierre) VALUES("
                + this.lblAgente.Text + ",getdate(), 0, null, '" + this.dtpFin.Value.ToString("yyyyMMdd") + "')";

            SqlCommand command = new SqlCommand(consulta, cnn);
            command.Transaction = this.transacction;
            command.ExecuteNonQuery();

            consulta = "SELECT @@IDENTITY";
            command = new SqlCommand(consulta, cnn);
            command.Transaction = this.transacction;
            int idAjuste = Convert.ToInt32(command.ExecuteScalar());

            foreach (DataRow row in ((DataTable)this.grdResumenComisiones.DataSource).AsEnumerable()
                .Where(x => !(x["saldo_a_pagar"] is DBNull)))
            {
                consulta = "INSERT INTO comisiones_pagadas (anio,mes,q,utilidad,monto_comisionable"
                    + ",comision,monto_comision,fecha_ajuste,agente,ajuste) values("
                    + row["anio"] + "," + this.dicMeses[row["mes"].ToString()]
                    + ",'" + row["q"].ToString().Trim() + "'," + row["utilidad_q"]
                    + "," + row["acumulado_comision"] + "," + row["porcentaje_comision"]
                    + "," + row["monto_comision"] + ", getdate(), " + this.lblAgente.Text
                    + "," + idAjuste + ")";

                command = new SqlCommand(consulta, cnn);
                command.Transaction = this.transacction;
                command.ExecuteNonQuery();
            }

            foreach (DataRow row in ((DataTable)this.grdDetalleComisiones.DataSource).Rows)
            {
                object[] values = row.ItemArray.ToArray();

                values.SetValue(Convert.ToDateTime(values[3]).ToString("yyyyMMdd hh:mm:ss"), 3);
                values.SetValue(Convert.ToDateTime(values[4]).ToString("yyyyMMdd hh:mm:ss"), 4);

                consulta = "INSERT INTO Detalle_Comisiones_Pagadas (" + string.Join(",",
                    row.Table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray())
                    + ", ajuste) VALUES ('" + string.Join("','",
                    values.Select(x => x.ToString().Trim().Replace("'", "''"))
                    .ToArray()) + "'," + idAjuste + ")";

                command = new SqlCommand(consulta, cnn);
                command.Transaction = this.transacction;
                command.ExecuteNonQuery();
            }
        }

        private void ProcesaFacturasPendientes(DataTable dtFacturasPendientes)
        {
            foreach (var group in dtFacturasPendientes.AsEnumerable().GroupBy(x =>
                new { año = x["anio"], mes = x["mes"], q = x["Q"] }))
            {
                decimal acumulado = decimal.Zero;

                foreach (DataRow row in group)
                {
                    acumulado += Convert.ToDecimal(row["utilidad"]);
                    row["total_acumulado"] = acumulado;
                }
            }

            foreach (DataRow row in dtFacturasPendientes.AsEnumerable())
            {
                row["mes"] = this.dicMeses.ElementAt(Convert.ToInt32(row["mes"]) - 1).Key;
            }
        }

        private void ProcesaFacturasCanceladas(DataTable dtFacturasCanceladas)
        {
            foreach (DataRow row in dtFacturasCanceladas.AsEnumerable())
            {
                row["mes"] = this.dicMeses.ElementAt(Convert.ToInt32(row["mes"]) - 1).Key;
            }
        }

        private void ProcesaFacturasRefacturaciónAgena(DataTable dtFacturasRefacturaciónAgena)
        {
            foreach (DataRow row in dtFacturasRefacturaciónAgena.AsEnumerable())
            {
                row["mes"] = this.dicMeses.ElementAt(Convert.ToInt32(row["mes"]) - 1).Key;
            }
        }

        private void FormatGridResumenComisiones()
        {
            foreach (DataGridViewRow row in this.grdReporteAnual.Rows)
            {
                if (row.Cells["concepto"].Value.ToString() == "Comisión")
                    row.DefaultCellStyle.Format = "";
                else
                    row.DefaultCellStyle.Format = "c";
            }
        }

        #endregion Methods

        #region Events

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            SqlCommand command = null;
            this.lblAgente.Text = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                List<string> lstAgents = this.lbAgentesEquivalentes.SelectedItems.Cast<DataRowView>()
                    .Select(x => x["agente"].ToString()).ToList();

                lstAgents.Add(this.cbxAgentes.SelectedValue.ToString());

                cnn.Open();

                command = new SqlCommand("Comisiones_Agente", cnn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@cSucursal", 1));
                command.Parameters.Add(new SqlParameter("@cAgente",
                    this.cbxAgentes.SelectedValue.ToString()));
                command.Parameters.Add(new SqlParameter("@cAgentes",
                    string.Join(",", lstAgents.ToArray())));
                command.Parameters.Add(new SqlParameter("@dFecha1",
                    this.dtpInicio.Value.ToString("yyyyMMdd")));
                command.Parameters.Add(new SqlParameter("@dFecha2",
                    this.dtpFin.Value.ToString("yyyyMMdd")));

                command.CommandTimeout = 120;
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataSet data = new DataSet();
                da.Fill(data);

                this.FormatGridResumenComisiones();
                this.grdDetalleComisiones.DataSource = null;
                this.grdDetalleComisiones.DataSource = data.Tables[0];
                this.grdResumenComisiones.DataSource = null;
                this.grdResumenComisiones.DataSource = data.Tables[1];
                this.grdFacturasPendientes.DataSource = null;
                this.grdFacturasPendientes.DataSource = data.Tables[2];
                this.grdFacturasCanceladas.DataSource = null;
                this.grdFacturasCanceladas.DataSource = data.Tables[3];
                this.grdRefacturaciónAgena.DataSource = null;
                this.grdRefacturaciónAgena.DataSource = data.Tables[4];

                this.CreaReporteAnual(data.Tables[1]);
                this.ProcesaFacturasPendientes(data.Tables[2]);
                this.CalculaComisionesQ(data.Tables[0], data.Tables[1]);
                this.ProcesaFacturasCanceladas(data.Tables[3]);
                this.ProcesaFacturasRefacturaciónAgena(data.Tables[4]);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("No se pudo generar el reporte, posiblemente por falta de "
                    + "configuración de cuotas del agente, consulte al administrador del sistema.\n"
                    + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el reporte, consulte al administrador del sistema.\n"
                    + ex.Message, "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                command.CommandTimeout = 10;
                cnn.Close();
                this.Cursor = Cursors.Default;
            }
        }

        private void cbxAgentesConfig_SelectedValueChanged(object sender, EventArgs e)
        {
            int idAgente;

            if (this.cbxAgentesConfig.SelectedValue != null 
                && int.TryParse(this.cbxAgentesConfig.SelectedValue.ToString(), out idAgente))
            {
                consulta =
                    "select * from agentes_activos where activo = 1 AND agente != "
                    + idAgente + " order by nombre_agente";
                SqlDataAdapter da = new SqlDataAdapter(consulta, cnn);
                ds = new DataSet();
                da.Fill(ds, "agentes_activos");
                this.clstConfigSelected.DataSource = null;
                this.clstConfigSelected.DataSource = ds.Tables["agentes_activos"];
                this.clstConfigSelected.ValueMember = "agente";
                this.clstConfigSelected.DisplayMember = "nombre_agente";

                consulta =
                    "select aae.agente, aae.nombre_agente from agentes_activos aa "
                    + "INNER JOIN agentes_equivalentes ae ON ae.agente_original = aa.agente "
                    + "INNER JOIN agentes_activos aae ON aae.agente = ae.agente_equivalente " 
                    + "where aa.activo = 1 AND aa.agente = "
                    + idAgente + " order by nombre_agente";

                da = new SqlDataAdapter(consulta, cnn);
                ds = new DataSet();
                da.Fill(ds, "agentes_equivalentes");

                this.clstConfigSelected.ItemCheck -= new ItemCheckEventHandler(clstConfigSelected_ItemCheck);
                foreach (DataRow row in ds.Tables["agentes_equivalentes"].Rows)
                {
                    this.clstConfigSelected.SelectedValue = row["agente"];
                    this.clstConfigSelected.SetItemCheckState(
                        this.clstConfigSelected.SelectedIndex, CheckState.Checked);
                }
                this.clstConfigSelected.SelectedIndex = 0;
                this.clstConfigSelected.ItemCheck += new ItemCheckEventHandler(clstConfigSelected_ItemCheck);
            }
        }

        private void clstConfigSelected_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idAgente;

            if (int.TryParse(this.cbxAgentesConfig.SelectedValue.ToString(), out idAgente))
            {
                bool closed = cnn.State == ConnectionState.Closed;

                if (closed)
                {
                    cnn.Open();
                }

                consulta = "DELETE FROM agentes_equivalentes WHERE agente_original = "
                    + idAgente + " AND agente_equivalente = "
                    + this.clstConfigSelected.SelectedValue;
                SqlCommand command = new SqlCommand(consulta, cnn);
                command.ExecuteNonQuery();

                if (e.NewValue == CheckState.Checked)
                {
                    consulta = "INSERT INTO agentes_equivalentes (agente_original, agente_equivalente)"
                        + "VALUES (" + this.cbxAgentesConfig.SelectedValue + ", " 
                        + this.clstConfigSelected.SelectedValue + ")";
                    command = new SqlCommand(consulta, cnn);
                    command.ExecuteNonQuery();
                }

                if (closed)
                {
                    cnn.Close();
                }

                this.LoadCombosAgentes(false);
            }
        }

        private void cbxAgentes_SelectedValueChanged(object sender, EventArgs e)
        {
            int idAgente;

            if (this.cbxAgentes.SelectedValue != null
                && int.TryParse(this.cbxAgentes.SelectedValue.ToString(), out idAgente))
            {
                consulta =
                    "select aae.agente, aae.nombre_agente from agentes_activos aa "
                    + "INNER JOIN agentes_equivalentes ae ON ae.agente_original = aa.agente "
                    + "INNER JOIN agentes_activos aae ON aae.agente = ae.agente_equivalente "
                    + "where aa.activo = 1 AND aa.agente = "
                    + idAgente + " order by nombre_agente";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cnn);
                ds = new DataSet();
                da.Fill(ds, "agentes_equivalentes");
                this.lbAgentesEquivalentes.DataSource = null;
                this.lbAgentesEquivalentes.DataSource = ds.Tables["agentes_equivalentes"];
                this.lbAgentesEquivalentes.ValueMember = "agente";
                this.lbAgentesEquivalentes.DisplayMember = "nombre_agente";
            }
        }

        private void grdAgentesActivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == this.grdAgentesActivos.Columns["activo"].Index)
            {
                bool activo = Convert.ToBoolean(
                    this.grdAgentesActivos.Rows[e.RowIndex].Cells["activo"].Value);

                if (MessageBox.Show("¿Esta seguro de " + (activo ? "desactivar" : "activar")
                    + " el agente "
                    + this.grdAgentesActivos.Rows[e.RowIndex].Cells["nombre_agente"].Value
                    + "?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                cnn.Open();

                consulta = "UPDATE agentes_activos SET activo = " + (activo ? 0 : 1)
                    + " WHERE agente = "
                    + this.grdAgentesActivos.Rows[e.RowIndex].Cells["agente"].Value;
                SqlCommand command = new SqlCommand(consulta, cnn);
                command.ExecuteNonQuery();

                this.LoadGridAgentesActivos();
                this.LoadCombosAgentes(true);
                cnn.Close();
            }

            if (e.ColumnIndex == this.grdAgentesActivos.Columns["puede_comisionar"].Index)
            {
                bool puedeComisionar = Convert.ToBoolean(
                    this.grdAgentesActivos.Rows[e.RowIndex].Cells["puede_comisionar"].Value);

                cnn.Open();

                consulta = "UPDATE agentes_activos SET puede_comisionar = " + (puedeComisionar ? 0 : 1)
                    + " WHERE agente = "
                    + this.grdAgentesActivos.Rows[e.RowIndex].Cells["agente"].Value;
                SqlCommand command = new SqlCommand(consulta, cnn);
                command.ExecuteNonQuery();

                this.LoadGridAgentesActivos();
                this.LoadCombosAgentes(true);
                cnn.Close();
            }
        }

        private void grdComisionesAgente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            ComisionDataDialog dialog = new ComisionDataDialog();
            dialog.Comision = Convert.ToDecimal(
                this.grdComisionesAgente.Rows[e.RowIndex].Cells["comision"].Value) * 100M;
            dialog.Cuota = Convert.ToDecimal(
                this.grdComisionesAgente.Rows[e.RowIndex].Cells["cuota"].Value);
            dialog.ShowDialog(this);
            if (dialog.Tipo != null)
            {
                consulta =
                    "UPDATE tabla_comisiones SET comision_mes = " + dialog.Comision
                    + ", cuota_mes = " + dialog.Cuota
                    + " WHERE agente = " + this.cbxAgenteComision.SelectedValue
                    + " AND anio = " + this.dudAños.SelectedItem;

                if (dialog.Tipo == ComisionTypeEnum.Mes)
                {
                    consulta += " AND mes = " + this.grdComisionesAgente.Rows[e.RowIndex].Cells["mes"].Value;
                }
                cnn.Open();

                SqlCommand command = new SqlCommand(consulta, cnn);
                command.ExecuteNonQuery();
                cnn.Close();

                this.UpdateGrdAgentesActivos();
            }
        }

        private void dudAños_SelectedItemChanged(object sender, EventArgs e)
        {
            this.UpdateGrdAgentesActivos();
        }

        private void cbxAgenteComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateGrdAgentesActivos();
            this.dudAños.SelectedItem = DateTime.Now.Year;
        }

        private void cbxAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            int año;

            if (this.cbxAños.SelectedValue != null
                && int.TryParse(this.cbxAños.SelectedValue.ToString(), out año))
            {
                DataTable dtResumen = (DataTable)this.grdResumenComisiones.DataSource;
                DataTable dtReporteAnual = (DataTable)this.grdReporteAnual.DataSource;

                if (dtReporteAnual != null)
                {
                    dtReporteAnual.Rows.Clear();
                    DataRow rowComision = dtReporteAnual.NewRow();
                    DataRow rowMontoComisionable = dtReporteAnual.NewRow();
                    DataRow rowUtilidadPagada = dtReporteAnual.NewRow();
                    DataRow rowUtilidadGeneral = dtReporteAnual.NewRow();
                    DataRow rowCuota = dtReporteAnual.NewRow();
                    DataRow rowPorcentaje = dtReporteAnual.NewRow();
                    DataRow rowTotalAPagar = dtReporteAnual.NewRow();
                    DataRow rowTotalPagado = dtReporteAnual.NewRow();

                    dtReporteAnual.Rows.Add(rowUtilidadGeneral);
                    dtReporteAnual.Rows.Add(rowUtilidadPagada);
                    dtReporteAnual.Rows.Add(rowCuota);
                    dtReporteAnual.Rows.Add(rowMontoComisionable);
                    dtReporteAnual.Rows.Add(rowPorcentaje);
                    dtReporteAnual.Rows.Add(rowComision);
                    dtReporteAnual.Rows.Add(rowTotalPagado);
                    dtReporteAnual.Rows.Add(rowTotalAPagar);

                    foreach (DataRow row in dtResumen.AsEnumerable()
                        .Where(x => Convert.ToInt32(x["anio"]) == año))
                    {
                        int mes = this.dicMeses[row["mes"].ToString()];
                        int index = mes * 2 + (row["Q"].ToString().Trim() == "Q1" ? -1 : 0);

                        rowUtilidadGeneral[index] = row["utilidad_general"];
                        rowUtilidadPagada[index] = row["utilidad_Q"];
                        rowCuota[index] = row["cuota"];
                        rowMontoComisionable[index] = row["acumulado_comision"];
                        rowPorcentaje[index] = row["porcentaje_comision"];
                        rowComision[index] = row["monto_comision"];
                        rowTotalAPagar[index] = Convert.ToDecimal(row["saldo_a_pagar"]).ToString("N2");
                        rowTotalPagado[index] = Convert.ToDecimal(row["total_pagado"]).ToString("N2");
                    }

                    rowUtilidadGeneral["concepto"] = "Utilidad General";
                    rowUtilidadPagada["concepto"] = "Utilidad Pagada";
                    rowCuota["concepto"] = "Cuota";
                    rowMontoComisionable["concepto"] = "Utilidad Comisionable";
                    rowPorcentaje["concepto"] = "Comisión";
                    rowComision["concepto"] = "Monto Comisión";
                    rowTotalPagado["concepto"] = "Total Pagado";
                    rowTotalAPagar["concepto"] = "Total a Pagar";

                    dtReporteAnual.AcceptChanges();
                }
            }
        }

        private void grdReporteAnual_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex == -1)
            {
                DetalleQuincena form = new DetalleQuincena();
                form.Año = (int)this.cbxAños.SelectedValue;
                form.Mes = (e.ColumnIndex - 1) / 2 + 1;
                form.Q = ((e.ColumnIndex - 1) % 2) == 0 ? "Q1" : "Q2";
                form.Title = "Detalle " + this.dicMeses.ElementAt(form.Mes - 1).Key + " " + form.Q;
                form.DtDetalleComisiones = (DataTable)this.grdDetalleComisiones.DataSource;
                form.DtFacturasPendientes = (DataTable)this.grdFacturasPendientes.DataSource;
                form.DtFacturasCanceladas = (DataTable)this.grdFacturasCanceladas.DataSource;
                form.LoadData();
                form.ShowDialog(this);
            }
        }

        private void GeneralGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (((DataGridView)sender) == this.grdResumenComisiones && e.Column.Name == "saldo_a_pagar")
                e.Column.ReadOnly = false || !isConfigurable;
            else
                e.Column.ReadOnly = true;

            if (GeneralUtils.IsRightAlignment(e.Column.Name))
            {
                e.Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btnActualizarComisiones_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de generar el pago?", 
                "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                cnn.Open();
                transacction = cnn.BeginTransaction();
                this.CreaAjuste();
                transacction.Commit();
            }
            catch (Exception ex)
            {
                transacction.Rollback();
                MessageBox.Show("No se pudo generar el ajuste de comisiones, consulte al administrador del sistema.\n"
                    + ex.Message, "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                cnn.Close();
                this.CalculaComisionesQ();
            }
        }

        private void grdResumenComisiones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ActualizaTotalComisiones();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            this.CalculaComisionesQ();
        }

        private void lblAgente_TextChanged(object sender, EventArgs e)
        {
            this.pnlAdmin.Enabled = this.lblAgente.Text.Length > 0 && isConfigurable;
        }

        private void btnEliminarAjuste_Click(object sender, EventArgs e)
        {
            string[] ajusteIds = this.grdAjustes.SelectedRows.Cast<DataGridViewRow>()
                .Select(x => (x.DataBoundItem as DataRowView).Row["saldo_a_pagar"].ToString()).ToArray();

            string pregunta = ajusteIds.Count() > 1 ? "¿Esta seguro de borrar los ajustes "
                : "¿Esta seguro de borrar el ajuste ";

            if (ajusteIds.Count() <= 0)
                return;

            if (MessageBox.Show( pregunta + string.Join(", ", ajusteIds.ToArray()) 
                + "?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            consulta = "update ajustes set borrado = 1, "
                + "fecha_borrado = getdate() where ajuste in ("
                + string.Join(", ", ajusteIds.ToArray()) + ")";

            cnn.Open();
            SqlCommand command = new SqlCommand(consulta, cnn);
            command.Transaction = this.transacction;
            command.ExecuteNonQuery();
            cnn.Close();

            this.LoadAjustes();
        }

        private void btnActualizarAjustes_Click(object sender, EventArgs e)
        {
            this.cbxAgenteAjustes.DataSource = null;
            this.LoadAjustes();
        }

        private void cbxAgenteAjustes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadAjustes();
        }

        private void grdReporteAnual_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.grdReporteAnual.Rows[e.RowIndex].Cells["concepto"].Value.ToString() == "Comisión")
                e.CellStyle.Format = "";
            else
                e.CellStyle.Format = "c";
        }

        private void cbxAgenteMargenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idAgente = 0;

            if (this.cbxAgenteMargenes.SelectedValue != null)
                int.TryParse(this.cbxAgenteMargenes.SelectedValue.ToString(), out idAgente);

            this.LoadGrdLineas(idAgente);
            this.LoadGrdSublineas(idAgente, -1);
            this.LoadGrdFamilias(idAgente, null);
        }

        private void grdFamilias_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;

            band.Columns["nombre_familia"].Header.Caption = "Familia";
            band.Columns["margen_minimo"].Header.Caption = "Margen Mínimo";

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["margen_minimo"],
                WindowsFormsUtil.TextMaskFormatEnum.Percentage);

            band.Columns["familia"].Hidden = true;
            band.Columns["linea"].Hidden = true;
            band.Columns["sublinea"].Hidden = true;
        }

        private void ComisionesForm_SizeChanged(object sender, EventArgs e)
        {
            this.gbxLineas.Size = new Size(this.Size.Width / 2, (this.Size.Height - 200) / 2);
            this.pnlLineasSublineas.Size = new Size(this.Size.Width / 2, (this.Size.Height - 200) / 2);
        }

        private void grdLineas_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            band.Columns["nombre_linea"].Header.Caption = "Linea";
            band.Columns["margen_promedio"].Header.Caption = "Margen Promedio";
            band.Columns["familias_configuradas"].Header.Caption = "Familias Configuradas";

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["margen_promedio"],
                WindowsFormsUtil.TextMaskFormatEnum.Percentage);

            band.Columns["linea"].Hidden = true;
        }

        private void grdSublineas_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            band.Columns["nombre_sublinea"].Header.Caption = "Sublinea";
            band.Columns["margen_promedio"].Header.Caption = "Margen Promedio";
            band.Columns["familias_configuradas"].Header.Caption = "Familias Configuradas";

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["margen_promedio"],
                WindowsFormsUtil.TextMaskFormatEnum.Percentage);

            band.Columns["sublinea"].Hidden = true;
            band.Columns["linea"].Hidden = true;
        }
        
        private void grdLineas_ClickCell(object sender, ClickCellEventArgs e)
        {
            int linea = -1;
            int idAgente = 0;

            linea = Convert.ToInt32(e.Cell.Row.Cells["linea"].Value);

            if (this.cbxAgenteMargenes.SelectedValue != null)
                int.TryParse(this.cbxAgenteMargenes.SelectedValue.ToString(), out idAgente);

            this.LoadGrdSublineas(idAgente, linea);
            this.LoadGrdFamilias(idAgente, linea);
        }

        private void grdSublineas_ClickCell(object sender, ClickCellEventArgs e)
        {
            Nullable<int> sublinea = null;
            int idAgente = 0;

            sublinea = Convert.ToInt32(e.Cell.Row.Cells["sublinea"].Value);

            if (this.cbxAgenteMargenes.SelectedValue != null)
                int.TryParse(this.cbxAgenteMargenes.SelectedValue.ToString(), out idAgente);

            this.LoadGrdFamilias(idAgente, sublinea);
        }

        private void grdLineas_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            MinimalMarginDialog dialog = new MinimalMarginDialog();

            dialog.ConceptName = e.Row.Cells["nombre_linea"].Value.ToString();
            if (e.Row.Cells["margen_promedio"].Value != DBNull.Value)
                dialog.MinimalMargin = Convert.ToDecimal(e.Row.Cells["margen_promedio"].Value);
            dialog.gbxMinimalMargin.Text = "Linea de Producto:";

            dialog.ShowDialog(this);
            
            if (dialog.Accepted)
            {
                int idAgente = 0;

                if (this.cbxAgenteMargenes.SelectedValue != null)
                    int.TryParse(this.cbxAgenteMargenes.SelectedValue.ToString(), out idAgente);

                consulta = string.Format(@"
                        UPDATE Familias_Agentes SET margen_minimo = {2}
                        WHERE agente = {0} AND familia IN (
                            SELECT fa.familia 
                            FROM ERP_CIE.dbo.Sublineas_Articulos sa 
                            INNER JOIN ERP_CIE.dbo.Familias_Articulos fa ON fa.sublinea = sa.sublinea
                            WHERE linea = {1}
                        )
                    ", idAgente, e.Row.Cells["linea"].Value,
                     dialog.MinimalMargin == null ? "null" : (dialog.MinimalMargin / 100M).ToString());

                cnn.Open();
                SqlCommand command = new SqlCommand(consulta, cnn);
                command.ExecuteNonQuery();
                cnn.Close();

                this.LoadGrdLineas(idAgente);
                this.LoadGrdSublineas(idAgente, Convert.ToInt32(e.Row.Cells["linea"].Value));
                this.LoadGrdFamilias(idAgente, null);
            }
        }

        private void grdSublineas_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            MinimalMarginDialog dialog = new MinimalMarginDialog();

            dialog.ConceptName = e.Row.Cells["nombre_sublinea"].Value.ToString();
            if (e.Row.Cells["margen_promedio"].Value != DBNull.Value)
                dialog.MinimalMargin = Convert.ToDecimal(e.Row.Cells["margen_promedio"].Value);
            dialog.gbxMinimalMargin.Text = "Subinea de Producto:";

            dialog.ShowDialog(this);

            if (dialog.Accepted)
            {
                int idAgente = 0;

                if (this.cbxAgenteMargenes.SelectedValue != null)
                    int.TryParse(this.cbxAgenteMargenes.SelectedValue.ToString(), out idAgente);

                consulta = string.Format(@"
                        UPDATE Familias_Agentes SET margen_minimo = {2}
                        WHERE agente = {0} AND familia IN (
                            SELECT fa.familia 
                            FROM ERP_CIE.dbo.Familias_Articulos fa 
                            WHERE fa.sublinea = {1}
                        )
                    ", idAgente, e.Row.Cells["sublinea"].Value,
                     dialog.MinimalMargin == null ? "null" : (dialog.MinimalMargin / 100M).ToString());

                cnn.Open();
                SqlCommand command = new SqlCommand(consulta, cnn);
                command.Transaction = this.transacction;
                command.ExecuteNonQuery();
                cnn.Close();

                this.LoadGrdLineas(idAgente);
                this.LoadGrdSublineas(idAgente, Convert.ToInt32(e.Row.Cells["linea"].Value));
                this.LoadGrdFamilias(idAgente, Convert.ToInt32(e.Row.Cells["sublinea"].Value));
            }
        }

        private void grdFamilias_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            MinimalMarginDialog dialog = new MinimalMarginDialog();

            dialog.ConceptName = e.Row.Cells["nombre_familia"].Value.ToString();
            if (e.Row.Cells["margen_minimo"].Value != DBNull.Value)
                dialog.MinimalMargin = Convert.ToDecimal(e.Row.Cells["margen_minimo"].Value);
            dialog.gbxMinimalMargin.Text = "Familia de Producto:";

            dialog.ShowDialog(this);

            if (dialog.Accepted)
            {
                int idAgente = 0;

                if (this.cbxAgenteMargenes.SelectedValue != null)
                    int.TryParse(this.cbxAgenteMargenes.SelectedValue.ToString(), out idAgente);

                consulta = string.Format(@"
                        UPDATE Familias_Agentes SET margen_minimo = {2}
                        WHERE agente = {0} AND familia = {1}
                    ", idAgente, e.Row.Cells["familia"].Value,
                     dialog.MinimalMargin == null ? "null" : (dialog.MinimalMargin / 100M).ToString());

                cnn.Open();
                SqlCommand command = new SqlCommand(consulta, cnn);
                command.Transaction = this.transacction;
                command.ExecuteNonQuery();
                cnn.Close();

                this.LoadGrdLineas(idAgente);
                this.LoadGrdSublineas(idAgente, Convert.ToInt32(e.Row.Cells["linea"].Value));
                this.LoadGrdFamilias(idAgente, Convert.ToInt32(e.Row.Cells["sublinea"].Value));
            }
        }
        
        #endregion Events
    }
}
