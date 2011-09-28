
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Samsara.Controls.Controls;

namespace Samsara.Controls.Controllers
{
    public class ManyToOneLevel1ControlController
    {
        #region Attributes

        private ManyToOneLevel1Control controller;
        protected int entityCounter;

        #endregion Attributes

        #region Constructor

        public ManyToOneLevel1ControlController(ManyToOneLevel1Control instance)
        {
            this.controller = instance;
            this.InitializeControlControls();
            this.entityCounter = -2;
        }

        #endregion Constructor

        #region Methods

        #region Internal

        [DebuggerStepThrough]
        internal void ButtonClick(object sender)
        {
            if ((sender as UltraButton) == this.controller.ubtnDeleteRelation)
                this.DeleteRelation();
            if ((sender as UltraButton) == this.controller.ubtnCancelRelation)
                this.CancelRelation();
            if ((sender as UltraButton) == this.controller.ubtnCreateRelation)
                this.CreateRelation();
            if ((sender as UltraButton) == this.controller.ubtnEditRelation)
                this.EditRelation();
            if ((sender as UltraButton) == this.controller.ubtnSaveRelation)
                this.SaveRelation();
        }

        internal void HideDetail()
        {
            this.controller.upnDetailButtons.Visible = true;
            this.controller.gbxDetDetail.Visible = false;
            this.controller.upnlButtons.Visible = false;
        }

        internal void ShowDetail()
        {
            this.controller.upnDetailButtons.Visible = false;
            this.controller.gbxDetDetail.Visible = true;
            this.controller.upnlButtons.Visible = true;
        }

        #endregion Internal

        #region Public

        private void InitializeControlControls()
        {
            this.HideDetail();
        }

        protected virtual void DeleteRelation()
        {
            UltraGridRow activeRow = this.controller.grdRelations.ActiveRow;

            if (activeRow != null)
            {
                if (MessageBox.Show("¿Esta seguro de borrar el registro?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;

                int entityId = Convert.ToInt32((activeRow.ListObject as DataRowView).Row[0]);

                this.DeleteEntity(entityId);

                DataRow row = (activeRow.ListObject as DataRowView).Row;

                DataTable dtGrid = this.controller.grdRelations.DataSource as DataTable;

                dtGrid.Rows.Remove(row);

                dtGrid.AcceptChanges();
            }
        }

        protected virtual void SaveRelation()
        {
            if (this.ValidateControlsData())
            {
                this.LoadEntity();
                this.HideDetail();
            }
        }

        protected virtual void EditRelation()
        {
            UltraGridRow activeRow = this.controller.grdRelations.ActiveRow;

            if (activeRow != null)
            {
                this.ClearDetailControls();
                this.ShowDetail();

                int entityId = Convert.ToInt32((activeRow.ListObject as DataRowView).Row[0]);

                this.LoadFromEntity(entityId);
            }
        }

        protected virtual void CreateRelation()
        {
            this.ClearDetailControls();
            this.ShowDetail();
        }

        protected virtual void CancelRelation()
        {
            this.HideDetail();
        }

        protected virtual void ClearDetailControls()
        {
            this.controller.tabDetail.SelectedTab
                = this.controller.tabItmPrincipal;
        }

        protected virtual void LoadEntity()
        {
        }

        protected virtual void LoadFromEntity(int entityId)
        {
        }

        protected virtual void DeleteEntity(int entityId)
        {
        }

        protected virtual bool ValidateControlsData()
        {
            return true;
        }

        #endregion Public

        #endregion Methods
    }
}
