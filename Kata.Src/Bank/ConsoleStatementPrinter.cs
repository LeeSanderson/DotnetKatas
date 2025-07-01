namespace Kata.Src.Bank;
public class ConsoleStatementPrinter : IStatementPrinter
{
    public const string StatementHeader = "Date || Amount || Balance";

    private IConsole console;

    public ConsoleStatementPrinter(IConsole console)
    {
        this.console = console;
    }

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

    private record RunningBalanceTransaction : Transaction
    {
        public RunningBalanceTransaction(int Value, DateTime Date, int Balance) : base(Value, Date)
        {
            this.Balance = Balance;
        }

        public int Balance { get; }
    }
}
