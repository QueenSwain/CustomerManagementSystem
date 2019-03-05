using System;
using System.Collections.Generic;
using CustomerManagementSystem.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace CMS_BLTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveCustomerTest()
        {
            var customerRepositry = new CustomerRepository();
            var expected = new Customer(1) //cosnturcter overload -takes single parameter
            {
             EmailId = "queen123@gmail.com",
             FirstName = "Sashi",
             LastName = "Laal",
          //   HomeAddress = "Odisha",
             //WorkAddress = "Bangalore"
        };
            var actual = customerRepositry.Retrieve(1);

            Assert.AreEqual(expected.CustomerId,actual.CustomerId);
            Assert.AreEqual(expected.EmailId, actual.EmailId);
            Assert.AreEqual(expected.FirstName,actual.FirstName);
            Assert.AreEqual(expected.LastName,actual.LastName);
            //Assert.AreEqual(expected.HomeAddress,actual.HomeAddress);
           //Assert.AreEqual(expected.WorkAddress,expected.WorkAddress);
        }

        [TestMethod]
        public void RetrieveProductTest()
        {
            //arrange
            ProductRepository productRepository = new ProductRepository();
            var expected = new Product()
            {
             ProductName = "Perfume",
             Description = "Flower Fragrence",
             CurrentPrice = 45.00m
        };
            //Act
            var actual = productRepository.Retrieve(2);

            //Assert
            Assert.AreEqual(expected.ProductName,actual.ProductName);
            Assert.AreEqual(expected.Description,actual.Description);
            Assert.AreEqual(expected.CurrentPrice,actual.CurrentPrice);
        }

        [TestMethod]
        public void RetrieveOrderTest()
        {
            OrderRepository orderRepository = new OrderRepository();
            var expected = new Order(10)
            {
                OrderDate = new DateTimeOffset(2019, 3, 2, 7, 0, 0, TimeSpan.Zero)
            };

            var actual = orderRepository.Retrieve(10);

            Assert.AreEqual(expected.OrderDate,actual.OrderDate);
        }

        [TestMethod]
        public void RetrieveAddressTest()
        {
            AddressRepository addressRepository = new AddressRepository();
            var expected = new Address(2)
            {
             AddressType = 1,
             City = "BBSR",
             Country = "India",
             State = "Odisha",
             StreetLine1 = "Lane no 8",
             StreetLine2 = "Shukhmeswar Temple",
             PostalCode = "751002"
        };

            var actual = addressRepository.Retrieve(2);

            Assert.AreEqual(expected.AddressType,actual.AddressType);
            Assert.AreEqual(expected.City, actual.City);
            Assert.AreEqual(expected.Country,actual.Country);
            Assert.AreEqual(expected.State,actual.State);
            Assert.AreEqual(expected.StreetLine1,actual.StreetLine1);
            Assert.AreEqual(expected.StreetLine2,actual.StreetLine2);
            Assert.AreEqual(expected.PostalCode,actual.PostalCode);
        }


        [TestMethod]
         public void RetrieveExistingWithAddress()
         {
            var customerRepositry = new CustomerRepository();
            var expected = new Customer()
            {
                EmailId = "queen123@gmail.com",
                FirstName = "Sashi",
                LastName = "Laal",
                AddressList = new List<Address>()
                {
                    new Address()
                    {
                        AddressType =1,
                        City = "BBSR",
                         Country = "India",
                         State = "Odisha",
                         StreetLine1 = "Lane no 8",
                         StreetLine2 = "Shukhmeswar Temple",
                         PostalCode = "751002"
                    },
                    new Address()
                    {
                        AddressType = 2,
                        City = "dfg",
                        Country = "f",
                        State = "f",
                        StreetLine1 = "f no 8",
                        StreetLine2 = "f Temple",
                        PostalCode = "751001"
                    }

                }

            };
            var actual = customerRepositry.Retrieve(1);

                Assert.AreEqual(expected.CustomerId, actual.CustomerId);
                Assert.AreEqual(expected.EmailId, actual.EmailId);
                Assert.AreEqual(expected.FirstName, actual.FirstName);
                Assert.AreEqual(expected.LastName, actual.LastName);

            for (int i=0;i<1;i++)
            {
                Assert.AreEqual(expected.AddressList[i].AddressType,actual.AddressList[i].AddressType);
                Assert.AreEqual(expected.AddressList[i].City,actual.AddressList[i].City);
                Assert.AreEqual(expected.AddressList[i].Country,actual.AddressList[i].Country);
                Assert.AreEqual(expected.AddressList[i].State,actual.AddressList[i].State);
                Assert.AreEqual(expected.AddressList[i].StreetLine1,actual.AddressList[i].StreetLine1);
                Assert.AreEqual(expected.AddressList[i].StreetLine2,actual.AddressList[i].StreetLine2);
                Assert.AreEqual(expected.AddressList[i].PostalCode,actual.AddressList[i].PostalCode);
            }
        }

    }
}
