using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    public delegate void AccountStateHandler(object sender, AccountEventArgs e);

    public class AccountEventArgs
    {
        /// <summary>
        /// Message event
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Change sum
        /// </summary>
        public decimal Sum { get; set; }
        public AccountEventArgs(string _message, decimal _sum)
        {
            this.Message = _message;
            this.Sum = _sum;
        }
    }
}
