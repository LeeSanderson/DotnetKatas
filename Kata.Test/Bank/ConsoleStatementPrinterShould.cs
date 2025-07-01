using Kata.Src.Bank;
using NSubstitute;
using System;
using Xunit;

namespace Kata.Test.Bank;

public class ConsoleStatementPrinterShould
{
    private readonly IConsole console;
    private readonly ConsoleStatementPrinter printer;

    public ConsoleStatementPrinterShould()
    {
        console = Substitute.For<IConsole>();
        printer = new ConsoleStatementPrinter(console);
    }

    [Fact]
    public void OnlyPrintsHeadersWhenTransactionListIsEmpty()
    {
        printer.Print(Array.Empty<Transaction>());

        console.Received().PrintLine("Date || Amount || Balance");
        Assert.Single(console.ReceivedCalls());
    }

    [Fact]
    public void PrintTransactionsInDateOrder()
    {
        printer.Print([
            new Transaction(1000, new DateTime(2012, 1,10)),
            new Transaction(2000, new DateTime(2012, 1,13))
        ]);

        Received.InOrder(() =>
        {
            console.PrintLine("Date || Amount || Balance");
            console.PrintLine("13/01/2012 || 2000 || 3000");
            console.PrintLine("10/01/2012 || 1000 || 1000");
        });
    }
}
