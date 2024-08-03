using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Facturador.Web.Controllers;
using Facturador.Web.Entities;
using Moq.EntityFrameworkCore;
using Newtonsoft.Json;
using Facturador.Web.Interfaces;
using Microsoft.AspNetCore.Http;
using Facturador.Web.DTOs;

namespace CustomerControllerTests
{
    public class CustomerControllerTests
    {
        private CustomerController _controller;
        private Mock<InvoiceContext> _mockContext;
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<ICustomerWriter> _mockCustomerWriter;
        private Mock<ICustomerReader> _mockCustomerReader;
        public class MyResultAll { public string IsSuccess { get; set; } public IList<Customer> ListCustomers { get; set; } }
        public class MyResultOne { public string IsSuccess { get; set; } public IList<Customer> customerFound { get; set; } }


        [SetUp]
        public void Setup()
        {

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
            _mockCustomerWriter = new Mock<ICustomerWriter>();
            _mockCustomerReader = new Mock<ICustomerReader>();

            //Add List Customers
            _mockContext.Setup(c => c.Customers).ReturnsDbSet(customers);

            //Is Instance
            _controller = new CustomerController(_mockCustomerWriter.Object, _mockCustomerReader.Object);

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

            //Set Metod
            _mockCustomerReader.Setup(reader => reader.GetAll()).ReturnsAsync(customers);

            // Act
            var result = await _controller.GetAllCustomer() as ObjectResult;

            // Assert

            Assert.That(result, Is.Not.Null);

            Assert.That(StatusCodes.Status200OK, Is.EqualTo(result.StatusCode));

            var resultJson = JsonConvert.SerializeObject(result.Value);
            var resultValue = JsonConvert.DeserializeObject<MyResultAll>(resultJson);


            Assert.That(resultValue.IsSuccess, Is.EqualTo("listado encontrado correctamente"));

            Assert.That(resultValue.ListCustomers, Is.Not.Null);
        }

        [Test]
        public async Task GetCustomerById_ReturnsCustomer()
        {
            // Arrange
            int customerId = 1;

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
                }
            };

            //set metod
            _mockCustomerReader.Setup(reader => reader.Get(It.IsAny<int>()))
                             .ReturnsAsync((int id) => customers.FirstOrDefault(c => c.Id == id));

            // Act
            var result = await _controller.GetCustomerById(customerId) as ObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);

            Assert.That(StatusCodes.Status200OK, Is.EqualTo(result.StatusCode));


            var resultJson = JsonConvert.SerializeObject(result.Value);
            var resultValue = JsonConvert.DeserializeObject<MyResultOne>(resultJson);


            Assert.That(resultValue.IsSuccess, Is.EqualTo("Registro encontrado correctamente"));

            Assert.That(resultValue.customerFound, Is.Not.Null);
        }

        [Test]
        public async Task AddCustomer_ReturnsSuccess()
        {
            // Arrange
            var customerDTO = new CustomerDTO
            {
                Email = "newcustomer@example.com",
                PasswordCustomer = "newpassword"
            };

            _mockCustomerWriter.Setup(writer => writer.AddCustomer(customerDTO)).ReturnsAsync(true);

            // Act
            var result = await _controller.AddCustomer(customerDTO) as ObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(StatusCodes.Status200OK, Is.EqualTo(result.StatusCode));

            var resultJson = JsonConvert.SerializeObject(result.Value);
            var resultValue = JsonConvert.DeserializeObject<MyResultAll>(resultJson);


            Assert.That(resultValue.IsSuccess, Is.EqualTo("Customer registrado correctamente"));
        }

        [Test]
        public async Task DeleteCustomer_ReturnsSuccess()
        {
            // Arrange
            int customerId = 1;

            _mockCustomerWriter.Setup(writer => writer.DeleteCustomer(customerId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteCustomer(customerId) as ObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(StatusCodes.Status200OK, Is.EqualTo(result.StatusCode));

            var resultJson = JsonConvert.SerializeObject(result.Value);
            var resultValue = JsonConvert.DeserializeObject<MyResultAll>(resultJson);


            Assert.That(resultValue.IsSuccess, Is.EqualTo("Registro eliminado correctamente"));
        }




    }
}
