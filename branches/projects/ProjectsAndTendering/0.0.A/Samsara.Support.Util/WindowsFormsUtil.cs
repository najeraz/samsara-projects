
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinMaskedEdit;

namespace Samsara.Support.Util
{
    public class WindowsFormsUtil
    {
        public enum GridCellFormat
        {
            Currency,
            Rate,
            Percentage,
            NoLimitPercentage,
            NaturalQuantity,
            RealQuantity,
            FileSize
        }
        
        private static string currencyMask = "-nnn,nnn,nnn,nnn.nn";
        private static string naturalQuantityMask = "nnn,nnn,nnn,nnn";
        private static string realQuantityMask = "nnn,nnn,nnn,nnn.nnnn";
        private static string percentageMask = "nnn.nn%";
        private static string noLimitPercentageMask = "nnn,nnn,nnn,nnn.nn%";
        private static string fileSizeMask = "nnn,nnn,nnn,nnn.nn MB";
        private static string rateMask = "{double:4.12}";

        public static void AddUltraGridSummary(UltraGridBand band, UltraGridColumn column)
        {
            band.Summaries.Add(column.Key, SummaryType.Sum, column, SummaryPosition.UseSummaryPositionColumn);
            band.Summaries[column.Key].DisplayFormat = "{0:###,###,##0.00}";
            band.Summaries[column.Key].Appearance.TextHAlign = HAlign.Right;
        }

        public static void LoadCombo<T>(UltraComboEditor combo, IEnumerable<T> collection,
            string valueMember, string displayMember, string defaultValue)
        {
            T blankEntity = (T)Activator.CreateInstance(typeof(T));
            IList<T> list = collection.ToList();

            if (defaultValue != null)
            {
                blankEntity.GetType().GetProperty(valueMember).SetValue(blankEntity, -1, null);
                blankEntity.GetType().GetProperty(displayMember).SetValue(blankEntity, defaultValue, null);
                list.Insert(0, blankEntity);
            }

            combo.DataSource = null;
            combo.DataSource = list;
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;

            if (defaultValue != null)
                combo.Value = -1;
        }

        public static void LoadCombo(UltraComboEditor combo, DataTable data,
            string valueMember, string displayMember)
        {
            DataRow row = data.NewRow();

            row[valueMember] = -1;
            row[displayMember] = "Seleccione";

            data.Rows.InsertAt(row, 0);

            combo.DataSource = null;
            combo.DataSource = data;
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;
            combo.Value = -1;
        }

        public static void SetUltraColumnFormat(UltraGridColumn column, GridCellFormat gridCellFormat)
        {
            switch (gridCellFormat)
            {
                case GridCellFormat.Currency:
                    column.MaskInput = currencyMask;
                    column.MaskDisplayMode = MaskMode.IncludeBoth; 
                    column.CellAppearance.TextHAlign = HAlign.Right;
                    column.PromptChar = ' ';
                    break;
                case GridCellFormat.NaturalQuantity:
                    column.MaskInput = naturalQuantityMask;
                    column.MaskDisplayMode = MaskMode.IncludeBoth; 
                    column.CellAppearance.TextHAlign = HAlign.Right;
                    column.PromptChar = ' ';
                    break;
                case GridCellFormat.RealQuantity:
                    column.MaskInput = realQuantityMask;
                    column.MaskDisplayMode = MaskMode.IncludeBoth; 
                    column.CellAppearance.TextHAlign = HAlign.Right;
                    column.PromptChar = ' ';
                    break;
                case GridCellFormat.Rate:
                    column.MaskInput = rateMask;
                    column.MaskDisplayMode = MaskMode.IncludeBoth; 
                    column.CellAppearance.TextHAlign = HAlign.Right;
                    column.PromptChar = ' ';
                    break;
                case GridCellFormat.Percentage:
                    column.MaskInput = percentageMask;
                    column.MaskDisplayMode = MaskMode.IncludeBoth; 
                    column.CellAppearance.TextHAlign = HAlign.Right;
                    column.PromptChar = ' ';
                    break;
                case GridCellFormat.NoLimitPercentage:
                    column.MaskInput = noLimitPercentageMask;
                    column.MaskDisplayMode = MaskMode.IncludeBoth; 
                    column.CellAppearance.TextHAlign = HAlign.Right;
                    column.PromptChar = ' ';
                    break;
                case GridCellFormat.FileSize:
                    column.MaskInput = fileSizeMask;
                    column.MaskDisplayMode = MaskMode.IncludeBoth; 
                    column.CellAppearance.TextHAlign = HAlign.Right;
                    column.PromptChar = ' ';
                    break;
                default:
                    break;
            }
        }

        public static void SetUltraGridValueList<T>(UltraGridLayout layout, IEnumerable<T> collection,
            UltraGridColumn column, string valueMember, string displayMember, string defaultValue)
        {
            ValueList vl;

            if (!layout.ValueLists.Exists(typeof(T).Name + valueMember + displayMember))
                vl = layout.ValueLists.Add(typeof(T).Name + valueMember + displayMember);

            vl = layout.ValueLists[typeof(T).Name + valueMember + displayMember];
            vl.ValueListItems.Clear();
            if (defaultValue != null)
                vl.ValueListItems.Add(-1, defaultValue);

            foreach (T entity in collection)
            {
                vl.ValueListItems.Add(entity.GetType().GetProperty(valueMember).GetValue(entity, null),
                    entity.GetType().GetProperty(displayMember).GetValue(entity, null).ToString());
            }

            vl.SelectedItem = -1;
            //column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column.ValueList = layout.ValueLists[typeof(T).Name + valueMember + displayMember];
        }
    }
}
