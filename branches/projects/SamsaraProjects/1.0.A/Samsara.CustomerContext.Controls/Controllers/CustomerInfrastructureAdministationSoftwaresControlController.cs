
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Controls.Controllers;
using Samsara.CustomerContext.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.CustomerContext.Controls.Controllers
{
    public class CustomerInfrastructureAdministationSoftwaresControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private CustomerInfrastructureAdministationSoftwaresControl controlCustomerInfrastructureAdministationSoftwares;
        private ICustomerInfrastructureAdministationSoftwareService srvCustomerInfrastructureAdministationSoftware;
        private CustomerInfrastructureAdministationSoftware customerInfrastructureAdministationSoftware;
        private ICustomerInfrastructureServerComputerService srvCustomerInfrastructureServerComputer;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private IDBMSService srvDBMS;

        private DataTable dtCustomerInfrastructureAdministationSoftwares;

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

        public CustomerInfrastructureAdministationSoftwaresControlController(
            CustomerInfrastructureAdministationSoftwaresControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureAdministationSoftwares = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureAdministationSoftware = SamsaraAppContext.Resolve<ICustomerInfrastructureAdministationSoftwareService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureAdministationSoftware);
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                Assert.IsNotNull(this.srvCustomerInfrastructure);
                this.srvDBMS = SamsaraAppContext.Resolve<IDBMSService>();
                Assert.IsNotNull(this.srvDBMS);
                this.srvCustomerInfrastructureServerComputer = SamsaraAppContext.Resolve<ICustomerInfrastructureServerComputerService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureServerComputer);
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
                DBMSParameters pmtDBMS = new DBMSParameters();

                IList<DBMS> dbmss = this.srvDBMS.GetListByParameters(pmtDBMS);
                WindowsFormsUtil.LoadCombo<DBMS>(this.controlCustomerInfrastructureAdministationSoftwares.uceDBMS,
                    dbmss, "DBMSId", "Name", "Seleccione");

                this.controlCustomerInfrastructureAdministationSoftwares.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureAdministationSoftwareParameters pmtCustomerInfrastructureAdministationSoftware
                = new CustomerInfrastructureAdministationSoftwareParameters();

            pmtCustomerInfrastructureAdministationSoftware.CustomerInfrastructureId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureAdministationSoftwares = this.srvCustomerInfrastructureAdministationSoftware
                .SearchByParameters(pmtCustomerInfrastructureAdministationSoftware);

            this.controlCustomerInfrastructureAdministationSoftwares.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureAdministationSoftwares.grdRelations.DataSource 
                = this.dtCustomerInfrastructureAdministationSoftwares;

            if (this.CustomerInfrastructure != null)
            {
                CustomerInfrastructureServerComputerParameters pmtCustomerInfrastructureServerComputer
                    = new CustomerInfrastructureServerComputerParameters();

                pmtCustomerInfrastructureServerComputer.CustomerInfrastructureId = this.CustomerInfrastructure.CustomerInfrastructureId;
                IList<CustomerInfrastructureServerComputer> customerInfrastructureServerComputers
                    = this.srvCustomerInfrastructureServerComputer.GetListByParameters(pmtCustomerInfrastructureServerComputer);
                WindowsFormsUtil.LoadCombo<CustomerInfrastructureServerComputer>(
                    this.controlCustomerInfrastructureAdministationSoftwares.uceCustomerInfraestructureServerComputer,
                    customerInfrastructureServerComputers, "CustomerInfrastructureServerComputerId", "ServerModel", "Seleccione");

                foreach (CustomerInfrastructureAdministationSoftware customerInfrastructureAdministationSoftware
                    in this.CustomerInfrastructure.CustomerInfrastructureAdministationSoftwares)
                {
                    DataRow row = this.dtCustomerInfrastructureAdministationSoftwares.NewRow();
                    this.dtCustomerInfrastructureAdministationSoftwares.Rows.Add(row);
                    
                    row["CustomerInfrastructureAdministationSoftwareId"]
                        = customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId;
                    row["DBMSId"] = customerInfrastructureAdministationSoftware.DBMS.DBMSId;
                    row["CustomerInfrastructureServerComputerId"] = customerInfrastructureAdministationSoftware
                        .CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerId;
                    row["Description"] = customerInfrastructureAdministationSoftware.Description;
                    row["Modules"] = customerInfrastructureAdministationSoftware.Modules;
                    row["Name"] = customerInfrastructureAdministationSoftware.Name;
                    row["NumberOfUsers"] = customerInfrastructureAdministationSoftware.NumberOfUsers;
                }

                this.dtCustomerInfrastructureAdministationSoftwares.AcceptChanges();
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureAdministationSoftwares.uceDBMS.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureAdministationSoftwares.txtDescription.Value = null;
            this.controlCustomerInfrastructureAdministationSoftwares.txtModules.Value = null;
            this.controlCustomerInfrastructureAdministationSoftwares.txtName.Value = null;
            this.controlCustomerInfrastructureAdministationSoftwares.steNumberOfUsers.Value = null;
            this.controlCustomerInfrastructureAdministationSoftwares.uceCustomerInfraestructureServerComputer.Value = ParameterConstants.IntDefault;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureAdministationSoftware = new CustomerInfrastructureAdministationSoftware();
            this.customerInfrastructureAdministationSoftware.CustomerInfrastructure = this.CustomerInfrastructure;
            this.customerInfrastructureAdministationSoftware.Activated = true;
            this.customerInfrastructureAdministationSoftware.Deleted = false;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureAdministationSoftwares.Rows.Clear();
            this.dtCustomerInfrastructureAdministationSoftwares.AcceptChanges();
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureAdministationSoftware = this.CustomerInfrastructure
                    .CustomerInfrastructureAdministationSoftwares
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureAdministationSoftware = this.CustomerInfrastructure
                    .CustomerInfrastructureAdministationSoftwares
                    .Single(x => x.CustomerInfrastructureAdministationSoftwareId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructure.CustomerInfrastructureAdministationSoftwares
                    .Remove(this.customerInfrastructureAdministationSoftware);
            else
            {
                this.customerInfrastructureAdministationSoftware.Activated = false;
                this.customerInfrastructureAdministationSoftware.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);
            
            if (entityId <= 0)
                this.customerInfrastructureAdministationSoftware 
                    = this.CustomerInfrastructure.CustomerInfrastructureAdministationSoftwares
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureAdministationSoftware 
                    = this.CustomerInfrastructure.CustomerInfrastructureAdministationSoftwares
                    .Single(x => x.CustomerInfrastructureAdministationSoftwareId == entityId);

            this.controlCustomerInfrastructureAdministationSoftwares.uceDBMS.Value
                = this.customerInfrastructureAdministationSoftware.DBMS.DBMSId;

            this.controlCustomerInfrastructureAdministationSoftwares.uceCustomerInfraestructureServerComputer.Value
                = this.customerInfrastructureAdministationSoftware.CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerId;

            this.controlCustomerInfrastructureAdministationSoftwares.txtDescription.Value
                = this.customerInfrastructureAdministationSoftware.Description;

            this.controlCustomerInfrastructureAdministationSoftwares.txtModules.Value
                = this.customerInfrastructureAdministationSoftware.Modules;

            this.controlCustomerInfrastructureAdministationSoftwares.txtName.Value
                = this.customerInfrastructureAdministationSoftware.Name;

            this.controlCustomerInfrastructureAdministationSoftwares.steNumberOfUsers.Value
                = this.customerInfrastructureAdministationSoftware.NumberOfUsers;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureAdministationSoftware.DBMS = this.srvDBMS
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureAdministationSoftwares.uceDBMS.Value));

            this.customerInfrastructureAdministationSoftware.CustomerInfrastructureServerComputer 
                = this.srvCustomerInfrastructureServerComputer
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureAdministationSoftwares.uceCustomerInfraestructureServerComputer.Value));

            this.customerInfrastructureAdministationSoftware.Description
                = this.controlCustomerInfrastructureAdministationSoftwares.txtDescription.Text;

            this.customerInfrastructureAdministationSoftware.Modules
                = this.controlCustomerInfrastructureAdministationSoftwares.txtModules.Text;

            this.customerInfrastructureAdministationSoftware.Name
                = this.controlCustomerInfrastructureAdministationSoftwares.txtName.Text;

            this.customerInfrastructureAdministationSoftware.NumberOfUsers
                = Convert.ToInt32(this.controlCustomerInfrastructureAdministationSoftwares.steNumberOfUsers.Value);
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId == -1)
                row = this.dtCustomerInfrastructureAdministationSoftwares.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureAdministationSoftwareId"])
                       == -(this.customerInfrastructureAdministationSoftware as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureAdministationSoftwares.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureAdministationSoftwareId"])
                        == this.customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId);

            if (row == null)
            {
                this.CustomerInfrastructure.CustomerInfrastructureAdministationSoftwares
                    .Add(this.customerInfrastructureAdministationSoftware);

                row = this.dtCustomerInfrastructureAdministationSoftwares.NewRow();
                this.dtCustomerInfrastructureAdministationSoftwares.Rows.Add(row);
            }

            if (this.customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId == -1)
                row["CustomerInfrastructureAdministationSoftwareId"]
                    = -(this.customerInfrastructureAdministationSoftware as object).GetHashCode();
            else
                row["CustomerInfrastructureAdministationSoftwareId"]
                    = this.customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId;

            row["DBMSId"] = this.customerInfrastructureAdministationSoftware.DBMS.DBMSId;

            if (this.customerInfrastructureAdministationSoftware.CustomerInfrastructureServerComputer == null)
                row["CustomerInfrastructureServerComputerId"] = DBNull.Value;
            else
                row["CustomerInfrastructureServerComputerId"] = this.customerInfrastructureAdministationSoftware
                    .CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerId;
            row["Description"] = this.customerInfrastructureAdministationSoftware.Description;
            row["Modules"] = this.customerInfrastructureAdministationSoftware.Modules;
            row["Name"] = this.customerInfrastructureAdministationSoftware.Name;
            row["NumberOfUsers"] = this.customerInfrastructureAdministationSoftware.NumberOfUsers;

            this.dtCustomerInfrastructureAdministationSoftwares.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureAdministationSoftwares.uceCustomerInfraestructureServerComputer.ReadOnly = !enabled;
            this.controlCustomerInfrastructureAdministationSoftwares.uceDBMS.ReadOnly = !enabled;
            this.controlCustomerInfrastructureAdministationSoftwares.txtDescription.ReadOnly = !enabled;
            this.controlCustomerInfrastructureAdministationSoftwares.txtModules.ReadOnly = !enabled;
            this.controlCustomerInfrastructureAdministationSoftwares.txtName.ReadOnly = !enabled;
            this.controlCustomerInfrastructureAdministationSoftwares.steNumberOfUsers.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            DBMSParameters pmtDBMS = new DBMSParameters();

            IList<DBMS> cctvBrands = this.srvDBMS.GetListByParameters(pmtDBMS);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["DBMSId"], "DBMSId", "Name", "Seleccione");

            CustomerInfrastructureServerComputerParameters pmtCustomerInfrastructureServerComputer
                = new CustomerInfrastructureServerComputerParameters();

            if (this.CustomerInfrastructure != null)
            {
                pmtCustomerInfrastructureServerComputer.CustomerInfrastructureId
                    = this.CustomerInfrastructure.CustomerInfrastructureId;
                IList<CustomerInfrastructureServerComputer> customerInfrastructureServerComputers
                    = this.srvCustomerInfrastructureServerComputer.GetListByParameters(pmtCustomerInfrastructureServerComputer);

                WindowsFormsUtil.LoadCombo<CustomerInfrastructureServerComputer>(
                    this.controlCustomerInfrastructureAdministationSoftwares.uceCustomerInfraestructureServerComputer,
                    customerInfrastructureServerComputers, "CustomerInfrastructureServerComputerId", "ServerModel", "Seleccione");

                WindowsFormsUtil.SetUltraGridValueList(e.Layout, customerInfrastructureServerComputers,
                    band.Columns["CustomerInfrastructureServerComputerId"], "CustomerInfrastructureServerComputerId", "ServerModel", "Seleccione");
            }
        }

        #endregion Events
    }
}
