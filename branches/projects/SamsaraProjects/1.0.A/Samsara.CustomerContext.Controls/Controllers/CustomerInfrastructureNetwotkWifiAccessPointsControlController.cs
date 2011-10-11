
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
    public class CustomerInfrastructureNetworkWifiAccessPointsControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureNetworkWifiAccessPointService srvCustomerInfrastructureNetworkWifiAccessPoint;
        private CustomerInfrastructureNetworkWifiAccessPointsControl controlCustomerInfrastructureNetworkWifiAccessPoints;
        private CustomerInfrastructureNetworkWifiAccessPoint customerInfrastructureNetworkWifiAccessPoint;
        private ICustomerInfrastructureNetworkWifiService srvCustomerInfrastructureNetworkWifi;
        private IAccessPointBrandService srvAccessPointBrand;
        private IAccessPointTypeService srvAccessPointType;

        private DataTable dtCustomerInfrastructureNetworkWifiAccessPoints;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureNetworkWifi CustomerInfrastructureNetworkWifi
        {
            get;
            set;
        }
        
        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructureNetworkWifiAccessPointsControlController(
            CustomerInfrastructureNetworkWifiAccessPointsControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureNetworkWifiAccessPoints = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureNetworkWifiAccessPoint = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkWifiAccessPointService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetworkWifiAccessPoint);
                this.srvCustomerInfrastructureNetworkWifi = SamsaraAppContext.Resolve<ICustomerInfrastructureNetworkWifiService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureNetworkWifi);
                this.srvAccessPointBrand = SamsaraAppContext.Resolve<IAccessPointBrandService>();
                Assert.IsNotNull(this.srvAccessPointBrand);
                this.srvAccessPointType = SamsaraAppContext.Resolve<IAccessPointTypeService>();
                Assert.IsNotNull(this.srvAccessPointType);
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
                AccessPointBrandParameters pmtAccessPointBrand = new AccessPointBrandParameters();

                IList<AccessPointBrand> cctvBrands = this.srvAccessPointBrand.GetListByParameters(pmtAccessPointBrand);
                WindowsFormsUtil.LoadCombo<AccessPointBrand>(this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointBrand,
                    cctvBrands, "AccessPointBrandId", "Name", "Seleccione");

                AccessPointTypeParameters pmtAccessPointType = new AccessPointTypeParameters();

                IList<AccessPointType> cctvTypes = this.srvAccessPointType.GetListByParameters(pmtAccessPointType);
                WindowsFormsUtil.LoadCombo<AccessPointType>(this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointType,
                    cctvTypes, "AccessPointTypeId", "Name", "Seleccione");

                this.controlCustomerInfrastructureNetworkWifiAccessPoints.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureNetworkWifiAccessPointParameters pmtCustomerInfrastructureNetworkWifiAccessPoint
                = new CustomerInfrastructureNetworkWifiAccessPointParameters();

            pmtCustomerInfrastructureNetworkWifiAccessPoint.CustomerInfrastructureNetworkWifiId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureNetworkWifiAccessPoints = this.srvCustomerInfrastructureNetworkWifiAccessPoint
                .SearchByParameters(pmtCustomerInfrastructureNetworkWifiAccessPoint);

            this.controlCustomerInfrastructureNetworkWifiAccessPoints.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureNetworkWifiAccessPoints.grdRelations.DataSource
                = this.dtCustomerInfrastructureNetworkWifiAccessPoints;

            if (this.CustomerInfrastructureNetworkWifi != null)
            {
                foreach (CustomerInfrastructureNetworkWifiAccessPoint customerInfrastructureNetworkWifiAccessPoint
                    in this.CustomerInfrastructureNetworkWifi.CustomerInfrastructureNetworkWifiAccessPoints)
                {
                    DataRow row = this.dtCustomerInfrastructureNetworkWifiAccessPoints.NewRow();
                    this.dtCustomerInfrastructureNetworkWifiAccessPoints.Rows.Add(row);

                    row["CustomerInfrastructureNetworkWifiAccessPointId"] = customerInfrastructureNetworkWifiAccessPoint
                        .CustomerInfrastructureNetworkWifiAccessPointId;
                    row["AccessPointBrandId"] = customerInfrastructureNetworkWifiAccessPoint.AccessPointBrand.AccessPointBrandId;
                    row["AccessPointTypeId"] = customerInfrastructureNetworkWifiAccessPoint.AccessPointType.AccessPointTypeId;
                    row["Model"] = customerInfrastructureNetworkWifiAccessPoint.Model;
                    row["Distance"] = customerInfrastructureNetworkWifiAccessPoint.Distance;
                    row["BandWidth"] = customerInfrastructureNetworkWifiAccessPoint.BandWidth;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointType.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtModel.Text = string.Empty;
            this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtBandWidth.Text = string.Empty;
            this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtDistance.Text = string.Empty;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureNetworkWifiAccessPoints.Rows.Clear();
            this.dtCustomerInfrastructureNetworkWifiAccessPoints.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureNetworkWifiAccessPoint = new CustomerInfrastructureNetworkWifiAccessPoint();

            this.customerInfrastructureNetworkWifiAccessPoint.CustomerInfrastructureNetworkWifi
                = this.CustomerInfrastructureNetworkWifi;
            this.customerInfrastructureNetworkWifiAccessPoint.Activated = true;
            this.customerInfrastructureNetworkWifiAccessPoint.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkWifiAccessPoint = this.CustomerInfrastructureNetworkWifi
                    .CustomerInfrastructureNetworkWifiAccessPoints.Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkWifiAccessPoint = this.CustomerInfrastructureNetworkWifi
                    .CustomerInfrastructureNetworkWifiAccessPoints
                    .Single(x => x.CustomerInfrastructureNetworkWifiAccessPointId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructureNetworkWifi.CustomerInfrastructureNetworkWifiAccessPoints
                    .Remove(this.customerInfrastructureNetworkWifiAccessPoint);
            else
            {
                this.customerInfrastructureNetworkWifiAccessPoint.Activated = false;
                this.customerInfrastructureNetworkWifiAccessPoint.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureNetworkWifiAccessPoint = this.CustomerInfrastructureNetworkWifi
                    .CustomerInfrastructureNetworkWifiAccessPoints.Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureNetworkWifiAccessPoint = this.CustomerInfrastructureNetworkWifi
                    .CustomerInfrastructureNetworkWifiAccessPoints
                    .Single(x => x.CustomerInfrastructureNetworkWifiAccessPointId == entityId);

            this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointBrand.Value
                = this.customerInfrastructureNetworkWifiAccessPoint.AccessPointBrand.AccessPointBrandId;

            this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointType.Value
                = this.customerInfrastructureNetworkWifiAccessPoint.AccessPointType.AccessPointTypeId;

            this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtModel.Text
                = this.customerInfrastructureNetworkWifiAccessPoint.Model;

            this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtDistance.Text
                = this.customerInfrastructureNetworkWifiAccessPoint.Distance;

            this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtBandWidth.Text
                = this.customerInfrastructureNetworkWifiAccessPoint.BandWidth;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureNetworkWifiAccessPoint.AccessPointBrand = this.srvAccessPointBrand
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointBrand.Value));

            this.customerInfrastructureNetworkWifiAccessPoint.AccessPointType = this.srvAccessPointType
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointType.Value));

            this.customerInfrastructureNetworkWifiAccessPoint.Model
                = this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtModel.Text;

            this.customerInfrastructureNetworkWifiAccessPoint.BandWidth
                = this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtBandWidth.Text;

            this.customerInfrastructureNetworkWifiAccessPoint.Distance
                = this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtDistance.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointBrand.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Punto de Acceso.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointBrand.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointType.Value == null ||
                Convert.ToInt32(this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointType.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo del Punto de Acceso.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureNetworkWifiAccessPoint.CustomerInfrastructureNetworkWifiAccessPointId == -1)
                row = this.dtCustomerInfrastructureNetworkWifiAccessPoints.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkWifiAccessPointId"])
                        == -(this.customerInfrastructureNetworkWifiAccessPoint as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureNetworkWifiAccessPoints.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureNetworkWifiAccessPointId"])
                        == this.customerInfrastructureNetworkWifiAccessPoint.CustomerInfrastructureNetworkWifiAccessPointId);

            if (row == null)
            {
                this.CustomerInfrastructureNetworkWifi.CustomerInfrastructureNetworkWifiAccessPoints
                    .Add(this.customerInfrastructureNetworkWifiAccessPoint);

                row = this.dtCustomerInfrastructureNetworkWifiAccessPoints.NewRow();
                this.dtCustomerInfrastructureNetworkWifiAccessPoints.Rows.Add(row);
            }

            if (this.customerInfrastructureNetworkWifiAccessPoint.CustomerInfrastructureNetworkWifiAccessPointId == -1)
                row["CustomerInfrastructureNetworkWifiAccessPointId"]
                    = -(this.customerInfrastructureNetworkWifiAccessPoint as object).GetHashCode();
            else
                row["CustomerInfrastructureNetworkWifiAccessPointId"] = this.customerInfrastructureNetworkWifiAccessPoint
                    .CustomerInfrastructureNetworkWifiAccessPointId;

            row["AccessPointBrandId"] = this.customerInfrastructureNetworkWifiAccessPoint.AccessPointBrand.AccessPointBrandId;
            row["AccessPointTypeId"] = this.customerInfrastructureNetworkWifiAccessPoint.AccessPointType.AccessPointTypeId;
            row["Model"] = this.customerInfrastructureNetworkWifiAccessPoint.Model;
            row["Distance"] = this.customerInfrastructureNetworkWifiAccessPoint.Distance;
            row["BandWidth"] = this.customerInfrastructureNetworkWifiAccessPoint.BandWidth;

            this.dtCustomerInfrastructureNetworkWifiAccessPoints.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointType.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtModel.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtBandWidth.ReadOnly = !enabled;
            this.controlCustomerInfrastructureNetworkWifiAccessPoints.txtDistance.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            AccessPointBrandParameters pmtAccessPointBrand = new AccessPointBrandParameters();

            IList<AccessPointBrand> cctvBrands = this.srvAccessPointBrand.GetListByParameters(pmtAccessPointBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["AccessPointBrandId"], "AccessPointBrandId", "Name", "Seleccione");

            AccessPointTypeParameters pmtAccessPointType = new AccessPointTypeParameters();

            IList<AccessPointType> cctvTypes = this.srvAccessPointType.GetListByParameters(pmtAccessPointType);
            WindowsFormsUtil.LoadCombo<AccessPointType>(this.controlCustomerInfrastructureNetworkWifiAccessPoints.uceAccessPointType,
                cctvTypes, "AccessPointTypeId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["AccessPointTypeId"], "AccessPointTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
