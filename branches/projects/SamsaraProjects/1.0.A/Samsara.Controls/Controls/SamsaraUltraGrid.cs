﻿
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Service.Interfaces;
using Samsara.Controls.Templates;

namespace Samsara.Controls
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

            if (this.DataSource != null && this.DataSource is DataTable)
            {
                string parentFormName = this.GetParentFormName();
                IList<string> lstParentNames = new List<string>();
                string customControlNames = null;

                this.GetParentControlName(this.Parent, lstParentNames);

                if (parentFormName == null)
                {
                    parentFormName = lstParentNames.Last();
                }

                lstParentNames.Remove(parentFormName);
                customControlNames = string.Join(".", lstParentNames.Reverse().ToArray());

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

                string gridName = (string.IsNullOrEmpty(customControlNames) ? "" : customControlNames + ".") + this.Name;

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
                                && x.Band == band.Index);

                        if (gridColumnConfiguration == null)
                        {
                            gridColumnConfiguration = new GridColumnConfiguration();
                            gridConfiguration.GridColumnConfigurations.Add(gridColumnConfiguration);
                            gridColumnConfiguration.ColumnName = column.Key;
                            gridColumnConfiguration.ColumnEndUserName = column.Key;
                            gridColumnConfiguration.GridConfiguration = gridConfiguration;
                            gridColumnConfiguration.Visible = false;
                            gridColumnConfiguration.Band = band.Index;
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
                                && x.Band == band.Index);

                        column.Hidden = !gridColumnConfiguration.Visible && !gridConfiguration.IgnoreConfiguration;
                        column.Header.Caption = gridColumnConfiguration.ColumnEndUserName;
                        column.Header.VisiblePosition = index++;
                    }

                    //band.SummaryFooterCaption = "Sumatorias";      
                }
            }
        }

        public string GetParentFormName()
        {
            Form form = this.FindForm();

            if (form == null)
                return null;
            else
                return form.Name;
        }

        public void GetParentControlName(Control control, IList<string> controlsNames)
        {
            if (control == null)
                return;

            controlsNames.Add(control.Name);

            if (control.GetType().BaseType == typeof(ManyToOneLevel1Control))
                GetParentControlName((control as ManyToOneLevel1Control).CustomParent, controlsNames);
            else
                GetParentControlName(control.Parent, controlsNames);
        }
    }
}
