
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
    public class CustomerInfrastructurePersonalComputersControlController : ManyToOneLevel1ControlController
    {
        #region Attributes

        private ICustomerInfrastructurePersonalComputerService srvCustomerInfrastructurePersonalComputer;
        private CustomerInfrastructurePersonalComputersControl controlCustomerInfrastructurePersonalComputers;
        private CustomerInfrastructurePersonalComputer customerInfrastructurePersonalComputer;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private IPersonalComputerTypeService srvPersonalComputerType;
        private IOperativeSystemService srvOperativeSystem;
        private IComputerBrandService srvComputerBrand;

        private DataTable dtCustomerInfrastructurePersonalComputers;

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

        public CustomerInfrastructurePersonalComputersControlController(
            CustomerInfrastructurePersonalComputersControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructurePersonalComputers = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructurePersonalComputer = SamsaraAppContext.Resolve<ICustomerInfrastructurePersonalComputerService>();
                Assert.IsNotNull(this.srvCustomerInfrastructurePersonalComputer);
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                Assert.IsNotNull(this.srvCustomerInfrastructure);
                this.srvPersonalComputerType = SamsaraAppContext.Resolve<IPersonalComputerTypeService>();
                Assert.IsNotNull(this.srvPersonalComputerType);
                this.srvOperativeSystem = SamsaraAppContext.Resolve<IOperativeSystemService>();
                Assert.IsNotNull(this.srvOperativeSystem);
                this.srvComputerBrand = SamsaraAppContext.Resolve<IComputerBrandService>();
                Assert.IsNotNull(this.srvComputerBrand);
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
                ComputerBrandParameters pmtComputerBrand = new ComputerBrandParameters();

                IList<ComputerBrand> cctvBrands = this.srvComputerBrand.GetListByParameters(pmtComputerBrand);
                WindowsFormsUtil.LoadCombo<ComputerBrand>(this.controlCustomerInfrastructurePersonalComputers.uceComputerBrand,
                    cctvBrands, "ComputerBrandId", "Name", "Seleccione");

                PersonalComputerTypeParameters pmtPersonalComputerType = new PersonalComputerTypeParameters();

                IList<PersonalComputerType> cctvTypes = this.srvPersonalComputerType.GetListByParameters(pmtPersonalComputerType);
                WindowsFormsUtil.LoadCombo<PersonalComputerType>(this.controlCustomerInfrastructurePersonalComputers.ucePersonalComputerType,
                    cctvTypes, "PersonalComputerTypeId", "Name", "Seleccione");

                OperativeSystemParameters pmtOperativeSystem = new OperativeSystemParameters();

                IList<OperativeSystem> cctvOperativeSystems = this.srvOperativeSystem.GetListByParameters(pmtOperativeSystem);
                WindowsFormsUtil.LoadCombo<OperativeSystem>(this.controlCustomerInfrastructurePersonalComputers.uceOperativeSystem,
                    cctvOperativeSystems, "OperativeSystemId", "Name", "Seleccione");

                this.controlCustomerInfrastructurePersonalComputers.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            CustomerInfrastructurePersonalComputerParameters pmtCustomerInfrastructurePersonalComputer
                = new CustomerInfrastructurePersonalComputerParameters();

            pmtCustomerInfrastructurePersonalComputer.CustomerInfrastructureId = ParameterConstants.IntNone;

            this.dtCustomerInfrastructurePersonalComputers = this.srvCustomerInfrastructurePersonalComputer
                .SearchByParameters(pmtCustomerInfrastructurePersonalComputer);

            this.controlCustomerInfrastructurePersonalComputers.grdRelations.DataSource = null;
            this.controlCustomerInfrastructurePersonalComputers.grdRelations.DataSource
                = this.dtCustomerInfrastructurePersonalComputers;

            if (this.CustomerInfrastructure != null)
            {
                foreach (CustomerInfrastructurePersonalComputer customerInfrastructurePersonalComputer
                    in this.CustomerInfrastructure.CustomerInfrastructurePersonalComputers)
                {
                    DataRow row = this.dtCustomerInfrastructurePersonalComputers.NewRow();
                    this.dtCustomerInfrastructurePersonalComputers.Rows.Add(row);

                    row["CustomerInfrastructurePersonalComputerId"] = customerInfrastructurePersonalComputer
                        .CustomerInfrastructurePersonalComputerId;
                    row["ComputerBrandId"] = customerInfrastructurePersonalComputer.ComputerBrand.ComputerBrandId;
                    row["PersonalComputerTypeId"] = customerInfrastructurePersonalComputer.PersonalComputerType.PersonalComputerTypeId;
                    row["Model"] = customerInfrastructurePersonalComputer.Model;
                    if (customerInfrastructurePersonalComputer.OperativeSystem == null)
                        row["OperativeSystemId"] = DBNull.Value;
                    else
                        row["OperativeSystemId"] = customerInfrastructurePersonalComputer.OperativeSystem.OperativeSystemId;
                    row["ManufacturerReferenceNumber"] = customerInfrastructurePersonalComputer.ManufacturerReferenceNumber;
                    row["RAM"] = customerInfrastructurePersonalComputer.RAM;
                    row["CPU"] = customerInfrastructurePersonalComputer.CPU;
                    row["SerialNumber"] = customerInfrastructurePersonalComputer.SerialNumber;
                    row["StorageSystem"] = customerInfrastructurePersonalComputer.StorageSystem;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructurePersonalComputers.uceComputerBrand.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructurePersonalComputers.ucePersonalComputerType.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructurePersonalComputers.uceOperativeSystem.Value = ParameterConstants.IntDefault;
            this.controlCustomerInfrastructurePersonalComputers.txtCPU.Value = null;
            this.controlCustomerInfrastructurePersonalComputers.txtManufacturerReferenceNumber.Value = null;
            this.controlCustomerInfrastructurePersonalComputers.txtRAM.Value = null;
            this.controlCustomerInfrastructurePersonalComputers.txtSerialNumber.Value = null;
            this.controlCustomerInfrastructurePersonalComputers.txtStorage.Value = null;
            this.controlCustomerInfrastructurePersonalComputers.txtModel.Value = null;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructurePersonalComputers.Rows.Clear();
            this.dtCustomerInfrastructurePersonalComputers.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructurePersonalComputer = new CustomerInfrastructurePersonalComputer();

            this.customerInfrastructurePersonalComputer.CustomerInfrastructure = this.CustomerInfrastructure;
            this.customerInfrastructurePersonalComputer.Activated = true;
            this.customerInfrastructurePersonalComputer.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructurePersonalComputer = this.CustomerInfrastructure
                    .CustomerInfrastructurePersonalComputers
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructurePersonalComputer = this.CustomerInfrastructure
                    .CustomerInfrastructurePersonalComputers
                    .Single(x => x.CustomerInfrastructurePersonalComputerId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructure.CustomerInfrastructurePersonalComputers
                    .Remove(this.customerInfrastructurePersonalComputer);
            else
            {
                this.customerInfrastructurePersonalComputer.Activated = false;
                this.customerInfrastructurePersonalComputer.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructurePersonalComputer = this.CustomerInfrastructure
                    .CustomerInfrastructurePersonalComputers
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructurePersonalComputer = this.CustomerInfrastructure
                    .CustomerInfrastructurePersonalComputers
                    .Single(x => x.CustomerInfrastructurePersonalComputerId == entityId);

            this.controlCustomerInfrastructurePersonalComputers.uceComputerBrand.Value
                = this.customerInfrastructurePersonalComputer.ComputerBrand.ComputerBrandId;

            this.controlCustomerInfrastructurePersonalComputers.ucePersonalComputerType.Value
                = this.customerInfrastructurePersonalComputer.PersonalComputerType.PersonalComputerTypeId;

            if (this.customerInfrastructurePersonalComputer.OperativeSystem == null)
                this.controlCustomerInfrastructurePersonalComputers.uceOperativeSystem.Value = ParameterConstants.IntDefault;
            else
                this.controlCustomerInfrastructurePersonalComputers.uceOperativeSystem.Value
                    = this.customerInfrastructurePersonalComputer.OperativeSystem.OperativeSystemId;

            this.controlCustomerInfrastructurePersonalComputers.txtCPU.Text
                = this.customerInfrastructurePersonalComputer.CPU;

            this.controlCustomerInfrastructurePersonalComputers.txtManufacturerReferenceNumber.Text
                = this.customerInfrastructurePersonalComputer.ManufacturerReferenceNumber;

            this.controlCustomerInfrastructurePersonalComputers.txtRAM.Text
                = this.customerInfrastructurePersonalComputer.RAM;

            this.controlCustomerInfrastructurePersonalComputers.txtSerialNumber.Text
                = this.customerInfrastructurePersonalComputer.SerialNumber;

            this.controlCustomerInfrastructurePersonalComputers.txtStorage.Text
                = this.customerInfrastructurePersonalComputer.StorageSystem;

            this.controlCustomerInfrastructurePersonalComputers.txtModel.Text
                = this.customerInfrastructurePersonalComputer.Model;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.customerInfrastructurePersonalComputer.ComputerBrand = this.srvComputerBrand
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructurePersonalComputers.uceComputerBrand.Value));

            this.customerInfrastructurePersonalComputer.PersonalComputerType = this.srvPersonalComputerType
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructurePersonalComputers.ucePersonalComputerType.Value));

            this.customerInfrastructurePersonalComputer.OperativeSystem = this.srvOperativeSystem
                .GetById(Convert.ToInt32(this.controlCustomerInfrastructurePersonalComputers.uceOperativeSystem.Value));

            this.customerInfrastructurePersonalComputer.RAM
                = this.controlCustomerInfrastructurePersonalComputers.txtRAM.Text;

            this.customerInfrastructurePersonalComputer.ManufacturerReferenceNumber
                = this.controlCustomerInfrastructurePersonalComputers.txtManufacturerReferenceNumber.Text;

            this.customerInfrastructurePersonalComputer.CPU
                = this.controlCustomerInfrastructurePersonalComputers.txtCPU.Text;

            this.customerInfrastructurePersonalComputer.SerialNumber
                = this.controlCustomerInfrastructurePersonalComputers.txtSerialNumber.Text;

            this.customerInfrastructurePersonalComputer.StorageSystem
                = this.controlCustomerInfrastructurePersonalComputers.txtStorage.Text;

            this.customerInfrastructurePersonalComputer.Model
                = this.controlCustomerInfrastructurePersonalComputers.txtModel.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlCustomerInfrastructurePersonalComputers.uceComputerBrand.Value == null ||
                    Convert.ToInt32(this.controlCustomerInfrastructurePersonalComputers.uceComputerBrand.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar la Marca de la Computadora.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructurePersonalComputers.uceComputerBrand.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructurePersonalComputers.ucePersonalComputerType.Value == null ||
                Convert.ToInt32(this.controlCustomerInfrastructurePersonalComputers.ucePersonalComputerType.Value) <= 0)
            {
                MessageBox.Show("Favor de seleccionar el Tipo de la Computadora.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructurePersonalComputers.ucePersonalComputerType.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructurePersonalComputer.CustomerInfrastructurePersonalComputerId == -1)
                row = this.dtCustomerInfrastructurePersonalComputers.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructurePersonalComputerId"])
                        == -(this.customerInfrastructurePersonalComputer as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructurePersonalComputers.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructurePersonalComputerId"])
                        == this.customerInfrastructurePersonalComputer.CustomerInfrastructurePersonalComputerId);

            if (row == null)
            {
                this.CustomerInfrastructure.CustomerInfrastructurePersonalComputers
                    .Add(this.customerInfrastructurePersonalComputer);

                row = this.dtCustomerInfrastructurePersonalComputers.NewRow();
                this.dtCustomerInfrastructurePersonalComputers.Rows.Add(row);
            }

            if (this.customerInfrastructurePersonalComputer.CustomerInfrastructurePersonalComputerId == -1)
                row["CustomerInfrastructurePersonalComputerId"] = -(this.customerInfrastructurePersonalComputer as object).GetHashCode();
            else
                row["CustomerInfrastructurePersonalComputerId"] = this.customerInfrastructurePersonalComputer
                    .CustomerInfrastructurePersonalComputerId;

            row["ComputerBrandId"] = this.customerInfrastructurePersonalComputer.ComputerBrand.ComputerBrandId;
            row["PersonalComputerTypeId"] = this.customerInfrastructurePersonalComputer.PersonalComputerType.PersonalComputerTypeId;
            row["Model"] = this.customerInfrastructurePersonalComputer.Model;
            if (this.customerInfrastructurePersonalComputer.OperativeSystem == null)
                row["OperativeSystemId"] = DBNull.Value;
            else
                row["OperativeSystemId"] = this.customerInfrastructurePersonalComputer.OperativeSystem.OperativeSystemId;
            row["ManufacturerReferenceNumber"] = this.customerInfrastructurePersonalComputer.ManufacturerReferenceNumber;
            row["RAM"] = this.customerInfrastructurePersonalComputer.RAM;
            row["CPU"] = this.customerInfrastructurePersonalComputer.CPU;
            row["SerialNumber"] = this.customerInfrastructurePersonalComputer.SerialNumber;
            row["StorageSystem"] = this.customerInfrastructurePersonalComputer.StorageSystem;

            this.dtCustomerInfrastructurePersonalComputers.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructurePersonalComputers.ucePersonalComputerType.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePersonalComputers.uceComputerBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePersonalComputers.uceOperativeSystem.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePersonalComputers.txtModel.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePersonalComputers.txtCPU.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePersonalComputers.txtManufacturerReferenceNumber.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePersonalComputers.txtRAM.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePersonalComputers.txtSerialNumber.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePersonalComputers.txtStorage.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            ComputerBrandParameters pmtComputerBrand = new ComputerBrandParameters();

            IList<ComputerBrand> cctvBrands = this.srvComputerBrand.GetListByParameters(pmtComputerBrand);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
                band.Columns["ComputerBrandId"], "ComputerBrandId", "Name", "Seleccione");
            
            OperativeSystemParameters pmtOperativeSystem = new OperativeSystemParameters();

            IList<OperativeSystem> cctvOperativeSystems = this.srvOperativeSystem.GetListByParameters(pmtOperativeSystem);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvOperativeSystems,
                band.Columns["OperativeSystemId"], "OperativeSystemId", "Name", "Seleccione"); ;

            PersonalComputerTypeParameters pmtPersonalComputerType = new PersonalComputerTypeParameters();

            IList<PersonalComputerType> cctvTypes = this.srvPersonalComputerType.GetListByParameters(pmtPersonalComputerType);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["PersonalComputerTypeId"], "PersonalComputerTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
