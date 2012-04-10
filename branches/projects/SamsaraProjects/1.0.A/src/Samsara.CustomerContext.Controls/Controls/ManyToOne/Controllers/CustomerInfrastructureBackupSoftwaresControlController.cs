
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Controls.Controllers;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Framework.Core.Constants;
using Samsara.Framework.Util;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers
{
    public class CustomerInfrastructureBackupSoftwaresControlController : ManyToOneLevel1ControlController<CustomerInfrastructureBackupSoftware>
    {
        #region Attributes

        private ICustomerInfrastructureBackupSoftwareService srvCustomerInfrastructureBackupSoftware;
        private CustomerInfrastructureBackupSoftwaresControl controlCustomerInfrastructureBackupSoftwares;
        private CustomerInfrastructureBackupSoftware customerInfrastructureBackupSoftware;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private IBackupSoftwareBrandService srvBackupSoftwareBrand;
        private ICustomerInfrastructureServerComputerService srvCustomerInfrastructureServerComputer;

        private DataTable dtCustomerInfrastructureBackupSoftwares;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructure CustomerInfrastructure
        {
            get;
            set;
        }

        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructureBackupSoftwaresControlController(
            CustomerInfrastructureBackupSoftwaresControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureBackupSoftwares = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureBackupSoftware = SamsaraAppContext.Resolve<ICustomerInfrastructureBackupSoftwareService>();
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                this.srvBackupSoftwareBrand = SamsaraAppContext.Resolve<IBackupSoftwareBrandService>();
                this.srvCustomerInfrastructureServerComputer = SamsaraAppContext.Resolve<ICustomerInfrastructureServerComputerService>();
            }

            this.InitializeControlControls();
        }

        #endregion Constructor

        #region Methods

        #region Private

        private void InitializeControlControls()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                BackupSoftwareBrandParameters pmtBackupSoftwareBrand = new BackupSoftwareBrandParameters();

                this.controlCustomerInfrastructureBackupSoftwares.bsbcBackupSoftwareBrand.Parameters = pmtBackupSoftwareBrand;
                this.controlCustomerInfrastructureBackupSoftwares.bsbcBackupSoftwareBrand.Refresh();

                this.controlCustomerInfrastructureBackupSoftwares.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureBackupSoftwareParameters pmtCustomerInfrastructureBackupSoftware
                = new CustomerInfrastructureBackupSoftwareParameters();

            pmtCustomerInfrastructureBackupSoftware.CustomerInfrastructureId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureBackupSoftwares = this.srvCustomerInfrastructureBackupSoftware
                .SearchByParameters(pmtCustomerInfrastructureBackupSoftware);

            this.controlCustomerInfrastructureBackupSoftwares.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureBackupSoftwares.grdRelations.DataSource = this.dtCustomerInfrastructureBackupSoftwares;

            if (this.CustomerInfrastructure != null)
            {
                CustomerInfrastructureServerComputerParameters pmtCustomerInfrastructureServerComputer
                    = new CustomerInfrastructureServerComputerParameters();

                pmtCustomerInfrastructureServerComputer.CustomerInfrastructureId = this.CustomerInfrastructure.CustomerInfrastructureId;

                this.controlCustomerInfrastructureBackupSoftwares.cisccCustomerInfrastructureServerComputer.Parameters
                    = pmtCustomerInfrastructureServerComputer;
                this.controlCustomerInfrastructureBackupSoftwares.cisccCustomerInfrastructureServerComputer.DisplayMember
                    = "ServerModel";
                this.controlCustomerInfrastructureBackupSoftwares.cisccCustomerInfrastructureServerComputer.Refresh();
                
                foreach (CustomerInfrastructureBackupSoftware customerInfrastructureBackupSoftware
                    in this.CustomerInfrastructure.CustomerInfrastructureBackupSoftwares)
                {
                    DataRow row = this.dtCustomerInfrastructureBackupSoftwares.NewRow();
                    this.dtCustomerInfrastructureBackupSoftwares.Rows.Add(row);

                    row["CustomerInfrastructureBackupSoftwareId"] 
                        = customerInfrastructureBackupSoftware.CustomerInfrastructureBackupSoftwareId;
                    row["BackupSoftwareBrandId"] = customerInfrastructureBackupSoftware.BackupSoftwareBrand.BackupSoftwareBrandId;

                    if (customerInfrastructureBackupSoftware.CustomerInfrastructureServerComputer == null)
                        row["CustomerInfrastructureServerComputerId"] = DBNull.Value;
                    else
                        row["CustomerInfrastructureServerComputerId"] = customerInfrastructureBackupSoftware
                            .CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerId;

                    row["Description"] = customerInfrastructureBackupSoftware.Description;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureBackupSoftwares.bsbcBackupSoftwareBrand.Value = null;
            this.controlCustomerInfrastructureBackupSoftwares.cisccCustomerInfrastructureServerComputer.Value = null;
            this.controlCustomerInfrastructureBackupSoftwares.txtDescription.Text = string.Empty;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureBackupSoftwares.Rows.Clear();
            this.dtCustomerInfrastructureBackupSoftwares.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureBackupSoftware = new CustomerInfrastructureBackupSoftware();

            this.customerInfrastructureBackupSoftware.CustomerInfrastructure = this.CustomerInfrastructure;
            this.customerInfrastructureBackupSoftware.Activated = true;
            this.customerInfrastructureBackupSoftware.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
            this.customerInfrastructureBackupSoftware = this.CustomerInfrastructure
                .CustomerInfrastructureBackupSoftwares
                .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureBackupSoftware = this.CustomerInfrastructure
                .CustomerInfrastructureBackupSoftwares
                    .Single(x => x.CustomerInfrastructureBackupSoftwareId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructure.CustomerInfrastructureBackupSoftwares
                    .Remove(this.customerInfrastructureBackupSoftware);
            else
            {
                this.customerInfrastructureBackupSoftware.Activated = false;
                this.customerInfrastructureBackupSoftware.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureBackupSoftware = this.CustomerInfrastructure
                    .CustomerInfrastructureBackupSoftwares
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureBackupSoftware = this.CustomerInfrastructure
                .CustomerInfrastructureBackupSoftwares
                    .Single(x => x.CustomerInfrastructureBackupSoftwareId == entityId);

            this.controlCustomerInfrastructureBackupSoftwares.bsbcBackupSoftwareBrand.Value
                = this.customerInfrastructureBackupSoftware.BackupSoftwareBrand;

            this.controlCustomerInfrastructureBackupSoftwares.cisccCustomerInfrastructureServerComputer.Value
                = this.customerInfrastructureBackupSoftware.CustomerInfrastructureServerComputer;

            this.controlCustomerInfrastructureBackupSoftwares.txtDescription.Value
                = this.customerInfrastructureBackupSoftware.Description;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureBackupSoftware.BackupSoftwareBrand 
                = this.controlCustomerInfrastructureBackupSoftwares.bsbcBackupSoftwareBrand.Value;

            this.customerInfrastructureBackupSoftware.CustomerInfrastructureServerComputer
                = this.controlCustomerInfrastructureBackupSoftwares.cisccCustomerInfrastructureServerComputer.Value;

            this.customerInfrastructureBackupSoftware.Description
                = this.controlCustomerInfrastructureBackupSoftwares.txtDescription.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureBackupSoftwares.bsbcBackupSoftwareBrand.Value == null)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Software.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureBackupSoftwares.bsbcBackupSoftwareBrand.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureBackupSoftware.CustomerInfrastructureBackupSoftwareId == -1)
                row = this.dtCustomerInfrastructureBackupSoftwares.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureBackupSoftwareId"])
                       == -(this.customerInfrastructureBackupSoftware as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureBackupSoftwares.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureBackupSoftwareId"])
                        == this.customerInfrastructureBackupSoftware.CustomerInfrastructureBackupSoftwareId);

            if (row == null)
            {
                this.CustomerInfrastructure.CustomerInfrastructureBackupSoftwares
                    .Add(this.customerInfrastructureBackupSoftware);

                row = this.dtCustomerInfrastructureBackupSoftwares.NewRow();
                this.dtCustomerInfrastructureBackupSoftwares.Rows.Add(row);
            }

            if (this.customerInfrastructureBackupSoftware.CustomerInfrastructureBackupSoftwareId == -1)
                row["CustomerInfrastructureBackupSoftwareId"] = -(this.customerInfrastructureBackupSoftware as object).GetHashCode();
            else
                row["CustomerInfrastructureBackupSoftwareId"] = this.customerInfrastructureBackupSoftware
                    .CustomerInfrastructureBackupSoftwareId;

            row["BackupSoftwareBrandId"] = this.customerInfrastructureBackupSoftware.BackupSoftwareBrand.BackupSoftwareBrandId;

            if (this.customerInfrastructureBackupSoftware.CustomerInfrastructureServerComputer == null)
                row["CustomerInfrastructureServerComputerId"] = DBNull.Value;
            else
                row["CustomerInfrastructureServerComputerId"] = this.customerInfrastructureBackupSoftware
                    .CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerId;
            row["Description"] = this.customerInfrastructureBackupSoftware.Description;

            this.dtCustomerInfrastructureBackupSoftwares.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureBackupSoftwares.cisccCustomerInfrastructureServerComputer.ReadOnly = !enabled;
            this.controlCustomerInfrastructureBackupSoftwares.bsbcBackupSoftwareBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureBackupSoftwares.txtDescription.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            BackupSoftwareBrandParameters pmtBackupSoftwareBrand = new BackupSoftwareBrandParameters();

            IList<BackupSoftwareBrand> cctvBrands = this.srvBackupSoftwareBrand.GetListByParameters(pmtBackupSoftwareBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["BackupSoftwareBrandId"], "BackupSoftwareBrandId", "Name", "Seleccione");

            if (this.CustomerInfrastructure != null)
            {
                CustomerInfrastructureServerComputerParameters pmtCustomerInfrastructureServerComputer
                    = new CustomerInfrastructureServerComputerParameters();

                pmtCustomerInfrastructureServerComputer.CustomerInfrastructureId = this.CustomerInfrastructure.CustomerInfrastructureId;
                IList<CustomerInfrastructureServerComputer> customerInfrastructureServerComputers
                    = this.srvCustomerInfrastructureServerComputer.GetListByParameters(pmtCustomerInfrastructureServerComputer);

                this.controlCustomerInfrastructureBackupSoftwares.cisccCustomerInfrastructureServerComputer.Parameters
                    = pmtCustomerInfrastructureServerComputer;
                this.controlCustomerInfrastructureBackupSoftwares.cisccCustomerInfrastructureServerComputer.DisplayMember
                    = "ServerModel";
                this.controlCustomerInfrastructureBackupSoftwares.cisccCustomerInfrastructureServerComputer.Refresh();

                WindowsFormsUtil.SetUltraGridValueList(e.Layout, customerInfrastructureServerComputers,
                    band.Columns["CustomerInfrastructureServerComputerId"], "CustomerInfrastructureServerComputerId", 
                    "ServerModel", "Seleccione");
            }
        }

        #endregion Events
    }
}
