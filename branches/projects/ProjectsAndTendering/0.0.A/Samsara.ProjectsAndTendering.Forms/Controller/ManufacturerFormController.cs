
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class ManufacturerFormController
    {
        #region Attributes

        private ManufacturerForm frmManufacturer;
        private Manufacturer manufacturer;
        private IManufacturerService srvManufacturer;

        #endregion Attributes

        #region Constructor

        public ManufacturerFormController(ManufacturerForm instance)
        {
            this.frmManufacturer = instance;
            this.srvManufacturer = SamsaraAppContext.Resolve<IManufacturerService>();
            Assert.IsNotNull(srvManufacturer);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmManufacturer.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmManufacturer.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmManufacturer.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmManufacturer.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmManufacturer.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmManufacturer.btnSchClear.Click += new EventHandler(btnSchClear_Click);

            this.frmManufacturer.HiddenDetail(true);
        }

        private void ShowDetail(bool show)
        {
            this.frmManufacturer.HiddenDetail(!show);
            if (show)
                this.frmManufacturer.tabPrincipal.SelectedTab = this.frmManufacturer.tabPrincipal.TabPages["New"];
            else
                this.frmManufacturer.tabPrincipal.SelectedTab = this.frmManufacturer.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmManufacturer.txtDetName.Text == null ||
                this.frmManufacturer.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Fabricante.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmManufacturer.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.manufacturer.Name = this.frmManufacturer.txtDetName.Text;

            this.manufacturer.Activated = true;
            this.manufacturer.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmManufacturer.txtDetName.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmManufacturer.txtSchName.Text = string.Empty;
        }

        private void SaveManufacturer()
        {
            if (this.ValidateFormInformation())
            {
                this.LoadEntity();
                this.srvManufacturer.SaveOrUpdateManufacturer(this.manufacturer);
                this.frmManufacturer.HiddenDetail(true);
            }
        }

        private void EditManufacturer(int manufacturerId)
        {
            this.manufacturer = this.srvManufacturer.LoadManufacturer(manufacturerId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmManufacturer.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmManufacturer.txtDetName.Text = this.manufacturer.Name;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            SearchManufacturersParameters pmtSearchManufacturers = new SearchManufacturersParameters();

            pmtSearchManufacturers.Name = "%" + this.frmManufacturer.txtSchName.Text + "%";

            DataTable dtManufacturers = srvManufacturer.SearchManufacturers(pmtSearchManufacturers);

            this.frmManufacturer.grdSchSearch.DataSource = null;
            this.frmManufacturer.grdSchSearch.DataSource = dtManufacturers;
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.manufacturer = new Manufacturer();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveManufacturer();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmManufacturer.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditManufacturer(Convert.ToInt32(activeRow.Cells["Column1"].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmManufacturer.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }
        #endregion Events
    }
}
