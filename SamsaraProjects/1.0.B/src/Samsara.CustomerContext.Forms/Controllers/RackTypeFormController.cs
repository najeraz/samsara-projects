
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
    public class RackTypeFormController
    {
        #region Attributes

        private RackTypeForm frmRackType;
        private RackType RackType;
        private IRackTypeService srvRackType;

        #endregion Attributes

        #region Constructor

        public RackTypeFormController(RackTypeForm instance)
        {
            this.frmRackType = instance;
            this.srvRackType = SamsaraAppContext.Resolve<IRackTypeService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmRackType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmRackType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmRackType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmRackType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmRackType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmRackType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmRackType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmRackType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmRackType.HiddenDetail(!show);
            if (show)
                this.frmRackType.tabPrincipal.SelectedTab = this.frmRackType.tabPrincipal.TabPages["New"];
            else
                this.frmRackType.tabPrincipal.SelectedTab = this.frmRackType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmRackType.txtDetName.Text == null || 
                this.frmRackType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Tipo de Rack.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmRackType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.RackType.Name = this.frmRackType.txtDetName.Text;
            this.RackType.Description = this.frmRackType.txtDetDescription.Text;

            this.RackType.Activated = true;
            this.RackType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmRackType.txtDetName.Text = string.Empty;
            this.frmRackType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmRackType.txtSchName.Text = string.Empty;
        }

        private void SaveRackType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Tipo de Rack?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvRackType.SaveOrUpdate(this.RackType);
                this.frmRackType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditRackType(int RackTypeId)
        {
            this.RackType = this.srvRackType.GetById(RackTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmRackType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmRackType.txtDetName.Text = this.RackType.Name;
            this.frmRackType.txtDetDescription.Text = this.RackType.Description;
        }

        private void DeleteEntity(int RackTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Tipo de Rack?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.RackType = this.srvRackType.GetById(RackTypeId);
            this.RackType.Activated = false;
            this.RackType.Deleted = true;
            this.srvRackType.SaveOrUpdate(this.RackType);
            this.Search();
        }

        private void Search()
        {
            RackTypeParameters pmtRackType = new RackTypeParameters();

            pmtRackType.Name = "%" + this.frmRackType.txtSchName.Text + "%";

            DataTable dtRackTypes = srvRackType.SearchByParameters(pmtRackType);

            this.frmRackType.grdSchSearch.DataSource = null;
            this.frmRackType.grdSchSearch.DataSource = dtRackTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.RackType = new RackType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveRackType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmRackType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditRackType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmRackType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmRackType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
