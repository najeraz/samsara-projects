
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
    public class TenderStatusFormController
    {
        #region Attributes

        private TenderStatusForm frmTenderStatus;
        private TenderStatus tenderStatus;
        private ITenderStatusService srvTenderStatus;

        #endregion Attributes

        #region Constructor

        public TenderStatusFormController(TenderStatusForm instance)
        {
            this.frmTenderStatus = instance;
            this.srvTenderStatus = SamsaraAppContext.Resolve<ITenderStatusService>();
            Assert.IsNotNull(srvTenderStatus);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmTenderStatus.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmTenderStatus.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmTenderStatus.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmTenderStatus.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmTenderStatus.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmTenderStatus.btnSchClear.Click += new EventHandler(btnSchClear_Click);

            this.frmTenderStatus.HiddenDetail(true);
        }

        private void ShowDetail(bool show)
        {
            this.frmTenderStatus.HiddenDetail(!show);
            if (show)
                this.frmTenderStatus.tabPrincipal.SelectedTab = this.frmTenderStatus.tabPrincipal.TabPages["New"];
            else
                this.frmTenderStatus.tabPrincipal.SelectedTab = this.frmTenderStatus.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmTenderStatus.txtDetName.Text == null ||
                this.frmTenderStatus.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el TenderStatus.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmTenderStatus.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.tenderStatus.Name = this.frmTenderStatus.txtDetName.Text;

            this.tenderStatus.Activated = true;
            this.tenderStatus.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmTenderStatus.txtDetName.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmTenderStatus.txtSchName.Text = string.Empty;
        }

        private void SaveTenderStatus()
        {
            if (this.ValidateFormInformation())
            {
                this.LoadEntity();
                this.srvTenderStatus.SaveOrUpdateTenderStatus(this.tenderStatus);
                this.frmTenderStatus.HiddenDetail(true);
            }
        }

        private void EditTenderStatus(int tenderStatusId)
        {
            this.tenderStatus = this.srvTenderStatus.LoadTenderStatus(tenderStatusId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmTenderStatus.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmTenderStatus.txtDetName.Text = this.tenderStatus.Name;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            SearchTenderStatusesParameters pmtSearchTenderStatuses = new SearchTenderStatusesParameters();

            pmtSearchTenderStatuses.Name = "%" + this.frmTenderStatus.txtSchName.Text + "%";

            DataTable dtTenderStatuses = srvTenderStatus.SearchTenderStatuses(pmtSearchTenderStatuses);

            this.frmTenderStatus.grdSchSearch.DataSource = null;
            this.frmTenderStatus.grdSchSearch.DataSource = dtTenderStatuses;
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.tenderStatus = new TenderStatus();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveTenderStatus();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTenderStatus.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditTenderStatus(Convert.ToInt32(activeRow.Cells["Column1"].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmTenderStatus.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }
        #endregion Events
    }
}
