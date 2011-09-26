
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

        #endregion Internal

        #region Public

        public virtual void DeleteRelation()
        {
            UltraGridRow activeRow = this.controlManyToOneLevel1Control.grdRelations.ActiveRow;

            if (activeRow != null)
            {
                DataRow row = (activeRow.ListObject as DataRowView).Row;

                DataTable dtGrid = this.controlManyToOneLevel1Control.grdRelations.DataSource as DataTable;

                dtGrid.Rows.Remove(row);

                dtGrid.AcceptChanges();
            }
        }

        public virtual void SaveRelation()
        {
            this.HideDetail();
        }

        public virtual void EditRelation()
        {
            this.ClearDetailControls();
            this.ShowDetail();
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
            // Se limpian los controles que se añadan al heredar la clase.
        }

        #endregion Public

        #region Private

        private void InitializeControlControls()
        {
            this.HideDetail();
        }

        private void HideDetail()
        {
            this.controlManyToOneLevel1Control.upnDetailButtons.Visible = false;
            this.controlManyToOneLevel1Control.gbxDetDetail.Visible = false;
            this.controlManyToOneLevel1Control.upnlButtons.Visible = true;
        }

        private void ShowDetail()
        {
            this.controlManyToOneLevel1Control.upnDetailButtons.Visible = true;
            this.controlManyToOneLevel1Control.gbxDetDetail.Visible = true;
            this.controlManyToOneLevel1Control.upnlButtons.Visible = false;
        }

        #endregion Private

        #endregion Methods
    }
}
