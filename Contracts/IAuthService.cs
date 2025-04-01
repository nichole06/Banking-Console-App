using BankingAppConsole.Models;

public interface IAuthService
{
   Account Authenticate(string accountNumber, string pinCode);
}