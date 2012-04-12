
using Samsara.Base.Dao.Interfaces;
using Samsara.Base.Service.Interfaces;

namespace Samsara.Base.Service.Impl
{
    public class GenericService : GenericReadOnlyService, IGenericService
    {
        #region Properties

        protected IGenericDao Dao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public virtual void Save(object entity)
        {
            this.Dao.Save(entity);
        }

        public virtual void SaveOrUpdate(object entity)
        {
            this.Dao.SaveOrUpdate(entity);
        }

        public virtual void Update(object entity)
        {
            this.Dao.Update(entity);
        }

        public virtual void Delete(object entity)
        {
            this.Dao.Delete(entity);
        }

        public virtual void Refresh(object entity)
        {
            this.Dao.Refresh(entity);
        }

        #endregion Methods
    }
}
