
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.Configuration.Code.Interfaces;
using Samsara.Configuration.Core.Entities;
using Samsara.Configuration.Core.Parameters;
using Samsara.Configuration.Service.Interfaces;
using Samsara.Framework.Util;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Base.Controls.Controls
{
    public partial class SamsaraUltraGrid : UltraGrid
    {
        private ISchemeService srvScheme;
        private IFormConfigurationService srvFormConfiguration;
        private IFormConfigurationGridService srvFormConfigurationGrid;
        private IFormConfigurationGridColumnService srvFormConfigurationGridColumn;

        public SamsaraUltraGrid()
        {
            InitializeComponent();
            
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvScheme = SamsaraAppContext.Resolve<ISchemeService>();
                this.srvFormConfiguration = SamsaraAppContext.Resolve<IFormConfigurationService>();
                this.srvFormConfigurationGrid = SamsaraAppContext.Resolve<IFormConfigurationGridService>();
                this.srvFormConfigurationGridColumn = SamsaraAppContext.Resolve<IFormConfigurationGridColumnService>();
            }
        }

        protected override void OnBeginInit()
        {
            base.OnBeginInit();

            this.DisplayLayout.Grid.DisplayLayout.GroupByBox.Prompt
                = "Arrastre un encabezado de la columna aquí para agrupar por esa columna";
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
                string schemeName = null;

                if (parentFormName != null && parentFormName.Contains("Form"))
                {
                    Form form = this.GetForm(this.Parent);
                    schemeName = form.GetType().Namespace.Split('.')[1];

                    if (typeof(IConfigurableForm).IsAssignableFrom(form.GetType()))
                    {
                        IConfigurableForm configurableForm = form as IConfigurableForm;

                        formConfiguration = configurableForm.FormConfiguration;
                    }
                    else
                    {
                        FormConfigurationParameters pmtFormConfiguration = new FormConfigurationParameters();
                        pmtFormConfiguration.FormName = parentFormName;
                        formConfiguration = srvFormConfiguration.GetByParameters(pmtFormConfiguration);
                    }
                }
                else
                    return;

                if (formConfiguration == null)
                {
                    SchemeParameters pmtScheme = new SchemeParameters();
                    pmtScheme.Name = schemeName;

                    Scheme scheme = this.srvScheme.GetByParameters(pmtScheme);

                    formConfiguration = new FormConfiguration();
                    formConfiguration.FormName = parentFormName;
                    formConfiguration.Scheme = scheme;
                    srvFormConfiguration.SaveOrUpdate(formConfiguration);
                }

                string gridName = (lstCustomControlNames.Count == 0 ? "" :
                    string.Join(".", lstCustomControlNames.Reverse().ToArray()) + ".") + this.Name;

                FormConfigurationGrid formGrid = formConfiguration.FormConfigurationGrids
                    .SingleOrDefault(x => x.GridName == gridName);

                if (formGrid == null)
                {
                    FormConfigurationGridParameters pmtFormConfigurationGrid = new FormConfigurationGridParameters();
                    pmtFormConfigurationGrid.GridName = gridName;
                    pmtFormConfigurationGrid.FormConfigurationId = formConfiguration.FormConfigurationId;
                    formGrid = srvFormConfigurationGrid.GetByParameters(pmtFormConfigurationGrid);
                }

                if (formGrid == null)
                {
                    formGrid = new FormConfigurationGrid();
                    formGrid.GridName = gridName;
                    formGrid.IgnoreConfiguration = false;
                    formGrid.FormConfiguration = formConfiguration;
                    srvFormConfigurationGrid.SaveOrUpdate(formGrid);
                }

                if (formGrid.IgnoreConfiguration)
                    return;

                foreach (UltraGridBand band in this.DisplayLayout.Bands)
                {
                    foreach (UltraGridColumn column in band.Columns)
                    {
                        FormConfigurationGridColumn formGridColumn = null;

                        if (formGrid.FormConfigurationGridColumns != null)
                            formGridColumn = formGrid
                                .FormConfigurationGridColumns.SingleOrDefault(x => x.ColumnName == column.Key
                                && (x.BandKey == null || x.BandKey == band.Key));

                        if (formGridColumn == null)
                        {
                            formGridColumn = new FormConfigurationGridColumn();
                            formGrid.FormConfigurationGridColumns.Add(formGridColumn);
                            formGridColumn.ColumnName = column.Key;
                            formGridColumn.ColumnEndUserName = column.Key;
                            formGridColumn.FormConfigurationGrid = formGrid;
                            formGridColumn.Visible = false;
                            formGridColumn.BandKey = band.Key;
                            srvFormConfigurationGridColumn.SaveOrUpdate(formGridColumn);
                        }
                    }
                }

                IList<string> lstOrderedColumnNames = formGrid.FormConfigurationGridColumns
                    .OrderBy(x => x.FormConfigurationGridColumnId).Select(x => x.ColumnName).ToList();

                foreach (UltraGridBand band in this.DisplayLayout.Bands)
                {
                    int index = 0;
                    foreach (UltraGridColumn column in band.Columns.Cast<UltraGridColumn>()
                        .OrderBy(x => lstOrderedColumnNames.IndexOf(x.Key)))
                    {
                        FormConfigurationGridColumn gridColumnConfiguration = formGrid
                                .FormConfigurationGridColumns.Single(x => x.ColumnName == column.Key
                                && (x.BandKey == null || x.BandKey == band.Key));

                        column.Hidden = !gridColumnConfiguration.Visible && !formGrid.IgnoreConfiguration;
                        column.Header.Caption = gridColumnConfiguration.ColumnEndUserName;
                        column.Header.VisiblePosition = index++;

                        if (gridColumnConfiguration.TextFormat != null)
                        {
                            WindowsFormsUtil.SetUltraColumnFormat(column, gridColumnConfiguration.TextFormat);
                        }
                    }

                    //band.SummaryFooterCaption = "Sumatorias";      
                }
            }
        }

        [DebuggerStepThrough]
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.Up:
                    this.PerformAction(UltraGridAction.ExitEditMode, false, false);
                    this.PerformAction(UltraGridAction.AboveCell, false, false);
                    e.Handled = true;
                    this.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    break;
                case Keys.Down:
                    this.PerformAction(UltraGridAction.ExitEditMode, false, false);
                    this.PerformAction(UltraGridAction.BelowCell, false, false);
                    e.Handled = true;
                    this.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    break;
                case Keys.Right:
                    this.PerformAction(UltraGridAction.ExitEditMode, false, false);
                    this.PerformAction(UltraGridAction.NextCellByTab, false, false);
                    e.Handled = true;
                    this.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    break;
                case Keys.Left:
                    this.PerformAction(UltraGridAction.ExitEditMode, false, false);
                    this.PerformAction(UltraGridAction.PrevCellByTab, false, false);
                    e.Handled = true;
                    this.PerformAction(UltraGridAction.EnterEditMode, false, false);
                    break;
            }
        }

        private Form GetForm(Control control)
        {
            if (control == null)
                return null;

            bool isForm = control is Form;
            bool isSamsaraUserControl = control.GetType().IsSubclassOf(typeof(SamsaraUserControl));

            if (isForm)
                return control as Form;

            if (isSamsaraUserControl)
                return this.GetForm((control as SamsaraUserControl).CustomParent);
            else
                return this.GetForm(control.Parent);
        }

        private void GetCustomControlsNames(Control control, IList<string> controlsNames)
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
