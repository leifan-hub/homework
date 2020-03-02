using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public interface Shape
    {
        double CalculateArea();
        bool IsShape();
    }

    class Square : Shape
    {
       public Square(double x,double y) { this.Long = x;this.Wide = y; }
        double Long { set; get; }
        double Wide { set; get; }
        public bool IsShape()
        {
            return (this.Long == this.Wide)&&(this.Long>0);
        }
        public double CalculateArea()
        {
            return (this.Wide * this.Long);
        }
    }

    class Rectangle : Shape
    {
        public Rectangle(double x, double y) { this.Long = x; this.Wide = y; }
        double Long { set; get; }
        double Wide { set; get; }
        public bool IsShape()
        {
            return (this.Long != this.Wide)&&(this.Long>0)&&(this.Wide>0);
        }
        public double CalculateArea()
        {
           return (this.Wide * this.Long);
        }
    }

    class Triangle : Shape
    {
        public Triangle(double x, double y,double z) { this.Edge1 = x; this.Edge2 = y;this.Edge3 = z; }
        double Edge1 { set; get; }
        double Edge2 { set; get; }
        double Edge3 { set; get; }
        public bool IsShape()
        {
            bool flag = (this.Edge1 + this.Edge2 > this.Edge3) && (this.Edge1 + this.Edge3 > this.Edge2) && (this.Edge2 + this.Edge3 > this.Edge1);
            return flag&&(this.Edge1>0)&&(this.Edge2>0)&&(this.Edge3>0);
        }
        public double CalculateArea()
        {
            double p = (this.Edge1 + this.Edge2 + this.Edge3) / 2;
            double area = Math.Sqrt(p*(p-this.Edge1)*(p-this.Edge2)*(p-this.Edge3));
            return area;
        }
    }

    class Factory
    {
        public  static Shape CreateShape(int num, double x, double y, double z=0)
        {
            switch (num)
            {
                case 0: return new Square(x, y);                   
                case 1: return new Rectangle(x,y);
                case 2: return new Triangle(x,y,z);
                default:return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double sumArea = 0;
            try
            {
                for (int x = 0; x < 10; x++)
                {
                    int temp = new Random(Guid.NewGuid().GetHashCode()).Next(1, 10) % 3;
                    int m = new Random(Guid.NewGuid().GetHashCode()).Next(1, 10);
                    int n = new Random(Guid.NewGuid().GetHashCode()).Next(1, 10);
                    int k = new Random(Guid.NewGuid().GetHashCode()).Next(1, 10);
                    Shape shape = Factory.CreateShape(temp, m, n, k);
                    sumArea = sumArea + (shape.IsShape() ? shape.CalculateArea() : 0);
                }
            }
            catch (OverflowException e)
            {
                throw e;
            }
            Console.WriteLine($"面积总和为：{sumArea}");
        }
    }
}
