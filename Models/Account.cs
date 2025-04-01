namespace BankingAppConsole.Models;

public class Account
{
   public string AccountNumber { get; set;}
   public string PinCode {get; set;}
   public string OwnerName { get; }
   public decimal Balance {get; set;}

   public Account(string accountNumber, string pinCode, string ownerName, decimal balance)
   {
      AccountNumber = accountNumber;
      PinCode = pinCode;
      OwnerName = ownerName;
      Balance = balance;
   }
}