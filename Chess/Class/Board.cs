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

        public ColorEnum ColorToMove { get; set; }

        public King BlackKing { get; set; }

        public King WhiteKing { get; set; }

        public int BlackScore { get; set; }

        public int WhiteScore { get; set; }

        public List<IPiece> CapturedBlackPieces { get; set; }

        public List<IPiece> CapturedWhitePieces { get; set; }

        public int MovesSinceLastCaptureOrPawnMove { get; set; }

        public Board()
        {
            ColorToMove = ColorEnum.White;
            Instance = new IPiece[8, 8];
            CapturedBlackPieces = new List<IPiece>();
            CapturedWhitePieces = new List<IPiece>();

            // black
            Instance[0, 0] = new Rook(0, 0, ColorEnum.Black);
            Instance[0, 1] = new Knight(0, 1, ColorEnum.Black);
            Instance[0, 2] = new Bishop(0, 2, ColorEnum.Black);
            Instance[0, 3] = new Queen(0, 3, ColorEnum.Black);
            Instance[0, 4] = new King(0, 4, ColorEnum.Black);
            BlackKing = (King)Instance[0, 4];
            Instance[0, 5] = new Bishop(0, 5, ColorEnum.Black);
            Instance[0, 6] = new Knight(0, 6, ColorEnum.Black);
            Instance[0, 7] = new Rook(0, 7, ColorEnum.Black);

            Instance[1, 0] = new Pawn(1, 0, ColorEnum.Black);
            Instance[1, 1] = new Pawn(1, 1, ColorEnum.Black);
            Instance[1, 2] = new Pawn(1, 2, ColorEnum.Black);
            Instance[1, 3] = new Pawn(1, 3, ColorEnum.Black);
            Instance[1, 4] = new Pawn(1, 4, ColorEnum.Black);
            Instance[1, 5] = new Pawn(1, 5, ColorEnum.Black);
            Instance[1, 6] = new Pawn(1, 6, ColorEnum.Black);
            Instance[1, 7] = new Pawn(1, 7, ColorEnum.Black);

            // white
            Instance[6, 0] = new Pawn(6, 0, ColorEnum.White);
            Instance[6, 1] = new Pawn(6, 1, ColorEnum.White);
            Instance[6, 2] = new Pawn(6, 2, ColorEnum.White);
            Instance[6, 3] = new Pawn(6, 3, ColorEnum.White);
            Instance[6, 4] = new Pawn(6, 4, ColorEnum.White);
            Instance[6, 5] = new Pawn(6, 5, ColorEnum.White);
            Instance[6, 6] = new Pawn(6, 6, ColorEnum.White);
            Instance[6, 7] = new Pawn(6, 7, ColorEnum.White);

            Instance[7, 0] = new Rook(7, 0, ColorEnum.White);
            Instance[7, 1] = new Knight(7, 1, ColorEnum.White);
            Instance[7, 2] = new Bishop(7, 2, ColorEnum.White);
            Instance[7, 3] = new Queen(7, 3, ColorEnum.White);
            Instance[7, 4] = new King(7, 4, ColorEnum.White);
            WhiteKing = (King)Instance[7, 4];
            Instance[7, 5] = new Bishop(7, 5, ColorEnum.White);
            Instance[7, 6] = new Knight(7, 6, ColorEnum.White);
            Instance[7, 7] = new Rook(7, 7, ColorEnum.White);


            // test checkmate
            //Instance[0, 0] = new King(0, 0, ColorEnum.Black);
            //BlackKing = (King)Instance[0, 0];

            //Instance[3, 3] = new Queen(3, 3, ColorEnum.White);
            //Instance[7, 4] = new King(7, 4, ColorEnum.White);
            //WhiteKing = (King)Instance[7, 4];
            //Instance[2, 1] = new Rook(2, 1, ColorEnum.White);


            //// test castling
            //Instance[0, 0] = new Rook(0, 0, ColorEnum.Black);
            //Instance[0, 4] = new King(0, 4, ColorEnum.Black);
            //BlackKing = (King)Instance[0, 4];
            //Instance[0, 7] = new Rook(0, 7, ColorEnum.Black);

            //Instance[7, 0] = new Rook(7, 0, ColorEnum.White);
            //Instance[7, 4] = new King(7, 4, ColorEnum.White);
            //WhiteKing = (King)Instance[7, 4];
            //Instance[7, 7] = new Rook(7, 7, ColorEnum.White);
        }

        public Board(bool setup)
        {
            ColorToMove = ColorEnum.White;
            Instance = new IPiece[8, 8];
            CapturedBlackPieces = new List<IPiece>();
            CapturedWhitePieces = new List<IPiece>();

            Console.WriteLine("enter black positions");
            // Q b4
            string input = string.Empty;
            KeyValuePair<int, int> prevCoordinates = new KeyValuePair<int, int>();
            while (input != "exit")
            {
                this.PrintBoardWithTakenPieces();

                input = Console.ReadLine();
                if (input == "next")
                {
                    input = "exit";
                    continue;
                }

                if (input == "undo")
                {
                    this.Instance[prevCoordinates.Key, prevCoordinates.Value] = null;
                    continue;
                }

                try
                {
                    var inputSplit = input.Split(' ');
                    var coordinates = prevCoordinates = this.ConvertNotationForMove(inputSplit[1]);
                    switch (inputSplit[0].ToUpper())
                    {
                        case "Q":
                            this.Instance[coordinates.Key, coordinates.Value] = new Queen(coordinates.Key, coordinates.Value, ColorEnum.Black);
                            break;
                        case "R":
                            this.Instance[coordinates.Key, coordinates.Value] = new Rook(coordinates.Key, coordinates.Value, ColorEnum.Black);
                            break;
                        case "B":
                            this.Instance[coordinates.Key, coordinates.Value] = new Bishop(coordinates.Key, coordinates.Value, ColorEnum.Black);
                            break;
                        case "N":
                            this.Instance[coordinates.Key, coordinates.Value] = new Knight(coordinates.Key, coordinates.Value, ColorEnum.Black);
                            break;
                        case "P":
                            Pawn pawn = new Pawn(coordinates.Key, coordinates.Value, ColorEnum.Black);
                            pawn.HasMoved = true;
                            this.Instance[coordinates.Key, coordinates.Value] = pawn; break;
                        case "K":
                            this.Instance[coordinates.Key, coordinates.Value] = new King(coordinates.Key, coordinates.Value, ColorEnum.Black);
                            this.BlackKing = (King)Instance[coordinates.Key, coordinates.Value];
                            break;
                        default:
                            Console.WriteLine("try again");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("try again");
                }
            }

            input = string.Empty;
            prevCoordinates = new KeyValuePair<int, int>();
            Console.WriteLine("enter white positions");
            this.PrintBoardWithTakenPieces();
            while (input != "exit")
            {
                this.PrintBoardWithTakenPieces();
                input = Console.ReadLine();
                if (input == "next")
                {
                    input = "exit";
                    continue;
                }
                if (input == "undo")
                {
                    this.Instance[prevCoordinates.Key, prevCoordinates.Value] = null;
                    this.BlackKing = null;
                    continue;
                }

                try
                {
                    var inputSplit = input.Split(' ');
                    var coordinates = prevCoordinates = this.ConvertNotationForMove(inputSplit[1]);
                    switch (inputSplit[0])
                    {
                        case "Q":
                            this.Instance[coordinates.Key, coordinates.Value] = new Queen(coordinates.Key, coordinates.Value, ColorEnum.White);
                            break;
                        case "R":
                            this.Instance[coordinates.Key, coordinates.Value] = new Rook(coordinates.Key, coordinates.Value, ColorEnum.White);
                            break;
                        case "B":
                            this.Instance[coordinates.Key, coordinates.Value] = new Bishop(coordinates.Key, coordinates.Value, ColorEnum.White);
                            break;
                        case "N":
                            this.Instance[coordinates.Key, coordinates.Value] = new Knight(coordinates.Key, coordinates.Value, ColorEnum.White);
                            break;
                        case "P":
                            Pawn pawn = new Pawn(coordinates.Key, coordinates.Value, ColorEnum.White);
                            pawn.HasMoved = true;
                            this.Instance[coordinates.Key, coordinates.Value] = pawn;
                            break;
                        case "K":
                            this.Instance[coordinates.Key, coordinates.Value] = new King(coordinates.Key, coordinates.Value, ColorEnum.White);
                            this.WhiteKing = (King)Instance[coordinates.Key, coordinates.Value];
                            break;
                        default:
                            Console.WriteLine("try again");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("try again");
                }
            }
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
                        if (Instance[i, j].Color == ColorEnum.Black) Console.ForegroundColor = ConsoleColor.Blue;
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
                        Console.Write($"(up {this.BlackScore})");
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
                        Console.Write($"(up {this.WhiteScore})");
                    }
                }

                Console.WriteLine();
            }
        }

        public KeyValuePair<int, int> ConvertNotationForMove(string move)
        {
            var moveArray = move.ToCharArray();
            int x = 0;
            switch (moveArray[0].ToString().ToLower())
            {
                case "a":
                    x = 0;
                    break;
                case "b":
                    x = 1;
                    break;
                case "c":
                    x = 2;
                    break;
                case "d":
                    x = 3;
                    break;
                case "e":
                    x = 4;
                    break;
                case "f":
                    x = 5;
                    break;
                case "g":
                    x = 6;
                    break;
                case "h":
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

        public string ConvertMoveForNotation(int column, int row)
        {
            string notation = String.Empty;
            switch (column)
            {
                case 0:
                    notation += 'a';
                    break;
                case 1:
                    notation += 'b';
                    break;
                case 2:
                    notation += 'c';
                    break;
                case 3:
                    notation += 'd';
                    break;
                case 4:
                    notation += 'e';
                    break;
                case 5:
                    notation += 'f';
                    break;
                case 6:
                    notation += 'g';
                    break;
                case 7:
                    notation += 'h';
                    break;
            }

            switch (row)
            {
                case 0:
                    notation += '8';
                    break;
                case 1:
                    notation += '7';
                    break;
                case 2:
                    notation += '6';
                    break;
                case 3:
                    notation += '5';
                    break;
                case 4:
                    notation += '4';
                    break;
                case 5:
                    notation += '3';
                    break;
                case 6:
                    notation += '2';
                    break;
                case 7:
                    notation += '1';
                    break;
            }

            return notation;
        }


        public void MovePiece(IPiece piece, int x, int y)
        {
            bool isCapture = false;
            if (Instance[x, y] != null)
            {
                // is a capture. update scores
                isCapture = true;
                var capturedPiece = Instance[x, y];
                switch (capturedPiece.Color)
                {
                    case ColorEnum.Black:
                        this.WhiteScore += capturedPiece.Value;
                        this.BlackScore -= capturedPiece.Value;
                        CapturedBlackPieces.Add(capturedPiece);
                        break;
                    case ColorEnum.White:
                        this.BlackScore += capturedPiece.Value;
                        this.WhiteScore -= capturedPiece.Value;
                        CapturedWhitePieces.Add(capturedPiece);
                        break;
                }
            }

            if (isCapture || piece.Type == TypeEnum.Pawn)
            {
                MovesSinceLastCaptureOrPawnMove = 0;
            }
            else
            {
                MovesSinceLastCaptureOrPawnMove++;
            }

            Instance[x, y] = piece;
            Instance[piece.CurrentLocation_x, piece.CurrentLocation_y] = null;
            piece.Move(x, y);

            // pawn promotion
            if (piece.Type == TypeEnum.Pawn &&
                (this.ColorToMove == ColorEnum.White && x == 0) || (this.ColorToMove == ColorEnum.Black && x == 7))
            {
                PromotePawn(piece);
            }
        }

        public void PromotePawn(IPiece piece)
        {
            var valid = false;
            Console.WriteLine("Q R B N");
            while (!valid)
            {
                Console.Write("> ");
                var newPieceType = Console.ReadLine();
                switch (newPieceType)
                {
                    case "Q":
                        this.Instance[piece.CurrentLocation_x, piece.CurrentLocation_y] = new Queen(piece.CurrentLocation_x, piece.CurrentLocation_y, this.ColorToMove);
                        valid = true;
                        break;
                    case "R":
                        this.Instance[piece.CurrentLocation_x, piece.CurrentLocation_y] = new Rook(piece.CurrentLocation_x, piece.CurrentLocation_y, this.ColorToMove);
                        valid = true;
                        break;
                    case "B":
                        this.Instance[piece.CurrentLocation_x, piece.CurrentLocation_y] = new Bishop(piece.CurrentLocation_x, piece.CurrentLocation_y, this.ColorToMove);
                        valid = true;
                        break;
                    case "N":
                        this.Instance[piece.CurrentLocation_x, piece.CurrentLocation_y] = new Knight(piece.CurrentLocation_x, piece.CurrentLocation_y, this.ColorToMove);
                        valid = true;
                        break;
                    default:
                        valid = false;
                        break;
                }
            }
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

        public void FindBestMove_OneLayer()
        {
            // stuff that might impact a move's "score"
            //    does the move capture?
            //    does the move put that piece (or any of my pieces) at risk?
            //    if the move is a capture, and it puts that piece (or any piece) at risk, is it worth it in points?
            foreach (var piece in Instance)
            {
                if (piece != null && piece.Color == this.ColorToMove)
                {
                    var moves = piece.AvailableMoves(this);
                    foreach (var move in moves)
                    {
                        var pieceCopy = (IPiece)this.DeepClone(piece);
                        var simBoard = (Board)this.DeepClone(this);
                    }
                }
            }
        }
    }
}
