
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
    public class CustomerInfrastructureBackupSoftwaresControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureBackupSoftwareService srvCustomerInfrastructureBackupSoftware;
        private CustomerInfrastructureBackupSoftwaresControl controlCustomerInfrastructureBackupSoftwares;
        private CustomerInfrastructureBackupSoftware customerInfrastructureBackupSoftware;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private IBackupSoftwareBrandService srvBackupSoftwareBrand;
        private ICustomerInfrastructureServerComputerService srvCustomerInfrastructureServerComputer;
        private System.Collections.Generic.ISet<CustomerInfrastructureBackupSoftware> customerInfrastructureBackupSoftwares;

        private DataTable dtCustomerInfrastructureBackupSoftwares;

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

        public System.Collections.Generic.ISet<CustomerInfrastructureBackupSoftware> CustomerInfrastructureBackupSoftwares
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureBackupSoftware> tmp
                    = new HashSet<CustomerInfrastructureBackupSoftware>();

                foreach(CustomerInfrastructureBackupSoftware customerInfrastructureBackupSoftware in
                    this.customerInfrastructureBackupSoftwares)
                {
                    customerInfrastructureBackupSoftware.CustomerInfrastructureBackupSoftwareId 
                        = customerInfrastructureBackupSoftware.CustomerInfrastructureBackupSoftwareId <= 0 ?
                        -1 : customerInfrastructureBackupSoftware.CustomerInfrastructureBackupSoftwareId;

                    tmp.Add(customerInfrastructureBackupSoftware);
                }

                return tmp;
            }
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
                Assert.IsNotNull(this.srvCustomerInfrastructureBackupSoftware);
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                Assert.IsNotNull(this.srvCustomerInfrastructure);
                this.srvBackupSoftwareBrand = SamsaraAppContext.Resolve<IBackupSoftwareBrandService>();
                Assert.IsNotNull(this.srvBackupSoftwareBrand);
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
                BackupSoftwareBrandParameters pmtBackupSoftwareBrand = new BackupSoftwareBrandParameters();

                IList<BackupSoftwareBrand> cctvBrands = this.srvBackupSoftwareBrand.GetListByParameters(pmtBackupSoftwareBrand);
                WindowsFormsUtil.LoadCombo<BackupSoftwareBrand>(this.controlCustomerInfrastructureBackupSoftwares.uceBackupSoftwareBrand,
                    cctvBrands, "BackupSoftwareBrandId", "Name", "Seleccione");

                this.controlCustomerInfrastructureBackupSoftwares.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            if (this.CustomerInfrastructureId != null)
            {
                CustomerInfrastructureServerComputerParameters pmtCustomerInfrastructureServerComputer
                    = new CustomerInfrastructureServerComputerParameters();

                pmtCustomerInfrastructureServerComputer.CustomerInfrastructureId = this.CustomerInfrastructureId;
                IList<CustomerInfrastructureServerComputer> customerInfrastructureServerComputers
                    = this.srvCustomerInfrastructureServerComputer.GetListByParameters(pmtCustomerInfrastructureServerComputer);
                WindowsFormsUtil.LoadCombo<CustomerInfrastructureServerComputer>(
                    this.controlCustomerInfrastructureBackupSoftwares.uceCustomerInfraestructureServerComputer,
                    customerInfrastructureServerComputers, "CustomerInfrastructureServerComputerId", "ServerModel", "Seleccione");

                CustomerInfrastructureBackupSoftwareParameters pmtCustomerInfrastructureBackupSoftware
                    = new CustomerInfrastructureBackupSoftwareParameters();

                pmtCustomerInfrastructureBackupSoftware.CustomerInfrastructureId = this.CustomerInfrastructureId;

                this.dtCustomerInfrastructureBackupSoftwares = this.srvCustomerInfrastructureBackupSoftware
                    .SearchByParameters(pmtCustomerInfrastructureBackupSoftware);

                this.controlCustomerInfrastructureBackupSoftwares.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureBackupSoftwares.grdRelations.DataSource = this.dtCustomerInfrastructureBackupSoftwares;

                IList<CustomerInfrastructureBackupSoftware> lstCustomerInfrastructureBackupSoftwares 
                    = this.srvCustomerInfrastructureBackupSoftware.GetListByParameters(pmtCustomerInfrastructureBackupSoftware);

                this.customerInfrastructureBackupSoftwares = new HashSet<CustomerInfrastructureBackupSoftware>();

                foreach (CustomerInfrastructureBackupSoftware customerInfrastructureBackupSoftware in
                    lstCustomerInfrastructureBackupSoftwares)
                {
                    this.customerInfrastructureBackupSoftwares.Add(customerInfrastructureBackupSoftware);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureBackupSoftwares.uceBackupSoftwareBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureBackupSoftwares.uceCustomerInfraestructureServerComputer.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureBackupSoftwares.txtDescription.Text = string.Empty;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureBackupSoftware = new CustomerInfrastructureBackupSoftware();

            this.customerInfrastructureBackupSoftware.Activated = true;
            this.customerInfrastructureBackupSoftware.Deleted = false;
            this.customerInfrastructureBackupSoftware.CustomerInfrastructure 
                = this.srvCustomerInfrastructure.GetById(this.CustomerInfrastructureId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureBackupSoftware = this.customerInfrastructureBackupSoftwares
                .Single(x => x.CustomerInfrastructureBackupSoftwareId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureBackupSoftwares.Remove(this.customerInfrastructureBackupSoftware);
            else
            {
                this.customerInfrastructureBackupSoftware.Activated = false;
                this.customerInfrastructureBackupSoftware.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureBackupSoftware = this.customerInfrastructureBackupSoftwares
                .Single(x => x.CustomerInfrastructureBackupSoftwareId == entityId);

            this.controlCustomerInfrastructureBackupSoftwares.uceBackupSoftwareBrand.Value
                = this.customerInfrastructureBackupSoftware.BackupSoftwareBrand.BackupSoftwareBrandId;

            this.controlCustomerInfrastructureBackupSoftwares.uceCustomerInfraestructureServerComputer.Value
                = this.customerInfrastructureBackupSoftware.CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerId;

            this.controlCustomerInfrastructureBackupSoftwares.txtDescription.Value
                = this.customerInfrastructureBackupSoftware.Description;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureBackupSoftware.BackupSoftwareBrand = this.srvBackupSoftwareBrand
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureBackupSoftwares.uceBackupSoftwareBrand.Value));

            this.customerInfrastructureBackupSoftware.CustomerInfrastructureServerComputer
                = this.srvCustomerInfrastructureServerComputer
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureBackupSoftwares.uceCustomerInfraestructureServerComputer.Value));


            this.customerInfrastructureBackupSoftware.Description
                = this.controlCustomerInfrastructureBackupSoftwares.txtDescription.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureBackupSoftwares.uceBackupSoftwareBrand.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureBackupSoftwares.uceBackupSoftwareBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Software.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureBackupSoftwares.uceBackupSoftwareBrand.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureBackupSoftware.CustomerInfrastructureBackupSoftwareId == -1)
            {
                this.customerInfrastructureBackupSoftware.CustomerInfrastructureBackupSoftwareId = this.entityCounter--;
                this.customerInfrastructureBackupSoftwares.Add(this.customerInfrastructureBackupSoftware);

                row = this.dtCustomerInfrastructureBackupSoftwares.NewRow();
                this.dtCustomerInfrastructureBackupSoftwares.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureBackupSoftwares.AsEnumerable().Single(x => Convert.ToInt32(x["CustomerInfrastructureBackupSoftwareId"])
                        == this.customerInfrastructureBackupSoftware.CustomerInfrastructureBackupSoftwareId);
            }

            row["CustomerInfrastructureBackupSoftwareId"] = this.customerInfrastructureBackupSoftware.CustomerInfrastructureBackupSoftwareId;
            row["BackupSoftwareBrandId"] = this.customerInfrastructureBackupSoftware.BackupSoftwareBrand.BackupSoftwareBrandId;
            row["CustomerInfrastructureServerComputerId"] = this.customerInfrastructureBackupSoftware
                .CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerId;
            row["Description"] = this.customerInfrastructureBackupSoftware.Description;

            this.dtCustomerInfrastructureBackupSoftwares.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureBackupSoftwares.uceCustomerInfraestructureServerComputer.ReadOnly = !enabled;
            this.controlCustomerInfrastructureBackupSoftwares.uceBackupSoftwareBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureBackupSoftwares.txtDescription.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            BackupSoftwareBrandParameters pmtBackupSoftwareBrand = new BackupSoftwareBrandParameters();

            IList<BackupSoftwareBrand> cctvBrands = this.srvBackupSoftwareBrand.GetListByParameters(pmtBackupSoftwareBrand);
            WindowsFormsUtil.LoadCombo<BackupSoftwareBrand>(this.controlCustomerInfrastructureBackupSoftwares.uceBackupSoftwareBrand,
                cctvBrands, "BackupSoftwareBrandId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["BackupSoftwareBrandId"], "BackupSoftwareBrandId", "Name", "Seleccione");

            CustomerInfrastructureServerComputerParameters pmtCustomerInfrastructureServerComputer
                = new CustomerInfrastructureServerComputerParameters();

            pmtCustomerInfrastructureServerComputer.CustomerInfrastructureId = this.CustomerInfrastructureId;
            IList<CustomerInfrastructureServerComputer> customerInfrastructureServerComputers
                = this.srvCustomerInfrastructureServerComputer.GetListByParameters(pmtCustomerInfrastructureServerComputer);

            WindowsFormsUtil.LoadCombo<CustomerInfrastructureServerComputer>(
                this.controlCustomerInfrastructureBackupSoftwares.uceCustomerInfraestructureServerComputer,
                customerInfrastructureServerComputers, "CustomerInfrastructureServerComputerId", "ServerModel", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, customerInfrastructureServerComputers,
                band.Columns["CustomerInfrastructureServerComputerId"], "CustomerInfrastructureServerComputerId", "ServerModel", "Seleccione");
        }

        #endregion Events
    }
}
