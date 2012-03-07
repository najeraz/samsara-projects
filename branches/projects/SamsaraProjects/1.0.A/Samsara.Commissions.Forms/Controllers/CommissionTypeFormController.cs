
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Commissions.Core.Entities;
using Samsara.Commissions.Core.Parameters;
using Samsara.Commissions.Forms.Forms;
using Samsara.Commissions.Service.Interfaces;

namespace Samsara.Commissions.Forms.Controller
{
    public class CommissionTypeFormController
    {
        #region Attributes

        private CommissionTypeForm frmCommissionType;
        private CommissionType CommissionType;
        private ICommissionTypeService srvCommissionType;

        #endregion Attributes

        #region Constructor

        public CommissionTypeFormController(CommissionTypeForm instance)
        {
            this.frmCommissionType = instance;
            this.srvCommissionType = SamsaraAppContext.Resolve<ICommissionTypeService>();
            Assert.IsNotNull(this.srvCommissionType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCommissionType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCommissionType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCommissionType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCommissionType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCommissionType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCommissionType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCommissionType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCommissionType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCommissionType.HiddenDetail(!show);
            if (show)
                this.frmCommissionType.tabPrincipal.SelectedTab = this.frmCommissionType.tabPrincipal.TabPages["New"];
            else
                this.frmCommissionType.tabPrincipal.SelectedTab = this.frmCommissionType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCommissionType.txtDetName.Text == null || 
                this.frmCommissionType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCommissionType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.CommissionType.Name = this.frmCommissionType.txtDetName.Text;
            this.CommissionType.Description = this.frmCommissionType.txtDetDescription.Text;

            this.CommissionType.Activated = true;
            this.CommissionType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCommissionType.txtDetName.Text = string.Empty;
            this.frmCommissionType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCommissionType.txtSchName.Text = string.Empty;
        }

        private void SaveCommissionType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el CommissionType?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCommissionType.SaveOrUpdate(this.CommissionType);
                this.frmCommissionType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCommissionType(int CommissionTypeId)
        {
            this.CommissionType = this.srvCommissionType.GetById(CommissionTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCommissionType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCommissionType.txtDetName.Text = this.CommissionType.Name;
            this.frmCommissionType.txtDetDescription.Text = this.CommissionType.Description;
        }

        private void DeleteEntity(int CommissionTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CommissionType = this.srvCommissionType.GetById(CommissionTypeId);
            this.CommissionType.Activated = false;
            this.CommissionType.Deleted = true;
            this.srvCommissionType.SaveOrUpdate(this.CommissionType);
            this.Search();
        }

        private void Search()
        {
            CommissionTypeParameters pmtCommissionType = new CommissionTypeParameters();

            pmtCommissionType.Name = "%" + this.frmCommissionType.txtSchName.Text + "%";

            DataTable dtCommissionTypes = srvCommissionType.SearchByParameters(pmtCommissionType);

            this.frmCommissionType.grdSchSearch.DataSource = null;
            this.frmCommissionType.grdSchSearch.DataSource = dtCommissionTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CommissionType = new CommissionType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCommissionType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCommissionType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCommissionType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCommissionType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCommissionType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
