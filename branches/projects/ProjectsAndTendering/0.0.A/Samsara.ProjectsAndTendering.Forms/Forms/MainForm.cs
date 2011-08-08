using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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

        private void estatusDeLaLicitaciónToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                TenderStatusForm frmTenderStatus = new TenderStatusForm();
                frmTenderStatus.Show();
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
    }
}
