
using System;

namespace Samsara.Framework.Util
{
    public class MoneyUtil
    {       
        public static decimal Round(decimal value)
        {
            return Math.Round(value, 2);
        }
    }
}
