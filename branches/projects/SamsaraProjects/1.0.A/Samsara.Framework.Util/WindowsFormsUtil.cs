
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinMaskedEdit;
using Samsara.Framework.Core.Entities;
using Samsara.Framework.Core.Enums;

namespace Samsara.Framework.Util
{
    public class WindowsFormsUtil
    {
        //private static IList<TextFormat> textFormats;

        //private static IList<TextFormat> TextFormats
        //{
        //    [DebuggerStepThrough]
        //    get
        //    {
        //        return session = session ?? new Session();
        //    }
        //}

        //private static string currencyMask = "-nnn,nnn,nnn,nnn.nn";
        //private static string naturalQuantityMask = "nnn,nnn,nnn,nnn";
        //private static string realQuantityMask = "nnn,nnn,nnn,nnn.nnnn";
        //private static string percentageMask = "nnn.nn %";
        //private static string integerMask = "nnnnnnnnnnnn";
        //private static string noLimitPercentageMask = "nnn,nnn,nnn,nnn.nn %";
        //private static string fileSizeMask = "nnn,nnn,nnn,nnn.nn MB";
        //private static string rateMask = "{double:4.12}";

        public static void AddUltraGridSummary(UltraGridBand band, UltraGridColumn column)
        {
            try
            {
                band.Summaries.Add(column.Key + band.Key, SummaryType.Sum, column, SummaryPosition.UseSummaryPositionColumn);
                band.Summaries[column.Key + band.Key].DisplayFormat = "{0:###,###,##0.00}";
                band.Summaries[column.Key + band.Key].Appearance.TextHAlign = HAlign.Right;
            }
            catch { }
        }

        public static void LoadCombo<T>(UltraComboEditor combo, IEnumerable<T> collection,
            string valueMember, string displayMember, string defaultValue, bool multiple)
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
            {
                if (multiple)
                {
                    combo.Value = new object[] { -1 };
                }
                else
                {
                    combo.Value = -1;
                }
            }
        }

        public static void LoadCombo(UltraComboEditor combo, DataTable dataTable,
            string valueMember, string displayMember)
        {
            DataRow row = dataTable.NewRow();

            row[valueMember] = -1;
            row[displayMember] = "Seleccione";

            dataTable.Rows.InsertAt(row, 0);

            combo.DataSource = null;
            combo.DataSource = dataTable;
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;
            combo.Value = -1;
        }

        public static void SetUltraColumnFormat(UltraGridColumn column, TextFormat textFormat)
        {
            column.MaskInput = textFormat.Mask;
            column.MaskDisplayMode = textFormat.MaskMode;
            column.CellAppearance.TextHAlign = textFormat.HAlign;
            column.PromptChar = textFormat.PromptChar;
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
            column.ValueList = layout.ValueLists[typeof(T).Name + valueMember + displayMember];
        }

        public static void SetUltraGridValueList(UltraGridLayout layout, DataTable dataTable,
            UltraGridColumn column, string valueMember, string displayMember, string defaultValue)
        {
            ValueList vl;

            if (dataTable.TableName == null)
                dataTable.TableName = string.Empty;

            if (!layout.ValueLists.Exists(dataTable.TableName + valueMember + displayMember))
                vl = layout.ValueLists.Add(dataTable.TableName + valueMember + displayMember);

            vl = layout.ValueLists[dataTable.TableName + valueMember + displayMember];
            vl.ValueListItems.Clear();

            if (defaultValue != null)
                vl.ValueListItems.Add(-1, defaultValue);

            foreach (DataRow row in dataTable.Rows)
            {
                vl.ValueListItems.Add(row[valueMember], row[displayMember].ToString());
            }

            vl.SelectedItem = -1;
            column.ValueList = layout.ValueLists[dataTable.TableName + valueMember + displayMember];
        }

        delegate void CloseMethod(Form form);
        static public void CloseForm(Form form)
        {
            if (!form.IsDisposed)
            {
                if (form.InvokeRequired)
                {
                    CloseMethod method = new CloseMethod(CloseForm);
                    form.Invoke(method, new object[] { form });
                }
                else
                {
                    form.Close();
                }
            }
        }
    }
}
