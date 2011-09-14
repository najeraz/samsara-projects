
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
    public class SwitchBrandFormController
    {
        #region Attributes

        private SwitchBrandForm frmSwitchBrand;
        private SwitchBrand SwitchBrand;
        private ISwitchBrandService srvSwitchBrand;

        #endregion Attributes

        #region Constructor

        public SwitchBrandFormController(SwitchBrandForm instance)
        {
            this.frmSwitchBrand = instance;
            this.srvSwitchBrand = SamsaraAppContext.Resolve<ISwitchBrandService>();
            Assert.IsNotNull(this.srvSwitchBrand);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmSwitchBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmSwitchBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmSwitchBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmSwitchBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmSwitchBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmSwitchBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmSwitchBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmSwitchBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmSwitchBrand.HiddenDetail(!show);
            if (show)
                this.frmSwitchBrand.tabPrincipal.SelectedTab = this.frmSwitchBrand.tabPrincipal.TabPages["New"];
            else
                this.frmSwitchBrand.tabPrincipal.SelectedTab = this.frmSwitchBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmSwitchBrand.txtDetName.Text == null || 
                this.frmSwitchBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Marca de Switch.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmSwitchBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.SwitchBrand.Name = this.frmSwitchBrand.txtDetName.Text;
            this.SwitchBrand.Description = this.frmSwitchBrand.txtDetDescription.Text;

            this.SwitchBrand.Activated = true;
            this.SwitchBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmSwitchBrand.txtDetName.Text = string.Empty;
            this.frmSwitchBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmSwitchBrand.txtSchName.Text = string.Empty;
        }

        private void SaveSwitchBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Marca de Switch?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvSwitchBrand.SaveOrUpdate(this.SwitchBrand);
                this.frmSwitchBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditSwitchBrand(int SwitchBrandId)
        {
            this.SwitchBrand = this.srvSwitchBrand.GetById(SwitchBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmSwitchBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmSwitchBrand.txtDetName.Text = this.SwitchBrand.Name;
            this.frmSwitchBrand.txtDetDescription.Text = this.SwitchBrand.Description;
        }

        private void DeleteEntity(int SwitchBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Marca de Switch?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.SwitchBrand = this.srvSwitchBrand.GetById(SwitchBrandId);
            this.SwitchBrand.Activated = false;
            this.SwitchBrand.Deleted = true;
            this.srvSwitchBrand.SaveOrUpdate(this.SwitchBrand);
            this.Search();
        }

        private void Search()
        {
            SwitchBrandParameters pmtSwitchBrand = new SwitchBrandParameters();

            pmtSwitchBrand.Name = "%" + this.frmSwitchBrand.txtSchName.Text + "%";

            DataTable dtSwitchBrands = srvSwitchBrand.SearchByParameters(pmtSwitchBrand);

            this.frmSwitchBrand.grdSchSearch.DataSource = null;
            this.frmSwitchBrand.grdSchSearch.DataSource = dtSwitchBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.SwitchBrand = new SwitchBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveSwitchBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmSwitchBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditSwitchBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmSwitchBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmSwitchBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
