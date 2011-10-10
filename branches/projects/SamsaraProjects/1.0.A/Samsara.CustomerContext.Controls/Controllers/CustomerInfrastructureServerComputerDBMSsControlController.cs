
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
    public class CustomerInfrastructureServerComputerDBMSsControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructureServerComputerDBMSService srvCustomerInfrastructureServerComputerDBMS;
        private CustomerInfrastructureServerComputerDBMSsControl controlCustomerInfrastructureServerComputerDBMSs;
        private ICustomerInfrastructureServerComputerService srvCustomerInfrastructureServerComputer;
        private CustomerInfrastructureServerComputerDBMS customerInfrastructureServerComputerDBMS;
        private IDBMSService srvDBMS;

        private DataTable dtCustomerInfrastructureServerComputerDBMSs;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public CustomerInfrastructureServerComputer CustomerInfrastructureServerComputer
        {
            get;
            set;
        }

        #endregion Properties
        
        #region Constructor

        public CustomerInfrastructureServerComputerDBMSsControlController(
            CustomerInfrastructureServerComputerDBMSsControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureServerComputerDBMSs = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureServerComputerDBMS = SamsaraAppContext.Resolve<ICustomerInfrastructureServerComputerDBMSService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureServerComputerDBMS);
                this.srvCustomerInfrastructureServerComputer = SamsaraAppContext.Resolve<ICustomerInfrastructureServerComputerService>();
                Assert.IsNotNull(this.srvCustomerInfrastructureServerComputer);
                this.srvDBMS = SamsaraAppContext.Resolve<IDBMSService>();
                Assert.IsNotNull(this.srvDBMS);
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
                DBMSParameters pmtDBMS = new DBMSParameters();

                IList<DBMS> cctvBrands = this.srvDBMS.GetListByParameters(pmtDBMS);
                WindowsFormsUtil.LoadCombo<DBMS>(this.controlCustomerInfrastructureServerComputerDBMSs.uceDBMS,
                    cctvBrands, "DBMSId", "Name", "Seleccione");

                this.controlCustomerInfrastructureServerComputerDBMSs.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructureServerComputerDBMSParameters pmtCustomerInfrastructureServerComputerDBMS
                = new CustomerInfrastructureServerComputerDBMSParameters();

            pmtCustomerInfrastructureServerComputerDBMS.CustomerInfrastructureServerComputerId
                = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureServerComputerDBMSs = this.srvCustomerInfrastructureServerComputerDBMS
                .SearchByParameters(pmtCustomerInfrastructureServerComputerDBMS);

            this.controlCustomerInfrastructureServerComputerDBMSs.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureServerComputerDBMSs.grdRelations.DataSource
                = this.dtCustomerInfrastructureServerComputerDBMSs;

            if (this.CustomerInfrastructureServerComputer != null)
            {
                foreach (CustomerInfrastructureServerComputerDBMS customerInfrastructureServerComputerDBMS
                    in this.CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerDBMSs)
                {
                    DataRow row = this.dtCustomerInfrastructureServerComputerDBMSs.NewRow();
                    this.dtCustomerInfrastructureServerComputerDBMSs.Rows.Add(row);

                    row["CustomerInfrastructureServerComputerDBMSId"] = customerInfrastructureServerComputerDBMS
                        .CustomerInfrastructureServerComputerDBMSId;
                    row["DBMSId"] = customerInfrastructureServerComputerDBMS.DBMS.DBMSId;
                    if (customerInfrastructureServerComputerDBMS.CustomerInfrastructureServerComputer == null)
                        row["CustomerInfrastructureServerComputerId"] = DBNull.Value;
                    else
                        row["CustomerInfrastructureServerComputerId"] = customerInfrastructureServerComputerDBMS
                            .CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerId;
                    row["Description"] = customerInfrastructureServerComputerDBMS.Description;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureServerComputerDBMSs.uceDBMS.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureServerComputerDBMSs.txtDescription.Text = string.Empty;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureServerComputerDBMSs.Rows.Clear();
            this.dtCustomerInfrastructureServerComputerDBMSs.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureServerComputerDBMS = new CustomerInfrastructureServerComputerDBMS();

            this.customerInfrastructureServerComputerDBMS.CustomerInfrastructureServerComputer
                = this.CustomerInfrastructureServerComputer;
            this.customerInfrastructureServerComputerDBMS.Activated = true;
            this.customerInfrastructureServerComputerDBMS.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureServerComputerDBMS = this.CustomerInfrastructureServerComputer
                    .CustomerInfrastructureServerComputerDBMSs.Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureServerComputerDBMS = this.CustomerInfrastructureServerComputer
                    .CustomerInfrastructureServerComputerDBMSs
                    .Single(x => x.CustomerInfrastructureServerComputerDBMSId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerDBMSs
                    .Remove(this.customerInfrastructureServerComputerDBMS);
            else
            {
                this.customerInfrastructureServerComputerDBMS.Activated = false;
                this.customerInfrastructureServerComputerDBMS.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureServerComputerDBMS = this.CustomerInfrastructureServerComputer
                    .CustomerInfrastructureServerComputerDBMSs.Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureServerComputerDBMS = this.CustomerInfrastructureServerComputer
                    .CustomerInfrastructureServerComputerDBMSs
                    .Single(x => x.CustomerInfrastructureServerComputerDBMSId == entityId);

            this.controlCustomerInfrastructureServerComputerDBMSs.uceDBMS.Value
                = this.customerInfrastructureServerComputerDBMS.DBMS.DBMSId;

            this.controlCustomerInfrastructureServerComputerDBMSs.txtDescription.Text
                = this.customerInfrastructureServerComputerDBMS.Description;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureServerComputerDBMS.DBMS = this.srvDBMS
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureServerComputerDBMSs.uceDBMS.Value));

            this.customerInfrastructureServerComputerDBMS.Description 
                = this.controlCustomerInfrastructureServerComputerDBMSs.txtDescription.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureServerComputerDBMSs.uceDBMS.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureServerComputerDBMSs.uceDBMS.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Sistema Gestor de Base de Datos.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureServerComputerDBMSs.uceDBMS.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureServerComputerDBMS.CustomerInfrastructureServerComputerDBMSId == -1)
                row = this.dtCustomerInfrastructureServerComputerDBMSs.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureServerComputerDBMSId"])
                        == -(this.customerInfrastructureServerComputerDBMS as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureServerComputerDBMSs.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureServerComputerDBMSId"])
                        == this.customerInfrastructureServerComputerDBMS.CustomerInfrastructureServerComputerDBMSId);

            if (row == null)
            {
                this.CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerDBMSs
                    .Add(this.customerInfrastructureServerComputerDBMS);

                row = this.dtCustomerInfrastructureServerComputerDBMSs.NewRow();
                this.dtCustomerInfrastructureServerComputerDBMSs.Rows.Add(row);
            }

            if (this.customerInfrastructureServerComputerDBMS.CustomerInfrastructureServerComputerDBMSId == -1)
                row["CustomerInfrastructureServerComputerDBMSId"]
                    = -(this.customerInfrastructureServerComputerDBMS as object).GetHashCode();
            else
                row["CustomerInfrastructureServerComputerDBMSId"] = this.customerInfrastructureServerComputerDBMS
                    .CustomerInfrastructureServerComputerDBMSId;

            row["DBMSId"] = this.customerInfrastructureServerComputerDBMS.DBMS.DBMSId;
            if (this.customerInfrastructureServerComputerDBMS.CustomerInfrastructureServerComputer == null)
                row["CustomerInfrastructureServerComputerId"] = DBNull.Value;
            else
                row["CustomerInfrastructureServerComputerId"] = this.customerInfrastructureServerComputerDBMS
                    .CustomerInfrastructureServerComputer.CustomerInfrastructureServerComputerId;
            row["Description"] = this.customerInfrastructureServerComputerDBMS.Description;

            this.dtCustomerInfrastructureServerComputerDBMSs.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureServerComputerDBMSs.uceDBMS.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputerDBMSs.txtDescription.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            DBMSParameters pmtDBMS = new DBMSParameters();

            IList<DBMS> cctvBrands = this.srvDBMS.GetListByParameters(pmtDBMS);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["DBMSId"], "DBMSId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
