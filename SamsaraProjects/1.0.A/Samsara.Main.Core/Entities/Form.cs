
using Samsara.AlleatoERP.Core.Entities;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Main.Core.Entities
{
    public class Form : GenericEntity
    {

        public Form()
        {
            FormId = -1;
        }

        [PrimaryKey]
        public virtual int FormId
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