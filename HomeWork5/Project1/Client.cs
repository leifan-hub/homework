using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    enum Products
    {
        orange,
        banana,
        apple,
        pear,
        peach
    };        

    class Client
    {
        static void Main(string[] args)
        {
            OrderItem od1 = new OrderItem(Products.apple,2,4000);
            OrderItem od2 = new OrderItem(Products.banana, 1, 3200);
            OrderItem od3 = new OrderItem(Products.orange, 3, 3500);
            OrderItem od4 = new OrderItem(Products.peach, 2, 3800);
            
            Order order1 = new Order
            {
                OrderId = 1,
                ClientName = "Bob",
            };
            Order order2 = new Order
            {
                OrderId = 2,
                ClientName = "Tom",
            };
            Order order3 = new Order
            {
                OrderId = 3,
                ClientName = "Alice",
            }; Order order4 = new Order
            {
                OrderId =4,
                ClientName = "Alex",
            };
            
            order1.OrderItems = new List<OrderItem>();
            order1.AddOrderItem(od1);
            order2.OrderItems = new List<OrderItem>();
            order2.AddOrderItem(od1);
            order2.AddOrderItem(od2);
            order3.OrderItems = new List<OrderItem>();
            order3.AddOrderItem(od1);
            order3.AddOrderItem(od2);
            order3.AddOrderItem(od3);
            order4.OrderItems = new List<OrderItem>();
            order4.AddOrderItem(od1);
            order4.AddOrderItem(od2);
            order4.AddOrderItem(od3);
            order4.AddOrderItem(od4);
            //订单服务,添加了两个订单
            OrderService orderService = new OrderService
            {
                Orders = new List<Order>()
            };
            orderService.AddOrder(order1);
            orderService.AddOrder(order1);
            orderService.AddOrder(order3);
            orderService.AddOrder(order4);

            //订单删除条目
            try
            {
                order1.RemoveOrderItem(order1.OrderItems[0]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
            orderService.RemoveOrder(order1);
            orderService.FindOrderByClientName("Tom");
            orderService.FindOrderByProductsBrand(Products.apple);
        }
    }
}
