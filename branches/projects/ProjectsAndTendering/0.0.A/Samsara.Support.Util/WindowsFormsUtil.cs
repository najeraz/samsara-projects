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

        public static void SetUltraGridValueList<T>(InitializeLayoutEventArgs e, IEnumerable<T> collection,
            int bandIndex, string valueMember, string displayMember)
        {
            ValueList vl;

            if (!e.Layout.ValueLists.Exists(typeof(T).Name + valueMember + displayMember))
            {
                vl = e.Layout.ValueLists.Add(typeof(T).Name + valueMember + displayMember);

                foreach (T entity in collection)
                {
                    vl.ValueListItems.Add(entity.GetType().GetProperty(valueMember).GetValue(entity, null),
                        entity.GetType().GetProperty(displayMember).GetValue(entity, null).ToString());
                }
            }
            e.Layout.Bands[bandIndex].Columns[valueMember].ValueList
                = e.Layout.ValueLists[typeof(T).Name + valueMember + displayMember];
        }
    }
}
