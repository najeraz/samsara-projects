
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Main.Core.Entities
{
    public class SamsaraForm : GenericEntity
    {

        public SamsaraForm()
        {
            SamsaraFormId = -1;
        }

        [PrimaryKey]
        public virtual int SamsaraFormId
        {
            get;
            set;
        }

        public virtual Scheme Scheme
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

    }
}