
using System;
using Samsara.Main.Core.Enums;

namespace Samsara.Support.Util
{
    public class TaxesUtil
    {
        private static decimal ivaPercent = .16M;

        public static decimal GetTaxPercent(TaxEnum taxEnum)
        {
            decimal value;

            switch (taxEnum)
            {
                case TaxEnum.IVA:
                    value = ivaPercent;
                    break;
                default:
                    throw new Exception("No existe el impuesto...");
            }

            return value;
        }
    }
}
