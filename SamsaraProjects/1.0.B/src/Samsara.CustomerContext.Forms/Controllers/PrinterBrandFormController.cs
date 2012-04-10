
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
    public class PrinterBrandFormController
    {
        #region Attributes

        private PrinterBrandForm frmPrinterBrand;
        private PrinterBrand PrinterBrand;
        private IPrinterBrandService srvPrinterBrand;

        #endregion Attributes

        #region Constructor

        public PrinterBrandFormController(PrinterBrandForm instance)
        {
            this.frmPrinterBrand = instance;
            this.srvPrinterBrand = SamsaraAppContext.Resolve<IPrinterBrandService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmPrinterBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmPrinterBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmPrinterBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmPrinterBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmPrinterBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmPrinterBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmPrinterBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmPrinterBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmPrinterBrand.HiddenDetail(!show);
            if (show)
                this.frmPrinterBrand.tabPrincipal.SelectedTab = this.frmPrinterBrand.tabPrincipal.TabPages["New"];
            else
                this.frmPrinterBrand.tabPrincipal.SelectedTab = this.frmPrinterBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmPrinterBrand.txtDetName.Text == null || 
                this.frmPrinterBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Marca de Impresora.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmPrinterBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.PrinterBrand.Name = this.frmPrinterBrand.txtDetName.Text;
            this.PrinterBrand.Description = this.frmPrinterBrand.txtDetDescription.Text;

            this.PrinterBrand.Activated = true;
            this.PrinterBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmPrinterBrand.txtDetName.Text = string.Empty;
            this.frmPrinterBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmPrinterBrand.txtSchName.Text = string.Empty;
        }

        private void SavePrinterBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Marca de Impresora?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvPrinterBrand.SaveOrUpdate(this.PrinterBrand);
                this.frmPrinterBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditPrinterBrand(int PrinterBrandId)
        {
            this.PrinterBrand = this.srvPrinterBrand.GetById(PrinterBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmPrinterBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmPrinterBrand.txtDetName.Text = this.PrinterBrand.Name;
            this.frmPrinterBrand.txtDetDescription.Text = this.PrinterBrand.Description;
        }

        private void DeleteEntity(int PrinterBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Marca de Impresora?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.PrinterBrand = this.srvPrinterBrand.GetById(PrinterBrandId);
            this.PrinterBrand.Activated = false;
            this.PrinterBrand.Deleted = true;
            this.srvPrinterBrand.SaveOrUpdate(this.PrinterBrand);
            this.Search();
        }

        private void Search()
        {
            PrinterBrandParameters pmtPrinterBrand = new PrinterBrandParameters();

            pmtPrinterBrand.Name = "%" + this.frmPrinterBrand.txtSchName.Text + "%";

            DataTable dtPrinterBrands = srvPrinterBrand.SearchByParameters(pmtPrinterBrand);

            this.frmPrinterBrand.grdSchSearch.DataSource = null;
            this.frmPrinterBrand.grdSchSearch.DataSource = dtPrinterBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.PrinterBrand = new PrinterBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SavePrinterBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmPrinterBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditPrinterBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmPrinterBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmPrinterBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
