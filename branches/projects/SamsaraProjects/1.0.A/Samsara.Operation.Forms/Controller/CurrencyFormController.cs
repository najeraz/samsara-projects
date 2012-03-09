
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;
using Samsara.Operation.Forms.Forms;
using Samsara.Operation.Service.Interfaces;

namespace Samsara.Operation.Forms.Controller
{
    public class CurrencyFormController
    {
        #region Attributes

        private CurrencyForm frmCurrency;
        private Currency Currency;
        private ICurrencyService srvCurrency;

        #endregion Attributes

        #region Constructor

        public CurrencyFormController(CurrencyForm instance)
        {
            this.frmCurrency = instance;
            this.srvCurrency = SamsaraAppContext.Resolve<ICurrencyService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCurrency.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCurrency.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCurrency.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCurrency.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCurrency.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCurrency.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCurrency.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCurrency.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCurrency.HiddenDetail(!show);
            if (show)
                this.frmCurrency.tabPrincipal.SelectedTab = this.frmCurrency.tabPrincipal.TabPages["New"];
            else
                this.frmCurrency.tabPrincipal.SelectedTab = this.frmCurrency.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCurrency.txtDetName.Text == null ||
                this.frmCurrency.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la moneda.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCurrency.txtDetName.Focus();
                return false;
            }

            if (this.frmCurrency.txtDetCode.Text == null ||
                this.frmCurrency.txtDetCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un código para la moneda.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCurrency.txtDetCode.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.Currency.Name = this.frmCurrency.txtDetName.Text;
            this.Currency.Code = this.frmCurrency.txtDetCode.Text;
            this.Currency.Description = this.frmCurrency.txtDetDescription.Text;
            this.Currency.IsDefault = this.frmCurrency.uchkDetIsDefault.Checked;

            this.Currency.Activated = true;
            this.Currency.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCurrency.txtDetCode.Text = string.Empty;
            this.frmCurrency.txtDetName.Text = string.Empty;
            this.frmCurrency.txtDetDescription.Text = string.Empty;
            this.frmCurrency.uchkDetIsDefault.Checked = false;
        }

        private void ClearSearchControls()
        {
            this.frmCurrency.txtSchName.Text = string.Empty;
            this.frmCurrency.txtSchCode.Text = string.Empty;
        }

        private void SaveCurrency()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Moneda?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCurrency.SaveOrUpdate(this.Currency);
                this.frmCurrency.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCurrency(int CurrencyId)
        {
            this.Currency = this.srvCurrency.GetById(CurrencyId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCurrency.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCurrency.txtDetCode.Text = this.Currency.Code;
            this.frmCurrency.txtDetName.Text = this.Currency.Name;
            this.frmCurrency.txtDetDescription.Text = this.Currency.Description;
            this.frmCurrency.uchkDetIsDefault.Checked = this.Currency.IsDefault;
        }

        private void DeleteEntity(int CurrencyId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Moneda?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.Currency = this.srvCurrency.GetById(CurrencyId);
            this.Currency.Activated = false;
            this.Currency.Deleted = true;
            this.srvCurrency.SaveOrUpdate(this.Currency);
            this.Search();
        }

        private void Search()
        {
            CurrencyParameters pmtCurrency = new CurrencyParameters();

            pmtCurrency.Code = "%" + this.frmCurrency.txtSchCode.Text + "%";
            pmtCurrency.Name = "%" + this.frmCurrency.txtSchName.Text + "%";

            DataTable dtCurrencys = srvCurrency.SearchByParameters(pmtCurrency);

            this.frmCurrency.grdSchSearch.DataSource = null;
            this.frmCurrency.grdSchSearch.DataSource = dtCurrencys;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.Currency = new Currency();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCurrency();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCurrency.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCurrency(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCurrency.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCurrency.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
