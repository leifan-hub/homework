using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] temp = new int[99];
            for(int m = 2; m <= 100; m++)
            {
                temp[m - 2] = m;
            }
            getNum(temp);
            Console.WriteLine("2到100以内的质数有：");
            foreach(int k in temp)
            {
                if(k!=0)
                    Console.WriteLine(k);
            }
              void getNum(int[] a)
            {
                for (int n = 2; n * n <= 100; n++)
                {
                    for (int x = 2; x < a.Length; x++)
                    {
                        if (a[x] % n == 0) a[x] = 0;
                    }
                }
            }
        }
    }
}
