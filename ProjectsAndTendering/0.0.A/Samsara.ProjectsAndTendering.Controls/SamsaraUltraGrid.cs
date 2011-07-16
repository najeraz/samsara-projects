
using System.Data;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Iesi.Collections;
using System.Linq;


namespace Samsara.ProjectsAndTendering.Controls
{
    public partial class SamsaraUltraGrid : UltraGrid
    {
        public SamsaraUltraGrid()
        {
            InitializeComponent();
        }

        protected override void OnInitializeLayout(InitializeLayoutEventArgs e)
        {
            base.OnInitializeLayout(e);

            FormConfiguration formConfiguration = null;
            IFormConfigurationService srvFormConfiguration = ApplicationContext.Resolve<IFormConfigurationService>();
            Assert.IsNotNull(srvFormConfiguration);

            if (this.DataSource != null && this.DataSource is DataTable)
            {
                string parentFormName = this.GetParentFormName(this.Parent);

                if (parentFormName != null)
                    formConfiguration = srvFormConfiguration.SearchFormConfigurationByName(parentFormName);
                else 
                    return;

                if (formConfiguration == null)
                {
                    formConfiguration = new FormConfiguration();
                    formConfiguration.FormName = parentFormName;
                    srvFormConfiguration.SaveOrUpdateFormConfiguration(formConfiguration);
                }
            }
        }

        private string GetParentFormName(System.Windows.Forms.Control control)
        {
            if (control == null)
                return null;
            if (control is System.Windows.Forms.Form)
                return control.Name;

            return GetParentFormName(control.Parent);
        }
    }
}
