
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
    public class FirewallBrandFormController
    {
        #region Attributes

        private FirewallBrandForm frmFirewallBrand;
        private FirewallBrand FirewallBrand;
        private IFirewallBrandService srvFirewallBrand;

        #endregion Attributes

        #region Constructor

        public FirewallBrandFormController(FirewallBrandForm instance)
        {
            this.frmFirewallBrand = instance;
            this.srvFirewallBrand = SamsaraAppContext.Resolve<IFirewallBrandService>();
            Assert.IsNotNull(this.srvFirewallBrand);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmFirewallBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmFirewallBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmFirewallBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmFirewallBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmFirewallBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmFirewallBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmFirewallBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmFirewallBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmFirewallBrand.HiddenDetail(!show);
            if (show)
                this.frmFirewallBrand.tabPrincipal.SelectedTab = this.frmFirewallBrand.tabPrincipal.TabPages["New"];
            else
                this.frmFirewallBrand.tabPrincipal.SelectedTab = this.frmFirewallBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmFirewallBrand.txtDetName.Text == null || 
                this.frmFirewallBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmFirewallBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.FirewallBrand.Name = this.frmFirewallBrand.txtDetName.Text;
            this.FirewallBrand.Description = this.frmFirewallBrand.txtDetDescription.Text;

            this.FirewallBrand.Activated = true;
            this.FirewallBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmFirewallBrand.txtDetName.Text = string.Empty;
            this.frmFirewallBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmFirewallBrand.txtSchName.Text = string.Empty;
        }

        private void SaveFirewallBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el FirewallBrand?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvFirewallBrand.SaveOrUpdate(this.FirewallBrand);
                this.frmFirewallBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditFirewallBrand(int FirewallBrandId)
        {
            this.FirewallBrand = this.srvFirewallBrand.GetById(FirewallBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmFirewallBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmFirewallBrand.txtDetName.Text = this.FirewallBrand.Name;
            this.frmFirewallBrand.txtDetDescription.Text = this.FirewallBrand.Description;
        }

        private void DeleteEntity(int FirewallBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Marca de Firewall?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.FirewallBrand = this.srvFirewallBrand.GetById(FirewallBrandId);
            this.FirewallBrand.Activated = false;
            this.FirewallBrand.Deleted = true;
            this.srvFirewallBrand.SaveOrUpdate(this.FirewallBrand);
            this.Search();
        }

        private void Search()
        {
            FirewallBrandParameters pmtFirewallBrand = new FirewallBrandParameters();

            pmtFirewallBrand.Name = "%" + this.frmFirewallBrand.txtSchName.Text + "%";

            DataTable dtFirewallBrands = srvFirewallBrand.SearchByParameters(pmtFirewallBrand);

            this.frmFirewallBrand.grdSchSearch.DataSource = null;
            this.frmFirewallBrand.grdSchSearch.DataSource = dtFirewallBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.FirewallBrand = new FirewallBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveFirewallBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmFirewallBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditFirewallBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmFirewallBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmFirewallBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
