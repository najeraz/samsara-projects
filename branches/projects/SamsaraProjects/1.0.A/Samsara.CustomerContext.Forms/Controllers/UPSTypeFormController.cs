
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
    public class UPSTypeFormController
    {
        #region Attributes

        private UPSTypeForm frmUPSType;
        private UPSType UPSType;
        private IUPSTypeService srvUPSType;

        #endregion Attributes

        #region Constructor

        public UPSTypeFormController(UPSTypeForm instance)
        {
            this.frmUPSType = instance;
            this.srvUPSType = SamsaraAppContext.Resolve<IUPSTypeService>();
            Assert.IsNotNull(this.srvUPSType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmUPSType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmUPSType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmUPSType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmUPSType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmUPSType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmUPSType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmUPSType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmUPSType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmUPSType.HiddenDetail(!show);
            if (show)
                this.frmUPSType.tabPrincipal.SelectedTab = this.frmUPSType.tabPrincipal.TabPages["New"];
            else
                this.frmUPSType.tabPrincipal.SelectedTab = this.frmUPSType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmUPSType.txtDetName.Text == null || 
                this.frmUPSType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmUPSType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.UPSType.Name = this.frmUPSType.txtDetName.Text;
            this.UPSType.Description = this.frmUPSType.txtDetDescription.Text;

            this.UPSType.Activated = true;
            this.UPSType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmUPSType.txtDetName.Text = string.Empty;
            this.frmUPSType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmUPSType.txtSchName.Text = string.Empty;
        }

        private void SaveUPSType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el UPSType?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvUPSType.SaveOrUpdate(this.UPSType);
                this.frmUPSType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditUPSType(int UPSTypeId)
        {
            this.UPSType = this.srvUPSType.GetById(UPSTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmUPSType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmUPSType.txtDetName.Text = this.UPSType.Name;
            this.frmUPSType.txtDetDescription.Text = this.UPSType.Description;
        }

        private void DeleteEntity(int UPSTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.UPSType = this.srvUPSType.GetById(UPSTypeId);
            this.UPSType.Activated = false;
            this.UPSType.Deleted = true;
            this.srvUPSType.SaveOrUpdate(this.UPSType);
            this.Search();
        }

        private void Search()
        {
            UPSTypeParameters pmtUPSType = new UPSTypeParameters();

            pmtUPSType.Name = "%" + this.frmUPSType.txtSchName.Text + "%";

            DataTable dtUPSTypes = srvUPSType.SearchByParameters(pmtUPSType);

            this.frmUPSType.grdSchSearch.DataSource = null;
            this.frmUPSType.grdSchSearch.DataSource = dtUPSTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.UPSType = new UPSType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveUPSType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUPSType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditUPSType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmUPSType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUPSType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
