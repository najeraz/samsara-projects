

namespace Samsara.Base.Dao.Interfaces
{
    public interface IGenericDao : IGenericReadOnlyDao
    {
        void Delete<T>(T entity);
        void SaveOrUpdate<T>(T entity);
        void Save<T>(T entity);
        void Update<T>(T entity);
        void Refresh<T>(T entity);
    }
}