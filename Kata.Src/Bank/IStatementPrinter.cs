namespace Kata.Src.Bank;

public interface IStatementPrinter
{
    void Print(IEnumerable<Transaction> transactions);
}