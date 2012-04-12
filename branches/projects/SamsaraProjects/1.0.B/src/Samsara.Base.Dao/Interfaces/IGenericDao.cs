

namespace Samsara.Base.Dao.Interfaces
{
    public interface IGenericDao : IGenericReadOnlyDao
    {
        void Delete(object entity);
        void SaveOrUpdate(object entity);
        void Save(object entity);
        void Update(object entity);
        void Refresh(object entity);
    }
}