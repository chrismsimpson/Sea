//
//
//

using System;
using System.Collections.Generic;

namespace Sea
{
    public partial class SeaNode : Node
    {
        public SeaNode(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}