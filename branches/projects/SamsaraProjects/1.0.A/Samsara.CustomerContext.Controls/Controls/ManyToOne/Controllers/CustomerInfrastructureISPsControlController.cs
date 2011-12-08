
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
using Samsara.Base.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers
{
    public class CustomerInfrastructureISPsControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureISPService srvCustomerInfrastructureISP;
        private CustomerInfrastructureISPsControl controlCustomerInfrastructureISPs;
        private CustomerInfrastructureISP customerInfrastructureISP;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private IISPService srvISP;

        private DataTable dtCustomerInfrastructureISPs;

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

        public CustomerInfrastructureISPsControlController(
            CustomerInfrastructureISPsControl instance)
            : base(instance)
        {
            this.controlCustomerInfrastructureISPs = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureISP = SamsaraAppContext.Resolve<ICustomerInfrastructureISPService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureISP);
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                Assert.IsNotNull(this.srvCustomerInfrastructure);
                this.srvISP = SamsaraAppContext.Resolve<IISPService>();
                Assert.IsNotNull(this.srvISP);

                this.InitializeControlControls();
            }
        }

        #endregion Constructor

        #region Methods

        #region Private

        private void InitializeControlControls()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                ISPParameters pmtISP = new ISPParameters();

                this.controlCustomerInfrastructureISPs.icISP.Parameters = pmtISP;
                this.controlCustomerInfrastructureISPs.icISP.Refresh();

                this.controlCustomerInfrastructureISPs.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureISPParameters pmtCustomerInfrastructureISP
                = new CustomerInfrastructureISPParameters();

            pmtCustomerInfrastructureISP.CustomerInfrastructureId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureISPs = this.srvCustomerInfrastructureISP
                .SearchByParameters(pmtCustomerInfrastructureISP);

            this.controlCustomerInfrastructureISPs.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureISPs.grdRelations.DataSource = this.dtCustomerInfrastructureISPs;

            if (this.CustomerInfrastructure != null)
            {
                foreach (CustomerInfrastructureISP customerInfrastructureISP
                    in this.CustomerInfrastructure.CustomerInfrastructureISPs)
                {
                    DataRow row = this.dtCustomerInfrastructureISPs.NewRow();
                    this.dtCustomerInfrastructureISPs.Rows.Add(row);

                    row["CustomerInfrastructureISPId"] = customerInfrastructureISP.CustomerInfrastructureISPId;
                    row["ISPId"] = customerInfrastructureISP.ISP.ISPId;
                    row["Bandwidth"] = customerInfrastructureISP.Bandwidth;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureISPs.icISP.Value = null;
            this.controlCustomerInfrastructureISPs.steBandwidth.Value = null;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureISPs.Rows.Clear();
            this.dtCustomerInfrastructureISPs.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureISP = new CustomerInfrastructureISP();

            this.customerInfrastructureISP.CustomerInfrastructure = this.CustomerInfrastructure;
            this.customerInfrastructureISP.Activated = true;
            this.customerInfrastructureISP.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureISP = this.CustomerInfrastructure.CustomerInfrastructureISPs
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureISP = this.CustomerInfrastructure.CustomerInfrastructureISPs
                    .Single(x => x.CustomerInfrastructureISPId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructure.CustomerInfrastructureISPs.Remove(this.customerInfrastructureISP);
            else
            {
                this.customerInfrastructureISP.Activated = false;
                this.customerInfrastructureISP.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureISP = this.CustomerInfrastructure.CustomerInfrastructureISPs
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureISP = this.CustomerInfrastructure.CustomerInfrastructureISPs
                    .Single(x => x.CustomerInfrastructureISPId == entityId);

            this.controlCustomerInfrastructureISPs.icISP.Value
                = this.customerInfrastructureISP.ISP;

            this.controlCustomerInfrastructureISPs.steBandwidth.Value
                = this.customerInfrastructureISP.Bandwidth;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureISP.ISP = this.controlCustomerInfrastructureISPs.icISP.Value;

            //TODO - Corregir value debe ser decimal y no string con la mascara...
            this.customerInfrastructureISP.Bandwidth = Convert.ToDecimal(this.controlCustomerInfrastructureISPs.steBandwidth.Value
                .ToString().Replace("MB", ""));
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureISPs.icISP.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el ISP.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureISPs.icISP.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureISP.CustomerInfrastructureISPId == -1)
                row = this.dtCustomerInfrastructureISPs.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureISPId"])
                        == -(this.customerInfrastructureISP as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureISPs.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureISPId"])
                        == this.customerInfrastructureISP.CustomerInfrastructureISPId);

            if (row == null)
            {
                this.CustomerInfrastructure.CustomerInfrastructureISPs.Add(this.customerInfrastructureISP);

                row = this.dtCustomerInfrastructureISPs.NewRow();
                this.dtCustomerInfrastructureISPs.Rows.Add(row);
            }

            if (this.customerInfrastructureISP.CustomerInfrastructureISPId == -1)
                row["CustomerInfrastructureISPId"] = -(this.customerInfrastructureISP as object).GetHashCode();
            else
                row["CustomerInfrastructureISPId"] = this.customerInfrastructureISP.CustomerInfrastructureISPId;

            row["ISPId"] = this.customerInfrastructureISP.ISP.ISPId;
            row["Bandwidth"] = this.customerInfrastructureISP.Bandwidth;

            this.dtCustomerInfrastructureISPs.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureISPs.icISP.ReadOnly = !enabled;
            this.controlCustomerInfrastructureISPs.steBandwidth.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            ISPParameters pmtISP = new ISPParameters();

            IList<ISP> cctvBrands = this.srvISP.GetListByParameters(pmtISP);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["ISPId"], "ISPId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
