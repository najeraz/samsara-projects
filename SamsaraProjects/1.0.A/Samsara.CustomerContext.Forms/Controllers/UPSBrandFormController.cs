
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
    public class UPSBrandFormController
    {
        #region Attributes

        private UPSBrandForm frmUPSBrand;
        private UPSBrand UPSBrand;
        private IUPSBrandService srvUPSBrand;

        #endregion Attributes

        #region Constructor

        public UPSBrandFormController(UPSBrandForm instance)
        {
            this.frmUPSBrand = instance;
            this.srvUPSBrand = SamsaraAppContext.Resolve<IUPSBrandService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmUPSBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmUPSBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmUPSBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmUPSBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmUPSBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmUPSBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmUPSBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmUPSBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmUPSBrand.HiddenDetail(!show);
            if (show)
                this.frmUPSBrand.tabPrincipal.SelectedTab = this.frmUPSBrand.tabPrincipal.TabPages["New"];
            else
                this.frmUPSBrand.tabPrincipal.SelectedTab = this.frmUPSBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmUPSBrand.txtDetName.Text == null || 
                this.frmUPSBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Marca de UPS.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmUPSBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.UPSBrand.Name = this.frmUPSBrand.txtDetName.Text;
            this.UPSBrand.Description = this.frmUPSBrand.txtDetDescription.Text;

            this.UPSBrand.Activated = true;
            this.UPSBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmUPSBrand.txtDetName.Text = string.Empty;
            this.frmUPSBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmUPSBrand.txtSchName.Text = string.Empty;
        }

        private void SaveUPSBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Marca de UPS?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvUPSBrand.SaveOrUpdate(this.UPSBrand);
                this.frmUPSBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditUPSBrand(int UPSBrandId)
        {
            this.UPSBrand = this.srvUPSBrand.GetById(UPSBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmUPSBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmUPSBrand.txtDetName.Text = this.UPSBrand.Name;
            this.frmUPSBrand.txtDetDescription.Text = this.UPSBrand.Description;
        }

        private void DeleteEntity(int UPSBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Marca de UPS?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.UPSBrand = this.srvUPSBrand.GetById(UPSBrandId);
            this.UPSBrand.Activated = false;
            this.UPSBrand.Deleted = true;
            this.srvUPSBrand.SaveOrUpdate(this.UPSBrand);
            this.Search();
        }

        private void Search()
        {
            UPSBrandParameters pmtUPSBrand = new UPSBrandParameters();

            pmtUPSBrand.Name = "%" + this.frmUPSBrand.txtSchName.Text + "%";

            DataTable dtUPSBrands = srvUPSBrand.SearchByParameters(pmtUPSBrand);

            this.frmUPSBrand.grdSchSearch.DataSource = null;
            this.frmUPSBrand.grdSchSearch.DataSource = dtUPSBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.UPSBrand = new UPSBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveUPSBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUPSBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditUPSBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmUPSBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUPSBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
