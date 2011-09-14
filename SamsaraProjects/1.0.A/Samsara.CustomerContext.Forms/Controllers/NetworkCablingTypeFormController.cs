
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
    public class NetworkCablingTypeFormController
    {
        #region Attributes

        private NetworkCablingTypeForm frmNetworkCablingType;
        private NetworkCablingType NetworkCablingType;
        private INetworkCablingTypeService srvNetworkCablingType;

        #endregion Attributes

        #region Constructor

        public NetworkCablingTypeFormController(NetworkCablingTypeForm instance)
        {
            this.frmNetworkCablingType = instance;
            this.srvNetworkCablingType = SamsaraAppContext.Resolve<INetworkCablingTypeService>();
            Assert.IsNotNull(this.srvNetworkCablingType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmNetworkCablingType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmNetworkCablingType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmNetworkCablingType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmNetworkCablingType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmNetworkCablingType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmNetworkCablingType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmNetworkCablingType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmNetworkCablingType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmNetworkCablingType.HiddenDetail(!show);
            if (show)
                this.frmNetworkCablingType.tabPrincipal.SelectedTab = this.frmNetworkCablingType.tabPrincipal.TabPages["New"];
            else
                this.frmNetworkCablingType.tabPrincipal.SelectedTab = this.frmNetworkCablingType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmNetworkCablingType.txtDetName.Text == null || 
                this.frmNetworkCablingType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Tipo de Cableado.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmNetworkCablingType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.NetworkCablingType.Name = this.frmNetworkCablingType.txtDetName.Text;
            this.NetworkCablingType.Description = this.frmNetworkCablingType.txtDetDescription.Text;

            this.NetworkCablingType.Activated = true;
            this.NetworkCablingType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmNetworkCablingType.txtDetName.Text = string.Empty;
            this.frmNetworkCablingType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmNetworkCablingType.txtSchName.Text = string.Empty;
        }

        private void SaveNetworkCablingType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Tipo de Cableado?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvNetworkCablingType.SaveOrUpdate(this.NetworkCablingType);
                this.frmNetworkCablingType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditNetworkCablingType(int NetworkCablingTypeId)
        {
            this.NetworkCablingType = this.srvNetworkCablingType.GetById(NetworkCablingTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmNetworkCablingType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmNetworkCablingType.txtDetName.Text = this.NetworkCablingType.Name;
            this.frmNetworkCablingType.txtDetDescription.Text = this.NetworkCablingType.Description;
        }

        private void DeleteEntity(int NetworkCablingTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Tipo de Cableado?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.NetworkCablingType = this.srvNetworkCablingType.GetById(NetworkCablingTypeId);
            this.NetworkCablingType.Activated = false;
            this.NetworkCablingType.Deleted = true;
            this.srvNetworkCablingType.SaveOrUpdate(this.NetworkCablingType);
            this.Search();
        }

        private void Search()
        {
            NetworkCablingTypeParameters pmtNetworkCablingType = new NetworkCablingTypeParameters();

            pmtNetworkCablingType.Name = "%" + this.frmNetworkCablingType.txtSchName.Text + "%";

            DataTable dtNetworkCablingTypes = srvNetworkCablingType.SearchByParameters(pmtNetworkCablingType);

            this.frmNetworkCablingType.grdSchSearch.DataSource = null;
            this.frmNetworkCablingType.grdSchSearch.DataSource = dtNetworkCablingTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.NetworkCablingType = new NetworkCablingType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveNetworkCablingType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmNetworkCablingType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditNetworkCablingType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmNetworkCablingType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmNetworkCablingType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
