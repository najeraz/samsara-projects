
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class DependencyFormController
    {
        #region Attributes

        private DependencyForm frmDependency;
        private Dependency dependency;
        private IDependencyService srvDependency;
        private IBidderService srvBidder;

        #endregion Attributes

        #region Constructor

        public DependencyFormController(DependencyForm instance)
        {
            this.frmDependency = instance;
            this.srvDependency = SamsaraAppContext.Resolve<IDependencyService>();
            this.srvBidder = SamsaraAppContext.Resolve<IBidderService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            // Bidder
            BidderParameters pmtBidder = new BidderParameters();

            this.frmDependency.bccDetBidder.Parameters = pmtBidder;
            this.frmDependency.bccDetBidder.ValueMember = "BidderId";
            this.frmDependency.bccDetBidder.DisplayMember = "Name";
            this.frmDependency.bccDetBidder.Refresh();

            this.frmDependency.bccSchBidder.Parameters = pmtBidder;
            this.frmDependency.bccSchBidder.ValueMember = "BidderId";
            this.frmDependency.bccSchBidder.DisplayMember = "Name";
            this.frmDependency.bccSchBidder.Refresh();

            this.frmDependency.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmDependency.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmDependency.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmDependency.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmDependency.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmDependency.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmDependency.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmDependency.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmDependency.HiddenDetail(!show);
            if (show)
                this.frmDependency.tabPrincipal.SelectedTab = this.frmDependency.tabPrincipal.TabPages["New"];
            else
                this.frmDependency.tabPrincipal.SelectedTab = this.frmDependency.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmDependency.txtDetName.Text == null || 
                this.frmDependency.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Dependency.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmDependency.txtDetName.Focus();
                return false;
            }

            if (this.frmDependency.bccDetBidder.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el Licitante.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmDependency.bccDetBidder.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.dependency.Bidder = this.frmDependency.bccDetBidder.Value;
            this.dependency.Name = this.frmDependency.txtDetName.Text;

            this.dependency.Activated = true;
            this.dependency.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmDependency.txtDetName.Text = string.Empty;
            this.frmDependency.bccDetBidder.Value = null;
        }

        private void ClearSearchControls()
        {
            this.frmDependency.txtSchName.Text = string.Empty;
            this.frmDependency.bccSchBidder.Value = null;
        }

        private void SaveDependency()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Dependencia?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvDependency.SaveOrUpdate(this.dependency);
                this.frmDependency.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditDependency(int dependencyId)
        {
            this.dependency = this.srvDependency.GetById(dependencyId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmDependency.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmDependency.bccDetBidder.Value = this.dependency.Bidder;
            this.frmDependency.txtDetName.Text = this.dependency.Name;
        }

        private void DeleteEntity(int dependencyId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Dependencia?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.dependency = this.srvDependency.GetById(dependencyId);
            this.dependency.Activated = false;
            this.dependency.Deleted = true;
            this.srvDependency.SaveOrUpdate(this.dependency);
            this.Search();
        }

        private void Search()
        {
            DependencyParameters pmtDependency = new DependencyParameters();

            pmtDependency.Name = "%" + this.frmDependency.txtSchName.Text + "%";
            pmtDependency.BidderId = this.frmDependency.bccSchBidder.Value == null ? 
                -1 : this.frmDependency.bccSchBidder.Value.BidderId;

            DataTable dtDependencies = srvDependency.SearchByParameters(pmtDependency);

            this.frmDependency.grdSchSearch.DataSource = null;
            this.frmDependency.grdSchSearch.DataSource = dtDependencies;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.dependency = new Dependency();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveDependency();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmDependency.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditDependency(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmDependency.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmDependency.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
