using CustomerManagementSystem.Common.cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystem.BL
{
  public  class Order:EntityBase,ILoggable
    {
        public Order()
        {

        }
        public Order(int OrderId)
        {
            this.OrderId = OrderId;
        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string ShippingAddressId { get; set; }
        public DateTimeOffset? OrderDate { get; set; }
        public List<OrderItem> orderItems { get;set; }

     

        public override bool Validate()
        {
            bool IsValidOrder = true;

            if (OrderDate == null) IsValidOrder = false;
            return IsValidOrder;
        }

        public override string ToString()
        {
            return OrderDate.Value.Date + "(" + OrderId + ")";
        }

        public string Log()
        {
            var logString = this.CustomerId + " " + this.ShippingAddressId + " "+"Status:"+this.EntityState.ToString();
            return logString;
        }
    }
}
