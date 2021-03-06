using System;
using System.Collections.Generic;
using Chess.Class.Enum;

namespace Chess.Class.Pieces
{
    [Serializable]
    public class Queen : IPiece
    {
        public TypeEnum Type { get; set; }

        public ColorEnum Color { get; set; }

        public char BoardNotation { get; set; }

        public int Value { get; set; }

        public int CurrentLocation_x { get; set; }

        public int CurrentLocation_y { get; set; }

        public bool IsAtRisk { get; set; }

        public bool IsPuttingPieceAtRisk { get; set; }


        public Queen(int x, int y, ColorEnum color)
        {
            CurrentLocation_x = x;
            CurrentLocation_y = y;

            Type = TypeEnum.Queen;
            BoardNotation = 'Q';
            Value = 8;
            Color = color;
        }

        public List<KeyValuePair<int, int>> AvailableMoves(Board.Board board)
        {
            List<KeyValuePair<int, int>> availableMoves = new List<KeyValuePair<int, int>>();

            // diagonal (bishop)
            int row = CurrentLocation_x;
            int col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row -= 1;
                col -= 1;
                if (row >= 0 && col >= 0)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row -= 1;
                col += 1;
                if (row >= 0 && col <= 7)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += 1;
                col += 1;
                if (row <= 7 && col <= 7)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += 1;
                col -= 1;
                if (row <= 7 && col >= 0)
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

            // horizontal (rook)
            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row -= 1;
                if (row >= 0)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                col += 1;
                if (col <= 7)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += 1;
                if (row <= 7)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                col -= 1;
                if (col >= 0)
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

            return availableMoves;
        }

        public List<Move> AvailableMovesWithDetails(Board.Board board)
        {
            List<Move> availableMoves = new List<Move>();

            // diagonal (bishop)
            int row = CurrentLocation_x;
            int col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row -= 1;
                col -= 1;
                if (row >= 0 && col >= 0)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row -= 1;
                col += 1;
                if (row >= 0 && col <= 7)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += 1;
                col += 1;
                if (row <= 7 && col <= 7)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += 1;
                col -= 1;
                if (row <= 7 && col >= 0)
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

            // horizontal (rook)
            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row -= 1;
                if (row >= 0)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                col += 1;
                if (col <= 7)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += 1;
                if (row <= 7)
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

            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                col -= 1;
                if (col >= 0)
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

            return availableMoves;
        }


        public List<KeyValuePair<int, int>> GetCheckPath(Board.Board board)
        {
            List<KeyValuePair<int, int>> checkPath = new List<KeyValuePair<int, int>>();

            // diagonal (bishop)
            int row = CurrentLocation_x;
            int col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row -= 1;
                col -= 1;
                if (row >= 0 && col >= 0)
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
                                return checkPath;
                            }
                            break;
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
            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row -= 1;
                col += 1;
                if (row >= 0 && col <= 7)
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
                                return checkPath;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            checkPath = new List<KeyValuePair<int, int>>();
            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += 1;
                col += 1;
                if (row <= 7 && col <= 7)
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
                                return checkPath;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            checkPath = new List<KeyValuePair<int, int>>();
            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += 1;
                col -= 1;
                if (row <= 7 && col >= 0)
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
                                return checkPath;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            // horizontal (rook)
            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row -= 1;
                if (row >= 0)
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
                                return checkPath;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }


            checkPath = new List<KeyValuePair<int, int>>();
            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                col += 1;
                if (col <= 7)
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
                                return checkPath;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            checkPath = new List<KeyValuePair<int, int>>();
            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row += 1;
                if (row <= 7)
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
                                return checkPath;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            checkPath = new List<KeyValuePair<int, int>>();
            row = CurrentLocation_x;
            col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                col -= 1;
                if (col >= 0)
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
                                return checkPath;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return new List<KeyValuePair<int, int>>();
        }

        public void Move(int x, int y)
        {
            CurrentLocation_x = x;
            CurrentLocation_y = y;
        }
    }
}
