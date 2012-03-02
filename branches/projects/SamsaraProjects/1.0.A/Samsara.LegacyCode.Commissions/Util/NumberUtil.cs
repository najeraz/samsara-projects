
using System;

namespace Samsara.LegacyCode.Commissions.Util
{
    public class NumberUtil
    {
        public static decimal DecimalValue(object p)
        {
            try { return Convert.ToDecimal(p); }
            catch { return decimal.Zero; }
        }
    }
}
