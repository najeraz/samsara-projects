
using Samsara.Base.Forms.Controllers;
using Samsara.Commissions.Forms.Forms;

namespace Samsara.Commissions.Forms.Controllers
{
    public class ServicesManagementFormController : GenericDocumentFormController
    {
        #region Attributes

        private ServicesManagementForm frmServicesManagement;

        #endregion Attributes

        #region Constructor

        public ServicesManagementFormController(ServicesManagementForm frmServicesManagement)
            : base(frmServicesManagement)
        {
            this.frmServicesManagement = frmServicesManagement;
        }

        #endregion Constructor

        #region Methods

        #region Protected

        protected override void InitializeFormControls()
        {
        }

        #endregion Protected

        #region Public

        public override void Search()
        {

        }

        public override void ClearSearchFields()
        {
        }

        public override void ReturnSelectedEntity()
        {
        }

        public override void CloseForm()
        {
        }

        public override void DeleteSelectedEntity()
        {
        }

        public override void EditSelectedEntity()
        {
        }

        public override void CreateEntity()
        {
        }

        public override void BackToSearch()
        {
        }

        public override void SaveEntity()
        {
        }

        #endregion Public

        #endregion Methods

        #region Events

        #endregion Events
    }
}
