using System;
using System.Collections.Generic;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using Infragistics.Win;

namespace Samsara.Support.Util
{
    public class WindowsFormsUtil
    {
        public static void LoadCombo<T>(UltraComboEditor combo, IList<T> collection, 
            string valueMember, string displayMember)
        {
            T blankEntity = (T)Activator.CreateInstance(typeof(T));

            blankEntity.GetType().GetProperty(valueMember).SetValue(blankEntity, -1, null);
            blankEntity.GetType().GetProperty(displayMember).SetValue(blankEntity, "Seleccione", null);
            collection.Insert(0, blankEntity);

            combo.DataSource = null;
            combo.DataSource = collection;
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;
            combo.Value = -1;
        }

        public static void SetUltraGridValueList<T>(UltraGridLayout layout, IEnumerable<T> collection,
            UltraGridBand band, string valueMember, string displayMember)
        {
            ValueList vl;

            if (!layout.ValueLists.Exists(typeof(T).Name + valueMember + displayMember))
                vl = layout.ValueLists.Add(typeof(T).Name + valueMember + displayMember);

            vl = layout.ValueLists[typeof(T).Name + valueMember + displayMember];
            vl.ValueListItems.Clear();
            vl.ValueListItems.Add(-1, "Seleccione");

            foreach (T entity in collection)
            {
                vl.ValueListItems.Add(entity.GetType().GetProperty(valueMember).GetValue(entity, null),
                    entity.GetType().GetProperty(displayMember).GetValue(entity, null).ToString());
            }

            band.Columns[valueMember].ValueList = layout.ValueLists[typeof(T).Name + valueMember + displayMember];
        }
    }
}
