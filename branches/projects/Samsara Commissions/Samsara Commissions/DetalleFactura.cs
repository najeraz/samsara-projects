
using System.Windows.Forms;
using System.Data;

namespace SamsaraCommissions
{
    public partial class DetalleFactura : Form
    {
        public DataTable DtInvoiceLines
        {
            get;
            set;
        }

        public DataTable DtInvoiceCharges
        {
            get;
            set;
        }

        public DataTable DtInvoiceCredits
        {
            get;
            set;
        }

        public DetalleFactura()
        {
            InitializeComponent();
        }

        private void LoadGrids()
        {
            this.grdLines.DataSource = this.DtInvoiceLines;
            this.grdCredits.DataSource = this.DtInvoiceCredits;
            this.grdCharges.DataSource = this.DtInvoiceCharges;


            string consulta = @"
                    SELECT numero_linea, a.nombre_articulo, dfc.precio_pactado, dfc.costo_promedio, dfc.cantidad
                    FROM erp_cie.dbo.detalles_facturas_clientes dfc
                    INNER JOIN erp_cie.dbo.articulos a ON a.articulo = dfc.articulo
                    WHERE factura = {0}
                    ORDER BY numero_linea;
		
		
		
                    SELECT	movimiento, fecha, importe, tipo_documento
                    FROM	ERP_CIE.dbo.Movimientos_Clientes m
                    INNER JOIN	ERP_CIE.dbo.Tipos_Movimientos_Clientes t ON m.tipo_movimiento = t.tipo_movimiento
                    WHERE	factura			= {0}
                    AND		m.estado_actual <> 'Cancelado'
                    AND		m.fecha         < dateadd(day, 1, getdate())
                ";
        }
    }
}
