using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace tp1_Vcote_Pturcotte
{
    // Classe implémentée à l'aide du projet github suivant : https://github.com/mystborn/Lexer/blob/master/Myst.LexicalAnalysis/TokenDefinition.cs

    // Cette classe permet de définir un Token. 
    public class TokenDefinition
    {
        // L'expression régulière qui est utilisée pour trouver un token
        public Regex Regex { get; set; }

        // Le type du token
        public string Type { get; set; }

        // Constructeur pour définir un token selon son regex et son type
        public TokenDefinition(string regex, string type)
            : this(new Regex(regex), type)
        { }

        // Constructeur de la définition du token. Permet de définir le token selon son regex et son type
        public TokenDefinition(Regex regex, string type)
        {
            Regex = regex;
            Type = type;
        }
    }
}
