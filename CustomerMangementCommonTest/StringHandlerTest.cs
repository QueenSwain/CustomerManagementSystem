using System;
using CustomerManagementSystem.Common.cs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerMangementCommonTest
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpaceTestValid()
        {

            //arrange
            var Source = "QueenSwain";
            var expected = "Queen Swain";


            //act
            // var actual = StringHandler.InsrtSpaces(Source); //using static method 
            var actual = Source.InsrtSpaces();  //using extensionmethod
            //assert
            Assert.AreEqual(expected,actual);
        }
    }
}
