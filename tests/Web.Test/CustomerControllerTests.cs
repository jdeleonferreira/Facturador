using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Facturador.Web.Controllers;
using Facturador.Web.Entities;
using Moq.EntityFrameworkCore;
using Newtonsoft.Json;
using Facturador.Web.Interfaces;

namespace CustomerControllerTests
{
    public class CustomerControllerTests
    {
        private CustomerController _controller;
        private Mock<InvoiceContext> _mockContext;
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<ICustomerWriter> _customerWriter;
        private Mock<ICustomerReader> _customerReader;

        [SetUp]
        public void Setup()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer {
                    Id = 1,
                    Name = "Customer 1",
                    TaxNumber = "123456789",
                    ContactNumber = "123-456-7890",
                    Address = "Address 1",
                    City = 1,
                    Email = "customer1@example.com",
                    PasswordCustomer = "password1",
                    Invoices = new List<Invoice>()
                },
                new Customer {
                    Id = 2,
                    Name = "Customer 2",
                    TaxNumber = "987654321",
                    ContactNumber = "098-765-4321",
                    Address = "Address 2",
                    City = 2,
                    Email = "customer2@example.com",
                    PasswordCustomer = "password2",
                    Invoices = new List<Invoice>()
                }
            };


            _mockConfiguration = new Mock<IConfiguration>();
            _mockContext = new Mock<InvoiceContext>();
            _customerWriter = new Mock<ICustomerWriter>();
            _customerReader = new Mock<ICustomerReader>();

            //Add List Customers
            _mockContext.Setup(c => c.Customers).ReturnsDbSet(customers);
            _controller = new CustomerController(_customerWriter.Object, _customerReader.Object);

        }

        [Test]
        public async Task GetAll_ReturnsOkResult_WithListOfCustomers()
        {

            // Arrange
            var customers = new List<Customer>
            {
                new Customer {
                    Id = 1,
                    Name = "Customer 1",
                    TaxNumber = "123456789",
                    ContactNumber = "123-456-7890",
                    Address = "Address 1",
                    City = 1,
                    Email = "customer1@example.com",
                    PasswordCustomer = "password1",
                    Invoices = new List<Invoice>()
                },
                new Customer {
                    Id = 2,
                    Name = "Customer 2",
                    TaxNumber = "987654321",
                    ContactNumber = "098-765-4321",
                    Address = "Address 2",
                    City = 2,
                    Email = "customer2@example.com",
                    PasswordCustomer = "password2",
                    Invoices = new List<Invoice>()
                }
            };


            // Act
            var result = await _controller.GetAllCustomer();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);

            var resultJson = JsonConvert.SerializeObject(okResult.Value);

            var resultValue = JsonConvert.DeserializeObject<MyResult>(resultJson);

            Assert.That(resultValue.IsSuccess, Is.EqualTo("listado encontrado correctamente"));
            Assert.That(resultValue.ListCustomers, Is.EqualTo(customers));


        }

        public class MyResult { public string IsSuccess { get; set; } public IList<Customer> ListCustomers { get; set; } }



        //[Test]
        //public async Task GetAll_ReturnsNotFound_WhenNoCustomers()
        //{
        //    // Arrange
        //    var customers = new List<Customer>();

        //    _mockContext.Setup(c => c.Customers).ReturnsDbSet(customers);

        //    // Act
        //    var result = await _controller.GetAll();

        //    // Assert
        //    Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
        //    var notFoundResult = result as NotFoundObjectResult;
        //    Assert.That(notFoundResult, Is.Not.Null);

        //    dynamic responseValue = notFoundResult.Value;
        //    Assert.That(responseValue.isSuccess, Is.EqualTo("Registro no encontrado"));
        //}
    }
}
