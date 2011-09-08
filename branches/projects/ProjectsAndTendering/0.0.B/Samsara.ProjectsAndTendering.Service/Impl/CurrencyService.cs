
using Samsara.BaseService.Impl;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Dao.Interfaces;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Service.Impl
{
    public class CurrencyService : GenericService<Currency, int, ICurrencyDao, CurrencyParameters>, ICurrencyService
    {
        public override void Save(Currency entity)
        {
            this.DefaultCurrencyLogic(entity);
            base.Save(entity);
        }

        public override void SaveOrUpdate(Currency entity)
        {
            this.DefaultCurrencyLogic(entity);
            base.SaveOrUpdate(entity);
        }

        private void DefaultCurrencyLogic(Currency entity)
        {
            if (entity.IsDefault)
            {
                CurrencyParameters pmtCurrency = new CurrencyParameters();
                pmtCurrency.IsDefault = true;

                Currency currency = this.GetByParameters(pmtCurrency);

                if (currency != null && currency.CurrencyId != entity.CurrencyId)
                {
                    currency.IsDefault = false;
                    this.Update(currency);
                }
            }
        }
    }
}