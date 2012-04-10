
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

        public virtual void Save<T>(T entity)
        {
            this.Dao.Save<T>(entity);
        }

        public virtual void SaveOrUpdate<T>(T entity)
        {
            this.Dao.SaveOrUpdate<T>(entity);
        }

        public virtual void Update<T>(T entity)
        {
            this.Dao.Update<T>(entity);
        }

        public virtual void Delete<T>(T entity)
        {
            this.Dao.Delete<T>(entity);
        }

        public virtual void Refresh<T>(T entity)
        {
            this.Dao.Refresh<T>(entity);
        }

        #endregion Methods
    }
}
