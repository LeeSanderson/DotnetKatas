using Kata.Src.Bank;
using NSubstitute;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Kata.Test.Bank;

public class AccountServiceShould
{
    private readonly TransactionRepository transactionRepository;
    private readonly IStatementPrinter statementPrinter;
    private readonly AccountService accountService;

    public AccountServiceShould()
    {
        transactionRepository = new TransactionRepository();
        statementPrinter = Substitute.For<IStatementPrinter>();
        accountService = new AccountService(new Clock(), transactionRepository, statementPrinter);
    }

    [Fact]
    public void StoreDepositTransactions()
    {
        accountService.Deposit(1000);

        transactionRepository.GetAll().Single().Value.Should().Be(1000);
    }

    [Fact]
    public void StoreWithDrawlTransactions()
    {
        accountService.Withdraw(1000);

        transactionRepository.GetAll().Single().Value.Should().Be(-1000);
    }

    [Fact]
    public void PrintExpectedStatement()
    {
        accountService.Deposit(1000);
        accountService.PrintStatement();

        statementPrinter.Received().Print(transactionRepository.GetAll());
    }
}
