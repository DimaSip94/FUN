using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUN
{
    public class SemaphorePract
    {
        //есть некоторое число читателей, которые приходят в библиотеку три раза в день и что-то там читают. 
        //И пусть у нас будет ограничение, что единовременно в библиотеке не может находиться больше трех читателей.

    }

    public class ReaderLib_semaphore
    {
        static Semaphore semaphore = new Semaphore(3, 3);
        Thread myThread;
        int count = 3;

        public ReaderLib_semaphore(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Читатель {i.ToString()}";
            myThread.Start();
        }

        private void Read()
        {
            while (count > 0)
            {
                semaphore.WaitOne();
                Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");
                Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                Thread.Sleep(1000);
                Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");
                semaphore.Release();
                count--;
                Thread.Sleep(1000);
            }
        }
    }
}
