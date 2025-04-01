using BankingAppConsole.Models;

namespace BankingAppConsole.UI.Client;

public class DashboardUI : IUIAuthenticated
{
   private readonly ITransactionService _transactionService;
   public DashboardUI(ITransactionService transactionService)
   {
      _transactionService = transactionService;
   }
    public void Show(Account account)
    {
      string? choice;
      Console.Clear();
      Console.WriteLine($"Welcome back {account.OwnerName}!\n");

      Console.WriteLine("1 | Deposit");
      Console.WriteLine("2 | Withdraw");
      Console.WriteLine("3 | Wire Trasnfer");
      Console.WriteLine("4 | Check Balance");
      Console.WriteLine("5 | Logout");
      Console.Write("Select: ");
      choice = Console.ReadLine();

      if (int.TryParse(choice, out int numberChoice))
      {
         switch(numberChoice)
         {
            case 1:
               // deposit
               new DepositUI(_transactionService).Show(account);
               Show(account);
            break;

            case 2:
               // withdraw
               new WithdrawUI(_transactionService).Show(account);
               Show(account);
            break;

            case 3:
               // wiretransfer
               new WireTransfer(_transactionService).Show(account);
               Show(account);
            break;

            case 4:
               // check balance
               Console.Clear();
               Console.WriteLine($"Your balance is: {account.Balance}");
               Thread.Sleep(2000);
               Show(account);
            break;

            case 5:
               
               for(int i = 0; i < 3; i++)
               {
                  Console.Clear();
                  Console.Write("Logging out");
                  for(int j = 0; j < 3; j++)
                  {
                     Console.Write(".");
                     Thread.Sleep(200);
                  }
               }
               return;
            default:
               errorWithSelfCall(account);
            break;
         }
      }
      else
      {
         errorWithSelfCall(account);
      }
    }

    void errorWithSelfCall(Account account)
    {
         Console.WriteLine("Invalid input, please try again.");
         Thread.Sleep(1500);
         Show(account);
    }
}

