
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
    public class TelephonyLineTypeFormController
    {
        #region Attributes

        private TelephonyLineTypeForm frmTelephonyLineType;
        private TelephonyLineType TelephonyLineType;
        private ITelephonyLineTypeService srvTelephonyLineType;

        #endregion Attributes

        #region Constructor

        public TelephonyLineTypeFormController(TelephonyLineTypeForm instance)
        {
            this.frmTelephonyLineType = instance;
            this.srvTelephonyLineType = SamsaraAppContext.Resolve<ITelephonyLineTypeService>();
            Assert.IsNotNull(this.srvTelephonyLineType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmTelephonyLineType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmTelephonyLineType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmTelephonyLineType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmTelephonyLineType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmTelephonyLineType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmTelephonyLineType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmTelephonyLineType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmTelephonyLineType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmTelephonyLineType.HiddenDetail(!show);
            if (show)
                this.frmTelephonyLineType.tabPrincipal.SelectedTab = this.frmTelephonyLineType.tabPrincipal.TabPages["New"];
            else
                this.frmTelephonyLineType.tabPrincipal.SelectedTab = this.frmTelephonyLineType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmTelephonyLineType.txtDetName.Text == null || 
                this.frmTelephonyLineType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Linea Telefónica.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmTelephonyLineType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.TelephonyLineType.Name = this.frmTelephonyLineType.txtDetName.Text;
            this.TelephonyLineType.Description = this.frmTelephonyLineType.txtDetDescription.Text;

            this.TelephonyLineType.Activated = true;
            this.TelephonyLineType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmTelephonyLineType.txtDetName.Text = string.Empty;
            this.frmTelephonyLineType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmTelephonyLineType.txtSchName.Text = string.Empty;
        }

        private void SaveTelephonyLineType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Linea Telefónica?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvTelephonyLineType.SaveOrUpdate(this.TelephonyLineType);
                this.frmTelephonyLineType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditTelephonyLineType(int TelephonyLineTypeId)
        {
            this.TelephonyLineType = this.srvTelephonyLineType.GetById(TelephonyLineTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmTelephonyLineType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmTelephonyLineType.txtDetName.Text = this.TelephonyLineType.Name;
            this.frmTelephonyLineType.txtDetDescription.Text = this.TelephonyLineType.Description;
        }

        private void DeleteEntity(int TelephonyLineTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Linea Telefónica?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.TelephonyLineType = this.srvTelephonyLineType.GetById(TelephonyLineTypeId);
            this.TelephonyLineType.Activated = false;
            this.TelephonyLineType.Deleted = true;
            this.srvTelephonyLineType.SaveOrUpdate(this.TelephonyLineType);
            this.Search();
        }

        private void Search()
        {
            TelephonyLineTypeParameters pmtTelephonyLineType = new TelephonyLineTypeParameters();

            pmtTelephonyLineType.Name = "%" + this.frmTelephonyLineType.txtSchName.Text + "%";

            DataTable dtTelephonyLineTypes = srvTelephonyLineType.SearchByParameters(pmtTelephonyLineType);

            this.frmTelephonyLineType.grdSchSearch.DataSource = null;
            this.frmTelephonyLineType.grdSchSearch.DataSource = dtTelephonyLineTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.TelephonyLineType = new TelephonyLineType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveTelephonyLineType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTelephonyLineType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditTelephonyLineType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmTelephonyLineType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmTelephonyLineType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
