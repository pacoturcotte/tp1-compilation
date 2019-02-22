using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tp1_Vcote_Pturcotte
{
    // Classe implémentée à l'aide du projet github suivant : https://github.com/mystborn/Lexer/blob/master/Myst.LexicalAnalysis/TokenPosition.cs (Auteur : mystborn)

    // Cette classe permet de représenter la position du Token dans le fichier C# à lire
    public class TokenPosition
    {
      
        // Index du token dans le fichier C#
        public int Index { get; set; }

        // Constructeur de la position du Token
        internal TokenPosition(int index)
        {
            Index = index;
        }

        // Retourne la position d'un Token
        public override string ToString()
        {
            return $"Index du token: {Index}";
        }
    }
}
