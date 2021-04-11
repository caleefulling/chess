using System;
using System.Collections.Generic;
using System.Linq;
using Chess.Class.Enum;

namespace Chess.Class.Pieces
{
    [Serializable]
    public class Rook : IPiece
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


        public Rook(int x, int y, ColorEnum color)
        {
            this.CurrentLocation_x = x;
            this.CurrentLocation_y = y;

            Type = TypeEnum.Rook;
            BoardNotation = 'R';
            Value = 5;
            Color = color;
        }

        public List<KeyValuePair<int, int>> AvailableMoves(Board.Board board)
        {
            List<KeyValuePair<int, int>> availableMoves = new List<KeyValuePair<int, int>>();

            GetAvailableMovesInInterval(board, availableMoves, -1, 0);
            GetAvailableMovesInInterval(board, availableMoves, 0, -1);
            GetAvailableMovesInInterval(board, availableMoves, 0, 1);
            GetAvailableMovesInInterval(board, availableMoves, 1, 0);

            return availableMoves;
        }

        public void GetAvailableMovesInInterval(Board.Board board, List<KeyValuePair<int, int>> availableMoves, int rowInterval, int colInterval)
        {
            int row = this.CurrentLocation_x;
            int col = this.CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += rowInterval;
                col += colInterval;
                if (board.IsInRange(row, col))
                {
                    var piece = board.Instance[row, col];
                    if (piece == null)
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(row, col));
                    }
                    else
                    {
                        if (piece.Color != this.Color)
                        {
                            availableMoves.Add(new KeyValuePair<int, int>(row, col));
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public List<Move> AvailableMovesWithDetails(Board.Board board)
        {
            List<Move> availableMoves = new List<Move>();

            GetAvailableMovesWithDetailsInInterval(board, availableMoves, -1, 0);
            GetAvailableMovesWithDetailsInInterval(board, availableMoves, 0, -1);
            GetAvailableMovesWithDetailsInInterval(board, availableMoves, 0, 1);
            GetAvailableMovesWithDetailsInInterval(board, availableMoves, 1, 0);

            return availableMoves;
        }

        public void GetAvailableMovesWithDetailsInInterval(Board.Board board, List<Move> availableMoves, int rowInterval, int colInterval)
        {
            int row = this.CurrentLocation_x;
            int col = this.CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += rowInterval;
                col += colInterval;
                if (board.IsInRange(row, col))
                {
                    var piece = board.Instance[row, col];
                    if (piece == null)
                    {
                        availableMoves.Add(new Move(this, new KeyValuePair<int, int>(row, col)));
                    }
                    else
                    {
                        if (piece.Color != this.Color)
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(row, col), piece));
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public List<KeyValuePair<int, int>> GetCheckPath(Board.Board board)
        {
            List<KeyValuePair<int, int>> checkPath = new List<KeyValuePair<int, int>>();

            GetCheckPathInInterval(board, checkPath, -1, 0);
            if (!checkPath.Any())
                GetCheckPathInInterval(board, checkPath, 0, -1);
            if (!checkPath.Any())
                GetCheckPathInInterval(board, checkPath, 0, 1);
            if (!checkPath.Any())
                GetCheckPathInInterval(board, checkPath, 1, 0);

            return checkPath;
        }

        public void GetCheckPathInInterval(Board.Board board, List<KeyValuePair<int, int>> checkPath, int rowInterval, int colInterval)
        {
            int row = this.CurrentLocation_x;
            int col = this.CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += rowInterval;
                col += colInterval;
                if (board.IsInRange(row, col))
                {
                    var piece = board.Instance[row, col];
                    if (piece == null)
                    {
                        checkPath.Add(new KeyValuePair<int, int>(row, col));
                    }
                    else
                    {
                        if (piece.Color != this.Color)
                        {
                            checkPath.Add(new KeyValuePair<int, int>(row, col));
                            if (piece.Type == TypeEnum.King)
                            {
                                return;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            checkPath = new List<KeyValuePair<int, int>>();
        }


        public void Move(int x, int y)
        {
            this.CurrentLocation_x = x;
            this.CurrentLocation_y = y;

            HasMoved = true;
        }
    }
}
