using Facturador.Web.Controllers;
using Facturador.Web.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Test
{
    [TestFixture]
    public class TestCustomer
    {
        //MMMMM

        [Test]
        public async Task CustomerTestGetAll()
        {
            //Arrange


            //Act
            var result = await _controller.GetAll();
            var objectResult = result as ObjectResult;

            //Assert

            Assert.That(result, Is.Not.Null);
            Assert.That(objectResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        }

        [Test]

        public async Task CustomerTestGetOne()
        {
            //Arrange
            int id = 1;

            //Act
            var result = await _controller.Get(id);
            var objectResult = result as ObjectResult;

            //Assert

            Assert.That(result, Is.Not.Null);
            Assert.That(objectResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        }


        [Test]

        public async Task CustomerTestCreate()
        {
            //Arrange
            var customerNew = new CustomerDTO()
            {
                Email = "pruebas@correo.com",
                PasswordCustomer = "1232"

            };

            //Act
            var result = await _controller.Post(customerNew);
            var objectResult = result as ObjectResult;

            //Assert

            Assert.That(result, Is.Not.Null);
            Assert.That(objectResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        }



        [Test]

        public async Task CustomerTestDelete()
        {
            //Arrange
            int id = 1;

            //Act
            var result = await _controller.Delete(id);
            var objectResult = result as ObjectResult;

            //Assert

            Assert.That(result, Is.Not.Null);
            Assert.That(objectResult?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        }

    }

}
