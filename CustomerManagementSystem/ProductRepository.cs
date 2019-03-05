using System;
using System.Collections.Generic;
using System.Text;


namespace CustomerManagementSystem.BL
{
   public class ProductRepository
    {
        public Product Retrieve(int productId)
        {
            Product product = new Product(productId);
            Object fg = new object();
            Console.WriteLine("object:"+fg.ToString());
            Console.WriteLine("product:"+product.ToString()); //all the methods-ex here ToString() are derived from system.object .Implicitly used th eobject class or inherit from object class
            if(productId==2)
            {
                product.ProductName = "Perfume";
                product.Description = "Flower Fragrence";
                product.CurrentPrice = 45.00m;
            }
            return product;
        }

        //returns the list of product
        public List<Product> Retrieve()
        {
            return new List<Product>();
        }



        public bool Save(Product product)
        {
            var Success = true;
            if(product.HasChange && product.IsValid)  //calling HasChange and Isvalid properties from EntityBase.cs
            {
                if(product.IsNew)
                {
                    //Call an Insert SP
                }
                else
                {
                    //Call an Update SP
                }

            }
            return Success;
        }
    }
}
