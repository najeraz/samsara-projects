
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Controls.EventsArgs;
using Samsara.Base.Controls.EventsHandlers;
using Samsara.Base.Core.Context;
using Samsara.Controls.Controllers;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Enums;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers
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

                this.controlCustomerInfrastructurePersonalComputers.cbcComputerBrand.Parameters = pmtComputerBrand;
                this.controlCustomerInfrastructurePersonalComputers.cbcComputerBrand.Refresh();

                PersonalComputerTypeParameters pmtPersonalComputerType = new PersonalComputerTypeParameters();

                this.controlCustomerInfrastructurePersonalComputers.pctcPersonalComputerType.Parameters = pmtPersonalComputerType;
                this.controlCustomerInfrastructurePersonalComputers.pctcPersonalComputerType.Refresh();

                OperativeSystemParameters pmtOperativeSystem = new OperativeSystemParameters();

                this.controlCustomerInfrastructurePersonalComputers.oscOperativeSystem.Parameters = pmtOperativeSystem;
                this.controlCustomerInfrastructurePersonalComputers.oscOperativeSystem.Refresh();

                this.controlCustomerInfrastructurePersonalComputers.cipcccCustomerInfrastructurePersonalComputerClassification.Parameters
                    = new CustomerInfrastructurePersonalComputerClassificationParameters();
                this.controlCustomerInfrastructurePersonalComputers.cipcccCustomerInfrastructurePersonalComputerClassification.Refresh();

                this.controlCustomerInfrastructurePersonalComputers
                    .cipcccCustomerInfrastructurePersonalComputerClassification.ValueChanged
                    += new SamsaraEntityChooserValueChangedEventHandler<
                        CustomerInfrastructurePersonalComputerClassification>
                        (cipcccCustomerInfrastructurePersonalComputerClassification_ValueChanged);

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

            this.controlCustomerInfrastructurePersonalComputers.cbcComputerBrand.Value = null;
            this.controlCustomerInfrastructurePersonalComputers.pctcPersonalComputerType.Value = null;
            this.controlCustomerInfrastructurePersonalComputers.oscOperativeSystem.Value = null;
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

            this.controlCustomerInfrastructurePersonalComputers.cbcComputerBrand.Value
                = this.customerInfrastructurePersonalComputer.ComputerBrand;

            this.controlCustomerInfrastructurePersonalComputers.pctcPersonalComputerType.Value
                = this.customerInfrastructurePersonalComputer.PersonalComputerType;

            if (this.customerInfrastructurePersonalComputer.OperativeSystem == null)
                this.controlCustomerInfrastructurePersonalComputers.oscOperativeSystem.Value = null;
            else
                this.controlCustomerInfrastructurePersonalComputers.oscOperativeSystem.Value
                    = this.customerInfrastructurePersonalComputer.OperativeSystem;

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

            this.customerInfrastructurePersonalComputer.ComputerBrand
                = this.controlCustomerInfrastructurePersonalComputers.cbcComputerBrand.Value;

            this.customerInfrastructurePersonalComputer.PersonalComputerType
                = this.controlCustomerInfrastructurePersonalComputers.pctcPersonalComputerType.Value;

            this.customerInfrastructurePersonalComputer.OperativeSystem 
                = this.controlCustomerInfrastructurePersonalComputers.oscOperativeSystem.Value;

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

            if (this.controlCustomerInfrastructurePersonalComputers.cbcComputerBrand.Value == null)
            {
                MessageBox.Show("Favor de seleccionar la Marca de la Computadora(s).",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructurePersonalComputers.cbcComputerBrand.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructurePersonalComputers.pctcPersonalComputerType.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el Tipo de la Computadora(s).",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructurePersonalComputers.pctcPersonalComputerType.Focus();
                return false;
            }

            if (this.controlCustomerInfrastructurePersonalComputers
                .cipcccCustomerInfrastructurePersonalComputerClassification.Value == null)
            {
                MessageBox.Show("Favor de seleccionar la Clasificación de la Computadora(s).",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructurePersonalComputers
                    .cipcccCustomerInfrastructurePersonalComputerClassification.Focus();
                return false;
            }

            if ((CustomerInfrastructurePersonalComputerClassificationEnum)this.controlCustomerInfrastructurePersonalComputers
                .cipcccCustomerInfrastructurePersonalComputerClassification.Value.CustomerInfrastructurePersonalComputerClassificationId
                == CustomerInfrastructurePersonalComputerClassificationEnum.Unique
                && (this.controlCustomerInfrastructurePersonalComputers.steQuantity.Value == null
                || string.IsNullOrEmpty(this.controlCustomerInfrastructurePersonalComputers.steQuantity.Value.ToString())))
            {
                MessageBox.Show("Favor de seleccionar la Cantidad de la Computadoras.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructurePersonalComputers.steQuantity.Focus();
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

            this.controlCustomerInfrastructurePersonalComputers.pctcPersonalComputerType.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePersonalComputers.cbcComputerBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructurePersonalComputers.oscOperativeSystem.ReadOnly = !enabled;
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

        private void cipcccCustomerInfrastructurePersonalComputerClassification_ValueChanged(object sender, 
            SamsaraEntityChooserValueChangedEventArgs<CustomerInfrastructurePersonalComputerClassification> e)
        {
            if (e.NewValue != null)
            {
                bool isUnique = (CustomerInfrastructurePersonalComputerClassificationEnum)
                    e.NewValue.CustomerInfrastructurePersonalComputerClassificationId
                    == CustomerInfrastructurePersonalComputerClassificationEnum.Unique;

                this.controlCustomerInfrastructurePersonalComputers.steQuantity.Visible = isUnique;
                this.controlCustomerInfrastructurePersonalComputers.ulblQuantity.Visible = isUnique;
                this.controlCustomerInfrastructurePersonalComputers.txtSerialNumber.Visible = !isUnique;
                this.controlCustomerInfrastructurePersonalComputers.lblSerie.Visible = !isUnique;
                this.controlCustomerInfrastructurePersonalComputers.txtManufacturerReferenceNumber.Visible = !isUnique;
                this.controlCustomerInfrastructurePersonalComputers.lblManufacturerReferenceNumber.Visible = !isUnique;
            }
        }

        #endregion Events
    }
}
