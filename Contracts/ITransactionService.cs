using BankingAppConsole.Models;

public interface ITransactionService
{
   decimal Deposit(Account account, decimal amount);
   bool Withdraw(Account account, decimal amount);
   bool WireTransfer(Account account, string whereToTransferAccount, decimal amountToTransfer);
   decimal CheckBalance(Account account);
}