
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Samsara.Controls.Controls;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using System.Windows.Forms;
using System.Data;

namespace Samsara.Controls.Controllers
{
    public class ManyToOneLevel1ControlController
    {
        #region Attributes

        private ManyToOneLevel1Control controlManyToOneLevel1Control;

        #endregion Attributes

        #region Constructor

        public ManyToOneLevel1ControlController(ManyToOneLevel1Control instance)
        {
            this.controlManyToOneLevel1Control = instance;
            this.InitializeControlControls();
        }

        #endregion Constructor

        #region Methods

        #region Internal

        internal void Click(object sender)
        {
            if ((sender as UltraButton) == this.controlManyToOneLevel1Control.ubtnDeleteRelation)
                this.DeleteRelation();
            if ((sender as UltraButton) == this.controlManyToOneLevel1Control.ubtnCancelRelation)
                this.CancelRelation();
            if ((sender as UltraButton) == this.controlManyToOneLevel1Control.ubtnCreateRelation)
                this.CreateRelation();
            if ((sender as UltraButton) == this.controlManyToOneLevel1Control.ubtnEditRelation)
                this.EditRelation();
            if ((sender as UltraButton) == this.controlManyToOneLevel1Control.ubtnSaveRelation)
                this.SaveRelation();
        }

        internal void HideDetail()
        {
            this.controlManyToOneLevel1Control.upnDetailButtons.Visible = true;
            this.controlManyToOneLevel1Control.gbxDetDetail.Visible = false;
            this.controlManyToOneLevel1Control.upnlButtons.Visible = false;
        }

        internal void ShowDetail()
        {
            this.controlManyToOneLevel1Control.upnDetailButtons.Visible = false;
            this.controlManyToOneLevel1Control.gbxDetDetail.Visible = true;
            this.controlManyToOneLevel1Control.upnlButtons.Visible = true;
        }

        #endregion Internal

        #region Public

        public virtual void InitializeControlControls()
        {
            this.HideDetail();
        }

        public virtual void DeleteRelation()
        {
            UltraGridRow activeRow = this.controlManyToOneLevel1Control.grdRelations.ActiveRow;

            if (activeRow != null)
            {
                if (MessageBox.Show("¿Esta seguro de borrar el registro?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;

                int entityId = Convert.ToInt32((activeRow.ListObject as DataRowView).Row[0]);

                this.DeleteEntity(entityId);

                DataRow row = (activeRow.ListObject as DataRowView).Row;

                DataTable dtGrid = this.controlManyToOneLevel1Control.grdRelations.DataSource as DataTable;

                dtGrid.Rows.Remove(row);

                dtGrid.AcceptChanges();
            }
        }

        public virtual void SaveRelation()
        {
            if (this.ValidateControlsData())
            {
                this.LoadEntity();
                this.HideDetail();
            }
        }

        public virtual void EditRelation()
        {
            UltraGridRow activeRow = this.controlManyToOneLevel1Control.grdRelations.ActiveRow;

            if (activeRow != null)
            {
                this.ClearDetailControls();
                this.ShowDetail();

                int entityId = Convert.ToInt32((activeRow.ListObject as DataRowView).Row[0]);

                this.LoadFromEntity(entityId);
            }
        }

        public virtual void CreateRelation()
        {
            this.ClearDetailControls();
            this.HideDetail();
        }

        public virtual void CancelRelation()
        {
            this.HideDetail();
        }

        public virtual void ClearDetailControls()
        {
            this.controlManyToOneLevel1Control.tabDetail.SelectedTab
                = this.controlManyToOneLevel1Control.tabItmPrincipal;
        }

        public virtual void LoadEntity()
        {
            throw new NotImplementedException();
        }

        public virtual void LoadFromEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public virtual void LoadGrid()
        {
            throw new NotImplementedException();
        }

        public virtual bool ValidateControlsData()
        {
            throw new NotImplementedException();
        }

        #endregion Public

        #endregion Methods
    }
}
