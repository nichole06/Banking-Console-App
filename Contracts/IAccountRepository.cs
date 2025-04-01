using BankingAppConsole.Models;

public interface IAccountRepository
{
   List<Account> GetAllAccounts();
   Account? GetAccountByNumber(string accountNumber);
   bool updateBalance(string accountNumber, decimal balance);
}