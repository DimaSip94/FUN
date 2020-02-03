using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUN
{
    public class MonitorTickTock
    {
        private object lockOn = new object();

        public void Tick(bool running)
        {
            lock (lockOn)
            {
                if (!running)
                {
                    //Stop 
                    Monitor.Pulse(lockOn);
                    return;
                }
                Console.WriteLine("Tick");
                Thread.Sleep(1000);
                //access Tock
                Monitor.Pulse(lockOn);
                // wait Tock
                Monitor.Wait(lockOn);
            }
            
        }

        public void Tock(bool running)
        {
            lock (lockOn)
            {
                if (!running)
                {
                    //Stop 
                    Monitor.Pulse(lockOn);
                    return;
                }
                Console.WriteLine("Tock");
                Thread.Sleep(1000);
                //access Tick
                Monitor.Pulse(lockOn);
                // wait Tick
                Monitor.Wait(lockOn);
            }
        }
    }

    public class MyThread
    {
        public Thread thrd;
        MonitorTickTock ttobj;

        // Новый поток
        public MyThread(string name, MonitorTickTock tt)
        {
            thrd = new Thread(this.Run);
            ttobj = tt;
            thrd.Name = name;
            thrd.Start();
        }

        private void Run()
        {
            if (thrd.Name == "Tick")
            {
                for (int i = 0; i < 5; i++)
                {
                    ttobj.Tick(true);
                }
                ttobj.Tick(false);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    ttobj.Tock(true);
                }
                ttobj.Tock(false);
            }
        }
    }

    //TickTock tt = new TickTock();
    //MyThread mt1 = new MyThread("Tick", tt);
    //MyThread mt2 = new MyThread("Tock", tt);
    //mt1.thrd.Join();
    //        mt2.thrd.Join();

    //        Console.WriteLine("Часы остановлены");
    //        Console.ReadLine();
}
