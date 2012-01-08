
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SamsaraCommissions
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

        private void LoadGrids()
        {
            consulta = string.Format(@"
                    SELECT numero_linea, a.nombre_articulo, dfc.precio_pactado, dfc.costo_promedio, dfc.cantidad
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

            this.grdCredits.DataSource = ds.Tables["data"];

            consulta = string.Format(@"
                    SELECT	movimiento, fecha, importe, tipo_documento
                    FROM	ERP_CIE.dbo.Movimientos_Clientes m
                    INNER JOIN	ERP_CIE.dbo.Tipos_Movimientos_Clientes t ON m.tipo_movimiento = t.tipo_movimiento
                    WHERE   factura = {0} AND es_cargo = 1
                    AND		m.estado_actual <> 'Cancelado'
                    AND		m.fecha         < dateadd(day, 1, getdate())
                ", this.IdFactura);

            this.grdCharges.DataSource = ds.Tables["data"];
        }
    }
}
