using System;
using CustomerManagementSystem.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS_BLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            //--Arrange
            Customer customer = new Customer(1);
            customer.FirstName = "Queen";
            customer.LastName = "Swain";

            string expected = "Queen Swain";
            //--Act
            string Actual = customer.FullName;
            //--Assert
            Assert.AreEqual(expected, Actual);
        }

        [TestMethod]
        public void TestStatic()
        {
            

            var c1 = new Customer(1);
            c1.FirstName = "Ram";
            Customer.StaticInstanceCount += 1;

            var c2 = new Customer(1);
            c2.FirstName = "Shyam";
            Customer.StaticInstanceCount += 1;

            Assert.AreEqual(2,Customer.StaticInstanceCount);
        }

        [TestMethod]
        public void ValidateTest()
        { 

            var validate1 = new Customer(1);
         
            validate1.FirstName = "Samit";
            validate1.LastName = "Scott";
            validate1.EmailId = "samitscott@gmail.com";
            validate1.HomeAddress = "BBSR";
            validate1.WorkAddress = "Sotckholm";

            var expected = true;
            var actual = validate1.Validate();

            Assert.AreEqual(expected,actual);

        }

        [TestMethod]
        public void ValidateProductTest()
        {
            var validateProdcut = new Product();
            validateProdcut.ProductName = "T-Shirt";
            validateProdcut.Description = "Black Size 40";
            validateProdcut.CurrentPrice = decimal.Parse("22.33");
            var expected = true;
            var actual = validateProdcut.Validate();
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void ValidOrderTest()
        {
            var validOrder = new Order();
            validOrder.OrderDate = Convert.ToDateTime("10-03-2019");

            var expected = true;
            var actual = validOrder.Validate();

            Assert.AreEqual(expected,actual);

        }

        [TestMethod]
        public void ValidOrderItemTest()
        {
            var ValidOrderItem = new OrderItem();
     
            ValidOrderItem.OrderQuantity = 10;
            ValidOrderItem.ProductId = 1;
            ValidOrderItem.PurchasePrise = Convert.ToDecimal("20.00");
        }
    }
}
