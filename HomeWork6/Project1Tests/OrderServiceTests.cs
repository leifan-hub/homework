using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace HomeWork5.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            OrderService orderService = new OrderService();
            Order order = new Order { ClientName = "Bob",OrderId=1, };
            orderService.Orders = new List<Order>();
            orderService.AddOrder(order);
            Assert.IsNotNull(orderService.GetOrderByOrderId(1));
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            OrderService orderService = new OrderService();
            Order order = new Order { ClientName = "Bob", OrderId = 1, };
            orderService.Orders = new List<Order>();
            orderService.AddOrder(order);
            orderService.RemoveOrder(order);
            Assert.IsFalse(orderService.FindOrderByClientName("bob").Any());   
        }

        [TestMethod()]
        public void RemoveAllOrdersTest()
        {
            OrderService orderService = new OrderService();
            Order order = new Order { ClientName = "Bob", OrderId = 1, };
            orderService.Orders = new List<Order>();
            orderService.AddOrder(order);
            orderService.RemoveAllOrders();
            Assert.IsFalse(orderService.Orders.Any());
        }

        [TestMethod()]
        public void GetOrderByOrderIdTest()
        {
            OrderService orderService = new OrderService();
            Order order = new Order { ClientName = "Bob", OrderId = 1, };
            orderService.Orders = new List<Order>();
            orderService.AddOrder(order);
            Assert.IsTrue(orderService.GetOrderByOrderId(1).OrderId==1);
            Assert.IsNull(orderService.GetOrderByOrderId(2));
        }

        [TestMethod()]
        public void FindOrderByClientNameTest()
        {
            OrderService orderService = new OrderService();
            Order order = new Order { ClientName = "Bob", OrderId = 1, };
            orderService.Orders = new List<Order>();
            order.OrderItems = new List<OrderItem>();
            orderService.AddOrder(order);
            Assert.IsTrue(orderService.FindOrderByClientName("Bob").Any());
            Assert.IsFalse(orderService.FindOrderByClientName("Jim").Any());
        }

        [TestMethod()]
        public void FindOrderByProductsBrandTest()
        {
            OrderService orderService = new OrderService();
            Order order = new Order { ClientName = "Bob", OrderId = 1, };
            OrderItem od1 = new OrderItem(Products.apple, 2, 4000);
            orderService.Orders = new List<Order>();
            order.OrderItems = new List<OrderItem>();
            order.AddOrderItem(od1);
            orderService.AddOrder(order);
            Assert.IsTrue(orderService.FindOrderByProductsBrand(Products.apple).Any());
            Assert.IsFalse(orderService.FindOrderByProductsBrand(Products.banana).Any());
        }

        [TestMethod()]
        public void SortOrdersTest()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order
            {
                OrderId = 1,
                ClientName = "Bob",
                OrderItems = new List<OrderItem>(),
            };
            Order order2 = new Order
            {
                OrderId = 2,
                ClientName = "Tom",
                OrderItems = new List<OrderItem>(),
            };
            Order order3 = new Order
            {
                OrderId = 3,
                ClientName = "Alice",
                OrderItems = new List<OrderItem>(),
            };
            Order order4 = new Order
            {
                OrderId = 4,
                ClientName = "Alex",
                OrderItems=new List<OrderItem>(),
            };
            orderService.Orders = new List<Order>();
            orderService.AddOrder(order3);
            orderService.AddOrder(order1);
            orderService.AddOrder(order4);
            orderService.AddOrder(order2);
            int num = 1;
            foreach(Order order in orderService.SortOrders(orderService.Orders)){
                Assert.IsTrue(order.OrderId ==num);
                num++;
            }
            
        }

        [TestMethod()]
        public void ExportTest()
        {
            OrderService orderService = new OrderService();
            orderService.Orders = new List<Order>();
            Order order1 = new Order
            {
                OrderId = 1,
                ClientName = "Bob",
                OrderItems = new List<OrderItem>(),
            };
            Order order2 = new Order
            {
                OrderId = 2,
                ClientName = "Tom",
                OrderItems = new List<OrderItem>(),
            };
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.Export(orderService.Orders);
            FileStream fs = new FileStream("order.xml",FileMode.Open);
            Assert.IsTrue(fs.CanWrite);
        }
        [TestMethod()]
        public void ImportTest()
        {
            Thread.Sleep(1000);
            OrderService orderService = new OrderService();
            orderService.Orders = new List<Order>();
            Order order1 = new Order
            {
                OrderId = 1,
                ClientName = "Bob",
                OrderItems = new List<OrderItem>(),
            };
            Order order2 = new Order
            {
                OrderId = 2,
                ClientName = "Tom",
                OrderItems = new List<OrderItem>(),
            };
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.Export(orderService.Orders);
            orderService.Import("order.xml");
            Assert.IsTrue(orderService.Orders.Count==4);
        }
    }
}