
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Forms.Forms;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Controller
{
    public class RouterBrandFormController
    {
        #region Attributes

        private RouterBrandForm frmRouterBrand;
        private RouterBrand RouterBrand;
        private IRouterBrandService srvRouterBrand;

        #endregion Attributes

        #region Constructor

        public RouterBrandFormController(RouterBrandForm instance)
        {
            this.frmRouterBrand = instance;
            this.srvRouterBrand = SamsaraAppContext.Resolve<IRouterBrandService>();
            Assert.IsNotNull(this.srvRouterBrand);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmRouterBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmRouterBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmRouterBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmRouterBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmRouterBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmRouterBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmRouterBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmRouterBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmRouterBrand.HiddenDetail(!show);
            if (show)
                this.frmRouterBrand.tabPrincipal.SelectedTab = this.frmRouterBrand.tabPrincipal.TabPages["New"];
            else
                this.frmRouterBrand.tabPrincipal.SelectedTab = this.frmRouterBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmRouterBrand.txtDetName.Text == null || 
                this.frmRouterBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmRouterBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.RouterBrand.Name = this.frmRouterBrand.txtDetName.Text;
            this.RouterBrand.Description = this.frmRouterBrand.txtDetDescription.Text;

            this.RouterBrand.Activated = true;
            this.RouterBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmRouterBrand.txtDetName.Text = string.Empty;
            this.frmRouterBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmRouterBrand.txtSchName.Text = string.Empty;
        }

        private void SaveRouterBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el RouterBrand?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvRouterBrand.SaveOrUpdate(this.RouterBrand);
                this.frmRouterBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditRouterBrand(int RouterBrandId)
        {
            this.RouterBrand = this.srvRouterBrand.GetById(RouterBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmRouterBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmRouterBrand.txtDetName.Text = this.RouterBrand.Name;
            this.frmRouterBrand.txtDetDescription.Text = this.RouterBrand.Description;
        }

        private void DeleteEntity(int RouterBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.RouterBrand = this.srvRouterBrand.GetById(RouterBrandId);
            this.RouterBrand.Activated = false;
            this.RouterBrand.Deleted = true;
            this.srvRouterBrand.SaveOrUpdate(this.RouterBrand);
            this.Search();
        }

        private void Search()
        {
            RouterBrandParameters pmtRouterBrand = new RouterBrandParameters();

            pmtRouterBrand.Name = "%" + this.frmRouterBrand.txtSchName.Text + "%";

            DataTable dtRouterBrands = srvRouterBrand.SearchByParameters(pmtRouterBrand);

            this.frmRouterBrand.grdSchSearch.DataSource = null;
            this.frmRouterBrand.grdSchSearch.DataSource = dtRouterBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.RouterBrand = new RouterBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveRouterBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmRouterBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditRouterBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmRouterBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmRouterBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
