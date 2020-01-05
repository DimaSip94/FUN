using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    public interface IAccount
    {
        /// <summary>
        /// Put money on account
        /// </summary>
        /// <param name="sum"></param>
        void Put(decimal sum);

        /// <summary>
        /// Withdraw some money from account
        /// </summary>
        /// <param name="sum"></param>
        decimal Withdraw(decimal sum);
    }
}
