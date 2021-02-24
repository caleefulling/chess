using System.Collections.Generic;

namespace Chess.Class
{
    public class Move
    {
        public IPiece Piece { get; set; }

        public KeyValuePair<int, int> Coordinates { get; set; }

        public bool IsCapture { get; set; }

        public int? CaptureValue { get; set; }

        public bool IsCapturableAfterMove { get; set; }

        public bool IsOtherPieceCapturableAfterMove { get; set; }

        public int? OtherPieceCapturableAfterMoveValue { get; set; }

        public Move(IPiece piece, int row, int column)
        {
            Piece = piece;
            Coordinates = new KeyValuePair<int, int>(row, column);
            IsCapture = false;
        }

        public Move(IPiece piece, int row, int column, int captureValue)
        {
            Piece = piece;
            Coordinates = new KeyValuePair<int, int>(row, column);
            IsCapture = true;
            CaptureValue = captureValue;
        }
    }
}
