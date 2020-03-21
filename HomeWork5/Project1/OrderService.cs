using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class OrderService
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
            return selectedOrders.First();
        }

        public IEnumerable<Order> FindOrderByClientName(string clientName)
        {
            var selectedOrders = Orders.Where(order => order.ClientName == clientName).OrderBy(order => order.OrderPrice);
            return selectedOrders;
        }

        public IEnumerable<Order> FindOrderByProductsBrand(Products brand)
        {
            List<Order> selectedOrders = new List<Order>();
            foreach (Order order in Orders)
            {
                var selectedOrderItems = order.OrderItems.Where(orderItem => orderItem.Brand == brand);
                if (selectedOrderItems.First() != null)
                {
                    selectedOrders.Add(order);
                }
            }
            return selectedOrders.OrderBy(order => order.OrderPrice);
        }

        public IEnumerable<Order> SortOrders(List<Order> orders)
        {
            return orders.OrderBy(order => order.OrderId);
        }
    }
}
