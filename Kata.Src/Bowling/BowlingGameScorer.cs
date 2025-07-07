namespace Kata.Src.Bowling;

public class BowlingGameScorer
{
    private int currentRoll;
    private readonly int[] rolls = new int[21];
    public void Roll(int pins)
    {
        // TODO: Check if currentRoll is within bounds
        // TODO: Check if pins is within bounds (0 to 10)
        // TODO: Check if pins in frame is valid (e.g., not more than 10 in a single frame)
        rolls[currentRoll++] = pins;
    }

    public void Roll(int firstPins, params int[] pins)
    {
        Roll(firstPins);
        foreach (var pin in pins)
        {
            Roll(pin);
        }
    }   

    public int Score
    {
        get
        {
            var score = 0;
            for (var i = 0; i < currentRoll; i++)
            {
                score += rolls[i];
            }
            return score;
        }
    }
}