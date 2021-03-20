using System;
using System.Collections.Generic;
using Chess.Class.Enum;

namespace Chess.Class.Pieces
{
    [Serializable]
    public class Pawn : IPiece
    {
        public TypeEnum Type { get; set; }

        public ColorEnum Color { get; set; }

        public char BoardNotation { get; set; }

        public int Value { get; set; }

        public int CurrentLocation_x { get; set; }

        public int CurrentLocation_y { get; set; }

        public bool HasMoved { get; set; }

        public bool IsAtRisk { get; set; }

        public bool IsPuttingPieceAtRisk { get; set; }


        public Pawn(int x, int y, ColorEnum color)
        {
            this.CurrentLocation_x = x;
            this.CurrentLocation_y = y;

            Type = TypeEnum.Pawn;
            BoardNotation = 'P';
            Value = 1;
            Color = color;
        }

        public List<KeyValuePair<int, int>> AvailableMoves(Board.Board board)
        {
            List<KeyValuePair<int, int>> availableMoves = new List<KeyValuePair<int, int>>();

            int ColorEnumMultiplier = this.Color == ColorEnum.White ? -1 : 1;
            // check space row +/- 1
            if (board.Instance[this.CurrentLocation_x + (1 * ColorEnumMultiplier), this.CurrentLocation_y] == null)
            {
                availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x + (1 * ColorEnumMultiplier), this.CurrentLocation_y));
            }

            // on home row, row +/- 2 available move
            if (!this.HasMoved)
            {
                if (board.Instance[this.CurrentLocation_x + (2 * ColorEnumMultiplier), this.CurrentLocation_y] == null)
                {
                    availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x + (2 * ColorEnumMultiplier), this.CurrentLocation_y));
                }
            }

            // potential captures
            if (this.Color == ColorEnum.White)
            {
                if (this.CurrentLocation_x - 1 >= 0 && this.CurrentLocation_y + 1 <= 7)
                {
                    var piece = board.Instance[this.CurrentLocation_x - 1, this.CurrentLocation_y + 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y + 1));
                    }
                }

                if (this.CurrentLocation_x - 1 >= 0 && this.CurrentLocation_y - 1 >= 0)
                {
                    var piece = board.Instance[this.CurrentLocation_x - 1, this.CurrentLocation_y - 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y - 1));
                    }
                }
            }
            else
            {
                if (this.CurrentLocation_x + 1 <= 7 && this.CurrentLocation_y + 1 <= 7)
                {
                    var piece = board.Instance[this.CurrentLocation_x + 1, this.CurrentLocation_y + 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y + 1));
                    }
                }

                if (this.CurrentLocation_x + 1 <= 7 && this.CurrentLocation_y - 1 >= 0)
                {
                    var piece = board.Instance[this.CurrentLocation_x + 1, this.CurrentLocation_y - 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y - 1));
                    }
                }
            }

            return availableMoves;
        }

        public List<Move> AvailableMovesWithDetails(Board.Board board)
        {
            List<Move> availableMoves = new List<Move>();

            int colorEnumMultiplier = this.Color == ColorEnum.White ? -1 : 1;
            // check space row +/- 1
            if (board.Instance[this.CurrentLocation_x + (1 * colorEnumMultiplier), this.CurrentLocation_y] == null)
            {
                availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x + (1 * colorEnumMultiplier), this.CurrentLocation_y)));
            }

            // on home row, row +/- 2 available move
            if (!this.HasMoved)
            {
                if (board.Instance[this.CurrentLocation_x + (2 * colorEnumMultiplier), this.CurrentLocation_y] == null)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x + (2 * colorEnumMultiplier), this.CurrentLocation_y)));
                }
            }

            // potential captures
            if (this.Color == ColorEnum.White)
            {
                if (this.CurrentLocation_x - 1 >= 0 && this.CurrentLocation_y + 1 <= 7)
                {
                    var piece = board.Instance[this.CurrentLocation_x - 1, this.CurrentLocation_y + 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y + 1), piece));
                    }
                }

                if (this.CurrentLocation_x - 1 >= 0 && this.CurrentLocation_y - 1 >= 0)
                {
                    var piece = board.Instance[this.CurrentLocation_x - 1, this.CurrentLocation_y - 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y - 1), piece));
                    }
                }
            }
            else
            {
                if (this.CurrentLocation_x + 1 <= 7 && this.CurrentLocation_y + 1 <= 7)
                {
                    var piece = board.Instance[this.CurrentLocation_x + 1, this.CurrentLocation_y + 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y + 1), piece));
                    }
                }

                if (this.CurrentLocation_x + 1 <= 7 && this.CurrentLocation_y - 1 >= 0)
                {
                    var piece = board.Instance[this.CurrentLocation_x + 1, this.CurrentLocation_y - 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y - 1), piece));
                    }
                }
            }

            return availableMoves;
        }


        public List<KeyValuePair<int, int>> GetCheckPath(Board.Board board)
        {
            // no "path" to intercept for a pawn check
            return new List<KeyValuePair<int, int>>();
        }

        public void Move(int x, int y)
        {
            this.CurrentLocation_x = x;
            this.CurrentLocation_y = y;

            this.HasMoved = true;
        }
    }
}
