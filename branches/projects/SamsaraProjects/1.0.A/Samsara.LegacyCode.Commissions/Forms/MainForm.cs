
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.LegacyCode.Commissions.Main;
using Samsara.LegacyCode.Commissions.Util;
using Samsara.Support.Util;
using Samsara.Main.Session;

namespace Samsara.LegacyCode.Commissions.Forms
{
    public partial class MainForm : Form
    {
        #region Attributes

        private static bool isConfigurable =
            Session.User.UserId == 2 //Najera
            || Session.User.UserId == 11 //Gaby
            || Session.User.UserId == 13; //Ana

        private static bool canPay =
            Session.User.UserId == 2 //Najera
            || Session.User.UserId == 13; //Ana

        private static bool canChangeMargins =
            Session.User.UserId == 2 //Najera
            || Session.User.UserId == 11; //Gaby;

        private SqlConnection cnn;
        private DataSet ds;
        private string consulta;
        private SqlDataAdapter da;
        private Dictionary<string, int> dicMeses = new Dictionary<string, int>();
        private SqlTransaction transacction = null;

        private DataTable dtDetalleComisiones;
        private DataTable dtResumenComisionesProductos;
        private DataTable dtResumenComisionesServicios;
        private DataTable dtFacturasPendientes;
        private DataTable dtFacturasCanceladas;
        private DataTable dtRefacturaciónAgena;

        #endregion Attributes

        #region Constructor

        public MainForm()
        {
            cnn = new SqlConnection(ConectionStrings.AlleatoConectionString);
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

                this.Text += "  -  " + WindowsIdentity.GetCurrent().Name;
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

            this.cbxAgenteComission.DataSource = null;
            this.cbxAgenteComission.DataSource = ds.Tables["agentes"].Copy();
            this.cbxAgenteComission.ValueMember = "agente";
            this.cbxAgenteComission.DisplayMember = "nombre_agente";
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

        private void LoadGrdLineas()
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
                    INNER JOIN Familias_Margenes_Minimos fag ON fag.familia = fa.familia
                    GROUP BY la.linea, la.nombre_linea
                    ORDER BY nombre_linea
                ");
            da = new SqlDataAdapter(consulta, cnn);
            ds = new DataSet();
            da.Fill(ds, "lineas");
            this.grdLineas.DataSource = ds.Tables["lineas"];

            if (closed)
            {
                cnn.Close();
            }
        }

        private void LoadGrdSublineas(int linea)
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
                    INNER JOIN Familias_Margenes_Minimos fag ON fag.familia = fa.familia
                    WHERE sa.linea = {0}
                    GROUP BY la.linea, sa.sublinea, sa.nombre_sublinea
                    ORDER BY nombre_sublinea
                ", linea);

            da = new SqlDataAdapter(consulta, cnn);
            ds = new DataSet();
            da.Fill(ds, "sublineas");
            this.grdSublineas.DataSource = ds.Tables["sublineas"];

            if (closed)
            {
                cnn.Close();
            }
        }

        private void LoadGrdFamilias(Nullable<int> sublinea)
        {
            bool closed = cnn.State == ConnectionState.Closed;

            if (closed)
            {
                cnn.Open();
            }

            consulta = string.Format(@"
                    INSERT INTO Familias_Margenes_Minimos (familia)
                    SELECT familia
                    FROM	ERP_CIE.dbo.Familias_Articulos fa
                    WHERE familia NOT IN (
					    SELECT familia FROM Familias_Margenes_Minimos
                    )
                ");

            SqlCommand command = new SqlCommand(consulta, cnn);
            command.ExecuteNonQuery();

            if (sublinea != null)
            {
                consulta = string.Format(@"
					    SELECT la.linea, sa.sublinea, fa.familia, RTRIM(far.nombre_familia) nombre_familia, 
                        fa.margen_minimo * 100.0 margen_minimo
                        FROM Familias_Margenes_Minimos fa
                        INNER JOIN ERP_CIE.dbo.Familias_Articulos far ON far.familia = fa.familia
                        INNER JOIN ERP_CIE.dbo.Sublineas_Articulos sa ON sa.sublinea = far.sublinea
                        INNER JOIN ERP_CIE.dbo.Lineas_Articulos la ON la.linea = sa.linea
					    WHERE sa.sublinea = {0}
                        ORDER BY nombre_familia
                    ", sublinea);
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
            DataRow lastRow = null;

            this.dtResumenComisionesProductos.Rows.Clear();
            this.dtResumenComisionesServicios.Rows.Clear();

            foreach (var group in this.dtDetalleComisiones.AsEnumerable().GroupBy(x =>
                new
                {
                    año = x["anio"],
                    mes = x["mes"],
                    q = x["Q"],
                    esServicio = x["es_servicio"].ToString() == "Si"
                }))
            {
                decimal acumulado = decimal.Zero;
                decimal sumatoria_cuotas = decimal.Zero;

                foreach (DataRow row in group)
                {
                    decimal cuota = Convert.ToDecimal(row["cuota"]);
                    sumatoria_cuotas += cuota;
                    acumulado += Convert.ToDecimal(row["utilidad_comisionable"]);
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

                DataRow rowResumen;

                if (!group.Key.esServicio)
                {
                    rowResumen = this.dtResumenComisionesProductos.NewRow();
                    this.dtResumenComisionesProductos.Rows.Add(rowResumen);
                }
                else
                {
                    rowResumen = this.dtResumenComisionesServicios.NewRow();
                    this.dtResumenComisionesServicios.Rows.Add(rowResumen);
                }

                rowResumen["anio"] = lastRow["anio"];
                rowResumen["mes"] = this.dicMeses.ElementAt(Convert.ToInt32(lastRow["mes"]) - 1).Key;
                rowResumen["Q"] = lastRow["Q"];
                rowResumen["saldo_a_pagar"] = "0.00";
                rowResumen["total_pagado"] = "0.00";
                rowResumen["fecha_ultimo_ajuste"] = "Nunca";
                rowResumen["porcentaje_comision_servicios"] = 0M;
                rowResumen["porcentaje_comision_productos"] = 0M;
                rowResumen["cuota_de_servicios"] = 0M;
                rowResumen["cuota_de_productos"] = 0M;
                rowResumen["utilidad_general"] = 0M;
                rowResumen["utilidad_Q"] = 0M;
                rowResumen["monto_comision"] = 0M;
                rowResumen["acumulado_comision"] = 0M;

                if (lastRow != null)
                {
                    rowResumen["utilidad_general"] =
                        Convert.ToDecimal(rowResumen["utilidad_general"]) + Math.Round(this.dtFacturasPendientes
                        .AsEnumerable().Where(x => this.dicMeses[x["mes"].ToString()] == Convert.ToInt32(group.Key.mes)
                            && Convert.ToInt32(x["anio"]) == Convert.ToInt32(group.Key.año)
                            && x["Q"].ToString().Trim() == group.Key.q.ToString().Trim())
                            .Sum(x => Convert.ToDecimal(x["utilidad"])) + acumulado, 2);
                    rowResumen["utilidad_Q"] =
                        Convert.ToDecimal(rowResumen["utilidad_Q"]) + Math.Round(acumulado, 2);
                    rowResumen["acumulado_comision"]
                        = Convert.ToDecimal(rowResumen["acumulado_comision"])
                        + Math.Round(Convert.ToDecimal(lastRow["acumulado_comision"]), 2);

                    if (group.Key.esServicio)
                    {
                        rowResumen["porcentaje_comision_servicios"]
                            = Convert.ToDecimal(lastRow["acumulado_comision_agente"]) == decimal.Zero ?
                            decimal.Zero.ToString("N2") : Math.Round(Convert.ToDecimal(lastRow["acumulado_comision_agente"])
                            / Convert.ToDecimal(lastRow["acumulado_comision"]), 2).ToString("N2");
                        rowResumen["cuota_de_servicios"] = Math.Round(sumatoria_cuotas / group.Count(), 2);
                    }
                    else
                    {
                        rowResumen["porcentaje_comision_productos"]
                            = Convert.ToDecimal(lastRow["acumulado_comision_agente"]) == decimal.Zero ?
                            decimal.Zero.ToString("N2") : Math.Round(Convert.ToDecimal(lastRow["acumulado_comision_agente"])
                            / Convert.ToDecimal(lastRow["acumulado_comision"]), 2).ToString("N2");
                        rowResumen["cuota_de_productos"] = Math.Round(sumatoria_cuotas / group.Count(), 2);
                    }
                    rowResumen["monto_comision"] = Convert.ToDecimal(rowResumen["monto_comision"])
                        + Math.Round(Convert.ToDecimal(lastRow["acumulado_comision_agente"]), 2);
                }
            }

            consulta = string.Format(@"
                    SELECT * FROM comisiones_pagadas cp 
                    WHERE agente = {0} AND id = ( 
                        SELECT MAX(cp1.id) FROM comisiones_pagadas cp1
                        INNER JOIN ajustes a ON a.id = cp1.ajuste
                        WHERE cp1.agente = cp.agente AND a.borrado = 0
                        AND mes = cp.mes AND anio = cp.anio AND q = cp.q AND cp1.tipo = {1})
                ", this.cbxAgentes.SelectedValue, (int)CommissionsTypes.Products);

            da = new SqlDataAdapter(consulta, cnn);
            ds = new DataSet();
            da.Fill(ds, "ajustes");

            foreach (DataRow resumenRow in this.dtResumenComisionesProductos.Rows)
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

            consulta = string.Format(@"
                    SELECT * FROM comisiones_pagadas cp 
                    WHERE agente = {0} AND id = ( 
                        SELECT MAX(cp1.id) FROM comisiones_pagadas cp1
                        INNER JOIN ajustes a ON a.id = cp1.ajuste
                        WHERE cp1.agente = cp.agente AND a.borrado = 0
                        AND mes = cp.mes AND anio = cp.anio AND q = cp.q AND cp1.tipo = {1})
                ", this.cbxAgentes.SelectedValue, (int)CommissionsTypes.Services);

            da = new SqlDataAdapter(consulta, cnn);
            ds = new DataSet();
            da.Fill(ds, "ajustes");

            foreach (DataRow resumenRow in this.dtResumenComisionesServicios.Rows)
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

            this.ActualizaTotalComisionesProductos(null, 0M);
            this.ActualizaTotalComisionesServicios(null, 0M);
            this.lblAgente.Text = this.cbxAgentes.SelectedValue.ToString();

            var años = this.dtResumenComisionesProductos.AsEnumerable()
                .Select(x => x["anio"]).Union(this.dtResumenComisionesServicios.AsEnumerable()
                .Select(x => x["anio"])).Select(x => new
            {
                año = Convert.ToInt32(x)
            }).Distinct().ToList();

            this.cbxAños.DataSource = null;
            this.cbxAños.DataSource = años;
            this.cbxAños.ValueMember = "año";
            this.cbxAños.DisplayMember = "año";
            this.cbxAños.SelectedValue = años.Max(x => x.año);
            this.cbxAños_SelectedIndexChanged(null, null);
        }

        private void CreaReporteAnual()
        {
            consulta = "SELECT '' as Concepto, 0.00 " + string.Join(", 0.00 ", this.dicMeses
                .ToDictionary(x => x.Key + "_Q1", x => x.Value).Concat(this.dicMeses
                .ToDictionary(x => x.Key + "_Q2", x => x.Value))
                .OrderBy(x => x.Value).Select(x => x.Key).ToArray());

            da = new SqlDataAdapter(consulta, cnn);
            ds = new DataSet();
            da.Fill(ds, "meses");

            ds.Tables["meses"].Rows.Remove(ds.Tables["meses"].Rows[0]);
            ds.Tables["meses"].AcceptChanges();

            this.grdReporteAnualProductos.DataSource = null;
            this.grdReporteAnualProductos.DataSource = ds.Tables["meses"];

            this.grdReporteAnualServicios.DataSource = null;
            this.grdReporteAnualServicios.DataSource = ds.Tables["meses"].Clone();
        }

        private bool ActualizaTotalComisionesProductos(UltraGridRow row, decimal newCellValue)
        {
            IList<UltraGridRow> list = new List<UltraGridRow>();
            list.Add(row);

            decimal oldValue = GeneralUtil.DecimalValue(this.txtTotalComisionesProductos.Text);

            decimal newValue = this.grdResumenComisionesProductos.Rows.Cast<UltraGridRow>().Except(list)
                .AsEnumerable().Sum(x => GeneralUtil.DecimalValue(x.Cells["saldo_a_pagar"].Value))
                + (row == null ? 0 : newCellValue);

            decimal difference = Math.Abs(oldValue - newValue);

            if (row != null && oldValue != newValue &&
                MessageBox.Show(string.Format("Cambió de total a pagar, la diferencia {0} es por {1}. ¿Desea continuar?",
                    oldValue < newValue ? "a Favor" : "en Contra", difference.ToString("N2")),
                    "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return false;

            this.txtTotalComisionesProductos.Text = newValue.ToString("N2");

            return true;
        }

        private bool ActualizaTotalComisionesServicios(UltraGridRow row, decimal newCellValue)
        {
            IList<UltraGridRow> list = new List<UltraGridRow>();
            list.Add(row);

            decimal oldValue = GeneralUtil.DecimalValue(this.txtTotalComisionesServicios.Text);

            decimal newValue = this.grdResumenComisionesServicios.Rows.Cast<UltraGridRow>().Except(list)
                .AsEnumerable().Sum(x => GeneralUtil.DecimalValue(x.Cells["saldo_a_pagar"].Value))
                + (row == null ? 0 : newCellValue);

            decimal difference = Math.Abs(oldValue - newValue);

            if (row != null && oldValue != newValue &&
                MessageBox.Show(string.Format("Cambió de total a pagar, la diferencia {0} es por {1}. ¿Desea continuar?",
                    oldValue < newValue ? "a Favor" : "en Contra", difference.ToString("N2")),
                    "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return false;

            this.txtTotalComisionesServicios.Text = newValue.ToString("N2");

            return true;
        }

        private void UpdateGrdEsquemasMulticuota()
        {
            int idAgente;

            if (this.cbxAgenteComission.SelectedValue != null
                && int.TryParse(this.cbxAgenteComission.SelectedValue.ToString(), out idAgente))
            {
                this.multicuotasControl.AgentId = idAgente;
                this.multicuotasControl.LoadGrids();
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

            foreach (DataRow row in ((DataTable)this.grdResumenComisionesProductos.DataSource).AsEnumerable()
                .Where(x => !(x["saldo_a_pagar"] is DBNull)))
            {
                consulta = string.Format(@"
                    INSERT INTO comisiones_pagadas (anio,mes,q,utilidad,monto_comisionable,
                        comision,monto_comision,fecha_ajuste,agente,ajuste, tipo) 
                    VALUES({0}, {1}, '{2}', {3}, {4}, {5}, {6}, GETDATE(), {7}, {8}, {9})
                    ", row["anio"], this.dicMeses[row["mes"].ToString()], row["q"].ToString().Trim(),
                     row["utilidad_q"], row["acumulado_comision"], row["porcentaje_comision_productos"],
                     row["monto_comision"], this.lblAgente.Text, idAjuste, (int)CommissionsTypes.Products);

                command = new SqlCommand(consulta, cnn);
                command.Transaction = this.transacction;
                command.ExecuteNonQuery();
            }

            foreach (DataRow row in ((DataTable)this.grdResumenComisionesServicios.DataSource).AsEnumerable()
                .Where(x => !(x["saldo_a_pagar"] is DBNull)))
            {
                consulta = string.Format(@"
                    INSERT INTO comisiones_pagadas (anio,mes,q,utilidad,monto_comisionable,
                        comision,monto_comision,fecha_ajuste,agente,ajuste, tipo) 
                    VALUES({0}, {1}, '{2}', {3}, {4}, {5}, {6}, GETDATE(), {7}, {8}, {9})
                    ", row["anio"], this.dicMeses[row["mes"].ToString()], row["q"].ToString().Trim(),
                     row["utilidad_q"], row["acumulado_comision"], row["porcentaje_comision_servicios"],
                     row["monto_comision"], this.lblAgente.Text, idAjuste, (int)CommissionsTypes.Services);

                command = new SqlCommand(consulta, cnn);
                command.Transaction = this.transacction;
                command.ExecuteNonQuery();
            }

            foreach (DataRow row in this.dtDetalleComisiones.Rows)
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

        private void ProcesaFacturasPendientes()
        {
            foreach (var group in this.dtFacturasPendientes.AsEnumerable().GroupBy(x =>
                new { año = x["anio"], mes = x["mes"], q = x["Q"] }))
            {
                decimal acumulado = decimal.Zero;

                foreach (DataRow row in group)
                {
                    acumulado += Convert.ToDecimal(row["utilidad"]);
                    row["total_acumulado"] = acumulado;
                }
            }

            foreach (DataRow row in this.dtFacturasPendientes.AsEnumerable())
            {
                row["mes"] = this.dicMeses.ElementAt(Convert.ToInt32(row["mes"]) - 1).Key;
            }
        }

        private void ProcesaFacturasCanceladas()
        {
            foreach (DataRow row in dtFacturasCanceladas.AsEnumerable())
            {
                row["mes"] = this.dicMeses.ElementAt(Convert.ToInt32(row["mes"]) - 1).Key;
            }
        }

        private void ProcesaFacturasRefacturaciónAgena()
        {
            foreach (DataRow row in this.dtRefacturaciónAgena.AsEnumerable())
            {
                row["mes"] = this.dicMeses.ElementAt(Convert.ToInt32(row["mes"]) - 1).Key;
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

                List<string> lstAgents = this.lbAgentesEquivalentes.Items.Cast<DataRowView>()
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

                this.dtDetalleComisiones = data.Tables[0];
                this.dtResumenComisionesProductos = data.Tables[1];
                this.dtFacturasPendientes = data.Tables[2];
                this.dtFacturasCanceladas = data.Tables[3];
                this.dtRefacturaciónAgena = data.Tables[4];

                this.grdResumenComisionesProductos.DataSource = this.dtResumenComisionesProductos;
                this.grdResumenComisionesServicios.DataSource = this.dtResumenComisionesServicios = this.dtResumenComisionesProductos.Clone();

                this.CreaReporteAnual();
                this.ProcesaFacturasPendientes();
                this.CalculaComisionesQ();
                this.ProcesaFacturasCanceladas();
                this.ProcesaFacturasRefacturaciónAgena();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el reporte, consulte al administrador del sistema.\n"
                    + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool puedeComissionar = Convert.ToBoolean(
                    this.grdAgentesActivos.Rows[e.RowIndex].Cells["puede_comisionar"].Value);

                cnn.Open();

                consulta = "UPDATE agentes_activos SET puede_comisionar = " + (puedeComissionar ? 0 : 1)
                    + " WHERE agente = "
                    + this.grdAgentesActivos.Rows[e.RowIndex].Cells["agente"].Value;
                SqlCommand command = new SqlCommand(consulta, cnn);
                command.ExecuteNonQuery();

                this.LoadGridAgentesActivos();
                this.LoadCombosAgentes(true);
                cnn.Close();
            }
        }

        private void dudAños_SelectedItemChanged(object sender, EventArgs e)
        {
            this.UpdateGrdEsquemasMulticuota();
        }

        private void cbxAgenteComission_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateGrdEsquemasMulticuota();
            this.dudAños.SelectedItem = DateTime.Now.Year;
        }

        private void cbxAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            int año = 0;

            if (this.cbxAños.SelectedValue != null
                && int.TryParse(this.cbxAños.SelectedValue.ToString(), out año))
            {
                DataTable dtReporteAnualProductos = (DataTable)this.grdReporteAnualProductos.DataSource;

                if (dtReporteAnualProductos != null)
                {
                    dtReporteAnualProductos.Rows.Clear();
                    DataRow rowComision = dtReporteAnualProductos.NewRow();
                    DataRow rowMontoComisionable = dtReporteAnualProductos.NewRow();
                    DataRow rowUtilidadPagada = dtReporteAnualProductos.NewRow();
                    DataRow rowUtilidadGeneral = dtReporteAnualProductos.NewRow();
                    DataRow rowCuotaProductos = dtReporteAnualProductos.NewRow();
                    DataRow rowPorcentajeProductos = dtReporteAnualProductos.NewRow();
                    DataRow rowTotalAPagar = dtReporteAnualProductos.NewRow();
                    DataRow rowTotalPagado = dtReporteAnualProductos.NewRow();

                    dtReporteAnualProductos.Rows.Add(rowUtilidadGeneral);
                    dtReporteAnualProductos.Rows.Add(rowUtilidadPagada);
                    dtReporteAnualProductos.Rows.Add(rowCuotaProductos);
                    dtReporteAnualProductos.Rows.Add(rowMontoComisionable);
                    dtReporteAnualProductos.Rows.Add(rowPorcentajeProductos);
                    dtReporteAnualProductos.Rows.Add(rowComision);
                    dtReporteAnualProductos.Rows.Add(rowTotalPagado);
                    dtReporteAnualProductos.Rows.Add(rowTotalAPagar);

                    foreach (DataRow row in this.dtResumenComisionesProductos.AsEnumerable()
                        .Where(x => Convert.ToInt32(x["anio"]) == año))
                    {
                        int mes = this.dicMeses[row["mes"].ToString()];
                        int index = mes * 2 + (row["Q"].ToString().Trim() == "Q1" ? -1 : 0);

                        rowUtilidadGeneral[index] = row["utilidad_general"];
                        rowUtilidadPagada[index] = row["utilidad_Q"];
                        rowCuotaProductos[index] = row["cuota_de_productos"];
                        rowMontoComisionable[index] = row["acumulado_comision"];
                        rowPorcentajeProductos[index] = row["porcentaje_comision_productos"];
                        rowComision[index] = row["monto_comision"];
                        rowTotalAPagar[index] = Convert.ToDecimal(row["saldo_a_pagar"]).ToString("N2");
                        rowTotalPagado[index] = Convert.ToDecimal(row["total_pagado"]).ToString("N2");
                    }

                    rowUtilidadGeneral["concepto"] = "Utilidad General";
                    rowUtilidadPagada["concepto"] = "Utilidad Pagada";
                    rowCuotaProductos["concepto"] = "Cuota Productos";
                    rowMontoComisionable["concepto"] = "Utilidad Comisionable";
                    rowPorcentajeProductos["concepto"] = "Comisión Productos";
                    rowComision["concepto"] = "Monto Comisión";
                    rowTotalPagado["concepto"] = "Total Pagado";
                    rowTotalAPagar["concepto"] = "Total a Pagar";

                    dtReporteAnualProductos.AcceptChanges();
                }
            }

            DataTable dtReporteAnualServicios = (DataTable)this.grdReporteAnualServicios.DataSource;

            if (dtReporteAnualServicios != null)
            {
                dtReporteAnualServicios.Rows.Clear();
                DataRow rowComision = dtReporteAnualServicios.NewRow();
                DataRow rowMontoComisionable = dtReporteAnualServicios.NewRow();
                DataRow rowUtilidadPagada = dtReporteAnualServicios.NewRow();
                DataRow rowUtilidadGeneral = dtReporteAnualServicios.NewRow();
                DataRow rowCuotaServicios = dtReporteAnualServicios.NewRow();
                DataRow rowPorcentajeServicios = dtReporteAnualServicios.NewRow();
                DataRow rowTotalAPagar = dtReporteAnualServicios.NewRow();
                DataRow rowTotalPagado = dtReporteAnualServicios.NewRow();

                dtReporteAnualServicios.Rows.Add(rowUtilidadGeneral);
                dtReporteAnualServicios.Rows.Add(rowUtilidadPagada);
                dtReporteAnualServicios.Rows.Add(rowCuotaServicios);
                dtReporteAnualServicios.Rows.Add(rowMontoComisionable);
                dtReporteAnualServicios.Rows.Add(rowPorcentajeServicios);
                dtReporteAnualServicios.Rows.Add(rowComision);
                dtReporteAnualServicios.Rows.Add(rowTotalPagado);
                dtReporteAnualServicios.Rows.Add(rowTotalAPagar);

                foreach (DataRow row in this.dtResumenComisionesServicios.AsEnumerable()
                    .Where(x => Convert.ToInt32(x["anio"]) == año))
                {
                    int mes = this.dicMeses[row["mes"].ToString()];
                    int index = mes * 2 + (row["Q"].ToString().Trim() == "Q1" ? -1 : 0);

                    rowUtilidadGeneral[index] = row["utilidad_general"];
                    rowUtilidadPagada[index] = row["utilidad_Q"];
                    rowCuotaServicios[index] = row["cuota_de_servicios"];
                    rowMontoComisionable[index] = row["acumulado_comision"];
                    rowPorcentajeServicios[index] = row["porcentaje_comision_servicios"];
                    rowComision[index] = row["monto_comision"];
                    rowTotalAPagar[index] = Convert.ToDecimal(row["saldo_a_pagar"]).ToString("N2");
                    rowTotalPagado[index] = Convert.ToDecimal(row["total_pagado"]).ToString("N2");
                }

                rowUtilidadGeneral["concepto"] = "Utilidad General";
                rowUtilidadPagada["concepto"] = "Utilidad Pagada";
                rowCuotaServicios["concepto"] = "Cuota Servicios";
                rowMontoComisionable["concepto"] = "Utilidad Comisionable";
                rowPorcentajeServicios["concepto"] = "Comisión Servicios";
                rowComision["concepto"] = "Monto Comisión";
                rowTotalPagado["concepto"] = "Total Pagado";
                rowTotalAPagar["concepto"] = "Total a Pagar";

                dtReporteAnualServicios.AcceptChanges();
            }
        }

        private void grdReporteAnual_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            foreach (UltraGridColumn column in band.Columns)
            {
                if (column.Header.Caption != "Comisión" && column.Header.Caption != "Concepto")
                {
                    WindowsFormsUtil.SetUltraColumnFormat(column, TextMaskFormatEnum.Currency);
                }
            }
        }
        
        private void grdReporteAnual_DoubleClickHeader(object sender, DoubleClickHeaderEventArgs e)
        {
            UltraGrid grid = sender as UltraGrid;

            DetalleQuincena form = new DetalleQuincena();
            form.SonServicios = grid.Name == "grdReporteAnualServicios";
            form.Año = (int)this.cbxAños.SelectedValue;
            form.Mes = (e.Header.VisiblePosition - 1) / 2 + 1;
            form.Q = ((e.Header.VisiblePosition - 1) % 2) == 0 ? "Q1" : "Q2";
            form.Title = "Detalle " + this.dicMeses.ElementAt(form.Mes - 1).Key + " " + form.Q;
            form.DtDetalleComisiones = this.dtDetalleComisiones;
            form.DtFacturasPendientes = this.dtFacturasPendientes;
            form.DtFacturasCanceladas = this.dtFacturasCanceladas;
            form.LoadData();
            form.ShowDialog(this);
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
                this.pnlAdmin.Enabled = false;
                this.LoadAjustes();
            }
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            this.CalculaComisionesQ();
        }

        private void lblAgente_TextChanged(object sender, EventArgs e)
        {
            this.pnlAdmin.Enabled = this.lblAgente.Text.Length > 0 && canPay;
        }

        private void btnEliminarAjuste_Click(object sender, EventArgs e)
        {
            string[] ajusteIds = this.grdAjustes.Selected.Rows.Cast<UltraGridRow>()
                .Select(x => x.Cells["ajuste"].Value.ToString()).ToArray();

            string pregunta = ajusteIds.Count() > 1 ? "¿Esta seguro de borrar los ajustes "
                : "¿Esta seguro de borrar el ajuste ";

            if (ajusteIds.Count() <= 0)
                return;

            if (MessageBox.Show( pregunta + string.Join(", ", ajusteIds.ToArray()) 
                + "?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            consulta = "update ajustes set borrado = 1, "
                + "fecha_borrado = getdate() where id in ("
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

        private void cbxAgenteMargenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadGrdLineas();
            this.LoadGrdSublineas(-1);
            this.LoadGrdFamilias(null);
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
                TextMaskFormatEnum.Percentage);

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
                TextMaskFormatEnum.Percentage);

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
                TextMaskFormatEnum.Percentage);

            band.Columns["sublinea"].Hidden = true;
            band.Columns["linea"].Hidden = true;
        }

        private void grdLineas_ClickCell(object sender, ClickCellEventArgs e)
        {
            int linea = -1;

            linea = Convert.ToInt32(e.Cell.Row.Cells["linea"].Value);

            this.LoadGrdSublineas(linea);
            this.LoadGrdFamilias(linea);
        }

        private void grdSublineas_ClickCell(object sender, ClickCellEventArgs e)
        {
            Nullable<int> sublinea = null;

            sublinea = Convert.ToInt32(e.Cell.Row.Cells["sublinea"].Value);

            this.LoadGrdFamilias(sublinea);
        }

        private void grdLineas_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (canChangeMargins)
            {
                MinimalMarginDialog dialog = new MinimalMarginDialog();

                dialog.ConceptName = e.Row.Cells["nombre_linea"].Value.ToString();
                if (e.Row.Cells["margen_promedio"].Value != DBNull.Value)
                    dialog.MinimalMargin = Convert.ToDecimal(e.Row.Cells["margen_promedio"].Value);
                dialog.gbxMinimalMargin.Text = "Linea de Producto:";

                dialog.ShowDialog(this);

                if (dialog.Accepted)
                {
                    consulta = string.Format(@"
                        UPDATE Familias_Margenes_Minimos SET margen_minimo = {1}
                        WHERE familia IN (
                            SELECT fa.familia 
                            FROM ERP_CIE.dbo.Sublineas_Articulos sa 
                            INNER JOIN ERP_CIE.dbo.Familias_Articulos fa ON fa.sublinea = sa.sublinea
                            WHERE linea = {0}
                        )
                    ", e.Row.Cells["linea"].Value,
                         dialog.MinimalMargin == null ? "null" : (dialog.MinimalMargin / 100M).ToString());

                    cnn.Open();
                    SqlCommand command = new SqlCommand(consulta, cnn);
                    command.ExecuteNonQuery();
                    cnn.Close();

                    this.LoadGrdLineas();
                    this.LoadGrdSublineas(Convert.ToInt32(e.Row.Cells["linea"].Value));
                    this.LoadGrdFamilias(null);
                }
            }
        }

        private void grdSublineas_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (canChangeMargins)
            {
                MinimalMarginDialog dialog = new MinimalMarginDialog();

                dialog.ConceptName = e.Row.Cells["nombre_sublinea"].Value.ToString();
                if (e.Row.Cells["margen_promedio"].Value != DBNull.Value)
                    dialog.MinimalMargin = Convert.ToDecimal(e.Row.Cells["margen_promedio"].Value);
                dialog.gbxMinimalMargin.Text = "Subinea de Producto:";

                dialog.ShowDialog(this);

                if (dialog.Accepted)
                {
                    consulta = string.Format(@"
                        UPDATE Familias_Margenes_Minimos SET margen_minimo = {1}
                        WHERE familia IN (
                            SELECT fa.familia 
                            FROM ERP_CIE.dbo.Familias_Articulos fa 
                            WHERE fa.sublinea = {0}
                        )
                    ", e.Row.Cells["sublinea"].Value,
                         dialog.MinimalMargin == null ? "null" : (dialog.MinimalMargin / 100M).ToString());

                    cnn.Open();
                    SqlCommand command = new SqlCommand(consulta, cnn);
                    command.Transaction = this.transacction;
                    command.ExecuteNonQuery();
                    cnn.Close();

                    this.LoadGrdLineas();
                    this.LoadGrdSublineas(Convert.ToInt32(e.Row.Cells["linea"].Value));
                    this.LoadGrdFamilias(Convert.ToInt32(e.Row.Cells["sublinea"].Value));
                }
            }
        }

        private void grdFamilias_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (canChangeMargins)
            {
                MinimalMarginDialog dialog = new MinimalMarginDialog();

                dialog.ConceptName = e.Row.Cells["nombre_familia"].Value.ToString();
                if (e.Row.Cells["margen_minimo"].Value != DBNull.Value)
                    dialog.MinimalMargin = Convert.ToDecimal(e.Row.Cells["margen_minimo"].Value);
                dialog.gbxMinimalMargin.Text = "Familia de Producto:";

                dialog.ShowDialog(this);

                if (dialog.Accepted)
                {
                    consulta = string.Format(@"
                        UPDATE Familias_Margenes_Minimos SET margen_minimo = {1}
                        WHERE familia = {0}
                    ", e.Row.Cells["familia"].Value,
                         dialog.MinimalMargin == null ? "null" : (dialog.MinimalMargin / 100M).ToString());

                    cnn.Open();
                    SqlCommand command = new SqlCommand(consulta, cnn);
                    command.Transaction = this.transacction;
                    command.ExecuteNonQuery();
                    cnn.Close();

                    this.LoadGrdLineas();
                    this.LoadGrdSublineas(Convert.ToInt32(e.Row.Cells["linea"].Value));
                    this.LoadGrdFamilias(Convert.ToInt32(e.Row.Cells["sublinea"].Value));
                }
            }
        }
        
        private void grdResumenComisiones_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            Parallel.ForEach(band.Columns.Cast<UltraGridColumn>(), column =>
            {
                column.CellActivation = Activation.ActivateOnly;
            });

            band.Columns["saldo_a_pagar"].CellActivation = Activation.AllowEdit;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["utilidad_general"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["utilidad_Q"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["acumulado_comision"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["cuota_de_servicios"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["cuota_de_productos"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["porcentaje_comision_servicios"],
                TextMaskFormatEnum.Percentage);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["porcentaje_comision_productos"],
                TextMaskFormatEnum.Percentage);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["monto_comision"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["saldo_a_pagar"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["total_pagado"],
                TextMaskFormatEnum.Currency);
        }

        private void grdResumenComisiones_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            UltraGrid grid = sender as UltraGrid;

            if (e.Cell.Column.Key == "saldo_a_pagar")
            {
                if (e.NewValue == DBNull.Value)
                    e.Cancel = true;

                if (grid.Name == "grdResumenComisionesProductos")
                {
                    if (!e.Cancel)
                        e.Cancel = !this.ActualizaTotalComisionesProductos(e.Cell.Row, Convert.ToDecimal(e.NewValue));
                }
                else
                {
                    if (!e.Cancel)
                        e.Cancel = !this.ActualizaTotalComisionesServicios(e.Cell.Row, Convert.ToDecimal(e.NewValue));
                }
            }
        }

        private void grdResumenComisiones_AfterCellUpdate(object sender, CellEventArgs e)
        {
            UltraGridRow activeRow = null;

            if (sender.Equals(this.grdResumenComisionesProductos))
                activeRow = this.grdResumenComisionesProductos.ActiveRow;
            else
                activeRow = this.grdResumenComisionesServicios.ActiveRow;

            if (activeRow != null)
                activeRow.Cells["monto_comision"].Value
                    = Convert.ToDecimal(activeRow.Cells["total_pagado"].Value)
                    + Convert.ToDecimal(activeRow.Cells["saldo_a_pagar"].Value);
        }

        private void grdAjustes_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            layout.Override.AllowUpdate = DefaultableBoolean.False;

            band.Columns["ajuste"].Header.Caption = "Pago";
            band.Columns["agente"].Hidden = true;
            band.Columns["nombre_agente"].Hidden = true;
            band.Columns["fecha_ajuste"].Header.Caption = "Fecha de Pago";
        }

        private void txtTotalComisionesProductos_TextChanged(object sender, EventArgs e)
        {
            this.txtTotalComisiones.Text = (GeneralUtil.DecimalValue(this.txtTotalComisionesProductos.Text)
                + GeneralUtil.DecimalValue(this.txtTotalComisionesServicios.Text)).ToString("N2");
        }

        private void txtTotalComisionesServicios_TextChanged(object sender, EventArgs e)
        {
            this.txtTotalComisiones.Text = (GeneralUtil.DecimalValue(this.txtTotalComisionesProductos.Text)
                + GeneralUtil.DecimalValue(this.txtTotalComisionesServicios.Text)).ToString("N2");
        }

        #endregion Events
    }
}
