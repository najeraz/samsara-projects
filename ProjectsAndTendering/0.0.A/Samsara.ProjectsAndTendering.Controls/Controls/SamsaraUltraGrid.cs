
using System;
using System.Data;
using System.Linq;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Common;
using Samsara.ProjectsAndTendering.Core.Entities.Configuration;
using Samsara.ProjectsAndTendering.Core.Parameters.Configuration;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;


namespace Samsara.ProjectsAndTendering.Controls
{
    public partial class SamsaraUltraGrid : UltraGrid
    {
        private IFormConfigurationService srvFormConfiguration;
        private IGridConfigurationService srvGridConfiguration;
        private IGridColumnConfigurationService srvGridColumnConfiguration;

        public SamsaraUltraGrid()
        {
            InitializeComponent();
            try
            {
                srvFormConfiguration = SamsaraAppContext.Resolve<IFormConfigurationService>();
                srvGridConfiguration = SamsaraAppContext.Resolve<IGridConfigurationService>();
                srvGridColumnConfiguration = SamsaraAppContext.Resolve<IGridColumnConfigurationService>();
            }
            catch (Exception ex) { ex.ToString(); }
        }

        protected override void OnInitializeLayout(InitializeLayoutEventArgs e)
        {
            base.OnInitializeLayout(e);

            Assert.IsNotNull(this.srvFormConfiguration);
            Assert.IsNotNull(this.srvGridConfiguration);
            Assert.IsNotNull(this.srvGridColumnConfiguration);

            FormConfiguration formConfiguration = null;

            if (this.DataSource != null && this.DataSource is DataTable)
            {
                string parentFormName = this.GetParentFormName(this.Parent);

                if (parentFormName != null)
                {
                    FormConfigurationParameters pmtFormConfiguration = new FormConfigurationParameters();
                    pmtFormConfiguration.FormName = parentFormName;
                    formConfiguration = srvFormConfiguration.GetByParameters(pmtFormConfiguration);
                }
                else
                    return;

                if (formConfiguration == null)
                {
                    formConfiguration = new FormConfiguration();
                    formConfiguration.FormName = parentFormName;
                    srvFormConfiguration.SaveOrUpdate(formConfiguration);
                }

                GridConfigurationParameters pmtGridConfiguration = new GridConfigurationParameters();
                pmtGridConfiguration.GridName = this.Name;
                pmtGridConfiguration.FormConfigurationId = formConfiguration.FormConfigurationId;
                GridConfiguration gridConfiguration = srvGridConfiguration.GetByParameters(pmtGridConfiguration);

                if (gridConfiguration == null)
                {
                    gridConfiguration = new GridConfiguration();
                    gridConfiguration.GridName = this.Name;
                    gridConfiguration.IgnoreVisibleProperty = false;
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
                            gridColumnConfiguration.Visible = false;
                            gridColumnConfiguration.Band = band.Index;

                            if (!gridConfiguration.IgnoreVisibleProperty)
                                srvGridColumnConfiguration.SaveOrUpdate(gridColumnConfiguration);
                        }
                        else
                        {
                            column.Hidden = !gridColumnConfiguration.Visible && !gridConfiguration.IgnoreVisibleProperty;
                            column.Header.Caption = gridColumnConfiguration.ColumnEndUserName;
                            if (!gridConfiguration.IgnoreVisibleProperty)
                                column.Header.VisiblePosition = gridConfiguration.GridColumnConfigurations
                                    .Where(x => x.Visible).OrderBy(x => x.GridColumnConfigurationId).ToList()
                                    .IndexOf(gridColumnConfiguration) + 1;
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
