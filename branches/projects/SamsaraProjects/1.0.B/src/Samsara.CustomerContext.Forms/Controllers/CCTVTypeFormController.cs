
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
    public class CCTVTypeFormController
    {
        #region Attributes

        private CCTVTypeForm frmCCTVType;
        private CCTVType CCTVType;
        private ICCTVTypeService srvCCTVType;

        #endregion Attributes

        #region Constructor

        public CCTVTypeFormController(CCTVTypeForm instance)
        {
            this.frmCCTVType = instance;
            this.srvCCTVType = SamsaraAppContext.Resolve<ICCTVTypeService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmCCTVType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmCCTVType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmCCTVType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmCCTVType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmCCTVType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmCCTVType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmCCTVType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmCCTVType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmCCTVType.HiddenDetail(!show);
            if (show)
                this.frmCCTVType.tabPrincipal.SelectedTab = this.frmCCTVType.tabPrincipal.TabPages["New"];
            else
                this.frmCCTVType.tabPrincipal.SelectedTab = this.frmCCTVType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmCCTVType.txtDetName.Text == null || 
                this.frmCCTVType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Tipo de CCTV.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCCTVType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.CCTVType.Name = this.frmCCTVType.txtDetName.Text;
            this.CCTVType.Description = this.frmCCTVType.txtDetDescription.Text;

            this.CCTVType.Activated = true;
            this.CCTVType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmCCTVType.txtDetName.Text = string.Empty;
            this.frmCCTVType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmCCTVType.txtSchName.Text = string.Empty;
        }

        private void SaveCCTVType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Tipo de CCTV?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvCCTVType.SaveOrUpdate(this.CCTVType);
                this.frmCCTVType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditCCTVType(int CCTVTypeId)
        {
            this.CCTVType = this.srvCCTVType.GetById(CCTVTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmCCTVType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmCCTVType.txtDetName.Text = this.CCTVType.Name;
            this.frmCCTVType.txtDetDescription.Text = this.CCTVType.Description;
        }

        private void DeleteEntity(int CCTVTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Tipo de CCTV?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.CCTVType = this.srvCCTVType.GetById(CCTVTypeId);
            this.CCTVType.Activated = false;
            this.CCTVType.Deleted = true;
            this.srvCCTVType.SaveOrUpdate(this.CCTVType);
            this.Search();
        }

        private void Search()
        {
            CCTVTypeParameters pmtCCTVType = new CCTVTypeParameters();

            pmtCCTVType.Name = "%" + this.frmCCTVType.txtSchName.Text + "%";

            DataTable dtCCTVTypes = srvCCTVType.SearchByParameters(pmtCCTVType);

            this.frmCCTVType.grdSchSearch.DataSource = null;
            this.frmCCTVType.grdSchSearch.DataSource = dtCCTVTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.CCTVType = new CCTVType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveCCTVType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCCTVType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditCCTVType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmCCTVType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmCCTVType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
