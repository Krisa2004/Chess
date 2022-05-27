using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess;

public class Piece
{
    // todo
    public static readonly Piece King = new Piece("király", "/pieces/king_dark.png",
        new Move(Direction.NORTH, 1),
        new Move(Direction.NORTHEAST, 1),
        new Move(Direction.EAST, 1),
        new Move(Direction.SOUTHEAST, 1),
        new Move(Direction.SOUTH, 1),
        new Move(Direction.SOUTHWEST, 1),
        new Move(Direction.WEST, 1),
        new Move(Direction.NORTHWEST, 1)
    );
    public static readonly Piece Rook = new Piece("bástya", "/pieces/rook_dark.png",
        new Move(Direction.NORTH, Type.ROW), 
        new Move(Direction.EAST, Type.ROW), 
        new Move(Direction.SOUTH, Type.ROW),
        new Move(Direction.WEST, Type.ROW)
    );
    public static readonly Piece Bishop = new Piece("futó", "/pieces/bishop_dark.png",
        new Move(Direction.NORTHEAST, Type.ROW), 
        new Move(Direction.SOUTHEAST, Type.ROW), 
        new Move(Direction.SOUTHWEST, Type.ROW),
        new Move(Direction.NORTHWEST, Type.ROW));
    // todo
    public static readonly Piece Queen = new Piece("királynő", "/pieces/queen_dark.png",
        new Move(Direction.NORTH, Type.ROW),
        new Move(Direction.NORTHEAST, Type.ROW),
        new Move(Direction.EAST, Type.ROW),
        new Move(Direction.SOUTHEAST, Type.ROW),
        new Move(Direction.SOUTH, Type.ROW),
        new Move(Direction.SOUTHWEST, Type.ROW),
        new Move(Direction.WEST, Type.ROW),
        new Move(Direction.NORTHWEST, Type.ROW)
    );
    // amúgy nincs túlbonyolítva xdd
    public static readonly Piece Knight = new Piece("ló", "/pieces/knight_dark.png", 
        new Move(new Step(Direction.NORTH, 2), new Step(Direction.WEST, 1)), 
        new Move(new Step(Direction.NORTH, 2), new Step(Direction.EAST, 1)),
        new Move(new Step(Direction.EAST, 2), new Step(Direction.NORTH, 1)), 
        new Move(new Step(Direction.EAST, 2), new Step(Direction.SOUTH, 1)),
        new Move(new Step(Direction.SOUTH, 2), new Step(Direction.EAST, 1)), 
        new Move(new Step(Direction.SOUTH, 2), new Step(Direction.WEST, 1)),
        new Move(new Step(Direction.WEST, 2), new Step(Direction.SOUTH, 1)), 
        new Move(new Step(Direction.WEST, 2), new Step(Direction.NORTH, 1))
    );
    //todo start move
    public static readonly Piece DarkPawn = new Piece("sötét gyalog", "/pieces/pawn_dark.png", new Move(Direction.SOUTH, 1));
    public static readonly Piece LightPawn = new Piece("világos gyalog", "/pieces/pawn_light.png", new Move(Direction.NORTH, 1));
    
    public string Name { get; }
    public List<Move> Moves { get; }
    public Image Image { get; }
    
    private Piece(string name, string image_name, params Move[] moves)
    {
        this.Name = name;
        this.Moves = moves.ToList();
        var image = new Image();
        image.Source = new BitmapImage(new Uri(image_name, UriKind.Relative));
        image.Stretch = Stretch.None;
        image.Width = 60;
        image.Height = 60;
        image.HorizontalAlignment = HorizontalAlignment.Left;
        image.VerticalAlignment = VerticalAlignment.Top;
        this.Image = image;
    }
}