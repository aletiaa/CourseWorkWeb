using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Data
{
    [TestClass]
    public class ProductTests
    {
        private Product _product;

        [TestInitialize]
        public void Initialize()
        {
            _product = new Product();
        }

        [TestMethod]
        public void ProductTests_Constructor_OrdersProducts_NotNull() 
        {
            //assert
            Assert.IsNotNull(_product.OrdersProducts);
        }

        [TestMethod]
        public void ProductTests_Constructor_OrdersProducts_Empty()
        {
            Assert.AreEqual(0, _product.OrdersProducts.Count);
        }


        [TestMethod]
        public void ProductTests_ImageName_ByDefault_ShouldReturnDefaultName()
        {
            // Assert
            Assert.IsNotNull(_product.ImageName);
            Assert.AreEqual("no-image.jpg", _product.ImageName);
        }

        [TestMethod]
        public void ProductTests_ImageName_ForNullName_ShouldReturnDefaultName()
        {
            // act
            _product.ImageName = null;

            // Assert
            Assert.IsNotNull(_product.ImageName);
            Assert.AreEqual("no-image.jpg", _product.ImageName);
        }

        [TestMethod]
        public void ProductTests_ImageName_ForCustomName_ShouldReturnCustomName()
        {
            // Arrange
            string? newImageName = "custom-name.jpg";

            // Act
            _product.ImageName = newImageName;  

            // Assert

            Assert.AreEqual(newImageName, _product.ImageName);  
        }
    }
}
