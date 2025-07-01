namespace Kata.Src.Bank;

public class AccountService(
    Clock clock,
    TransactionRepository transactionRepository,
    IStatementPrinter statementPrinter)
{
    public void Deposit(int amount) => 
        transactionRepository.Add(TransactionFor(amount));

    public void Withdraw(int amount) => 
        transactionRepository.Add(TransactionFor(-amount));

    public void PrintStatement() => 
        statementPrinter.Print(transactionRepository.GetAll());

    private Transaction TransactionFor(int amount) => new(amount, clock.CurrentDate);
}
