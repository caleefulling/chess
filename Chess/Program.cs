using System;
using Chess.Class.Board;
using Chess.Class.Enum;
using System.Collections.Generic;

namespace Chess
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool validMove;
            Board board = new Board();
            while (!board.WhiteKing.IsCheckMate(board) && !board.BlackKing.IsCheckMate(board))
            {
                Console.WriteLine($"{board.ColorToMove}'s move");
                board.PrintBoardWithTakenPieces();
                validMove = false;

                var command = Console.ReadLine();
                if (command.Contains("stats"))
                {
                    Console.WriteLine($"black score: {board.BlackScore}, white score: {board.WhiteScore}");
                    continue;
                }
                else if (command.Trim() == "0-0")
                {
                    // castle kingside
                    var king = board.ColorToMove == PieceColorEnum.Black ? board.BlackKing : board.WhiteKing;
                    var canCastleResult = king.CanCastleOnKingSide(board);
                    if (canCastleResult.canCastle)
                    {
                        var castleResult = king.CastleKingSide(board);
                        if (castleResult.castled)
                        {
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine($"can't castle kingside, {castleResult.message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"can't castle kingside, {canCastleResult.message}");
                    }
                }
                else if (command.Trim() == "0-0-0")
                {
                    // castle queenside
                    var king = board.ColorToMove == PieceColorEnum.Black ? board.BlackKing : board.WhiteKing;
                    var canCastleResult = king.CanCastleOnQueenSide(board);
                    if (canCastleResult.canCastle)
                    {
                        var castleResult = king.CastleQueenSide(board);
                        if (castleResult.castled)
                        {
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine($"can't castle queenside, {castleResult.message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"can't castle queenside, {canCastleResult.message}");
                    }
                }
                else
                {
                    try
                    {
                        var commands = command.Split(' ');
                        var startPos = board.ConvertNotationForMove(commands[0]);
                        var endPos = board.ConvertNotationForMove(commands[1]);

                        var piece = board.Instance[Convert.ToInt32(startPos.Key), Convert.ToInt32(startPos.Value)];
                        if (piece != null && piece.Color == board.ColorToMove)
                        {
                            var moves = piece.AvailableMoves(board);
                            if (moves.Contains(new KeyValuePair<int, int>(Convert.ToInt32(endPos.Key), Convert.ToInt32(endPos.Value))))
                            {
                                // valid move
                                board.MovePiece(piece, Convert.ToInt32(endPos.Key), Convert.ToInt32(endPos.Value));
                                validMove = true;

                                // see if there's a check
                                if (board.WhiteKing.IsInCheck(board) || board.BlackKing.IsInCheck(board))
                                {
                                    Console.WriteLine("check");
                                }

                            }
                            else
                            {
                                Console.WriteLine($"piece at {commands[0]} cannot legally move to {commands[1]}");
                            }
                        }
                        else if (piece == null)
                        {
                            Console.WriteLine($"piece at {commands[0]} not found");
                        }
                        else
                        {
                            Console.WriteLine($"piece at {commands[0]} is not yours to move");
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"invalid command");
                    }
                }

                if (validMove)
                    board.ColorToMove = board.ColorToMove == PieceColorEnum.Black ? PieceColorEnum.White : PieceColorEnum.Black;
            }

            Console.WriteLine($"check mate - game over. { (board.WhiteKing.IsCheckMate(board) ? PieceColorEnum.Black.ToString() : PieceColorEnum.White.ToString()) } wins!");
            Console.WriteLine($"black score: {board.BlackScore}, white score: {board.WhiteScore}");
        }
    }
}
