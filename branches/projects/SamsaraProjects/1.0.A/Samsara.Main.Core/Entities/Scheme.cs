
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Main.Core.Entities
{
    public class Scheme : GenericEntity
    {

        public Scheme()
        {
            SchemeId = -1;
        }

        [PrimaryKey]
        public virtual int SchemeId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

    }
}