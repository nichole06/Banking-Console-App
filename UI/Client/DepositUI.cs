using BankingAppConsole.Models;

public class DepositUI : IUIAuthenticated
{
    private readonly ITransactionService _transactionService;

    public DepositUI(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    public void Show(Account account)
    {
        string amount;
        Console.Clear();
        Console.Write("Enter the amount to Deposit: ");
        amount = Console.ReadLine();

        if(decimal.TryParse(amount, out decimal parsedAmount))
        {
            // call deposit sevice
            decimal newBalance = _transactionService.Deposit(account, parsedAmount);
            Console.Clear();
            Console.WriteLine($"You have successfully deposited {parsedAmount} in your account.\n");
            Thread.Sleep(1000);
            Console.Write($"New Balance: {newBalance}");
            Thread.Sleep(1000);
            return;
        }
        else
        {
            Console.WriteLine("Invalid amount inputted.");
        }
    }
}