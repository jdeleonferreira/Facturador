using Facturador.Web.Models.Taxes;

namespace Facturador.Test
{
    
    internal class TaxesTest
    {
        [Test]
        public async Task CalculateTaxIVA()
        {
            //Arrange
            Taxes tax = new Taxes();

            //Act
            var calculatedTaxIva = tax.CalculateTaxes(TaxesList.IVA, 100000m);
            var calculatedTaxICA = tax.CalculateTaxes(TaxesList.ICA, 100000m);
            var calculatedTaxIpoconsumo = tax.CalculateTaxes(TaxesList.IPOCONSUMO, 100000m);



            //Assert
            

            //Cases calculte result
            Assert.That(calculatedTaxIva == 100000 * .19m);
            Assert.That(calculatedTaxICA == 100000 * 0.04m);
            Assert.That(calculatedTaxIpoconsumo != 100000 * 0.08m);



           //Cases type date not number decimal
           //???




        }
    }
}
