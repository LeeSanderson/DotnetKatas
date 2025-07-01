using Kata.Src.Bank;
using NSubstitute;
using System;
using Xunit;

namespace Kata.Test.Bank.Features;

public class PrintStatementFeature
{
    [Fact]
    public void PrintExpectedStatementWhenTransactionsAreSubmitted()
    {
        var console = Substitute.For<IConsole>();
        var clock = Substitute.For<Clock>();
        clock.CurrentDate.Returns(new DateTime(2012, 01, 10), new DateTime(2012, 01, 13), new DateTime(2012, 01, 14));

        var accountService = new AccountService(clock, new TransactionRepository(), new ConsoleStatementPrinter(console));
        accountService.Deposit(1000);
        accountService.Deposit(2000);
        accountService.Withdraw(500);
        accountService.PrintStatement();

        Received.InOrder(() =>
        {
            console.PrintLine("Date || Amount || Balance");
            console.PrintLine("14/01/2012 || -500 || 2500");
            console.PrintLine("13/01/2012 || 2000 || 3000");
            console.PrintLine("10/01/2012 || 1000 || 1000");
        });
    }
}