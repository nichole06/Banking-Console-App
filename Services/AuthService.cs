using BankingAppConsole.Models;
using BankingAppConsole.UI.Client;

public class AuthService : IAuthService
{
   private readonly IAccountRepository _accountRepository;

    public AuthService(IAccountRepository accountRepository)
      {
         _accountRepository = accountRepository;
      }

    public Account Authenticate(string accountNumber, string pinCode)
    {
      Account? account = _accountRepository.GetAccountByNumber(accountNumber);
      

        if(account.PinCode == pinCode)
         {
            return account;
         }
         else
         {
            return null;
         }
    }
}