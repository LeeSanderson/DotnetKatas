namespace Kata.Src.Bank;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
// This class is designed to be mocked in tests, so it has virtual members.
public class Clock
{
    public virtual DateTime CurrentDate => DateTime.Today;
}
