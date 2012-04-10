
using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;

namespace Samsara.Framework.Util
{
    public class ExcelUtil
    {
        public static void ExportToExcel(UltraGrid grid)
        {
            SaveFileDialog dlgSurveyExcel = new SaveFileDialog();

            dlgSurveyExcel.Filter = "Excel WorkBook (*.xls)|.xls";
            dlgSurveyExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            DialogResult dlgResSaveFile = dlgSurveyExcel.ShowDialog();

            if (dlgResSaveFile == DialogResult.OK)
            {
                UltraGridExcelExporter ultraGridExcelExporter = new UltraGridExcelExporter();
                ultraGridExcelExporter.FileLimitBehaviour = FileLimitBehaviour.TruncateData;
                ultraGridExcelExporter.Export(grid, dlgSurveyExcel.FileName); 
            }
        }
    }
}
