using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tp1_Vcote_Pturcotte
{
    // Classe implémentée à l'aide du projet github suivant : https://github.com/mystborn/Lexer/blob/master/Myst.LexicalAnalysis/Token.cs (Auteur : mystborn)

    public class Token
    {
        // La position dans laquelle le Token a été trouvé dans le fichier C#
        public TokenPosition Position{get;}

        // Le type du Token
        public string Type { get; }

        // La valeur du Token
        public string Value { get; }

        // Constucteur par défaut du Token
        internal Token(string pType, string pValue, TokenPosition pPosition)
        {
            Type = pType;
            Value = pValue;
            Position = pPosition;
        }

        // Retourner la valeur, la position et le type du Token
        public override string ToString()
        {
            return "Token :" + Value + " Position : " + Position + " Type : " + Type;
        }
    }
}
