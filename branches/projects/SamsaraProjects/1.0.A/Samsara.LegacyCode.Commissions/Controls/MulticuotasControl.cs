
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.LegacyCode.Commissions.Main;
using Samsara.Support.Util;

namespace Samsara.LegacyCode.Commissions.Controls
{
    public partial class MulticuotasControl : UserControl
    {
        #region Attributes

        private SqlConnection cnn;
        private DataSet ds;
        private string consulta;
        //private SqlDataAdapter da;
        private Nullable<int> agentId;

        #endregion Attributes

        #region Properties

        public int AgentId
        {
            set
            {
                this.agentId = value;
            }
        }

        public Nullable<int> SelectedSquemeId
        {
            get
            {
                if (this.grdMultiquotaSchemes.ActiveRow == null)
                    return null;

                return Convert.ToInt32(this.grdMultiquotaSchemes.ActiveRow.Cells["esquema"].Value);
            }
        }

        public Nullable<int> SelectedSegmentId
        {
            get
            {
                if (this.grdAgentSegments.ActiveRow == null)
                    return null;

                return Convert.ToInt32(this.grdAgentSegments.ActiveRow.Cells["id"].Value);
            }
        }

        #endregion Properties

        #region Constructor

        public MulticuotasControl()
        {
            cnn = new SqlConnection(ConectionStrings.AlleatoConectionString);
            InitializeComponent();
            InitializeControlControls();
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadGrids()
        {
            this.LoadSchemesGrid();
            this.LoadSegmentsGrid();
        }

        #endregion Public

        #region Private

        private void InitializeControlControls()
        {
        }

        private void LoadSchemesGrid()
        {
            consulta = string.Format(@"
                    SELECT 
                        esquema, nombre, fecha, agente, cuota_productos, 
                        comisiona_servicios, cuota_servicios
                    FROM        Esquemas_Agentes ea
                    WHERE agente = {0} AND borrado = 0
                ", this.agentId);

            SqlDataAdapter da = new SqlDataAdapter(consulta, cnn);
            ds = new DataSet();
            da.Fill(ds, "esquemas");
            this.grdMultiquotaSchemes.DataSource = null;
            this.grdMultiquotaSchemes.DataSource = ds.Tables["esquemas"];
        }

        private void LoadSegmentsGrid()
        {
            this.grdAgentSegments.DataSource = null;

            if (this.SelectedSquemeId != null)
            {
                consulta = string.Format(@"
                    SELECT 
                        id, esquema, utilidad_inicial, comision * 100 comision
                    FROM Esquemas_Cuotas ec
                    WHERE esquema = {0} AND borrado = 0
                    ORDER BY utilidad_inicial
                ", this.SelectedSquemeId);

                SqlDataAdapter da = new SqlDataAdapter(consulta, cnn);
                ds = new DataSet();
                da.Fill(ds, "quotas");
                this.grdAgentSegments.DataSource = ds.Tables["quotas"];
            }
        }

        private void ShowNewSchemeControls(bool visible)
        {
            this.ugbxNewScheme.Visible = visible;
            this.uplSchemesButtons.Visible = !visible;
        }

        private bool ValidateSchemeFields()
        {
            if (string.IsNullOrEmpty(this.txtSchemeName.Text)
                || string.IsNullOrWhiteSpace(this.txtSchemeName.Text))
            {
                MessageBox.Show("Debe asignarle un nombre al esquema de comisiones.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            if (this.dteSchemeStartDate.DateTime == null)
            {
                MessageBox.Show("Debe asignarle una fecha al esquema de comisiones.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            if (this.agentId == null)
            {
                throw new Exception("No se asigno el agente al control de multicuotas");
            }

            return true;
        }

        private void ClearNewSchemeFields()
        {
            this.txtSchemeName.Value = null;
            this.dteSchemeStartDate.DateTime = new DateTime(DateTime.Now.Year, 01, 01);
        }

        private void ShowNewSegmentControls(bool visible)
        {
            this.ugbxNewSegment.Visible = visible;
            this.upnlSegmentButtons.Visible = !visible;
        }

        private void ClearNewSegmentFields()
        {
            this.txtComissionPercent.Value = null;
            this.txtSegmentAmount.Value = null;
        }

        private bool ValidateSegmentFields()
        {
            if (this.txtSegmentAmount.Value == null
                || string.IsNullOrEmpty(this.txtSegmentAmount.Value.ToString().Trim()))
            {
                MessageBox.Show("Debe asignar una utilidad inicial al esquema del agente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            if (this.txtComissionPercent.Value == null
                || string.IsNullOrEmpty(this.txtComissionPercent.Value.ToString().Trim()))
            {
                MessageBox.Show("Debe asignar un porcentaje de comsión al esquema del agente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            if (this.agentId == null)
            {
                throw new Exception("No se asigno el esquema para asignar cuotas");
            }

            return true;
        }

        private bool IsUsedSelectedScheme()
        {
            consulta = string.Format(@"
                    SELECT 
                        DISTINCT ea.esquema
                    FROM        Esquemas_Agentes ea
                    INNER JOIN  Detalle_Comisiones_Pagadas dcp ON dcp.esquema = ea.esquema
                    WHERE ea.esquema = {0}
                ", this.SelectedSquemeId);

            cnn.Open();
            SqlCommand command = new SqlCommand(consulta, cnn);
            object value = command.ExecuteScalar();
            cnn.Close();

            if (value != null)
            {
                MessageBox.Show("No puede borrar el registro debido a que ya "
                    + "se han realizado pagos bajo ese esquema.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }

            return false;
        }

        #endregion Private

        #endregion Methods
        
        #region Events

        private void ubtnCreateScheme_Click(object sender, EventArgs e)
        {
            this.ClearNewSchemeFields();
            this.ShowNewSchemeControls(true);
        }

        private void ubtnCancelScheme_Click(object sender, EventArgs e)
        {
            this.ShowNewSchemeControls(false);
        }

        private void ubtnAcceptScheme_Click(object sender, EventArgs e)
        {
            if (!this.ValidateSchemeFields())
            {
                return;
            }

            string schemeName = this.txtSchemeName.Text;
            DateTime schemeDate = this.dteSchemeStartDate.DateTime;

            consulta = string.Format(@"
                    INSERT INTO Esquemas_Agentes (nombre, fecha, agente, borrado)
                    VALUES ('{0}', '{1}', {2}, 0)
                ", schemeName, schemeDate.ToString("yyyyMMdd"), this.agentId);

            cnn.Open();
            SqlCommand command = new SqlCommand(consulta, cnn);
            command.ExecuteNonQuery();
            cnn.Close();

            this.ShowNewSchemeControls(false);
            this.LoadSchemesGrid();
        }

        private void ubtnDeleteScheme_Click(object sender, EventArgs e)
        {
            if (this.SelectedSquemeId == null || this.IsUsedSelectedScheme())
                return;

            if (MessageBox.Show(string.Format("¿Esta seguro de borrar el esquema \"{0}\"?", 
                this.grdMultiquotaSchemes.ActiveRow.Cells["nombre"].Value),
                "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            consulta = string.Format(@"
                    SELECT 
                        DISTINCT ea.esquema
                    FROM        Esquemas_Agentes ea
                    INNER JOIN  Esquemas_Cuotas ec ON ec.esquema = ea.esquema
                    WHERE ea.esquema = {0}
                ", this.SelectedSquemeId);

            cnn.Open();
            SqlCommand command = new SqlCommand(consulta, cnn);
            object value = command.ExecuteScalar();
            cnn.Close();

            if (value != null && MessageBox.Show("Existen cuotas relacionadas al esquema, "
                + "estas se borraran ¿Desea continuar?",
                "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            consulta = string.Format(@"
                    UPDATE Esquemas_Cuotas SET borrado = 1
                    WHERE esquema = {0};

                    UPDATE Esquemas_Agentes SET borrado = 1
                    WHERE esquema = {0};
                ", this.SelectedSquemeId);

            cnn.Open();
            command = new SqlCommand(consulta, cnn);
            command.ExecuteNonQuery();
            cnn.Close();

            this.LoadGrids();
        }

        private void ubtnDeleteSegment_Click(object sender, EventArgs e)
        {
            if (this.SelectedSegmentId == null || this.IsUsedSelectedScheme())
                return;

            if (MessageBox.Show(string.Format("¿Esta seguro de borrar la cuota de monto \"{0}\"?",
                Convert.ToDecimal(this.grdAgentSegments.ActiveRow.Cells["cuota"].Value).ToString("N2")),
                "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            consulta = string.Format(@"
                    UPDATE Esquemas_Cuotas SET borrado = 1
                    WHERE id = {0};
                ", this.SelectedSegmentId);

            cnn.Open();
            SqlCommand command = new SqlCommand(consulta, cnn);
            command.ExecuteNonQuery();
            cnn.Close();

            this.LoadSegmentsGrid();
        }

        private void ubtnCreateSegment_Click(object sender, EventArgs e)
        {
            if (this.SelectedSquemeId != null)
            {
                this.ClearNewSegmentFields();
                this.ShowNewSegmentControls(true);
            }
        }

        private void ubtnAcceptSegment_Click(object sender, EventArgs e)
        {
            if (!this.ValidateSegmentFields())
            {
                return;
            }
            try
            {
                decimal quotaPercent = Convert.ToDecimal(this.txtComissionPercent.Value.ToString().Replace("%", "")) / 100;
                decimal quotaAmount = Convert.ToDecimal(this.txtSegmentAmount.Value);

                consulta = string.Format(@"
                    INSERT INTO Esquemas_Cuotas (esquema, utilidad_inicial, comision, borrado)
                    VALUES ({0}, {1}, {2}, 0)
                ", this.SelectedSquemeId, quotaAmount, quotaPercent);

                cnn.Open();
                SqlCommand command = new SqlCommand(consulta, cnn);
                command.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("Ya existe una cuota con ese monto.\n", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (cnn.State != ConnectionState.Closed)
                {
                    cnn.Close();
                }
            }

            this.ShowNewSegmentControls(false);
            this.LoadSegmentsGrid();
        }

        private void ubtnCancelSegment_Click(object sender, EventArgs e)
        {
            this.ShowNewSegmentControls(false);
        }

        private void grdMultiquotaSchemes_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            layout.Override.AllowUpdate = DefaultableBoolean.False;

            band.Columns["esquema"].Hidden = true;
            band.Columns["agente"].Hidden = true;
            band.Columns["nombre"].Header.Caption = "Esquema";
            band.Columns["nombre"].Width = 200;
            band.Columns["fecha"].Header.Caption = "Fecha de inicio";
            band.Columns["cuota_servicios"].Header.Caption = "Cuota de servicios";
            band.Columns["cuota_productos"].Header.Caption = "Cuota de productos";
            band.Columns["comisiona_servicios"].Hidden = true;
        }

        private void grdAgentSegments_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            layout.Override.AllowUpdate = DefaultableBoolean.False;

            band.Columns["id"].Hidden = true;
            band.Columns["esquema"].Hidden = true;
            band.Columns["utilidad_inicial"].Header.Caption = "Utilidad inicial";
            band.Columns["comision"].Header.Caption = "Comisión";

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["utilidad_inicial"],
                TextMaskFormatEnum.Currency);
            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["comision"],
                TextMaskFormatEnum.Percentage);
        }

        private void grdMultiquotaSchemes_ClickCell(object sender, ClickCellEventArgs e)
        {
            this.LoadSegmentsGrid();
        }

        #endregion Events
    }
}
