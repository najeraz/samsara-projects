
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Forms.Forms;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Framework.Core.Constants;
using Samsara.Framework.Util;

namespace Samsara.CustomerContext.Forms.Controller
{
    public class OperativeSystemFormController
    {
        #region Attributes

        private OperativeSystemForm frmOperativeSystem;
        private OperativeSystem OperativeSystem;
        private IOperativeSystemService srvOperativeSystem;
        private IOperativeSystemTypeService srvOperativeSystemType;

        #endregion Attributes

        #region Constructor

        public OperativeSystemFormController(OperativeSystemForm instance)
        {
            this.frmOperativeSystem = instance;
            this.srvOperativeSystem = SamsaraAppContext.Resolve<IOperativeSystemService>();
            this.srvOperativeSystemType = SamsaraAppContext.Resolve<IOperativeSystemTypeService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            // OperativeSystemType
            OperativeSystemTypeParameters pmtOperativeSystemType = new OperativeSystemTypeParameters();
            pmtOperativeSystemType.OperativeSystemTypeId = ParameterConstants.IntDefault;
            IList<OperativeSystemType> lstDependencies =
                srvOperativeSystemType.GetListByParameters(pmtOperativeSystemType);

            WindowsFormsUtil.LoadCombo<OperativeSystemType>(this.frmOperativeSystem.uceSchOperativeSystemType,
                lstDependencies, "OperativeSystemTypeId", "Name", "Seleccione", false);
            WindowsFormsUtil.LoadCombo<OperativeSystemType>(this.frmOperativeSystem.uceDetOperativeSystemType,
                lstDependencies, "OperativeSystemTypeId", "Name", "Seleccione", false);

            this.frmOperativeSystem.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmOperativeSystem.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmOperativeSystem.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmOperativeSystem.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmOperativeSystem.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmOperativeSystem.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmOperativeSystem.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmOperativeSystem.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmOperativeSystem.HiddenDetail(!show);
            if (show)
                this.frmOperativeSystem.tabPrincipal.SelectedTab = this.frmOperativeSystem.tabPrincipal.TabPages["New"];
            else
                this.frmOperativeSystem.tabPrincipal.SelectedTab = this.frmOperativeSystem.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmOperativeSystem.txtDetName.Text == null || 
                this.frmOperativeSystem.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Sistema Operativo.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmOperativeSystem.txtDetName.Focus();
                return false;
            }

            if (this.frmOperativeSystem.uceDetOperativeSystemType.Value == null ||
                Convert.ToInt32(this.frmOperativeSystem.uceDetOperativeSystemType.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo de Sistema Operativo.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmOperativeSystem.uceDetOperativeSystemType.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.OperativeSystem.Name = this.frmOperativeSystem.txtDetName.Text;
            this.OperativeSystem.Description = this.frmOperativeSystem.txtDetDescription.Text;
            this.OperativeSystem.OperativeSystemType = this.srvOperativeSystemType.GetById(
                Convert.ToInt32(this.frmOperativeSystem.uceDetOperativeSystemType.Value));

            this.OperativeSystem.Activated = true;
            this.OperativeSystem.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmOperativeSystem.txtDetName.Text = string.Empty;
            this.frmOperativeSystem.txtDetDescription.Text = string.Empty;
            this.frmOperativeSystem.uceDetOperativeSystemType.Value = -1;
        }

        private void ClearSearchControls()
        {
            this.frmOperativeSystem.txtSchName.Text = string.Empty;
        }

        private void SaveOperativeSystem()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Sistema Operativo?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvOperativeSystem.SaveOrUpdate(this.OperativeSystem);
                this.frmOperativeSystem.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditOperativeSystem(int OperativeSystemId)
        {
            this.OperativeSystem = this.srvOperativeSystem.GetById(OperativeSystemId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmOperativeSystem.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmOperativeSystem.txtDetName.Text = this.OperativeSystem.Name;
            this.frmOperativeSystem.txtDetDescription.Text = this.OperativeSystem.Description;
            this.frmOperativeSystem.uceDetOperativeSystemType.Value = this.OperativeSystem.OperativeSystemType.OperativeSystemTypeId;
        }

        private void DeleteEntity(int OperativeSystemId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Sistema Operativo?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.OperativeSystem = this.srvOperativeSystem.GetById(OperativeSystemId);
            this.OperativeSystem.Activated = false;
            this.OperativeSystem.Deleted = true;
            this.srvOperativeSystem.SaveOrUpdate(this.OperativeSystem);
            this.Search();
        }

        private void Search()
        {
            OperativeSystemParameters pmtOperativeSystem = new OperativeSystemParameters();

            pmtOperativeSystem.Name = "%" + this.frmOperativeSystem.txtSchName.Text + "%";

            DataTable dtOperativeSystems = srvOperativeSystem.SearchByParameters(pmtOperativeSystem);

            this.frmOperativeSystem.grdSchSearch.DataSource = null;
            this.frmOperativeSystem.grdSchSearch.DataSource = dtOperativeSystems;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.OperativeSystem = new OperativeSystem();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveOperativeSystem();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmOperativeSystem.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditOperativeSystem(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmOperativeSystem.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmOperativeSystem.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
