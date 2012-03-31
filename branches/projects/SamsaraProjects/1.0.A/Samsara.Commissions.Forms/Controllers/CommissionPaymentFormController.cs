
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Controllers;
using Samsara.Commissions.Core.Entities;
using Samsara.Commissions.Core.Enums;
using Samsara.Commissions.Core.Parameters;
using Samsara.Commissions.Forms.Forms;
using Samsara.Commissions.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.Commissions.Forms.Controllers
{
    public class CommissionPaymentFormController : GenericDocumentFormController
    {
        #region Attributes

        private CommissionPaymentForm frmCommissionPayment;
        private ICommissionPaymentService srvCommissionPayment;
        private CommissionPayment commissionPayment;

        #endregion Attributes

        #region Constructor

        public CommissionPaymentFormController(CommissionPaymentForm frmCommissionPayment)
            : base(frmCommissionPayment)
        {
            this.frmCommissionPayment = frmCommissionPayment;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvCommissionPayment = SamsaraAppContext.Resolve<ICommissionPaymentService>();
            }
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected override void ReadOnlySearchFields(bool readOnly)
        {
            base.ReadOnlySearchFields(readOnly);
        }

        #endregion Protected

        #region Public

        public override void InitializeFormControls()
        {
            this.frmCommissionPayment.sccSchStaff.DisplayMember = "Fullname";
            this.frmCommissionPayment.sccSchStaff.Refresh();

            this.frmCommissionPayment.grdPrincipal.InitializeLayout 
                += new InitializeLayoutEventHandler(grdPrincipal_InitializeLayout);
        }

        public override void InitializeDetailFormControls()
        {
            this.frmCommissionPayment.sccDetStaff.DisplayMember = "Fullname";
            this.frmCommissionPayment.sccDetStaff.Refresh();

            WindowsFormsUtil.LoadCombo(this.frmCommissionPayment.uceDetMonth,
                TimeUtil.Months, "Index", "Name", "Seleccione", false);
        }

        public override bool ValidateCanCreateEntity()
        {
            return this.HasPermission(CommissionPaymentFormUserPermissionEnum
                .CanCreateEditOrDeleteCommissionsPayments);
        }

        public override bool ValidateCanEditEntity()
        {
            return this.HasPermission(CommissionPaymentFormUserPermissionEnum
                .CanCreateEditOrDeleteCommissionsPayments);
        }

        public override bool ValidateCanDeleteEntity()
        {
            return this.HasPermission(CommissionPaymentFormUserPermissionEnum
                .CanCreateEditOrDeleteCommissionsPayments);
        }

        public override void Search()
        {
            CommissionPaymentParameters pmtCommissionPayment = new CommissionPaymentParameters();

            pmtCommissionPayment.StaffId = this.frmCommissionPayment.sccSchStaff.Value == null ?
                ParameterConstants.IntDefault : this.frmCommissionPayment.sccSchStaff.Value.StaffId;

            this.frmCommissionPayment.grdPrincipal.DataSource = null;
            this.frmCommissionPayment.grdPrincipal.DataSource = this.srvCommissionPayment.SearchByParameters(pmtCommissionPayment);
        }

        public override void ClearSearchFields()
        {
            this.frmCommissionPayment.sccSchStaff.Value = null;
        }

        public override void ReturnSelectedEntity()
        {
        }

        public override void DeleteEntity()
        {
            if (commissionPayment != null)
            {
                this.srvCommissionPayment.Delete(commissionPayment);
            }

            this.Search();
        }

        public override bool ValidateFormInformation()
        {
            if (this.frmCommissionPayment.sccDetStaff.Value == null)
            {
                MessageBox.Show("Favor de asignar el Asesor de Venta.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCommissionPayment.sccDetStaff.Focus();
                return false;
            }

            if (this.frmCommissionPayment.txtDetAmount.Value == null ||
                string.IsNullOrEmpty(this.frmCommissionPayment.txtDetAmount.Value.ToString()))
            {
                MessageBox.Show("Favor de asignar el Monto del Pago.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCommissionPayment.txtDetAmount.Focus();
                return false;
            }

            if (this.frmCommissionPayment.uceDetMonth.Value == null ||
                Convert.ToInt32(this.frmCommissionPayment.uceDetMonth.Value) == -1)
            {
                MessageBox.Show("Favor de asignar el Mes del Pago.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCommissionPayment.uceDetMonth.Focus();
                return false;
            }

            if (this.frmCommissionPayment.txtDetYear.Value == null ||
                string.IsNullOrEmpty(this.frmCommissionPayment.txtDetYear.Value.ToString()))
            {
                MessageBox.Show("Favor de asignar el Año del Pago.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmCommissionPayment.txtDetYear.Focus();
                return false;
            }

            return true;
        }

        public override bool LoadEntity(int serviceId)
        {
            this.commissionPayment = this.srvCommissionPayment.GetById(serviceId);

            return this.commissionPayment != null;
        }

        public override void CreateEntity()
        {
            this.commissionPayment = new CommissionPayment();
        }

        public override void ReadOnlyDetailFields(bool readOnly)
        {
            this.frmCommissionPayment.txtDetComments.ReadOnly = readOnly;
            this.frmCommissionPayment.sccDetStaff.ReadOnly = readOnly;
            this.frmCommissionPayment.txtDetAmount.ReadOnly = readOnly;
            this.frmCommissionPayment.uceDetMonth.ReadOnly = readOnly;
            this.frmCommissionPayment.txtDetYear.ReadOnly = readOnly;
        }

        public override void LoadDetail()
        {
            this.frmCommissionPayment.txtDetComments.Value = this.commissionPayment.Comments;
            this.frmCommissionPayment.sccDetStaff.Value = this.commissionPayment.Staff;
            this.frmCommissionPayment.txtDetAmount.Value = this.commissionPayment.Amount;
            this.frmCommissionPayment.uceDetMonth.Value = this.commissionPayment.Month;
            this.frmCommissionPayment.txtDetYear.Value = this.commissionPayment.Year;
        }

        public override void SaveEntity()
        {
            this.commissionPayment.Comments = this.frmCommissionPayment.txtDetComments.Value as string;
            this.commissionPayment.Staff = this.frmCommissionPayment.sccDetStaff.Value;
            this.commissionPayment.Amount = Convert.ToDecimal(this.frmCommissionPayment.txtDetAmount.Value);
            this.commissionPayment.Month = Convert.ToInt32(this.frmCommissionPayment.uceDetMonth.Value);
            this.commissionPayment.Year = Convert.ToInt32(this.frmCommissionPayment.txtDetYear.Value);

            this.srvCommissionPayment.SaveOrUpdate(this.commissionPayment);
        }

        public override void ClearDetailFields()
        {
            this.frmCommissionPayment.txtDetComments.Value = null;
            this.frmCommissionPayment.sccDetStaff.Value = null;
            this.frmCommissionPayment.txtDetAmount.Value = null;
            this.frmCommissionPayment.uceDetMonth.Value = -1;
            this.frmCommissionPayment.txtDetYear.Value = null;
        }

        #endregion Public

        #endregion Methods

        #region Events

        private void grdPrincipal_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            WindowsFormsUtil.SetUltraGridValueList(layout, TimeUtil.Months, 
                band.Columns["Month"], "Index", "Name", null);
        }

        #endregion Events
    }
}
