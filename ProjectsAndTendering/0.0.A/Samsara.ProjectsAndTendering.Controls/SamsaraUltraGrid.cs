
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
                    formConfiguration = srvFormConfiguration.SearchFormConfigurationByName(parentFormName);
                else 
                    return;

                if (formConfiguration == null)
                {
                    formConfiguration = new FormConfiguration();
                    formConfiguration.FormName = parentFormName;
                    srvFormConfiguration.SaveOrUpdateFormConfiguration(formConfiguration);
                    formConfiguration = srvFormConfiguration.LoadFormConfiguration(
                        formConfiguration.FormConfigurationId);
                }

                GridConfiguration gridConfiguration = formConfiguration.GridConfigurations
                    .SingleOrDefault(x => x.GridName == this.Name);

                if (gridConfiguration == null)
                {
                    gridConfiguration = new GridConfiguration();
                    gridConfiguration.GridName = this.Name;
                    gridConfiguration.FormConfiguration = formConfiguration;
                    srvGridConfiguration.SaveOrUpdateGridConfiguration(gridConfiguration);
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

                            srvGridColumnConfiguration.SaveOrUpdateGridColumnConfiguration(gridColumnConfiguration);
                        }
                        else
                        {
                            column.Hidden = !gridColumnConfiguration.Visible;
                            column.Header.Caption = gridColumnConfiguration.ColumnEndUserName;
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
