
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class WarrantyFormController
    {
        #region Attributes

        private WarrantyForm frmWarranty;
        private Warranty Warranty;
        private IWarrantyService srvWarranty;

        #endregion Attributes

        #region Constructor

        public WarrantyFormController(WarrantyForm instance)
        {
            this.frmWarranty = instance;
            this.srvWarranty = SamsaraAppContext.Resolve<IWarrantyService>();
            Assert.IsNotNull(this.srvWarranty);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmWarranty.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmWarranty.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmWarranty.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmWarranty.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmWarranty.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmWarranty.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmWarranty.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmWarranty.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmWarranty.HiddenDetail(!show);
            if (show)
                this.frmWarranty.tabPrincipal.SelectedTab = this.frmWarranty.tabPrincipal.TabPages["New"];
            else
                this.frmWarranty.tabPrincipal.SelectedTab = this.frmWarranty.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmWarranty.txtDetName.Text == null || 
                this.frmWarranty.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la fianza.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmWarranty.txtDetName.Focus();
                return false;
            }

            if (this.frmWarranty.uceDetWarrantyType.Value == null ||
                Convert.ToInt32(this.frmWarranty.uceDetWarrantyType.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el tipo de fianza.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmWarranty.uceDetWarrantyType.Focus();
                return false;
            }

            if (this.frmWarranty.uceDetDocumentTypeWarranty.Value == null ||
                Convert.ToInt32(this.frmWarranty.uceDetDocumentTypeWarranty.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el tipo de documento de la fianza.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmWarranty.uceDetDocumentTypeWarranty.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.Warranty.Name = this.frmWarranty.txtDetName.Text;
            this.Warranty.Description = this.frmWarranty.txtDetDescription.Text;

            this.Warranty.Activated = true;
            this.Warranty.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmWarranty.txtDetName.Text = string.Empty;
            this.frmWarranty.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmWarranty.txtSchName.Text = string.Empty;
        }

        private void SaveWarranty()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Warranty?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvWarranty.SaveOrUpdate(this.Warranty);
                this.frmWarranty.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditWarranty(int WarrantyId)
        {
            this.Warranty = this.srvWarranty.GetById(WarrantyId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmWarranty.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmWarranty.txtDetName.Text = this.Warranty.Name;
            this.frmWarranty.txtDetDescription.Text = this.Warranty.Description;
        }

        private void DeleteEntity(int WarrantyId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;
            this.Warranty = this.srvWarranty.GetById(WarrantyId);
            this.Warranty.Activated = false;
            this.Warranty.Deleted = true;
            this.srvWarranty.SaveOrUpdate(this.Warranty);
            this.Search();
        }

        private void Search()
        {
            WarrantyParameters pmtWarranty = new WarrantyParameters();

            pmtWarranty.Name = "%" + this.frmWarranty.txtSchName.Text + "%";

            DataTable dtWarrantys = srvWarranty.SearchByParameters(pmtWarranty);

            this.frmWarranty.grdSchSearch.DataSource = null;
            this.frmWarranty.grdSchSearch.DataSource = dtWarrantys;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.Warranty = new Warranty();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveWarranty();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmWarranty.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditWarranty(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmWarranty.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmWarranty.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
