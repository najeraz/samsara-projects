using System;
using System.Collections.Generic;
using System.Text;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;

namespace Samsara.ProjectsAndTendering.Service.Interfaces.Domain
{
    public interface IBeneficiaryService
    {
        Dictionary<int, Beneficiary> LoadBeneficiaries();
        Beneficiary LoadBeneficiary(int BeneficiaryId);
        void SaveOrUpdateBeneficiary(Beneficiary entity);
        void DeleteBeneficiary(Beneficiary entity);
    }
}
