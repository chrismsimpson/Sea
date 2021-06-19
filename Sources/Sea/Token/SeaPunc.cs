//
//
//

using System;

namespace Sea
{
    public enum SeaPuncType
    {
        LeftBrace,
        RightBrace

    }

    public partial class SeaPunc : SeaToken
    {
        public SeaPuncType PuncType { get; init; }

        ///

        public SeaPunc(
            Char source,
            SourceLocation start,
            SourceLocation end,
            SeaPuncType puncType)
            : base(new String(new Char[] { source }), start, end)
        {
            this.PuncType = puncType;
        }

        public SeaPunc(
            String source,
            SourceLocation start,
            SourceLocation end,
            SeaPuncType puncType)
            : base(source, start, end)
        {
            this.PuncType = puncType;
        }
    }
}