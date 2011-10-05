
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
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
    public class CustomerInfrastructureNetworkCablingsControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureNetworkCablingService srvCustomerInfrastructureNetworkCabling;
        private CustomerInfrastructureNetworkCablingsControl controlCustomerInfrastructureNetworkCablings;
        private CustomerInfrastructureNetworkCabling customerInfrastructureNetworkCabling;
        private ICustomerInfrastructureNetworkService srvCustomerInfrastructureNetwork;
        private INetworkCablingTypeService srvNetworkCablingType;
        private System.Collections.Generic.ISet<CustomerInfrastructureNetworkCabling> customerInfrastructureNetworkCablings;

        private DataTable dtCustomerInfrastructureNetworkCablings;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// Id de la entidad padre
        /// </summary>
        public Nullable<int> CustomerInfrastructureNetworkId
        {
            get;
            set;
        }

        public System.Collections.Generic.ISet<CustomerInfrastructureNetworkCabling> CustomerInfrastructureNetworkCablings
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureNetworkCabling> tmp
                    = new HashSet<CustomerInfrastructureNetworkCabling>();

                foreach(CustomerInfrastructureNetworkCabling customerInfrastructureNetworkCabling in
                    this.customerInfrastructureNetworkCablings)
                {
                    customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId 
                        = customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId <= 0 ?
                        -1 : customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId;

                    tmp.Add(customerInfrastructureNetworkCabling);
                }

                return tmp;
            }
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
                Assert.IsNotNull(this.srvCustomerInfrastructureNetworkCabling);
                this.srvCustomerInfrastructureNetwork = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetwork);
                this.srvNetworkCablingType = SamsaraAppContext.Resolve<INetworkCablingTypeService>();
                Assert.IsNotNull(this.srvNetworkCablingType);
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

                IList<NetworkCablingType> cctvTypes = this.srvNetworkCablingType.GetListByParameters(pmtNetworkCablingType);
                WindowsFormsUtil.LoadCombo<NetworkCablingType>(this.controlCustomerInfrastructureNetworkCablings.uceNetworkCablingType,
                    cctvTypes, "NetworkCablingTypeId", "Name", "Seleccione");

                this.controlCustomerInfrastructureNetworkCablings.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            if (this.CustomerInfrastructureNetworkId != null)
            {
                CustomerInfrastructureNetworkCablingParameters pmtCustomerInfrastructureNetworkCabling
                    = new CustomerInfrastructureNetworkCablingParameters();

                pmtCustomerInfrastructureNetworkCabling.CustomerInfrastructureNetworkId 
                    = this.CustomerInfrastructureNetworkId;

                this.dtCustomerInfrastructureNetworkCablings = this.srvCustomerInfrastructureNetworkCabling
                    .SearchByParameters(pmtCustomerInfrastructureNetworkCabling);

                this.controlCustomerInfrastructureNetworkCablings.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureNetworkCablings.grdRelations.DataSource = this.dtCustomerInfrastructureNetworkCablings;

                IList<CustomerInfrastructureNetworkCabling> lstCustomerInfrastructureNetworkCablings 
                    = this.srvCustomerInfrastructureNetworkCabling.GetListByParameters(pmtCustomerInfrastructureNetworkCabling);

                this.customerInfrastructureNetworkCablings = new HashSet<CustomerInfrastructureNetworkCabling>();

                foreach (CustomerInfrastructureNetworkCabling customerInfrastructureNetworkCabling in
                    lstCustomerInfrastructureNetworkCablings)
                {
                    this.customerInfrastructureNetworkCablings.Add(customerInfrastructureNetworkCabling);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkCablings.uceNetworkCablingType.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureNetworkCablings.txtCategory.Text = string.Empty;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkCabling = new CustomerInfrastructureNetworkCabling();

            this.customerInfrastructureNetworkCabling.Activated = true;
            this.customerInfrastructureNetworkCabling.Deleted = false;
            this.customerInfrastructureNetworkCabling.CustomerInfrastructureNetwork 
                = this.srvCustomerInfrastructureNetwork.GetById(this.CustomerInfrastructureNetworkId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureNetworkCabling = this.customerInfrastructureNetworkCablings
                .Single(x => x.CustomerInfrastructureNetworkCablingId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkCablings.Remove(this.customerInfrastructureNetworkCabling);
            else
            {
                this.customerInfrastructureNetworkCabling.Activated = false;
                this.customerInfrastructureNetworkCabling.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureNetworkCabling = this.customerInfrastructureNetworkCablings
                .Single(x => x.CustomerInfrastructureNetworkCablingId == entityId);

            this.controlCustomerInfrastructureNetworkCablings.uceNetworkCablingType.Value
                = this.customerInfrastructureNetworkCabling.NetworkCablingType.NetworkCablingTypeId;

            this.controlCustomerInfrastructureNetworkCablings.txtCategory.Text
                = this.customerInfrastructureNetworkCabling.Category;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureNetworkCabling.NetworkCablingType = this.srvNetworkCablingType
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureNetworkCablings.uceNetworkCablingType.Value));

            this.customerInfrastructureNetworkCabling.Category = this.controlCustomerInfrastructureNetworkCablings.txtCategory.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureNetworkCablings.uceNetworkCablingType.Value == null ||
                Convert.ToInt32(this.controlCustomerInfrastructureNetworkCablings.uceNetworkCablingType.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo del Cable de Red.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkCablings.uceNetworkCablingType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId == -1)
            {
                this.customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId = this.entityCounter--;
                this.customerInfrastructureNetworkCablings.Add(this.customerInfrastructureNetworkCabling);

                row = this.dtCustomerInfrastructureNetworkCablings.NewRow();
                this.dtCustomerInfrastructureNetworkCablings.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureNetworkCablings.AsEnumerable().Single(x => Convert.ToInt32(x["CustomerInfrastructureNetworkCablingId"])
                        == this.customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId);
            }

            row["CustomerInfrastructureNetworkCablingId"] = this.customerInfrastructureNetworkCabling.CustomerInfrastructureNetworkCablingId;
            row["NetworkCablingTypeId"] = this.customerInfrastructureNetworkCabling.NetworkCablingType.NetworkCablingTypeId;
            row["Category"] = this.customerInfrastructureNetworkCabling.Category;

            this.dtCustomerInfrastructureNetworkCablings.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureNetworkCablings.uceNetworkCablingType.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkCablings.txtCategory.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            NetworkCablingTypeParameters pmtNetworkCablingType = new NetworkCablingTypeParameters();

            IList<NetworkCablingType> cctvTypes = this.srvNetworkCablingType.GetListByParameters(pmtNetworkCablingType);
            WindowsFormsUtil.LoadCombo<NetworkCablingType>(this.controlCustomerInfrastructureNetworkCablings.uceNetworkCablingType,
                cctvTypes, "NetworkCablingTypeId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["NetworkCablingTypeId"], "NetworkCablingTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
