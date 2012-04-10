
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
    public class CustomerInfrastructureNetworkCommutatorsControlController : ManyToOneLevel1ControlController<CustomerInfrastructureNetworkCommutator>
    {
        #region Attributes

        private ICustomerInfrastructureNetworkCommutatorService srvCustomerInfrastructureNetworkCommutator;
        private CustomerInfrastructureNetworkCommutatorsControl controlCustomerInfrastructureNetworkCommutators;
        private CustomerInfrastructureNetworkCommutator customerInfrastructureNetworkCommutator;
        private ICustomerInfrastructureNetworkService srvCustomerInfrastructureNetwork;
        private ICommutatorBrandService srvCommutatorBrand;
        private ICommutatorTypeService srvCommutatorType;

        private DataTable dtCustomerInfrastructureNetworkCommutators;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureNetwork CustomerInfrastructureNetwork
        {
            get;
            set;
        }
        
        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructureNetworkCommutatorsControlController(
            CustomerInfrastructureNetworkCommutatorsControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureNetworkCommutators = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureNetworkCommutator = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkCommutatorService>();
                this.srvCustomerInfrastructureNetwork = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkService>();
                this.srvCommutatorBrand = SamsaraAppContext.Resolve<ICommutatorBrandService>();
                this.srvCommutatorType = SamsaraAppContext.Resolve<ICommutatorTypeService>();
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
                CommutatorBrandParameters pmtCommutatorBrand = new CommutatorBrandParameters();

                this.controlCustomerInfrastructureNetworkCommutators.cbcCommutatorBrand.Parameters = pmtCommutatorBrand;
                this.controlCustomerInfrastructureNetworkCommutators.cbcCommutatorBrand.Refresh();

                CommutatorTypeParameters pmtCommutatorType = new CommutatorTypeParameters();

                this.controlCustomerInfrastructureNetworkCommutators.ctcCommutatorType.Parameters = pmtCommutatorType;
                this.controlCustomerInfrastructureNetworkCommutators.ctcCommutatorType.Refresh();

                this.controlCustomerInfrastructureNetworkCommutators.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureNetworkCommutatorParameters pmtCustomerInfrastructureNetworkCommutator
                = new CustomerInfrastructureNetworkCommutatorParameters();

            pmtCustomerInfrastructureNetworkCommutator.CustomerInfrastructureNetworkId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureNetworkCommutators = this.srvCustomerInfrastructureNetworkCommutator
                .SearchByParameters(pmtCustomerInfrastructureNetworkCommutator);

            this.controlCustomerInfrastructureNetworkCommutators.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureNetworkCommutators.grdRelations.DataSource
                = this.dtCustomerInfrastructureNetworkCommutators;

            if (this.CustomerInfrastructureNetwork != null)
            {
                foreach (CustomerInfrastructureNetworkCommutator customerInfrastructureNetworkCommutator
                    in this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkCommutators)
                {
                    DataRow row = this.dtCustomerInfrastructureNetworkCommutators.NewRow();
                    this.dtCustomerInfrastructureNetworkCommutators.Rows.Add(row);

                    row["CustomerInfrastructureNetworkCommutatorId"] = customerInfrastructureNetworkCommutator
                        .CustomerInfrastructureNetworkCommutatorId;
                    row["CommutatorBrandId"] = customerInfrastructureNetworkCommutator.CommutatorBrand.CommutatorBrandId;
                    row["CommutatorTypeId"] = customerInfrastructureNetworkCommutator.CommutatorType.CommutatorTypeId;
                    row["NumberOfTrunks"] = customerInfrastructureNetworkCommutator.NumberOfTrunks;
                    row["NumberOfExtensions"] = customerInfrastructureNetworkCommutator.NumberOfExtensions;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkCommutators.cbcCommutatorBrand.Value = null;
            this.controlCustomerInfrastructureNetworkCommutators.ctcCommutatorType.Value = null;
            this.controlCustomerInfrastructureNetworkCommutators.steNumberOfTrunks.Value = null;
            this.controlCustomerInfrastructureNetworkCommutators.steNumberOfExtensions.Value = null;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureNetworkCommutators.Rows.Clear();
            this.dtCustomerInfrastructureNetworkCommutators.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkCommutator = new CustomerInfrastructureNetworkCommutator();

            this.customerInfrastructureNetworkCommutator.CustomerInfrastructureNetwork = this.CustomerInfrastructureNetwork;
            this.customerInfrastructureNetworkCommutator.Activated = true;
            this.customerInfrastructureNetworkCommutator.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkCommutator = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkCommutators
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkCommutator = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkCommutators
                    .Single(x => x.CustomerInfrastructureNetworkCommutatorId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkCommutators
                    .Remove(this.customerInfrastructureNetworkCommutator);
            else
            {
                this.customerInfrastructureNetworkCommutator.Activated = false;
                this.customerInfrastructureNetworkCommutator.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkCommutator = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkCommutators
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkCommutator = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkCommutators
                    .Single(x => x.CustomerInfrastructureNetworkCommutatorId == entityId);

            this.controlCustomerInfrastructureNetworkCommutators.cbcCommutatorBrand.Value
                = this.customerInfrastructureNetworkCommutator.CommutatorBrand;

            this.controlCustomerInfrastructureNetworkCommutators.ctcCommutatorType.Value
                = this.customerInfrastructureNetworkCommutator.CommutatorType;

            this.controlCustomerInfrastructureNetworkCommutators.steNumberOfTrunks.Value
                = this.customerInfrastructureNetworkCommutator.NumberOfTrunks;

            this.controlCustomerInfrastructureNetworkCommutators.steNumberOfExtensions.Value
                = this.customerInfrastructureNetworkCommutator.NumberOfExtensions;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureNetworkCommutator.CommutatorBrand 
                = this.controlCustomerInfrastructureNetworkCommutators.cbcCommutatorBrand.Value;

            this.customerInfrastructureNetworkCommutator.CommutatorType 
                = this.controlCustomerInfrastructureNetworkCommutators.ctcCommutatorType.Value;

            this.customerInfrastructureNetworkCommutator.NumberOfExtensions
                = Convert.ToInt32(this.controlCustomerInfrastructureNetworkCommutators.steNumberOfExtensions.Value);

            this.customerInfrastructureNetworkCommutator.NumberOfTrunks
                = Convert.ToInt32(this.controlCustomerInfrastructureNetworkCommutators.steNumberOfTrunks.Value);
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureNetworkCommutators.cbcCommutatorBrand.Value == null)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Conmutador.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkCommutators.cbcCommutatorBrand.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructureNetworkCommutators.ctcCommutatorType.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el Tipo del Conmutador.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkCommutators.ctcCommutatorType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureNetworkCommutator.CustomerInfrastructureNetworkCommutatorId == -1)
                row = this.dtCustomerInfrastructureNetworkCommutators.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkCommutatorId"])
                        == -(this.customerInfrastructureNetworkCommutator as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureNetworkCommutators.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkCommutatorId"])
                        == this.customerInfrastructureNetworkCommutator.CustomerInfrastructureNetworkCommutatorId);

            if (row == null)
            {
                this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkCommutators
                    .Add(this.customerInfrastructureNetworkCommutator);

                row = this.dtCustomerInfrastructureNetworkCommutators.NewRow();
                this.dtCustomerInfrastructureNetworkCommutators.Rows.Add(row);
            }

            if (this.customerInfrastructureNetworkCommutator.CustomerInfrastructureNetworkCommutatorId == -1)
                row["CustomerInfrastructureNetworkCommutatorId"]
                    = -(this.customerInfrastructureNetworkCommutator as object).GetHashCode();
            else
                row["CustomerInfrastructureNetworkCommutatorId"] = this.customerInfrastructureNetworkCommutator
                    .CustomerInfrastructureNetworkCommutatorId;

            row["CommutatorBrandId"] = this.customerInfrastructureNetworkCommutator.CommutatorBrand.CommutatorBrandId;
            row["CommutatorTypeId"] = this.customerInfrastructureNetworkCommutator.CommutatorType.CommutatorTypeId;
            row["NumberOfTrunks"] = this.customerInfrastructureNetworkCommutator.NumberOfTrunks;
            row["NumberOfExtensions"] = this.customerInfrastructureNetworkCommutator.NumberOfExtensions;

            this.dtCustomerInfrastructureNetworkCommutators.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureNetworkCommutators.ctcCommutatorType.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkCommutators.cbcCommutatorBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkCommutators.steNumberOfTrunks.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkCommutators.steNumberOfExtensions.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            CommutatorBrandParameters pmtCommutatorBrand = new CommutatorBrandParameters();

            IList<CommutatorBrand> cctvBrands = this.srvCommutatorBrand.GetListByParameters(pmtCommutatorBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["CommutatorBrandId"], "CommutatorBrandId", "Name", "Seleccione");

            CommutatorTypeParameters pmtCommutatorType = new CommutatorTypeParameters();

            this.controlCustomerInfrastructureNetworkCommutators.ctcCommutatorType.Parameters = pmtCommutatorType;
            this.controlCustomerInfrastructureNetworkCommutators.ctcCommutatorType.Refresh();

            IList<CommutatorType> cctvTypes = this.srvCommutatorType.GetListByParameters(pmtCommutatorType);

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["CommutatorTypeId"], "CommutatorTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
