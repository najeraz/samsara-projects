using System;
using System.Collections.Generic;
using Infragistics.Win.UltraWinEditors;

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
    }
}
