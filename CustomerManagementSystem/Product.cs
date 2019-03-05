using CustomerManagementSystem.Common.cs;
using System;
using System.Collections.Generic;
using System.Text;


namespace CustomerManagementSystem.BL
{
   public class Product:EntityBase,ILoggable
    {
        public Product()
        {

        }
        public Product(int productId)
        {
            this.ProductId = productId;
            
        }

            private string _ProductName;
        public string ProductName
        {
            get
            {
              //  return StringHandler.InsrtSpaces(_ProductName); //can use the method of the class of another project using the static concept without creating new instance.
                return _ProductName.InsrtSpaces(); //using extension method 
            }
            set
            { _ProductName = value; }
        }

            public int ProductId { get;private set; }
            public string Description { get; set; }
            public Decimal? CurrentPrice { get; set; }

        public override bool Validate()
        //A derived class cannot override the base class if it will not allows.To allow override in child class the base class should declare as abstract or virtual 
        {
            var IsValid = true;
            if (string.IsNullOrWhiteSpace(ProductName)) IsValid = false;
            if (CurrentPrice==null) IsValid = false;

            return IsValid;
        }

        public override string ToString()  //to make debugging easier we have created override tostring() method
        {
            return ProductName+Description+CurrentPrice;

        }
        public string Log()
        {
            var logString = this.ProductId + " " + this.ProductName + " " + "Details:" + this.Description + " ";
            return logString;
        }

    }
}
