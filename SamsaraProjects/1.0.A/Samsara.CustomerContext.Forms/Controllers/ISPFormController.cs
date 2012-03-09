
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
    public class ISPFormController
    {
        #region Attributes

        private ISPForm frmISP;
        private ISP ISP;
        private IISPService srvISP;

        #endregion Attributes

        #region Constructor

        public ISPFormController(ISPForm instance)
        {
            this.frmISP = instance;
            this.srvISP = SamsaraAppContext.Resolve<IISPService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmISP.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmISP.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmISP.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmISP.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmISP.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmISP.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmISP.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmISP.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmISP.HiddenDetail(!show);
            if (show)
                this.frmISP.tabPrincipal.SelectedTab = this.frmISP.tabPrincipal.TabPages["New"];
            else
                this.frmISP.tabPrincipal.SelectedTab = this.frmISP.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmISP.txtDetName.Text == null || 
                this.frmISP.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el ISP.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmISP.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.ISP.Name = this.frmISP.txtDetName.Text;
            this.ISP.Description = this.frmISP.txtDetDescription.Text;

            this.ISP.Activated = true;
            this.ISP.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmISP.txtDetName.Text = string.Empty;
            this.frmISP.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmISP.txtSchName.Text = string.Empty;
        }

        private void SaveISP()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el ISP?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvISP.SaveOrUpdate(this.ISP);
                this.frmISP.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditISP(int ISPId)
        {
            this.ISP = this.srvISP.GetById(ISPId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmISP.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmISP.txtDetName.Text = this.ISP.Name;
            this.frmISP.txtDetDescription.Text = this.ISP.Description;
        }

        private void DeleteEntity(int ISPId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el ISP?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.ISP = this.srvISP.GetById(ISPId);
            this.ISP.Activated = false;
            this.ISP.Deleted = true;
            this.srvISP.SaveOrUpdate(this.ISP);
            this.Search();
        }

        private void Search()
        {
            ISPParameters pmtISP = new ISPParameters();

            pmtISP.Name = "%" + this.frmISP.txtSchName.Text + "%";

            DataTable dtISPs = srvISP.SearchByParameters(pmtISP);

            this.frmISP.grdSchSearch.DataSource = null;
            this.frmISP.grdSchSearch.DataSource = dtISPs;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.ISP = new ISP();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveISP();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmISP.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditISP(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmISP.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmISP.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
