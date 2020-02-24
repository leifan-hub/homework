using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("请输入数组元素个数及相应的值：");
            n = int.Parse(Console.ReadLine());
            double[] a = new double[n];
            try { 
            for (int i = 0; i < n; i++)
            {
                a[i] = double.Parse(Console.ReadLine());
            }
                }
            catch(OverflowException e)
            {
                throw e;
            }
            double min, max, sum, aver;
            Caculate(a,out min,out max,out sum,out aver);
            
            Console.WriteLine($"最大值：{max}");
            Console.WriteLine($"最小值：{min}");
            Console.WriteLine($"平均值：{aver}");
            Console.WriteLine($"和值：{sum}");
        }

        private static void Caculate(double[] a, out double min, out double max, out double sum, out double aver)
        {
            min = max = a[0];
            sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < min) min = a[i];
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max) max = a[i];
            }
            for (int i = 0; i < a.Length; i++)
            {
                sum = sum + a[i];
            }
            aver = sum / a.Length;
        }
    }
}
