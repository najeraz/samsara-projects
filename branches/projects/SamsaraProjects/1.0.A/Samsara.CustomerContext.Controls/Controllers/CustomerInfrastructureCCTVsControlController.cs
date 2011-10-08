
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
    public class CustomerInfrastructureCCTVsControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureCCTVService srvCustomerInfrastructureCCTV;
        private CustomerInfrastructureCCTVsControl controlCustomerInfrastructureCCTVs;
        private CustomerInfrastructureCCTV customerInfrastructureCCTV;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private ICCTVBrandService srvCCTVBrand;
        private ICCTVTypeService srvCCTVType;

        private DataTable dtCustomerInfrastructureCCTVs;

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

        public CustomerInfrastructureCCTVsControlController(
            CustomerInfrastructureCCTVsControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureCCTVs = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureCCTV = SamsaraAppContext.Resolve<ICustomerInfrastructureCCTVService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureCCTV);
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                Assert.IsNotNull(this.srvCustomerInfrastructure);
                this.srvCCTVBrand = SamsaraAppContext.Resolve<ICCTVBrandService>();
                Assert.IsNotNull(this.srvCCTVBrand);
                this.srvCCTVType = SamsaraAppContext.Resolve<ICCTVTypeService>();
                Assert.IsNotNull(this.srvCCTVType);
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
                CCTVBrandParameters pmtCCTVBrand = new CCTVBrandParameters();

                IList<CCTVBrand> cctvBrands = this.srvCCTVBrand.GetListByParameters(pmtCCTVBrand);
                WindowsFormsUtil.LoadCombo<CCTVBrand>(this.controlCustomerInfrastructureCCTVs.uceCCTVBrand,
                    cctvBrands, "CCTVBrandId", "Name", "Seleccione");

                CCTVTypeParameters pmtCCTVType = new CCTVTypeParameters();

                IList<CCTVType> cctvTypes = this.srvCCTVType.GetListByParameters(pmtCCTVType);
                WindowsFormsUtil.LoadCombo<CCTVType>(this.controlCustomerInfrastructureCCTVs.uceCCTVType,
                    cctvTypes, "CCTVTypeId", "Name", "Seleccione");

                this.controlCustomerInfrastructureCCTVs.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureCCTVParameters pmtCustomerInfrastructureCCTV
                = new CustomerInfrastructureCCTVParameters();

            pmtCustomerInfrastructureCCTV.CustomerInfrastructureId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureCCTVs = this.srvCustomerInfrastructureCCTV
                .SearchByParameters(pmtCustomerInfrastructureCCTV);

            this.controlCustomerInfrastructureCCTVs.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureCCTVs.grdRelations.DataSource = this.dtCustomerInfrastructureCCTVs;

            if (this.CustomerInfrastructure != null)
            {
                foreach (CustomerInfrastructureCCTV customerInfrastructureCCTV
                    in this.CustomerInfrastructure.CustomerInfrastructureCCTVs)
                {
                    DataRow row = this.dtCustomerInfrastructureCCTVs.NewRow();
                    this.dtCustomerInfrastructureCCTVs.Rows.Add(row);

                    row["CustomerInfrastructureCCTVId"] = customerInfrastructureCCTV.CustomerInfrastructureCCTVId;
                    row["CCTVBrandId"] = customerInfrastructureCCTV.CCTVBrand.CCTVBrandId;
                    row["CCTVTypeId"] = customerInfrastructureCCTV.CCTVType.CCTVTypeId;
                    row["Utilization"] = customerInfrastructureCCTV.Utilization;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureCCTVs.uceCCTVBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureCCTVs.uceCCTVType.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureCCTVs.txtUtilization.Text = string.Empty;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureCCTVs.Rows.Clear();
            this.dtCustomerInfrastructureCCTVs.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureCCTV = new CustomerInfrastructureCCTV();

            this.customerInfrastructureCCTV.CustomerInfrastructure = this.CustomerInfrastructure;
            this.customerInfrastructureCCTV.Activated = true;
            this.customerInfrastructureCCTV.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureCCTV = this.CustomerInfrastructure.CustomerInfrastructureCCTVs
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureCCTV = this.CustomerInfrastructure.CustomerInfrastructureCCTVs
                    .Single(x => x.CustomerInfrastructureCCTVId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructure.CustomerInfrastructureCCTVs.Remove(this.customerInfrastructureCCTV);
            else
            {
                this.customerInfrastructureCCTV.Activated = false;
                this.customerInfrastructureCCTV.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureCCTV = this.CustomerInfrastructure.CustomerInfrastructureCCTVs
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureCCTV = this.CustomerInfrastructure.CustomerInfrastructureCCTVs
                    .Single(x => x.CustomerInfrastructureCCTVId == entityId);

            this.controlCustomerInfrastructureCCTVs.uceCCTVBrand.Value
                = this.customerInfrastructureCCTV.CCTVBrand.CCTVBrandId;

            this.controlCustomerInfrastructureCCTVs.uceCCTVType.Value
                = this.customerInfrastructureCCTV.CCTVType.CCTVTypeId;

            this.controlCustomerInfrastructureCCTVs.txtUtilization.Text
                = this.customerInfrastructureCCTV.Utilization;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureCCTV.CCTVBrand = this.srvCCTVBrand
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureCCTVs.uceCCTVBrand.Value));

            this.customerInfrastructureCCTV.CCTVType = this.srvCCTVType
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureCCTVs.uceCCTVType.Value));

            this.customerInfrastructureCCTV.Utilization = this.controlCustomerInfrastructureCCTVs.txtUtilization.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureCCTVs.uceCCTVBrand.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureCCTVs.uceCCTVBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca del CCTV.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureCCTVs.uceCCTVBrand.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructureCCTVs.uceCCTVType.Value == null ||
                Convert.ToInt32(this.controlCustomerInfrastructureCCTVs.uceCCTVType.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo del CCTV.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureCCTVs.uceCCTVType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureCCTV.CustomerInfrastructureCCTVId == -1)
                row = this.dtCustomerInfrastructureCCTVs.AsEnumerable()
                    .Single(x => Convert.ToInt32(x["CustomerInfrastructureCCTVId"])
                       == -(this.customerInfrastructureCCTV as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureCCTVs.AsEnumerable()
                    .Single(x => Convert.ToInt32(x["CustomerInfrastructureCCTVId"])
                        == this.customerInfrastructureCCTV.CustomerInfrastructureCCTVId);

            if (row == null)
            {
                this.CustomerInfrastructure.CustomerInfrastructureCCTVs.Add(this.customerInfrastructureCCTV);

                row = this.dtCustomerInfrastructureCCTVs.NewRow();
                this.dtCustomerInfrastructureCCTVs.Rows.Add(row);
            }

            if (this.customerInfrastructureCCTV.CustomerInfrastructureCCTVId == -1)
                row["CustomerInfrastructureCCTVId"] = -(this.customerInfrastructureCCTV as object).GetHashCode();
            else
                row["CustomerInfrastructureCCTVId"] = this.customerInfrastructureCCTV.CustomerInfrastructureCCTVId;

            row["CCTVBrandId"] = this.customerInfrastructureCCTV.CCTVBrand.CCTVBrandId;
            row["CCTVTypeId"] = this.customerInfrastructureCCTV.CCTVType.CCTVTypeId;
            row["Utilization"] = this.customerInfrastructureCCTV.Utilization;

            this.dtCustomerInfrastructureCCTVs.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureCCTVs.uceCCTVType.ReadOnly = !enabled;
            this.controlCustomerInfrastructureCCTVs.uceCCTVBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureCCTVs.txtUtilization.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            CCTVBrandParameters pmtCCTVBrand = new CCTVBrandParameters();

            IList<CCTVBrand> cctvBrands = this.srvCCTVBrand.GetListByParameters(pmtCCTVBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["CCTVBrandId"], "CCTVBrandId", "Name", "Seleccione");

            CCTVTypeParameters pmtCCTVType = new CCTVTypeParameters();

            IList<CCTVType> cctvTypes = this.srvCCTVType.GetListByParameters(pmtCCTVType);
            WindowsFormsUtil.LoadCombo<CCTVType>(this.controlCustomerInfrastructureCCTVs.uceCCTVType,
                cctvTypes, "CCTVTypeId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["CCTVTypeId"], "CCTVTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
