using BankingAppConsole.Models;

namespace BankingAppConsole.Database;

public class MockDatabase : IAccountRepository
{
   private List<Account> accounts = new List<Account>
   {
      new Account("123456789", "12345", "Sample Name", 0), // change this if you want to.
      new Account("12345678", "1234", "Sample Name 2", 0),
   };

   public List<Account> GetAllAccounts()
   {
      return accounts;
   }

   public Account? GetAccountByNumber(string accountNumber)
   {
      return accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
   }

   public bool updateBalance(string accountNumber, decimal balance)
   {
      Account? account = GetAccountByNumber(accountNumber);

      if (account != null)
      {
         account.Balance = balance;
        return true; 
      }
      else
      {
         return false;
      }
   }

}
