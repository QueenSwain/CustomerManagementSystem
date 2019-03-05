using CustomerManagementSystem.Common.cs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagementSystem.BL
{


    //1.Customer -------------->  Name, Email Address, Home Address, Work Address
    // 2.Products----------------> Product Name, Description, Current Price 
    // 3.Orders-------------------> Customer, Order date, Shipping address 
    // 4.Order Item--------------> Products, Purchase Price, Quantities


    public class Customer:EntityBase,ILoggable
    {
        public Customer():this(0) //here default consturctor calling parameterized constructer.This is called Constructer chaining
        {

        }
        public Customer(int customerId)
        {
           // this.CustomerId = customerId;

            AddressList= new List<Address>();
        }
        public static int StaticInstanceCount { get; set; }
        public int CustomerType { get; set; }
        public string FirstName { get; set; }

        private string _lastname;
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }


        public string FullName
        {
            get
            {
                string FullName = FirstName;
                if (!string.IsNullOrWhiteSpace(LastName))
                {
                    if (!string.IsNullOrWhiteSpace(FirstName))
                    {
                        FullName += " ";
                    }
                    FullName += LastName;
                }
                return FullName;
            }
        }

        public string EmailId { get; set; }
        public int CustomerId { get; private set; }
        public string HomeAddress { get; set; }
        public string WorkAddress { get; set; }
        public List<Address> AddressList{get;set;}

        public override bool Validate()
        {
            var IsValid = true;
            if (string.IsNullOrWhiteSpace(FirstName)) IsValid = false;
            if (string.IsNullOrWhiteSpace(LastName)) IsValid = false;

            return IsValid;
        }

        public override string ToString()
        {
            return FirstName+LastName;
        }

        public string Log()
        {
            var logString = this.CustomerId + " " + this.FullName + " " + "Email:" + this.EmailId + " ";
            return logString;
        }
    }
}