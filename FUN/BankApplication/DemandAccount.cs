using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    public class DemandAccount:Account
    {
        public DemandAccount(decimal sum, int perc):base(sum, perc)
        {
            
        }

        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"Opened new Demand Account! ID:{this.Id}", this.Sum));  
        }
    }
}
