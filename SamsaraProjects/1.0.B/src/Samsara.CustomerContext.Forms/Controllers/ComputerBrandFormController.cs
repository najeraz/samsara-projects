
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
    public class ComputerBrandFormController
    {
        #region Attributes

        private ComputerBrandForm frmComputerBrand;
        private ComputerBrand ComputerBrand;
        private IComputerBrandService srvComputerBrand;

        #endregion Attributes

        #region Constructor

        public ComputerBrandFormController(ComputerBrandForm instance)
        {
            this.frmComputerBrand = instance;
            this.srvComputerBrand = SamsaraAppContext.Resolve<IComputerBrandService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmComputerBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmComputerBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmComputerBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmComputerBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmComputerBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmComputerBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmComputerBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmComputerBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmComputerBrand.HiddenDetail(!show);
            if (show)
                this.frmComputerBrand.tabPrincipal.SelectedTab = this.frmComputerBrand.tabPrincipal.TabPages["New"];
            else
                this.frmComputerBrand.tabPrincipal.SelectedTab = this.frmComputerBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmComputerBrand.txtDetName.Text == null || 
                this.frmComputerBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Marca de Computadora.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmComputerBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.ComputerBrand.Name = this.frmComputerBrand.txtDetName.Text;
            this.ComputerBrand.Description = this.frmComputerBrand.txtDetDescription.Text;

            this.ComputerBrand.Activated = true;
            this.ComputerBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmComputerBrand.txtDetName.Text = string.Empty;
            this.frmComputerBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmComputerBrand.txtSchName.Text = string.Empty;
        }

        private void SaveComputerBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Marca de Computadora?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvComputerBrand.SaveOrUpdate(this.ComputerBrand);
                this.frmComputerBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditComputerBrand(int ComputerBrandId)
        {
            this.ComputerBrand = this.srvComputerBrand.GetById(ComputerBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmComputerBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmComputerBrand.txtDetName.Text = this.ComputerBrand.Name;
            this.frmComputerBrand.txtDetDescription.Text = this.ComputerBrand.Description;
        }

        private void DeleteEntity(int ComputerBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Marca de Computadora?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.ComputerBrand = this.srvComputerBrand.GetById(ComputerBrandId);
            this.ComputerBrand.Activated = false;
            this.ComputerBrand.Deleted = true;
            this.srvComputerBrand.SaveOrUpdate(this.ComputerBrand);
            this.Search();
        }

        private void Search()
        {
            ComputerBrandParameters pmtComputerBrand = new ComputerBrandParameters();

            pmtComputerBrand.Name = "%" + this.frmComputerBrand.txtSchName.Text + "%";

            DataTable dtComputerBrands = srvComputerBrand.SearchByParameters(pmtComputerBrand);

            this.frmComputerBrand.grdSchSearch.DataSource = null;
            this.frmComputerBrand.grdSchSearch.DataSource = dtComputerBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.ComputerBrand = new ComputerBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveComputerBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmComputerBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditComputerBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmComputerBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmComputerBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
