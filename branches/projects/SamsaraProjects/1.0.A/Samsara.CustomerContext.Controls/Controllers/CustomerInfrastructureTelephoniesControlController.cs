
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
    public class CustomerInfrastructureTelephoniesControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureTelephonyService srvCustomerInfrastructureTelephony;
        private CustomerInfrastructureTelephoniesControl controlCustomerInfrastructureTelephonies;
        private CustomerInfrastructureTelephony customerInfrastructureTelephony;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private ITelephonyProviderService srvTelephonyProvider;
        private ITelephonyLineTypeService srvTelephonyLineType;
        private System.Collections.Generic.ISet<CustomerInfrastructureTelephony> customerInfrastructureTelephonys;

        private DataTable dtCustomerInfrastructureTelephonies;

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

        public System.Collections.Generic.ISet<CustomerInfrastructureTelephony> CustomerInfrastructureTelephonies
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureTelephony> tmp
                    = new HashSet<CustomerInfrastructureTelephony>();

                foreach(CustomerInfrastructureTelephony customerInfrastructureTelephony in
                    this.customerInfrastructureTelephonys)
                {
                    customerInfrastructureTelephony.CustomerInfrastructureTelephonyId 
                        = customerInfrastructureTelephony.CustomerInfrastructureTelephonyId <= 0 ?
                        -1 : customerInfrastructureTelephony.CustomerInfrastructureTelephonyId;

                    tmp.Add(customerInfrastructureTelephony);
                }

                return tmp;
            }
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
                Assert.IsNotNull(this.srvCustomerInfrastructureTelephony);
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                Assert.IsNotNull(this.srvCustomerInfrastructure);
                this.srvTelephonyProvider = SamsaraAppContext.Resolve<ITelephonyProviderService>();
                Assert.IsNotNull(this.srvTelephonyProvider);
                this.srvTelephonyLineType = SamsaraAppContext.Resolve<ITelephonyLineTypeService>();
                Assert.IsNotNull(this.srvTelephonyLineType);
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

                IList<TelephonyProvider> cctvBrands = this.srvTelephonyProvider.GetListByParameters(pmtTelephonyProvider);
                WindowsFormsUtil.LoadCombo<TelephonyProvider>(this.controlCustomerInfrastructureTelephonies.uceTelephonyProvider,
                    cctvBrands, "TelephonyProviderId", "Name", "Seleccione");

                TelephonyLineTypeParameters pmtTelephonyLineType = new TelephonyLineTypeParameters();

                IList<TelephonyLineType> cctvTypes = this.srvTelephonyLineType.GetListByParameters(pmtTelephonyLineType);
                WindowsFormsUtil.LoadCombo<TelephonyLineType>(this.controlCustomerInfrastructureTelephonies.uceTelephonyLineType,
                    cctvTypes, "TelephonyLineTypeId", "Name", "Seleccione");

                this.controlCustomerInfrastructureTelephonies.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            if (this.CustomerInfrastructureId != null)
            {
                CustomerInfrastructureTelephonyParameters pmtCustomerInfrastructureTelephony
                    = new CustomerInfrastructureTelephonyParameters();

                pmtCustomerInfrastructureTelephony.CustomerInfrastructureId = this.CustomerInfrastructureId;

                this.dtCustomerInfrastructureTelephonies = this.srvCustomerInfrastructureTelephony
                    .SearchByParameters(pmtCustomerInfrastructureTelephony);

                this.controlCustomerInfrastructureTelephonies.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureTelephonies.grdRelations.DataSource = this.dtCustomerInfrastructureTelephonies;

                IList<CustomerInfrastructureTelephony> lstCustomerInfrastructureTelephonies
                    = this.srvCustomerInfrastructureTelephony.GetListByParameters(pmtCustomerInfrastructureTelephony);

                this.customerInfrastructureTelephonys = new HashSet<CustomerInfrastructureTelephony>();

                foreach (CustomerInfrastructureTelephony customerInfrastructureTelephony in
                    lstCustomerInfrastructureTelephonies)
                {
                    this.customerInfrastructureTelephonys.Add(customerInfrastructureTelephony);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureTelephonies.uceTelephonyProvider.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureTelephonies.uceTelephonyLineType.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureTelephonies.steNumberOfLines.Value = null;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureTelephony = new CustomerInfrastructureTelephony();

            this.customerInfrastructureTelephony.Activated = true;
            this.customerInfrastructureTelephony.Deleted = false;
            this.customerInfrastructureTelephony.CustomerInfrastructure 
                = this.srvCustomerInfrastructure.GetById(this.CustomerInfrastructureId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureTelephony = this.customerInfrastructureTelephonys
                .Single(x => x.CustomerInfrastructureTelephonyId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureTelephonys.Remove(this.customerInfrastructureTelephony);
            else
            {
                this.customerInfrastructureTelephony.Activated = false;
                this.customerInfrastructureTelephony.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureTelephony = this.customerInfrastructureTelephonys
                .Single(x => x.CustomerInfrastructureTelephonyId == entityId);

            this.controlCustomerInfrastructureTelephonies.uceTelephonyProvider.Value
                = this.customerInfrastructureTelephony.TelephonyProvider.TelephonyProviderId;

            this.controlCustomerInfrastructureTelephonies.uceTelephonyLineType.Value
                = this.customerInfrastructureTelephony.TelephonyLineType.TelephonyLineTypeId;

            this.controlCustomerInfrastructureTelephonies.steNumberOfLines.Value
                = this.customerInfrastructureTelephony.NumberOfLines;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureTelephony.TelephonyProvider = this.srvTelephonyProvider
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureTelephonies.uceTelephonyProvider.Value));

            this.customerInfrastructureTelephony.TelephonyLineType = this.srvTelephonyLineType
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureTelephonies.uceTelephonyLineType.Value));

            this.customerInfrastructureTelephony.NumberOfLines 
                = Convert.ToInt32(this.controlCustomerInfrastructureTelephonies.steNumberOfLines.Value);
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureTelephonies.uceTelephonyProvider.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureTelephonies.uceTelephonyProvider.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Proveedor de Internet.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureTelephonies.uceTelephonyProvider.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructureTelephonies.uceTelephonyLineType.Value == null ||
                Convert.ToInt32(this.controlCustomerInfrastructureTelephonies.uceTelephonyLineType.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo de Linea Telefónica.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureTelephonies.uceTelephonyLineType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureTelephony.CustomerInfrastructureTelephonyId == -1)
            {
                this.customerInfrastructureTelephony.CustomerInfrastructureTelephonyId = this.entityCounter--;
                this.customerInfrastructureTelephonys.Add(this.customerInfrastructureTelephony);

                row = this.dtCustomerInfrastructureTelephonies.NewRow();
                this.dtCustomerInfrastructureTelephonies.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureTelephonies.AsEnumerable().Single(x => Convert.ToInt32(x["CustomerInfrastructureTelephonyId"])
                        == this.customerInfrastructureTelephony.CustomerInfrastructureTelephonyId);
            }

            row["CustomerInfrastructureTelephonyId"] = this.customerInfrastructureTelephony.CustomerInfrastructureTelephonyId;
            row["TelephonyProviderId"] = this.customerInfrastructureTelephony.TelephonyProvider.TelephonyProviderId;
            row["TelephonyLineTypeId"] = this.customerInfrastructureTelephony.TelephonyLineType.TelephonyLineTypeId;
            row["NumberOfLines"] = this.customerInfrastructureTelephony.NumberOfLines;

            this.dtCustomerInfrastructureTelephonies.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureTelephonies.uceTelephonyLineType.ReadOnly = !enabled;
            this.controlCustomerInfrastructureTelephonies.uceTelephonyProvider.ReadOnly = !enabled;
            this.controlCustomerInfrastructureTelephonies.steNumberOfLines.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            TelephonyProviderParameters pmtTelephonyProvider = new TelephonyProviderParameters();

            IList<TelephonyProvider> cctvBrands = this.srvTelephonyProvider.GetListByParameters(pmtTelephonyProvider);
            WindowsFormsUtil.LoadCombo<TelephonyProvider>(this.controlCustomerInfrastructureTelephonies.uceTelephonyProvider,
                cctvBrands, "TelephonyProviderId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["TelephonyProviderId"], "TelephonyProviderId", "Name", "Seleccione");

            TelephonyLineTypeParameters pmtTelephonyLineType = new TelephonyLineTypeParameters();

            IList<TelephonyLineType> cctvTypes = this.srvTelephonyLineType.GetListByParameters(pmtTelephonyLineType);
            WindowsFormsUtil.LoadCombo<TelephonyLineType>(this.controlCustomerInfrastructureTelephonies.uceTelephonyLineType,
                cctvTypes, "TelephonyLineTypeId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["TelephonyLineTypeId"], "TelephonyLineTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
