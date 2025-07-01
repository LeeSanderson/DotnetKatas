namespace Kata.Src.Bank;

public class AccountService
{
    private readonly Clock clock;
    private readonly TransactionRepository transactionRepository;
    private readonly IStatementPrinter statementPrinter;

    public AccountService(
        Clock clock,
        TransactionRepository transactionRepository,
        IStatementPrinter statementPrinter)
    {
        this.clock = clock;
        this.transactionRepository = transactionRepository;
        this.statementPrinter = statementPrinter;
    }

    public void Deposit(int amount)
    {
        transactionRepository.Add(TransactionFor(amount));
    }

    public void Withdral(int amount)
    {
        transactionRepository.Add(TransactionFor(-amount));
    }

    public void PrintStatement()
    {
        statementPrinter.Print(transactionRepository.GetAll());
    }

    private Transaction TransactionFor(int amount) => new Transaction(amount, clock.CurrentDate);
}
