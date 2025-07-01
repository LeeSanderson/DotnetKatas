namespace Kata.Src.MarsRover;

public enum Facing { North, East, South, West }

public static class FacingExtensions
{
    private static readonly Dictionary<Facing, Facing> LeftRotationFacings;
    private static readonly Dictionary<Facing, Facing> RightRotationFacings;
    private static readonly Dictionary<Facing, int> XDeltas;
    private static readonly Dictionary<Facing, int> YDeltas;

    static FacingExtensions()
    {
        LeftRotationFacings = new() 
        { 
            { Facing.North, Facing.West },
            { Facing.West, Facing.South },
            { Facing.South, Facing.East },
            { Facing.East, Facing.North }
        };

        RightRotationFacings = new()
        {
            { Facing.North, Facing.East },
            { Facing.East, Facing.South },
            { Facing.South, Facing.West },
            { Facing.West, Facing.North }
        };

        XDeltas = new()
        {
            { Facing.North, 0 },
            { Facing.East, 1 },
            { Facing.South, 0 },
            { Facing.West, -1 }
        };

        YDeltas = new()
        {
            { Facing.North, 1 },
            { Facing.East, 0 },
            { Facing.South, -1 },
            { Facing.West, 0 }
        };
    }

    public static char CompassPoint(this Facing facing) => facing.ToString()[0];

    public static Facing RotateLeft(this Facing facing) => LeftRotationFacings[facing];

    public static Facing RotateRight(this Facing facing) => RightRotationFacings[facing];

    public static int XDelta(this Facing facing) => XDeltas[facing];

    public static int YDelta(this Facing facing) => YDeltas[facing];
}