using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    [Serializable]
    public class Order
    {
        public string ClientName { get; set; }
        public int OrderId { set; get; }
        public double OrderPrice
        {
            get
            {
                double sum=0;
                foreach(OrderItem orderItem in OrderItems)
                {
                    sum += orderItem.ProductsNum * orderItem.Price;
                }
                return sum;
            }
        }
        public List<OrderItem> OrderItems { set; get; }

        public void AddOrderItem(OrderItem orderItem)
        {
            bool flag = false;
            foreach (OrderItem _orderItem in OrderItems)
            {
                flag = flag|_orderItem.Equals(orderItem);
            }
            if (flag == false)
                this.OrderItems.Add(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
             this.OrderItems.Remove(orderItem);
        } 

        public void ClearOrderItems()
        {
             OrderItems.Clear();
        } 

        public override string ToString()
        {
            return ClientName +" "+ OrderId +" "+ OrderPrice;
        }

        public override bool Equals(object obj)
        {
            Order orderTemp = (Order)obj;
            return obj!=null &&
                   this.OrderId == orderTemp.OrderId;                
        }

        public override int GetHashCode()
        {
            var hashCode = -1463918288;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ClientName);
            hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(OrderItems);
            return hashCode;
        }
    }
}
