
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class ISP : GenericEntity
    {
        public ISP()
        {
            ISPId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int ISPId
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