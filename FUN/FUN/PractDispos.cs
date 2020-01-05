using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUN
{
    public class PractDispos : IDisposable
    {
        private bool disposed = false;


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Clear managed resources");
                }
                Console.WriteLine("Clear unmanaged resources");
                disposed = true;
            }
        }

        ~PractDispos()
        {
            Dispose(false);
        }
    }
}
