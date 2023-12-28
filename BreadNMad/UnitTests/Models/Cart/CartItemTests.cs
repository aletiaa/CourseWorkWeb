using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Models.Cart
{
    [TestClass]
    public class CartItemTests
    {
        [TestMethod]
        public void CartItemTests_CreateCart_PropertiesAreCorrect()
        {
            // Arrange
            var productId = 1;
            var productName = "item 1";
            var imageName = "someimage.jpg";
            var price = 100.1;
            var quantity = 2;

            // Act
            var cartItem = new CartItem(productId, productName, imageName, price, quantity);

            // Assert
            Assert.AreEqual(productId, cartItem.ProductId);
            Assert.AreEqual(productName, cartItem.ProductName);
            Assert.AreEqual(price, cartItem.Price);
            Assert.AreEqual(quantity, cartItem.Quantity);
            Assert.AreEqual(imageName, cartItem.ImageName);
        }

        [TestMethod]
        public void CartItemTests_IncreaseQuantity_QuantityIncreasedByOneEveryTime()
        {
            // Arrange
            var productId = 1;
            var productName = "item 1";
            var imageName = "someimage.jpg";
            var price = 100.1;
            var quantity = 2;
            var cartItem = new CartItem(productId, productName, imageName, price, quantity);

            //act and assert 
            cartItem.IncreaseQuantity();
            Assert.AreEqual(3, cartItem.Quantity);

            //act and assert
            cartItem.IncreaseQuantity(); 
            Assert.AreEqual(4, cartItem.Quantity);
        }
    }
}
