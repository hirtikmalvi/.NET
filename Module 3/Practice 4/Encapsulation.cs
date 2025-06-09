using System;

namespace Practice_4
{
    class BankAccount
    {
        private string AccountNumber;
        private decimal Balance;
        private string AccountHolder;

        public decimal SetBalance
        {
            get {  return Balance; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Balance can not be negative");
                }
                Balance = value;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Amount must be greater than zero");
            }
            else
            {
                SetBalance += amount;
            }
        }
        public void Withdraw(decimal amount)
        {
            if (Balance - amount < 0)
            {
                throw new Exception("Insufficient Balance");
            }
            else
            {
                SetBalance -= amount;
            }
        }
    }
}
