//
//
//

using System;

namespace Sea
{
    public partial class SeaLiteral : SeaToken
    {
        public SeaLiteral(
            String source,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }
}