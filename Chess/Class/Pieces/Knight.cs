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
            this.CurrentLocation_x = x;
            this.CurrentLocation_y = y;

            Type = TypeEnum.Knight;
            BoardNotation = 'N';
            Value = 3;
            Color = color;
        }

        public List<KeyValuePair<int, int>> AvailableMoves(Board.Board board)
        {
            List<KeyValuePair<int, int>> availableMoves = new List<KeyValuePair<int, int>>();

            GetAvailableMove(board, availableMoves, -2, -1);
            GetAvailableMove(board, availableMoves, -2, 1);
            GetAvailableMove(board, availableMoves, -1, -2);
            GetAvailableMove(board, availableMoves, -1, 2);
            GetAvailableMove(board, availableMoves, 1, 2);
            GetAvailableMove(board, availableMoves, 1, -2);
            GetAvailableMove(board, availableMoves, 2, 1);
            GetAvailableMove(board, availableMoves, 2, -1);

            return availableMoves;
        }

        public void GetAvailableMove(Board.Board board, List<KeyValuePair<int, int>> availableMoves, int rowInterval, int colInterval)
        {
            var row = this.CurrentLocation_x + rowInterval;
            var column = this.CurrentLocation_y + colInterval;
            if (board.InRange(row, column))
            {
                var piece = board.Instance[row, column];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    availableMoves.Add(new KeyValuePair<int, int>(row, column));
                }
            }
        }

        public List<Move> AvailableMovesWithDetails(Board.Board board)
        {
            List<Move> availableMoves = new List<Move>();

            GetAvailableMoveWithDetails(board, availableMoves, -2, -1);
            GetAvailableMoveWithDetails(board, availableMoves, -2, 1);
            GetAvailableMoveWithDetails(board, availableMoves, -1, -2);
            GetAvailableMoveWithDetails(board, availableMoves, -1, 2);
            GetAvailableMoveWithDetails(board, availableMoves, 1, 2);
            GetAvailableMoveWithDetails(board, availableMoves, 1, -2);
            GetAvailableMoveWithDetails(board, availableMoves, 2, 1);
            GetAvailableMoveWithDetails(board, availableMoves, 2, -1);

            return availableMoves;
        }

        public void GetAvailableMoveWithDetails(Board.Board board, List<Move> availableMoves, int rowInterval, int colInterval)
        {
            var row = this.CurrentLocation_x + rowInterval;
            var column = this.CurrentLocation_y + colInterval;
            if (board.InRange(row, column))
            {
                var piece = board.Instance[row, column];
                if (piece == null)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(row, column)));
                }
                else if (piece.Color != Color)
                {
                    availableMoves.Add(new Move(this, new KeyValuePair<int, int>(row, column), piece));
                }
            }
        }

        public List<KeyValuePair<int, int>> GetCheckPath(Board.Board board)
        {
            // no "path" to intercept for a knight check
            return new List<KeyValuePair<int, int>>();
        }

        public void Move(int x, int y)
        {
            this.CurrentLocation_x = x;
            this.CurrentLocation_y = y;
        }
    }
}
