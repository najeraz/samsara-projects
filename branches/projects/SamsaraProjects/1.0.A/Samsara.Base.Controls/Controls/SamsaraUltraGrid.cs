
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Service.Interfaces;

namespace Samsara.Base.Controls.Controls
{
    public partial class SamsaraUltraGrid : UltraGrid
    {
        private IFormConfigurationService srvFormConfiguration;
        private IGridConfigurationService srvGridConfiguration;
        private IGridColumnConfigurationService srvGridColumnConfiguration;

        public SamsaraUltraGrid()
        {
            InitializeComponent();
            
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                srvFormConfiguration = SamsaraAppContext.Resolve<IFormConfigurationService>();
                Assert.IsNotNull(this.srvFormConfiguration);
                srvGridConfiguration = SamsaraAppContext.Resolve<IGridConfigurationService>();
                Assert.IsNotNull(this.srvGridConfiguration);
                srvGridColumnConfiguration = SamsaraAppContext.Resolve<IGridColumnConfigurationService>();
                Assert.IsNotNull(this.srvGridColumnConfiguration);
            }
        }

        protected override void OnInitializeLayout(InitializeLayoutEventArgs e)
        {
            base.OnInitializeLayout(e);
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;   

            FormConfiguration formConfiguration = null;

            if (this.DataSource != null)
            {
                IList<string> lstCustomControlNames = new List<string>();
                this.GetCustomControlsNames(this.Parent, lstCustomControlNames);
                string parentFormName = lstCustomControlNames.Last();
                lstCustomControlNames.Remove(parentFormName);

                if (parentFormName != null && parentFormName.Contains("Form"))
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

                string gridName = (lstCustomControlNames.Count == 0 ? "" :
                    string.Join(".", lstCustomControlNames.Reverse().ToArray()) + ".") + this.Name;

                GridConfigurationParameters pmtGridConfiguration = new GridConfigurationParameters();
                pmtGridConfiguration.GridName = gridName;
                pmtGridConfiguration.FormConfigurationId = formConfiguration.FormConfigurationId;
                GridConfiguration gridConfiguration = srvGridConfiguration.GetByParameters(pmtGridConfiguration);
                
                if (gridConfiguration == null)
                {
                    gridConfiguration = new GridConfiguration();
                    gridConfiguration.GridName = gridName;
                    gridConfiguration.IgnoreConfiguration = false;
                    gridConfiguration.FormConfiguration = formConfiguration;
                    srvGridConfiguration.SaveOrUpdate(gridConfiguration);
                }

                if (gridConfiguration.IgnoreConfiguration)
                    return;

                foreach (UltraGridBand band in this.DisplayLayout.Bands)
                {
                    foreach (UltraGridColumn column in band.Columns)
                    {
                        GridColumnConfiguration gridColumnConfiguration = null;

                        if (gridConfiguration.GridColumnConfigurations != null)
                            gridColumnConfiguration = gridConfiguration
                                .GridColumnConfigurations.SingleOrDefault(x => x.ColumnName == column.Key
                                && (x.BandKey == null || x.BandKey == band.Key));

                        if (gridColumnConfiguration == null)
                        {
                            gridColumnConfiguration = new GridColumnConfiguration();
                            gridConfiguration.GridColumnConfigurations.Add(gridColumnConfiguration);
                            gridColumnConfiguration.ColumnName = column.Key;
                            gridColumnConfiguration.ColumnEndUserName = column.Key;
                            gridColumnConfiguration.GridConfiguration = gridConfiguration;
                            gridColumnConfiguration.Visible = false;
                            gridColumnConfiguration.BandKey = band.Key;
                            srvGridColumnConfiguration.SaveOrUpdate(gridColumnConfiguration);
                        }
                    }
                }

                IList<string> lstOrderedColumnNames = gridConfiguration.GridColumnConfigurations
                    .OrderBy(x => x.GridColumnConfigurationId).Select(x => x.ColumnName).ToList();

                foreach (UltraGridBand band in this.DisplayLayout.Bands)
                {
                    int index = 0;
                    foreach (UltraGridColumn column in band.Columns.Cast<UltraGridColumn>()
                        .OrderBy(x => lstOrderedColumnNames.IndexOf(x.Key)))
                    {
                        GridColumnConfiguration gridColumnConfiguration = gridConfiguration
                                .GridColumnConfigurations.Single(x => x.ColumnName == column.Key
                                && (x.BandKey == null || x.BandKey == band.Key));

                        column.Hidden = !gridColumnConfiguration.Visible && !gridConfiguration.IgnoreConfiguration;
                        column.Header.Caption = gridColumnConfiguration.ColumnEndUserName;
                        column.Header.VisiblePosition = index++;
                    }

                    //band.SummaryFooterCaption = "Sumatorias";      
                }
            }
        }

        public void GetCustomControlsNames(Control control, IList<string> controlsNames)
        {
            if (control == null)
                return;

            bool isForm = control is Form;
            bool isSamsaraUserControl = control.GetType().IsSubclassOf(typeof(SamsaraUserControl));

            if (isForm || isSamsaraUserControl)
                controlsNames.Add(control.Name);

            if (isSamsaraUserControl)
                this.GetCustomControlsNames((control as SamsaraUserControl).CustomParent, controlsNames);
            else
                this.GetCustomControlsNames(control.Parent, controlsNames);
        }

    }
}
