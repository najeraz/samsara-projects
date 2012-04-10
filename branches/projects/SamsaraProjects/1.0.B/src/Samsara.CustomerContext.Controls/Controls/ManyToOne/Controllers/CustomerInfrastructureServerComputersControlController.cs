
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Controls.Controllers;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Enums;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Service.Interfaces;
using Samsara.Framework.Core.Constants;
using Samsara.Framework.Util;

namespace Samsara.CustomerContext.Controls.Controls.ManyToOne.Controllers
{
    public class CustomerInfrastructureServerComputersControlController : ManyToOneLevel1ControlController<CustomerInfrastructureServerComputer>
    {
        #region Attributes

        private ICustomerInfrastructureServerComputerService srvCustomerInfrastructureServerComputer;
        private CustomerInfrastructureServerComputersControl controlCustomerInfrastructureServerComputers;
        private CustomerInfrastructureServerComputer customerInfrastructureServerComputer;
        private ICustomerInfrastructureService srvCustomerInfrastructure;
        private IOperativeSystemService srvOperativeSystem;
        private IComputerBrandService srvComputerBrand;

        private DataTable dtCustomerInfrastructureServerComputers;

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

        public CustomerInfrastructureServerComputersControlController(
            CustomerInfrastructureServerComputersControl instance) : base(instance)  
        {
            this.controlCustomerInfrastructureServerComputers = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCustomerInfrastructureServerComputer = SamsaraAppContext.Resolve<ICustomerInfrastructureServerComputerService>();
                this.srvCustomerInfrastructure = SamsaraAppContext.Resolve<ICustomerInfrastructureService>();
                this.srvComputerBrand = SamsaraAppContext.Resolve<IComputerBrandService>();
                this.srvOperativeSystem = SamsaraAppContext.Resolve<IOperativeSystemService>();
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

                this.controlCustomerInfrastructureServerComputers.cbcComputerBrand.Parameters = pmtComputerBrand;
                this.controlCustomerInfrastructureServerComputers.cbcComputerBrand.Refresh();

                OperativeSystemParameters pmtOperativeSystem = new OperativeSystemParameters()
                {
                    OperativeSystemTypeId = (int)OperativeSystemTypeEnum.Server
                };

                this.controlCustomerInfrastructureServerComputers.oscOperativeSystem.Parameters = pmtOperativeSystem;
                this.controlCustomerInfrastructureServerComputers.oscOperativeSystem.Refresh();

                this.controlCustomerInfrastructureServerComputers.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            this.controlCustomerInfrastructureServerComputers
                .mtoCustomerInfrastructureServerComputerDBMSs.CustomerInfrastructureServerComputer
                = this.customerInfrastructureServerComputer;
            this.controlCustomerInfrastructureServerComputers
                .mtoCustomerInfrastructureServerComputerDBMSs.CustomParent
                = this.controlCustomerInfrastructureServerComputers;
            this.controlCustomerInfrastructureServerComputers
                .mtoCustomerInfrastructureServerComputerDBMSs.LoadControls();

            CustomerInfrastructureServerComputerParameters pmtCustomerInfrastructureServerComputer
                = new CustomerInfrastructureServerComputerParameters();

            pmtCustomerInfrastructureServerComputer.CustomerInfrastructureId
                = ParameterConstants.IntNone;

            this.dtCustomerInfrastructureServerComputers = this.srvCustomerInfrastructureServerComputer
                .SearchByParameters(pmtCustomerInfrastructureServerComputer);

            this.controlCustomerInfrastructureServerComputers.grdRelations.DataSource = null;
            this.controlCustomerInfrastructureServerComputers.grdRelations.DataSource
                = this.dtCustomerInfrastructureServerComputers;

            if (this.CustomerInfrastructure != null)
            {
                foreach (CustomerInfrastructureServerComputer customerInfrastructureServerComputer
                    in this.CustomerInfrastructure.CustomerInfrastructureServerComputers)
                {
                    DataRow row = this.dtCustomerInfrastructureServerComputers.NewRow();
                    this.dtCustomerInfrastructureServerComputers.Rows.Add(row);

                    row["CustomerInfrastructureServerComputerId"] = customerInfrastructureServerComputer
                        .CustomerInfrastructureServerComputerId;

                    row["ComputerBrandId"] = customerInfrastructureServerComputer.ComputerBrand.ComputerBrandId;
                    if (customerInfrastructureServerComputer.OperativeSystem == null)
                        row["OperativeSystemId"] = DBNull.Value;
                    else
                        row["OperativeSystemId"] = customerInfrastructureServerComputer.OperativeSystem.OperativeSystemId;
                    row["Utilization"] = customerInfrastructureServerComputer.Utilization;
                    row["CPU"] = customerInfrastructureServerComputer.CPU;
                    row["ManufacturerReferenceNumber"] = customerInfrastructureServerComputer.ManufacturerReferenceNumber;
                    row["ServerModel"] = customerInfrastructureServerComputer.ServerModel;
                    row["RAM"] = customerInfrastructureServerComputer.RAM;
                    row["Scalability"] = customerInfrastructureServerComputer.Scalability;
                    row["SerialNumber"] = customerInfrastructureServerComputer.SerialNumber;
                    row["StorageSystem"] = customerInfrastructureServerComputer.StorageSystem;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlCustomerInfrastructureServerComputers.cbcComputerBrand.Value = null;
            this.controlCustomerInfrastructureServerComputers.oscOperativeSystem.Value = null;
            this.controlCustomerInfrastructureServerComputers.txtUtilization.Text = string.Empty;
            this.controlCustomerInfrastructureServerComputers.txtCPU.Text = string.Empty;
            this.controlCustomerInfrastructureServerComputers.txtManufacturerNumber.Text = string.Empty;
            this.controlCustomerInfrastructureServerComputers.txtModel.Text = string.Empty;
            this.controlCustomerInfrastructureServerComputers.txtRAM.Text = string.Empty;
            this.controlCustomerInfrastructureServerComputers.txtScalability.Text = string.Empty;
            this.controlCustomerInfrastructureServerComputers.txtSerialNumber.Text = string.Empty;
            this.controlCustomerInfrastructureServerComputers.txtStorage.Text = string.Empty;
            this.controlCustomerInfrastructureServerComputers.mtoCustomerInfrastructureServerComputerDBMSs.LoadControls();
            this.controlCustomerInfrastructureServerComputers.mtoCustomerInfrastructureServerComputerDBMSs.ClearControls();
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtCustomerInfrastructureServerComputers.Rows.Clear();
            this.dtCustomerInfrastructureServerComputers.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.customerInfrastructureServerComputer = new CustomerInfrastructureServerComputer();
            this.customerInfrastructureServerComputer.CustomerInfrastructure = this.CustomerInfrastructure;
            this.controlCustomerInfrastructureServerComputers.mtoCustomerInfrastructureServerComputerDBMSs
                .CustomerInfrastructureServerComputer = this.customerInfrastructureServerComputer;
            this.customerInfrastructureServerComputer.Activated = true;
            this.customerInfrastructureServerComputer.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            if (entityId <= 0)
                this.customerInfrastructureServerComputer = this.CustomerInfrastructure
                    .CustomerInfrastructureServerComputers
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureServerComputer = this.CustomerInfrastructure
                    .CustomerInfrastructureServerComputers
                    .Single(x => x.CustomerInfrastructureServerComputerId == entityId);

            if (entityId <= 0)
                this.CustomerInfrastructure.CustomerInfrastructureServerComputers
                    .Remove(this.customerInfrastructureServerComputer);
            else
            {
                this.customerInfrastructureServerComputer.Activated = false;
                this.customerInfrastructureServerComputer.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            if (entityId <= 0)
                this.customerInfrastructureServerComputer = this.CustomerInfrastructure
                    .CustomerInfrastructureServerComputers
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureServerComputer = this.CustomerInfrastructure
                    .CustomerInfrastructureServerComputers
                    .Single(x => x.CustomerInfrastructureServerComputerId == entityId);

            this.controlCustomerInfrastructureServerComputers.cbcComputerBrand.Value
                = this.customerInfrastructureServerComputer.ComputerBrand;

            if (this.customerInfrastructureServerComputer.OperativeSystem == null)
                this.controlCustomerInfrastructureServerComputers.oscOperativeSystem.Value = null;
            else
                this.controlCustomerInfrastructureServerComputers.oscOperativeSystem.Value
                    = this.customerInfrastructureServerComputer.OperativeSystem;

            this.controlCustomerInfrastructureServerComputers.txtUtilization.Text
                = this.customerInfrastructureServerComputer.Utilization;
            this.controlCustomerInfrastructureServerComputers.txtCPU.Text
                = this.customerInfrastructureServerComputer.CPU;
            this.controlCustomerInfrastructureServerComputers.txtManufacturerNumber.Text
                = this.customerInfrastructureServerComputer.ManufacturerReferenceNumber;
            this.controlCustomerInfrastructureServerComputers.txtModel.Text
                = this.customerInfrastructureServerComputer.ServerModel;
            this.controlCustomerInfrastructureServerComputers.txtRAM.Text
                = this.customerInfrastructureServerComputer.RAM;
            this.controlCustomerInfrastructureServerComputers.txtScalability.Text
                = this.customerInfrastructureServerComputer.Scalability;
            this.controlCustomerInfrastructureServerComputers.txtSerialNumber.Text
                = this.customerInfrastructureServerComputer.SerialNumber;
            this.controlCustomerInfrastructureServerComputers.txtStorage.Text
                = this.customerInfrastructureServerComputer.StorageSystem;

            this.controlCustomerInfrastructureServerComputers.mtoCustomerInfrastructureServerComputerDBMSs
                .CustomerInfrastructureServerComputer = this.customerInfrastructureServerComputer;

            this.controlCustomerInfrastructureServerComputers.mtoCustomerInfrastructureServerComputerDBMSs
                .LoadControls();
        }

        protected override void LoadEntity()
        {
            this.customerInfrastructureServerComputer.ComputerBrand 
                = this.controlCustomerInfrastructureServerComputers.cbcComputerBrand.Value;

            this.customerInfrastructureServerComputer.OperativeSystem 
                = this.controlCustomerInfrastructureServerComputers.oscOperativeSystem.Value;

            this.customerInfrastructureServerComputer.Utilization
                = this.controlCustomerInfrastructureServerComputers.txtUtilization.Text;
            this.customerInfrastructureServerComputer.CPU
                = this.controlCustomerInfrastructureServerComputers.txtCPU.Text;
            this.customerInfrastructureServerComputer.ManufacturerReferenceNumber
                = this.controlCustomerInfrastructureServerComputers.txtManufacturerNumber.Text;
            this.customerInfrastructureServerComputer.ServerModel
                = this.controlCustomerInfrastructureServerComputers.txtModel.Text;
            this.customerInfrastructureServerComputer.RAM
                = this.controlCustomerInfrastructureServerComputers.txtRAM.Text;
            this.customerInfrastructureServerComputer.Scalability
                = this.controlCustomerInfrastructureServerComputers.txtScalability.Text;
            this.customerInfrastructureServerComputer.SerialNumber
                = this.controlCustomerInfrastructureServerComputers.txtSerialNumber.Text;
            this.customerInfrastructureServerComputer.StorageSystem
                = this.controlCustomerInfrastructureServerComputers.txtStorage.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (this.controlCustomerInfrastructureServerComputers.cbcComputerBrand.Value == null)
            {
                MessageBox.Show("Favor de seleccionar la Marca del Servidor.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlCustomerInfrastructureServerComputers.cbcComputerBrand.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            if (this.customerInfrastructureServerComputer.CustomerInfrastructureServerComputerId == -1)
                row = this.dtCustomerInfrastructureServerComputers.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureServerComputerId"])
                        == -(this.customerInfrastructureServerComputer as object).GetHashCode());
            else
                row = this.dtCustomerInfrastructureServerComputers.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["CustomerInfrastructureServerComputerId"])
                        == this.customerInfrastructureServerComputer.CustomerInfrastructureServerComputerId);

            if (row == null)
            {
                this.CustomerInfrastructure.CustomerInfrastructureServerComputers
                    .Add(this.customerInfrastructureServerComputer);

                row = this.dtCustomerInfrastructureServerComputers.NewRow();
                this.dtCustomerInfrastructureServerComputers.Rows.Add(row);
            }

            if (this.customerInfrastructureServerComputer.CustomerInfrastructureServerComputerId == -1)
                row["CustomerInfrastructureServerComputerId"] = -(this.customerInfrastructureServerComputer as object).GetHashCode();
            else
                row["CustomerInfrastructureServerComputerId"] = this.customerInfrastructureServerComputer
                    .CustomerInfrastructureServerComputerId;

            row["ComputerBrandId"] = this.customerInfrastructureServerComputer.ComputerBrand.ComputerBrandId;
            if (this.customerInfrastructureServerComputer.OperativeSystem == null)
                row["OperativeSystemId"] = DBNull.Value;
            else
                row["OperativeSystemId"] = this.customerInfrastructureServerComputer.OperativeSystem.OperativeSystemId;
            row["Utilization"] = this.customerInfrastructureServerComputer.Utilization;
            row["CPU"] = this.customerInfrastructureServerComputer.CPU;
            row["ManufacturerReferenceNumber"] = this.customerInfrastructureServerComputer.ManufacturerReferenceNumber;
            row["ServerModel"] = this.customerInfrastructureServerComputer.ServerModel;
            row["RAM"] = this.customerInfrastructureServerComputer.RAM;
            row["Scalability"] = this.customerInfrastructureServerComputer.Scalability;
            row["SerialNumber"] = this.customerInfrastructureServerComputer.SerialNumber;
            row["StorageSystem"] = this.customerInfrastructureServerComputer.StorageSystem;

            this.dtCustomerInfrastructureServerComputers.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlCustomerInfrastructureServerComputers.oscOperativeSystem.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputers.cbcComputerBrand.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputers.txtUtilization.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputers.txtCPU.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputers.txtManufacturerNumber.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputers.txtModel.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputers.txtRAM.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputers.txtScalability.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputers.txtSerialNumber.ReadOnly = !enabled;
            this.controlCustomerInfrastructureServerComputers.txtStorage.ReadOnly = !enabled;
        }

        protected override CustomerInfrastructureServerComputer GetEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        protected override int GetEntityId()
        {
            throw new NotImplementedException();
        }

        protected override DataRow GetEntityRow(CustomerInfrastructureServerComputer entity)
        {
            throw new NotImplementedException();
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

            OperativeSystemParameters pmtOperativeSystem = new OperativeSystemParameters()
            {
                OperativeSystemTypeId = ParameterConstants.IntDefault
            };

            IList<OperativeSystem> cctvTypes = this.srvOperativeSystem.GetListByParameters(pmtOperativeSystem);

            this.controlCustomerInfrastructureServerComputers.oscOperativeSystem.Parameters = pmtOperativeSystem;
            this.controlCustomerInfrastructureServerComputers.oscOperativeSystem.Refresh();

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                band.Columns["OperativeSystemId"], "OperativeSystemId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
