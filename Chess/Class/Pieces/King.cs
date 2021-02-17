using System;
using System.Collections.Generic;
using System.Linq;
using Chess.Class.Enum;

namespace Chess.Class.Pieces
{
    [Serializable]
    public class King : IPiece
    {
        public PieceTypeEnum Type { get; set; }

        public PieceColorEnum Color { get; set; }

        public char BoardNotation { get; set; }

        public int Value { get; set; }

        public int CurrentLocation_x { get; set; }

        public int CurrentLocation_y { get; set; }

        public bool HasMoved { get; set; }


        public King(int x, int y, PieceColorEnum color)
        {
            CurrentLocation_x = x;
            CurrentLocation_y = y;

            Type = PieceTypeEnum.King;
            BoardNotation = 'K';
            Value = 1000;
            Color = color;
        }

        public List<KeyValuePair<int, int>> AvailableMoves(Board.Board board)
        {
            List<KeyValuePair<int, int>> positionsReturn = new List<KeyValuePair<int, int>>();

            if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y - 1];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    // clone board and king to look for check
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, CurrentLocation_x - 1, CurrentLocation_y - 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        // doesn't result in check, add as valid move
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y - 1));
                    }
                }
            }

            if (CurrentLocation_x - 1 >= 0 && CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y + 1];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    // clone board and king to look for check
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, CurrentLocation_x - 1, CurrentLocation_y + 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        // doesn't result in check, add as valid move
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y + 1));
                    }
                }
            }

            if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y + 1];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    // clone board and king to look for check
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, CurrentLocation_x + 1, CurrentLocation_y + 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        // doesn't result in check, add as valid move
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y + 1));
                    }
                }
            }

            if (CurrentLocation_x + 1 <= 7 && CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y - 1];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    // clone board and king to look for check
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, CurrentLocation_x + 1, CurrentLocation_y - 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        // doesn't result in check, add as valid move
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y - 1));
                    }
                }
            }

            if (CurrentLocation_x - 1 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x - 1, CurrentLocation_y];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    // clone board and king to look for check
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, CurrentLocation_x - 1, CurrentLocation_y);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        // doesn't result in check, add as valid move
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x - 1, CurrentLocation_y));
                    }
                }
            }

            if (CurrentLocation_y - 1 >= 0)
            {
                var piece = board.Instance[CurrentLocation_x, CurrentLocation_y - 1];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    // clone board and king to look for check
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, CurrentLocation_x, CurrentLocation_y - 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        // doesn't result in check, add as valid move
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x, CurrentLocation_y - 1));
                    }
                }
            }

            if (CurrentLocation_x + 1 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x + 1, CurrentLocation_y];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    // clone board and king to look for check
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, CurrentLocation_x + 1, CurrentLocation_y);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        // doesn't result in check, add as valid move
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x + 1, CurrentLocation_y));
                    }
                }
            }

            if (CurrentLocation_y + 1 <= 7)
            {
                var piece = board.Instance[CurrentLocation_x, CurrentLocation_y + 1];
                if (piece == null || (piece != null && piece.Color != Color))
                {
                    // clone board and king to look for check
                    var kingCopy = (King)board.DeepClone(this);
                    var simBoard = (Board.Board)board.DeepClone(board);
                    simBoard.MovePiece(kingCopy, CurrentLocation_x, CurrentLocation_y + 1);
                    if (!kingCopy.IsInCheck(simBoard))
                    {
                        // doesn't result in check, add as valid move
                        positionsReturn.Add(new KeyValuePair<int, int>(CurrentLocation_x, CurrentLocation_y + 1));
                    }
                }
            }


            return positionsReturn;
        }

        public void Move(int x, int y)
        {
            CurrentLocation_x = x;
            CurrentLocation_y = y;

            HasMoved = true;
        }

        public List<KeyValuePair<int, int>> GetCheckPath(Board.Board board)
        {
            throw new NotImplementedException();
        }

        public bool IsInCheck(Board.Board board)
        {
            foreach (var piece in board.Instance)
            {
                if (piece != null && piece.Type != PieceTypeEnum.King && piece.Color != this.Color)
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

        public bool IsCheckMate(Board.Board board)
        {
            bool isInCheck = false;
            foreach (var piece in board.Instance)
            {
                if (piece != null && piece.Type != PieceTypeEnum.King && piece.Color != this.Color)
                {
                    var pieceMoves = piece.AvailableMoves(board);
                    if (pieceMoves.Contains(new KeyValuePair<int, int>(this.CurrentLocation_x, this.CurrentLocation_y)))
                    {
                        isInCheck = true;
                        // in check, now check conditions for mate -
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
                                var checkPath = piece.GetCheckPath(board);
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

        public (bool canCastle, string message) CanCastleOnKingSide(Board.Board board)
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
            if (this.Color == PieceColorEnum.Black)
                rookSpot = board.Instance[0, 7];
            else
                rookSpot = board.Instance[7, 7];

            if (rookSpot != null && rookSpot.Type == PieceTypeEnum.Rook && rookSpot.Color == this.Color)
            {
                Rook rook = (Rook)rookSpot;
                if (!rook.HasMoved)
                {
                    if (this.Color == PieceColorEnum.Black)
                    {
                        if (board.Instance[0, 5] != null)
                        {
                            return (false, "spot (0,5) has a piece");
                        }

                        if (board.Instance[0, 6] != null)
                        {
                            return (false, "spot (0,6) has a piece");
                        }

                        return (true, string.Empty);
                    }
                    else
                    {
                        if (board.Instance[7, 5] != null)
                        {
                            return (false, "spot (7,5) has a piece");
                        }

                        if (board.Instance[7, 6] != null)
                        {
                            return (false, "spot (7,6) has a piece");
                        }

                        return (true, string.Empty);
                    }
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

            return (false, string.Empty);
        }

        public (bool canCastle, string message) CanCastleOnQueenSide(Board.Board board)
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
            if (this.Color == PieceColorEnum.Black)
                rookSpot = board.Instance[0, 0];
            else
                rookSpot = board.Instance[7, 0];

            if (rookSpot != null && rookSpot.Type == PieceTypeEnum.Rook && rookSpot.Color == this.Color)
            {
                var rook = (Rook)rookSpot;
                if (!rook.HasMoved)
                {
                    if (this.Color == PieceColorEnum.Black)
                    {
                        if (board.Instance[0, 1] != null)
                        {
                            return (false, "spot (0,1) has a piece");
                        }

                        if (board.Instance[0, 2] != null)
                        {
                            return (false, "spot (0,2) has a piece");
                        }

                        if (board.Instance[0, 3] != null)
                        {
                            return (false, "spot (0,3) has a piece");
                        }

                        return (true, string.Empty);
                    }
                    else
                    {
                        if (board.Instance[7, 1] != null)
                        {
                            return (false, "spot (7,1) has a piece");
                        }

                        if (board.Instance[7, 2] != null)
                        {
                            return (false, "spot (7,2) has a piece");
                        }

                        if (board.Instance[7, 3] != null)
                        {
                            return (false, "spot (7,3) has a piece");
                        }

                        return (true, string.Empty);
                    }
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

            return (false, string.Empty);
        }

        public (bool castled, string message) CastleKingSide(Board.Board board)
        {
            // store current pos in case of failed castle from check
            var beginning_x = this.CurrentLocation_x;
            var beginning_y = this.CurrentLocation_y;

            int rook_beginning_x;
            int rook_beginning_y;

            Rook rook;
            if (this.Color == PieceColorEnum.Black)
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
            if (this.Color == PieceColorEnum.Black)
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
