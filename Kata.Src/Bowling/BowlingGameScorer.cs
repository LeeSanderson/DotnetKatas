namespace Kata.Src.Bowling;

public class BowlingGameScorer
{
    private readonly List<Frame> frames = [];

    public BowlingGameScorer()
    {
        AddFrame();
    }

    private Frame AddFrame()
    {
        var frame = new Frame(frames.Count + 1);
        frames.Add(frame);
        return frame;
    }

    public void Roll(int pins)
    {
        var currentFrame = frames[^1];
        if (currentFrame.IsComplete)
        {
            currentFrame = AddFrame();
        }

        currentFrame.Roll(pins);
    }

    public void Roll(int firstPins, params int[] pins)
    {
        Roll(firstPins);
        foreach (var pin in pins)
        {
            Roll(pin);
        }
    }   

    public int Score => frames.Sum(CalculateFrameScore);

    private int CalculateFrameScore(Frame frame)
    {
        if (frame.IsFinalFrame)
        {
            // In the final frame, all extra rolls are stored in the frame itself.
            return frame.Rolls.Sum();
        }

        if (frame.IsStrike)
        {
            return 10 + GetNextRolls(frame).Take(2).Sum();
        }

        if (frame.IsSpare)
        {
            return 10 + GetNextRolls(frame).Take(1).Sum();
        }

        return frame.Rolls.Sum();
    }

    private IEnumerable<int> GetNextRolls(Frame frame) => 
        frames.Where(f => f.FrameNumber > frame.FrameNumber).SelectMany(f => f.Rolls);
}