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

            int colorEnumMultiplier = this.Color == ColorEnum.White ? -1 : 1;
            // check space row +/- 1
            if (board.Instance[this.CurrentLocation_x + (1 * colorEnumMultiplier), this.CurrentLocation_y] == null)
            {
                availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x + (1 * colorEnumMultiplier), this.CurrentLocation_y));
            }

            // on home row, row +/- 2 available move
            if (!this.HasMoved)
            {
                if (board.Instance[this.CurrentLocation_x + (2 * colorEnumMultiplier), this.CurrentLocation_y] == null)
                {
                    availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x + (2 * colorEnumMultiplier), this.CurrentLocation_y));
                }
            }

            // potential captures
            if (this.Color == ColorEnum.White)
            {
                GetAvailableMove(board, availableMoves, -1, 1);
                GetAvailableMove(board, availableMoves, -1, -1);
            }
            else
            {
                GetAvailableMove(board, availableMoves, 1, 1);
                GetAvailableMove(board, availableMoves, 1, -1);
            }

            return availableMoves;
        }

        public void GetAvailableMove(Board.Board board, List<KeyValuePair<int, int>> availableMoves, int rowInterval, int colInterval)
        {
            var row = this.CurrentLocation_x + rowInterval;
            var column = this.CurrentLocation_y + colInterval;
            if (row >= 0 && row <= 7 && column >= 0 && column <= 7)
            {
                var piece = board.Instance[row, column];
                if (piece != null && piece.Color != this.Color)
                {
                    availableMoves.Add(new KeyValuePair<int, int>(row, column));
                }
            }
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
                GetAvailableMoveWithDetails(board, availableMoves, -1, 1);
                GetAvailableMoveWithDetails(board, availableMoves, -1, -1);
            }
            else
            {
                GetAvailableMoveWithDetails(board, availableMoves, 1, 1);
                GetAvailableMoveWithDetails(board, availableMoves, 1, -1);
            }

            return availableMoves;
        }

        public void GetAvailableMoveWithDetails(Board.Board board, List<Move> availableMoves, int rowInterval, int colInterval)
        {
            var row = this.CurrentLocation_x + rowInterval;
            var column = this.CurrentLocation_y + colInterval;
            if (row >= 0 && row <= 7 && column >= 0 && column <= 7)
            {
                var piece = board.Instance[row, column];
                if (piece != null && piece.Color != this.Color)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(row, column), piece));
                }
            }
        }

        public List<KeyValuePair<int, int>> GetCheckPath(Board.Board board)
        {
            // no "path" to intercept for a pawn check
            return new List<KeyValuePair<int, int>>();
        }

        public void Move(int x, int y)
        {
            this.HasMoved = true;
            this.CurrentLocation_x = x;
            this.CurrentLocation_y = y;
        }
    }
}
