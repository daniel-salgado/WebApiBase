using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;
using WebApiBase.Controllers;
using WebApiBase.Core;
using WebApiBase.Core.Dtos;
using WebApiBase.Core.Repositories;

namespace WebApiBase.Tests
{
    [TestClass]
    public class UnitTestProduct
    {

        private ProductsController _controller;
        private Mock<IProductRepository> _mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {

            _mockRepository = new Mock<IProductRepository>();

            // Initialize mock UnitOfWork.
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.SetupGet(m => m.Products).Returns(_mockRepository.Object);

            //Initialize mock ProductsController

            _controller = new ProductsController(mockUnitOfWork.Object);

        }

        [TestMethod]
        public void Create_ExistingProduct_ShouldReturnConflictResult()
        {
            var product = new ProductDto
            {
                ProductID = 1,
                ProductName = "Test Existing Product",
                CategoryID = 3,
                UnitPrice = new decimal(999.99),
                QuantityPerUnit = "0",
                SupplierID = 22
            };

            _mockRepository.Setup(r => r.Exists(product.ProductID)).Returns(true);

            var result = _controller.CreateProduct(product);

            Assert.IsInstanceOfType(result, typeof(ConflictResult));

        }

        [TestMethod]
        public void Create_Product_ShouldReturnOK()
        {
            var product = new ProductDto
            {
                ProductName = "Test Existing Product",
                CategoryID = 3,
                UnitPrice = new decimal(999.99),
                QuantityPerUnit = "0",
                SupplierID = 22
            };

            _mockRepository.Setup(r => r.Exists(product.ProductID)).Returns(false);

            var result = _controller.CreateProduct(product);

            Assert.IsInstanceOfType(result, typeof(OkResult));

        }



    }
}
