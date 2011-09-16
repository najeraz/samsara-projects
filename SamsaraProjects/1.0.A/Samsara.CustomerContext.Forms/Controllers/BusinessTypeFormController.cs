
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
    public class BusinessTypeFormController
    {
        #region Attributes

        private BusinessTypeForm frmBusinessType;
        private BusinessType BusinessType;
        private IBusinessTypeService srvBusinessType;

        #endregion Attributes

        #region Constructor

        public BusinessTypeFormController(BusinessTypeForm instance)
        {
            this.frmBusinessType = instance;
            this.srvBusinessType = SamsaraAppContext.Resolve<IBusinessTypeService>();
            Assert.IsNotNull(this.srvBusinessType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmBusinessType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmBusinessType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmBusinessType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmBusinessType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmBusinessType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmBusinessType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmBusinessType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmBusinessType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmBusinessType.HiddenDetail(!show);
            if (show)
                this.frmBusinessType.tabPrincipal.SelectedTab = this.frmBusinessType.tabPrincipal.TabPages["New"];
            else
                this.frmBusinessType.tabPrincipal.SelectedTab = this.frmBusinessType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmBusinessType.txtDetName.Text == null || 
                this.frmBusinessType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmBusinessType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.BusinessType.Name = this.frmBusinessType.txtDetName.Text;
            this.BusinessType.Description = this.frmBusinessType.txtDetDescription.Text;

            this.BusinessType.Activated = true;
            this.BusinessType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmBusinessType.txtDetName.Text = string.Empty;
            this.frmBusinessType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmBusinessType.txtSchName.Text = string.Empty;
        }

        private void SaveBusinessType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el BusinessType?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvBusinessType.SaveOrUpdate(this.BusinessType);
                this.frmBusinessType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditBusinessType(int BusinessTypeId)
        {
            this.BusinessType = this.srvBusinessType.GetById(BusinessTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmBusinessType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmBusinessType.txtDetName.Text = this.BusinessType.Name;
            this.frmBusinessType.txtDetDescription.Text = this.BusinessType.Description;
        }

        private void DeleteEntity(int BusinessTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.BusinessType = this.srvBusinessType.GetById(BusinessTypeId);
            this.BusinessType.Activated = false;
            this.BusinessType.Deleted = true;
            this.srvBusinessType.SaveOrUpdate(this.BusinessType);
            this.Search();
        }

        private void Search()
        {
            BusinessTypeParameters pmtBusinessType = new BusinessTypeParameters();

            pmtBusinessType.Name = "%" + this.frmBusinessType.txtSchName.Text + "%";

            DataTable dtBusinessTypes = srvBusinessType.SearchByParameters(pmtBusinessType);

            this.frmBusinessType.grdSchSearch.DataSource = null;
            this.frmBusinessType.grdSchSearch.DataSource = dtBusinessTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.BusinessType = new BusinessType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveBusinessType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmBusinessType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditBusinessType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmBusinessType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmBusinessType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
