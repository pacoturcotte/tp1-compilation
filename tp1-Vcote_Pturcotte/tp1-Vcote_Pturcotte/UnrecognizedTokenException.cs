using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tp1_Vcote_Pturcotte
{
    class UnrecognizedTokenException : Exception
    {
        // Position dans le document où l'erreure s'est produite.
        public TokenPosition Position { get; }
        
        // Le symbol qui n'a pas été reconnu par les tokens
        public char Symbol { get; }

        public UnrecognizedTokenException(char symbol, TokenPosition position)
        {
            Position = position;
            Symbol = symbol;
        }

        public UnrecognizedTokenException(char symbol, TokenPosition position, string message)
            : base(message)
        {
            Position = position;
            Symbol = symbol;
        }

        public UnrecognizedTokenException(char symbol, TokenPosition position, string message, Exception innerException)
            : base(message, innerException)
        {
            Position = position;
            Symbol = symbol;
        }
    }
}
