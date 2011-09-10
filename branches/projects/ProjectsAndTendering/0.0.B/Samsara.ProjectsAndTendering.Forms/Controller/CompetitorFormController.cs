
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class CompetitorFormController
    {
        #region Attributes

        private CompetitorForm frmCompetitor;
        private Competitor Competitor;
        private ICompetitorService srvCompetitor;

        #endregion Attributes

        #region Constructor

        public CompetitorFormController(CompetitorForm instance)
        {
            this.frmCompetitor = instance;
            this.srvCompetitor = SamsaraAppContext.Resolve<ICompetitorService>();
            Assert.IsNotNull(this.srvCompetitor);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCompetitor.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCompetitor.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCompetitor.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCompetitor.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCompetitor.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCompetitor.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCompetitor.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCompetitor.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCompetitor.HiddenDetail(!show);
            if (show)
                this.frmCompetitor.tabPrincipal.SelectedTab = this.frmCompetitor.tabPrincipal.TabPages["New"];
            else
                this.frmCompetitor.tabPrincipal.SelectedTab = this.frmCompetitor.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCompetitor.txtDetName.Text == null || 
                this.frmCompetitor.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCompetitor.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.Competitor.Name = this.frmCompetitor.txtDetName.Text;
            this.Competitor.Description = this.frmCompetitor.txtDetDescription.Text;

            this.Competitor.Activated = true;
            this.Competitor.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCompetitor.txtDetName.Text = string.Empty;
            this.frmCompetitor.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCompetitor.txtSchName.Text = string.Empty;
        }

        private void SaveCompetitor()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Competitor?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCompetitor.SaveOrUpdate(this.Competitor);
                this.frmCompetitor.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCompetitor(int CompetitorId)
        {
            this.Competitor = this.srvCompetitor.GetById(CompetitorId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCompetitor.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCompetitor.txtDetName.Text = this.Competitor.Name;
            this.frmCompetitor.txtDetDescription.Text = this.Competitor.Description;
        }

        private void DeleteEntity(int CompetitorId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.Competitor = this.srvCompetitor.GetById(CompetitorId);
            this.Competitor.Activated = false;
            this.Competitor.Deleted = true;
            this.srvCompetitor.SaveOrUpdate(this.Competitor);
            this.Search();
        }

        private void Search()
        {
            CompetitorParameters pmtCompetitor = new CompetitorParameters();

            pmtCompetitor.Name = "%" + this.frmCompetitor.txtSchName.Text + "%";

            DataTable dtCompetitors = srvCompetitor.SearchByParameters(pmtCompetitor);

            this.frmCompetitor.grdSchSearch.DataSource = null;
            this.frmCompetitor.grdSchSearch.DataSource = dtCompetitors;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.Competitor = new Competitor();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCompetitor();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCompetitor.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCompetitor(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCompetitor.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCompetitor.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
