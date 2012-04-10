
using System;

namespace Samsara.Base.Controls.EventsArgs
{
    public class ManyToOneLevel1EntityChangedEventArgs <T> : EventArgs
    {
        public T EntityChanged { get; set; }

        public ManyToOneLevel1EntityChangedEventArgs(T entityChanged)
        {
            EntityChanged = entityChanged;
        }
    }
}
