using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUN
{

    class Program
    {       
        static void Main(string[] args)
        {
            MonitorTickTock tt = new MonitorTickTock();
            MyThread mt1 = new MyThread("Tick", tt);
            MyThread mt2 = new MyThread("Tock", tt);
            mt1.thrd.Join();
            mt2.thrd.Join();

            Console.WriteLine("Часы остановлены");
            Console.ReadLine();
        }
    }
}
