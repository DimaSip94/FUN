using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    public abstract class Account : IAccount
    {

        protected internal event AccountStateHandler Withdrawed;
        protected internal event AccountStateHandler Added;
        protected internal event AccountStateHandler Opened;
        protected internal event AccountStateHandler Closed;
        protected internal event AccountStateHandler Calculated;

        static int counter = 0;
        protected int _days = 0; //days after open account

        // Current sum
        public decimal Sum { get; private set; }
        // Percent
        public int Percentage { get; private set; }
        // ID
        public int Id { get; private set; }

        public Account(decimal sum, int percentage)
        {
            Sum = sum;
            Percentage = percentage;
            Id = ++counter;
        }

        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if (e != null)
            {
                handler?.Invoke(this, e);
            }
        }

        //Events
        protected virtual void OnOpened(AccountEventArgs e)
        {
            CallEvent(e, Opened);
        }
        protected virtual void OnClosed(AccountEventArgs e)
        {
            CallEvent(e, Closed);
        }
        protected virtual void OnCalculated(AccountEventArgs e)
        {
            CallEvent(e, Calculated);
        }
        protected virtual void OnAdded(AccountEventArgs e)
        {
            CallEvent(e, Added);
        }
        protected virtual void OnWithdrawed(AccountEventArgs e)
        {
            CallEvent(e, Withdrawed);
        }



        public virtual void Put(decimal sum)
        {
            Sum += sum;
            OnAdded(new AccountEventArgs($"Added to account {sum}", sum));
        }

        public virtual decimal Withdraw(decimal sum)
        {
            decimal result = 0;
            if (Sum >= sum)
            {
                Sum -= sum;
                result = sum;
                OnWithdrawed(new AccountEventArgs($"Withdrawed from account {sum}", sum));
            }
            else
            {
                OnWithdrawed(new AccountEventArgs($"Not enough money!", sum));
            }
            return result;
        }

        protected internal virtual void Open()
        {
            OnOpened(new AccountEventArgs($"Opened new account! Id: {Id}", Sum));
        }
        // закрытие счета
        protected internal virtual void Close()
        {
            OnClosed(new AccountEventArgs($"The account {Id} is closed.  Total: {Sum}", Sum));
        }

        protected internal void IncrementDays()
        {
            _days++;
        }
        // начисление процентов
        protected internal virtual void Calculate()
        {
            decimal increment = Sum * Percentage / 100;
            Sum = Sum + increment;
            OnCalculated(new AccountEventArgs($"Accrued interest in the amount of: {increment}", increment));
        }
    }
}
