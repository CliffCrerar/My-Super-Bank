using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach( var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 100001;

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            MakeDeposit(initialBalance, DateTime.Now, "Open Account");
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            try { 
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
                }
                var deposit = new Transaction(amount, date, note);
                allTransactions.Add(deposit);
            }
            catch(Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public void MakeWithdrawel(decimal amount, DateTime date, string note)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
                }
                if (Balance - amount < 0)
                {
                    throw new InvalidOperationException("Insuffcient funds for this withdrawel");
                }
                var withDrawel = new Transaction(-amount, date, note);
                allTransactions.Add(withDrawel);
            }
            catch(Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            report.AppendLine("Date\t\tAmount\tNote");
            foreach(var item in allTransactions)
            {
                // ROWS
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}
