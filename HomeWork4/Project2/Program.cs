using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Project2
{
    public delegate void TickHandler( );
    public delegate void AlarmHandler( );

    public class Clock
    {
        public event TickHandler onTick;
        public event AlarmHandler onAlarm;
        public void startWork()
        {
            for(int n=1;n<=10;n++)
            {
                Console.WriteLine($"当前的时间是：{DateTime.Now.ToString()}");
                onTick();
                if (n % 3 == 0)
                {
                    onAlarm();
                }
                Thread.Sleep(1000);
            } 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            clock.onTick += new TickHandler(Clock_onTick);
            clock.onAlarm += new AlarmHandler(Clock_onAlarm);
            clock.startWork();

            void Clock_onTick()
            {
                Console.WriteLine("闹钟正在走时");
            }

            void Clock_onAlarm()
            {
                Console.WriteLine("闹钟响了");
            }
        }
    }
}

