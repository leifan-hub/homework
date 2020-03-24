using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HomeWork5
{
    public class OrderService
    {
        public List<Order> Orders { set; get; }

        public void AddOrder(Order order)
        {
            bool flag = false;
            foreach (Order _order in Orders)
            {
                flag = _order.Equals(order);
                if (flag)
                    break;
            }
            if (flag == false)
            {
                Orders.Add(order);
            }
        }

        public void RemoveOrder(Order order)
        {
            Orders.Remove(order);
        }

        public void RemoveAllOrders()
        {
            Orders.Clear();
        } 

        public Order GetOrderByOrderId(int id)
        {
            var selectedOrders = Orders.Where(order => order.OrderId == id);
            return selectedOrders.FirstOrDefault();
        }

        public IEnumerable<Order> FindOrderByClientName(string clientName)
        {
            var selectedOrders = Orders.Where(order => order.ClientName == clientName).OrderBy(order => order.OrderPrice);
            return selectedOrders;
        }

        public IEnumerable<Order> FindOrderByProductsBrand(Products brand)
        {
            var selectedOrders = Orders.Where(order => order.OrderItems.Exists(orderItem => orderItem.Brand == brand)).OrderBy(order => order.OrderPrice); ;
            return selectedOrders;
        }

        public IEnumerable<Order> SortOrders(List<Order> orders)
        {
            return orders.OrderBy(order => order.OrderId);
        }

        public void Export(List<Order> orders)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("order.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orders);
            }
        }

        public void Import(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream((filePath), FileMode.Open))
            {
                List<Order> newOrders=(List<Order>)xmlSerializer.Deserialize(fs);
                foreach(Order order in newOrders)
                {
                    Orders.Add(order);
                }
            }
        }
    }
}
