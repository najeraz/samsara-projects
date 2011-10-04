
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
    public class AccessPointTypeFormController
    {
        #region Attributes

        private AccessPointTypeForm frmAccessPointType;
        private AccessPointType AccessPointType;
        private IAccessPointTypeService srvAccessPointType;

        #endregion Attributes

        #region Constructor

        public AccessPointTypeFormController(AccessPointTypeForm instance)
        {
            this.frmAccessPointType = instance;
            this.srvAccessPointType = SamsaraAppContext.Resolve<IAccessPointTypeService>();
            Assert.IsNotNull(this.srvAccessPointType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmAccessPointType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmAccessPointType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmAccessPointType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmAccessPointType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmAccessPointType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmAccessPointType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmAccessPointType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmAccessPointType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmAccessPointType.HiddenDetail(!show);
            if (show)
                this.frmAccessPointType.tabPrincipal.SelectedTab = this.frmAccessPointType.tabPrincipal.TabPages["New"];
            else
                this.frmAccessPointType.tabPrincipal.SelectedTab = this.frmAccessPointType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmAccessPointType.txtDetName.Text == null || 
                this.frmAccessPointType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmAccessPointType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.AccessPointType.Name = this.frmAccessPointType.txtDetName.Text;
            this.AccessPointType.Description = this.frmAccessPointType.txtDetDescription.Text;

            this.AccessPointType.Activated = true;
            this.AccessPointType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmAccessPointType.txtDetName.Text = string.Empty;
            this.frmAccessPointType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmAccessPointType.txtSchName.Text = string.Empty;
        }

        private void SaveAccessPointType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el AccessPointType?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvAccessPointType.SaveOrUpdate(this.AccessPointType);
                this.frmAccessPointType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditAccessPointType(int AccessPointTypeId)
        {
            this.AccessPointType = this.srvAccessPointType.GetById(AccessPointTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmAccessPointType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmAccessPointType.txtDetName.Text = this.AccessPointType.Name;
            this.frmAccessPointType.txtDetDescription.Text = this.AccessPointType.Description;
        }

        private void DeleteEntity(int AccessPointTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.AccessPointType = this.srvAccessPointType.GetById(AccessPointTypeId);
            this.AccessPointType.Activated = false;
            this.AccessPointType.Deleted = true;
            this.srvAccessPointType.SaveOrUpdate(this.AccessPointType);
            this.Search();
        }

        private void Search()
        {
            AccessPointTypeParameters pmtAccessPointType = new AccessPointTypeParameters();

            pmtAccessPointType.Name = "%" + this.frmAccessPointType.txtSchName.Text + "%";

            DataTable dtAccessPointTypes = srvAccessPointType.SearchByParameters(pmtAccessPointType);

            this.frmAccessPointType.grdSchSearch.DataSource = null;
            this.frmAccessPointType.grdSchSearch.DataSource = dtAccessPointTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.AccessPointType = new AccessPointType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveAccessPointType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmAccessPointType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditAccessPointType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmAccessPointType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmAccessPointType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
