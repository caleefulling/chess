using System;
using System.Collections.Generic;
using Chess.Class.Enum;

namespace Chess.Class.Pieces
{
    [Serializable]
    public class Knight : IPiece
    {
        public TypeEnum Type { get; set; }

        public ColorEnum Color { get; set; }

        public char BoardNotation { get; set; }

        public int Value { get; set; }

        public int CurrentLocation_x { get; set; }

        public int CurrentLocation_y { get; set; }

        public bool IsAtRisk { get; set; }

        public bool IsPuttingPieceAtRisk { get; set; }


        public Knight(int x, int y, ColorEnum color)
        {
            CurrentLocation_x = x;
            CurrentLocation_y = y;

            Type = TypeEnum.Knight;
            BoardNotation = 'N';
            Value = 3;
            Color = color;
        }

        public List<KeyValuePair<int, int>> AvailableMoves(Board.Board board)
        {
            List<KeyValuePair<int, int>> availableMoves = new List<KeyValuePair<int, int>>();

            if (CurrentLocation_x - 2 >= 0 && CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x - 2, CurrentLocation_y - 1];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x - 2, CurrentLocation_y - 1));
                }
            }

            if (CurrentLocation_x - 2 >= 0 && CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x - 2, CurrentLocation_y + 1];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x - 2, CurrentLocation_y + 1));
                }
            }

            if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y + 2 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y + 2];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y + 2));
                }
            }

            if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y + 2 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y + 2];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y + 2));
                }
            }

            if (CurrentLocation_x + 2 <= 7 && CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x + 2, CurrentLocation_y + 1];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + 2, CurrentLocation_y + 1));
                }
            }

            if (CurrentLocation_x + 2 <= 7 && CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x + 2, CurrentLocation_y - 1];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + 2, CurrentLocation_y - 1));
                }
            }

            if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y - 2 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y - 2];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y - 2));
                }
            }

            if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y - 2 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y - 2];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y - 2));
                }
            }

            return availableMoves;
        }

        public List<Move> AvailableMovesWithDetails(Board.Board board)
        {
            List<Move> availableMoves = new List<Move>();

            if (CurrentLocation_x - 2 >= 0 && CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x - 2, CurrentLocation_y - 1];
                if (piece == null)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x - 2, CurrentLocation_y - 1)));
                }
                else if (piece.Color != Color)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x - 2, CurrentLocation_y - 1), piece));
                }
            }

            if (CurrentLocation_x - 2 >= 0 && CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x - 2, CurrentLocation_y + 1];
                if (piece == null)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x - 2, CurrentLocation_y + 1)));
                }
                else if (piece.Color != Color)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x - 2, CurrentLocation_y + 1), piece));
                }
            }

            if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y + 2 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y + 2];
                if (piece == null)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y + 2)));
                }
                else if (piece.Color != Color)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y + 2), piece));
                }

            }
            if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y + 2 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y + 2];
                if (piece == null)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y + 2)));
                }
                else if (piece.Color != Color)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y + 2), piece));
                }
            }

            if (CurrentLocation_x + 2 <= 7 && CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x + 2, CurrentLocation_y + 1];
                if (piece == null)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x + 2, CurrentLocation_y + 1)));
                }
                else if (piece.Color != Color)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x + 2, CurrentLocation_y + 1), piece));
                }
            }

            if (CurrentLocation_x + 2 <= 7 && CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x + 2, CurrentLocation_y - 1];
                if (piece == null)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x + 2, CurrentLocation_y - 1)));
                }
                else if (piece.Color != Color)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x + 2, CurrentLocation_y - 1), piece));
                }
            }

            if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y - 2 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y - 2];
                if (piece == null)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y - 2)));
                }
                else if (piece.Color != Color)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y - 2), piece));
                }
            }

            if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y - 2 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y - 2];
                if (piece == null)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y - 2)));
                }
                else if (piece.Color != Color)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y - 2), piece));
                }
            }

            return availableMoves;
        }


        public List<KeyValuePair<int, int>> GetCheckPath(Board.Board board)
        {
            // no "path" to intercept for a knight check
            return new List<KeyValuePair<int, int>>();
        }

        public void Move(int x, int y)
        {
            CurrentLocation_x = x;
            CurrentLocation_y = y;
        }
    }
}
