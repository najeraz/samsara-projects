
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Common;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Infragistics.Win.UltraWinGrid;
using System;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class DependencyForm : DependencySearchForm
    {
        #region Attributes

        private DependencyFormController ctrlDependencyForm;
        private IDependencyService srvDependency;

        #endregion Attributes

        public DependencyForm()
        {
            InitializeComponent();
            this.ctrlDependencyForm = new DependencyFormController(this);
            this.srvDependency = SamsaraAppContext.Resolve<IDependencyService>();
            Assert.IsNotNull(srvDependency);
        }

        #region Methods

        internal override Dependency GetSerchResult()
        {
            Dependency dependency = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int dependencyId = Convert.ToInt32(activeRow.Cells[0].Value);
                dependency = this.srvDependency.LoadDependency(dependencyId);
            }

            return dependency;
        }

        #endregion Methods
    }
}
