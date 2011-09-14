
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
    public class DocumentTypeWarrantyFormController
    {
        #region Attributes

        private DocumentTypeWarrantyForm frmDocumentTypeWarranty;
        private DocumentTypeWarranty DocumentTypeWarranty;
        private IDocumentTypeWarrantyService srvDocumentTypeWarranty;

        #endregion Attributes

        #region Constructor

        public DocumentTypeWarrantyFormController(DocumentTypeWarrantyForm instance)
        {
            this.frmDocumentTypeWarranty = instance;
            this.srvDocumentTypeWarranty = SamsaraAppContext.Resolve<IDocumentTypeWarrantyService>();
            Assert.IsNotNull(this.srvDocumentTypeWarranty);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmDocumentTypeWarranty.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmDocumentTypeWarranty.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmDocumentTypeWarranty.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmDocumentTypeWarranty.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmDocumentTypeWarranty.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmDocumentTypeWarranty.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmDocumentTypeWarranty.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmDocumentTypeWarranty.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmDocumentTypeWarranty.HiddenDetail(!show);
            if (show)
                this.frmDocumentTypeWarranty.tabPrincipal.SelectedTab = this.frmDocumentTypeWarranty.tabPrincipal.TabPages["New"];
            else
                this.frmDocumentTypeWarranty.tabPrincipal.SelectedTab = this.frmDocumentTypeWarranty.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmDocumentTypeWarranty.txtDetName.Text == null || 
                this.frmDocumentTypeWarranty.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el tipo de documento de la fianza.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmDocumentTypeWarranty.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.DocumentTypeWarranty.Name = this.frmDocumentTypeWarranty.txtDetName.Text;
            this.DocumentTypeWarranty.Description = this.frmDocumentTypeWarranty.txtDetDescription.Text;

            this.DocumentTypeWarranty.Activated = true;
            this.DocumentTypeWarranty.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmDocumentTypeWarranty.txtDetName.Text = string.Empty;
            this.frmDocumentTypeWarranty.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmDocumentTypeWarranty.txtSchName.Text = string.Empty;
        }

        private void SaveDocumentTypeWarranty()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el tipo de documento de la fianza?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvDocumentTypeWarranty.SaveOrUpdate(this.DocumentTypeWarranty);
                this.frmDocumentTypeWarranty.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditDocumentTypeWarranty(int DocumentTypeWarrantyId)
        {
            this.DocumentTypeWarranty = this.srvDocumentTypeWarranty.GetById(DocumentTypeWarrantyId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmDocumentTypeWarranty.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmDocumentTypeWarranty.txtDetName.Text = this.DocumentTypeWarranty.Name;
            this.frmDocumentTypeWarranty.txtDetDescription.Text = this.DocumentTypeWarranty.Description;
        }

        private void DeleteEntity(int DocumentTypeWarrantyId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el tipo de Documento de Fianza?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.DocumentTypeWarranty = this.srvDocumentTypeWarranty.GetById(DocumentTypeWarrantyId);
            this.DocumentTypeWarranty.Activated = false;
            this.DocumentTypeWarranty.Deleted = true;
            this.srvDocumentTypeWarranty.SaveOrUpdate(this.DocumentTypeWarranty);
            this.Search();
        }

        private void Search()
        {
            DocumentTypeWarrantyParameters pmtDocumentTypeWarranty = new DocumentTypeWarrantyParameters();

            pmtDocumentTypeWarranty.Name = "%" + this.frmDocumentTypeWarranty.txtSchName.Text + "%";

            DataTable dtDocumentTypeWarrantys = srvDocumentTypeWarranty.SearchByParameters(pmtDocumentTypeWarranty);

            this.frmDocumentTypeWarranty.grdSchSearch.DataSource = null;
            this.frmDocumentTypeWarranty.grdSchSearch.DataSource = dtDocumentTypeWarrantys;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.DocumentTypeWarranty = new DocumentTypeWarranty();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveDocumentTypeWarranty();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmDocumentTypeWarranty.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditDocumentTypeWarranty(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmDocumentTypeWarranty.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmDocumentTypeWarranty.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
