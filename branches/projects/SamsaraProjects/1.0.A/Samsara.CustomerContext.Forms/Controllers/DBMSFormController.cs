
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
    public class DBMSFormController
    {
        #region Attributes

        private DBMSForm frmDBMS;
        private DBMS DBMS;
        private IDBMSService srvDBMS;

        #endregion Attributes

        #region Constructor

        public DBMSFormController(DBMSForm instance)
        {
            this.frmDBMS = instance;
            this.srvDBMS = SamsaraAppContext.Resolve<IDBMSService>();
            Assert.IsNotNull(this.srvDBMS);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmDBMS.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmDBMS.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmDBMS.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmDBMS.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmDBMS.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmDBMS.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmDBMS.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmDBMS.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmDBMS.HiddenDetail(!show);
            if (show)
                this.frmDBMS.tabPrincipal.SelectedTab = this.frmDBMS.tabPrincipal.TabPages["New"];
            else
                this.frmDBMS.tabPrincipal.SelectedTab = this.frmDBMS.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmDBMS.txtDetName.Text == null || 
                this.frmDBMS.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el DBMS.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmDBMS.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.DBMS.Name = this.frmDBMS.txtDetName.Text;
            this.DBMS.Description = this.frmDBMS.txtDetDescription.Text;

            this.DBMS.Activated = true;
            this.DBMS.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmDBMS.txtDetName.Text = string.Empty;
            this.frmDBMS.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmDBMS.txtSchName.Text = string.Empty;
        }

        private void SaveDBMS()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el DBMS?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvDBMS.SaveOrUpdate(this.DBMS);
                this.frmDBMS.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditDBMS(int DBMSId)
        {
            this.DBMS = this.srvDBMS.GetById(DBMSId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmDBMS.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmDBMS.txtDetName.Text = this.DBMS.Name;
            this.frmDBMS.txtDetDescription.Text = this.DBMS.Description;
        }

        private void DeleteEntity(int DBMSId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el DBMS?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.DBMS = this.srvDBMS.GetById(DBMSId);
            this.DBMS.Activated = false;
            this.DBMS.Deleted = true;
            this.srvDBMS.SaveOrUpdate(this.DBMS);
            this.Search();
        }

        private void Search()
        {
            DBMSParameters pmtDBMS = new DBMSParameters();

            pmtDBMS.Name = "%" + this.frmDBMS.txtSchName.Text + "%";

            DataTable dtDBMSs = srvDBMS.SearchByParameters(pmtDBMS);

            this.frmDBMS.grdSchSearch.DataSource = null;
            this.frmDBMS.grdSchSearch.DataSource = dtDBMSs;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.DBMS = new DBMS();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveDBMS();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmDBMS.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditDBMS(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmDBMS.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmDBMS.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
