
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
    public class CustomerInfrastructureUPSsControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureUPSService srvCustomerInfrastructureUPS;
        private CustomerInfrastructureUPSsControl controlCustomerInfrastructureUPSs;
        private CustomerInfrastructureUPS customerInfrastructureUPS;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private IUPSBrandService srvUPSBrand;
        private IUPSTypeService srvUPSType;

        private DataTable dtCustomerInfrastructureUPSs;

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

        public CustomerInfrastructureUPSsControlController(
            CustomerInfrastructureUPSsControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureUPSs = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureUPS = SamsaraAppContext.Resolve<ICustomerInfrastructureUPSService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureUPS);
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                Assert.IsNotNull(this.srvCustomerInfrastructure);
                this.srvUPSBrand = SamsaraAppContext.Resolve<IUPSBrandService>();
                Assert.IsNotNull(this.srvUPSBrand);
                this.srvUPSType = SamsaraAppContext.Resolve<IUPSTypeService>();
                Assert.IsNotNull(this.srvUPSType);
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
                UPSBrandParameters pmtUPSBrand = new UPSBrandParameters();

                IList<UPSBrand> cctvBrands = this.srvUPSBrand.GetListByParameters(pmtUPSBrand);
                WindowsFormsUtil.LoadCombo<UPSBrand>(this.controlCustomerInfrastructureUPSs.uceUPSBrand,
                    cctvBrands, "UPSBrandId", "Name", "Seleccione");

                UPSTypeParameters pmtUPSType = new UPSTypeParameters();

                IList<UPSType> cctvTypes = this.srvUPSType.GetListByParameters(pmtUPSType);
                WindowsFormsUtil.LoadCombo<UPSType>(this.controlCustomerInfrastructureUPSs.uceUPSType,
                    cctvTypes, "UPSTypeId", "Name", "Seleccione");

                this.controlCustomerInfrastructureUPSs.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureUPSParameters pmtCustomerInfrastructureUPS
                = new CustomerInfrastructureUPSParameters();

            pmtCustomerInfrastructureUPS.CustomerInfrastructureId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureUPSs = this.srvCustomerInfrastructureUPS
                .SearchByParameters(pmtCustomerInfrastructureUPS);

            this.controlCustomerInfrastructureUPSs.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureUPSs.grdRelations.DataSource = this.dtCustomerInfrastructureUPSs;

            if (this.CustomerInfrastructure != null)
            {
                foreach (CustomerInfrastructureUPS customerInfrastructureUPS
                    in this.CustomerInfrastructure.CustomerInfrastructureUPSs)
                {
                    DataRow row = this.dtCustomerInfrastructureUPSs.NewRow();
                    this.dtCustomerInfrastructureUPSs.Rows.Add(row);

                    row["CustomerInfrastructureUPSId"] = this.customerInfrastructureUPS.CustomerInfrastructureUPSId;
                    row["UPSBrandId"] = this.customerInfrastructureUPS.UPSBrand.UPSBrandId;
                    row["UPSTypeId"] = this.customerInfrastructureUPS.UPSType.UPSTypeId;
                    row["Capacity"] = this.customerInfrastructureUPS.Capacity;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureUPSs.uceUPSBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureUPSs.uceUPSType.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureUPSs.txtCapacity.Text = string.Empty;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureUPSs.Rows.Clear();
            this.dtCustomerInfrastructureUPSs.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureUPS = new CustomerInfrastructureUPS();

            this.customerInfrastructureUPS.CustomerInfrastructure = this.CustomerInfrastructure;
            this.customerInfrastructureUPS.Activated = true;
            this.customerInfrastructureUPS.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureUPS = this.CustomerInfrastructure.CustomerInfrastructureUPSs
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureUPS = this.CustomerInfrastructure.CustomerInfrastructureUPSs
                    .Single(x => x.CustomerInfrastructureUPSId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructure.CustomerInfrastructureUPSs.Remove(this.customerInfrastructureUPS);
            else
            {
                this.customerInfrastructureUPS.Activated = false;
                this.customerInfrastructureUPS.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureUPS = this.CustomerInfrastructure.CustomerInfrastructureUPSs
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureUPS = this.CustomerInfrastructure.CustomerInfrastructureUPSs
                    .Single(x => x.CustomerInfrastructureUPSId == entityId);

            this.controlCustomerInfrastructureUPSs.uceUPSBrand.Value
                = this.customerInfrastructureUPS.UPSBrand.UPSBrandId;

            this.controlCustomerInfrastructureUPSs.uceUPSType.Value
                = this.customerInfrastructureUPS.UPSType.UPSTypeId;

            this.controlCustomerInfrastructureUPSs.txtCapacity.Text
                = this.customerInfrastructureUPS.Capacity;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureUPS.UPSBrand = this.srvUPSBrand
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureUPSs.uceUPSBrand.Value));

            this.customerInfrastructureUPS.UPSType = this.srvUPSType
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureUPSs.uceUPSType.Value));

            this.customerInfrastructureUPS.Capacity = this.controlCustomerInfrastructureUPSs.txtCapacity.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureUPSs.uceUPSBrand.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureUPSs.uceUPSBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca del UPS.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureUPSs.uceUPSBrand.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructureUPSs.uceUPSType.Value == null ||
                Convert.ToInt32(this.controlCustomerInfrastructureUPSs.uceUPSType.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo del UPS.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureUPSs.uceUPSType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureUPS.CustomerInfrastructureUPSId == -1)
                row = this.dtCustomerInfrastructureUPSs.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureUPSId"])
                        == -(this.customerInfrastructureUPS as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureUPSs.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureUPSId"])
                        == this.customerInfrastructureUPS.CustomerInfrastructureUPSId);

            if (row == null)
            {
                this.CustomerInfrastructure.CustomerInfrastructureUPSs.Add(this.customerInfrastructureUPS);

                row = this.dtCustomerInfrastructureUPSs.NewRow();
                this.dtCustomerInfrastructureUPSs.Rows.Add(row);
            }

            if (this.customerInfrastructureUPS.CustomerInfrastructureUPSId == -1)
                row["CustomerInfrastructureUPSId"]
                    = -(this.customerInfrastructureUPS as object).GetHashCode();
            else
                row["CustomerInfrastructureUPSId"] 
                    = this.customerInfrastructureUPS.CustomerInfrastructureUPSId;

            row["UPSBrandId"] = this.customerInfrastructureUPS.UPSBrand.UPSBrandId;
            row["UPSTypeId"] = this.customerInfrastructureUPS.UPSType.UPSTypeId;
            row["Capacity"] = this.customerInfrastructureUPS.Capacity;

            this.dtCustomerInfrastructureUPSs.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureUPSs.uceUPSType.ReadOnly = !enabled;
            this.controlCustomerInfrastructureUPSs.uceUPSBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureUPSs.txtCapacity.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            UPSBrandParameters pmtUPSBrand = new UPSBrandParameters();

            IList<UPSBrand> cctvBrands = this.srvUPSBrand.GetListByParameters(pmtUPSBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["UPSBrandId"], "UPSBrandId", "Name", "Seleccione");

            UPSTypeParameters pmtUPSType = new UPSTypeParameters();

            IList<UPSType> cctvTypes = this.srvUPSType.GetListByParameters(pmtUPSType);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["UPSTypeId"], "UPSTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
