using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudMvc.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Designation { get; set; }
    }
}