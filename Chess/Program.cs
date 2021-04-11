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
            Board board = new Board(args[0]);

            ColorEnum? winner = null;
            bool isCheckMate = false;
            bool validMove;
            while (!isCheckMate)
            {
                Console.WriteLine($"\n{board.ColorToMove}'s move");
                board.PrintBoardWithTakenPieces();
                validMove = false;

                var command = Console.ReadLine();
                if (command.Trim() == "stats")
                {
                    Console.WriteLine($"black score: {board.BlackScore}, white score: {board.WhiteScore}");
                }
                else if (command.Trim() == "best")
                {
                    var bestMove = board.FindBestMove_OneLayer(board, 1);
                    Console.WriteLine($"best move - {board.ConvertMoveForNotation(bestMove.Piece.CurrentLocation_x, bestMove.Piece.CurrentLocation_y)} {board.ConvertMoveForNotation(bestMove.MoveCoordinates.Key, bestMove.MoveCoordinates.Value)}");
                    //auto-move
                    //board.MovePiece(bestMove.Piece, bestMove.MoveCoordinates.Key, bestMove.MoveCoordinates.Value);
                    //validMove = true;
                }
                else if (command.Trim() == "0-0")
                {
                    // castle kingside
                    var king = board.ColorToMove == ColorEnum.Black ? board.BlackKing : board.WhiteKing;
                    // maybe to do - move castling to board Move function and add it to AvailableMovesWithDetails? (so it can be used in best move)
                    var canCastleResult = king.CanCastleKingSide(board);
                    if (canCastleResult.CanCastle)
                    {
                        var castleResult = king.CastleKingSide(board);
                        if (castleResult.Castled)
                        {
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine($"can't castle kingside, {castleResult.Error}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"can't castle kingside, {canCastleResult.Error}");
                    }
                }
                else if (command.Trim() == "0-0-0")
                {
                    // castle queenside
                    var king = board.ColorToMove == ColorEnum.Black ? board.BlackKing : board.WhiteKing;
                    var canCastleResult = king.CanCastleQueenSide(board);
                    if (canCastleResult.CanCastle)
                    {
                        var castleResult = king.CastleQueenSide(board);
                        if (castleResult.Castled)
                        {
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine($"can't castle queenside, {castleResult.Error}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"can't castle queenside, {canCastleResult.Error}");
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
                            }
                            else
                            {
                                Console.WriteLine($"piece at {commands[0]} can't move to {commands[1]}");
                            }
                        }
                        else if (piece == null)
                        {
                            Console.WriteLine($"piece at {commands[0]} not found");
                        }
                        else
                        {
                            Console.WriteLine($"piece at {commands[0]} isn't yours to move");
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"invalid command");
                    }
                }

                if (validMove)
                {
                    // see if there's a resulting check or mate
                    if (board.ColorToMove == ColorEnum.Black)
                    {
                        var isCheckOrMate = board.WhiteKing.IsCheckOrMate(board);
                        if (isCheckOrMate.IsMate && isCheckOrMate.IsCheck)
                        {
                            // check & mate
                            isCheckMate = true;
                            winner = ColorEnum.Black;
                        }
                        else if (isCheckOrMate.IsCheck)
                        {
                            // check
                            Console.WriteLine("check");
                        }
                    }
                    else if (board.ColorToMove == ColorEnum.White)
                    {
                        var isCheckOrMate = board.BlackKing.IsCheckOrMate(board);
                        if (isCheckOrMate.IsMate && isCheckOrMate.IsCheck)
                        {
                            // check & mate
                            isCheckMate = true;
                            winner = ColorEnum.White;
                        }
                        else if (isCheckOrMate.IsCheck)
                        {
                            // check
                            Console.WriteLine("check");
                        }
                    }

                    board.ColorToMove = board.ColorToMove == ColorEnum.Black ? ColorEnum.White : ColorEnum.Black;
                }
            }

            Console.WriteLine($"check mate - game over. {winner} wins!");
            Console.WriteLine($"black score: {board.BlackScore}, white score: {board.WhiteScore}");
            Console.ReadLine();
        }
    }
}
