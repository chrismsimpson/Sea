//
//
//

using System;
using System.Linq;

namespace Sea
{
    public class Token : Node
    {
        public String Source { get; init; }

        ///

        public Token(
            Char source,
            SourceLocation start,
            SourceLocation end)
            : base(new Node[] { }, start, end)
        {
            this.Source = new String(new [] { source });
        }

        public Token(
            String source,
            SourceLocation start, 
            SourceLocation end)
            : base(new Node[] { }, start, end)
        {
            this.Source = source;
        }
    }
}