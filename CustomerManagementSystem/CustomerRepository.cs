using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomerManagementSystem.BL
{
  public  class CustomerRepository
    {
        private AddressRepository addressRepository { get; set; }

        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }
        public Customer Retrieve(int customerId)
        {
            Customer customer = new Customer(customerId);
            customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList(); //list of address
            if(customerId==1)
            {
                customer.EmailId = "queen123@gmail.com";
                customer.FirstName = "Sashi";
                customer.LastName = "Laal";
                //customer.HomeAddress = "Odisha";
                //customer.WorkAddress = "Bangalore";
            }
            return customer;
        }

        //retrieves all customer
        public List<Customer> Retrieve()
        {
            return new List<Customer>();
        }

        public bool Save()
        {
            return true;
        }

        
    }
}
