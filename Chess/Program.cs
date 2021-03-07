using System;
using Chess.Class.Board;
using Chess.Class.Enum;
using System.Collections.Generic;

namespace Chess
{
    class MainClass
    {
        // stuff to do -
        //   en passant
        //   draws
        //       stalemate - the king is NOT in check, but no piece can be moved without putting the king in check
        //   could refactor GetAvailableMoves to work with the details function, instead of having two
        //       you could store temp lists for each list, and then add them to a more global var later
        //          first test performance - is the detail function much slower/less efficient?
        //   refactor to have a list of white and black pieces at a board level. this way won't have to loop the entire board each time
        //   attempt at "AI" 
        public static void Main(string[] args)
        {
            bool manualBoard = true;
            bool validMove;

            Board board;
            if (!manualBoard)
            {
                board = new Board();
            }
            else
            {
                board = new Board(true);
            }

            while (!board.WhiteKing.IsCheckMate(board) && !board.BlackKing.IsCheckMate(board))
            {
                Console.WriteLine($"\n{board.ColorToMove}'s move");
                board.PrintBoardWithTakenPieces();
                validMove = false;

                var command = Console.ReadLine();
                if (command.Contains("stats"))
                {
                    Console.WriteLine($"black score: {board.BlackScore}, white score: {board.WhiteScore}");
                }
                else if (command.Contains("best"))
                {
                    var move = board.FindBestMove_OneLayer(board, 1);
                    Console.WriteLine($"best - {board.ConvertMoveForNotation(move.Piece.CurrentLocation_x, move.Piece.CurrentLocation_y)} {board.ConvertMoveForNotation(move.MoveCoordinates.Key, move.MoveCoordinates.Value)}");
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

                                // see if there's a resulting check
                                if ((board.ColorToMove == ColorEnum.Black && board.WhiteKing.IsInCheck(board)) || (board.ColorToMove == ColorEnum.White && board.BlackKing.IsInCheck(board)))
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
