
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
    public class CustomerInfrastructureTelephoniesControlController : ManyToOneLevel1ControlController<CustomerInfrastructureTelephony>
    {
        #region Attributes

        private ICustomerInfrastructureTelephonyService srvCustomerInfrastructureTelephony;
        private CustomerInfrastructureTelephoniesControl controlCustomerInfrastructureTelephonies;
        private CustomerInfrastructureTelephony customerInfrastructureTelephony;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private ITelephonyProviderService srvTelephonyProvider;
        private ITelephonyLineTypeService srvTelephonyLineType;

        private DataTable dtCustomerInfrastructureTelephonies;

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

        public CustomerInfrastructureTelephoniesControlController(
            CustomerInfrastructureTelephoniesControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureTelephonies = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureTelephony = SamsaraAppContext.Resolve<ICustomerInfrastructureTelephonyService>();
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                this.srvTelephonyProvider = SamsaraAppContext.Resolve<ITelephonyProviderService>();
                this.srvTelephonyLineType = SamsaraAppContext.Resolve<ITelephonyLineTypeService>();
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
                TelephonyProviderParameters pmtTelephonyProvider = new TelephonyProviderParameters();

                this.controlCustomerInfrastructureTelephonies.tpcTelephonyProvider.Parameters = pmtTelephonyProvider;
                this.controlCustomerInfrastructureTelephonies.tpcTelephonyProvider.Refresh();

                TelephonyLineTypeParameters pmtTelephonyLineType = new TelephonyLineTypeParameters();

                this.controlCustomerInfrastructureTelephonies.tltcTelephonyLineType.Parameters = pmtTelephonyLineType;
                this.controlCustomerInfrastructureTelephonies.tltcTelephonyLineType.Refresh();

                this.controlCustomerInfrastructureTelephonies.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureTelephonyParameters pmtCustomerInfrastructureTelephony
                = new CustomerInfrastructureTelephonyParameters();

            pmtCustomerInfrastructureTelephony.CustomerInfrastructureId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureTelephonies = this.srvCustomerInfrastructureTelephony
                .SearchByParameters(pmtCustomerInfrastructureTelephony);

            this.controlCustomerInfrastructureTelephonies.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureTelephonies.grdRelations.DataSource = this.dtCustomerInfrastructureTelephonies;

            if (this.CustomerInfrastructure != null)
            {
                foreach (CustomerInfrastructureTelephony customerInfrastructureTelephony
                    in this.CustomerInfrastructure.CustomerInfrastructureTelephonies)
                {
                    DataRow row = this.dtCustomerInfrastructureTelephonies.NewRow();
                    this.dtCustomerInfrastructureTelephonies.Rows.Add(row);

                    row["CustomerInfrastructureTelephonyId"] 
                        = customerInfrastructureTelephony.CustomerInfrastructureTelephonyId;
                    row["TelephonyProviderId"] = customerInfrastructureTelephony.TelephonyProvider.TelephonyProviderId;
                    row["TelephonyLineTypeId"] = customerInfrastructureTelephony.TelephonyLineType.TelephonyLineTypeId;
                    row["NumberOfLines"] = customerInfrastructureTelephony.NumberOfLines;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureTelephonies.tpcTelephonyProvider.Value = null;
            this.controlCustomerInfrastructureTelephonies.tltcTelephonyLineType.Value = null;
            this.controlCustomerInfrastructureTelephonies.steNumberOfLines.Value = null;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureTelephonies.Rows.Clear();
            this.dtCustomerInfrastructureTelephonies.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureTelephony = new CustomerInfrastructureTelephony();

            this.customerInfrastructureTelephony.CustomerInfrastructure = this.CustomerInfrastructure;
            this.customerInfrastructureTelephony.Activated = true;
            this.customerInfrastructureTelephony.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            if (entityId <= 0)
                this.customerInfrastructureTelephony = this.CustomerInfrastructure.CustomerInfrastructureTelephonies
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureTelephony = this.CustomerInfrastructure.CustomerInfrastructureTelephonies
                    .Single(x => x.CustomerInfrastructureTelephonyId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructure.CustomerInfrastructureTelephonies.Remove(this.customerInfrastructureTelephony);
            else
            {
                this.customerInfrastructureTelephony.Activated = false;
                this.customerInfrastructureTelephony.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            if (entityId <= 0)
                this.customerInfrastructureTelephony = this.CustomerInfrastructure.CustomerInfrastructureTelephonies
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureTelephony = this.CustomerInfrastructure.CustomerInfrastructureTelephonies
                    .Single(x => x.CustomerInfrastructureTelephonyId == entityId);

            this.controlCustomerInfrastructureTelephonies.tpcTelephonyProvider.Value
                = this.customerInfrastructureTelephony.TelephonyProvider;

            this.controlCustomerInfrastructureTelephonies.tltcTelephonyLineType.Value
                = this.customerInfrastructureTelephony.TelephonyLineType;

            this.controlCustomerInfrastructureTelephonies.steNumberOfLines.Value
                = this.customerInfrastructureTelephony.NumberOfLines;
        }

        protected override void LoadEntity()
        {
            this.customerInfrastructureTelephony.TelephonyProvider
                = this.controlCustomerInfrastructureTelephonies.tpcTelephonyProvider.Value;

            this.customerInfrastructureTelephony.TelephonyLineType
                = this.controlCustomerInfrastructureTelephonies.tltcTelephonyLineType.Value;

            this.customerInfrastructureTelephony.NumberOfLines 
                = Convert.ToInt32(this.controlCustomerInfrastructureTelephonies.steNumberOfLines.Value);
        }

        protected override bool ValidateControlsData()
        {
            if (this.controlCustomerInfrastructureTelephonies.tpcTelephonyProvider.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el Proveedor de Internet.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureTelephonies.tpcTelephonyProvider.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructureTelephonies.tltcTelephonyLineType.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el Tipo de Linea Telefónica.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureTelephonies.tltcTelephonyLineType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            if (this.customerInfrastructureTelephony.CustomerInfrastructureTelephonyId == -1)
                row = this.dtCustomerInfrastructureTelephonies.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureTelephonyId"])
                        == -(this.customerInfrastructureTelephony as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureTelephonies.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureTelephonyId"])
                        == this.customerInfrastructureTelephony.CustomerInfrastructureTelephonyId);

            if (row == null)
            {
                this.CustomerInfrastructure.CustomerInfrastructureTelephonies.Add(this.customerInfrastructureTelephony);

                row = this.dtCustomerInfrastructureTelephonies.NewRow();
                this.dtCustomerInfrastructureTelephonies.Rows.Add(row);
            }

            if (this.customerInfrastructureTelephony.CustomerInfrastructureTelephonyId == -1)
                row["CustomerInfrastructureTelephonyId"]
                    = -(this.customerInfrastructureTelephony as object).GetHashCode();
            else
                row["CustomerInfrastructureTelephonyId"] 
                    = this.customerInfrastructureTelephony.CustomerInfrastructureTelephonyId;

            row["TelephonyProviderId"] = this.customerInfrastructureTelephony.TelephonyProvider.TelephonyProviderId;
            row["TelephonyLineTypeId"] = this.customerInfrastructureTelephony.TelephonyLineType.TelephonyLineTypeId;
            row["NumberOfLines"] = this.customerInfrastructureTelephony.NumberOfLines;

            this.dtCustomerInfrastructureTelephonies.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureTelephonies.tltcTelephonyLineType.ReadOnly = !enabled;
            this.controlCustomerInfrastructureTelephonies.tpcTelephonyProvider.ReadOnly = !enabled;
            this.controlCustomerInfrastructureTelephonies.steNumberOfLines.ReadOnly = !enabled;
        }

        protected override CustomerInfrastructureTelephony GetEntity(int entityId)
        {
            if (entityId <= 0)
                return this.CustomerInfrastructure.CustomerInfrastructureTelephonies
                    .Single(x => -x.GetHashCode() == entityId);
            else
                return this.CustomerInfrastructure.CustomerInfrastructureTelephonies
                    .Single(x => x.CustomerInfrastructureTelephonyId == entityId);
        }

        protected override int GetEntityId()
        {
            if (this.customerInfrastructureTelephony.CustomerInfrastructureTelephonyId <= 0)
                return -this.customerInfrastructureTelephony.GetHashCode();
            else
                return this.customerInfrastructureTelephony.CustomerInfrastructureTelephonyId;
        }

        protected override DataRow GetEntityRow(CustomerInfrastructureTelephony entity)
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

            TelephonyProviderParameters pmtTelephonyProvider = new TelephonyProviderParameters();

            IList<TelephonyProvider> cctvBrands = this.srvTelephonyProvider.GetListByParameters(pmtTelephonyProvider);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["TelephonyProviderId"], "TelephonyProviderId", "Name", "Seleccione");

            TelephonyLineTypeParameters pmtTelephonyLineType = new TelephonyLineTypeParameters();

            IList<TelephonyLineType> cctvTypes = this.srvTelephonyLineType.GetListByParameters(pmtTelephonyLineType);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["TelephonyLineTypeId"], "TelephonyLineTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
