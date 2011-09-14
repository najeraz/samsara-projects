
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
    public class CommutatorTypeFormController
    {
        #region Attributes

        private CommutatorTypeForm frmCommutatorType;
        private CommutatorType CommutatorType;
        private ICommutatorTypeService srvCommutatorType;

        #endregion Attributes

        #region Constructor

        public CommutatorTypeFormController(CommutatorTypeForm instance)
        {
            this.frmCommutatorType = instance;
            this.srvCommutatorType = SamsaraAppContext.Resolve<ICommutatorTypeService>();
            Assert.IsNotNull(this.srvCommutatorType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCommutatorType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCommutatorType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCommutatorType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCommutatorType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCommutatorType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCommutatorType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCommutatorType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCommutatorType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCommutatorType.HiddenDetail(!show);
            if (show)
                this.frmCommutatorType.tabPrincipal.SelectedTab = this.frmCommutatorType.tabPrincipal.TabPages["New"];
            else
                this.frmCommutatorType.tabPrincipal.SelectedTab = this.frmCommutatorType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCommutatorType.txtDetName.Text == null || 
                this.frmCommutatorType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Tipo de Conmutador.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCommutatorType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.CommutatorType.Name = this.frmCommutatorType.txtDetName.Text;
            this.CommutatorType.Description = this.frmCommutatorType.txtDetDescription.Text;

            this.CommutatorType.Activated = true;
            this.CommutatorType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCommutatorType.txtDetName.Text = string.Empty;
            this.frmCommutatorType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCommutatorType.txtSchName.Text = string.Empty;
        }

        private void SaveCommutatorType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Tipo de Conmutador?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCommutatorType.SaveOrUpdate(this.CommutatorType);
                this.frmCommutatorType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCommutatorType(int CommutatorTypeId)
        {
            this.CommutatorType = this.srvCommutatorType.GetById(CommutatorTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCommutatorType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCommutatorType.txtDetName.Text = this.CommutatorType.Name;
            this.frmCommutatorType.txtDetDescription.Text = this.CommutatorType.Description;
        }

        private void DeleteEntity(int CommutatorTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Tipo de Conmutador?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CommutatorType = this.srvCommutatorType.GetById(CommutatorTypeId);
            this.CommutatorType.Activated = false;
            this.CommutatorType.Deleted = true;
            this.srvCommutatorType.SaveOrUpdate(this.CommutatorType);
            this.Search();
        }

        private void Search()
        {
            CommutatorTypeParameters pmtCommutatorType = new CommutatorTypeParameters();

            pmtCommutatorType.Name = "%" + this.frmCommutatorType.txtSchName.Text + "%";

            DataTable dtCommutatorTypes = srvCommutatorType.SearchByParameters(pmtCommutatorType);

            this.frmCommutatorType.grdSchSearch.DataSource = null;
            this.frmCommutatorType.grdSchSearch.DataSource = dtCommutatorTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CommutatorType = new CommutatorType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCommutatorType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCommutatorType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCommutatorType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCommutatorType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCommutatorType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
