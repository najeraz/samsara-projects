
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class ComputerType : GenericEntity
    {
        public ComputerType()
        {
            ComputerTypeId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int ComputerTypeId
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