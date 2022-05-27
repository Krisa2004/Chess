using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess;

// A move consists of multiple steps
// a step has a direction, a type, and an amount
public class Move
{
    public List<Step> Steps { get; }
    public Move(Direction direction, Type type, int amount = 0)
    {
        this.Steps = new List<Step>();
        Steps.Add(new Step(direction, type, amount));
    }

    public Move(Direction direction, int amount)
    {
        this.Steps = new List<Step>();
        Steps.Add(new Step(direction, Type.SINGLE, amount));
    }

    public Move(params Step[] steps)
    {
        this.Steps = steps.ToList();
    }
}

public class Step
{
    public Direction Direction { get; }
    public Type Type { get; }
    public int Amount { get; }
    
    public Step(Direction direction, Type type, int amount)
    {
        this.Direction = direction;
        this.Type = type;
        this.Amount = amount;
    }

    public Step(Direction direction, int amount)
    {
        this.Direction = direction;
        this.Type = Type.SINGLE;
        this.Amount = amount;
    }
}

public enum Direction
{
    NORTH,
    EAST,
    SOUTH,
    WEST,
    NORTHEAST,
    SOUTHEAST,
    SOUTHWEST,
    NORTHWEST
}

public enum Type
{
    SINGLE,
    ROW
}