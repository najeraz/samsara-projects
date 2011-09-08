
using System;

namespace Samsara.Support.Util
{
    public class MoneyUtil
    {       
        public static decimal Round(decimal value)
        {
            return Math.Round(value, 2);
        }
    }
}
