
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Framework.Core.Entities
{
    public class TextFormat : BaseEntity
    {
        public TextFormat()
        {
            TextFormatId = -1;
        }

        [PrimaryKey]
        public virtual int TextFormatId
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