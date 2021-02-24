using System;
using Chess.Class.Board;
using Chess.Class.Enum;
using System.Collections.Generic;

namespace Chess
{
    class MainClass
    {
        // to do -
        //   en passant
        //   stalemate
        //   draws
        //   "AI" attempt
        //   function for "dev" board for testing scenarios, accept input for placing the pieces.
        //      undo (store locations at end of loop, set that location to null)
        public static void Main(string[] args)
        {
            bool validMove;
            Board board = new Board();
            while (!board.WhiteKing.IsCheckMate(board) && !board.BlackKing.IsCheckMate(board) && board.MovesSinceLastCaptureOrPawnMove <= 50)
            {
                Console.WriteLine($"{board.ColorToMove}'s move");
                board.PrintBoardWithTakenPieces();
                validMove = false;

                var command = Console.ReadLine();
                if (command.Contains("stats"))
                {
                    Console.WriteLine($"black score: {board.BlackScore}, white score: {board.WhiteScore}");
                }
                else if (command.Trim().Contains("best"))
                {

                }
                else if (command.Trim() == "0-0")
                {
                    // castle kingside
                    var king = board.ColorToMove == ColorEnum.Black ? board.BlackKing : board.WhiteKing;
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
                    var king = board.ColorToMove == ColorEnum.Black ? board.BlackKing : board.WhiteKing;
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

                        var piece = board.Instance[startPos.Key, startPos.Value];
                        if (piece != null && piece.Color == board.ColorToMove)
                        {
                            var moves = piece.AvailableMoves(board);
                            if (moves.Contains(new KeyValuePair<int, int>(endPos.Key, endPos.Value)))
                            {
                                // valid move
                                board.MovePiece(piece, endPos.Key, endPos.Value);
                                validMove = true;

                                // pawn promotion
                                if (piece.Type == TypeEnum.Pawn &&
                                       (board.ColorToMove == ColorEnum.White && endPos.Key == 0)
                                    || (board.ColorToMove == ColorEnum.Black && endPos.Key == 7))
                                {
                                    board.PromotePawn(piece);
                                }

                                // see if there's a resulting check
                                if ((board.ColorToMove == ColorEnum.Black && board.WhiteKing.IsInCheck(board))
                                 || (board.ColorToMove == ColorEnum.White && board.BlackKing.IsInCheck(board)))
                                {
                                    Console.WriteLine("check");
                                }

                            }
                            else
                            {
                                Console.WriteLine($"piece at {commands[0]} cannot move to {commands[1]}");
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
                    board.ColorToMove = board.ColorToMove == ColorEnum.Black ? ColorEnum.White : ColorEnum.Black;
            }

            Console.WriteLine($"check mate - game over. { (board.WhiteKing.IsCheckMate(board) ? ColorEnum.Black.ToString() : ColorEnum.White.ToString()) } wins!");
            Console.WriteLine($"black score: {board.BlackScore}, white score: {board.WhiteScore}");
        }
    }
}
