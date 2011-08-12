
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class OpportunityStatusFormController
    {
        #region Attributes

        private OpportunityStatusForm frmOpportunityStatus;
        private OpportunityStatus OpportunityStatus;
        private IOpportunityStatusService srvOpportunityStatus;

        #endregion Attributes

        #region Constructor

        public OpportunityStatusFormController(OpportunityStatusForm instance)
        {
            this.frmOpportunityStatus = instance;
            this.srvOpportunityStatus = SamsaraAppContext.Resolve<IOpportunityStatusService>();
            Assert.IsNotNull(this.srvOpportunityStatus);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmOpportunityStatus.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmOpportunityStatus.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmOpportunityStatus.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmOpportunityStatus.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmOpportunityStatus.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmOpportunityStatus.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmOpportunityStatus.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmOpportunityStatus.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmOpportunityStatus.HiddenDetail(!show);
            if (show)
                this.frmOpportunityStatus.tabPrincipal.SelectedTab = this.frmOpportunityStatus.tabPrincipal.TabPages["New"];
            else
                this.frmOpportunityStatus.tabPrincipal.SelectedTab = this.frmOpportunityStatus.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmOpportunityStatus.txtDetName.Text == null ||
                this.frmOpportunityStatus.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el OpportunityStatus.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmOpportunityStatus.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.OpportunityStatus.Name = this.frmOpportunityStatus.txtDetName.Text;

            this.OpportunityStatus.Activated = true;
            this.OpportunityStatus.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmOpportunityStatus.txtDetName.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmOpportunityStatus.txtSchName.Text = string.Empty;
        }

        private void SaveOpportunityStatus()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Estatus?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvOpportunityStatus.SaveOrUpdate(this.OpportunityStatus);
                this.frmOpportunityStatus.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditOpportunityStatus(int OpportunityStatusId)
        {
            this.OpportunityStatus = this.srvOpportunityStatus.GetById(OpportunityStatusId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmOpportunityStatus.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmOpportunityStatus.txtDetName.Text = this.OpportunityStatus.Name;
        }

        private void DeleteEntity(int OpportunityStatusId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Estatus?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;
            this.OpportunityStatus = this.srvOpportunityStatus.GetById(OpportunityStatusId);
            this.OpportunityStatus.Activated = false;
            this.OpportunityStatus.Deleted = true;
            this.srvOpportunityStatus.SaveOrUpdate(this.OpportunityStatus);
            this.Search();
        }

        private void Search()
        {
            OpportunityStatusParameters pmtOpportunityStatus = new OpportunityStatusParameters();

            pmtOpportunityStatus.Name = "%" + this.frmOpportunityStatus.txtSchName.Text + "%";

            DataTable dtOpportunityStatuses = srvOpportunityStatus.SearchByParameters(pmtOpportunityStatus);

            this.frmOpportunityStatus.grdSchSearch.DataSource = null;
            this.frmOpportunityStatus.grdSchSearch.DataSource = dtOpportunityStatuses;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.OpportunityStatus = new OpportunityStatus();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveOpportunityStatus();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmOpportunityStatus.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditOpportunityStatus(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmOpportunityStatus.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmOpportunityStatus.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
