
using Samsara.Base.Controls.EventsArgs;

namespace Samsara.Base.Controls.EventsHandlers
{
    public delegate void SamsaraEntityChooserValueChangedEventHandler<T>(object sender,
        SamsaraEntityChooserValueChangedEventArgs<T> e);
}
