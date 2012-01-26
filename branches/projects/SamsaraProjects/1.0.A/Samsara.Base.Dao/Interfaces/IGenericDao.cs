

namespace Samsara.Base.Dao.Interfaces
{
    public interface IGenericDao<T, TId, Tpmt> : IGenericReadOnlyDao<T, TId, Tpmt>
    {
        void Delete(T entity);
        void SaveOrUpdate(T entity);
        void Save(T entity);
        void Update(T entity);
        void Refresh(T entity);
    }
}