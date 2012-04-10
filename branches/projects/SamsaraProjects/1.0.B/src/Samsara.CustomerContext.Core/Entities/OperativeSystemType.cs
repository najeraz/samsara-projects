
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class OperativeSystemType : BaseEntity
    {
        public OperativeSystemType()
        {
            OperativeSystemTypeId = -1;
        }

        [PrimaryKey]
        public virtual int OperativeSystemTypeId
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