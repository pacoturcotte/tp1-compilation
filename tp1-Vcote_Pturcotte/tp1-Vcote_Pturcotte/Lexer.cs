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


            int index = 0;
            int line = 1;
            int column = 0;
            // string[] splited = source.Split(';', ' ');
            char[] delimiters = new char[] {' ', '\n', '\r' };
            List<string> splited = source.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
            var i = 0;
            while (i < splited.Count)
            {
                TokenDefinition matchedDefinition = null;
                int matchLength = 0;

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
                        matchLength = match.Length +1;
                        if (rule.Type == "Terminaux")
                        {
                            matchLength--;
                        }
                        break;
                    }
                }

                if (matchedDefinition == null)
                {
                    FrmCompilateur frmTemp = (FrmCompilateur)FrmCompilateur;
                    frmTemp.ShowError("Erreur à l'index " + index + ", châine en conflit : " + splited[i]);
                    index++;
                }
                else
                {
                    yield return new Token(matchedDefinition.Type, splited[i], new TokenPosition(index));
                }

                index += matchLength;
                //if (matchedDefinition == null)
                //    throw new UnrecognizedTokenException(source[index], new TokenPosition(index, line, column),
                //        $"Unrecognized symbol '{source[index]}' at index {index} (line {line}, column {column})");

          //     var value = source.Substring(index, matchLength);
          //  
          //  if (matchedDefinition != null && !matchedDefinition.IsIgnored)
          //      yield return new Token(matchedDefinition.Type, value, new TokenPosition(index, line, column));
          //  
          //   var whitespace = _whiteSpace.Match(source, index + matchLength);
          //  
          //   if (whitespace.Success && whitespace.Length > 0)
          //   {
          //       if (!ignoreWhitespace)
          //           yield return new Token("Whitespace", whitespace.Value, new TokenPosition(whitespace.Index, line, column + matchLength));
          //  
          //       matchLength += whitespace.Length;
          //       var newLines = whitespace.Groups["NewLine"];
          //       if (newLines.Success)
          //       {
          //           line += newLines.Captures.Count;
          //           column = whitespace.Length - (whitespace.Value.LastIndexOf(newLines.Value) + 1);
          //       }
          //       else
          //           column += matchLength;
          //   }
          //   else
          //       column += matchLength;
          //  
          //   index += matchLength;
                i++;
            }

            yield return new Token(EoF, null, new TokenPosition(index));
        }
    }
}
