//
//
//


using System;

namespace Sea
{
    public abstract class Parser<T> where T : Token
    {
        public Tokenizer<T> Tokenizer { get; init; }

        ///

        public Parser(
            Tokenizer<T> tokenizer)
        {
            this.Tokenizer = tokenizer;
        }
    }

    ///

    public static partial class ParserHelpers
    {
        public static bool IsEof<T>(
            this Parser<T> parser)
            where T : Token
        {
            return parser.Tokenizer.IsEof();
        }

        public static SourceLocation Position<T>(
            this Parser<T> parser)
            where T : Token
        {
            return parser.Tokenizer.Position();
        }
    }
}