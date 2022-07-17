namespace P06MoneyTransactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            string[] input = Console.ReadLine().Split(",");
            foreach (var item in input)
            {
                int accountNumber = int.Parse(item.Split("-")[0]);
                double accountBalance = double.Parse(item.Split("-")[1]);
                accounts.Add(accountNumber, accountBalance);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] cmdArgs = command.Split();
                    if (cmdArgs[0] == "Deposit")
                    {
                        IfAccountExis(accounts, int.Parse(cmdArgs[1]));
                        int accountNumber = int.Parse(cmdArgs[1]);
                        double addToAccountBalance = double.Parse(cmdArgs[2]);
                        accounts[accountNumber] += addToAccountBalance;
                        Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                    }
                    else if (cmdArgs[0] == "Withdraw")
                    {
                        IfAccountExis(accounts, int.Parse(cmdArgs[1]));
                        int accountNumber = int.Parse(cmdArgs[1]);
                        double substractFromAccountBalance = double.Parse(cmdArgs[2]);

                        if (accounts[accountNumber] < substractFromAccountBalance)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }

                        accounts[accountNumber] -= substractFromAccountBalance;
                        Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }

        public static void IfAccountExis(Dictionary<int, double> accounts, int accountNumber)
        {
            if (!accounts.ContainsKey(accountNumber))
            {
                throw new ArgumentException("Invalid account!");
            }
        }
    }
}
