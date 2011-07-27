
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.Support.Util;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class EndUserFormController
    {
        #region Attributes

        private EndUserForm frmEndUser;
        private EndUser endUser;
        private IEndUserService srvEndUser;
        private IDependencyService srvDependency;

        #endregion Attributes

        #region Constructor

        public EndUserFormController(EndUserForm instance)
        {
            this.frmEndUser = instance;
            this.srvEndUser = SamsaraAppContext.Resolve<IEndUserService>();
            Assert.IsNotNull(srvEndUser);
            this.srvDependency = SamsaraAppContext.Resolve<IDependencyService>();
            Assert.IsNotNull(srvDependency);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            // Dependency
            Dictionary<int, Dependency> dicDependencies = srvDependency.LoadDependencies();

            WindowsFormsUtil.LoadCombo<Dependency>(this.frmEndUser.uceSchDependency,
                dicDependencies.Values, "DependencyId", "Name");
            WindowsFormsUtil.LoadCombo<Dependency>(this.frmEndUser.uceDetDependency,
                dicDependencies.Values, "DependencyId", "Name");

            this.frmEndUser.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmEndUser.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmEndUser.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmEndUser.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmEndUser.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmEndUser.btnSchClear.Click += new EventHandler(btnSchClear_Click);

            this.frmEndUser.HiddenDetail(true);
        }

        private void ShowDetail(bool show)
        {
            this.frmEndUser.HiddenDetail(!show);
            if (show)
                this.frmEndUser.tabPrincipal.SelectedTab = this.frmEndUser.tabPrincipal.TabPages["New"];
            else
                this.frmEndUser.tabPrincipal.SelectedTab = this.frmEndUser.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmEndUser.txtDetName.Text == null || 
                this.frmEndUser.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Usuario Final.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmEndUser.txtDetName.Focus();
                return false;
            }

            if (this.frmEndUser.uceDetDependency.Value == null ||
                Convert.ToInt32(this.frmEndUser.uceDetDependency.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Dependencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmEndUser.uceDetDependency.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            if (Convert.ToInt32(this.frmEndUser.uceDetDependency.Value) > 0)
            {
                Dependency endUserType = srvDependency.LoadDependency(
                    Convert.ToInt32(this.frmEndUser.uceDetDependency.Value));
                Assert.IsNotNull(endUserType);
                this.endUser.Dependency = endUserType;
            }

            this.endUser.Name = this.frmEndUser.txtDetName.Text;

            this.endUser.Activated = true;
            this.endUser.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmEndUser.txtDetName.Text = string.Empty;
            this.frmEndUser.uceDetDependency.Value = -1;
        }

        private void ClearSearchControls()
        {
            this.frmEndUser.txtSchName.Text = string.Empty;
            this.frmEndUser.uceSchDependency.Value = -1;
        }

        private void SaveEndUser()
        {
            if (this.ValidateFormInformation())
            {
                this.LoadEntity();
                this.srvEndUser.SaveOrUpdateEndUser(this.endUser);
                this.frmEndUser.HiddenDetail(true);
            }
        }

        private void EditEndUser(int endUserId)
        {
            this.endUser = this.srvEndUser.LoadEndUser(endUserId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmEndUser.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmEndUser.txtDetName.Text = this.endUser.Name;
            this.frmEndUser.uceDetDependency.Value = this.endUser.Dependency.DependencyId;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            SearchEndUsersParameters pmtSearchEndUsers = new SearchEndUsersParameters();

            pmtSearchEndUsers.Name = "%" + this.frmEndUser.txtSchName.Text + "%";
            pmtSearchEndUsers.DependencyId = (int)this.frmEndUser.uceSchDependency.Value;

            DataTable dtEndUsers = srvEndUser.SearchEndUsers(pmtSearchEndUsers);

            this.frmEndUser.grdSchSearch.DataSource = null;
            this.frmEndUser.grdSchSearch.DataSource = dtEndUsers;
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.endUser = new EndUser();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveEndUser();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmEndUser.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditEndUser(Convert.ToInt32(activeRow.Cells["Column1"].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmEndUser.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }
        #endregion Events
    }
}
