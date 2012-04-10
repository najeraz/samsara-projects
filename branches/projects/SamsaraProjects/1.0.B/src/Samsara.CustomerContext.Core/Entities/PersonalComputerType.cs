
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class PersonalComputerType : BaseEntity
    {
        public PersonalComputerType()
        {
            PersonalComputerTypeId = -1;
        }

        [PrimaryKey]
        public virtual int PersonalComputerTypeId
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