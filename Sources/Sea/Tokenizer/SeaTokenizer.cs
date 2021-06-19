//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.Char;
using static System.IO.File;
using static System.String;

using static Sea.SeaTokenizer;

namespace Sea
{
    public partial class SeaTokenizer : Tokenizer<SeaToken>
    {
        public SeaTokenizer(
            Scanner scanner)
            : base(scanner) { }
    }
}