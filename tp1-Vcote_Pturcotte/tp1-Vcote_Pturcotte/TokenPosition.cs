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
        // Position du token sur la ligne de texte où il est trouvé
        public int Colonne { get; set; }

        // Index du token dans le fichier C#
        public int Index { get; set; }

        // Ligne où le token a été trouvé dans le fichier C#
        public int Ligne { get; set; }

        // Constructeur de la position du Token
        internal TokenPosition(int index, int ligne, int colonne)
        {
            Index = index;
            Ligne = ligne;
            Colonne = colonne;
        }

        // Retourne la position d'un Token
        public override string ToString()
        {
            return $"Position du Token: Ligne: {Ligne} | Colonne: {Colonne} | Index: {Index}";
        }
    }
}
