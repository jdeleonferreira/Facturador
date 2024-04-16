using Facturador.Models.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturador.Models.Taxes;

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
            var calculatedTax = tax.CalculateTaxes(TaxesList.IVA, 100000m);

            //Assert
            Assert.That(calculatedTax == 100000 * .19m);
        }
    }
}
