using Chess.Class.Pieces;
using Chess.Class.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chess.Class.Board
{
    [Serializable]
    public class Board
    {
        public IPiece[,] Instance { get; set; }

        public PieceColorEnum ColorToMove { get; set; }

        public King BlackKing { get; set; }

        public King WhiteKing { get; set; }

        public int BlackScore { get; set; }

        public int WhiteScore { get; set; }

        public List<IPiece> CapturedBlackPieces { get; set; }

        public List<IPiece> CapturedWhitePieces { get; set; }

        public Board()
        {
            ColorToMove = PieceColorEnum.White;
            Instance = new IPiece[8, 8];
            CapturedBlackPieces = new List<IPiece>();
            CapturedWhitePieces = new List<IPiece>();

            // black
            Instance[0, 0] = new Rook(0, 0, PieceColorEnum.Black);
            Instance[0, 1] = new Knight(0, 1, PieceColorEnum.Black);
            Instance[0, 2] = new Bishop(0, 2, PieceColorEnum.Black);
            Instance[0, 3] = new Queen(0, 3, PieceColorEnum.Black);
            Instance[0, 4] = new King(0, 4, PieceColorEnum.Black);
            BlackKing = (King)Instance[0, 4];
            Instance[0, 5] = new Bishop(0, 5, PieceColorEnum.Black);
            Instance[0, 6] = new Knight(0, 6, PieceColorEnum.Black);
            Instance[0, 7] = new Rook(0, 7, PieceColorEnum.Black);

            Instance[1, 0] = new Pawn(1, 0, PieceColorEnum.Black);
            Instance[1, 1] = new Pawn(1, 1, PieceColorEnum.Black);
            Instance[1, 2] = new Pawn(1, 2, PieceColorEnum.Black);
            Instance[1, 3] = new Pawn(1, 3, PieceColorEnum.Black);
            Instance[1, 4] = new Pawn(1, 4, PieceColorEnum.Black);
            Instance[1, 5] = new Pawn(1, 5, PieceColorEnum.Black);
            Instance[1, 6] = new Pawn(1, 6, PieceColorEnum.Black);
            Instance[1, 7] = new Pawn(1, 7, PieceColorEnum.Black);

            // white
            Instance[6, 0] = new Pawn(6, 0, PieceColorEnum.White);
            Instance[6, 1] = new Pawn(6, 1, PieceColorEnum.White);
            Instance[6, 2] = new Pawn(6, 2, PieceColorEnum.White);
            Instance[6, 3] = new Pawn(6, 3, PieceColorEnum.White);
            Instance[6, 4] = new Pawn(6, 4, PieceColorEnum.White);
            Instance[6, 5] = new Pawn(6, 5, PieceColorEnum.White);
            Instance[6, 6] = new Pawn(6, 6, PieceColorEnum.White);
            Instance[6, 7] = new Pawn(6, 7, PieceColorEnum.White);

            Instance[7, 0] = new Rook(7, 0, PieceColorEnum.White);
            Instance[7, 1] = new Knight(7, 1, PieceColorEnum.White);
            Instance[7, 2] = new Bishop(7, 2, PieceColorEnum.White);
            Instance[7, 3] = new Queen(7, 3, PieceColorEnum.White);
            Instance[7, 4] = new King(7, 4, PieceColorEnum.White);
            WhiteKing = (King)Instance[7, 4];
            Instance[7, 5] = new Bishop(7, 5, PieceColorEnum.White);
            Instance[7, 6] = new Knight(7, 6, PieceColorEnum.White);
            Instance[7, 7] = new Rook(7, 7, PieceColorEnum.White);


            // test checkmate
            //Instance[0, 0] = new King(0, 0, PieceColorEnum.Black);
            //BlackKing = (King)Instance[0, 0];

            //Instance[3, 3] = new Queen(3, 3, PieceColorEnum.White);
            //Instance[7, 4] = new King(7, 4, PieceColorEnum.White);
            //WhiteKing = (King)Instance[7, 4];
            //Instance[2, 1] = new Rook(2, 1, PieceColorEnum.White);


            //// test castling
            //Instance[0, 0] = new Rook(0, 0, PieceColorEnum.Black);
            //Instance[0, 4] = new King(0, 4, PieceColorEnum.Black);
            //BlackKing = (King)Instance[0, 4];
            //Instance[0, 7] = new Rook(0, 7, PieceColorEnum.Black);

            //Instance[7, 0] = new Rook(7, 0, PieceColorEnum.White);
            //Instance[7, 4] = new King(7, 4, PieceColorEnum.White);
            //WhiteKing = (King)Instance[7, 4];
            //Instance[7, 7] = new Rook(7, 7, PieceColorEnum.White);
        }

        public void PrintBoardWithTakenPieces()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  A B C D E F G H");
            for (int i = 0; i < 8; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{8 - i} ");
                for (int j = 0; j < 8; j++)
                {
                    if (Instance[i, j] != null)
                    {
                        if (Instance[i, j].Color == PieceColorEnum.Black) Console.ForegroundColor = ConsoleColor.Blue;
                        else Console.ForegroundColor = ConsoleColor.White;

                        Console.Write($"{ Instance[i, j].BoardNotation } ");
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            if (j % 2 == 0) Console.ForegroundColor = ConsoleColor.White;
                            else Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else
                        {
                            if (j % 2 == 0) Console.ForegroundColor = ConsoleColor.Blue;
                            else Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.Write(". ");
                    }
                }

                if (i == 0 && CapturedWhitePieces.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"  ");

                    foreach (var pieceToPrint in CapturedWhitePieces.OrderByDescending(e => e.Value))
                    {
                        Console.Write($"{pieceToPrint.BoardNotation} ");
                    }

                    if (this.BlackScore > 0 && this.WhiteScore != this.BlackScore)
                    {
                        Console.Write($"up {this.BlackScore}");
                    }
                }
                else if (i == 7 && CapturedBlackPieces.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"  ");

                    foreach (var pieceToPrint in CapturedBlackPieces.OrderByDescending(e => e.Value))
                    {
                        Console.Write($"{pieceToPrint.BoardNotation} ");
                    }

                    if (this.WhiteScore > 0 && this.BlackScore != this.WhiteScore)
                    {
                        Console.Write($"up {this.WhiteScore}");
                    }
                }

                Console.WriteLine();
            }
        }

        public KeyValuePair<int, int> ConvertNotationForMove(string move)
        {
            var moveArray = move.ToCharArray();
            int x = 0;
            switch (moveArray[0])
            {
                case 'a':
                    x = 0;
                    break;
                case 'b':
                    x = 1;
                    break;
                case 'c':
                    x = 2;
                    break;
                case 'd':
                    x = 3;
                    break;
                case 'e':
                    x = 4;
                    break;
                case 'f':
                    x = 5;
                    break;
                case 'g':
                    x = 6;
                    break;
                case 'h':
                    x = 7;
                    break;
                default:
                    x = 8;
                    break;
            }

            int y = 0;
            switch (moveArray[1])
            {
                case '8':
                    y = 0;
                    break;
                case '7':
                    y = 1;
                    break;
                case '6':
                    y = 2;
                    break;
                case '5':
                    y = 3;
                    break;
                case '4':
                    y = 4;
                    break;
                case '3':
                    y = 5;
                    break;
                case '2':
                    y = 6;
                    break;
                case '1':
                    y = 7;
                    break;
                default:
                    y = 8;
                    break;
            }

            return new KeyValuePair<int, int>(y, x);
        }

        public void MovePiece(IPiece piece, int x, int y)
        {
            if (Instance[x, y] != null)
            {
                // is a capture. update scores
                var capturedPiece = Instance[x, y];
                switch (capturedPiece.Color)
                {
                    case PieceColorEnum.Black:
                        this.WhiteScore += capturedPiece.Value;
                        this.BlackScore -= capturedPiece.Value;
                        CapturedBlackPieces.Add(capturedPiece);
                        break;
                    case PieceColorEnum.White:
                        this.BlackScore += capturedPiece.Value;
                        this.WhiteScore -= capturedPiece.Value;
                        CapturedWhitePieces.Add(capturedPiece);
                        break;
                }
            }

            Instance[x, y] = piece;
            Instance[piece.CurrentLocation_x, piece.CurrentLocation_y] = null;
            piece.Move(x, y);
        }

        public object DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;
                return formatter.Deserialize(ms);
            }
        }
    }
}
