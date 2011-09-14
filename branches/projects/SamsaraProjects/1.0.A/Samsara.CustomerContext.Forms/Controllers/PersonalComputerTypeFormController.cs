
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
    public class PersonalComputerTypeFormController
    {
        #region Attributes

        private PersonalComputerTypeForm frmPersonalComputerType;
        private PersonalComputerType PersonalComputerType;
        private IPersonalComputerTypeService srvPersonalComputerType;

        #endregion Attributes

        #region Constructor

        public PersonalComputerTypeFormController(PersonalComputerTypeForm instance)
        {
            this.frmPersonalComputerType = instance;
            this.srvPersonalComputerType = SamsaraAppContext.Resolve<IPersonalComputerTypeService>();
            Assert.IsNotNull(this.srvPersonalComputerType);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmPersonalComputerType.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmPersonalComputerType.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmPersonalComputerType.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmPersonalComputerType.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmPersonalComputerType.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmPersonalComputerType.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmPersonalComputerType.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmPersonalComputerType.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmPersonalComputerType.HiddenDetail(!show);
            if (show)
                this.frmPersonalComputerType.tabPrincipal.SelectedTab = this.frmPersonalComputerType.tabPrincipal.TabPages["New"];
            else
                this.frmPersonalComputerType.tabPrincipal.SelectedTab = this.frmPersonalComputerType.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmPersonalComputerType.txtDetName.Text == null || 
                this.frmPersonalComputerType.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Tipo de Computadora.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmPersonalComputerType.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.PersonalComputerType.Name = this.frmPersonalComputerType.txtDetName.Text;
            this.PersonalComputerType.Description = this.frmPersonalComputerType.txtDetDescription.Text;

            this.PersonalComputerType.Activated = true;
            this.PersonalComputerType.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmPersonalComputerType.txtDetName.Text = string.Empty;
            this.frmPersonalComputerType.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmPersonalComputerType.txtSchName.Text = string.Empty;
        }

        private void SavePersonalComputerType()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Tipo de Computadora?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvPersonalComputerType.SaveOrUpdate(this.PersonalComputerType);
                this.frmPersonalComputerType.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditPersonalComputerType(int PersonalComputerTypeId)
        {
            this.PersonalComputerType = this.srvPersonalComputerType.GetById(PersonalComputerTypeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmPersonalComputerType.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmPersonalComputerType.txtDetName.Text = this.PersonalComputerType.Name;
            this.frmPersonalComputerType.txtDetDescription.Text = this.PersonalComputerType.Description;
        }

        private void DeleteEntity(int PersonalComputerTypeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Tipo de Computadora?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.PersonalComputerType = this.srvPersonalComputerType.GetById(PersonalComputerTypeId);
            this.PersonalComputerType.Activated = false;
            this.PersonalComputerType.Deleted = true;
            this.srvPersonalComputerType.SaveOrUpdate(this.PersonalComputerType);
            this.Search();
        }

        private void Search()
        {
            PersonalComputerTypeParameters pmtPersonalComputerType = new PersonalComputerTypeParameters();

            pmtPersonalComputerType.Name = "%" + this.frmPersonalComputerType.txtSchName.Text + "%";

            DataTable dtPersonalComputerTypes = srvPersonalComputerType.SearchByParameters(pmtPersonalComputerType);

            this.frmPersonalComputerType.grdSchSearch.DataSource = null;
            this.frmPersonalComputerType.grdSchSearch.DataSource = dtPersonalComputerTypes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.PersonalComputerType = new PersonalComputerType();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SavePersonalComputerType();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmPersonalComputerType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditPersonalComputerType(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmPersonalComputerType.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmPersonalComputerType.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
