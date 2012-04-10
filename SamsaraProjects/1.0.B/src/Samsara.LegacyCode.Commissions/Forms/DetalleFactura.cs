
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.Framework.Core.Enums;
using Samsara.Framework.Util;
using Samsara.LegacyCode.Commissions.Main;

namespace Samsara.LegacyCode.Commissions.Forms
{
    public partial class DetalleFactura : Form
    {
        private SqlConnection cnn;
        private DataSet ds;
        private string consulta;
        private SqlDataAdapter da;

        public int IdFactura
        {
            get;
            set;
        }

        public DetalleFactura()
        {
            cnn = new SqlConnection(ConectionStrings.AlleatoConectionString);
            InitializeComponent();
        }

        public void LoadGrids()
        {
            consulta = string.Format(@"
                    SELECT numero_linea, a.nombre_articulo, dfc.cantidad, dfc.precio_pactado, dfc.costo_promedio
                    FROM erp_cie.dbo.detalles_facturas_clientes dfc
                    INNER JOIN erp_cie.dbo.articulos a ON a.articulo = dfc.articulo
                    WHERE factura = {0}
                    ORDER BY numero_linea;
                ", this.IdFactura);

            ds = new DataSet();
            da = new SqlDataAdapter(consulta, cnn);
            da.Fill(ds, "data");

            this.grdLines.DataSource = ds.Tables["data"];

            consulta = string.Format(@"
                    SELECT	movimiento, fecha, importe, tipo_documento
                    FROM	ERP_CIE.dbo.Movimientos_Clientes m
                    INNER JOIN	ERP_CIE.dbo.Tipos_Movimientos_Clientes t ON m.tipo_movimiento = t.tipo_movimiento
                    WHERE   factura = {0} AND es_cargo = 0
                    AND		m.estado_actual <> 'Cancelado'
                    AND		m.fecha         < dateadd(day, 1, getdate())
                ", this.IdFactura);

            ds = new DataSet();
            da = new SqlDataAdapter(consulta, cnn);
            da.Fill(ds, "data");

            this.grdCredits.DataSource = ds.Tables["data"];

            consulta = string.Format(@"
                    SELECT	movimiento, fecha, importe, tipo_documento
                    FROM	ERP_CIE.dbo.Movimientos_Clientes m
                    INNER JOIN	ERP_CIE.dbo.Tipos_Movimientos_Clientes t ON m.tipo_movimiento = t.tipo_movimiento
                    WHERE   factura = {0} AND es_cargo = 1
                    AND		m.estado_actual <> 'Cancelado'
                    AND		m.fecha         < dateadd(day, 1, getdate())
                ", this.IdFactura);

            ds = new DataSet();
            da = new SqlDataAdapter(consulta, cnn);
            da.Fill(ds, "data");

            this.grdCharges.DataSource = ds.Tables["data"];
        }

        private void grdLines_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.Select;
            
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["numero_linea"],
                TextFormatEnum.Integer);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["precio_pactado"],
                TextFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["costo_promedio"],
                TextFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["cantidad"],
                TextFormatEnum.NaturalQuantity);
        }

        private void grdCredits_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.Select;
            
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["movimiento"],
                TextFormatEnum.Integer);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["importe"],
                TextFormatEnum.Currency);
        }

        private void grdCharges_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.Select;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["movimiento"],
                TextFormatEnum.Integer);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["importe"],
                TextFormatEnum.Currency);
        }
    }
}
