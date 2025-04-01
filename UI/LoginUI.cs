using BankingAppConsole.Database;
using BankingAppConsole.Models;
using BankingAppConsole.UI.Client;

namespace UI;

public class LoginUI : IUI
{
   private readonly IAuthService _authService;
   private readonly ITransactionService _transactionService;

   public LoginUI(IAuthService authService, ITransactionService transactionService)
   {
      _authService = authService;
      _transactionService = transactionService;
   }

   public void Show(string accountNumber)
   {
      string pinCodeInput;

      for(int counter = 3; counter > 0; counter--)
      {
         Console.Clear();
         Console.WriteLine("Your account number is found.");
         Console.Write("Please enter your pin code: ");
         pinCodeInput = Console.ReadLine().ToLower();

         Account account = _authService.Authenticate(accountNumber, pinCodeInput);

         if(account != null)
         {
            for(int i = 0; i < 3; i++)
            {
               Console.Clear();
               Console.Write("Logging in");
               for(int j = 0; j < 3; j++)
               {
                  Console.Write(".");
                  Thread.Sleep(200);
               }
            }

            new DashboardUI(_transactionService).Show(account);
            return; 
         }

         if(counter == 2)
         {
            Console.WriteLine($"Invalid pin code please try again. ({counter - 1} attempt left)");
            Thread.Sleep(2000);
         }
         else
         {
            Console.WriteLine($"Invalid pin code please try again. ({counter - 1} attempts left)");
            Thread.Sleep(2000);
         }
         
         if(counter == 1)
         {
            Console.WriteLine("Reached maximum pincode input attempt");
            Thread.Sleep(2000);
            return;
         }
      }
   }
}