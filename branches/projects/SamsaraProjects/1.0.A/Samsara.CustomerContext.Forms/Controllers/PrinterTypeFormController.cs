
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
    public class PrinterTypeFormController
    {
        #region Attributes

        private PrinterTypeForm frmPrinterType;
        private PrinterType PrinterType;
        private IPrinterTypeService srvPrinterType;

        #endregion Attributes

        #region Constructor

        public PrinterTypeFormController(PrinterTypeForm instance)
        {
            this.frmPrinterType = instance;
            this.srvPrinterType = SamsaraAppContext.Resolve<IPrinterTypeService>();
            Assert.IsNotNull(this.srvPrinterType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmPrinterType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmPrinterType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmPrinterType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmPrinterType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmPrinterType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmPrinterType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmPrinterType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmPrinterType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmPrinterType.HiddenDetail(!show);
            if (show)
                this.frmPrinterType.tabPrincipal.SelectedTab = this.frmPrinterType.tabPrincipal.TabPages["New"];
            else
                this.frmPrinterType.tabPrincipal.SelectedTab = this.frmPrinterType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmPrinterType.txtDetName.Text == null || 
                this.frmPrinterType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Tipo de Impresora.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmPrinterType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.PrinterType.Name = this.frmPrinterType.txtDetName.Text;
            this.PrinterType.Description = this.frmPrinterType.txtDetDescription.Text;

            this.PrinterType.Activated = true;
            this.PrinterType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmPrinterType.txtDetName.Text = string.Empty;
            this.frmPrinterType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmPrinterType.txtSchName.Text = string.Empty;
        }

        private void SavePrinterType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Tipo de Impresora?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvPrinterType.SaveOrUpdate(this.PrinterType);
                this.frmPrinterType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditPrinterType(int PrinterTypeId)
        {
            this.PrinterType = this.srvPrinterType.GetById(PrinterTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmPrinterType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmPrinterType.txtDetName.Text = this.PrinterType.Name;
            this.frmPrinterType.txtDetDescription.Text = this.PrinterType.Description;
        }

        private void DeleteEntity(int PrinterTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Tipo de Impresora?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.PrinterType = this.srvPrinterType.GetById(PrinterTypeId);
            this.PrinterType.Activated = false;
            this.PrinterType.Deleted = true;
            this.srvPrinterType.SaveOrUpdate(this.PrinterType);
            this.Search();
        }

        private void Search()
        {
            PrinterTypeParameters pmtPrinterType = new PrinterTypeParameters();

            pmtPrinterType.Name = "%" + this.frmPrinterType.txtSchName.Text + "%";

            DataTable dtPrinterTypes = srvPrinterType.SearchByParameters(pmtPrinterType);

            this.frmPrinterType.grdSchSearch.DataSource = null;
            this.frmPrinterType.grdSchSearch.DataSource = dtPrinterTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.PrinterType = new PrinterType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SavePrinterType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmPrinterType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditPrinterType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmPrinterType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmPrinterType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
