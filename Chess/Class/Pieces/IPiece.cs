using System.Collections.Generic;
using Chess.Class.Enum;

namespace Chess.Class
{
    public interface IPiece
    {
        PieceTypeEnum Type { get; set; }
        PieceColorEnum Color { get; set; }
        char BoardNotation { get; set; }
        int Value { get; set; }
        int CurrentLocation_x { get; set; }
        int CurrentLocation_y { get; set; }

        List<KeyValuePair<int, int>> AvailableMoves(Board.Board board);
        void Move(int x, int y);
        List<KeyValuePair<int, int>> GetCheckPath(Board.Board board);
    }
}
