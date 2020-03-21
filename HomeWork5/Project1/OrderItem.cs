using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class OrderItem
    {
        internal Products Brand { get; set; }
        public int ProductsNum { get; set; }
        public double Price { get; set; }

        public OrderItem(Products brand, int productsNum, double price)
        {
            Brand = brand;
            ProductsNum = productsNum;
            Price = price;
        }

        public override string ToString()
        {
            return Brand + " " + ProductsNum + " " + Price;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderItem item &&
                   Brand == item.Brand &&
                   ProductsNum == item.ProductsNum &&
                   Price == item.Price;
        }

        public override int GetHashCode()
        {
            var hashCode = -510703613;
            hashCode = hashCode * -1521134295 + Brand.GetHashCode();
            hashCode = hashCode * -1521134295 + ProductsNum.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }

    }
}
