using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace tp1_Vcote_Pturcotte
{
    public class Lexer
    {
        public const string EoF = "__0End__";
        public const string Whitespace = "Whitespace";
        private List<TokenDefinition> _definitions = new List<TokenDefinition>();
        private static Regex _whiteSpace = new Regex($@"((\r|\t|\v|\f| )*(?<NewLine>({Environment.NewLine}|\n)+)?)+", RegexOptions.Compiled);
        public Form FrmCompilateur;

        public Lexer()
        {

        }

        public Lexer(FrmCompilateur pFrmCompilateur)
        {
            FrmCompilateur = pFrmCompilateur;
        }
        //Constructeur de lexer, on lui envoie une liste d'enumerables de type TokenDefinition
        public Lexer(IEnumerable<TokenDefinition> definitions)
        {
            foreach (var def in definitions)
            {
                AddDefinition(def);
            }
        }

        //Permet d'ajouter les définitions à notre liste de type TokenDefinitions.
        //Celle-ci va être utile lorsque l'on parcoueras un fichier
        public void AddDefinition(TokenDefinition definition)
        {
            if (definition == null)
            {
                throw new ArgumentNullException("definition");
            }
            _definitions.Add(definition);
        }

        public IEnumerable<Token> Tokenize(string source, bool ignoreWhitespace = false)
        {
            int index = 1;
            char[] delimiters = new char[] {' ', '\n', '\r' };
            List<string> splited = source.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
            var i = 0;
            while (i < splited.Count)
            {
                TokenDefinition matchedDefinition = null;
                int matchLength = 0;
                //Pour chaque règle, on vérifie si le règle match avec la chaîne actuelle
                foreach (var rule in _definitions)
                {
                    string strToTest = splited[i];

                    if (strToTest.Length > 1 && strToTest[strToTest.Length - 1].Equals(';'))
                    {
                        splited[i] = (splited[i].Substring(0, splited[i].Length - 1));
                        splited.Insert(i+1, ";");
                    }
                    var match = rule.Regex.Match(splited[i]);
                    if (match.Success)
                    {
                        matchedDefinition = rule;
                        matchLength = match.Length+1;
                        //Si c'est un terminaux on enlève 1, car il ny a pas d'espace entre le terminaux et la chaîne avant
                        if (rule.Type == "Terminaux")
                        {
                            index--;
                            matchLength--;
                        }
                        break;
                    }
                }


                //Si aucun des regex ne match
                if (matchedDefinition == null)
                {
                    FrmCompilateur frmTemp = (FrmCompilateur)FrmCompilateur;
                    frmTemp.ShowError("Erreur à l'index " + index + ", châine en conflit : " + splited[i]);
                    index += splited[i].Length + 1;
                }
                else
                {
                    yield return new Token(matchedDefinition.Type, splited[i], new TokenPosition(index));
                }

                index += matchLength;
                i++;
            }

            yield return new Token(EoF, null, new TokenPosition(index));
        }
    }
}
