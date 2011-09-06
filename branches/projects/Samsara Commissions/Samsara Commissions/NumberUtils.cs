using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComisionesSamsara
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
