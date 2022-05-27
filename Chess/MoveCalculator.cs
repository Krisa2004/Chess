using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

namespace Chess;

public class MoveCalculator
{
    public static List<Position> GetValidMoves(Position from, Piece piece)
    {
        List<Position> validMoves = new List<Position>();
        piece.Moves.ForEach(m =>
        {
            var temp = from.Clone();
            for (var i = 0; i < m.Steps.Count; i++)
            {
                var step = m.Steps[i];
                if (step.Type == Type.SINGLE)
                {
                    if (i == m.Steps.Count - 1)
                        validMoves.Add(add(temp, step.Direction, step.Amount));
                    else
                        add(temp, step.Direction, step.Amount);
                }
                else
                {
                    bool once = true;
                    for (Position p = temp.Clone(); p.X is <= 8 and >= 1 && p.Y is <= 8 and >= 1; add(p, step.Direction, 1))
                    {
                        validMoves.Add(p.Clone());
                    }
                }
            }
        });
        // gyalog nyitás kezelése
        if (piece.Name == "sötét gyalog" && from.Row == 7)
            validMoves.Add(new Position(from.X, 5));
        if (piece.Name == "világos gyalog" && from.Row == 2)
            validMoves.Add(new Position(from.X, 4));
        // túlcsorduló pozíciók kezelése
        return validMoves.FindAll(p => p.X > 0 && p.X < 9 && p.Y > 0 && p.Y < 9);
    }

    private static Position add(Position p, Direction d, int i)
    {
        switch (d)
        {
            case Direction.NORTH:
                p.Y += i;
                break;
            case Direction.EAST:
                p.X += i;
                break;
            case Direction.SOUTH:
                p.Y -= i;
                break;
            case Direction.WEST:
                p.X -= i;
                break;
            case Direction.NORTHEAST:
                p.X += i;
                p.Y += i;
                break;
            case Direction.SOUTHEAST:
                p.X += i;
                p.Y -= i;
                break;
            case Direction.SOUTHWEST:
                p.X -= i;
                p.Y -= i;
                break;
            case Direction.NORTHWEST:
                p.X -= i;
                p.Y += i;
                break;
        }

        return p;
    }
}