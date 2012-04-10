
using System;
using System.Collections.Generic;

namespace Samsara.Base.Controls.EventsArgs
{
    public class SamsaraEntityChooserValuesChangedEventArgs <T> : EventArgs
    {
        public IList<T> NewValues { get; set; }

        public SamsaraEntityChooserValuesChangedEventArgs(IList<T> newValues)
        {
            NewValues = newValues;
        }
    }
}
