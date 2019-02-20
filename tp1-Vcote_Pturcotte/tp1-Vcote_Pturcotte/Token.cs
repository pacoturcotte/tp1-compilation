using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tp1_Vcote_Pturcotte
{
    public class Token
    {
        public TokenPosition Position{get;}

        public string Type { get; }

        public string Value { get; }

        internal Token(string pType, string pValue, TokenPosition pPosition)
        {
            Type = pType;
            Value = pValue;
            Position = pPosition;
        }


        public override string ToString()
        {
            return "Token :" + Value + " Position : " + Position + " Type : " + Type;
        }
    }
}
