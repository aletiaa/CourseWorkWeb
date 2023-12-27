using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Data
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void OrderTests_Constructor_OrdersProducts_NotNull()
        {
            // arrange and act
            Order order = new Order(); 

            //assert
            Assert.IsNotNull(order.OrdersProducts);
        }

        [TestMethod]
        public void OrderTests_PhoneNumberAndNameAreNotNull_NoErrorMessages()
        {
            // Arrange
            var order = new Order
            {
                PhoneNumber = "+380501234567",
                FullName = "Customer name"
            };

            // Act
            var validationResult = ValidateModel(order);

            // Assert
            Assert.AreEqual(0, validationResult.Count());
        }

        [TestMethod]
        public void OrderTests_PhoneNumberAndNameAreNull_RequiredErrorMessages()
        {
            // Arrange
            var order = new Order
            {
                PhoneNumber = null,
                FullName = null
            };

            // Act
            var validationResult = ValidateModel(order);

            // Assert
            Assert.AreEqual(2, validationResult.Count());
            Assert.AreEqual("Введіть номер телефону", validationResult.ElementAt(0).ErrorMessage);
            Assert.AreEqual(nameof(Order.PhoneNumber), validationResult.ElementAt(0).MemberNames.Single());
            Assert.AreEqual("Введіть прізвище та ім'я", validationResult.ElementAt(1).ErrorMessage);
            Assert.AreEqual(nameof(Order.FullName), validationResult.ElementAt(1).MemberNames.Single());
        }

        [TestMethod]
        public void OrderTests_PhoneNumberIsNull_RequiredErrorMessage()
        {
            // Arrange
            var order = new Order
            {
                PhoneNumber = null,
                FullName = "Customer name"
            };

            // Act
            var validationResult = ValidateModel(order);

            // Assert
            Assert.AreEqual(1, validationResult.Count());
            Assert.AreEqual("Введіть номер телефону", validationResult.Single().ErrorMessage);
            Assert.AreEqual(nameof(Order.PhoneNumber), validationResult.Single().MemberNames.Single());
        }

        [TestMethod]
        public void OrderTests_FullNameIsNull_RequiredErrorMessage()
        {
            // Arrange
            var order = new Order
            {
                PhoneNumber = "+380501234567",
                FullName = null
            };

            // Act
            var validationResult = ValidateModel(order);

            // Assert
            Assert.AreEqual(1, validationResult.Count());
            Assert.AreEqual("Введіть прізвище та ім'я", validationResult.Single().ErrorMessage);
            Assert.AreEqual(nameof(Order.FullName), validationResult.Single().MemberNames.Single());
        }

        private static IEnumerable<ValidationResult> ValidateModel(object model)
        //ValidationResult is a .NET framework class designed to keep the results of validation
        {
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);
            return validationResults;
        }
    }
}
