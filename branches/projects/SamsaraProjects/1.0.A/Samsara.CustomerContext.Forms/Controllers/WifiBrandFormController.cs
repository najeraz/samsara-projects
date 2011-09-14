
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
    public class WifiBrandFormController
    {
        #region Attributes

        private WifiBrandForm frmWifiBrand;
        private WifiBrand WifiBrand;
        private IWifiBrandService srvWifiBrand;

        #endregion Attributes

        #region Constructor

        public WifiBrandFormController(WifiBrandForm instance)
        {
            this.frmWifiBrand = instance;
            this.srvWifiBrand = SamsaraAppContext.Resolve<IWifiBrandService>();
            Assert.IsNotNull(this.srvWifiBrand);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmWifiBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmWifiBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmWifiBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmWifiBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmWifiBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmWifiBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmWifiBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmWifiBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmWifiBrand.HiddenDetail(!show);
            if (show)
                this.frmWifiBrand.tabPrincipal.SelectedTab = this.frmWifiBrand.tabPrincipal.TabPages["New"];
            else
                this.frmWifiBrand.tabPrincipal.SelectedTab = this.frmWifiBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmWifiBrand.txtDetName.Text == null || 
                this.frmWifiBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmWifiBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.WifiBrand.Name = this.frmWifiBrand.txtDetName.Text;
            this.WifiBrand.Description = this.frmWifiBrand.txtDetDescription.Text;

            this.WifiBrand.Activated = true;
            this.WifiBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmWifiBrand.txtDetName.Text = string.Empty;
            this.frmWifiBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmWifiBrand.txtSchName.Text = string.Empty;
        }

        private void SaveWifiBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el WifiBrand?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvWifiBrand.SaveOrUpdate(this.WifiBrand);
                this.frmWifiBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditWifiBrand(int WifiBrandId)
        {
            this.WifiBrand = this.srvWifiBrand.GetById(WifiBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmWifiBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmWifiBrand.txtDetName.Text = this.WifiBrand.Name;
            this.frmWifiBrand.txtDetDescription.Text = this.WifiBrand.Description;
        }

        private void DeleteEntity(int WifiBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Marca de red Inalámbrica?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.WifiBrand = this.srvWifiBrand.GetById(WifiBrandId);
            this.WifiBrand.Activated = false;
            this.WifiBrand.Deleted = true;
            this.srvWifiBrand.SaveOrUpdate(this.WifiBrand);
            this.Search();
        }

        private void Search()
        {
            WifiBrandParameters pmtWifiBrand = new WifiBrandParameters();

            pmtWifiBrand.Name = "%" + this.frmWifiBrand.txtSchName.Text + "%";

            DataTable dtWifiBrands = srvWifiBrand.SearchByParameters(pmtWifiBrand);

            this.frmWifiBrand.grdSchSearch.DataSource = null;
            this.frmWifiBrand.grdSchSearch.DataSource = dtWifiBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.WifiBrand = new WifiBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveWifiBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmWifiBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditWifiBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmWifiBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmWifiBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
