//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Sea
{
    public class Tokenizer<T> where T : Token
    {
        internal Scanner Scanner { get; init; }

        internal IList<T> Tokens { get; init; }

        internal int Counter { get; set; }

        ///

        public Tokenizer(
            Scanner scanner)
        {
            this.Scanner = scanner;

            this.Tokens = new List<T>();

            this.Counter = 0;
        }
    }

    ///

    public static partial class TokenizerHelpers
    {
        public static bool IsEof<T>(
            this Tokenizer<T> tokenizer)
            where T : Token
        {
            if (tokenizer.Position().RawPosition == tokenizer.Scanner.Position().RawPosition)
            {
                return tokenizer.Scanner.IsEof();
            }

            return false;
        }

        public static SourceLocation Position<T>(
            this Tokenizer<T> tokenizer)
            where T : Token
        {
            if (tokenizer.Counter + 1 <= tokenizer.Tokens.Count)
            {
                return tokenizer.Tokens.ElementAt(tokenizer.Counter).Start;
            }

            return tokenizer.Scanner.Position();
        }

        public static T? Previous<T>(
            this Tokenizer<T> tokenizer,
            int steps = 1)
            where T : Token
        {
            var prev = tokenizer.Counter - steps;

            if (prev < 0)
            {
                return null;
            }

            if (tokenizer.Counter <= tokenizer.Tokens.Count)
            {
                return tokenizer.Tokens.ElementAt(prev);
            }

            return null;
        }

        public static bool PreviousContainsNewline<T>(
            this Tokenizer<T> tokenizer)
            where T : Token
        {
            return tokenizer.Previous()?.Source.Contains('\n') ?? false;
        }
    }
}