using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace tp1_Vcote_Pturcotte
{
    // Classe implémentée à l'aide du projet github suivant : https://github.com/mystborn/Lexer/blob/master/Myst.LexicalAnalysis/TokenDefinition.cs (Auteur : mystborn)

    // Cette classe permet de définir un Token. 
    public class TokenDefinition
    {
        // L'attribut sert a choisir si on retourne le type du token quand il est trouvé lors de la compilation.
        public bool IsIgnored { get; }

        // L'expression régulière qui est utilisée pour trouver un token
        public Regex Regex { get; set; }

        // Le type du token
        public string Type { get; set; }

        // Constructeur pour définir un token selon son regex et son type
        public TokenDefinition(string regex, string type, bool isIgnored)
            : this(new Regex(regex), type, isIgnored)
        { }

        // Constructeur de la définition du token. Permet de définir le token selon son regex et son type
        public TokenDefinition(Regex regex, string type, bool isIgnored)
        {
            Regex = regex;
            Type = type;
            IsIgnored = isIgnored;
        }
    }
}
