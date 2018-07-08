using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiBase.Core;
using WebApiBase.Core.Dtos;
using WebApiBase.Core.Models;
using WebApiBase.Persistance;

namespace WebApiBase.Controllers
{

    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {

        private ApplicationDbContext context;
        private IUnitOfWork unitOfWork;

        public ProductsController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }

        public ProductsController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        //GET api/products
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetProducts()
        {

            var products = unitOfWork?.Products.GetProducts().ToList();

            if (products == null)
                return Content(HttpStatusCode.NotFound, "No products were found");

            return Ok(products);

        }

        /// <summary>
        /// Gets product by ID
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>Product object</returns>
        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {

            var product = unitOfWork?.Products.GetProductById(id);

            if (product == null)
                return Content(HttpStatusCode.NotFound, "Product not found");

            return Ok(product);

        }

        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns>OK, BadRequest or Conflict</returns>
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto product)
        {

            if (!ModelState.IsValid)
                return BadRequest("Wrong product format");

            if (unitOfWork.Products.Exists(product.ProductID))
                return Conflict();

            var newProduct = new Product
            {
                CategoryID = product.CategoryID,
                Discontinued = product.Discontinued,
                ProductName = product.ProductName,
                ProductID = product.ProductID,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                SupplierID = product.SupplierID,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder
            };

            try
            {

                unitOfWork?.Products.Insert(newProduct);
                unitOfWork?.Save();

                return Ok();

            }
            catch (DbUpdateException ex)
            {

                return BadRequest(ex.Message);
            }


        }

        //PUT
        /// <summary>
        /// Updates a product informing Id
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <param name="product">Product object</param>
        /// <returns>OK, BadRequest, NotFound</returns>
        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductDto product)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            if (product == null || !unitOfWork.Products.Exists(id))
                return NotFound();

            var productToUpdate = new Product
            {
                CategoryID = product.CategoryID,
                Discontinued = product.Discontinued,
                ProductName = product.ProductName,
                ProductID = id,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                SupplierID = product.SupplierID,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder
            };

            try
            {

                unitOfWork?.Products.Update(productToUpdate);
                unitOfWork?.Save();

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }

        //Delete
        /// <summary>
        /// Delete a product informing id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Ok, NotFound, BadRequest</returns>
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {

            if (!unitOfWork.Products.Exists(id))
                return NotFound();

            try
            {
                unitOfWork.Products.Delete(id);
                unitOfWork.Save();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }

    }

}
