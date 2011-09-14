
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class WarrantyTypeFormController
    {
        #region Attributes

        private WarrantyTypeForm frmWarrantyType;
        private WarrantyType WarrantyType;
        private IWarrantyTypeService srvWarrantyType;

        #endregion Attributes

        #region Constructor

        public WarrantyTypeFormController(WarrantyTypeForm instance)
        {
            this.frmWarrantyType = instance;
            this.srvWarrantyType = SamsaraAppContext.Resolve<IWarrantyTypeService>();
            Assert.IsNotNull(this.srvWarrantyType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmWarrantyType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmWarrantyType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmWarrantyType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmWarrantyType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmWarrantyType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmWarrantyType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmWarrantyType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmWarrantyType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmWarrantyType.HiddenDetail(!show);
            if (show)
                this.frmWarrantyType.tabPrincipal.SelectedTab = this.frmWarrantyType.tabPrincipal.TabPages["New"];
            else
                this.frmWarrantyType.tabPrincipal.SelectedTab = this.frmWarrantyType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmWarrantyType.txtDetName.Text == null || 
                this.frmWarrantyType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el tipo de fianza.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmWarrantyType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.WarrantyType.Name = this.frmWarrantyType.txtDetName.Text;
            this.WarrantyType.Description = this.frmWarrantyType.txtDetDescription.Text;

            this.WarrantyType.Activated = true;
            this.WarrantyType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmWarrantyType.txtDetName.Text = string.Empty;
            this.frmWarrantyType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmWarrantyType.txtSchName.Text = string.Empty;
        }

        private void SaveWarrantyType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el tipo de propuesta?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvWarrantyType.SaveOrUpdate(this.WarrantyType);
                this.frmWarrantyType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditWarrantyType(int WarrantyTypeId)
        {
            this.WarrantyType = this.srvWarrantyType.GetById(WarrantyTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmWarrantyType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmWarrantyType.txtDetName.Text = this.WarrantyType.Name;
            this.frmWarrantyType.txtDetDescription.Text = this.WarrantyType.Description;
        }

        private void DeleteEntity(int WarrantyTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el tipo de Fianza?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.WarrantyType = this.srvWarrantyType.GetById(WarrantyTypeId);
            this.WarrantyType.Activated = false;
            this.WarrantyType.Deleted = true;
            this.srvWarrantyType.SaveOrUpdate(this.WarrantyType);
            this.Search();
        }

        private void Search()
        {
            WarrantyTypeParameters pmtWarrantyType = new WarrantyTypeParameters();

            pmtWarrantyType.Name = "%" + this.frmWarrantyType.txtSchName.Text + "%";

            DataTable dtWarrantyTypes = srvWarrantyType.SearchByParameters(pmtWarrantyType);

            this.frmWarrantyType.grdSchSearch.DataSource = null;
            this.frmWarrantyType.grdSchSearch.DataSource = dtWarrantyTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.WarrantyType = new WarrantyType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveWarrantyType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmWarrantyType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditWarrantyType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmWarrantyType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmWarrantyType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
