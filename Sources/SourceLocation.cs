//
//
//

using System;
using System.Text;

using static System.Char;
using static System.DateTimeOffset;

using static Sea.Scanner;

namespace Sea
{
    public partial class SourceLocation
    {
        internal int RawPosition { get; init; }

        internal int LineNumber { get; init; }

        internal int Column { get; init; }

        internal long Ticks { get; init; }

        ///

        public SourceLocation(
            int rawPosition,
            int lineNumber,
            int column)
        {
            this.RawPosition = rawPosition;
            this.LineNumber = lineNumber;
            this.Column = column;
            this.Ticks = UtcNow.UtcTicks;
        }
    }

    ///

    public partial class SourceLocation
    {
        public static bool AreEqual(
            SourceLocation lhs, 
            SourceLocation rhs)
        {
            return lhs.RawPosition == rhs.RawPosition;
        }
    }
}