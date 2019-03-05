using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystem.BL
{
    public class AddressRepository
    {
     
        public Address Retrieve(int addressId)
        {
            Address address = new Address();
            if(addressId==2)
            {
                address.AddressType =1;
                address.City = "BBSR";
                address.Country = "India";
                address.State = "Odisha";
                address.StreetLine1 = "Lane no 8";
                address.StreetLine2 = "Shukhmeswar Temple";
                address.PostalCode = "751002";
            }
            
            return address;
        }

        public IEnumerable<Address> RetrieveByCustomerId(int customerId)  //returns list of address
        {
            var AddressList = new List<Address>();
            Address address = new Address(1)
            {
                AddressType =1,
                City = "BBSR",
                Country = "India",
                State = "Odisha",
                StreetLine1 = "Lane no 8",
                StreetLine2 = "Shukhmeswar Temple",
                PostalCode = "751002"
            };
            AddressList.Add(address);

            address=new Address(2)
            {
                AddressType = 2,
                City = "dfg",
                Country = "f",
                State = "f",
                StreetLine1 = "f no 8",
                StreetLine2 = "f Temple",
                PostalCode = "751001"
            };
            AddressList.Add(address);
            return AddressList;
        }
        public bool Save()
        {
            return true;
        }
        
    }
}
