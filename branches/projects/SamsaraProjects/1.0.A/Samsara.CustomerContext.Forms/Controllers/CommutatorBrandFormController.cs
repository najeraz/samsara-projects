
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Forms.Forms;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Controller
{
    public class CommutatorBrandFormController
    {
        #region Attributes

        private CommutatorBrandForm frmCommutatorBrand;
        private CommutatorBrand CommutatorBrand;
        private ICommutatorBrandService srvCommutatorBrand;

        #endregion Attributes

        #region Constructor

        public CommutatorBrandFormController(CommutatorBrandForm instance)
        {
            this.frmCommutatorBrand = instance;
            this.srvCommutatorBrand = SamsaraAppContext.Resolve<ICommutatorBrandService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCommutatorBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCommutatorBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCommutatorBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCommutatorBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCommutatorBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCommutatorBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCommutatorBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCommutatorBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCommutatorBrand.HiddenDetail(!show);
            if (show)
                this.frmCommutatorBrand.tabPrincipal.SelectedTab = this.frmCommutatorBrand.tabPrincipal.TabPages["New"];
            else
                this.frmCommutatorBrand.tabPrincipal.SelectedTab = this.frmCommutatorBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCommutatorBrand.txtDetName.Text == null || 
                this.frmCommutatorBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Marca de Conmutador.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCommutatorBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.CommutatorBrand.Name = this.frmCommutatorBrand.txtDetName.Text;
            this.CommutatorBrand.Description = this.frmCommutatorBrand.txtDetDescription.Text;

            this.CommutatorBrand.Activated = true;
            this.CommutatorBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCommutatorBrand.txtDetName.Text = string.Empty;
            this.frmCommutatorBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCommutatorBrand.txtSchName.Text = string.Empty;
        }

        private void SaveCommutatorBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Marca de Conmutador?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCommutatorBrand.SaveOrUpdate(this.CommutatorBrand);
                this.frmCommutatorBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCommutatorBrand(int CommutatorBrandId)
        {
            this.CommutatorBrand = this.srvCommutatorBrand.GetById(CommutatorBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCommutatorBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCommutatorBrand.txtDetName.Text = this.CommutatorBrand.Name;
            this.frmCommutatorBrand.txtDetDescription.Text = this.CommutatorBrand.Description;
        }

        private void DeleteEntity(int CommutatorBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Marca de Conmutador?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CommutatorBrand = this.srvCommutatorBrand.GetById(CommutatorBrandId);
            this.CommutatorBrand.Activated = false;
            this.CommutatorBrand.Deleted = true;
            this.srvCommutatorBrand.SaveOrUpdate(this.CommutatorBrand);
            this.Search();
        }

        private void Search()
        {
            CommutatorBrandParameters pmtCommutatorBrand = new CommutatorBrandParameters();

            pmtCommutatorBrand.Name = "%" + this.frmCommutatorBrand.txtSchName.Text + "%";

            DataTable dtCommutatorBrands = srvCommutatorBrand.SearchByParameters(pmtCommutatorBrand);

            this.frmCommutatorBrand.grdSchSearch.DataSource = null;
            this.frmCommutatorBrand.grdSchSearch.DataSource = dtCommutatorBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CommutatorBrand = new CommutatorBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCommutatorBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCommutatorBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCommutatorBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCommutatorBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCommutatorBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
