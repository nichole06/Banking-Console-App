using BankingAppConsole.Models;

public class TransactionSrvice : ITransactionService
{

   private readonly IAccountRepository _accountRepository;
   public TransactionSrvice(IAccountRepository accountRepository)
   {
      _accountRepository = accountRepository;
   }

    public decimal CheckBalance(Account account)
    {
      return account.Balance;
    }

    public decimal Deposit(Account account, decimal amount)
    {
      decimal newBalance = account.Balance + amount;
      _accountRepository.updateBalance(account.AccountNumber, newBalance);
      return newBalance;
    }

    public bool WireTransfer(Account account, string whereToTransferAccountNumber, decimal amountToTransfer)
    {

      Account? accountToTransfer = _accountRepository.GetAccountByNumber(whereToTransferAccountNumber);

      if(account.Balance - amountToTransfer >= 0)
      {
        if(accountToTransfer != null)
        {
          _accountRepository.updateBalance(account.AccountNumber, account.Balance - amountToTransfer);
          _accountRepository.updateBalance(accountToTransfer.AccountNumber, accountToTransfer.Balance + amountToTransfer);
          return true;
        }
      }
      return false;
    }

    public bool Withdraw(Account account, decimal amount)
    {
        if(account.Balance - amount >= 0)
        {
          _accountRepository.updateBalance(account.AccountNumber, account.Balance - amount);
          return true;
        }
        else
        {
          return false;
        }
    }
}