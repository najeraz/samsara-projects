
using System;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class AsesorForm : AsesorSearchForm
    {
        #region Attributes

        private AsesorFormController ctrlAsesorForm;
        private IAsesorService srvAsesor;

        #endregion Attributes

        public AsesorForm()
        {
            InitializeComponent();
            this.ctrlAsesorForm = new AsesorFormController(this);
            this.srvAsesor = SamsaraAppContext.Resolve<IAsesorService>();
        }

        #region Methods

        public override Asesor GetSearchResult()
        {
            Asesor asesor = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int asesorId = Convert.ToInt32(activeRow.Cells[0].Value);
                asesor = this.srvAsesor.GetById(asesorId);
            }

            return asesor;
        }

        #endregion Methods
    }
}
