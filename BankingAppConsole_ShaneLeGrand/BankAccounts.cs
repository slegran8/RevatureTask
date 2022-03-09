using System;


class BankAccounts{

    int accNo;

    string AccName;

    string accType;

    double accBalance;

    bool isActive;

    string accEmail;

    public int AccountNumber
    {
        get{return accNo;}
        set{accNo = value;}
    }

    public string AccountName{
        get{return AccName;}
        set{AccName = value;}
    }
    public string AccountType
    {
        get{return accType;}
        set{accType = value;}
    }

    public double AccountBalance
    {
        get{return accBalance;}
        set{accBalance = value;}
    }
    
    public bool isBankAccountActive
    {
        get{return isActive;}
        set{isActive = value;}
    }

    public string AccountEmail
    {
        get{return accEmail;}
        set{accEmail = value;}
    }

    public double Withdraw(double w_amount){
        AccountBalance = AccountBalance - w_amount;
        AccountBalance = Math.Round(AccountBalance, 2);
        return AccountBalance;
    }

    public double Deposit(double d_amount){
        AccountBalance = AccountBalance + d_amount;
        AccountBalance = Math.Round(AccountBalance, 2);
        return AccountBalance;
    }

    public void getAccountDetails(){
        Console.WriteLine("Account Number: " +AccountNumber +
        "\n Account Name: " + AccountName +
        "\n Account Type: " + AccountType + 
        "\n Account Balance: " + AccountBalance +
        "\n Account Email: " + AccountEmail);
        return;
    }

    public double CheckBalance(){
        return AccountBalance;
    }
}