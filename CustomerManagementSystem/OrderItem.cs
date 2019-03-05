using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystem.BL
{
   public class OrderItem
    {

        public OrderItem()
        {

        }
        public OrderItem(int orderItemId)
        {
            this.OrderItemId = orderItemId;
            
        }

        public int OrderItemId { get;private set; }
        public int OrderQuantity { get; set; }
        public int ProductId { get; set; }
        public decimal? PurchasePrise { get; set; }
       

        public OrderItem Retrieve(int OrderItemId)
        {
            return new OrderItem();
        }

        public List<OrderItem> Retrieve()
        {
            return new List<OrderItem>();
        }

        public bool Save()
        {
            return true;
        }

        public bool ValidateOrderItem()
        {
            bool IsvalidOrderItemm = true;

            if (ProductId <= 0) IsvalidOrderItemm = false;
            if (OrderQuantity <= 0) IsvalidOrderItemm = false;
            if (PurchasePrise == null) IsvalidOrderItemm = false;

            return IsvalidOrderItemm;
        }
    }
}
