namespace Kata.Src.Bank;

public class TransactionRepository
{
    private readonly List<Transaction> transactions = new();

    public IEnumerable<Transaction> GetAll()
    {
        return transactions;
    }

    internal void Add(Transaction transaction)
    {
        transactions.Add(transaction);
    }
}
