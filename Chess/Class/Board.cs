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

        public Board(string manualBoard)
        {
            this.ColorToMove = ColorEnum.White;
            this.Instance = new IPiece[8, 8];
            this.CapturedBlackPieces = new List<IPiece>();
            this.CapturedWhitePieces = new List<IPiece>();

            if (Convert.ToBoolean(manualBoard))
            {
                this.ManualBoardSetup();
            }
            else
            {
                // standard board initiation 
                this.Instance[0, 0] = new Rook(0, 0, ColorEnum.Black);
                this.Instance[0, 1] = new Knight(0, 1, ColorEnum.Black);
                this.Instance[0, 2] = new Bishop(0, 2, ColorEnum.Black);
                this.Instance[0, 3] = new Queen(0, 3, ColorEnum.Black);
                this.Instance[0, 4] = new King(0, 4, ColorEnum.Black);
                this.BlackKing = (King)Instance[0, 4];
                this.Instance[0, 5] = new Bishop(0, 5, ColorEnum.Black);
                this.Instance[0, 6] = new Knight(0, 6, ColorEnum.Black);
                this.Instance[0, 7] = new Rook(0, 7, ColorEnum.Black);

                this.Instance[1, 0] = new Pawn(1, 0, ColorEnum.Black);
                this.Instance[1, 1] = new Pawn(1, 1, ColorEnum.Black);
                this.Instance[1, 2] = new Pawn(1, 2, ColorEnum.Black);
                this.Instance[1, 3] = new Pawn(1, 3, ColorEnum.Black);
                this.Instance[1, 4] = new Pawn(1, 4, ColorEnum.Black);
                this.Instance[1, 5] = new Pawn(1, 5, ColorEnum.Black);
                this.Instance[1, 6] = new Pawn(1, 6, ColorEnum.Black);
                this.Instance[1, 7] = new Pawn(1, 7, ColorEnum.Black);


                this.Instance[6, 0] = new Pawn(6, 0, ColorEnum.White);
                this.Instance[6, 1] = new Pawn(6, 1, ColorEnum.White);
                this.Instance[6, 2] = new Pawn(6, 2, ColorEnum.White);
                this.Instance[6, 3] = new Pawn(6, 3, ColorEnum.White);
                this.Instance[6, 4] = new Pawn(6, 4, ColorEnum.White);
                this.Instance[6, 5] = new Pawn(6, 5, ColorEnum.White);
                this.Instance[6, 6] = new Pawn(6, 6, ColorEnum.White);
                this.Instance[6, 7] = new Pawn(6, 7, ColorEnum.White);

                this.Instance[7, 0] = new Rook(7, 0, ColorEnum.White);
                this.Instance[7, 1] = new Knight(7, 1, ColorEnum.White);
                this.Instance[7, 2] = new Bishop(7, 2, ColorEnum.White);
                this.Instance[7, 3] = new Queen(7, 3, ColorEnum.White);
                this.Instance[7, 4] = new King(7, 4, ColorEnum.White);
                this.WhiteKing = (King)Instance[7, 4];
                this.Instance[7, 5] = new Bishop(7, 5, ColorEnum.White);
                this.Instance[7, 6] = new Knight(7, 6, ColorEnum.White);
                this.Instance[7, 7] = new Rook(7, 7, ColorEnum.White);
            }
        }

        // manual board initiation 
        public void ManualBoardSetup()
        {
            Console.WriteLine("enter black positions");

            bool exit = false;
            var input = string.Empty;
            KeyValuePair<int, int> prevCoordinates = new KeyValuePair<int, int>();
            while (!exit)
            {
                this.PrintBoardWithTakenPieces();

                input = Console.ReadLine();
                if (input == "next")
                {
                    exit = true;
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
                            this.Instance[coordinates.Key, coordinates.Value] = new Pawn(coordinates.Key, coordinates.Value, ColorEnum.Black);
                            break;
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

            exit = false;
            input = string.Empty;
            prevCoordinates = new KeyValuePair<int, int>();
            Console.WriteLine("enter white positions");
            while (!exit)
            {
                this.PrintBoardWithTakenPieces();
                input = Console.ReadLine();
                if (input == "next")
                {
                    exit = true;
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
                            this.Instance[coordinates.Key, coordinates.Value] = new Pawn(coordinates.Key, coordinates.Value, ColorEnum.White);
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

                if (i == 0 && this.CapturedWhitePieces.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"  ");

                    foreach (var pieceToPrint in this.CapturedWhitePieces.OrderByDescending(e => e.Value))
                    {
                        Console.Write($"{pieceToPrint.BoardNotation} ");
                    }

                    if (this.BlackScore > 0 && this.WhiteScore != this.BlackScore)
                    {
                        Console.Write($"(up {this.BlackScore})");
                    }
                }
                else if (i == 7 && this.CapturedBlackPieces.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"  ");

                    foreach (var pieceToPrint in this.CapturedBlackPieces.OrderByDescending(e => e.Value))
                    {
                        Console.Write($"{pieceToPrint.BoardNotation} ");
                    }

                    if (this.WhiteScore > 0 && this.BlackScore != this.WhiteScore)
                    {
                        Console.Write($"(up {this.WhiteScore})");
                    }
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public KeyValuePair<int, int> ConvertNotationForMove(string move)
        {
            var moveArray = move.ToCharArray();
            int column = 0;
            switch (moveArray[0].ToString().ToLower())
            {
                case "a":
                    column = 0;
                    break;
                case "b":
                    column = 1;
                    break;
                case "c":
                    column = 2;
                    break;
                case "d":
                    column = 3;
                    break;
                case "e":
                    column = 4;
                    break;
                case "f":
                    column = 5;
                    break;
                case "g":
                    column = 6;
                    break;
                case "h":
                    column = 7;
                    break;
                default:
                    column = 8;
                    break;
            }

            int row = 0;
            switch (moveArray[1])
            {
                case '8':
                    row = 0;
                    break;
                case '7':
                    row = 1;
                    break;
                case '6':
                    row = 2;
                    break;
                case '5':
                    row = 3;
                    break;
                case '4':
                    row = 4;
                    break;
                case '3':
                    row = 5;
                    break;
                case '2':
                    row = 6;
                    break;
                case '1':
                    row = 7;
                    break;
                default:
                    row = 8;
                    break;
            }

            return new KeyValuePair<int, int>(row, column);
        }

        public string ConvertMoveForNotation(int row, int column)
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
            if (this.Instance[x, y] != null)
            {
                // is a capture. update scores
                var capturedPiece = this.Instance[x, y];
                switch (capturedPiece.Color)
                {
                    case ColorEnum.Black:
                        this.WhiteScore += capturedPiece.Value;
                        this.BlackScore -= capturedPiece.Value;
                        this.CapturedBlackPieces.Add(capturedPiece);
                        break;
                    case ColorEnum.White:
                        this.BlackScore += capturedPiece.Value;
                        this.WhiteScore -= capturedPiece.Value;
                        this.CapturedWhitePieces.Add(capturedPiece);
                        break;
                }
            }

            this.Instance[x, y] = piece;
            this.Instance[piece.CurrentLocation_x, piece.CurrentLocation_y] = null;
            piece.Move(x, y);

            // pawn promotion
            if (piece.Type == TypeEnum.Pawn && (this.ColorToMove == ColorEnum.White && x == 0) || (this.ColorToMove == ColorEnum.Black && x == 7))
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
                valid = true;
                Console.Write("> ");
                var newPieceType = Console.ReadLine();
                switch (newPieceType)
                {
                    case "Q":
                        this.Instance[piece.CurrentLocation_x, piece.CurrentLocation_y] = new Queen(piece.CurrentLocation_x, piece.CurrentLocation_y, this.ColorToMove);
                        break;
                    case "R":
                        this.Instance[piece.CurrentLocation_x, piece.CurrentLocation_y] = new Rook(piece.CurrentLocation_x, piece.CurrentLocation_y, this.ColorToMove);
                        break;
                    case "B":
                        this.Instance[piece.CurrentLocation_x, piece.CurrentLocation_y] = new Bishop(piece.CurrentLocation_x, piece.CurrentLocation_y, this.ColorToMove);
                        break;
                    case "N":
                        this.Instance[piece.CurrentLocation_x, piece.CurrentLocation_y] = new Knight(piece.CurrentLocation_x, piece.CurrentLocation_y, this.ColorToMove);
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

        public Move? FindBestMove_OneLayer(Board board, int layer)
        {
            //if (layer > 3)
            //{
            //    return null;
            //}

            List<Move> moves = new List<Move>();

            // function for taking the board and finding the point value of pieces currently at risk
            // call this before the move and then after, and compare the point value difference (ie did the move result in an at risk change?)
            var currentSideRiskValue = board.CurrentSideRiskValue();
            var currentSideOffenseValue = board.CurrentSideOffenseValue();

            foreach (var piece in Instance)
            {
                if (piece != null && piece.Color == board.ColorToMove)
                {
                    var availableMoves = piece.AvailableMovesWithDetails(this);
                    foreach (var move in availableMoves)
                    {
                        var pieceCopy = (IPiece)board.DeepClone(piece);
                        var simBoard = (Board)board.DeepClone(board);
                        simBoard.MovePiece(pieceCopy, move.MoveCoordinates.Key, move.MoveCoordinates.Value);
                        move.AtRiskValue = simBoard.CurrentSideRiskValue() - currentSideRiskValue;
                        move.OffenseScore = simBoard.CurrentSideOffenseValue() + move.CaptureValue - currentSideOffenseValue;
                        move.CalculateMoveScore();
                        moves.Add(move);
                        //_ = simBoard.FindBestMove_OneLayer(simBoard, layer + 1);

                    }
                }
            }

            return moves.OrderBy(e => e.Score).FirstOrDefault();

            //return moves.OrderByDescending(e => e.IsCapture).ThenByDescending(e => e.CaptureValue).ThenBy(e => e.AtRiskValue).ThenBy(e => e.MoveLocationScore).FirstOrDefault();
        }

        public int CurrentSideRiskValue()
        {
            List<KeyValuePair<int, int>> defenseAvailableMoves = new List<KeyValuePair<int, int>>();
            int riskValue = 0;
            foreach (var piece in this.Instance)
            {
                if (piece != null && piece.Color != this.ColorToMove)
                {
                    defenseAvailableMoves.AddRange(piece.AvailableMoves(this));
                }
            }

            foreach (var piece in this.Instance)
            {
                if (piece != null && piece.Color == this.ColorToMove)
                {
                    if (defenseAvailableMoves.Contains(new KeyValuePair<int, int>(piece.CurrentLocation_x, piece.CurrentLocation_y)))
                    {
                        piece.IsAtRisk = true; // not using this for anything right now
                        riskValue += piece.Value;
                    }
                }
            }

            return riskValue;
        }

        public int CurrentSideOffenseValue()
        {
            List<KeyValuePair<int, int>> offenseAvailableMoves = new List<KeyValuePair<int, int>>();
            int riskValue = 0;
            foreach (var piece in this.Instance)
            {
                if (piece != null && piece.Color == this.ColorToMove)
                {
                    offenseAvailableMoves.AddRange(piece.AvailableMoves(this));
                }
            }

            foreach (var piece in this.Instance)
            {
                if (piece != null && piece.Color != this.ColorToMove)
                {
                    if (offenseAvailableMoves.Contains(new KeyValuePair<int, int>(piece.CurrentLocation_x, piece.CurrentLocation_y)))
                    {
                        piece.IsAtRisk = true; // not using this for anything right now
                        riskValue += piece.Value;
                    }
                }
            }

            return riskValue;
        }

    }
}
