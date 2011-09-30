
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
        private CustomerInfrastructureTelephonie customerInfrastructureTelephonie;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private ITelephonieBrandService srvTelephonieBrand;
        private ITelephonieTypeService srvTelephonieType;
        private System.Collections.Generic.ISet<CustomerInfrastructureTelephonie> customerInfrastructureTelephonies;

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

        public System.Collections.Generic.ISet<CustomerInfrastructureTelephonie> CustomerInfrastructureTelephonies
        {
            get
            {
                System.Collections.Generic.ISet<CustomerInfrastructureTelephonie> tmp
                    = new HashSet<CustomerInfrastructureTelephonie>();

                foreach(CustomerInfrastructureTelephonie customerInfrastructureTelephonie in
                    this.customerInfrastructureTelephonies)
                {
                    customerInfrastructureTelephonie.CustomerInfrastructureTelephonieId 
                        = customerInfrastructureTelephonie.CustomerInfrastructureTelephonieId <= 0 ?
                        -1 : customerInfrastructureTelephonie.CustomerInfrastructureTelephonieId;

                    tmp.Add(customerInfrastructureTelephonie);
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
                this.srvTelephonieBrand = SamsaraAppContext.Resolve<ITelephonieBrandService>();
                Assert.IsNotNull(this.srvTelephonieBrand);
                this.srvTelephonieType = SamsaraAppContext.Resolve<ITelephonieTypeService>();
                Assert.IsNotNull(this.srvTelephonieType);
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
                TelephonieBrandParameters pmtTelephonieBrand = new TelephonieBrandParameters();

                IList<TelephonieBrand> cctvBrands = this.srvTelephonieBrand.GetListByParameters(pmtTelephonieBrand);
                WindowsFormsUtil.LoadCombo<TelephonieBrand>(this.controlCustomerInfrastructureTelephonies.uceTelephonieBrand,
                    cctvBrands, "TelephonieBrandId", "Name", "Seleccione");

                TelephonieTypeParameters pmtTelephonieType = new TelephonieTypeParameters();

                IList<TelephonieType> cctvTypes = this.srvTelephonieType.GetListByParameters(pmtTelephonieType);
                WindowsFormsUtil.LoadCombo<TelephonieType>(this.controlCustomerInfrastructureTelephonies.uceTelephonieType,
                    cctvTypes, "TelephonieTypeId", "Name", "Seleccione");

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
                CustomerInfrastructureTelephonieParameters pmtCustomerInfrastructureTelephonie
                    = new CustomerInfrastructureTelephonieParameters();

                pmtCustomerInfrastructureTelephonie.CustomerInfrastructureId = this.CustomerInfrastructureId;

                this.dtCustomerInfrastructureTelephonies = this.srvCustomerInfrastructureTelephony
                    .SearchByParameters(pmtCustomerInfrastructureTelephonie);

                this.controlCustomerInfrastructureTelephonies.grdRelations.DataSource = null;
                this.controlCustomerInfrastructureTelephonies.grdRelations.DataSource = this.dtCustomerInfrastructureTelephonies;

                IList<CustomerInfrastructureTelephonie> lstCustomerInfrastructureTelephonies 
                    = this.srvCustomerInfrastructureTelephony.GetListByParameters(pmtCustomerInfrastructureTelephonie);

                this.customerInfrastructureTelephonies = new HashSet<CustomerInfrastructureTelephonie>();

                foreach (CustomerInfrastructureTelephonie customerInfrastructureTelephonie in
                    lstCustomerInfrastructureTelephonies)
                {
                    this.customerInfrastructureTelephonies.Add(customerInfrastructureTelephonie);
                }
            }
        }

        #endregion Public

        #region Protected

        protected override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureTelephonies.uceTelephonieBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureTelephonies.uceTelephonieType.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructureTelephonies.txtUtilization.Text = string.Empty;
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureTelephonie = new CustomerInfrastructureTelephonie();

            this.customerInfrastructureTelephonie.Activated = true;
            this.customerInfrastructureTelephonie.Deleted = false;
            this.customerInfrastructureTelephonie.CustomerInfrastructure 
                = this.srvCustomerInfrastructure.GetById(this.CustomerInfrastructureId.Value);
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.customerInfrastructureTelephonie = this.customerInfrastructureTelephonies
                .Single(x => x.CustomerInfrastructureTelephonieId == entityId);

            if (entityId <= 0)
                this.customerInfrastructureTelephonies.Remove(this.customerInfrastructureTelephonie);
            else
            {
                this.customerInfrastructureTelephonie.Activated = false;
                this.customerInfrastructureTelephonie.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.customerInfrastructureTelephonie = this.customerInfrastructureTelephonies
                .Single(x => x.CustomerInfrastructureTelephonieId == entityId);

            this.controlCustomerInfrastructureTelephonies.uceTelephonieBrand.Value
                = this.customerInfrastructureTelephonie.TelephonieBrand.TelephonieBrandId;

            this.controlCustomerInfrastructureTelephonies.uceTelephonieType.Value
                = this.customerInfrastructureTelephonie.TelephonieType.TelephonieTypeId;

            this.controlCustomerInfrastructureTelephonies.txtUtilization.Text
                = this.customerInfrastructureTelephonie.Utilization;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructureTelephonie.TelephonieBrand = this.srvTelephonieBrand
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureTelephonies.uceTelephonieBrand.Value));

            this.customerInfrastructureTelephonie.TelephonieType = this.srvTelephonieType
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructureTelephonies.uceTelephonieType.Value));

            this.customerInfrastructureTelephonie.Utilization = this.controlCustomerInfrastructureTelephonies.txtUtilization.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructureTelephonies.uceTelephonieBrand.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructureTelephonies.uceTelephonieBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Telephonie.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureTelephonies.uceTelephonieBrand.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructureTelephonies.uceTelephonieType.Value == null ||
                Convert.ToInt32(this.controlCustomerInfrastructureTelephonies.uceTelephonieType.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo del Telephonie.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureTelephonies.uceTelephonieType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureTelephonie.CustomerInfrastructureTelephonieId == -1)
            {
                this.customerInfrastructureTelephonie.CustomerInfrastructureTelephonieId = this.entityCounter--;
                this.customerInfrastructureTelephonies.Add(this.customerInfrastructureTelephonie);

                row = this.dtCustomerInfrastructureTelephonies.NewRow();
                this.dtCustomerInfrastructureTelephonies.Rows.Add(row);
            }
            else
            {
                row = this.dtCustomerInfrastructureTelephonies.AsEnumerable().Single(x => Convert.ToInt32(x["CustomerInfrastructureTelephonieId"])
                        == this.customerInfrastructureTelephonie.CustomerInfrastructureTelephonieId);
            }

            row["CustomerInfrastructureTelephonieId"] = this.customerInfrastructureTelephonie.CustomerInfrastructureTelephonieId;
            row["TelephonieBrandId"] = this.customerInfrastructureTelephonie.TelephonieBrand.TelephonieBrandId;
            row["TelephonieTypeId"] = this.customerInfrastructureTelephonie.TelephonieType.TelephonieTypeId;
            row["Utilization"] = this.customerInfrastructureTelephonie.Utilization;

            this.dtCustomerInfrastructureTelephonies.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureTelephonies.uceTelephonieType.ReadOnly = !enabled;
            this.controlCustomerInfrastructureTelephonies.uceTelephonieBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureTelephonies.txtUtilization.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            TelephonieBrandParameters pmtTelephonieBrand = new TelephonieBrandParameters();

            IList<TelephonieBrand> cctvBrands = this.srvTelephonieBrand.GetListByParameters(pmtTelephonieBrand);
            WindowsFormsUtil.LoadCombo<TelephonieBrand>(this.controlCustomerInfrastructureTelephonies.uceTelephonieBrand,
                cctvBrands, "TelephonieBrandId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["TelephonieBrandId"], "TelephonieBrandId", "Name", "Seleccione");

            TelephonieTypeParameters pmtTelephonieType = new TelephonieTypeParameters();

            IList<TelephonieType> cctvTypes = this.srvTelephonieType.GetListByParameters(pmtTelephonieType);
            WindowsFormsUtil.LoadCombo<TelephonieType>(this.controlCustomerInfrastructureTelephonies.uceTelephonieType,
                cctvTypes, "TelephonieTypeId", "Name", "Seleccione");

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["TelephonieTypeId"], "TelephonieTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
