
using Samsara.BaseService.Impl;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Core.Parameters;
using Samsara.Operation.Dao.Interfaces;
using Samsara.Operation.Service.Interfaces;

namespace Samsara.Operation.Service.Impl
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