using System;

class Accounts
{
    int accNo;

    string accName;

    string accType;

    double accBalance;

    bool accIsActive;

    string accEmail;

    public int AccountNumber
    {
        get{ return accNo;}
        set{accNo  = value;}
    }

    public string AccountName
    {
        get{return accName;}
        set{accName = value;}
    }

    public string AccountType
    {
        get{return accType;}
        set{accType = value;}
    }

    public double AccountBalance{
        get{return accBalance;}
        set{accBalance = value;}
    }

    public string AccountEmail
    {
        get{return accEmail;}
        set{accEmail = value;}
    }

    public double Withdraw(double w_amount){
        AccountBalance =  AccountBalance - w_amount;
        return AccountBalance;
    }

    public double Deposit(int d_amount)
    {
        AccountBalance = AccountBalance + d_amount;
        return AccountBalance;
    }


    public string getAccountDetails(){
        System.Console.WriteLine("-------- Account Details --------");
        System.Console.WriteLine("Account Number: " + AccountNumber);
        System.Console.WriteLine("Account Name: " + AccountName);
        System.Console.WriteLine("Account Type: " + AccountType);
        System.Console.WriteLine("Account Balance: " + AccountBalance);
        System.Console.WriteLine("Account Email: " + AccountEmail);
    }
    public double CheckBalance()
    {
        return AccountBalance;
    }
}
