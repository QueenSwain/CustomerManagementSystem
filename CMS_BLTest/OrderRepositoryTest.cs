using System;
using System.Collections.Generic;
using CustomerManagementSystem.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS_BLTest
{
    [TestClass()]
    public class OrderRepositoryTest
    {
        [TestMethod()]
        public void RetrieveOrderDispalyTest()
        {
            var orderRepository = new OrderRepository();
            var expected = new OrderDisplay()
            {
                FirstName = "Queen",
                LastName = "Swain",
                OrderDate = new DateTimeOffset(2019, 3, 2, 7, 0, 0, TimeSpan.Zero),
                ShippingAddress = new Address()
                {
                    AddressType = 1,
                    City = "BBSR",
                    Country = "India",
                    State = "Odisha",
                    StreetLine1 = "Lane no 8",
                    StreetLine2 = "Shukhmeswar Temple",
                    PostalCode = "751002"
                },

                orderDisplayItemList = new List<OrderDisplayItem>()
                {
                    new OrderDisplayItem()
                    {

                        ProductName = "Tshirt",
                        PurchasePrice = 15.55m,
                        OrderQuantity = 3
                    },
                    new OrderDisplayItem()
                    {
                         ProductName = "Pant",
                         PurchasePrice = 55.55m,
                         OrderQuantity = 3
                    }
                }
            };
            var actual = orderRepository.RetrieveOrderDisplay(1);

            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.OrderDate, actual.OrderDate);

            Assert.AreEqual(expected.ShippingAddress.AddressType,actual.ShippingAddress.AddressType);
            Assert.AreEqual(expected.ShippingAddress.StreetLine1, actual.ShippingAddress.StreetLine1);
            Assert.AreEqual(expected.ShippingAddress.StreetLine2, actual.ShippingAddress.StreetLine2);
            Assert.AreEqual(expected.ShippingAddress.City,actual.ShippingAddress.City);
            Assert.AreEqual(expected.ShippingAddress.Country,actual.ShippingAddress.Country);
            Assert.AreEqual(expected.ShippingAddress.State,actual.ShippingAddress.State);
            Assert.AreEqual(expected.ShippingAddress.PostalCode,actual.ShippingAddress.PostalCode);

            for(int i=0;i<1;i++)
            {
                Assert.AreEqual(expected.orderDisplayItemList[i].ProductName,actual.orderDisplayItemList[i].ProductName);
                Assert.AreEqual(expected.orderDisplayItemList[i].PurchasePrice,actual.orderDisplayItemList[i].PurchasePrice);
                Assert.AreEqual(expected.orderDisplayItemList[i].OrderQuantity, actual.orderDisplayItemList[i].OrderQuantity);
                
            }

        }
    }
}
