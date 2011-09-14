
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
    public class OperativeSystemTypeFormController
    {
        #region Attributes

        private OperativeSystemTypeForm frmOperativeSystemType;
        private OperativeSystemType OperativeSystemType;
        private IOperativeSystemTypeService srvOperativeSystemType;

        #endregion Attributes

        #region Constructor

        public OperativeSystemTypeFormController(OperativeSystemTypeForm instance)
        {
            this.frmOperativeSystemType = instance;
            this.srvOperativeSystemType = SamsaraAppContext.Resolve<IOperativeSystemTypeService>();
            Assert.IsNotNull(this.srvOperativeSystemType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmOperativeSystemType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmOperativeSystemType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmOperativeSystemType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmOperativeSystemType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmOperativeSystemType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmOperativeSystemType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmOperativeSystemType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmOperativeSystemType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmOperativeSystemType.HiddenDetail(!show);
            if (show)
                this.frmOperativeSystemType.tabPrincipal.SelectedTab = this.frmOperativeSystemType.tabPrincipal.TabPages["New"];
            else
                this.frmOperativeSystemType.tabPrincipal.SelectedTab = this.frmOperativeSystemType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmOperativeSystemType.txtDetName.Text == null || 
                this.frmOperativeSystemType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Tipo de Sistema Operativo.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmOperativeSystemType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.OperativeSystemType.Name = this.frmOperativeSystemType.txtDetName.Text;
            this.OperativeSystemType.Description = this.frmOperativeSystemType.txtDetDescription.Text;

            this.OperativeSystemType.Activated = true;
            this.OperativeSystemType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmOperativeSystemType.txtDetName.Text = string.Empty;
            this.frmOperativeSystemType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmOperativeSystemType.txtSchName.Text = string.Empty;
        }

        private void SaveOperativeSystemType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Tipo de Sistema Operativo?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvOperativeSystemType.SaveOrUpdate(this.OperativeSystemType);
                this.frmOperativeSystemType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditOperativeSystemType(int OperativeSystemTypeId)
        {
            this.OperativeSystemType = this.srvOperativeSystemType.GetById(OperativeSystemTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmOperativeSystemType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmOperativeSystemType.txtDetName.Text = this.OperativeSystemType.Name;
            this.frmOperativeSystemType.txtDetDescription.Text = this.OperativeSystemType.Description;
        }

        private void DeleteEntity(int OperativeSystemTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Tipo de Sistema Operativo?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.OperativeSystemType = this.srvOperativeSystemType.GetById(OperativeSystemTypeId);
            this.OperativeSystemType.Activated = false;
            this.OperativeSystemType.Deleted = true;
            this.srvOperativeSystemType.SaveOrUpdate(this.OperativeSystemType);
            this.Search();
        }

        private void Search()
        {
            OperativeSystemTypeParameters pmtOperativeSystemType = new OperativeSystemTypeParameters();

            pmtOperativeSystemType.Name = "%" + this.frmOperativeSystemType.txtSchName.Text + "%";

            DataTable dtOperativeSystemTypes = srvOperativeSystemType.SearchByParameters(pmtOperativeSystemType);

            this.frmOperativeSystemType.grdSchSearch.DataSource = null;
            this.frmOperativeSystemType.grdSchSearch.DataSource = dtOperativeSystemTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.OperativeSystemType = new OperativeSystemType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveOperativeSystemType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmOperativeSystemType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditOperativeSystemType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmOperativeSystemType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmOperativeSystemType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
