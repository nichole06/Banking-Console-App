using BankingAppConsole.Models;

public class WithdrawUI : IUIAuthenticated
{
   private readonly ITransactionService _transactionService;
   public WithdrawUI(ITransactionService transactionService)
   {
      _transactionService = transactionService;
   }
    public void Show(Account account)
    {
      string? amountToWithdraw;
      Console.Clear();
      Console.Write("Enter the amount to withdraw: ");
      amountToWithdraw = Console.ReadLine();

      if(decimal.TryParse(amountToWithdraw, out decimal parsedAmount))
      {
         bool withdrawAmount = _transactionService.Withdraw(account, parsedAmount);

         if(withdrawAmount)
         {
            Console.Clear();
            Console.WriteLine($"You have successfully withdrawn {parsedAmount} from your account.");
            Thread.Sleep(1000);
            Console.WriteLine($"Your new balance is {account.Balance}");
            Thread.Sleep(2000);
         }
         else
         {
            Console.Clear();
            Console.WriteLine("Withdraw process failed, insufficient balance");
            Thread.Sleep(2000);
            return;
         }
      }
      else
      {
         Console.Clear();
         Console.WriteLine("Invalid inputted amount");
         Thread.Sleep(2000);
         return;
      }
    }
}