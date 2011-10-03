
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
    public class CustomerInfrastructureServerComputersControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureServerComputerService srvCustomerInfrastructureServerComputer;
        private CustomerInfrastructureServerComputersControl controlCustomerInfrastructureServerComputers;
        private CustomerInfrastructureServerComputer customerInfrastructureServerComputer;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private IOperativeSystemService srvOperativeSystem;
        private IComputerBrandService srvComputerBrand;
        private System.Collections.Generic.ISet<CustomerInfrastructureServerComputer> customerInfrastructureServerComputers;

        private DataTable dtCustomerInfrastructureServerComputers;

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

        public System.Collections.Generic.ISet<CustomerInfrastructureServerComputer> CustomerInfrastructureServerComputers
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureServerComputer> tmp
                    = new HashSet<CustomerInfrastructureServerComputer>();

                foreach(CustomerInfrastructureServerComputer customerInfrastructureServerComputer in
                    this.customerInfrastructureServerComputers)
                {
                    customerInfrastructureServerComputer.CustomerInfrastructureServerComputerId 
                        = customerInfrastructureServerComputer.CustomerInfrastructureServerComputerId <= 0 ?
                        -1 : customerInfrastructureServerComputer.CustomerInfrastructureServerComputerId;

                    tmp.Add(customerInfrastructureServerComputer);
                }

                return tmp;
            }
        }
        
        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructureServerComputersControlController(
            CustomerInfrastructureServerComputersControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureServerComputers = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureServerComputer = SamsaraAppContext.Resolve<ICustomerInfrastructureServerComputerService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureServerComputer);
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                Assert.IsNotNull(this.srvCustomerInfrastructure);
                this.srvComputerBrand = SamsaraAppContext.Resolve<IComputerBrandService>();
                Assert.IsNotNull(this.srvComputerBrand);
                this.srvOperativeSystem = SamsaraAppContext.Resolve<IOperativeSystemService>();
                Assert.IsNotNull(this.srvOperativeSystem);
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
                ComputerBrandParameters pmtComputerBrand = new ComputerBrandParameters();

                IList<ComputerBrand> cctvBrands = this.srvComputerBrand.GetListByParameters(pmtComputerBrand);
                WindowsFormsUtil.LoadCombo<ComputerBrand>(this.controlCustomerInfrastructureServerComputers.uceComputerBrand,
                    cctvBrands, "ComputerBrandId", "Name", "Seleccione");

                OperativeSystemParameters pmtOperativeSystem = new OperativeSystemParameters();

                IList<OperativeSystem> cctvTypes = this.srvOperativeSystem.GetListByParameters(pmtOperativeSystem);
                WindowsFormsUtil.LoadCombo<OperativeSystem>(this.controlCustomerInfrastructureServerComputers.uceOperativeSystem,
                    cctvTypes, "OperativeSystemId", "Name", "Seleccione");

                this.controlCustomerInfrastructureServerComputers.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            if (this.CustomerInfrastructureId != null)
            {
                this.controlCustomerInfrastructureServerComputers
                    .mtoCustomerInfrastructureServerComputerDBMSs.CustomerInfrastructureServerComputerId = -1;
                this.controlCustomerInfrastructureServerComputers
                    .mtoCustomerInfrastructureServerComputerDBMSs.CustomParent = this.controlCustomerInfrastructureServerComputers;
                this.controlCustomerInfrastructureServerComputers
                    .mtoCustomerInfrastructureServerComputerDBMSs.LoadControls();

                CustomerInfrastructureServerComputerParameters pmtCustomerInfrastructureServerComputer
                    = new CustomerInfrastructureServerComputerParameters();

                pmtCustomerInfrastructureServerComputer.CustomerInfrastructureId = this.CustomerInfrastructureId;

                this.dtCustomerInfrastructureServerComputers = this.srvCustomerInfrastructureServerComputer
                    .SearchByParameters(pmtCustomerInfrastructureServerComputer);

                this.controlCustomerInfrastructureServerComputers.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureServerComputers.grdRelations.DataSource = this.dtCustomerInfrastructureServerComputers;

                IList<CustomerInfrastructureServerComputer> lstCustomerInfrastructureServerComputers 
                    = this.srvCustomerInfrastructureServerComputer.GetListByParameters(pmtCustomerInfrastructureServerComputer);

                this.customerInfrastructureServerComputers = new HashSet<CustomerInfrastructureServerComputer>();

                foreach (CustomerInfrastructureServerComputer customerInfrastructureServerComputer in
                    lstCustomerInfrastructureServerComputers)
                {
                    this.customerInfrastructureServerComputers.Add(customerInfrastructureServerComputer);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureServerComputers.uceComputerBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureServerComputers.uceOperativeSystem.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureServerComputers.txtUtilization.Text = string.Empty;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureServerComputer = new CustomerInfrastructureServerComputer();

            this.customerInfrastructureServerComputer.Activated = true;
            this.customerInfrastructureServerComputer.Deleted = false;
            this.customerInfrastructureServerComputer.CustomerInfrastructure 
                = this.srvCustomerInfrastructure.GetById(this.CustomerInfrastructureId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureServerComputer = this.customerInfrastructureServerComputers
                .Single(x => x.CustomerInfrastructureServerComputerId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureServerComputers.Remove(this.customerInfrastructureServerComputer);
            else
            {
                this.customerInfrastructureServerComputer.Activated = false;
                this.customerInfrastructureServerComputer.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureServerComputer = this.customerInfrastructureServerComputers
                .Single(x => x.CustomerInfrastructureServerComputerId == entityId);

            this.controlCustomerInfrastructureServerComputers.uceComputerBrand.Value
                = this.customerInfrastructureServerComputer.ComputerBrand.ComputerBrandId;

            this.controlCustomerInfrastructureServerComputers.uceOperativeSystem.Value
                = this.customerInfrastructureServerComputer.OperativeSystem.OperativeSystemId;

            this.controlCustomerInfrastructureServerComputers.txtUtilization.Text
                = this.customerInfrastructureServerComputer.Utilization;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureServerComputer.ComputerBrand = this.srvComputerBrand
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureServerComputers.uceComputerBrand.Value));

            this.customerInfrastructureServerComputer.OperativeSystem = this.srvOperativeSystem
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureServerComputers.uceOperativeSystem.Value));

            this.customerInfrastructureServerComputer.Utilization = this.controlCustomerInfrastructureServerComputers.txtUtilization.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureServerComputers.uceComputerBrand.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureServerComputers.uceComputerBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca del ServerComputer.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureServerComputers.uceComputerBrand.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructureServerComputers.uceOperativeSystem.Value == null ||
                Convert.ToInt32(this.controlCustomerInfrastructureServerComputers.uceOperativeSystem.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo del ServerComputer.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureServerComputers.uceOperativeSystem.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureServerComputer.CustomerInfrastructureServerComputerId == -1)
            {
                this.customerInfrastructureServerComputer.CustomerInfrastructureServerComputerId = this.entityCounter--;
                this.customerInfrastructureServerComputers.Add(this.customerInfrastructureServerComputer);

                row = this.dtCustomerInfrastructureServerComputers.NewRow();
                this.dtCustomerInfrastructureServerComputers.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureServerComputers.AsEnumerable().Single(x => Convert.ToInt32(x["CustomerInfrastructureServerComputerId"])
                        == this.customerInfrastructureServerComputer.CustomerInfrastructureServerComputerId);
            }

            row["CustomerInfrastructureServerComputerId"] = this.customerInfrastructureServerComputer.CustomerInfrastructureServerComputerId;
            row["ComputerBrandId"] = this.customerInfrastructureServerComputer.ComputerBrand.ComputerBrandId;
            row["OperativeSystemId"] = this.customerInfrastructureServerComputer.OperativeSystem.OperativeSystemId;
            row["Utilization"] = this.customerInfrastructureServerComputer.Utilization;

            this.dtCustomerInfrastructureServerComputers.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureServerComputers.uceOperativeSystem.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputers.uceComputerBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputers.txtUtilization.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            ComputerBrandParameters pmtComputerBrand = new ComputerBrandParameters();

            IList<ComputerBrand> cctvBrands = this.srvComputerBrand.GetListByParameters(pmtComputerBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["ComputerBrandId"], "ComputerBrandId", "Name", "Seleccione");

            OperativeSystemParameters pmtOperativeSystem = new OperativeSystemParameters();

            IList<OperativeSystem> cctvTypes = this.srvOperativeSystem.GetListByParameters(pmtOperativeSystem);
            WindowsFormsUtil.LoadCombo<OperativeSystem>(this.controlCustomerInfrastructureServerComputers.uceOperativeSystem,
                cctvTypes, "OperativeSystemId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["OperativeSystemId"], "OperativeSystemId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
