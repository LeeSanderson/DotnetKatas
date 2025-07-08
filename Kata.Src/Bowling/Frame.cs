namespace Kata.Src.Bowling;

public record Frame(int FrameNumber)
{
    private readonly List<int> rolls = [];

    public void Roll(int pins) => rolls.Add(pins);

    public IEnumerable<int> Rolls => rolls;

    public bool IsStrike => rolls.Take(1).Sum() == 10;

    public bool IsSpare => rolls.Take(2).Sum() == 10;

    public bool IsFinalFrame => FrameNumber == 10;

    public bool IsComplete => IsFinalFrame ? IsFinalFrameComplete : IsNonFinalFrameComplete;

    private bool IsNonFinalFrameComplete => IsStrike || rolls.Count == 2;

    private bool IsFinalFrameComplete => rolls.Count == RollsInCompleteFinalFrame;

    private int RollsInCompleteFinalFrame => IsStrike || IsSpare ? 3 : 2;
}