
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
    public class BackupSoftwareBrandFormController
    {
        #region Attributes

        private BackupSoftwareBrandForm frmBackupSoftwareBrand;
        private BackupSoftwareBrand BackupSoftwareBrand;
        private IBackupSoftwareBrandService srvBackupSoftwareBrand;

        #endregion Attributes

        #region Constructor

        public BackupSoftwareBrandFormController(BackupSoftwareBrandForm instance)
        {
            this.frmBackupSoftwareBrand = instance;
            this.srvBackupSoftwareBrand = SamsaraAppContext.Resolve<IBackupSoftwareBrandService>();
            Assert.IsNotNull(this.srvBackupSoftwareBrand);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmBackupSoftwareBrand.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmBackupSoftwareBrand.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmBackupSoftwareBrand.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmBackupSoftwareBrand.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmBackupSoftwareBrand.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmBackupSoftwareBrand.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmBackupSoftwareBrand.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmBackupSoftwareBrand.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmBackupSoftwareBrand.HiddenDetail(!show);
            if (show)
                this.frmBackupSoftwareBrand.tabPrincipal.SelectedTab = this.frmBackupSoftwareBrand.tabPrincipal.TabPages["New"];
            else
                this.frmBackupSoftwareBrand.tabPrincipal.SelectedTab = this.frmBackupSoftwareBrand.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmBackupSoftwareBrand.txtDetName.Text == null || 
                this.frmBackupSoftwareBrand.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Marca de Software de Seguridad.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmBackupSoftwareBrand.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.BackupSoftwareBrand.Name = this.frmBackupSoftwareBrand.txtDetName.Text;
            this.BackupSoftwareBrand.Description = this.frmBackupSoftwareBrand.txtDetDescription.Text;

            this.BackupSoftwareBrand.Activated = true;
            this.BackupSoftwareBrand.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmBackupSoftwareBrand.txtDetName.Text = string.Empty;
            this.frmBackupSoftwareBrand.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmBackupSoftwareBrand.txtSchName.Text = string.Empty;
        }

        private void SaveBackupSoftwareBrand()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar la Marca de Software de Seguridad?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvBackupSoftwareBrand.SaveOrUpdate(this.BackupSoftwareBrand);
                this.frmBackupSoftwareBrand.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditBackupSoftwareBrand(int BackupSoftwareBrandId)
        {
            this.BackupSoftwareBrand = this.srvBackupSoftwareBrand.GetById(BackupSoftwareBrandId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmBackupSoftwareBrand.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmBackupSoftwareBrand.txtDetName.Text = this.BackupSoftwareBrand.Name;
            this.frmBackupSoftwareBrand.txtDetDescription.Text = this.BackupSoftwareBrand.Description;
        }

        private void DeleteEntity(int BackupSoftwareBrandId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Marca de Software de Seguridad?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.BackupSoftwareBrand = this.srvBackupSoftwareBrand.GetById(BackupSoftwareBrandId);
            this.BackupSoftwareBrand.Activated = false;
            this.BackupSoftwareBrand.Deleted = true;
            this.srvBackupSoftwareBrand.SaveOrUpdate(this.BackupSoftwareBrand);
            this.Search();
        }

        private void Search()
        {
            BackupSoftwareBrandParameters pmtBackupSoftwareBrand = new BackupSoftwareBrandParameters();

            pmtBackupSoftwareBrand.Name = "%" + this.frmBackupSoftwareBrand.txtSchName.Text + "%";

            DataTable dtBackupSoftwareBrands = srvBackupSoftwareBrand.SearchByParameters(pmtBackupSoftwareBrand);

            this.frmBackupSoftwareBrand.grdSchSearch.DataSource = null;
            this.frmBackupSoftwareBrand.grdSchSearch.DataSource = dtBackupSoftwareBrands;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.BackupSoftwareBrand = new BackupSoftwareBrand();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveBackupSoftwareBrand();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmBackupSoftwareBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditBackupSoftwareBrand(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmBackupSoftwareBrand.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmBackupSoftwareBrand.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
