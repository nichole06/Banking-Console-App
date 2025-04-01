using BankingAppConsole.Database;
using BankingAppConsole.Models;
using UI;
public class Program
{
   public static void Main()
   {

      IAccountRepository accountRepository = new MockDatabase();
      IAuthService authService = new AuthService(accountRepository);
      ITransactionService transactionService = new TransactionSrvice(accountRepository);

      
      string inputValue = "swipe";
      string? swipeInput;
      string? accountNumberInput;


      while(true)
      {
         Console.Clear();
         Console.WriteLine("===Welcome to Mini Banking Application===\n");
         Console.Write("Please Enter your account number: ");
         accountNumberInput = Console.ReadLine();

         Console.Write("Please type 'Swipe' to swipe your card: ");
         swipeInput = (Console.ReadLine() ?? "").ToLower();

         if(swipeInput == inputValue)
         {
            Account? account = accountRepository.GetAccountByNumber(accountNumberInput);

            Console.WriteLine(account);
            if(account != null)
            {
               Console.Clear();
               Console.WriteLine("You have successfully swiped your card");
               Thread.Sleep(2000);
               new LoginUI(authService, transactionService).Show(accountNumberInput);
            }
            else
            {
               Console.Clear(); 
               Console.WriteLine("Invalid account number please try again.");
               Thread.Sleep(2000);
            }
         }
         else
         {
            Console.Clear();
            Console.WriteLine("Please swipe your card properly!");
            Thread.Sleep(2000);
         }
      }
   }
}