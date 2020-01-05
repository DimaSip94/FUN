using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUN
{
    public class MutexPractice
    {
        //есть некоторое число читателей, которые приходят в библиотеку три раза в день и что-то там читают. 
        //И пусть у нас будет ограничение, что единовременно в библиотеке не может находиться больше трех читателей.
    }

    public class ReaderLib_mutex
    {
        static Mutex mutexObj = new Mutex();
        static int x = 0;
        Thread myThread;

        public ReaderLib_mutex(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Читатель {i.ToString()}";
            myThread.Start();
        }

        private void Read()
        {
            mutexObj.WaitOne();
            x = 1;
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
            mutexObj.ReleaseMutex();
        }
    }
}
