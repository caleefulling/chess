using System;
using System.Collections.Generic;

namespace Chess.Class
{
    public class Move
    {
        public IPiece Piece { get; set; }

        public int AtRiskValue { get; set; }

        public KeyValuePair<int, int> MoveCoordinates { get; set; }

        public bool IsCapture { get; set; }

        public int CaptureValue { get; set; }

        public int OffenseScore { get; set; }

        public int MoveLocationScore { get; set; }

        public int Score { get; set; }


        public Move(IPiece piece, KeyValuePair<int, int> coordinates)
        {
            Piece = piece;
            MoveCoordinates = coordinates;
            MoveLocationScore = GetMoveLocationScore();

        }

        public Move(IPiece piece, KeyValuePair<int, int> coordinates, IPiece pieceToCapture)
        {
            Piece = piece;
            MoveCoordinates = coordinates;
            CaptureValue = pieceToCapture.Value;
            IsCapture = true;
            MoveLocationScore = GetMoveLocationScore();
        }

        public int GetMoveLocationScore()
        {
            var totalDistance = 0;

            // check against center
            totalDistance += (Math.Abs(3 - this.MoveCoordinates.Key) + Math.Abs(3 - this.MoveCoordinates.Value));
            totalDistance += (Math.Abs(4 - this.MoveCoordinates.Key) + Math.Abs(3 - this.MoveCoordinates.Value));
            totalDistance += (Math.Abs(3 - this.MoveCoordinates.Key) + Math.Abs(4 - this.MoveCoordinates.Value));
            totalDistance += (Math.Abs(4 - this.MoveCoordinates.Key) + Math.Abs(4 - this.MoveCoordinates.Value));

            // check against opposite side
            if (Piece.Color == Enum.ColorEnum.Black)
            {
                // row 0, cols 0-7
                totalDistance += (Math.Abs(0 - this.MoveCoordinates.Key) + Math.Abs(0 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(0 - this.MoveCoordinates.Key) + Math.Abs(1 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(0 - this.MoveCoordinates.Key) + Math.Abs(2 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(0 - this.MoveCoordinates.Key) + Math.Abs(3 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(0 - this.MoveCoordinates.Key) + Math.Abs(4 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(0 - this.MoveCoordinates.Key) + Math.Abs(5 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(0 - this.MoveCoordinates.Key) + Math.Abs(6 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(0 - this.MoveCoordinates.Key) + Math.Abs(7 - this.MoveCoordinates.Value));
            }
            else
            {
                // row 7, cols 0-7
                totalDistance += (Math.Abs(7 - this.MoveCoordinates.Key) + Math.Abs(0 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(7 - this.MoveCoordinates.Key) + Math.Abs(1 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(7 - this.MoveCoordinates.Key) + Math.Abs(2 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(7 - this.MoveCoordinates.Key) + Math.Abs(3 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(7 - this.MoveCoordinates.Key) + Math.Abs(4 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(7 - this.MoveCoordinates.Key) + Math.Abs(5 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(7 - this.MoveCoordinates.Key) + Math.Abs(6 - this.MoveCoordinates.Value));
                totalDistance += (Math.Abs(7 - this.MoveCoordinates.Key) + Math.Abs(7 - this.MoveCoordinates.Value));
            }

            return totalDistance / 12;
        }

        public void CalculateMoveScore()
        {
            Score = (AtRiskValue * 45) + (OffenseScore * 45) + (MoveLocationScore * 10);
        }
    }
}
