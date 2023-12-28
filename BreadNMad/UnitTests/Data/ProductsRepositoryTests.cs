using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Data
{
    [TestClass]
    public class ProductsRepositoryTests
    {
        private ProductsRepository _productsRepository;
        private List<Product> _products;
        private ShopContext _dbContext;

        [TestInitialize]
        public void TestInitialize()
        {
            _products = new List<Product>
            {
                new Product { ID = 1, Name = "Product 1" },
                new Product { ID = 2, Name = "Product 2" },
                new Product { ID = 3, Name = "Product 3" },
                new Product { ID = 4, Name = "Product 4" },
                new Product { ID = 5, Name = "Product 5" }
            };

            //mock of products table can be only created if the method is virtual
            var mockDbSet = GetProductsDbSet(_products);

            // mock of database can be created if perameterless constuctor exists
            _dbContext = Substitute.For<ShopContext>();
            _dbContext.Products.Returns(mockDbSet);

            _productsRepository = new ProductsRepository(_dbContext);
        }

        [TestMethod]
        public void ProductsRepositoryTests_GetAllProducts_ShouldReturnAllProducts()
        {
            // Arrange

            // Act
            var result = _productsRepository.GetAllProducts();

            // Assert
            CollectionAssert.AreEqual(_products, result);
        }

        [TestMethod]
        public void ProductsRepositoryTests_GetRandomThreeProducts_ShouldReturnThreeRandomProducts()
        {
            // Arrange
            if (_products.Count <= 3)
            {
                Assert.Fail("More than 3 products required for test.");
            }

            // Act
            var result = _productsRepository.GetRandomThreeProducts();

            // Assert
            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreNotEqual(_products, result);
            foreach (var product in result)
            {
                Assert.IsTrue(_products.Any(p => p.ID == product.ID));
            }
        }

        [TestMethod]
        public void ProductsRepositoryTests_Add_ShouldAddProductToContext()
        {
            // Arrange
            var productToAdd = new Product { ID = 1, Name = "New Product" };

            // Act
            _productsRepository.Add(productToAdd);

            // Assert, method add was recieved one call with product, with id 1 and name New Product
            _dbContext.Products.Received(1).Add(Arg.Is<Product>(p => p.ID == 1
                                                                     && p.Name == "New Product"));
            // method save changes was called once on the db object
            _dbContext.Received(1).SaveChanges();
        }

        [TestMethod]
        public void ProductsRepositoryTests_Remove_ShouldRemoveProductFromContext()
        {
            // Arrange
            var productIdToRemove = 1;

            // Act
            _productsRepository.Remove(productIdToRemove);

            // Assert

            _dbContext.Products.Received(1).Remove(Arg.Any<Product>());
            _dbContext.Received(1).SaveChanges();
        }

        [TestMethod]
        public void ProductsRepositoryTests_FindProduct_ProductExists_ShouldReturnCorrectProduct()
        {
            // Arrange
            var productIdToFind = 2;
            var expectedProduct = _products.Single(p => p.ID == productIdToFind);

            // Act
            var result = _productsRepository.FindProduct(productIdToFind);

            // Assert
            Assert.AreEqual(expectedProduct, result);
        }

        [TestMethod]
        public void ProductsRepositoryTests_FindProduct_ProductDoesExist_ShouldReturnProduct()
        {
            // Arrange
            var productIdToFind = 2;

            // Act
            var result = _productsRepository.FindProduct(productIdToFind);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(productIdToFind, result.ID);
        }

        [TestMethod]
        public void ProductsRepositoryTests_FindProduct_ProductDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var productIdToFind = -1;

            // Act
            var result = _productsRepository.FindProduct(productIdToFind);

            // Assert
            Assert.IsNull(result);
        }

        private DbSet<Product> GetProductsDbSet(IEnumerable<Product> products)
        {
            var mockDbSet = Substitute.For<DbSet<Product>, IQueryable<Product>>();
            ((IQueryable<Product>)mockDbSet).Provider.Returns(products.AsQueryable().Provider);
            ((IQueryable<Product>)mockDbSet).Expression.Returns(products.AsQueryable().Expression);
            ((IQueryable<Product>)mockDbSet).ElementType.Returns(products.AsQueryable().ElementType);
            ((IQueryable<Product>)mockDbSet).GetEnumerator().Returns(products.AsQueryable().GetEnumerator());
           
            return mockDbSet;
        }
    }
}
