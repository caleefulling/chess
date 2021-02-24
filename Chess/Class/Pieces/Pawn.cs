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


        public Pawn(int x, int y, ColorEnum color)
        {
            CurrentLocation_x = x;
            CurrentLocation_y = y;

            Type = TypeEnum.Pawn;
            BoardNotation = 'P';
            Value = 1;
            Color = color;
        }

        public List<Move> AvailableMoves(Board.Board board, bool? test)
        {
            List<Move> moves = new List<Move>();
            //List<KeyValuePair<int, int>> availableMoves = new List<KeyValuePair<int, int>>();

            int ColorEnumMultiplier = this.Color == ColorEnum.White ? -1 : 1;
            // check space row +/- 1
            if (board.Instance[CurrentLocation_x + (1 * ColorEnumMultiplier), CurrentLocation_y] == null)
            {
                moves.Add(new Move(this, CurrentLocation_x + (1 * ColorEnumMultiplier), CurrentLocation_y));
                //availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + (1 * ColorEnumMultiplier), CurrentLocation_y));
            }

            // on home row, row +/- 2 available move
            if (!this.HasMoved)
            {
                if (board.Instance[CurrentLocation_x + (2 * ColorEnumMultiplier), CurrentLocation_y] == null)
                {
                    moves.Add(new Move(this, CurrentLocation_x + (2 * ColorEnumMultiplier), CurrentLocation_y));
                    //availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + (2 * ColorEnumMultiplier), CurrentLocation_y));
                }

            }

            // potential captures
            if (this.Color == ColorEnum.White)
            {
                if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y + 1 <= 7)
                {
                    var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y + 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        moves.Add(new Move(this, CurrentLocation_x - 1, CurrentLocation_y + 1, piece.Value));
                        //availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y + 1));
                    }
                }

                if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y - 1 >= 0)
                {
                    var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y - 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        moves.Add(new Move(this, CurrentLocation_x - 1, CurrentLocation_y - 1, piece.Value));
                        //availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y - 1));
                    }
                }
            }
            else
            {
                if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y + 1 <= 7)
                {
                    var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y + 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        moves.Add(new Move(this, CurrentLocation_x + 1, CurrentLocation_y + 1, piece.Value));
                        //availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y + 1));
                    }
                }

                if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y - 1 >= 0)
                {
                    var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y - 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        moves.Add(new Move(this, CurrentLocation_x + 1, CurrentLocation_y - 1, piece.Value));
                        //availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y - 1));
                    }
                }
            }

            return moves;
        }

        public List<KeyValuePair<int, int>> AvailableMoves(Board.Board board)
        {
            List<KeyValuePair<int, int>> availableMoves = new List<KeyValuePair<int, int>>();

            int ColorEnumMultiplier = this.Color == ColorEnum.White ? -1 : 1;
            // check space row +/- 1
            if (board.Instance[CurrentLocation_x + (1 * ColorEnumMultiplier), CurrentLocation_y] == null)
            {
                availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + (1 * ColorEnumMultiplier), CurrentLocation_y));
            }

            // on home row, row +/- 2 available move
            if (!this.HasMoved)
            {
                if (board.Instance[CurrentLocation_x + (2 * ColorEnumMultiplier), CurrentLocation_y] == null)
                {
                    availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + (2 * ColorEnumMultiplier), CurrentLocation_y));
                }

            }

            // potential captures
            if (this.Color == ColorEnum.White)
            {
                if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y + 1 <= 7)
                {
                    var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y + 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y + 1));
                    }
                }

                if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y - 1 >= 0)
                {
                    var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y - 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y - 1));
                    }
                }
            }
            else
            {
                if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y + 1 <= 7)
                {
                    var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y + 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y + 1));
                    }
                }

                if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y - 1 >= 0)
                {
                    var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y - 1];
                    if (piece != null && piece.Color != this.Color)
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y - 1));
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
            CurrentLocation_x = x;
            CurrentLocation_y = y;

            HasMoved = true;
        }
    }
}
