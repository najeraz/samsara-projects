
using Samsara.Base.Controls.EventsArgs;

namespace Samsara.Base.Controls.EventsHandlers
{
    public delegate void ManyToOneLevel1EntityChangedEventHandler<T>(object sender,
        ManyToOneLevel1EntityChangedEventArgs<T> e);
}
