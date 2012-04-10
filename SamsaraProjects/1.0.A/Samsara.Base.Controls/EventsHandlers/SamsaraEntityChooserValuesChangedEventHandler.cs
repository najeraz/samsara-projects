
using Samsara.Base.Controls.EventsArgs;

namespace Samsara.Base.Controls.EventsHandlers
{
    public delegate void SamsaraEntityChooserValuesChangedEventHandler<T>(object sender,
        SamsaraEntityChooserValuesChangedEventArgs<T> e);
}
