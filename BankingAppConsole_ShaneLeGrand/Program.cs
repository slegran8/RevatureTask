using System;

namespace BankingAppConsole_ShaneLeGrand
{
    class Program
    {
        static void Main(string[] args)
        {
        Console.WriteLine("1. Create New Account");
        Console.WriteLine("2. Check Balance ");
        Console.WriteLine("3. Withdraw ");
        Console.WriteLine("4. Deposit ");
        Console.WriteLine("5. Get Details ");
        Console.WriteLine("6. Exit");
            
        bool continueBanking = true;

        BankAccounts FakeAccount = new BankAccounts(){
            AccountNumber = 123,
            AccountName = "John Schmickle",
            AccountType = "Savings",
            AccountBalance = 2004.32,
            isBankAccountActive = true,
            AccountEmail = "Swag420@gmail.com"
                        };

        BankAccounts newAccount = new BankAccounts();

        while (continueBanking){

        
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
                {
                    case 1:
                        Console.WriteLine("You Chose to Create a new Account");
                        Console.WriteLine("Enter Your Account Number");
                        int accoNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Your Account Name");
                        string accoName = Console.ReadLine();
                        Console.WriteLine("Enter Your Account Type");
                        string accType = Console.ReadLine();
                        Console.WriteLine("Enter Your Account Balance");
                        double accBalance = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Your Account Email");
                        string AccEmail = Console.ReadLine();

                        newAccount = new BankAccounts(){
                            AccountNumber = accoNo,
                            AccountName = accoName,
                            AccountType = accType,
                            AccountBalance = accBalance,
                            isBankAccountActive = true,
                            AccountEmail = AccEmail
                        };
                        break;

                    case 2:
                       System.Console.WriteLine("Your Balance is: $" + newAccount.CheckBalance());
                        break;
                    case 3:
                        Console.WriteLine("How much would you like to Withdraw?");
                        double withdraw_amount = Convert.ToDouble(Console.ReadLine());
                        System.Console.WriteLine("Balance After Withdraw: $" +newAccount.Withdraw(withdraw_amount));
                        break;
                    case 4:
                        Console.WriteLine("How much would you like to Deposit?");
                        double deposit_amount = Convert.ToDouble(Console.ReadLine());
                        System.Console.WriteLine("Balance After Deposit: $" +newAccount.Deposit(deposit_amount));
                        break;
                    case 5:
                        newAccount.getAccountDetails();
                        break;
                    case 6:
                        System.Console.WriteLine("Thank you for Banking With Us");
                        System.Console.WriteLine("GoodBye!");
                        continueBanking = false;
                        break;
                    default:
                        System.Console.WriteLine("Invalid Option");
                        System.Console.WriteLine("Try Again");
                        break;
                }
            }
        }
    }
}
