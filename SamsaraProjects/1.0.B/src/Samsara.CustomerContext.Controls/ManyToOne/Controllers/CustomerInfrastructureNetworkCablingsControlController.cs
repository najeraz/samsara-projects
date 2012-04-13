
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Controls.ControlsControllers;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Framework.Core.Constants;
using Samsara.Framework.Util;

namespace Samsara.CustomerContext.Controls.ManyToOne.Controllers
{
    public class CustomerInfrastructureNetworkCablingsControlController : ManyToOneLevel1ControlController<CustomerInfrastructureNetworkCabling>
    {
        #region Attributes

        private ICustomerInfrastructureNetworkCablingService srvCustomerInfrastructureNetworkCabling;
        private CustomerInfrastructureNetworkCablingsControl controlCustomerInfrastructureNetworkCablings;
        private CustomerInfrastructureNetworkCabling customerInfrastructureNetworkCabling;
        private ICustomerInfrastructureNetworkService srvCustomerInfrastructureNetwork;
        private INetworkCablingTypeService srvNetworkCablingType;

        private DataTable dtCustomerInfrastructureNetworkCablings;

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

        public CustomerInfrastructureNetworkCablingsControlController(
            CustomerInfrastructureNetworkCablingsControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureNetworkCablings = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureNetworkCabling = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkCablingService>();
                this.srvCustomerInfrastructureNetwork = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkService>();
                this.srvNetworkCablingType = SamsaraAppContext.Resolve<INetworkCablingTypeService>();
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
                NetworkCablingTypeParameters pmtNetworkCablingType = new NetworkCablingTypeParameters();

                this.controlCustomerInfrastructureNetworkCablings.nctcNetworkCablingType.Parameters = pmtNetworkCablingType;
                this.controlCustomerInfrastructureNetworkCablings.nctcNetworkCablingType.Refresh();

                this.controlCustomerInfrastructureNetworkCablings.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureNetworkCablingParameters pmtCustomerInfrastructureNetworkCabling
                = new CustomerInfrastructureNetworkCablingParameters();

            pmtCustomerInfrastructureNetworkCabling.CustomerInfrastructureNetworkId
                = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureNetworkCablings = this.srvCustomerInfrastructureNetworkCabling
                .SearchByParameters(pmtCustomerInfrastructureNetworkCabling);

            this.controlCustomerInfrastructureNetworkCablings.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureNetworkCablings.grdRelations.DataSource = this.dtCustomerInfrastructureNetworkCablings;
            if (this.CustomerInfrastructureNetwork != null)
            {
                foreach (CustomerInfrastructureNetworkCabling customerInfrastructureNetworkCabling
                    in this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkCablings)
                {
                    DataRow row = this.dtCustomerInfrastructureNetworkCablings.NewRow();
                    this.dtCustomerInfrastructureNetworkCablings.Rows.Add(row);

                    row["CustomerInfrastructureNetworkCablingId"] 
                        = customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId;
                    row["NetworkCablingTypeId"] = customerInfrastructureNetworkCabling.NetworkCablingType.NetworkCablingTypeId;
                    row["Category"] = customerInfrastructureNetworkCabling.Category;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkCablings.nctcNetworkCablingType.Value = null;
            this.controlCustomerInfrastructureNetworkCablings.txtCategory.Text = string.Empty;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureNetworkCablings.Rows.Clear();
            this.dtCustomerInfrastructureNetworkCablings.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkCabling = new CustomerInfrastructureNetworkCabling();

            this.customerInfrastructureNetworkCabling.CustomerInfrastructureNetwork = this.CustomerInfrastructureNetwork;
            this.customerInfrastructureNetworkCabling.Activated = true;
            this.customerInfrastructureNetworkCabling.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            if (entityId <= 0)
                this.customerInfrastructureNetworkCabling = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkCablings
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkCabling = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkCablings
                    .Single(x => x.CustomerInfrastructureNetworkCablingId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkCablings
                    .Remove(this.customerInfrastructureNetworkCabling);
            else
            {
                this.customerInfrastructureNetworkCabling.Activated = false;
                this.customerInfrastructureNetworkCabling.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            if (entityId <= 0)
                this.customerInfrastructureNetworkCabling = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkCablings
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkCabling = this.CustomerInfrastructureNetwork
                    .CustomerInfrastructureNetworkCablings
                    .Single(x => x.CustomerInfrastructureNetworkCablingId == entityId);

            this.controlCustomerInfrastructureNetworkCablings.nctcNetworkCablingType.Value
                = this.customerInfrastructureNetworkCabling.NetworkCablingType;

            this.controlCustomerInfrastructureNetworkCablings.txtCategory.Text
                = this.customerInfrastructureNetworkCabling.Category;
        }

        protected override void LoadEntity()
        {
            this.customerInfrastructureNetworkCabling.NetworkCablingType 
                = this.controlCustomerInfrastructureNetworkCablings.nctcNetworkCablingType.Value;

            this.customerInfrastructureNetworkCabling.Category = this.controlCustomerInfrastructureNetworkCablings.txtCategory.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (this.controlCustomerInfrastructureNetworkCablings.nctcNetworkCablingType.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el Tipo del Cable de Red.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkCablings.nctcNetworkCablingType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            if (this.customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId == -1)
                row = this.dtCustomerInfrastructureNetworkCablings.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkCablingId"])
                        == - (this.customerInfrastructureNetworkCabling as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureNetworkCablings.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkCablingId"])
                        == this.customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId);

            if (row == null)
            {
                this.CustomerInfrastructureNetwork.CustomerInfrastructureNetworkCablings
                    .Add(this.customerInfrastructureNetworkCabling);

                row = this.dtCustomerInfrastructureNetworkCablings.NewRow();
                this.dtCustomerInfrastructureNetworkCablings.Rows.Add(row);
            }

            if (this.customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId == -1)
                row["CustomerInfrastructureNetworkCablingId"]
                    = -(this.customerInfrastructureNetworkCabling as object).GetHashCode();
            else
                row["CustomerInfrastructureNetworkCablingId"]
                    = this.customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId;

            row["NetworkCablingTypeId"] = this.customerInfrastructureNetworkCabling.NetworkCablingType.NetworkCablingTypeId;
            row["Category"] = this.customerInfrastructureNetworkCabling.Category;

            this.dtCustomerInfrastructureNetworkCablings.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureNetworkCablings.nctcNetworkCablingType.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkCablings.txtCategory.ReadOnly = !enabled;
        }

        protected override CustomerInfrastructureNetworkCabling GetEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        protected override int GetEntityId()
        {
            throw new NotImplementedException();
        }

        protected override DataRow GetEntityRow(CustomerInfrastructureNetworkCabling entity)
        {
            throw new NotImplementedException();
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            NetworkCablingTypeParameters pmtNetworkCablingType = new NetworkCablingTypeParameters();

            this.controlCustomerInfrastructureNetworkCablings.nctcNetworkCablingType.Parameters = pmtNetworkCablingType;
            this.controlCustomerInfrastructureNetworkCablings.nctcNetworkCablingType.Refresh();

            IList<NetworkCablingType> cctvTypes = this.srvNetworkCablingType.GetListByParameters(pmtNetworkCablingType);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["NetworkCablingTypeId"], "NetworkCablingTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
