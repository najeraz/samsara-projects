
using System;
using System.Linq;
using System.Windows.Forms;
using Samsara.AlleatoERP.Forms.Forms;
using Samsara.Commissions.Forms.Forms;
using Samsara.CustomerContext.Forms.Forms;
using Samsara.Dashboard.Forms.Forms;
using Samsara.Operation.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.Support.Util;

namespace Samsara.Main.Forms.Forms
{
    public partial class MainForm : Form
    {
        public bool ClosedSession
        {
            get;
            private set;
        }

        public MainForm()
        {
            InitializeComponent();
            PostInitializeComponent();
        }

        private void PostInitializeComponent()
        {
            this.ulblPrplUsername.Text = Session.Session.User.Username;
        }

        private void licitanteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                BidderForm frmBidder = new BidderForm();
                frmBidder.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dependenciaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DependencyForm frmDependency = new DependencyForm();
                frmDependency.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void usuarioFinalToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                EndUserForm frmEndUser = new EndUserForm();
                frmEndUser.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void fabricanteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ManufacturerForm frmManufacturer = new ManufacturerForm();
                frmManufacturer.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void asesorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                AsesorForm frmAsesor = new AsesorForm();
                frmAsesor.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void licitacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                TenderForm frmTender = new TenderForm();
                frmTender.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void oportunidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                OpportunityForm frmOpportunity = new OpportunityForm();
                frmOpportunity.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void competenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CompetitorForm frmCompetitor = new CompetitorForm();
                frmCompetitor.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void estatusDeLaOportunidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                OpportunityStatusForm frmOpportunityStatus = new OpportunityStatusForm();
                frmOpportunityStatus.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void organizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                OrganizationForm frmOrganization = new OrganizationForm();
                frmOrganization.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void mayoristasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                WholesalerForm frmWholesaler = new WholesalerForm();
                frmWholesaler.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tiposDeFianzasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                WarrantyTypeForm frmWarrantyType = new WarrantyTypeForm();
                frmWarrantyType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tiposDeDocumentosDeFianzasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DocumentTypeWarrantyForm frmDocumentTypeWarranty = new DocumentTypeWarrantyForm();
                frmDocumentTypeWarranty.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void monedasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CurrencyForm frmCurrency = new CurrencyForm();
                frmCurrency.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tiposDeComputadorasPersonalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PersonalComputerTypeForm frmPersonalComputerType = new PersonalComputerTypeForm();
                frmPersonalComputerType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void marcasDeComputadorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ComputerBrandForm frmComputerBrand = new ComputerBrandForm();
                frmComputerBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tipoDeCableadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                NetworkCablingTypeForm frmNetworkCablingType = new NetworkCablingTypeForm();
                frmNetworkCablingType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tiposDeRacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                RackTypeForm frmRackType = new RackTypeForm();
                frmRackType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void marcasDeRoutersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                RouterBrandForm frmRouterBrand = new RouterBrandForm();
                frmRouterBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void marcasDeSwitchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SwitchBrandForm frmSwitchBrand = new SwitchBrandForm();
                frmSwitchBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void marcaDeCCTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CCTVBrandForm frmCCTVBrand = new CCTVBrandForm();
                frmCCTVBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tipoDeCCTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CCTVTypeForm frmCCTVType = new CCTVTypeForm();
                frmCCTVType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void marcaDeConmutadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CommutatorBrandForm frmCommutatorBrand = new CommutatorBrandForm();
                frmCommutatorBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tipoDeConmutadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CommutatorTypeForm frmCommutatorType = new CommutatorTypeForm();
                frmCommutatorType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tiposDeLíneasTelefónicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                TelephonyLineTypeForm frmTelephonyLineType = new TelephonyLineTypeForm();
                frmTelephonyLineType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void marcasDeImpresorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PrinterBrandForm frmPrinterBrand = new PrinterBrandForm();
                frmPrinterBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tiposDeImpresorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PrinterTypeForm frmPrinterType = new PrinterTypeForm();
                frmPrinterType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void marcasDeUPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                UPSBrandForm frmUPSBrand = new UPSBrandForm();
                frmUPSBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tiposDeUPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                UPSTypeForm frmUPSType = new UPSTypeForm();
                frmUPSType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void iSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ISPForm frmISP = new ISPForm();
                frmISP.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void proveedorDeTelefoníaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                TelephonyProviderForm frmTelephonyProvider = new TelephonyProviderForm();
                frmTelephonyProvider.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void sistemasOperativosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                OperativeSystemForm frmOperativeSystem = new OperativeSystemForm();
                frmOperativeSystem.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tiposDeSistemasOperativosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                OperativeSystemTypeForm frmOperativeSystemType = new OperativeSystemTypeForm();
                frmOperativeSystemType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void firewallsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                FirewallBrandForm frmFirewallBrand = new FirewallBrandForm();
                frmFirewallBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dBMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DBMSForm frmDBMS = new DBMSForm();
                frmDBMS.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void catálogoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CustomerForm frmCustomer = new CustomerForm();
                frmCustomer.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void girosDeNegocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                BusinessTypeForm frmBusinessType = new BusinessTypeForm();
                frmBusinessType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void marcasDeSoftwareDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SecuritySoftwareBrandForm frmSecuritySoftwareBrand = new SecuritySoftwareBrandForm();
                frmSecuritySoftwareBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tiposDeSoftwareDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SecuritySoftwareTypeForm frmSecuritySoftwareType = new SecuritySoftwareTypeForm();
                frmSecuritySoftwareType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void marcasDeSoftwareDeRespaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                BackupSoftwareBrandForm frmBackupSoftwareBrand = new BackupSoftwareBrandForm();
                frmBackupSoftwareBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void marcaDePuntoDeAccesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                AccessPointBrandForm frmAccessPointBrand = new AccessPointBrandForm();
                frmAccessPointBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tipoDePuntoDeAccesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                AccessPointTypeForm frmAccessPointType = new AccessPointTypeForm();
                frmAccessPointType.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ProductForm frmProduct = new ProductForm();
                frmProduct.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void marcasDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ProductBrandForm frmProductBrand = new ProductBrandForm();
                frmProductBrand.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void coberturaHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                HorizontalIntegrationReportForm frmHorizontalIntegrationReport = new HorizontalIntegrationReportForm();
                frmHorizontalIntegrationReport.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void coberturaVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                VerticalIntegrationReportForm frmVerticalIntegrationReport = new VerticalIntegrationReportForm();
                frmVerticalIntegrationReport.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.Session.Logout();
            this.ClosedSession = true;
            foreach (Form form in Application.OpenForms.Cast<Form>().ToArray())
            {
                if (!(form is LoginForm))
                    WindowsFormsUtil.CloseForm(form);
            }
        }

        private void comisionesDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ServicesManagementForm frmServicesManagement = new ServicesManagementForm();
                frmServicesManagement.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void calculoDeComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Samsara.LegacyCode.Commissions.Forms.MainForm frmMainComissions = new Samsara.LegacyCode.Commissions.Forms.MainForm();
                frmMainComissions.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
