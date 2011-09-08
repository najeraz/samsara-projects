
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Common.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class WholesalerFormController
    {
        #region Attributes

        private WholesalerForm frmWholesaler;
        private Wholesaler Wholesaler;
        private IWholesalerService srvWholesaler;

        #endregion Attributes

        #region Constructor

        public WholesalerFormController(WholesalerForm instance)
        {
            this.frmWholesaler = instance;
            this.srvWholesaler = SamsaraAppContext.Resolve<IWholesalerService>();
            Assert.IsNotNull(this.srvWholesaler);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmWholesaler.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmWholesaler.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmWholesaler.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmWholesaler.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmWholesaler.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmWholesaler.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmWholesaler.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmWholesaler.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmWholesaler.HiddenDetail(!show);
            if (show)
                this.frmWholesaler.tabPrincipal.SelectedTab = this.frmWholesaler.tabPrincipal.TabPages["New"];
            else
                this.frmWholesaler.tabPrincipal.SelectedTab = this.frmWholesaler.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmWholesaler.txtDetName.Text == null || 
                this.frmWholesaler.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Mayorista.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmWholesaler.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.Wholesaler.Name = this.frmWholesaler.txtDetName.Text;
            this.Wholesaler.Description = this.frmWholesaler.txtDetDescription.Text;

            this.Wholesaler.Activated = true;
            this.Wholesaler.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmWholesaler.txtDetName.Text = string.Empty;
            this.frmWholesaler.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmWholesaler.txtSchName.Text = string.Empty;
        }

        private void SaveWholesaler()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Wholesaler?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvWholesaler.SaveOrUpdate(this.Wholesaler);
                this.frmWholesaler.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditWholesaler(int WholesalerId)
        {
            this.Wholesaler = this.srvWholesaler.GetById(WholesalerId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmWholesaler.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmWholesaler.txtDetName.Text = this.Wholesaler.Name;
            this.frmWholesaler.txtDetDescription.Text = this.Wholesaler.Description;
        }

        private void DeleteEntity(int WholesalerId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.Wholesaler = this.srvWholesaler.GetById(WholesalerId);
            this.Wholesaler.Activated = false;
            this.Wholesaler.Deleted = true;
            this.srvWholesaler.SaveOrUpdate(this.Wholesaler);
            this.Search();
        }

        private void Search()
        {
            WholesalerParameters pmtWholesaler = new WholesalerParameters();

            pmtWholesaler.Name = "%" + this.frmWholesaler.txtSchName.Text + "%";

            DataTable dtWholesalers = srvWholesaler.SearchByParameters(pmtWholesaler);

            this.frmWholesaler.grdSchSearch.DataSource = null;
            this.frmWholesaler.grdSchSearch.DataSource = dtWholesalers;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.Wholesaler = new Wholesaler();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveWholesaler();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmWholesaler.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditWholesaler(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmWholesaler.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmWholesaler.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
