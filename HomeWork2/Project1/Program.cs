using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            int input, temp = 2;
            Console.Write("Please type a number:");
            try
            {
                input = Int32.Parse(Console.ReadLine());
           

            if (input <= 1)
                Console.WriteLine("它没有素数因子！");
                Console.WriteLine("它的素数因子有:");
            while (input > 1)
            {
                if (input % temp == 0)
                {
                    input /= temp;
                    Console.WriteLine(temp);
                }
                else temp++;
            }
            }
            catch(OverflowException e)
            {
                throw e;
            }
        }
    }
}
