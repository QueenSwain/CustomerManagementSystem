using System;
using System.Collections.Generic;
using CustomerManagementSystem.BL;
using CustomerManagementSystem.Common.cs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerMangementCommonTest
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void WriteToFileTest()
        {
            var ChangeItems = new List<ILoggable>();
            var customer = new Customer(1)
            {
                EmailId = "queen123@gmail.com",
                FirstName = "Sashi",
                LastName = "Laal"
            };
            ChangeItems.Add(customer as ILoggable);

            var product = new Product()
            {
                ProductName = "Perfume",
                Description = "Flower Fragrence",
                CurrentPrice = 45.00m
            };
            ChangeItems.Add(product as ILoggable); //added products using ILoggable
            LoggingService.WriteToFile(ChangeItems);
        }
        
    }
}
