//
//
//

using System;
using System.Text;

using static System.Char;
using static System.DateTimeOffset;
using static System.String;

using static Sea.Scanner;

namespace Sea
{
    public partial class Scanner
    {
        public String Source { get; init; }

        internal int RawPosition { get; set; }
        
        internal int LineNumber { get; set; }

        internal int Column { get; set; }

        ///

        public Scanner(
            String source)
        {
            this.Source = source;

            ///

            this.RawPosition = 0;

            this.LineNumber = 0;

            this.Column = 0;
        }
    }

    ///

    public partial class Scanner
    {
        public static bool IsZeroThruTen(
            Char c)
        {
            return c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9'; 
        }

        public static bool IsSpaceOrTabs(
            Char c)
        {
            return c == ' ' || c == '\t';
        }
    }

    ///

    public static partial class ScannerHelpers
    {
        public static SourceLocation Position(
            this Scanner scanner)
        {
            return new SourceLocation(
                rawPosition: scanner.RawPosition,
                lineNumber: scanner.LineNumber,
                column: scanner.Column);
        }

        ///

        public static Char Consume(
            this Scanner scanner)
        {
            var c = scanner.Source[scanner.RawPosition];

            ///

            switch (c)
            {
                case '\n':

                    scanner.LineNumber++;

                    scanner.Column = 0;

                    break;

                default:

                    scanner.Column++;

                    break;
            }

            ///

            scanner.RawPosition++;

            ///

            return c;
        }

        public static Char[] Consume(
            this Scanner scanner, 
            int length)
        {
            var end = scanner.RawPosition + length;

            if (end >= scanner.Source.Length)
            {
                throw new Exception();
            }

            var chars = new Char[length];

            for (var i = 0; i < length; i++)
            {
                chars[i] = scanner.Consume();
            }

            return chars;
        }

        public static String ConsumeString(
            this Scanner scanner,
            int length)
        {
            var chars = scanner.Consume(length: length);

            if (chars.Length != length)
            {
                throw new Exception();
            }

            ///

            var maybeString = new String(chars);

            if (IsNullOrWhiteSpace(maybeString))
            {
                throw new Exception();
            }

            ///

            return maybeString;
        }

        public static Char Consume(
            this Scanner scanner, 
            Char c)
        {
            var next = scanner.Consume();

            if (next != c)
            {
                throw new Exception();
            }

            return next;
        }

        public static String Consume(
            this Scanner scanner, 
            String s)
        {
            var result = new StringBuilder();

            foreach (var c in s)
            {
                result.Append(scanner.Consume(c));
            }

            return result.ToString();
        }


        public static String Consume(
            this Scanner scanner, 
            Func<Char, bool> test)
        {
            var result = new StringBuilder();

            while (!scanner.IsEof() && test(scanner.RawNext()))
            {
                result.Append(scanner.Consume());
            }

            return result.ToString();
        }

        public static String ConsumeUntil(
            this Scanner scanner, 
            Func<Char, bool> test)
        {
            var result = new StringBuilder();

            while (!scanner.IsEof() && !test(scanner.RawNext()))
            {
                result.Append(scanner.Consume());
            }

            return result.ToString();
        }

        public static String ConsumeUntil(
            this Scanner scanner,
            String test)
        {
            var result = new StringBuilder();

            while (!scanner.IsEof() && !scanner.Next(equals: test))
            {
                result.Append(scanner.Consume());
            }

            return result.ToString();
        }

        public static String ConsumeUntilInclusive(
            this Scanner scanner,
            String test)
        {
            var result = new StringBuilder();

            while (!scanner.IsEof() && !scanner.Next(equals: test))
            {
                result.Append(scanner.Consume());
            }

            result.Append(scanner.Consume(test));

            return result.ToString();
        }

        public static String ConsumeWhitespace(
            this Scanner scanner)
        {
            return scanner.Consume(c => IsWhiteSpace(c));
        }

        public static String ConsumeUntilWhitespace(
            this Scanner scanner)
        {
            return scanner.ConsumeUntil(c => IsWhiteSpace(c));
        }

        public static String ConsumeSpaceOrTabs(
            this Scanner scanner)
        {
            return scanner.Consume(c => IsSpaceOrTabs(c));
        }

        public static String ConsumeZeroThruTen(
            this Scanner scanner)
        {
            return scanner.Consume(c => IsZeroThruTen(c));
        }
















        ///

        public static bool IsEof(
            this Scanner scanner)
        {
            return scanner.RawPosition == scanner.Source.Length;
        }

        ///

        public static char RawNext(
            this Scanner scanner)
        {
            return scanner.Source[scanner.RawPosition];
        }

        ///

        public static char? Next(
            this Scanner scanner)
        {
            if (scanner.IsEof())
            {
                return null;
            }

            return scanner.Source[scanner.RawPosition];
        }

        ///

        public static bool Next(
            this Scanner lexer, 
            String equals)
        {
            if (lexer.IsEof())
            {
                return false;
            }

            var start = lexer.RawPosition;

            var end = start + equals.Length;

            if (end >= lexer.Source.Length)
            {
                return false;
            }

            var next = lexer.Source.Substring(start, equals.Length);

            return next == equals;
        }

        ///

        public static bool Peek(
            this Scanner scanner,
            String equals)
        {
            if (scanner.IsEof())   
            {
                return false;
            }

            var start = scanner.RawPosition + 1;

            var end = start + equals.Length;

            if (end >= scanner.Source.Length)
            {
                return false;
            }

            var next = scanner.Source.Substring(start, equals.Length);

            return next == equals;
        }

        public static bool Peek(
            this Scanner lexer,
            Char equals)
        {
            if (lexer.IsEof())   
            {
                return false;
            }

            var n = lexer.RawPosition + 1;

            if (n >= lexer.Source.Length)
            {
                return false;
            }

            var next = lexer.Source[n];

            return next == equals;
        }

        ///

        public static bool PeekThenWhitespace(
            this Scanner scanner,
            String equals)
        {
            if (scanner.IsEof())   
            {
                return false;
            }

            var start = scanner.RawPosition + 1;

            var end = start + equals.Length;

            if (end >= scanner.Source.Length)
            {
                return false;
            }

            var next = scanner.Source.Substring(start, equals.Length);

            if (next != equals)
            {
                return false;
            }

            var possibleWhitespace = scanner.Source[end];

            return IsWhiteSpace(possibleWhitespace);
        }

        ///

        public static bool PeekThenDelimiter(
            this Scanner scanner,
            String equals,
            Func<char, bool> delimitedBy)
        {
            if (scanner.IsEof())   
            {
                return false;
            }

            var start = scanner.RawPosition + 1;

            var end = start + equals.Length;

            if (end >= scanner.Source.Length)
            {
                return false;
            }

            var next = scanner.Source.Substring(start, equals.Length);

            if (next != equals)
            {
                return false;
            }

            var possibleDelimiter = scanner.Source[end];

            return delimitedBy(possibleDelimiter);
        }

        ///

        public static bool PeekNumbersThenDelimiter(
            this Scanner scanner,
            Func<char, bool> delimitedBy)
        {
            if (scanner.IsEof())   
            {
                return false;
            }

            var pos = scanner.RawPosition + 1;

            var next = scanner.Source[pos];

            var digits = 0;

            while (pos < scanner.Source.Length)
            {
                if (!IsZeroThruTen(next))
                {
                    break;
                }

                digits++;

                pos++;

                next = scanner.Source[pos];
            }

            if (digits < 1)
            {
                return false;
            }

            return delimitedBy(next);
        }
    }
}