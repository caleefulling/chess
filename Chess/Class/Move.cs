using System;
using System.Collections.Generic;

namespace Chess.Class
{
    public class Move
    {
        public IPiece Piece { get; set; }

        public bool IsAtRisk { get; set; }

        public int? AtRiskValue { get; set; }

        public int? PuttingPieceAtRiskValue { get; set; }

        public KeyValuePair<int, int> MoveCoordinates { get; set; }

        public bool IsCapture { get; set; }

        public int? CaptureValue { get; set; }

        public int DistanceFromMiddleOfBoard { get; set; }


        public Move(IPiece piece, KeyValuePair<int, int> coordinates)
        {
            Piece = piece;
            MoveCoordinates = coordinates;
            DistanceFromMiddleOfBoard = GetDistanceFromMiddleOfBoard();
        }

        public Move(IPiece piece, KeyValuePair<int, int> coordinates, IPiece pieceToCapture)
        {
            Piece = piece;
            MoveCoordinates = coordinates;
            CaptureValue = pieceToCapture.Value;
            IsCapture = true;
            DistanceFromMiddleOfBoard = GetDistanceFromMiddleOfBoard();
        }

        public int GetDistanceFromMiddleOfBoard()
        {
            var totalDistance = 0;
            totalDistance += (Math.Abs(3 - this.MoveCoordinates.Key) + Math.Abs(3 - this.MoveCoordinates.Value));
            totalDistance += (Math.Abs(4 - this.MoveCoordinates.Key) + Math.Abs(3 - this.MoveCoordinates.Value));
            totalDistance += (Math.Abs(3 - this.MoveCoordinates.Key) + Math.Abs(4 - this.MoveCoordinates.Value));
            totalDistance += (Math.Abs(4 - this.MoveCoordinates.Key) + Math.Abs(4 - this.MoveCoordinates.Value));

            return totalDistance / 4;
        }
    }
}
