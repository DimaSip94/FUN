using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    // тип счета
    public enum AccountType
    {
        Ordinary,
        Deposit
    }

    public class Bank<T> where T:Account
    {
        T[] accounts;

        public string Name { get; private set; }
        public Bank(string name)
        {
            Name = name;
        }

        public void Open(AccountType accountType, decimal sum,
            AccountStateHandler addSumHandler, AccountStateHandler withdrawSumHandler,
            AccountStateHandler calculationHandler, AccountStateHandler closeAccountHandler,
            AccountStateHandler openAccountHandler)
        {
            T newAccount = null;
            switch (accountType)
            {
                case AccountType.Deposit:
                    newAccount = new DemandAccount(sum, 1) as T;
                    break;
                case AccountType.Ordinary:
                    newAccount = new DemandAccount(sum, 40) as T;
                    break;
            }

            if (newAccount == null)
                throw new Exception("Error create account");
            else
            {
                T[] tempAccounts = new T[accounts.Length + 1];
                for (int i = 0; i < accounts.Length; i++)
                    tempAccounts[i] = accounts[i];
                tempAccounts[tempAccounts.Length - 1] = newAccount;
                accounts = tempAccounts;
            }

            //add events handlers
            newAccount.Added += addSumHandler;
            newAccount.Calculated += calculationHandler;
            newAccount.Closed += closeAccountHandler;
            newAccount.Opened += openAccountHandler;
            newAccount.Withdrawed += withdrawSumHandler;

            newAccount.Open();
        }

        public void Put(decimal sum, int id)
        {
            T account = GetAccount(id);
            account.Put(sum);
        }

        public void Withdraw(decimal sum, int id)
        {
            T account = GetAccount(id);
            account.Withdraw(sum);
        }

        public void Close(int id)
        {
            int index;
            T account = GetAccount(id, out index);
            account.Close();

            if (accounts.Length <= 1)
                accounts = null;
            else
            {
                // remove closed account
                T[] tempAccounts = new T[accounts.Length - 1];
                for (int i = 0, j = 0; i < accounts.Length; i++)
                {
                    if (i != index)
                        tempAccounts[j++] = accounts[i];
                }
                accounts = tempAccounts;
            }
        }

        private T GetAccount(int id, out int index)
        {
            T account = FindAccount(id, out index);
            if (account == null)
            {
                throw new Exception("Accoun did not find!");
            }
            return account;
        }

        private T GetAccount(int id)
        {
            T account = FindAccount(id);
            if (account == null)
            {
                throw new Exception("Accoun did not find!");
            }
            return account;
        }

        public void CalculatePercentage()
        {
            if (accounts == null) 
                return;
            for (int i = 0; i < accounts.Length; i++)
            {
                T account = accounts[i];
                account.IncrementDays();
                account.Calculate();
            }
        }

        public T FindAccount(int id)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id)
                    return accounts[i];
            }
            return null;
        }
         
        public T FindAccount(int id, out int index)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id)
                {
                    index = i;
                    return accounts[i];
                }
            }
            index = -1;
            return null;
        }
    }
}
