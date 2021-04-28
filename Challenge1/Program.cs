using System;

namespace Challenge1
{
    class BankAccount
    {
        public string firstName="" ;
        public string lastName="";
        public decimal Balance=0;
       public string AccountOwner ="";

        public virtual void Deposit(decimal bal)
        {
            //Balance += amount;
        }
        public virtual void Withdraw(decimal bal)
        {
           // Balance -= amount;
        }
       
    }
    class CheckingAcct : BankAccount
    {
        public CheckingAcct(string fName, string lName, decimal bal)
        {
            firstName = fName;
            lastName = lName;
            Balance = bal;
            AccountOwner = firstName + lastName;

        }
        public override void Deposit(decimal bal)
        {
            Balance += bal;
        }
        public override void Withdraw(decimal bal)
        {
            if (bal > Balance)
                Console.WriteLine("Denied");
            else
            {
                Balance -= bal;
            }
        }

    }
    class SavingsAcct : BankAccount
    {
        public int count = 0;
        public decimal charge = 2.00m;
       
        public SavingsAcct(string fName, string lName, decimal bal) 
        {
            firstName = fName;
            lastName = lName;
            Balance = bal;
            AccountOwner = firstName + lastName;
        }
        public override void Deposit(decimal bal)
        {
            Balance += bal;
        }
        public override void Withdraw(decimal bal)
        {
            if (bal > Balance)
                Console.WriteLine("Denied");
            else
            {
                count++;
                if (count > 3) Balance -= charge;
                Balance -= bal;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create the Checking Account with initial balance
            CheckingAcct checking = new CheckingAcct("Ahmad", "Nasser", 2500.0m);
            // Create the Savings Account with interest and initial balance
            SavingsAcct saving = new SavingsAcct("Ahmad", "Nasser", 1000.0m);


            // Check the balances
            // Expected output should be 2500 and 1000 at this point
            Console.WriteLine($"Checking balance is {checking.Balance:C2}");
            Console.WriteLine($"Savings balance is {saving.Balance:C2}");


            // Print the account owner information. Expected output: 
            // "Checking owner: Ahmad Nasser"
            // "Savings owner: Ahmad Nasser"
           Console.WriteLine($"Checking owner: {checking.AccountOwner}");
            Console.WriteLine($"Savings owner: {saving.AccountOwner}");


            // Deposit some money in each account
            checking.Deposit(200.0m);
            saving.Deposit(150.0m);


            // Check the balances
            // Expected output should be 2700 and 1150 at this point
            Console.WriteLine($"Checking balance is {checking.Balance:C2}");
            Console.WriteLine($"Savings balance is {saving.Balance:C2}");


            // Make some withdrawals from each account
            checking.Withdraw(50.0m);
            saving.Withdraw(125.0m);


            // Check the balances
            // Expected output should be 2650 and 1025 at this point
            Console.WriteLine($"Checking balance is {checking.Balance:C2}");
            Console.WriteLine($"Savings balance is {saving.Balance:C2}");


            // More than 3 Savings withdrawals should result in 2.00 charge
            saving.Withdraw(10.0m);
            saving.Withdraw(20.0m);
            saving.Withdraw(30.0m);


            // Savings balance should now be 988.63
            Console.WriteLine($"Savings balance is {saving.Balance:C2}");


            // try to overdraw savings - this should be denied and print message
            saving.Withdraw(2000.0m);


            // try to overdraw checking - this should be denied and print message
            checking.Withdraw(3000.0m);

            //Expected output should be -2,650 and 988.63
            Console.WriteLine($"Checking balance is {checking.Balance:C2}");
            Console.WriteLine($"Savings balance is {saving.Balance:C2}");

            Console.ReadKey();
        }
    }
}
