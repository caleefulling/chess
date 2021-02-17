using System;
using System.Collections.Generic;
using Chess.Class.Enum;

namespace Chess.Class.Pieces
{
    [Serializable]
    public class Rook : IPiece
    {
        public PieceTypeEnum Type { get; set; }

        public PieceColorEnum Color { get; set; }

        public char BoardNotation { get; set; }

        public int Value { get; set; }

        public int CurrentLocation_x { get; set; }

        public int CurrentLocation_y { get; set; }

        public bool HasMoved { get; set; }


        public Rook(int x, int y, PieceColorEnum color)
        {
            CurrentLocation_x = x;
            CurrentLocation_y = y;

            Type = PieceTypeEnum.Rook;
            BoardNotation = 'R';
            Value = 5;
            Color = color;
        }

        public List<KeyValuePair<int, int>> AvailableMoves(Board.Board board)
        {
            List<KeyValuePair<int, int>> positionsReturn = new List<KeyValuePair<int, int>>();

            int row = CurrentLocation_x;
            int col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row -= 1;
                if (row >= 0)
                {
                    var piece = board.Instance[row, col];
                    if (piece == null)
                    {
                        positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                    }
                    else
                    {
                        if (piece.Color != Color)
                        {
                            positionsReturn.Add(new KeyValuePair<int, int>(row, col));
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
                        positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                    }
                    else
                    {
                        if (piece.Color != Color)
                        {
                            positionsReturn.Add(new KeyValuePair<int, int>(row, col));
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
                        positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                    }
                    else
                    {
                        if (piece.Color != Color)
                        {
                            positionsReturn.Add(new KeyValuePair<int, int>(row, col));
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
                        positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                    }
                    else
                    {
                        if (piece.Color != Color)
                        {
                            positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return positionsReturn;
        }

        public List<KeyValuePair<int, int>> GetCheckPath(Board.Board board)
        {
            List<KeyValuePair<int, int>> positionsReturn = new List<KeyValuePair<int, int>>();

            bool isCheckPath = false;
            int row = CurrentLocation_x;
            int col = CurrentLocation_y;
            for (int i = 0; i <= 7; i++)
            {
                row -= 1;
                if (row >= 0)
                {
                    var piece = board.Instance[row, col];
                    if (piece == null)
                    {
                        positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                    }
                    else
                    {
                        if (piece.Color != Color)
                        {
                            if (piece.Type == PieceTypeEnum.King)
                            {
                                isCheckPath = true;
                            }
                            positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (isCheckPath)
            {
                return positionsReturn;
            }
            else
            {
                positionsReturn = new List<KeyValuePair<int, int>>();
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
                        positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                    }
                    else
                    {
                        if (piece.Color != Color)
                        {
                            if (piece.Type == PieceTypeEnum.King)
                            {
                                isCheckPath = true;
                            }
                            positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (isCheckPath)
            {
                return positionsReturn;
            }
            else
            {
                positionsReturn = new List<KeyValuePair<int, int>>();
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
                        positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                    }
                    else
                    {
                        if (piece.Color != Color)
                        {
                            if (piece.Type == PieceTypeEnum.King)
                            {
                                isCheckPath = true;
                            }
                            positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (isCheckPath)
            {
                return positionsReturn;
            }
            else
            {
                positionsReturn = new List<KeyValuePair<int, int>>();
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
                        positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                    }
                    else
                    {
                        if (piece.Color != Color)
                        {
                            if (piece.Type == PieceTypeEnum.King)
                            {
                                isCheckPath = true;
                            }
                            positionsReturn.Add(new KeyValuePair<int, int>(row, col));
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (isCheckPath)
            {
                return positionsReturn;
            }
            else
            {
                positionsReturn = new List<KeyValuePair<int, int>>();
            }

            return positionsReturn;
        }


        public void Move(int x, int y)
        {
            CurrentLocation_x = x;
            CurrentLocation_y = y;

            HasMoved = true;
        }
    }
}
