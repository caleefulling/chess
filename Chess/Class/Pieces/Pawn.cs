using System;
using System.Collections.Generic;
using Chess.Class.Enum;

namespace Chess.Class.Pieces
{
    [Serializable]
    public class Pawn : IPiece
    {
        public PieceTypeEnum Type { get; set; }

        public PieceColorEnum Color { get; set; }

        public char BoardNotation { get; set; }

        public int Value { get; set; }

        public int CurrentLocation_x { get; set; }

        public int CurrentLocation_y { get; set; }

        public bool HasMoved { get; set; }


        public Pawn(int x, int y, PieceColorEnum color)
        {
            CurrentLocation_x = x;
            CurrentLocation_y = y;

            Type = PieceTypeEnum.Pawn;
            BoardNotation = 'P';
            Value = 1;
            Color = color;
        }

        public List<KeyValuePair<int, int>> AvailableMoves(Board.Board board)
        {
            List<KeyValuePair<int, int>> positionsReturn = new List<KeyValuePair<int, int>>();

            int colorMultiplier = 1;
            if (Color == PieceColorEnum.White)
                colorMultiplier = -1;

            // check space row +/- 1
            if (board.Instance[CurrentLocation_x + (1 * colorMultiplier), CurrentLocation_y] == null)
            {
                positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x + (1 * colorMultiplier), CurrentLocation_y));
            }

            // on home row, row +/- 2 available move
            if (!this.HasMoved)
            {
                if (board.Instance[CurrentLocation_x + (2 * colorMultiplier), CurrentLocation_y] == null)
                {
                    positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x + (2 * colorMultiplier), CurrentLocation_y));
                }

            }

            // potential captures
            if (Color == PieceColorEnum.White)
            {
                if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y + 1 <= 7)
                {
                    var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y + 1];
                    if (piece != null && piece.Color != Color)
                    {
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y + 1));
                    }
                }

                if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y - 1 >= 0)
                {
                    var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y - 1];
                    if (piece != null && piece.Color != Color)
                    {
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y - 1));
                    }
                }
            }
            else
            {
                if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y + 1 <= 7)
                {
                    var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y + 1];
                    if (piece != null && piece.Color != Color)
                    {
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y + 1));
                    }
                }

                if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y - 1 >= 0)
                {
                    var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y - 1];
                    if (piece != null && piece.Color != Color)
                    {
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y - 1));
                    }
                }
            }

            return positionsReturn;
        }

        public List<KeyValuePair<int, int>> GetCheckPath(Board.Board board)
        {
            // no "path" to intercept for a pawn check
            return new List<KeyValuePair<int, int>>();
        }

        public void Move(int x, int y)
        {
            CurrentLocation_x = x;
            CurrentLocation_y = y;

            HasMoved = true;
        }
    }
}
