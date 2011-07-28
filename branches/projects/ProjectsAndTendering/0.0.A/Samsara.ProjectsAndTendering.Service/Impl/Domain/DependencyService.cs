
using System.Collections.Generic;
using System.Data;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class DependencyService : BaseService, IDependencyService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IDependencyDao DependencyDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public DataTable SearchDependencies(SearchDependenciesParameters pmtSearchDependencies)
        {
            return this.DependencyDao.SearchDependencies(pmtSearchDependencies);
        }

        public Dictionary<int, Dependency> LoadDependencies(LoadDependenciesParameters pmtLoadDependencies)
        {
            return this.DependencyDao.LoadDependencies(pmtLoadDependencies);
        }

        public Dependency LoadDependency(int DependencyId)
        {
            return this.DependencyDao.GetById(DependencyId);
        }

        public void SaveOrUpdateDependency(Dependency entity)
        {
            if (entity.DependencyId < 0)
            {
                this.DependencyDao.Save(entity);
            }
            else
            {
                this.DependencyDao.Update(entity);
            }
        }

        public void DeleteDependency(Dependency entity)
        {
            this.DependencyDao.Delete(entity);
        }

        #endregion Methods
    }
}