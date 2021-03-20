using System;
using System.Collections.Generic;
using System.Linq;
using Chess.Class.Enum;

namespace Chess.Class.Pieces
{
    [Serializable]
    public class King : IPiece
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


        public King(int x, int y, ColorEnum color)
        {
            this.CurrentLocation_x = x;
            this.CurrentLocation_y = y;

            this.Type = TypeEnum.King;
            this.BoardNotation = 'K';
            this.Value = 1000;
            this.Color = color;
        }

        public List<KeyValuePair<int, int>> AvailableMoves(Board.Board board)
        {
            List<KeyValuePair<int, int>> availableMoves = new List<KeyValuePair<int, int>>();

            if (this.CurrentLocation_x - 1 >= 0 && this.CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[this.CurrentLocation_x - 1, this.CurrentLocation_y - 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x - 1, this.CurrentLocation_y - 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y - 1));
                    }
                }
            }

            if (this.CurrentLocation_x - 1 >= 0 && this.CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[this.CurrentLocation_x - 1, this.CurrentLocation_y + 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x - 1, this.CurrentLocation_y + 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y + 1));
                    }
                }
            }

            if (this.CurrentLocation_x + 1 <= 7 && this.CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[this.CurrentLocation_x + 1, this.CurrentLocation_y + 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x + 1, this.CurrentLocation_y + 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y + 1));
                    }
                }
            }

            if (this.CurrentLocation_x + 1 <= 7 && this.CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[this.CurrentLocation_x + 1, this.CurrentLocation_y - 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x + 1, this.CurrentLocation_y - 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y - 1));
                    }
                }
            }

            if (this.CurrentLocation_x - 1 >= 0)
            {
                var piece = board.Instance[this.CurrentLocation_x - 1, this.CurrentLocation_y];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x - 1, this.CurrentLocation_y);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y));
                    }
                }
            }

            if (this.CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[this.CurrentLocation_x, this.CurrentLocation_y - 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x, this.CurrentLocation_y - 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x, this.CurrentLocation_y - 1));
                    }
                }
            }

            if (this.CurrentLocation_x + 1 <= 7)
            {
                var piece = board.Instance[this.CurrentLocation_x + 1, this.CurrentLocation_y];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x + 1, this.CurrentLocation_y);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y));
                    }
                }
            }

            if (this.CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[this.CurrentLocation_x, this.CurrentLocation_y + 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x, this.CurrentLocation_y + 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        availableMoves.Add(new KeyValuePair<int, int>(this.CurrentLocation_x, this.CurrentLocation_y + 1));
                    }
                }
            }


            return availableMoves;
        }

        public List<Move> AvailableMovesWithDetails(Board.Board board)
        {
            List<Move> availableMoves = new List<Move>();

            if (this.CurrentLocation_x - 1 >= 0 && this.CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[this.CurrentLocation_x - 1, this.CurrentLocation_y - 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x - 1, this.CurrentLocation_y - 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        if (piece != null)
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y - 1), piece));
                        }
                        else
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y - 1)));
                        }
                    }
                }
            }

            if (this.CurrentLocation_x - 1 >= 0 && this.CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[this.CurrentLocation_x - 1, this.CurrentLocation_y + 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x - 1, this.CurrentLocation_y + 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        if (piece != null)
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y + 1), piece));
                        }
                        else
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y + 1)));
                        }
                    }
                }
            }

            if (this.CurrentLocation_x + 1 <= 7 && this.CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[this.CurrentLocation_x + 1, this.CurrentLocation_y + 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x + 1, this.CurrentLocation_y + 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        if (piece != null)
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y + 1), piece));
                        }
                        else
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y + 1)));
                        }
                    }
                }
            }

            if (this.CurrentLocation_x + 1 <= 7 && this.CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[this.CurrentLocation_x + 1, this.CurrentLocation_y - 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x + 1, this.CurrentLocation_y - 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        if (piece != null)
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y - 1), piece));
                        }
                        else
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y - 1)));
                        }
                    }
                }
            }

            if (this.CurrentLocation_x - 1 >= 0)
            {
                var piece = board.Instance[this.CurrentLocation_x - 1, this.CurrentLocation_y];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x - 1, this.CurrentLocation_y);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        if (piece != null)
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y), piece));
                        }
                        else
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x - 1, this.CurrentLocation_y)));
                        }
                    }
                }
            }

            if (this.CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[this.CurrentLocation_x, this.CurrentLocation_y - 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x, this.CurrentLocation_y - 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        if (piece != null)
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x, this.CurrentLocation_y - 1), piece));
                        }
                        else
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x, this.CurrentLocation_y - 1)));
                        }
                    }
                }
            }

            if (this.CurrentLocation_x + 1 <= 7)
            {
                var piece = board.Instance[this.CurrentLocation_x + 1, this.CurrentLocation_y];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x + 1, this.CurrentLocation_y);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        if (piece != null)
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y), piece));
                        }
                        else
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x + 1, this.CurrentLocation_y)));
                        }
                    }
                }
            }

            if (this.CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[this.CurrentLocation_x, this.CurrentLocation_y + 1];
                if (piece == null || (piece != null && piece.Color != this.Color))
                {
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, this.CurrentLocation_x, this.CurrentLocation_y + 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        if (piece != null)
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x, this.CurrentLocation_y + 1), piece));
                        }
                        else
                        {
                            availableMoves.Add(new Move(this, new KeyValuePair<int, int>(this.CurrentLocation_x, this.CurrentLocation_y + 1)));
                        }
                    }
                }
            }


            return availableMoves;
        }

        public void Move(int x, int y)
        {
            this.CurrentLocation_x = x;
            this.CurrentLocation_y = y;

            this.HasMoved = true;
        }

        public List<KeyValuePair<int, int>> GetCheckPath(Board.Board board)
        {
            throw new NotImplementedException();
        }

        public bool IsInCheck(Board.Board board)
        {
            foreach (var piece in board.Instance)
            {
                if (piece != null && piece.Type != TypeEnum.King && piece.Color != this.Color)
                {
                    var pieceMoves = piece.AvailableMoves(board);
                    if (pieceMoves.Contains(new KeyValuePair<int, int>(this.CurrentLocation_x, this.CurrentLocation_y)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsStaleMate(Board.Board board)
        {
            //  always be stalemate in the beginning

            // king has no "legal" moves, particularly because of resulting checks 
            foreach (var move in this.AvailableMoves(board))
            {

            }

            return false;
        }

        public bool IsCheckMate(Board.Board board)
        {
            bool isInCheck = false;
            foreach (var piece in board.Instance)
            {
                if (piece != null && piece.Type != TypeEnum.King && piece.Color != this.Color)
                {
                    var pieceMoves = piece.AvailableMoves(board);
                    if (pieceMoves.Contains(new KeyValuePair<int, int>(this.CurrentLocation_x, this.CurrentLocation_y)))
                    {
                        isInCheck = true;
                        // conditions for mate -
                        //   1 - all possible moves for king result in checks
                        //   2 - the piece putting king in check isn't capturable
                        //   3 - no piece can intercept the check path

                        // 1
                        var kingMoves = this.AvailableMoves(board);
                        foreach (var kingMove in kingMoves)
                        {
                            // simulate each move on a new copy of the board to see if it results in check
                            var kingCopy = (King)board.DeepClone(this);
                            var simBoard = (Board.Board)board.DeepClone(board);
                            simBoard.MovePiece(kingCopy, kingMove.Key, kingMove.Value);
                            if (!kingCopy.IsInCheck(simBoard))
                            {
                                // has an available move, not a mate
                                return false;
                            }
                        }

                        // 2/3
                        var checkPath = piece.GetCheckPath(board);
                        foreach (var defensePiece in board.Instance)
                        {
                            if (defensePiece != null && defensePiece.Color != piece.Color)
                            {
                                // 2. see if a defense piece can capture the piece putting king in check
                                var defensePieceMoves = defensePiece.AvailableMoves(board);
                                if (defensePieceMoves.Contains(new KeyValuePair<int, int>(piece.CurrentLocation_x, piece.CurrentLocation_y)))
                                {
                                    // can capture piece putting king in check
                                    return false;
                                }

                                // 3. see if a defense piece can intercept the check path
                                if (defensePieceMoves.Any(x => checkPath.Any(e => e.Key == x.Key && e.Value == x.Value)))
                                {
                                    // can intercept check
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return (isInCheck && true);
        }

        public (bool canCastle, string message) CanCastleKingSide(Board.Board board)
        {
            if (this.HasMoved)
            {
                return (false, "king has moved");
            }

            if (this.IsInCheck(board))
            {
                return (false, "king is in check");
            }

            IPiece rookSpot;
            if (this.Color == ColorEnum.Black)
                rookSpot = board.Instance[0, 7];
            else
                rookSpot = board.Instance[7, 7];

            if (rookSpot != null && rookSpot.Type == TypeEnum.Rook && rookSpot.Color == this.Color)
            {
                Rook rook = (Rook)rookSpot;
                if (!rook.HasMoved)
                {
                    if (this.Color == ColorEnum.Black)
                    {
                        if (board.Instance[0, 5] != null)
                        {
                            var notation = board.ConvertMoveForNotation(0, 5);
                            return (false, $"spot {notation} has a piece");
                        }

                        if (board.Instance[0, 6] != null)
                        {
                            var notation = board.ConvertMoveForNotation(0, 6);
                            return (false, $"spot {notation} has a piece");
                        }

                        return (true, string.Empty);
                    }
                    else
                    {
                        if (board.Instance[7, 5] != null)
                        {
                            var notation = board.ConvertMoveForNotation(7, 5);
                            return (false, $"spot {notation} has a piece");
                        }

                        if (board.Instance[7, 6] != null)
                        {
                            var notation = board.ConvertMoveForNotation(7, 6);
                            return (false, $"spot {notation} has a piece");
                        }

                        return (true, string.Empty);
                    }
                }
                else
                {
                    return (false, "rook has moved");
                }
            }
            else if (rookSpot == null)
            {
                return (false, "the kingside rook isn't in its place");
            }
            else
            {
                return (false, "the kingside rook spot is taken");
            }
        }

        public (bool canCastle, string message) CanCastleQueenSide(Board.Board board)
        {
            if (this.HasMoved)
            {
                return (false, "king has moved");
            }

            if (this.IsInCheck(board))
            {
                return (false, "king is in check");
            }

            IPiece rookSpot;
            if (this.Color == ColorEnum.Black)
                rookSpot = board.Instance[0, 0];
            else
                rookSpot = board.Instance[7, 0];

            if (rookSpot != null && rookSpot.Type == TypeEnum.Rook && rookSpot.Color == this.Color)
            {
                var rook = (Rook)rookSpot;
                if (!rook.HasMoved)
                {
                    if (this.Color == ColorEnum.Black)
                    {
                        if (board.Instance[0, 1] != null)
                        {
                            var notation = board.ConvertMoveForNotation(0, 1);
                            return (false, $"spot {notation} has a piece");
                        }

                        if (board.Instance[0, 2] != null)
                        {
                            var notation = board.ConvertMoveForNotation(0, 2);
                            return (false, $"spot {notation} has a piece");
                        }

                        if (board.Instance[0, 3] != null)
                        {
                            var notation = board.ConvertMoveForNotation(0, 3);
                            return (false, $"spot {notation} has a piece");
                        }

                        return (true, string.Empty);
                    }
                    else
                    {
                        if (board.Instance[7, 1] != null)
                        {
                            var notation = board.ConvertMoveForNotation(7, 1);
                            return (false, $"spot {notation} has a piece");
                        }

                        if (board.Instance[7, 2] != null)
                        {
                            var notation = board.ConvertMoveForNotation(7, 2);
                            return (false, $"spot {notation} has a piece");
                        }

                        if (board.Instance[7, 3] != null)
                        {
                            var notation = board.ConvertMoveForNotation(7, 3);
                            return (false, $"spot {notation} has a piece");
                        }

                        return (true, string.Empty);
                    }
                }
                else
                {
                    return (false, "rook has moved");
                }
            }
            else if (rookSpot == null)
            {
                return (false, "the queenside rook isn't in its place");
            }
            else
            {
                return (false, "the queenside rook spot is taken");
            }
        }

        public (bool castled, string message) CastleKingSide(Board.Board board)
        {
            // store current pos in case of failed castle from check
            var beginning_x = this.CurrentLocation_x;
            var beginning_y = this.CurrentLocation_y;

            int rook_beginning_x;
            int rook_beginning_y;

            Rook rook;
            if (this.Color == ColorEnum.Black)
            {
                board.MovePiece(this, 0, 6);

                rook_beginning_x = 0;
                rook_beginning_y = 7;
                rook = (Rook)board.Instance[rook_beginning_x, rook_beginning_y];
                board.MovePiece(rook, rook_beginning_x, 5);
            }
            else
            {
                board.MovePiece(this, 7, 6);

                rook_beginning_x = 7;
                rook_beginning_y = 7;
                rook = (Rook)board.Instance[rook_beginning_x, rook_beginning_y];
                board.MovePiece(rook, rook_beginning_x, 5);
            }

            // can't castle if it puts in check
            if (this.IsInCheck(board))
            {
                // move king and rook back to og position
                board.MovePiece(this, beginning_x, beginning_y);
                board.MovePiece(rook, rook_beginning_x, rook_beginning_y);
                // before this point king and rook had HasMoved = false, update them back
                this.HasMoved = false;
                rook.HasMoved = false;

                return (false, "castling results in a check");
            }

            return (true, string.Empty);
        }

        public (bool castled, string message) CastleQueenSide(Board.Board board)
        {
            // store current pos in case of failed castle
            var beginning_x = this.CurrentLocation_x;
            var beginning_y = this.CurrentLocation_y;

            int rook_beginning_x;
            int rook_beginning_y;

            Rook rook;
            if (this.Color == ColorEnum.Black)
            {
                board.MovePiece(this, 0, 2);

                rook_beginning_x = 0;
                rook_beginning_y = 0;
                rook = (Rook)board.Instance[rook_beginning_x, rook_beginning_y];
                board.MovePiece(rook, rook_beginning_x, 3);
            }
            else
            {
                board.MovePiece(this, 7, 2);

                rook_beginning_x = 7;
                rook_beginning_y = 0;
                rook = (Rook)board.Instance[rook_beginning_x, rook_beginning_y];
                board.MovePiece(rook, rook_beginning_x, 3);
            }

            // can't castle if it results in a check
            if (this.IsInCheck(board))
            {
                // move king and rook back to og pos
                board.MovePiece(this, beginning_x, beginning_y);
                board.MovePiece(rook, rook_beginning_x, rook_beginning_y);
                // before this point king and rook had HasMoved = false, update them back
                this.HasMoved = false;
                rook.HasMoved = false;

                return (false, "castling results in a check");
            }

            return (true, string.Empty);
        }
    }
}