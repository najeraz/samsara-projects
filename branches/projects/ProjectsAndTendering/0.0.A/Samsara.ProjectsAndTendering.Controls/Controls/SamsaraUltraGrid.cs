
using System.Data;
using System.Linq;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;


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
            IFormConfigurationService srvFormConfiguration = SamsaraAppContext.Resolve<IFormConfigurationService>();
            Assert.IsNotNull(srvFormConfiguration);
            IGridConfigurationService srvGridConfiguration = SamsaraAppContext.Resolve<IGridConfigurationService>();
            Assert.IsNotNull(srvGridConfiguration);
            IGridColumnConfigurationService srvGridColumnConfiguration = SamsaraAppContext.Resolve<IGridColumnConfigurationService>();
            Assert.IsNotNull(srvGridColumnConfiguration);

            if (this.DataSource != null && this.DataSource is DataTable)
            {
                string parentFormName = this.GetParentFormName(this.Parent);

                if (parentFormName != null)
                {
                    FormConfigurationParameters pmtFormConfiguration = new FormConfigurationParameters();
                    pmtFormConfiguration.Name = parentFormName;
                    formConfiguration = srvFormConfiguration.GetByParameters(pmtFormConfiguration);
                }
                else
                    return;

                if (formConfiguration == null)
                {
                    formConfiguration = new FormConfiguration();
                    formConfiguration.FormName = parentFormName;
                    srvFormConfiguration.SaveOrUpdate(formConfiguration);
                    formConfiguration = srvFormConfiguration.GetById(
                        formConfiguration.FormConfigurationId);
                }

                GridConfiguration gridConfiguration = formConfiguration.GridConfigurations
                    .SingleOrDefault(x => x.GridName == this.Name);

                if (gridConfiguration == null)
                {
                    gridConfiguration = new GridConfiguration();
                    gridConfiguration.GridName = this.Name;
                    gridConfiguration.FormConfiguration = formConfiguration;
                    srvGridConfiguration.SaveOrUpdate(gridConfiguration);
                }

                foreach (UltraGridBand band in this.DisplayLayout.Bands)
                {
                    foreach (UltraGridColumn column in band.Columns)
                    {
                        GridColumnConfiguration gridColumnConfiguration = null;

                        if (gridConfiguration.GridColumnConfigurations != null)
                            gridColumnConfiguration = gridConfiguration
                                .GridColumnConfigurations.SingleOrDefault(x => x.ColumnName == column.Key
                                && x.Band == band.Index);

                        if (gridColumnConfiguration == null)
                        {
                            gridColumnConfiguration = new GridColumnConfiguration();
                            gridColumnConfiguration.ColumnName = column.Key;
                            gridColumnConfiguration.ColumnEndUserName = column.Key;
                            gridColumnConfiguration.GridConfiguration = gridConfiguration;
                            gridColumnConfiguration.Visible = true;
                            gridColumnConfiguration.Band = band.Index;

                            srvGridColumnConfiguration.SaveOrUpdate(gridColumnConfiguration);
                        }
                        else
                        {
                            column.Hidden = !gridColumnConfiguration.Visible;
                            column.Header.Caption = gridColumnConfiguration.ColumnEndUserName;
                            column.Header.VisiblePosition = gridConfiguration.GridColumnConfigurations
                                .Where(x => x.Visible).ToList().IndexOf(gridColumnConfiguration) + 1;
                        }
                    }
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
