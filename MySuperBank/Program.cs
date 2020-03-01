using System;

namespace MySuperBank
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            BankAccount account = new BankAccount("Cliff", 10000);

            account.MakeWithdrawel(3000, DateTime.Now, "poes");

            account.MakeWithdrawel(10000, DateTime.Now, "Lekke");

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
