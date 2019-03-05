using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystem.BL
{
    public class OrderRepository
    {
       
        public bool Save()
        {
            return true;
        }
        public Order Retrieve(int OrderId)
        {
            Order order = new Order(OrderId);
            if(OrderId==10)
            {
                order.OrderDate = new DateTimeOffset(2019, 3,2, 7, 0, 0, TimeSpan.Zero);
            }
           
            return order;
        }
        public OrderDisplay RetrieveOrderDisplay(int orderId)
        {
            OrderDisplay orderDisplay = new OrderDisplay();
            if(orderId==1)
            {
                orderDisplay.FirstName = "Queen";
                orderDisplay.LastName = "Swain";
                orderDisplay.OrderDate = new DateTimeOffset(2019, 3, 2, 7, 0, 0, TimeSpan.Zero);
                orderDisplay.ShippingAddress = new Address()
                {
                    AddressType = 1,
                    City = "BBSR",
                    Country = "India",
                    State = "Odisha",
                    StreetLine1 = "Lane no 8",
                    StreetLine2 = "Shukhmeswar Temple",
                    PostalCode = "751002"
                };
            }
            orderDisplay.orderDisplayItemList = new List<OrderDisplayItem>();
           //code that retrieves order Item
            if(orderId==1)
            {
                var orderDispalyItem = new OrderDisplayItem()
                {
                    ProductName = "Tshirt",
                    PurchasePrice = 15.55m,
                    OrderQuantity = 3
                };
                orderDisplay.orderDisplayItemList.Add(orderDispalyItem);

                orderDispalyItem = new OrderDisplayItem()
                {
                    ProductName = "Pant",
                    PurchasePrice = 55.55m,
                    OrderQuantity = 3
                };
                orderDisplay.orderDisplayItemList.Add(orderDispalyItem);


            }
            return orderDisplay;
        }
        public List<Order> Retrieve()
        {
            return new List<Order>();
        }
    }
}
