

namespace Samsara.BaseCore.Entities
{
    public class GenericEntity
    {
        public GenericEntity()
        {
        }

        public virtual bool Deleted
        {
            get;
            set;
        }

        public virtual bool Activated
        {
            get;
            set;
        }
    }
}