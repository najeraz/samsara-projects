
using Samsara.ProjectsAndTendering.Service.Interfaces.Domain;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using System.Linq;
using System.Collections.Generic;
using Samsara.ProjectsAndTendering.Dao.Interfaces.Domain;

namespace Samsara.ProjectsAndTendering.Service.Impl.Domain
{
    public class BeneficiaryService : BaseService, IBeneficiaryService
    {
        #region Properties

        /// <summary>
        /// This field is inyected by IoC through the property.
        /// </summary>
        public IBeneficiaryDao BeneficiaryDao
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public Dictionary<int, Beneficiary> LoadBeneficiaries()
        {
            return this.BeneficiaryDao.LoadBeneficiaries();
        }

        public Beneficiary LoadBeneficiary(int BeneficiaryId)
        {
            return this.BeneficiaryDao.GetById(BeneficiaryId);
        }

        public void SaveOrUpdateBeneficiary(Beneficiary entity)
        {
            if (entity.BeneficiaryId < 0)
            {
                this.BeneficiaryDao.Save(entity);
            }
            else
            {
                this.BeneficiaryDao.Update(entity);
            }
        }

        public void DeleteBeneficiary(Beneficiary entity)
        {
            this.BeneficiaryDao.Delete(entity);
        }

        #endregion Methods
    }
}