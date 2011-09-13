
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces;

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
            Assert.IsNotNull(this.srvDependency);
        }

        #region Methods

        public override Dependency GetSerchResult()
        {
            Dependency dependency = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int dependencyId = Convert.ToInt32(activeRow.Cells[0].Value);
                dependency = this.srvDependency.GetById(dependencyId);
            }

            return dependency;
        }

        #endregion Methods
    }
}
