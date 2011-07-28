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

        private void licitaciónToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            TenderForm frmTender = new TenderForm();
            frmTender.Show();
        }

        private void licitanteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            BidderForm frmBidder = new BidderForm();
            frmBidder.Show();
        }

        private void dependenciaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DependencyForm frmDependency = new DependencyForm();
            frmDependency.Show();
        }

        private void usuarioFinalToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            EndUserForm frmEndUser = new EndUserForm();
            frmEndUser.Show();
        }

        private void fabricanteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ManufacturerForm frmManufacturer = new ManufacturerForm();
            frmManufacturer.Show();
        }

        private void asesorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AsesorForm frmAsesor = new AsesorForm();
            frmAsesor.Show();
        }

        private void estatusDeLaLicitaciónToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            TenderStatusForm frmTenderStatus = new TenderStatusForm();
            frmTenderStatus.Show();
        }
    }
}
