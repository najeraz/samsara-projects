
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
using Samsara.TIConsulting.Core.Entities;
using Samsara.TIConsulting.Core.Parameters;
using Samsara.TIConsulting.Service.Interfaces;

namespace Samsara.TIConsulting.Controls.Controls.ManyToOne.Controllers
{
    public class ServerConsultingOldServerComputersControlController : ManyToOneLevel1ControlController<ServerConsultingOldServerComputer>
    {
        #region Attributes

        private IServerConsultingOldServerComputerService srvServerConsultingOldServerComputer;
        private ServerConsultingOldServerComputersControl ctlServerConsultingOldServerComputers;
        private ServerConsultingOldServerComputer serverConsultingOldServerComputer;
        private IServerComputerTypeService srvServerComputerType;
        private IServerConsultingService srvServerConsulting;
        private IOperativeSystemService srvOperativeSystem;
        private IComputerBrandService srvComputerBrand;
        private IRackTypeService srvRackType;

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
            this.ctlServerConsultingOldServerComputers = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvServerConsultingOldServerComputer = SamsaraAppContext.Resolve<IServerConsultingOldServerComputerService>();
                this.srvServerComputerType = SamsaraAppContext.Resolve<IServerComputerTypeService>();
                this.srvServerConsulting = SamsaraAppContext.Resolve<IServerConsultingService>();
                this.srvOperativeSystem = SamsaraAppContext.Resolve<IOperativeSystemService>();
                this.srvComputerBrand = SamsaraAppContext.Resolve<IComputerBrandService>();
                this.srvRackType = SamsaraAppContext.Resolve<IRackTypeService>();
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
                this.ctlServerConsultingOldServerComputers.sctcServerComputerType.Refresh();
                this.ctlServerConsultingOldServerComputers.rtcRackType.Refresh();
                this.ctlServerConsultingOldServerComputers.cbcComputerBrand.Refresh();

                OperativeSystemParameters pmtOperativeSystem = new OperativeSystemParameters()
                {
                    OperativeSystemTypeId = (int)OperativeSystemTypeEnum.Server
                };

                this.ctlServerConsultingOldServerComputers.oscOperativeSystem.Parameters = pmtOperativeSystem;
                this.ctlServerConsultingOldServerComputers.oscOperativeSystem.Refresh();

                this.ctlServerConsultingOldServerComputers.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            ServerConsultingOldServerComputerParameters pmtServerConsultingOldServerComputer
                = new ServerConsultingOldServerComputerParameters()
                {
                    ServerConsultingOldServerComputerId = ParameterConstants.IntNone
                };

            this.dtServerConsultingOldServerComputers = this.srvServerConsultingOldServerComputer
                .SearchByParameters(pmtServerConsultingOldServerComputer);

            this.ctlServerConsultingOldServerComputers.grdRelations.DataSource = null;
            this.ctlServerConsultingOldServerComputers.grdRelations.DataSource
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

                    if (serverConsultingOldServerComputer.OperativeSystem == null)
                        row["OperativeSystemId"] = DBNull.Value;
                    else
                        row["OperativeSystemId"] = serverConsultingOldServerComputer.OperativeSystem.OperativeSystemId;

                    if (serverConsultingOldServerComputer.ComputerBrand == null)
                        row["ComputerBrandId"] = DBNull.Value;
                    else
                        row["ComputerBrandId"] = serverConsultingOldServerComputer.ComputerBrand.ComputerBrandId;

                    if (serverConsultingOldServerComputer.RackType == null)
                        row["RackTypeId"] = DBNull.Value;
                    else
                        row["RackTypeId"] = serverConsultingOldServerComputer.RackType.RackTypeId;

                    row["ServerSpecs"] = serverConsultingOldServerComputer.ServerSpecs;
                    row["ServerModel"] = serverConsultingOldServerComputer.ServerModel;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.ctlServerConsultingOldServerComputers.rtcRackType.Value = null;
            this.ctlServerConsultingOldServerComputers.sctcServerComputerType.Value = null;
            this.ctlServerConsultingOldServerComputers.oscOperativeSystem.Value = null;
            this.ctlServerConsultingOldServerComputers.cbcComputerBrand.Value = null;
            this.ctlServerConsultingOldServerComputers.txtServerModel.Value = null;
            this.ctlServerConsultingOldServerComputers.txtServerSpecs.Value = null;
            this.ctlServerConsultingOldServerComputers.txtServersQuantity.Value = null;
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

            this.serverConsultingOldServerComputer = new ServerConsultingOldServerComputer();
            this.serverConsultingOldServerComputer.ServerConsulting = this.ServerConsulting;
        }

        protected override ServerConsultingOldServerComputer GetEntity(int entityId)
        {
            if (entityId <= 0)
                return this.ServerConsulting.ServerConsultingOldServerComputers
                    .Single(x => -x.GetHashCode() == entityId);
            else
                return this.ServerConsulting.ServerConsultingOldServerComputers
                    .Single(x => x.ServerConsultingOldServerComputerId == entityId);
        }

        protected override int GetEntityId()
        {
            return this.serverConsultingOldServerComputer == null ? base.GetEntityId()
                : this.serverConsultingOldServerComputer.ServerConsultingOldServerComputerId <= 0 ?
                -this.serverConsultingOldServerComputer.GetHashCode() 
                : this.serverConsultingOldServerComputer.ServerConsultingOldServerComputerId;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            this.serverConsultingOldServerComputer = this.GetEntity(entityId);

            if (entityId <= 0)
            {
                this.ServerConsulting.ServerConsultingOldServerComputers
                    .Remove(this.serverConsultingOldServerComputer);
            }
            else
            {
                this.serverConsultingOldServerComputer.Activated = false;
                this.serverConsultingOldServerComputer.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            this.serverConsultingOldServerComputer = this.GetEntity(entityId);

            this.ctlServerConsultingOldServerComputers.txtServerModel.Value = this.serverConsultingOldServerComputer.ServerModel;
            this.ctlServerConsultingOldServerComputers.txtServerSpecs.Value = this.serverConsultingOldServerComputer.ServerSpecs;
            this.ctlServerConsultingOldServerComputers.txtServersQuantity.Value = this.serverConsultingOldServerComputer.ServersQuantity;

            this.ctlServerConsultingOldServerComputers.rtcRackType.Value = this.serverConsultingOldServerComputer.RackType;
            this.ctlServerConsultingOldServerComputers.sctcServerComputerType.Value = this.serverConsultingOldServerComputer.ServerComputerType;
            this.ctlServerConsultingOldServerComputers.cbcComputerBrand.Value = this.serverConsultingOldServerComputer.ComputerBrand;
            this.ctlServerConsultingOldServerComputers.oscOperativeSystem.Value = this.serverConsultingOldServerComputer.OperativeSystem;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.serverConsultingOldServerComputer.RackType
                = this.ctlServerConsultingOldServerComputers.rtcRackType.Value;
            this.serverConsultingOldServerComputer.ComputerBrand
                = this.ctlServerConsultingOldServerComputers.cbcComputerBrand.Value;
            this.serverConsultingOldServerComputer.OperativeSystem
                = this.ctlServerConsultingOldServerComputers.oscOperativeSystem.Value;
            this.serverConsultingOldServerComputer.ServerComputerType
                = this.ctlServerConsultingOldServerComputers.sctcServerComputerType.Value;

            this.serverConsultingOldServerComputer.ServerSpecs
                = this.ctlServerConsultingOldServerComputers.txtServerSpecs.Text;
            this.serverConsultingOldServerComputer.ServerModel
                = this.ctlServerConsultingOldServerComputers.txtServerModel.Text;
            this.serverConsultingOldServerComputer.ServersQuantity
                = Convert.ToInt32(this.ctlServerConsultingOldServerComputers.txtServerModel.Value);
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            row = this.GetEntityRow(this.serverConsultingOldServerComputer);

            if (row == null)
            {
                this.ServerConsulting.ServerConsultingOldServerComputers
                    .Add(this.serverConsultingOldServerComputer);

                row = this.dtServerConsultingOldServerComputers.NewRow();
                this.dtServerConsultingOldServerComputers.Rows.Add(row);
            }

            if (this.serverConsultingOldServerComputer.ServerConsultingOldServerComputerId == -1)
                row["ServerConsultingOldServerComputerId"] = -(this.serverConsultingOldServerComputer as object).GetHashCode();
            else
                row["ServerConsultingOldServerComputerId"] = this.serverConsultingOldServerComputer
                    .ServerConsultingOldServerComputerId;

            if (this.serverConsultingOldServerComputer.OperativeSystem == null)
                row["OperativeSystemId"] = DBNull.Value;
            else
                row["OperativeSystemId"] = this.serverConsultingOldServerComputer.OperativeSystem.OperativeSystemId;

            if (this.serverConsultingOldServerComputer.ComputerBrand == null)
                row["ComputerBrandId"] = DBNull.Value;
            else
                row["ComputerBrandId"] = this.serverConsultingOldServerComputer.ComputerBrand.ComputerBrandId;

            if (this.serverConsultingOldServerComputer.ServerComputerType == null)
                row["ServerComputerTypeId"] = DBNull.Value;
            else
                row["ServerComputerTypeId"] = this.serverConsultingOldServerComputer.ServerComputerType.ServerComputerTypeId;

            if (this.serverConsultingOldServerComputer.RackType == null)
                row["RackTypeId"] = DBNull.Value;
            else
                row["RackTypeId"] = this.serverConsultingOldServerComputer.RackType.RackTypeId;

            row["ServerModel"] = this.serverConsultingOldServerComputer.ServerModel;
            row["ServerSpecs"] = this.serverConsultingOldServerComputer.ServerSpecs;
            row["ServersQuantity"] = this.serverConsultingOldServerComputer.ServersQuantity;

            this.dtServerConsultingOldServerComputers.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.ctlServerConsultingOldServerComputers.rtcRackType.ReadOnly = !enabled;
            this.ctlServerConsultingOldServerComputers.sctcServerComputerType.ReadOnly = !enabled;
            this.ctlServerConsultingOldServerComputers.oscOperativeSystem.ReadOnly = !enabled;
            this.ctlServerConsultingOldServerComputers.cbcComputerBrand.ReadOnly = !enabled;
            this.ctlServerConsultingOldServerComputers.txtServerModel.ReadOnly = !enabled;
            this.ctlServerConsultingOldServerComputers.txtServerSpecs.ReadOnly = !enabled;
            this.ctlServerConsultingOldServerComputers.txtServersQuantity.ReadOnly = !enabled;
        }

        protected override DataRow GetEntityRow(ServerConsultingOldServerComputer entity)
        {
            if (this.serverConsultingOldServerComputer.ServerConsultingOldServerComputerId == -1)
                return this.dtServerConsultingOldServerComputers.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["ServerConsultingOldServerComputerId"])
                        == -(this.serverConsultingOldServerComputer as object).GetHashCode());
            else
                return this.dtServerConsultingOldServerComputers.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["ServerConsultingOldServerComputerId"])
                        == this.serverConsultingOldServerComputer.ServerConsultingOldServerComputerId);
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
                OperativeSystemTypeId = (int)OperativeSystemTypeEnum.Server
            };

            IList<OperativeSystem> operativeSystemTypes = this.srvOperativeSystem.GetListByParameters(pmtOperativeSystem);

            WindowsFormsUtil.SetUltraGridValueList(e.Layout, operativeSystemTypes,
                band.Columns["OperativeSystemId"], "OperativeSystemId", "Name", "Seleccione");

            ServerComputerTypeParameters pmtServerComputerType = new ServerComputerTypeParameters();

            IList<ServerComputerType> serverComputerTypes = this.srvServerComputerType.GetListByParameters(pmtServerComputerType);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, serverComputerTypes,
                band.Columns["ServerComputerTypeId"], "ServerComputerTypeId", "Name", "Seleccione");

            RackTypeParameters pmtRackType = new RackTypeParameters();

            IList<RackType> rackTypes = this.srvRackType.GetListByParameters(pmtRackType);
            WindowsFormsUtil.SetUltraGridValueList(e.Layout, rackTypes,
                band.Columns["RackTypeId"], "RackTypeId", "Name", "Seleccione");
        }

        #endregion Events
    }
}
