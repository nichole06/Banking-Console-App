using BankingAppConsole.Models;

namespace BankingAppConsole.Database;

public class MockDatabase : IAccountRepository
{
   private List<Account> accounts = new List<Account>
   {
      new Account("123456789", "12345", "Nichole John Tejara", 0),
      new Account("12345678", "1234321", "Mary Stephany Gweneth Pizana", 0),
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
