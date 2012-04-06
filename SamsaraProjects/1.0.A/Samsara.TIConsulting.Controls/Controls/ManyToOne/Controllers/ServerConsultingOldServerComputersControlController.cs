
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
using Samsara.TIConsulting.Core.Entities;
using Samsara.TIConsulting.Core.Parameters;
using Samsara.TIConsulting.Service.Interfaces;
using Samsara.Framework.Core.Constants;
using Samsara.Framework.Util;

namespace Samsara.TIConsulting.Controls.Controls.ManyToOne.Controllers
{
    public class ServerConsultingOldServerComputersControlController : ManyToOneLevel1ControlController<ServerConsultingOldServerComputer>
    {
        #region Attributes

        private IServerConsultingOldServerComputerService srvServerConsultingOldServerComputer;
        private ServerConsultingOldServerComputersControl controlServerConsultingOldServerComputers;
        private ServerConsultingOldServerComputer customerInfrastructureServerComputer;
        private IServerConsultingService srvServerConsulting;
        //private IOperativeSystemService srvOperativeSystem;
        //private IComputerBrandService srvComputerBrand;

        private DataTable dtServerConsultingOldServerComputers;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public ServerConsulting ServerConsulting
        {
            get;
            set;
        }

        #endregion Properties
        
        #region Constructor

        public ServerConsultingOldServerComputersControlController(
            ServerConsultingOldServerComputersControl instance) : base(instance)  
        {
            this.controlServerConsultingOldServerComputers = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvServerConsultingOldServerComputer = SamsaraAppContext.Resolve<IServerConsultingOldServerComputerService>();
                this.srvServerConsulting = SamsaraAppContext.Resolve<IServerConsultingService>();
                //this.srvComputerBrand = SamsaraAppContext.Resolve<IComputerBrandService>();
                //this.srvOperativeSystem = SamsaraAppContext.Resolve<IOperativeSystemService>();
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
                //ComputerBrandParameters pmtComputerBrand = new ComputerBrandParameters();

                //this.controlServerConsultingOldServerComputers.cbcComputerBrand.Parameters = pmtComputerBrand;
                //this.controlServerConsultingOldServerComputers.cbcComputerBrand.Refresh();

                //OperativeSystemParameters pmtOperativeSystem = new OperativeSystemParameters();

                //this.controlServerConsultingOldServerComputers.oscOperativeSystem.Parameters = pmtOperativeSystem;
                //this.controlServerConsultingOldServerComputers.oscOperativeSystem.Refresh();

                this.controlServerConsultingOldServerComputers.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            //this.controlServerConsultingOldServerComputers
            //    .mtoServerConsultingOldServerComputerDBMSs.ServerConsultingOldServerComputer
            //    = this.customerInfrastructureServerComputer;
            //this.controlServerConsultingOldServerComputers
            //    .mtoServerConsultingOldServerComputerDBMSs.CustomParent
            //    = this.controlServerConsultingOldServerComputers;
            //this.controlServerConsultingOldServerComputers
            //    .mtoServerConsultingOldServerComputerDBMSs.LoadControls();

            ServerConsultingOldServerComputerParameters pmtServerConsultingOldServerComputer
                = new ServerConsultingOldServerComputerParameters();

            //pmtServerConsultingOldServerComputer.ServerConsultingId
            //    = ParameterConstants.IntNone;

            //this.dtServerConsultingOldServerComputers = this.srvServerConsultingOldServerComputer
            //    .SearchByParameters(pmtServerConsultingOldServerComputer);

            this.controlServerConsultingOldServerComputers.grdRelations.DataSource = null;
            this.controlServerConsultingOldServerComputers.grdRelations.DataSource
                = this.dtServerConsultingOldServerComputers;

            if (this.ServerConsulting != null)
            {
                foreach (ServerConsultingOldServerComputer serverConsultingOldServerComputer
                    in this.ServerConsulting.ServerConsultingOldServerComputers)
                {
                    DataRow row = this.dtServerConsultingOldServerComputers.NewRow();
                    this.dtServerConsultingOldServerComputers.Rows.Add(row);

                    row["ServerConsultingOldServerComputerId"] = serverConsultingOldServerComputer
                        .ServerConsultingOldServerComputerId;

                    //row["ComputerBrandId"] = customerInfrastructureServerComputer.ComputerBrand.ComputerBrandId;
                    //if (customerInfrastructureServerComputer.OperativeSystem == null)
                    //    row["OperativeSystemId"] = DBNull.Value;
                    //else
                    //    row["OperativeSystemId"] = customerInfrastructureServerComputer.OperativeSystem.OperativeSystemId;
                    //row["Utilization"] = customerInfrastructureServerComputer.Utilization;
                    //row["CPU"] = customerInfrastructureServerComputer.CPU;
                    //row["ManufacturerReferenceNumber"] = customerInfrastructureServerComputer.ManufacturerReferenceNumber;
                    //row["ServerModel"] = customerInfrastructureServerComputer.ServerModel;
                    //row["RAM"] = customerInfrastructureServerComputer.RAM;
                    //row["Scalability"] = customerInfrastructureServerComputer.Scalability;
                    //row["SerialNumber"] = customerInfrastructureServerComputer.SerialNumber;
                    //row["StorageSystem"] = customerInfrastructureServerComputer.StorageSystem;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            //this.controlServerConsultingOldServerComputers.cbcComputerBrand.Value = null;
            //this.controlServerConsultingOldServerComputers.oscOperativeSystem.Value = null;
            //this.controlServerConsultingOldServerComputers.txtUtilization.Text = string.Empty;
            //this.controlServerConsultingOldServerComputers.txtCPU.Text = string.Empty;
            //this.controlServerConsultingOldServerComputers.txtManufacturerNumber.Text = string.Empty;
            //this.controlServerConsultingOldServerComputers.txtModel.Text = string.Empty;
            //this.controlServerConsultingOldServerComputers.txtRAM.Text = string.Empty;
            //this.controlServerConsultingOldServerComputers.txtScalability.Text = string.Empty;
            //this.controlServerConsultingOldServerComputers.txtSerialNumber.Text = string.Empty;
            //this.controlServerConsultingOldServerComputers.txtStorage.Text = string.Empty;
            //this.controlServerConsultingOldServerComputers.mtoServerConsultingOldServerComputerDBMSs.LoadControls();
            //this.controlServerConsultingOldServerComputers.mtoServerConsultingOldServerComputerDBMSs.ClearControls();
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtServerConsultingOldServerComputers.Rows.Clear();
            this.dtServerConsultingOldServerComputers.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            //this.customerInfrastructureServerComputer = new ServerConsultingOldServerComputer();
            //this.customerInfrastructureServerComputer.ServerConsulting = this.ServerConsulting;
            //this.controlServerConsultingOldServerComputers.mtoServerConsultingOldServerComputerDBMSs
            //    .ServerConsultingOldServerComputer = this.customerInfrastructureServerComputer;
            //this.customerInfrastructureServerComputer.Activated = true;
            //this.customerInfrastructureServerComputer.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureServerComputer = this.ServerConsulting
                    .ServerConsultingOldServerComputers
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureServerComputer = this.ServerConsulting
                    .ServerConsultingOldServerComputers
                    .Single(x => x.ServerConsultingOldServerComputerId == entityId);

            if (entityId <= 0)
                this.ServerConsulting.ServerConsultingOldServerComputers
                    .Remove(this.customerInfrastructureServerComputer);
            else
            {
                this.customerInfrastructureServerComputer.Activated = false;
                this.customerInfrastructureServerComputer.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.customerInfrastructureServerComputer = this.ServerConsulting
                    .ServerConsultingOldServerComputers
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.customerInfrastructureServerComputer = this.ServerConsulting
                    .ServerConsultingOldServerComputers
                    .Single(x => x.ServerConsultingOldServerComputerId == entityId);

            //this.controlServerConsultingOldServerComputers.cbcComputerBrand.Value
            //    = this.customerInfrastructureServerComputer.ComputerBrand;

            //if (this.customerInfrastructureServerComputer.OperativeSystem == null)
            //    this.controlServerConsultingOldServerComputers.oscOperativeSystem.Value = null;
            //else
            //    this.controlServerConsultingOldServerComputers.oscOperativeSystem.Value
            //        = this.customerInfrastructureServerComputer.OperativeSystem;

            //this.controlServerConsultingOldServerComputers.txtUtilization.Text
            //    = this.customerInfrastructureServerComputer.Utilization;
            //this.controlServerConsultingOldServerComputers.txtCPU.Text
            //    = this.customerInfrastructureServerComputer.CPU;
            //this.controlServerConsultingOldServerComputers.txtManufacturerNumber.Text
            //    = this.customerInfrastructureServerComputer.ManufacturerReferenceNumber;
            //this.controlServerConsultingOldServerComputers.txtModel.Text
            //    = this.customerInfrastructureServerComputer.ServerModel;
            //this.controlServerConsultingOldServerComputers.txtRAM.Text
            //    = this.customerInfrastructureServerComputer.RAM;
            //this.controlServerConsultingOldServerComputers.txtScalability.Text
            //    = this.customerInfrastructureServerComputer.Scalability;
            //this.controlServerConsultingOldServerComputers.txtSerialNumber.Text
            //    = this.customerInfrastructureServerComputer.SerialNumber;
            //this.controlServerConsultingOldServerComputers.txtStorage.Text
            //    = this.customerInfrastructureServerComputer.StorageSystem;

            //this.controlServerConsultingOldServerComputers.mtoServerConsultingOldServerComputerDBMSs
            //    .ServerConsultingOldServerComputer = this.customerInfrastructureServerComputer;

            //this.controlServerConsultingOldServerComputers.mtoServerConsultingOldServerComputerDBMSs
            //    .LoadControls();
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            //this.customerInfrastructureServerComputer.ComputerBrand 
            //    = this.controlServerConsultingOldServerComputers.cbcComputerBrand.Value;

            //this.customerInfrastructureServerComputer.OperativeSystem 
            //    = this.controlServerConsultingOldServerComputers.oscOperativeSystem.Value;

            //this.customerInfrastructureServerComputer.Utilization
            //    = this.controlServerConsultingOldServerComputers.txtUtilization.Text;
            //this.customerInfrastructureServerComputer.CPU
            //    = this.controlServerConsultingOldServerComputers.txtCPU.Text;
            //this.customerInfrastructureServerComputer.ManufacturerReferenceNumber
            //    = this.controlServerConsultingOldServerComputers.txtManufacturerNumber.Text;
            //this.customerInfrastructureServerComputer.ServerModel
            //    = this.controlServerConsultingOldServerComputers.txtModel.Text;
            //this.customerInfrastructureServerComputer.RAM
            //    = this.controlServerConsultingOldServerComputers.txtRAM.Text;
            //this.customerInfrastructureServerComputer.Scalability
            //    = this.controlServerConsultingOldServerComputers.txtScalability.Text;
            //this.customerInfrastructureServerComputer.SerialNumber
            //    = this.controlServerConsultingOldServerComputers.txtSerialNumber.Text;
            //this.customerInfrastructureServerComputer.StorageSystem
            //    = this.controlServerConsultingOldServerComputers.txtStorage.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            //if (this.controlServerConsultingOldServerComputers.cbcComputerBrand.Value == null)
            //{
            //    MessageBox.Show("Favor de seleccionar la Marca del Servidor.",
            //        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.controlServerConsultingOldServerComputers.cbcComputerBrand.Focus();
            //    return false;
            //}

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.customerInfrastructureServerComputer.ServerConsultingOldServerComputerId == -1)
                row = this.dtServerConsultingOldServerComputers.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["ServerConsultingOldServerComputerId"])
                        == -(this.customerInfrastructureServerComputer as object).GetHashCode());
            else
                row = this.dtServerConsultingOldServerComputers.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["ServerConsultingOldServerComputerId"])
                        == this.customerInfrastructureServerComputer.ServerConsultingOldServerComputerId);

            if (row == null)
            {
                this.ServerConsulting.ServerConsultingOldServerComputers
                    .Add(this.customerInfrastructureServerComputer);

                row = this.dtServerConsultingOldServerComputers.NewRow();
                this.dtServerConsultingOldServerComputers.Rows.Add(row);
            }

            if (this.customerInfrastructureServerComputer.ServerConsultingOldServerComputerId == -1)
                row["ServerConsultingOldServerComputerId"] = -(this.customerInfrastructureServerComputer as object).GetHashCode();
            else
                row["ServerConsultingOldServerComputerId"] = this.customerInfrastructureServerComputer
                    .ServerConsultingOldServerComputerId;

            //row["ComputerBrandId"] = this.customerInfrastructureServerComputer.ComputerBrand.ComputerBrandId;
            //if (this.customerInfrastructureServerComputer.OperativeSystem == null)
            //    row["OperativeSystemId"] = DBNull.Value;
            //else
            //    row["OperativeSystemId"] = this.customerInfrastructureServerComputer.OperativeSystem.OperativeSystemId;
            //row["Utilization"] = this.customerInfrastructureServerComputer.Utilization;
            //row["CPU"] = this.customerInfrastructureServerComputer.CPU;
            //row["ManufacturerReferenceNumber"] = this.customerInfrastructureServerComputer.ManufacturerReferenceNumber;
            //row["ServerModel"] = this.customerInfrastructureServerComputer.ServerModel;
            //row["RAM"] = this.customerInfrastructureServerComputer.RAM;
            //row["Scalability"] = this.customerInfrastructureServerComputer.Scalability;
            //row["SerialNumber"] = this.customerInfrastructureServerComputer.SerialNumber;
            //row["StorageSystem"] = this.customerInfrastructureServerComputer.StorageSystem;

            this.dtServerConsultingOldServerComputers.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            //this.controlServerConsultingOldServerComputers.oscOperativeSystem.ReadOnly = !enabled;
            //this.controlServerConsultingOldServerComputers.cbcComputerBrand.ReadOnly = !enabled;
            //this.controlServerConsultingOldServerComputers.txtUtilization.ReadOnly = !enabled;
            //this.controlServerConsultingOldServerComputers.txtCPU.ReadOnly = !enabled;
            //this.controlServerConsultingOldServerComputers.txtManufacturerNumber.ReadOnly = !enabled;
            //this.controlServerConsultingOldServerComputers.txtModel.ReadOnly = !enabled;
            //this.controlServerConsultingOldServerComputers.txtRAM.ReadOnly = !enabled;
            //this.controlServerConsultingOldServerComputers.txtScalability.ReadOnly = !enabled;
            //this.controlServerConsultingOldServerComputers.txtSerialNumber.ReadOnly = !enabled;
            //this.controlServerConsultingOldServerComputers.txtStorage.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand band = e.Layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            //ComputerBrandParameters pmtComputerBrand = new ComputerBrandParameters();

            //IList<ComputerBrand> cctvBrands = this.srvComputerBrand.GetListByParameters(pmtComputerBrand);
            //WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvBrands,
            //    band.Columns["ComputerBrandId"], "ComputerBrandId", "Name", "Seleccione");

            //OperativeSystemParameters pmtOperativeSystem = new OperativeSystemParameters();

            //IList<OperativeSystem> cctvTypes = this.srvOperativeSystem.GetListByParameters(pmtOperativeSystem);

            //this.controlServerConsultingOldServerComputers.oscOperativeSystem.Parameters = pmtOperativeSystem;
            //this.controlServerConsultingOldServerComputers.oscOperativeSystem.Refresh();

            //WindowsFormsUtil.SetUltraGridValueList(e.Layout, cctvTypes,
                //band.Columns["OperativeSystemId"], "OperativeSystemId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
