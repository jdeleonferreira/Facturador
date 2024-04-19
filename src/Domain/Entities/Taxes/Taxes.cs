using Facturador.Domain.Enums;

namespace Facturador.Domain.Entities.Taxes
{
    public class Taxes
    {

        //List TaxName & Value

        public decimal CalculateTaxes(TaxesList tax, decimal value)
        {
            decimal result = 0;
            switch (tax)
            {
                case TaxesList.IVA:
                    result = value * 0.19m;
                    break;
                case TaxesList.ICA:
                    result = value * 0.04m; // | 0.08f | 0.16f
                    break;
                case TaxesList.IPOCONSUMO:
                    result = value * 0.08m;
                    break;
            }

            return result;
        }
    }
}


