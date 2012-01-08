using System;

namespace SamsaraCommissions
{
    public class NumberUtils
    {
        public static decimal DecimalValue(object p)
        {
            try { return Convert.ToDecimal(p); }
            catch { return decimal.Zero; }
        }
    }
}
