
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private IFormService srvForm;
        private IFormGridService srvFormGrid;
        private IFormGridColumnService srvFormGridColumn;

        public SamsaraUltraGrid()
        {
            InitializeComponent();
            
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                srvForm = SamsaraAppContext.Resolve<IFormService>();
                Assert.IsNotNull(this.srvForm);
                srvFormGrid = SamsaraAppContext.Resolve<IFormGridService>();
                Assert.IsNotNull(this.srvFormGrid);
                srvFormGridColumn = SamsaraAppContext.Resolve<IFormGridColumnService>();
                Assert.IsNotNull(this.srvFormGridColumn);
            }
        }

        protected override void OnInitializeLayout(InitializeLayoutEventArgs e)
        {
            base.OnInitializeLayout(e);
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;   

            Samsara.Configuration.Core.Entities.Form form = null;

            if (this.DataSource != null)
            {
                IList<string> lstCustomControlNames = new List<string>();
                this.GetCustomControlsNames(this.Parent, lstCustomControlNames);
                string parentFormName = lstCustomControlNames.Last();
                lstCustomControlNames.Remove(parentFormName);

                if (parentFormName != null && parentFormName.Contains("Form"))
                {
                    FormParameters pmtForm = new FormParameters();
                    pmtForm.FormName = parentFormName;
                    form = srvForm.GetByParameters(pmtForm);
                }
                else
                    return;

                if (form == null)
                {
                    form = new Samsara.Configuration.Core.Entities.Form();
                    form.FormName = parentFormName;
                    srvForm.SaveOrUpdate(form);
                }

                string gridName = (lstCustomControlNames.Count == 0 ? "" :
                    string.Join(".", lstCustomControlNames.Reverse().ToArray()) + ".") + this.Name;

                FormGridParameters pmtFormGrid = new FormGridParameters();
                pmtFormGrid.GridName = gridName;
                pmtFormGrid.FormId = form.FormId;
                FormGrid formGrid = srvFormGrid.GetByParameters(pmtFormGrid);
                
                if (formGrid == null)
                {
                    formGrid = new FormGrid();
                    formGrid.GridName = gridName;
                    formGrid.IgnoreConfiguration = false;
                    formGrid.Form = form;
                    srvFormGrid.SaveOrUpdate(formGrid);
                }

                if (formGrid.IgnoreConfiguration)
                    return;

                foreach (UltraGridBand band in this.DisplayLayout.Bands)
                {
                    foreach (UltraGridColumn column in band.Columns)
                    {
                        FormGridColumn formGridColumn = null;

                        if (formGrid.FormGridColumns != null)
                            formGridColumn = formGrid
                                .FormGridColumns.SingleOrDefault(x => x.ColumnName == column.Key
                                && (x.BandKey == null || x.BandKey == band.Key));

                        if (formGridColumn == null)
                        {
                            formGridColumn = new FormGridColumn();
                            formGrid.FormGridColumns.Add(formGridColumn);
                            formGridColumn.ColumnName = column.Key;
                            formGridColumn.ColumnEndUserName = column.Key;
                            formGridColumn.FormGrid = formGrid;
                            formGridColumn.Visible = false;
                            formGridColumn.BandKey = band.Key;
                            srvFormGridColumn.SaveOrUpdate(formGridColumn);
                        }
                    }
                }

                IList<string> lstOrderedColumnNames = formGrid.FormGridColumns
                    .OrderBy(x => x.FormGridColumnId).Select(x => x.ColumnName).ToList();

                foreach (UltraGridBand band in this.DisplayLayout.Bands)
                {
                    int index = 0;
                    foreach (UltraGridColumn column in band.Columns.Cast<UltraGridColumn>()
                        .OrderBy(x => lstOrderedColumnNames.IndexOf(x.Key)))
                    {
                        FormGridColumn gridColumnConfiguration = formGrid
                                .FormGridColumns.Single(x => x.ColumnName == column.Key
                                && (x.BandKey == null || x.BandKey == band.Key));

                        column.Hidden = !gridColumnConfiguration.Visible && !formGrid.IgnoreConfiguration;
                        column.Header.Caption = gridColumnConfiguration.ColumnEndUserName;
                        column.Header.VisiblePosition = index++;
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

        private void GetCustomControlsNames(Control control, IList<string> controlsNames)
        {
            if (control == null)
                return;

            bool isForm = control is System.Windows.Forms.Form;
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
