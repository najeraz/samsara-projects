
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class AsesorFormController
    {
        #region Attributes

        private AsesorForm frmAsesor;
        private Asesor asesor;
        private IAsesorService srvAsesor;

        #endregion Attributes

        #region Constructor

        public AsesorFormController(AsesorForm instance)
        {
            this.frmAsesor = instance;
            this.srvAsesor = SamsaraAppContext.Resolve<IAsesorService>();
            Assert.IsNotNull(srvAsesor);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmAsesor.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmAsesor.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmAsesor.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmAsesor.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmAsesor.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmAsesor.chkSchShowAll.CheckedChanged += new EventHandler(chkSchShowAll_CheckedChanged);
            this.frmAsesor.btnSchClear.Click += new EventHandler(btnSchClear_Click);

            this.frmAsesor.HiddenDetail(true);
        }

        private void ShowDetail(bool show)
        {
            this.frmAsesor.HiddenDetail(!show);
            if (show)
                this.frmAsesor.tabPrincipal.SelectedTab = this.frmAsesor.tabPrincipal.TabPages["New"];
            else
                this.frmAsesor.tabPrincipal.SelectedTab = this.frmAsesor.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmAsesor.txtDetName.Text == null || this.frmAsesor.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Asesor.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmAsesor.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.asesor.CanApprove = this.frmAsesor.chkDetCanApprove.Checked;
            this.asesor.Name = this.frmAsesor.txtDetName.Text;
            this.asesor.FullName = this.frmAsesor.txtDetFullName.Text;

            this.asesor.Activated = true;
            this.asesor.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmAsesor.chkDetCanApprove.Checked = false;
            this.frmAsesor.txtDetName.Text = string.Empty;
            this.frmAsesor.txtDetFullName.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmAsesor.chkSchShowAll.Checked = true;
            this.frmAsesor.chkSchShowApprovers.Checked = false;
            this.frmAsesor.txtSchFullName.Text = string.Empty;
            this.frmAsesor.txtSchName.Text = string.Empty;
        }

        private void SaveAsesor()
        {
            if (this.ValidateFormInformation())
            {
                this.LoadEntity();
                this.srvAsesor.SaveOrUpdateAsesor(this.asesor);
                this.frmAsesor.HiddenDetail(true);
            }
        }

        private void EditAsesor(int asesorId)
        {
            this.asesor = this.srvAsesor.LoadAsesor(asesorId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmAsesor.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmAsesor.chkDetCanApprove.Checked = this.asesor.CanApprove;
            this.frmAsesor.txtDetName.Text = this.asesor.Name;
            this.frmAsesor.txtDetFullName.Text = this.asesor.FullName;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            SearchAsesorsParameters pmtSearchAsesors = new SearchAsesorsParameters();

            pmtSearchAsesors.ShowAll = this.frmAsesor.chkSchShowAll.Checked;
            pmtSearchAsesors.ShowApprovers = this.frmAsesor.chkSchShowApprovers.Checked;
            pmtSearchAsesors.Name = "%" + this.frmAsesor.txtSchName.Text + "%";
            pmtSearchAsesors.FullName = "%" + this.frmAsesor.txtSchFullName.Text + "%";

            DataTable dtAsesors = srvAsesor.SearchAsesors(pmtSearchAsesors);

            this.frmAsesor.grdSchSearch.DataSource = null;
            this.frmAsesor.grdSchSearch.DataSource = dtAsesors;
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.asesor = new Asesor();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveAsesor();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmAsesor.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditAsesor(Convert.ToInt32(activeRow.Cells["Column1"].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmAsesor.HiddenDetail(true);
        }

        private void chkSchShowAll_CheckedChanged(object sender, EventArgs e)
        {
            this.frmAsesor.chkSchShowApprovers.Checked = false;
            this.frmAsesor.chkSchShowApprovers.Enabled = !this.frmAsesor.chkSchShowAll.Checked;
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }
        #endregion Events
    }
}
