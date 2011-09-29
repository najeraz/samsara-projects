
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
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
        private System.Collections.Generic.ISet<CustomerInfrastructureAdministationSoftware> customerInfrastructureAdministationSoftwares;

        private DataTable dtCustomerInfrastructureAdministationSoftwares;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureId
        {
            get;
            set;
        }

        public System.Collections.Generic.ISet<CustomerInfrastructureAdministationSoftware> CustomerInfrastructureAdministationSoftwares
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureAdministationSoftware> tmp
                    = new HashSet<CustomerInfrastructureAdministationSoftware>();

                foreach(CustomerInfrastructureAdministationSoftware customerInfrastructureAdministationSoftware in
                    this.customerInfrastructureAdministationSoftwares)
                {
                    customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId 
                        = customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId <= 0 ?
                        -1 : customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId;

                    tmp.Add(customerInfrastructureAdministationSoftware);
                }

                return tmp;
            }
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

                CustomerInfrastructureServerComputerParameters pmtCustomerInfrastructureServerComputer 
                    = new CustomerInfrastructureServerComputerParameters();

                pmtCustomerInfrastructureServerComputer.CustomerInfrastructureId = this.CustomerInfrastructureId;
                IList<CustomerInfrastructureServerComputer> customerInfrastructureServerComputers
                    = this.srvCustomerInfrastructureServerComputer.GetListByParameters(pmtCustomerInfrastructureServerComputer);
                WindowsFormsUtil.LoadCombo<CustomerInfrastructureServerComputer>(
                    this.controlCustomerInfrastructureAdministationSoftwares.uceCustomerInfraestructureServerComputer,
                    customerInfrastructureServerComputers, "CustomerInfrastructureServerComputerId", "ServerModel", "Seleccione");

                this.controlCustomerInfrastructureAdministationSoftwares.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadGrid()
        {
            if (this.CustomerInfrastructureId != null)
            {
                CustomerInfrastructureAdministationSoftwareParameters pmtCustomerInfrastructureAdministationSoftware
                    = new CustomerInfrastructureAdministationSoftwareParameters();

                pmtCustomerInfrastructureAdministationSoftware.CustomerInfrastructureId = this.CustomerInfrastructureId;

                this.dtCustomerInfrastructureAdministationSoftwares = this.srvCustomerInfrastructureAdministationSoftware
                    .SearchByParameters(pmtCustomerInfrastructureAdministationSoftware);

                this.controlCustomerInfrastructureAdministationSoftwares.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureAdministationSoftwares.grdRelations.DataSource = this.dtCustomerInfrastructureAdministationSoftwares;

                IList<CustomerInfrastructureAdministationSoftware> lstCustomerInfrastructureAdministationSoftwares 
                    = this.srvCustomerInfrastructureAdministationSoftware.GetListByParameters(pmtCustomerInfrastructureAdministationSoftware);

                this.customerInfrastructureAdministationSoftwares = new HashSet<CustomerInfrastructureAdministationSoftware>();

                foreach (CustomerInfrastructureAdministationSoftware customerInfrastructureAdministationSoftware in
                    lstCustomerInfrastructureAdministationSoftwares)
                {
                    this.customerInfrastructureAdministationSoftwares.Add(customerInfrastructureAdministationSoftware);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
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

            this.customerInfrastructureAdministationSoftware.Activated = true;
            this.customerInfrastructureAdministationSoftware.Deleted = false;
            this.customerInfrastructureAdministationSoftware.CustomerInfrastructure 
                = this.srvCustomerInfrastructure.GetById(this.CustomerInfrastructureId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureAdministationSoftware = this.customerInfrastructureAdministationSoftwares
                .Single(x => x.CustomerInfrastructureAdministationSoftwareId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureAdministationSoftwares.Remove(this.customerInfrastructureAdministationSoftware);
            else
            {
                this.customerInfrastructureAdministationSoftware.Activated = false;
                this.customerInfrastructureAdministationSoftware.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureAdministationSoftware = this.customerInfrastructureAdministationSoftwares
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

            if (this.controlCustomerInfrastructureAdministationSoftwares.uceDBMS.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureAdministationSoftwares.uceDBMS.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Software.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureAdministationSoftwares.uceDBMS.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId == -1)
            {
                this.customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId = this.entityCounter--;
                this.customerInfrastructureAdministationSoftwares.Add(this.customerInfrastructureAdministationSoftware);

                row = this.dtCustomerInfrastructureAdministationSoftwares.NewRow();
                this.dtCustomerInfrastructureAdministationSoftwares.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureAdministationSoftwares.AsEnumerable()
                    .Single(x => Convert.ToInt32(x["CustomerInfrastructureAdministationSoftwareId"])
                        == this.customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId);
            }

            row["CustomerInfrastructureAdministationSoftwareId"] 
                = this.customerInfrastructureAdministationSoftware.CustomerInfrastructureAdministationSoftwareId;
            row["DBMSId"] = this.customerInfrastructureAdministationSoftware.DBMS.DBMSId;
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

            DBMSParameters pmtDBMS = new DBMSParameters();

            IList<DBMS> cctvBrands = this.srvDBMS.GetListByParameters(pmtDBMS);
            WindowsFormsUtil.LoadCombo<DBMS>(this.controlCustomerInfrastructureAdministationSoftwares.uceDBMS,
                cctvBrands, "DBMSId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["DBMSId"], "DBMSId", "Name", "Seleccione");

            CustomerInfrastructureServerComputerParameters pmtCustomerInfrastructureServerComputer
                = new CustomerInfrastructureServerComputerParameters();

            pmtCustomerInfrastructureServerComputer.CustomerInfrastructureId = this.CustomerInfrastructureId;
            IList<CustomerInfrastructureServerComputer> customerInfrastructureServerComputers
                = this.srvCustomerInfrastructureServerComputer.GetListByParameters(pmtCustomerInfrastructureServerComputer);

            WindowsFormsUtil.LoadCombo<CustomerInfrastructureServerComputer>(
                this.controlCustomerInfrastructureAdministationSoftwares.uceCustomerInfraestructureServerComputer,
                customerInfrastructureServerComputers, "CustomerInfrastructureServerComputerId", "ServerModel", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, customerInfrastructureServerComputers,
                band.Columns["CustomerInfrastructureServerComputerId"], "CustomerInfrastructureServerComputerId", "ServerModel", "Seleccione");
        }

        #endregion Events
    }
}
