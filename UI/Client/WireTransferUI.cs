using BankingAppConsole.Models;

public class WireTransfer : IUIAuthenticated
{
   private readonly ITransactionService _transactionService;
   public WireTransfer(ITransactionService transactionService)
   {
      _transactionService = transactionService;
   }

    public void Show(Account account)
    {
      string? accountNumber;
      string? amountToTransfer;
      Console.Clear();
      Console.Write("Enter the account number to transfer: ");
      accountNumber = Console.ReadLine();
      Console.Write("Enter the amount to transfer: ");
      amountToTransfer = Console.ReadLine();
      if(decimal.TryParse(amountToTransfer, out decimal parsedAmount))
      {
         bool tryWireTransfer = _transactionService.WireTransfer(account, accountNumber, parsedAmount);

         if(tryWireTransfer)
         {
            Console.Clear();
            Console.WriteLine($"You have successfully transfered an amount to {accountNumber}");
            Thread.Sleep(1000);
            Console.WriteLine($"Your new balance is: {account.Balance}");
            Thread.Sleep(2000);
         }
         else
         {
            Console.Clear();
            Console.WriteLine("Failed to transfer an amount, account not found or insufficient balance");
            Thread.Sleep(1000);
            return;
         }
      }
      else
      {
         Console.Clear();
         Console.WriteLine("Invalid amount inputted");
         Thread.Sleep(2000);
         return;
      }        
    }
}