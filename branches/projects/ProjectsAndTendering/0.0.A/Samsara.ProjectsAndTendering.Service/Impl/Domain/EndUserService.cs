
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using System.Linq;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Parameters;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class EndUserService : BaseService, IEndUserService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IEndUserDao EndUserDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public Dictionary<int, EndUser> LoadEndUsers(LoadEndUsersParameters pmtLoadEndUsers)
        {
            return this.EndUserDao.LoadEndUsers(pmtLoadEndUsers);
        }

        public Dictionary<int, EndUser> LoadEndUsers()
        {
            return this.EndUserDao.LoadEndUsers();
        }

        public EndUser LoadEndUser(int EndUserId)
        {
            return this.EndUserDao.GetById(EndUserId);
        }

        public void SaveOrUpdateEndUser(EndUser entity)
        {
            if (entity.EndUserId < 0)
            {
                this.EndUserDao.Save(entity);
            }
            else
            {
                this.EndUserDao.Update(entity);
            }
        }

        public void DeleteEndUser(EndUser entity)
        {
            this.EndUserDao.Delete(entity);
        }

        #endregion Methods
    }
}