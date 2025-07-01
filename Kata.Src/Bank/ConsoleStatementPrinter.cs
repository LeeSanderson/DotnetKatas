namespace Kata.Src.Bank;
public class ConsoleStatementPrinter(IConsole console) : IStatementPrinter
{
    private const string StatementHeader = "Date || Amount || Balance";

    public void Print(IEnumerable<Transaction> transactions)
    {
        console.PrintLine(StatementHeader);

        int balance = 0;
        var runningBalanceTransactions =
            transactions
            .OrderBy(t => t.Date)
            .Select(t => new RunningBalanceTransaction(t.Value, t.Date, balance += t.Value))
            .ToList();

        foreach (var ot in runningBalanceTransactions.OrderByDescending(ot => ot.Date))
        {
            console.PrintLine($"{ot.Date:dd/MM/yyyy} || {ot.Value} || {ot.Balance}");
        }
    }

    private record RunningBalanceTransaction(int Value, DateTime Date, int Balance) : Transaction(Value, Date);
}
