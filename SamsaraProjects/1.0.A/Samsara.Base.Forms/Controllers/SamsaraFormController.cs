
using Samsara.Base.Core.Context;
using Samsara.Base.Forms.Forms;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Service.Interfaces;

namespace Samsara.Base.Forms.Controllers
{
    public class SamsaraFormController
    {
        #region Attributes

        private SamsaraForm frmSamsara;
        private IFormConfigurationService srvFormConfiguration;

        #endregion Attributes

        #region Properties

        internal protected FormConfiguration FormConfiguration
        {
            get;
            private set;
        }

        #endregion Properties

        #region Constructor

        public SamsaraFormController(SamsaraForm frmSamsara)
        {
            this.frmSamsara = frmSamsara;

            FormConfigurationParameters pmtFormConfiguration = new FormConfigurationParameters();
            this.srvFormConfiguration = SamsaraAppContext.Resolve<IFormConfigurationService>();

            pmtFormConfiguration.FormName = this.frmSamsara.Name;
            this.FormConfiguration = this.srvFormConfiguration.GetByParameters(pmtFormConfiguration);
        }

        #endregion Constructor

        #region Methods
        #endregion Methods
    }
}
