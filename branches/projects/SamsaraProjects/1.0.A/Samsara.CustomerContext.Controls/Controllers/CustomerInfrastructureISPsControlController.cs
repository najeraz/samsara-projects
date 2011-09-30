
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
    public class CustomerInfrastructureISPsControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureISPService srvCustomerInfrastructureISP;
        private CustomerInfrastructureISPsControl controlCustomerInfrastructureISPs;
        private CustomerInfrastructureISP customerInfrastructureISP;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private IISPService srvISP;
        private System.Collections.Generic.ISet<CustomerInfrastructureISP> customerInfrastructureISPs;

        private DataTable dtCustomerInfrastructureISPs;

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

        public System.Collections.Generic.ISet<CustomerInfrastructureISP> CustomerInfrastructureISPs
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureISP> tmp
                    = new HashSet<CustomerInfrastructureISP>();

                foreach(CustomerInfrastructureISP customerInfrastructureISP in
                    this.customerInfrastructureISPs)
                {
                    customerInfrastructureISP.CustomerInfrastructureISPId 
                        = customerInfrastructureISP.CustomerInfrastructureISPId <= 0 ?
                        -1 : customerInfrastructureISP.CustomerInfrastructureISPId;

                    tmp.Add(customerInfrastructureISP);
                }

                return tmp;
            }
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

                IList<ISP> cctvBrands = this.srvISP.GetListByParameters(pmtISP);
                WindowsFormsUtil.LoadCombo<ISP>(this.controlCustomerInfrastructureISPs.uceISP,
                    cctvBrands, "ISPId", "Name", "Seleccione");

                this.controlCustomerInfrastructureISPs.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            if (this.CustomerInfrastructureId != null)
            {
                CustomerInfrastructureISPParameters pmtCustomerInfrastructureISP
                    = new CustomerInfrastructureISPParameters();

                pmtCustomerInfrastructureISP.CustomerInfrastructureId = this.CustomerInfrastructureId;

                this.dtCustomerInfrastructureISPs = this.srvCustomerInfrastructureISP
                    .SearchByParameters(pmtCustomerInfrastructureISP);

                this.controlCustomerInfrastructureISPs.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureISPs.grdRelations.DataSource = this.dtCustomerInfrastructureISPs;

                IList<CustomerInfrastructureISP> lstCustomerInfrastructureISPs 
                    = this.srvCustomerInfrastructureISP.GetListByParameters(pmtCustomerInfrastructureISP);

                this.customerInfrastructureISPs = new HashSet<CustomerInfrastructureISP>();

                foreach (CustomerInfrastructureISP customerInfrastructureISP in
                    lstCustomerInfrastructureISPs)
                {
                    this.customerInfrastructureISPs.Add(customerInfrastructureISP);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureISPs.uceISP.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureISPs.steBandwidth.Value = null;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureISP = new CustomerInfrastructureISP();

            this.customerInfrastructureISP.Activated = true;
            this.customerInfrastructureISP.Deleted = false;
            this.customerInfrastructureISP.CustomerInfrastructure 
                = this.srvCustomerInfrastructure.GetById(this.CustomerInfrastructureId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureISP = this.customerInfrastructureISPs
                .Single(x => x.CustomerInfrastructureISPId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureISPs.Remove(this.customerInfrastructureISP);
            else
            {
                this.customerInfrastructureISP.Activated = false;
                this.customerInfrastructureISP.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureISP = this.customerInfrastructureISPs
                .Single(x => x.CustomerInfrastructureISPId == entityId);

            this.controlCustomerInfrastructureISPs.uceISP.Value
                = this.customerInfrastructureISP.ISP.ISPId;

            this.controlCustomerInfrastructureISPs.steBandwidth.Value
                = this.customerInfrastructureISP.Bandwidth;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureISP.ISP = this.srvISP
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureISPs.uceISP.Value));

            this.customerInfrastructureISP.Bandwidth = Convert.ToDecimal(this.controlCustomerInfrastructureISPs.steBandwidth.Value);
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureISPs.uceISP.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureISPs.uceISP.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el ISP.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureISPs.uceISP.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureISP.CustomerInfrastructureISPId == -1)
            {
                this.customerInfrastructureISP.CustomerInfrastructureISPId = this.entityCounter--;
                this.customerInfrastructureISPs.Add(this.customerInfrastructureISP);

                row = this.dtCustomerInfrastructureISPs.NewRow();
                this.dtCustomerInfrastructureISPs.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureISPs.AsEnumerable().Single(x => Convert.ToInt32(x["CustomerInfrastructureISPId"])
                        == this.customerInfrastructureISP.CustomerInfrastructureISPId);
            }

            row["CustomerInfrastructureISPId"] = this.customerInfrastructureISP.CustomerInfrastructureISPId;
            row["ISPId"] = this.customerInfrastructureISP.ISP.ISPId;
            row["Bandwidth"] = this.customerInfrastructureISP.Bandwidth;

            this.dtCustomerInfrastructureISPs.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureISPs.uceISP.ReadOnly = !enabled;
            this.controlCustomerInfrastructureISPs.steBandwidth.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            ISPParameters pmtISP = new ISPParameters();

            IList<ISP> cctvBrands = this.srvISP.GetListByParameters(pmtISP);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["ISPId"], "ISPId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
