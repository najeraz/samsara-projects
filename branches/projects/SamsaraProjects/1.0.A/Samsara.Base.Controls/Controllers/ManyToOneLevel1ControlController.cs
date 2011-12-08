﻿
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Controls.Controls;
using Samsara.Base.Controls.EventsArgs;

namespace Samsara.Base.Controls.Controllers
{
    public class ManyToOneLevel1ControlController<T>
    {
        #region Attributes

        private ManyToOneLevel1Control<T> control;

        #endregion Attributes

        #region Constructor

        public ManyToOneLevel1ControlController(ManyToOneLevel1Control<T> instance)
        {
            this.control = instance;
            this.InitializeControlControls();
        }

        #endregion Constructor

        #region Methods

        #region Internal

        [DebuggerStepThrough]
        internal void ButtonClick(object sender)
        {
            if ((sender as UltraButton) == this.control.ubtnDeleteRelation)
                this.DeleteRelation();
            if ((sender as UltraButton) == this.control.ubtnCancelRelation)
                this.CancelRelation();
            if ((sender as UltraButton) == this.control.ubtnCreateRelation)
                this.CreateRelation();
            if ((sender as UltraButton) == this.control.ubtnEditRelation)
                this.EditRelation();
            if ((sender as UltraButton) == this.control.ubtnSaveRelation)
                this.SaveRelation();
            if ((sender as UltraButton) == this.control.ubtnViewRelation)
                this.ViewRelation();
            if ((sender as UltraButton) == this.control.ubtnCloseRelation)
                this.CloseRelation();
        }

        internal void HideDetail()
        {
            this.control.upnDetailButtons.Visible = true;
            this.control.gbxDetDetail.Visible = false;
            this.control.upnlButtons.Visible = false;
        }

        internal void ShowDetail()
        {
            this.control.upnDetailButtons.Visible = false;
            this.control.gbxDetDetail.Visible = true;
            this.control.upnlButtons.Visible = true;
        }

        #endregion Internal

        #region Public

        public virtual void ClearDetailControls()
        {
            this.control.tabDetail.SelectedTab = this.control.tabItmPrincipal;
        }

        public virtual void ClearControls()
        {
        }

        private void InitializeControlControls()
        {
            this.HideDetail();
        }

        protected virtual void DeleteRelation()
        {
            UltraGridRow activeRow = this.control.grdRelations.ActiveRow;

            if (activeRow != null)
            {
                if (MessageBox.Show("¿Esta seguro de borrar el registro?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;

                int entityId = Convert.ToInt32((activeRow.ListObject as DataRowView).Row[0]);

                this.DeleteEntity(entityId);

                DataRow row = (activeRow.ListObject as DataRowView).Row;

                DataTable dtGrid = this.control.grdRelations.DataSource as DataTable;

                dtGrid.Rows.Remove(row);

                dtGrid.AcceptChanges();
            }
        }

        protected virtual void SaveRelation()
        {
            if (this.ValidateControlsData())
            {
                this.LoadEntity();
                this.AddEntity();
                this.HideDetail();

                UltraGridCell activeCell = this.control.grdRelations.ActiveCell;

                if (activeCell != null)
                {
                    this.control.OnEntityChanged(new ManyToOneLevel1EntityChangedEventArgs<T>(
                        GetEntity(Convert.ToInt32(activeCell.Row.Cells[0].Value))));
                }
            }
        }

        protected virtual void AddEntity()
        {
        }

        protected virtual void ViewRelation()
        {
            UltraGridRow activeRow = this.control.grdRelations.ActiveRow;

            if (activeRow != null)
            {
                this.ClearDetailControls();
                this.ShowDetail();
                this.EnabledDetailControls(false);

                int entityId = Convert.ToInt32((activeRow.ListObject as DataRowView).Row[0]);

                this.LoadFromEntity(entityId);
            }
        }

        protected virtual void CloseRelation()
        {
            this.HideDetail();
        }

        protected virtual void EditRelation()
        {
            UltraGridRow activeRow = this.control.grdRelations.ActiveRow;

            if (activeRow != null)
            {
                this.ClearDetailControls();
                this.ShowDetail();
                this.EnabledDetailControls(true);

                int entityId = Convert.ToInt32((activeRow.ListObject as DataRowView).Row[0]);

                this.LoadFromEntity(entityId);
            }
        }

        protected virtual void CreateRelation()
        {
            this.ClearDetailControls();
            this.ShowDetail();
            this.EnabledDetailControls(true);
        }

        protected virtual void CancelRelation()
        {
            this.HideDetail();
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

        protected virtual void EnabledDetailControls(bool enabled)
        {
            this.control.ubtnCloseRelation.Visible = !enabled;
            this.control.upnlSeparatorCloseRelation.Visible = !enabled;
            this.control.ubtnCancelRelation.Visible = enabled;
            this.control.upnlSeparatorCancelRelation.Visible = enabled;
            this.control.ubtnSaveRelation.Visible = enabled;
            this.control.upnlSeparatorSaveRelation.Visible = enabled;
        }

        protected virtual T GetEntity(int entityId)
        {
            return default(T);
        }

        #endregion Public

        #endregion Methods
    }
}
