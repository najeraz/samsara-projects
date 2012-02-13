
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Forms.Forms;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Forms.Controller
{
    public class UserGroupFormController
    {
        #region Attributes

        private UserGroupForm frmUserGroup;
        private UserGroup UserGroup;
        private IUserGroupService srvUserGroup;

        #endregion Attributes

        #region Constructor

        public UserGroupFormController(UserGroupForm instance)
        {
            this.frmUserGroup = instance;
            this.srvUserGroup = SamsaraAppContext.Resolve<IUserGroupService>();
            Assert.IsNotNull(this.srvUserGroup);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmUserGroup.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmUserGroup.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmUserGroup.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmUserGroup.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmUserGroup.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmUserGroup.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmUserGroup.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmUserGroup.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmUserGroup.HiddenDetail(!show);
            if (show)
                this.frmUserGroup.tabPrincipal.SelectedTab = this.frmUserGroup.tabPrincipal.TabPages["New"];
            else
                this.frmUserGroup.tabPrincipal.SelectedTab = this.frmUserGroup.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmUserGroup.txtDetName.Text == null || 
                this.frmUserGroup.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmUserGroup.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.UserGroup.Name = this.frmUserGroup.txtDetName.Text;
            this.UserGroup.Description = this.frmUserGroup.txtDetDescription.Text;

            this.UserGroup.Activated = true;
            this.UserGroup.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmUserGroup.txtDetName.Text = string.Empty;
            this.frmUserGroup.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmUserGroup.txtSchName.Text = string.Empty;
        }

        private void SaveUserGroup()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el UserGroup?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvUserGroup.SaveOrUpdate(this.UserGroup);
                this.frmUserGroup.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditUserGroup(int UserGroupId)
        {
            this.UserGroup = this.srvUserGroup.GetById(UserGroupId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmUserGroup.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmUserGroup.txtDetName.Text = this.UserGroup.Name;
            this.frmUserGroup.txtDetDescription.Text = this.UserGroup.Description;
        }

        private void DeleteEntity(int UserGroupId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.UserGroup = this.srvUserGroup.GetById(UserGroupId);
            this.UserGroup.Activated = false;
            this.UserGroup.Deleted = true;
            this.srvUserGroup.SaveOrUpdate(this.UserGroup);
            this.Search();
        }

        private void Search()
        {
            UserGroupParameters pmtUserGroup = new UserGroupParameters();

            pmtUserGroup.Name = "%" + this.frmUserGroup.txtSchName.Text + "%";

            DataTable dtUserGroups = srvUserGroup.SearchByParameters(pmtUserGroup);

            this.frmUserGroup.grdSchSearch.DataSource = null;
            this.frmUserGroup.grdSchSearch.DataSource = dtUserGroups;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.UserGroup = new UserGroup();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveUserGroup();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUserGroup.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditUserGroup(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmUserGroup.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmUserGroup.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
