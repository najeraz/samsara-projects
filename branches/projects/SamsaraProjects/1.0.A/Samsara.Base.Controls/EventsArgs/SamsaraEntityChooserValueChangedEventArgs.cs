
using System;

namespace Samsara.Base.Controls.EventsArgs
{
    public class SamsaraEntityChooserValueChangedEventArgs <T> : EventArgs
    {
        public T NewValue { get; set; }

        public SamsaraEntityChooserValueChangedEventArgs(T newValue)
        {
            NewValue = newValue;
        }
    }
}
