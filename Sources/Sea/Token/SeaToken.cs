//
//
//

using System;

namespace Sea
{
    public partial class SeaToken : Token
    {
        public SeaToken(
            String source,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }
}